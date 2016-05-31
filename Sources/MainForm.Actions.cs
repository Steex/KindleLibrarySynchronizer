using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace KindleLibrarySynchronizer
{
	partial class MainForm
	{
		private KindleLibrarySynchronizer.Action actionExit;
		private KindleLibrarySynchronizer.Action actionCompare;
		private KindleLibrarySynchronizer.Action actionCompareSelected;
		private KindleLibrarySynchronizer.Action actionSelectNew;
		private KindleLibrarySynchronizer.Action actionSelectChanged;
		private KindleLibrarySynchronizer.Action actionSelectDeleted;
		private KindleLibrarySynchronizer.Action actionConvertSelected;
		private KindleLibrarySynchronizer.Action actionDeleteSelected;
		private KindleLibrarySynchronizer.Action actionOpenItem;
		private KindleLibrarySynchronizer.Action actionExploreItem;
		private KindleLibrarySynchronizer.Action actionShowAll;
		private KindleLibrarySynchronizer.Action actionShowActual;
		private KindleLibrarySynchronizer.Action actionShowNew;
		private KindleLibrarySynchronizer.Action actionShowChanged;
		private KindleLibrarySynchronizer.Action actionShowDeleted;
		private KindleLibrarySynchronizer.Action actionShowIgnored;
		private KindleLibrarySynchronizer.Action actionToggleLogPane;
		private KindleLibrarySynchronizer.Action actionOptions;
		private KindleLibrarySynchronizer.Action actionAbout;

		private void InitializeActions()
		{
			actionExit = new KindleLibrarySynchronizer.Action("E&xit");
			actionExit.AttachToolItem(menuExit);
			actionExit.Execute += actionExit_Execute;

			actionCompare = new KindleLibrarySynchronizer.Action("&Compare", "Recompare books in the library");
			actionCompare.ShortcutKeys = Keys.F5;
			actionCompare.AttachToolItem(menuCompare);
			actionCompare.AttachToolItem(buttonCompare);
			actionCompare.Execute += actionCompare_Execute;
			actionCompare.Update += actionCompare_Update;

			actionCompareSelected = new KindleLibrarySynchronizer.Action("&Compare Selected", "Recompare selected books");
			actionCompareSelected.ShortcutKeys = Keys.Control | Keys.R;
			actionCompareSelected.AttachToolItem(menuBooksCompare);
			actionCompareSelected.Execute += actionCompareSelected_Execute;
			actionCompareSelected.Update += actionCompareSelected_Update;

			actionSelectNew = new KindleLibrarySynchronizer.Action("Select All &New", "Select all books that are present on PC but not on the device");
			actionSelectNew.AttachToolItem(menuSelectNew);
			actionSelectNew.AttachToolItem(buttonSelectNew);
			actionSelectNew.Execute += actionSelectNew_Execute;
			actionSelectNew.Update += actionSelectNew_Update;

			actionSelectChanged = new KindleLibrarySynchronizer.Action("Select All &Changed", "Select all books that were changed since they had been copied to the device");
			actionSelectChanged.AttachToolItem(menuSelectChanged);
			actionSelectChanged.AttachToolItem(buttonSelectChanged);
			actionSelectChanged.Execute += actionSelectChanged_Execute;
			actionSelectChanged.Update += actionSelectChanged_Update;

			actionSelectDeleted = new KindleLibrarySynchronizer.Action("Select All &Deleted", "Select all books that are present on the device but not on PC");
			actionSelectDeleted.AttachToolItem(menuSelectDeleted);
			actionSelectDeleted.AttachToolItem(buttonSelectDeleted);
			actionSelectDeleted.Execute += actionSelectDeleted_Execute ;
			actionSelectDeleted.Update += actionSelectDeleted_Update;

			actionConvertSelected = new KindleLibrarySynchronizer.Action("&Convert Selected Books", "Convert all selected books into PDF and copy them to the device");
			actionConvertSelected.ShortcutKeys = Keys.Control | Keys.U;
			actionConvertSelected.AttachToolItem(menuConvertSelected);
			actionConvertSelected.AttachToolItem(menuBooksConvert);
			actionConvertSelected.AttachToolItem(buttonConvertSelected);
			actionConvertSelected.Execute += actionUpdateSelected_Execute;
			actionConvertSelected.Update += actionUpdateSelected_Update;

			actionDeleteSelected = new KindleLibrarySynchronizer.Action("Delete Selected Books", "Delete all selected PDF books from the device (original books will remain safe)");
			actionDeleteSelected.ShortcutKeys = Keys.Control | Keys.Delete;
			actionDeleteSelected.AttachToolItem(menuDeleteSelected);
			actionDeleteSelected.AttachToolItem(menuBooksDelete);
			actionDeleteSelected.AttachToolItem(buttonDeleteSelected);
			actionDeleteSelected.Execute += actionDeleteSelected_Execute;
			actionDeleteSelected.Update += actionDeleteSelected_Update;

			actionOpenItem = new KindleLibrarySynchronizer.Action("&Open", "Open the selected item in the default viewer");
			actionOpenItem.AttachToolItem(menuBooksOpen);
			actionOpenItem.Execute += actionOpenItem_Execute;
			actionOpenItem.Update += actionOpenItem_Update;

			actionExploreItem = new KindleLibrarySynchronizer.Action("&Explore", "Reveals the selected item in Windows Explorer");
			actionExploreItem.AttachToolItem(menuBooksExplore);
			actionExploreItem.Execute += actionExploreItem_Execute;
			actionExploreItem.Update += actionExploreItem_Update;

			actionShowAll = new KindleLibrarySynchronizer.Action("Show A&ll", "Display all books in the list");
			actionShowAll.AttachToolItem(menuShowAll);
			actionShowAll.AttachToolItem(buttonShowAll);
			actionShowAll.Execute += actionShowAll_Execute;

			actionShowActual = new KindleLibrarySynchronizer.Action("Show &Actual", "Display in the list all books that haven't been changed since they had been copied to the device");
			actionShowActual.AttachToolItem(menuShowActual);
			actionShowActual.AttachToolItem(buttonShowActual);
			actionShowActual.Execute += actionShowActual_Execute;
			actionShowActual.Update += actionShowActual_Update;

			actionShowNew = new KindleLibrarySynchronizer.Action("Show &New", "Display in the list all books that are present on PC but not on the device");
			actionShowNew.AttachToolItem(menuShowNew);
			actionShowNew.AttachToolItem(buttonShowNew);
			actionShowNew.Execute += actionShowNew_Execute;
			actionShowNew.Update += actionShowNew_Update;

			actionShowChanged = new KindleLibrarySynchronizer.Action("Show &Changed", "Display in the list all books that were changed since they had been copied to the device");
			actionShowChanged.AttachToolItem(menuShowChanged);
			actionShowChanged.AttachToolItem(buttonShowChanged);
			actionShowChanged.Execute += actionShowChanged_Execute;
			actionShowChanged.Update += actionShowChanged_Update;

			actionShowDeleted = new KindleLibrarySynchronizer.Action("Show &Deleted", "Display in the list all books that are present on the device but not on PC");
			actionShowDeleted.AttachToolItem(menuShowDeleted);
			actionShowDeleted.AttachToolItem(buttonShowDeleted);
			actionShowDeleted.Execute += actionShowDeleted_Execute;
			actionShowDeleted.Update += actionShowDeleted_Update;

			actionShowIgnored = new KindleLibrarySynchronizer.Action("Show &Ignored", "Display in the list books from ignored folders");
			actionShowIgnored.AttachToolItem(menuShowIgnored);
			actionShowIgnored.AttachToolItem(buttonShowIgnored);
			actionShowIgnored.Execute += actionShowIgnored_Execute;
			actionShowIgnored.Update += actionShowIgnored_Update;

			actionToggleLogPane = new KindleLibrarySynchronizer.Action("Log Pane", "Toggle the log pane");
			actionToggleLogPane.AttachToolItem(menuToggleLogPane);
			actionToggleLogPane.AttachToolItem(buttonToggleLogPane);
			actionToggleLogPane.Execute += actionToggleLogPane_Execute;
			actionToggleLogPane.Update += actionToggleLogPane_Update;

			actionOptions = new KindleLibrarySynchronizer.Action("&Options...", "Display the configuration dialog");
			actionOptions.AttachToolItem(menuOptions);
			actionOptions.AttachToolItem(buttonOptions);
			actionOptions.Execute += actionOptions_Execute;

			actionAbout = new KindleLibrarySynchronizer.Action("&About...");
			actionAbout.AttachToolItem(menuAbout);
			actionAbout.Execute += actionAbout_Execute;

			KindleLibrarySynchronizer.Action.UpdateActions(EventArgs.Empty);
		}


		private void actionExit_Execute(object sender, EventArgs e)
		{
			Close();
		}

		private void actionCompare_Execute(object sender, EventArgs e)
		{
			bookComparer.Compare(library.Clone());
			synchroList.UpdateItems(false);
			UpdateStatusCounters();

			Logger.WriteLine("---");
		}

		private void actionCompareSelected_Execute(object sender, EventArgs e)
		{
			bookComparer.Compare(
				synchroList.TopLevelSelectedItems.Where(i => i.Folder != null).Select(i => i.Folder),
				synchroList.TopLevelSelectedItems.Where(i => i.Book != null).Select(i => i.Book));
			synchroList.UpdateItems(true);
			UpdateStatusCounters();
		}

		private void actionSelectNew_Execute(object sender, EventArgs e)
		{
			synchroList.SelectItemsWithState(BookState.New);
		}

		private void actionSelectChanged_Execute(object sender, EventArgs e)
		{
			synchroList.SelectItemsWithState(BookState.Changed);
		}

		private void actionSelectDeleted_Execute(object sender, EventArgs e)
		{
			synchroList.SelectItemsWithState(BookState.Deleted);
		}

		private void actionUpdateSelected_Execute(object sender, EventArgs e)
		{
			// If some of the books are up-to-date, ask the user to overwrite.
			if (synchroList.SelectedBooks.Any(b => b.State == BookState.Actual) &&
				Utils.ShowQuestion(this, "Some of the books are up-to-date. Do you want to convert them anyway?", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}

			// Start converting.
			ConvertBooks(synchroList.SelectedBooks);
		}

		private void actionDeleteSelected_Execute(object sender, EventArgs e)
		{
			// If some of the books are up-to-date, ask the user to overwrite.
			if (Utils.ShowQuestion(this, "Do you want to delete selected books?", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				return;
			}

			// Start deleting.
			DeleteBooks(synchroList.SelectedBooks);
		}

		private void actionOpenItem_Execute(object sender, EventArgs e)
		{
			if (synchroList.FocusedColumn == SynchroList.Column.Source)
			{
				if (synchroList.FocusedItem.Folder != null)
				{
					Utils.OpenOrExplorePath(Path.Combine(library.SourceRoot, synchroList.FocusedItem.Folder.Path));
				}
				else if (synchroList.FocusedItem.Book != null)
				{
					if (synchroList.FocusedItem.Book.State != BookState.Deleted)
					{
						Utils.OpenOrExplorePath(synchroList.FocusedItem.Book.SourcePath);
					}
					else
					{
						string targetDirectory = Path.GetDirectoryName(synchroList.FocusedItem.Book.TargetPath);
						string relativeDirectory = Utils.GetRelativePath(targetDirectory, library.TargetRoot);
						string sourceDirectory = Path.Combine(library.SourceRoot, relativeDirectory);
						Utils.OpenOrExplorePath(sourceDirectory);
					}
				}
			}
			else if (synchroList.FocusedColumn == SynchroList.Column.Target)
			{
				if (synchroList.FocusedItem.Folder != null)
				{
					Utils.OpenOrExplorePath(Path.Combine(library.TargetRoot, synchroList.FocusedItem.Folder.Path));
				}
				else if (synchroList.FocusedItem.Book != null)
				{
					Utils.OpenOrExplorePath(synchroList.FocusedItem.Book.TargetPath);
				}
			}
		}

		private void actionExploreItem_Execute(object sender, EventArgs e)
		{
			if (synchroList.FocusedColumn == SynchroList.Column.Source)
			{
				if (synchroList.FocusedItem.Folder != null)
				{
					Utils.ExplorePath(Path.Combine(library.SourceRoot, synchroList.FocusedItem.Folder.Path));
				}
				else if (synchroList.FocusedItem.Book != null)
				{
					if (synchroList.FocusedItem.Book.State != BookState.Deleted)
					{
						Utils.ExplorePath(synchroList.FocusedItem.Book.SourcePath);
					}
					else
					{
						string targetDirectory = Path.GetDirectoryName(synchroList.FocusedItem.Book.TargetPath);
						string relativeDirectory = Utils.GetRelativePath(targetDirectory, library.TargetRoot);
						string sourceDirectory = Path.Combine(library.SourceRoot, relativeDirectory);
						Utils.OpenOrExplorePath(sourceDirectory);
					}
				}
			}
			else if (synchroList.FocusedColumn == SynchroList.Column.Target)
			{
				if (synchroList.FocusedItem.Folder != null)
				{
					Utils.ExplorePath(Path.Combine(library.TargetRoot, synchroList.FocusedItem.Folder.Path));
				}
				else if (synchroList.FocusedItem.Book != null)
				{
					Utils.ExplorePath(synchroList.FocusedItem.Book.TargetPath);
				}
			}
		}

		private void actionShowAll_Execute(object sender, EventArgs e)
		{
			synchroList.ShowActualBooks = true;
			synchroList.ShowNewBooks = true;
			synchroList.ShowChangedBooks = true;
			synchroList.ShowDeletedBooks = true;
		}

		private void actionShowActual_Execute(object sender, EventArgs e)
		{
			Config.Main.ShowActualBooks = !Config.Main.ShowActualBooks;
			synchroList.ShowActualBooks = Config.Main.ShowActualBooks;
		}

		private void actionShowNew_Execute(object sender, EventArgs e)
		{
			Config.Main.ShowNewBooks = !Config.Main.ShowNewBooks;
			synchroList.ShowNewBooks = Config.Main.ShowNewBooks;
		}

		private void actionShowChanged_Execute(object sender, EventArgs e)
		{
			Config.Main.ShowChangedBooks = !Config.Main.ShowChangedBooks;
			synchroList.ShowChangedBooks = Config.Main.ShowChangedBooks;
		}

		private void actionShowDeleted_Execute(object sender, EventArgs e)
		{
			Config.Main.ShowDeletedBooks = !Config.Main.ShowDeletedBooks;
			synchroList.ShowDeletedBooks = Config.Main.ShowDeletedBooks;
		}

		private void actionShowIgnored_Execute(object sender, EventArgs e)
		{
			Config.Main.ShowIgnoredBooks = !Config.Main.ShowIgnoredBooks;
			bookComparer.SkipIgnoredBooks = !Config.Main.ShowIgnoredBooks;
			bookComparer.Compare();
			synchroList.UpdateItems(true);
			UpdateStatusCounters();
		}

		private void actionToggleLogPane_Execute(object sender, EventArgs e)
		{
			splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;
			ResetLogButtonLevel();
		}

		private void actionOptions_Execute(object sender, EventArgs e)
		{
			using (OptionsForm optionsForm = new OptionsForm(Config.Main.Clone()))
			{
				if (optionsForm.ShowDialog(this) == DialogResult.OK)
				{
					// Update and save the config.
					Config.SetMain(optionsForm.LocalConfig);
					Config.Main.Save();

					// Update the combo.
					PopulateLibraryCombo();

					// Try to select the same library.
					SelectLibraryWithName(library.Name);
				}
			}
		}

		private void actionAbout_Execute(object sender, EventArgs e)
		{
			MessageBox.Show(this, "About", Application.ProductName);
		}


		private void actionCompare_Update(object sender, EventArgs e)
		{
			actionCompare.Enabled = library != null;
		}

		private void actionCompareSelected_Update(object sender, EventArgs e)
		{
			actionCompareSelected.Enabled = synchroList.SelectedItems.Any();
		}

		private void actionSelectNew_Update(object sender, EventArgs e)
		{
			actionSelectNew.Enabled = bookComparer.Books.AllBooks.Any();
		}

		private void actionSelectChanged_Update(object sender, EventArgs e)
		{
			actionSelectChanged.Enabled = bookComparer.Books.AllBooks.Any();
		}

		private void actionSelectDeleted_Update(object sender, EventArgs e)
		{
			actionSelectDeleted.Enabled = bookComparer.Books.AllBooks.Any();
		}

		private void actionUpdateSelected_Update(object sender, EventArgs e)
		{
			actionConvertSelected.Enabled = synchroList.SelectedBooks.Any(book => book.State != BookState.Deleted);
		}

		private void actionDeleteSelected_Update(object sender, EventArgs e)
		{
			actionDeleteSelected.Enabled = synchroList.SelectedBooks.Any(book => book.State != BookState.New);
		}

		private void actionOpenItem_Update(object sender, EventArgs e)
		{
			actionOpenItem.Enabled = synchroList.FocusedColumn != SynchroList.Column.None;
		}

		private void actionExploreItem_Update(object sender, EventArgs e)
		{
			actionExploreItem.Enabled = synchroList.FocusedColumn != SynchroList.Column.None;
		}

		private void actionShowActual_Update(object sender, EventArgs e)
		{
			actionShowActual.Checked = synchroList.ShowActualBooks;
		}

		private void actionShowNew_Update(object sender, EventArgs e)
		{
			actionShowNew.Checked = synchroList.ShowNewBooks;
		}

		private void actionShowChanged_Update(object sender, EventArgs e)
		{
			actionShowChanged.Checked = synchroList.ShowChangedBooks;
		}

		private void actionShowDeleted_Update(object sender, EventArgs e)
		{
			actionShowDeleted.Checked = synchroList.ShowDeletedBooks;
		}

		private void actionToggleLogPane_Update(object sender, EventArgs e)
		{
			actionToggleLogPane.Checked = !splitContainer.Panel2Collapsed;
		}

		private void actionShowIgnored_Update(object sender, EventArgs e)
		{
			actionShowIgnored.Checked = !bookComparer.SkipIgnoredBooks;
		}

	}
}