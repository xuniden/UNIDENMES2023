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
    public partial class frmPcbList : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        public frmPcbList()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            txtLot.Enabled = t;
            txtModel.Enabled = t;
            txtBModel.Enabled = t;
            txtAssy.Enabled = t;
            txtPart.Enabled = t;
            txtDesc.Enabled = t;
            txtSpec.Enabled = t;
            numericHsqty.Enabled = t;
        }

        void ResetControll()
        {

            txtLot.Text = "";
            txtModel.Text = "";
            txtBModel.Text = "";
            txtAssy.Text = "";
            txtPart.Text = "";
            txtDesc.Text = "";
            txtSpec.Text = "";
            numericHsqty.Value = 1;
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        public void DisplayViewData()
        {
            dgView.DataSource = UVPcbListDAL.Instance.getAllPcbList();
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmPcbList_Load(object sender, EventArgs e)
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
            txtLot.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtLot.Focus();
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
                    bool flag = UVPcbListDAL.Instance.RemoveProdLine(Id);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtLot.Text.Trim().Equals("") || string.IsNullOrEmpty(txtLot.Text.Trim()))
            {
                MessageBox.Show("LOT không được để trống hoặc [None]!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLot.Focus();
                return false;
            }
            if (txtModel.Text.Trim().Equals(""))
            {
                MessageBox.Show("MODEL không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
                return false;
            }
            if (txtBModel.Text.Trim().Equals("") || string.IsNullOrEmpty(txtBModel.Text.Trim()))
            {
                MessageBox.Show("BMODEL không được để trống hoặc [None]!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBModel.Focus();
                return false;
            }
            if (txtAssy.Text.Trim().Equals(""))
            {
                MessageBox.Show("ASSY không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAssy.Focus();
                return false;
            }
            if (txtPart.Text.Trim().Equals("") || string.IsNullOrEmpty(txtPart.Text.Trim()))
            {
                MessageBox.Show("PART không được để trống hoặc [None]!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPart.Focus();
                return false;
            }
            if (txtDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("DESC không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDesc.Focus();
                return false;
            }
            if (txtSpec.Text.Trim().Equals("") || string.IsNullOrEmpty(txtSpec.Text.Trim()))
            {
                MessageBox.Show("SPEC không được để trống hoặc [None]!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSpec.Focus();
                return false;
            }
            if (numericHsqty.Text.Trim().Equals(""))
            {
                MessageBox.Show("HSQTY không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericHsqty.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var pcbList = new UV_STAGING_PCBLIST();
                pcbList.Lot = txtLot.Text;
                pcbList.Model = txtModel.Text;
                pcbList.BModel = txtBModel.Text;
                pcbList.Assy = txtAssy.Text;
                pcbList.Parts = txtPart.Text;
                pcbList.Desciption = txtDesc.Text;
                pcbList.Spec = txtSpec.Text;
                pcbList.HsQty = int.Parse(numericHsqty.Value.ToString());
                pcbList.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                if (AddFlag)
                {
                    if (UVPcbListDAL.Instance.Add(pcbList))
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
                    pcbList.ID = Id;
                    if (UVPcbListDAL.Instance.Update(pcbList))
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

            bool check = false;
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
                string[] str = new string[8];
                for (cCnt = 1; cCnt <= 8; cCnt++)
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
                for (int ik = 0; ik < str.Length; ik++)
                {
                    if (string.IsNullOrEmpty(str[ik]) || str[ik].Equals(""))
                    {
                        check = true;
                    }
                }
                if (check == false)
                {
                    var pcbList = new UV_STAGING_PCBLIST();
                    pcbList.Lot = str[0].ToString().Trim();
                    pcbList.Model = str[1].ToString().Trim();
                    pcbList.BModel = str[2].ToString().Trim();
                    pcbList.Assy = str[3].ToString().Trim();
                    pcbList.Parts = str[4].ToString().Trim();
                    pcbList.Desciption = str[5].ToString().Trim();
                    pcbList.Spec = str[6].ToString().Trim();
                    pcbList.HsQty = int.Parse(str[7].ToString().Trim());
                    pcbList.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (UVPcbListDAL.Instance.checkExistImport(pcbList)==false  )
                    {
                        UVPcbListDAL.Instance.Add(pcbList);
                    }                             
                   
                    check = false;
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
                dgView.DataSource = UVPcbListDAL.Instance.getAllPcbList(txtSearch.Text.Trim());
                dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
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
                Id = long.Parse(row.Cells["ID"].Value.ToString());
                txtLot.Text = row.Cells["Lot"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtBModel.Text = row.Cells["BModel"].Value.ToString();
                txtAssy.Text = row.Cells["Assy"].Value.ToString();
                txtPart.Text = row.Cells["Parts"].Value.ToString();
                txtDesc.Text = row.Cells["Desciption"].Value.ToString();
                txtSpec.Text = row.Cells["Spec"].Value.ToString();
                numericHsqty.Value = int.Parse(row.Cells["HsQty"].Value.ToString());
            }
        }
    }
}
