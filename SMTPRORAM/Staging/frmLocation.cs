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
    public partial class frmLocation : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        public frmLocation()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            txtLocCode.Enabled = t;
            txtLocName.Enabled = t;
            txtRemark.Enabled = t;
        }

        void ResetControll()
        {

            txtLocCode.Text = "";
            txtLocName.Text = "";
            txtRemark.Text = "";
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
            dgView.DataSource = UVLocationDAL.Instance.getAllLocation();
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
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
            txtLocCode.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtLocCode.Focus();
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
                    bool flag = UVLocationDAL.Instance.Remove(Id);
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
            if (txtLocCode.Text.Trim().Equals("") || string.IsNullOrEmpty(txtLocCode.Text.Trim()))
            {
                MessageBox.Show("Location Code không được để trống hoặc [None]!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocCode.Focus();
                return false;
            }
            if (txtLocName.Text.Trim().Equals("") || string.IsNullOrEmpty(txtLocName.Text.Trim()))
            {
                MessageBox.Show("Location Name không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocName.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var sgLocation = new UV_STAGING_LOCATION();
                sgLocation.Loc = txtLocCode.Text;
                sgLocation.LocName = txtLocName.Text;
                sgLocation.LocRemark = txtRemark.Text;
                sgLocation.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                if (AddFlag)
                {
                    if (UVLocationDAL.Instance.Add(sgLocation))
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
                    sgLocation.ID = Id;
                    if (UVLocationDAL.Instance.Update(sgLocation))
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
                UVPcbListDAL.Instance.RemoveDuplicateRow();
                ResetControll();
                _enable(false);
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
                string _loc;

                _loc = str[0].ToString();

                if (!_loc.Equals(""))
                {

                    bool _CheckLocExist;
                    var sgLoction = new UV_STAGING_LOCATION();
                    _CheckLocExist = UVLocationDAL.Instance.CheckLocExist(_loc);

                    sgLoction.Loc = str[0].ToString().Trim();
                    sgLoction.LocName = str[1].ToString().Trim();
                    sgLoction.LocRemark = str[2].ToString().Trim();
                    sgLoction.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (_CheckLocExist == false)
                    {
                        UVLocationDAL.Instance.Add(sgLoction);
                    }
                }
                progressBar.Value = rCnt;
                j = 0;

            }
            MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayViewData();
            UVPcbListDAL.Instance.RemoveDuplicateRow();
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
                dgView.DataSource = UVLocationDAL.Instance.getAllLocation(txtSearch.Text.Trim());
                dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
           
            SearchData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SearchData();
            }
            
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id = long.Parse(row.Cells["ID"].Value.ToString());
                txtLocCode.Text = row.Cells["Loc"].Value.ToString();
                txtLocName.Text = row.Cells["LocName"].Value.ToString();
                txtRemark.Text = row.Cells["Remark"].Value.ToString();
            }
        }
    }
}
