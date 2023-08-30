namespace SMTPRORAM.Smt.Output
{
    partial class frmCheckOutputErrorAndApprove
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtApprove = new System.Windows.Forms.TextBox();
			this.iconbtnApprove = new FontAwesome.Sharp.IconButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.lblRemark = new System.Windows.Forms.Label();
			this.lblApprove = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(7, 175);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Leader Xác nhận lỗi:";
			// 
			// txtApprove
			// 
			this.txtApprove.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtApprove.Location = new System.Drawing.Point(118, 172);
			this.txtApprove.Name = "txtApprove";
			this.txtApprove.Size = new System.Drawing.Size(144, 20);
			this.txtApprove.TabIndex = 2;
			// 
			// iconbtnApprove
			// 
			this.iconbtnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.iconbtnApprove.ForeColor = System.Drawing.Color.Black;
			this.iconbtnApprove.IconChar = FontAwesome.Sharp.IconChar.None;
			this.iconbtnApprove.IconColor = System.Drawing.Color.Black;
			this.iconbtnApprove.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnApprove.Location = new System.Drawing.Point(140, 248);
			this.iconbtnApprove.Name = "iconbtnApprove";
			this.iconbtnApprove.Size = new System.Drawing.Size(133, 34);
			this.iconbtnApprove.TabIndex = 4;
			this.iconbtnApprove.Text = "Xác nhận là có lỗi";
			this.iconbtnApprove.UseVisualStyleBackColor = true;
			this.iconbtnApprove.Click += new System.EventHandler(this.iconbtnApprove_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(278, 175);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "(Nhập ID của leader để xác nhận)";
			// 
			// txtRemark
			// 
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtRemark.Location = new System.Drawing.Point(118, 198);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(311, 20);
			this.txtRemark.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(7, 201);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Remark:";
			// 
			// richTextBox
			// 
			this.richTextBox.Location = new System.Drawing.Point(10, 12);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(456, 120);
			this.richTextBox.TabIndex = 6;
			this.richTextBox.Text = "";
			// 
			// lblRemark
			// 
			this.lblRemark.AutoSize = true;
			this.lblRemark.Location = new System.Drawing.Point(435, 201);
			this.lblRemark.Name = "lblRemark";
			this.lblRemark.Size = new System.Drawing.Size(25, 13);
			this.lblRemark.TabIndex = 7;
			this.lblRemark.Text = "NG";
			// 
			// lblApprove
			// 
			this.lblApprove.AutoSize = true;
			this.lblApprove.Location = new System.Drawing.Point(453, 175);
			this.lblApprove.Name = "lblApprove";
			this.lblApprove.Size = new System.Drawing.Size(25, 13);
			this.lblApprove.TabIndex = 8;
			this.lblApprove.Text = "NG";
			// 
			// frmCheckOutputErrorAndApprove
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 306);
			this.Controls.Add(this.lblApprove);
			this.Controls.Add(this.lblRemark);
			this.Controls.Add(this.richTextBox);
			this.Controls.Add(this.txtRemark);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.iconbtnApprove);
			this.Controls.Add(this.txtApprove);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ForeColor = System.Drawing.Color.Red;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCheckOutputErrorAndApprove";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KIỂM TRA VÀ XÁC NHẬN LỖI";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckOutputErrorAndApprove_FormClosing);
			this.Load += new System.EventHandler(this.frmCheckOutputErrorAndApprove_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApprove;
        private FontAwesome.Sharp.IconButton iconbtnApprove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox;
		private System.Windows.Forms.Label lblRemark;
		private System.Windows.Forms.Label lblApprove;
	}
}