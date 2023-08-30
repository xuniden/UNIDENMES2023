using DocumentFormat.OpenXml.Office2010.Excel;
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
using UnidenDAL.Jig;
using UnidenDAL.Smt.Output;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.Smt.Output
{
    public partial class frmLeaderApprove : Form
    {
        bool AddFlag = false;
        private string staffId = "";
        private List<SYS_UserButtonFunction> lstUBFunction;
        public frmLeaderApprove()
        {
            InitializeComponent();
        }
        private void ListAll()
        {
            var listAll = LeaderApproveDAL.Instance.getListAll();
            if (listAll.Count>0)
            {
                CommonDAL.Instance.ShowDataGridView(dgView, listAll);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            
        }
        private void frmLeaderApprove_Load(object sender, EventArgs e)
        {
            _enable(false);
            ListAll();
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        void _enable(bool t)
        {
            txtStaffID.Enabled = t;
            txtStaffName.Enabled = t;
            chkActiveStatus.Enabled = t;
        }

        void ResetControll()
        {
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            chkActiveStatus.Checked = false;
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            txtStaffID.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (!staffId.Equals(""))
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtStaffID.Enabled = false;
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (!staffId.Equals(""))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool flag = LeaderApproveDAL.Instance.Remove(staffId);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CommonDAL.Instance.ShowDataGridView(dgView,LeaderApproveDAL.Instance.getByStaffID(staffId));
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
            if (txtStaffID.Text.Trim().Equals(""))
            {
                MessageBox.Show("ID của Leader không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStaffID.Focus();
                return false;
            }
            if (txtStaffName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên của Leader không để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStaffName.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK()==true)
            {
                var approveLeader = new EASTECH_ERROR_APPROVE();
                approveLeader.StaffID = txtStaffID.Text.Trim();
                approveLeader.StaffName= txtStaffName.Text.Trim();
                approveLeader.ActiveStatus = chkActiveStatus.Checked;
                approveLeader.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                if (AddFlag==false && LeaderApproveDAL.Instance.getByStaffID(approveLeader.StaffID).ToList().Count()>0)
                {
                    DialogResult dialogResult = MessageBox.Show("ID Leader này đã có trong csld."+"\n"+
                        "Bạn có muốn cập nhật không???", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        LeaderApproveDAL.Instance.Update(approveLeader);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Bạn đã không cập nhật ", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                else
                {
                    LeaderApproveDAL.Instance.Add(approveLeader);
                    MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            AddFlag = false;
            ListAll();
            showHideControll(true);
            ResetControll();
            _enable(false);
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
                staffId = row.Cells["StaffID"].Value.ToString();
                txtStaffID.Text = staffId;
                txtStaffName.Text = row.Cells["StaffName"].Value.ToString();//ActiveStatus
                chkActiveStatus.Checked= bool.Parse( row.Cells["ActiveStatus"].Value.ToString());
            }
        }
        private void SearchData(string search)
        {
            if (!string.IsNullOrEmpty(search)|| !search.Equals(""))
            {
                CommonDAL.Instance.ShowDataGridView(dgView, LeaderApproveDAL.Instance.getListAllBySearch(search));
            }
        }    
        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            SearchData(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                SearchData(txtSearch.Text.Trim());
            }
        }
    }
}
