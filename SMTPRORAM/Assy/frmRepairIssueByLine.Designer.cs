namespace SMTPRORAM.Assy
{
	partial class frmRepairIssueByLine
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
			this.cbLineName = new System.Windows.Forms.ComboBox();
			this.txtLOT = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cbProcess = new System.Windows.Forms.ComboBox();
			this.txtENDescription = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtVNDescription = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbErrorCode = new System.Windows.Forms.ComboBox();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.txtReason = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.cbLineName);
			this.panel1.Controls.Add(this.txtLOT);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.cbProcess);
			this.panel1.Controls.Add(this.txtENDescription);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtVNDescription);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.cbErrorCode);
			this.panel1.Controls.Add(this.iconbtnCancel);
			this.panel1.Controls.Add(this.iconbtnSave);
			this.panel1.Controls.Add(this.txtReason);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtBarcode);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(329, 528);
			this.panel1.TabIndex = 2;
			// 
			// cbLineName
			// 
			this.cbLineName.FormattingEnabled = true;
			this.cbLineName.Location = new System.Drawing.Point(117, 94);
			this.cbLineName.Name = "cbLineName";
			this.cbLineName.Size = new System.Drawing.Size(125, 21);
			this.cbLineName.TabIndex = 21;
			this.cbLineName.SelectionChangeCommitted += new System.EventHandler(this.cbLineName_SelectionChangeCommitted);
			this.cbLineName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLineName_KeyDown);
			// 
			// txtLOT
			// 
			this.txtLOT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLOT.Location = new System.Drawing.Point(248, 94);
			this.txtLOT.Name = "txtLOT";
			this.txtLOT.Size = new System.Drawing.Size(69, 20);
			this.txtLOT.TabIndex = 20;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 97);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "Line Name:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Blue;
			this.label7.Location = new System.Drawing.Point(102, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 25);
			this.label7.TabIndex = 16;
			this.label7.Text = "KEYIN DDR";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Công đoạn:";
			// 
			// cbProcess
			// 
			this.cbProcess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProcess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbProcess.FormattingEnabled = true;
			this.cbProcess.Location = new System.Drawing.Point(117, 125);
			this.cbProcess.Name = "cbProcess";
			this.cbProcess.Size = new System.Drawing.Size(202, 21);
			this.cbProcess.TabIndex = 3;
			this.cbProcess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProcess_KeyDown);
			this.cbProcess.Validating += new System.ComponentModel.CancelEventHandler(this.cbProcess_Validating);
			// 
			// txtENDescription
			// 
			this.txtENDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtENDescription.Enabled = false;
			this.txtENDescription.Location = new System.Drawing.Point(117, 215);
			this.txtENDescription.Name = "txtENDescription";
			this.txtENDescription.Size = new System.Drawing.Size(202, 20);
			this.txtENDescription.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 218);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Mô tả EN:";
			// 
			// txtVNDescription
			// 
			this.txtVNDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVNDescription.Enabled = false;
			this.txtVNDescription.Location = new System.Drawing.Point(117, 184);
			this.txtVNDescription.Name = "txtVNDescription";
			this.txtVNDescription.Size = new System.Drawing.Size(202, 20);
			this.txtVNDescription.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 187);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Mô tả VN:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 161);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Mã lỗi:";
			// 
			// cbErrorCode
			// 
			this.cbErrorCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbErrorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbErrorCode.FormattingEnabled = true;
			this.cbErrorCode.Location = new System.Drawing.Point(117, 157);
			this.cbErrorCode.Name = "cbErrorCode";
			this.cbErrorCode.Size = new System.Drawing.Size(202, 21);
			this.cbErrorCode.TabIndex = 5;
			this.cbErrorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbErrorCode_KeyDown);
			this.cbErrorCode.Validating += new System.ComponentModel.CancelEventHandler(this.cbErrorCode_Validating);
			// 
			// iconbtnCancel
			// 
			this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
			this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnCancel.Location = new System.Drawing.Point(242, 281);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(75, 23);
			this.iconbtnCancel.TabIndex = 7;
			this.iconbtnCancel.Text = "Hủy";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.Location = new System.Drawing.Point(117, 281);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSave.TabIndex = 6;
			this.iconbtnSave.Text = "Gủi Repair";
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// txtReason
			// 
			this.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtReason.Location = new System.Drawing.Point(117, 247);
			this.txtReason.Name = "txtReason";
			this.txtReason.Size = new System.Drawing.Size(202, 20);
			this.txtReason.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 253);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Lý do:";
			// 
			// txtBarcode
			// 
			this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBarcode.Location = new System.Drawing.Point(117, 65);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(202, 20);
			this.txtBarcode.TabIndex = 1;
			this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Barcode (QR Code):";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(881, 528);
			this.panel2.TabIndex = 3;
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(335, 6);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(543, 510);
			this.dgView.TabIndex = 0;
			// 
			// frmRepairIssueByLine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(881, 528);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "frmRepairIssueByLine";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BÁO SỬA TẠI LINE";
			this.Load += new System.EventHandler(this.frmRepairIssueByLine_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private System.Windows.Forms.TextBox txtReason;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgView;
		private FontAwesome.Sharp.IconButton iconbtnCancel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbErrorCode;
		private System.Windows.Forms.TextBox txtVNDescription;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtENDescription;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbProcess;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtLOT;
		private System.Windows.Forms.ComboBox cbLineName;
	}
}