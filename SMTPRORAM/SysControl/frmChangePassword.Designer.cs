namespace SMTPRORAM.SysControl
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconbtnCancel = new FontAwesome.Sharp.IconButton();
            this.iconbtnChangePassword = new FontAwesome.Sharp.IconButton();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(147, 12);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(165, 20);
            this.txtCurrentPassword.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iconbtnCancel);
            this.panel1.Controls.Add(this.iconbtnChangePassword);
            this.panel1.Controls.Add(this.txtConfirmNewPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNewPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCurrentPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 139);
            this.panel1.TabIndex = 7;
            // 
            // iconbtnCancel
            // 
            this.iconbtnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnCancel.IconColor = System.Drawing.Color.Black;
            this.iconbtnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnCancel.Location = new System.Drawing.Point(223, 106);
            this.iconbtnCancel.Name = "iconbtnCancel";
            this.iconbtnCancel.Size = new System.Drawing.Size(89, 23);
            this.iconbtnCancel.TabIndex = 13;
            this.iconbtnCancel.Text = "Hủy bỏ";
            this.iconbtnCancel.UseVisualStyleBackColor = true;
            this.iconbtnCancel.Click += new System.EventHandler(this.iconbtnCancel_Click);
            // 
            // iconbtnChangePassword
            // 
            this.iconbtnChangePassword.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconbtnChangePassword.IconColor = System.Drawing.Color.Black;
            this.iconbtnChangePassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconbtnChangePassword.Location = new System.Drawing.Point(110, 106);
            this.iconbtnChangePassword.Name = "iconbtnChangePassword";
            this.iconbtnChangePassword.Size = new System.Drawing.Size(95, 23);
            this.iconbtnChangePassword.TabIndex = 12;
            this.iconbtnChangePassword.Text = "Đổi mật khẩu";
            this.iconbtnChangePassword.UseVisualStyleBackColor = true;
            this.iconbtnChangePassword.Click += new System.EventHandler(this.iconbtnChangePassword_Click);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(147, 75);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '*';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(165, 20);
            this.txtConfirmNewPassword.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Xác nhận mật khẩu mới:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(147, 43);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(165, 20);
            this.txtNewPassword.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mật khẩu hiện tại:";
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 139);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu người dùng";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconbtnCancel;
        private FontAwesome.Sharp.IconButton iconbtnChangePassword;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}