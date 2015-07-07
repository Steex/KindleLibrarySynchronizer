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
		public event EventHandler SelectionChanged;


		private BookComparer bookComparer;
		private bool[] showState;
		private Color[] stateBackColors;
		private Color[] stateTextColors;

		private float columnWidthCoeff = 0.5f;
		private bool updatingColumnWidths = false;


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

		[Browsable(false)]
		public IEnumerable<BookInfo> SelectedBooks
		{
			get
			{
				foreach (ListViewItem item in listview.SelectedItems)
				{
					if (item.Tag is ListItemInfo)
					{
						ListItemInfo itemInfo = item.Tag as ListItemInfo;
						if (itemInfo.Book != null)
						{
							yield return itemInfo.Book;
						}
					}
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

			//stateBackColors[(int)BookState.New] = Color.FromArgb(223, 238, 223); ;
			//stateBackColors[(int)BookState.Changed] = Color.FromArgb(210, 229, 247);
			//stateBackColors[(int)BookState.Deleted] = Color.FromArgb(255, 206, 206);

			stateBackColors[(int)BookState.New] = Color.FromArgb(223, 238, 223); ;
			stateBackColors[(int)BookState.Changed] = Color.FromArgb(255, 240, 191);
			stateBackColors[(int)BookState.Deleted] = Color.FromArgb(255, 206, 206);

			stateTextColors[(int)BookState.New] = Color.FromArgb(127, 127, 127);
		}


		protected virtual void OnBookComparerChanged(EventArgs args)
		{
			UpdateItems();
		}

		protected virtual void OnShowStateChanged(EventArgs args)
		{
			UpdateItems();
		}


		public void UpdateItems()
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

			// Refresh the list.
			listview.EndUpdate();

			// Notify listeners.
			if (SelectionChanged != null)
			{
				SelectionChanged(this, EventArgs.Empty);
			}
		}

		private ListViewItem CreateFolderItem(BookFolder folder, int nestingLevel)
		{
			string textPrefix = new string(' ', nestingLevel * 4);
			string textSource = textPrefix + folder.Name;
			string textTarget = textPrefix + folder.Name;

			// Create a new item.
			ListViewItem item = new ListViewItem(textSource);
			item.SubItems.Add(textTarget);
			item.Tag = new ListItemInfo(folder, null);

			// Return the created item.
			return item;
		}

		private ListViewItem CreateBookItem(BookInfo book, int nestingLevel)
		{
			string textPrefix = new string(' ', nestingLevel * 4);
			string textSource = textPrefix + Path.GetFileName(book.SourcePath);
			string textTarget = textPrefix + Path.GetFileName(book.TargetPath);

			// Create a new item.
			ListViewItem item = new ListViewItem(textSource);
			item.BackColor = stateBackColors[(int)book.State];
			item.Tag = new ListItemInfo(null, book);
			item.UseItemStyleForSubItems = false;

			var subitemTarget = item.SubItems.Add(textTarget);
			subitemTarget.ForeColor = stateTextColors[(int)book.State];
			subitemTarget.BackColor = stateBackColors[(int)book.State];

			// Return the created item.
			return item;
		}


		private void listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (SelectionChanged != null)
			{
				SelectionChanged(this, EventArgs.Empty);
			}
		}

		private void listview_ClientSizeChanged(object sender, EventArgs e)
		{
			UpdateColumnWidths();
		}

		private void listview_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				headerTarget.Width = listview.ClientSize.Width - e.NewWidth;
				columnWidthCoeff = (float)e.NewWidth / listview.ClientSize.Width;
			}
			else
			{
				e.Cancel = true;
				e.NewWidth = headerTarget.Width;
			}
		}

		private void listview_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				UpdateColumnWidths();
			}
		}

		private void UpdateColumnWidths()
		{
			if (!updatingColumnWidths)
			{
				updatingColumnWidths = true;

				headerSource.Width = (int)(listview.ClientSize.Width * columnWidthCoeff);
				headerTarget.Width = listview.ClientSize.Width - headerSource.Width;

				updatingColumnWidths = false;
			}
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
