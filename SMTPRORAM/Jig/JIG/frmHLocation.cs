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
using UnidenDAL.Jig;
using UnidenDAL.Jig.JIG;

namespace SMTPRORAM.Jig.JIG
{
    public partial class frmHLocation : Form
    {
        private bool AddFlag = false;
        DataTableCollection tableCollection;
        private List<SYS_UserButtonFunction> lstUBFunction;
        private long Id = 0;
        public frmHLocation()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            txtLocCode.Enabled = t;
            txtLocDesc.Enabled = t;
            chkIsDisable.Enabled = t;
        }

        void ResetControll()
        {
            txtLocCode.Text = "";
            txtLocDesc.Text = "";
            chkIsDisable.Checked = false;
            txtLocCode.Focus();
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }

        private void frmHLocation_Load(object sender, EventArgs e)
        {
            lblProcess.Text = "";
            showListLocation();
            _enable(false);
            txtSearch.Focus();
            lblProcess.Text = "";
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            txtLocCode.Focus();
        }
        private void searchData(string search)
        {           
            CommonDAL.Instance.ShowDataGridView(dgView, JIGHLOCATION_DAL.Instance.getListLocation(search));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                if (txtSearch.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Nhập dữ liệu cần tìm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtSearch.Focus();
                    return;
                }
                else
                {
                    searchData(txtSearch.Text);
                }
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                searchData(txtSearch.Text);
            }
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtLocCode.Enabled = false;
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
                    string message = JIGHLOCATION_DAL.Instance.Remove(Id);
                    if (message == "")
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showListLocation();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        private bool IsDataOK()
        {
            if (txtLocCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vị trí để JIG không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocCode.Focus();
                return false;
            }
            if (txtLocDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả vị trí không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocDesc.Focus();
                return false;
            }
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var loc = new JIGH_LOCATION();
                loc.JLocName = txtLocCode.Text.Trim();
                loc.JLocDesc = txtLocDesc.Text.Trim();
                loc.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                loc.CreatedBy = Program.UserId;
                loc.JIsDisable= chkIsDisable.Checked;

                var checkExist = new JIGH_LOCATION();
                checkExist = JIGHLOCATION_DAL.Instance.checkLocExist(loc.JLocName);
                if (AddFlag && checkExist == null)
                {
                    loc.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    string message = JIGHLOCATION_DAL.Instance.Add(loc);
                    if (message=="")
                    {
                        MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }
                }
                else
                {
                    loc.Id = Id;
                    loc.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    string message = JIGHLOCATION_DAL.Instance.Update(loc);
                    if (message=="")
                    {
                        MessageBox.Show("Update thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                    else
                    {
                        MessageBox.Show("Update không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }

                }
                AddFlag = false;
                showListLocation();
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
            ResetControll();
        }

        private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id = int.Parse(row.Cells["Id"].Value.ToString());
                chkIsDisable.Checked = bool.Parse(row.Cells["JIsDisable"].Value.ToString());
                txtLocCode.Text = row.Cells["JLocName"].Value.ToString();
                txtLocDesc.Text = row.Cells["JLocDesc"].Value.ToString();
            }
        }

        private void iconbtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    tableCollection = CommonDAL.Instance.BrowserExcelToCombobox(txtFilename.Text);
                    cbSheet.Items.Clear();
                    foreach (System.Data.DataTable table in tableCollection)
                        cbSheet.Items.Add(table.TableName); //add sheet to combo                    
                }
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            //dgView.DataSource = dt;
            if (dt != null)
            {
                List<JIGH_LOCATION> jigLocs = new List<JIGH_LOCATION>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var jigLoc = new JIGH_LOCATION();
                    jigLoc.JLocName = dt.Rows[i]["JLocName"].ToString();
                    jigLoc.JLocDesc = dt.Rows[i]["JLocDesc"].ToString();
                    jigLoc.JIsDisable = false;
                    jigLoc.CreatedBy = Program.UserId;
                    jigLoc.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    jigLoc.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    // Kiểm tra xem có chưa nếu chưa có thì thêm có rồi thì không thêm nữa.
                    var jigCheck = new JIGH_LOCATION();
                    jigCheck = JIGHLOCATION_DAL.Instance.checkLocExist(jigLoc.JLocName);
                    if (jigCheck == null)
                    {
                        jigLocs.Add(jigLoc);
                    }
                }
                var _entities = new UVEntities();
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    _entities.JIGH_LOCATION.AddRange(jigLocs);
                    _entities.SaveChanges();
                    lblProcess.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

                dgView.DataSource = jigLocs;
            }
        }
        private void showListLocation()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, JIGHLOCATION_DAL.Instance.getListLocation());
        }
        private void iconbtnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"D:\";
                saveFileDialog1.Title = "Save Csv Files";
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "Csv files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    CommonDAL.Instance.writeCSV(dgView, filename);
                    MessageBox.Show("Đã Export Thành Công !!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                throw;
            }
        }
    }
}
