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
    public partial class frmDiv : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        public frmDiv()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            txtDivCode.Enabled = t;
            txtDivDesc.Enabled = t;
        }

        void ResetControll()
        {
            txtDivCode.Text = "";
            txtDivDesc.Text = "";
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }

        private void frmDiv_Load(object sender, EventArgs e)
        {
            GridViewDisplay();
            progressBar.Visible = false;
            showHideControll(true);
            _enable(false);
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

        }
        private void GridViewDisplay()
        {
            dgView.DataSource = UVDivDAL.Instance.getAllDiv();
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void ClickSearch()
        {
            if (txtSearch.Text == "" || string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                GridViewDisplay();
            }
            else
            {
                dgView.DataSource = UVDivDAL.Instance.SearchDiv(txtSearch.Text.Trim());
                dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            ClickSearch();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            ClickSearch();
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            txtDivCode.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtDivCode.Focus();
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            showHideControll(true);
            _enable(false);
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool flag = UVDivDAL.Instance.RemoveDiv(Id);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GridViewDisplay();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GridViewDisplay();
                        return;
                    }
                }
            }
        }
        private bool IsDataOK()
        {
            if (txtDivCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Div Code không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDivCode.Focus();
                return false;
            }
            if (txtDivDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Div Desc Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDivDesc.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var div = new UV_DIV();
                div.DivCode = txtDivCode.Text;
                div.DivDesc = txtDivDesc.Text;
                div.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                if (AddFlag)
                {
                    if (UVDivDAL.Instance.Add(div))
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
                    div.DivID = Id;
                    if (UVDivDAL.Instance.Update(div))
                    {
                        MessageBox.Show("Ghi thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ghi không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                AddFlag = false;
                GridViewDisplay();
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id = long.Parse(row.Cells["DivID"].Value.ToString());
                txtDivCode.Text = row.Cells["DivCode"].Value.ToString();
                txtDivDesc.Text = row.Cells["DivDesc"].Value.ToString();
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
                string _divcode;
                _divcode = str[0].ToString();
                if (!_divcode.Equals(""))
                {
                    bool _chkExist;
                    var div = new UV_DIV();
                    _chkExist = UVDivDAL.Instance.CheckDivExist(_divcode);
                    div.DivCode = str[0].ToString();
                    div.DivDesc = str[1].ToString();
                    div.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (_chkExist == false)
                    {
                        UVDivDAL.Instance.Add(div);
                    }
                }
                j = 0;

            }
            MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GridViewDisplay();
            txtFile.Text = "";
            progressBar.Visible = false;
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            CommonDAL.Instance.releaseObject(xlWorkSheet);
            CommonDAL.Instance.releaseObject(xlWorkBook);
            CommonDAL.Instance.releaseObject(xlApp);
        }
    }
}
