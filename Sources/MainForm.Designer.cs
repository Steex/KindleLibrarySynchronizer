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
			this.labelSelection = new System.Windows.Forms.Label();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRecompare = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSelectNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSelectChanged = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSelectDeleted = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuView = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowActual = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowChanged = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowDeleted = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuUpdateSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDeleteSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowIgnored = new System.Windows.Forms.ToolStripMenuItem();
			this.synchroList = new KindleLibrarySynchronizer.SynchroList();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// textSourceRoot
			// 
			this.textSourceRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textSourceRoot.Location = new System.Drawing.Point(13, 66);
			this.textSourceRoot.Name = "textSourceRoot";
			this.textSourceRoot.Size = new System.Drawing.Size(782, 20);
			this.textSourceRoot.TabIndex = 0;
			this.textSourceRoot.Text = "E:\\Library";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 50);
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
			this.textTargetRoot.Location = new System.Drawing.Point(13, 111);
			this.textTargetRoot.Name = "textTargetRoot";
			this.textTargetRoot.Size = new System.Drawing.Size(782, 20);
			this.textTargetRoot.TabIndex = 0;
			this.textTargetRoot.Text = "E:\\Library-Kindle";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Music target root folder";
			// 
			// buttonCompare
			// 
			this.buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCompare.Location = new System.Drawing.Point(720, 137);
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
			this.checkShowActual.Location = new System.Drawing.Point(10, 141);
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
			this.checkShowChanged.Location = new System.Drawing.Point(136, 141);
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
			this.checkShowNew.Location = new System.Drawing.Point(82, 141);
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
			this.checkShowDeleted.Location = new System.Drawing.Point(211, 141);
			this.checkShowDeleted.Name = "checkShowDeleted";
			this.checkShowDeleted.Size = new System.Drawing.Size(63, 17);
			this.checkShowDeleted.TabIndex = 4;
			this.checkShowDeleted.Text = "Deleted";
			this.checkShowDeleted.UseVisualStyleBackColor = true;
			this.checkShowDeleted.CheckedChanged += new System.EventHandler(this.checkShowDeleted_CheckedChanged);
			// 
			// labelSelection
			// 
			this.labelSelection.AutoSize = true;
			this.labelSelection.Location = new System.Drawing.Point(338, 142);
			this.labelSelection.Name = "labelSelection";
			this.labelSelection.Size = new System.Drawing.Size(83, 13);
			this.labelSelection.TabIndex = 5;
			this.labelSelection.Text = "0 book selected";
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpdate.Enabled = false;
			this.buttonUpdate.Location = new System.Drawing.Point(482, 137);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdate.TabIndex = 2;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.Enabled = false;
			this.buttonDelete.Location = new System.Drawing.Point(563, 137);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(75, 23);
			this.buttonDelete.TabIndex = 2;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.UseVisualStyleBackColor = true;
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuTools,
            this.menuHelp});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(806, 24);
			this.mainMenu.TabIndex = 6;
			this.mainMenu.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(35, 20);
			this.menuFile.Text = "File";
			// 
			// menuTools
			// 
			this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings});
			this.menuTools.Name = "menuTools";
			this.menuTools.Size = new System.Drawing.Size(44, 20);
			this.menuTools.Text = "Tools";
			// 
			// menuHelp
			// 
			this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
			this.menuHelp.Name = "menuHelp";
			this.menuHelp.Size = new System.Drawing.Size(40, 20);
			this.menuHelp.Text = "Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Name = "menuAbout";
			this.menuAbout.Size = new System.Drawing.Size(152, 22);
			this.menuAbout.Text = "About...";
			// 
			// menuSettings
			// 
			this.menuSettings.Name = "menuSettings";
			this.menuSettings.Size = new System.Drawing.Size(152, 22);
			this.menuSettings.Text = "Settings...";
			// 
			// menuExit
			// 
			this.menuExit.Name = "menuExit";
			this.menuExit.Size = new System.Drawing.Size(152, 22);
			this.menuExit.Text = "Exit";
			// 
			// menuEdit
			// 
			this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRecompare,
            this.toolStripMenuItem1,
            this.menuSelectNew,
            this.menuSelectChanged,
            this.menuSelectDeleted,
            this.toolStripMenuItem2,
            this.menuUpdateSelected,
            this.menuDeleteSelected});
			this.menuEdit.Name = "menuEdit";
			this.menuEdit.Size = new System.Drawing.Size(37, 20);
			this.menuEdit.Text = "Edit";
			// 
			// menuRecompare
			// 
			this.menuRecompare.Name = "menuRecompare";
			this.menuRecompare.Size = new System.Drawing.Size(184, 22);
			this.menuRecompare.Text = "Recompare";
			// 
			// menuSelectNew
			// 
			this.menuSelectNew.Name = "menuSelectNew";
			this.menuSelectNew.Size = new System.Drawing.Size(184, 22);
			this.menuSelectNew.Text = "Select All New";
			// 
			// menuSelectChanged
			// 
			this.menuSelectChanged.Name = "menuSelectChanged";
			this.menuSelectChanged.Size = new System.Drawing.Size(184, 22);
			this.menuSelectChanged.Text = "Select All Changed";
			// 
			// menuSelectDeleted
			// 
			this.menuSelectDeleted.Name = "menuSelectDeleted";
			this.menuSelectDeleted.Size = new System.Drawing.Size(184, 22);
			this.menuSelectDeleted.Text = "Select All Deleted";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
			// 
			// menuView
			// 
			this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowActual,
            this.menuShowNew,
            this.menuShowChanged,
            this.menuShowDeleted,
            this.menuShowIgnored});
			this.menuView.Name = "menuView";
			this.menuView.Size = new System.Drawing.Size(41, 20);
			this.menuView.Text = "View";
			// 
			// menuShowActual
			// 
			this.menuShowActual.Name = "menuShowActual";
			this.menuShowActual.Size = new System.Drawing.Size(152, 22);
			this.menuShowActual.Text = "Show Actual";
			// 
			// menuShowNew
			// 
			this.menuShowNew.Name = "menuShowNew";
			this.menuShowNew.Size = new System.Drawing.Size(152, 22);
			this.menuShowNew.Text = "Show New";
			// 
			// menuShowChanged
			// 
			this.menuShowChanged.Name = "menuShowChanged";
			this.menuShowChanged.Size = new System.Drawing.Size(152, 22);
			this.menuShowChanged.Text = "Show Changed";
			// 
			// menuShowDeleted
			// 
			this.menuShowDeleted.Name = "menuShowDeleted";
			this.menuShowDeleted.Size = new System.Drawing.Size(152, 22);
			this.menuShowDeleted.Text = "Show Deleted";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
			// 
			// menuUpdateSelected
			// 
			this.menuUpdateSelected.Name = "menuUpdateSelected";
			this.menuUpdateSelected.Size = new System.Drawing.Size(184, 22);
			this.menuUpdateSelected.Text = "Update Selected Books";
			// 
			// menuDeleteSelected
			// 
			this.menuDeleteSelected.Name = "menuDeleteSelected";
			this.menuDeleteSelected.Size = new System.Drawing.Size(184, 22);
			this.menuDeleteSelected.Text = "Delete Selected Books";
			// 
			// menuShowIgnored
			// 
			this.menuShowIgnored.Name = "menuShowIgnored";
			this.menuShowIgnored.Size = new System.Drawing.Size(152, 22);
			this.menuShowIgnored.Text = "Show Ignored";
			// 
			// synchroList
			// 
			this.synchroList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.synchroList.BookComparer = null;
			this.synchroList.Location = new System.Drawing.Point(9, 163);
			this.synchroList.Margin = new System.Windows.Forms.Padding(0);
			this.synchroList.Name = "synchroList";
			this.synchroList.ShowActualBooks = true;
			this.synchroList.ShowChangedBooks = true;
			this.synchroList.ShowDeletedBooks = true;
			this.synchroList.ShowNewBooks = true;
			this.synchroList.Size = new System.Drawing.Size(787, 341);
			this.synchroList.TabIndex = 3;
			this.synchroList.SelectionChanged += new System.EventHandler(this.synchroList_SelectionChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 623);
			this.Controls.Add(this.labelSelection);
			this.Controls.Add(this.checkShowDeleted);
			this.Controls.Add(this.checkShowNew);
			this.Controls.Add(this.checkShowChanged);
			this.Controls.Add(this.checkShowActual);
			this.Controls.Add(this.synchroList);
			this.Controls.Add(this.textLog);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.buttonCompare);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textTargetRoot);
			this.Controls.Add(this.textSourceRoot);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Kindle Library Synchronizer";
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
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
		private System.Windows.Forms.Label labelSelection;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuExit;
		private System.Windows.Forms.ToolStripMenuItem menuEdit;
		private System.Windows.Forms.ToolStripMenuItem menuRecompare;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuSelectNew;
		private System.Windows.Forms.ToolStripMenuItem menuSelectChanged;
		private System.Windows.Forms.ToolStripMenuItem menuSelectDeleted;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem menuUpdateSelected;
		private System.Windows.Forms.ToolStripMenuItem menuDeleteSelected;
		private System.Windows.Forms.ToolStripMenuItem menuView;
		private System.Windows.Forms.ToolStripMenuItem menuShowActual;
		private System.Windows.Forms.ToolStripMenuItem menuShowNew;
		private System.Windows.Forms.ToolStripMenuItem menuShowChanged;
		private System.Windows.Forms.ToolStripMenuItem menuShowDeleted;
		private System.Windows.Forms.ToolStripMenuItem menuShowIgnored;
		private System.Windows.Forms.ToolStripMenuItem menuTools;
		private System.Windows.Forms.ToolStripMenuItem menuSettings;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
		private System.Windows.Forms.ToolStripMenuItem menuAbout;
	}
}

