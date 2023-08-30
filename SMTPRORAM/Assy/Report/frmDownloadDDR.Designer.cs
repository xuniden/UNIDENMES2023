namespace SMTPRORAM.Assy.Report
{
	partial class frmDownloadDDR
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
			this.tabPageDDRDate = new System.Windows.Forms.TabPage();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView02 = new System.Windows.Forms.DataGridView();
			this.panelTop = new System.Windows.Forms.Panel();
			this.tabPageDDRLot = new System.Windows.Forms.TabPage();
			this.panel1Content = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2Top = new System.Windows.Forms.Panel();
			this.lblError = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblOutput = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.cbLot = new System.Windows.Forms.ComboBox();
			this.tabControlDDR = new System.Windows.Forms.TabControl();
			this.dateFrom = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.iconbtnTim = new FontAwesome.Sharp.IconButton();
			this.iconButton1 = new FontAwesome.Sharp.IconButton();
			this.iconButton2 = new FontAwesome.Sharp.IconButton();
			this.tabPageDDRDate.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView02)).BeginInit();
			this.panelTop.SuspendLayout();
			this.tabPageDDRLot.SuspendLayout();
			this.panel1Content.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.panelLeft.SuspendLayout();
			this.panel2Top.SuspendLayout();
			this.tabControlDDR.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPageDDRDate
			// 
			this.tabPageDDRDate.Controls.Add(this.panelContent);
			this.tabPageDDRDate.Controls.Add(this.panelTop);
			this.tabPageDDRDate.Location = new System.Drawing.Point(4, 22);
			this.tabPageDDRDate.Name = "tabPageDDRDate";
			this.tabPageDDRDate.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDDRDate.Size = new System.Drawing.Size(976, 535);
			this.tabPageDDRDate.TabIndex = 1;
			this.tabPageDDRDate.Text = "Download DDR theo ngày tháng";
			this.tabPageDDRDate.UseVisualStyleBackColor = true;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView02);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(3, 50);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(970, 482);
			this.panelContent.TabIndex = 1;
			// 
			// dgView02
			// 
			this.dgView02.AllowUserToAddRows = false;
			this.dgView02.AllowUserToDeleteRows = false;
			this.dgView02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView02.Location = new System.Drawing.Point(5, 6);
			this.dgView02.Name = "dgView02";
			this.dgView02.ReadOnly = true;
			this.dgView02.Size = new System.Drawing.Size(960, 471);
			this.dgView02.TabIndex = 1;
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.iconButton1);
			this.panelTop.Controls.Add(this.iconbtnTim);
			this.panelTop.Controls.Add(this.label4);
			this.panelTop.Controls.Add(this.label3);
			this.panelTop.Controls.Add(this.dateTimePicker1);
			this.panelTop.Controls.Add(this.dateFrom);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(3, 3);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(970, 47);
			this.panelTop.TabIndex = 0;
			// 
			// tabPageDDRLot
			// 
			this.tabPageDDRLot.Controls.Add(this.panel1Content);
			this.tabPageDDRLot.Controls.Add(this.panel2Top);
			this.tabPageDDRLot.Location = new System.Drawing.Point(4, 22);
			this.tabPageDDRLot.Name = "tabPageDDRLot";
			this.tabPageDDRLot.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDDRLot.Size = new System.Drawing.Size(976, 535);
			this.tabPageDDRLot.TabIndex = 0;
			this.tabPageDDRLot.Text = "Download DDR theo lot";
			this.tabPageDDRLot.UseVisualStyleBackColor = true;
			// 
			// panel1Content
			// 
			this.panel1Content.Controls.Add(this.dgView);
			this.panel1Content.Controls.Add(this.panelLeft);
			this.panel1Content.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1Content.Location = new System.Drawing.Point(3, 50);
			this.panel1Content.Name = "panel1Content";
			this.panel1Content.Size = new System.Drawing.Size(970, 482);
			this.panel1Content.TabIndex = 3;
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(308, 8);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(657, 469);
			this.dgView.TabIndex = 2;
			// 
			// panelLeft
			// 
			this.panelLeft.AutoScroll = true;
			this.panelLeft.Controls.Add(this.panel1);
			this.panelLeft.Controls.Add(this.panel5);
			this.panelLeft.Controls.Add(this.panel4);
			this.panelLeft.Controls.Add(this.panel3);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(302, 482);
			this.panelLeft.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 500);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(285, 0);
			this.panel1.TabIndex = 4;
			// 
			// panel5
			// 
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 308);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(285, 192);
			this.panel5.TabIndex = 3;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 193);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(285, 115);
			this.panel4.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(285, 193);
			this.panel3.TabIndex = 1;
			// 
			// panel2Top
			// 
			this.panel2Top.Controls.Add(this.iconButton2);
			this.panel2Top.Controls.Add(this.lblError);
			this.panel2Top.Controls.Add(this.label2);
			this.panel2Top.Controls.Add(this.lblOutput);
			this.panel2Top.Controls.Add(this.label1);
			this.panel2Top.Controls.Add(this.iconbtnSearch);
			this.panel2Top.Controls.Add(this.cbLot);
			this.panel2Top.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2Top.Location = new System.Drawing.Point(3, 3);
			this.panel2Top.Name = "panel2Top";
			this.panel2Top.Size = new System.Drawing.Size(970, 47);
			this.panel2Top.TabIndex = 2;
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(763, 16);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(71, 13);
			this.lblError.TabIndex = 5;
			this.lblError.Text = "Tổng Error:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(677, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "/     Tổng Error:";
			// 
			// lblOutput
			// 
			this.lblOutput.AutoSize = true;
			this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblOutput.ForeColor = System.Drawing.Color.Blue;
			this.lblOutput.Location = new System.Drawing.Point(601, 16);
			this.lblOutput.Name = "lblOutput";
			this.lblOutput.Size = new System.Drawing.Size(82, 13);
			this.lblOutput.TabIndex = 3;
			this.lblOutput.Text = "Tổng Output:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(525, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tổng Output:";
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.Location = new System.Drawing.Point(444, 11);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSearch.TabIndex = 1;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// cbLot
			// 
			this.cbLot.FormattingEnabled = true;
			this.cbLot.Location = new System.Drawing.Point(308, 13);
			this.cbLot.Name = "cbLot";
			this.cbLot.Size = new System.Drawing.Size(121, 21);
			this.cbLot.TabIndex = 0;
			// 
			// tabControlDDR
			// 
			this.tabControlDDR.Controls.Add(this.tabPageDDRLot);
			this.tabControlDDR.Controls.Add(this.tabPageDDRDate);
			this.tabControlDDR.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlDDR.Location = new System.Drawing.Point(0, 0);
			this.tabControlDDR.Name = "tabControlDDR";
			this.tabControlDDR.SelectedIndex = 0;
			this.tabControlDDR.Size = new System.Drawing.Size(984, 561);
			this.tabControlDDR.TabIndex = 1;
			// 
			// dateFrom
			// 
			this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateFrom.Location = new System.Drawing.Point(64, 12);
			this.dateFrom.Name = "dateFrom";
			this.dateFrom.Size = new System.Drawing.Size(103, 20);
			this.dateFrom.TabIndex = 0;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(230, 12);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(103, 20);
			this.dateTimePicker1.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Từ ngày:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(173, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Tới ngày:";
			// 
			// iconbtnTim
			// 
			this.iconbtnTim.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnTim.IconColor = System.Drawing.Color.Black;
			this.iconbtnTim.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnTim.Location = new System.Drawing.Point(339, 11);
			this.iconbtnTim.Name = "iconbtnTim";
			this.iconbtnTim.Size = new System.Drawing.Size(75, 23);
			this.iconbtnTim.TabIndex = 4;
			this.iconbtnTim.Text = "Tìm kiếm";
			this.iconbtnTim.UseVisualStyleBackColor = true;
			this.iconbtnTim.Click += new System.EventHandler(this.iconbtnTim_Click);
			// 
			// iconButton1
			// 
			this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconButton1.IconColor = System.Drawing.Color.Black;
			this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconButton1.Location = new System.Drawing.Point(420, 12);
			this.iconButton1.Name = "iconButton1";
			this.iconButton1.Size = new System.Drawing.Size(75, 23);
			this.iconButton1.TabIndex = 5;
			this.iconButton1.Text = "Export CSV";
			this.iconButton1.UseVisualStyleBackColor = true;
			this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
			// 
			// iconButton2
			// 
			this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconButton2.IconColor = System.Drawing.Color.Black;
			this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconButton2.Location = new System.Drawing.Point(5, 11);
			this.iconButton2.Name = "iconButton2";
			this.iconButton2.Size = new System.Drawing.Size(75, 23);
			this.iconButton2.TabIndex = 6;
			this.iconButton2.Text = "Export CSV";
			this.iconButton2.UseVisualStyleBackColor = true;
			this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
			// 
			// frmDownloadDDR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tabControlDDR);
			this.Name = "frmDownloadDDR";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DOWNLOAD DDR";
			this.Load += new System.EventHandler(this.frmDownloadDDR_Load);
			this.tabPageDDRDate.ResumeLayout(false);
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView02)).EndInit();
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.tabPageDDRLot.ResumeLayout(false);
			this.panel1Content.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panelLeft.ResumeLayout(false);
			this.panel2Top.ResumeLayout(false);
			this.panel2Top.PerformLayout();
			this.tabControlDDR.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPageDDRDate;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.TabPage tabPageDDRLot;
		private System.Windows.Forms.TabControl tabControlDDR;
		private System.Windows.Forms.Panel panel1Content;
		private System.Windows.Forms.Panel panel2Top;
		private System.Windows.Forms.DataGridView dgView02;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.ComboBox cbLot;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.Label lblError;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblOutput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateFrom;
		private FontAwesome.Sharp.IconButton iconbtnTim;
		private FontAwesome.Sharp.IconButton iconButton1;
		private FontAwesome.Sharp.IconButton iconButton2;
	}
}