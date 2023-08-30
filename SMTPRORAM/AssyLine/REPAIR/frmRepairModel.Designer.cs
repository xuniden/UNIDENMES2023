namespace SMTPRORAM.AssyLine.REPAIR
{
	partial class frmRepairModel
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
			this.txtShortModel = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.iconbtnFirst = new FontAwesome.Sharp.IconButton();
			this.labelPageInfo = new System.Windows.Forms.Label();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.labelTotalRecords = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.iconbtnLast = new FontAwesome.Sharp.IconButton();
			this.label1 = new System.Windows.Forms.Label();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.iconbtnSave = new FontAwesome.Sharp.IconButton();
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnAdd = new FontAwesome.Sharp.IconButton();
			this.iconbtnLoadAll = new FontAwesome.Sharp.IconButton();
			this.btImport = new System.Windows.Forms.Button();
			this.btBrowser = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBrowser = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panelContent.SuspendLayout();
			this.panelLeft.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
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
			this.dataGridView.Location = new System.Drawing.Point(6, 44);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.Size = new System.Drawing.Size(626, 505);
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
			this.iconbtnSearch.Location = new System.Drawing.Point(12, 42);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(76, 23);
			this.iconbtnSearch.TabIndex = 95;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearch.Location = new System.Drawing.Point(94, 44);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(230, 20);
			this.txtSearch.TabIndex = 94;
			// 
			// txtShortModel
			// 
			this.txtShortModel.Location = new System.Drawing.Point(84, 100);
			this.txtShortModel.Name = "txtShortModel";
			this.txtShortModel.Size = new System.Drawing.Size(240, 20);
			this.txtShortModel.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Short Model:";
			// 
			// iconbtnFirst
			// 
			this.iconbtnFirst.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnFirst.IconColor = System.Drawing.Color.Black;
			this.iconbtnFirst.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnFirst.Location = new System.Drawing.Point(195, 12);
			this.iconbtnFirst.Name = "iconbtnFirst";
			this.iconbtnFirst.Size = new System.Drawing.Size(34, 23);
			this.iconbtnFirst.TabIndex = 58;
			this.iconbtnFirst.Text = "<<";
			this.iconbtnFirst.UseVisualStyleBackColor = true;
			// 
			// labelPageInfo
			// 
			this.labelPageInfo.AutoSize = true;
			this.labelPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelPageInfo.ForeColor = System.Drawing.Color.Blue;
			this.labelPageInfo.Location = new System.Drawing.Point(276, 17);
			this.labelPageInfo.Name = "labelPageInfo";
			this.labelPageInfo.Size = new System.Drawing.Size(34, 13);
			this.labelPageInfo.TabIndex = 57;
			this.labelPageInfo.Text = "CurP";
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(374, 12);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(34, 23);
			this.iconbtnNext.TabIndex = 56;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			// 
			// iconbtnPrev
			// 
			this.iconbtnPrev.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrev.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrev.Location = new System.Drawing.Point(235, 12);
			this.iconbtnPrev.Name = "iconbtnPrev";
			this.iconbtnPrev.Size = new System.Drawing.Size(34, 23);
			this.iconbtnPrev.TabIndex = 55;
			this.iconbtnPrev.Text = "<";
			this.iconbtnPrev.UseVisualStyleBackColor = true;
			// 
			// labelTotalRecords
			// 
			this.labelTotalRecords.AutoSize = true;
			this.labelTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelTotalRecords.ForeColor = System.Drawing.Color.Blue;
			this.labelTotalRecords.Location = new System.Drawing.Point(77, 17);
			this.labelTotalRecords.Name = "labelTotalRecords";
			this.labelTotalRecords.Size = new System.Drawing.Size(87, 13);
			this.labelTotalRecords.TabIndex = 54;
			this.labelTotalRecords.Text = "Total Records";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.iconbtnLast);
			this.panelContent.Controls.Add(this.iconbtnFirst);
			this.panelContent.Controls.Add(this.labelPageInfo);
			this.panelContent.Controls.Add(this.iconbtnNext);
			this.panelContent.Controls.Add(this.iconbtnPrev);
			this.panelContent.Controls.Add(this.labelTotalRecords);
			this.panelContent.Controls.Add(this.label1);
			this.panelContent.Controls.Add(this.dataGridView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(340, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(644, 561);
			this.panelContent.TabIndex = 3;
			// 
			// iconbtnLast
			// 
			this.iconbtnLast.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLast.IconColor = System.Drawing.Color.Black;
			this.iconbtnLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLast.Location = new System.Drawing.Point(414, 12);
			this.iconbtnLast.Name = "iconbtnLast";
			this.iconbtnLast.Size = new System.Drawing.Size(34, 23);
			this.iconbtnLast.TabIndex = 59;
			this.iconbtnLast.Text = ">>";
			this.iconbtnLast.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 53;
			this.label1.Text = "Total Rows:";
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.tableLayoutPanel1);
			this.panelLeft.Controls.Add(this.btImport);
			this.panelLeft.Controls.Add(this.btBrowser);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.txtBrowser);
			this.panelLeft.Controls.Add(this.iconbtnSearch);
			this.panelLeft.Controls.Add(this.txtSearch);
			this.panelLeft.Controls.Add(this.txtShortModel);
			this.panelLeft.Controls.Add(this.label6);
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
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.89743F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.19658F));
			this.tableLayoutPanel1.Controls.Add(this.iconbtnDelete, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnSave, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnCancel, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnAdd, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.iconbtnLoadAll, 2, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 150);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 60);
			this.tableLayoutPanel1.TabIndex = 100;
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.Minus;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.IconSize = 16;
			this.iconbtnDelete.Location = new System.Drawing.Point(217, 3);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(82, 23);
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
			this.iconbtnSave.Size = new System.Drawing.Size(87, 23);
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
			this.iconbtnCancel.Location = new System.Drawing.Point(106, 33);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(94, 23);
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
			this.iconbtnAdd.Size = new System.Drawing.Size(87, 23);
			this.iconbtnAdd.TabIndex = 13;
			this.iconbtnAdd.Text = "Thêm";
			this.iconbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnAdd.UseVisualStyleBackColor = true;
			this.iconbtnAdd.Click += new System.EventHandler(this.iconbtnAdd_Click);
			// 
			// iconbtnLoadAll
			// 
			this.iconbtnLoadAll.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLoadAll.IconColor = System.Drawing.Color.Black;
			this.iconbtnLoadAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLoadAll.Location = new System.Drawing.Point(217, 33);
			this.iconbtnLoadAll.Name = "iconbtnLoadAll";
			this.iconbtnLoadAll.Size = new System.Drawing.Size(82, 23);
			this.iconbtnLoadAll.TabIndex = 18;
			this.iconbtnLoadAll.Text = "Load All";
			this.iconbtnLoadAll.UseVisualStyleBackColor = true;
			this.iconbtnLoadAll.Click += new System.EventHandler(this.iconbtnLoadAll_Click);
			// 
			// btImport
			// 
			this.btImport.Location = new System.Drawing.Point(132, 290);
			this.btImport.Name = "btImport";
			this.btImport.Size = new System.Drawing.Size(81, 23);
			this.btImport.TabIndex = 98;
			this.btImport.Text = "Import";
			this.btImport.UseVisualStyleBackColor = true;
			this.btImport.Click += new System.EventHandler(this.btImport_Click);
			// 
			// btBrowser
			// 
			this.btBrowser.Location = new System.Drawing.Point(51, 290);
			this.btBrowser.Name = "btBrowser";
			this.btBrowser.Size = new System.Drawing.Size(75, 23);
			this.btBrowser.TabIndex = 99;
			this.btBrowser.Text = "Browser";
			this.btBrowser.UseVisualStyleBackColor = true;
			this.btBrowser.Click += new System.EventHandler(this.btBrowser_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 268);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 97;
			this.label3.Text = "Path:";
			// 
			// txtBrowser
			// 
			this.txtBrowser.Location = new System.Drawing.Point(51, 264);
			this.txtBrowser.Name = "txtBrowser";
			this.txtBrowser.Size = new System.Drawing.Size(273, 20);
			this.txtBrowser.TabIndex = 96;
			// 
			// frmRepairModel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmRepairModel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "REPAIR MODEL";
			this.Load += new System.EventHandler(this.frmRepairModel_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panelContent.ResumeLayout(false);
			this.panelContent.PerformLayout();
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.TextBox txtShortModel;
		private System.Windows.Forms.Label label6;
		private FontAwesome.Sharp.IconButton iconbtnFirst;
		private System.Windows.Forms.Label labelPageInfo;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
		private System.Windows.Forms.Label labelTotalRecords;
		private System.Windows.Forms.Panel panelContent;
		private FontAwesome.Sharp.IconButton iconbtnLast;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private FontAwesome.Sharp.IconButton iconbtnDelete;
		private FontAwesome.Sharp.IconButton iconbtnSave;
		private FontAwesome.Sharp.IconButton iconbtnCancel;
		private FontAwesome.Sharp.IconButton iconbtnAdd;
		private FontAwesome.Sharp.IconButton iconbtnLoadAll;
		private System.Windows.Forms.Button btImport;
		private System.Windows.Forms.Button btBrowser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtBrowser;
	}
}