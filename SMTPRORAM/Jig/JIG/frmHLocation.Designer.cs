namespace SMTPRORAM.Jig.JIG
{
    partial class frmHLocation
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
			this.lblProcess = new System.Windows.Forms.Label();
			this.cbSheet = new System.Windows.Forms.ComboBox();
			this.iconbtnBrowse = new FontAwesome.Sharp.IconButton();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkIsDisable = new System.Windows.Forms.CheckBox();
			this.txtLocDesc = new System.Windows.Forms.TextBox();
			this.txtLocCode = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnExportCsv = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.icobtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblProcess);
			this.panel1.Controls.Add(this.cbSheet);
			this.panel1.Controls.Add(this.iconbtnBrowse);
			this.panel1.Controls.Add(this.txtFilename);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(348, 561);
			this.panel1.TabIndex = 0;
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProcess.ForeColor = System.Drawing.Color.Red;
			this.lblProcess.Location = new System.Drawing.Point(10, 478);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(50, 16);
			this.lblProcess.TabIndex = 92;
			this.lblProcess.Text = "label1";
			// 
			// cbSheet
			// 
			this.cbSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSheet.FormattingEnabled = true;
			this.cbSheet.Location = new System.Drawing.Point(10, 440);
			this.cbSheet.Name = "cbSheet";
			this.cbSheet.Size = new System.Drawing.Size(328, 21);
			this.cbSheet.TabIndex = 91;
			this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
			// 
			// iconbtnBrowse
			// 
			this.iconbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnBrowse.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnBrowse.IconColor = System.Drawing.Color.Black;
			this.iconbtnBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnBrowse.IconSize = 16;
			this.iconbtnBrowse.Location = new System.Drawing.Point(246, 404);
			this.iconbtnBrowse.Name = "iconbtnBrowse";
			this.iconbtnBrowse.Size = new System.Drawing.Size(96, 22);
			this.iconbtnBrowse.TabIndex = 90;
			this.iconbtnBrowse.Text = "Chọn file";
			this.iconbtnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnBrowse.UseVisualStyleBackColor = true;
			this.iconbtnBrowse.Click += new System.EventHandler(this.iconbtnBrowse_Click);
			// 
			// txtFilename
			// 
			this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilename.Location = new System.Drawing.Point(10, 405);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(230, 20);
			this.txtFilename.TabIndex = 89;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkIsDisable);
			this.groupBox2.Controls.Add(this.txtLocDesc);
			this.groupBox2.Controls.Add(this.txtLocCode);
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(348, 198);
			this.groupBox2.TabIndex = 88;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thêm mới";
			// 
			// chkIsDisable
			// 
			this.chkIsDisable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkIsDisable.AutoSize = true;
			this.chkIsDisable.Location = new System.Drawing.Point(132, 83);
			this.chkIsDisable.Name = "chkIsDisable";
			this.chkIsDisable.Size = new System.Drawing.Size(202, 17);
			this.chkIsDisable.TabIndex = 2;
			this.chkIsDisable.Text = "Trạng thái (Tích là không hoạt động)";
			this.chkIsDisable.UseVisualStyleBackColor = true;
			// 
			// txtLocDesc
			// 
			this.txtLocDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLocDesc.Location = new System.Drawing.Point(132, 54);
			this.txtLocDesc.Name = "txtLocDesc";
			this.txtLocDesc.Size = new System.Drawing.Size(206, 20);
			this.txtLocDesc.TabIndex = 1;
			// 
			// txtLocCode
			// 
			this.txtLocCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLocCode.Location = new System.Drawing.Point(132, 25);
			this.txtLocCode.Name = "txtLocCode";
			this.txtLocCode.Size = new System.Drawing.Size(206, 20);
			this.txtLocCode.TabIndex = 0;
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 117);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 60);
			this.tableLayoutPanel1.TabIndex = 35;
			// 
			// iconbtnExportCsv
			// 
			this.iconbtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExportCsv.IconColor = System.Drawing.Color.Black;
			this.iconbtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExportCsv.IconSize = 16;
			this.iconbtnExportCsv.Location = new System.Drawing.Point(227, 33);
			this.iconbtnExportCsv.Name = "iconbtnExportCsv";
			this.iconbtnExportCsv.Size = new System.Drawing.Size(108, 23);
			this.iconbtnExportCsv.TabIndex = 87;
			this.iconbtnExportCsv.Text = "Export Csv";
			this.iconbtnExportCsv.UseVisualStyleBackColor = true;
			this.iconbtnExportCsv.Click += new System.EventHandler(this.iconbtnExportCsv_Click);
			// 
			// iconbtnAdd
			// 
			this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
			this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnAdd.IconSize = 16;
			this.iconbtnAdd.Location = new System.Drawing.Point(3, 3);
			this.iconbtnAdd.Name = "iconbtnAdd";
			this.iconbtnAdd.Size = new System.Drawing.Size(106, 23);
			this.iconbtnAdd.TabIndex = 13;
			this.iconbtnAdd.Text = "Thêm";
			this.iconbtnAdd.UseVisualStyleBackColor = true;
			this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
			// 
			// iconbtnEdit
			// 
			this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
			this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnEdit.IconSize = 16;
			this.iconbtnEdit.Location = new System.Drawing.Point(115, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(106, 23);
			this.iconbtnEdit.TabIndex = 14;
			this.iconbtnEdit.Text = "Sửa";
			this.iconbtnEdit.UseVisualStyleBackColor = true;
			this.iconbtnEdit.Click += new System.EventHandler(this.iconbtnEdit_Click);
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.IconSize = 16;
			this.iconbtnDelete.Location = new System.Drawing.Point(227, 3);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(108, 23);
			this.iconbtnDelete.TabIndex = 15;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 16;
			this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(106, 23);
			this.iconbtnSave.TabIndex = 16;
			this.iconbtnSave.Text = "Ghi lại";
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// iconbtnCancel
			// 
			this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
			this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnCancel.IconSize = 16;
			this.iconbtnCancel.Location = new System.Drawing.Point(115, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(106, 23);
			this.iconbtnCancel.TabIndex = 17;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Mô tả JIG:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Mã vị trí JIG:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.icobtnSearch);
			this.groupBox1.Controls.Add(this.txtSearch);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(348, 72);
			this.groupBox1.TabIndex = 87;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tìm kiếm";
			// 
			// icobtnSearch
			// 
			this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.icobtnSearch.IconColor = System.Drawing.Color.Black;
			this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.icobtnSearch.IconSize = 16;
			this.icobtnSearch.Location = new System.Drawing.Point(246, 26);
			this.icobtnSearch.Name = "icobtnSearch";
			this.icobtnSearch.Size = new System.Drawing.Size(98, 23);
			this.icobtnSearch.TabIndex = 32;
			this.icobtnSearch.Text = "Tìm kiếm";
			this.icobtnSearch.UseVisualStyleBackColor = true;
			this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(10, 27);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(230, 20);
			this.txtSearch.TabIndex = 10;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(348, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(636, 561);
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
			this.dgView.Location = new System.Drawing.Point(6, 3);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(627, 555);
			this.dgView.TabIndex = 0;
			this.dgView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_CellMouseClick);
			// 
			// frmHLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmHLocation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ VỊ TRÍ CỦA THIẾT BỊ  JIG";
			this.Load += new System.EventHandler(this.frmHLocation_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ComboBox cbSheet;
        private FontAwesome.Sharp.IconButton iconbtnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIsDisable;
        private System.Windows.Forms.TextBox txtLocDesc;
        private System.Windows.Forms.TextBox txtLocCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnExportCsv;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}