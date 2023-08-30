namespace SMTPRORAM.Jig
{
    partial class frmJigUpdateNgayHieuChuan
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
			this.panelTitle = new System.Windows.Forms.Panel();
			this.cbSheet = new System.Windows.Forms.ComboBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
			this.btUploadD = new System.Windows.Forms.Button();
			this.txtUpload = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelTitle.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTitle
			// 
			this.panelTitle.Controls.Add(this.cbSheet);
			this.panelTitle.Controls.Add(this.progressBar1);
			this.panelTitle.Controls.Add(this.iconbtnUpload);
			this.panelTitle.Controls.Add(this.btUploadD);
			this.panelTitle.Controls.Add(this.txtUpload);
			this.panelTitle.Controls.Add(this.label1);
			this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitle.Location = new System.Drawing.Point(0, 0);
			this.panelTitle.Name = "panelTitle";
			this.panelTitle.Size = new System.Drawing.Size(984, 75);
			this.panelTitle.TabIndex = 0;
			// 
			// cbSheet
			// 
			this.cbSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSheet.FormattingEnabled = true;
			this.cbSheet.Location = new System.Drawing.Point(39, 43);
			this.cbSheet.Name = "cbSheet";
			this.cbSheet.Size = new System.Drawing.Size(394, 21);
			this.cbSheet.TabIndex = 126;
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(39, 3);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(394, 10);
			this.progressBar1.TabIndex = 14;
			// 
			// iconbtnUpload
			// 
			this.iconbtnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
			this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnUpload.Location = new System.Drawing.Point(440, 41);
			this.iconbtnUpload.Name = "iconbtnUpload";
			this.iconbtnUpload.Size = new System.Drawing.Size(94, 23);
			this.iconbtnUpload.TabIndex = 13;
			this.iconbtnUpload.Text = "Upload";
			this.iconbtnUpload.UseVisualStyleBackColor = true;
			this.iconbtnUpload.Click += new System.EventHandler(this.iconbtnUpload_Click);
			// 
			// btUploadD
			// 
			this.btUploadD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btUploadD.Location = new System.Drawing.Point(440, 15);
			this.btUploadD.Name = "btUploadD";
			this.btUploadD.Size = new System.Drawing.Size(93, 23);
			this.btUploadD.TabIndex = 12;
			this.btUploadD.Text = "Chọn File";
			this.btUploadD.UseVisualStyleBackColor = true;
			this.btUploadD.Click += new System.EventHandler(this.btUploadD_Click);
			// 
			// txtUpload
			// 
			this.txtUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUpload.Location = new System.Drawing.Point(39, 17);
			this.txtUpload.Name = "txtUpload";
			this.txtUpload.Size = new System.Drawing.Size(395, 20);
			this.txtUpload.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Path";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 75);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 486);
			this.panelContent.TabIndex = 1;
			// 
			// dgView
			// 
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(12, 6);
			this.dgView.Name = "dgView";
			this.dgView.Size = new System.Drawing.Size(960, 468);
			this.dgView.TabIndex = 0;
			// 
			// frmJigUpdateNgayHieuChuan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelTitle);
			this.Name = "frmJigUpdateNgayHieuChuan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CẬP NHẬN THÔNG TIN NGÀY HIỆU CHUẨN";
			this.panelTitle.ResumeLayout(false);
			this.panelTitle.PerformLayout();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Button btUploadD;
        private System.Windows.Forms.TextBox txtUpload;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox cbSheet;
    }
}