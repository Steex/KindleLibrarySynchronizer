﻿using System;
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
		public enum Column
		{
			None,
			Source,
			Target,
		}

		public class ItemInfo
		{
			public ListViewItem Parent { get; private set; }
			public string Path { get; private set; }
			public BookFolder Folder { get; private set; }
			public BookInfo Book { get; private set; }

			public ItemInfo(ListViewItem parent, BookFolder folder, BookInfo book)
			{
				Parent = parent;
				Folder = folder;
				Book = book;

				if (Folder != null)
				{
					Path = Folder.Path;
				}
				else if (Book != null)
				{
					Path = Book.TargetPath;
				}
			}
		}


		private class ViewState
		{
			private int topItemIndex;
			private HashSet<string> selectedPaths;


			public ViewState(ListView listview)
			{
				// Store the scroll position.
				topItemIndex = listview.Items.IndexOf(listview.TopItem);

				// Store selected items.
				selectedPaths = new HashSet<string>();
				foreach (ListViewItem item in listview.SelectedItems)
				{
					selectedPaths.Add(((ItemInfo)item.Tag).Path);
				}
			}

			public void ApplyTo(ListView listview)
			{
				// Restore the scroll positions.
				if (topItemIndex >= 0 && topItemIndex < listview.Items.Count)
				{
					listview.EnsureVisible(listview.Items.Count - 1);
					listview.EnsureVisible(topItemIndex);
				}

				// Restore selected items.
				if (selectedPaths.Count > 0)
				{
					foreach (ListViewItem item in listview.Items)
					{
						string itemPath = ((ItemInfo)item.Tag).Path;
						item.Selected = selectedPaths.Contains(itemPath);
					}
				}
			}
		}


		public event EventHandler SelectionChanged;


		private BookComparer bookComparer;
		private bool[] showState;
		private Color[] stateBackColors;
		private Color[] stateTextColors;

		private float columnWidthCoeff = 0.5f;
		private bool updatingColumnWidths = false;
		private Column clickedColumn = Column.None;


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
					if (item.Tag is ItemInfo)
					{
						ItemInfo itemInfo = item.Tag as ItemInfo;
						if (itemInfo.Book != null)
						{
							yield return itemInfo.Book;
						}
					}
				}
			}
		}

		[Browsable(false)]
		public ItemInfo FocusedItem
		{
			get
			{
				if (listview.FocusedItem != null)
				{
					return listview.FocusedItem.Tag as ItemInfo;
				}
				else
				{
					return null;
				}
			}
		}

		[Browsable(false)]
		public Column FocusedColumn
		{
			get
			{
				return clickedColumn;
			}
		}

		[Browsable(false)]
		public IEnumerable<ItemInfo> SelectedItems
		{
			get
			{
				foreach (ListViewItem item in listview.SelectedItems)
				{
					if (item.Tag is ItemInfo)
					{
						yield return (ItemInfo)item.Tag;
					}
				}
			}
		}

		[Browsable(false)]
		public IEnumerable<ItemInfo> TopLevelSelectedItems
		{
			get
			{
				foreach (ListViewItem item in listview.SelectedItems)
				{
					ItemInfo itemInfo = (ItemInfo)item.Tag;

					bool isTopLevel = true;
					ListViewItem parentItem = itemInfo.Parent;
					while (parentItem != null)
					{
						isTopLevel = isTopLevel && !parentItem.Selected;
						parentItem = (parentItem.Tag as ItemInfo).Parent;
					}
					
					if (isTopLevel)
					{
						yield return itemInfo;
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

			stateBackColors[(int)BookState.New] = Color.FromArgb(223, 238, 223); ;
			stateBackColors[(int)BookState.Changed] = Color.FromArgb(255, 240, 191);
			stateBackColors[(int)BookState.Deleted] = Color.FromArgb(255, 206, 206);

			stateTextColors[(int)BookState.New] = Color.FromArgb(127, 127, 127);
		}


		protected virtual void OnBookComparerChanged(EventArgs args)
		{
			UpdateItems(false);
		}

		protected virtual void OnShowStateChanged(EventArgs args)
		{
			UpdateItems(true);
		}


		public void UpdateItems(bool preserveViewState)
		{
			listview.BeginUpdate();

			// Store the view state if necessary.
			ViewState viewState = null;
			if (preserveViewState)
			{
				viewState = new ViewState(listview);
			}

			// Clear existing items.
			listview.Items.Clear();

			// Fill new items.
			var folderStack = new Stack<BookFolder>();
			var enumeratorStack = new Stack<IEnumerator<BookFolder>>();
			var itemStack = new Stack<ListViewItem>();

			folderStack.Push(BookComparer.Books);
			enumeratorStack.Push(BookComparer.Books.Folders.GetEnumerator());
			itemStack.Push(null);

			while (folderStack.Count > 0)
			{
				BookFolder folder = folderStack.Peek();
				IEnumerator<BookFolder> enumerator = enumeratorStack.Peek();
				ListViewItem folderItem = itemStack.Peek();

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
					ListViewItem item = listview.Items.Add(CreateFolderItem(folderItem, enumerator.Current, folderStack.Count - 1));

					// Iterate the subfolder.
					folderStack.Push(enumerator.Current);
					enumeratorStack.Push(enumerator.Current.Folders.GetEnumerator());
					itemStack.Push(item);
				}
				else
				{
					folderStack.Pop();
					enumeratorStack.Pop();
					itemStack.Pop();

					foreach (BookInfo book in folder.Books)
					{
						// Skip books of disabled states.
						if (!showState[(int)book.State])
						{
							continue;
						}

						// Create the book item.
						ListViewItem item = listview.Items.Add(CreateBookItem(folderItem, book, folderStack.Count));
					}
				}
			}

			// Restore view state if necessary.
			if (preserveViewState)
			{
				viewState.ApplyTo(listview);
			}

			// Refresh the list.
			listview.EndUpdate();

			// Notify listeners.
			if (SelectionChanged != null)
			{
				SelectionChanged(this, EventArgs.Empty);
			}
		}

		private ListViewItem CreateFolderItem(ListViewItem parent, BookFolder folder, int nestingLevel)
		{
			string textPrefix = new string(' ', nestingLevel * 4);
			string textSource = textPrefix + folder.Name;
			string textTarget = textPrefix + folder.Name;

			// Create a new item.
			ListViewItem item = new ListViewItem(textSource);
			item.SubItems.Add(textTarget);
			item.Tag = new ItemInfo(parent, folder, null);

			// Return the created item.
			return item;
		}

		private ListViewItem CreateBookItem(ListViewItem parent, BookInfo book, int nestingLevel)
		{
			string textPrefix = new string(' ', nestingLevel * 4);
			string textSource = textPrefix + Path.GetFileName(book.SourcePath);
			string textTarget = textPrefix + Path.GetFileName(book.TargetPath);

			// Create a new item.
			ListViewItem item = new ListViewItem(textSource);
			item.BackColor = stateBackColors[(int)book.State];
			item.Tag = new ItemInfo(parent, null, book);
			item.UseItemStyleForSubItems = false;

			var subitemTarget = item.SubItems.Add(textTarget);
			subitemTarget.ForeColor = stateTextColors[(int)book.State];
			subitemTarget.BackColor = stateBackColors[(int)book.State];

			// Return the created item.
			return item;
		}


		public void SelectItemsWithState(BookState state)
		{
			listview.BeginUpdate();

			foreach (ListViewItem item in listview.Items)
			{
				ItemInfo itemInfo = (ItemInfo)item.Tag;
				item.Selected = itemInfo.Book != null && itemInfo.Book.State == state;
			}

			listview.EndUpdate();
		}


		private void listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (SelectionChanged != null)
			{
				SelectionChanged(this, EventArgs.Empty);
			}
		}

		private void listview_MouseDown(object sender, MouseEventArgs e)
		{
			clickedColumn = Column.None;

			var hitResult = listview.HitTest(e.X, e.Y);
			if (hitResult.SubItem == null)
			{
				return;
			}

			switch (hitResult.Item.SubItems.IndexOf(hitResult.SubItem))
			{
				case 0: clickedColumn = Column.Source; break;
				case 1: clickedColumn = Column.Target; break;
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

}
