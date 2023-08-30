using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Jig;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.SysControl;
using UnidenDAL.Staging;

namespace SMTPRORAM.Jig
{
    
    public partial class frmJIGSection : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        public frmJIGSection()
        {
            InitializeComponent();
        }

        private void frmJIGSection_Load(object sender, EventArgs e)
        {
            showListSection();
            LoadComboboxData();
            _enable(false);
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            txtSection.Focus();
        }
        void _enable(bool t)
        {
            cbDept.Enabled = t;
            txtSection.Enabled = t;
            txtSectionDesc.Enabled = t;
            chkIsDisable.Enabled = t;
        }

        void ResetControll()
        {
            cbDept.Text = "[None]";
            txtSection.Text = "";
            txtSectionDesc.Text = "";
            chkIsDisable.Checked = false;
            cbDept.Focus();
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void showListSection()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, JIGSECTION_DAL.Instance.getListSection());
        }
        private void searchData(string search)
        {
            if (search.Equals(""))
            {
                CommonDAL.Instance.ShowDataGridView(dgView, JIGSECTION_DAL.Instance.getListSection());
            }
            else
            {
                CommonDAL.Instance.ShowDataGridView(dgView, JIGSECTION_DAL.Instance.getListSection(search));
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtSearch.Text.Trim().Equals(""))
                {
                    CommonDAL.Instance.ShowDataGridView(dgView, JIGSECTION_DAL.Instance.getListSection(txtSearch.Text.Trim()));
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
                txtSection.Enabled = false;
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
                    bool flag = JIGSECTION_DAL.Instance.Remove(Id);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showListSection();
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
            if (txtSection.Text.Trim().Equals(""))
            {
                MessageBox.Show("Section không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSection.Focus();
                return false;
            }
            if (txtSectionDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả section không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSectionDesc.Focus();
                return false;
            }
            if (cbDept.Text=="[None]")
            {
                MessageBox.Show(" Bộ phận không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDept.Focus();
                return false;
            }
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var sec = new JIG_SECTION();
                sec.JigSecCode = txtSection.Text.Trim();
                sec.JigSecDesc = txtSectionDesc.Text.Trim();
                sec.DeptID = long.Parse(cbDept.SelectedValue.ToString());
                sec.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                sec.CreatedBy = Program.UserId;
                if (chkIsDisable.Checked==true)
                {
                    sec.IsDisable = true;
                }
                else
                {
                    sec.IsDisable= false;
                }
                var checkExist = new JIG_SECTION();
                checkExist = JIGSECTION_DAL.Instance.checkLocExist(sec.JigSecCode);
                if (AddFlag && checkExist == null)
                {
                    sec.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (JIGSECTION_DAL.Instance.Add(sec))
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
                    sec.Id = Id;
                    sec.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (sec.Id>0)
                    {
                        if (JIGSECTION_DAL.Instance.Update(sec))
                        {
                            MessageBox.Show("Update thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Id = 0;
                            //return;
                        }
                        else
                        {
                            MessageBox.Show("Update không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chọn bản ghi cần cập nhật thông tin vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                   

                }
                AddFlag = false;
                showListSection();
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
                int deptID= int.Parse(row.Cells["DeptID"].Value.ToString());
                var dept = new UV_DEPT();
                dept=UVDeptDAL.Instance.getDeptByID(deptID);
                cbDept.Text = dept.DeptCode;
                chkIsDisable.Checked = bool.Parse(row.Cells["IsDisable"].Value.ToString());
                txtSection.Text = row.Cells["JigSecCode"].Value.ToString();
                txtSectionDesc.Text = row.Cells["JigSecDesc"].Value.ToString();
            }
        }
        private void LoadComboboxData()
        {           
            var lstDept = UVDeptDAL.Instance.getListDept();
            var dept = new UV_DEPT();
            dept.DeptID = 0;
            dept.DeptCode = "[None]";
            dept.DeptDesc = "[None]";
            lstDept.Add(dept);
            cbDept.DataSource = lstDept.OrderBy(p=>p.DeptCode).ToList();
            cbDept.DisplayMember = "DeptCode";
            cbDept.ValueMember = "DeptID";
        }
        private void cbDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender,e);
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
