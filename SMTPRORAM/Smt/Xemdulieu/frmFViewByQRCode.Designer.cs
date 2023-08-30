namespace SMTPRORAM.Smt.View
{
    partial class frmFViewByQRCode
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
			this.lblRecod = new System.Windows.Forms.Label();
			this.btFind = new System.Windows.Forms.Button();
			this.dtp_2 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.dtp_1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.btToCsv = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtQRCode = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.cbSelect = new System.Windows.Forms.ComboBox();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.lblCurrentPage = new System.Windows.Forms.Label();
			this.lbltotalPages = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.lbltotalPages);
			this.panel1.Controls.Add(this.lblCurrentPage);
			this.panel1.Controls.Add(this.iconbtnNext);
			this.panel1.Controls.Add(this.iconbtnPrev);
			this.panel1.Controls.Add(this.cbSelect);
			this.panel1.Controls.Add(this.lblRecod);
			this.panel1.Controls.Add(this.btFind);
			this.panel1.Controls.Add(this.dtp_2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.dtp_1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btToCsv);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.txtQRCode);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 59);
			this.panel1.TabIndex = 0;
			// 
			// lblRecod
			// 
			this.lblRecod.AutoSize = true;
			this.lblRecod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblRecod.ForeColor = System.Drawing.Color.Blue;
			this.lblRecod.Location = new System.Drawing.Point(675, 39);
			this.lblRecod.Name = "lblRecod";
			this.lblRecod.Size = new System.Drawing.Size(41, 13);
			this.lblRecod.TabIndex = 32;
			this.lblRecod.Text = "label5";
			// 
			// btFind
			// 
			this.btFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btFind.Location = new System.Drawing.Point(595, 8);
			this.btFind.Name = "btFind";
			this.btFind.Size = new System.Drawing.Size(74, 23);
			this.btFind.TabIndex = 31;
			this.btFind.Text = "Tìm Kiếm";
			this.btFind.UseVisualStyleBackColor = true;
			this.btFind.Click += new System.EventHandler(this.btFind_Click);
			// 
			// dtp_2
			// 
			this.dtp_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtp_2.Location = new System.Drawing.Point(491, 9);
			this.dtp_2.Name = "dtp_2";
			this.dtp_2.Size = new System.Drawing.Size(98, 20);
			this.dtp_2.TabIndex = 30;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(429, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Đến ngày:";
			// 
			// dtp_1
			// 
			this.dtp_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp_1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtp_1.Location = new System.Drawing.Point(320, 9);
			this.dtp_1.Name = "dtp_1";
			this.dtp_1.Size = new System.Drawing.Size(103, 20);
			this.dtp_1.TabIndex = 28;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(265, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Từ ngày:";
			// 
			// btToCsv
			// 
			this.btToCsv.Location = new System.Drawing.Point(675, 8);
			this.btToCsv.Name = "btToCsv";
			this.btToCsv.Size = new System.Drawing.Size(79, 22);
			this.btToCsv.TabIndex = 26;
			this.btToCsv.Text = "Export Csv";
			this.btToCsv.UseVisualStyleBackColor = true;
			this.btToCsv.Click += new System.EventHandler(this.btToCsv_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(605, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Total Rows:";
			// 
			// txtQRCode
			// 
			this.txtQRCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQRCode.Location = new System.Drawing.Point(139, 9);
			this.txtQRCode.Name = "txtQRCode";
			this.txtQRCode.Size = new System.Drawing.Size(120, 20);
			this.txtQRCode.TabIndex = 16;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 59);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 502);
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
			this.dgView.Location = new System.Drawing.Point(3, 0);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(978, 499);
			this.dgView.TabIndex = 0;
			// 
			// cbSelect
			// 
			this.cbSelect.FormattingEnabled = true;
			this.cbSelect.Items.AddRange(new object[] {
            "--Select--",
            "QRCode",
            "Partcode"});
			this.cbSelect.Location = new System.Drawing.Point(12, 9);
			this.cbSelect.Name = "cbSelect";
			this.cbSelect.Size = new System.Drawing.Size(121, 21);
			this.cbSelect.TabIndex = 33;
			// 
			// iconbtnPrev
			// 
			this.iconbtnPrev.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrev.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrev.Location = new System.Drawing.Point(760, 8);
			this.iconbtnPrev.Name = "iconbtnPrev";
			this.iconbtnPrev.Size = new System.Drawing.Size(34, 23);
			this.iconbtnPrev.TabIndex = 34;
			this.iconbtnPrev.Text = "<";
			this.iconbtnPrev.UseVisualStyleBackColor = true;
			this.iconbtnPrev.Click += new System.EventHandler(this.iconbtnPrev_Click);
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(878, 8);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(34, 23);
			this.iconbtnNext.TabIndex = 35;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			this.iconbtnNext.Click += new System.EventHandler(this.iconbtnNext_Click);
			// 
			// lblCurrentPage
			// 
			this.lblCurrentPage.AutoSize = true;
			this.lblCurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblCurrentPage.ForeColor = System.Drawing.Color.Blue;
			this.lblCurrentPage.Location = new System.Drawing.Point(793, 13);
			this.lblCurrentPage.Name = "lblCurrentPage";
			this.lblCurrentPage.Size = new System.Drawing.Size(34, 13);
			this.lblCurrentPage.TabIndex = 36;
			this.lblCurrentPage.Text = "CurP";
			// 
			// lbltotalPages
			// 
			this.lbltotalPages.AutoSize = true;
			this.lbltotalPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbltotalPages.ForeColor = System.Drawing.Color.Blue;
			this.lbltotalPages.Location = new System.Drawing.Point(838, 13);
			this.lbltotalPages.Name = "lbltotalPages";
			this.lbltotalPages.Size = new System.Drawing.Size(26, 13);
			this.lbltotalPages.TabIndex = 37;
			this.lbltotalPages.Text = "Tot";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(826, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 13);
			this.label5.TabIndex = 38;
			this.label5.Text = "/";
			// 
			// frmFViewByQRCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmFViewByQRCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XEM DỮ LIỆU OUTPUT THEO QR CODE VA NGÀY THÁNG";
			this.Load += new System.EventHandler(this.frmFViewByQRCode_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Button btToCsv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.DateTimePicker dtp_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecod;
		private System.Windows.Forms.ComboBox cbSelect;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
		private System.Windows.Forms.Label lblCurrentPage;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbltotalPages;
	}
}