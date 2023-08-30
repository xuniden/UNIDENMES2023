using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.SysControl.IT;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.SysControl;
using UnidenDAL.Smt.OutSource;
using Excel = Microsoft.Office.Interop.Excel;
using static UnidenDAL.Smt.Output.SmtAOIQrCodeOutputDAL;

namespace SMTPRORAM.SysControl.IT
{
  
    public partial class frmITDeviceManagement : Form
    {
        public static string maTB { get; private set; }
        public static string issueDbNumber { get; private set; }
        public frmITDeviceManagement()
        {
            InitializeComponent();
        }
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        private void frmITDeviceManagement_Load(object sender, EventArgs e)
        {
            loadCombobox();
            showListDevices();
            _enable(false);
            txtSearch.Focus();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
            cbDept.Text = "IT";
            txtLocation.Text = "STOCK IT";
            cbDept.Enabled = false;
            txtLocation.Enabled = false;

        }
        private void loadCombobox()
        {
            var dtype = new HienThiLoaiThietBi();
            dtype.LoaiTB = "[None]";
            var lstType = ITDevicesType_DAL.Instance.getListDevicesType();
            lstType.Add(dtype);
            cbLoaiTB.DataSource = lstType.OrderBy(p => p.LoaiTB).ToList();
            cbLoaiTB.DisplayMember = "LoaiTB";
            cbLoaiTB.ValueMember = "LoaiTB";

            var dept = new ViewDept();
            dept.DeptCode = "[None]";
            var lstDept = UVDeptDAL.Instance.getAllDept();
            lstDept.Add(dept);
            cbDept.DataSource = lstDept.OrderBy(p => p.DeptCode).ToList();
            cbDept.DisplayMember = "DeptCode";
            cbDept.ValueMember = "DeptCode";


            var dt = new DataTable();
            cbDbNumber.DataSource=IT_BuyDeviceMonitorDAL.Instance.getListSubDbNumber();
            cbDbNumber.DisplayMember = "DisplayCombobox";
            cbDbNumber.ValueMember = "SubDbNumber";
        }
           
