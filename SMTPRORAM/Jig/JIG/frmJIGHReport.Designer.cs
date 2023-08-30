namespace SMTPRORAM.Jig.JIG
{
    partial class frmJIGHReport
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
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.iconbtnExport = new FontAwesome.Sharp.IconButton();
			this.iconbtnTim = new FontAwesome.Sharp.IconButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lbltotalIn = new System.Windows.Forms.Label();
			this.lbltotalOut = new System.Windows.Forms.Label();
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
			this.panel1.Controls.Add(this.lbltotalOut);
			this.panel1.Controls.Add(this.lbltotalIn);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.iconbtnExport);
			this.panel1.Controls.Add(this.iconbtnTim);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.dateTimePickerTo);
			this.panel1.Controls.Add(this.dateTimePickerFrom);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 47);
			this.panel1.TabIndex = 2;
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
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(745, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(145, 20);
			this.txtSearch.TabIndex = 7;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
			this.iconbtnExport.Click += new System.EventHandler(this.iconbtnExport_Click);
			// 
			// iconbtnTim
			// 
			this.iconbtnTim.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnTim.IconColor = System.Drawing.Color.Black;
			this.iconbtnTim.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnTim.Location = new System.Drawing.Point(322, 11);
			this.iconbtnTim.Name = "iconbtnTim";
			this.iconbtnTim.Size = new System.Drawing.Size(75, 23);
			this.iconbtnTim.TabIndex = 4;
			this.iconbtnTim.Text = "Tìm kiếm";
			this.iconbtnTim.UseVisualStyleBackColor = true;
			this.iconbtnTim.Click += new System.EventHandler(this.iconbtnTim_Click);
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
			this.panel2.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(403, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Tổng Nhập:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(534, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Tổng xuất:";
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
			// lbltotalOut
			// 
			this.lbltotalOut.AutoSize = true;
			this.lbltotalOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbltotalOut.ForeColor = System.Drawing.Color.Blue;
			this.lbltotalOut.Location = new System.Drawing.Point(593, 16);
			this.lbltotalOut.Name = "lbltotalOut";
			this.lbltotalOut.Size = new System.Drawing.Size(65, 13);
			this.lbltotalOut.TabIndex = 12;
			this.lbltotalOut.Text = "lbltotalOut";
			// 
			// frmJIGHReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "frmJIGHReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BÁO CÁO XUẤT NHẬP JIG";
			this.Load += new System.EventHandler(this.frmJIGHReport_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconbtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private FontAwesome.Sharp.IconButton iconbtnExport;
        private FontAwesome.Sharp.IconButton iconbtnTim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbltotalOut;
		private System.Windows.Forms.Label lbltotalIn;
	}
}