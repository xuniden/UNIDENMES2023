namespace SMTPRORAM.Smt.Input
{
	partial class frmNewIPQCCheck
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
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgResult = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.txtLine = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtfeeder = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtprogram = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgResult);
			this.panelContent.Controls.Add(this.panel1);
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(984, 561);
			this.panelContent.TabIndex = 1;
			// 
			// dgResult
			// 
			this.dgResult.AllowUserToAddRows = false;
			this.dgResult.AllowUserToDeleteRows = false;
			this.dgResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgResult.Location = new System.Drawing.Point(12, 235);
			this.dgResult.Name = "dgResult";
			this.dgResult.ReadOnly = true;
			this.dgResult.Size = new System.Drawing.Size(960, 314);
			this.dgResult.TabIndex = 2;
			this.dgResult.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgResult_RowPrePaint);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblRecord);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.txtLine);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtfeeder);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtprogram);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 42);
			this.panel1.TabIndex = 1;
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.Location = new System.Drawing.Point(750, 9);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(75, 23);
			this.iconbtnSearch.TabIndex = 6;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// txtLine
			// 
			this.txtLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLine.Location = new System.Drawing.Point(89, 10);
			this.txtLine.Name = "txtLine";
			this.txtLine.Size = new System.Drawing.Size(91, 20);
			this.txtLine.TabIndex = 1;
			this.txtLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLine_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Line Name:";
			// 
			// txtfeeder
			// 
			this.txtfeeder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtfeeder.Location = new System.Drawing.Point(613, 10);
			this.txtfeeder.Name = "txtfeeder";
			this.txtfeeder.Size = new System.Drawing.Size(110, 20);
			this.txtfeeder.TabIndex = 5;
			this.txtfeeder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfeeder_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(545, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Feeder:";
			// 
			// txtprogram
			// 
			this.txtprogram.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtprogram.Location = new System.Drawing.Point(274, 10);
			this.txtprogram.Name = "txtprogram";
			this.txtprogram.Size = new System.Drawing.Size(244, 20);
			this.txtprogram.TabIndex = 3;
			this.txtprogram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtprogram_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(202, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Program:";
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(12, 48);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(960, 181);
			this.dgView.TabIndex = 0;
			this.dgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellDoubleClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(847, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Số lượng: ";
			// 
			// lblRecord
			// 
			this.lblRecord.AutoSize = true;
			this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblRecord.ForeColor = System.Drawing.Color.Blue;
			this.lblRecord.Location = new System.Drawing.Point(908, 14);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(41, 13);
			this.lblRecord.TabIndex = 8;
			this.lblRecord.Text = "label5";
			// 
			// frmNewIPQCCheck
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Name = "frmNewIPQCCheck";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IPQC KIỂM TRA THAY LINH KIỆN";
			this.Load += new System.EventHandler(this.frmNewIPQCCheck_Load);
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtLine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtfeeder;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtprogram;
		private System.Windows.Forms.Label label2;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.DataGridView dgResult;
		private System.Windows.Forms.Label lblRecord;
		private System.Windows.Forms.Label label4;
	}
}