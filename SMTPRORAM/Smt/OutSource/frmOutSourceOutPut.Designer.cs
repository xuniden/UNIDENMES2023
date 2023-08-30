namespace SMTPRORAM.Smt.OutSource
{
    partial class frmOutSourceOutPut
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
            this.iconbtnDownload = new FontAwesome.Sharp.IconButton();
            this.iconbtnTimKiem = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.iconbtnSelectFile = new FontAwesome.Sharp.IconButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
            this.icobtnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.box_ETManagerTableAdapter1 = new SMTPRORAM.BoxET.DataSetPrintReportTableAdapters.Box_ETManagerTableAdapter();
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
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnDownload);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnTimKiem);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnSelectFile);
            this.splitContainer1.Panel1.Controls.Add(this.txtFile);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnUpload);
            this.splitContainer1.Panel1.Controls.Add(this.icobtnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgView);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 0;
            // 
            // iconbtnDownload
            // 
            this.iconbtnDownload.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnDownload.IconColor = System.Drawing.Color.Black;
            this.iconbtnDownload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnDownload.Location = new System.Drawing.Point(118, 220);
            this.iconbtnDownload.Name = "iconbtnDownload";
            this.iconbtnDownload.Size = new System.Drawing.Size(113, 28);
            this.iconbtnDownload.TabIndex = 75;
            this.iconbtnDownload.Text = "Download Csv";
            this.iconbtnDownload.UseVisualStyleBackColor = true;
            this.iconbtnDownload.Click += new System.EventHandler(this.iconbtnDownload_Click);
            // 
            // iconbtnTimKiem
            // 
            this.iconbtnTimKiem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnTimKiem.IconColor = System.Drawing.Color.Black;
            this.iconbtnTimKiem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnTimKiem.Location = new System.Drawing.Point(13, 220);
            this.iconbtnTimKiem.Name = "iconbtnTimKiem";
            this.iconbtnTimKiem.Size = new System.Drawing.Size(92, 28);
            this.iconbtnTimKiem.TabIndex = 74;
            this.iconbtnTimKiem.Text = "Tìm kiếm";
            this.iconbtnTimKiem.UseVisualStyleBackColor = true;
            this.iconbtnTimKiem.Click += new System.EventHandler(this.iconbtnTimKiem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Đến ngày:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy/MM/dd H:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(66, 177);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker2.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Từ ngày:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd H:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(66, 148);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker1.TabIndex = 70;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(10, 67);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(301, 20);
            this.progressBar.TabIndex = 69;
            // 
            // iconbtnSelectFile
            // 
            this.iconbtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnSelectFile.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.iconbtnSelectFile.IconColor = System.Drawing.Color.Black;
            this.iconbtnSelectFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSelectFile.IconSize = 16;
            this.iconbtnSelectFile.Location = new System.Drawing.Point(166, 93);
            this.iconbtnSelectFile.Name = "iconbtnSelectFile";
            this.iconbtnSelectFile.Size = new System.Drawing.Size(74, 22);
            this.iconbtnSelectFile.TabIndex = 67;
            this.iconbtnSelectFile.Text = "Chọn file";
            this.iconbtnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSelectFile.UseVisualStyleBackColor = true;
            this.iconbtnSelectFile.Click += new System.EventHandler(this.iconbtnSelectFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(10, 93);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(150, 20);
            this.txtFile.TabIndex = 66;
            // 
            // iconbtnUpload
            // 
            this.iconbtnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
            this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnUpload.IconSize = 16;
            this.iconbtnUpload.Location = new System.Drawing.Point(246, 93);
            this.iconbtnUpload.Name = "iconbtnUpload";
            this.iconbtnUpload.Size = new System.Drawing.Size(66, 23);
            this.iconbtnUpload.TabIndex = 68;
            this.iconbtnUpload.Text = "Upload";
            this.iconbtnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnUpload.UseVisualStyleBackColor = true;
            this.iconbtnUpload.Click += new System.EventHandler(this.iconbtnUpload_Click);
            // 
            // icobtnSearch
            // 
            this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.icobtnSearch.IconColor = System.Drawing.Color.Black;
            this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icobtnSearch.IconSize = 16;
            this.icobtnSearch.Location = new System.Drawing.Point(237, 23);
            this.icobtnSearch.Name = "icobtnSearch";
            this.icobtnSearch.Size = new System.Drawing.Size(74, 23);
            this.icobtnSearch.TabIndex = 51;
            this.icobtnSearch.Text = "Tìm kiếm";
            this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icobtnSearch.UseVisualStyleBackColor = true;
            this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(10, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 20);
            this.txtSearch.TabIndex = 50;
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
            this.dgView.Size = new System.Drawing.Size(642, 551);
            this.dgView.TabIndex = 0;
            // 
            // box_ETManagerTableAdapter1
            // 
            this.box_ETManagerTableAdapter1.ClearBeforeFill = true;
            // 
            // frmOutSourceOutPut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmOutSourceOutPut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌNH TRẠNG XUẤT HÀNG CỦA CÁC ĐƠN HÀNG";
            this.Load += new System.EventHandler(this.frmOutSourceOutPut_Load);
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
        private System.Windows.Forms.ProgressBar progressBar;
        private FontAwesome.Sharp.IconButton iconbtnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private FontAwesome.Sharp.IconButton iconbtnDownload;
        private FontAwesome.Sharp.IconButton iconbtnTimKiem;
        private BoxET.DataSetPrintReportTableAdapters.Box_ETManagerTableAdapter box_ETManagerTableAdapter1;
    }
}