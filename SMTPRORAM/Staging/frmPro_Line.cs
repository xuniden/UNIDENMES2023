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
using UnidenDAL.Staging;
using UnidenDAL.SysControl;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;
namespace SMTPRORAM.Staging
{
    public partial class frmPro_Line : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        public frmPro_Line()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            cbDeptCode.Enabled = t;
            txtLineName.Enabled = t;
        }

        void ResetControll()
        {

            cbDeptCode.Text = "";
            txtLineName.Text = "";
            LoadCbDept();
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void LoadCbDept()
        {
            var cbdept = new ViewDept();
            cbdept.DeptID = 0;
            cbdept.DeptCode = "[None]";

            var lstView = UVDeptDAL.Instance.getAllDept();
            lstView.Add(cbdept);
            cbDeptCode.DataSource = lstView.OrderBy(p => p.DeptCode).ToList();
            cbDeptCode.DisplayMember = "DeptCode";
            cbDeptCode.ValueMember = "DeptId";
        }
        private void DisplayViewData()
        {
            dgView.DataSource = UVProLineDAL.Instance.getAllProdLine();
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmPro_Line_Load(object sender, EventArgs e)
        {
            LoadCbDept();
            DisplayViewData();
            progressBar.Visible = false;
            showHideControll(true);
            _enable(false);

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
            txtLineName.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtLineName.Focus();
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
                    bool flag = UVProLineDAL.Instance.RemoveProdLine(Id);
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
            if (cbDeptCode.Text.Trim().Equals("") || string.IsNullOrEmpty(cbDeptCode.Text.Trim()) || cbDeptCode.Text == "[None]")
            {
                MessageBox.Show("Div Code không được để trống hoặc [None]!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDeptCode.Focus();
                return false;
            }
            if (txtLineName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Dept Code không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLineName.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var prodLine = new UV_PRO_LINE();
                prodLine.LineName = txtLineName.Text;
                prodLine.DeptID = long.Parse(cbDeptCode.SelectedValue.ToString());
                prodLine.CreateDate = CommonDAL.Instance.getSqlServerDatetime();
                if (AddFlag)
                {
                    if (UVProLineDAL.Instance.Add(prodLine))
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
                    prodLine.DeptID = Id;
                    if (UVProLineDAL.Instance.Update(prodLine))
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
                UVPcbListDAL.Instance.RemoveDuplicateRow();
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
                string[] str = new string[2];
                for (cCnt = 1; cCnt <= 2; cCnt++)
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
                string _lineName;
                long _deptId;
                _lineName = str[0].ToString();
                _deptId = long.Parse(str[1].ToString());
                if (!_lineName.Equals(""))
                {
                    bool _CheckLineNameExist;
                    bool _CheckDeptIdExist;
                    var lineName = new UV_PRO_LINE();
                    _CheckLineNameExist = UVProLineDAL.Instance.CheckLineNameExist(_lineName);
                    _CheckDeptIdExist = UVProLineDAL.Instance.CheckDeptIdExist(_deptId);
                    lineName.LineName = str[0].ToString();
                    lineName.DeptID = long.Parse(str[1].ToString());
                    lineName.CreateDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (_CheckLineNameExist == false && _CheckDeptIdExist == true)
                    {
                        UVProLineDAL.Instance.Add(lineName);
                    }
                }
                progressBar.Value = rCnt;
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
                dgView.DataSource = UVProLineDAL.Instance.getAllProdLine(txtSearch.Text.Trim());
                dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void txtFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SearchData();
            }
           
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id = long.Parse(row.Cells["Id"].Value.ToString());
                txtLineName.Text = row.Cells["LineName"].Value.ToString();
                long deptId = long.Parse(row.Cells["DeptID"].Value.ToString());
                var dept = UVDeptDAL.Instance.getDeptByID(deptId);
                if (dept != null)
                {
                    cbDeptCode.Text = dept.DeptCode;
                }
                else
                {
                    MessageBox.Show("Đã có  lỗi xảy ra trong khi chọn sửa Dept", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }
    }
}
