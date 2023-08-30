namespace SMTPRORAM.Assy
{
    partial class frmCombineQRCode
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
			this.pictureBoxNG = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblTotal = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblUserTotal = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.btnDeleteBarcode = new System.Windows.Forms.Button();
			this.numQR = new System.Windows.Forms.NumericUpDown();
			this.lblQRCode = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtQRCode = new System.Windows.Forms.TextBox();
			this.lblProcess = new System.Windows.Forms.Label();
			this.cbLot = new System.Windows.Forms.ComboBox();
			this.cbLine = new System.Windows.Forms.ComboBox();
			this.lblOperator = new System.Windows.Forms.Label();
			this.lblLot = new System.Windows.Forms.Label();
			this.lblLine = new System.Windows.Forms.Label();
			this.iconbtnReset03 = new FontAwesome.Sharp.IconButton();
			this.txtEmployeeID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.iconbtnReset02 = new FontAwesome.Sharp.IconButton();
			this.iconbtnReset01 = new FontAwesome.Sharp.IconButton();
			this.cbProcessName = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Lbl_Baud = new System.Windows.Forms.Label();
			this.Txt_Baud = new System.Windows.Forms.TextBox();
			this.Cbo_COM = new System.Windows.Forms.ComboBox();
			this.RBtn_COM = new System.Windows.Forms.RadioButton();
			this.Cbo_USB = new System.Windows.Forms.ComboBox();
			this.RBtn_USB = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQR)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxNG
			// 
			this.pictureBoxNG.Image = global::SMTPRORAM.Properties.Resources.NG_picture;
			this.pictureBoxNG.Location = new System.Drawing.Point(371, 246);
			this.pictureBoxNG.Name = "pictureBoxNG";
			this.pictureBoxNG.Size = new System.Drawing.Size(111, 105);
			this.pictureBoxNG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxNG.TabIndex = 78;
			this.pictureBoxNG.TabStop = false;
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.Image = global::SMTPRORAM.Properties.Resources.OK_picture;
			this.pictureBoxOK.Location = new System.Drawing.Point(371, 246);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(109, 105);
			this.pictureBoxOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxOK.TabIndex = 77;
			this.pictureBoxOK.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lblTotal);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.lblUserTotal);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(496, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(488, 561);
			this.panel2.TabIndex = 5;
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTotal.ForeColor = System.Drawing.Color.Blue;
			this.lblTotal.Location = new System.Drawing.Point(135, 9);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(36, 13);
			this.lblTotal.TabIndex = 4;
			this.lblTotal.Text = "Total";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(117, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 3;
			this.label9.Text = "/";
			// 
			// lblUserTotal
			// 
			this.lblUserTotal.AutoSize = true;
			this.lblUserTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblUserTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.lblUserTotal.Location = new System.Drawing.Point(55, 9);
			this.lblUserTotal.Name = "lblUserTotal";
			this.lblUserTotal.Size = new System.Drawing.Size(62, 13);
			this.lblUserTotal.TabIndex = 2;
			this.lblUserTotal.Text = "UserTotal";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(43, 13);
			this.label8.TabIndex = 1;
			this.label8.Text = "Đã làm:";
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(6, 31);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(479, 527);
			this.dgView.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.btnDeleteBarcode);
			this.panel1.Controls.Add(this.numQR);
			this.panel1.Controls.Add(this.lblQRCode);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.txtQRCode);
			this.panel1.Controls.Add(this.lblProcess);
			this.panel1.Controls.Add(this.cbLot);
			this.panel1.Controls.Add(this.cbLine);
			this.panel1.Controls.Add(this.lblOperator);
			this.panel1.Controls.Add(this.lblLot);
			this.panel1.Controls.Add(this.lblLine);
			this.panel1.Controls.Add(this.iconbtnReset03);
			this.panel1.Controls.Add(this.txtEmployeeID);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.iconbtnReset02);
			this.panel1.Controls.Add(this.iconbtnReset01);
			this.panel1.Controls.Add(this.cbProcessName);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.Lbl_Baud);
			this.panel1.Controls.Add(this.Txt_Baud);
			this.panel1.Controls.Add(this.Cbo_COM);
			this.panel1.Controls.Add(this.RBtn_COM);
			this.panel1.Controls.Add(this.Cbo_USB);
			this.panel1.Controls.Add(this.RBtn_USB);
			this.panel1.Controls.Add(this.pictureBoxNG);
			this.panel1.Controls.Add(this.pictureBoxOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(496, 561);
			this.panel1.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(12, 424);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(418, 13);
			this.label5.TabIndex = 148;
			this.label5.Text = "Chỉ thực hiện khi một trong các mạch lắp ráp bị hỏng và phải thay thế bằng mạch k" +
    "hác";
			// 
			// btnDeleteBarcode
			// 
			this.btnDeleteBarcode.Location = new System.Drawing.Point(12, 398);
			this.btnDeleteBarcode.Name = "btnDeleteBarcode";
			this.btnDeleteBarcode.Size = new System.Drawing.Size(113, 23);
			this.btnDeleteBarcode.TabIndex = 147;
			this.btnDeleteBarcode.Text = "Xóa Barcode";
			this.btnDeleteBarcode.UseVisualStyleBackColor = true;
			this.btnDeleteBarcode.Click += new System.EventHandler(this.btnDeleteBarcode_Click);
			// 
			// numQR
			// 
			this.numQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numQR.Location = new System.Drawing.Point(93, 174);
			this.numQR.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.numQR.Name = "numQR";
			this.numQR.Size = new System.Drawing.Size(47, 22);
			this.numQR.TabIndex = 8;
			this.numQR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numQR_KeyDown);
			// 
			// lblQRCode
			// 
			this.lblQRCode.AutoSize = true;
			this.lblQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQRCode.Location = new System.Drawing.Point(371, 177);
			this.lblQRCode.Name = "lblQRCode";
			this.lblQRCode.Size = new System.Drawing.Size(83, 16);
			this.lblQRCode.TabIndex = 146;
			this.lblQRCode.Text = "lblQRCode";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(4, 177);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 16);
			this.label6.TabIndex = 137;
			this.label6.Text = "QR CODE:";
			// 
			// txtQRCode
			// 
			this.txtQRCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQRCode.Location = new System.Drawing.Point(146, 174);
			this.txtQRCode.Name = "txtQRCode";
			this.txtQRCode.Size = new System.Drawing.Size(219, 22);
			this.txtQRCode.TabIndex = 9;
			this.txtQRCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQRCode_KeyDown);
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProcess.Location = new System.Drawing.Point(371, 102);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(81, 16);
			this.lblProcess.TabIndex = 145;
			this.lblProcess.Text = "lblProcess";
			// 
			// cbLot
			// 
			this.cbLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLot.FormattingEnabled = true;
			this.cbLot.Location = new System.Drawing.Point(118, 64);
			this.cbLot.Name = "cbLot";
			this.cbLot.Size = new System.Drawing.Size(247, 21);
			this.cbLot.TabIndex = 3;
			this.cbLot.SelectionChangeCommitted += new System.EventHandler(this.cbLot_SelectionChangeCommitted);
			// 
			// cbLine
			// 
			this.cbLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLine.FormattingEnabled = true;
			this.cbLine.Location = new System.Drawing.Point(118, 28);
			this.cbLine.Name = "cbLine";
			this.cbLine.Size = new System.Drawing.Size(247, 21);
			this.cbLine.TabIndex = 1;
			this.cbLine.SelectionChangeCommitted += new System.EventHandler(this.cbLine_SelectionChangeCommitted);
			// 
			// lblOperator
			// 
			this.lblOperator.AutoSize = true;
			this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOperator.Location = new System.Drawing.Point(371, 140);
			this.lblOperator.Name = "lblOperator";
			this.lblOperator.Size = new System.Drawing.Size(85, 16);
			this.lblOperator.TabIndex = 144;
			this.lblOperator.Text = "lblOperator";
			// 
			// lblLot
			// 
			this.lblLot.AutoSize = true;
			this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLot.Location = new System.Drawing.Point(371, 65);
			this.lblLot.Name = "lblLot";
			this.lblLot.Size = new System.Drawing.Size(45, 16);
			this.lblLot.TabIndex = 143;
			this.lblLot.Text = "lblLot";
			// 
			// lblLine
			// 
			this.lblLine.AutoSize = true;
			this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLine.Location = new System.Drawing.Point(371, 31);
			this.lblLine.Name = "lblLine";
			this.lblLine.Size = new System.Drawing.Size(53, 16);
			this.lblLine.TabIndex = 142;
			this.lblLine.Text = "lblLine";
			// 
			// iconbtnReset03
			// 
			this.iconbtnReset03.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset03.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset03.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset03.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset03.Location = new System.Drawing.Point(420, 134);
			this.iconbtnReset03.Name = "iconbtnReset03";
			this.iconbtnReset03.Size = new System.Drawing.Size(67, 28);
			this.iconbtnReset03.TabIndex = 141;
			this.iconbtnReset03.Text = "Làm lại";
			this.iconbtnReset03.UseVisualStyleBackColor = true;
			this.iconbtnReset03.Click += new System.EventHandler(this.iconbtnReset03_Click);
			// 
			// txtEmployeeID
			// 
			this.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmployeeID.Location = new System.Drawing.Point(118, 136);
			this.txtEmployeeID.Name = "txtEmployeeID";
			this.txtEmployeeID.Size = new System.Drawing.Size(247, 22);
			this.txtEmployeeID.TabIndex = 7;
			this.txtEmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(4, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "ID công nhân:";
			// 
			// iconbtnReset02
			// 
			this.iconbtnReset02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset02.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset02.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset02.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset02.Location = new System.Drawing.Point(420, 60);
			this.iconbtnReset02.Name = "iconbtnReset02";
			this.iconbtnReset02.Size = new System.Drawing.Size(67, 28);
			this.iconbtnReset02.TabIndex = 140;
			this.iconbtnReset02.Text = "Làm lại";
			this.iconbtnReset02.UseVisualStyleBackColor = true;
			this.iconbtnReset02.Click += new System.EventHandler(this.iconbtnReset02_Click);
			// 
			// iconbtnReset01
			// 
			this.iconbtnReset01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset01.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset01.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset01.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset01.Location = new System.Drawing.Point(420, 24);
			this.iconbtnReset01.Name = "iconbtnReset01";
			this.iconbtnReset01.Size = new System.Drawing.Size(67, 28);
			this.iconbtnReset01.TabIndex = 139;
			this.iconbtnReset01.Text = "Làm lại";
			this.iconbtnReset01.UseVisualStyleBackColor = true;
			this.iconbtnReset01.Click += new System.EventHandler(this.iconbtnReset01_Click);
			// 
			// cbProcessName
			// 
			this.cbProcessName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProcessName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbProcessName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbProcessName.FormattingEnabled = true;
			this.cbProcessName.Location = new System.Drawing.Point(118, 99);
			this.cbProcessName.Name = "cbProcessName";
			this.cbProcessName.Size = new System.Drawing.Size(247, 24);
			this.cbProcessName.TabIndex = 5;
			this.cbProcessName.SelectionChangeCommitted += new System.EventHandler(this.cbProcessName_SelectionChangeCommitted);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(4, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Công đoạn: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(4, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tên LOT:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(4, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên chuyền:";
			// 
			// Lbl_Baud
			// 
			this.Lbl_Baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Lbl_Baud.AutoSize = true;
			this.Lbl_Baud.Location = new System.Drawing.Point(67, 304);
			this.Lbl_Baud.Name = "Lbl_Baud";
			this.Lbl_Baud.Size = new System.Drawing.Size(58, 13);
			this.Lbl_Baud.TabIndex = 89;
			this.Lbl_Baud.Text = "Baud Rate";
			// 
			// Txt_Baud
			// 
			this.Txt_Baud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Txt_Baud.Location = new System.Drawing.Point(128, 301);
			this.Txt_Baud.Name = "Txt_Baud";
			this.Txt_Baud.Size = new System.Drawing.Size(57, 20);
			this.Txt_Baud.TabIndex = 88;
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
			this.Cbo_COM.Location = new System.Drawing.Point(67, 273);
			this.Cbo_COM.Name = "Cbo_COM";
			this.Cbo_COM.Size = new System.Drawing.Size(298, 21);
			this.Cbo_COM.TabIndex = 86;
			// 
			// RBtn_COM
			// 
			this.RBtn_COM.AutoSize = true;
			this.RBtn_COM.Location = new System.Drawing.Point(9, 277);
			this.RBtn_COM.Name = "RBtn_COM";
			this.RBtn_COM.Size = new System.Drawing.Size(49, 17);
			this.RBtn_COM.TabIndex = 87;
			this.RBtn_COM.Text = "COM";
			this.RBtn_COM.UseVisualStyleBackColor = true;
			// 
			// Cbo_USB
			// 
			this.Cbo_USB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Cbo_USB.FormattingEnabled = true;
			this.Cbo_USB.Location = new System.Drawing.Point(67, 246);
			this.Cbo_USB.Name = "Cbo_USB";
			this.Cbo_USB.Size = new System.Drawing.Size(298, 21);
			this.Cbo_USB.TabIndex = 85;
			// 
			// RBtn_USB
			// 
			this.RBtn_USB.AutoSize = true;
			this.RBtn_USB.Checked = true;
			this.RBtn_USB.Location = new System.Drawing.Point(8, 249);
			this.RBtn_USB.Name = "RBtn_USB";
			this.RBtn_USB.Size = new System.Drawing.Size(47, 17);
			this.RBtn_USB.TabIndex = 84;
			this.RBtn_USB.TabStop = true;
			this.RBtn_USB.Text = "USB";
			this.RBtn_USB.UseVisualStyleBackColor = true;
			// 
			// frmCombineQRCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmCombineQRCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "COMBINE QRCODE TO NEW BARCODE";
			this.Load += new System.EventHandler(this.frmCombineQRCode_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numQR)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxNG;
        private System.Windows.Forms.PictureBox pictureBoxOK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_Baud;
        private System.Windows.Forms.TextBox Txt_Baud;
        private System.Windows.Forms.ComboBox Cbo_COM;
        private System.Windows.Forms.RadioButton RBtn_COM;
        private System.Windows.Forms.ComboBox Cbo_USB;
        private System.Windows.Forms.RadioButton RBtn_USB;
        private System.Windows.Forms.Label lblQRCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ComboBox cbLot;
        private System.Windows.Forms.ComboBox cbLine;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.Label lblLine;
        private FontAwesome.Sharp.IconButton iconbtnReset03;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton iconbtnReset02;
        private FontAwesome.Sharp.IconButton iconbtnReset01;
        private System.Windows.Forms.ComboBox cbProcessName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numQR;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnDeleteBarcode;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblUserTotal;
		private System.Windows.Forms.Label label8;
	}
}