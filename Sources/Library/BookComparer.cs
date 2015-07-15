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

		public LibraryInfo Library { get; private set; }
		public BookFolder Books { get; private set; }
		public bool SkipIgnoredBooks { get; set; }


		public BookComparer()
		{
			Books = new BookFolder(null, "");
			SkipIgnoredBooks = true;
		}


		public void Compare()
		{
			// Make sure the library is set.
			if (Library == null)
			{
				return;
			}


			Books = new BookFolder(null, "");

			SortedSet<string> targetPaths = new SortedSet<string>();

			// Collect source books.
			foreach (string sourceFile in FindBookFiles(Library.SourceRoot, sourceFileMask))
			{
				try
				{
					string sourcePath = Path.Combine(Library.SourceRoot, sourceFile);
					string targetDir = Path.Combine(Library.TargetRoot, Path.GetDirectoryName(sourceFile));

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
			foreach (string targetFile in FindBookFiles(Library.TargetRoot, targetFileMask))
			{
				string targetPath = Path.Combine(Library.TargetRoot, targetFile);

				if (!targetPaths.Contains(targetPath.ToLower()))
				{
					BookInfo bookInfo = BookInfo.CreateFromTarget(targetPath);

					Books.AddBook(bookInfo, targetFile);
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
			}

			// Count book states in each folder.
			Books.CountStates();
		}

		public void Compare(LibraryInfo library)
		{
			Library = library;
			Compare();
		}


		private IEnumerable<string> FindBookFiles(string root, string mask)
		{
			foreach (string targetFile in Directory.GetFiles(root, mask, SearchOption.AllDirectories))
			{
				string basePath = Utils.GetRelativePath(targetFile, root);
				if (!SkipIgnoredBooks || !IsPathIgnored(basePath))
				{
					yield return Utils.GetRelativePath(targetFile, root);
				}
			}
		}

		private bool IsPathIgnored(string path)
		{
			return Library.IgnoredFiles.Any(f => path.StartsWith(f, StringComparison.CurrentCultureIgnoreCase));
		}
	}
}
