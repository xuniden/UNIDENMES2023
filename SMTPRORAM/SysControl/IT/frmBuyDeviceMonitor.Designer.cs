namespace SMTPRORAM.SysControl.IT
{
    partial class frmBuyDeviceMonitor
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
            this.txtNcc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.icobtnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.iconbtnExportCsv = new FontAwesome.Sharp.IconButton();
            this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
            this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
            this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
            this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
            this.numericQty = new System.Windows.Forms.NumericUpDown();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpReceiverDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubDbNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtNcc);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.icobtnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.numericQty);
            this.splitContainer1.Panel1.Controls.Add(this.txtRemark);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.dtpReceiverDate);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtPrice);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.dtpIssueDate);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtModel);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtDesc);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtSubDbNumber);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgView);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtNcc
            // 
            this.txtNcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNcc.Location = new System.Drawing.Point(102, 266);
            this.txtNcc.Name = "txtNcc";
            this.txtNcc.Size = new System.Drawing.Size(208, 20);
            this.txtNcc.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 10020;
            this.label9.Text = "Nhà cung cấp";
            // 
            // icobtnSearch
            // 
            this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.icobtnSearch.IconColor = System.Drawing.Color.Black;
            this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icobtnSearch.IconSize = 16;
            this.icobtnSearch.Location = new System.Drawing.Point(233, 25);
            this.icobtnSearch.Name = "icobtnSearch";
            this.icobtnSearch.Size = new System.Drawing.Size(78, 23);
            this.icobtnSearch.TabIndex = 10018;
            this.icobtnSearch.Text = "Tìm kiếm";
            this.icobtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icobtnSearch.UseVisualStyleBackColor = true;
            this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(13, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 20);
            this.txtSearch.TabIndex = 10017;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 324);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 58);
            this.tableLayoutPanel1.TabIndex = 1008;
            // 
            // iconbtnExportCsv
            // 
            this.iconbtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.ArrowDown;
            this.iconbtnExportCsv.IconColor = System.Drawing.Color.Black;
            this.iconbtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnExportCsv.IconSize = 16;
            this.iconbtnExportCsv.Location = new System.Drawing.Point(201, 32);
            this.iconbtnExportCsv.Name = "iconbtnExportCsv";
            this.iconbtnExportCsv.Size = new System.Drawing.Size(94, 23);
            this.iconbtnExportCsv.TabIndex = 13;
            this.iconbtnExportCsv.Text = "Export Csv";
            this.iconbtnExportCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnExportCsv.UseVisualStyleBackColor = true;
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
            this.iconbtnAdd.TabIndex = 9;
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
            this.iconbtnEdit.Location = new System.Drawing.Point(102, 3);
            this.iconbtnEdit.Name = "iconbtnEdit";
            this.iconbtnEdit.Size = new System.Drawing.Size(93, 23);
            this.iconbtnEdit.TabIndex = 10;
            this.iconbtnEdit.Text = "Sửa";
            this.iconbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnEdit.UseVisualStyleBackColor = true;
            this.iconbtnEdit.Click += new System.EventHandler(this.iconbtnEdit_Click);
            // 
            // iconbtnDelete
            // 
            this.iconbtnDelete.Enabled = false;
            this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
            this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnDelete.IconSize = 1;
            this.iconbtnDelete.Location = new System.Drawing.Point(201, 3);
            this.iconbtnDelete.Name = "iconbtnDelete";
            this.iconbtnDelete.Size = new System.Drawing.Size(94, 23);
            this.iconbtnDelete.TabIndex = 18;
            this.iconbtnDelete.Text = "Issue + Return";
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
            this.iconbtnSave.Location = new System.Drawing.Point(3, 32);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(92, 23);
            this.iconbtnSave.TabIndex = 11;
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
            this.iconbtnCancel.Location = new System.Drawing.Point(102, 32);
            this.iconbtnCancel.Name = "iconbtnCancel";
            this.iconbtnCancel.Size = new System.Drawing.Size(93, 23);
            this.iconbtnCancel.TabIndex = 12;
            this.iconbtnCancel.Text = "Hủy bỏ";
            this.iconbtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconbtnCancel.UseVisualStyleBackColor = true;
            this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
            // 
            // numericQty
            // 
            this.numericQty.Location = new System.Drawing.Point(103, 149);
            this.numericQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericQty.Name = "numericQty";
            this.numericQty.Size = new System.Drawing.Size(120, 20);
            this.numericQty.TabIndex = 3;
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Location = new System.Drawing.Point(103, 293);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(208, 20);
            this.txtRemark.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 1007;
            this.label8.Text = "Remark:";
            // 
            // dtpReceiverDate
            // 
            this.dtpReceiverDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReceiverDate.CustomFormat = "yyyy/MM/dd";
            this.dtpReceiverDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiverDate.Location = new System.Drawing.Point(103, 237);
            this.dtpReceiverDate.Name = "dtpReceiverDate";
            this.dtpReceiverDate.Size = new System.Drawing.Size(208, 20);
            this.dtpReceiverDate.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 1006;
            this.label7.Text = "Ngày nhận:";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(103, 208);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(208, 20);
            this.txtPrice.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 1005;
            this.label6.Text = "Giá:";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpIssueDate.CustomFormat = "yyyy/MM/dd";
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueDate.Location = new System.Drawing.Point(103, 179);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(208, 20);
            this.dtpIssueDate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 1004;
            this.label5.Text = "Ngày phát hành:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 1003;
            this.label4.Text = "Qty";
            // 
            // txtModel
            // 
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(103, 120);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(208, 20);
            this.txtModel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1002;
            this.label3.Text = "Model:";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(103, 91);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(208, 20);
            this.txtDesc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1001;
            this.label2.Text = "Mô tả";
            // 
            // txtSubDbNumber
            // 
            this.txtSubDbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubDbNumber.Location = new System.Drawing.Point(103, 63);
            this.txtSubDbNumber.Name = "txtSubDbNumber";
            this.txtSubDbNumber.Size = new System.Drawing.Size(208, 20);
            this.txtSubDbNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1000;
            this.label1.Text = "Sub DB Number:";
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
            this.dgView.Size = new System.Drawing.Size(646, 555);
            this.dgView.TabIndex = 0;
            this.dgView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_CellMouseClick);
            // 
            // frmBuyDeviceMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmBuyDeviceMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ MUA THIẾT BỊ";
            this.Load += new System.EventHandler(this.frmBuyDeviceMonitor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubDbNumber;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpReceiverDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericQty;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnExportCsv;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtNcc;
        private System.Windows.Forms.Label label9;
    }
}