namespace SMTPRORAM.Smt.DataControl
{
	partial class frmAOIErrorRecord
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
			this.panelLeft = new System.Windows.Forms.Panel();
			this.txtLoi = new System.Windows.Forms.TextBox();
			this.cbMaloi = new System.Windows.Forms.ComboBox();
			this.iconbtnClose = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.lbl_05 = new System.Windows.Forms.Label();
			this.lbl_04 = new System.Windows.Forms.Label();
			this.lbl_03 = new System.Windows.Forms.Label();
			this.lbl_02 = new System.Windows.Forms.Label();
			this.lbl_01 = new System.Windows.Forms.Label();
			this.txtsoluong = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtpartcode = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtVitri = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtQRCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelLeft.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.txtLoi);
			this.panelLeft.Controls.Add(this.cbMaloi);
			this.panelLeft.Controls.Add(this.iconbtnClose);
			this.panelLeft.Controls.Add(this.iconbtnSave);
			this.panelLeft.Controls.Add(this.lbl_05);
			this.panelLeft.Controls.Add(this.lbl_04);
			this.panelLeft.Controls.Add(this.lbl_03);
			this.panelLeft.Controls.Add(this.lbl_02);
			this.panelLeft.Controls.Add(this.lbl_01);
			this.panelLeft.Controls.Add(this.txtsoluong);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.txtpartcode);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.txtVitri);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Controls.Add(this.txtQRCode);
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(413, 561);
			this.panelLeft.TabIndex = 0;
			// 
			// txtLoi
			// 
			this.txtLoi.Enabled = false;
			this.txtLoi.Location = new System.Drawing.Point(110, 152);
			this.txtLoi.Name = "txtLoi";
			this.txtLoi.Size = new System.Drawing.Size(231, 20);
			this.txtLoi.TabIndex = 18;
			// 
			// cbMaloi
			// 
			this.cbMaloi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbMaloi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbMaloi.FormattingEnabled = true;
			this.cbMaloi.Location = new System.Drawing.Point(110, 119);
			this.cbMaloi.Name = "cbMaloi";
			this.cbMaloi.Size = new System.Drawing.Size(121, 21);
			this.cbMaloi.TabIndex = 17;
			this.cbMaloi.SelectionChangeCommitted += new System.EventHandler(this.cbMaloi_SelectionChangeCommitted);
			// 
			// iconbtnClose
			// 
			this.iconbtnClose.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnClose.IconColor = System.Drawing.Color.Black;
			this.iconbtnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnClose.Location = new System.Drawing.Point(266, 252);
			this.iconbtnClose.Name = "iconbtnClose";
			this.iconbtnClose.Size = new System.Drawing.Size(75, 28);
			this.iconbtnClose.TabIndex = 16;
			this.iconbtnClose.Text = "CLOSE";
			this.iconbtnClose.UseVisualStyleBackColor = true;
			this.iconbtnClose.Click += new System.EventHandler(this.iconbtnClose_Click);
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.Location = new System.Drawing.Point(110, 252);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(75, 28);
			this.iconbtnSave.TabIndex = 15;
			this.iconbtnSave.Text = "SAVE";
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// lbl_05
			// 
			this.lbl_05.AutoSize = true;
			this.lbl_05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_05.Location = new System.Drawing.Point(347, 218);
			this.lbl_05.Name = "lbl_05";
			this.lbl_05.Size = new System.Drawing.Size(24, 13);
			this.lbl_05.TabIndex = 14;
			this.lbl_05.Text = "OK";
			// 
			// lbl_04
			// 
			this.lbl_04.AutoSize = true;
			this.lbl_04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_04.Location = new System.Drawing.Point(347, 187);
			this.lbl_04.Name = "lbl_04";
			this.lbl_04.Size = new System.Drawing.Size(24, 13);
			this.lbl_04.TabIndex = 13;
			this.lbl_04.Text = "OK";
			// 
			// lbl_03
			// 
			this.lbl_03.AutoSize = true;
			this.lbl_03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_03.Location = new System.Drawing.Point(347, 155);
			this.lbl_03.Name = "lbl_03";
			this.lbl_03.Size = new System.Drawing.Size(24, 13);
			this.lbl_03.TabIndex = 12;
			this.lbl_03.Text = "OK";
			// 
			// lbl_02
			// 
			this.lbl_02.AutoSize = true;
			this.lbl_02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_02.Location = new System.Drawing.Point(347, 91);
			this.lbl_02.Name = "lbl_02";
			this.lbl_02.Size = new System.Drawing.Size(24, 13);
			this.lbl_02.TabIndex = 11;
			this.lbl_02.Text = "OK";
			// 
			// lbl_01
			// 
			this.lbl_01.AutoSize = true;
			this.lbl_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_01.Location = new System.Drawing.Point(347, 60);
			this.lbl_01.Name = "lbl_01";
			this.lbl_01.Size = new System.Drawing.Size(24, 13);
			this.lbl_01.TabIndex = 10;
			this.lbl_01.Text = "OK";
			// 
			// txtsoluong
			// 
			this.txtsoluong.Location = new System.Drawing.Point(110, 214);
			this.txtsoluong.Name = "txtsoluong";
			this.txtsoluong.Size = new System.Drawing.Size(231, 20);
			this.txtsoluong.TabIndex = 9;
			this.txtsoluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsoluong_KeyDown);
			this.txtsoluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsoluong_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 218);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Số lượng:";
			// 
			// txtpartcode
			// 
			this.txtpartcode.Enabled = false;
			this.txtpartcode.Location = new System.Drawing.Point(110, 183);
			this.txtpartcode.Name = "txtpartcode";
			this.txtpartcode.Size = new System.Drawing.Size(231, 20);
			this.txtpartcode.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 187);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "PartCode";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mã lỗi:";
			// 
			// txtVitri
			// 
			this.txtVitri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVitri.Location = new System.Drawing.Point(110, 87);
			this.txtVitri.Name = "txtVitri";
			this.txtVitri.Size = new System.Drawing.Size(231, 20);
			this.txtVitri.TabIndex = 3;
			this.txtVitri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVitri_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Vị Trí:";
			// 
			// txtQRCode
			// 
			this.txtQRCode.Location = new System.Drawing.Point(110, 56);
			this.txtQRCode.Name = "txtQRCode";
			this.txtQRCode.Size = new System.Drawing.Size(231, 20);
			this.txtQRCode.TabIndex = 1;
			this.txtQRCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQRCode_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "QR Code:";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(413, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(571, 561);
			this.panelContent.TabIndex = 1;
			// 
			// dgView
			// 
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(6, 12);
			this.dgView.Name = "dgView";
			this.dgView.Size = new System.Drawing.Size(553, 537);
			this.dgView.TabIndex = 0;
			// 
			// frmAOIErrorRecord
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAOIErrorRecord";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GHI LẠI LỖI TẠI CÔNG ĐOẠN AOI";
			this.Load += new System.EventHandler(this.frmAOIErrorRecord_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.TextBox txtQRCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtsoluong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtpartcode;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtVitri;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbl_05;
		private System.Windows.Forms.Label lbl_03;
		private System.Windows.Forms.Label lbl_02;
		private System.Windows.Forms.Label lbl_01;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private FontAwesome.Sharp.IconButton iconbtnClose;
		private System.Windows.Forms.Label lbl_04;
		private System.Windows.Forms.ComboBox cbMaloi;
		private System.Windows.Forms.TextBox txtLoi;
	}
}