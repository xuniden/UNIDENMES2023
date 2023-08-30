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

namespace SMTPRORAM.Jig
{
    public partial class frmJIGCalType : Form
    {
        public frmJIGCalType()
        {
            InitializeComponent();
        }
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        private void frmJIGCalType_Load(object sender, EventArgs e)
        {
            showListCaltype();
            _enable(false);
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        void _enable(bool t)
        {
            txtCalType.Enabled = t;
            txtCalDesc.Enabled = t;
            numericUpDownCycle.Enabled = t;
            chkIsDisable.Enabled = t;
        }

        void ResetControll()
        {            
            txtCalType.Text = "";
            txtCalDesc.Text = "";
            chkIsDisable.Checked = false;
            numericUpDownCycle.Value = 0;
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void showListCaltype()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, JIGCALTYPE_DAL.Instance.getListCalType());
        }
        private void searchData(string search)
        {
            if (search.Equals(""))
            {
                CommonDAL.Instance.ShowDataGridView(dgView, JIGCALTYPE_DAL.Instance.getListCalType());
            }
            else
            {
                CommonDAL.Instance.ShowDataGridView(dgView, JIGCALTYPE_DAL.Instance.getListCalType(search));
            }

        }
		#region Kiểm tra có nhập dữ liệu vào ô tìm kiếm không
        private bool checkSearch()
        {
			if (!txtSearch.Text.Trim().Equals(""))
			{
				CommonDAL.Instance.ShowDataGridView(dgView, JIGCALTYPE_DAL.Instance.getListCalType(txtSearch.Text.Trim()));
			}
			else
			{
				MessageBox.Show("Nhập dữ liệu vào ô tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
            return true;
		}
		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkSearch())
                {

                }
                else
                {
                    txtSearch.Focus();
                    txtSearch.SelectAll();
                }
            }
        }
		#endregion
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
                txtCalType.Enabled = false;
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
                    bool flag = JIGCALTYPE_DAL.Instance.Remove(Id);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showListCaltype();
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
            if (txtCalType.Text.Trim().Equals(""))
            {
                MessageBox.Show("Loại Hiệu chỉnh không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCalType.Focus();
                return false;
            }
            if (txtCalDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả loại hiệu chỉnh không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCalDesc.Focus();
                return false;
            }
            if (int.Parse(numericUpDownCycle.Value.ToString())<0)
            {
                MessageBox.Show("Giá trịn nhập vào không được nhỏ hơn 0 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDownCycle.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var calType = new JIG_CALTYPE();
                calType.CalType = txtCalType.Text.Trim();
                calType.CalDesc = txtCalDesc.Text.Trim();
                calType.Cycle=int.Parse(numericUpDownCycle.Value.ToString());
                calType.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                calType.CreatedBy = Program.UserId;
                if (chkIsDisable.Checked == true)
                {
                    calType.IsDisable = true;
                }
                else
                {
                    calType.IsDisable = false;
                }
                var checkExist = new JIG_CALTYPE();
                checkExist = JIGCALTYPE_DAL.Instance.checkCalTypeExist(calType.CalType);
                if (AddFlag && checkExist == null)
                {
                    calType.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (JIGCALTYPE_DAL.Instance.Add(calType))
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
                    calType.Id = Id;
                    calType.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (calType.Id > 0)
                    {
                        if (JIGCALTYPE_DAL.Instance.Update(calType))
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
                    else
                    {
                        MessageBox.Show("Chọn bản ghi cần cập nhật thông tin vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                AddFlag = false;
                showListCaltype();
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
                txtCalType.Text = row.Cells["CalType"].Value.ToString();
                txtCalDesc.Text = row.Cells["CalDesc"].Value.ToString();
                numericUpDownCycle.Value= int.Parse(row.Cells["Cycle"].Value.ToString());
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
