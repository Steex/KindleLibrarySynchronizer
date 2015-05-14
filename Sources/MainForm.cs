using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aliasworlds;

namespace KindleLibrarySynchronizer
{
	public partial class MainForm : Form
	{
		private List<string> skippedFiles = new List<string>();

		public MainForm()
		{
			InitializeComponent();

			skippedFiles.Add("Разное\\Эти странные…\\");
			skippedFiles.Add("Художественная\\_Не оформленное\\");
			skippedFiles.Add("Художественная\\_Периодика\\");
		}

		private void buttonCompare_Click(object sender, EventArgs e)
		{
			// Collect book files.
			SortedSet<string> sourceFiles = new SortedSet<string>();

			sourceFiles.UnionWith(FindBookFiles(textSourceRoot.Text, "*.fb2"));
			sourceFiles.UnionWith(FindBookFiles(textTargetRoot.Text, "*.fb2"));

			// Compare books.
			List<BookInfo> books = new List<BookInfo>();

			foreach (string sourceFile in sourceFiles)
			{
				string sourceBookPath = Path.Combine(textSourceRoot.Text, sourceFile) + ".fb2";
				string targetBookPath = Path.Combine(textTargetRoot.Text, sourceFile) + ".fb2";
				books.Add(new BookInfo(sourceBookPath, targetBookPath));
			}

			// Report.
			textLog.Clear();

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.Changed)
				{
					textLog.AppendText(string.Format("Changed: {0}\r\n", book.SourcePath));
				}
			}

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.Deleted)
				{
					textLog.AppendText(string.Format("Deleted: {0}\r\n", book.SourcePath));
				}
			}

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.New)
				{
					textLog.AppendText(string.Format("New: {0}\r\n", book.SourcePath));
				}
			}

			textLog.AppendText("---");
		}

		private IEnumerable<string> FindBookFiles(string root, string mask)
		{
			List<string> files = new List<string>();

			foreach (string targetFile in Directory.GetFiles(root, mask, SearchOption.AllDirectories))
			{
				string basePath = Utils.RemoveExtension(Utils.GetRelativePath(targetFile, root));

				if (!skippedFiles.Any(f => basePath.StartsWith(f, StringComparison.CurrentCultureIgnoreCase)))
				{
					yield return basePath;
				}
			}
		}
	}

}
