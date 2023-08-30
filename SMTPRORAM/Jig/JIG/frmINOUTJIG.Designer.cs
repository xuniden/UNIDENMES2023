namespace SMTPRORAM.Jig.JIG
{
    partial class frmINOUTJIG
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
			this.cbFixLocation = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.chkKeep = new System.Windows.Forms.CheckBox();
			this.txtApprove = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnExportCsv = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.cbToLoc = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbToSec = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPIC = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbFromLoc = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbFromSec = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtControlNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbFixLocation);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.chkKeep);
			this.panel1.Controls.Add(this.txtApprove);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Controls.Add(this.cbToLoc);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.cbToSec);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.txtRemark);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtPIC);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.cbFromLoc);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbFromSec);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtControlNo);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(381, 561);
			this.panel1.TabIndex = 0;
			// 
			// cbFixLocation
			// 
			this.cbFixLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFixLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFixLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFixLocation.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.cbFixLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFixLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbFixLocation.FormattingEnabled = true;
			this.cbFixLocation.Location = new System.Drawing.Point(181, 349);
			this.cbFixLocation.Name = "cbFixLocation";
			this.cbFixLocation.Size = new System.Drawing.Size(193, 26);
			this.cbFixLocation.TabIndex = 12023;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(9, 353);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(109, 18);
			this.label9.TabIndex = 12024;
			this.label9.Text = "FIX LOCATION";
			// 
			// chkKeep
			// 
			this.chkKeep.AutoSize = true;
			this.chkKeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkKeep.Location = new System.Drawing.Point(106, 167);
			this.chkKeep.Name = "chkKeep";
			this.chkKeep.Size = new System.Drawing.Size(269, 21);
			this.chkKeep.TabIndex = 12022;
			this.chkKeep.Text = "Giữ lại PIC và APP khi xuất nhập nhiều";
			this.chkKeep.UseVisualStyleBackColor = true;
			// 
			// txtApprove
			// 
			this.txtApprove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtApprove.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtApprove.Location = new System.Drawing.Point(181, 227);
			this.txtApprove.Name = "txtApprove";
			this.txtApprove.Size = new System.Drawing.Size(193, 23);
			this.txtApprove.TabIndex = 12009;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label8.Location = new System.Drawing.Point(9, 230);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(78, 17);
			this.label8.TabIndex = 12021;
			this.label8.Text = "APPROVE:";
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 399);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 64);
			this.tableLayoutPanel1.TabIndex = 12020;
			// 
			// iconbtnExportCsv
			// 
			this.iconbtnExportCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.iconbtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExportCsv.IconColor = System.Drawing.Color.Black;
			this.iconbtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExportCsv.IconSize = 16;
			this.iconbtnExportCsv.Location = new System.Drawing.Point(243, 35);
			this.iconbtnExportCsv.Name = "iconbtnExportCsv";
			this.iconbtnExportCsv.Size = new System.Drawing.Size(113, 26);
			this.iconbtnExportCsv.TabIndex = 13;
			this.iconbtnExportCsv.Text = "Export";
			this.iconbtnExportCsv.UseVisualStyleBackColor = true;
			// 
			// iconbtnAdd
			// 
			this.iconbtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.iconbtnAdd.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnAdd.IconColor = System.Drawing.Color.Black;
			this.iconbtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnAdd.IconSize = 16;
			this.iconbtnAdd.Location = new System.Drawing.Point(3, 3);
			this.iconbtnAdd.Name = "iconbtnAdd";
			this.iconbtnAdd.Size = new System.Drawing.Size(113, 26);
			this.iconbtnAdd.TabIndex = 10;
			this.iconbtnAdd.Text = "Thêm";
			this.iconbtnAdd.UseVisualStyleBackColor = true;
			// 
			// iconbtnEdit
			// 
			this.iconbtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
			this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnEdit.IconSize = 16;
			this.iconbtnEdit.Location = new System.Drawing.Point(123, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(113, 26);
			this.iconbtnEdit.TabIndex = 11;
			this.iconbtnEdit.Text = "Sửa";
			this.iconbtnEdit.UseVisualStyleBackColor = true;
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.IconSize = 16;
			this.iconbtnDelete.Location = new System.Drawing.Point(243, 3);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(113, 26);
			this.iconbtnDelete.TabIndex = 12;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 16;
			this.iconbtnSave.Location = new System.Drawing.Point(3, 35);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(113, 26);
			this.iconbtnSave.TabIndex = 8;
			this.iconbtnSave.Text = "Ghi lại";
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// iconbtnCancel
			// 
			this.iconbtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
			this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnCancel.IconSize = 16;
			this.iconbtnCancel.Location = new System.Drawing.Point(123, 35);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(113, 26);
			this.iconbtnCancel.TabIndex = 9;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			// 
			// cbToLoc
			// 
			this.cbToLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbToLoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbToLoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbToLoc.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.cbToLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbToLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbToLoc.FormattingEnabled = true;
			this.cbToLoc.Location = new System.Drawing.Point(181, 317);
			this.cbToLoc.Name = "cbToLoc";
			this.cbToLoc.Size = new System.Drawing.Size(193, 26);
			this.cbToLoc.TabIndex = 12012;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(9, 321);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(111, 18);
			this.label6.TabIndex = 12019;
			this.label6.Text = "TỚI LOCATION";
			// 
			// cbToSec
			// 
			this.cbToSec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbToSec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbToSec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbToSec.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.cbToSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbToSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbToSec.FormattingEnabled = true;
			this.cbToSec.Location = new System.Drawing.Point(181, 285);
			this.cbToSec.Name = "cbToSec";
			this.cbToSec.Size = new System.Drawing.Size(193, 26);
			this.cbToSec.TabIndex = 12011;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(9, 289);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(106, 18);
			this.label7.TabIndex = 12018;
			this.label7.Text = "TỚI SECTION:";
			// 
			// txtRemark
			// 
			this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtRemark.Location = new System.Drawing.Point(181, 256);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(193, 23);
			this.txtRemark.TabIndex = 12010;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.Location = new System.Drawing.Point(9, 259);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 17);
			this.label5.TabIndex = 12017;
			this.label5.Text = "REMARK:";
			// 
			// txtPIC
			// 
			this.txtPIC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtPIC.Location = new System.Drawing.Point(181, 198);
			this.txtPIC.Name = "txtPIC";
			this.txtPIC.Size = new System.Drawing.Size(193, 23);
			this.txtPIC.TabIndex = 12008;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(9, 201);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 17);
			this.label4.TabIndex = 12016;
			this.label4.Text = "PIC:";
			// 
			// cbFromLoc
			// 
			this.cbFromLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFromLoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFromLoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFromLoc.BackColor = System.Drawing.Color.Bisque;
			this.cbFromLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbFromLoc.FormattingEnabled = true;
			this.cbFromLoc.Location = new System.Drawing.Point(182, 127);
			this.cbFromLoc.Name = "cbFromLoc";
			this.cbFromLoc.Size = new System.Drawing.Size(193, 26);
			this.cbFromLoc.TabIndex = 12007;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(9, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 18);
			this.label3.TabIndex = 12015;
			this.label3.Text = "TỪ LOCATION";
			// 
			// cbFromSec
			// 
			this.cbFromSec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFromSec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFromSec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFromSec.BackColor = System.Drawing.Color.LightSalmon;
			this.cbFromSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFromSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbFromSec.FormattingEnabled = true;
			this.cbFromSec.Location = new System.Drawing.Point(182, 95);
			this.cbFromSec.Name = "cbFromSec";
			this.cbFromSec.Size = new System.Drawing.Size(193, 26);
			this.cbFromSec.TabIndex = 12006;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 99);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 18);
			this.label2.TabIndex = 12014;
			this.label2.Text = "TỪ SECTION:";
			// 
			// txtControlNo
			// 
			this.txtControlNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtControlNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.txtControlNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtControlNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtControlNo.Location = new System.Drawing.Point(12, 50);
			this.txtControlNo.Name = "txtControlNo";
			this.txtControlNo.Size = new System.Drawing.Size(363, 32);
			this.txtControlNo.TabIndex = 12005;
			this.txtControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtControlNo_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(13, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(211, 26);
			this.label1.TabIndex = 12013;
			this.label1.Text = "JIG CONTROL NO";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(381, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(603, 561);
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
			this.dgView.Size = new System.Drawing.Size(585, 537);
			this.dgView.TabIndex = 0;
			// 
			// frmINOUTJIG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmINOUTJIG";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XUẤT NHẬP JIG";
			this.Load += new System.EventHandler(this.frmINOUTJIG_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkKeep;
        private System.Windows.Forms.TextBox txtApprove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton iconbtnExportCsv;
        private FontAwesome.Sharp.IconButton iconbtnAdd;
        private FontAwesome.Sharp.IconButton iconbtnEdit;
        private FontAwesome.Sharp.IconButton iconbtnDelete;
        private FontAwesome.Sharp.IconButton iconbtnSave;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private System.Windows.Forms.ComboBox cbToLoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbToSec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPIC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFromLoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFromSec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.ComboBox cbFixLocation;
		private System.Windows.Forms.Label label9;
	}
}