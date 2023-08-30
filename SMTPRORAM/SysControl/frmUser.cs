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
using UnidenDAL;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.SysControl
{
    public partial class frmUser : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        public static string userID { get; private set; }
        public frmUser()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            txtUserId.Enabled = t;
            txtFullName.Enabled = t;
            txtPassword.Enabled = t;
            cbDept.Enabled = t;
            chkAccessStatus.Enabled = t;
        }

        void ResetControll()
        {
            txtUserId.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            cbDept.Text = "";
            chkAccessStatus.Enabled = true;
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            dgUser.DataSource= SYSUserDAL.Instance.getListUsers();
            dgUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            progressBar.Visible = false;
            showHideControll(true);
            _enable(false);
            LoadDept();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            //var frm = new frmUser();
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();

            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        private void LoadDept()
        {
            var cbdept = new List<ViewDept>();
            var dept = new ViewDept();
            cbdept = UVDeptDAL.Instance.getAllDept();
            dept.DeptCode = "[None]";
            cbdept.Add(dept);
            cbDept.DataSource = cbdept.OrderBy(p => p.DeptCode).ToList();
            cbDept.DisplayMember = "DeptCode";
            cbDept.ValueMember = "DeptID";
        }

        private void dgUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgUser.RowCount > 0)
            {
                long deptId = 0;
                DataGridViewRow row = dgUser.SelectedCells[0].OwningRow;
                txtUserId.Text = row.Cells["UserId"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtPassword.Text = row.Cells["ePassword"].Value.ToString();
                deptId= long.Parse(row.Cells["DeptID"].Value.ToString());
                if (deptId>0)
                {
                    var deptInfo = new UV_DEPT();
                    deptInfo= UVDeptDAL.Instance.getDeptByID(deptId);
                    cbDept.Text = deptInfo.DeptCode;
                }
                //cbDept.Text = row.Cells["Dept"].Value.ToString();
                if ((bool?)row.Cells["IsDisable"].Value == true)
                {
                    chkAccessStatus.Checked = true;
                }
                else
                {
                    chkAccessStatus.Checked = false;
                }
            }
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            //CommonDAL.Instance.CheckButtonFunction(this, lstUBFunction);
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            showHideControll(true);
            _enable(false);
        }
        private bool IsDataOK()
        {
            if (txtUserId.Text.Trim().Equals(""))
            {
                MessageBox.Show("User ID không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFullName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Họ và tên không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.SelectAll();
                txtFullName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                MessageBox.Show("Password không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll();
                txtPassword.Focus();
                return false;
            }
            if (cbDept.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bộ phạn không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDept.SelectAll();
                cbDept.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var user = new SYS_Users();
                user.UserID = txtUserId.Text;
                user.FullName = txtFullName.Text;
                user.ePassword = txtPassword.Text;
                user.DeptID = long.Parse(cbDept.SelectedValue.ToString());
                user.IsDisable = chkAccessStatus.Checked;
               
                
                if (AddFlag)
                {
                    if (SYSUserDAL.Instance.checkExistUser(txtUserId.Text))
                    {
                        MessageBox.Show("User Id này đã có trong csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUserId.SelectAll();
                        txtUserId.Focus();
                        return;
                    }
                    else
                    {
                        user.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        user.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        if (SYSUserDAL.Instance.Add(user))
                        {                            
                            MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    user.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (SYSUserDAL.Instance.EditUser(user))
                    {                        
                        MessageBox.Show("Ghi thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ghi không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                AddFlag = false;
                dgUser.DataSource = SYSUserDAL.Instance.getListUsers();
                dgUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            _enable(true);
            txtUserId.Enabled = false;
            showHideControll(false);
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            var lst = SYSUserDAL.Instance.findUser(txtSearch.Text.Trim());
            if (lst.Count > 0)
            {
                dgUser.DataSource = lst;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được tìm thấy :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void iconbtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Please Select Excel File to Import |*.xlsx;*.xls";
            op.Title = "Select Excel";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = op.FileName;
            }
        }

        private void iconbtnUpload_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            int j = 0;
            int rCnt = 0;
            int cCnt = 0;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(txtFile.Text.Trim(), 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            progressBar.Minimum = 0;
            progressBar.Maximum = range.Rows.Count;
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                string[] str = new string[5];
                for (cCnt = 1; cCnt <= 5; cCnt++)
                {
                    if (!string.IsNullOrEmpty((range.Cells[rCnt, cCnt] as Excel.Range).Text) || (range.Cells[rCnt, cCnt] as Excel.Range).Text == "")
                    {
                        str[j] = (range.Cells[rCnt, cCnt] as Excel.Range).Text;
                        j = j + 1;
                    }
                    else
                    {
                        str[j] = "";
                        j = j + 1;
                    }
                }
                string _userId;


                _userId = str[0].ToString();
                if (!_userId.Equals(""))
                {
                    bool _chkExist;
                    var user = new SYS_Users();
                    _chkExist = SYSUserDAL.Instance.checkExistUser(_userId);
                    user.UserID = str[0].ToString();
                    user.FullName = str[1].ToString();
                    user.ePassword = str[2].ToString();
                    user.DeptID = long.Parse(str[3].ToString());
                    if (str[4].ToString().Equals("") || str[4].ToString().Equals("0"))
                    {
                        user.IsDisable = false;
                    }
                    else
                    {
                        user.IsDisable = true;
                    }
                    // Đã tồn tại model này thì update

                    if (_chkExist == true)
                    {
                        user.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        SYSUserDAL.Instance.EditUser(user);
                    }
                    else
                    {
                        user.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        user.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        SYSUserDAL.Instance.Add(user);
                    }
                }
                j = 0;

            }
            MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar.Visible = false;
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            CommonDAL.Instance.releaseObject(xlWorkSheet);
            CommonDAL.Instance.releaseObject(xlWorkBook);
            CommonDAL.Instance.releaseObject(xlApp);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtSearch.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Hãy nhập điều kiện tìm kiếm vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSearch.Focus();
                    return;
                }
                else
                {
                    var lst = SYSUserDAL.Instance.findUser(txtSearch.Text.Trim());
                    if (lst.Count > 0)
                    {
                        dgUser.DataSource = lst;
                        dgUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được tìm thấy :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void StripMenuItemUserPermission_Click(object sender, EventArgs e)
        {            
            DataGridViewRow row = dgUser.SelectedCells[0].OwningRow;
            userID = row.Cells["UserId"].Value.ToString();
            frmUserRight frmUserRight = new frmUserRight();
            frmUserRight.ShowDialog();
        }
    }
}
