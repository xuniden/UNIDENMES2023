using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTPRORAM
{
    public partial class F_UserManagement : Form
    {
        public F_UserManagement()
        {
            InitializeComponent();
        }
        bool flag = false;
        private void DisableAll()
        {
            txtUser.Enabled = true;
            txtpass.Enabled = false;
            txtconfirpass.Enabled = false;
            txtname.Enabled = false;
            txtemp.Enabled = false;
        }

        private void ResetAll()
        {
            txtUser.Enabled = true;
            txtpass.Enabled = true;
            txtconfirpass.Enabled = true;
            txtname.Enabled = true;
            txtemp.Enabled = true;
            txtUser.Focus();
        }
        private void F_UserManagement_Load(object sender, EventArgs e)
        {
            btSave.Enabled = false;
            DisableAll();
            DataTable dt = new DataTable();
            dt = USERService.USER_GetByAll();
            if (dt.Rows.Count>0)
            {
                dgView.DataSource = dt;
                dgView.AutoResizeColumns();
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu ");
                return;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            txtUser.Text = txtUser.Text.Trim().ToLower();
            var csv = new UserInfo();
            csv.username = txtUser.Text;
            DataTable dt = new DataTable();
            dt = USERService.USER_GetByUser(csv);
            if (dt.Rows.Count>0)
            {
                dgView.DataSource = dt;
                dgView.AutoResizeColumns();
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu giống ");
                return;
            }
        }
        private void Ena()
        {
            txtUser.Text = "";
            txtpass.Text = "";
            txtconfirpass.Text = "";
            txtname.Text = "";
            txtemp.Text = "";
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            flag = false;
            ResetAll();
            Ena();
            btSave.Enabled = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập user name");
                txtUser.Focus();
            }
            else
            {
                // Kiểm tra xem user name có trong csdl không???
                if (txtpass.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Nhập mật khẩu vào đây");
                    txtpass.Focus();
                }
                else
                {
                    if (txtconfirpass.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Nhập xác nhận mật khẩu vào đây");
                        txtconfirpass.Focus();
                    }
                    else
                    {
                        if (txtpass.Text.Trim() !=txtconfirpass.Text.Trim())
                        {
                            MessageBox.Show("Mật khẩu và xác nhận mật khẩu không giống nhau");
                            txtpass.Focus();
                        }
                        else
                        {
                            if (txtname.Text.Trim().Equals(""))
                            {
                                MessageBox.Show("Nhập Tên đầy đủ không dấu vào đây");
                                txtname.Focus();
                            }
                            else
                            {
                                if (txtemp.Text.Trim().Equals(""))
                                {
                                    MessageBox.Show("Nhập Tên đầy đủ không dấu vào đây");
                                    txtemp.Focus();
                                }
                                else
                                {
                                    if (cbPermission.Text.Equals(""))
                                    {
                                        MessageBox.Show("Hãy Chọn Quyền Cho User");
                                        cbPermission.Focus();
                                    }
                                    else
                                    {
                                        if (cbStatus.Text.Equals(""))
                                        {
                                            MessageBox.Show("Hãy Chọn trạng thái cho user là Active hay Disable");
                                            cbStatus.Focus();
                                        }
                                        else
                                        {
                                            if (cbDept.Text.Equals(""))
                                            {
                                                MessageBox.Show("Hãy Chọn Bộ Phận cho user là Active hay Disable");
                                                cbDept.Focus();
                                            }
                                            else
                                            {
                                                var obj = new UserInfo();
                                                obj.username = txtUser.Text;
                                                obj.password = txtpass.Text;
                                                obj.fullname = txtname.Text;
                                                obj.idnumber = txtemp.Text;
                                                obj.permission = cbPermission.Text;
                                                obj.Status = cbStatus.Text;
                                                obj.CreateDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                                obj.Dept = cbDept.Text;
                                                if (flag == false) // Thêm mới
                                                {
                                                    // Nếu thêm mới thì phải kiểm tra xem user này có trong csdl chưa
                                                    DataTable du = new DataTable();
                                                    du = USERService.USER_GetByUser(obj);
                                                    if (du.Rows.Count > 0)
                                                    {
                                                        MessageBox.Show("User này đã có trong csdl ");
                                                        txtUser.Focus();
                                                        txtUser.SelectAll();
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            USERService.USER_Insert(obj);
                                                            DisplayData();
                                                            MessageBox.Show("Đã Thêm thành công vào csdl");
                                                            Ena();

                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Có lỗi xảy ra:  " + ex.Message);
                                                            return;
                                                        }
                                                    }
                                                }
                                                else // Update thông tin
                                                {
                                                    try
                                                    {
                                                        USERService.USER_Update(obj);
                                                        MessageBox.Show("Đã Sửa thành công vào csdl");
                                                        DisplayData();
                                                        Ena();
                                                        DisableAll();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show("Có lỗi xảy ra:  " + ex.Message);
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            flag = true;
            txtUser.Enabled = false;
            txtpass.Enabled = true;
            txtconfirpass.Enabled = true;
            txtname.Enabled = true;
            txtemp.Enabled = true;
            txtpass.Focus();
            btSave.Enabled = true;
        }

        private void dgView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {           
            txtUser.Text = dgView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtpass.Text = dgView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtname.Text = dgView.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtemp.Text = dgView.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbPermission.Text = dgView.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbStatus.Text = dgView.Rows[e.RowIndex].Cells[6].Value.ToString();
            cbDept.Text = dgView.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var csv = new UserInfo();
            csv.username = txtUser.Text;
            try
            {
                USERService.USER_Delete(csv);
                MessageBox.Show("Đã Xóa Thành công");
                DisplayData();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra:  " + ex.Message);
                return;
            }
        }

        private void DisplayData()
        {
            DataTable dt = new DataTable();
            dt = USERService.USER_GetByAll();
            if (dt.Rows.Count>0)
            {
                dgView.DataSource = dt;
                dgView.AutoResizeColumns();
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
        }

    }
}
