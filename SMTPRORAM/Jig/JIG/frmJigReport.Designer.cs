namespace SMTPRORAM.Jig.JIG
{
	partial class frmJigReport
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
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbltotalIn = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.iconbtnExport = new FontAwesome.Sharp.IconButton();
			this.iconbtnReport = new FontAwesome.Sharp.IconButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(12, 53);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(960, 496);
			this.dgView.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbltotalIn);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.iconbtnExport);
			this.panel1.Controls.Add(this.iconbtnReport);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.dateTimePickerTo);
			this.panel1.Controls.Add(this.dateTimePickerFrom);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 47);
			this.panel1.TabIndex = 4;
			// 
			// lbltotalIn
			// 
			this.lbltotalIn.AutoSize = true;
			this.lbltotalIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbltotalIn.ForeColor = System.Drawing.Color.Blue;
			this.lbltotalIn.Location = new System.Drawing.Point(470, 16);
			this.lbltotalIn.Name = "lbltotalIn";
			this.lbltotalIn.Size = new System.Drawing.Size(56, 13);
			this.lbltotalIn.TabIndex = 11;
			this.lbltotalIn.Text = "lbltotalIn";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(403, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Tổng tạo:";
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.Location = new System.Drawing.Point(895, 11);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(80, 23);
			this.iconbtnSearch.TabIndex = 8;
			this.iconbtnSearch.Text = "Tìm JIG trên chuyền";
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(745, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(145, 20);
			this.txtSearch.TabIndex = 7;
			// 
			// iconbtnExport
			// 
			this.iconbtnExport.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExport.IconColor = System.Drawing.Color.Black;
			this.iconbtnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExport.Location = new System.Drawing.Point(664, 11);
			this.iconbtnExport.Name = "iconbtnExport";
			this.iconbtnExport.Size = new System.Drawing.Size(75, 23);
			this.iconbtnExport.TabIndex = 5;
			this.iconbtnExport.Text = "Export CSV";
			this.iconbtnExport.UseVisualStyleBackColor = true;
			// 
			// iconbtnReport
			// 
			this.iconbtnReport.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnReport.IconColor = System.Drawing.Color.Black;
			this.iconbtnReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnReport.Location = new System.Drawing.Point(322, 11);
			this.iconbtnReport.Name = "iconbtnReport";
			this.iconbtnReport.Size = new System.Drawing.Size(75, 23);
			this.iconbtnReport.TabIndex = 4;
			this.iconbtnReport.Text = "Tìm kiếm";
			this.iconbtnReport.UseVisualStyleBackColor = true;
			this.iconbtnReport.Click += new System.EventHandler(this.iconbtnReport_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(166, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Từ ngày:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Từ ngày:";
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.CustomFormat = "yyyy/MM/dd";
			this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTo.Location = new System.Drawing.Point(221, 12);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(97, 20);
			this.dateTimePickerTo.TabIndex = 1;
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.CustomFormat = "yyyy/MM/dd";
			this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerFrom.Location = new System.Drawing.Point(62, 12);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(99, 20);
			this.dateTimePickerFrom.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 561);
			this.panel2.TabIndex = 5;
			// 
			// frmJigReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "frmJigReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông kê JIG";
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbltotalIn;
		private System.Windows.Forms.Label label3;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private FontAwesome.Sharp.IconButton iconbtnExport;
		private FontAwesome.Sharp.IconButton iconbtnReport;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePickerTo;
		private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
		private System.Windows.Forms.Panel panel2;
	}
}