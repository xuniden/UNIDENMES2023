namespace SMTPRORAM.Smt.OutSource
{
    partial class frmOutSourceImportOrder
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.iconbtnExport = new FontAwesome.Sharp.IconButton();
			this.iconbtnShowMrp = new FontAwesome.Sharp.IconButton();
			this.lblProcess = new System.Windows.Forms.Label();
			this.cbSheet = new System.Windows.Forms.ComboBox();
			this.iconbtnBrowse = new FontAwesome.Sharp.IconButton();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.lblCount = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOrder = new System.Windows.Forms.TextBox();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.icobtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.dgView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.iconbtnExport);
			this.splitContainer1.Panel1.Controls.Add(this.iconbtnShowMrp);
			this.splitContainer1.Panel1.Controls.Add(this.lblProcess);
			this.splitContainer1.Panel1.Controls.Add(this.cbSheet);
			this.splitContainer1.Panel1.Controls.Add(this.iconbtnBrowse);
			this.splitContainer1.Panel1.Controls.Add(this.txtFilename);
			this.splitContainer1.Panel1.Controls.Add(this.lblCount);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.txtOrder);
			this.splitContainer1.Panel1.Controls.Add(this.iconbtnDelete);
			this.splitContainer1.Panel1.Controls.Add(this.icobtnSearch);
			this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgView);
			this.splitContainer1.Size = new System.Drawing.Size(984, 561);
			this.splitContainer1.SplitterDistance = 390;
			this.splitContainer1.TabIndex = 0;
			// 
			// iconbtnExport
			// 
			this.iconbtnExport.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExport.IconColor = System.Drawing.Color.Black;
			this.iconbtnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExport.Location = new System.Drawing.Point(105, 286);
			this.iconbtnExport.Name = "iconbtnExport";
			this.iconbtnExport.Size = new System.Drawing.Size(75, 23);
			this.iconbtnExport.TabIndex = 88;
			this.iconbtnExport.Text = "Export CSV";
			this.iconbtnExport.UseVisualStyleBackColor = true;
			this.iconbtnExport.Click += new System.EventHandler(this.iconbtnExport_Click);
			// 
			// iconbtnShowMrp
			// 
			this.iconbtnShowMrp.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnShowMrp.IconColor = System.Drawing.Color.Black;
			this.iconbtnShowMrp.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnShowMrp.Location = new System.Drawing.Point(10, 286);
			this.iconbtnShowMrp.Name = "iconbtnShowMrp";
			this.iconbtnShowMrp.Size = new System.Drawing.Size(89, 23);
			this.iconbtnShowMrp.TabIndex = 87;
			this.iconbtnShowMrp.Text = "Hiển thị MRP";
			this.iconbtnShowMrp.UseVisualStyleBackColor = true;
			this.iconbtnShowMrp.Click += new System.EventHandler(this.iconbtnShowMrp_Click);
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProcess.ForeColor = System.Drawing.Color.Red;
			this.lblProcess.Location = new System.Drawing.Point(10, 84);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(50, 16);
			this.lblProcess.TabIndex = 86;
			this.lblProcess.Text = "label1";
			// 
			// cbSheet
			// 
			this.cbSheet.FormattingEnabled = true;
			this.cbSheet.Location = new System.Drawing.Point(10, 46);
			this.cbSheet.Name = "cbSheet";
			this.cbSheet.Size = new System.Drawing.Size(362, 21);
			this.cbSheet.TabIndex = 85;
			this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
			// 
			// iconbtnBrowse
			// 
			this.iconbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnBrowse.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnBrowse.IconColor = System.Drawing.Color.Black;
			this.iconbtnBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnBrowse.IconSize = 16;
			this.iconbtnBrowse.Location = new System.Drawing.Point(298, 8);
			this.iconbtnBrowse.Name = "iconbtnBrowse";
			this.iconbtnBrowse.Size = new System.Drawing.Size(74, 22);
			this.iconbtnBrowse.TabIndex = 84;
			this.iconbtnBrowse.Text = "Chọn file";
			this.iconbtnBrowse.UseVisualStyleBackColor = true;
			this.iconbtnBrowse.Click += new System.EventHandler(this.iconbtnBrowse_Click);
			// 
			// txtFilename
			// 
			this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilename.Location = new System.Drawing.Point(10, 10);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(282, 20);
			this.txtFilename.TabIndex = 83;
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCount.ForeColor = System.Drawing.Color.Red;
			this.lblCount.Location = new System.Drawing.Point(145, 197);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(41, 13);
			this.lblCount.TabIndex = 75;
			this.lblCount.Text = "label2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 197);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 13);
			this.label1.TabIndex = 74;
			this.label1.Text = "Số dòng dữ liệu tìm thấy:";
			// 
			// txtOrder
			// 
			this.txtOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrder.Location = new System.Drawing.Point(10, 226);
			this.txtOrder.Name = "txtOrder";
			this.txtOrder.Size = new System.Drawing.Size(277, 20);
			this.txtOrder.TabIndex = 73;
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.IconSize = 16;
			this.iconbtnDelete.Location = new System.Drawing.Point(298, 226);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(85, 23);
			this.iconbtnDelete.TabIndex = 72;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
			// 
			// icobtnSearch
			// 
			this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.icobtnSearch.IconColor = System.Drawing.Color.Black;
			this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.icobtnSearch.IconSize = 16;
			this.icobtnSearch.Location = new System.Drawing.Point(295, 158);
			this.icobtnSearch.Name = "icobtnSearch";
			this.icobtnSearch.Size = new System.Drawing.Size(88, 23);
			this.icobtnSearch.TabIndex = 67;
			this.icobtnSearch.Text = "Tìm kiếm";
			this.icobtnSearch.UseVisualStyleBackColor = true;
			this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(10, 161);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(279, 20);
			this.txtSearch.TabIndex = 66;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(3, 3);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(580, 551);
			this.dgView.TabIndex = 0;
			// 
			// frmOutSourceImportOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmOutSourceImportOrder";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IMPORT ORDER CỦA KHÁCH HÀNG";
			this.Load += new System.EventHandler(this.frmOutSourceImportOrder_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgView;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtOrder;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ComboBox cbSheet;
        private FontAwesome.Sharp.IconButton iconbtnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private FontAwesome.Sharp.IconButton iconbtnShowMrp;
        private FontAwesome.Sharp.IconButton iconbtnExport;
    }
}