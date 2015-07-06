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
		private Color[] stateBackColors;
		private Color[] stateTextColors;

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
			stateBackColors = new Color[Enum.GetValues(typeof(BookState)).Length];
			stateTextColors = new Color[Enum.GetValues(typeof(BookState)).Length];
			for (int i = 0; i < showState.Length; ++i)
			{
				showState[i] = true;
				stateBackColors[i] = listview.BackColor;
				stateTextColors[i] = listview.ForeColor;
			}

			stateBackColors[(int)BookState.New] = Color.FromArgb(223, 238, 223); ;
			stateBackColors[(int)BookState.Changed] = Color.FromArgb(210, 229, 247);
			stateBackColors[(int)BookState.Deleted] = Color.FromArgb(255, 206, 206);

			stateTextColors[(int)BookState.New] = Color.FromArgb(127, 127, 127);
		}


		protected override void OnSizeChanged(EventArgs args)
		{
			base.OnSizeChanged(args);

			columnHeader5.Width = (int)(listview.ClientSize.Width * treeSplitCoeff);
			columnHeader6.Width = listview.ClientSize.Width - columnHeader5.Width;
		}


		protected virtual void OnBookComparerChanged(EventArgs args)
		{
			FillList();
		}

		protected virtual void OnShowStateChanged(EventArgs args)
		{
			FillList();
		}


		private void FillList()
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
					// Skip the subfolder if it does not contain books to display.
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

					// Create the subfolder item.
					ListViewItem item = listview.Items.Add(CreateFolderItem(enumerator.Current, folderStack.Count - 1));

					// Iterate the subfolder.
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
						ListViewItem item = listview.Items.Add(CreateBookItem(book, folderStack.Count));
					}
				}
			}

			// Refresh the trees.
			listview.EndUpdate();
		}


		private ListViewItem CreateFolderItem(BookFolder folder, int nestingLevel)
		{
			string textPrefix = new string(' ', nestingLevel * 4);

			// Create a new item.
			ListViewItem item = new ListViewItem("folder");
			item.SubItems.Add(textPrefix + folder.Name);
			item.SubItems.Add(textPrefix + folder.Name);
			item.Tag = new ListItemInfo(folder, null);

			// Return the created item.
			return item;
		}

		private ListViewItem CreateBookItem(BookInfo book, int nestingLevel)
		{
			string textPrefix = new string(' ', nestingLevel * 4);

			// Create a new item.
			ListViewItem item = new ListViewItem("file");
			item.Tag = new ListItemInfo(null, book);
			item.UseItemStyleForSubItems = false;

			var subitemSource = item.SubItems.Add(textPrefix + Path.GetFileName(book.SourcePath));
			subitemSource.BackColor = stateBackColors[(int)book.State];

			var subitemTarget = item.SubItems.Add(textPrefix + Path.GetFileName(book.TargetPath));
			subitemTarget.ForeColor = stateTextColors[(int)book.State];
			subitemTarget.BackColor = stateBackColors[(int)book.State];

			// Return the created item.
			return item;
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
