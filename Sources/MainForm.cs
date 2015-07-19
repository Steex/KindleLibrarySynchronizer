using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace KindleLibrarySynchronizer
{
	public partial class MainForm : Form
	{
		private LibraryInfo library;
		private BookComparer bookComparer;
		private List<string> errorInfoList;
		private Color[] logButtonColors;
		private LogLevel logLevel = LogLevel.Info;


		public MainForm()
		{
			InitializeComponent();

			Logger.OnWrite += (level, msg) => { textLog.AppendText(msg); UpdateLogButtonLevel(level); };
			Logger.OnClear += () => textLog.Clear();

			bookComparer = new BookComparer();
			synchroList.BookComparer = bookComparer;

			PopulateLibraryCombo();
			if (comboLibraries.Items.Count > 0)
			{
				comboLibraries.SelectedIndex = 0;
			}

			errorInfoList = new List<string>();
			logButtonColors = new Color[Enum.GetValues(typeof(LogLevel)).Length];
			logButtonColors[(int)LogLevel.Debug] = buttonToggleLogPane.BackColor;
			logButtonColors[(int)LogLevel.Info] = buttonToggleLogPane.BackColor;
			logButtonColors[(int)LogLevel.Warning] = Color.FromArgb(255, 240, 191);
			logButtonColors[(int)LogLevel.Error] = Color.FromArgb(255, 206, 206);

			InitializeActions();
		}


		private void PopulateLibraryCombo()
		{
			comboLibraries.BeginUpdate();

			comboLibraries.Items.Clear();
			foreach (LibraryInfo libraryInfo in Config.Main.Libraries)
			{
				comboLibraries.Items.Add(libraryInfo.Name);
			}

			comboLibraries.EndUpdate();
		}

		private void UpdateStatusCounters()
		{
			if (bookComparer.Library != null)
			{
				statusCounters.Text = string.Format("{0} actual, {1} new, {2} changed, {3} deleted",
					bookComparer.Books.GetBookStateCount(BookState.Actual),
					bookComparer.Books.GetBookStateCount(BookState.New),
					bookComparer.Books.GetBookStateCount(BookState.Changed),
					bookComparer.Books.GetBookStateCount(BookState.Deleted));
			}
			else
			{
				statusCounters.Text = "";
			}
		}


		private void synchroList_SelectionChanged(object sender, EventArgs e)
		{
			int selectedCount = synchroList.SelectedBooks.Count();
			string textTemplate = (selectedCount == 1) ? "{0} book selected" : "{0} books selected";
			statusSelection.Text = string.Format(textTemplate, selectedCount);

			Action.UpdateActions(EventArgs.Empty);
		}

		private void comboLibraries_SelectedIndexChanged(object sender, EventArgs e)
		{
			string libraryName = (string)comboLibraries.SelectedItem;

			library = Config.Main.Libraries.Find(l => l.Name == libraryName);
		}

		private void textLog_DoubleClick(object sender, EventArgs e)
		{
			string clickedLine = textLog.Lines[textLog.GetLineFromCharIndex(textLog.SelectionStart)];

			Match errorLink = Regex.Match(clickedLine, "LOG#([0-9]+)");
			if (errorLink != null)
			{
				try
				{
					int errorIndex = int.Parse(errorLink.Groups[1].Value);
					MessageBox.Show(this, errorInfoList[errorIndex - 1], "Log");
				}
				catch
				{
					// just ignore this error
				}
			}
		}


		private void ConvertBooks(IEnumerable<BookInfo> books)
		{
			Logger.WriteLine("Converting {0} books", books.Count());

			// Create a worker and show the conversion progress.
			using (BackgroundWorker worker = BookOperations.CreateConverter())
			using (OperationProgressForm progressForm = new OperationProgressForm(worker, new BookOperations.OperationData("Conversion", books)))
			{
				worker.ProgressChanged += ConvertWorker_ProgressChanged;
				worker.RunWorkerCompleted += ConvertWorker_RunWorkerCompleted;

				progressForm.ShowDialog(this);
			}

			// Update the list.
			bookComparer.Compare(
				synchroList.TopLevelSelectedItems.Where(i => i.Folder != null).Select(i => i.Folder),
				synchroList.TopLevelSelectedItems.Where(i => i.Book != null).Select(i => i.Book));
			synchroList.UpdateItems(true);
		}

		private void ConvertWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState is BookOperations.StepInfo)
			{
				BookOperations.StepInfo info = (BookOperations.StepInfo)e.UserState;
				Logger.Write(info.Book.SourceName + "... ");
			}
			else if (e.UserState is BookOperations.StepResult)
			{
				BookOperations.StepResult result = (BookOperations.StepResult)e.UserState;
				if (result.Succeeded)
				{
					if (string.IsNullOrWhiteSpace(result.ErrorText))
					{
						Logger.WriteLine("OK");
					}
					else
					{
						Logger.WriteWarning("Done with warnings. Double-click this line to see the full info (LOG#{0})", CreateErrorInfo(result.ErrorText));
					}
				}
				else
				{
					Logger.WriteError("Failed! Double-click this line to see the full info (LOG#{0})", CreateErrorInfo(result.ErrorText));
					Logger.WriteError(">> Error message: \"{0}\"", Utils.ExtractFirstLine(result.ErrorText));
				}
			}
		}

		private void ConvertWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Logger.WriteLine("Conversion complete");
			Logger.WriteLine("---");
		}


		private void DeleteBooks(IEnumerable<BookInfo> books)
		{
			Logger.WriteLine("Deleting {0} books", books.Count());

			// Create a worker and show the conversion progress.
			using (BackgroundWorker worker = BookOperations.CreateDeleter())
			using (OperationProgressForm progressForm = new OperationProgressForm(worker, new BookOperations.OperationData("Delete", books)))
			{
				worker.ProgressChanged += DeleteWorker_ProgressChanged;
				worker.RunWorkerCompleted += DeleteWorker_RunWorkerCompleted;

				progressForm.ShowDialog(this);
			}

			// Update the list.
			bookComparer.Compare(
				synchroList.TopLevelSelectedItems.Where(i => i.Folder != null).Select(i => i.Folder),
				synchroList.TopLevelSelectedItems.Where(i => i.Book != null).Select(i => i.Book));
			synchroList.UpdateItems(true);
		}

		private void DeleteWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState is BookOperations.StepInfo)
			{
				BookOperations.StepInfo info = (BookOperations.StepInfo)e.UserState;
				Logger.Write(info.Book.TargetName + "... ");
			}
			else if (e.UserState is BookOperations.StepResult)
			{
				BookOperations.StepResult result = (BookOperations.StepResult)e.UserState;
				if (result.Succeeded)
				{
					if (string.IsNullOrWhiteSpace(result.ErrorText))
					{
						Logger.WriteLine("OK");
					}
					else
					{
						Logger.WriteWarning("Done with warnings. Double-click this line to see the full info (LOG#{0})", CreateErrorInfo(result.ErrorText));
					}
				}
				else
				{
					Logger.WriteError("Failed! Double-click this line to see the full info (LOG#{0})", CreateErrorInfo(result.ErrorText));
					Logger.WriteError(">> Error message: \"{0}\"", Utils.ExtractFirstLine(result.ErrorText));
				}
			}
		}

		private void DeleteWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Logger.WriteLine("Deleting complete");
			Logger.WriteLine("---");
		}


		private void OpenPath(string path)
		{
			if (File.Exists(path) || Directory.Exists(path))
			{
				ProcessStartInfo processInfo = new ProcessStartInfo();
				processInfo.FileName = path;
				Process.Start(processInfo);
			}
			else
			{
				ExplorePath(path);
			}
		}

		private void ExplorePath(string path)
		{
			ProcessStartInfo processInfo = new ProcessStartInfo();
			processInfo.FileName = "explorer";
			processInfo.Arguments = string.Format("/select,{0}", path);
			Process.Start(processInfo);
		}


		private int CreateErrorInfo(string errorText)
		{
			errorInfoList.Add(errorText);
			return errorInfoList.Count();
		}

		private void UpdateLogButtonLevel(LogLevel level)
		{
			if (!buttonToggleLogPane.Checked &&
				logLevel < level)
			{
				logLevel = level;
				buttonToggleLogPane.BackColor = logButtonColors[(int)logLevel];
			}
		}

		private void ResetLogButtonLevel()
		{
			logLevel = LogLevel.Info;
			buttonToggleLogPane.BackColor = logButtonColors[(int)logLevel];
		}

	}

}
