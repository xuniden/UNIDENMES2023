namespace SMTPRORAM.Smt.Input
{
    partial class frmF_Combine_Program
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
			this.btChuyenLine = new System.Windows.Forms.Button();
			this.lblProgram2 = new System.Windows.Forms.Label();
			this.txtProgram2 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lwait = new System.Windows.Forms.Label();
			this.cbOldLine = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbNewLine = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btCancel = new System.Windows.Forms.Button();
			this.lnewline = new System.Windows.Forms.Label();
			this.loldline = new System.Windows.Forms.Label();
			this.lprogram = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtProgram = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btChuyenLine);
			this.panel1.Controls.Add(this.lblProgram2);
			this.panel1.Controls.Add(this.txtProgram2);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.lwait);
			this.panel1.Controls.Add(this.cbOldLine);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.cbNewLine);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.btCancel);
			this.panel1.Controls.Add(this.lnewline);
			this.panel1.Controls.Add(this.loldline);
			this.panel1.Controls.Add(this.lprogram);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtProgram);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(448, 561);
			this.panel1.TabIndex = 0;
			// 
			// btChuyenLine
			// 
			this.btChuyenLine.Location = new System.Drawing.Point(179, 206);
			this.btChuyenLine.Name = "btChuyenLine";
			this.btChuyenLine.Size = new System.Drawing.Size(129, 23);
			this.btChuyenLine.TabIndex = 36;
			this.btChuyenLine.Text = "Thực Hiện Chuyển Line";
			this.btChuyenLine.UseVisualStyleBackColor = true;
			this.btChuyenLine.Click += new System.EventHandler(this.btChuyenLine_Click);
			// 
			// lblProgram2
			// 
			this.lblProgram2.AutoSize = true;
			this.lblProgram2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProgram2.Location = new System.Drawing.Point(413, 123);
			this.lblProgram2.Name = "lblProgram2";
			this.lblProgram2.Size = new System.Drawing.Size(24, 13);
			this.lblProgram2.TabIndex = 47;
			this.lblProgram2.Text = "OK";
			// 
			// txtProgram2
			// 
			this.txtProgram2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProgram2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProgram2.Location = new System.Drawing.Point(179, 119);
			this.txtProgram2.Name = "txtProgram2";
			this.txtProgram2.Size = new System.Drawing.Size(228, 20);
			this.txtProgram2.TabIndex = 45;
			this.txtProgram2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProgram2_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(2, 123);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(94, 13);
			this.label6.TabIndex = 46;
			this.label6.Text = "Chương Trình Mới:";
			// 
			// lwait
			// 
			this.lwait.AutoSize = true;
			this.lwait.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lwait.Location = new System.Drawing.Point(176, 182);
			this.lwait.Name = "lwait";
			this.lwait.Size = new System.Drawing.Size(245, 13);
			this.lwait.TabIndex = 44;
			this.lwait.Text = "Đang Xử Lý Chuyển Line. Vui Lòng đợi .................";
			// 
			// cbOldLine
			// 
			this.cbOldLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOldLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbOldLine.FormattingEnabled = true;
			this.cbOldLine.Location = new System.Drawing.Point(179, 91);
			this.cbOldLine.Name = "cbOldLine";
			this.cbOldLine.Size = new System.Drawing.Size(121, 21);
			this.cbOldLine.TabIndex = 33;
			this.cbOldLine.SelectedIndexChanged += new System.EventHandler(this.cbOldLine_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(13, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(394, 13);
			this.label5.TabIndex = 43;
			this.label5.Text = "Chú Ý: Khi Combine Line Thì Tất Cả Feeder Của Line Cũ Phải Giống Bên Line Mới";
			// 
			// cbNewLine
			// 
			this.cbNewLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbNewLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbNewLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbNewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbNewLine.FormattingEnabled = true;
			this.cbNewLine.Location = new System.Drawing.Point(179, 148);
			this.cbNewLine.Name = "cbNewLine";
			this.cbNewLine.Size = new System.Drawing.Size(121, 21);
			this.cbNewLine.TabIndex = 34;
			this.cbNewLine.SelectedIndexChanged += new System.EventHandler(this.cbNewLine_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(60, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(353, 20);
			this.label4.TabIndex = 42;
			this.label4.Text = "TRƯỜNG HỢP COMBINE CHƯƠNG TRÌNH";
			// 
			// btCancel
			// 
			this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancel.Location = new System.Drawing.Point(340, 206);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(81, 26);
			this.btCancel.TabIndex = 37;
			this.btCancel.Text = "Hủy Bỏ";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// lnewline
			// 
			this.lnewline.AutoSize = true;
			this.lnewline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lnewline.Location = new System.Drawing.Point(316, 152);
			this.lnewline.Name = "lnewline";
			this.lnewline.Size = new System.Drawing.Size(24, 13);
			this.lnewline.TabIndex = 41;
			this.lnewline.Text = "OK";
			// 
			// loldline
			// 
			this.loldline.AutoSize = true;
			this.loldline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loldline.Location = new System.Drawing.Point(316, 95);
			this.loldline.Name = "loldline";
			this.loldline.Size = new System.Drawing.Size(24, 13);
			this.loldline.TabIndex = 40;
			this.loldline.Text = "OK";
			// 
			// lprogram
			// 
			this.lprogram.AutoSize = true;
			this.lprogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lprogram.Location = new System.Drawing.Point(413, 67);
			this.lprogram.Name = "lprogram";
			this.lprogram.Size = new System.Drawing.Size(24, 13);
			this.lprogram.TabIndex = 39;
			this.lprogram.Text = "OK";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(2, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 38;
			this.label3.Text = "Line Mới:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(2, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 35;
			this.label2.Text = "Line Hiện Tại:";
			// 
			// txtProgram
			// 
			this.txtProgram.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProgram.Location = new System.Drawing.Point(179, 63);
			this.txtProgram.Name = "txtProgram";
			this.txtProgram.Size = new System.Drawing.Size(228, 20);
			this.txtProgram.TabIndex = 31;
			this.txtProgram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProgram_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "Chương Trình Cũ:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dataGridView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(448, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(536, 561);
			this.panel2.TabIndex = 1;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(530, 555);
			this.dataGridView1.TabIndex = 0;
			// 
			// frmF_Combine_Program
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmF_Combine_Program";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Combine chương trình SMT";
			this.Load += new System.EventHandler(this.frmF_Combine_Program_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btChuyenLine;
        private System.Windows.Forms.Label lblProgram2;
        private System.Windows.Forms.TextBox txtProgram2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lwait;
        private System.Windows.Forms.ComboBox cbOldLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbNewLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lnewline;
        private System.Windows.Forms.Label loldline;
        private System.Windows.Forms.Label lprogram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Label label1;
    }
}