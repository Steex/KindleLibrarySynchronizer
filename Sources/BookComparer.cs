using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KindleLibrarySynchronizer
{
	public class BookComparer
	{
		private readonly string sourceFileMask = "*.fb2";
		private readonly string targetFileMask = "*.pdf";

		public string SourceRoot { get; private set; }
		public string TargetRoot { get; private set; }
		public List<string> SkippedFiles { get; private set; }
		public BookFolder Books { get; private set; }


		public BookComparer(string sourceRoot, string targetRoot, IEnumerable<string> skippedFiles)
		{
			SourceRoot = sourceRoot;
			TargetRoot = targetRoot;
			SkippedFiles = new List<string>(skippedFiles);
			Books = new BookFolder(null, "");

			SortedSet<string> targetPaths = new SortedSet<string>();

			// Collect source books.
			foreach (string sourceFile in FindBookFiles(sourceRoot, sourceFileMask))
			{
				try
				{
					string sourcePath = Path.Combine(sourceRoot, sourceFile);
					string targetDir = Path.Combine(targetRoot, Path.GetDirectoryName(sourceFile));

					BookInfo bookInfo = BookInfo.CreateFromSource(sourcePath, targetDir);

					Books.AddBook(bookInfo, Path.Combine(Path.GetDirectoryName(sourceFile), bookInfo.PdfTitle));
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
				catch (Exception ex)
				{
					Logger.WriteLine("FB2 error in file {0}: {1}", sourceFile, ex.Message);
					continue;
				}
			}

			// Collect unknown target books.
			foreach (string targetFile in FindBookFiles(targetRoot, targetFileMask))
			{
				string targetPath = Path.Combine(targetRoot, targetFile);

				if (!targetPaths.Contains(targetPath.ToLower()))
				{
					BookInfo bookInfo = BookInfo.CreateFromTarget(targetPath);

					Books.AddBook(bookInfo, targetFile);
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
			}
		}

		private IEnumerable<string> FindBookFiles(string root, string mask)
		{
			foreach (string targetFile in Directory.GetFiles(root, mask, SearchOption.AllDirectories))
			{
				string basePath = Utils.GetRelativePath(targetFile, root);

				if (!SkippedFiles.Any(f => basePath.StartsWith(f, StringComparison.CurrentCultureIgnoreCase)))
				{
					yield return basePath;
				}
			}
		}
	}
}
