﻿namespace SMTPRORAM.Jig.JIG
{
    partial class frmViewAllJIG
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
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblview = new System.Windows.Forms.Label();
			this.Cbo_USB = new System.Windows.Forms.ComboBox();
			this.RBtn_USB = new System.Windows.Forms.RadioButton();
			this.iconbtnPrint = new FontAwesome.Sharp.IconButton();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.iconbtnExport = new FontAwesome.Sharp.IconButton();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.iconbtnExport);
			this.panel1.Controls.Add(this.lblTotal);
			this.panel1.Controls.Add(this.lblview);
			this.panel1.Controls.Add(this.Cbo_USB);
			this.panel1.Controls.Add(this.RBtn_USB);
			this.panel1.Controls.Add(this.iconbtnPrint);
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 45);
			this.panel1.TabIndex = 0;
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblTotal.ForeColor = System.Drawing.Color.Blue;
			this.lblTotal.Location = new System.Drawing.Point(425, 15);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(92, 13);
			this.lblTotal.TabIndex = 35;
			this.lblTotal.Text = "Đếm số thiết bị";
			// 
			// lblview
			// 
			this.lblview.AutoSize = true;
			this.lblview.Location = new System.Drawing.Point(350, 15);
			this.lblview.Name = "lblview";
			this.lblview.Size = new System.Drawing.Size(69, 13);
			this.lblview.TabIndex = 34;
			this.lblview.Text = "Tổng thiết bị:";
			// 
			// Cbo_USB
			// 
			this.Cbo_USB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Cbo_USB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Cbo_USB.FormattingEnabled = true;
			this.Cbo_USB.Location = new System.Drawing.Point(729, 11);
			this.Cbo_USB.Name = "Cbo_USB";
			this.Cbo_USB.Size = new System.Drawing.Size(162, 21);
			this.Cbo_USB.TabIndex = 33;
			// 
			// RBtn_USB
			// 
			this.RBtn_USB.AutoSize = true;
			this.RBtn_USB.Checked = true;
			this.RBtn_USB.Location = new System.Drawing.Point(676, 13);
			this.RBtn_USB.Name = "RBtn_USB";
			this.RBtn_USB.Size = new System.Drawing.Size(47, 17);
			this.RBtn_USB.TabIndex = 32;
			this.RBtn_USB.TabStop = true;
			this.RBtn_USB.Text = "USB";
			this.RBtn_USB.UseVisualStyleBackColor = true;
			// 
			// iconbtnPrint
			// 
			this.iconbtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.iconbtnPrint.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrint.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrint.Location = new System.Drawing.Point(897, 10);
			this.iconbtnPrint.Name = "iconbtnPrint";
			this.iconbtnPrint.Size = new System.Drawing.Size(75, 23);
			this.iconbtnPrint.TabIndex = 31;
			this.iconbtnPrint.Text = "In Tem";
			this.iconbtnPrint.UseVisualStyleBackColor = true;
			this.iconbtnPrint.Click += new System.EventHandler(this.iconbtnPrint_Click);
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.Location = new System.Drawing.Point(269, 10);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSearch.TabIndex = 3;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(12, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(251, 20);
			this.txtSearch.TabIndex = 2;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 45);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 516);
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
			this.dgView.Location = new System.Drawing.Point(3, 6);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(978, 507);
			this.dgView.TabIndex = 0;
			this.dgView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_CellMouseClick);
			this.dgView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgView_MouseDoubleClick);
			// 
			// iconbtnExport
			// 
			this.iconbtnExport.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExport.IconColor = System.Drawing.Color.Black;
			this.iconbtnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExport.Location = new System.Drawing.Point(544, 10);
			this.iconbtnExport.Name = "iconbtnExport";
			this.iconbtnExport.Size = new System.Drawing.Size(75, 23);
			this.iconbtnExport.TabIndex = 36;
			this.iconbtnExport.Text = "Export CSV";
			this.iconbtnExport.UseVisualStyleBackColor = true;
			this.iconbtnExport.Click += new System.EventHandler(this.iconbtnExport_Click);
			// 
			// frmViewAllJIG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmViewAllJIG";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XEM THÔNG TIN JIG";
			this.Load += new System.EventHandler(this.frmViewAllJIG_Load);
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
        private FontAwesome.Sharp.IconButton iconbtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox Cbo_USB;
        private System.Windows.Forms.RadioButton RBtn_USB;
        private FontAwesome.Sharp.IconButton iconbtnPrint;
		private System.Windows.Forms.Label lblview;
		private System.Windows.Forms.Label lblTotal;
		private FontAwesome.Sharp.IconButton iconbtnExport;
	}
}