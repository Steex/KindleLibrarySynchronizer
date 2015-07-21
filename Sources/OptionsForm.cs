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

			tabControl.SelectedTab = pageGeneral;

			// Allow exiting without saving of an incorrect data.
			buttonCancel.CausesValidation = false;

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

		private void buttonOk_Click(object sender, EventArgs e)
		{
			ProcessValidationError(textConverterDirectory, "");
			ProcessValidationError(textConverterStylesheet, "");

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


		private void ValidateControl(Control control, CancelEventHandler onValidating, EventHandler onValidated)
		{
			CancelEventArgs validatingArgs = new CancelEventArgs();
			
			if (onValidating != null)
			{
				onValidating(control, validatingArgs);
			}

			if (onValidated != null && !validatingArgs.Cancel)
			{
				onValidated(control, EventArgs.Empty);
			}
		}

		private void ProcessValidationError(Control control, string message)
		{
			bool isValid = string.IsNullOrEmpty(message);

			labelError.Visible = !isValid;
			labelError.Text = isValid ? "" : message;

			if (control != null)
			{
				control.BackColor = isValid ? SystemColors.Window : Color.FromArgb(255, 191, 191);
			}


			/*Utils.ShowErrorMessage(this, message);

			if (control != null)
			{
				control.Focus();

				if (control is TextBox)
				{
					(control as TextBox).SelectAll();
				}
			}*/
		}


		private void textLibraryName_Validating(object sender, CancelEventArgs e)
		{
			if (currentLibrary != null)
			{
				// Check the name is valid.
				String enteredName = textLibraryName.Text.Trim();
				if (string.IsNullOrEmpty(enteredName))
				{
					ProcessValidationError(textLibraryName, "Enter the library name!");
					e.Cancel = true;
					return;
				}

				// Check the name is unique.
				LibraryInfo libraryWithName = LocalConfig.Libraries.FirstOrDefault(l => l.Name == enteredName);
				if (libraryWithName != null && libraryWithName != currentLibrary)
				{
					ProcessValidationError(textLibraryName, "Library with this name already exists.");
					e.Cancel = true;
					return;
				}

				// Hide an error message.
				ProcessValidationError(textLibraryName, "");
			}
		}

		private void textLibraryName_Validated(object sender, EventArgs e)
		{
			if (currentLibrary != null)
			{
				currentLibrary.Name = textLibraryName.Text.Trim();
				listLibraries.Items[listLibraries.SelectedIndex] = currentLibrary.Name;
			}
		}

		private void textLibraryName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				ValidateControl(textLibraryName, textLibraryName_Validating, textLibraryName_Validated);
			}
		}


		private void textLibrarySourceRoot_Validating(object sender, CancelEventArgs e)
		{
			// Check the source root is in correct format (but allow empty paths).
			string enteredSourceRoot = textLibrarySourceRoot.Text.Trim();
			if (enteredSourceRoot.IndexOfAny(Path.GetInvalidPathChars()) != -1)
			{
				ProcessValidationError(textLibrarySourceRoot, "The source path is invalid.");
				e.Cancel = true;
				return;
			}

			// Hide an error message.
			ProcessValidationError(textLibrarySourceRoot, "");
		}

		private void textLibrarySourceRoot_Validated(object sender, EventArgs e)
		{
			currentLibrary.SourceRoot = textLibrarySourceRoot.Text.Trim();
		}

		private void textLibrarySourceRoot_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				ValidateControl(textLibrarySourceRoot, textLibrarySourceRoot_Validating, textLibrarySourceRoot_Validated);
			}
		}


		private void textLibraryTargetRoot_Validating(object sender, CancelEventArgs e)
		{
			// Check the target root is in correct format (but allow empty paths).
			string enteredTargetRoot = textLibraryTargetRoot.Text.Trim();
			if (enteredTargetRoot.IndexOfAny(Path.GetInvalidPathChars()) != -1)
			{
				ProcessValidationError(textLibraryTargetRoot, "The target path is invalid.");
				e.Cancel = true;
				return;
			}

			// Hide an error message.
			ProcessValidationError(textLibraryTargetRoot, "");
		}

		private void textLibraryTargetRoot_Validated(object sender, EventArgs e)
		{
			currentLibrary.TargetRoot = textLibraryTargetRoot.Text.Trim();
		}

		private void textLibraryTargetRoot_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				ValidateControl(textLibraryTargetRoot, textLibraryTargetRoot_Validating, textLibraryTargetRoot_Validated);
			}
		}


		private void textLibraryIgnoredFiles_Validated(object sender, EventArgs e)
		{
			currentLibrary.IgnoredFiles.Clear();

			foreach (string line in textLibraryIgnoredFiles.Lines)
			{
				if (!string.IsNullOrWhiteSpace(line))
				{
					currentLibrary.IgnoredFiles.Add(line.Trim());
				}
			}
		}


		private void textLibraryMainStylesheet_Validating(object sender, CancelEventArgs e)
		{
			// Check the path to stylesheet is in correct format (but allow empty paths).
			string enteredMainStylesheet = textLibraryMainStylesheet.Text.Trim();
			if (enteredMainStylesheet.IndexOfAny(Path.GetInvalidPathChars()) != -1)
			{
				ProcessValidationError(textLibraryMainStylesheet, "The stylesheet path is invalid.");
				e.Cancel = true;
				return;
			}

			// Hide an error message.
			ProcessValidationError(textLibraryMainStylesheet, "");
		}

		private void textLibraryMainStylesheet_Validated(object sender, EventArgs e)
		{
			currentLibrary.MainStylesheet = textLibraryMainStylesheet.Text.Trim();
		}

		private void textLibraryMainStylesheet_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				ValidateControl(textLibraryMainStylesheet, textLibraryMainStylesheet_Validating, textLibraryMainStylesheet_Validated);
			}
		}

	}
}
