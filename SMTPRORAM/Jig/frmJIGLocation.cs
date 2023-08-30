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
using Microsoft.Office.Interop.Excel;
using UnidenDAL.Smt.DataControl;

namespace SMTPRORAM.Jig
{
    public partial class frmJIGLocation : Form
    {
        public frmJIGLocation()
        {
            InitializeComponent();
        }
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        private void showListLocation()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, JIGLOCATION_DAL.Instance.getListLocation());
        }
        private void frmJIGLocation_Load(object sender, EventArgs e)
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
        private void searchData(string search)
        {
            if (search.Equals(""))
            {
                CommonDAL.Instance.ShowDataGridView(dgView, JIGLOCATION_DAL.Instance.getListLocation());
            }
            else
            {
                CommonDAL.Instance.ShowDataGridView(dgView, JIGLOCATION_DAL.Instance.getListLocation(search));
            }
            
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtSearch.Text.Trim().Equals(""))
                {
                    CommonDAL.Instance.ShowDataGridView(dgView, JIGLOCATION_DAL.Instance.getListLocation(txtSearch.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("Nhập dữ liệu vào ô tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            searchData(txtSearch.Text.Trim());
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
                    bool flag = JIGLOCATION_DAL.Instance.Remove(Id);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showListLocation();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        private bool IsDataOK()
        {
            if (txtLocCode.Text.Trim().Equals("") )
            {
                MessageBox.Show("Vị trí để JIG không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocCode.Focus();
                return false;
            }
            if (txtLocDesc.Text.Trim().Equals("") )
            {
                MessageBox.Show("Mô tả vị trí không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocDesc.Focus();
                return false;
            }           
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK()==true)
            {
                var loc = new JIG_LOCATION();
                loc.LocName = txtLocCode.Text.Trim();
                loc.LocDesc = txtLocDesc.Text.Trim();
                loc.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                loc.CreatedBy = Program.UserId;
                if (chkIsDisable.Checked == true)
                {
                    loc.IsDisable = true;
                }
                else
                {
                    loc.IsDisable = false;
                }
                var checkExist = new JIG_LOCATION();
                checkExist = JIGLOCATION_DAL.Instance.checkLocExist(loc.LocName);
                if (AddFlag && checkExist ==null)
                {
                    loc.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (JIGLOCATION_DAL.Instance.Add(loc))
                    {
                        MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }
                }
                else
                {
                    loc.Id = Id;
                    loc.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (JIGLOCATION_DAL.Instance.Update(loc))
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
                chkIsDisable.Checked = bool.Parse(row.Cells["IsDisable"].Value.ToString());
                txtLocCode.Text = row.Cells["LocName"].Value.ToString();
                txtLocDesc.Text = row.Cells["LocDesc"].Value.ToString();               
            }
        }
        DataTableCollection tableCollection;
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
                List<JIG_LOCATION> jigLocs = new List<JIG_LOCATION>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var jigLoc = new JIG_LOCATION();
                    jigLoc.LocName = dt.Rows[i]["LocName"].ToString();
                    jigLoc.LocDesc = dt.Rows[i]["LocDesc"].ToString();
                    jigLoc.IsDisable = false;
                    jigLoc.CreatedBy = Program.UserId;
                    jigLoc.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    jigLoc.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    // Kiểm tra xem có chưa nếu chưa có thì thêm có rồi thì không thêm nữa.
                    var jigCheck = new JIG_LOCATION();
                    jigCheck = JIGLOCATION_DAL.Instance.checkLocExist(jigLoc.LocName);
                    if (jigCheck==null)
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
                    _entities.JIG_LOCATION.AddRange(jigLocs);
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
