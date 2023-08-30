namespace SMTPRORAM.Assy.ET
{
    partial class frmAssyETCheckProcess
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.label8 = new System.Windows.Forms.Label();
			this.chkWireless = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtWireless = new System.Windows.Forms.TextBox();
			this.lblNgayThang = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btThoat = new System.Windows.Forms.Button();
			this.lblSoLuong = new System.Windows.Forms.Label();
			this.cbMarket = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btDownload = new System.Windows.Forms.Button();
			this.cbModel = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btSave = new System.Windows.Forms.Button();
			this.cbTypePcb = new System.Windows.Forms.ComboBox();
			this.lblChecker = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cbProcess = new System.Windows.Forms.ComboBox();
			this.txtQrCode = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtLineName = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.NG = new System.Windows.Forms.PictureBox();
			this.ok = new System.Windows.Forms.PictureBox();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(6, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(520, 548);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 40;
			this.label8.Text = "Checker:";
			// 
			// chkWireless
			// 
			this.chkWireless.AutoSize = true;
			this.chkWireless.Location = new System.Drawing.Point(227, 55);
			this.chkWireless.Name = "chkWireless";
			this.chkWireless.Size = new System.Drawing.Size(69, 17);
			this.chkWireless.TabIndex = 47;
			this.chkWireless.Text = "Wireless ";
			this.chkWireless.UseVisualStyleBackColor = true;
			this.chkWireless.CheckedChanged += new System.EventHandler(this.chkWireless_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 24;
			this.label1.Text = "Ngày:";
			// 
			// txtWireless
			// 
			this.txtWireless.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtWireless.Location = new System.Drawing.Point(73, 267);
			this.txtWireless.Name = "txtWireless";
			this.txtWireless.Size = new System.Drawing.Size(276, 20);
			this.txtWireless.TabIndex = 32;
			this.txtWireless.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWireless_KeyDown);
			// 
			// lblNgayThang
			// 
			this.lblNgayThang.AutoSize = true;
			this.lblNgayThang.BackColor = System.Drawing.SystemColors.Control;
			this.lblNgayThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblNgayThang.ForeColor = System.Drawing.Color.Blue;
			this.lblNgayThang.Location = new System.Drawing.Point(57, 19);
			this.lblNgayThang.Name = "lblNgayThang";
			this.lblNgayThang.Size = new System.Drawing.Size(85, 13);
			this.lblNgayThang.TabIndex = 26;
			this.lblNgayThang.Text = "lblNgayThang";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(13, 270);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(47, 13);
			this.label9.TabIndex = 46;
			this.label9.Text = "Wireless";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(210, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 28;
			this.label3.Text = "Số Lượng:";
			// 
			// btThoat
			// 
			this.btThoat.Location = new System.Drawing.Point(16, 412);
			this.btThoat.Name = "btThoat";
			this.btThoat.Size = new System.Drawing.Size(75, 23);
			this.btThoat.TabIndex = 45;
			this.btThoat.Text = "Thoát";
			this.btThoat.UseVisualStyleBackColor = true;
			this.btThoat.Visible = false;
			// 
			// lblSoLuong
			// 
			this.lblSoLuong.AutoSize = true;
			this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblSoLuong.ForeColor = System.Drawing.Color.Blue;
			this.lblSoLuong.Location = new System.Drawing.Point(272, 19);
			this.lblSoLuong.Name = "lblSoLuong";
			this.lblSoLuong.Size = new System.Drawing.Size(70, 13);
			this.lblSoLuong.TabIndex = 31;
			this.lblSoLuong.Text = "lblSoLuong";
			// 
			// cbMarket
			// 
			this.cbMarket.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbMarket.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMarket.FormattingEnabled = true;
			this.cbMarket.Location = new System.Drawing.Point(73, 159);
			this.cbMarket.Name = "cbMarket";
			this.cbMarket.Size = new System.Drawing.Size(276, 21);
			this.cbMarket.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 33;
			this.label2.Text = "Model:";
			// 
			// btDownload
			// 
			this.btDownload.Location = new System.Drawing.Point(16, 444);
			this.btDownload.Name = "btDownload";
			this.btDownload.Size = new System.Drawing.Size(75, 23);
			this.btDownload.TabIndex = 44;
			this.btDownload.Text = "Download";
			this.btDownload.UseVisualStyleBackColor = true;
			this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
			// 
			// cbModel
			// 
			this.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbModel.FormattingEnabled = true;
			this.cbModel.Location = new System.Drawing.Point(73, 123);
			this.cbModel.Name = "cbModel";
			this.cbModel.Size = new System.Drawing.Size(276, 21);
			this.cbModel.TabIndex = 25;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 36;
			this.label4.Text = "Market:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 197);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 13);
			this.label5.TabIndex = 37;
			this.label5.Text = "Type Pcb:";
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(73, 338);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 23);
			this.btSave.TabIndex = 35;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// cbTypePcb
			// 
			this.cbTypePcb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbTypePcb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbTypePcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTypePcb.FormattingEnabled = true;
			this.cbTypePcb.Location = new System.Drawing.Point(73, 194);
			this.cbTypePcb.Name = "cbTypePcb";
			this.cbTypePcb.Size = new System.Drawing.Size(277, 21);
			this.cbTypePcb.TabIndex = 29;
			// 
			// lblChecker
			// 
			this.lblChecker.AutoSize = true;
			this.lblChecker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblChecker.ForeColor = System.Drawing.Color.Blue;
			this.lblChecker.Location = new System.Drawing.Point(71, 56);
			this.lblChecker.Name = "lblChecker";
			this.lblChecker.Size = new System.Drawing.Size(67, 13);
			this.lblChecker.TabIndex = 41;
			this.lblChecker.Text = "lblChecker";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 235);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 13);
			this.label6.TabIndex = 38;
			this.label6.Text = "Process:";
			// 
			// cbProcess
			// 
			this.cbProcess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProcess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProcess.FormattingEnabled = true;
			this.cbProcess.Location = new System.Drawing.Point(73, 232);
			this.cbProcess.Name = "cbProcess";
			this.cbProcess.Size = new System.Drawing.Size(277, 21);
			this.cbProcess.TabIndex = 30;
			this.cbProcess.SelectedValueChanged += new System.EventHandler(this.cbProcess_SelectedValueChanged);
			// 
			// txtQrCode
			// 
			this.txtQrCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQrCode.Location = new System.Drawing.Point(73, 295);
			this.txtQrCode.Name = "txtQrCode";
			this.txtQrCode.Size = new System.Drawing.Size(276, 20);
			this.txtQrCode.TabIndex = 34;
			this.txtQrCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQrCode_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 298);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 13);
			this.label7.TabIndex = 39;
			this.label7.Text = "QR Code:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(364, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(538, 572);
			this.panel2.TabIndex = 28;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtLineName);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.chkWireless);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtWireless);
			this.panel1.Controls.Add(this.lblNgayThang);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.btThoat);
			this.panel1.Controls.Add(this.lblSoLuong);
			this.panel1.Controls.Add(this.cbMarket);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btDownload);
			this.panel1.Controls.Add(this.cbModel);
			this.panel1.Controls.Add(this.NG);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.ok);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.btSave);
			this.panel1.Controls.Add(this.cbTypePcb);
			this.panel1.Controls.Add(this.lblChecker);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.cbProcess);
			this.panel1.Controls.Add(this.txtQrCode);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(364, 572);
			this.panel1.TabIndex = 27;
			// 
			// txtLineName
			// 
			this.txtLineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLineName.Location = new System.Drawing.Point(74, 90);
			this.txtLineName.Name = "txtLineName";
			this.txtLineName.Size = new System.Drawing.Size(275, 20);
			this.txtLineName.TabIndex = 49;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 93);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(52, 13);
			this.label10.TabIndex = 48;
			this.label10.Text = "Tên Line:";
			// 
			// NG
			// 
			this.NG.Image = global::SMTPRORAM.Properties.Resources.NG_picture;
			this.NG.Location = new System.Drawing.Point(227, 338);
			this.NG.Name = "NG";
			this.NG.Size = new System.Drawing.Size(122, 117);
			this.NG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.NG.TabIndex = 43;
			this.NG.TabStop = false;
			// 
			// ok
			// 
			this.ok.Image = global::SMTPRORAM.Properties.Resources.OK_picture;
			this.ok.Location = new System.Drawing.Point(227, 338);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(122, 119);
			this.ok.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ok.TabIndex = 42;
			this.ok.TabStop = false;
			// 
			// frmAssyETCheckProcess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(902, 572);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmAssyETCheckProcess";
			this.Text = "Kiểm tra công đoạn trên line ET";
			this.Load += new System.EventHandler(this.frmAssyETCheckProcess_Load);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkWireless;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWireless;
        private System.Windows.Forms.Label lblNgayThang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.ComboBox cbMarket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.PictureBox NG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox ok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.ComboBox cbTypePcb;
        private System.Windows.Forms.Label lblChecker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProcess;
        private System.Windows.Forms.TextBox txtQrCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtLineName;
		private System.Windows.Forms.Label label10;
	}
}