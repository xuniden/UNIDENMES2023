namespace SMTPRORAM.AssyLine.VIEW
{
	partial class frmViewUGCOM2
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
			this.iconbtnLast = new FontAwesome.Sharp.IconButton();
			this.iconbtnFirst = new FontAwesome.Sharp.IconButton();
			this.labelPageInfo = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panelContent = new System.Windows.Forms.Panel();
			this.btDownloadCSV = new System.Windows.Forms.Button();
			this.labelTotalRecords = new System.Windows.Forms.Label();
			this.btLotLoad = new System.Windows.Forms.Button();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.txtLot = new System.Windows.Forms.TextBox();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.panelTop = new System.Windows.Forms.Panel();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.panel2.SuspendLayout();
			this.panelContent.SuspendLayout();
			this.panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgView
			// 
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(12, 32);
			this.dgView.Name = "dgView";
			this.dgView.Size = new System.Drawing.Size(960, 470);
			this.dgView.TabIndex = 0;
			// 
			// iconbtnLast
			// 
			this.iconbtnLast.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLast.IconColor = System.Drawing.Color.Black;
			this.iconbtnLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLast.Location = new System.Drawing.Point(690, 3);
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
			this.iconbtnFirst.Location = new System.Drawing.Point(492, 3);
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
			this.labelPageInfo.Location = new System.Drawing.Point(573, 8);
			this.labelPageInfo.Name = "labelPageInfo";
			this.labelPageInfo.Size = new System.Drawing.Size(34, 13);
			this.labelPageInfo.TabIndex = 57;
			this.labelPageInfo.Text = "CurP";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(322, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 53;
			this.label5.Text = "Total Rows:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panelContent);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 47);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 514);
			this.panel2.TabIndex = 4;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.iconbtnLast);
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Controls.Add(this.iconbtnPrev);
			this.panelContent.Controls.Add(this.iconbtnFirst);
			this.panelContent.Controls.Add(this.labelTotalRecords);
			this.panelContent.Controls.Add(this.iconbtnNext);
			this.panelContent.Controls.Add(this.labelPageInfo);
			this.panelContent.Controls.Add(this.label5);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 514);
			this.panelContent.TabIndex = 1;
			// 
			// btDownloadCSV
			// 
			this.btDownloadCSV.Location = new System.Drawing.Point(595, 11);
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
			this.labelTotalRecords.Location = new System.Drawing.Point(392, 8);
			this.labelTotalRecords.Name = "labelTotalRecords";
			this.labelTotalRecords.Size = new System.Drawing.Size(87, 13);
			this.labelTotalRecords.TabIndex = 54;
			this.labelTotalRecords.Text = "Total Records";
			// 
			// btLotLoad
			// 
			this.btLotLoad.Location = new System.Drawing.Point(514, 11);
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
			this.iconbtnPrev.Location = new System.Drawing.Point(532, 3);
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
			this.txtLot.Location = new System.Drawing.Point(380, 12);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new System.Drawing.Size(128, 20);
			this.txtLot.TabIndex = 9;
			this.txtLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLot_KeyDown);
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(650, 3);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(34, 23);
			this.iconbtnNext.TabIndex = 56;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			this.iconbtnNext.Click += new System.EventHandler(this.iconbtnNext_Click);
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.label3);
			this.panelTop.Controls.Add(this.label2);
			this.panelTop.Controls.Add(this.label1);
			this.panelTop.Controls.Add(this.dtpTo);
			this.panelTop.Controls.Add(this.dtpFrom);
			this.panelTop.Controls.Add(this.btDownloadCSV);
			this.panelTop.Controls.Add(this.btLotLoad);
			this.panelTop.Controls.Add(this.txtLot);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(984, 47);
			this.panelTop.TabIndex = 3;
			// 
			// dtpFrom
			// 
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFrom.Location = new System.Drawing.Point(64, 12);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(108, 20);
			this.dtpFrom.TabIndex = 13;
			// 
			// dtpTo
			// 
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTo.Location = new System.Drawing.Point(235, 12);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(108, 20);
			this.dtpTo.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Từ ngày:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(178, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Tới ngày:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(349, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Lot:";
			// 
			// frmViewUGCOM2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panelTop);
			this.Name = "frmViewUGCOM2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XEM DỮ LIỆU COM 2";
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panelContent.ResumeLayout(false);
			this.panelContent.PerformLayout();
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgView;
		private FontAwesome.Sharp.IconButton iconbtnLast;
		private FontAwesome.Sharp.IconButton iconbtnFirst;
		private System.Windows.Forms.Label labelPageInfo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Button btDownloadCSV;
		private System.Windows.Forms.Label labelTotalRecords;
		private System.Windows.Forms.Button btLotLoad;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
		private System.Windows.Forms.TextBox txtLot;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
	}
}