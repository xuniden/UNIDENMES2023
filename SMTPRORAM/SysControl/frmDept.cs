using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.SysControl;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.SysControl
{
    public partial class frmDept : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        public frmDept()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            cbDivCode.Enabled = t;
            txtDeptCode.Enabled = t;
            txtDeptDesc.Enabled = t;
        }

        void ResetControll()
        {

            cbDivCode.Text = "";
            txtDeptCode.Text = "";
            txtDeptDesc.Text = "";
            LoadCbDiv();
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void DisplayViewData()
        {
            dgView.DataSource = UVDeptDAL.Instance.getAllDept();
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void LoadCbDiv()
        {
            var dl = new UVDiv();
            dl.DivID = 0;
            dl.DivCode = "[None]";
            dl.DivDesc = "[None]";
            var lstDiv = UVDivDAL.Instance.getAllDiv();
            lstDiv.Add(dl);
            lstDiv = lstDiv.OrderBy(x => x.DivCode).ToList();
            cbDivCode.DataSource = lstDiv;
            cbDivCode.DisplayMember = "DivCode";
            cbDivCode.ValueMember = "DivID";
        }

        private void frmDept_Load(object sender, EventArgs e)
        {
            DisplayViewData();
            progressBar.Visible = false;
            showHideControll(true);
            _enable(false);
            // Load Div by DivCode vs DivId
            LoadCbDiv();

            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {

            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            txtDeptCode.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtDeptCode.Focus();
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool flag = UVDeptDAL.Instance.RemoveDept(Id);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayViewData();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DisplayViewData();
                        return;
                    }
                }
            }
        }
        private bool IsDataOK()
        {
            if (cbDivCode.Text.Trim().Equals("") || string.IsNullOrEmpty(cbDivCode.Text.Trim()) || cbDivCode.Text == "[None]")
            {
                MessageBox.Show("Div Code không được để trống hoặc [None]!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDivCode.Focus();
                return false;
            }
            if (txtDeptCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Dept Code không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDeptCode.Focus();
                return false;
            }
            if (txtDeptDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Dept Desc Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDeptDesc.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var dept = new UV_DEPT();
                dept.DeptCode = txtDeptCode.Text;
                dept.DeptDesc = txtDeptDesc.Text;
                dept.DivID = long.Parse(cbDivCode.SelectedValue.ToString());
                dept.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();

                if (AddFlag)
                {
                    var checkExist = UVDeptDAL.Instance.checkExist(dept.DeptCode);
                    if (checkExist==null)
                    {
                        if (UVDeptDAL.Instance.Add(dept))
                        {
                            MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã có Dept code này trong csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
                else
                {
                    dept.DeptID = Id;
                    if (UVDeptDAL.Instance.Update(dept))
                    {
                        MessageBox.Show("Ghi thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ghi không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                AddFlag = false;
                DisplayViewData();
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            showHideControll(true);
            _enable(false);
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
                string[] str = new string[3];
                for (cCnt = 1; cCnt <= 3; cCnt++)
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
                string _deptCode;
                long _divId;
                _deptCode = str[0].ToString();
                _divId = long.Parse(str[2].ToString());
                if (!_deptCode.Equals(""))
                {
                    bool _chkDeptExist;
                    bool _chkDivExist;
                    var dept = new UV_DEPT();
                    _chkDeptExist = UVDeptDAL.Instance.CheckDeptExist(_deptCode);
                    _chkDivExist = UVDeptDAL.Instance.CheckDivIdExist(_divId);
                    dept.DeptCode = str[0].ToString();
                    dept.DeptDesc = str[1].ToString();
                    dept.DivID = long.Parse(str[2].ToString());
                    dept.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (_chkDeptExist == false && _chkDivExist == true)
                    {
                        UVDeptDAL.Instance.Add(dept);
                    }
                }
                j = 0;

            }
            MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayViewData();
            txtFile.Text = "";
            progressBar.Visible = false;
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            CommonDAL.Instance.releaseObject(xlWorkSheet);
            CommonDAL.Instance.releaseObject(xlWorkBook);
            CommonDAL.Instance.releaseObject(xlApp);
        }
        private void SearchData()
        {
            if (txtSearch.Text.Trim().Equals("") || string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                DisplayViewData();
            }
            else
            {
                dgView.DataSource = UVDeptDAL.Instance.getAllDept(txtSearch.Text.Trim());
                dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id = long.Parse(row.Cells["DeptID"].Value.ToString());
                txtDeptCode.Text = row.Cells["DeptCode"].Value.ToString();
                txtDeptDesc.Text = row.Cells["DeptDesc"].Value.ToString();
                long divId = long.Parse(row.Cells["DivID"].Value.ToString());
                var div = UVDivDAL.Instance.getDivByID(divId);
                if (div != null)
                {
                    cbDivCode.Text = div.DivCode;
                }
                else
                {
                    MessageBox.Show("Đã có  lỗi xảy ra trong khi chọn sửa Dept", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchData();
        }
    }
}
