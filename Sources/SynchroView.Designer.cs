namespace KindleLibrarySynchronizer
{
	partial class SynchroView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.treeTarget = new KindleLibrarySynchronizer.MultiSelectTreeView();
			this.treeSource = new KindleLibrarySynchronizer.MultiSelectTreeView();
			this.SuspendLayout();
			// 
			// treeTarget
			// 
			this.treeTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.treeTarget.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeTarget.Location = new System.Drawing.Point(250, 0);
			this.treeTarget.Margin = new System.Windows.Forms.Padding(0);
			this.treeTarget.Name = "treeTarget";
			this.treeTarget.Size = new System.Drawing.Size(250, 400);
			this.treeTarget.TabIndex = 1;
			this.treeTarget.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeTarget_AfterCollapse);
			this.treeTarget.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeTarget_AfterExpand);
			this.treeTarget.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeTarget_AfterSelect);
			// 
			// treeSource
			// 
			this.treeSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeSource.BackColor = System.Drawing.SystemColors.Window;
			this.treeSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeSource.Location = new System.Drawing.Point(0, 0);
			this.treeSource.Margin = new System.Windows.Forms.Padding(0);
			this.treeSource.Name = "treeSource";
			this.treeSource.Size = new System.Drawing.Size(500, 400);
			this.treeSource.TabIndex = 0;
			this.treeSource.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeSource_AfterCollapse);
			this.treeSource.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeSource_AfterExpand);
			this.treeSource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSource_AfterSelect);
			// 
			// SynchroView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.treeTarget);
			this.Controls.Add(this.treeSource);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SynchroView";
			this.Size = new System.Drawing.Size(500, 400);
			this.ResumeLayout(false);

		}

		#endregion

		private KindleLibrarySynchronizer.MultiSelectTreeView treeSource;
		private KindleLibrarySynchronizer.MultiSelectTreeView treeTarget;
	}
}
