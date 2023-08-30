namespace SMTPRORAM.AssyLine.ETASSY
{
	partial class frmGeneralSerial
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
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.btExport = new System.Windows.Forms.Button();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.numericTo = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.numericFrom = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.cbDCode = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cbMCode = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbYCode = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbFactoryCode = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbPCBCode = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbPCBType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbManuoc = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbModel = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.panelLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericFrom)).BeginInit();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.IconSize = 16;
			this.iconbtnSearch.Location = new System.Drawing.Point(22, 14);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(90, 23);
			this.iconbtnSearch.TabIndex = 91;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearch.Location = new System.Drawing.Point(118, 16);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(205, 20);
			this.txtSearch.TabIndex = 90;
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.btExport);
			this.panelLeft.Controls.Add(this.iconbtnCancel);
			this.panelLeft.Controls.Add(this.iconbtnSave);
			this.panelLeft.Controls.Add(this.numericTo);
			this.panelLeft.Controls.Add(this.label10);
			this.panelLeft.Controls.Add(this.numericFrom);
			this.panelLeft.Controls.Add(this.label9);
			this.panelLeft.Controls.Add(this.cbDCode);
			this.panelLeft.Controls.Add(this.label8);
			this.panelLeft.Controls.Add(this.cbMCode);
			this.panelLeft.Controls.Add(this.label7);
			this.panelLeft.Controls.Add(this.cbYCode);
			this.panelLeft.Controls.Add(this.label6);
			this.panelLeft.Controls.Add(this.cbFactoryCode);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.cbPCBCode);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Controls.Add(this.cbPCBType);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.cbManuoc);
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Controls.Add(this.cbModel);
			this.panelLeft.Controls.Add(this.iconbtnSearch);
			this.panelLeft.Controls.Add(this.txtSearch);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(340, 561);
			this.panelLeft.TabIndex = 4;
			// 
			// btExport
			// 
			this.btExport.Location = new System.Drawing.Point(93, 401);
			this.btExport.Name = "btExport";
			this.btExport.Size = new System.Drawing.Size(97, 23);
			this.btExport.TabIndex = 94;
			this.btExport.Text = "Export To CSV";
			this.btExport.UseVisualStyleBackColor = true;
			this.btExport.Click += new System.EventHandler(this.btExport_Click);
			// 
			// iconbtnCancel
			// 
			this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
			this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnCancel.Location = new System.Drawing.Point(248, 358);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(75, 23);
			this.iconbtnCancel.TabIndex = 93;
			this.iconbtnCancel.Text = "HỦY";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.Location = new System.Drawing.Point(93, 358);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSave.TabIndex = 92;
			this.iconbtnSave.Text = "SAVE";
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// numericTo
			// 
			this.numericTo.Location = new System.Drawing.Point(93, 321);
			this.numericTo.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.numericTo.Name = "numericTo";
			this.numericTo.Size = new System.Drawing.Size(120, 20);
			this.numericTo.TabIndex = 19;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(19, 323);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(47, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "In tới số:";
			// 
			// numericFrom
			// 
			this.numericFrom.Location = new System.Drawing.Point(93, 293);
			this.numericFrom.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.numericFrom.Name = "numericFrom";
			this.numericFrom.Size = new System.Drawing.Size(120, 20);
			this.numericFrom.TabIndex = 17;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(19, 295);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "In từ số:";
			// 
			// cbDCode
			// 
			this.cbDCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDCode.FormattingEnabled = true;
			this.cbDCode.Items.AddRange(new object[] {
            "--Select--",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V"});
			this.cbDCode.Location = new System.Drawing.Point(93, 260);
			this.cbDCode.Name = "cbDCode";
			this.cbDCode.Size = new System.Drawing.Size(230, 21);
			this.cbDCode.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(19, 264);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Mã Ngày:";
			// 
			// cbMCode
			// 
			this.cbMCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbMCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbMCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMCode.FormattingEnabled = true;
			this.cbMCode.Items.AddRange(new object[] {
            "--Select--",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C"});
			this.cbMCode.Location = new System.Drawing.Point(93, 231);
			this.cbMCode.Name = "cbMCode";
			this.cbMCode.Size = new System.Drawing.Size(230, 21);
			this.cbMCode.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(19, 235);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Mã Tháng:";
			// 
			// cbYCode
			// 
			this.cbYCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbYCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbYCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbYCode.FormattingEnabled = true;
			this.cbYCode.Items.AddRange(new object[] {
            "--Select--",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
			this.cbYCode.Location = new System.Drawing.Point(93, 202);
			this.cbYCode.Name = "cbYCode";
			this.cbYCode.Size = new System.Drawing.Size(230, 21);
			this.cbYCode.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(19, 206);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Mã Năm:";
			// 
			// cbFactoryCode
			// 
			this.cbFactoryCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFactoryCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFactoryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFactoryCode.FormattingEnabled = true;
			this.cbFactoryCode.Items.AddRange(new object[] {
            "--Select--",
            "L110",
            "L108"});
			this.cbFactoryCode.Location = new System.Drawing.Point(93, 173);
			this.cbFactoryCode.Name = "cbFactoryCode";
			this.cbFactoryCode.Size = new System.Drawing.Size(230, 21);
			this.cbFactoryCode.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(19, 177);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Mã Nhà Máy:";
			// 
			// cbPCBCode
			// 
			this.cbPCBCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbPCBCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbPCBCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPCBCode.FormattingEnabled = true;
			this.cbPCBCode.Items.AddRange(new object[] {
            "10",
            "14"});
			this.cbPCBCode.Location = new System.Drawing.Point(93, 144);
			this.cbPCBCode.Name = "cbPCBCode";
			this.cbPCBCode.Size = new System.Drawing.Size(230, 21);
			this.cbPCBCode.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 148);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "MÃ PCB:";
			// 
			// cbPCBType
			// 
			this.cbPCBType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbPCBType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbPCBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPCBType.FormattingEnabled = true;
			this.cbPCBType.Items.AddRange(new object[] {
            "--Select--",
            "10",
            "14"});
			this.cbPCBType.Location = new System.Drawing.Point(93, 115);
			this.cbPCBType.Name = "cbPCBType";
			this.cbPCBType.Size = new System.Drawing.Size(230, 21);
			this.cbPCBType.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "LOẠI PCB:";
			// 
			// cbManuoc
			// 
			this.cbManuoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbManuoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbManuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbManuoc.FormattingEnabled = true;
			this.cbManuoc.Items.AddRange(new object[] {
            "--Select--",
            "VN",
            "CN"});
			this.cbManuoc.Location = new System.Drawing.Point(93, 85);
			this.cbManuoc.Name = "cbManuoc";
			this.cbManuoc.Size = new System.Drawing.Size(230, 21);
			this.cbManuoc.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "MÃ NƯỚC:";
			// 
			// cbModel
			// 
			this.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbModel.FormattingEnabled = true;
			this.cbModel.Location = new System.Drawing.Point(93, 54);
			this.cbModel.Name = "cbModel";
			this.cbModel.Size = new System.Drawing.Size(230, 21);
			this.cbModel.TabIndex = 1;
			this.cbModel.SelectedValueChanged += new System.EventHandler(this.cbModel_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "MODEL:";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dataGridView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 561);
			this.panelContent.TabIndex = 5;
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(346, 12);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(626, 537);
			this.dataGridView.TabIndex = 0;
			// 
			// frmGeneralSerial
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.panelContent);
			this.Name = "frmGeneralSerial";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TẠO SERIAL CHO EASTECH";
			this.Load += new System.EventHandler(this.frmGeneralSerial_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericFrom)).EndInit();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.ComboBox cbModel;
		private System.Windows.Forms.ComboBox cbPCBType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbManuoc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbPCBCode;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbDCode;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbMCode;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbYCode;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbFactoryCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericTo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown numericFrom;
		private System.Windows.Forms.Label label9;
		private FontAwesome.Sharp.IconButton iconbtnCancel;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private System.Windows.Forms.Button btExport;
	}
}