using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.SysControl;

namespace SMTPRORAM.SysControl
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconbtnChangePassword_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mật khẩu hiện tại có đúng không
            if (txtCurrentPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập mật khẩu hiện tại vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Focus();
                return;
            }
            if (txtNewPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập mật khẩu mới vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
                return;
            }
            if (txtConfirmNewPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập xác nhận mật khẩu mới vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmNewPassword.Focus();
                return;
            }
            if (!txtConfirmNewPassword.Text.Trim().Equals(txtNewPassword.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmNewPassword.Focus();
                return;
            }
            var user = SYSUserDAL.Instance.getOldPassword(Program.UserId);
            if (user.ePassword != txtCurrentPassword.Text.Trim())
            {
                MessageBox.Show("Nhập mật khẩu hiện tại không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentPassword.Focus();
                return;
            }
            else
            {
                user.ePassword = txtNewPassword.Text.Trim();
                bool updat = SYSUserDAL.Instance.EditUser(user);
                if (updat == true)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();

                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCurrentPassword.Focus();
                    return;
                }
            }

        }
    }
}
