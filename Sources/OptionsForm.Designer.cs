namespace KindleLibrarySynchronizer
{
	partial class OptionsForm
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.pageGeneral = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.pageLibraries = new System.Windows.Forms.TabPage();
			this.groupEditLibrary = new System.Windows.Forms.GroupBox();
			this.textLibraryIgnoredFiles = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textLibraryName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textLibrarySourceRoot = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textLibraryTargetRoot = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonAddLibrary = new System.Windows.Forms.Button();
			this.buttonDeleteLibrary = new System.Windows.Forms.Button();
			this.buttonMoveLibraryDown = new System.Windows.Forms.Button();
			this.buttonMoveLibraryUp = new System.Windows.Forms.Button();
			this.listLibraries = new System.Windows.Forms.ListBox();
			this.pageConverter = new System.Windows.Forms.TabPage();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSaveLibraryData = new System.Windows.Forms.Button();
			this.buttonResetLibraryData = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.pageGeneral.SuspendLayout();
			this.pageLibraries.SuspendLayout();
			this.groupEditLibrary.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.pageGeneral);
			this.tabControl.Controls.Add(this.pageLibraries);
			this.tabControl.Controls.Add(this.pageConverter);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(626, 396);
			this.tabControl.TabIndex = 0;
			// 
			// pageGeneral
			// 
			this.pageGeneral.Controls.Add(this.propertyGrid1);
			this.pageGeneral.Location = new System.Drawing.Point(4, 22);
			this.pageGeneral.Name = "pageGeneral";
			this.pageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.pageGeneral.Size = new System.Drawing.Size(618, 370);
			this.pageGeneral.TabIndex = 0;
			this.pageGeneral.Text = "General";
			this.pageGeneral.UseVisualStyleBackColor = true;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Location = new System.Drawing.Point(6, 6);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(210, 358);
			this.propertyGrid1.TabIndex = 0;
			// 
			// pageLibraries
			// 
			this.pageLibraries.Controls.Add(this.groupEditLibrary);
			this.pageLibraries.Controls.Add(this.buttonAddLibrary);
			this.pageLibraries.Controls.Add(this.buttonDeleteLibrary);
			this.pageLibraries.Controls.Add(this.buttonMoveLibraryDown);
			this.pageLibraries.Controls.Add(this.buttonMoveLibraryUp);
			this.pageLibraries.Controls.Add(this.listLibraries);
			this.pageLibraries.Location = new System.Drawing.Point(4, 22);
			this.pageLibraries.Name = "pageLibraries";
			this.pageLibraries.Padding = new System.Windows.Forms.Padding(3);
			this.pageLibraries.Size = new System.Drawing.Size(618, 370);
			this.pageLibraries.TabIndex = 1;
			this.pageLibraries.Text = "Libraries";
			this.pageLibraries.UseVisualStyleBackColor = true;
			// 
			// groupEditLibrary
			// 
			this.groupEditLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupEditLibrary.Controls.Add(this.textLibraryIgnoredFiles);
			this.groupEditLibrary.Controls.Add(this.label5);
			this.groupEditLibrary.Controls.Add(this.buttonResetLibraryData);
			this.groupEditLibrary.Controls.Add(this.buttonSaveLibraryData);
			this.groupEditLibrary.Controls.Add(this.textLibraryName);
			this.groupEditLibrary.Controls.Add(this.label4);
			this.groupEditLibrary.Controls.Add(this.textLibrarySourceRoot);
			this.groupEditLibrary.Controls.Add(this.label3);
			this.groupEditLibrary.Controls.Add(this.textLibraryTargetRoot);
			this.groupEditLibrary.Controls.Add(this.label2);
			this.groupEditLibrary.Location = new System.Drawing.Point(188, 6);
			this.groupEditLibrary.Name = "groupEditLibrary";
			this.groupEditLibrary.Size = new System.Drawing.Size(424, 358);
			this.groupEditLibrary.TabIndex = 8;
			this.groupEditLibrary.TabStop = false;
			this.groupEditLibrary.Text = "Library Properties";
			// 
			// textLibraryIgnoredFiles
			// 
			this.textLibraryIgnoredFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibraryIgnoredFiles.Location = new System.Drawing.Point(6, 180);
			this.textLibraryIgnoredFiles.Multiline = true;
			this.textLibraryIgnoredFiles.Name = "textLibraryIgnoredFiles";
			this.textLibraryIgnoredFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textLibraryIgnoredFiles.Size = new System.Drawing.Size(412, 143);
			this.textLibraryIgnoredFiles.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 164);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(219, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Ignored Files (one path or path mask per line)";
			// 
			// textLibraryName
			// 
			this.textLibraryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibraryName.Location = new System.Drawing.Point(6, 48);
			this.textLibraryName.Name = "textLibraryName";
			this.textLibraryName.Size = new System.Drawing.Size(412, 20);
			this.textLibraryName.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Target Root";
			// 
			// textLibrarySourceRoot
			// 
			this.textLibrarySourceRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibrarySourceRoot.Location = new System.Drawing.Point(6, 92);
			this.textLibrarySourceRoot.Name = "textLibrarySourceRoot";
			this.textLibrarySourceRoot.Size = new System.Drawing.Size(412, 20);
			this.textLibrarySourceRoot.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Source Root";
			// 
			// textLibraryTargetRoot
			// 
			this.textLibraryTargetRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibraryTargetRoot.Location = new System.Drawing.Point(6, 136);
			this.textLibraryTargetRoot.Name = "textLibraryTargetRoot";
			this.textLibraryTargetRoot.Size = new System.Drawing.Size(412, 20);
			this.textLibraryTargetRoot.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Library Name";
			// 
			// buttonAddLibrary
			// 
			this.buttonAddLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddLibrary.Location = new System.Drawing.Point(130, 341);
			this.buttonAddLibrary.Name = "buttonAddLibrary";
			this.buttonAddLibrary.Size = new System.Drawing.Size(23, 23);
			this.buttonAddLibrary.TabIndex = 1;
			this.buttonAddLibrary.Text = "+";
			this.buttonAddLibrary.UseVisualStyleBackColor = true;
			this.buttonAddLibrary.Click += new System.EventHandler(this.buttonAddLibrary_Click);
			// 
			// buttonDeleteLibrary
			// 
			this.buttonDeleteLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDeleteLibrary.Location = new System.Drawing.Point(159, 341);
			this.buttonDeleteLibrary.Name = "buttonDeleteLibrary";
			this.buttonDeleteLibrary.Size = new System.Drawing.Size(23, 23);
			this.buttonDeleteLibrary.TabIndex = 1;
			this.buttonDeleteLibrary.Text = "-";
			this.buttonDeleteLibrary.UseVisualStyleBackColor = true;
			this.buttonDeleteLibrary.Click += new System.EventHandler(this.buttonDeleteLibrary_Click);
			// 
			// buttonMoveLibraryDown
			// 
			this.buttonMoveLibraryDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveLibraryDown.Location = new System.Drawing.Point(35, 341);
			this.buttonMoveLibraryDown.Name = "buttonMoveLibraryDown";
			this.buttonMoveLibraryDown.Size = new System.Drawing.Size(23, 23);
			this.buttonMoveLibraryDown.TabIndex = 1;
			this.buttonMoveLibraryDown.Text = "v";
			this.buttonMoveLibraryDown.UseVisualStyleBackColor = true;
			this.buttonMoveLibraryDown.Click += new System.EventHandler(this.buttonMoveLibraryDown_Click);
			// 
			// buttonMoveLibraryUp
			// 
			this.buttonMoveLibraryUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveLibraryUp.Location = new System.Drawing.Point(6, 341);
			this.buttonMoveLibraryUp.Name = "buttonMoveLibraryUp";
			this.buttonMoveLibraryUp.Size = new System.Drawing.Size(23, 23);
			this.buttonMoveLibraryUp.TabIndex = 1;
			this.buttonMoveLibraryUp.Text = "^";
			this.buttonMoveLibraryUp.UseVisualStyleBackColor = true;
			this.buttonMoveLibraryUp.Click += new System.EventHandler(this.buttonMoveLibraryUp_Click);
			// 
			// listLibraries
			// 
			this.listLibraries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listLibraries.FormattingEnabled = true;
			this.listLibraries.IntegralHeight = false;
			this.listLibraries.Location = new System.Drawing.Point(6, 6);
			this.listLibraries.Name = "listLibraries";
			this.listLibraries.Size = new System.Drawing.Size(176, 323);
			this.listLibraries.TabIndex = 0;
			this.listLibraries.SelectedIndexChanged += new System.EventHandler(this.listLibraries_SelectedIndexChanged);
			// 
			// pageConverter
			// 
			this.pageConverter.Location = new System.Drawing.Point(4, 22);
			this.pageConverter.Name = "pageConverter";
			this.pageConverter.Padding = new System.Windows.Forms.Padding(3);
			this.pageConverter.Size = new System.Drawing.Size(618, 370);
			this.pageConverter.TabIndex = 2;
			this.pageConverter.Text = "Converter";
			this.pageConverter.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(563, 414);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(482, 414);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSaveLibraryData
			// 
			this.buttonSaveLibraryData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveLibraryData.Location = new System.Drawing.Point(395, 329);
			this.buttonSaveLibraryData.Name = "buttonSaveLibraryData";
			this.buttonSaveLibraryData.Size = new System.Drawing.Size(23, 23);
			this.buttonSaveLibraryData.TabIndex = 1;
			this.buttonSaveLibraryData.Text = "!";
			this.buttonSaveLibraryData.UseVisualStyleBackColor = true;
			this.buttonSaveLibraryData.Click += new System.EventHandler(this.buttonSaveLibraryData_Click);
			// 
			// buttonResetLibraryData
			// 
			this.buttonResetLibraryData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonResetLibraryData.Location = new System.Drawing.Point(366, 329);
			this.buttonResetLibraryData.Name = "buttonResetLibraryData";
			this.buttonResetLibraryData.Size = new System.Drawing.Size(23, 23);
			this.buttonResetLibraryData.TabIndex = 1;
			this.buttonResetLibraryData.Text = "x";
			this.buttonResetLibraryData.UseVisualStyleBackColor = true;
			this.buttonResetLibraryData.Click += new System.EventHandler(this.buttonResetLibraryData_Click);
			// 
			// OptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(650, 449);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.tabControl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "OptionsForm";
			this.tabControl.ResumeLayout(false);
			this.pageGeneral.ResumeLayout(false);
			this.pageLibraries.ResumeLayout(false);
			this.groupEditLibrary.ResumeLayout(false);
			this.groupEditLibrary.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage pageGeneral;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TabPage pageLibraries;
		private System.Windows.Forms.Button buttonAddLibrary;
		private System.Windows.Forms.Button buttonDeleteLibrary;
		private System.Windows.Forms.Button buttonMoveLibraryDown;
		private System.Windows.Forms.Button buttonMoveLibraryUp;
		private System.Windows.Forms.ListBox listLibraries;
		private System.Windows.Forms.TextBox textLibraryIgnoredFiles;
		private System.Windows.Forms.TextBox textLibraryTargetRoot;
		private System.Windows.Forms.TextBox textLibrarySourceRoot;
		private System.Windows.Forms.TextBox textLibraryName;
		private System.Windows.Forms.GroupBox groupEditLibrary;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.TabPage pageConverter;
		private System.Windows.Forms.Button buttonResetLibraryData;
		private System.Windows.Forms.Button buttonSaveLibraryData;
	}
}