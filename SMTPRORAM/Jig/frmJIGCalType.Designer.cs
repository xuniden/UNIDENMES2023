namespace SMTPRORAM.Jig
{
    partial class frmJIGCalType
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDownCycle = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.chkIsDisable = new System.Windows.Forms.CheckBox();
			this.txtCalDesc = new System.Windows.Forms.TextBox();
			this.txtCalType = new System.Windows.Forms.TextBox();
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
			this.dgView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycle)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgView);
			this.splitContainer1.Size = new System.Drawing.Size(984, 561);
			this.splitContainer1.SplitterDistance = 364;
			this.splitContainer1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.numericUpDownCycle);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.chkIsDisable);
			this.groupBox2.Controls.Add(this.txtCalDesc);
			this.groupBox2.Controls.Add(this.txtCalType);
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 78);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(360, 479);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thêm mới";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(278, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 13);
			this.label4.TabIndex = 39;
			this.label4.Text = "(Tháng)";
			// 
			// numericUpDownCycle
			// 
			this.numericUpDownCycle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownCycle.Location = new System.Drawing.Point(178, 79);
			this.numericUpDownCycle.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
			this.numericUpDownCycle.Name = "numericUpDownCycle";
			this.numericUpDownCycle.Size = new System.Drawing.Size(94, 20);
			this.numericUpDownCycle.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 37;
			this.label3.Text = "Chu kỳ hiệu chỉnh";
			// 
			// chkIsDisable
			// 
			this.chkIsDisable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkIsDisable.AutoSize = true;
			this.chkIsDisable.Location = new System.Drawing.Point(178, 109);
			this.chkIsDisable.Name = "chkIsDisable";
			this.chkIsDisable.Size = new System.Drawing.Size(84, 17);
			this.chkIsDisable.TabIndex = 3;
			this.chkIsDisable.Text = "Không dùng";
			this.chkIsDisable.UseVisualStyleBackColor = true;
			// 
			// txtCalDesc
			// 
			this.txtCalDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCalDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCalDesc.Location = new System.Drawing.Point(178, 49);
			this.txtCalDesc.Name = "txtCalDesc";
			this.txtCalDesc.Size = new System.Drawing.Size(169, 20);
			this.txtCalDesc.TabIndex = 1;
			// 
			// txtCalType
			// 
			this.txtCalType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCalType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCalType.Location = new System.Drawing.Point(178, 19);
			this.txtCalType.Name = "txtCalType";
			this.txtCalType.Size = new System.Drawing.Size(169, 20);
			this.txtCalType.TabIndex = 0;
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 157);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 60);
			this.tableLayoutPanel1.TabIndex = 35;
			// 
			// iconbtnExportCsv
			// 
			this.iconbtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExportCsv.IconColor = System.Drawing.Color.Black;
			this.iconbtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExportCsv.IconSize = 16;
			this.iconbtnExportCsv.Location = new System.Drawing.Point(235, 33);
			this.iconbtnExportCsv.Name = "iconbtnExportCsv";
			this.iconbtnExportCsv.Size = new System.Drawing.Size(112, 23);
			this.iconbtnExportCsv.TabIndex = 40;
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
			this.iconbtnAdd.Size = new System.Drawing.Size(110, 23);
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
			this.iconbtnEdit.Location = new System.Drawing.Point(119, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(110, 23);
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
			this.iconbtnDelete.Location = new System.Drawing.Point(235, 3);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(112, 23);
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
			this.iconbtnSave.Size = new System.Drawing.Size(110, 23);
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
			this.iconbtnCancel.Location = new System.Drawing.Point(119, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(110, 23);
			this.iconbtnCancel.TabIndex = 17;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Mổ tả chi tiết:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Loại hiệu chỉnh";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.icobtnSearch);
			this.groupBox1.Controls.Add(this.txtSearch);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 78);
			this.groupBox1.TabIndex = 4;
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
			this.icobtnSearch.Location = new System.Drawing.Point(250, 26);
			this.icobtnSearch.Name = "icobtnSearch";
			this.icobtnSearch.Size = new System.Drawing.Size(100, 23);
			this.icobtnSearch.TabIndex = 32;
			this.icobtnSearch.Text = "Tìm kiếm";
			this.icobtnSearch.UseVisualStyleBackColor = true;
			this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(10, 28);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(234, 20);
			this.txtSearch.TabIndex = 10;
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
			this.dgView.Location = new System.Drawing.Point(12, 10);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(590, 537);
			this.dgView.TabIndex = 0;
			this.dgView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_CellMouseClick);
			// 
			// frmJIGCalType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmJIGCalType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "THIẾT LẬP LOẠI VÀ THỜI GIAN HIỆU CHỈNH";
			this.Load += new System.EventHandler(this.frmJIGCalType_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycle)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIsDisable;
        private System.Windows.Forms.TextBox txtCalDesc;
        private System.Windows.Forms.TextBox txtCalType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.NumericUpDown numericUpDownCycle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton iconbtnExportCsv;
    }
}