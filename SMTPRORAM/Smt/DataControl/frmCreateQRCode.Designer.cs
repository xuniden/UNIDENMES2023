namespace SMTPRORAM.Smt.DataControl
{
    partial class frmCreateQRCode
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateQRCode));
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbModel = new System.Windows.Forms.ComboBox();
			this.btExport = new System.Windows.Forms.Button();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.numericUpDownTo = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownFrom = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cbDayOfWeek = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbWeekOfYear = new System.Windows.Forms.ComboBox();
			this.cbEndOfYear = new System.Windows.Forms.ComboBox();
			this.cbTypeOfProduct = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtModelCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbPcbCode = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbModel);
			this.panel1.Controls.Add(this.btExport);
			this.panel1.Controls.Add(this.iconbtnSave);
			this.panel1.Controls.Add(this.numericUpDownTo);
			this.panel1.Controls.Add(this.numericUpDownFrom);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.cbDayOfWeek);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.cbWeekOfYear);
			this.panel1.Controls.Add(this.cbEndOfYear);
			this.panel1.Controls.Add(this.cbTypeOfProduct);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtModelCode);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cbPcbCode);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(339, 561);
			this.panel1.TabIndex = 0;
			// 
			// cbModel
			// 
			this.cbModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbModel.FormattingEnabled = true;
			this.cbModel.Location = new System.Drawing.Point(132, 33);
			this.cbModel.Name = "cbModel";
			this.cbModel.Size = new System.Drawing.Size(154, 21);
			this.cbModel.TabIndex = 0;
			this.cbModel.SelectedValueChanged += new System.EventHandler(this.cbModel_SelectedValueChanged);
			this.cbModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbModel_KeyPress);
			// 
			// btExport
			// 
			this.btExport.Location = new System.Drawing.Point(236, 281);
			this.btExport.Name = "btExport";
			this.btExport.Size = new System.Drawing.Size(97, 23);
			this.btExport.TabIndex = 9;
			this.btExport.Text = "Export To CSV";
			this.btExport.UseVisualStyleBackColor = true;
			this.btExport.Click += new System.EventHandler(this.btExport_Click);
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 16;
			this.iconbtnSave.Location = new System.Drawing.Point(132, 281);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(79, 23);
			this.iconbtnSave.TabIndex = 8;
			this.iconbtnSave.Text = "Ghi lại";
			this.iconbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// numericUpDownTo
			// 
			this.numericUpDownTo.Location = new System.Drawing.Point(273, 242);
			this.numericUpDownTo.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
			this.numericUpDownTo.Name = "numericUpDownTo";
			this.numericUpDownTo.Size = new System.Drawing.Size(60, 20);
			this.numericUpDownTo.TabIndex = 7;
			this.numericUpDownTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDownFrom
			// 
			this.numericUpDownFrom.Location = new System.Drawing.Point(132, 242);
			this.numericUpDownFrom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownFrom.Name = "numericUpDownFrom";
			this.numericUpDownFrom.Size = new System.Drawing.Size(58, 20);
			this.numericUpDownFrom.TabIndex = 6;
			this.numericUpDownFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(213, 246);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 13);
			this.label9.TabIndex = 55;
			this.label9.Text = "In Tới Số:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 246);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(51, 13);
			this.label8.TabIndex = 54;
			this.label8.Text = "In Từ Số:";
			// 
			// cbDayOfWeek
			// 
			this.cbDayOfWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbDayOfWeek.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDayOfWeek.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDayOfWeek.FormattingEnabled = true;
			this.cbDayOfWeek.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
			this.cbDayOfWeek.Location = new System.Drawing.Point(131, 212);
			this.cbDayOfWeek.Name = "cbDayOfWeek";
			this.cbDayOfWeek.Size = new System.Drawing.Size(202, 21);
			this.cbDayOfWeek.TabIndex = 5;
			this.cbDayOfWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDayOfWeek_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 216);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 13);
			this.label4.TabIndex = 51;
			this.label4.Text = "Days Of Week:";
			// 
			// cbWeekOfYear
			// 
			this.cbWeekOfYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbWeekOfYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbWeekOfYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbWeekOfYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWeekOfYear.FormattingEnabled = true;
			this.cbWeekOfYear.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52"});
			this.cbWeekOfYear.Location = new System.Drawing.Point(131, 182);
			this.cbWeekOfYear.Name = "cbWeekOfYear";
			this.cbWeekOfYear.Size = new System.Drawing.Size(202, 21);
			this.cbWeekOfYear.TabIndex = 4;
			this.cbWeekOfYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbWeekOfYear_KeyPress);
			// 
			// cbEndOfYear
			// 
			this.cbEndOfYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbEndOfYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbEndOfYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbEndOfYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEndOfYear.FormattingEnabled = true;
			this.cbEndOfYear.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.cbEndOfYear.Location = new System.Drawing.Point(131, 152);
			this.cbEndOfYear.Name = "cbEndOfYear";
			this.cbEndOfYear.Size = new System.Drawing.Size(202, 21);
			this.cbEndOfYear.TabIndex = 3;
			this.cbEndOfYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEndOfYear_KeyPress);
			// 
			// cbTypeOfProduct
			// 
			this.cbTypeOfProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTypeOfProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbTypeOfProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbTypeOfProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTypeOfProduct.FormattingEnabled = true;
			this.cbTypeOfProduct.Items.AddRange(new object[] {
            "A| AMP PCBA",
            "G| AUDIO PCBA",
            "V| AV PCBA",
            "B| BD PCBA",
            "D| CD PCBA",
            "C| CONTROL PCBA",
            "Y| DISPLAY PCBA",
            "S| DSP PCBA",
            "I| IPOD PCBA",
            "M| MAIN PCBA",
            "P| POWER PCBA",
            "E| REMOTE PCBA",
            "O| SERVO PCBA",
            "T| TAPE PCBA",
            "R| TUNER PCBA",
            "U| OTHER"});
			this.cbTypeOfProduct.Location = new System.Drawing.Point(132, 122);
			this.cbTypeOfProduct.Name = "cbTypeOfProduct";
			this.cbTypeOfProduct.Size = new System.Drawing.Size(202, 21);
			this.cbTypeOfProduct.TabIndex = 2;
			this.cbTypeOfProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTypeOfProduct_KeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 186);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 13);
			this.label7.TabIndex = 50;
			this.label7.Text = "Weeks In Year:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 156);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 13);
			this.label6.TabIndex = 49;
			this.label6.Text = "End Of Year:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 126);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 13);
			this.label5.TabIndex = 48;
			this.label5.Text = "Type Of Product:";
			// 
			// txtModelCode
			// 
			this.txtModelCode.Enabled = false;
			this.txtModelCode.Location = new System.Drawing.Point(132, 63);
			this.txtModelCode.Name = "txtModelCode";
			this.txtModelCode.Size = new System.Drawing.Size(66, 20);
			this.txtModelCode.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Model Code";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Model";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "PCB Code";
			// 
			// cbPcbCode
			// 
			this.cbPcbCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPcbCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbPcbCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbPcbCode.FormattingEnabled = true;
			this.cbPcbCode.Location = new System.Drawing.Point(132, 92);
			this.cbPcbCode.Name = "cbPcbCode";
			this.cbPcbCode.Size = new System.Drawing.Size(201, 21);
			this.cbPcbCode.TabIndex = 1;
			this.cbPcbCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPcbCode_KeyPress);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(339, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(645, 561);
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
			this.dgView.Location = new System.Drawing.Point(6, 12);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(627, 537);
			this.dgView.TabIndex = 0;
			// 
			// frmCreateQRCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCreateQRCode";
			this.Text = "Tạo mã số serial theo số QR code";
			this.Load += new System.EventHandler(this.frmCreateQRCode_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrom)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ComboBox cbPcbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDayOfWeek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbWeekOfYear;
        private System.Windows.Forms.ComboBox cbEndOfYear;
        private System.Windows.Forms.ComboBox cbTypeOfProduct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownTo;
        private System.Windows.Forms.NumericUpDown numericUpDownFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.ComboBox cbModel;
    }
}