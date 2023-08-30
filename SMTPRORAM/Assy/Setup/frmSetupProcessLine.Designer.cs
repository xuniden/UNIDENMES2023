namespace SMTPRORAM.Assy.Setup
{
    partial class frmSetupProcessLine
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.iconbtnReset = new FontAwesome.Sharp.IconButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.chkAuto = new System.Windows.Forms.CheckBox();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.chkStatus = new System.Windows.Forms.CheckBox();
			this.cbLot = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtProcessName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.iconbtnScanQRDown = new FontAwesome.Sharp.IconButton();
			this.iconbtnScanQRUp = new FontAwesome.Sharp.IconButton();
			this.iconbtnNonScanQRDown = new FontAwesome.Sharp.IconButton();
			this.iconbtnNonScanQRUp = new FontAwesome.Sharp.IconButton();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.listViewScanQR = new System.Windows.Forms.ListView();
			this.listViewNonScanQR = new System.Windows.Forms.ListView();
			this.iconSaveToDB = new FontAwesome.Sharp.IconButton();
			this.iconbtnToLeft = new FontAwesome.Sharp.IconButton();
			this.iconbtnToRight = new FontAwesome.Sharp.IconButton();
			this.cbgroupProcess = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbgroupProcess);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.iconbtnReset);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.numericUpDown2);
			this.panel1.Controls.Add(this.numericUpDown1);
			this.panel1.Controls.Add(this.chkAuto);
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Controls.Add(this.chkStatus);
			this.panel1.Controls.Add(this.cbLot);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtProcessName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(285, 561);
			this.panel1.TabIndex = 0;
			// 
			// iconbtnReset
			// 
			this.iconbtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnReset.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset.Location = new System.Drawing.Point(17, 390);
			this.iconbtnReset.Name = "iconbtnReset";
			this.iconbtnReset.Size = new System.Drawing.Size(252, 43);
			this.iconbtnReset.TabIndex = 97;
			this.iconbtnReset.Text = "Reset trạng thái của công đoạn không bắn QRCode để bắn lại";
			this.iconbtnReset.UseVisualStyleBackColor = true;
			this.iconbtnReset.Click += new System.EventHandler(this.iconbtnReset_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 96;
			this.label4.Text = "Tới số:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 209);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 95;
			this.label3.Text = "Từ số:";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(98, 238);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(171, 20);
			this.numericUpDown2.TabIndex = 94;
			this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(98, 207);
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(171, 20);
			this.numericUpDown1.TabIndex = 93;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// chkAuto
			// 
			this.chkAuto.AutoSize = true;
			this.chkAuto.Location = new System.Drawing.Point(98, 182);
			this.chkAuto.Name = "chkAuto";
			this.chkAuto.Size = new System.Drawing.Size(91, 17);
			this.chkAuto.TabIndex = 92;
			this.chkAuto.Text = "Tự động tăng";
			this.chkAuto.UseVisualStyleBackColor = true;
			this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.IconSize = 16;
			this.iconbtnSearch.Location = new System.Drawing.Point(194, 29);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSearch.TabIndex = 91;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(17, 31);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(171, 20);
			this.txtSearch.TabIndex = 90;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.89743F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.19658F));
			this.tableLayoutPanel1.Controls.Add(this.iconbtnEdit, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnDelete, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnAdd, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 299);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 60);
			this.tableLayoutPanel1.TabIndex = 89;
			// 
			// iconbtnEdit
			// 
			this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
			this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
			this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnEdit.IconSize = 16;
			this.iconbtnEdit.Location = new System.Drawing.Point(86, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(84, 23);
			this.iconbtnEdit.TabIndex = 14;
			this.iconbtnEdit.Text = "Sửa";
			this.iconbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnEdit.UseVisualStyleBackColor = true;
			this.iconbtnEdit.Click += new System.EventHandler(this.iconbtnEdit_Click);
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.IconSize = 16;
			this.iconbtnDelete.Location = new System.Drawing.Point(176, 3);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(73, 23);
			this.iconbtnDelete.TabIndex = 15;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 18;
			this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(77, 23);
			this.iconbtnSave.TabIndex = 16;
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
			this.iconbtnCancel.IconSize = 18;
			this.iconbtnCancel.Location = new System.Drawing.Point(86, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(84, 23);
			this.iconbtnCancel.TabIndex = 17;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// iconbtnAdd
			// 
			this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
			this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
			this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnAdd.IconSize = 18;
			this.iconbtnAdd.Location = new System.Drawing.Point(3, 3);
			this.iconbtnAdd.Name = "iconbtnAdd";
			this.iconbtnAdd.Size = new System.Drawing.Size(77, 23);
			this.iconbtnAdd.TabIndex = 13;
			this.iconbtnAdd.Text = "Thêm";
			this.iconbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnAdd.UseVisualStyleBackColor = true;
			this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
			// 
			// chkStatus
			// 
			this.chkStatus.AutoSize = true;
			this.chkStatus.Location = new System.Drawing.Point(98, 267);
			this.chkStatus.Name = "chkStatus";
			this.chkStatus.Size = new System.Drawing.Size(98, 17);
			this.chkStatus.TabIndex = 4;
			this.chkStatus.Text = "Không sử dụng";
			this.chkStatus.UseVisualStyleBackColor = true;
			// 
			// cbLot
			// 
			this.cbLot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLot.FormattingEnabled = true;
			this.cbLot.Location = new System.Drawing.Point(98, 93);
			this.cbLot.Name = "cbLot";
			this.cbLot.Size = new System.Drawing.Size(171, 21);
			this.cbLot.TabIndex = 1;
			this.cbLot.SelectionChangeCommitted += new System.EventHandler(this.cbLot_SelectionChangeCommitted);
			this.cbLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLot_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "LOT Chạy:";
			// 
			// txtProcessName
			// 
			this.txtProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProcessName.Location = new System.Drawing.Point(98, 152);
			this.txtProcessName.Name = "txtProcessName";
			this.txtProcessName.Size = new System.Drawing.Size(171, 20);
			this.txtProcessName.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 155);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tên công đoạn:";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Location = new System.Drawing.Point(743, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(241, 561);
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
			this.dgView.Location = new System.Drawing.Point(0, 3);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(238, 558);
			this.dgView.TabIndex = 0;
			this.dgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellDoubleClick);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.iconbtnScanQRDown);
			this.panel3.Controls.Add(this.iconbtnScanQRUp);
			this.panel3.Controls.Add(this.iconbtnNonScanQRDown);
			this.panel3.Controls.Add(this.iconbtnNonScanQRUp);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.listViewScanQR);
			this.panel3.Controls.Add(this.listViewNonScanQR);
			this.panel3.Controls.Add(this.iconSaveToDB);
			this.panel3.Controls.Add(this.iconbtnToLeft);
			this.panel3.Controls.Add(this.iconbtnToRight);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(285, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(452, 561);
			this.panel3.TabIndex = 2;
			// 
			// iconbtnScanQRDown
			// 
			this.iconbtnScanQRDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.iconbtnScanQRDown.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnScanQRDown.IconColor = System.Drawing.Color.Black;
			this.iconbtnScanQRDown.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnScanQRDown.Location = new System.Drawing.Point(197, 299);
			this.iconbtnScanQRDown.Name = "iconbtnScanQRDown";
			this.iconbtnScanQRDown.Size = new System.Drawing.Size(61, 23);
			this.iconbtnScanQRDown.TabIndex = 10;
			this.iconbtnScanQRDown.Text = "S Down";
			this.iconbtnScanQRDown.UseVisualStyleBackColor = false;
			this.iconbtnScanQRDown.Click += new System.EventHandler(this.iconbtnScanQRDown_Click);
			// 
			// iconbtnScanQRUp
			// 
			this.iconbtnScanQRUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.iconbtnScanQRUp.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnScanQRUp.IconColor = System.Drawing.Color.Black;
			this.iconbtnScanQRUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnScanQRUp.Location = new System.Drawing.Point(197, 270);
			this.iconbtnScanQRUp.Name = "iconbtnScanQRUp";
			this.iconbtnScanQRUp.Size = new System.Drawing.Size(61, 23);
			this.iconbtnScanQRUp.TabIndex = 9;
			this.iconbtnScanQRUp.Text = "S Up";
			this.iconbtnScanQRUp.UseVisualStyleBackColor = false;
			this.iconbtnScanQRUp.Click += new System.EventHandler(this.iconbtnScanQRUp_Click);
			// 
			// iconbtnNonScanQRDown
			// 
			this.iconbtnNonScanQRDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.iconbtnNonScanQRDown.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNonScanQRDown.IconColor = System.Drawing.Color.Black;
			this.iconbtnNonScanQRDown.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNonScanQRDown.Location = new System.Drawing.Point(197, 60);
			this.iconbtnNonScanQRDown.Name = "iconbtnNonScanQRDown";
			this.iconbtnNonScanQRDown.Size = new System.Drawing.Size(61, 23);
			this.iconbtnNonScanQRDown.TabIndex = 10;
			this.iconbtnNonScanQRDown.Text = "N Down";
			this.iconbtnNonScanQRDown.UseVisualStyleBackColor = false;
			this.iconbtnNonScanQRDown.Click += new System.EventHandler(this.iconbtnNonScanQRDown_Click);
			// 
			// iconbtnNonScanQRUp
			// 
			this.iconbtnNonScanQRUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.iconbtnNonScanQRUp.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNonScanQRUp.IconColor = System.Drawing.Color.Black;
			this.iconbtnNonScanQRUp.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNonScanQRUp.Location = new System.Drawing.Point(197, 31);
			this.iconbtnNonScanQRUp.Name = "iconbtnNonScanQRUp";
			this.iconbtnNonScanQRUp.Size = new System.Drawing.Size(61, 23);
			this.iconbtnNonScanQRUp.TabIndex = 9;
			this.iconbtnNonScanQRUp.Text = "N Up";
			this.iconbtnNonScanQRUp.UseVisualStyleBackColor = false;
			this.iconbtnNonScanQRUp.Click += new System.EventHandler(this.iconbtnNonScanQRUp_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(259, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Scan QRCode";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Không Scan QRCode";
			// 
			// listViewScanQR
			// 
			this.listViewScanQR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listViewScanQR.HideSelection = false;
			this.listViewScanQR.Location = new System.Drawing.Point(262, 31);
			this.listViewScanQR.Name = "listViewScanQR";
			this.listViewScanQR.Size = new System.Drawing.Size(187, 525);
			this.listViewScanQR.TabIndex = 6;
			this.listViewScanQR.UseCompatibleStateImageBehavior = false;
			this.listViewScanQR.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewScanQR_DragDrop);
			this.listViewScanQR.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewScanQR_DragEnter);
			// 
			// listViewNonScanQR
			// 
			this.listViewNonScanQR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listViewNonScanQR.HideSelection = false;
			this.listViewNonScanQR.Location = new System.Drawing.Point(6, 31);
			this.listViewNonScanQR.Name = "listViewNonScanQR";
			this.listViewNonScanQR.Size = new System.Drawing.Size(185, 525);
			this.listViewNonScanQR.TabIndex = 5;
			this.listViewNonScanQR.UseCompatibleStateImageBehavior = false;
			this.listViewNonScanQR.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewNonScanQR_ItemDrag);
			this.listViewNonScanQR.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewNonScanQR_DragDrop);
			this.listViewNonScanQR.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewNonScanQR_DragEnter);
			// 
			// iconSaveToDB
			// 
			this.iconSaveToDB.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconSaveToDB.IconColor = System.Drawing.Color.Black;
			this.iconSaveToDB.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconSaveToDB.Location = new System.Drawing.Point(197, 186);
			this.iconSaveToDB.Name = "iconSaveToDB";
			this.iconSaveToDB.Size = new System.Drawing.Size(61, 23);
			this.iconSaveToDB.TabIndex = 4;
			this.iconSaveToDB.Text = "Save";
			this.iconSaveToDB.UseVisualStyleBackColor = true;
			this.iconSaveToDB.Click += new System.EventHandler(this.iconSaveToDB_Click);
			// 
			// iconbtnToLeft
			// 
			this.iconbtnToLeft.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.iconbtnToLeft.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnToLeft.IconColor = System.Drawing.Color.Black;
			this.iconbtnToLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnToLeft.Location = new System.Drawing.Point(197, 145);
			this.iconbtnToLeft.Name = "iconbtnToLeft";
			this.iconbtnToLeft.Size = new System.Drawing.Size(61, 23);
			this.iconbtnToLeft.TabIndex = 3;
			this.iconbtnToLeft.Text = "<<";
			this.iconbtnToLeft.UseVisualStyleBackColor = false;
			this.iconbtnToLeft.Click += new System.EventHandler(this.iconbtnToLeft_Click);
			// 
			// iconbtnToRight
			// 
			this.iconbtnToRight.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.iconbtnToRight.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnToRight.IconColor = System.Drawing.Color.Black;
			this.iconbtnToRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnToRight.Location = new System.Drawing.Point(197, 116);
			this.iconbtnToRight.Name = "iconbtnToRight";
			this.iconbtnToRight.Size = new System.Drawing.Size(61, 23);
			this.iconbtnToRight.TabIndex = 2;
			this.iconbtnToRight.Text = ">>";
			this.iconbtnToRight.UseVisualStyleBackColor = false;
			this.iconbtnToRight.Click += new System.EventHandler(this.iconbtnToRight_Click);
			// 
			// cbgroupProcess
			// 
			this.cbgroupProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbgroupProcess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbgroupProcess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbgroupProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbgroupProcess.FormattingEnabled = true;
			this.cbgroupProcess.Location = new System.Drawing.Point(98, 125);
			this.cbgroupProcess.Name = "cbgroupProcess";
			this.cbgroupProcess.Size = new System.Drawing.Size(171, 21);
			this.cbgroupProcess.TabIndex = 99;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 13);
			this.label7.TabIndex = 98;
			this.label7.Text = "Group:";
			// 
			// frmSetupProcessLine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmSetupProcessLine";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "THIẾT LẬP CÁC CÔNG ĐOẠN CẦN KIỂM TRA";
			this.Load += new System.EventHandler(this.frmSetupProcessLine_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ComboBox cbLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton iconbtnReset;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconbtnToLeft;
        private FontAwesome.Sharp.IconButton iconbtnToRight;
        private FontAwesome.Sharp.IconButton iconSaveToDB;
        private System.Windows.Forms.ListView listViewScanQR;
        private System.Windows.Forms.ListView listViewNonScanQR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton iconbtnScanQRDown;
        private FontAwesome.Sharp.IconButton iconbtnScanQRUp;
        private FontAwesome.Sharp.IconButton iconbtnNonScanQRDown;
        private FontAwesome.Sharp.IconButton iconbtnNonScanQRUp;
		private System.Windows.Forms.ComboBox cbgroupProcess;
		private System.Windows.Forms.Label label7;
	}
}