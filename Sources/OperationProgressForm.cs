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
		private BackgroundWorker worker;
		private bool conversionSuccessfull = true;


		public OperationProgressForm(BackgroundWorker worker, BookOperations.OperationData data)
		{
			InitializeComponent();

			labelTitle.Text = string.Format("{0}: {1} books queued", data.OperationName, data.Books.Count());

			this.worker = worker;
			this.worker.ProgressChanged += worker_ProgressChanged;
			this.worker.RunWorkerCompleted += worker_RunWorkerCompleted;
			this.worker.RunWorkerAsync(data);
		}


		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

			if (worker.IsBusy)
			{
				if (Utils.ShowQuestion(this, "Do you want to stop the current operation?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					worker.CancelAsync();
				}
				else
				{
					e.Cancel = true;
				}
			}
		}


		private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Update the progress bar.
			progressBar.Value = e.ProgressPercentage;

			// Show the current book and warnings.
			if (e.UserState is BookOperations.StepInfo)
			{
				BookOperations.StepInfo info = (BookOperations.StepInfo)e.UserState;
				labelCurrentBook.Text = "Processing \"" + info.Book.SourceName + "\"...";
			}
			else if (e.UserState is BookOperations.StepResult)
			{
				BookOperations.StepResult result = (BookOperations.StepResult)e.UserState;
				if (!result.Succeeded)
				{
					conversionSuccessfull = false;
					labelErrors.Visible = true;
				}
			}
		}

		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (conversionSuccessfull)
			{
				Close();
			}
			else
			{
				buttonCancel.Text = "Close";
			}
		}

	}
}
