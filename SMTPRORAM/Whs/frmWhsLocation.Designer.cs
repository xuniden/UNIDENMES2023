namespace SMTPRORAM.Whs
{
    partial class frmWhsLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWhsLocation));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.iconbtnSelectFile = new FontAwesome.Sharp.IconButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
            this.iconbtnPaste = new FontAwesome.Sharp.IconButton();
            this.iconbtnEditmode = new FontAwesome.Sharp.IconButton();
            this.iconbtnEnable = new FontAwesome.Sharp.IconButton();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
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
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.progressBar);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnSelectFile);
            this.splitContainer1.Panel1.Controls.Add(this.txtFile);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnUpload);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnPaste);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnEditmode);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnEnable);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnSave);
            this.splitContainer1.Panel1.Controls.Add(this.icobtnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgView);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(244, 20);
            this.progressBar.TabIndex = 54;
            // 
            // iconbtnSelectFile
            // 
            this.iconbtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnSelectFile.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.iconbtnSelectFile.IconColor = System.Drawing.Color.Black;
            this.iconbtnSelectFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSelectFile.IconSize = 16;
            this.iconbtnSelectFile.Location = new System.Drawing.Point(182, 38);
            this.iconbtnSelectFile.Name = "iconbtnSelectFile";
            this.iconbtnSelectFile.Size = new System.Drawing.Size(74, 22);
            this.iconbtnSelectFile.TabIndex = 52;
            this.iconbtnSelectFile.Text = "Chọn file";
            this.iconbtnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSelectFile.UseVisualStyleBackColor = true;
            this.iconbtnSelectFile.Click += new System.EventHandler(this.iconbtnSelectFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(12, 38);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(164, 20);
            this.txtFile.TabIndex = 51;
            // 
            // iconbtnUpload
            // 
            this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
            this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnUpload.IconSize = 16;
            this.iconbtnUpload.Location = new System.Drawing.Point(12, 64);
            this.iconbtnUpload.Name = "iconbtnUpload";
            this.iconbtnUpload.Size = new System.Drawing.Size(75, 23);
            this.iconbtnUpload.TabIndex = 53;
            this.iconbtnUpload.Text = "Upload";
            this.iconbtnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnUpload.UseVisualStyleBackColor = true;
            this.iconbtnUpload.Click += new System.EventHandler(this.iconbtnUpload_Click);
            // 
            // iconbtnPaste
            // 
            this.iconbtnPaste.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnPaste.IconColor = System.Drawing.Color.Black;
            this.iconbtnPaste.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnPaste.Location = new System.Drawing.Point(166, 138);
            this.iconbtnPaste.Name = "iconbtnPaste";
            this.iconbtnPaste.Size = new System.Drawing.Size(89, 23);
            this.iconbtnPaste.TabIndex = 57;
            this.iconbtnPaste.Text = "Paste Dữ liệu";
            this.iconbtnPaste.UseVisualStyleBackColor = true;
            this.iconbtnPaste.Click += new System.EventHandler(this.iconbtnPaste_Click);
            // 
            // iconbtnEditmode
            // 
            this.iconbtnEditmode.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnEditmode.IconColor = System.Drawing.Color.Black;
            this.iconbtnEditmode.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnEditmode.Location = new System.Drawing.Point(11, 138);
            this.iconbtnEditmode.Name = "iconbtnEditmode";
            this.iconbtnEditmode.Size = new System.Drawing.Size(75, 23);
            this.iconbtnEditmode.TabIndex = 56;
            this.iconbtnEditmode.Text = "Edit Mode";
            this.iconbtnEditmode.UseVisualStyleBackColor = true;
            this.iconbtnEditmode.Click += new System.EventHandler(this.iconbtnEditmode_Click);
            // 
            // iconbtnEnable
            // 
            this.iconbtnEnable.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnEnable.IconColor = System.Drawing.Color.Black;
            this.iconbtnEnable.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnEnable.Location = new System.Drawing.Point(92, 138);
            this.iconbtnEnable.Name = "iconbtnEnable";
            this.iconbtnEnable.Size = new System.Drawing.Size(69, 23);
            this.iconbtnEnable.TabIndex = 55;
            this.iconbtnEnable.Text = "Clear Data";
            this.iconbtnEnable.UseVisualStyleBackColor = true;
            this.iconbtnEnable.Click += new System.EventHandler(this.iconbtnEnable_Click);
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconbtnSave.IconColor = System.Drawing.Color.Black;
            this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSave.IconSize = 16;
            this.iconbtnSave.Location = new System.Drawing.Point(12, 167);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(64, 23);
            this.iconbtnSave.TabIndex = 50;
            this.iconbtnSave.Text = "Ghi lại";
            this.iconbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSave.UseVisualStyleBackColor = true;
            this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
            // 
            // icobtnSearch
            // 
            this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.icobtnSearch.IconColor = System.Drawing.Color.Black;
            this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icobtnSearch.IconSize = 16;
            this.icobtnSearch.Location = new System.Drawing.Point(182, 100);
            this.icobtnSearch.Name = "icobtnSearch";
            this.icobtnSearch.Size = new System.Drawing.Size(74, 23);
            this.icobtnSearch.TabIndex = 49;
            this.icobtnSearch.Text = "Tìm kiếm";
            this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icobtnSearch.UseVisualStyleBackColor = true;
            this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(12, 102);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 20);
            this.txtSearch.TabIndex = 48;
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
            this.dgView.Size = new System.Drawing.Size(701, 555);
            this.dgView.TabIndex = 0;
            // 
            // frmWhsLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWhsLocation";
            this.Text = "CẬP NHẬT WHS LOCATION";
            this.Load += new System.EventHandler(this.frmWhsLocation_Load);
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
        private System.Windows.Forms.ProgressBar progressBar;
        private FontAwesome.Sharp.IconButton iconbtnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private FontAwesome.Sharp.IconButton iconbtnPaste;
        private FontAwesome.Sharp.IconButton iconbtnEditmode;
        private FontAwesome.Sharp.IconButton iconbtnEnable;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgView;
    }
}