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
			this.treeSource = new MyTreeView();
			this.treeTarget = new System.Windows.Forms.TreeView();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.scrollbar = new System.Windows.Forms.VScrollBar();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeSource
			// 
			this.treeSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeSource.Location = new System.Drawing.Point(0, 0);
			this.treeSource.Margin = new System.Windows.Forms.Padding(0);
			this.treeSource.Name = "treeSource";
			this.treeSource.Scrollable = false;
			this.treeSource.Size = new System.Drawing.Size(240, 302);
			this.treeSource.TabIndex = 0;
			this.treeSource.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeSource_AfterCollapse);
			this.treeSource.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeSource_AfterExpand);
			this.treeSource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSource_AfterSelect);
			// 
			// treeTarget
			// 
			this.treeTarget.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeTarget.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeTarget.Location = new System.Drawing.Point(0, 0);
			this.treeTarget.Margin = new System.Windows.Forms.Padding(0);
			this.treeTarget.Name = "treeTarget";
			this.treeTarget.Size = new System.Drawing.Size(240, 302);
			this.treeTarget.TabIndex = 1;
			this.treeTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeTarget_MouseDown);
			this.treeTarget.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeTarget_MouseMove);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.treeSource);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.treeTarget);
			this.splitContainer.Size = new System.Drawing.Size(481, 302);
			this.splitContainer.SplitterDistance = 240;
			this.splitContainer.SplitterWidth = 1;
			this.splitContainer.TabIndex = 2;
			// 
			// scrollbar
			// 
			this.scrollbar.Dock = System.Windows.Forms.DockStyle.Right;
			this.scrollbar.Location = new System.Drawing.Point(481, 0);
			this.scrollbar.Name = "scrollbar";
			this.scrollbar.Size = new System.Drawing.Size(16, 302);
			this.scrollbar.TabIndex = 3;
			// 
			// SynchroView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.scrollbar);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SynchroView";
			this.Size = new System.Drawing.Size(497, 302);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MyTreeView treeSource;
		private System.Windows.Forms.TreeView treeTarget;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.VScrollBar scrollbar;
	}
}
