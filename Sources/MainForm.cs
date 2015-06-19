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

			BookFolder books = new BookFolder(null, "");
			SortedSet<string> targetPaths = new SortedSet<string>();

			// Collect source books.
			foreach (string sourceFile in FindBookFiles(sourceRoot, "*.fb2"))
			{
				try
				{
					string sourcePath = Path.Combine(sourceRoot, sourceFile);
					string targetDir = Path.Combine(targetRoot, Path.GetDirectoryName(sourceFile));

					BookInfo bookInfo = BookInfo.CreateFromSource(sourcePath, targetDir);
					books.AddBook(bookInfo, Path.Combine(Path.GetDirectoryName(sourceFile), bookInfo.PdfTitle));
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

					books.AddBook(bookInfo, targetFile);
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
			}

			// Report.
			foreach (BookInfo book in books.AllBooks)
			{
				Logger.WriteLine("{0}:\t{1}", book.State.ToString()[0], Utils.GetRelativePath(book.TargetPath, targetRoot));
			}

			textLog.AppendText("---");

			// Fill trees
			treeSource.BeginUpdate();
			treeTarget.BeginUpdate();

			treeSource.Nodes.Clear();
			treeTarget.Nodes.Clear();


			var folderStack = new Stack<BookFolder>();
			var enumeratorStack = new Stack<IEnumerator<BookFolder>>();
			var sourceNodesStack = new Stack<TreeNodeCollection>();
			var targetNodesStack = new Stack<TreeNodeCollection>();

			folderStack.Push(books);
			enumeratorStack.Push(books.Folders.GetEnumerator());
			sourceNodesStack.Push(treeSource.Nodes);
			targetNodesStack.Push(treeTarget.Nodes);

			while (folderStack.Count > 0)
			{
				BookFolder folder = folderStack.Peek();
				IEnumerator<BookFolder> enumerator = enumeratorStack.Peek();
				TreeNodeCollection sourceNodes = sourceNodesStack.Peek();
				TreeNodeCollection targetNodes = targetNodesStack.Peek();

				if (enumerator.MoveNext())
				{
					folderStack.Push(enumerator.Current);
					enumeratorStack.Push(enumerator.Current.Folders.GetEnumerator());
					sourceNodesStack.Push(sourceNodes.Add(enumerator.Current.Name).Nodes);
					targetNodesStack.Push(targetNodes.Add(enumerator.Current.Name).Nodes);
				}
				else
				{
					folderStack.Pop();
					enumeratorStack.Pop();
					sourceNodesStack.Pop();
					targetNodesStack.Pop();

					foreach (BookInfo book in folder.Books)
					{
						switch (book.State)
						{
							case BookState.Actual:
								sourceNodes.Add(Utils.GetRelativePath(book.SourcePath, sourceRoot)).ForeColor = Color.Black;
								targetNodes.Add(Utils.GetRelativePath(book.TargetPath, targetRoot)).ForeColor = Color.Black;
								break;

							case BookState.New:
								sourceNodes.Add(Utils.GetRelativePath(book.SourcePath, sourceRoot)).ForeColor = Color.Blue;
								targetNodes.Add(Utils.GetRelativePath(book.TargetPath, targetRoot)).ForeColor = Color.Blue;
								break;

							case BookState.Changed:
								sourceNodes.Add(Utils.GetRelativePath(book.SourcePath, sourceRoot)).ForeColor = Color.DarkGreen;
								targetNodes.Add(Utils.GetRelativePath(book.TargetPath, targetRoot)).ForeColor = Color.DarkGreen;
								break;

							case BookState.Deleted:
								sourceNodes.Add(Utils.GetRelativePath(book.SourcePath, sourceRoot)).ForeColor = Color.Silver;
								targetNodes.Add(Utils.GetRelativePath(book.TargetPath, targetRoot)).ForeColor = Color.Red;
								break;
						}
					}
				}
			}

			treeSource.EndUpdate();
			treeTarget.EndUpdate();
		}


		private IEnumerable<string> FindBookFiles(string root, string mask)
		{
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
