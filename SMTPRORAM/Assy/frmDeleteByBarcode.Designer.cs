namespace SMTPRORAM.Assy
{
	partial class frmDeleteByBarcode
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
			this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnDelete = new FontAwesome.Sharp.IconButton();
			this.txtReason = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.iconbtnSearch = new FontAwesome.Sharp.IconButton();
			this.dgDelete = new System.Windows.Forms.DataGridView();
			this.panelTop = new System.Windows.Forms.Panel();
			this.panelbutton = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgDelete)).BeginInit();
			this.panelTop.SuspendLayout();
			this.panelbutton.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.iconbtnSearch);
			this.panel1.Controls.Add(this.iconbtnCancel);
			this.panel1.Controls.Add(this.iconbtnDelete);
			this.panel1.Controls.Add(this.txtReason);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(338, 528);
			this.panel1.TabIndex = 0;
			// 
			// iconbtnCancel
			// 
			this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
			this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnCancel.Location = new System.Drawing.Point(158, 117);
			this.iconbtnCancel.Name = "iconbtnCancel";
			this.iconbtnCancel.Size = new System.Drawing.Size(75, 23);
			this.iconbtnCancel.TabIndex = 5;
			this.iconbtnCancel.Text = "Close";
			this.iconbtnCancel.UseVisualStyleBackColor = true;
			this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
			// 
			// iconbtnDelete
			// 
			this.iconbtnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnDelete.IconColor = System.Drawing.Color.Black;
			this.iconbtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnDelete.Location = new System.Drawing.Point(68, 117);
			this.iconbtnDelete.Name = "iconbtnDelete";
			this.iconbtnDelete.Size = new System.Drawing.Size(75, 23);
			this.iconbtnDelete.TabIndex = 4;
			this.iconbtnDelete.Text = "Xóa";
			this.iconbtnDelete.UseVisualStyleBackColor = true;
			this.iconbtnDelete.Click += new System.EventHandler(this.iconbtnDelete_Click);
			// 
			// txtReason
			// 
			this.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtReason.Location = new System.Drawing.Point(68, 79);
			this.txtReason.Name = "txtReason";
			this.txtReason.Size = new System.Drawing.Size(251, 20);
			this.txtReason.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Lý do:";
			// 
			// txtSearch
			// 
			this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSearch.Location = new System.Drawing.Point(68, 14);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(165, 20);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Barcode:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panelbutton);
			this.panel2.Controls.Add(this.panelTop);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(338, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(543, 528);
			this.panel2.TabIndex = 1;
			// 
			// dgView
			// 
			this.dgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgView.Location = new System.Drawing.Point(6, 12);
			this.dgView.Name = "dgView";
			this.dgView.Size = new System.Drawing.Size(534, 232);
			this.dgView.TabIndex = 0;
			// 
			// iconbtnSearch
			// 
			this.iconbtnSearch.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnSearch.IconColor = System.Drawing.Color.Black;
			this.iconbtnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnSearch.Location = new System.Drawing.Point(239, 12);
			this.iconbtnSearch.Name = "iconbtnSearch";
			this.iconbtnSearch.Size = new System.Drawing.Size(80, 23);
			this.iconbtnSearch.TabIndex = 6;
			this.iconbtnSearch.Text = "Tìm kiếm";
			this.iconbtnSearch.UseVisualStyleBackColor = true;
			this.iconbtnSearch.Click += new System.EventHandler(this.iconbtnSearch_Click);
			// 
			// dgDelete
			// 
			this.dgDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgDelete.Location = new System.Drawing.Point(6, 6);
			this.dgDelete.Name = "dgDelete";
			this.dgDelete.Size = new System.Drawing.Size(534, 266);
			this.dgDelete.TabIndex = 1;
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.dgView);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(543, 253);
			this.panelTop.TabIndex = 0;
			// 
			// panelbutton
			// 
			this.panelbutton.Controls.Add(this.dgDelete);
			this.panelbutton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelbutton.Location = new System.Drawing.Point(0, 253);
			this.panelbutton.Name = "panelbutton";
			this.panelbutton.Size = new System.Drawing.Size(543, 275);
			this.panelbutton.TabIndex = 1;
			// 
			// frmDeleteByBarcode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(881, 528);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeleteByBarcode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XÓA THEO BARCODE";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDeleteByBarcode_FormClosing);
			this.Load += new System.EventHandler(this.frmDeleteByBarcode_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgDelete)).EndInit();
			this.panelTop.ResumeLayout(false);
			this.panelbutton.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtReason;
		private System.Windows.Forms.Label label2;
		private FontAwesome.Sharp.IconButton iconbtnDelete;
		private FontAwesome.Sharp.IconButton iconbtnCancel;
		private FontAwesome.Sharp.IconButton iconbtnSearch;
		private System.Windows.Forms.DataGridView dgDelete;
		private System.Windows.Forms.Panel panelbutton;
		private System.Windows.Forms.Panel panelTop;
	}
}