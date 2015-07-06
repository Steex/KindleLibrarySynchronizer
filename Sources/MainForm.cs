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
		private List<string> skippedFiles = new List<string>();
		private BookComparer bookComparer;

		public MainForm()
		{
			InitializeComponent();
			InitializeActions();

			Logger.OnWrite += (msg) => textLog.AppendText(msg);
			Logger.OnClear += () => textLog.Clear();

			skippedFiles.Add("Разное\\Эти странные…\\");
			skippedFiles.Add("Художественная\\_Не оформленное\\");
			skippedFiles.Add("Художественная\\_Периодика\\");

			bookComparer = new BookComparer(textSourceRoot.Text, textTargetRoot.Text, skippedFiles);
			synchroList.BookComparer = bookComparer;
		}

		private void buttonCompare_Click(object sender, EventArgs e)
		{
			Logger.Clear();

			bookComparer.Compare();
			synchroList.UpdateItems();

			// Report.
			foreach (BookInfo book in bookComparer.Books.AllBooks)
			{
				Logger.WriteLine("{0}:\t{1}",
					book.State.ToString()[0],
					Utils.GetRelativePath(book.TargetPath, bookComparer.TargetRoot));
			}

			Logger.WriteLine();
			Logger.WriteLine("{0} actual, {1} new, {2} changed, {3} deleted",
				bookComparer.Books.GetBookStateCount(BookState.Actual),
				bookComparer.Books.GetBookStateCount(BookState.New),
				bookComparer.Books.GetBookStateCount(BookState.Changed),
				bookComparer.Books.GetBookStateCount(BookState.Deleted));
			Logger.WriteLine("---");
		}

		private void synchroList_SelectionChanged(object sender, EventArgs e)
		{
			labelSelection.Text = string.Format("{0} books is selected", synchroList.SelectedBooks.Count());
			Action.UpdateActions(EventArgs.Empty);
		}

	}

}
