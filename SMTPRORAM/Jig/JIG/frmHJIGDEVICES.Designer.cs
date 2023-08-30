namespace SMTPRORAM.Jig.JIG
{
    partial class frmHJIGDEVICES
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbFixLocation = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lblProcess = new System.Windows.Forms.Label();
			this.cbSheet = new System.Windows.Forms.ComboBox();
			this.iconbtnBrowse = new FontAwesome.Sharp.IconButton();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnExportCsv = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.dtpRepairDate = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.icobtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtImportCond = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.dtpPurDate = new System.Windows.Forms.DateTimePicker();
			this.label13 = new System.Windows.Forms.Label();
			this.txtNGDetail = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtSStatus = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cbJigLocName = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbJigSecCode = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.dtpMakeDate = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.txtMaker = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEqName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtControlNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.printLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iconbtnExport = new FontAwesome.Sharp.IconButton();
			this.iconbtnLast = new FontAwesome.Sharp.IconButton();
			this.iconbtnFirst = new FontAwesome.Sharp.IconButton();
			this.label24 = new System.Windows.Forms.Label();
			this.lbltotalPages = new System.Windows.Forms.Label();
			this.lblCurrentPage = new System.Windows.Forms.Label();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.lblRecod = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbFixLocation);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lblProcess);
			this.panel1.Controls.Add(this.cbSheet);
			this.panel1.Controls.Add(this.iconbtnBrowse);
			this.panel1.Controls.Add(this.txtFilename);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Controls.Add(this.dtpRepairDate);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.icobtnSearch);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.txtRemark);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.txtImportCond);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Controls.Add(this.dtpPurDate);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.txtNGDetail);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.txtSStatus);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.cbJigLocName);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.cbJigSecCode);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.dtpMakeDate);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.txtMaker);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.txtModel);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtEqName);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtControlNo);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(369, 561);
			this.panel1.TabIndex = 0;
			// 
			// cbFixLocation
			// 
			this.cbFixLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFixLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFixLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFixLocation.FormattingEnabled = true;
			this.cbFixLocation.Location = new System.Drawing.Point(161, 248);
			this.cbFixLocation.Name = "cbFixLocation";
			this.cbFixLocation.Size = new System.Drawing.Size(197, 21);
			this.cbFixLocation.TabIndex = 163;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 252);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 164;
			this.label4.Text = "FixLocation";
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProcess.ForeColor = System.Drawing.Color.Red;
			this.lblProcess.Location = new System.Drawing.Point(9, 532);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(50, 16);
			this.lblProcess.TabIndex = 162;
			this.lblProcess.Text = "label1";
			// 
			// cbSheet
			// 
			this.cbSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSheet.FormattingEnabled = true;
			this.cbSheet.Location = new System.Drawing.Point(9, 508);
			this.cbSheet.Name = "cbSheet";
			this.cbSheet.Size = new System.Drawing.Size(349, 21);
			this.cbSheet.TabIndex = 21;
			this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
			// 
			// iconbtnBrowse
			// 
			this.iconbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnBrowse.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnBrowse.IconColor = System.Drawing.Color.Black;
			this.iconbtnBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnBrowse.IconSize = 16;
			this.iconbtnBrowse.Location = new System.Drawing.Point(276, 480);
			this.iconbtnBrowse.Name = "iconbtnBrowse";
			this.iconbtnBrowse.Size = new System.Drawing.Size(82, 22);
			this.iconbtnBrowse.TabIndex = 20;
			this.iconbtnBrowse.Text = "Chọn file";
			this.iconbtnBrowse.UseVisualStyleBackColor = true;
			this.iconbtnBrowse.Click += new System.EventHandler(this.iconbtnBrowse_Click);
			// 
			// txtFilename
			// 
			this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilename.Location = new System.Drawing.Point(9, 481);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(261, 20);
			this.txtFilename.TabIndex = 19;
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 412);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 60);
			this.tableLayoutPanel1.TabIndex = 161;
			// 
			// iconbtnExportCsv
			// 
			this.iconbtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExportCsv.IconColor = System.Drawing.Color.Black;
			this.iconbtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExportCsv.IconSize = 16;
			this.iconbtnExportCsv.Location = new System.Drawing.Point(237, 33);
			this.iconbtnExportCsv.Name = "iconbtnExportCsv";
			this.iconbtnExportCsv.Size = new System.Drawing.Size(112, 23);
			this.iconbtnExportCsv.TabIndex = 18;
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
			this.iconbtnAdd.Size = new System.Drawing.Size(111, 23);
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
			this.iconbtnEdit.Location = new System.Drawing.Point(120, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(111, 23);
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
			this.iconbtnDelete.Location = new System.Drawing.Point(237, 3);
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
			this.iconbtnSave.Size = new System.Drawing.Size(111, 23);
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
			this.iconbtnCancel.Location = new System.Drawing.Point(120, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(111, 23);
			this.iconbtnCancel.TabIndex = 17;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// dtpRepairDate
			// 
			this.dtpRepairDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpRepairDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpRepairDate.Location = new System.Drawing.Point(161, 168);
			this.dtpRepairDate.Name = "dtpRepairDate";
			this.dtpRepairDate.Size = new System.Drawing.Size(200, 20);
			this.dtpRepairDate.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 172);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 160;
			this.label3.Text = "Ngày sửa";
			// 
			// icobtnSearch
			// 
			this.icobtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.icobtnSearch.IconColor = System.Drawing.Color.Black;
			this.icobtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.icobtnSearch.IconSize = 16;
			this.icobtnSearch.Location = new System.Drawing.Point(9, 11);
			this.icobtnSearch.Name = "icobtnSearch";
			this.icobtnSearch.Size = new System.Drawing.Size(89, 23);
			this.icobtnSearch.TabIndex = 158;
			this.icobtnSearch.Text = "Tìm kiếm";
			this.icobtnSearch.UseVisualStyleBackColor = true;
			this.icobtnSearch.Click += new System.EventHandler(this.icobtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearch.Location = new System.Drawing.Point(161, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 20);
			this.txtSearch.TabIndex = 157;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// txtRemark
			// 
			this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Location = new System.Drawing.Point(161, 379);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(200, 20);
			this.txtRemark.TabIndex = 12;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(9, 383);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(47, 13);
			this.label16.TabIndex = 155;
			this.label16.Text = "Remark:";
			// 
			// txtImportCond
			// 
			this.txtImportCond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportCond.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtImportCond.Location = new System.Drawing.Point(161, 353);
			this.txtImportCond.Name = "txtImportCond";
			this.txtImportCond.Size = new System.Drawing.Size(200, 20);
			this.txtImportCond.TabIndex = 11;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(9, 357);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(99, 13);
			this.label15.TabIndex = 154;
			this.label15.Text = "Trạng thái khi nhập";
			// 
			// dtpPurDate
			// 
			this.dtpPurDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpPurDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpPurDate.Location = new System.Drawing.Point(161, 327);
			this.dtpPurDate.Name = "dtpPurDate";
			this.dtpPurDate.Size = new System.Drawing.Size(200, 20);
			this.dtpPurDate.TabIndex = 10;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(9, 331);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(58, 13);
			this.label13.TabIndex = 153;
			this.label13.Text = "Ngày mua:";
			// 
			// txtNGDetail
			// 
			this.txtNGDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNGDetail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNGDetail.Location = new System.Drawing.Point(161, 301);
			this.txtNGDetail.Name = "txtNGDetail";
			this.txtNGDetail.Size = new System.Drawing.Size(200, 20);
			this.txtNGDetail.TabIndex = 9;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 305);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 13);
			this.label11.TabIndex = 151;
			this.label11.Text = "Chi tiết lỗi (NG)";
			// 
			// txtSStatus
			// 
			this.txtSStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSStatus.Location = new System.Drawing.Point(161, 275);
			this.txtSStatus.Name = "txtSStatus";
			this.txtSStatus.Size = new System.Drawing.Size(200, 20);
			this.txtSStatus.TabIndex = 8;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(9, 279);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(89, 13);
			this.label12.TabIndex = 150;
			this.label12.Text = "Tình trạng thiết bị";
			// 
			// cbJigLocName
			// 
			this.cbJigLocName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbJigLocName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbJigLocName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbJigLocName.FormattingEnabled = true;
			this.cbJigLocName.Location = new System.Drawing.Point(161, 221);
			this.cbJigLocName.Name = "cbJigLocName";
			this.cbJigLocName.Size = new System.Drawing.Size(197, 21);
			this.cbJigLocName.TabIndex = 7;
			this.cbJigLocName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbJigLocName_KeyPress);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(9, 225);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 13);
			this.label9.TabIndex = 149;
			this.label9.Text = "Location";
			// 
			// cbJigSecCode
			// 
			this.cbJigSecCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbJigSecCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbJigSecCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbJigSecCode.FormattingEnabled = true;
			this.cbJigSecCode.Location = new System.Drawing.Point(161, 194);
			this.cbJigSecCode.Name = "cbJigSecCode";
			this.cbJigSecCode.Size = new System.Drawing.Size(197, 21);
			this.cbJigSecCode.TabIndex = 6;
			this.cbJigSecCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbJigSecCode_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 198);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(43, 13);
			this.label8.TabIndex = 148;
			this.label8.Text = "Section";
			// 
			// dtpMakeDate
			// 
			this.dtpMakeDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpMakeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpMakeDate.Location = new System.Drawing.Point(161, 142);
			this.dtpMakeDate.Name = "dtpMakeDate";
			this.dtpMakeDate.Size = new System.Drawing.Size(200, 20);
			this.dtpMakeDate.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 146);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 13);
			this.label7.TabIndex = 147;
			this.label7.Text = "Ngày tạo";
			// 
			// txtMaker
			// 
			this.txtMaker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMaker.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMaker.Location = new System.Drawing.Point(161, 116);
			this.txtMaker.Name = "txtMaker";
			this.txtMaker.Size = new System.Drawing.Size(200, 20);
			this.txtMaker.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 146;
			this.label6.Text = "Maker";
			// 
			// txtModel
			// 
			this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtModel.Location = new System.Drawing.Point(161, 90);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(200, 20);
			this.txtModel.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 145;
			this.label5.Text = "Model";
			// 
			// txtEqName
			// 
			this.txtEqName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEqName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEqName.Location = new System.Drawing.Point(161, 64);
			this.txtEqName.Name = "txtEqName";
			this.txtEqName.Size = new System.Drawing.Size(200, 20);
			this.txtEqName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 141;
			this.label2.Text = "Tên thiết bị:";
			// 
			// txtControlNo
			// 
			this.txtControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtControlNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtControlNo.Location = new System.Drawing.Point(161, 38);
			this.txtControlNo.Name = "txtControlNo";
			this.txtControlNo.Size = new System.Drawing.Size(200, 20);
			this.txtControlNo.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 140;
			this.label1.Text = "Mã quản lý:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.iconbtnExport);
			this.panel2.Controls.Add(this.iconbtnLast);
			this.panel2.Controls.Add(this.iconbtnFirst);
			this.panel2.Controls.Add(this.label24);
			this.panel2.Controls.Add(this.lbltotalPages);
			this.panel2.Controls.Add(this.lblCurrentPage);
			this.panel2.Controls.Add(this.iconbtnNext);
			this.panel2.Controls.Add(this.iconbtnPrev);
			this.panel2.Controls.Add(this.lblRecod);
			this.panel2.Controls.Add(this.label25);
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(369, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(615, 561);
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
			this.dgView.ContextMenuStrip = this.contextMenuStrip1;
			this.dgView.Location = new System.Drawing.Point(6, 38);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(597, 511);
			this.dgView.TabIndex = 0;
			this.dgView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_CellMouseClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printLabelToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(131, 26);
			// 
			// printLabelToolStripMenuItem
			// 
			this.printLabelToolStripMenuItem.Name = "printLabelToolStripMenuItem";
			this.printLabelToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.printLabelToolStripMenuItem.Text = "Print Label";
			this.printLabelToolStripMenuItem.Click += new System.EventHandler(this.printLabelToolStripMenuItem_Click);
			// 
			// iconbtnExport
			// 
			this.iconbtnExport.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExport.IconColor = System.Drawing.Color.Black;
			this.iconbtnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExport.IconSize = 16;
			this.iconbtnExport.Location = new System.Drawing.Point(429, 9);
			this.iconbtnExport.Name = "iconbtnExport";
			this.iconbtnExport.Size = new System.Drawing.Size(81, 23);
			this.iconbtnExport.TabIndex = 58;
			this.iconbtnExport.Text = "Export Csv";
			this.iconbtnExport.UseVisualStyleBackColor = true;
			this.iconbtnExport.Click += new System.EventHandler(this.iconbtnExport_Click);
			// 
			// iconbtnLast
			// 
			this.iconbtnLast.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLast.IconColor = System.Drawing.Color.Black;
			this.iconbtnLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLast.Location = new System.Drawing.Point(382, 9);
			this.iconbtnLast.Name = "iconbtnLast";
			this.iconbtnLast.Size = new System.Drawing.Size(41, 23);
			this.iconbtnLast.TabIndex = 57;
			this.iconbtnLast.Text = ">>";
			this.iconbtnLast.UseVisualStyleBackColor = true;
			this.iconbtnLast.Click += new System.EventHandler(this.iconbtnLast_Click);
			// 
			// iconbtnFirst
			// 
			this.iconbtnFirst.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnFirst.IconColor = System.Drawing.Color.Black;
			this.iconbtnFirst.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnFirst.Location = new System.Drawing.Point(145, 9);
			this.iconbtnFirst.Name = "iconbtnFirst";
			this.iconbtnFirst.Size = new System.Drawing.Size(40, 23);
			this.iconbtnFirst.TabIndex = 56;
			this.iconbtnFirst.Text = "<<";
			this.iconbtnFirst.UseVisualStyleBackColor = true;
			this.iconbtnFirst.Click += new System.EventHandler(this.iconbtnFirst_Click);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(279, 14);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(12, 13);
			this.label24.TabIndex = 55;
			this.label24.Text = "/";
			// 
			// lbltotalPages
			// 
			this.lbltotalPages.AutoSize = true;
			this.lbltotalPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbltotalPages.ForeColor = System.Drawing.Color.Blue;
			this.lbltotalPages.Location = new System.Drawing.Point(291, 14);
			this.lbltotalPages.Name = "lbltotalPages";
			this.lbltotalPages.Size = new System.Drawing.Size(26, 13);
			this.lbltotalPages.TabIndex = 54;
			this.lbltotalPages.Text = "Tot";
			// 
			// lblCurrentPage
			// 
			this.lblCurrentPage.AutoSize = true;
			this.lblCurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCurrentPage.ForeColor = System.Drawing.Color.Blue;
			this.lblCurrentPage.Location = new System.Drawing.Point(246, 14);
			this.lblCurrentPage.Name = "lblCurrentPage";
			this.lblCurrentPage.Size = new System.Drawing.Size(34, 13);
			this.lblCurrentPage.TabIndex = 53;
			this.lblCurrentPage.Text = "CurP";
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(335, 9);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(41, 23);
			this.iconbtnNext.TabIndex = 52;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			this.iconbtnNext.Click += new System.EventHandler(this.iconbtnNext_Click);
			// 
			// iconbtnPrev
			// 
			this.iconbtnPrev.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrev.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrev.Location = new System.Drawing.Point(190, 9);
			this.iconbtnPrev.Name = "iconbtnPrev";
			this.iconbtnPrev.Size = new System.Drawing.Size(40, 23);
			this.iconbtnPrev.TabIndex = 51;
			this.iconbtnPrev.Text = "<";
			this.iconbtnPrev.UseVisualStyleBackColor = true;
			this.iconbtnPrev.Click += new System.EventHandler(this.iconbtnPrev_Click);
			// 
			// lblRecod
			// 
			this.lblRecod.AutoSize = true;
			this.lblRecod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblRecod.ForeColor = System.Drawing.Color.Blue;
			this.lblRecod.Location = new System.Drawing.Point(98, 14);
			this.lblRecod.Name = "lblRecod";
			this.lblRecod.Size = new System.Drawing.Size(41, 13);
			this.lblRecod.TabIndex = 50;
			this.lblRecod.Text = "label5";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(5, 14);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(87, 13);
			this.label25.TabIndex = 49;
			this.label25.Text = "Tổng số bản ghi:";
			// 
			// frmHJIGDEVICES
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmHJIGDEVICES";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ JIG";
			this.Load += new System.EventHandler(this.frmHJIGDEVICES_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private FontAwesome.Sharp.IconButton icobtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtImportCond;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpPurDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNGDetail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbJigLocName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbJigSecCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpMakeDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEqName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRepairDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSheet;
        private FontAwesome.Sharp.IconButton iconbtnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnExportCsv;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printLabelToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbFixLocation;
		private System.Windows.Forms.Label label4;
		private FontAwesome.Sharp.IconButton iconbtnExport;
		private FontAwesome.Sharp.IconButton iconbtnLast;
		private FontAwesome.Sharp.IconButton iconbtnFirst;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label lbltotalPages;
		private System.Windows.Forms.Label lblCurrentPage;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
		private System.Windows.Forms.Label lblRecod;
		private System.Windows.Forms.Label label25;
	}
}