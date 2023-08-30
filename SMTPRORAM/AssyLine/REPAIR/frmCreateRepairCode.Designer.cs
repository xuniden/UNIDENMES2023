namespace SMTPRORAM.AssyLine.REPAIR
{
	partial class frmCreateRepairCode
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
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.btnHuy = new System.Windows.Forms.Button();
			this.btnCreate = new System.Windows.Forms.Button();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cbYear = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbDept = new System.Windows.Forms.ComboBox();
			this.panelContent = new System.Windows.Forms.Panel();
			this.iconbtnLast = new FontAwesome.Sharp.IconButton();
			this.iconbtnFirst = new FontAwesome.Sharp.IconButton();
			this.labelPageInfo = new System.Windows.Forms.Label();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.labelTotalRecords = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.panelLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.iconbtnSearch);
			this.panelLeft.Controls.Add(this.txtSearch);
			this.panelLeft.Controls.Add(this.btnHuy);
			this.panelLeft.Controls.Add(this.btnCreate);
			this.panelLeft.Controls.Add(this.numericUpDown2);
			this.panelLeft.Controls.Add(this.label8);
			this.panelLeft.Controls.Add(this.numericUpDown1);
			this.panelLeft.Controls.Add(this.label7);
			this.panelLeft.Controls.Add(this.txtID);
			this.panelLeft.Controls.Add(this.label6);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.cbYear);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Controls.Add(this.cbDept);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(340, 561);
			this.panelLeft.TabIndex = 0;
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.IconSize = 16;
			this.iconbtnSearch.Location = new System.Drawing.Point(13, 42);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSearch.TabIndex = 95;
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
			this.txtSearch.Location = new System.Drawing.Point(94, 44);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(230, 20);
			this.txtSearch.TabIndex = 94;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// btnHuy
			// 
			this.btnHuy.Location = new System.Drawing.Point(165, 258);
			this.btnHuy.Name = "btnHuy";
			this.btnHuy.Size = new System.Drawing.Size(75, 23);
			this.btnHuy.TabIndex = 15;
			this.btnHuy.Text = "Hủy";
			this.btnHuy.UseVisualStyleBackColor = true;
			this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(84, 258);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 14;
			this.btnCreate.Text = "Tạo";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(84, 217);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(239, 20);
			this.numericUpDown2.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 221);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Tới số:";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(84, 189);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(239, 20);
			this.numericUpDown1.TabIndex = 10;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 193);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Từ số:";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(84, 161);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(240, 20);
			this.txtID.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 165);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "ID Người sửa";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Năm:";
			// 
			// cbYear
			// 
			this.cbYear.FormattingEnabled = true;
			this.cbYear.Items.AddRange(new object[] {
            "T|2022",
            "U|2023",
            "V|2024",
            "W|2025",
            "X|2026",
            "Y|2027",
            "Z|2028"});
			this.cbYear.Location = new System.Drawing.Point(84, 132);
			this.cbYear.Name = "cbYear";
			this.cbYear.Size = new System.Drawing.Size(240, 21);
			this.cbYear.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Bộ phận:";
			// 
			// cbDept
			// 
			this.cbDept.FormattingEnabled = true;
			this.cbDept.Items.AddRange(new object[] {
            "ET"});
			this.cbDept.Location = new System.Drawing.Point(84, 101);
			this.cbDept.Name = "cbDept";
			this.cbDept.Size = new System.Drawing.Size(240, 21);
			this.cbDept.TabIndex = 4;
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
			this.panelContent.TabIndex = 1;
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
			this.iconbtnLast.Click += new System.EventHandler(this.iconbtnLast_Click);
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
			this.iconbtnFirst.Click += new System.EventHandler(this.iconbtnFirst_Click);
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
			this.iconbtnNext.Click += new System.EventHandler(this.iconbtnNext_Click);
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
			this.iconbtnPrev.Click += new System.EventHandler(this.iconbtnPrev_Click);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 53;
			this.label1.Text = "Total Rows:";
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
			// 
			// frmCreateRepairCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmCreateRepairCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TẠO MÃ REPAIR CHO NGƯỜI SỬ DỤNG";
			this.Load += new System.EventHandler(this.frmCreateRepairCode_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.panelContent.ResumeLayout(false);
			this.panelContent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbYear;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbDept;
		private System.Windows.Forms.Button btnHuy;
		private System.Windows.Forms.Button btnCreate;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private FontAwesome.Sharp.IconButton iconbtnLast;
		private FontAwesome.Sharp.IconButton iconbtnFirst;
		private System.Windows.Forms.Label labelPageInfo;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
		private System.Windows.Forms.Label labelTotalRecords;
		private System.Windows.Forms.Label label1;
	}
}