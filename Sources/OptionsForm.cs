using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KindleLibrarySynchronizer
{
	public partial class OptionsForm : Form
	{
		public Config LocalConfig { get; private set; }


		public OptionsForm(Config configCopy)
		{
			InitializeComponent();

			LocalConfig = configCopy;

			// Prepare library editor.
			foreach (LibraryInfo library in LocalConfig.Libraries)
			{
				listLibraries.Items.Add(library.Name);
			}

			propertyGrid1.SelectedObject = LocalConfig;
		}

	}
}
