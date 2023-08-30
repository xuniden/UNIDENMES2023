namespace SMTPRORAM.Whs
{
    partial class frmReceivingInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceivingInput));
            this.dgView = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteDataAfterCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconbtnSelectFile = new FontAwesome.Sharp.IconButton();
            this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconbtnInlistreturn = new FontAwesome.Sharp.IconButton();
            this.iconbtnIqcLabel = new FontAwesome.Sharp.IconButton();
            this.iconbtnPaste = new FontAwesome.Sharp.IconButton();
            this.iconbtnEditmode = new FontAwesome.Sharp.IconButton();
            this.iconbtnEnable = new FontAwesome.Sharp.IconButton();
            this.iconbtnViewReport = new FontAwesome.Sharp.IconButton();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
            this.icobtnSearch = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgView.Size = new System.Drawing.Size(978, 461);
            this.dgView.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgView);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.progressBar);
            this.splitContainer2.Panel1.Controls.Add(this.iconbtnSelectFile);
            this.splitContainer2.Panel1.Controls.Add(this.txtFile);
            this.splitContainer2.Panel1.Controls.Add(this.iconbtnUpload);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.iconButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iconbtnInlistreturn);
            this.splitContainer2.Panel2.Controls.Add(this.iconbtnIqcLabel);
            this.splitContainer2.Panel2.Controls.Add(this.iconbtnPaste);
            this.splitContainer2.Panel2.Controls.Add(this.iconbtnEditmode);
            this.splitContainer2.Panel2.Controls.Add(this.iconbtnEnable);
            this.splitContainer2.Panel2.Controls.Add(this.iconbtnViewReport);
            this.splitContainer2.Panel2.Controls.Add(this.iconbtnSave);
            this.splitContainer2.Panel2.Controls.Add(this.icobtnSearch);
            this.splitContainer2.Panel2.Controls.Add(this.txtSearch);
            this.splitContainer2.Size = new System.Drawing.Size(984, 90);
            this.splitContainer2.SplitterDistance = 403;
            this.splitContainer2.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(379, 14);
            this.progressBar.TabIndex = 43;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(12, 24);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(299, 20);
            this.txtFile.TabIndex = 40;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(13, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 20);
            this.txtSearch.TabIndex = 31;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteDataAfterCopyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 26);
            // 
            // pasteDataAfterCopyToolStripMenuItem
            // 
            this.pasteDataAfterCopyToolStripMenuItem.Name = "pasteDataAfterCopyToolStripMenuItem";
            this.pasteDataAfterCopyToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.pasteDataAfterCopyToolStripMenuItem.Text = "Paste Data After Copy";
            // 
            // iconbtnSelectFile
            // 
            this.iconbtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnSelectFile.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.iconbtnSelectFile.IconColor = System.Drawing.Color.Black;
            this.iconbtnSelectFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSelectFile.IconSize = 16;
            this.iconbtnSelectFile.Location = new System.Drawing.Point(317, 22);
            this.iconbtnSelectFile.Name = "iconbtnSelectFile";
            this.iconbtnSelectFile.Size = new System.Drawing.Size(74, 23);
            this.iconbtnSelectFile.TabIndex = 41;
            this.iconbtnSelectFile.Text = "Chọn file";
            this.iconbtnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSelectFile.UseVisualStyleBackColor = true;
            this.iconbtnSelectFile.Click += new System.EventHandler(this.iconbtnSelectFile_Click);
            // 
            // iconbtnUpload
            // 
            this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
            this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnUpload.IconSize = 16;
            this.iconbtnUpload.Location = new System.Drawing.Point(12, 52);
            this.iconbtnUpload.Name = "iconbtnUpload";
            this.iconbtnUpload.Size = new System.Drawing.Size(75, 23);
            this.iconbtnUpload.TabIndex = 42;
            this.iconbtnUpload.Text = "Upload";
            this.iconbtnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnUpload.UseVisualStyleBackColor = true;
            this.iconbtnUpload.Click += new System.EventHandler(this.iconbtnUpload_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.ForeColor = System.Drawing.Color.Blue;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(336, 65);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(229, 23);
            this.iconButton1.TabIndex = 50;
            this.iconButton1.Text = "RECEIVING IN LIST GIAO HANG";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconbtnInlistreturn
            // 
            this.iconbtnInlistreturn.ForeColor = System.Drawing.Color.Blue;
            this.iconbtnInlistreturn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnInlistreturn.IconColor = System.Drawing.Color.Black;
            this.iconbtnInlistreturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnInlistreturn.Location = new System.Drawing.Point(489, 10);
            this.iconbtnInlistreturn.Name = "iconbtnInlistreturn";
            this.iconbtnInlistreturn.Size = new System.Drawing.Size(76, 52);
            this.iconbtnInlistreturn.TabIndex = 49;
            this.iconbtnInlistreturn.Text = "IN LIST RETURN";
            this.iconbtnInlistreturn.UseVisualStyleBackColor = true;
            this.iconbtnInlistreturn.Click += new System.EventHandler(this.iconbtnInlistreturn_Click);
            // 
            // iconbtnIqcLabel
            // 
            this.iconbtnIqcLabel.ForeColor = System.Drawing.Color.Blue;
            this.iconbtnIqcLabel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnIqcLabel.IconColor = System.Drawing.Color.Black;
            this.iconbtnIqcLabel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnIqcLabel.Location = new System.Drawing.Point(336, 39);
            this.iconbtnIqcLabel.Name = "iconbtnIqcLabel";
            this.iconbtnIqcLabel.Size = new System.Drawing.Size(147, 23);
            this.iconbtnIqcLabel.TabIndex = 48;
            this.iconbtnIqcLabel.Text = "IN LOTTAG IQC LABEL";
            this.iconbtnIqcLabel.UseVisualStyleBackColor = true;
            this.iconbtnIqcLabel.Click += new System.EventHandler(this.iconbtnIqcLabel_Click);
            // 
            // iconbtnPaste
            // 
            this.iconbtnPaste.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnPaste.IconColor = System.Drawing.Color.Black;
            this.iconbtnPaste.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnPaste.Location = new System.Drawing.Point(168, 39);
            this.iconbtnPaste.Name = "iconbtnPaste";
            this.iconbtnPaste.Size = new System.Drawing.Size(89, 23);
            this.iconbtnPaste.TabIndex = 47;
            this.iconbtnPaste.Text = "Paste Dữ liệu";
            this.iconbtnPaste.UseVisualStyleBackColor = true;
            this.iconbtnPaste.Click += new System.EventHandler(this.iconbtnPaste_Click);
            // 
            // iconbtnEditmode
            // 
            this.iconbtnEditmode.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnEditmode.IconColor = System.Drawing.Color.Black;
            this.iconbtnEditmode.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnEditmode.Location = new System.Drawing.Point(13, 39);
            this.iconbtnEditmode.Name = "iconbtnEditmode";
            this.iconbtnEditmode.Size = new System.Drawing.Size(75, 23);
            this.iconbtnEditmode.TabIndex = 46;
            this.iconbtnEditmode.Text = "Edit Mode";
            this.iconbtnEditmode.UseVisualStyleBackColor = true;
            this.iconbtnEditmode.Click += new System.EventHandler(this.iconbtnEditmode_Click);
            // 
            // iconbtnEnable
            // 
            this.iconbtnEnable.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnEnable.IconColor = System.Drawing.Color.Black;
            this.iconbtnEnable.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnEnable.Location = new System.Drawing.Point(93, 39);
            this.iconbtnEnable.Name = "iconbtnEnable";
            this.iconbtnEnable.Size = new System.Drawing.Size(69, 23);
            this.iconbtnEnable.TabIndex = 45;
            this.iconbtnEnable.Text = "Clear Data";
            this.iconbtnEnable.UseVisualStyleBackColor = true;
            this.iconbtnEnable.Click += new System.EventHandler(this.iconbtnEnable_Click);
            // 
            // iconbtnViewReport
            // 
            this.iconbtnViewReport.BackColor = System.Drawing.Color.Transparent;
            this.iconbtnViewReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconbtnViewReport.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnViewReport.IconColor = System.Drawing.Color.Black;
            this.iconbtnViewReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnViewReport.Location = new System.Drawing.Point(336, 10);
            this.iconbtnViewReport.Name = "iconbtnViewReport";
            this.iconbtnViewReport.Size = new System.Drawing.Size(147, 23);
            this.iconbtnViewReport.TabIndex = 44;
            this.iconbtnViewReport.Text = "IN LOTTAG IQC URGENT";
            this.iconbtnViewReport.UseVisualStyleBackColor = false;
            this.iconbtnViewReport.Click += new System.EventHandler(this.iconbtnViewReport_Click);
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconbtnSave.IconColor = System.Drawing.Color.Black;
            this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSave.IconSize = 16;
            this.iconbtnSave.Location = new System.Drawing.Point(263, 39);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(64, 23);
            this.iconbtnSave.TabIndex = 34;
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
            this.icobtnSearch.Location = new System.Drawing.Point(239, 10);
            this.icobtnSearch.Name = "icobtnSearch";
            this.icobtnSearch.Size = new System.Drawing.Size(74, 23);
            this.icobtnSearch.TabIndex = 32;
            this.icobtnSearch.Text = "Tìm kiếm";
            this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icobtnSearch.UseVisualStyleBackColor = true;
            this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
            // 
            // frmReceivingInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReceivingInput";
            this.Text = "Quản lý nhập liệu Receiving";
            this.Load += new System.EventHandler(this.frmReceivingInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ProgressBar progressBar;
        private FontAwesome.Sharp.IconButton iconbtnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private FontAwesome.Sharp.IconButton iconbtnPaste;
        private FontAwesome.Sharp.IconButton iconbtnEditmode;
        private FontAwesome.Sharp.IconButton iconbtnEnable;
        private FontAwesome.Sharp.IconButton iconbtnViewReport;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pasteDataAfterCopyToolStripMenuItem;
        private FontAwesome.Sharp.IconButton iconbtnIqcLabel;
        private FontAwesome.Sharp.IconButton iconbtnInlistreturn;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}