using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.SysControl;
using UnidenDAL.SysControl.IT;
using UnidenDTO;

namespace SMTPRORAM.SysControl.IT
{
    public partial class frmIssueReturn : Form
    {
        private string subDbNumber = "";
        private readonly frmITDeviceManagement frm1; //readonly is optional (For safety purposes)
        public frmIssueReturn(frmITDeviceManagement frm)
        {
            InitializeComponent();
            frm1 = frm;
        }
        void ResetControll()
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtMaTB.Text = "";
            cbFromDept.Text = "[None]";
            txtFromLoc.Text = "";
            cbToDept.Text = "[None]";
            txtToLoc.Text = "";
            txtIpAddress.Text = "";
            txtRemark.Text = "";
            txtMaTB.Focus();
        }
        private void frmIssueReturn_Load(object sender, EventArgs e)
        {
            loadDept();
            getDataByUser(Program.UserId);
            if (SysControl.IT.frmITDeviceManagement.maTB.Equals("") 
                || string.IsNullOrEmpty(SysControl.IT.frmITDeviceManagement.maTB))
            {
                MessageBox.Show("Dữ  liệu nhập vào không đúng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
                this.Close();
            }
           
            txtMaTB.Text = SysControl.IT.frmITDeviceManagement.maTB;
            subDbNumber = SysControl.IT.frmITDeviceManagement.issueDbNumber;
            var checkDevices = new IT_DevicesManagement();
            checkDevices = ITDevicesManagement_DAL.Instance.checkExist(txtMaTB.Text);
            if (checkDevices.Stock==true)
            {
                txtEmployeeID.Enabled = true;
                txtEmployeeName.Enabled = true;
                cbFromDept.Text = checkDevices.Dept;
                txtFromLoc.Text= checkDevices.Loc;
                cbFromDept.Enabled = false;
                txtFromLoc.Enabled = false;
            }
            else
            {
                var transHistory = IT_DevicesTransactionDAL.Instance.getLastTrans(txtMaTB.Text);
                txtEmployeeID.Text = "00000000";
                txtEmployeeName.Text = "STOCK IT";
                txtEmployeeID.Enabled = false;
                txtEmployeeName.Enabled = false;
                cbFromDept.Text= transHistory.ToDept;
                txtFromLoc.Text =transHistory.ToLoc;
                cbToDept.Text = checkDevices.Dept;
                txtToLoc.Text = checkDevices.Loc;
                cbToDept.Enabled = false;
                txtToLoc.Enabled = false;

            }

        }
        private bool checkDevicesIsAvailable(string MaTB)
        {
            var deviceAvailable = new IT_DevicesManagement();
            deviceAvailable = ITDevicesManagement_DAL.Instance.checkDeviceAvailable(MaTB);
            if (deviceAvailable!=null)
            {
                return true;
            }
            return false;
        }
        private bool IsDataOK()
        {
            if (txtEmployeeID.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã nhân viên không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeID.Focus();
                return false;
            }
            if (txtEmployeeName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên nhân viên không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                return false;
            }
            if (cbFromDept.Text.Trim().Equals("")|| cbFromDept.Text.Trim().Equals("[None]"))
            {
                MessageBox.Show("Từ bộ phận phải được chọn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFromDept.Focus();
                return false;
            }
            if (txtFromLoc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Xuất thiết bị từ vị trí không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFromLoc.Focus();
                return false;
            }
            if (cbToDept.Text.Trim().Equals("") || cbToDept.Text.Trim().Equals("[None]"))
            {
                MessageBox.Show("Tới bộ phận phải được chọn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbToDept.Focus();
                return false;
            }
            if (txtToLoc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Xuất thiết bị tới vị trí không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtToLoc.Focus();
                return false;
            }           
            return true;
        }
        
        private void getDataByUser(string User)
        {           
             CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, IT_DevicesTransactionDAL.Instance.getListTranByUser(User));
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK()==true)
            {
                var itemSave = new IT_DevicesTransaction();
                itemSave.MaTB = txtMaTB.Text;
                itemSave.EmployeeID = txtEmployeeID.Text.Trim();
                itemSave.EmployeeName = txtEmployeeName.Text.Trim();
                itemSave.FromDept = cbFromDept.Text;
                itemSave.FromLoc=txtFromLoc.Text.Trim();
                itemSave.ToDept = cbToDept.Text;
                itemSave.ToLoc = txtToLoc.Text;
                itemSave.Remark = txtRemark.Text.Trim();
                itemSave.IPAddress = txtIpAddress.Text.Trim();
                itemSave.CreatedBy = Program.UserId;
                itemSave.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                var device = new IT_DevicesManagement();
                device.MaTB = txtMaTB.Text;
                device.UpdateBy = Program.UserId;
                device.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                var checkDevices = new IT_DevicesManagement();
                checkDevices = ITDevicesManagement_DAL.Instance.checkExist(device.MaTB);
                if (checkDevicesIsAvailable(SysControl.IT.frmITDeviceManagement.maTB) == true)
                {   
                    device.Stock = false;
                    itemSave.IssueReturn = "ISSUE (Xuất đi)";                   
                    // Xuất từ IT đi các bộ phận
                }
                else
                {                    
                    // Các bộ phận trả lại thiết bị cho IT
                    device.Stock = true;
                    itemSave.IssueReturn = "RETUTRN (Trả lại)";                    
                }
                ITDevicesManagement_DAL.Instance.UpdateIssueReturn(device);
                // Thêm vào xuất đi thì phải bỏ
                IT_DevicesTransactionDAL.Instance.Add(itemSave);
                getDataByUser(Program.UserId);
                ResetControll();
            }
        }
        private void loadDept()
        {
            var dept = new ViewDept();
            dept.DeptCode = "[None]";
            var depts = new List<ViewDept>();
            depts = UVDeptDAL.Instance.getAllDept();
            depts.Add(dept);
            cbFromDept.DataSource = depts.OrderBy(p => p.DeptCode).ToList();
            cbFromDept.DisplayMember = "DeptCode";
            cbFromDept.ValueMember = "DeptCode";

            cbToDept.DataSource = depts.OrderBy(p => p.DeptCode).ToList();
            cbToDept.DisplayMember = "DeptCode";
            cbToDept.ValueMember = "DeptCode";
        }

        private void cbFromDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbToDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            frm1.showListDevices();
            this.Close();
        }

        private void searchData(string search)
        {
            if (txtSearch.Text.Equals(""))
            {
                MessageBox.Show("Nhập dữ liệu trước khi tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, IT_DevicesTransactionDAL.Instance.getListTranBySearch(search));
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
                searchData(txtSearch.Text.Trim());
            }
        }

        private void frmIssueReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.showListDevices();
        }
    }
}
