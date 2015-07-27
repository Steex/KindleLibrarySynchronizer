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

		private void textMessage_DoubleClick(object sender, EventArgs e)
		{
			// Search for a clicked file.
			Point mousePosition = textMessage.PointToClient(Cursor.Position);
			int clickedChar = textMessage.GetCharIndexFromPosition(mousePosition);
			string clickedPath = Utils.ExtractFileNameAtPosition(textMessage.Text, clickedChar);

			// Open the clicked file.
			if (!string.IsNullOrEmpty(clickedPath))
			{
				Utils.OpenOrExplorePath(clickedPath);
			}
		}

	}
}
