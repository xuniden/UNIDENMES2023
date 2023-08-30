namespace SMTPRORAM.AssyLine.ETASSY
{
	partial class frmWirelessQRImport
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
			this.panelLeft = new System.Windows.Forms.Panel();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btUpload = new System.Windows.Forms.Button();
			this.btFile = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.iconbtnLast = new FontAwesome.Sharp.IconButton();
			this.iconbtnFirst = new FontAwesome.Sharp.IconButton();
			this.labelPageInfo = new System.Windows.Forms.Label();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.labelTotalRecords = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.panelLeft.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.iconbtnSearch);
			this.panelLeft.Controls.Add(this.txtSearch);
			this.panelLeft.Controls.Add(this.btUpload);
			this.panelLeft.Controls.Add(this.btFile);
			this.panelLeft.Controls.Add(this.txtPath);
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(334, 561);
			this.panelLeft.TabIndex = 0;
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.IconSize = 16;
			this.iconbtnSearch.Location = new System.Drawing.Point(14, 10);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(90, 23);
			this.iconbtnSearch.TabIndex = 93;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearch.Location = new System.Drawing.Point(110, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(218, 20);
			this.txtSearch.TabIndex = 92;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// btUpload
			// 
			this.btUpload.Location = new System.Drawing.Point(130, 140);
			this.btUpload.Name = "btUpload";
			this.btUpload.Size = new System.Drawing.Size(75, 23);
			this.btUpload.TabIndex = 6;
			this.btUpload.Text = "Upload";
			this.btUpload.UseVisualStyleBackColor = true;
			this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
			// 
			// btFile
			// 
			this.btFile.Location = new System.Drawing.Point(35, 140);
			this.btFile.Name = "btFile";
			this.btFile.Size = new System.Drawing.Size(75, 23);
			this.btFile.TabIndex = 5;
			this.btFile.Text = "File";
			this.btFile.UseVisualStyleBackColor = true;
			this.btFile.Click += new System.EventHandler(this.btFile_Click);
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(35, 114);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(293, 20);
			this.txtPath.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 117);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "File";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.iconbtnLast);
			this.panelContent.Controls.Add(this.iconbtnFirst);
			this.panelContent.Controls.Add(this.labelPageInfo);
			this.panelContent.Controls.Add(this.iconbtnNext);
			this.panelContent.Controls.Add(this.iconbtnPrev);
			this.panelContent.Controls.Add(this.labelTotalRecords);
			this.panelContent.Controls.Add(this.label4);
			this.panelContent.Controls.Add(this.dataGridView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(334, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(650, 561);
			this.panelContent.TabIndex = 1;
			// 
			// iconbtnLast
			// 
			this.iconbtnLast.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLast.IconColor = System.Drawing.Color.Black;
			this.iconbtnLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLast.Location = new System.Drawing.Point(392, 5);
			this.iconbtnLast.Name = "iconbtnLast";
			this.iconbtnLast.Size = new System.Drawing.Size(34, 23);
			this.iconbtnLast.TabIndex = 45;
			this.iconbtnLast.Text = ">>";
			this.iconbtnLast.UseVisualStyleBackColor = true;
			this.iconbtnLast.Click += new System.EventHandler(this.iconbtnLast_Click);
			// 
			// iconbtnFirst
			// 
			this.iconbtnFirst.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnFirst.IconColor = System.Drawing.Color.Black;
			this.iconbtnFirst.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnFirst.Location = new System.Drawing.Point(194, 5);
			this.iconbtnFirst.Name = "iconbtnFirst";
			this.iconbtnFirst.Size = new System.Drawing.Size(34, 23);
			this.iconbtnFirst.TabIndex = 44;
			this.iconbtnFirst.Text = "<<";
			this.iconbtnFirst.UseVisualStyleBackColor = true;
			this.iconbtnFirst.Click += new System.EventHandler(this.iconbtnFirst_Click);
			// 
			// labelPageInfo
			// 
			this.labelPageInfo.AutoSize = true;
			this.labelPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelPageInfo.ForeColor = System.Drawing.Color.Blue;
			this.labelPageInfo.Location = new System.Drawing.Point(275, 10);
			this.labelPageInfo.Name = "labelPageInfo";
			this.labelPageInfo.Size = new System.Drawing.Size(34, 13);
			this.labelPageInfo.TabIndex = 41;
			this.labelPageInfo.Text = "CurP";
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(352, 5);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(34, 23);
			this.iconbtnNext.TabIndex = 40;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			this.iconbtnNext.Click += new System.EventHandler(this.iconbtnNext_Click);
			// 
			// iconbtnPrev
			// 
			this.iconbtnPrev.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrev.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrev.Location = new System.Drawing.Point(234, 5);
			this.iconbtnPrev.Name = "iconbtnPrev";
			this.iconbtnPrev.Size = new System.Drawing.Size(34, 23);
			this.iconbtnPrev.TabIndex = 39;
			this.iconbtnPrev.Text = "<";
			this.iconbtnPrev.UseVisualStyleBackColor = true;
			this.iconbtnPrev.Click += new System.EventHandler(this.iconbtnPrev_Click);
			// 
			// labelTotalRecords
			// 
			this.labelTotalRecords.AutoSize = true;
			this.labelTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelTotalRecords.ForeColor = System.Drawing.Color.Blue;
			this.labelTotalRecords.Location = new System.Drawing.Point(76, 10);
			this.labelTotalRecords.Name = "labelTotalRecords";
			this.labelTotalRecords.Size = new System.Drawing.Size(87, 13);
			this.labelTotalRecords.TabIndex = 34;
			this.labelTotalRecords.Text = "Total Records";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 33;
			this.label4.Text = "Total Rows:";
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(6, 37);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(632, 512);
			this.dataGridView.TabIndex = 0;
			// 
			// frmWirelessQRImport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmWirelessQRImport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ WIRELESS QR";
			this.Load += new System.EventHandler(this.frmWirelessQRImport_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.panelContent.ResumeLayout(false);
			this.panelContent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button btUpload;
		private System.Windows.Forms.Button btFile;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Label label1;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label labelTotalRecords;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelPageInfo;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
		private FontAwesome.Sharp.IconButton iconbtnLast;
		private FontAwesome.Sharp.IconButton iconbtnFirst;
	}
}