        public void showListDevices()
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, ITDevicesManagement_DAL.Instance.getListDevicesAll());
        }
        void _enable(bool t)
        {
            txtMaTB.Enabled = t;
            txtTenTB.Enabled = t;
            txtModel.Enabled = t;
            rtxtMotaTB.Enabled = t;
            //cbDept.Enabled = t;
            //txtLocation.Enabled = t;
            cbStatus.Enabled = t;
            cbDbNumber.Enabled = t;
            dtpBuyDate.Enabled = t;
            txtServicesTag.Enabled = t;
            txtServicesCode.Enabled = t;
            txtMacAddress.Enabled = t;
            cbLoaiTB.Enabled = t;
            txtSupplier.Enabled = t;
            txtRemark.Enabled = t;
        }

        void ResetControll()
        {
            txtMaTB.Text = "";
            txtTenTB.Text = "";
            txtModel.Text="";
            rtxtMotaTB.Text = "";
            //cbDept.Text = "[None]";
            //txtLocation.Text = "";
            cbDept.Text = "IT";
            txtLocation.Text = "STOCK IT";
            cbDept.Enabled = false;
            txtLocation.Enabled = false;
            cbDbNumber.Text = "[None]";
            cbStatus.Text = "[None]";
            txtServicesTag.Text = "";
            txtServicesCode.Text = "";
            cbLoaiTB.Text = "[None]";
            txtMacAddress.Text = "";
            txtSupplier.Text = "";
            txtRemark.Text = "";
        }

        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnIssueReturn.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void searchData(string search)
        {
            if (search.Equals(""))
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, ITDevicesManagement_DAL.Instance.getListDevicesAll());
            }
            else
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, ITDevicesManagement_DAL.Instance.getListDevicesAll(search));
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            searchData(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                if (!txtSearch.Text.Trim().Equals(""))
                {
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, ITDevicesManagement_DAL.Instance.getListDevicesAll(txtSearch.Text.Trim()));
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
            loadCombobox();
            showHideControll(false);
            _enable(true);
            ResetControll();
            txtMaTB.Focus();
           
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                loadCombobox();
                _enable(true);
                showHideControll(false);
                txtMaTB.Enabled = false;
               
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool IsDataOK()
        {
            if (txtMaTB.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã thiết bị không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaTB.Focus();
                return false;
            }
            if (txtTenTB.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên thiết bị không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTB.Focus();
                return false;
            }
            if (txtModel.Text.Trim().Equals(""))
            {
                MessageBox.Show("Model không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
                return false;
            }
            if (rtxtMotaTB.Text.Trim().Equals(""))
            {
                MessageBox.Show("Model không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtMotaTB.Focus();
                return false;
            }
            if (cbDept.Text.Trim().Equals("") || cbDept.Text.Trim().Equals("[None]"))
            {
                MessageBox.Show("Dept không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDept.Focus();
                return false;
            }
            if (txtLocation.Text.Trim().Equals("") || cbDept.Text.Trim().Equals("[None]"))
            {
                MessageBox.Show("Vị trí không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
                return false;
            }
            if (cbStatus.Text.Trim().Equals("") || cbStatus.Text.Trim().Equals("[None]"))
            {
                MessageBox.Show("Trạng thái thiết bị không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbStatus.Focus();
                return false;
            }
            if (cbLoaiTB.Text.Trim().Equals("") || cbLoaiTB.Text.Trim().Equals("[None]"))
            {
                MessageBox.Show("Loại thiết bị không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLoaiTB.Focus();
                return false;
            }
            if (cbDbNumber.Text.Trim().Equals("") )
            {
                MessageBox.Show("Số DB number không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDbNumber.Focus();
                return false;
            }
            if (cbLoaiTB.Text.Equals("DESKTOP")|| cbLoaiTB.Text.Equals("LAPTOP"))
            {
                if (txtMacAddress.Text.Equals(""))
                {
                    MessageBox.Show("Máy tính cần phải điền địa chỉ MAC, ServiceTag, SerivceCode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (txtServicesTag.Text.Equals(""))
                {
                    MessageBox.Show("Máy tính cần phải điền địa chỉ MAC, ServiceTag, SerivceCode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (txtServicesCode.Text.Equals(""))
                {
                    MessageBox.Show("Máy tính cần phải điền địa chỉ MAC, ServiceTag, SerivceCode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK()==true)
            {
                var devices = new IT_DevicesManagement();
                devices.MaTB = txtMaTB.Text.Trim();
                devices.TenTB = txtTenTB.Text.Trim();
                devices.Model = txtModel.Text.Trim();
                devices.MotaTB = rtxtMotaTB.Text.Trim();
                devices.Dept = cbDept.Text.Trim();
                devices.Loc = txtLocation.Text.Trim();

                devices.Status = cbStatus.Text.Trim();
                devices.BuyDate = dtpBuyDate.Value.Date;
                devices.ServiceTag = txtServicesTag.Text.Trim();
                devices.ServiceCode = txtServicesCode.Text.Trim();
                devices.MacAddress = txtMacAddress.Text.Trim();
                devices.LoaiTB = cbLoaiTB.Text.Trim();
                devices.Supplier = txtSupplier.Text.Trim();
                devices.NoteDBNumber = cbDbNumber.SelectedValue.ToString();              
                devices.Stock = true;
                devices.Remark = txtRemark.Text.Trim();

                devices.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                devices.CreatedBy = Program.UserId;

                var checkExist = new IT_DevicesManagement();
                checkExist = ITDevicesManagement_DAL.Instance.checkExist(devices.MaTB);
                if (AddFlag && checkExist == null)
                {
                    devices.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    devices.UpdateBy = Program.UserId;
                    if (ITDevicesManagement_DAL.Instance.Add(devices))
                    {
                        MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (devices.NoteDBNumber !="[None]")
                        {
                            // upload trừ thiết bị mới đi 1
                            // Kiểm tra thiết bị mua về và xuất đi có băng nhau không
                            var buyDevice = new IT_BuyDeviceMonitor();
                            buyDevice=IT_BuyDeviceMonitorDAL.Instance.getBuyDevicesByDbNumber(devices.NoteDBNumber);
                            var lstDevices = new List<IT_DevicesManagement>();
                            lstDevices = ITDevicesManagement_DAL.Instance.getDevicesByNoteDbNumber(devices.NoteDBNumber);

                            // buyDevice.SubDbNumber=devices.NoteDBNumber;
                            
                            if (buyDevice.Qty>=lstDevices.Count)
                            {
                                buyDevice.UpdatedBy = Program.UserId;
                                buyDevice.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                IT_BuyDeviceMonitorDAL.Instance.UpdateQty(buyDevice);
                            }
                            else
                            {
                                MessageBox.Show("Có thể có nhầm lẫn khi thêm hoặc xuất thiết bị này" + "\n\n" + "Thông báo cho IT !!!"
                                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
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
                    devices.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    devices.UpdateBy = Program.UserId;
                    if (ITDevicesManagement_DAL.Instance.Update(devices))
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
                showListDevices();
                showHideControll(true);
                ResetControll();
                loadCombobox();
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
                maTB= row.Cells["MaTB"].Value.ToString();
                var selectedValue = row.Cells["NoteDBNumber"].Value.ToString();
                var dt = new DataTable();
                dt = IT_BuyDeviceMonitorDAL.Instance.getSelectedValue(selectedValue);
                cbDbNumber.Text = dt.Rows[0]["SubDbNumber"].ToString();
                issueDbNumber = cbDbNumber.Text;
                txtMaTB.Text = row.Cells["MaTB"].Value.ToString();
                txtTenTB.Text = row.Cells["TenTB"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                rtxtMotaTB.Text = row.Cells["MotaTB"].Value.ToString();
                cbDept.Text = row.Cells["Dept"].Value.ToString();
                txtLocation.Text = row.Cells["Loc"].Value.ToString();
                cbStatus.Text = row.Cells["Status"].Value.ToString();
                dtpBuyDate.Value =DateTime.Parse(row.Cells["BuyDate"].Value.ToString());
                txtServicesTag.Text = row.Cells["ServiceTag"].Value.ToString();
                txtServicesCode.Text = row.Cells["ServiceCode"].Value.ToString();
                txtMacAddress.Text = row.Cells["MacAddress"].Value.ToString();
                cbLoaiTB.Text = row.Cells["LoaiTB"].Value.ToString();
                txtSupplier.Text = row.Cells["Supplier"].Value.ToString();
                txtRemark.Text = row.Cells["Remark"].Value.ToString();
                //cbDbNumber.Text
            }
        }
        private void cbLoaiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }
        private void cbDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }
        private void cbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }
        private string pathFile = "";
        private void iconbtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Please Select Excel File to Import |*.xlsx;*.xls";
            op.Title = "Select Excel";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = op.FileName;
                pathFile = System.IO.Path.GetDirectoryName(op.FileName);
            }
        }

        private void iconbtnUpload_Click(object sender, EventArgs e)
        {
            if (!txtFile.Text.Trim().Equals(""))
            {
                string fileError = "Import_Error_" + CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
                string fileFullPath = pathFile + "\\" + fileError;
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
                    string[] str = new string[17];
                    for (cCnt = 1; cCnt <= 17; cCnt++)
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
                    string matb;
                    matb = str[0].ToString();
                    var checkExist= ITDevicesManagement_DAL.Instance.checkExist(matb);
                    if (checkExist==null)
                    {                       
                        var rcInput = new IT_DevicesManagement();
                        rcInput.MaTB = str[0].ToString().Trim();
                        rcInput.TenTB = str[1].ToString().Trim();
                        rcInput.Model = str[2].ToString().Trim();
                        rcInput.MotaTB= str[3].ToString().Trim()+ "\n" + str[4].ToString().Trim()+ "\n"+ str[5].ToString().Trim();
                        rcInput.Dept = str[6].ToString().Trim().ToUpper();
                        rcInput.Loc= str[7].ToString().Trim().ToUpper();
                        rcInput.Status = str[8].ToString().Trim().ToUpper();
                        rcInput.BuyDate = DateTime.Parse(str[9].ToString().Trim());
                        rcInput.ServiceTag = str[10].ToString().Trim().ToUpper();
                        rcInput.ServiceCode = str[11].ToString().Trim().ToUpper();
                        rcInput.MacAddress = str[12].ToString().Trim().ToUpper();
                        rcInput.LoaiTB = str[13].ToString().Trim().ToUpper();
                        rcInput.Supplier= str[14].ToString().Trim().ToUpper();
                        rcInput.Remark= str[15].ToString().Trim().ToUpper();
                        rcInput.Stock = true;
                        rcInput.NoteDBNumber = str[16].ToString().Trim().ToUpper();
                        if (rcInput.NoteDBNumber != "[None]")
                        {
                            // upload trừ thiết bị mới đi 1
                            // Kiểm tra thiết bị mua về và xuất đi có băng nhau không
                            var buyDevice = new IT_BuyDeviceMonitor();
                            buyDevice = IT_BuyDeviceMonitorDAL.Instance.getBuyDevicesByDbNumber(rcInput.NoteDBNumber);
                            var lstDevices = new List<IT_DevicesManagement>();
                            lstDevices = ITDevicesManagement_DAL.Instance.getDevicesByNoteDbNumber(rcInput.NoteDBNumber);

                           // buyDevice.SubDbNumber = rcInput.NoteDBNumber;

                            if (buyDevice.Qty > lstDevices.Count)
                            {
                                buyDevice.UpdatedBy = Program.UserId;
                                buyDevice.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                IT_BuyDeviceMonitorDAL.Instance.UpdateQty(buyDevice);
                            }
                            else
                            {
                                MessageBox.Show("Có thể có nhầm lẫn khi thêm hoặc xuất thiết bị này" + "\n\n" + "Thông báo cho IT !!!"
                                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }                       
                        rcInput.CreatedBy = Program.username;
                        rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        rcInput.UpdateBy = Program.UserId;
                        ITDevicesManagement_DAL.Instance.Add(rcInput);                        
                    }
                    progressBar.Value = rCnt;
                    j = 0;
                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, ITDevicesManagement_DAL.Instance.getListDevices());
                txtFile.Text = "";
                progressBar.Visible = false;
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                CommonDAL.Instance.releaseObject(xlWorkSheet);
                CommonDAL.Instance.releaseObject(xlWorkBook);
                CommonDAL.Instance.releaseObject(xlApp);
            }
        }

           

        private void cbLoaiTB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (AddFlag==true)
            {
                cbLoaiTB.Refresh();
                cbLoaiTB.Update();
                if (cbLoaiTB.Text.Equals("DESKTOP") || cbLoaiTB.Text.Equals("LAPTOP"))
                {
                    var dt = new DataTable();
                    dt = ITDevicesManagement_DAL.Instance.getLastSerialDesktopLaptop();
                    txtMaTB.Text = "DELL-2021" + (int.Parse(dt.Rows[0]["MaTB"].ToString().Substring(9, 5)) + 1).ToString("00000");
                    //DELL-202100119
                }
                else
                {
                    var dt = new DataTable();
                    dt = ITDevicesManagement_DAL.Instance.getLastMaTBOtherDevices(cbLoaiTB.Text);
                    if (dt.Rows.Count > 0)
                    {
                        string lastStr = (int.Parse(dt.Rows[0]["MaTB"].ToString().Substring(dt.Rows[0]["MaTB"].ToString().Length - 5)) + 1).ToString("00000");
                        txtMaTB.Text = dt.Rows[0]["MaTB"].ToString().Substring(0, dt.Rows[0]["MaTB"].ToString().Length - lastStr.Length) + lastStr;
                    }
                    else
                    {
                        int i = 1;
                        txtMaTB.Text=cbLoaiTB.Text.Substring(0,4)+"-2021"+i.ToString("00000");
                    }
                }
            }
            
        }

        private void cbDbNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbDbNumber.SelectedValue.ToString());
            if (!cbDbNumber.SelectedValue.ToString().Equals("System.Data.DataRowView")
                )
            {
                if (!cbDbNumber.SelectedValue.ToString().Equals("[None]"))
                {
                    var dt = new DataTable();
                    dt = IT_BuyDeviceMonitorDAL.Instance.getInfoSubDbNumber(cbDbNumber.SelectedValue.ToString());

                    txtModel.Text = dt.Rows[0]["Model"].ToString();
                    txtTenTB.Text = dt.Rows[0]["Model"].ToString();
                    rtxtMotaTB.Text = dt.Rows[0]["DDescription"].ToString();                   
                    txtSupplier.Text = dt.Rows[0]["Supplier"].ToString();
                    dtpBuyDate.Value = DateTime.Parse(dt.Rows[0]["ReceiverDate"].ToString());
                }
                
            }
        }

        private void iconbtnIssueReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maTB) || maTB.Equals(""))
            {
                MessageBox.Show("Hãy chọn mã thiết bị cần Issue or Return !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SysControl.IT.frmIssueReturn frm = new SysControl.IT.frmIssueReturn(this);
                frm.ShowDialog();
            }
        }

        private void ToolStripMenuItemViewHistory_Click(object sender, EventArgs e)
        {
            frmIssueHistory frm = new frmIssueHistory();
            frm.ShowDialog();
        }

        private void cbDbNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
           // loadCombobox();
        }

        private void iconbtnShow_Click(object sender, EventArgs e)
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, ITDevicesManagement_DAL.Instance.getListDevicesStockOnly());
        }
    }
}
