﻿namespace KindleLibrarySynchronizer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.textLog = new System.Windows.Forms.TextBox();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCompare = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuSelectNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSelectChanged = new System.Windows.Forms.ToolStripMenuItem();
			this.menuSelectDeleted = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuUpdateSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDeleteSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.menuView = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowActual = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowNew = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowChanged = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowDeleted = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowIgnored = new System.Windows.Forms.ToolStripMenuItem();
			this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolbar = new System.Windows.Forms.ToolStrip();
			this.comboLibraries = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonCompare = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonShowActual = new System.Windows.Forms.ToolStripButton();
			this.buttonShowNew = new System.Windows.Forms.ToolStripButton();
			this.buttonShowChanged = new System.Windows.Forms.ToolStripButton();
			this.buttonShowDeleted = new System.Windows.Forms.ToolStripButton();
			this.buttonShowIgnored = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonSelectNew = new System.Windows.Forms.ToolStripButton();
			this.buttonSelectChanged = new System.Windows.Forms.ToolStripButton();
			this.buttonSelectDeleted = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonUpdateSelected = new System.Windows.Forms.ToolStripButton();
			this.buttonDeleteSelected = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonOptions = new System.Windows.Forms.ToolStripButton();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusSelection = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusCounters = new System.Windows.Forms.ToolStripStatusLabel();
			this.synchroList = new KindleLibrarySynchronizer.SynchroList();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.mainMenu.SuspendLayout();
			this.toolbar.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// textLog
			// 
			this.textLog.AllowDrop = true;
			this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLog.Location = new System.Drawing.Point(0, 507);
			this.textLog.Multiline = true;
			this.textLog.Name = "textLog";
			this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textLog.Size = new System.Drawing.Size(806, 91);
			this.textLog.TabIndex = 0;
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
			this.menuFile.Text = "&File";
			// 
			// menuExit
			// 
			this.menuExit.Name = "menuExit";
			this.menuExit.Size = new System.Drawing.Size(92, 22);
			this.menuExit.Text = "Exit";
			// 
			// menuEdit
			// 
			this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCompare,
            this.toolStripMenuItem1,
            this.menuSelectNew,
            this.menuSelectChanged,
            this.menuSelectDeleted,
            this.toolStripMenuItem2,
            this.menuUpdateSelected,
            this.menuDeleteSelected});
			this.menuEdit.Name = "menuEdit";
			this.menuEdit.Size = new System.Drawing.Size(37, 20);
			this.menuEdit.Text = "&Edit";
			// 
			// menuCompare
			// 
			this.menuCompare.Image = global::KindleLibrarySynchronizer.Properties.Resources.Compare;
			this.menuCompare.Name = "menuCompare";
			this.menuCompare.Size = new System.Drawing.Size(184, 22);
			this.menuCompare.Text = "Compare";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
			// 
			// menuSelectNew
			// 
			this.menuSelectNew.Image = global::KindleLibrarySynchronizer.Properties.Resources.Select_New;
			this.menuSelectNew.Name = "menuSelectNew";
			this.menuSelectNew.Size = new System.Drawing.Size(184, 22);
			this.menuSelectNew.Text = "Select All New";
			// 
			// menuSelectChanged
			// 
			this.menuSelectChanged.Image = global::KindleLibrarySynchronizer.Properties.Resources.Select_Changed;
			this.menuSelectChanged.Name = "menuSelectChanged";
			this.menuSelectChanged.Size = new System.Drawing.Size(184, 22);
			this.menuSelectChanged.Text = "Select All Changed";
			// 
			// menuSelectDeleted
			// 
			this.menuSelectDeleted.Image = ((System.Drawing.Image)(resources.GetObject("menuSelectDeleted.Image")));
			this.menuSelectDeleted.Name = "menuSelectDeleted";
			this.menuSelectDeleted.Size = new System.Drawing.Size(184, 22);
			this.menuSelectDeleted.Text = "Select All Deleted";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
			// 
			// menuUpdateSelected
			// 
			this.menuUpdateSelected.Image = global::KindleLibrarySynchronizer.Properties.Resources.Convert;
			this.menuUpdateSelected.Name = "menuUpdateSelected";
			this.menuUpdateSelected.Size = new System.Drawing.Size(184, 22);
			this.menuUpdateSelected.Text = "Update Selected Books";
			// 
			// menuDeleteSelected
			// 
			this.menuDeleteSelected.Image = global::KindleLibrarySynchronizer.Properties.Resources.Delete;
			this.menuDeleteSelected.Name = "menuDeleteSelected";
			this.menuDeleteSelected.Size = new System.Drawing.Size(184, 22);
			this.menuDeleteSelected.Text = "Delete Selected Books";
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
			this.menuView.Text = "&View";
			// 
			// menuShowActual
			// 
			this.menuShowActual.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Actual;
			this.menuShowActual.Name = "menuShowActual";
			this.menuShowActual.Size = new System.Drawing.Size(146, 22);
			this.menuShowActual.Text = "Show Actual";
			// 
			// menuShowNew
			// 
			this.menuShowNew.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_New;
			this.menuShowNew.Name = "menuShowNew";
			this.menuShowNew.Size = new System.Drawing.Size(146, 22);
			this.menuShowNew.Text = "Show New";
			// 
			// menuShowChanged
			// 
			this.menuShowChanged.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Changed;
			this.menuShowChanged.Name = "menuShowChanged";
			this.menuShowChanged.Size = new System.Drawing.Size(146, 22);
			this.menuShowChanged.Text = "Show Changed";
			// 
			// menuShowDeleted
			// 
			this.menuShowDeleted.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Deleted;
			this.menuShowDeleted.Name = "menuShowDeleted";
			this.menuShowDeleted.Size = new System.Drawing.Size(146, 22);
			this.menuShowDeleted.Text = "Show Deleted";
			// 
			// menuShowIgnored
			// 
			this.menuShowIgnored.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Ignored;
			this.menuShowIgnored.Name = "menuShowIgnored";
			this.menuShowIgnored.Size = new System.Drawing.Size(146, 22);
			this.menuShowIgnored.Text = "Show Ignored";
			// 
			// menuTools
			// 
			this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions});
			this.menuTools.Name = "menuTools";
			this.menuTools.Size = new System.Drawing.Size(44, 20);
			this.menuTools.Text = "&Tools";
			// 
			// menuOptions
			// 
			this.menuOptions.Image = global::KindleLibrarySynchronizer.Properties.Resources.Options;
			this.menuOptions.Name = "menuOptions";
			this.menuOptions.Size = new System.Drawing.Size(123, 22);
			this.menuOptions.Text = "Options...";
			// 
			// menuHelp
			// 
			this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
			this.menuHelp.Name = "menuHelp";
			this.menuHelp.Size = new System.Drawing.Size(40, 20);
			this.menuHelp.Text = "&Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Name = "menuAbout";
			this.menuAbout.Size = new System.Drawing.Size(115, 22);
			this.menuAbout.Text = "About...";
			// 
			// toolbar
			// 
			this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboLibraries,
            this.toolStripSeparator5,
            this.buttonCompare,
            this.toolStripSeparator1,
            this.buttonShowActual,
            this.buttonShowNew,
            this.buttonShowChanged,
            this.buttonShowDeleted,
            this.buttonShowIgnored,
            this.toolStripSeparator2,
            this.buttonSelectNew,
            this.buttonSelectChanged,
            this.buttonSelectDeleted,
            this.toolStripSeparator3,
            this.buttonUpdateSelected,
            this.buttonDeleteSelected,
            this.toolStripSeparator4,
            this.buttonOptions,
            this.toolStripButton1});
			this.toolbar.Location = new System.Drawing.Point(0, 24);
			this.toolbar.Name = "toolbar";
			this.toolbar.Size = new System.Drawing.Size(806, 25);
			this.toolbar.TabIndex = 7;
			this.toolbar.Text = "toolStrip1";
			// 
			// comboLibraries
			// 
			this.comboLibraries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLibraries.Name = "comboLibraries";
			this.comboLibraries.Size = new System.Drawing.Size(200, 25);
			this.comboLibraries.SelectedIndexChanged += new System.EventHandler(this.comboLibraries_SelectedIndexChanged);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonCompare
			// 
			this.buttonCompare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonCompare.Image = global::KindleLibrarySynchronizer.Properties.Resources.Compare;
			this.buttonCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCompare.Name = "buttonCompare";
			this.buttonCompare.Size = new System.Drawing.Size(23, 22);
			this.buttonCompare.Text = "toolStripButton1";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonShowActual
			// 
			this.buttonShowActual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonShowActual.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Actual;
			this.buttonShowActual.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonShowActual.Name = "buttonShowActual";
			this.buttonShowActual.Size = new System.Drawing.Size(23, 22);
			this.buttonShowActual.Text = "toolStripButton2";
			// 
			// buttonShowNew
			// 
			this.buttonShowNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonShowNew.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_New;
			this.buttonShowNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonShowNew.Name = "buttonShowNew";
			this.buttonShowNew.Size = new System.Drawing.Size(23, 22);
			this.buttonShowNew.Text = "toolStripButton3";
			// 
			// buttonShowChanged
			// 
			this.buttonShowChanged.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonShowChanged.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Changed;
			this.buttonShowChanged.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonShowChanged.Name = "buttonShowChanged";
			this.buttonShowChanged.Size = new System.Drawing.Size(23, 22);
			this.buttonShowChanged.Text = "toolStripButton4";
			// 
			// buttonShowDeleted
			// 
			this.buttonShowDeleted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonShowDeleted.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Deleted;
			this.buttonShowDeleted.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonShowDeleted.Name = "buttonShowDeleted";
			this.buttonShowDeleted.Size = new System.Drawing.Size(23, 22);
			this.buttonShowDeleted.Text = "toolStripButton8";
			// 
			// buttonShowIgnored
			// 
			this.buttonShowIgnored.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonShowIgnored.Image = global::KindleLibrarySynchronizer.Properties.Resources.Show_Ignored;
			this.buttonShowIgnored.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonShowIgnored.Name = "buttonShowIgnored";
			this.buttonShowIgnored.Size = new System.Drawing.Size(23, 22);
			this.buttonShowIgnored.Text = "toolStripButton9";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonSelectNew
			// 
			this.buttonSelectNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonSelectNew.Image = global::KindleLibrarySynchronizer.Properties.Resources.Select_New;
			this.buttonSelectNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSelectNew.Name = "buttonSelectNew";
			this.buttonSelectNew.Size = new System.Drawing.Size(23, 22);
			this.buttonSelectNew.Text = "toolStripButton5";
			// 
			// buttonSelectChanged
			// 
			this.buttonSelectChanged.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonSelectChanged.Image = global::KindleLibrarySynchronizer.Properties.Resources.Select_Changed;
			this.buttonSelectChanged.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSelectChanged.Name = "buttonSelectChanged";
			this.buttonSelectChanged.Size = new System.Drawing.Size(23, 22);
			this.buttonSelectChanged.Text = "toolStripButton6";
			// 
			// buttonSelectDeleted
			// 
			this.buttonSelectDeleted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonSelectDeleted.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectDeleted.Image")));
			this.buttonSelectDeleted.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSelectDeleted.Name = "buttonSelectDeleted";
			this.buttonSelectDeleted.Size = new System.Drawing.Size(23, 22);
			this.buttonSelectDeleted.Text = "toolStripButton7";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonUpdateSelected
			// 
			this.buttonUpdateSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonUpdateSelected.Image = global::KindleLibrarySynchronizer.Properties.Resources.Convert;
			this.buttonUpdateSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonUpdateSelected.Name = "buttonUpdateSelected";
			this.buttonUpdateSelected.Size = new System.Drawing.Size(23, 22);
			this.buttonUpdateSelected.Text = "toolStripButton10";
			// 
			// buttonDeleteSelected
			// 
			this.buttonDeleteSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonDeleteSelected.Image = global::KindleLibrarySynchronizer.Properties.Resources.Delete;
			this.buttonDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.Size = new System.Drawing.Size(23, 22);
			this.buttonDeleteSelected.Text = "toolStripButton11";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonOptions
			// 
			this.buttonOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonOptions.Image = global::KindleLibrarySynchronizer.Properties.Resources.Options;
			this.buttonOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonOptions.Name = "buttonOptions";
			this.buttonOptions.Size = new System.Drawing.Size(23, 22);
			this.buttonOptions.Text = "toolStripButton1";
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusSelection,
            this.statusCounters});
			this.statusBar.Location = new System.Drawing.Point(0, 601);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(806, 22);
			this.statusBar.TabIndex = 8;
			this.statusBar.Text = "statusStrip1";
			// 
			// statusSelection
			// 
			this.statusSelection.AutoSize = false;
			this.statusSelection.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.statusSelection.Name = "statusSelection";
			this.statusSelection.Size = new System.Drawing.Size(200, 17);
			this.statusSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusCounters
			// 
			this.statusCounters.AutoSize = false;
			this.statusCounters.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.statusCounters.Name = "statusCounters";
			this.statusCounters.Size = new System.Drawing.Size(300, 17);
			this.statusCounters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// synchroList
			// 
			this.synchroList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.synchroList.BookComparer = null;
			this.synchroList.Location = new System.Drawing.Point(0, 52);
			this.synchroList.Name = "synchroList";
			this.synchroList.ShowActualBooks = true;
			this.synchroList.ShowChangedBooks = true;
			this.synchroList.ShowDeletedBooks = true;
			this.synchroList.ShowNewBooks = true;
			this.synchroList.Size = new System.Drawing.Size(806, 449);
			this.synchroList.TabIndex = 3;
			this.synchroList.SelectionChanged += new System.EventHandler(this.synchroList_SelectionChanged);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 623);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolbar);
			this.Controls.Add(this.synchroList);
			this.Controls.Add(this.textLog);
			this.Controls.Add(this.mainMenu);
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Kindle Library Synchronizer";
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.toolbar.ResumeLayout(false);
			this.toolbar.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textLog;
		private SynchroList synchroList;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuExit;
		private System.Windows.Forms.ToolStripMenuItem menuEdit;
		private System.Windows.Forms.ToolStripMenuItem menuCompare;
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
		private System.Windows.Forms.ToolStripMenuItem menuOptions;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
		private System.Windows.Forms.ToolStripMenuItem menuAbout;
		private System.Windows.Forms.ToolStrip toolbar;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripStatusLabel statusSelection;
		private System.Windows.Forms.ToolStripStatusLabel statusCounters;
		private System.Windows.Forms.ToolStripComboBox comboLibraries;
		private System.Windows.Forms.ToolStripButton buttonCompare;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonShowActual;
		private System.Windows.Forms.ToolStripButton buttonShowNew;
		private System.Windows.Forms.ToolStripButton buttonShowChanged;
		private System.Windows.Forms.ToolStripButton buttonShowDeleted;
		private System.Windows.Forms.ToolStripButton buttonShowIgnored;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonSelectNew;
		private System.Windows.Forms.ToolStripButton buttonSelectChanged;
		private System.Windows.Forms.ToolStripButton buttonSelectDeleted;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton buttonUpdateSelected;
		private System.Windows.Forms.ToolStripButton buttonDeleteSelected;
		private System.Windows.Forms.ToolStripButton buttonOptions;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}

