namespace SMTPRORAM.Jig
{
    partial class frmEQRepairHistory
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.txtControlNo = new System.Windows.Forms.TextBox();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnExportCsv = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.icobtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbVitri = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.pBSau = new System.Windows.Forms.PictureBox();
			this.pBTruoc = new System.Windows.Forms.PictureBox();
			this.iconbtnSimage = new FontAwesome.Sharp.IconButton();
			this.iconbtnTimage = new FontAwesome.Sharp.IconButton();
			this.txtPahtImage02 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPahtImage01 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtLKTT = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.richRepairAction = new System.Windows.Forms.RichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.richRepairReason = new System.Windows.Forms.RichTextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.label12 = new System.Windows.Forms.Label();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pBSau)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pBTruoc)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
			this.dateTimePicker1.Enabled = false;
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(157, 69);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(235, 20);
			this.dateTimePicker1.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Ngày sửa:";
			// 
			// txtControlNo
			// 
			this.txtControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtControlNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtControlNo.Location = new System.Drawing.Point(157, 41);
			this.txtControlNo.Name = "txtControlNo";
			this.txtControlNo.Size = new System.Drawing.Size(236, 20);
			this.txtControlNo.TabIndex = 1;
			this.txtControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControlNo_KeyDown);
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.Enabled = false;
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.IconSize = 16;
			this.iconbtnDelete.Location = new System.Drawing.Point(255, 3);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(122, 23);
			this.iconbtnDelete.TabIndex = 24;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			this.iconbtnDelete.Visible = false;
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 16;
			this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(120, 23);
			this.iconbtnSave.TabIndex = 25;
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
			this.iconbtnCancel.Location = new System.Drawing.Point(129, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(120, 23);
			this.iconbtnCancel.TabIndex = 26;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 489);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 60);
			this.tableLayoutPanel1.TabIndex = 48;
			// 
			// iconbtnExportCsv
			// 
			this.iconbtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExportCsv.IconColor = System.Drawing.Color.Black;
			this.iconbtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExportCsv.IconSize = 16;
			this.iconbtnExportCsv.Location = new System.Drawing.Point(255, 33);
			this.iconbtnExportCsv.Name = "iconbtnExportCsv";
			this.iconbtnExportCsv.Size = new System.Drawing.Size(122, 23);
			this.iconbtnExportCsv.TabIndex = 27;
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
			this.iconbtnAdd.Size = new System.Drawing.Size(120, 23);
			this.iconbtnAdd.TabIndex = 22;
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
			this.iconbtnEdit.Location = new System.Drawing.Point(129, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(120, 23);
			this.iconbtnEdit.TabIndex = 23;
			this.iconbtnEdit.Text = "Sửa";
			this.iconbtnEdit.UseVisualStyleBackColor = true;
			this.iconbtnEdit.Visible = false;
			this.iconbtnEdit.Click += new System.EventHandler(this.iconbtnEdit_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nguyên nhân:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Control No:";
			// 
			// icobtnSearch
			// 
			this.icobtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.icobtnSearch.IconColor = System.Drawing.Color.Black;
			this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.icobtnSearch.IconSize = 16;
			this.icobtnSearch.Location = new System.Drawing.Point(294, 11);
			this.icobtnSearch.Name = "icobtnSearch";
			this.icobtnSearch.Size = new System.Drawing.Size(99, 23);
			this.icobtnSearch.TabIndex = 101;
			this.icobtnSearch.Text = "Tìm kiếm";
			this.icobtnSearch.UseVisualStyleBackColor = true;
			this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(12, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(276, 20);
			this.txtSearch.TabIndex = 100;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbStatus);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.cbVitri);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.pBSau);
			this.panel1.Controls.Add(this.pBTruoc);
			this.panel1.Controls.Add(this.iconbtnSimage);
			this.panel1.Controls.Add(this.iconbtnTimage);
			this.panel1.Controls.Add(this.txtPahtImage02);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.txtPahtImage01);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.txtLKTT);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.richRepairAction);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtRemark);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.richRepairReason);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtControlNo);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.icobtnSearch);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(399, 561);
			this.panel1.TabIndex = 2;
			// 
			// cbVitri
			// 
			this.cbVitri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbVitri.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbVitri.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbVitri.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.cbVitri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbVitri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cbVitri.FormattingEnabled = true;
			this.cbVitri.Location = new System.Drawing.Point(157, 194);
			this.cbVitri.Name = "cbVitri";
			this.cbVitri.Size = new System.Drawing.Size(234, 21);
			this.cbVitri.TabIndex = 9;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(224, 369);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(86, 13);
			this.label11.TabIndex = 151;
			this.label11.Text = "Ảnh sau khi sửa:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(41, 372);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(93, 13);
			this.label10.TabIndex = 150;
			this.label10.Text = "Ảnh trước khi sửa:";
			// 
			// pBSau
			// 
			this.pBSau.Location = new System.Drawing.Point(227, 387);
			this.pBSau.Name = "pBSau";
			this.pBSau.Size = new System.Drawing.Size(101, 95);
			this.pBSau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pBSau.TabIndex = 149;
			this.pBSau.TabStop = false;
			this.pBSau.Click += new System.EventHandler(this.pBSau_Click);
			// 
			// pBTruoc
			// 
			this.pBTruoc.Location = new System.Drawing.Point(44, 388);
			this.pBTruoc.Name = "pBTruoc";
			this.pBTruoc.Size = new System.Drawing.Size(103, 94);
			this.pBTruoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pBTruoc.TabIndex = 148;
			this.pBTruoc.TabStop = false;
			this.pBTruoc.Click += new System.EventHandler(this.pBTruoc_Click);
			// 
			// iconbtnSimage
			// 
			this.iconbtnSimage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSimage.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSimage.IconColor = System.Drawing.Color.Black;
			this.iconbtnSimage.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSimage.Location = new System.Drawing.Point(339, 331);
			this.iconbtnSimage.Name = "iconbtnSimage";
			this.iconbtnSimage.Size = new System.Drawing.Size(53, 23);
			this.iconbtnSimage.TabIndex = 21;
			this.iconbtnSimage.Text = "img2";
			this.iconbtnSimage.UseVisualStyleBackColor = true;
			this.iconbtnSimage.Click += new System.EventHandler(this.iconbtnSimage_Click);
			// 
			// iconbtnTimage
			// 
			this.iconbtnTimage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnTimage.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnTimage.IconColor = System.Drawing.Color.Black;
			this.iconbtnTimage.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnTimage.Location = new System.Drawing.Point(339, 302);
			this.iconbtnTimage.Name = "iconbtnTimage";
			this.iconbtnTimage.Size = new System.Drawing.Size(53, 23);
			this.iconbtnTimage.TabIndex = 18;
			this.iconbtnTimage.Text = "img1";
			this.iconbtnTimage.UseVisualStyleBackColor = true;
			this.iconbtnTimage.Click += new System.EventHandler(this.iconbtnTimage_Click);
			// 
			// txtPahtImage02
			// 
			this.txtPahtImage02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPahtImage02.Location = new System.Drawing.Point(157, 331);
			this.txtPahtImage02.Name = "txtPahtImage02";
			this.txtPahtImage02.Size = new System.Drawing.Size(171, 20);
			this.txtPahtImage02.TabIndex = 20;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 335);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(86, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "Ảnh sau khi sửa:";
			// 
			// txtPahtImage01
			// 
			this.txtPahtImage01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPahtImage01.Location = new System.Drawing.Point(157, 303);
			this.txtPahtImage01.Name = "txtPahtImage01";
			this.txtPahtImage01.Size = new System.Drawing.Size(171, 20);
			this.txtPahtImage01.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 307);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(93, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Ảnh trước khi sửa:";
			// 
			// txtLKTT
			// 
			this.txtLKTT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLKTT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLKTT.Location = new System.Drawing.Point(157, 221);
			this.txtLKTT.Name = "txtLKTT";
			this.txtLKTT.Size = new System.Drawing.Size(236, 20);
			this.txtLKTT.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 225);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Linh kiện TT:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 198);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Vị trí:";
			// 
			// richRepairAction
			// 
			this.richRepairAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richRepairAction.Location = new System.Drawing.Point(157, 148);
			this.richRepairAction.Name = "richRepairAction";
			this.richRepairAction.Size = new System.Drawing.Size(235, 40);
			this.richRepairAction.TabIndex = 7;
			this.richRepairAction.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 162);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Khắc phục:";
			// 
			// txtRemark
			// 
			this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Location = new System.Drawing.Point(157, 275);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(236, 20);
			this.txtRemark.TabIndex = 15;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 279);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Ghi chú:";
			// 
			// richRepairReason
			// 
			this.richRepairReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richRepairReason.Location = new System.Drawing.Point(157, 101);
			this.richRepairReason.Name = "richRepairReason";
			this.richRepairReason.Size = new System.Drawing.Size(235, 42);
			this.richRepairReason.TabIndex = 5;
			this.richRepairReason.Text = "";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(399, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(585, 561);
			this.panel2.TabIndex = 3;
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(14, 12);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(559, 537);
			this.dgView.TabIndex = 0;
			this.dgView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_CellMouseDoubleClick);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(12, 251);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(58, 13);
			this.label12.TabIndex = 12;
			this.label12.Text = "Tình trạng:";
			// 
			// cbStatus
			// 
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Items.AddRange(new object[] {
            "--Select--",
            "OK",
            "NG"});
			this.cbStatus.Location = new System.Drawing.Point(157, 247);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(235, 21);
			this.cbStatus.TabIndex = 13;
			// 
			// frmEQRepairHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmEQRepairHistory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LỊCH SỬA SỬA CHỮA THIẾT BỊ";
			this.Load += new System.EventHandler(this.frmEQRepairHistory_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pBSau)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pBTruoc)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtControlNo;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnExportCsv;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richRepairReason;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox richRepairAction;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLKTT;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPahtImage02;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtPahtImage01;
		private System.Windows.Forms.Label label8;
		private FontAwesome.Sharp.IconButton iconbtnSimage;
		private FontAwesome.Sharp.IconButton iconbtnTimage;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.PictureBox pBSau;
		private System.Windows.Forms.PictureBox pBTruoc;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.ComboBox cbVitri;
		private System.Windows.Forms.ComboBox cbStatus;
		private System.Windows.Forms.Label label12;
	}
}