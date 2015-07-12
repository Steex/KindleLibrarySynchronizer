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

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			//using (OperationProgressForm progressForm = new OperationProgressForm())
			//{
			//    progressForm.ShowDialog(this);
			//}


			// Create book list.
			List<BookInfo> books = new List<BookInfo>();

			foreach (string file in Directory.GetFiles(@"E:\L2\Публицистика\_Дневники, биографии", "*.fb2"))
			{
				string fullPath = Path.GetFullPath(file);
				books.Add(BookInfo.CreateFromSource(fullPath, Path.GetDirectoryName(fullPath)));
			}

			// Start the worker.
			using (BackgroundWorker worker = BookOperations.CreateConverter())
			{
				worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
				worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

				worker.RunWorkerAsync(books);
			}
		}

		void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState is OperationStepInfo)
			{
				OperationStepInfo info = (OperationStepInfo)e.UserState;
				Logger.WriteLine("Conversion: {0}% done, next book: {1}", e.ProgressPercentage, info.Book.SourceName);
			}
			else if (e.UserState is OperationStepResult)
			{
				OperationStepResult result = (OperationStepResult)e.UserState;
				if (!result.Succeeded)
				{
					Logger.WriteLine("Conversion error: {0}", result.ErrorText);
				}
			}
		}

		void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Logger.WriteLine("Conversion complete!");
		}

	}

}
