namespace SMTPRORAM.AssyLine
{
	partial class frmLotControlSetup
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.panelContent = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLot = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.numericUnit = new System.Windows.Forms.NumericUpDown();
			this.numericLotsize = new System.Windows.Forms.NumericUpDown();
			this.txtCtn = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDbox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtEndNumber = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtStartNumber = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panelContent.SuspendLayout();
			this.panelLeft.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUnit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericLotsize)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(6, 12);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(626, 537);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.IconSize = 16;
			this.iconbtnSearch.Location = new System.Drawing.Point(16, 13);
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
			this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearch.Location = new System.Drawing.Point(103, 15);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 20);
			this.txtSearch.TabIndex = 90;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dataGridView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(340, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(644, 561);
			this.panelContent.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "LOT SIZE#:";
			// 
			// txtLot
			// 
			this.txtLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLot.Location = new System.Drawing.Point(103, 54);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new System.Drawing.Size(200, 20);
			this.txtLot.TabIndex = 1;
			this.txtLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLot_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "LOT#:";
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.tableLayoutPanel1);
			this.panelLeft.Controls.Add(this.numericUnit);
			this.panelLeft.Controls.Add(this.numericLotsize);
			this.panelLeft.Controls.Add(this.txtCtn);
			this.panelLeft.Controls.Add(this.label8);
			this.panelLeft.Controls.Add(this.txtDbox);
			this.panelLeft.Controls.Add(this.label6);
			this.panelLeft.Controls.Add(this.txtEndNumber);
			this.panelLeft.Controls.Add(this.label7);
			this.panelLeft.Controls.Add(this.txtStartNumber);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.txtModel);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.iconbtnSearch);
			this.panelLeft.Controls.Add(this.txtSearch);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Controls.Add(this.txtLot);
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(340, 561);
			this.panelLeft.TabIndex = 2;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.89743F));
			this.tableLayoutPanel1.Controls.Add(this.iconbtnEdit, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnAdd, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 292);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(287, 60);
			this.tableLayoutPanel1.TabIndex = 92;
			// 
			// iconbtnEdit
			// 
			this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
			this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
			this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnEdit.IconSize = 16;
			this.iconbtnEdit.Location = new System.Drawing.Point(141, 3);
			this.iconbtnEdit.Name = "iconbtnEdit";
			this.iconbtnEdit.Size = new System.Drawing.Size(105, 23);
			this.iconbtnEdit.TabIndex = 14;
			this.iconbtnEdit.Text = "Sửa";
			this.iconbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnEdit.UseVisualStyleBackColor = true;
			this.iconbtnEdit.Click += new System.EventHandler(this.iconbtnEdit_Click);
			// 
			// iconbtnSave
			// 
			this.iconbtnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.iconbtnSave.IconColor = System.Drawing.Color.Black;
			this.iconbtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSave.IconSize = 18;
			this.iconbtnSave.Location = new System.Drawing.Point(3, 33);
			this.iconbtnSave.Name = "iconbtnSave";
			this.iconbtnSave.Size = new System.Drawing.Size(97, 23);
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
			this.iconbtnCancel.Location = new System.Drawing.Point(141, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(105, 23);
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
			this.iconbtnAdd.Size = new System.Drawing.Size(97, 23);
			this.iconbtnAdd.TabIndex = 13;
			this.iconbtnAdd.Text = "Thêm";
			this.iconbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnAdd.UseVisualStyleBackColor = true;
			this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
			// 
			// numericUnit
			// 
			this.numericUnit.Location = new System.Drawing.Point(103, 139);
			this.numericUnit.Name = "numericUnit";
			this.numericUnit.Size = new System.Drawing.Size(120, 20);
			this.numericUnit.TabIndex = 7;
			this.numericUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUnit_KeyDown);
			// 
			// numericLotsize
			// 
			this.numericLotsize.Location = new System.Drawing.Point(103, 83);
			this.numericLotsize.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.numericLotsize.Name = "numericLotsize";
			this.numericLotsize.Size = new System.Drawing.Size(120, 20);
			this.numericLotsize.TabIndex = 3;
			this.numericLotsize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericLotsize_KeyDown);
			// 
			// txtCtn
			// 
			this.txtCtn.Location = new System.Drawing.Point(103, 250);
			this.txtCtn.Name = "txtCtn";
			this.txtCtn.Size = new System.Drawing.Size(200, 20);
			this.txtCtn.TabIndex = 15;
			this.txtCtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCtn_KeyDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 253);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "CTN CODE#";
			// 
			// txtDbox
			// 
			this.txtDbox.Location = new System.Drawing.Point(103, 223);
			this.txtDbox.Name = "txtDbox";
			this.txtDbox.Size = new System.Drawing.Size(200, 20);
			this.txtDbox.TabIndex = 13;
			this.txtDbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDbox_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 226);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "DBOX CODE #";
			// 
			// txtEndNumber
			// 
			this.txtEndNumber.Location = new System.Drawing.Point(103, 195);
			this.txtEndNumber.Name = "txtEndNumber";
			this.txtEndNumber.Size = new System.Drawing.Size(200, 20);
			this.txtEndNumber.TabIndex = 11;
			this.txtEndNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndNumber_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 198);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "END#:";
			// 
			// txtStartNumber
			// 
			this.txtStartNumber.Location = new System.Drawing.Point(103, 165);
			this.txtStartNumber.Name = "txtStartNumber";
			this.txtStartNumber.Size = new System.Drawing.Size(200, 20);
			this.txtStartNumber.TabIndex = 9;
			this.txtStartNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartNumber_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "START#:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 140);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "UNIT/CTN#:";
			// 
			// txtModel
			// 
			this.txtModel.Location = new System.Drawing.Point(103, 110);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(200, 20);
			this.txtModel.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "MODEL#:";
			// 
			// frmLotControlSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmLotControlSetup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "THIẾT LẬP LOT CONTROL";
			this.Load += new System.EventHandler(this.frmLotControlSetup_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panelContent.ResumeLayout(false);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUnit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericLotsize)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLot;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.TextBox txtCtn;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDbox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEndNumber;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtStartNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUnit;
		private System.Windows.Forms.NumericUpDown numericLotsize;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private FontAwesome.Sharp.IconButton iconbtnEdit;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private FontAwesome.Sharp.IconButton iconbtnCancel;
		private FontAwesome.Sharp.IconButton iconbtnAdd;
	}
}