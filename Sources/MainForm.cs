using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KindleLibrarySynchronizer
{
	public partial class MainForm : Form
	{
		private LibraryInfo library;
		private BookComparer bookComparer;

		public MainForm()
		{
			InitializeComponent();

			Logger.OnWrite += (msg) => textLog.AppendText(msg);
			Logger.OnClear += () => textLog.Clear();

			bookComparer = new BookComparer();
			synchroList.BookComparer = bookComparer;

			PopulateLibraryCombo();
			if (comboLibraries.Items.Count > 0)
			{
				comboLibraries.SelectedIndex = 0;
			}

			InitializeActions();
		}


		private void PopulateLibraryCombo()
		{
			comboLibraries.BeginUpdate();

			comboLibraries.Items.Clear();
			foreach (LibraryInfo libraryInfo in Config.Main.Libraries)
			{
				comboLibraries.Items.Add(libraryInfo.Name);
			}

			comboLibraries.EndUpdate();
		}


		private void synchroList_SelectionChanged(object sender, EventArgs e)
		{
			int selectedCount = synchroList.SelectedBooks.Count();
			string textTemplate = (selectedCount == 1) ? "{0} book selected" : "{0} books selected";
			statusSelection.Text = string.Format(textTemplate, selectedCount);

			Action.UpdateActions(EventArgs.Empty);
		}

		private void comboLibraries_SelectedIndexChanged(object sender, EventArgs e)
		{
			string libraryName = (string)comboLibraries.SelectedItem;

			library = Config.Main.Libraries.Find(l => l.Name == libraryName);
		}

	}

}
