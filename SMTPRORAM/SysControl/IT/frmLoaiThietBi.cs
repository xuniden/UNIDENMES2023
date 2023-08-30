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
using UnidenDAL.SysControl.IT;

namespace SMTPRORAM.SysControl.IT
{
    public partial class frmLoaiThietBi : Form
    {
        public frmLoaiThietBi()
        {
            InitializeComponent();
        }
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;

        private void frmLoaiThietBi_Load(object sender, EventArgs e)
        {
            showListType();
            _enable(false);
            txtSearch.Focus();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            
        }
        private void showListType()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, ITDevicesType_DAL.Instance.getListDevicesType());
        }
        void _enable(bool t)
        {
            txtLoaiTB.Enabled = t;
            txtMotaTB.Enabled = t;           
        }

        void ResetControll()
        {
            txtLoaiTB.Text = "";
            txtMotaTB.Text = "";
            txtLoaiTB.Focus();
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
                CommonDAL.Instance.ShowDataGridView(dgView, ITDevicesType_DAL.Instance.getListDevicesType());
            }
            else
            {
                CommonDAL.Instance.ShowDataGridView(dgView, ITDevicesType_DAL.Instance.getListDevicesType(search));
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            searchData(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                if (!txtSearch.Text.Trim().Equals(""))
                {
                    CommonDAL.Instance.ShowDataGridView(dgView, ITDevicesType_DAL.Instance.getListDevicesType(txtSearch.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("Nhập dữ liệu vào ô tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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
                txtLoaiTB.Enabled = false;
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool IsDataOK()
        {
            if (txtLoaiTB.Text.Trim().Equals(""))
            {
                MessageBox.Show("Loại Thiết bị không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoaiTB.Focus();
                return false;
            }
            if (txtMotaTB.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả vị trí không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotaTB.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var type = new IT_DevicesType();
                type.LoaiTB = txtLoaiTB.Text.Trim();
                type.MotaTB = txtMotaTB.Text.Trim();
                type.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                type.CreatedBy = Program.UserId;
               
                var checkExist = new IT_DevicesType();
                checkExist = ITDevicesType_DAL.Instance.checkExist(type.LoaiTB);
                if (AddFlag && checkExist == null)
                {
                    type.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    type.UpdatedBy = Program.UserId;
                    if (ITDevicesType_DAL.Instance.Add(type))
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
                    type.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    type.UpdatedBy = Program.UserId;
                    if (ITDevicesType_DAL.Instance.Update(type))
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
                showListType();
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
                txtLoaiTB.Text = row.Cells["LoaiTB"].Value.ToString();
                txtMotaTB.Text = row.Cells["MotaTB"].Value.ToString();
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không co phép xóa !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;
        }
    }
}
