namespace KindleLibrarySynchronizer
{
	partial class SynchroList
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
			this.listview = new System.Windows.Forms.ListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listview
			// 
			this.listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listview.FullRowSelect = true;
			this.listview.GridLines = true;
			this.listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listview.LabelWrap = false;
			this.listview.Location = new System.Drawing.Point(0, 0);
			this.listview.Margin = new System.Windows.Forms.Padding(0);
			this.listview.Name = "listview";
			this.listview.ShowGroups = false;
			this.listview.Size = new System.Drawing.Size(500, 400);
			this.listview.TabIndex = 0;
			this.listview.UseCompatibleStateImageBehavior = false;
			this.listview.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Width = 0;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Source";
			this.columnHeader5.Width = 248;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Target";
			this.columnHeader6.Width = 248;
			// 
			// SynchroList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listview);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SynchroList";
			this.Size = new System.Drawing.Size(500, 400);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listview;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;


	}
}
