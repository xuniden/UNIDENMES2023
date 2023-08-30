namespace SMTPRORAM.AssyLine.VIEW
{
	partial class frmViewEastechHistoryInput
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
			this.panelLeft = new System.Windows.Forms.Panel();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.cbModel = new System.Windows.Forms.ComboBox();
			this.btDownload = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtPick2 = new System.Windows.Forms.DateTimePicker();
			this.dtPick1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btTimKiem = new System.Windows.Forms.Button();
			this.btLoad = new System.Windows.Forms.Button();
			this.iconbtnLast = new FontAwesome.Sharp.IconButton();
			this.iconbtnFirst = new FontAwesome.Sharp.IconButton();
			this.labelPageInfo = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.iconbtnNext = new FontAwesome.Sharp.IconButton();
			this.labelTotalRecords = new System.Windows.Forms.Label();
			this.iconbtnPrev = new FontAwesome.Sharp.IconButton();
			this.panelLeft.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.iconbtnLast);
			this.panelLeft.Controls.Add(this.iconbtnFirst);
			this.panelLeft.Controls.Add(this.labelPageInfo);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.iconbtnNext);
			this.panelLeft.Controls.Add(this.labelTotalRecords);
			this.panelLeft.Controls.Add(this.iconbtnPrev);
			this.panelLeft.Controls.Add(this.cbModel);
			this.panelLeft.Controls.Add(this.btDownload);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Controls.Add(this.dtPick2);
			this.panelLeft.Controls.Add(this.dtPick1);
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Controls.Add(this.btTimKiem);
			this.panelLeft.Controls.Add(this.btLoad);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(984, 71);
			this.panelLeft.TabIndex = 0;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 71);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 490);
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
			this.dgView.Size = new System.Drawing.Size(960, 472);
			this.dgView.TabIndex = 0;
			// 
			// cbModel
			// 
			this.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbModel.FormattingEnabled = true;
			this.cbModel.Location = new System.Drawing.Point(49, 12);
			this.cbModel.Name = "cbModel";
			this.cbModel.Size = new System.Drawing.Size(147, 21);
			this.cbModel.TabIndex = 18;
			// 
			// btDownload
			// 
			this.btDownload.Location = new System.Drawing.Point(757, 11);
			this.btDownload.Name = "btDownload";
			this.btDownload.Size = new System.Drawing.Size(73, 23);
			this.btDownload.TabIndex = 17;
			this.btDownload.Text = "Download";
			this.btDownload.UseVisualStyleBackColor = true;
			this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(385, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Đến:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(202, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Từ:";
			// 
			// dtPick2
			// 
			this.dtPick2.CustomFormat = "yyyy/MM/dd HH:mm";
			this.dtPick2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPick2.Location = new System.Drawing.Point(421, 12);
			this.dtPick2.Name = "dtPick2";
			this.dtPick2.Size = new System.Drawing.Size(155, 20);
			this.dtPick2.TabIndex = 14;
			// 
			// dtPick1
			// 
			this.dtPick1.CustomFormat = "yyyy/MM/dd HH:mm";
			this.dtPick1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtPick1.Location = new System.Drawing.Point(231, 12);
			this.dtPick1.Name = "dtPick1";
			this.dtPick1.Size = new System.Drawing.Size(148, 20);
			this.dtPick1.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Model:";
			// 
			// btTimKiem
			// 
			this.btTimKiem.Location = new System.Drawing.Point(582, 11);
			this.btTimKiem.Name = "btTimKiem";
			this.btTimKiem.Size = new System.Drawing.Size(63, 23);
			this.btTimKiem.TabIndex = 11;
			this.btTimKiem.Text = "Tìm Kiếm";
			this.btTimKiem.UseVisualStyleBackColor = true;
			this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
			// 
			// btLoad
			// 
			this.btLoad.Location = new System.Drawing.Point(651, 11);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(100, 23);
			this.btLoad.TabIndex = 10;
			this.btLoad.Text = "Load theo Model";
			this.btLoad.UseVisualStyleBackColor = true;
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// iconbtnLast
			// 
			this.iconbtnLast.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnLast.IconColor = System.Drawing.Color.Black;
			this.iconbtnLast.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLast.Location = new System.Drawing.Point(377, 45);
			this.iconbtnLast.Name = "iconbtnLast";
			this.iconbtnLast.Size = new System.Drawing.Size(34, 23);
			this.iconbtnLast.TabIndex = 66;
			this.iconbtnLast.Text = ">>";
			this.iconbtnLast.UseVisualStyleBackColor = true;
			// 
			// iconbtnFirst
			// 
			this.iconbtnFirst.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnFirst.IconColor = System.Drawing.Color.Black;
			this.iconbtnFirst.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnFirst.Location = new System.Drawing.Point(179, 45);
			this.iconbtnFirst.Name = "iconbtnFirst";
			this.iconbtnFirst.Size = new System.Drawing.Size(34, 23);
			this.iconbtnFirst.TabIndex = 65;
			this.iconbtnFirst.Text = "<<";
			this.iconbtnFirst.UseVisualStyleBackColor = true;
			// 
			// labelPageInfo
			// 
			this.labelPageInfo.AutoSize = true;
			this.labelPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelPageInfo.ForeColor = System.Drawing.Color.Blue;
			this.labelPageInfo.Location = new System.Drawing.Point(260, 50);
			this.labelPageInfo.Name = "labelPageInfo";
			this.labelPageInfo.Size = new System.Drawing.Size(34, 13);
			this.labelPageInfo.TabIndex = 64;
			this.labelPageInfo.Text = "CurP";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 60;
			this.label5.Text = "Total Rows:";
			// 
			// iconbtnNext
			// 
			this.iconbtnNext.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnNext.IconColor = System.Drawing.Color.Black;
			this.iconbtnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnNext.Location = new System.Drawing.Point(337, 45);
			this.iconbtnNext.Name = "iconbtnNext";
			this.iconbtnNext.Size = new System.Drawing.Size(34, 23);
			this.iconbtnNext.TabIndex = 63;
			this.iconbtnNext.Text = ">";
			this.iconbtnNext.UseVisualStyleBackColor = true;
			// 
			// labelTotalRecords
			// 
			this.labelTotalRecords.AutoSize = true;
			this.labelTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelTotalRecords.ForeColor = System.Drawing.Color.Blue;
			this.labelTotalRecords.Location = new System.Drawing.Point(79, 50);
			this.labelTotalRecords.Name = "labelTotalRecords";
			this.labelTotalRecords.Size = new System.Drawing.Size(87, 13);
			this.labelTotalRecords.TabIndex = 61;
			this.labelTotalRecords.Text = "Total Records";
			// 
			// iconbtnPrev
			// 
			this.iconbtnPrev.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnPrev.IconColor = System.Drawing.Color.Black;
			this.iconbtnPrev.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnPrev.Location = new System.Drawing.Point(219, 45);
			this.iconbtnPrev.Name = "iconbtnPrev";
			this.iconbtnPrev.Size = new System.Drawing.Size(34, 23);
			this.iconbtnPrev.TabIndex = 62;
			this.iconbtnPrev.Text = "<";
			this.iconbtnPrev.UseVisualStyleBackColor = true;
			// 
			// frmViewEastechHistoryInput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmViewEastechHistoryInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LỊCH SỬ NHẬP DỮ LIỆU EASTECH";
			this.Load += new System.EventHandler(this.frmViewEastechHistoryInput_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.ComboBox cbModel;
		private System.Windows.Forms.Button btDownload;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtPick2;
		private System.Windows.Forms.DateTimePicker dtPick1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btTimKiem;
		private System.Windows.Forms.Button btLoad;
		private FontAwesome.Sharp.IconButton iconbtnLast;
		private FontAwesome.Sharp.IconButton iconbtnFirst;
		private System.Windows.Forms.Label labelPageInfo;
		private System.Windows.Forms.Label label5;
		private FontAwesome.Sharp.IconButton iconbtnNext;
		private System.Windows.Forms.Label labelTotalRecords;
		private FontAwesome.Sharp.IconButton iconbtnPrev;
	}
}