namespace SMTPRORAM.SysControl
{
    partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.iconCancel = new FontAwesome.Sharp.IconButton();
			this.iconbtnLogin = new FontAwesome.Sharp.IconButton();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUserId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// iconCancel
			// 
			this.iconCancel.AutoSize = true;
			this.iconCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.iconCancel.IconChar = FontAwesome.Sharp.IconChar.Code;
			this.iconCancel.IconColor = System.Drawing.Color.Black;
			this.iconCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconCancel.IconSize = 16;
			this.iconCancel.Location = new System.Drawing.Point(246, 90);
			this.iconCancel.Name = "iconCancel";
			this.iconCancel.Size = new System.Drawing.Size(75, 23);
			this.iconCancel.TabIndex = 11;
			this.iconCancel.Text = "Close";
			this.iconCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconCancel.UseVisualStyleBackColor = true;
			this.iconCancel.Click += new System.EventHandler(this.iconCancel_Click);
			// 
			// iconbtnLogin
			// 
			this.iconbtnLogin.AutoSize = true;
			this.iconbtnLogin.IconChar = FontAwesome.Sharp.IconChar.User;
			this.iconbtnLogin.IconColor = System.Drawing.Color.Black;
			this.iconbtnLogin.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconbtnLogin.IconSize = 16;
			this.iconbtnLogin.Location = new System.Drawing.Point(123, 90);
			this.iconbtnLogin.Name = "iconbtnLogin";
			this.iconbtnLogin.Size = new System.Drawing.Size(92, 23);
			this.iconbtnLogin.TabIndex = 10;
			this.iconbtnLogin.Text = "Đăng nhập";
			this.iconbtnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconbtnLogin.UseVisualStyleBackColor = true;
			this.iconbtnLogin.Click += new System.EventHandler(this.iconbtnLogin_Click);
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(123, 54);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(198, 20);
			this.txtPassword.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(34, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Password:";
			// 
			// txtUserId
			// 
			this.txtUserId.Location = new System.Drawing.Point(123, 19);
			this.txtUserId.Name = "txtUserId";
			this.txtUserId.Size = new System.Drawing.Size(198, 20);
			this.txtUserId.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "User ID:";
			// 
			// frmLogin
			// 
			this.AcceptButton = this.iconbtnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.iconCancel;
			this.ClientSize = new System.Drawing.Size(357, 133);
			this.Controls.Add(this.iconCancel);
			this.Controls.Add(this.iconbtnLogin);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtUserId);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đăng nhập hệ thống";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton iconCancel;
        private FontAwesome.Sharp.IconButton iconbtnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
    }
}