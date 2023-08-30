namespace SMTPRORAM.Smt.OutSource
{
    partial class frmOutSourceInput
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.iconbtnTonKho = new FontAwesome.Sharp.IconButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.iconbtnSelectFile = new FontAwesome.Sharp.IconButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
            this.icobtnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iconbtnTonKho);
            this.splitContainer2.Panel1.Controls.Add(this.progressBar);
            this.splitContainer2.Panel1.Controls.Add(this.iconbtnSelectFile);
            this.splitContainer2.Panel1.Controls.Add(this.txtFile);
            this.splitContainer2.Panel1.Controls.Add(this.iconbtnUpload);
            this.splitContainer2.Panel1.Controls.Add(this.icobtnSearch);
            this.splitContainer2.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgView);
            this.splitContainer2.Size = new System.Drawing.Size(984, 561);
            this.splitContainer2.SplitterDistance = 410;
            this.splitContainer2.TabIndex = 1;
            // 
            // iconbtnTonKho
            // 
            this.iconbtnTonKho.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnTonKho.IconColor = System.Drawing.Color.Black;
            this.iconbtnTonKho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnTonKho.Location = new System.Drawing.Point(8, 125);
            this.iconbtnTonKho.Name = "iconbtnTonKho";
            this.iconbtnTonKho.Size = new System.Drawing.Size(89, 23);
            this.iconbtnTonKho.TabIndex = 70;
            this.iconbtnTonKho.Text = "Xem Tồn Kho";
            this.iconbtnTonKho.UseVisualStyleBackColor = true;
            this.iconbtnTonKho.Click += new System.EventHandler(this.iconbtnTonKho_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(8, 10);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(392, 20);
            this.progressBar.TabIndex = 65;
            // 
            // iconbtnSelectFile
            // 
            this.iconbtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnSelectFile.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.iconbtnSelectFile.IconColor = System.Drawing.Color.Black;
            this.iconbtnSelectFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSelectFile.IconSize = 16;
            this.iconbtnSelectFile.Location = new System.Drawing.Point(252, 34);
            this.iconbtnSelectFile.Name = "iconbtnSelectFile";
            this.iconbtnSelectFile.Size = new System.Drawing.Size(74, 22);
            this.iconbtnSelectFile.TabIndex = 63;
            this.iconbtnSelectFile.Text = "Chọn file";
            this.iconbtnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSelectFile.UseVisualStyleBackColor = true;
            this.iconbtnSelectFile.Click += new System.EventHandler(this.iconbtnSelectFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(8, 36);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(238, 20);
            this.txtFile.TabIndex = 62;
            // 
            // iconbtnUpload
            // 
            this.iconbtnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
            this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnUpload.IconSize = 16;
            this.iconbtnUpload.Location = new System.Drawing.Point(335, 33);
            this.iconbtnUpload.Name = "iconbtnUpload";
            this.iconbtnUpload.Size = new System.Drawing.Size(66, 23);
            this.iconbtnUpload.TabIndex = 64;
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
            this.icobtnSearch.Location = new System.Drawing.Point(326, 80);
            this.icobtnSearch.Name = "icobtnSearch";
            this.icobtnSearch.Size = new System.Drawing.Size(74, 23);
            this.icobtnSearch.TabIndex = 60;
            this.icobtnSearch.Text = "Tìm kiếm";
            this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icobtnSearch.UseVisualStyleBackColor = true;
            this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(10, 83);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(310, 20);
            this.txtSearch.TabIndex = 59;
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
            this.dgView.Size = new System.Drawing.Size(560, 551);
            this.dgView.TabIndex = 0;
            // 
            // frmOutSourceInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmOutSourceInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHẬP SỐ LƯỢNG ĐẦU VÀO";
            this.Load += new System.EventHandler(this.frmOutSourceInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ProgressBar progressBar;
        private FontAwesome.Sharp.IconButton iconbtnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private FontAwesome.Sharp.IconButton iconbtnTonKho;
    }
}