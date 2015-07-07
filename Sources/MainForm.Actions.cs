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
		private KindleLibrarySynchronizer.Action actionSelectNew;
		private KindleLibrarySynchronizer.Action actionSelectChanged;
		private KindleLibrarySynchronizer.Action actionSelectDeleted;
		private KindleLibrarySynchronizer.Action actionUpdateSelected;
		private KindleLibrarySynchronizer.Action actionDeleteSelected;
		private KindleLibrarySynchronizer.Action actionShowActual;
		private KindleLibrarySynchronizer.Action actionShowNew;
		private KindleLibrarySynchronizer.Action actionShowChanged;
		private KindleLibrarySynchronizer.Action actionShowDeleted;
		private KindleLibrarySynchronizer.Action actionShowIgnored;
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

			actionUpdateSelected = new KindleLibrarySynchronizer.Action("&Update Selected Books", "Covert all selected books into PDF and copy them to the device");
			actionUpdateSelected.ShortcutKeys = Keys.Control | Keys.U;
			actionUpdateSelected.AttachToolItem(menuUpdateSelected);
			actionUpdateSelected.AttachToolItem(buttonUpdateSelected);
			actionUpdateSelected.Execute += actionUpdateSelected_Execute;
			actionUpdateSelected.Update += actionUpdateSelected_Update;

			actionDeleteSelected = new KindleLibrarySynchronizer.Action("Delete Selected Books", "Delete all selected PDF books from the device (original books will remain safe)");
			actionDeleteSelected.ShortcutKeys = Keys.Control | Keys.Delete;
			actionDeleteSelected.AttachToolItem(menuDeleteSelected);
			actionDeleteSelected.AttachToolItem(buttonDeleteSelected);
			actionDeleteSelected.Execute += actionDeleteSelected_Execute;
			actionDeleteSelected.Update += actionDeleteSelected_Update;

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
			Logger.Clear();

			bookComparer.Compare(library);
			synchroList.UpdateItems();

			statusCounters.Text = string.Format("{0} actual, {1} new, {2} changed, {3} deleted",
				bookComparer.Books.GetBookStateCount(BookState.Actual),
				bookComparer.Books.GetBookStateCount(BookState.New),
				bookComparer.Books.GetBookStateCount(BookState.Changed),
				bookComparer.Books.GetBookStateCount(BookState.Deleted));

			// Report.
			foreach (BookInfo book in bookComparer.Books.AllBooks)
			{
				Logger.WriteLine("{0}:\t{1}",
					book.State.ToString()[0],
					Utils.GetRelativePath(book.TargetPath, bookComparer.Library.TargetRoot));
			}

			Logger.WriteLine();
			Logger.WriteLine("{0} actual, {1} new, {2} changed, {3} deleted",
				bookComparer.Books.GetBookStateCount(BookState.Actual),
				bookComparer.Books.GetBookStateCount(BookState.New),
				bookComparer.Books.GetBookStateCount(BookState.Changed),
				bookComparer.Books.GetBookStateCount(BookState.Deleted));
			Logger.WriteLine("---");
		}

		private void actionSelectNew_Execute(object sender, EventArgs e)
		{
		}

		private void actionSelectChanged_Execute(object sender, EventArgs e)
		{
		}

		private void actionSelectDeleted_Execute(object sender, EventArgs e)
		{
		}

		private void actionUpdateSelected_Execute(object sender, EventArgs e)
		{
		}

		private void actionDeleteSelected_Execute(object sender, EventArgs e)
		{
		}

		private void actionShowActual_Execute(object sender, EventArgs e)
		{
			synchroList.ShowActualBooks = !synchroList.ShowActualBooks;
		}

		private void actionShowNew_Execute(object sender, EventArgs e)
		{
			synchroList.ShowNewBooks = !synchroList.ShowNewBooks;
		}

		private void actionShowChanged_Execute(object sender, EventArgs e)
		{
			synchroList.ShowChangedBooks = !synchroList.ShowChangedBooks;
		}

		private void actionShowDeleted_Execute(object sender, EventArgs e)
		{
			synchroList.ShowDeletedBooks = !synchroList.ShowDeletedBooks;
		}

		private void actionShowIgnored_Execute(object sender, EventArgs e)
		{
			//synchroList.ShowIgnoredBooks = !synchroList.ShowIgnoredBooks;
		}

		private void actionOptions_Execute(object sender, EventArgs e)
		{
			using (OptionsForm optionsForm = new OptionsForm())
			{
				if (optionsForm.ShowDialog(this) == DialogResult.OK)
				{

				}
			}
		}

		private void actionAbout_Execute(object sender, EventArgs e)
		{
			MessageBox.Show(this, "About", Application.ProductName);
		}


		private void actionCompare_Update(object sender, EventArgs e)
		{
		}

		private void actionSelectNew_Update(object sender, EventArgs e)
		{
		}

		private void actionSelectChanged_Update(object sender, EventArgs e)
		{
		}

		private void actionSelectDeleted_Update(object sender, EventArgs e)
		{
		}

		private void actionUpdateSelected_Update(object sender, EventArgs e)
		{
			actionUpdateSelected.Enabled =
				synchroList.SelectedBooks.Any() &&
				synchroList.SelectedBooks.All(book => book.State == BookState.New || book.State == BookState.Changed);
		}

		private void actionDeleteSelected_Update(object sender, EventArgs e)
		{
			actionDeleteSelected.Enabled =
				synchroList.SelectedBooks.Any();
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

		private void actionShowIgnored_Update(object sender, EventArgs e)
		{
			//actionShowIgnored.Checked = synchroList.ShowActualBooks;
		}

	}
}