namespace SMTPRORAM.Assy.Report
{
	partial class frmFromQRToHistory
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
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtUnitCode = new System.Windows.Forms.TextBox();
			this.panelContent = new System.Windows.Forms.Panel();
			this.panelRepairAssy = new System.Windows.Forms.Panel();
			this.dgViewRepairAssy = new System.Windows.Forms.DataGridView();
			this.panelDept = new System.Windows.Forms.Panel();
			this.dgViewDept = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelRepairSMT = new System.Windows.Forms.Panel();
			this.dgViewRepairSMT = new System.Windows.Forms.DataGridView();
			this.panelAssy = new System.Windows.Forms.Panel();
			this.dgViewAssy = new System.Windows.Forms.DataGridView();
			this.panelSMT = new System.Windows.Forms.Panel();
			this.dgViewSMT = new System.Windows.Forms.DataGridView();
			this.panelTop01 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgViewJ = new System.Windows.Forms.DataGridView();
			this.iconbtnExport = new FontAwesome.Sharp.IconButton();
			this.panelTop.SuspendLayout();
			this.panelContent.SuspendLayout();
			this.panelRepairAssy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewRepairAssy)).BeginInit();
			this.panelDept.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewDept)).BeginInit();
			this.panel2.SuspendLayout();
			this.panelRepairSMT.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewRepairSMT)).BeginInit();
			this.panelAssy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewAssy)).BeginInit();
			this.panelSMT.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewSMT)).BeginInit();
			this.panelTop01.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgViewJ)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.iconbtnExport);
			this.panelTop.Controls.Add(this.iconbtnSearch);
			this.panelTop.Controls.Add(this.txtUnitCode);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(984, 38);
			this.panelTop.TabIndex = 0;
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.Location = new System.Drawing.Point(182, 6);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSearch.TabIndex = 1;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// txtUnitCode
			// 
			this.txtUnitCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUnitCode.Location = new System.Drawing.Point(12, 8);
			this.txtUnitCode.Name = "txtUnitCode";
			this.txtUnitCode.Size = new System.Drawing.Size(164, 20);
			this.txtUnitCode.TabIndex = 0;
			this.txtUnitCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnitCode_KeyDown);
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.panelRepairAssy);
			this.panelContent.Controls.Add(this.panelDept);
			this.panelContent.Controls.Add(this.panel2);
			this.panelContent.Controls.Add(this.panelSMT);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 38);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 523);
			this.panelContent.TabIndex = 1;
			// 
			// panelRepairAssy
			// 
			this.panelRepairAssy.Controls.Add(this.dgViewRepairAssy);
			this.panelRepairAssy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRepairAssy.Location = new System.Drawing.Point(536, 431);
			this.panelRepairAssy.Name = "panelRepairAssy";
			this.panelRepairAssy.Size = new System.Drawing.Size(448, 92);
			this.panelRepairAssy.TabIndex = 3;
			// 
			// dgViewRepairAssy
			// 
			this.dgViewRepairAssy.AllowUserToAddRows = false;
			this.dgViewRepairAssy.AllowUserToDeleteRows = false;
			this.dgViewRepairAssy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewRepairAssy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewRepairAssy.Location = new System.Drawing.Point(6, 8);
			this.dgViewRepairAssy.Name = "dgViewRepairAssy";
			this.dgViewRepairAssy.ReadOnly = true;
			this.dgViewRepairAssy.Size = new System.Drawing.Size(430, 72);
			this.dgViewRepairAssy.TabIndex = 0;
			// 
			// panelDept
			// 
			this.panelDept.Controls.Add(this.dgViewDept);
			this.panelDept.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelDept.Location = new System.Drawing.Point(536, 231);
			this.panelDept.Name = "panelDept";
			this.panelDept.Size = new System.Drawing.Size(448, 200);
			this.panelDept.TabIndex = 2;
			// 
			// dgViewDept
			// 
			this.dgViewDept.AllowUserToAddRows = false;
			this.dgViewDept.AllowUserToDeleteRows = false;
			this.dgViewDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewDept.Location = new System.Drawing.Point(6, 6);
			this.dgViewDept.Name = "dgViewDept";
			this.dgViewDept.ReadOnly = true;
			this.dgViewDept.Size = new System.Drawing.Size(430, 188);
			this.dgViewDept.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panelRepairSMT);
			this.panel2.Controls.Add(this.panelAssy);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 231);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(536, 292);
			this.panel2.TabIndex = 1;
			// 
			// panelRepairSMT
			// 
			this.panelRepairSMT.Controls.Add(this.dgViewRepairSMT);
			this.panelRepairSMT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRepairSMT.Location = new System.Drawing.Point(0, 200);
			this.panelRepairSMT.Name = "panelRepairSMT";
			this.panelRepairSMT.Size = new System.Drawing.Size(536, 92);
			this.panelRepairSMT.TabIndex = 1;
			// 
			// dgViewRepairSMT
			// 
			this.dgViewRepairSMT.AllowUserToAddRows = false;
			this.dgViewRepairSMT.AllowUserToDeleteRows = false;
			this.dgViewRepairSMT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewRepairSMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewRepairSMT.Location = new System.Drawing.Point(12, 8);
			this.dgViewRepairSMT.Name = "dgViewRepairSMT";
			this.dgViewRepairSMT.ReadOnly = true;
			this.dgViewRepairSMT.Size = new System.Drawing.Size(518, 72);
			this.dgViewRepairSMT.TabIndex = 0;
			// 
			// panelAssy
			// 
			this.panelAssy.Controls.Add(this.dgViewAssy);
			this.panelAssy.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelAssy.Location = new System.Drawing.Point(0, 0);
			this.panelAssy.Name = "panelAssy";
			this.panelAssy.Size = new System.Drawing.Size(536, 200);
			this.panelAssy.TabIndex = 0;
			// 
			// dgViewAssy
			// 
			this.dgViewAssy.AllowUserToAddRows = false;
			this.dgViewAssy.AllowUserToDeleteRows = false;
			this.dgViewAssy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewAssy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewAssy.Location = new System.Drawing.Point(12, 6);
			this.dgViewAssy.Name = "dgViewAssy";
			this.dgViewAssy.ReadOnly = true;
			this.dgViewAssy.Size = new System.Drawing.Size(518, 188);
			this.dgViewAssy.TabIndex = 0;
			// 
			// panelSMT
			// 
			this.panelSMT.Controls.Add(this.panel1);
			this.panelSMT.Controls.Add(this.panelTop01);
			this.panelSMT.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSMT.Location = new System.Drawing.Point(0, 0);
			this.panelSMT.Name = "panelSMT";
			this.panelSMT.Size = new System.Drawing.Size(984, 231);
			this.panelSMT.TabIndex = 0;
			// 
			// dgViewSMT
			// 
			this.dgViewSMT.AllowUserToAddRows = false;
			this.dgViewSMT.AllowUserToDeleteRows = false;
			this.dgViewSMT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewSMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewSMT.Location = new System.Drawing.Point(12, 6);
			this.dgViewSMT.Name = "dgViewSMT";
			this.dgViewSMT.ReadOnly = true;
			this.dgViewSMT.Size = new System.Drawing.Size(617, 219);
			this.dgViewSMT.TabIndex = 0;
			// 
			// panelTop01
			// 
			this.panelTop01.Controls.Add(this.dgViewSMT);
			this.panelTop01.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelTop01.Location = new System.Drawing.Point(0, 0);
			this.panelTop01.Name = "panelTop01";
			this.panelTop01.Size = new System.Drawing.Size(635, 231);
			this.panelTop01.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgViewJ);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(635, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(349, 231);
			this.panel1.TabIndex = 1;
			// 
			// dgViewJ
			// 
			this.dgViewJ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgViewJ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgViewJ.Location = new System.Drawing.Point(6, 6);
			this.dgViewJ.Name = "dgViewJ";
			this.dgViewJ.Size = new System.Drawing.Size(331, 219);
			this.dgViewJ.TabIndex = 0;
			// 
			// iconbtnExport
			// 
			this.iconbtnExport.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnExport.IconColor = System.Drawing.Color.Black;
			this.iconbtnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnExport.Location = new System.Drawing.Point(263, 6);
			this.iconbtnExport.Name = "iconbtnExport";
			this.iconbtnExport.Size = new System.Drawing.Size(92, 23);
			this.iconbtnExport.TabIndex = 2;
			this.iconbtnExport.Text = "Export to Excel";
			this.iconbtnExport.UseVisualStyleBackColor = true;
			this.iconbtnExport.Click += new System.EventHandler(this.iconbtnExport_Click);
			// 
			// frmFromQRToHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelTop);
			this.Name = "frmFromQRToHistory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TRA CỨU LỊCH SỬ THEO UNIT SERIAL";
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panelContent.ResumeLayout(false);
			this.panelRepairAssy.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewRepairAssy)).EndInit();
			this.panelDept.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewDept)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panelRepairSMT.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewRepairSMT)).EndInit();
			this.panelAssy.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewAssy)).EndInit();
			this.panelSMT.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewSMT)).EndInit();
			this.panelTop01.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgViewJ)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelTop;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.TextBox txtUnitCode;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Panel panelRepairAssy;
		private System.Windows.Forms.Panel panelDept;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panelRepairSMT;
		private System.Windows.Forms.Panel panelAssy;
		private System.Windows.Forms.Panel panelSMT;
		private System.Windows.Forms.DataGridView dgViewSMT;
		private System.Windows.Forms.DataGridView dgViewRepairSMT;
		private System.Windows.Forms.DataGridView dgViewAssy;
		private System.Windows.Forms.DataGridView dgViewRepairAssy;
		private System.Windows.Forms.DataGridView dgViewDept;
		private System.Windows.Forms.Panel panelTop01;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgViewJ;
		private FontAwesome.Sharp.IconButton iconbtnExport;
	}
}