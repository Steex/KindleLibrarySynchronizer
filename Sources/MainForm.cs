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

		public MainForm()
		{
			InitializeComponent();

			Logger.OnWrite += (msg) => textLog.AppendText(msg);
			Logger.OnClear += () => textLog.Clear();

			skippedFiles.Add("Разное\\Эти странные…\\");
			skippedFiles.Add("Художественная\\_Не оформленное\\");
			skippedFiles.Add("Художественная\\_Периодика\\");
		}

		private void buttonCompare_Click(object sender, EventArgs e)
		{
			Logger.Clear();

			BookComparer bookComparer = new BookComparer(textSourceRoot.Text, textTargetRoot.Text, skippedFiles);
			synchroView.BookComparer = bookComparer;

			// Report.
			foreach (BookInfo book in bookComparer.Books.AllBooks)
			{
				Logger.WriteLine("{0}:\t{1}",
					book.State.ToString()[0],
					Utils.GetRelativePath(book.TargetPath, bookComparer.TargetRoot));
			}

			textLog.AppendText("---");
		}

	}

}
