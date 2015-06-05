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


			string sourceRoot = textSourceRoot.Text;
			string targetRoot = textTargetRoot.Text;

			List<BookInfo> books = new List<BookInfo>();
			SortedSet<string> targetPaths = new SortedSet<string>();

			// Collect source books.
			foreach (string sourceFile in FindBookFiles(sourceRoot, "*.fb2"))
			{
				try
				{
					string sourcePath = Path.Combine(sourceRoot, sourceFile);
					string targetDir = Path.Combine(targetRoot, Path.GetDirectoryName(sourceFile));

					BookInfo bookInfo = BookInfo.CreateFromSource(sourcePath, targetDir);
					books.Add(bookInfo);
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
				catch (Exception ex)
				{
					Logger.WriteLine("FB2 error in file {0}: {1}", sourceFile, ex.Message);
					continue;
				}
			}

			// Collect unknown target books.
			foreach (string targetFile in FindBookFiles(targetRoot, "*.pdf"))
			{
				string targetPath = Path.Combine(targetRoot, targetFile);

				if (!targetPaths.Contains(targetPath.ToLower()))
				{
					BookInfo bookInfo = BookInfo.CreateFromTarget(targetPath);

					books.Add(bookInfo);
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
			}

			// Report.
			foreach (BookInfo book in books)
			{
				if (book.State == BookState.Changed)
				{
					Logger.WriteLine("Changed: {0}", book.TargetPath);
				}
			}

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.Deleted)
				{
					Logger.WriteLine("Deleted: {0}", book.TargetPath);
				}
			}

			foreach (BookInfo book in books)
			{
				if (book.State == BookState.New)
				{
					Logger.WriteLine("New: {0}", book.TargetPath);
				}
			}

			textLog.AppendText("---");
		}


		private IEnumerable<string> FindBookFiles(string root, string mask)
		{
			List<string> files = new List<string>();

			foreach (string targetFile in Directory.GetFiles(root, mask, SearchOption.AllDirectories))
			{
				string basePath = Utils.GetRelativePath(targetFile, root);

				if (!skippedFiles.Any(f => basePath.StartsWith(f, StringComparison.CurrentCultureIgnoreCase)))
				{
					yield return basePath;
				}
			}
		}
	}

}
