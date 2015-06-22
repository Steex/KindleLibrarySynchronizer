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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node1");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node2");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node4");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node8");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node9");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node5", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7});
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node7");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node6", new System.Windows.Forms.TreeNode[] {
            treeNode9});
			this.textSourceRoot = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textTargetRoot = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonCompare = new System.Windows.Forms.Button();
			this.textLog = new System.Windows.Forms.TextBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.synchroView = new KindleLibrarySynchronizer.SynchroView();
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
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(12, 291);
			this.treeView1.Name = "treeView1";
			treeNode1.ForeColor = System.Drawing.Color.Red;
			treeNode1.Name = "Node0";
			treeNode1.Text = "Node0";
			treeNode2.Name = "Node1";
			treeNode2.Text = "Node1";
			treeNode3.Name = "Node2";
			treeNode3.Text = "Node2";
			treeNode4.Name = "Node4";
			treeNode4.Text = "Node4";
			treeNode5.Name = "Node8";
			treeNode5.Text = "Node8";
			treeNode6.Name = "Node9";
			treeNode6.Text = "Node9";
			treeNode7.Name = "Node5";
			treeNode7.Text = "Node5";
			treeNode8.Name = "Node3";
			treeNode8.Text = "Node3";
			treeNode9.Name = "Node7";
			treeNode9.Text = "Node7";
			treeNode10.Name = "Node6";
			treeNode10.Text = "Node6";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode8,
            treeNode10});
			this.treeView1.Size = new System.Drawing.Size(681, 189);
			this.treeView1.TabIndex = 4;
			// 
			// synchroView
			// 
			this.synchroView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.synchroView.BookComparer = null;
			this.synchroView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.synchroView.Location = new System.Drawing.Point(9, 122);
			this.synchroView.Margin = new System.Windows.Forms.Padding(0);
			this.synchroView.Name = "synchroView";
			this.synchroView.Size = new System.Drawing.Size(788, 152);
			this.synchroView.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 623);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.synchroView);
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
		private SynchroView synchroView;
		private System.Windows.Forms.TreeView treeView1;
	}
}

