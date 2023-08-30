namespace SMTPRORAM.Jig
{
    partial class frmInventory
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventory));
			this.panelTitle = new System.Windows.Forms.Panel();
			this.Lbl_Baud = new System.Windows.Forms.Label();
			this.Txt_Baud = new System.Windows.Forms.TextBox();
			this.Cbo_COM = new System.Windows.Forms.ComboBox();
			this.RBtn_COM = new System.Windows.Forms.RadioButton();
			this.iconbtnNew = new FontAwesome.Sharp.IconButton();
			this.Cbo_USB = new System.Windows.Forms.ComboBox();
			this.RBtn_USB = new System.Windows.Forms.RadioButton();
			this.iconbtnPrint = new FontAwesome.Sharp.IconButton();
			this.iconbtnTim = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.dgViewOld = new System.Windows.Forms.DataGridView();
			this.panelConten1 = new System.Windows.Forms.Panel();
			this.txtInvoiceNo = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtBookvalue = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtOldControlNo = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtFACode2 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtFACode1 = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtDevicesDesc = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtNGDetail = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtOrigin = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtImportCond = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.dtpPurDate = new System.Windows.Forms.DateTimePicker();
			this.label13 = new System.Windows.Forms.Label();
			this.txtUseStatus = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtSStatus = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cbJigLocName = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbJigSecCode = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.dtpCalDate = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.txtMaker = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbCalType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSerial = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEqName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtControlNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelContent2 = new System.Windows.Forms.Panel();
			this.dgViewNew = new System.Windows.Forms.DataGridView();
			this.label23 = new System.Windows.Forms.Label();
			this.cbMaCty = new System.Windows.Forms.ComboBox();
			this.panelTitle.SuspendLayout();
			this.panelLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewOld)).BeginInit();
			this.panelConten1.SuspendLayout();
			this.panelContent2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewNew)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTitle
			// 
			this.panelTitle.Controls.Add(this.Lbl_Baud);
			this.panelTitle.Controls.Add(this.Txt_Baud);
			this.panelTitle.Controls.Add(this.Cbo_COM);
			this.panelTitle.Controls.Add(this.RBtn_COM);
			this.panelTitle.Controls.Add(this.iconbtnNew);
			this.panelTitle.Controls.Add(this.Cbo_USB);
			this.panelTitle.Controls.Add(this.RBtn_USB);
			this.panelTitle.Controls.Add(this.iconbtnPrint);
			this.panelTitle.Controls.Add(this.iconbtnTim);
			this.panelTitle.Controls.Add(this.txtSearch);
			this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitle.Location = new System.Drawing.Point(0, 0);
			this.panelTitle.Name = "panelTitle";
			this.panelTitle.Size = new System.Drawing.Size(1097, 41);
			this.panelTitle.TabIndex = 0;
			// 
			// Lbl_Baud
			// 
			this.Lbl_Baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Lbl_Baud.AutoSize = true;
			this.Lbl_Baud.Location = new System.Drawing.Point(798, 13);
			this.Lbl_Baud.Name = "Lbl_Baud";
			this.Lbl_Baud.Size = new System.Drawing.Size(58, 13);
			this.Lbl_Baud.TabIndex = 35;
			this.Lbl_Baud.Text = "Baud Rate";
			// 
			// Txt_Baud
			// 
			this.Txt_Baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Txt_Baud.Location = new System.Drawing.Point(862, 9);
			this.Txt_Baud.Name = "Txt_Baud";
			this.Txt_Baud.Size = new System.Drawing.Size(57, 20);
			this.Txt_Baud.TabIndex = 34;
			this.Txt_Baud.Text = "9600";
			// 
			// Cbo_COM
			// 
			this.Cbo_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Cbo_COM.FormattingEnabled = true;
			this.Cbo_COM.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4"});
			this.Cbo_COM.Location = new System.Drawing.Point(633, 9);
			this.Cbo_COM.Name = "Cbo_COM";
			this.Cbo_COM.Size = new System.Drawing.Size(148, 21);
			this.Cbo_COM.TabIndex = 32;
			// 
			// RBtn_COM
			// 
			this.RBtn_COM.AutoSize = true;
			this.RBtn_COM.Location = new System.Drawing.Point(578, 11);
			this.RBtn_COM.Name = "RBtn_COM";
			this.RBtn_COM.Size = new System.Drawing.Size(49, 17);
			this.RBtn_COM.TabIndex = 33;
			this.RBtn_COM.Text = "COM";
			this.RBtn_COM.UseVisualStyleBackColor = true;
			// 
			// iconbtnNew
			// 
			this.iconbtnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnNew.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNew.IconColor = System.Drawing.Color.Black;
			this.iconbtnNew.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNew.Location = new System.Drawing.Point(1006, 8);
			this.iconbtnNew.Name = "iconbtnNew";
			this.iconbtnNew.Size = new System.Drawing.Size(75, 23);
			this.iconbtnNew.TabIndex = 31;
			this.iconbtnNew.Text = "Thêm mới";
			this.iconbtnNew.UseVisualStyleBackColor = true;
			this.iconbtnNew.Click += new System.EventHandler(this.iconbtnNew_Click);
			// 
			// Cbo_USB
			// 
			this.Cbo_USB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Cbo_USB.FormattingEnabled = true;
			this.Cbo_USB.Location = new System.Drawing.Point(411, 9);
			this.Cbo_USB.Name = "Cbo_USB";
			this.Cbo_USB.Size = new System.Drawing.Size(152, 21);
			this.Cbo_USB.TabIndex = 30;
			// 
			// RBtn_USB
			// 
			this.RBtn_USB.AutoSize = true;
			this.RBtn_USB.Checked = true;
			this.RBtn_USB.Location = new System.Drawing.Point(358, 11);
			this.RBtn_USB.Name = "RBtn_USB";
			this.RBtn_USB.Size = new System.Drawing.Size(47, 17);
			this.RBtn_USB.TabIndex = 29;
			this.RBtn_USB.TabStop = true;
			this.RBtn_USB.Text = "USB";
			this.RBtn_USB.UseVisualStyleBackColor = true;
			// 
			// iconbtnPrint
			// 
			this.iconbtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnPrint.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrint.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrint.Location = new System.Drawing.Point(925, 8);
			this.iconbtnPrint.Name = "iconbtnPrint";
			this.iconbtnPrint.Size = new System.Drawing.Size(75, 23);
			this.iconbtnPrint.TabIndex = 2;
			this.iconbtnPrint.Text = "In Tem";
			this.iconbtnPrint.UseVisualStyleBackColor = true;
			this.iconbtnPrint.Click += new System.EventHandler(this.iconbtnPrint_Click);
			// 
			// iconbtnTim
			// 
			this.iconbtnTim.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnTim.IconColor = System.Drawing.Color.Black;
			this.iconbtnTim.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnTim.Location = new System.Drawing.Point(265, 8);
			this.iconbtnTim.Name = "iconbtnTim";
			this.iconbtnTim.Size = new System.Drawing.Size(75, 23);
			this.iconbtnTim.TabIndex = 1;
			this.iconbtnTim.Text = "Tìm kiếm";
			this.iconbtnTim.UseVisualStyleBackColor = true;
			this.iconbtnTim.Click += new System.EventHandler(this.iconbtnTim_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(12, 9);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(247, 20);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.dgViewOld);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 41);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(410, 520);
			this.panelLeft.TabIndex = 1;
			// 
			// dgViewOld
			// 
			this.dgViewOld.AllowUserToAddRows = false;
			this.dgViewOld.AllowUserToDeleteRows = false;
			this.dgViewOld.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewOld.Location = new System.Drawing.Point(12, 8);
			this.dgViewOld.Name = "dgViewOld";
			this.dgViewOld.ReadOnly = true;
			this.dgViewOld.RowHeadersWidth = 62;
			this.dgViewOld.Size = new System.Drawing.Size(382, 500);
			this.dgViewOld.TabIndex = 0;
			this.dgViewOld.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgViewOld_CellMouseDoubleClick);
			// 
			// panelConten1
			// 
			this.panelConten1.Controls.Add(this.cbMaCty);
			this.panelConten1.Controls.Add(this.label23);
			this.panelConten1.Controls.Add(this.txtInvoiceNo);
			this.panelConten1.Controls.Add(this.label22);
			this.panelConten1.Controls.Add(this.txtBookvalue);
			this.panelConten1.Controls.Add(this.label21);
			this.panelConten1.Controls.Add(this.txtOldControlNo);
			this.panelConten1.Controls.Add(this.label20);
			this.panelConten1.Controls.Add(this.txtRemark);
			this.panelConten1.Controls.Add(this.label19);
			this.panelConten1.Controls.Add(this.txtFACode2);
			this.panelConten1.Controls.Add(this.label17);
			this.panelConten1.Controls.Add(this.txtFACode1);
			this.panelConten1.Controls.Add(this.label18);
			this.panelConten1.Controls.Add(this.txtDevicesDesc);
			this.panelConten1.Controls.Add(this.label10);
			this.panelConten1.Controls.Add(this.txtNGDetail);
			this.panelConten1.Controls.Add(this.label11);
			this.panelConten1.Controls.Add(this.txtOrigin);
			this.panelConten1.Controls.Add(this.label16);
			this.panelConten1.Controls.Add(this.txtImportCond);
			this.panelConten1.Controls.Add(this.label15);
			this.panelConten1.Controls.Add(this.dtpPurDate);
			this.panelConten1.Controls.Add(this.label13);
			this.panelConten1.Controls.Add(this.txtUseStatus);
			this.panelConten1.Controls.Add(this.label14);
			this.panelConten1.Controls.Add(this.txtSStatus);
			this.panelConten1.Controls.Add(this.label12);
			this.panelConten1.Controls.Add(this.cbJigLocName);
			this.panelConten1.Controls.Add(this.label9);
			this.panelConten1.Controls.Add(this.cbJigSecCode);
			this.panelConten1.Controls.Add(this.label8);
			this.panelConten1.Controls.Add(this.dtpCalDate);
			this.panelConten1.Controls.Add(this.label7);
			this.panelConten1.Controls.Add(this.txtMaker);
			this.panelConten1.Controls.Add(this.label6);
			this.panelConten1.Controls.Add(this.cbCalType);
			this.panelConten1.Controls.Add(this.label5);
			this.panelConten1.Controls.Add(this.txtSerial);
			this.panelConten1.Controls.Add(this.label4);
			this.panelConten1.Controls.Add(this.txtModel);
			this.panelConten1.Controls.Add(this.label3);
			this.panelConten1.Controls.Add(this.txtEqName);
			this.panelConten1.Controls.Add(this.label2);
			this.panelConten1.Controls.Add(this.txtControlNo);
			this.panelConten1.Controls.Add(this.label1);
			this.panelConten1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelConten1.Location = new System.Drawing.Point(410, 41);
			this.panelConten1.Name = "panelConten1";
			this.panelConten1.Size = new System.Drawing.Size(687, 325);
			this.panelConten1.TabIndex = 2;
			// 
			// txtInvoiceNo
			// 
			this.txtInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtInvoiceNo.Location = new System.Drawing.Point(502, 296);
			this.txtInvoiceNo.Name = "txtInvoiceNo";
			this.txtInvoiceNo.Size = new System.Drawing.Size(178, 20);
			this.txtInvoiceNo.TabIndex = 43;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(325, 300);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(59, 13);
			this.label22.TabIndex = 42;
			this.label22.Text = "Invoice No";
			// 
			// txtBookvalue
			// 
			this.txtBookvalue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBookvalue.Location = new System.Drawing.Point(502, 270);
			this.txtBookvalue.Name = "txtBookvalue";
			this.txtBookvalue.Size = new System.Drawing.Size(178, 20);
			this.txtBookvalue.TabIndex = 41;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(325, 274);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(62, 13);
			this.label21.TabIndex = 40;
			this.label21.Text = "Book Value";
			// 
			// txtOldControlNo
			// 
			this.txtOldControlNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtOldControlNo.Location = new System.Drawing.Point(502, 166);
			this.txtOldControlNo.Name = "txtOldControlNo";
			this.txtOldControlNo.Size = new System.Drawing.Size(178, 20);
			this.txtOldControlNo.TabIndex = 33;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(325, 170);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(77, 13);
			this.label20.TabIndex = 32;
			this.label20.Text = "Mã quản lý cũ:";
			// 
			// txtRemark
			// 
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Location = new System.Drawing.Point(502, 244);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(178, 20);
			this.txtRemark.TabIndex = 39;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(325, 248);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(47, 13);
			this.label19.TabIndex = 38;
			this.label19.Text = "Remark:";
			// 
			// txtFACode2
			// 
			this.txtFACode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFACode2.Location = new System.Drawing.Point(502, 218);
			this.txtFACode2.Name = "txtFACode2";
			this.txtFACode2.Size = new System.Drawing.Size(178, 20);
			this.txtFACode2.TabIndex = 37;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(325, 222);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(107, 13);
			this.label17.TabIndex = 36;
			this.label17.Text = "Mã quản lý kế toán 2";
			// 
			// txtFACode1
			// 
			this.txtFACode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFACode1.Location = new System.Drawing.Point(502, 192);
			this.txtFACode1.Name = "txtFACode1";
			this.txtFACode1.Size = new System.Drawing.Size(178, 20);
			this.txtFACode1.TabIndex = 35;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(325, 196);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(107, 13);
			this.label18.TabIndex = 34;
			this.label18.Text = "Mã quản lý kế toán 1";
			// 
			// txtDevicesDesc
			// 
			this.txtDevicesDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDevicesDesc.Location = new System.Drawing.Point(502, 140);
			this.txtDevicesDesc.Name = "txtDevicesDesc";
			this.txtDevicesDesc.Size = new System.Drawing.Size(178, 20);
			this.txtDevicesDesc.TabIndex = 31;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(325, 144);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 13);
			this.label10.TabIndex = 30;
			this.label10.Text = "Mô tả thiết bị";
			// 
			// txtNGDetail
			// 
			this.txtNGDetail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNGDetail.Location = new System.Drawing.Point(502, 114);
			this.txtNGDetail.Name = "txtNGDetail";
			this.txtNGDetail.Size = new System.Drawing.Size(178, 20);
			this.txtNGDetail.TabIndex = 29;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(325, 118);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(77, 13);
			this.label11.TabIndex = 28;
			this.label11.Text = "Chi tiết lỗi (NG)";
			// 
			// txtOrigin
			// 
			this.txtOrigin.BackColor = System.Drawing.SystemColors.Info;
			this.txtOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtOrigin.Location = new System.Drawing.Point(502, 88);
			this.txtOrigin.Name = "txtOrigin";
			this.txtOrigin.Size = new System.Drawing.Size(178, 20);
			this.txtOrigin.TabIndex = 27;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(325, 92);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(92, 13);
			this.label16.TabIndex = 26;
			this.label16.Text = "Nhập từ quốc gia:";
			// 
			// txtImportCond
			// 
			this.txtImportCond.BackColor = System.Drawing.SystemColors.Info;
			this.txtImportCond.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtImportCond.Location = new System.Drawing.Point(502, 62);
			this.txtImportCond.Name = "txtImportCond";
			this.txtImportCond.Size = new System.Drawing.Size(178, 20);
			this.txtImportCond.TabIndex = 25;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(325, 66);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(99, 13);
			this.label15.TabIndex = 24;
			this.label15.Text = "Trạng thái khi nhập";
			// 
			// dtpPurDate
			// 
			this.dtpPurDate.CalendarMonthBackground = System.Drawing.SystemColors.Info;
			this.dtpPurDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpPurDate.Location = new System.Drawing.Point(502, 36);
			this.dtpPurDate.Name = "dtpPurDate";
			this.dtpPurDate.Size = new System.Drawing.Size(126, 20);
			this.dtpPurDate.TabIndex = 23;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(325, 40);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(58, 13);
			this.label13.TabIndex = 22;
			this.label13.Text = "Ngày mua:";
			// 
			// txtUseStatus
			// 
			this.txtUseStatus.BackColor = System.Drawing.SystemColors.Info;
			this.txtUseStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUseStatus.Location = new System.Drawing.Point(157, 299);
			this.txtUseStatus.Name = "txtUseStatus";
			this.txtUseStatus.Size = new System.Drawing.Size(161, 20);
			this.txtUseStatus.TabIndex = 21;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(8, 303);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(96, 13);
			this.label14.TabIndex = 20;
			this.label14.Text = "Trạng thái sử dụng";
			// 
			// txtSStatus
			// 
			this.txtSStatus.BackColor = System.Drawing.SystemColors.Info;
			this.txtSStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSStatus.Location = new System.Drawing.Point(157, 273);
			this.txtSStatus.Name = "txtSStatus";
			this.txtSStatus.Size = new System.Drawing.Size(161, 20);
			this.txtSStatus.TabIndex = 19;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(8, 277);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(89, 13);
			this.label12.TabIndex = 18;
			this.label12.Text = "Tình trạng thiết bị";
			// 
			// cbJigLocName
			// 
			this.cbJigLocName.BackColor = System.Drawing.SystemColors.Info;
			this.cbJigLocName.FormattingEnabled = true;
			this.cbJigLocName.Location = new System.Drawing.Point(157, 246);
			this.cbJigLocName.Name = "cbJigLocName";
			this.cbJigLocName.Size = new System.Drawing.Size(73, 21);
			this.cbJigLocName.TabIndex = 17;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(8, 250);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "Location";
			// 
			// cbJigSecCode
			// 
			this.cbJigSecCode.BackColor = System.Drawing.SystemColors.Info;
			this.cbJigSecCode.FormattingEnabled = true;
			this.cbJigSecCode.Location = new System.Drawing.Point(157, 219);
			this.cbJigSecCode.Name = "cbJigSecCode";
			this.cbJigSecCode.Size = new System.Drawing.Size(73, 21);
			this.cbJigSecCode.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 223);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(43, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Section";
			// 
			// dtpCalDate
			// 
			this.dtpCalDate.CalendarMonthBackground = System.Drawing.SystemColors.Info;
			this.dtpCalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpCalDate.Location = new System.Drawing.Point(157, 193);
			this.dtpCalDate.Name = "dtpCalDate";
			this.dtpCalDate.Size = new System.Drawing.Size(73, 20);
			this.dtpCalDate.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 197);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(84, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Ngày hiệu chỉnh";
			// 
			// txtMaker
			// 
			this.txtMaker.BackColor = System.Drawing.SystemColors.Info;
			this.txtMaker.Location = new System.Drawing.Point(157, 167);
			this.txtMaker.Name = "txtMaker";
			this.txtMaker.Size = new System.Drawing.Size(163, 20);
			this.txtMaker.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 171);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Maker";
			// 
			// cbCalType
			// 
			this.cbCalType.BackColor = System.Drawing.SystemColors.Info;
			this.cbCalType.FormattingEnabled = true;
			this.cbCalType.Location = new System.Drawing.Point(157, 140);
			this.cbCalType.Name = "cbCalType";
			this.cbCalType.Size = new System.Drawing.Size(73, 21);
			this.cbCalType.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Loại hiệu chỉnh:";
			// 
			// txtSerial
			// 
			this.txtSerial.BackColor = System.Drawing.SystemColors.Info;
			this.txtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSerial.Location = new System.Drawing.Point(157, 114);
			this.txtSerial.Name = "txtSerial";
			this.txtSerial.Size = new System.Drawing.Size(163, 20);
			this.txtSerial.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Serial";
			// 
			// txtModel
			// 
			this.txtModel.BackColor = System.Drawing.SystemColors.Info;
			this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtModel.Location = new System.Drawing.Point(157, 88);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(163, 20);
			this.txtModel.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Model";
			// 
			// txtEqName
			// 
			this.txtEqName.BackColor = System.Drawing.SystemColors.Info;
			this.txtEqName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEqName.Location = new System.Drawing.Point(157, 62);
			this.txtEqName.Name = "txtEqName";
			this.txtEqName.Size = new System.Drawing.Size(163, 20);
			this.txtEqName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "EQ Name";
			// 
			// txtControlNo
			// 
			this.txtControlNo.BackColor = System.Drawing.SystemColors.Info;
			this.txtControlNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtControlNo.Enabled = false;
			this.txtControlNo.Location = new System.Drawing.Point(157, 36);
			this.txtControlNo.Name = "txtControlNo";
			this.txtControlNo.Size = new System.Drawing.Size(163, 20);
			this.txtControlNo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Control No";
			// 
			// panelContent2
			// 
			this.panelContent2.Controls.Add(this.dgViewNew);
			this.panelContent2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent2.Location = new System.Drawing.Point(410, 366);
			this.panelContent2.Name = "panelContent2";
			this.panelContent2.Size = new System.Drawing.Size(687, 195);
			this.panelContent2.TabIndex = 3;
			// 
			// dgViewNew
			// 
			this.dgViewNew.AllowUserToAddRows = false;
			this.dgViewNew.AllowUserToDeleteRows = false;
			this.dgViewNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewNew.Location = new System.Drawing.Point(11, 14);
			this.dgViewNew.Name = "dgViewNew";
			this.dgViewNew.ReadOnly = true;
			this.dgViewNew.RowHeadersWidth = 62;
			this.dgViewNew.Size = new System.Drawing.Size(669, 169);
			this.dgViewNew.TabIndex = 0;
			this.dgViewNew.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgViewNew_CellMouseDoubleClick);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(8, 12);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(64, 13);
			this.label23.TabIndex = 44;
			this.label23.Text = "Mã Quản lý:";
			// 
			// cbMaCty
			// 
			this.cbMaCty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.cbMaCty.FormattingEnabled = true;
			this.cbMaCty.Items.AddRange(new object[] {
            "--Select--",
            "UVEQ",
            "UVEA"});
			this.cbMaCty.Location = new System.Drawing.Point(157, 8);
			this.cbMaCty.Name = "cbMaCty";
			this.cbMaCty.Size = new System.Drawing.Size(121, 21);
			this.cbMaCty.TabIndex = 45;
			// 
			// frmInventory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1097, 561);
			this.Controls.Add(this.panelContent2);
			this.Controls.Add(this.panelConten1);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.panelTitle);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmInventory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KIỂM KÊ VÀ TẠO MỚI";
			this.Load += new System.EventHandler(this.frmInventory_Load);
			this.panelTitle.ResumeLayout(false);
			this.panelTitle.PerformLayout();
			this.panelLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewOld)).EndInit();
			this.panelConten1.ResumeLayout(false);
			this.panelConten1.PerformLayout();
			this.panelContent2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewNew)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelConten1;
        private System.Windows.Forms.Panel panelContent2;
        private System.Windows.Forms.DataGridView dgViewOld;
        private System.Windows.Forms.DataGridView dgViewNew;
        private System.Windows.Forms.TextBox txtSearch;
        private FontAwesome.Sharp.IconButton iconbtnTim;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconbtnPrint;
        private System.Windows.Forms.TextBox txtEqName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCalType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbJigLocName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbJigSecCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpCalDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtImportCond;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpPurDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUseStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDevicesDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNGDetail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtBookvalue;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtOldControlNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtFACode2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFACode1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox Cbo_USB;
        private System.Windows.Forms.RadioButton RBtn_USB;
        private FontAwesome.Sharp.IconButton iconbtnNew;
        private System.Windows.Forms.ComboBox Cbo_COM;
        private System.Windows.Forms.RadioButton RBtn_COM;
        private System.Windows.Forms.Label Lbl_Baud;
        private System.Windows.Forms.TextBox Txt_Baud;
		private System.Windows.Forms.ComboBox cbMaCty;
		private System.Windows.Forms.Label label23;
	}
}