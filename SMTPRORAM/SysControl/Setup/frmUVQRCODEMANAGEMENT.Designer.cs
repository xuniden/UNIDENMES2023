namespace SMTPRORAM.SysControl.Setup
{
    partial class frmUVQRCODEMANAGEMENT
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
            this.tabControlCreate = new System.Windows.Forms.TabControl();
            this.tabPageCreateQRCode = new System.Windows.Forms.TabPage();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dgViewCreate = new System.Windows.Forms.DataGridView();
            this.panelCreateQR = new System.Windows.Forms.Panel();
            this.txtPCBTYPE = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPcbCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.iconbtnSeach = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
            this.iconbtnSave = new FontAwesome.Sharp.IconButton();
            this.numericTo = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericFrom = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDayInWeek = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbWeek = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbEndOfYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFactoryCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQRSample = new System.Windows.Forms.Label();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.iconbtnExportCSV = new FontAwesome.Sharp.IconButton();
            this.tabControlCreate.SuspendLayout();
            this.tabPageCreateQRCode.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewCreate)).BeginInit();
            this.panelCreateQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlCreate
            // 
            this.tabControlCreate.Controls.Add(this.tabPageCreateQRCode);
            this.tabControlCreate.Controls.Add(this.tabPageSearch);
            this.tabControlCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCreate.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlCreate.Location = new System.Drawing.Point(0, 0);
            this.tabControlCreate.Name = "tabControlCreate";
            this.tabControlCreate.SelectedIndex = 0;
            this.tabControlCreate.Size = new System.Drawing.Size(984, 561);
            this.tabControlCreate.TabIndex = 0;
            this.tabControlCreate.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlCreate_DrawItem);
            // 
            // tabPageCreateQRCode
            // 
            this.tabPageCreateQRCode.Controls.Add(this.panelContent);
            this.tabPageCreateQRCode.Controls.Add(this.panelCreateQR);
            this.tabPageCreateQRCode.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreateQRCode.Name = "tabPageCreateQRCode";
            this.tabPageCreateQRCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreateQRCode.Size = new System.Drawing.Size(976, 535);
            this.tabPageCreateQRCode.TabIndex = 0;
            this.tabPageCreateQRCode.Text = "Tạo mã QRCode";
            this.tabPageCreateQRCode.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dgViewCreate);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(422, 3);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(551, 529);
            this.panelContent.TabIndex = 1;
            // 
            // dgViewCreate
            // 
            this.dgViewCreate.AllowUserToAddRows = false;
            this.dgViewCreate.AllowUserToDeleteRows = false;
            this.dgViewCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgViewCreate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewCreate.Location = new System.Drawing.Point(6, 3);
            this.dgViewCreate.Name = "dgViewCreate";
            this.dgViewCreate.ReadOnly = true;
            this.dgViewCreate.Size = new System.Drawing.Size(540, 521);
            this.dgViewCreate.TabIndex = 0;
            // 
            // panelCreateQR
            // 
            this.panelCreateQR.Controls.Add(this.iconbtnExportCSV);
            this.panelCreateQR.Controls.Add(this.txtPCBTYPE);
            this.panelCreateQR.Controls.Add(this.label10);
            this.panelCreateQR.Controls.Add(this.cbPcbCode);
            this.panelCreateQR.Controls.Add(this.label9);
            this.panelCreateQR.Controls.Add(this.cbModel);
            this.panelCreateQR.Controls.Add(this.iconbtnSeach);
            this.panelCreateQR.Controls.Add(this.txtSearch);
            this.panelCreateQR.Controls.Add(this.label1);
            this.panelCreateQR.Controls.Add(this.iconbtnCancel);
            this.panelCreateQR.Controls.Add(this.iconbtnSave);
            this.panelCreateQR.Controls.Add(this.numericTo);
            this.panelCreateQR.Controls.Add(this.label8);
            this.panelCreateQR.Controls.Add(this.numericFrom);
            this.panelCreateQR.Controls.Add(this.label7);
            this.panelCreateQR.Controls.Add(this.cbDayInWeek);
            this.panelCreateQR.Controls.Add(this.label6);
            this.panelCreateQR.Controls.Add(this.cbWeek);
            this.panelCreateQR.Controls.Add(this.label5);
            this.panelCreateQR.Controls.Add(this.cbEndOfYear);
            this.panelCreateQR.Controls.Add(this.label4);
            this.panelCreateQR.Controls.Add(this.label3);
            this.panelCreateQR.Controls.Add(this.cbFactoryCode);
            this.panelCreateQR.Controls.Add(this.label2);
            this.panelCreateQR.Controls.Add(this.lblQRSample);
            this.panelCreateQR.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCreateQR.ForeColor = System.Drawing.Color.Blue;
            this.panelCreateQR.Location = new System.Drawing.Point(3, 3);
            this.panelCreateQR.Name = "panelCreateQR";
            this.panelCreateQR.Size = new System.Drawing.Size(419, 529);
            this.panelCreateQR.TabIndex = 0;
            // 
            // txtPCBTYPE
            // 
            this.txtPCBTYPE.Enabled = false;
            this.txtPCBTYPE.Location = new System.Drawing.Point(141, 189);
            this.txtPCBTYPE.Name = "txtPCBTYPE";
            this.txtPCBTYPE.Size = new System.Drawing.Size(227, 20);
            this.txtPCBTYPE.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "PCB TYPE";
            // 
            // cbPcbCode
            // 
            this.cbPcbCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPcbCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPcbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPcbCode.FormattingEnabled = true;
            this.cbPcbCode.Location = new System.Drawing.Point(141, 154);
            this.cbPcbCode.Name = "cbPcbCode";
            this.cbPcbCode.Size = new System.Drawing.Size(227, 21);
            this.cbPcbCode.TabIndex = 6;
            this.cbPcbCode.SelectionChangeCommitted += new System.EventHandler(this.cbPcbCode_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "PCB CODE:";
            // 
            // cbModel
            // 
            this.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(141, 121);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(227, 21);
            this.cbModel.TabIndex = 4;
            this.cbModel.SelectionChangeCommitted += new System.EventHandler(this.cbModel_SelectionChangeCommitted);
            // 
            // iconbtnSeach
            // 
            this.iconbtnSeach.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnSeach.IconColor = System.Drawing.Color.Black;
            this.iconbtnSeach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSeach.Location = new System.Drawing.Point(334, 46);
            this.iconbtnSeach.Name = "iconbtnSeach";
            this.iconbtnSeach.Size = new System.Drawing.Size(75, 23);
            this.iconbtnSeach.TabIndex = 19;
            this.iconbtnSeach.Text = "Tìm kiếm";
            this.iconbtnSeach.UseVisualStyleBackColor = true;
            this.iconbtnSeach.Click += new System.EventHandler(this.iconbtnSeach_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(88, 48);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 20);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tìm kiếm:";
            // 
            // iconbtnCancel
            // 
            this.iconbtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.iconbtnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
            this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnCancel.Location = new System.Drawing.Point(206, 404);
            this.iconbtnCancel.Name = "iconbtnCancel";
            this.iconbtnCancel.Size = new System.Drawing.Size(76, 23);
            this.iconbtnCancel.TabIndex = 18;
            this.iconbtnCancel.Text = "Cancel";
            this.iconbtnCancel.UseVisualStyleBackColor = true;
            this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
            // 
            // iconbtnSave
            // 
            this.iconbtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.iconbtnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnSave.IconColor = System.Drawing.Color.Black;
            this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnSave.Location = new System.Drawing.Point(73, 404);
            this.iconbtnSave.Name = "iconbtnSave";
            this.iconbtnSave.Size = new System.Drawing.Size(116, 23);
            this.iconbtnSave.TabIndex = 17;
            this.iconbtnSave.Text = "Create QR Code";
            this.iconbtnSave.UseVisualStyleBackColor = true;
            this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
            // 
            // numericTo
            // 
            this.numericTo.Location = new System.Drawing.Point(141, 364);
            this.numericTo.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTo.Name = "numericTo";
            this.numericTo.Size = new System.Drawing.Size(227, 20);
            this.numericTo.TabIndex = 16;
            this.numericTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "TO NUMBER:";
            // 
            // numericFrom
            // 
            this.numericFrom.Location = new System.Drawing.Point(141, 329);
            this.numericFrom.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericFrom.Name = "numericFrom";
            this.numericFrom.Size = new System.Drawing.Size(227, 20);
            this.numericFrom.TabIndex = 14;
            this.numericFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "FROM NUMBER:";
            // 
            // cbDayInWeek
            // 
            this.cbDayInWeek.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDayInWeek.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDayInWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayInWeek.FormattingEnabled = true;
            this.cbDayInWeek.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbDayInWeek.Location = new System.Drawing.Point(141, 294);
            this.cbDayInWeek.Name = "cbDayInWeek";
            this.cbDayInWeek.Size = new System.Drawing.Size(227, 21);
            this.cbDayInWeek.TabIndex = 12;
            this.cbDayInWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDayInWeek_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "DAY IN WEEK:";
            // 
            // cbWeek
            // 
            this.cbWeek.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbWeek.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeek.FormattingEnabled = true;
            this.cbWeek.Items.AddRange(new object[] {
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
            this.cbWeek.Location = new System.Drawing.Point(141, 257);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(227, 21);
            this.cbWeek.TabIndex = 10;
            this.cbWeek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbWeek_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "WEEK:";
            // 
            // cbEndOfYear
            // 
            this.cbEndOfYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEndOfYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEndOfYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndOfYear.FormattingEnabled = true;
            this.cbEndOfYear.Items.AddRange(new object[] {
            "Q-->0",
            "R-->1",
            "S-->2",
            "T-->3",
            "U-->4",
            "V-->5",
            "W-->6",
            "X-->7",
            "Y-->8",
            "Z-->9"});
            this.cbEndOfYear.Location = new System.Drawing.Point(141, 221);
            this.cbEndOfYear.Name = "cbEndOfYear";
            this.cbEndOfYear.Size = new System.Drawing.Size(227, 21);
            this.cbEndOfYear.TabIndex = 8;
            this.cbEndOfYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEndOfYear_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "END OF YEAR:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "MODEL:";
            // 
            // cbFactoryCode
            // 
            this.cbFactoryCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFactoryCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFactoryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFactoryCode.FormattingEnabled = true;
            this.cbFactoryCode.Location = new System.Drawing.Point(141, 88);
            this.cbFactoryCode.Name = "cbFactoryCode";
            this.cbFactoryCode.Size = new System.Drawing.Size(227, 21);
            this.cbFactoryCode.TabIndex = 2;
            this.cbFactoryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFactoryCode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "FACTORY CODE:";
            // 
            // lblQRSample
            // 
            this.lblQRSample.AutoSize = true;
            this.lblQRSample.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblQRSample.Location = new System.Drawing.Point(21, 24);
            this.lblQRSample.Name = "lblQRSample";
            this.lblQRSample.Size = new System.Drawing.Size(35, 13);
            this.lblQRSample.TabIndex = 0;
            this.lblQRSample.Text = "label1";
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(976, 535);
            this.tabPageSearch.TabIndex = 1;
            this.tabPageSearch.Text = "Tìm kiếm, tra cứu thông tin mã QRCode";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // iconbtnExportCSV
            // 
            this.iconbtnExportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.iconbtnExportCSV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconbtnExportCSV.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnExportCSV.IconColor = System.Drawing.Color.Black;
            this.iconbtnExportCSV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnExportCSV.Location = new System.Drawing.Point(301, 404);
            this.iconbtnExportCSV.Name = "iconbtnExportCSV";
            this.iconbtnExportCSV.Size = new System.Drawing.Size(76, 23);
            this.iconbtnExportCSV.TabIndex = 22;
            this.iconbtnExportCSV.Text = "ExportCSV";
            this.iconbtnExportCSV.UseVisualStyleBackColor = true;
            this.iconbtnExportCSV.Click += new System.EventHandler(this.iconbtnExportCSV_Click);
            // 
            // frmUVQRCODEMANAGEMENT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControlCreate);
            this.Name = "frmUVQRCODEMANAGEMENT";
            this.Text = "TẠO VÀ QUẢN LÝ QRCODE";
            this.Load += new System.EventHandler(this.frmUVQRCODEMANAGEMENT_Load);
            this.tabControlCreate.ResumeLayout(false);
            this.tabPageCreateQRCode.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewCreate)).EndInit();
            this.panelCreateQR.ResumeLayout(false);
            this.panelCreateQR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCreate;
        private System.Windows.Forms.TabPage tabPageCreateQRCode;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dgViewCreate;
        private System.Windows.Forms.Panel panelCreateQR;
        private System.Windows.Forms.Label lblQRSample;
        private System.Windows.Forms.NumericUpDown numericFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDayInWeek;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbWeek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEndOfYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFactoryCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericTo;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnSeach;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPcbCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.TextBox txtPCBTYPE;
        private System.Windows.Forms.Label label10;
        private FontAwesome.Sharp.IconButton iconbtnExportCSV;
    }
}