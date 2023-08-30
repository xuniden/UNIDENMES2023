namespace SMTPRORAM.Assy.Setup
{
	partial class frmAddErrorCode
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
			this.lblProcess = new System.Windows.Forms.Label();
			this.cbSheet = new System.Windows.Forms.ComboBox();
			this.iconbtnBrowse = new FontAwesome.Sharp.IconButton();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtErrorENDesc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtErrorVNDesc = new System.Windows.Forms.TextBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtErrorCode = new System.Windows.Forms.TextBox();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.chkIsDisable = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnEdit = new FontAwesome.Sharp.IconButton();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
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
			this.panel1.Controls.Add(this.lblProcess);
			this.panel1.Controls.Add(this.cbSheet);
			this.panel1.Controls.Add(this.iconbtnBrowse);
			this.panel1.Controls.Add(this.txtFilename);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtErrorENDesc);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtErrorVNDesc);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtErrorCode);
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.chkIsDisable);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(308, 561);
			this.panel1.TabIndex = 0;
			// 
			// lblProcess
			// 
			this.lblProcess.AutoSize = true;
			this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProcess.ForeColor = System.Drawing.Color.Red;
			this.lblProcess.Location = new System.Drawing.Point(10, 370);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(50, 16);
			this.lblProcess.TabIndex = 166;
			this.lblProcess.Text = "label1";
			// 
			// cbSheet
			// 
			this.cbSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSheet.FormattingEnabled = true;
			this.cbSheet.Location = new System.Drawing.Point(12, 346);
			this.cbSheet.Name = "cbSheet";
			this.cbSheet.Size = new System.Drawing.Size(290, 21);
			this.cbSheet.TabIndex = 165;
			this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
			// 
			// iconbtnBrowse
			// 
			this.iconbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnBrowse.IconChar = FontAwesome.Sharp.IconChar.Child;
			this.iconbtnBrowse.IconColor = System.Drawing.Color.Black;
			this.iconbtnBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnBrowse.IconSize = 16;
			this.iconbtnBrowse.Location = new System.Drawing.Point(228, 319);
			this.iconbtnBrowse.Name = "iconbtnBrowse";
			this.iconbtnBrowse.Size = new System.Drawing.Size(74, 22);
			this.iconbtnBrowse.TabIndex = 164;
			this.iconbtnBrowse.Text = "Chọn file";
			this.iconbtnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnBrowse.UseVisualStyleBackColor = true;
			this.iconbtnBrowse.Click += new System.EventHandler(this.iconbtnBrowse_Click);
			// 
			// txtFilename
			// 
			this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilename.Location = new System.Drawing.Point(12, 319);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(210, 20);
			this.txtFilename.TabIndex = 163;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 165);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mô tả EN:";
			// 
			// txtErrorENDesc
			// 
			this.txtErrorENDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrorENDesc.Location = new System.Drawing.Point(74, 162);
			this.txtErrorENDesc.Name = "txtErrorENDesc";
			this.txtErrorENDesc.Size = new System.Drawing.Size(228, 20);
			this.txtErrorENDesc.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 129);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Mô tả VN:";
			// 
			// txtErrorVNDesc
			// 
			this.txtErrorVNDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrorVNDesc.Location = new System.Drawing.Point(74, 126);
			this.txtErrorVNDesc.Name = "txtErrorVNDesc";
			this.txtErrorVNDesc.Size = new System.Drawing.Size(228, 20);
			this.txtErrorVNDesc.TabIndex = 3;
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
			this.label1.Location = new System.Drawing.Point(13, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 99;
			this.label1.Text = "Mã Lỗi:";
			// 
			// txtErrorCode
			// 
			this.txtErrorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtErrorCode.Location = new System.Drawing.Point(74, 91);
			this.txtErrorCode.Name = "txtErrorCode";
			this.txtErrorCode.Size = new System.Drawing.Size(228, 20);
			this.txtErrorCode.TabIndex = 1;
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
			// chkIsDisable
			// 
			this.chkIsDisable.AutoSize = true;
			this.chkIsDisable.Location = new System.Drawing.Point(74, 198);
			this.chkIsDisable.Name = "chkIsDisable";
			this.chkIsDisable.Size = new System.Drawing.Size(98, 17);
			this.chkIsDisable.TabIndex = 6;
			this.chkIsDisable.Text = "Không sử dụng";
			this.chkIsDisable.UseVisualStyleBackColor = true;
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 239);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 60);
			this.tableLayoutPanel1.TabIndex = 102;
			// 
			// iconbtnEdit
			// 
			this.iconbtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
			this.iconbtnEdit.IconColor = System.Drawing.Color.Black;
			this.iconbtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnEdit.IconSize = 16;
			this.iconbtnEdit.Location = new System.Drawing.Point(99, 3);
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
			this.iconbtnDelete.Location = new System.Drawing.Point(202, 3);
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
			this.iconbtnCancel.Location = new System.Drawing.Point(99, 33);
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
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(308, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(676, 561);
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
			this.dgView.Location = new System.Drawing.Point(6, 3);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(667, 555);
			this.dgView.TabIndex = 0;
			this.dgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellDoubleClick);
			// 
			// frmAddErrorCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmAddErrorCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QUẢN LÝ MÃ LỖI";
			this.Load += new System.EventHandler(this.frmAddErrorCode_Load);
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
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtErrorCode;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.CheckBox chkIsDisable;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private FontAwesome.Sharp.IconButton iconbtnEdit;
		private FontAwesome.Sharp.IconButton iconbtnDelete;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private FontAwesome.Sharp.IconButton iconbtnCancel;
		private FontAwesome.Sharp.IconButton iconbtnAdd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtErrorENDesc;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtErrorVNDesc;
		private System.Windows.Forms.Label lblProcess;
		private System.Windows.Forms.ComboBox cbSheet;
		private FontAwesome.Sharp.IconButton iconbtnBrowse;
		private System.Windows.Forms.TextBox txtFilename;
	}
}