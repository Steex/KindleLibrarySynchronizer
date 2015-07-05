using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KindleLibrarySynchronizer
{
	public partial class SynchroList : UserControl
	{
		private BookComparer bookComparer;

		private bool[] showState;

		private float treeSplitCoeff = 0.5f;

		[Browsable(false)]
		public BookComparer BookComparer
		{
			get
			{
				return bookComparer;
			}
			set
			{
				if (bookComparer != value)
				{
					bookComparer = value;
					OnBookComparerChanged(EventArgs.Empty);
				}
			}
		}

		[Category("Book States")]
		public bool ShowActualBooks
		{
			get
			{
				return showState[(int)BookState.Actual];
			}
			set
			{
				if (showState[(int)BookState.Actual] != value)
				{
					showState[(int)BookState.Actual] = value;
					OnShowStateChanged(EventArgs.Empty);
				}
			}
		}

		[Category("Book States")]
		public bool ShowNewBooks
		{
			get
			{
				return showState[(int)BookState.New];
			}
			set
			{
				if (showState[(int)BookState.New] != value)
				{
					showState[(int)BookState.New] = value;
					OnShowStateChanged(EventArgs.Empty);
				}
			}
		}

		[Category("Book States")]
		public bool ShowChangedBooks
		{
			get
			{
				return showState[(int)BookState.Changed];
			}
			set
			{
				if (showState[(int)BookState.Changed] != value)
				{
					showState[(int)BookState.Changed] = value;
					OnShowStateChanged(EventArgs.Empty);
				}
			}
		}

		[Category("Book States")]
		public bool ShowDeletedBooks
		{
			get
			{
				return showState[(int)BookState.Deleted];
			}
			set
			{
				if (showState[(int)BookState.Deleted] != value)
				{
					showState[(int)BookState.Deleted] = value;
					OnShowStateChanged(EventArgs.Empty);
				}
			}
		}


		public SynchroList()
		{
			InitializeComponent();

			showState = new bool[Enum.GetValues(typeof(BookState)).Length];
			for (int i = 0; i < showState.Length; ++i)
			{
				showState[i] = true;
			}
		}


		protected override void OnSizeChanged(EventArgs args)
		{
			base.OnSizeChanged(args);

			columnHeader5.Width = (int)(listview.ClientSize.Width * treeSplitCoeff);
			columnHeader6.Width = listview.ClientSize.Width - columnHeader5.Width;
		}


		protected virtual void OnBookComparerChanged(EventArgs args)
		{
			FillTrees();
		}

		protected virtual void OnShowStateChanged(EventArgs args)
		{
			FillTrees();
		}


		private void FillTrees()
		{
			listview.BeginUpdate();

			// Clear existing items.
			listview.Items.Clear();

			// Fill new items.
			var folderStack = new Stack<BookFolder>();
			var enumeratorStack = new Stack<IEnumerator<BookFolder>>();

			folderStack.Push(BookComparer.Books);
			enumeratorStack.Push(BookComparer.Books.Folders.GetEnumerator());

			while (folderStack.Count > 0)
			{
				BookFolder folder = folderStack.Peek();
				IEnumerator<BookFolder> enumerator = enumeratorStack.Peek();

				if (enumerator.MoveNext())
				{
					// Skip the folder if it does not contain books to display.
					bool containsDisplayableBooks = false;
					foreach (BookState state in Enum.GetValues(typeof(BookState)))
					{
						bool showThisState = showState[(int)state];
						bool haveThisState = enumerator.Current.GetBookStateCount(state) > 0;
						containsDisplayableBooks = containsDisplayableBooks | (showThisState && haveThisState);
					}

					if (!containsDisplayableBooks)
					{
						continue;
					}

					// Create the folder item.
					string prefix = new string(' ', (folderStack.Count - 1) * 4);

					ListViewItem item = listview.Items.Add("folder");
					item.SubItems.Add(prefix + enumerator.Current.Name);
					item.SubItems.Add(prefix + enumerator.Current.Name);
					item.Tag = new ListItemInfo(enumerator.Current, null);
					item.UseItemStyleForSubItems = false;

					folderStack.Push(enumerator.Current);
					enumeratorStack.Push(enumerator.Current.Folders.GetEnumerator());
				}
				else
				{
					folderStack.Pop();
					enumeratorStack.Pop();

					foreach (BookInfo book in folder.Books)
					{
						// Skip books of disabled states.
						if (!showState[(int)book.State])
						{
							continue;
						}

						// Create the book item.
						string prefix = new string(' ', (folderStack.Count) * 4);

						ListViewItem item = listview.Items.Add("file");
						Color sourceColor = item.ForeColor;
						Color targetColor = item.ForeColor;
						Color backColor = item.BackColor;

						switch (book.State)
						{
							case BookState.Actual:
								sourceColor = Color.Black;
								targetColor = Color.Black;
								backColor = item.BackColor;
								break;

							case BookState.New:
								sourceColor = Color.Blue;
								targetColor = Color.Blue;
								backColor = Color.FromArgb(255, 192, 220, 192);
								break;

							case BookState.Changed:
								sourceColor = Color.DarkGreen;
								targetColor = Color.DarkGreen;
								backColor = Color.FromArgb(255, 166, 202, 240);
								break;

							case BookState.Deleted:
								sourceColor = Color.Silver;
								targetColor = Color.Red;
								backColor = Color.FromArgb(255, 255, 156, 156);
								break;
						}

						item.SubItems.Add(prefix + Path.GetFileName(book.SourcePath), item.ForeColor, backColor, item.Font);
						item.SubItems.Add(prefix + Path.GetFileName(book.TargetPath), item.ForeColor, backColor, item.Font);
						item.Tag = new ListItemInfo(null, book);
						item.UseItemStyleForSubItems = false;
					}
				}
			}

			// Refresh the trees.
			listview.EndUpdate();
		}

	}


	public class ListItemInfo
	{
		public BookFolder Folder { get; private set; }
		public BookInfo Book { get; private set; }

		public ListItemInfo(BookFolder folder, BookInfo book)
		{
			Folder = folder;
			Book = book;
		}
	}


}
