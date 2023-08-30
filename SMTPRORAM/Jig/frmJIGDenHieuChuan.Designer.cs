namespace SMTPRORAM.Jig
{
    partial class frmJIGDenHieuChuan
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
			this.iconbtnKhonghieuchuanVabaoduong = new FontAwesome.Sharp.IconButton();
			this.iconbtnKhongHieuChuan = new FontAwesome.Sharp.IconButton();
			this.iconbtnHieuChuanNgoai = new FontAwesome.Sharp.IconButton();
			this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.iconbtnList = new FontAwesome.Sharp.IconButton();
			this.iconbtnExport = new FontAwesome.Sharp.IconButton();
			this.iconbtnLoad = new FontAwesome.Sharp.IconButton();
			this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
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
			this.panel1.Controls.Add(this.iconbtnKhonghieuchuanVabaoduong);
			this.panel1.Controls.Add(this.iconbtnKhongHieuChuan);
			this.panel1.Controls.Add(this.iconbtnHieuChuanNgoai);
			this.panel1.Controls.Add(this.dateTimePickerTo);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.iconbtnList);
			this.panel1.Controls.Add(this.iconbtnExport);
			this.panel1.Controls.Add(this.iconbtnLoad);
			this.panel1.Controls.Add(this.dateTimePickerFrom);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 51);
			this.panel1.TabIndex = 0;
			// 
			// iconbtnKhonghieuchuanVabaoduong
			// 
			this.iconbtnKhonghieuchuanVabaoduong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnKhonghieuchuanVabaoduong.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnKhonghieuchuanVabaoduong.IconColor = System.Drawing.Color.Black;
			this.iconbtnKhonghieuchuanVabaoduong.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnKhonghieuchuanVabaoduong.Location = new System.Drawing.Point(741, 3);
			this.iconbtnKhonghieuchuanVabaoduong.Name = "iconbtnKhonghieuchuanVabaoduong";
			this.iconbtnKhonghieuchuanVabaoduong.Size = new System.Drawing.Size(113, 42);
			this.iconbtnKhonghieuchuanVabaoduong.TabIndex = 11;
			this.iconbtnKhonghieuchuanVabaoduong.Text = "Không hiệu chuẩn và bảo dưỡng";
			this.iconbtnKhonghieuchuanVabaoduong.UseVisualStyleBackColor = true;
			this.iconbtnKhonghieuchuanVabaoduong.Click += new System.EventHandler(this.iconbtnKhonghieuchuanVabaoduong_Click);
			// 
			// iconbtnKhongHieuChuan
			// 
			this.iconbtnKhongHieuChuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnKhongHieuChuan.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnKhongHieuChuan.IconColor = System.Drawing.Color.Black;
			this.iconbtnKhongHieuChuan.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnKhongHieuChuan.Location = new System.Drawing.Point(631, 10);
			this.iconbtnKhongHieuChuan.Name = "iconbtnKhongHieuChuan";
			this.iconbtnKhongHieuChuan.Size = new System.Drawing.Size(104, 23);
			this.iconbtnKhongHieuChuan.TabIndex = 10;
			this.iconbtnKhongHieuChuan.Text = "Không hiệu chuẩn";
			this.iconbtnKhongHieuChuan.UseVisualStyleBackColor = true;
			this.iconbtnKhongHieuChuan.Click += new System.EventHandler(this.iconbtnKhongHieuChuan_Click);
			// 
			// iconbtnHieuChuanNgoai
			// 
			this.iconbtnHieuChuanNgoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnHieuChuanNgoai.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnHieuChuanNgoai.IconColor = System.Drawing.Color.Black;
			this.iconbtnHieuChuanNgoai.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnHieuChuanNgoai.Location = new System.Drawing.Point(522, 9);
			this.iconbtnHieuChuanNgoai.Name = "iconbtnHieuChuanNgoai";
			this.iconbtnHieuChuanNgoai.Size = new System.Drawing.Size(103, 23);
			this.iconbtnHieuChuanNgoai.TabIndex = 9;
			this.iconbtnHieuChuanNgoai.Text = "Hiệu chuẩn ngoài";
			this.iconbtnHieuChuanNgoai.UseVisualStyleBackColor = true;
			this.iconbtnHieuChuanNgoai.Click += new System.EventHandler(this.iconbtnHieuChuanNgoai_Click);
			// 
			// dateTimePickerTo
			// 
			this.dateTimePickerTo.CustomFormat = "yyyy/MM/dd";
			this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerTo.Location = new System.Drawing.Point(220, 12);
			this.dateTimePickerTo.Name = "dateTimePickerTo";
			this.dateTimePickerTo.Size = new System.Drawing.Size(101, 20);
			this.dateTimePickerTo.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(165, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Tới ngày:";
			// 
			// iconbtnList
			// 
			this.iconbtnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnList.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnList.IconColor = System.Drawing.Color.Black;
			this.iconbtnList.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnList.Location = new System.Drawing.Point(426, 9);
			this.iconbtnList.Name = "iconbtnList";
			this.iconbtnList.Size = new System.Drawing.Size(90, 23);
			this.iconbtnList.TabIndex = 4;
			this.iconbtnList.Text = "Cần bảo dưỡng";
			this.iconbtnList.UseVisualStyleBackColor = true;
			this.iconbtnList.Click += new System.EventHandler(this.iconbtnList_Click);
			// 
			// iconbtnExport
			// 
			this.iconbtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnExport.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExport.IconColor = System.Drawing.Color.Black;
			this.iconbtnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExport.Location = new System.Drawing.Point(906, 9);
			this.iconbtnExport.Name = "iconbtnExport";
			this.iconbtnExport.Size = new System.Drawing.Size(75, 23);
			this.iconbtnExport.TabIndex = 3;
			this.iconbtnExport.Text = "Export CSV";
			this.iconbtnExport.UseVisualStyleBackColor = true;
			this.iconbtnExport.Click += new System.EventHandler(this.iconbtnExport_Click);
			// 
			// iconbtnLoad
			// 
			this.iconbtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnLoad.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLoad.IconColor = System.Drawing.Color.Black;
			this.iconbtnLoad.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLoad.Location = new System.Drawing.Point(325, 9);
			this.iconbtnLoad.Name = "iconbtnLoad";
			this.iconbtnLoad.Size = new System.Drawing.Size(95, 23);
			this.iconbtnLoad.TabIndex = 2;
			this.iconbtnLoad.Text = "Cần hiệu chuẩn";
			this.iconbtnLoad.UseVisualStyleBackColor = true;
			this.iconbtnLoad.Click += new System.EventHandler(this.iconbtnLoad_Click);
			// 
			// dateTimePickerFrom
			// 
			this.dateTimePickerFrom.CustomFormat = "yyyy/MM/dd";
			this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerFrom.Location = new System.Drawing.Point(58, 12);
			this.dateTimePickerFrom.Name = "dateTimePickerFrom";
			this.dateTimePickerFrom.Size = new System.Drawing.Size(101, 20);
			this.dateTimePickerFrom.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ ngày:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 51);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 510);
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
			this.dgView.Location = new System.Drawing.Point(12, 6);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(960, 492);
			this.dgView.TabIndex = 0;
			// 
			// frmJIGDenHieuChuan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmJIGDenHieuChuan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DANH SÁCH THIẾT BỊ ĐẾN HẠN HIỆU CHỈNH";
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
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconbtnLoad;
        private FontAwesome.Sharp.IconButton iconbtnExport;
        private FontAwesome.Sharp.IconButton iconbtnList;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconbtnKhongHieuChuan;
        private FontAwesome.Sharp.IconButton iconbtnHieuChuanNgoai;
        private FontAwesome.Sharp.IconButton iconbtnKhonghieuchuanVabaoduong;
    }
}