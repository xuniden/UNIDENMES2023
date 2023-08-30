namespace SMTPRORAM.AssyLine.MENU
{
	partial class frmChangeBatch
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
			this.panelContent = new System.Windows.Forms.Panel();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cbSelect = new System.Windows.Forms.ComboBox();
			this.rtReason = new System.Windows.Forms.RichTextBox();
			this.cbChangeTo = new System.Windows.Forms.ComboBox();
			this.txtCurrentBatch = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBatch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtLot = new System.Windows.Forms.TextBox();
			this.btUpdate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.panelContent.SuspendLayout();
			this.panelLeft.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(6, 12);
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.Size = new System.Drawing.Size(470, 537);
			this.dgView.TabIndex = 0;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(496, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(488, 561);
			this.panelContent.TabIndex = 3;
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.btUpdate);
			this.panelLeft.Controls.Add(this.label7);
			this.panelLeft.Controls.Add(this.cbSelect);
			this.panelLeft.Controls.Add(this.rtReason);
			this.panelLeft.Controls.Add(this.cbChangeTo);
			this.panelLeft.Controls.Add(this.txtCurrentBatch);
			this.panelLeft.Controls.Add(this.label6);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Controls.Add(this.txtBatch);
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Controls.Add(this.txtLot);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(496, 561);
			this.panelLeft.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(473, 38);
			this.label4.TabIndex = 9;
			this.label4.Text = "THAY ĐỔI TÌNH TRẠNG BATCH";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 73);
			this.label7.Margin = new System.Windows.Forms.Padding(23, 0, 23, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 13);
			this.label7.TabIndex = 33;
			this.label7.Text = "SELECT #:";
			// 
			// cbSelect
			// 
			this.cbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSelect.FormattingEnabled = true;
			this.cbSelect.Items.AddRange(new object[] {
            "1.CB Model",
            "2.COM2"});
			this.cbSelect.Location = new System.Drawing.Point(206, 69);
			this.cbSelect.Name = "cbSelect";
			this.cbSelect.Size = new System.Drawing.Size(266, 21);
			this.cbSelect.TabIndex = 32;
			this.cbSelect.SelectedIndexChanged += new System.EventHandler(this.cbSelect_SelectedIndexChanged);
			// 
			// rtReason
			// 
			this.rtReason.Location = new System.Drawing.Point(206, 236);
			this.rtReason.Name = "rtReason";
			this.rtReason.Size = new System.Drawing.Size(266, 96);
			this.rtReason.TabIndex = 31;
			this.rtReason.Text = "";
			this.rtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtReason_KeyDown);
			this.rtReason.Validating += new System.ComponentModel.CancelEventHandler(this.rtReason_Validating);
			// 
			// cbChangeTo
			// 
			this.cbChangeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChangeTo.FormattingEnabled = true;
			this.cbChangeTo.Items.AddRange(new object[] {
            "OK",
            "NG"});
			this.cbChangeTo.Location = new System.Drawing.Point(206, 198);
			this.cbChangeTo.Name = "cbChangeTo";
			this.cbChangeTo.Size = new System.Drawing.Size(266, 21);
			this.cbChangeTo.TabIndex = 30;
			this.cbChangeTo.SelectedIndexChanged += new System.EventHandler(this.cbChangeTo_SelectedIndexChanged);
			// 
			// txtCurrentBatch
			// 
			this.txtCurrentBatch.Enabled = false;
			this.txtCurrentBatch.Location = new System.Drawing.Point(206, 166);
			this.txtCurrentBatch.Margin = new System.Windows.Forms.Padding(23, 26, 23, 26);
			this.txtCurrentBatch.Name = "txtCurrentBatch";
			this.txtCurrentBatch.Size = new System.Drawing.Size(266, 20);
			this.txtCurrentBatch.TabIndex = 29;
			this.txtCurrentBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 239);
			this.label6.Margin = new System.Windows.Forms.Padding(23, 0, 23, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "REASON CHANGE #:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 202);
			this.label5.Margin = new System.Windows.Forms.Padding(23, 0, 23, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(172, 13);
			this.label5.TabIndex = 26;
			this.label5.Text = "REPLACE BATCH STATUS TO #:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 170);
			this.label3.Margin = new System.Windows.Forms.Padding(23, 0, 23, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(158, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "CURRENT BATCH  STATUS#:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 138);
			this.label2.Margin = new System.Windows.Forms.Padding(23, 0, 23, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 28;
			this.label2.Text = "BATCH #:";
			// 
			// txtBatch
			// 
			this.txtBatch.Location = new System.Drawing.Point(206, 134);
			this.txtBatch.Margin = new System.Windows.Forms.Padding(23, 26, 23, 26);
			this.txtBatch.Name = "txtBatch";
			this.txtBatch.Size = new System.Drawing.Size(266, 20);
			this.txtBatch.TabIndex = 24;
			this.txtBatch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBatch_KeyDown);
			this.txtBatch.Validating += new System.ComponentModel.CancelEventHandler(this.txtBatch_Validating);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 106);
			this.label1.Margin = new System.Windows.Forms.Padding(23, 0, 23, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "LOT #:";
			// 
			// txtLot
			// 
			this.txtLot.Location = new System.Drawing.Point(206, 102);
			this.txtLot.Margin = new System.Windows.Forms.Padding(23, 26, 23, 26);
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new System.Drawing.Size(266, 20);
			this.txtLot.TabIndex = 22;
			this.txtLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLot_KeyDown);
			this.txtLot.Validating += new System.ComponentModel.CancelEventHandler(this.txtLot_Validating);
			// 
			// btUpdate
			// 
			this.btUpdate.Location = new System.Drawing.Point(206, 344);
			this.btUpdate.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.btUpdate.Name = "btUpdate";
			this.btUpdate.Size = new System.Drawing.Size(176, 53);
			this.btUpdate.TabIndex = 34;
			this.btUpdate.Text = "UPDATE";
			this.btUpdate.UseVisualStyleBackColor = true;
			this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
			// 
			// frmChangeBatch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmChangeBatch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "THAY ĐỔI TÌNH TRẠNG BATCH";
			this.Load += new System.EventHandler(this.frmChangeBatch_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.panelContent.ResumeLayout(false);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbSelect;
		private System.Windows.Forms.RichTextBox rtReason;
		private System.Windows.Forms.ComboBox cbChangeTo;
		private System.Windows.Forms.TextBox txtCurrentBatch;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBatch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtLot;
		private System.Windows.Forms.Button btUpdate;
	}
}