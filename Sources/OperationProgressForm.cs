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
	public partial class OperationProgressForm : Form
	{
		private bool operationComplete = false;


		public OperationProgressForm()
		{
			InitializeComponent();
		}


		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

			if (!operationComplete &&
				Utils.ShowQuestion(this, "Do you want to stop the current operation?", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				e.Cancel = true;
			}
		}
	}
}
