namespace SMTPRORAM.AssyLine.VIEW
{
	partial class frmViewCBData
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
			this.iconbtnLast = new FontAwesome.Sharp.IconButton();
			this.label2 = new System.Windows.Forms.Label();
			this.iconbtnFirst = new FontAwesome.Sharp.IconButton();
			this.label1 = new System.Windows.Forms.Label();
			this.labelPageInfo = new System.Windows.Forms.Label();
			this.lblSoluong = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblLotSize = new System.Windows.Forms.Label();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.btDownloadCSV = new System.Windows.Forms.Button();
			this.labelTotalRecords = new System.Windows.Forms.Label();
			this.btLotLoad = new System.Windows.Forms.Button();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.txtLot = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelTop.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.iconbtnLast);
			this.panelTop.Controls.Add(this.label2);
			this.panelTop.Controls.Add(this.iconbtnFirst);
			this.panelTop.Controls.Add(this.label1);
			this.panelTop.Controls.Add(this.labelPageInfo);
			this.panelTop.Controls.Add(this.lblSoluong);
			this.panelTop.Controls.Add(this.label5);
			this.panelTop.Controls.Add(this.lblLotSize);
			this.panelTop.Controls.Add(this.iconbtnNext);
			this.panelTop.Controls.Add(this.btDownloadCSV);
			this.panelTop.Controls.Add(this.labelTotalRecords);
			this.panelTop.Controls.Add(this.btLotLoad);
			this.panelTop.Controls.Add(this.iconbtnPrev);
			this.panelTop.Controls.Add(this.txtLot);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(984, 47);
			this.panelTop.TabIndex = 0;
			// 
			// iconbtnLast
			// 
			this.iconbtnLast.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLast.IconColor = System.Drawing.Color.Black;
			this.iconbtnLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLast.Location = new System.Drawing.Point(693, 11);
			this.iconbtnLast.Name = "iconbtnLast";
			this.iconbtnLast.Size = new System.Drawing.Size(34, 23);
			this.iconbtnLast.TabIndex = 59;
			this.iconbtnLast.Text = ">>";
			this.iconbtnLast.UseVisualStyleBackColor = true;
			this.iconbtnLast.Click += new System.EventHandler(this.iconbtnLast_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(859, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Lot Size:";
			// 
			// iconbtnFirst
			// 
			this.iconbtnFirst.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnFirst.IconColor = System.Drawing.Color.Black;
			this.iconbtnFirst.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnFirst.Location = new System.Drawing.Point(495, 11);
			this.iconbtnFirst.Name = "iconbtnFirst";
			this.iconbtnFirst.Size = new System.Drawing.Size(34, 23);
			this.iconbtnFirst.TabIndex = 58;
			this.iconbtnFirst.Text = "<<";
			this.iconbtnFirst.UseVisualStyleBackColor = true;
			this.iconbtnFirst.Click += new System.EventHandler(this.iconbtnFirst_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(733, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Số lượng:";
			// 
			// labelPageInfo
			// 
			this.labelPageInfo.AutoSize = true;
			this.labelPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelPageInfo.ForeColor = System.Drawing.Color.Blue;
			this.labelPageInfo.Location = new System.Drawing.Point(576, 16);
			this.labelPageInfo.Name = "labelPageInfo";
			this.labelPageInfo.Size = new System.Drawing.Size(34, 13);
			this.labelPageInfo.TabIndex = 57;
			this.labelPageInfo.Text = "CurP";
			// 
			// lblSoluong
			// 
			this.lblSoluong.AutoSize = true;
			this.lblSoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblSoluong.ForeColor = System.Drawing.Color.Blue;
			this.lblSoluong.Location = new System.Drawing.Point(796, 16);
			this.lblSoluong.Name = "lblSoluong";
			this.lblSoluong.Size = new System.Drawing.Size(57, 13);
			this.lblSoluong.TabIndex = 14;
			this.lblSoluong.Text = "Số lượng";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(325, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 53;
			this.label5.Text = "Total Rows:";
			// 
			// lblLotSize
			// 
			this.lblLotSize.AutoSize = true;
			this.lblLotSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblLotSize.ForeColor = System.Drawing.Color.Blue;
			this.lblLotSize.Location = new System.Drawing.Point(918, 16);
			this.lblLotSize.Name = "lblLotSize";
			this.lblLotSize.Size = new System.Drawing.Size(53, 13);
			this.lblLotSize.TabIndex = 13;
			this.lblLotSize.Text = "Lot Size";
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(653, 11);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(34, 23);
			this.iconbtnNext.TabIndex = 56;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			this.iconbtnNext.Click += new System.EventHandler(this.iconbtnNext_Click);
			// 
			// btDownloadCSV
			// 
			this.btDownloadCSV.Location = new System.Drawing.Point(227, 11);
			this.btDownloadCSV.Name = "btDownloadCSV";
			this.btDownloadCSV.Size = new System.Drawing.Size(92, 23);
			this.btDownloadCSV.TabIndex = 12;
			this.btDownloadCSV.Text = "Download CSV";
			this.btDownloadCSV.UseVisualStyleBackColor = true;
			this.btDownloadCSV.Click += new System.EventHandler(this.btDownloadCSV_Click);
			// 
			// labelTotalRecords
			// 
			this.labelTotalRecords.AutoSize = true;
			this.labelTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelTotalRecords.ForeColor = System.Drawing.Color.Blue;
			this.labelTotalRecords.Location = new System.Drawing.Point(395, 16);
			this.labelTotalRecords.Name = "labelTotalRecords";
			this.labelTotalRecords.Size = new System.Drawing.Size(87, 13);
			this.labelTotalRecords.TabIndex = 54;
			this.labelTotalRecords.Text = "Total Records";
			// 
			// btLotLoad
			// 
			this.btLotLoad.Location = new System.Drawing.Point(146, 11);
			this.btLotLoad.Name = "btLotLoad";
			this.btLotLoad.Size = new System.Drawing.Size(75, 23);
			this.btLotLoad.TabIndex = 10;
			this.btLotLoad.Text = "Tìm kiếm";
			this.btLotLoad.UseVisualStyleBackColor = true;
			this.btLotLoad.Click += new System.EventHandler(this.btLotLoad_Click);
			// 
			// iconbtnPrev
			// 
			this.iconbtnPrev.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrev.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrev.Location = new System.Drawing.Point(535, 11);
			this.iconbtnPrev.Name = "iconbtnPrev";
			this.iconbtnPrev.Size = new System.Drawing.Size(34, 23);
			this.iconbtnPrev.TabIndex = 55;
			this.iconbtnPrev.Text = "<";
			this.iconbtnPrev.UseVisualStyleBackColor = true;
			this.iconbtnPrev.Click += new System.EventHandler(this.iconbtnPrev_Click);
			// 
			// txtLot
			// 
			this.txtLot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLot.Location = new System.Drawing.Point(12, 12);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new System.Drawing.Size(128, 20);
			this.txtLot.TabIndex = 9;
			this.txtLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLot_KeyDown);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panelContent);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 47);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 514);
			this.panel2.TabIndex = 2;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 514);
			this.panelContent.TabIndex = 1;
			// 
			// dgView
			// 
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(12, 6);
			this.dgView.Name = "dgView";
			this.dgView.Size = new System.Drawing.Size(960, 496);
			this.dgView.TabIndex = 0;
			// 
			// frmViewCBData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panelTop);
			this.Name = "frmViewCBData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XEM DỮ LIỆU CB";
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Button btDownloadCSV;
		private System.Windows.Forms.Button btLotLoad;
		private System.Windows.Forms.TextBox txtLot;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblSoluong;
		private System.Windows.Forms.Label lblLotSize;
		private System.Windows.Forms.DataGridView dgView;
		private FontAwesome.Sharp.IconButton iconbtnLast;
		private FontAwesome.Sharp.IconButton iconbtnFirst;
		private System.Windows.Forms.Label labelPageInfo;
		private System.Windows.Forms.Label label5;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private System.Windows.Forms.Label labelTotalRecords;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
	}
}