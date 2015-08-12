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

			// Compare files in the root folder.
			Books = new BookFolder(null, "");
			CompareFolder(Books.Path);

			// Count book states in each folder.
			Books.CountStates();
		}

		public void Compare(LibraryInfo library)
		{
			Library = library;
			Compare();
		}

		public void Compare(IEnumerable<BookFolder> folders, IEnumerable<BookInfo> books)
		{
			if (folders != null)
			{
				foreach (BookFolder folder in folders)
				{
					Books.RemoveFolder(folder.Path);
					CompareFolder(folder.Path);
				}
			}

			if (books != null)
			{
				foreach (BookInfo book in books)
				{
					string bookPath = Utils.GetRelativePath(book.TargetPath, Library.TargetRoot);
					Books.RemoveBook(bookPath);
					CompareBook(book.SourcePath, book.TargetPath);
				}
			}

			// Count book states in each folder.
			Books.CountStates();
		}

		private void CompareFolder(string folderPath)
		{
			SortedSet<string> targetPaths = new SortedSet<string>();

			// Collect source books.
			foreach (string sourceFile in FindBookFiles(Library.SourceRoot, folderPath, sourceFileMask))
			{
				try
				{
					string sourcePath = Path.Combine(Library.SourceRoot, sourceFile);
					string targetDir = Path.Combine(Library.TargetRoot, Path.GetDirectoryName(sourceFile));

					BookInfo bookInfo = BookInfo.CreateFromSource(sourcePath, targetDir);

					Books.AddBook(bookInfo, Utils.GetRelativePath(bookInfo.TargetPath, Library.TargetRoot));
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
				catch (Exception ex)
				{
					Logger.WriteError("FB2 error in file {0}: {1}", sourceFile, ex.Message);
					continue;
				}
			}

			// Collect unknown target books.
			foreach (string targetFile in FindBookFiles(Library.TargetRoot, folderPath, targetFileMask))
			{
				string targetPath = Path.Combine(Library.TargetRoot, targetFile);

				if (!targetPaths.Contains(targetPath.ToLower()))
				{
					BookInfo bookInfo = BookInfo.CreateFromTarget(targetPath);

					Books.AddBook(bookInfo, targetFile);
					targetPaths.Add(bookInfo.TargetPath.ToLower());
				}
			}
		}

		private void CompareBook(string sourcePath, string targetPath)
		{
			BookInfo bookInfo = null;

			if (File.Exists(sourcePath))
			{
				bookInfo = BookInfo.CreateFromSource(sourcePath, Path.GetDirectoryName(targetPath));
			}
			else if (File.Exists(targetPath))
			{
				bookInfo = BookInfo.CreateFromTarget(targetPath);
			}

			if (bookInfo != null)
			{
				Books.AddBook(bookInfo, Utils.GetRelativePath(bookInfo.TargetPath, Library.TargetRoot));
			}
		}


		private IEnumerable<string> FindBookFiles(string root, string folder, string mask)
		{
			string directory = Path.Combine(root, folder);

			// Make sure the directory exists.
			if (!Directory.Exists(directory))
			{
				yield break;
			}

			// Iterate through all files in the directory.
			foreach (string bookFile in Directory.GetFiles(directory, mask, SearchOption.AllDirectories))
			{
				string basePath = Utils.GetRelativePath(bookFile, root);
				if (!SkipIgnoredBooks || !IsPathIgnored(basePath))
				{
					yield return basePath;
				}
			}
		}

		private bool IsPathIgnored(string path)
		{
			return Library.IgnoredFiles.Any(f => path.StartsWith(f, StringComparison.CurrentCultureIgnoreCase));
		}
	}
}
