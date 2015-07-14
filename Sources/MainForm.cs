using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KindleLibrarySynchronizer
{
	public partial class MainForm : Form
	{
		private LibraryInfo library;
		private BookComparer bookComparer;

		public MainForm()
		{
			InitializeComponent();

			Logger.OnWrite += (msg) => textLog.AppendText(msg);
			Logger.OnClear += () => textLog.Clear();

			bookComparer = new BookComparer();
			synchroList.BookComparer = bookComparer;

			PopulateLibraryCombo();
			if (comboLibraries.Items.Count > 0)
			{
				comboLibraries.SelectedIndex = 0;
			}

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


		private void ConvertBooks(IEnumerable<BookInfo> books)
		{
			// Create a worker and show the conversion progress.
			using (BackgroundWorker worker = BookOperations.CreateConverter())
			using (OperationProgressForm progressForm = new OperationProgressForm(worker, new BookOperations.OperationData("Conversion", books)))
			{
				worker.ProgressChanged += ConvertWorker_ProgressChanged;
				worker.RunWorkerCompleted += ConvertWorker_RunWorkerCompleted;

				progressForm.ShowDialog(this);
			}
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
					Logger.WriteLine("OK");
				}
				else
				{
					Logger.WriteLine("Failed!");
					Logger.WriteLine(">> Error message: \"{0}\"", result.ErrorText);
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
			// Create a worker and show the conversion progress.
			using (BackgroundWorker worker = BookOperations.CreateDeleter())
			using (OperationProgressForm progressForm = new OperationProgressForm(worker, new BookOperations.OperationData("Delete", books)))
			{
				worker.ProgressChanged += DeleteWorker_ProgressChanged;
				worker.RunWorkerCompleted += DeleteWorker_RunWorkerCompleted;

				progressForm.ShowDialog(this);
			}
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
					Logger.WriteLine("OK");
				}
				else
				{
					Logger.WriteLine("Failed!");
					Logger.WriteLine(">> Error message: \"{0}\"", result.ErrorText);
				}
			}
		}

		private void DeleteWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Logger.WriteLine("Deleting complete");
			Logger.WriteLine("---");
		}

	}

}
