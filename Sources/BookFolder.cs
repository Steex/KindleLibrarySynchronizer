using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace KindleLibrarySynchronizer
{
	public class BookFolder
	{
		private SortedDictionary<string, BookFolder> folders;
		private SortedDictionary<string, BookInfo> books;

		public string Name { get; private set; }
		public string Path { get; private set; }
		public BookFolder Parent { get; private set; }
		public IEnumerable<BookFolder> Folders { get { return folders.Values; } }
		public IEnumerable<BookInfo> Books { get { return books.Values; } }
		public IEnumerable<BookInfo> AllBooks
		{
			get 
			{
				foreach (BookFolder folder in Folders)
				{
					foreach (BookInfo book in folder.AllBooks)
					{
						yield return book;
					}
				}

				foreach (BookInfo book in Books)
				{
					yield return book;
				}
			}
		}


		public BookFolder(BookFolder parent, string name)
		{
			Name = name;
			Path = parent != null ? parent.Path + "/" + name : name;
			Parent = parent;
			folders = new SortedDictionary<string, BookFolder>();
			books = new SortedDictionary<string, BookInfo>();
		}


		public void AddBook(BookInfo book, string path)
		{
			int separatorPos = path.IndexOfAny(Utils.DirectorySeparators);
			if (separatorPos == 0)
			{
				// ignore separators at path start
				AddBook(book, path.Substring(1));
			}
			else if (separatorPos == -1)
			{
				// the path is a file name
				if (!books.ContainsKey(path))
				{
					books.Add(path, book);
				}
			}
			else
			{
				// the path contains folders
				string folderName = path.Substring(0, separatorPos);
				string innerPath = path.Substring(separatorPos + 1);
				if (!folders.ContainsKey(folderName))
				{
					folders.Add(folderName, new BookFolder(this, folderName));
				}

				folders[folderName].AddBook(book, innerPath);
			}
		}

	}

}
