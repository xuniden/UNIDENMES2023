namespace SMTPRORAM.AssyLine.REPAIR
{
	partial class frmKeyinSamsungRepair
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
			this.label9 = new System.Windows.Forms.Label();
			this.cbModel = new System.Windows.Forms.ComboBox();
			this.cbPCBType = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.cbDeptCode = new System.Windows.Forms.ComboBox();
			this.cbCauseCode = new System.Windows.Forms.ComboBox();
			this.cbErrorCode = new System.Windows.Forms.ComboBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNGPosition = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRepairCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.panelLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.label9);
			this.panelLeft.Controls.Add(this.cbModel);
			this.panelLeft.Controls.Add(this.cbPCBType);
			this.panelLeft.Controls.Add(this.label8);
			this.panelLeft.Controls.Add(this.numericUpDown1);
			this.panelLeft.Controls.Add(this.label7);
			this.panelLeft.Controls.Add(this.cbDeptCode);
			this.panelLeft.Controls.Add(this.cbCauseCode);
			this.panelLeft.Controls.Add(this.cbErrorCode);
			this.panelLeft.Controls.Add(this.btnSave);
			this.panelLeft.Controls.Add(this.btnCancel);
			this.panelLeft.Controls.Add(this.label6);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.txtNGPosition);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.txtRepairCode);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(372, 561);
			this.panelLeft.TabIndex = 0;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.Blue;
			this.label9.Location = new System.Drawing.Point(12, 12);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(340, 32);
			this.label9.TabIndex = 1023;
			this.label9.Text = "NHẬP SAMSUNG REPAIR";
			// 
			// cbModel
			// 
			this.cbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbModel.FormattingEnabled = true;
			this.cbModel.Location = new System.Drawing.Point(117, 63);
			this.cbModel.Name = "cbModel";
			this.cbModel.Size = new System.Drawing.Size(223, 21);
			this.cbModel.TabIndex = 1005;
			// 
			// cbPCBType
			// 
			this.cbPCBType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPCBType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbPCBType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbPCBType.FormattingEnabled = true;
			this.cbPCBType.Items.AddRange(new object[] {
            "MAIN",
            "KEY",
            "LED",
            "AMP",
            "OLED",
            "PCB",
            "SW"});
			this.cbPCBType.Location = new System.Drawing.Point(117, 125);
			this.cbPCBType.Name = "cbPCBType";
			this.cbPCBType.Size = new System.Drawing.Size(223, 21);
			this.cbPCBType.TabIndex = 1007;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 127);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 13);
			this.label8.TabIndex = 1022;
			this.label8.Text = "Loại PCB:";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(117, 221);
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 1010;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(17, 223);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 13);
			this.label7.TabIndex = 1021;
			this.label7.Text = "Số lượng lỗi:";
			// 
			// cbDeptCode
			// 
			this.cbDeptCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbDeptCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDeptCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDeptCode.FormattingEnabled = true;
			this.cbDeptCode.Location = new System.Drawing.Point(117, 284);
			this.cbDeptCode.Name = "cbDeptCode";
			this.cbDeptCode.Size = new System.Drawing.Size(223, 21);
			this.cbDeptCode.TabIndex = 1012;
			// 
			// cbCauseCode
			// 
			this.cbCauseCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbCauseCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbCauseCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbCauseCode.FormattingEnabled = true;
			this.cbCauseCode.Location = new System.Drawing.Point(117, 252);
			this.cbCauseCode.Name = "cbCauseCode";
			this.cbCauseCode.Size = new System.Drawing.Size(223, 21);
			this.cbCauseCode.TabIndex = 1011;
			// 
			// cbErrorCode
			// 
			this.cbErrorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbErrorCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbErrorCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbErrorCode.FormattingEnabled = true;
			this.cbErrorCode.Location = new System.Drawing.Point(117, 158);
			this.cbErrorCode.Name = "cbErrorCode";
			this.cbErrorCode.Size = new System.Drawing.Size(223, 21);
			this.cbErrorCode.TabIndex = 1008;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(117, 322);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 37);
			this.btnSave.TabIndex = 1013;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(247, 322);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(93, 37);
			this.btnCancel.TabIndex = 1014;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 286);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 1020;
			this.label6.Text = "Bộ Phận:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 254);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 1019;
			this.label5.Text = "Nguyên Nhân:";
			// 
			// txtNGPosition
			// 
			this.txtNGPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNGPosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNGPosition.Location = new System.Drawing.Point(117, 190);
			this.txtNGPosition.Name = "txtNGPosition";
			this.txtNGPosition.Size = new System.Drawing.Size(223, 20);
			this.txtNGPosition.TabIndex = 1009;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 193);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 1018;
			this.label4.Text = "Vị trí LK NG";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 160);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 1017;
			this.label3.Text = "Mã Lỗi:";
			// 
			// txtRepairCode
			// 
			this.txtRepairCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRepairCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRepairCode.Location = new System.Drawing.Point(117, 94);
			this.txtRepairCode.Name = "txtRepairCode";
			this.txtRepairCode.Size = new System.Drawing.Size(223, 20);
			this.txtRepairCode.TabIndex = 1006;
			this.txtRepairCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRepairCode_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 1016;
			this.label2.Text = "Mã Repair:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 1015;
			this.label1.Text = "Model:";
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dgView);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(372, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(612, 561);
			this.panelContent.TabIndex = 1;
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
			this.dgView.Size = new System.Drawing.Size(594, 537);
			this.dgView.TabIndex = 1;
			// 
			// frmKeyinSamsungRepair
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmKeyinSamsungRepair";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NHẬP DỮ LIỆU REPAIR SAMSUNG";
			this.Load += new System.EventHandler(this.frmKeyinSamsungRepair_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.ComboBox cbModel;
		private System.Windows.Forms.ComboBox cbPCBType;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbDeptCode;
		private System.Windows.Forms.ComboBox cbCauseCode;
		private System.Windows.Forms.ComboBox cbErrorCode;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNGPosition;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRepairCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgView;
		private System.Windows.Forms.Label label9;
	}
}