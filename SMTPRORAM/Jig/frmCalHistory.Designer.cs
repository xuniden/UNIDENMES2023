namespace SMTPRORAM.Jig
{
    partial class frmCalHistory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.iconbtnUpload = new FontAwesome.Sharp.IconButton();
            this.btUploadD = new System.Windows.Forms.Button();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtUpload = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.iconbtnExportCsv = new FontAwesome.Sharp.IconButton();
            this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
            this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
            this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
            this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.icobtnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.iconbtnUpload);
            this.panel1.Controls.Add(this.btUploadD);
            this.panel1.Controls.Add(this.cbSheet);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.txtUpload);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtReason);
            this.panel1.Controls.Add(this.txtControlNo);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.icobtnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 561);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(122, 114);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(211, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 133;
            this.label4.Text = "Ngày hiệu chỉnh mới:";
            // 
            // iconbtnUpload
            // 
            this.iconbtnUpload.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnUpload.IconColor = System.Drawing.Color.Black;
            this.iconbtnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnUpload.Location = new System.Drawing.Point(259, 313);
            this.iconbtnUpload.Name = "iconbtnUpload";
            this.iconbtnUpload.Size = new System.Drawing.Size(75, 23);
            this.iconbtnUpload.TabIndex = 131;
            this.iconbtnUpload.Text = "Upload";
            this.iconbtnUpload.UseVisualStyleBackColor = true;
            this.iconbtnUpload.Click += new System.EventHandler(this.iconbtnUpload_Click);
            // 
            // btUploadD
            // 
            this.btUploadD.Location = new System.Drawing.Point(259, 287);
            this.btUploadD.Name = "btUploadD";
            this.btUploadD.Size = new System.Drawing.Size(74, 23);
            this.btUploadD.TabIndex = 130;
            this.btUploadD.Text = "Chọn File";
            this.btUploadD.UseVisualStyleBackColor = true;
            this.btUploadD.Click += new System.EventHandler(this.btUploadD_Click);
            // 
            // cbSheet
            // 
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(16, 315);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(237, 21);
            this.cbSheet.TabIndex = 129;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 275);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(238, 10);
            this.progressBar1.TabIndex = 128;
            // 
            // txtUpload
            // 
            this.txtUpload.Location = new System.Drawing.Point(16, 289);
            this.txtUpload.Name = "txtUpload";
            this.txtUpload.Size = new System.Drawing.Size(238, 20);
            this.txtUpload.TabIndex = 127;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(122, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(211, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Ngày hiệu chỉnh cũ:";
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.Location = new System.Drawing.Point(122, 147);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(211, 20);
            this.txtReason.TabIndex = 4;
            // 
            // txtControlNo
            // 
            this.txtControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtControlNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtControlNo.Location = new System.Drawing.Point(122, 52);
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.Size = new System.Drawing.Size(211, 20);
            this.txtControlNo.TabIndex = 1;
            this.txtControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControlNo_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.iconbtnExportCsv, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 192);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 60);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // iconbtnExportCsv
            // 
            this.iconbtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.iconbtnExportCsv.IconColor = System.Drawing.Color.Black;
            this.iconbtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnExportCsv.IconSize = 16;
            this.iconbtnExportCsv.Location = new System.Drawing.Point(215, 33);
            this.iconbtnExportCsv.Name = "iconbtnExportCsv";
            this.iconbtnExportCsv.Size = new System.Drawing.Size(82, 23);
            this.iconbtnExportCsv.TabIndex = 10;
            this.iconbtnExportCsv.Text = "Export Csv";
            this.iconbtnExportCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnExportCsv.UseVisualStyleBackColor = true;
            this.iconbtnExportCsv.Click += new System.EventHandler(this.iconbtnExportCsv_Click);
            // 
            // iconbtnAdd
            // 
            this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
            this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnAdd.IconSize = 16;
            this.iconbtnAdd.Location = new System.Drawing.Point(3, 3);
            this.iconbtnAdd.Name = "iconbtnAdd";
            this.iconbtnAdd.Size = new System.Drawing.Size(79, 23);
            this.iconbtnAdd.TabIndex = 5;
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
            this.iconbtnEdit.Location = new System.Drawing.Point(109, 3);
            this.iconbtnEdit.Name = "iconbtnEdit";
            this.iconbtnEdit.Size = new System.Drawing.Size(79, 23);
            this.iconbtnEdit.TabIndex = 6;
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
            this.iconbtnDelete.Location = new System.Drawing.Point(215, 3);
            this.iconbtnDelete.Name = "iconbtnDelete";
            this.iconbtnDelete.Size = new System.Drawing.Size(80, 23);
            this.iconbtnDelete.TabIndex = 7;
            this.iconbtnDelete.Text = "Xóa";
            this.iconbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnDelete.UseVisualStyleBackColor = true;
            this.iconbtnDelete.Visible = false;
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconbtnSave.IconColor = System.Drawing.Color.Black;
            this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSave.IconSize = 16;
            this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(79, 23);
            this.iconbtnSave.TabIndex = 8;
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
            this.iconbtnCancel.Location = new System.Drawing.Point(109, 33);
            this.iconbtnCancel.Name = "iconbtnCancel";
            this.iconbtnCancel.Size = new System.Drawing.Size(79, 23);
            this.iconbtnCancel.TabIndex = 9;
            this.iconbtnCancel.Text = "Hủy bỏ";
            this.iconbtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnCancel.UseVisualStyleBackColor = true;
            this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Lý do hiệu chỉnh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Control No:";
            // 
            // icobtnSearch
            // 
            this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.icobtnSearch.IconColor = System.Drawing.Color.Black;
            this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icobtnSearch.IconSize = 16;
            this.icobtnSearch.Location = new System.Drawing.Point(259, 12);
            this.icobtnSearch.Name = "icobtnSearch";
            this.icobtnSearch.Size = new System.Drawing.Size(74, 23);
            this.icobtnSearch.TabIndex = 11;
            this.icobtnSearch.Text = "Tìm kiếm";
            this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icobtnSearch.UseVisualStyleBackColor = true;
            this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(241, 20);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(339, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 561);
            this.panel2.TabIndex = 1;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(6, 12);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(636, 537);
            this.dgView.TabIndex = 0;
            // 
            // frmCalHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCalHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LỊCH SỬ HIỆU CHỈNH, BẢO DƯỠNG, SỬA CHỮA THIẾT BỊ";
            this.Load += new System.EventHandler(this.frmCalHistory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnExportCsv;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtUpload;
        private FontAwesome.Sharp.IconButton iconbtnUpload;
        private System.Windows.Forms.Button btUploadD;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
    }
}