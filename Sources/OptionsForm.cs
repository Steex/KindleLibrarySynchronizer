using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KindleLibrarySynchronizer
{
	public partial class OptionsForm : Form
	{
		public Config LocalConfig { get; private set; }

		private LibraryInfo currentLibrary;


		public OptionsForm(Config configCopy)
		{
			InitializeComponent();

			LocalConfig = configCopy;

			// Prepare converter settings.
			textConverterDirectory.Text = LocalConfig.ConverterDirectory;
			textConverterStylesheet.Text = LocalConfig.ConverterUserStylesheet;

			// Prepare library editor.
			foreach (LibraryInfo library in LocalConfig.Libraries)
			{
				listLibraries.Items.Add(library.Name);
			}

			if (listLibraries.Items.Count > 0)
			{
				listLibraries.SelectedIndex = 0;
			}

			propertyGrid1.SelectedObject = LocalConfig;

			tabControl.SelectedTab = pageGeneral;

			// Limit resizing by the current size.
			MinimumSize = Size;

			// Assign tooltips.
			toolTip.SetToolTip(textConverterStylesheet, "The main style sheet is used unless it is overridden by library settings\r\nCan be relative or absolute");
		}


		private void listLibraries_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Populate library data.
			if (listLibraries.SelectedIndex != -1)
			{
				currentLibrary = LocalConfig.Libraries[listLibraries.SelectedIndex];

				textLibraryName.Text = currentLibrary.Name;
				textLibrarySourceRoot.Text = currentLibrary.SourceRoot;
				textLibraryTargetRoot.Text = currentLibrary.TargetRoot;
				textLibraryIgnoredFiles.Text = string.Join("\r\n", currentLibrary.IgnoredFiles);
				textLibraryMainStylesheet.Text = currentLibrary.MainStylesheet;
			}
			else
			{
				currentLibrary = null;

				textLibraryName.Text = "";
				textLibrarySourceRoot.Text = "";
				textLibraryTargetRoot.Text = "";
				textLibraryIgnoredFiles.Text = "";
				textLibraryMainStylesheet.Text = "";
			}


			// Update buttons.
			buttonMoveLibraryUp.Enabled = listLibraries.SelectedIndex > 0;
			buttonMoveLibraryDown.Enabled = listLibraries.SelectedIndex != -1 && listLibraries.SelectedIndex < listLibraries.Items.Count - 1;
			buttonDeleteLibrary.Enabled = listLibraries.SelectedIndex != -1;
			buttonSaveLibraryData.Enabled = listLibraries.SelectedIndex != -1;
			buttonResetLibraryData.Enabled = listLibraries.SelectedIndex != -1;
		}


		private void buttonMoveLibraryUp_Click(object sender, EventArgs e)
		{
			if (listLibraries.SelectedIndex > 0)
			{
				int index = listLibraries.SelectedIndex;

				LibraryInfo library = LocalConfig.Libraries[index];
				LocalConfig.Libraries.RemoveAt(index);
				LocalConfig.Libraries.Insert(index - 1, library);

				object item = listLibraries.Items[index];
				listLibraries.Items.RemoveAt(index);
				listLibraries.Items.Insert(index - 1, item);

				listLibraries.SelectedIndex = index - 1;
			}
		}

		private void buttonMoveLibraryDown_Click(object sender, EventArgs e)
		{
			if (listLibraries.SelectedIndex != -1 &&
				listLibraries.SelectedIndex < listLibraries.Items.Count - 1)
			{
				int index = listLibraries.SelectedIndex;

				LibraryInfo library = LocalConfig.Libraries[index];
				LocalConfig.Libraries.RemoveAt(index);
				LocalConfig.Libraries.Insert(index + 1, library);

				object item = listLibraries.Items[index];
				listLibraries.Items.RemoveAt(index);
				listLibraries.Items.Insert(index + 1, item);

				listLibraries.SelectedIndex = index + 1;
			}
		}

		private void buttonAddLibrary_Click(object sender, EventArgs e)
		{
			// Generate unique name.
			string libraryName;
			for (int counter = 1; ; ++counter)
			{
				libraryName = "Library " + counter.ToString();
				if (!LocalConfig.Libraries.Any(l => l.Name == libraryName))
				{
					break;
				}
			}

			// Create a new library.
			LibraryInfo library = new LibraryInfo();
			library.Name = libraryName;

			// Add the created library to the end of the list and select it.
			LocalConfig.Libraries.Add(library);
			listLibraries.Items.Add(library.Name);
			listLibraries.SelectedIndex = listLibraries.Items.Count - 1;
		}

		private void buttonDeleteLibrary_Click(object sender, EventArgs e)
		{
			if (listLibraries.SelectedIndex != -1)
			{
				string message = string.Format("Delete library \"{0}\"?", listLibraries.SelectedItem);
				if (Utils.ShowQuestion(this, message, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					LocalConfig.Libraries.RemoveAt(listLibraries.SelectedIndex);
					listLibraries.Items.RemoveAt(listLibraries.SelectedIndex);
				}
			}
		}

		private void buttonResetLibraryData_Click(object sender, EventArgs e)
		{
			if (currentLibrary != null)
			{
				textLibraryName.Text = currentLibrary.Name;
				textLibrarySourceRoot.Text = currentLibrary.SourceRoot;
				textLibraryTargetRoot.Text = currentLibrary.TargetRoot;
				textLibraryIgnoredFiles.Text = string.Join("\r\n", currentLibrary.IgnoredFiles);
			}
		}

		private void buttonSaveLibraryData_Click(object sender, EventArgs e)
		{
			if (currentLibrary != null)
			{
				// Check the name is valid.
				String enteredName = textLibraryName.Text.Trim();
				if (string.IsNullOrEmpty(enteredName))
				{
					Utils.ShowErrorMessage(this, "Enter the library name!");
					textLibraryName.Focus();
					textLibraryName.SelectAll();
					return;
				}

				// Check the name is unique.
				LibraryInfo libraryWithName = LocalConfig.Libraries.FirstOrDefault(l => l.Name == enteredName);
				if (libraryWithName != null && libraryWithName != currentLibrary)
				{
					Utils.ShowErrorMessage(this, "Library with this name already exists.");
					textLibraryName.Focus();
					textLibraryName.SelectAll();
					return;
				}

				// Check the source root is in correct format (but allow empty paths).
				string enteredSourceRoot = textLibrarySourceRoot.Text.Trim();
				if (enteredSourceRoot.IndexOfAny(Path.GetInvalidPathChars()) != -1)
				{
					Utils.ShowErrorMessage(this, "The source path is invalid.");
					textLibrarySourceRoot.Focus();
					textLibrarySourceRoot.SelectAll();
					return;
				}

				// Check the target root is in correct format (but allow empty paths).
				string enteredTargetRoot = textLibraryTargetRoot.Text.Trim();
				if (enteredTargetRoot.IndexOfAny(Path.GetInvalidPathChars()) != -1)
				{
					Utils.ShowErrorMessage(this, "The target path is invalid.");
					textLibraryTargetRoot.Focus();
					textLibraryTargetRoot.SelectAll();
					return;
				}

				// Check the path to stylesheet is in correct format (but allow empty paths).
				string enteredMainStylesheet = textLibraryMainStylesheet.Text.Trim();
				if (enteredMainStylesheet.IndexOfAny(Path.GetInvalidPathChars()) != -1)
				{
					Utils.ShowErrorMessage(this, "The stylesheet path is invalid.");
					textLibraryMainStylesheet.Focus();
					textLibraryMainStylesheet.SelectAll();
					return;
				}


				// Store the library data.
				currentLibrary.Name = enteredName;
				currentLibrary.SourceRoot = enteredSourceRoot;
				currentLibrary.TargetRoot = enteredTargetRoot;
				currentLibrary.MainStylesheet = enteredMainStylesheet;

				currentLibrary.IgnoredFiles.Clear();

				foreach (string line in textLibraryIgnoredFiles.Lines)
				{
					if (!string.IsNullOrWhiteSpace(line))
					{
						currentLibrary.IgnoredFiles.Add(line.Trim());
					}
				}

				// Update the list box.
				listLibraries.Items[listLibraries.SelectedIndex] = currentLibrary.Name;
			}
		}


		private void buttonOk_Click(object sender, EventArgs e)
		{
			// Check the converter directory is exists.
			string enteredConverterDirectory = textConverterDirectory.Text.Trim();
			if (!string.IsNullOrEmpty(enteredConverterDirectory))
			{
				if (!Directory.Exists(enteredConverterDirectory))
				{
					ProcessValidationError(textConverterDirectory, "Cannot find the converter directory.");
					return;
				}

				// Check the converter directory have fb2pdf executable.
				if (!File.Exists(Path.Combine(enteredConverterDirectory, LocalConfig.ConverterExecutable)))
				{
					ProcessValidationError(textConverterDirectory, "Cannot find the converter executable in the specified directory.");
					return;
				}
			}

			// Check the path to stylesheet is in correct format (but allow empty paths).
			string enteredConverterStylesheet = textConverterStylesheet.Text.Trim();
			if (!string.IsNullOrEmpty(enteredConverterStylesheet))
			{
				try
				{
					string fullStylesheetPath;
					if (Path.IsPathRooted(enteredConverterStylesheet))
					{
						fullStylesheetPath = enteredConverterStylesheet;
					}
					else
					{
						fullStylesheetPath = Path.Combine(enteredConverterDirectory, enteredConverterStylesheet);
					}

					if (!File.Exists(fullStylesheetPath))
					{
						ProcessValidationError(textConverterStylesheet, "Cannot find the stylesheet.");
						return;
					}
				}
				catch
				{
					ProcessValidationError(textConverterStylesheet, "The stylesheet path is invalid.");
					return;
				}
			}

			// Store the library data.
			LocalConfig.ConverterDirectory = enteredConverterDirectory;
			LocalConfig.ConverterUserStylesheet = enteredConverterStylesheet;

			// Close the form.
			DialogResult = DialogResult.OK;
			Close();
		}


		private void ProcessValidationError(Control control, string message)
		{
			Utils.ShowErrorMessage(this, message);

			if (control != null)
			{
				control.Focus();

				if (control is TextBox)
				{
					(control as TextBox).SelectAll();
				}
			}
		}
	}
}
