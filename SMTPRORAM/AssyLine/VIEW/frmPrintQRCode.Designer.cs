namespace SMTPRORAM.AssyLine.VIEW
{
	partial class frmPrintQRCode
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
			this.button2 = new System.Windows.Forms.Button();
			this.txtpath = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtSC = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtUT = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtBoxNo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtQT = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtED = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPD = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtLN = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPN = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btView = new System.Windows.Forms.Button();
			this.btnCreateQRCode = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(286, 11);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(67, 23);
			this.button2.TabIndex = 31;
			this.button2.Text = "Browser";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtpath
			// 
			this.txtpath.Location = new System.Drawing.Point(12, 12);
			this.txtpath.Name = "txtpath";
			this.txtpath.Size = new System.Drawing.Size(268, 20);
			this.txtpath.TabIndex = 28;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(359, 11);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(67, 23);
			this.button3.TabIndex = 29;
			this.button3.Text = "Import";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// crystalReportViewer
			// 
			this.crystalReportViewer.ActiveViewIndex = 0;
			this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
			this.crystalReportViewer.Location = new System.Drawing.Point(12, 40);
			this.crystalReportViewer.Name = "crystalReportViewer";
			this.crystalReportViewer.ReportSource = this.reportDocument1;
			this.crystalReportViewer.Size = new System.Drawing.Size(660, 509);
			this.crystalReportViewer.TabIndex = 32;
			this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
			// 
			// reportDocument1
			// 
			this.reportDocument1.FileName = "rassdk://D:\\000_Uniden\\008_GitHub\\SMTPRORAM-Combine\\SMTPRORAM\\AssyLine\\CrystalRep" +
    "ort\\QRCrystalReport.rpt";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(240, 238);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(82, 66);
			this.pictureBox1.TabIndex = 33;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// textBox1
			// 
			this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox1.Location = new System.Drawing.Point(776, 139);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(196, 20);
			this.textBox1.TabIndex = 37;
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(687, 143);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 13);
			this.label10.TabIndex = 53;
			this.label10.Text = "Qty Total:";
			// 
			// txtSC
			// 
			this.txtSC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSC.Enabled = false;
			this.txtSC.Location = new System.Drawing.Point(776, 337);
			this.txtSC.Name = "txtSC";
			this.txtSC.Size = new System.Drawing.Size(196, 20);
			this.txtSC.TabIndex = 45;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(687, 341);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(90, 13);
			this.label9.TabIndex = 52;
			this.label9.Text = "供应商代码(SC):";
			// 
			// txtUT
			// 
			this.txtUT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUT.Enabled = false;
			this.txtUT.Location = new System.Drawing.Point(776, 304);
			this.txtUT.Name = "txtUT";
			this.txtUT.Size = new System.Drawing.Size(196, 20);
			this.txtUT.TabIndex = 44;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(687, 308);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(55, 13);
			this.label8.TabIndex = 51;
			this.label8.Text = "单位(UT):";
			// 
			// txtBoxNo
			// 
			this.txtBoxNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBoxNo.Enabled = false;
			this.txtBoxNo.Location = new System.Drawing.Point(776, 271);
			this.txtBoxNo.Name = "txtBoxNo";
			this.txtBoxNo.Size = new System.Drawing.Size(196, 20);
			this.txtBoxNo.TabIndex = 43;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(687, 275);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 13);
			this.label7.TabIndex = 50;
			this.label7.Text = "Box No:";
			// 
			// txtQT
			// 
			this.txtQT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQT.Enabled = false;
			this.txtQT.Location = new System.Drawing.Point(776, 238);
			this.txtQT.Name = "txtQT";
			this.txtQT.Size = new System.Drawing.Size(196, 20);
			this.txtQT.TabIndex = 41;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(687, 242);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 49;
			this.label6.Text = "数量(QT):";
			// 
			// txtED
			// 
			this.txtED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtED.Enabled = false;
			this.txtED.Location = new System.Drawing.Point(776, 205);
			this.txtED.Name = "txtED";
			this.txtED.Size = new System.Drawing.Size(196, 20);
			this.txtED.TabIndex = 39;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(687, 209);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 13);
			this.label5.TabIndex = 48;
			this.label5.Text = "有效日期(ED):";
			// 
			// txtPD
			// 
			this.txtPD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPD.Enabled = false;
			this.txtPD.Location = new System.Drawing.Point(776, 172);
			this.txtPD.Name = "txtPD";
			this.txtPD.Size = new System.Drawing.Size(196, 20);
			this.txtPD.TabIndex = 38;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(687, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 47;
			this.label4.Text = "生产日期(PD):";
			// 
			// txtLN
			// 
			this.txtLN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLN.Location = new System.Drawing.Point(776, 106);
			this.txtLN.Name = "txtLN";
			this.txtLN.Size = new System.Drawing.Size(196, 20);
			this.txtLN.TabIndex = 36;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(687, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 46;
			this.label3.Text = "生产批号(LN):";
			// 
			// txtPN
			// 
			this.txtPN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPN.Enabled = false;
			this.txtPN.Location = new System.Drawing.Point(776, 73);
			this.txtPN.Name = "txtPN";
			this.txtPN.Size = new System.Drawing.Size(196, 20);
			this.txtPN.TabIndex = 35;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(687, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 42;
			this.label2.Text = "料号(PN):";
			// 
			// txtModel
			// 
			this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtModel.Location = new System.Drawing.Point(776, 40);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(196, 20);
			this.txtModel.TabIndex = 34;
			this.txtModel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModel_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(697, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 40;
			this.label1.Text = "Model:";
			// 
			// btView
			// 
			this.btView.Location = new System.Drawing.Point(744, 376);
			this.btView.Name = "btView";
			this.btView.Size = new System.Drawing.Size(75, 23);
			this.btView.TabIndex = 55;
			this.btView.Text = "View Report";
			this.btView.UseVisualStyleBackColor = true;
			this.btView.Click += new System.EventHandler(this.btView_Click);
			// 
			// btnCreateQRCode
			// 
			this.btnCreateQRCode.Location = new System.Drawing.Point(897, 376);
			this.btnCreateQRCode.Name = "btnCreateQRCode";
			this.btnCreateQRCode.Size = new System.Drawing.Size(75, 23);
			this.btnCreateQRCode.TabIndex = 54;
			this.btnCreateQRCode.Text = "Create QR";
			this.btnCreateQRCode.UseVisualStyleBackColor = true;
			this.btnCreateQRCode.Click += new System.EventHandler(this.btnCreateQRCode_Click);
			// 
			// frmPrintQRCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.btView);
			this.Controls.Add(this.btnCreateQRCode);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtSC);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtUT);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtBoxNo);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtQT);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtED);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPD);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtLN);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPN);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtModel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.crystalReportViewer);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtpath);
			this.Controls.Add(this.button3);
			this.Name = "frmPrintQRCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PRINT QRCODE";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtpath;
		private System.Windows.Forms.Button button3;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
		private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtSC;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtUT;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtBoxNo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtQT;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtED;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPD;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLN;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btView;
		private System.Windows.Forms.Button btnCreateQRCode;
	}
}