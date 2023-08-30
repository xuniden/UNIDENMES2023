using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UnidenDAL.SysControl;
using UnidenDAL;
using UnidenDTO;
using DocumentFormat.OpenXml.Office2010.Drawing;
using UnidenDAL.Staging;
using UnidenDAL.SysControl.IT;

namespace SMTPRORAM.SysControl.IT
{
    public partial class frmBuyDeviceMonitor : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        string subDbNumber = "";
        long Id = 0;
        public frmBuyDeviceMonitor()
        {
            InitializeComponent();
        }

        private void frmBuyDeviceMonitor_Load(object sender, EventArgs e)
        {
            _enable(false);
            showListByDevices();
            txtSearch.Focus();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        void _enable(bool t)
        {
            txtSubDbNumber.Enabled = t;
            txtDesc.Enabled = t;
            txtModel.Enabled = t;
            numericQty.Enabled = t;
            dtpIssueDate.Enabled = t;
            dtpReceiverDate.Enabled = t;
            txtPrice.Enabled = t;
            txtRemark.Enabled = t; 
            txtNcc.Enabled = t;
        }

        void ResetControll()
        {
            txtSubDbNumber.Text = "";
            txtDesc.Text = "";
            txtModel.Text = "";
            numericQty.Value = 0;
            dtpIssueDate.Value = CommonDAL.Instance.getSqlServerDatetime();
            dtpReceiverDate.Value = CommonDAL.Instance.getSqlServerDatetime();
            txtPrice.Text = "0";
            txtRemark.Text = "";
            txtNcc.Text = "";
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
            txtSubDbNumber.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (!subDbNumber.Equals(""))
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtSubDbNumber.Enabled = false;
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
            ResetControll();
        }

        private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;               
                txtSubDbNumber.Text = row.Cells["SubDbNumber"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtDesc.Text = row.Cells["DDescription"].Value.ToString();
                numericQty.Value =int.Parse( row.Cells["Qty"].Value.ToString());
                dtpIssueDate.Value =DateTime.Parse( row.Cells["IssueDate"].Value.ToString());
                txtPrice.Text = row.Cells["ByPrice"].Value.ToString();
                dtpReceiverDate.Value = DateTime.Parse(row.Cells["ReceiverDate"].Value.ToString());
                txtRemark.Text = row.Cells["Remark"].Value.ToString();   
                txtNcc.Text= row.Cells["Supplier"].Value.ToString();
                subDbNumber = txtSubDbNumber.Text;                
            }
        }
        private bool IsDataOK()
        {
            if (txtSubDbNumber.Text.Trim().Equals(""))
            {
                MessageBox.Show("Số sub DB không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubDbNumber.Focus();
                return false;
            }
            if (txtModel.Text.Trim().Equals(""))
            {
                MessageBox.Show("Model sản phẩm cần mua không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
                return false;
            }
            if (txtDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả sản phẩm cần mua không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDesc.Focus();
                return false;
            }
            if (int.Parse(numericQty.Value.ToString())<=0)
            {
                MessageBox.Show("Qty không được <0 hoặc =0 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericQty.Focus();
                return false;
            }
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var byDevices = new IT_BuyDeviceMonitor();
                byDevices.DBNumber =txtSubDbNumber.Text.Trim().Substring(0,10);
                byDevices.SubDbNumber = txtSubDbNumber.Text.Trim();
                byDevices.Model = txtModel.Text.Trim();
                byDevices.DDescription = txtDesc.Text.Trim();
                byDevices.Qty = int.Parse(numericQty.Value.ToString());
                byDevices.IssueDate = dtpIssueDate.Value.Date;
                byDevices.Supplier = txtNcc.Text.Trim();
                byDevices.ByPrice = double.Parse(txtPrice.Text.Trim());
                byDevices.ReceiverDate = dtpReceiverDate.Value.Date;
                byDevices.Remark = txtRemark.Text.Trim();

                byDevices.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                byDevices.CreatedBy = Program.UserId;

                var checkExist = new IT_BuyDeviceMonitor();
                checkExist = IT_BuyDeviceMonitorDAL.Instance.checkExist(byDevices.SubDbNumber);
                if (AddFlag && checkExist == null)
                {
                    byDevices.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    byDevices.UpdatedBy = Program.UserId;
                    if (IT_BuyDeviceMonitorDAL.Instance.Add(byDevices))
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
                    byDevices.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    byDevices.UpdatedBy = Program.UserId;
                    if (IT_BuyDeviceMonitorDAL.Instance.Update(byDevices))
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
                showListByDevices();
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        
        }
        private void showListByDevices()
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView,IT_BuyDeviceMonitorDAL.Instance.getListByDevices());
        }

        private void Search(string search)
        {
            if (search.Equals(""))
            {
                MessageBox.Show("Nhập dữ liệu cần tìm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, IT_BuyDeviceMonitorDAL.Instance.getSearchListByDevices(search));
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                Search(txtSearch.Text.Trim());
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
