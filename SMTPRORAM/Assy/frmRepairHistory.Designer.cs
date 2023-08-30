namespace SMTPRORAM.Assy
{
	partial class frmRepairHistory
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtQrCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtLot = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.cbCauseDept = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbCauseCode = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNGPosition = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbErrorCode = new System.Windows.Forms.ComboBox();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(308, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(676, 561);
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
			this.dgView.Location = new System.Drawing.Point(6, 3);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(667, 555);
			this.dgView.TabIndex = 0;
			// 
			// iconbtnCancel
			// 
			this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.XmarkSquare;
			this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
			this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnCancel.IconSize = 18;
			this.iconbtnCancel.Location = new System.Drawing.Point(142, 3);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(84, 23);
			this.iconbtnCancel.TabIndex = 15;
			this.iconbtnCancel.Text = "Hủy bỏ";
			this.iconbtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "QR/Barcode:";
			// 
			// txtQrCode
			// 
			this.txtQrCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtQrCode.Location = new System.Drawing.Point(87, 97);
			this.txtQrCode.Name = "txtQrCode";
			this.txtQrCode.Size = new System.Drawing.Size(212, 20);
			this.txtQrCode.TabIndex = 1;
			this.txtQrCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQrCode_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(153, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Model:";
			// 
			// txtModel
			// 
			this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtModel.Enabled = false;
			this.txtModel.Location = new System.Drawing.Point(189, 132);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(110, 20);
			this.txtModel.TabIndex = 5;
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 18;
			this.iconbtnSave.Location = new System.Drawing.Point(3, 3);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(77, 23);
			this.iconbtnSave.TabIndex = 14;
			this.iconbtnSave.Text = "Ghi lại";
			this.iconbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSave.UseVisualStyleBackColor = true;
			this.iconbtnSave.Click += new System.EventHandler(this.iconbtnSave_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(12, 41);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(209, 20);
			this.txtSearch.TabIndex = 103;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 135);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Lot:";
			// 
			// txtLot
			// 
			this.txtLot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLot.Enabled = false;
			this.txtLot.Location = new System.Drawing.Point(44, 132);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new System.Drawing.Size(103, 20);
			this.txtLot.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.14815F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.85184F));
			this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 360);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 30);
			this.tableLayoutPanel1.TabIndex = 102;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.cbCauseDept);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.cbCauseCode);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.txtNGPosition);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.cbErrorCode);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtQrCode);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtModel);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtLot);
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(308, 561);
			this.panel1.TabIndex = 2;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 281);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(145, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Nguyên nhân bởi phòng ban:";
			// 
			// cbCauseDept
			// 
			this.cbCauseDept.FormattingEnabled = true;
			this.cbCauseDept.Location = new System.Drawing.Point(172, 278);
			this.cbCauseDept.Name = "cbCauseDept";
			this.cbCauseDept.Size = new System.Drawing.Size(127, 21);
			this.cbCauseDept.TabIndex = 13;
			this.cbCauseDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCauseDept_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 245);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Nguyên nhân:";
			// 
			// cbCauseCode
			// 
			this.cbCauseCode.FormattingEnabled = true;
			this.cbCauseCode.Location = new System.Drawing.Point(87, 242);
			this.cbCauseCode.Name = "cbCauseCode";
			this.cbCauseCode.Size = new System.Drawing.Size(212, 21);
			this.cbCauseCode.TabIndex = 11;
			this.cbCauseCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCauseCode_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 209);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Vị trí NG:";
			// 
			// txtNGPosition
			// 
			this.txtNGPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNGPosition.Location = new System.Drawing.Point(87, 206);
			this.txtNGPosition.Name = "txtNGPosition";
			this.txtNGPosition.Size = new System.Drawing.Size(212, 20);
			this.txtNGPosition.TabIndex = 9;
			this.txtNGPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNGPosition_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 173);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Mã lỗi:";
			// 
			// cbErrorCode
			// 
			this.cbErrorCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbErrorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbErrorCode.FormattingEnabled = true;
			this.cbErrorCode.Location = new System.Drawing.Point(87, 170);
			this.cbErrorCode.Name = "cbErrorCode";
			this.cbErrorCode.Size = new System.Drawing.Size(212, 21);
			this.cbErrorCode.TabIndex = 7;
			this.cbErrorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbErrorCode_KeyDown);
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.IconSize = 16;
			this.iconbtnSearch.Location = new System.Drawing.Point(227, 39);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSearch.TabIndex = 104;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// frmRepairHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmRepairHistory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LỊCH SỬ SỬA CHỮA";
			this.Load += new System.EventHandler(this.frmRepairHistory_Load);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgView;
		private FontAwesome.Sharp.IconButton iconbtnCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtQrCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtModel;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtLot;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbCauseCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNGPosition;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbErrorCode;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbCauseDept;
	}
}