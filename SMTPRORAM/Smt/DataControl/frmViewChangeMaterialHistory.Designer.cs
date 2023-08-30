namespace SMTPRORAM.Smt.DataControl
{
    partial class frmViewChangeMaterialHistory
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
			this.panelTop = new System.Windows.Forms.Panel();
			this.cbSelectSearch = new System.Windows.Forms.ComboBox();
			this.lbltotalPages = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblcurrentPage = new System.Windows.Forms.Label();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.iconbtnBefore = new FontAwesome.Sharp.IconButton();
			this.btExport = new System.Windows.Forms.Button();
			this.lblCount = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSearchPart = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPart = new System.Windows.Forms.TextBox();
			this.panelDesktop = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelTop.SuspendLayout();
			this.panelDesktop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.cbSelectSearch);
			this.panelTop.Controls.Add(this.lbltotalPages);
			this.panelTop.Controls.Add(this.label2);
			this.panelTop.Controls.Add(this.lblcurrentPage);
			this.panelTop.Controls.Add(this.iconbtnNext);
			this.panelTop.Controls.Add(this.iconbtnBefore);
			this.panelTop.Controls.Add(this.btExport);
			this.panelTop.Controls.Add(this.lblCount);
			this.panelTop.Controls.Add(this.label5);
			this.panelTop.Controls.Add(this.btnSearchPart);
			this.panelTop.Controls.Add(this.label4);
			this.panelTop.Controls.Add(this.txtPart);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(984, 56);
			this.panelTop.TabIndex = 0;
			// 
			// cbSelectSearch
			// 
			this.cbSelectSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSelectSearch.FormattingEnabled = true;
			this.cbSelectSearch.Items.AddRange(new object[] {
            "--Select--",
            "Program Key",
            "Part code"});
			this.cbSelectSearch.Location = new System.Drawing.Point(18, 18);
			this.cbSelectSearch.Name = "cbSelectSearch";
			this.cbSelectSearch.Size = new System.Drawing.Size(148, 21);
			this.cbSelectSearch.TabIndex = 0;
			// 
			// lbltotalPages
			// 
			this.lbltotalPages.AutoSize = true;
			this.lbltotalPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbltotalPages.ForeColor = System.Drawing.Color.Blue;
			this.lbltotalPages.Location = new System.Drawing.Point(761, 20);
			this.lbltotalPages.Name = "lbltotalPages";
			this.lbltotalPages.Size = new System.Drawing.Size(36, 13);
			this.lbltotalPages.TabIndex = 91;
			this.lbltotalPages.Text = "Tổng";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(748, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 13);
			this.label2.TabIndex = 90;
			this.label2.Text = "/";
			// 
			// lblcurrentPage
			// 
			this.lblcurrentPage.AutoSize = true;
			this.lblcurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblcurrentPage.ForeColor = System.Drawing.Color.Blue;
			this.lblcurrentPage.Location = new System.Drawing.Point(706, 20);
			this.lblcurrentPage.Name = "lblcurrentPage";
			this.lblcurrentPage.Size = new System.Drawing.Size(40, 13);
			this.lblcurrentPage.TabIndex = 89;
			this.lblcurrentPage.Text = "Trang";
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(803, 15);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(55, 23);
			this.iconbtnNext.TabIndex = 88;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			this.iconbtnNext.Click += new System.EventHandler(this.iconbtnNext_Click);
			// 
			// iconbtnBefore
			// 
			this.iconbtnBefore.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnBefore.IconColor = System.Drawing.Color.Black;
			this.iconbtnBefore.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnBefore.Location = new System.Drawing.Point(645, 15);
			this.iconbtnBefore.Name = "iconbtnBefore";
			this.iconbtnBefore.Size = new System.Drawing.Size(55, 23);
			this.iconbtnBefore.TabIndex = 87;
			this.iconbtnBefore.Text = "<";
			this.iconbtnBefore.UseVisualStyleBackColor = true;
			this.iconbtnBefore.Click += new System.EventHandler(this.iconbtnBefore_Click);
			// 
			// btExport
			// 
			this.btExport.Location = new System.Drawing.Point(875, 15);
			this.btExport.Name = "btExport";
			this.btExport.Size = new System.Drawing.Size(87, 23);
			this.btExport.TabIndex = 85;
			this.btExport.Text = "Export To CSV";
			this.btExport.UseVisualStyleBackColor = true;
			this.btExport.Click += new System.EventHandler(this.btExport_Click);
			// 
			// lblCount
			// 
			this.lblCount.AutoSize = true;
			this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCount.ForeColor = System.Drawing.Color.Red;
			this.lblCount.Location = new System.Drawing.Point(556, 18);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(44, 16);
			this.lblCount.TabIndex = 84;
			this.lblCount.Text = "count";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(501, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 13);
			this.label5.TabIndex = 83;
			this.label5.Text = "Tổng số:";
			// 
			// btnSearchPart
			// 
			this.btnSearchPart.Location = new System.Drawing.Point(412, 15);
			this.btnSearchPart.Name = "btnSearchPart";
			this.btnSearchPart.Size = new System.Drawing.Size(83, 23);
			this.btnSearchPart.TabIndex = 2;
			this.btnSearchPart.Text = "Search";
			this.btnSearchPart.UseVisualStyleBackColor = true;
			this.btnSearchPart.Click += new System.EventHandler(this.btnSearchPart_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(0, 13);
			this.label4.TabIndex = 81;
			// 
			// txtPart
			// 
			this.txtPart.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.txtPart.Location = new System.Drawing.Point(183, 17);
			this.txtPart.Name = "txtPart";
			this.txtPart.Size = new System.Drawing.Size(223, 20);
			this.txtPart.TabIndex = 1;
			this.txtPart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPart_KeyDown);
			// 
			// panelDesktop
			// 
			this.panelDesktop.Controls.Add(this.dgView);
			this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDesktop.Location = new System.Drawing.Point(0, 56);
			this.panelDesktop.Name = "panelDesktop";
			this.panelDesktop.Size = new System.Drawing.Size(984, 505);
			this.panelDesktop.TabIndex = 1;
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
			this.dgView.Size = new System.Drawing.Size(960, 487);
			this.dgView.TabIndex = 0;
			// 
			// frmViewChangeMaterialHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelDesktop);
			this.Controls.Add(this.panelTop);
			this.Name = "frmViewChangeMaterialHistory";
			this.Text = "Xem lịch sử thay linh kiện";
			this.Load += new System.EventHandler(this.frmViewChangeMaterialHistory_Load);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panelDesktop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchPart;
        private System.Windows.Forms.TextBox txtPart;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private FontAwesome.Sharp.IconButton iconbtnBefore;
		private System.Windows.Forms.Label lbltotalPages;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblcurrentPage;
		private System.Windows.Forms.ComboBox cbSelectSearch;
		private System.Windows.Forms.Label label4;
	}
}