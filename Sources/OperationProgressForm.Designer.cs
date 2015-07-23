namespace KindleLibrarySynchronizer
{
	partial class OperationProgressForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.labelCurrentBook = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelErrors = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 67);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(400, 16);
			this.progressBar.TabIndex = 0;
			// 
			// labelCurrentBook
			// 
			this.labelCurrentBook.AutoEllipsis = true;
			this.labelCurrentBook.Location = new System.Drawing.Point(12, 51);
			this.labelCurrentBook.Name = "labelCurrentBook";
			this.labelCurrentBook.Size = new System.Drawing.Size(400, 13);
			this.labelCurrentBook.TabIndex = 1;
			this.labelCurrentBook.Text = "Current book";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(337, 96);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoEllipsis = true;
			this.labelTitle.Location = new System.Drawing.Point(12, 19);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(400, 13);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "<Operation> ## books";
			// 
			// labelErrors
			// 
			this.labelErrors.AutoSize = true;
			this.labelErrors.ForeColor = System.Drawing.Color.Red;
			this.labelErrors.Location = new System.Drawing.Point(12, 101);
			this.labelErrors.Name = "labelErrors";
			this.labelErrors.Size = new System.Drawing.Size(256, 13);
			this.labelErrors.TabIndex = 1;
			this.labelErrors.Text = "There were conversion errors. See the log for details.";
			this.labelErrors.Visible = false;
			// 
			// OperationProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(424, 127);
			this.ControlBox = false;
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.labelErrors);
			this.Controls.Add(this.labelCurrentBook);
			this.Controls.Add(this.progressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "OperationProgressForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "<Operation name>";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label labelCurrentBook;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelErrors;
	}
}