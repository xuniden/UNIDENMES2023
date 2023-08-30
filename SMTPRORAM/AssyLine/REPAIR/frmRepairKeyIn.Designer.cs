namespace SMTPRORAM.AssyLine.REPAIR
{
	partial class frmRepairKeyIn
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
			this.panelLeft = new System.Windows.Forms.Panel();
			this.grSave = new System.Windows.Forms.GroupBox();
			this.btClear = new System.Windows.Forms.Button();
			this.btSaveClose = new System.Windows.Forms.Button();
			this.btSaveNext = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btImport = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.btBrowser = new System.Windows.Forms.Button();
			this.txtBrowser = new System.Windows.Forms.TextBox();
			this.grInput = new System.Windows.Forms.GroupBox();
			this.cbDefectCode = new System.Windows.Forms.ComboBox();
			this.cbLot = new System.Windows.Forms.ComboBox();
			this.txtPCBName = new System.Windows.Forms.TextBox();
			this.lblPCBname = new System.Windows.Forms.Label();
			this.txtPCBNo = new System.Windows.Forms.TextBox();
			this.lblPCBno = new System.Windows.Forms.Label();
			this.txtPCSNo = new System.Windows.Forms.TextBox();
			this.lblPCSNo = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.cbCauseCode = new System.Windows.Forms.ComboBox();
			this.cbReasonCode = new System.Windows.Forms.ComboBox();
			this.txtADJNo = new System.Windows.Forms.TextBox();
			this.lblAdjno = new System.Windows.Forms.Label();
			this.txtNgQty = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtPartLocation = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.lblDefect = new System.Windows.Forms.Label();
			this.txtRepairBarcode = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtTechnicalID = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLine = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpNgay = new System.Windows.Forms.DateTimePicker();
			this.grDepartment = new System.Windows.Forms.GroupBox();
			this.chkSMT = new System.Windows.Forms.CheckBox();
			this.chkScl = new System.Windows.Forms.CheckBox();
			this.chkAssy = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelLeft.SuspendLayout();
			this.grSave.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grInput.SuspendLayout();
			this.grDepartment.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.grSave);
			this.panelLeft.Controls.Add(this.groupBox1);
			this.panelLeft.Controls.Add(this.grInput);
			this.panelLeft.Controls.Add(this.grDepartment);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(723, 561);
			this.panelLeft.TabIndex = 0;
			// 
			// grSave
			// 
			this.grSave.Controls.Add(this.btClear);
			this.grSave.Controls.Add(this.btSaveClose);
			this.grSave.Controls.Add(this.btSaveNext);
			this.grSave.Location = new System.Drawing.Point(12, 456);
			this.grSave.Name = "grSave";
			this.grSave.Size = new System.Drawing.Size(291, 73);
			this.grSave.TabIndex = 44;
			this.grSave.TabStop = false;
			this.grSave.Text = "SAVE";
			// 
			// btClear
			// 
			this.btClear.Location = new System.Drawing.Point(147, 19);
			this.btClear.Name = "btClear";
			this.btClear.Size = new System.Drawing.Size(123, 40);
			this.btClear.TabIndex = 1;
			this.btClear.Text = "CLEAR ALL";
			this.btClear.UseVisualStyleBackColor = true;
			this.btClear.Click += new System.EventHandler(this.btClear_Click);
			// 
			// btSaveClose
			// 
			this.btSaveClose.Location = new System.Drawing.Point(147, 19);
			this.btSaveClose.Name = "btSaveClose";
			this.btSaveClose.Size = new System.Drawing.Size(120, 40);
			this.btSaveClose.TabIndex = 1;
			this.btSaveClose.Text = "SAVE & CLOSE";
			this.btSaveClose.UseVisualStyleBackColor = true;
			// 
			// btSaveNext
			// 
			this.btSaveNext.Location = new System.Drawing.Point(7, 19);
			this.btSaveNext.Name = "btSaveNext";
			this.btSaveNext.Size = new System.Drawing.Size(120, 40);
			this.btSaveNext.TabIndex = 0;
			this.btSaveNext.Text = "SAVE & NEXT";
			this.btSaveNext.UseVisualStyleBackColor = true;
			this.btSaveNext.Click += new System.EventHandler(this.btSaveNext_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btImport);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.btBrowser);
			this.groupBox1.Controls.Add(this.txtBrowser);
			this.groupBox1.Location = new System.Drawing.Point(324, 451);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(393, 82);
			this.groupBox1.TabIndex = 43;
			this.groupBox1.TabStop = false;
			this.groupBox1.Visible = false;
			// 
			// btImport
			// 
			this.btImport.Location = new System.Drawing.Point(312, 45);
			this.btImport.Name = "btImport";
			this.btImport.Size = new System.Drawing.Size(75, 23);
			this.btImport.TabIndex = 6;
			this.btImport.Text = "Import";
			this.btImport.UseVisualStyleBackColor = true;
			this.btImport.Click += new System.EventHandler(this.btImport_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 22);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(32, 13);
			this.label12.TabIndex = 9;
			this.label12.Text = "Path:";
			// 
			// btBrowser
			// 
			this.btBrowser.Location = new System.Drawing.Point(312, 17);
			this.btBrowser.Name = "btBrowser";
			this.btBrowser.Size = new System.Drawing.Size(75, 23);
			this.btBrowser.TabIndex = 7;
			this.btBrowser.Text = "Browser";
			this.btBrowser.UseVisualStyleBackColor = true;
			this.btBrowser.Click += new System.EventHandler(this.btBrowser_Click);
			// 
			// txtBrowser
			// 
			this.txtBrowser.Location = new System.Drawing.Point(44, 18);
			this.txtBrowser.Name = "txtBrowser";
			this.txtBrowser.Size = new System.Drawing.Size(260, 20);
			this.txtBrowser.TabIndex = 8;
			// 
			// grInput
			// 
			this.grInput.Controls.Add(this.cbDefectCode);
			this.grInput.Controls.Add(this.cbLot);
			this.grInput.Controls.Add(this.txtPCBName);
			this.grInput.Controls.Add(this.lblPCBname);
			this.grInput.Controls.Add(this.txtPCBNo);
			this.grInput.Controls.Add(this.lblPCBno);
			this.grInput.Controls.Add(this.txtPCSNo);
			this.grInput.Controls.Add(this.lblPCSNo);
			this.grInput.Controls.Add(this.label24);
			this.grInput.Controls.Add(this.label23);
			this.grInput.Controls.Add(this.label22);
			this.grInput.Controls.Add(this.label21);
			this.grInput.Controls.Add(this.label20);
			this.grInput.Controls.Add(this.label19);
			this.grInput.Controls.Add(this.label18);
			this.grInput.Controls.Add(this.label17);
			this.grInput.Controls.Add(this.label16);
			this.grInput.Controls.Add(this.label15);
			this.grInput.Controls.Add(this.label14);
			this.grInput.Controls.Add(this.label13);
			this.grInput.Controls.Add(this.cbCauseCode);
			this.grInput.Controls.Add(this.cbReasonCode);
			this.grInput.Controls.Add(this.txtADJNo);
			this.grInput.Controls.Add(this.lblAdjno);
			this.grInput.Controls.Add(this.txtNgQty);
			this.grInput.Controls.Add(this.label11);
			this.grInput.Controls.Add(this.txtPartLocation);
			this.grInput.Controls.Add(this.label10);
			this.grInput.Controls.Add(this.lblDefect);
			this.grInput.Controls.Add(this.txtRepairBarcode);
			this.grInput.Controls.Add(this.label8);
			this.grInput.Controls.Add(this.label7);
			this.grInput.Controls.Add(this.txtModel);
			this.grInput.Controls.Add(this.label6);
			this.grInput.Controls.Add(this.txtTechnicalID);
			this.grInput.Controls.Add(this.label5);
			this.grInput.Controls.Add(this.txtLine);
			this.grInput.Controls.Add(this.label3);
			this.grInput.Controls.Add(this.label2);
			this.grInput.Controls.Add(this.dtpNgay);
			this.grInput.Location = new System.Drawing.Point(12, 135);
			this.grInput.Name = "grInput";
			this.grInput.Size = new System.Drawing.Size(705, 315);
			this.grInput.TabIndex = 16;
			this.grInput.TabStop = false;
			this.grInput.Text = "INPUT DATA";
			// 
			// cbDefectCode
			// 
			this.cbDefectCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDefectCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDefectCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDefectCode.FormattingEnabled = true;
			this.cbDefectCode.Location = new System.Drawing.Point(66, 202);
			this.cbDefectCode.Name = "cbDefectCode";
			this.cbDefectCode.Size = new System.Drawing.Size(111, 21);
			this.cbDefectCode.TabIndex = 41;
			// 
			// cbLot
			// 
			this.cbLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLot.FormattingEnabled = true;
			this.cbLot.Location = new System.Drawing.Point(75, 84);
			this.cbLot.Name = "cbLot";
			this.cbLot.Size = new System.Drawing.Size(112, 21);
			this.cbLot.TabIndex = 40;
			this.cbLot.SelectedValueChanged += new System.EventHandler(this.cbLot_SelectedValueChanged);
			// 
			// txtPCBName
			// 
			this.txtPCBName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPCBName.Location = new System.Drawing.Point(596, 147);
			this.txtPCBName.Name = "txtPCBName";
			this.txtPCBName.Size = new System.Drawing.Size(100, 20);
			this.txtPCBName.TabIndex = 8;
			// 
			// lblPCBname
			// 
			this.lblPCBname.AutoSize = true;
			this.lblPCBname.Location = new System.Drawing.Point(531, 151);
			this.lblPCBname.Name = "lblPCBname";
			this.lblPCBname.Size = new System.Drawing.Size(59, 13);
			this.lblPCBname.TabIndex = 39;
			this.lblPCBname.Text = "PCB Name";
			// 
			// txtPCBNo
			// 
			this.txtPCBNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPCBNo.Location = new System.Drawing.Point(426, 147);
			this.txtPCBNo.Name = "txtPCBNo";
			this.txtPCBNo.Size = new System.Drawing.Size(100, 20);
			this.txtPCBNo.TabIndex = 7;
			// 
			// lblPCBno
			// 
			this.lblPCBno.AutoSize = true;
			this.lblPCBno.Location = new System.Drawing.Point(375, 151);
			this.lblPCBno.Name = "lblPCBno";
			this.lblPCBno.Size = new System.Drawing.Size(45, 13);
			this.lblPCBno.TabIndex = 38;
			this.lblPCBno.Text = "PCB No";
			// 
			// txtPCSNo
			// 
			this.txtPCSNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPCSNo.Location = new System.Drawing.Point(257, 147);
			this.txtPCSNo.Name = "txtPCSNo";
			this.txtPCSNo.Size = new System.Drawing.Size(100, 20);
			this.txtPCSNo.TabIndex = 6;
			// 
			// lblPCSNo
			// 
			this.lblPCSNo.AutoSize = true;
			this.lblPCSNo.Location = new System.Drawing.Point(203, 151);
			this.lblPCSNo.Name = "lblPCSNo";
			this.lblPCSNo.Size = new System.Drawing.Size(48, 13);
			this.lblPCSNo.TabIndex = 37;
			this.lblPCSNo.Text = "PCS No:";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(413, 241);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(135, 13);
			this.label24.TabIndex = 33;
			this.label24.Text = "Nguyên Nhân bởi bộ phận:";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(219, 241);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(39, 13);
			this.label23.TabIndex = 32;
			this.label23.Text = "Lý do.:";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(183, 187);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(109, 13);
			this.label22.TabIndex = 31;
			this.label22.Text = "Công đoạn phát sinh:";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(545, 187);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(71, 13);
			this.label21.TabIndex = 30;
			this.label21.Text = "Số lượng NG:";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(350, 187);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(93, 13);
			this.label20.TabIndex = 29;
			this.label20.Text = "Vị trí link kiên NG:";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(1, 187);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(38, 13);
			this.label19.TabIndex = 28;
			this.label19.Text = "Mã lỗi:";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(5, 128);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(99, 13);
			this.label18.TabIndex = 27;
			this.label18.Text = "Mã vạch sửa hàng:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(365, 54);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(71, 13);
			this.label17.TabIndex = 26;
			this.label17.Text = "Technical ID:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(214, 54);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(30, 13);
			this.label16.TabIndex = 25;
			this.label16.Text = "Line:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(10, 54);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(67, 13);
			this.label15.TabIndex = 24;
			this.label15.Text = "Date Repair:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(413, 261);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(57, 13);
			this.label14.TabIndex = 23;
			this.label14.Text = "Cause by.:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(219, 261);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(50, 13);
			this.label13.TabIndex = 22;
			this.label13.Text = "Reason.:";
			// 
			// cbCauseCode
			// 
			this.cbCauseCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbCauseCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbCauseCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCauseCode.FormattingEnabled = true;
			this.cbCauseCode.Location = new System.Drawing.Point(476, 257);
			this.cbCauseCode.Name = "cbCauseCode";
			this.cbCauseCode.Size = new System.Drawing.Size(121, 21);
			this.cbCauseCode.TabIndex = 14;
			// 
			// cbReasonCode
			// 
			this.cbReasonCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbReasonCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbReasonCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbReasonCode.FormattingEnabled = true;
			this.cbReasonCode.Location = new System.Drawing.Point(275, 257);
			this.cbReasonCode.Name = "cbReasonCode";
			this.cbReasonCode.Size = new System.Drawing.Size(121, 21);
			this.cbReasonCode.Sorted = true;
			this.cbReasonCode.TabIndex = 13;
			// 
			// txtADJNo
			// 
			this.txtADJNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtADJNo.Location = new System.Drawing.Point(239, 203);
			this.txtADJNo.Name = "txtADJNo";
			this.txtADJNo.Size = new System.Drawing.Size(100, 20);
			this.txtADJNo.TabIndex = 10;
			// 
			// lblAdjno
			// 
			this.lblAdjno.AutoSize = true;
			this.lblAdjno.Location = new System.Drawing.Point(183, 207);
			this.lblAdjno.Name = "lblAdjno";
			this.lblAdjno.Size = new System.Drawing.Size(50, 13);
			this.lblAdjno.TabIndex = 19;
			this.lblAdjno.Text = "ADJ No.:";
			// 
			// txtNgQty
			// 
			this.txtNgQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNgQty.Location = new System.Drawing.Point(596, 203);
			this.txtNgQty.Name = "txtNgQty";
			this.txtNgQty.Size = new System.Drawing.Size(100, 20);
			this.txtNgQty.TabIndex = 12;
			this.txtNgQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNgQty_KeyPress);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(545, 207);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(45, 13);
			this.label11.TabIndex = 17;
			this.label11.Text = "NG Qty:";
			// 
			// txtPartLocation
			// 
			this.txtPartLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPartLocation.Location = new System.Drawing.Point(426, 203);
			this.txtPartLocation.Name = "txtPartLocation";
			this.txtPartLocation.Size = new System.Drawing.Size(100, 20);
			this.txtPartLocation.TabIndex = 11;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(350, 207);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(73, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "Part Location:";
			// 
			// lblDefect
			// 
			this.lblDefect.AutoSize = true;
			this.lblDefect.Location = new System.Drawing.Point(1, 207);
			this.lblDefect.Name = "lblDefect";
			this.lblDefect.Size = new System.Drawing.Size(67, 13);
			this.lblDefect.TabIndex = 13;
			this.lblDefect.Text = "Code Defect";
			// 
			// txtRepairBarcode
			// 
			this.txtRepairBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRepairBarcode.Location = new System.Drawing.Point(92, 147);
			this.txtRepairBarcode.Name = "txtRepairBarcode";
			this.txtRepairBarcode.Size = new System.Drawing.Size(110, 20);
			this.txtRepairBarcode.TabIndex = 5;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 151);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(84, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Repair Barcode:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(44, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(25, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Lot:";
			// 
			// txtModel
			// 
			this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtModel.Enabled = false;
			this.txtModel.Location = new System.Drawing.Point(250, 84);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(107, 20);
			this.txtModel.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(205, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(39, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Model:";
			// 
			// txtTechnicalID
			// 
			this.txtTechnicalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTechnicalID.Location = new System.Drawing.Point(442, 50);
			this.txtTechnicalID.Name = "txtTechnicalID";
			this.txtTechnicalID.Size = new System.Drawing.Size(100, 20);
			this.txtTechnicalID.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(439, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "ID Người Sửa :";
			// 
			// txtLine
			// 
			this.txtLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLine.Location = new System.Drawing.Point(250, 50);
			this.txtLine.Name = "txtLine";
			this.txtLine.Size = new System.Drawing.Size(100, 20);
			this.txtLine.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(214, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Tên Chuyền:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ngày sửa:";
			// 
			// dtpNgay
			// 
			this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpNgay.Location = new System.Drawing.Point(83, 50);
			this.dtpNgay.Name = "dtpNgay";
			this.dtpNgay.Size = new System.Drawing.Size(104, 20);
			this.dtpNgay.TabIndex = 0;
			// 
			// grDepartment
			// 
			this.grDepartment.Controls.Add(this.chkSMT);
			this.grDepartment.Controls.Add(this.chkScl);
			this.grDepartment.Controls.Add(this.chkAssy);
			this.grDepartment.Controls.Add(this.label1);
			this.grDepartment.Location = new System.Drawing.Point(12, 59);
			this.grDepartment.Name = "grDepartment";
			this.grDepartment.Size = new System.Drawing.Size(293, 74);
			this.grDepartment.TabIndex = 15;
			this.grDepartment.TabStop = false;
			this.grDepartment.Text = "DEPARTMENT";
			// 
			// chkSMT
			// 
			this.chkSMT.AutoSize = true;
			this.chkSMT.Location = new System.Drawing.Point(229, 34);
			this.chkSMT.Name = "chkSMT";
			this.chkSMT.Size = new System.Drawing.Size(49, 17);
			this.chkSMT.TabIndex = 3;
			this.chkSMT.Text = "SMT";
			this.chkSMT.UseVisualStyleBackColor = true;
			this.chkSMT.Click += new System.EventHandler(this.chkSMT_Click);
			// 
			// chkScl
			// 
			this.chkScl.AutoSize = true;
			this.chkScl.Location = new System.Drawing.Point(177, 34);
			this.chkScl.Name = "chkScl";
			this.chkScl.Size = new System.Drawing.Size(46, 17);
			this.chkScl.TabIndex = 2;
			this.chkScl.Text = "SCL";
			this.chkScl.UseVisualStyleBackColor = true;
			this.chkScl.Click += new System.EventHandler(this.chkScl_Click);
			// 
			// chkAssy
			// 
			this.chkAssy.AutoSize = true;
			this.chkAssy.Location = new System.Drawing.Point(117, 34);
			this.chkAssy.Name = "chkAssy";
			this.chkAssy.Size = new System.Drawing.Size(54, 17);
			this.chkAssy.TabIndex = 1;
			this.chkAssy.Text = "ASSY";
			this.chkAssy.UseVisualStyleBackColor = true;
			this.chkAssy.Click += new System.EventHandler(this.chkAssy_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Department Select:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Green;
			this.label4.Location = new System.Drawing.Point(128, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(355, 38);
			this.label4.TabIndex = 14;
			this.label4.Text = "REPAIR KEY IN FORM";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(723, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(261, 561);
			this.panelContent.TabIndex = 1;
			// 
			// dgView
			// 
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(9, 12);
			this.dgView.Name = "dgView";
			this.dgView.Size = new System.Drawing.Size(240, 537);
			this.dgView.TabIndex = 0;
			// 
			// frmRepairKeyIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmRepairKeyIn";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NHẬP DỮ LIỆU REPAIR";
			this.Load += new System.EventHandler(this.frmRepairKeyIn_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.grSave.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grInput.ResumeLayout(false);
			this.grInput.PerformLayout();
			this.grDepartment.ResumeLayout(false);
			this.grDepartment.PerformLayout();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.GroupBox grSave;
		private System.Windows.Forms.Button btClear;
		private System.Windows.Forms.Button btSaveClose;
		private System.Windows.Forms.Button btSaveNext;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btImport;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btBrowser;
		private System.Windows.Forms.TextBox txtBrowser;
		private System.Windows.Forms.GroupBox grInput;
		private System.Windows.Forms.TextBox txtPCBName;
		private System.Windows.Forms.Label lblPCBname;
		private System.Windows.Forms.TextBox txtPCBNo;
		private System.Windows.Forms.Label lblPCBno;
		private System.Windows.Forms.TextBox txtPCSNo;
		private System.Windows.Forms.Label lblPCSNo;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cbCauseCode;
		private System.Windows.Forms.ComboBox cbReasonCode;
		private System.Windows.Forms.TextBox txtADJNo;
		private System.Windows.Forms.Label lblAdjno;
		private System.Windows.Forms.TextBox txtNgQty;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtPartLocation;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblDefect;
		private System.Windows.Forms.TextBox txtRepairBarcode;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtTechnicalID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpNgay;
		private System.Windows.Forms.GroupBox grDepartment;
		private System.Windows.Forms.CheckBox chkSMT;
		private System.Windows.Forms.CheckBox chkScl;
		private System.Windows.Forms.CheckBox chkAssy;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.ComboBox cbLot;
		private System.Windows.Forms.ComboBox cbDefectCode;
	}
}