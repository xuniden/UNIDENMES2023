namespace SMTPRORAM.AssyLine.UG
{
	partial class frmBCard
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
			this.panelTop = new System.Windows.Forms.Panel();
			this.btBrowser = new System.Windows.Forms.Button();
			this.txtBrowser = new System.Windows.Forms.TextBox();
			this.btProcess = new System.Windows.Forms.Button();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelTop.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.btBrowser);
			this.panelTop.Controls.Add(this.txtBrowser);
			this.panelTop.Controls.Add(this.btProcess);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(984, 48);
			this.panelTop.TabIndex = 0;
			// 
			// btBrowser
			// 
			this.btBrowser.Location = new System.Drawing.Point(335, 11);
			this.btBrowser.Name = "btBrowser";
			this.btBrowser.Size = new System.Drawing.Size(75, 23);
			this.btBrowser.TabIndex = 8;
			this.btBrowser.Text = "Browser";
			this.btBrowser.UseVisualStyleBackColor = true;
			this.btBrowser.Click += new System.EventHandler(this.btBrowser_Click);
			// 
			// txtBrowser
			// 
			this.txtBrowser.Location = new System.Drawing.Point(12, 12);
			this.txtBrowser.Name = "txtBrowser";
			this.txtBrowser.Size = new System.Drawing.Size(317, 20);
			this.txtBrowser.TabIndex = 7;
			// 
			// btProcess
			// 
			this.btProcess.Location = new System.Drawing.Point(416, 11);
			this.btProcess.Name = "btProcess";
			this.btProcess.Size = new System.Drawing.Size(75, 23);
			this.btProcess.TabIndex = 6;
			this.btProcess.Text = "Update";
			this.btProcess.UseVisualStyleBackColor = true;
			this.btProcess.Click += new System.EventHandler(this.btProcess_Click);
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 48);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 513);
			this.panelContent.TabIndex = 1;
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(12, 6);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(960, 495);
			this.dgView.TabIndex = 6;
			// 
			// frmBCard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelTop);
			this.Name = "frmBCard";
			this.Text = "IMPORT DỮ LIỆU BCARD";
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Button btBrowser;
		private System.Windows.Forms.TextBox txtBrowser;
		private System.Windows.Forms.Button btProcess;
		private System.Windows.Forms.DataGridView dgView;
	}
}