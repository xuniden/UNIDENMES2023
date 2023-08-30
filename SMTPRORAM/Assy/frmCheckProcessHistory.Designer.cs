namespace SMTPRORAM.Assy
{
    partial class frmCheckProcessHistory
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
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBoxNG = new System.Windows.Forms.PictureBox();
			this.pictureBoxOK = new System.Windows.Forms.PictureBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lblQRCode = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtQRCode = new System.Windows.Forms.TextBox();
			this.lblProcess = new System.Windows.Forms.Label();
			this.checkMTE = new System.Windows.Forms.CheckBox();
			this.checkOSG = new System.Windows.Forms.CheckBox();
			this.checkJIG = new System.Windows.Forms.CheckBox();
			this.checkEQ = new System.Windows.Forms.CheckBox();
			this.cbLot = new System.Windows.Forms.ComboBox();
			this.cbLine = new System.Windows.Forms.ComboBox();
			this.numMetarial = new System.Windows.Forms.NumericUpDown();
			this.numOSG = new System.Windows.Forms.NumericUpDown();
			this.numJIG = new System.Windows.Forms.NumericUpDown();
			this.numEQ = new System.Windows.Forms.NumericUpDown();
			this.lblMetarial = new System.Windows.Forms.Label();
			this.lblOSG = new System.Windows.Forms.Label();
			this.lblJIG = new System.Windows.Forms.Label();
			this.lblEq = new System.Windows.Forms.Label();
			this.lblOperator = new System.Windows.Forms.Label();
			this.lblLot = new System.Windows.Forms.Label();
			this.lblLine = new System.Windows.Forms.Label();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnReset07 = new FontAwesome.Sharp.IconButton();
			this.txtMaterial = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.iconbtnReset06 = new FontAwesome.Sharp.IconButton();
			this.txtOsg = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.iconbtnReset05 = new FontAwesome.Sharp.IconButton();
			this.txtJig = new System.Windows.Forms.TextBox();
			this.iconbtnReset04 = new FontAwesome.Sharp.IconButton();
			this.txtEqName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.iconbtnReset03 = new FontAwesome.Sharp.IconButton();
			this.txtEmployeeID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.iconbtnReset02 = new FontAwesome.Sharp.IconButton();
			this.iconbtnReset01 = new FontAwesome.Sharp.IconButton();
			this.cbProcessName = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMetarial)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numOSG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numJIG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numEQ)).BeginInit();
			this.SuspendLayout();
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(6, 3);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(479, 555);
			this.dgView.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(496, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(488, 561);
			this.panel2.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBoxNG);
			this.panel1.Controls.Add(this.pictureBoxOK);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.lblQRCode);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.txtQRCode);
			this.panel1.Controls.Add(this.lblProcess);
			this.panel1.Controls.Add(this.checkMTE);
			this.panel1.Controls.Add(this.checkOSG);
			this.panel1.Controls.Add(this.checkJIG);
			this.panel1.Controls.Add(this.checkEQ);
			this.panel1.Controls.Add(this.cbLot);
			this.panel1.Controls.Add(this.cbLine);
			this.panel1.Controls.Add(this.numMetarial);
			this.panel1.Controls.Add(this.numOSG);
			this.panel1.Controls.Add(this.numJIG);
			this.panel1.Controls.Add(this.numEQ);
			this.panel1.Controls.Add(this.lblMetarial);
			this.panel1.Controls.Add(this.lblOSG);
			this.panel1.Controls.Add(this.lblJIG);
			this.panel1.Controls.Add(this.lblEq);
			this.panel1.Controls.Add(this.lblOperator);
			this.panel1.Controls.Add(this.lblLot);
			this.panel1.Controls.Add(this.lblLine);
			this.panel1.Controls.Add(this.iconbtnSave);
			this.panel1.Controls.Add(this.iconbtnReset07);
			this.panel1.Controls.Add(this.txtMaterial);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.iconbtnReset06);
			this.panel1.Controls.Add(this.txtOsg);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.iconbtnReset05);
			this.panel1.Controls.Add(this.txtJig);
			this.panel1.Controls.Add(this.iconbtnReset04);
			this.panel1.Controls.Add(this.txtEqName);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.iconbtnReset03);
			this.panel1.Controls.Add(this.txtEmployeeID);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.iconbtnReset02);
			this.panel1.Controls.Add(this.iconbtnReset01);
			this.panel1.Controls.Add(this.cbProcessName);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(496, 561);
			this.panel1.TabIndex = 2;
			// 
			// pictureBoxNG
			// 
			this.pictureBoxNG.Image = global::SMTPRORAM.Properties.Resources.NG_picture;
			this.pictureBoxNG.Location = new System.Drawing.Point(335, 350);
			this.pictureBoxNG.Name = "pictureBoxNG";
			this.pictureBoxNG.Size = new System.Drawing.Size(155, 147);
			this.pictureBoxNG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxNG.TabIndex = 130;
			this.pictureBoxNG.TabStop = false;
			// 
			// pictureBoxOK
			// 
			this.pictureBoxOK.Image = global::SMTPRORAM.Properties.Resources.OK_picture;
			this.pictureBoxOK.Location = new System.Drawing.Point(335, 350);
			this.pictureBoxOK.Name = "pictureBoxOK";
			this.pictureBoxOK.Size = new System.Drawing.Size(155, 147);
			this.pictureBoxOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxOK.TabIndex = 129;
			this.pictureBoxOK.TabStop = false;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(7, 208);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(30, 16);
			this.label9.TabIndex = 11;
			this.label9.Text = "JIG:";
			// 
			// lblQRCode
			// 
			this.lblQRCode.AutoSize = true;
			this.lblQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQRCode.Location = new System.Drawing.Point(374, 315);
			this.lblQRCode.Name = "lblQRCode";
			this.lblQRCode.Size = new System.Drawing.Size(83, 16);
			this.lblQRCode.TabIndex = 128;
			this.lblQRCode.Text = "lblQRCode";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(7, 315);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 16);
			this.label6.TabIndex = 20;
			this.label6.Text = "QR CODE:";
			// 
			// txtQRCode
			// 
			this.txtQRCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQRCode.Location = new System.Drawing.Point(135, 312);
			this.txtQRCode.Name = "txtQRCode";
			this.txtQRCode.Size = new System.Drawing.Size(233, 22);
			this.txtQRCode.TabIndex = 21;
			this.txtQRCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQRCode_KeyDown);
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProcess.Location = new System.Drawing.Point(374, 102);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(81, 16);
			this.lblProcess.TabIndex = 125;
			this.lblProcess.Text = "lblProcess";
			// 
			// checkMTE
			// 
			this.checkMTE.AutoSize = true;
			this.checkMTE.Location = new System.Drawing.Point(64, 279);
			this.checkMTE.Name = "checkMTE";
			this.checkMTE.Size = new System.Drawing.Size(15, 14);
			this.checkMTE.TabIndex = 84;
			this.checkMTE.UseVisualStyleBackColor = true;
			this.checkMTE.CheckedChanged += new System.EventHandler(this.checkMTE_CheckedChanged);
			// 
			// checkOSG
			// 
			this.checkOSG.AutoSize = true;
			this.checkOSG.Location = new System.Drawing.Point(64, 244);
			this.checkOSG.Name = "checkOSG";
			this.checkOSG.Size = new System.Drawing.Size(15, 14);
			this.checkOSG.TabIndex = 83;
			this.checkOSG.UseVisualStyleBackColor = true;
			this.checkOSG.CheckedChanged += new System.EventHandler(this.checkOSG_CheckedChanged);
			// 
			// checkJIG
			// 
			this.checkJIG.AutoSize = true;
			this.checkJIG.Location = new System.Drawing.Point(64, 209);
			this.checkJIG.Name = "checkJIG";
			this.checkJIG.Size = new System.Drawing.Size(15, 14);
			this.checkJIG.TabIndex = 82;
			this.checkJIG.UseVisualStyleBackColor = true;
			this.checkJIG.CheckedChanged += new System.EventHandler(this.checkJIG_CheckedChanged);
			// 
			// checkEQ
			// 
			this.checkEQ.AutoSize = true;
			this.checkEQ.Location = new System.Drawing.Point(64, 175);
			this.checkEQ.Name = "checkEQ";
			this.checkEQ.Size = new System.Drawing.Size(15, 14);
			this.checkEQ.TabIndex = 81;
			this.checkEQ.UseVisualStyleBackColor = true;
			this.checkEQ.CheckedChanged += new System.EventHandler(this.checkEQ_CheckedChanged);
			// 
			// cbLot
			// 
			this.cbLot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLot.FormattingEnabled = true;
			this.cbLot.Location = new System.Drawing.Point(121, 64);
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
			this.cbLine.Location = new System.Drawing.Point(121, 28);
			this.cbLine.Name = "cbLine";
			this.cbLine.Size = new System.Drawing.Size(247, 21);
			this.cbLine.TabIndex = 1;
			this.cbLine.SelectionChangeCommitted += new System.EventHandler(this.cbLine_SelectionChangeCommitted);
			// 
			// numMetarial
			// 
			this.numMetarial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numMetarial.Location = new System.Drawing.Point(82, 275);
			this.numMetarial.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.numMetarial.Name = "numMetarial";
			this.numMetarial.Size = new System.Drawing.Size(47, 22);
			this.numMetarial.TabIndex = 18;
			this.numMetarial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numMetarial_KeyDown);
			// 
			// numOSG
			// 
			this.numOSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numOSG.Location = new System.Drawing.Point(82, 240);
			this.numOSG.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.numOSG.Name = "numOSG";
			this.numOSG.Size = new System.Drawing.Size(47, 22);
			this.numOSG.TabIndex = 15;
			this.numOSG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numOSG_KeyDown);
			// 
			// numJIG
			// 
			this.numJIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numJIG.Location = new System.Drawing.Point(82, 204);
			this.numJIG.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.numJIG.Name = "numJIG";
			this.numJIG.Size = new System.Drawing.Size(47, 22);
			this.numJIG.TabIndex = 12;
			this.numJIG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numJIG_KeyDown);
			// 
			// numEQ
			// 
			this.numEQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numEQ.Location = new System.Drawing.Point(82, 171);
			this.numEQ.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.numEQ.Name = "numEQ";
			this.numEQ.Size = new System.Drawing.Size(47, 22);
			this.numEQ.TabIndex = 9;
			this.numEQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numEQ_KeyDown);
			// 
			// lblMetarial
			// 
			this.lblMetarial.AutoSize = true;
			this.lblMetarial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetarial.Location = new System.Drawing.Point(374, 280);
			this.lblMetarial.Name = "lblMetarial";
			this.lblMetarial.Size = new System.Drawing.Size(80, 16);
			this.lblMetarial.TabIndex = 120;
			this.lblMetarial.Text = "lblMetarial";
			// 
			// lblOSG
			// 
			this.lblOSG.AutoSize = true;
			this.lblOSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOSG.Location = new System.Drawing.Point(374, 244);
			this.lblOSG.Name = "lblOSG";
			this.lblOSG.Size = new System.Drawing.Size(56, 16);
			this.lblOSG.TabIndex = 119;
			this.lblOSG.Text = "lblOSG";
			// 
			// lblJIG
			// 
			this.lblJIG.AutoSize = true;
			this.lblJIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblJIG.Location = new System.Drawing.Point(374, 209);
			this.lblJIG.Name = "lblJIG";
			this.lblJIG.Size = new System.Drawing.Size(47, 16);
			this.lblJIG.TabIndex = 118;
			this.lblJIG.Text = "lblJIG";
			// 
			// lblEq
			// 
			this.lblEq.AutoSize = true;
			this.lblEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEq.Location = new System.Drawing.Point(374, 173);
			this.lblEq.Name = "lblEq";
			this.lblEq.Size = new System.Drawing.Size(43, 16);
			this.lblEq.TabIndex = 117;
			this.lblEq.Text = "lblEq";
			// 
			// lblOperator
			// 
			this.lblOperator.AutoSize = true;
			this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOperator.Location = new System.Drawing.Point(374, 140);
			this.lblOperator.Name = "lblOperator";
			this.lblOperator.Size = new System.Drawing.Size(85, 16);
			this.lblOperator.TabIndex = 116;
			this.lblOperator.Text = "lblOperator";
			// 
			// lblLot
			// 
			this.lblLot.AutoSize = true;
			this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLot.Location = new System.Drawing.Point(374, 65);
			this.lblLot.Name = "lblLot";
			this.lblLot.Size = new System.Drawing.Size(45, 16);
			this.lblLot.TabIndex = 115;
			this.lblLot.Text = "lblLot";
			// 
			// lblLine
			// 
			this.lblLine.AutoSize = true;
			this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLine.Location = new System.Drawing.Point(374, 31);
			this.lblLine.Name = "lblLine";
			this.lblLine.Size = new System.Drawing.Size(53, 16);
			this.lblLine.TabIndex = 114;
			this.lblLine.Text = "lblLine";
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.Location = new System.Drawing.Point(121, 421);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(130, 35);
			this.iconbtnSave.TabIndex = 26;
			this.iconbtnSave.Text = "Lưu thông tin";
			this.iconbtnSave.UseVisualStyleBackColor = true;
			// 
			// iconbtnReset07
			// 
			this.iconbtnReset07.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset07.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset07.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset07.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset07.Location = new System.Drawing.Point(423, 273);
			this.iconbtnReset07.Name = "iconbtnReset07";
			this.iconbtnReset07.Size = new System.Drawing.Size(67, 30);
			this.iconbtnReset07.TabIndex = 113;
			this.iconbtnReset07.Text = "Làm lại";
			this.iconbtnReset07.UseVisualStyleBackColor = true;
			this.iconbtnReset07.Click += new System.EventHandler(this.iconbtnReset07_Click);
			// 
			// txtMaterial
			// 
			this.txtMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaterial.Location = new System.Drawing.Point(135, 275);
			this.txtMaterial.Name = "txtMaterial";
			this.txtMaterial.Size = new System.Drawing.Size(233, 22);
			this.txtMaterial.TabIndex = 19;
			this.txtMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaterial_KeyDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(7, 278);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(51, 16);
			this.label8.TabIndex = 17;
			this.label8.Text = "Vật liệu";
			// 
			// iconbtnReset06
			// 
			this.iconbtnReset06.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset06.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset06.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset06.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset06.Location = new System.Drawing.Point(423, 238);
			this.iconbtnReset06.Name = "iconbtnReset06";
			this.iconbtnReset06.Size = new System.Drawing.Size(67, 29);
			this.iconbtnReset06.TabIndex = 112;
			this.iconbtnReset06.Text = "Làm lại";
			this.iconbtnReset06.UseVisualStyleBackColor = true;
			this.iconbtnReset06.Click += new System.EventHandler(this.iconbtnReset06_Click);
			// 
			// txtOsg
			// 
			this.txtOsg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtOsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOsg.Location = new System.Drawing.Point(135, 240);
			this.txtOsg.Name = "txtOsg";
			this.txtOsg.Size = new System.Drawing.Size(233, 22);
			this.txtOsg.TabIndex = 16;
			this.txtOsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOsg_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(7, 243);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 16);
			this.label7.TabIndex = 14;
			this.label7.Text = "OSG";
			// 
			// iconbtnReset05
			// 
			this.iconbtnReset05.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset05.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset05.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset05.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset05.Location = new System.Drawing.Point(423, 203);
			this.iconbtnReset05.Name = "iconbtnReset05";
			this.iconbtnReset05.Size = new System.Drawing.Size(67, 29);
			this.iconbtnReset05.TabIndex = 111;
			this.iconbtnReset05.Text = "Làm lại";
			this.iconbtnReset05.UseVisualStyleBackColor = true;
			this.iconbtnReset05.Click += new System.EventHandler(this.iconbtnReset05_Click);
			// 
			// txtJig
			// 
			this.txtJig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtJig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtJig.Location = new System.Drawing.Point(135, 205);
			this.txtJig.Name = "txtJig";
			this.txtJig.Size = new System.Drawing.Size(233, 22);
			this.txtJig.TabIndex = 13;
			this.txtJig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJig_KeyDown);
			// 
			// iconbtnReset04
			// 
			this.iconbtnReset04.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset04.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset04.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset04.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset04.Location = new System.Drawing.Point(423, 168);
			this.iconbtnReset04.Name = "iconbtnReset04";
			this.iconbtnReset04.Size = new System.Drawing.Size(67, 28);
			this.iconbtnReset04.TabIndex = 110;
			this.iconbtnReset04.Text = "Làm lại";
			this.iconbtnReset04.UseVisualStyleBackColor = true;
			this.iconbtnReset04.Click += new System.EventHandler(this.iconbtnReset04_Click);
			// 
			// txtEqName
			// 
			this.txtEqName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEqName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEqName.Location = new System.Drawing.Point(135, 170);
			this.txtEqName.Name = "txtEqName";
			this.txtEqName.Size = new System.Drawing.Size(233, 22);
			this.txtEqName.TabIndex = 10;
			this.txtEqName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEqName_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(7, 173);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Thiết bị";
			// 
			// iconbtnReset03
			// 
			this.iconbtnReset03.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconbtnReset03.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReset03.IconColor = System.Drawing.Color.Black;
			this.iconbtnReset03.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReset03.Location = new System.Drawing.Point(423, 134);
			this.iconbtnReset03.Name = "iconbtnReset03";
			this.iconbtnReset03.Size = new System.Drawing.Size(67, 28);
			this.iconbtnReset03.TabIndex = 109;
			this.iconbtnReset03.Text = "Làm lại";
			this.iconbtnReset03.UseVisualStyleBackColor = true;
			this.iconbtnReset03.Click += new System.EventHandler(this.iconbtnReset03_Click);
			// 
			// txtEmployeeID
			// 
			this.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmployeeID.Location = new System.Drawing.Point(121, 136);
			this.txtEmployeeID.Name = "txtEmployeeID";
			this.txtEmployeeID.Size = new System.Drawing.Size(247, 22);
			this.txtEmployeeID.TabIndex = 7;
			this.txtEmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeID_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(7, 139);
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
			this.iconbtnReset02.Location = new System.Drawing.Point(423, 60);
			this.iconbtnReset02.Name = "iconbtnReset02";
			this.iconbtnReset02.Size = new System.Drawing.Size(67, 28);
			this.iconbtnReset02.TabIndex = 108;
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
			this.iconbtnReset01.Location = new System.Drawing.Point(423, 24);
			this.iconbtnReset01.Name = "iconbtnReset01";
			this.iconbtnReset01.Size = new System.Drawing.Size(67, 28);
			this.iconbtnReset01.TabIndex = 107;
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
			this.cbProcessName.Location = new System.Drawing.Point(121, 99);
			this.cbProcessName.Name = "cbProcessName";
			this.cbProcessName.Size = new System.Drawing.Size(247, 24);
			this.cbProcessName.TabIndex = 5;
			this.cbProcessName.SelectionChangeCommitted += new System.EventHandler(this.cbProcessName_SelectionChangeCommitted);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(7, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Công đoạn: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(7, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tên LOT:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên chuyền:";
			// 
			// frmCheckProcessHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmCheckProcessHistory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LỊCH SỬ CÔNG ĐOẠN SỬ DỤNG QR CODE";
			this.Load += new System.EventHandler(this.frmCheckProcessHistory_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxNG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMetarial)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numOSG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numJIG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numEQ)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.CheckBox checkMTE;
        private System.Windows.Forms.CheckBox checkOSG;
        private System.Windows.Forms.CheckBox checkJIG;
        private System.Windows.Forms.CheckBox checkEQ;
        private System.Windows.Forms.ComboBox cbLot;
        private System.Windows.Forms.ComboBox cbLine;
        private System.Windows.Forms.NumericUpDown numMetarial;
        private System.Windows.Forms.NumericUpDown numOSG;
        private System.Windows.Forms.NumericUpDown numJIG;
        private System.Windows.Forms.NumericUpDown numEQ;
        private System.Windows.Forms.Label lblMetarial;
        private System.Windows.Forms.Label lblOSG;
        private System.Windows.Forms.Label lblJIG;
        private System.Windows.Forms.Label lblEq;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.Label lblLine;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnReset07;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton iconbtnReset06;
        private System.Windows.Forms.TextBox txtOsg;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton iconbtnReset05;
        private System.Windows.Forms.TextBox txtJig;
        private FontAwesome.Sharp.IconButton iconbtnReset04;
        private System.Windows.Forms.TextBox txtEqName;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton iconbtnReset03;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton iconbtnReset02;
        private FontAwesome.Sharp.IconButton iconbtnReset01;
        private System.Windows.Forms.ComboBox cbProcessName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQRCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBoxNG;
        private System.Windows.Forms.PictureBox pictureBoxOK;
	}
}