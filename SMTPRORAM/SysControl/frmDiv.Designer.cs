namespace SMTPRORAM.SysControl
{
    partial class frmDiv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiv));
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtDivCode = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
            this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
            this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
            this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
            this.txtDivDesc = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.iconbtnSelectFile = new FontAwesome.Sharp.IconButton();
            this.icobtnSearch = new FontAwesome.Sharp.IconButton();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(18, 283);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(211, 20);
            this.txtFile.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Div Desc";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(15, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(211, 20);
            this.txtSearch.TabIndex = 29;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // txtDivCode
            // 
            this.txtDivCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDivCode.Location = new System.Drawing.Point(68, 68);
            this.txtDivCode.Name = "txtDivCode";
            this.txtDivCode.Size = new System.Drawing.Size(238, 20);
            this.txtDivCode.TabIndex = 23;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(18, 263);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(291, 13);
            this.progressBar.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.iconbtnAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 159);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 60);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // iconbtnAdd
            // 
            this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
            this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnAdd.IconSize = 16;
            this.iconbtnAdd.Location = new System.Drawing.Point(3, 3);
            this.iconbtnAdd.Name = "iconbtnAdd";
            this.iconbtnAdd.Size = new System.Drawing.Size(92, 23);
            this.iconbtnAdd.TabIndex = 13;
            this.iconbtnAdd.Text = "Thêm";
            this.iconbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnAdd.UseVisualStyleBackColor = true;
            this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
            // 
            // iconbtnEdit
            // 
            this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
            this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnEdit.IconSize = 16;
            this.iconbtnEdit.Location = new System.Drawing.Point(101, 3);
            this.iconbtnEdit.Name = "iconbtnEdit";
            this.iconbtnEdit.Size = new System.Drawing.Size(92, 23);
            this.iconbtnEdit.TabIndex = 14;
            this.iconbtnEdit.Text = "Sửa";
            this.iconbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnEdit.UseVisualStyleBackColor = true;
            this.iconbtnEdit.Click += new System.EventHandler(this.iconbtnEdit_Click);
            // 
            // iconbtnDelete
            // 
            this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
            this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnDelete.IconSize = 16;
            this.iconbtnDelete.Location = new System.Drawing.Point(199, 3);
            this.iconbtnDelete.Name = "iconbtnDelete";
            this.iconbtnDelete.Size = new System.Drawing.Size(95, 23);
            this.iconbtnDelete.TabIndex = 15;
            this.iconbtnDelete.Text = "Xóa";
            this.iconbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnDelete.UseVisualStyleBackColor = true;
            this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconbtnSave.IconColor = System.Drawing.Color.Black;
            this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSave.IconSize = 16;
            this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(92, 23);
            this.iconbtnSave.TabIndex = 16;
            this.iconbtnSave.Text = "Ghi lại";
            this.iconbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSave.UseVisualStyleBackColor = true;
            this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
            // 
            // iconbtnCancel
            // 
            this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.XmarkSquare;
            this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
            this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnCancel.IconSize = 16;
            this.iconbtnCancel.Location = new System.Drawing.Point(101, 33);
            this.iconbtnCancel.Name = "iconbtnCancel";
            this.iconbtnCancel.Size = new System.Drawing.Size(92, 23);
            this.iconbtnCancel.TabIndex = 17;
            this.iconbtnCancel.Text = "Hủy bỏ";
            this.iconbtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnCancel.UseVisualStyleBackColor = true;
            this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
            // 
            // txtDivDesc
            // 
            this.txtDivDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDivDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDivDesc.Location = new System.Drawing.Point(68, 103);
            this.txtDivDesc.Name = "txtDivDesc";
            this.txtDivDesc.Size = new System.Drawing.Size(238, 20);
            this.txtDivDesc.TabIndex = 25;
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnUpload);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.iconbtnSelectFile);
            this.splitContainer1.Panel1.Controls.Add(this.txtDivCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtFile);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.icobtnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtDivDesc);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgView);
            this.splitContainer1.Size = new System.Drawing.Size(995, 569);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 1;
            // 
            // iconbtnUpload
            // 
            this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
            this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnUpload.IconSize = 16;
            this.iconbtnUpload.Location = new System.Drawing.Point(18, 311);
            this.iconbtnUpload.Name = "iconbtnUpload";
            this.iconbtnUpload.Size = new System.Drawing.Size(75, 23);
            this.iconbtnUpload.TabIndex = 33;
            this.iconbtnUpload.Text = "Upload";
            this.iconbtnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnUpload.UseVisualStyleBackColor = true;
            this.iconbtnUpload.Click += new System.EventHandler(this.iconbtnUpload_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Div Code";
            // 
            // iconbtnSelectFile
            // 
            this.iconbtnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconbtnSelectFile.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.iconbtnSelectFile.IconColor = System.Drawing.Color.Black;
            this.iconbtnSelectFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSelectFile.IconSize = 16;
            this.iconbtnSelectFile.Location = new System.Drawing.Point(235, 282);
            this.iconbtnSelectFile.Name = "iconbtnSelectFile";
            this.iconbtnSelectFile.Size = new System.Drawing.Size(74, 23);
            this.iconbtnSelectFile.TabIndex = 32;
            this.iconbtnSelectFile.Text = "Chọn file";
            this.iconbtnSelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnSelectFile.UseVisualStyleBackColor = true;
            this.iconbtnSelectFile.Click += new System.EventHandler(this.iconbtnSelectFile_Click);
            // 
            // icobtnSearch
            // 
            this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.icobtnSearch.IconColor = System.Drawing.Color.Black;
            this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icobtnSearch.IconSize = 16;
            this.icobtnSearch.Location = new System.Drawing.Point(232, 24);
            this.icobtnSearch.Name = "icobtnSearch";
            this.icobtnSearch.Size = new System.Drawing.Size(74, 23);
            this.icobtnSearch.TabIndex = 30;
            this.icobtnSearch.Text = "Tìm kiếm";
            this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icobtnSearch.UseVisualStyleBackColor = true;
            this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(0, 0);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(660, 569);
            this.dgView.TabIndex = 0;
            this.dgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellDoubleClick);
            // 
            // frmDiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 569);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng ban";
            this.Load += new System.EventHandler(this.frmDiv_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnSelectFile;
        private System.Windows.Forms.TextBox txtDivCode;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private System.Windows.Forms.TextBox txtDivDesc;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgView;
    }
}