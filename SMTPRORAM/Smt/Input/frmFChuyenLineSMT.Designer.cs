namespace SMTPRORAM.Smt.Input
{
    partial class frmFChuyenLineSMT
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
			this.lwait = new System.Windows.Forms.Label();
			this.cbOldLine = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbNewLine = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btCancel = new System.Windows.Forms.Button();
			this.btProcess = new System.Windows.Forms.Button();
			this.lnewline = new System.Windows.Forms.Label();
			this.loldline = new System.Windows.Forms.Label();
			this.lprogram = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtProgram = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.panelContent = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panelLeft.SuspendLayout();
			this.panelContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// lwait
			// 
			this.lwait.AutoSize = true;
			this.lwait.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lwait.Location = new System.Drawing.Point(109, 184);
			this.lwait.Name = "lwait";
			this.lwait.Size = new System.Drawing.Size(287, 13);
			this.lwait.TabIndex = 27;
			this.lwait.Text = "Đang Xử Lý Chuyển Line. Vui Lòng đợi ..............";
			// 
			// cbOldLine
			// 
			this.cbOldLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOldLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbOldLine.FormattingEnabled = true;
			this.cbOldLine.Location = new System.Drawing.Point(112, 116);
			this.cbOldLine.Name = "cbOldLine";
			this.cbOldLine.Size = new System.Drawing.Size(284, 21);
			this.cbOldLine.TabIndex = 16;
			this.cbOldLine.SelectedIndexChanged += new System.EventHandler(this.cbOldLine_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(109, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(224, 16);
			this.label5.TabIndex = 26;
			this.label5.Text = "Chú Ý: Phải Giống Bên Line Mới";
			// 
			// cbNewLine
			// 
			this.cbNewLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbNewLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbNewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbNewLine.FormattingEnabled = true;
			this.cbNewLine.Location = new System.Drawing.Point(112, 146);
			this.cbNewLine.Name = "cbNewLine";
			this.cbNewLine.Size = new System.Drawing.Size(284, 21);
			this.cbNewLine.TabIndex = 17;
			this.cbNewLine.SelectedIndexChanged += new System.EventHandler(this.cbNewLine_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(62, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(307, 29);
			this.label4.TabIndex = 25;
			this.label4.Text = "CHUYỂN LINE, CẮT LOT";
			// 
			// btCancel
			// 
			this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancel.Location = new System.Drawing.Point(285, 214);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(111, 27);
			this.btCancel.TabIndex = 20;
			this.btCancel.Text = "Hủy Bỏ";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btProcess
			// 
			this.btProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btProcess.Location = new System.Drawing.Point(112, 214);
			this.btProcess.Name = "btProcess";
			this.btProcess.Size = new System.Drawing.Size(141, 27);
			this.btProcess.TabIndex = 19;
			this.btProcess.Text = "Thực Hiện Chuyển";
			this.btProcess.UseVisualStyleBackColor = true;
			this.btProcess.Click += new System.EventHandler(this.btProcess_Click);
			// 
			// lnewline
			// 
			this.lnewline.AutoSize = true;
			this.lnewline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lnewline.Location = new System.Drawing.Point(402, 150);
			this.lnewline.Name = "lnewline";
			this.lnewline.Size = new System.Drawing.Size(24, 13);
			this.lnewline.TabIndex = 24;
			this.lnewline.Text = "OK";
			// 
			// loldline
			// 
			this.loldline.AutoSize = true;
			this.loldline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loldline.Location = new System.Drawing.Point(402, 120);
			this.loldline.Name = "loldline";
			this.loldline.Size = new System.Drawing.Size(24, 13);
			this.loldline.TabIndex = 23;
			this.loldline.Text = "OK";
			// 
			// lprogram
			// 
			this.lprogram.AutoSize = true;
			this.lprogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lprogram.Location = new System.Drawing.Point(402, 88);
			this.lprogram.Name = "lprogram";
			this.lprogram.Size = new System.Drawing.Size(24, 13);
			this.lprogram.TabIndex = 22;
			this.lprogram.Text = "OK";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 150);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Chuyển Đến Line:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(10, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Line Hiện Tại:";
			// 
			// txtProgram
			// 
			this.txtProgram.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProgram.Location = new System.Drawing.Point(112, 85);
			this.txtProgram.Name = "txtProgram";
			this.txtProgram.Size = new System.Drawing.Size(284, 20);
			this.txtProgram.TabIndex = 14;
			this.txtProgram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProgram_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Tên Chương Trình:";
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.label1);
			this.panelLeft.Controls.Add(this.label5);
			this.panelLeft.Controls.Add(this.lwait);
			this.panelLeft.Controls.Add(this.label4);
			this.panelLeft.Controls.Add(this.label2);
			this.panelLeft.Controls.Add(this.btCancel);
			this.panelLeft.Controls.Add(this.cbOldLine);
			this.panelLeft.Controls.Add(this.btProcess);
			this.panelLeft.Controls.Add(this.cbNewLine);
			this.panelLeft.Controls.Add(this.label3);
			this.panelLeft.Controls.Add(this.txtProgram);
			this.panelLeft.Controls.Add(this.lprogram);
			this.panelLeft.Controls.Add(this.loldline);
			this.panelLeft.Controls.Add(this.lnewline);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(441, 561);
			this.panelLeft.TabIndex = 28;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.dataGridView1);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(441, 0);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(543, 561);
			this.panelContent.TabIndex = 29;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(6, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(525, 537);
			this.dataGridView1.TabIndex = 0;
			// 
			// frmFChuyenLineSMT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelLeft);
			this.Name = "frmFChuyenLineSMT";
			this.Text = "Chuyển line SMT";
			this.Load += new System.EventHandler(this.frmFChuyenLineSMT_Load);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.panelContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lwait;
        private System.Windows.Forms.ComboBox cbOldLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbNewLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btProcess;
        private System.Windows.Forms.Label lnewline;
        private System.Windows.Forms.Label loldline;
        private System.Windows.Forms.Label lprogram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}