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
using DocumentFormat.OpenXml.Spreadsheet;
using System.Web.Caching;

namespace SMTPRORAM.Jig
{
    public partial class frmJIGINOUT : Form
    {
        public frmJIGINOUT()
        {
            InitializeComponent();
        }
        private bool flagCheck = false;
        private string InOutFlag = "";
        private bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        private long Id = 0;
        private string controNo = "";
        private void frmJIGINOUT_Load(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            txtControlNo.Focus();

            showInOutByUserId();
            LoadCombobox();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
            if (frmViewCalibrationDevices.sendControlNo!="")
            {
                txtControlNo.Text = frmViewCalibrationDevices.sendControlNo;
                SendKeys.Send("{ENTER}");
            }
        }
        void _enable(bool t)
        {
            txtControlNo.Enabled = t;
            cbFromLoc.Enabled = t;
            cbFromSec.Enabled = t;
            txtPIC.Enabled = t;
            txtApprove.Enabled = t;
            txtRemark.Enabled = t;
            cbToLoc.Enabled = t;
            cbToSec.Enabled = t;
            txtSStatus.Enabled = t;
            txtUseStatus.Enabled = t;
            txtNGDetail.Enabled = t;
        }

        void ResetControll()
        {
            txtControlNo.Text = "";
            cbFromLoc.Text = "[None]";
            cbFromSec.Text = "[None]";
            txtPIC.Text = "";
            txtApprove.Text = "";
            txtRemark.Text = "";
            cbToLoc.Text = "[None]";
            cbToSec.Text = "[None]";
            txtNGDetail.Text = "";
            txtSStatus.Text = "";
            txtUseStatus.Text = "";
        }
        void ResetControll2()
        {
            txtControlNo.Text = "";
            cbFromLoc.Text = "[None]";
            cbFromSec.Text = "[None]";
            txtRemark.Text = "";
            cbToLoc.Text = "[None]";
            cbToSec.Text = "[None]";
            txtNGDetail.Text = "";
            txtSStatus.Text = "";
            txtUseStatus.Text = "";
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void showInOutByUserId()
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, JIGINOUT_DAL.Instance.getListJigInOutDaily(Program.UserId));
            //dgView.DataSource = JIGINOUT_DAL.Instance.getInOutByUserId(Program.UserId);           
            //foreach (DataGridViewRow row in dgView.Rows)
            //{
            //    var calDevices = new JIG_CALDEVICES();
            //    calDevices = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(row.Cells[2].Value.ToString());
            //    if (calDevices != null)
            //    {
            //        DateTime calDate = calDevices.CalDate;
            //        DateTime currentDate = CommonDAL.Instance.getSqlServerDatetime();

            //        var calType = new JIG_CALTYPE();
            //        calType = JIGCALTYPE_DAL.Instance.checkCalTypeExist(calDevices.CalType);
            //        int cycle = calType.Cycle;
            //        if (calDate.AddMonths(cycle) <= currentDate.AddMonths(1))
            //        {
            //            row.DefaultCellStyle.BackColor=System.Drawing.Color.Red;
            //        }
            //    }

            //}    

        }
        private void LoadCombobox()
        {
            var lstLoc = JIGLOCATION_DAL.Instance.getListLocation();
            var loc = new ShowDisplay();
            loc.LocName = "[None]";
            lstLoc.Add(loc);
            cbFromLoc.DataSource = lstLoc.OrderBy(p => p.LocName).ToList();
            cbFromLoc.DisplayMember = "LocName";
            cbFromLoc.ValueMember = "LocName";


            cbToLoc.DataSource = lstLoc.OrderBy(p => p.LocName).ToList();
            cbToLoc.DisplayMember = "LocName";
            cbToLoc.ValueMember = "LocName";


            var lstSec = JIGSECTION_DAL.Instance.getListSection();
            var sec = new ShowView();
            sec.JigSecCode = "[None]";
            lstSec.Add(sec);
            cbFromSec.DataSource = lstSec.OrderBy(p => p.JigSecCode).ToList();
            cbFromSec.DisplayMember = "JigSecCode";
            cbFromSec.ValueMember = "JigSecCode";


            cbToSec.DataSource = lstSec.OrderBy(p => p.JigSecCode).ToList();
            cbToSec.DisplayMember = "JigSecCode";
            cbToSec.ValueMember = "JigSecCode";
        }

