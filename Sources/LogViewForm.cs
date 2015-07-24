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
	public partial class LogViewForm : Form
	{
		public LogViewForm(string message)
		{
			InitializeComponent();

			textMessage.Text = message;
		}

		private void checkWordWrap_CheckedChanged(object sender, EventArgs e)
		{
			textMessage.WordWrap = checkWordWrap.Checked;
		}

	}
}
