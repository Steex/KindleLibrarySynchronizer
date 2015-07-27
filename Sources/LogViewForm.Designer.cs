namespace KindleLibrarySynchronizer
{
	partial class LogViewForm
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
			this.buttonOk = new System.Windows.Forms.Button();
			this.textMessage = new System.Windows.Forms.TextBox();
			this.checkWordWrap = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
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
			// 
			// textMessage
			// 
			this.textMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textMessage.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textMessage.Location = new System.Drawing.Point(12, 12);
			this.textMessage.Multiline = true;
			this.textMessage.Name = "textMessage";
			this.textMessage.ReadOnly = true;
			this.textMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textMessage.Size = new System.Drawing.Size(626, 433);
			this.textMessage.TabIndex = 2;
			this.textMessage.DoubleClick += new System.EventHandler(this.textMessage_DoubleClick);
			// 
			// checkWordWrap
			// 
			this.checkWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkWordWrap.AutoSize = true;
			this.checkWordWrap.Checked = true;
			this.checkWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkWordWrap.Location = new System.Drawing.Point(12, 457);
			this.checkWordWrap.Name = "checkWordWrap";
			this.checkWordWrap.Size = new System.Drawing.Size(76, 17);
			this.checkWordWrap.TabIndex = 3;
			this.checkWordWrap.Text = "Wrap Text";
			this.checkWordWrap.UseVisualStyleBackColor = true;
			this.checkWordWrap.CheckedChanged += new System.EventHandler(this.checkWordWrap_CheckedChanged);
			// 
			// LogViewForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(650, 486);
			this.Controls.Add(this.checkWordWrap);
			this.Controls.Add(this.textMessage);
			this.Controls.Add(this.buttonOk);
			this.MinimizeBox = false;
			this.Name = "LogViewForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Log View";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.TextBox textMessage;
		private System.Windows.Forms.CheckBox checkWordWrap;
	}
}