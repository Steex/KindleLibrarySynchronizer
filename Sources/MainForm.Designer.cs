namespace KindleLibrarySynchronizer
{
	partial class MainForm
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
			this.textSourceRoot = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textTargetRoot = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonCompare = new System.Windows.Forms.Button();
			this.textLog = new System.Windows.Forms.TextBox();
			this.checkShowActual = new System.Windows.Forms.CheckBox();
			this.checkShowChanged = new System.Windows.Forms.CheckBox();
			this.checkShowNew = new System.Windows.Forms.CheckBox();
			this.checkShowDeleted = new System.Windows.Forms.CheckBox();
			this.synchroList = new KindleLibrarySynchronizer.SynchroList();
			this.SuspendLayout();
			// 
			// textSourceRoot
			// 
			this.textSourceRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textSourceRoot.Location = new System.Drawing.Point(12, 25);
			this.textSourceRoot.Name = "textSourceRoot";
			this.textSourceRoot.Size = new System.Drawing.Size(782, 20);
			this.textSourceRoot.TabIndex = 0;
			this.textSourceRoot.Text = "E:\\Library";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Music source root folder";
			// 
			// textTargetRoot
			// 
			this.textTargetRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textTargetRoot.Location = new System.Drawing.Point(12, 70);
			this.textTargetRoot.Name = "textTargetRoot";
			this.textTargetRoot.Size = new System.Drawing.Size(782, 20);
			this.textTargetRoot.TabIndex = 0;
			this.textTargetRoot.Text = "E:\\Library-Kindle";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Music target root folder";
			// 
			// buttonCompare
			// 
			this.buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCompare.Location = new System.Drawing.Point(719, 96);
			this.buttonCompare.Name = "buttonCompare";
			this.buttonCompare.Size = new System.Drawing.Size(75, 23);
			this.buttonCompare.TabIndex = 2;
			this.buttonCompare.Text = "Compare";
			this.buttonCompare.UseVisualStyleBackColor = true;
			this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
			// 
			// textLog
			// 
			this.textLog.AllowDrop = true;
			this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLog.Location = new System.Drawing.Point(9, 507);
			this.textLog.Multiline = true;
			this.textLog.Name = "textLog";
			this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textLog.Size = new System.Drawing.Size(788, 104);
			this.textLog.TabIndex = 0;
			// 
			// checkShowActual
			// 
			this.checkShowActual.AutoSize = true;
			this.checkShowActual.Checked = true;
			this.checkShowActual.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkShowActual.Location = new System.Drawing.Point(9, 100);
			this.checkShowActual.Name = "checkShowActual";
			this.checkShowActual.Size = new System.Drawing.Size(56, 17);
			this.checkShowActual.TabIndex = 4;
			this.checkShowActual.Text = "Actual";
			this.checkShowActual.UseVisualStyleBackColor = true;
			this.checkShowActual.CheckedChanged += new System.EventHandler(this.checkShowActual_CheckedChanged);
			// 
			// checkShowChanged
			// 
			this.checkShowChanged.AutoSize = true;
			this.checkShowChanged.Checked = true;
			this.checkShowChanged.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkShowChanged.Location = new System.Drawing.Point(135, 100);
			this.checkShowChanged.Name = "checkShowChanged";
			this.checkShowChanged.Size = new System.Drawing.Size(69, 17);
			this.checkShowChanged.TabIndex = 4;
			this.checkShowChanged.Text = "Changed";
			this.checkShowChanged.UseVisualStyleBackColor = true;
			this.checkShowChanged.CheckedChanged += new System.EventHandler(this.checkShowChanged_CheckedChanged);
			// 
			// checkShowNew
			// 
			this.checkShowNew.AutoSize = true;
			this.checkShowNew.Checked = true;
			this.checkShowNew.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkShowNew.Location = new System.Drawing.Point(81, 100);
			this.checkShowNew.Name = "checkShowNew";
			this.checkShowNew.Size = new System.Drawing.Size(48, 17);
			this.checkShowNew.TabIndex = 4;
			this.checkShowNew.Text = "New";
			this.checkShowNew.UseVisualStyleBackColor = true;
			this.checkShowNew.CheckedChanged += new System.EventHandler(this.checkShowNew_CheckedChanged);
			// 
			// checkShowDeleted
			// 
			this.checkShowDeleted.AutoSize = true;
			this.checkShowDeleted.Checked = true;
			this.checkShowDeleted.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkShowDeleted.Location = new System.Drawing.Point(210, 100);
			this.checkShowDeleted.Name = "checkShowDeleted";
			this.checkShowDeleted.Size = new System.Drawing.Size(63, 17);
			this.checkShowDeleted.TabIndex = 4;
			this.checkShowDeleted.Text = "Deleted";
			this.checkShowDeleted.UseVisualStyleBackColor = true;
			this.checkShowDeleted.CheckedChanged += new System.EventHandler(this.checkShowDeleted_CheckedChanged);
			// 
			// synchroList
			// 
			this.synchroList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.synchroList.BookComparer = null;
			this.synchroList.Location = new System.Drawing.Point(9, 122);
			this.synchroList.Margin = new System.Windows.Forms.Padding(0);
			this.synchroList.Name = "synchroList";
			this.synchroList.ShowActualBooks = true;
			this.synchroList.ShowChangedBooks = true;
			this.synchroList.ShowDeletedBooks = true;
			this.synchroList.ShowNewBooks = true;
			this.synchroList.Size = new System.Drawing.Size(787, 382);
			this.synchroList.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 623);
			this.Controls.Add(this.checkShowDeleted);
			this.Controls.Add(this.checkShowNew);
			this.Controls.Add(this.checkShowChanged);
			this.Controls.Add(this.checkShowActual);
			this.Controls.Add(this.synchroList);
			this.Controls.Add(this.textLog);
			this.Controls.Add(this.buttonCompare);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textTargetRoot);
			this.Controls.Add(this.textSourceRoot);
			this.Name = "MainForm";
			this.Text = "Kindle Library Synchronizer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textSourceRoot;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textTargetRoot;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonCompare;
		private System.Windows.Forms.TextBox textLog;
		private SynchroList synchroList;
		private System.Windows.Forms.CheckBox checkShowActual;
		private System.Windows.Forms.CheckBox checkShowChanged;
		private System.Windows.Forms.CheckBox checkShowNew;
		private System.Windows.Forms.CheckBox checkShowDeleted;
	}
}

