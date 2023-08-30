namespace SMTPRORAM.Smt.Input
{
	partial class frmIPQCConfirm
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtLine = new System.Windows.Forms.TextBox();
			this.txtprogram = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtPcbSheet = new System.Windows.Forms.TextBox();
			this.chkPanasonic = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtFeeder = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtcheckPartcode = new System.Windows.Forms.TextBox();
			this.txtcheckQty = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtcheckDatecode = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtusage = new System.Windows.Forms.TextBox();
			this.txtpart2 = new System.Windows.Forms.TextBox();
			this.txtpart1 = new System.Windows.Forms.TextBox();
			this.txtTempQty = new System.Windows.Forms.TextBox();
			this.txtdatec = new System.Windows.Forms.TextBox();
			this.txtqty = new System.Windows.Forms.TextBox();
			this.lbl_01 = new System.Windows.Forms.Label();
			this.lbl_02 = new System.Windows.Forms.Label();
			this.lbl_03 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.lbl_04 = new System.Windows.Forms.Label();
			this.txtcheckDesc = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtIDMaterialNew = new System.Windows.Forms.TextBox();
			this.txtIDMaterialOld = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtIDMaterialCurr = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line Name:";
			// 
			// txtLine
			// 
			this.txtLine.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.txtLine.Enabled = false;
			this.txtLine.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtLine.Location = new System.Drawing.Point(140, 20);
			this.txtLine.Name = "txtLine";
			this.txtLine.Size = new System.Drawing.Size(313, 20);
			this.txtLine.TabIndex = 1;
			// 
			// txtprogram
			// 
			this.txtprogram.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.txtprogram.Enabled = false;
			this.txtprogram.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtprogram.Location = new System.Drawing.Point(140, 49);
			this.txtprogram.Name = "txtprogram";
			this.txtprogram.Size = new System.Drawing.Size(313, 20);
			this.txtprogram.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Program:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.Red;
			this.label12.Location = new System.Drawing.Point(20, 161);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(108, 13);
			this.label12.TabIndex = 8;
			this.label12.Text = "Số PCB / 1 Sheet";
			// 
			// txtPcbSheet
			// 
			this.txtPcbSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPcbSheet.ForeColor = System.Drawing.Color.Red;
			this.txtPcbSheet.Location = new System.Drawing.Point(252, 157);
			this.txtPcbSheet.Name = "txtPcbSheet";
			this.txtPcbSheet.Size = new System.Drawing.Size(100, 20);
			this.txtPcbSheet.TabIndex = 9;
			this.txtPcbSheet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPcbSheet_KeyDown);
			this.txtPcbSheet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPcbSheet_KeyPress);
			// 
			// chkPanasonic
			// 
			this.chkPanasonic.AutoSize = true;
			this.chkPanasonic.Location = new System.Drawing.Point(253, 123);
			this.chkPanasonic.Name = "chkPanasonic";
			this.chkPanasonic.Size = new System.Drawing.Size(99, 17);
			this.chkPanasonic.TabIndex = 7;
			this.chkPanasonic.Text = "Line Panasonic";
			this.chkPanasonic.UseVisualStyleBackColor = true;
			this.chkPanasonic.Click += new System.EventHandler(this.chkPanasonic_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Red;
			this.label11.Location = new System.Drawing.Point(20, 125);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(205, 13);
			this.label11.TabIndex = 6;
			this.label11.Text = "Phần chỉ dành cho line Panasonic:";
			// 
			// txtFeeder
			// 
			this.txtFeeder.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.txtFeeder.Enabled = false;
			this.txtFeeder.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFeeder.Location = new System.Drawing.Point(140, 78);
			this.txtFeeder.Name = "txtFeeder";
			this.txtFeeder.Size = new System.Drawing.Size(313, 20);
			this.txtFeeder.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Feeder:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 204);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Partcode:";
			// 
			// txtcheckPartcode
			// 
			this.txtcheckPartcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtcheckPartcode.Location = new System.Drawing.Point(157, 200);
			this.txtcheckPartcode.Name = "txtcheckPartcode";
			this.txtcheckPartcode.Size = new System.Drawing.Size(165, 20);
			this.txtcheckPartcode.TabIndex = 11;
			this.txtcheckPartcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcheckPartcode_KeyDown);
			// 
			// txtcheckQty
			// 
			this.txtcheckQty.Location = new System.Drawing.Point(157, 231);
			this.txtcheckQty.Name = "txtcheckQty";
			this.txtcheckQty.Size = new System.Drawing.Size(165, 20);
			this.txtcheckQty.TabIndex = 13;
			this.txtcheckQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcheckQty_KeyDown);
			this.txtcheckQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcheckQty_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 235);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(26, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Qty:";
			// 
			// txtcheckDatecode
			// 
			this.txtcheckDatecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtcheckDatecode.Location = new System.Drawing.Point(157, 262);
			this.txtcheckDatecode.Name = "txtcheckDatecode";
			this.txtcheckDatecode.Size = new System.Drawing.Size(165, 20);
			this.txtcheckDatecode.TabIndex = 15;
			this.txtcheckDatecode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcheckDatecode_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 266);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "DateCode";
			// 
			// txtusage
			// 
			this.txtusage.Enabled = false;
			this.txtusage.Location = new System.Drawing.Point(327, 427);
			this.txtusage.Name = "txtusage";
			this.txtusage.Size = new System.Drawing.Size(140, 20);
			this.txtusage.TabIndex = 18;
			// 
			// txtpart2
			// 
			this.txtpart2.Enabled = false;
			this.txtpart2.Location = new System.Drawing.Point(327, 402);
			this.txtpart2.Name = "txtpart2";
			this.txtpart2.Size = new System.Drawing.Size(140, 20);
			this.txtpart2.TabIndex = 17;
			// 
			// txtpart1
			// 
			this.txtpart1.Enabled = false;
			this.txtpart1.Location = new System.Drawing.Point(327, 377);
			this.txtpart1.Name = "txtpart1";
			this.txtpart1.Size = new System.Drawing.Size(140, 20);
			this.txtpart1.TabIndex = 16;
			// 
			// txtTempQty
			// 
			this.txtTempQty.Enabled = false;
			this.txtTempQty.Location = new System.Drawing.Point(327, 352);
			this.txtTempQty.Name = "txtTempQty";
			this.txtTempQty.Size = new System.Drawing.Size(140, 20);
			this.txtTempQty.TabIndex = 21;
			// 
			// txtdatec
			// 
			this.txtdatec.Enabled = false;
			this.txtdatec.Location = new System.Drawing.Point(327, 477);
			this.txtdatec.Name = "txtdatec";
			this.txtdatec.Size = new System.Drawing.Size(140, 20);
			this.txtdatec.TabIndex = 20;
			// 
			// txtqty
			// 
			this.txtqty.Enabled = false;
			this.txtqty.Location = new System.Drawing.Point(327, 452);
			this.txtqty.Name = "txtqty";
			this.txtqty.Size = new System.Drawing.Size(140, 20);
			this.txtqty.TabIndex = 19;
			// 
			// lbl_01
			// 
			this.lbl_01.AutoSize = true;
			this.lbl_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_01.Location = new System.Drawing.Point(328, 202);
			this.lbl_01.Name = "lbl_01";
			this.lbl_01.Size = new System.Drawing.Size(27, 16);
			this.lbl_01.TabIndex = 182;
			this.lbl_01.Text = "OK";
			// 
			// lbl_02
			// 
			this.lbl_02.AutoSize = true;
			this.lbl_02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_02.Location = new System.Drawing.Point(328, 233);
			this.lbl_02.Name = "lbl_02";
			this.lbl_02.Size = new System.Drawing.Size(27, 16);
			this.lbl_02.TabIndex = 183;
			this.lbl_02.Text = "OK";
			// 
			// lbl_03
			// 
			this.lbl_03.AutoSize = true;
			this.lbl_03.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_03.Location = new System.Drawing.Point(328, 264);
			this.lbl_03.Name = "lbl_03";
			this.lbl_03.Size = new System.Drawing.Size(27, 16);
			this.lbl_03.TabIndex = 184;
			this.lbl_03.Text = "OK";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Enabled = false;
			this.label7.Location = new System.Drawing.Point(245, 381);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(62, 13);
			this.label7.TabIndex = 185;
			this.label7.Text = "Partcode 1:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Enabled = false;
			this.label8.Location = new System.Drawing.Point(245, 406);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(62, 13);
			this.label8.TabIndex = 186;
			this.label8.Text = "Partcode 2:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Enabled = false;
			this.label9.Location = new System.Drawing.Point(245, 431);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 13);
			this.label9.TabIndex = 187;
			this.label9.Text = "Usage:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Enabled = false;
			this.label10.Location = new System.Drawing.Point(245, 456);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(26, 13);
			this.label10.TabIndex = 188;
			this.label10.Text = "Qty:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Enabled = false;
			this.label13.Location = new System.Drawing.Point(245, 481);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(61, 13);
			this.label13.TabIndex = 189;
			this.label13.Text = "Date Code:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Enabled = false;
			this.label14.Location = new System.Drawing.Point(245, 356);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(50, 13);
			this.label14.TabIndex = 190;
			this.label14.Text = "Tmp Qty:";
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.Location = new System.Drawing.Point(157, 320);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(165, 23);
			this.iconbtnSave.TabIndex = 191;
			this.iconbtnSave.Text = "Save";
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// lbl_04
			// 
			this.lbl_04.AutoSize = true;
			this.lbl_04.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_04.Location = new System.Drawing.Point(328, 296);
			this.lbl_04.Name = "lbl_04";
			this.lbl_04.Size = new System.Drawing.Size(27, 16);
			this.lbl_04.TabIndex = 194;
			this.lbl_04.Text = "OK";
			// 
			// txtcheckDesc
			// 
			this.txtcheckDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtcheckDesc.Location = new System.Drawing.Point(157, 294);
			this.txtcheckDesc.Name = "txtcheckDesc";
			this.txtcheckDesc.Size = new System.Drawing.Size(165, 20);
			this.txtcheckDesc.TabIndex = 17;
			this.txtcheckDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcheckDesc_KeyDown);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(20, 298);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 13);
			this.label16.TabIndex = 16;
			this.label16.Text = "Desc";
			// 
			// txtIDMaterialNew
			// 
			this.txtIDMaterialNew.Enabled = false;
			this.txtIDMaterialNew.Location = new System.Drawing.Point(12, 475);
			this.txtIDMaterialNew.Name = "txtIDMaterialNew";
			this.txtIDMaterialNew.Size = new System.Drawing.Size(213, 20);
			this.txtIDMaterialNew.TabIndex = 195;
			// 
			// txtIDMaterialOld
			// 
			this.txtIDMaterialOld.Enabled = false;
			this.txtIDMaterialOld.Location = new System.Drawing.Point(12, 422);
			this.txtIDMaterialOld.Name = "txtIDMaterialOld";
			this.txtIDMaterialOld.Size = new System.Drawing.Size(213, 20);
			this.txtIDMaterialOld.TabIndex = 196;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Enabled = false;
			this.label15.Location = new System.Drawing.Point(12, 400);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(78, 13);
			this.label15.TabIndex = 197;
			this.label15.Text = "ID linh kiện cũ:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Enabled = false;
			this.label17.Location = new System.Drawing.Point(12, 459);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(82, 13);
			this.label17.TabIndex = 197;
			this.label17.Text = "ID linh kiện mới:";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Enabled = false;
			this.label18.Location = new System.Drawing.Point(12, 347);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 13);
			this.label18.TabIndex = 199;
			this.label18.Text = "ID linh kiện hiện tại:";
			// 
			// txtIDMaterialCurr
			// 
			this.txtIDMaterialCurr.Enabled = false;
			this.txtIDMaterialCurr.Location = new System.Drawing.Point(12, 369);
			this.txtIDMaterialCurr.Name = "txtIDMaterialCurr";
			this.txtIDMaterialCurr.Size = new System.Drawing.Size(213, 20);
			this.txtIDMaterialCurr.TabIndex = 198;
			// 
			// frmIPQCConfirm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 507);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.txtIDMaterialCurr);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.txtIDMaterialOld);
			this.Controls.Add(this.txtIDMaterialNew);
			this.Controls.Add(this.lbl_04);
			this.Controls.Add(this.txtcheckDesc);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.iconbtnSave);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lbl_03);
			this.Controls.Add(this.lbl_02);
			this.Controls.Add(this.lbl_01);
			this.Controls.Add(this.txtTempQty);
			this.Controls.Add(this.txtdatec);
			this.Controls.Add(this.txtqty);
			this.Controls.Add(this.txtusage);
			this.Controls.Add(this.txtpart2);
			this.Controls.Add(this.txtpart1);
			this.Controls.Add(this.txtcheckDatecode);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtcheckQty);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtcheckPartcode);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtFeeder);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtPcbSheet);
			this.Controls.Add(this.chkPanasonic);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txtprogram);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtLine);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmIPQCConfirm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IPQC KIỂM TRA LẠI";
			this.Load += new System.EventHandler(this.frmIPQCConfirm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtLine;
		private System.Windows.Forms.TextBox txtprogram;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtPcbSheet;
		private System.Windows.Forms.CheckBox chkPanasonic;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtFeeder;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtcheckPartcode;
		private System.Windows.Forms.TextBox txtcheckQty;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtcheckDatecode;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtusage;
		private System.Windows.Forms.TextBox txtpart2;
		private System.Windows.Forms.TextBox txtpart1;
		private System.Windows.Forms.TextBox txtTempQty;
		private System.Windows.Forms.TextBox txtdatec;
		private System.Windows.Forms.TextBox txtqty;
		private System.Windows.Forms.Label lbl_01;
		private System.Windows.Forms.Label lbl_02;
		private System.Windows.Forms.Label lbl_03;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private System.Windows.Forms.Label lbl_04;
		private System.Windows.Forms.TextBox txtcheckDesc;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtIDMaterialNew;
		private System.Windows.Forms.TextBox txtIDMaterialOld;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtIDMaterialCurr;
	}
}