        private void cbFromSec_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbFromLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbToSec_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbToLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private bool checkControlNo()
        {
			// Kiểm tra xem mã này có trong csdl hay không?
			// 1. Nếu có trong csl thì 
			// 1.1 Kiểm tra xem còn không? Nếu không còn thì có nghĩ là đã xuất xuống sx rồi
			string inputString = txtControlNo.Text.Trim();
			char[] separator = { ';' };
			string[] result = inputString.Split(separator);
			if (!result[0].Equals(""))
			{
				txtControlNo.Text = result[0];
				var calDevices = new JIG_CALDEVICES();
				calDevices = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(result[0].ToString());
				if (calDevices != null && !calDevices.SStatus.Contains("NG"))
				{
					DateTime calDate = calDevices.CalDate;
					var calType = new JIG_CALTYPE();
					calType = JIGCALTYPE_DAL.Instance.checkCalTypeExist(calDevices.CalType);
					int cycle = calType.Cycle;
					if (calDate.AddMonths(cycle) <= CommonDAL.Instance.getSqlServerDatetime().AddMonths(1))
					{
						flagCheck = true;
					}
					if (calDevices.Real == true) // Vẫn trong phòng JIG
					{
						//InOutFlag = "OUT";
						cbFromSec.Text = calDevices.JigSecCode;
						cbFromLoc.Text = calDevices.LocName;
						txtSStatus.Text = calDevices.SStatus;
						txtUseStatus.Text = calDevices.UseStatus;
						txtNGDetail.Text = calDevices.NGDetail;
						txtPIC.Focus();
					}
					else // Đã xuất ra sản xuất rồi --> Ngầm hiểu là trả lại phòng JIG
					{
						var lastOut = new JIG_INOUT();
						lastOut = JIGINOUT_DAL.Instance.getLastOutJig(calDevices.ControlNo);
						if (lastOut == null)
						{
							MessageBox.Show("Đã có sự nhầm lẫn trong quá trình thêm dữ liệu", "Thông báo",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
						else
						{
							//InOutFlag = "IN";
							cbFromSec.Text = lastOut.ToSecCode;
							cbFromLoc.Text = lastOut.ToLocCode;

							cbToSec.Text = calDevices.JigSecCode;
							cbToLoc.Text = calDevices.LocName;
							txtSStatus.Text = calDevices.SStatus;
							txtUseStatus.Text = calDevices.UseStatus;
							txtNGDetail.Text = calDevices.NGDetail;
							txtPIC.Focus();
						}

					}
				}
				else
				{
					MessageBox.Show("Mã này không có trong csdl hoặc Tình trạng thiết bị đang NG !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtControlNo.Focus();
					txtControlNo.SelectAll();
					return false;
				}
			}

			return true;
        }    

        private void txtControlNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter||e.KeyCode==Keys.Tab)
            {
                if (checkControlNo())
                {
                    txtPIC.Focus();
                }
                else
                {
                    txtControlNo.Focus();
                    txtControlNo.SelectAll();
                }
                /*
                // Kiểm tra xem mã này có trong csdl hay không?
                // 1. Nếu có trong csl thì 
                // 1.1 Kiểm tra xem còn không? Nếu không còn thì có nghĩ là đã xuất xuống sx rồi
                string inputString = txtControlNo.Text.Trim();
                char[] separator = { ';' };
                string[] result = inputString.Split(separator);
                if (!result[0].Equals(""))
                {
                    txtControlNo.Text = result[0];
                    var calDevices = new JIG_CALDEVICES();
                    calDevices = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(result[0].ToString());
                    if (calDevices != null)
                    {
                        DateTime calDate = calDevices.CalDate;
                        var calType = new JIG_CALTYPE();
                        calType = JIGCALTYPE_DAL.Instance.checkCalTypeExist(calDevices.CalType);
                        int cycle = calType.Cycle;
                        if (calDate.AddMonths(cycle) <= CommonDAL.Instance.getSqlServerDatetime().AddMonths(1))
                        {
                            flagCheck = true;
                        }
                        if (calDevices.Real == true) // Vẫn trong phòng JIG
                        {
                            //InOutFlag = "OUT";
                            cbFromSec.Text = calDevices.JigSecCode;
                            cbFromLoc.Text = calDevices.LocName;
                            txtSStatus.Text = calDevices.SStatus;
                            txtUseStatus.Text = calDevices.UseStatus;
                            txtNGDetail.Text = calDevices.NGDetail;
                            txtPIC.Focus();
                        }
                        else // Đã xuất ra sản xuất rồi --> Ngầm hiểu là trả lại phòng JIG
                        {
                            var lastOut = new JIG_INOUT();
                            lastOut = JIGINOUT_DAL.Instance.getLastOutJig(calDevices.ControlNo);
                            if (lastOut == null)
                            {
                                MessageBox.Show("Đã có sự nhầm lẫn trong quá trình thêm dữ liệu", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                //InOutFlag = "IN";
                                cbFromSec.Text = lastOut.ToSecCode;
                                cbFromLoc.Text = lastOut.ToLocCode;

                                cbToSec.Text = calDevices.JigSecCode;
                                cbToLoc.Text = calDevices.LocName;
                                txtSStatus.Text = calDevices.SStatus;
                                txtUseStatus.Text = calDevices.UseStatus;
                                txtNGDetail.Text = calDevices.NGDetail;
                                txtPIC.Focus();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã này không có trong csdl :D !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtControlNo.Focus();
                        txtControlNo.SelectAll();
                        return;
                    }
                }
                */
            }
        }
        private bool checkControlAgain()
        {
			var calDevices = new JIG_CALDEVICES();
			calDevices = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(txtControlNo.Text.Trim());
            if (calDevices==null)
            {
                return false;
            }
            return true;
		}    
        private bool IsDataOK()
        {
            if (!checkControlAgain())
            {
                //MessageBox.Show("Hãy nhập Control No vào !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtControlNo.Focus();
                return false;
            }
            if (cbFromLoc.Text.Equals("") || cbFromLoc.Text.Equals("[None]"))
            {
                MessageBox.Show("Nhập từ vị trí nào !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFromLoc.Focus();
                return false;
            }
            if (cbFromSec.Text.Equals("") || cbFromSec.Text.Equals("[None]"))
            {
                MessageBox.Show("Nhập từ Section nào !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFromSec.Focus();
                return false;
            }
            if (txtPIC.Text.Equals(""))
            {
                MessageBox.Show("Hãy nhập PIC liệu vào ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPIC.Focus();
                return false;
            }
            if (txtApprove.Text.Equals(""))
            {
                MessageBox.Show("Hãy nhập PIC liệu vào ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApprove.Focus();
                return false;
            }
            if (cbToLoc.Text.Equals("") || cbToLoc.Text.Equals("[None]"))
            {
                MessageBox.Show("Nhập tới vị trí nào !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbToLoc.Focus();
                return false;
            }
            if (cbToSec.Text.Equals("") || cbToSec.Text.Equals("[None]"))
            {
                MessageBox.Show("Nhập tới Section nào !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbToSec.Focus();
                return false;
            }
            if (cbToSec.Text.Equals(cbFromSec.Text))
            {
                MessageBox.Show("From Section và To Section không được giống nhau !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbToSec.Focus();
                return false;
            }
            if (cbFromLoc.Text.Equals(cbToLoc.Text))
            {
                MessageBox.Show("From Location và To Location không được giống nhau !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFromLoc.Focus();
                return false;
            }
            if (txtSStatus.Text.Trim().Equals(""))
            {
                MessageBox.Show("Trạng thái của thiết bị phải điền !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSStatus.Focus();
                return false;
            }
            else
            {
                if (txtUseStatus.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Tình trạng của thiết bị phải điền !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUseStatus.Focus();
                    return false;
                }
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            
            if (IsDataOK() == true)
            {
                var jigInOut = new JIG_INOUT();
                jigInOut.ControlNo = txtControlNo.Text.Trim();
                jigInOut.FromLocCode = cbFromLoc.Text.Trim();
                jigInOut.FromSecCode = cbFromSec.Text.Trim();
                jigInOut.PIC = txtPIC.Text.Trim();
                jigInOut.Appr = txtApprove.Text.Trim();
                jigInOut.ToLocCode = cbToLoc.Text.Trim();
                jigInOut.ToSecCode = cbToSec.Text.Trim();
                jigInOut.Remark = txtRemark.Text.Trim();

                // Thêm 2 thuộc tính caldate và cycle để tính toán ngày hiệu chỉnh
                var jigCalGet = new JIG_CALDEVICES();
                jigCalGet = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(txtControlNo.Text.Trim());
                if (jigCalGet != null)
                {
                    jigInOut.CalDate = jigCalGet.CalDate;
                    // Lấy cycle thông qua jig type
                    var calType = new JIG_CALTYPE();
                    calType = JIGCALTYPE_DAL.Instance.checkCalTypeExist(jigCalGet.CalType.ToString());
                    jigInOut.Cycle = calType.Cycle;
                }
                else
                {
                    MessageBox.Show("Thiết bị  này không có trong csld", "Thông báo"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                jigInOut.CreatedBy = Program.UserId;
                jigInOut.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                // Nếu to section mà là JIG hoặc EQ thì mặc định là IN 
                // Ngược lại thì là OUT
                if (cbToSec.Text.Trim().ToUpper().Contains("EQUIPMENT") || cbToSec.Text.Trim().ToUpper().Contains("JIG"))
                {
                    jigInOut.InOut_Type = "IN";
                    string message = JIGINOUT_DAL.Instance.Add(jigInOut);
                    if (message != "")
                    {
                        MessageBox.Show("Đã có lỗi xảy ra IN " + message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string messages = "";
                        messages = JIGCALDEVICES_DAL.Instance.UpdateRealIN(jigInOut.ControlNo, true, txtSStatus.Text.Trim(),
                            txtNGDetail.Text.Trim(), txtUseStatus.Text.Trim(),cbToSec.Text,cbToLoc.Text);
                        if (messages == "")
                        {

                        }
                        else
                        {
                            MessageBox.Show(messages, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    jigInOut.InOut_Type = "OUT";
                    string message = JIGINOUT_DAL.Instance.Add(jigInOut);
                    if (message != "")
                    {
                        MessageBox.Show("Đã có lỗi xảy ra OUT " + message, "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string messages = "";

                        messages = JIGCALDEVICES_DAL.Instance.UpdateRealOUT(jigInOut.ControlNo, false, txtSStatus.Text.Trim(),
                            txtNGDetail.Text.Trim(), txtUseStatus.Text.Trim());
                        if (messages == "")
                        {

                        }
                        else
                        {
                            MessageBox.Show(messages, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                
               

                //if (InOutFlag == "OUT")
                //{
                   
                //    //JIGINOUT_DAL.Instance.Add(jigInOut);
                    
                //}
                //else
                //{
                    

                //}
                //InOutFlag = "";
                showHideControll(false);
                _enable(true);
                if (chkKeep.Checked == true)
                {
                    ResetControll2();
                }
                else
                {
                    ResetControll();
                }

                txtControlNo.Focus();
                showInOutByUserId();
                LoadCombobox();
            }
        }

        private void dgView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //foreach (DataGridViewRow row in dgView.Rows)
            //{
            //   // row = dgView.Rows[e.RowIndex];
            //    var calDevices = new JIG_CALDEVICES();
            //    calDevices = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(row.Cells[2].Value.ToString());
            //    if (calDevices != null)
            //    {
            //        DateTime calDate = calDevices.CalDate;
            //        DateTime currentDate = CommonDAL.Instance.getSqlServerDatetime();

            //        var calType = new JIG_CALTYPE();
            //        calType = JIGCALTYPE_DAL.Instance.checkCalTypeExist(calDevices.CalType);
            //        int cycle = calType.Cycle;
            //        if (calDate.AddMonths(cycle) <= currentDate.AddMonths(1))
            //        {
            //            row.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
            //        }
            //    }
            //}
            // DataGridViewRow row = dgView.Rows[e.RowIndex];// get you required index
            // check the cell value under your specific column and then you can toggle your colors
            //row.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
        }

        private void dgView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= dgView.FirstDisplayedScrollingRowIndex && e.RowIndex < (dgView.FirstDisplayedScrollingRowIndex + dgView.DisplayedRowCount(true)))
            {
                DateTime currentDate = CommonDAL.Instance.getSqlServerDatetime();
                DataGridViewRow row = dgView.Rows[e.RowIndex];
                DateTime calDate = DateTime.Parse(row.Cells["CalDate"].Value.ToString());
                int Cycle = int.Parse(row.Cells["Cycle"].Value.ToString());
                if (calDate.AddMonths(Cycle) <= currentDate.AddMonths(1))
                {
                    // Thiết lập màu nền cho dòng dữ liệu
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                    // row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
    }
}
