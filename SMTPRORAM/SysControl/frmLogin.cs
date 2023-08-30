using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.SysControl
{
    public partial class frmLogin : Form
	{
        public bool UserSuccessfullyAuthenticated { get; private set; }
		
		public frmLogin()
        {
            InitializeComponent();
			
		}

        private void iconbtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập Id của người dùng vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserId.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập mật khẩu của người dùng vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            var check = SYSUserDAL.Instance.checkLogin(txtUserId.Text.Trim(), txtPassword.Text.Trim());

            if (check != null)
            {
                // Kiểm tra xem người dùng này đã đăng nhập ở máy khác chưa?
                // Nếu đăng nhập rồi thì không cho đăng nhập tiếp
                Program.UserId = check.UserID;
                Program.username = check.UserID;
                Program.FullName = check.FullName;
                Program.DeptID = long.Parse(check.DeptID.ToString());
                var ndept = new UV_DEPT();
                ndept = UVDeptDAL.Instance.getDeptByID(Program.DeptID);
                Program.Dept = ndept.DeptCode;


                string hostName = Dns.GetHostName();
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

                var loginSec = new tbl_SessionLogin();
                if (hostName.Equals("") || string.IsNullOrEmpty(hostName))
                {
                    hostName = "";
                }
                else
                {
                    loginSec.HostName = hostName;
                }
                if (myIP.Equals("") || string.IsNullOrEmpty(myIP))
                {
                    myIP = "";
                }
                else
                {
                    loginSec.IpAddress = myIP;
                }
                loginSec.UserId = txtUserId.Text.Trim();
                loginSec.Dept = ndept.DeptCode;
                loginSec.LoginTime = CommonDAL.Instance.getSqlServerDatetime();

                var checkLogined = new tbl_SessionLogin();
                checkLogined = SessionLoginDAL.Instance.GetLogin(txtUserId.Text.Trim());

                if (checkLogined != null)
                {
                    //if (checkLogined.HostName != hostName)
                    //{
                    //    if (checkLogined.UserId.ToLower() == "admin")
                    //    {
                    //        UserSuccessfullyAuthenticated = true;
                    //        bool result = SessionLoginDAL.Instance.Update(loginSec);
                    //        Close();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("User này đã đăng nhập ở máy khác có: " + Environment.NewLine +
                    //            "Host Name: " + checkLogined.HostName + Environment.NewLine +
                    //            "Địa chỉ IP: " + checkLogined.IpAddress + Environment.NewLine +
                    //            "Thời gian: " + checkLogined.LoginTime, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        txtUserId.Clear();
                    //        txtPassword.Clear();
                    //        txtUserId.Focus();
                    //    }
                    //}
                    //else
                    //{
                        UserSuccessfullyAuthenticated = true;
                        bool result = SessionLoginDAL.Instance.Update(loginSec);
                        Close();
                    //}
                }
                else
                {
                    // Nếu chưa đăng nhập thì lưu thông tin đăng nhập lại
                    UserSuccessfullyAuthenticated = true;
                    bool result = SessionLoginDAL.Instance.Add(loginSec);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserId.Focus();
                return;
            }
        }

        private void iconCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

		private void frmLogin_Load(object sender, EventArgs e)
		{
			
			// autoScaleMonitor.AdjustControls(this.Controls, scaleRatio);
			// AdjustControls(this.Controls, scaleRatio);
		}

		private void AdjustControls(Control.ControlCollection controls, float scaleRatio)
		{
			foreach (Control control in controls)
			{
				control.Font = new Font(control.Font.FontFamily, control.Font.Size * scaleRatio);
				control.Scale(new SizeF(scaleRatio, scaleRatio));

				if (control.Controls.Count > 0)
				{
					AdjustControls(control.Controls, scaleRatio);
				}
			}
		}
	}
}
