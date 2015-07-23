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
			this.components = new System.ComponentModel.Container();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.pageGeneral = new System.Windows.Forms.TabPage();
			this.groupConverter = new System.Windows.Forms.GroupBox();
			this.textConverterDirectory = new System.Windows.Forms.TextBox();
			this.textConverterStylesheet = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.pageLibraries = new System.Windows.Forms.TabPage();
			this.groupEditLibrary = new System.Windows.Forms.GroupBox();
			this.gridCustomStylesheets = new System.Windows.Forms.DataGridView();
			this.label8 = new System.Windows.Forms.Label();
			this.textLibraryIgnoredFiles = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textLibraryName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textLibrarySourceRoot = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textLibraryMainStylesheet = new System.Windows.Forms.TextBox();
			this.textLibraryTargetRoot = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.listLibraries = new System.Windows.Forms.ListBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.labelError = new System.Windows.Forms.Label();
			this.buttonDuplicateLibrary = new System.Windows.Forms.Button();
			this.buttonAddLibrary = new System.Windows.Forms.Button();
			this.buttonDeleteLibrary = new System.Windows.Forms.Button();
			this.buttonMoveLibraryDown = new System.Windows.Forms.Button();
			this.buttonMoveLibraryUp = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.pageGeneral.SuspendLayout();
			this.groupConverter.SuspendLayout();
			this.pageLibraries.SuspendLayout();
			this.groupEditLibrary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCustomStylesheets)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.pageGeneral);
			this.tabControl.Controls.Add(this.pageLibraries);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(626, 433);
			this.tabControl.TabIndex = 0;
			// 
			// pageGeneral
			// 
			this.pageGeneral.Controls.Add(this.groupConverter);
			this.pageGeneral.Location = new System.Drawing.Point(4, 22);
			this.pageGeneral.Name = "pageGeneral";
			this.pageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.pageGeneral.Size = new System.Drawing.Size(618, 407);
			this.pageGeneral.TabIndex = 0;
			this.pageGeneral.Text = "General";
			this.pageGeneral.UseVisualStyleBackColor = true;
			// 
			// groupConverter
			// 
			this.groupConverter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupConverter.Controls.Add(this.textConverterDirectory);
			this.groupConverter.Controls.Add(this.textConverterStylesheet);
			this.groupConverter.Controls.Add(this.label7);
			this.groupConverter.Controls.Add(this.label6);
			this.groupConverter.Location = new System.Drawing.Point(6, 6);
			this.groupConverter.Name = "groupConverter";
			this.groupConverter.Size = new System.Drawing.Size(606, 172);
			this.groupConverter.TabIndex = 0;
			this.groupConverter.TabStop = false;
			this.groupConverter.Text = "Converter";
			// 
			// textConverterDirectory
			// 
			this.textConverterDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textConverterDirectory.Location = new System.Drawing.Point(6, 44);
			this.textConverterDirectory.Name = "textConverterDirectory";
			this.textConverterDirectory.Size = new System.Drawing.Size(594, 20);
			this.textConverterDirectory.TabIndex = 7;
			// 
			// textConverterStylesheet
			// 
			this.textConverterStylesheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textConverterStylesheet.Location = new System.Drawing.Point(6, 88);
			this.textConverterStylesheet.Name = "textConverterStylesheet";
			this.textConverterStylesheet.Size = new System.Drawing.Size(594, 20);
			this.textConverterStylesheet.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(318, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Main Stylesheet (leave blank to use default \"data\\stylesheet.json\"";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(335, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Converter Directory (the directory where the file fb2pdf.cmd is located)";
			// 
			// pageLibraries
			// 
			this.pageLibraries.Controls.Add(this.groupEditLibrary);
			this.pageLibraries.Controls.Add(this.buttonDuplicateLibrary);
			this.pageLibraries.Controls.Add(this.buttonAddLibrary);
			this.pageLibraries.Controls.Add(this.buttonDeleteLibrary);
			this.pageLibraries.Controls.Add(this.buttonMoveLibraryDown);
			this.pageLibraries.Controls.Add(this.buttonMoveLibraryUp);
			this.pageLibraries.Controls.Add(this.listLibraries);
			this.pageLibraries.Location = new System.Drawing.Point(4, 22);
			this.pageLibraries.Name = "pageLibraries";
			this.pageLibraries.Padding = new System.Windows.Forms.Padding(3);
			this.pageLibraries.Size = new System.Drawing.Size(618, 407);
			this.pageLibraries.TabIndex = 1;
			this.pageLibraries.Text = "Libraries";
			this.pageLibraries.UseVisualStyleBackColor = true;
			// 
			// groupEditLibrary
			// 
			this.groupEditLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupEditLibrary.Controls.Add(this.gridCustomStylesheets);
			this.groupEditLibrary.Controls.Add(this.label8);
			this.groupEditLibrary.Controls.Add(this.textLibraryIgnoredFiles);
			this.groupEditLibrary.Controls.Add(this.label5);
			this.groupEditLibrary.Controls.Add(this.textLibraryName);
			this.groupEditLibrary.Controls.Add(this.label1);
			this.groupEditLibrary.Controls.Add(this.label4);
			this.groupEditLibrary.Controls.Add(this.textLibrarySourceRoot);
			this.groupEditLibrary.Controls.Add(this.label3);
			this.groupEditLibrary.Controls.Add(this.textLibraryMainStylesheet);
			this.groupEditLibrary.Controls.Add(this.textLibraryTargetRoot);
			this.groupEditLibrary.Controls.Add(this.label2);
			this.groupEditLibrary.Location = new System.Drawing.Point(188, 6);
			this.groupEditLibrary.Name = "groupEditLibrary";
			this.groupEditLibrary.Size = new System.Drawing.Size(424, 395);
			this.groupEditLibrary.TabIndex = 8;
			this.groupEditLibrary.TabStop = false;
			this.groupEditLibrary.Text = "Library Properties";
			// 
			// gridCustomStylesheets
			// 
			this.gridCustomStylesheets.AllowUserToResizeRows = false;
			this.gridCustomStylesheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridCustomStylesheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridCustomStylesheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridCustomStylesheets.Location = new System.Drawing.Point(6, 318);
			this.gridCustomStylesheets.Name = "gridCustomStylesheets";
			this.gridCustomStylesheets.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.gridCustomStylesheets.RowTemplate.Height = 17;
			this.gridCustomStylesheets.Size = new System.Drawing.Size(412, 71);
			this.gridCustomStylesheets.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 302);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(99, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Custom Stylesheets";
			// 
			// textLibraryIgnoredFiles
			// 
			this.textLibraryIgnoredFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibraryIgnoredFiles.Location = new System.Drawing.Point(6, 176);
			this.textLibraryIgnoredFiles.Multiline = true;
			this.textLibraryIgnoredFiles.Name = "textLibraryIgnoredFiles";
			this.textLibraryIgnoredFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textLibraryIgnoredFiles.Size = new System.Drawing.Size(412, 71);
			this.textLibraryIgnoredFiles.TabIndex = 3;
			this.textLibraryIgnoredFiles.Text = "1\r\n2\r\n3\r\n4\r\n5";
			this.textLibraryIgnoredFiles.Validated += new System.EventHandler(this.textLibraryIgnoredFiles_Validated);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(219, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Ignored Files (one path or path mask per line)";
			// 
			// textLibraryName
			// 
			this.textLibraryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibraryName.Location = new System.Drawing.Point(6, 44);
			this.textLibraryName.Name = "textLibraryName";
			this.textLibraryName.Size = new System.Drawing.Size(412, 20);
			this.textLibraryName.TabIndex = 0;
			this.textLibraryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textLibraryName_KeyDown);
			this.textLibraryName.Validating += new System.ComponentModel.CancelEventHandler(this.textLibraryName_Validating);
			this.textLibraryName.Validated += new System.EventHandler(this.textLibraryName_Validated);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 258);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(317, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Library-Specific Stylesheet (leave blank to use the main stylesheet";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Target Root";
			// 
			// textLibrarySourceRoot
			// 
			this.textLibrarySourceRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibrarySourceRoot.Location = new System.Drawing.Point(6, 88);
			this.textLibrarySourceRoot.Name = "textLibrarySourceRoot";
			this.textLibrarySourceRoot.Size = new System.Drawing.Size(412, 20);
			this.textLibrarySourceRoot.TabIndex = 1;
			this.textLibrarySourceRoot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textLibrarySourceRoot_KeyDown);
			this.textLibrarySourceRoot.Validating += new System.ComponentModel.CancelEventHandler(this.textLibrarySourceRoot_Validating);
			this.textLibrarySourceRoot.Validated += new System.EventHandler(this.textLibrarySourceRoot_Validated);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Source Root";
			// 
			// textLibraryMainStylesheet
			// 
			this.textLibraryMainStylesheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibraryMainStylesheet.Location = new System.Drawing.Point(6, 274);
			this.textLibraryMainStylesheet.Name = "textLibraryMainStylesheet";
			this.textLibraryMainStylesheet.Size = new System.Drawing.Size(412, 20);
			this.textLibraryMainStylesheet.TabIndex = 4;
			this.textLibraryMainStylesheet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textLibraryMainStylesheet_KeyDown);
			this.textLibraryMainStylesheet.Validating += new System.ComponentModel.CancelEventHandler(this.textLibraryMainStylesheet_Validating);
			this.textLibraryMainStylesheet.Validated += new System.EventHandler(this.textLibraryMainStylesheet_Validated);
			// 
			// textLibraryTargetRoot
			// 
			this.textLibraryTargetRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLibraryTargetRoot.Location = new System.Drawing.Point(6, 132);
			this.textLibraryTargetRoot.Name = "textLibraryTargetRoot";
			this.textLibraryTargetRoot.Size = new System.Drawing.Size(412, 20);
			this.textLibraryTargetRoot.TabIndex = 2;
			this.textLibraryTargetRoot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textLibraryTargetRoot_KeyDown);
			this.textLibraryTargetRoot.Validating += new System.ComponentModel.CancelEventHandler(this.textLibraryTargetRoot_Validating);
			this.textLibraryTargetRoot.Validated += new System.EventHandler(this.textLibraryTargetRoot_Validated);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Library Name";
			// 
			// listLibraries
			// 
			this.listLibraries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listLibraries.FormattingEnabled = true;
			this.listLibraries.IntegralHeight = false;
			this.listLibraries.Location = new System.Drawing.Point(6, 6);
			this.listLibraries.Name = "listLibraries";
			this.listLibraries.Size = new System.Drawing.Size(176, 360);
			this.listLibraries.TabIndex = 0;
			this.listLibraries.SelectedIndexChanged += new System.EventHandler(this.listLibraries_SelectedIndexChanged);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.Location = new System.Drawing.Point(563, 451);
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
			this.buttonCancel.Location = new System.Drawing.Point(482, 451);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelError
			// 
			this.labelError.AutoSize = true;
			this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelError.ForeColor = System.Drawing.Color.Red;
			this.labelError.Location = new System.Drawing.Point(13, 419);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(59, 13);
			this.labelError.TabIndex = 4;
			this.labelError.Text = "Error text";
			this.labelError.Visible = false;
			// 
			// buttonDuplicateLibrary
			// 
			this.buttonDuplicateLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDuplicateLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonDuplicateLibrary.Image = global::KindleLibrarySynchronizer.Properties.Resources.Library_Duplicate;
			this.buttonDuplicateLibrary.Location = new System.Drawing.Point(130, 378);
			this.buttonDuplicateLibrary.Name = "buttonDuplicateLibrary";
			this.buttonDuplicateLibrary.Size = new System.Drawing.Size(23, 23);
			this.buttonDuplicateLibrary.TabIndex = 1;
			this.buttonDuplicateLibrary.TabStop = false;
			this.toolTip.SetToolTip(this.buttonDuplicateLibrary, "Duplicate the current library");
			this.buttonDuplicateLibrary.UseVisualStyleBackColor = true;
			this.buttonDuplicateLibrary.Click += new System.EventHandler(this.buttonDuplicateLibrary_Click);
			// 
			// buttonAddLibrary
			// 
			this.buttonAddLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAddLibrary.Image = global::KindleLibrarySynchronizer.Properties.Resources.Library_Add;
			this.buttonAddLibrary.Location = new System.Drawing.Point(101, 378);
			this.buttonAddLibrary.Name = "buttonAddLibrary";
			this.buttonAddLibrary.Size = new System.Drawing.Size(23, 23);
			this.buttonAddLibrary.TabIndex = 1;
			this.buttonAddLibrary.TabStop = false;
			this.toolTip.SetToolTip(this.buttonAddLibrary, "Create a new library");
			this.buttonAddLibrary.UseVisualStyleBackColor = true;
			this.buttonAddLibrary.Click += new System.EventHandler(this.buttonAddLibrary_Click);
			// 
			// buttonDeleteLibrary
			// 
			this.buttonDeleteLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDeleteLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonDeleteLibrary.Image = global::KindleLibrarySynchronizer.Properties.Resources.Library_Delete;
			this.buttonDeleteLibrary.Location = new System.Drawing.Point(159, 378);
			this.buttonDeleteLibrary.Name = "buttonDeleteLibrary";
			this.buttonDeleteLibrary.Size = new System.Drawing.Size(23, 23);
			this.buttonDeleteLibrary.TabIndex = 1;
			this.buttonDeleteLibrary.TabStop = false;
			this.toolTip.SetToolTip(this.buttonDeleteLibrary, "Delete the current library");
			this.buttonDeleteLibrary.UseVisualStyleBackColor = true;
			this.buttonDeleteLibrary.Click += new System.EventHandler(this.buttonDeleteLibrary_Click);
			// 
			// buttonMoveLibraryDown
			// 
			this.buttonMoveLibraryDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveLibraryDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonMoveLibraryDown.Image = global::KindleLibrarySynchronizer.Properties.Resources.Library_Move_Down;
			this.buttonMoveLibraryDown.Location = new System.Drawing.Point(35, 378);
			this.buttonMoveLibraryDown.Name = "buttonMoveLibraryDown";
			this.buttonMoveLibraryDown.Size = new System.Drawing.Size(23, 23);
			this.buttonMoveLibraryDown.TabIndex = 2;
			this.buttonMoveLibraryDown.TabStop = false;
			this.toolTip.SetToolTip(this.buttonMoveLibraryDown, "Move the current library down");
			this.buttonMoveLibraryDown.UseVisualStyleBackColor = true;
			this.buttonMoveLibraryDown.Click += new System.EventHandler(this.buttonMoveLibraryDown_Click);
			// 
			// buttonMoveLibraryUp
			// 
			this.buttonMoveLibraryUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonMoveLibraryUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonMoveLibraryUp.Image = global::KindleLibrarySynchronizer.Properties.Resources.Library_Move_Up;
			this.buttonMoveLibraryUp.Location = new System.Drawing.Point(6, 378);
			this.buttonMoveLibraryUp.Name = "buttonMoveLibraryUp";
			this.buttonMoveLibraryUp.Size = new System.Drawing.Size(23, 23);
			this.buttonMoveLibraryUp.TabIndex = 3;
			this.buttonMoveLibraryUp.TabStop = false;
			this.toolTip.SetToolTip(this.buttonMoveLibraryUp, "Move the current library up");
			this.buttonMoveLibraryUp.UseVisualStyleBackColor = true;
			this.buttonMoveLibraryUp.Click += new System.EventHandler(this.buttonMoveLibraryUp_Click);
			// 
			// OptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(650, 486);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelError);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.tabControl.ResumeLayout(false);
			this.pageGeneral.ResumeLayout(false);
			this.groupConverter.ResumeLayout(false);
			this.groupConverter.PerformLayout();
			this.pageLibraries.ResumeLayout(false);
			this.groupEditLibrary.ResumeLayout(false);
			this.groupEditLibrary.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCustomStylesheets)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.GroupBox groupConverter;
		private System.Windows.Forms.TextBox textConverterDirectory;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textConverterStylesheet;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.GroupBox groupEditLibrary;
		private System.Windows.Forms.TextBox textLibraryIgnoredFiles;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textLibraryName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textLibrarySourceRoot;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textLibraryMainStylesheet;
		private System.Windows.Forms.TextBox textLibraryTargetRoot;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelError;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGridView gridCustomStylesheets;
		private System.Windows.Forms.Button buttonDuplicateLibrary;
	}
}