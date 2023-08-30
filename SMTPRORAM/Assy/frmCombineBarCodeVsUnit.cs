using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Assy;
using UnidenDAL.Assy.Setup;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Staging;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;
using static ClosedXML.Excel.XLPredefinedFormat;
using DataTable = System.Data.DataTable;

namespace SMTPRORAM.Assy
{
    public partial class frmCombineBarCodeVsUnit : Form
    {
        public frmCombineBarCodeVsUnit()
        {
            InitializeComponent();
        }
        private void ClearLabel()
        {
            lblLine.Text = string.Empty;
            lblLot.Text = string.Empty;
            lblProcess.Text = string.Empty;
            lblOperator.Text = string.Empty;
            lblQRCode.Text = string.Empty;
            lblUnitCode.Text = string.Empty;
            pictureBoxNG.Visible = false;
            pictureBoxOK.Visible = false;
        }
        private void loadLotforCombobox()
        {
            DataTable dtLot = new DataTable();
            dtLot = MODELLOTINFO_DAL.Instance.getLotForSetupProcess();
            DataRow dataRow = dtLot.NewRow();
            dataRow["Lot"] = "--Select--";
            dtLot.Rows.InsertAt(dataRow, 0);
            dtLot.DefaultView.Sort = "Lot";
            DataTable dt = new DataTable();
            dt = dtLot.DefaultView.ToTable();

            cbLot.DataSource = dt;
            cbLot.DisplayMember = "Lot";
            cbLot.ValueMember = "Lot";
        }
        private void loadLineName()
        {
            var line = new ViewCombobox();
            line.LineName = "--Select--";
            var listLine = new List<ViewCombobox>();
            listLine = UVProLineDAL.Instance.getLineNotSMTDeptID(10001);
            listLine.Insert(0, line); // Add "--Select--" item at the beginning of the list
            //alistLine = 
            cbLine.DataSource = listLine.OrderBy(x => x.ID).ToList();
            cbLine.DisplayMember = "LineName";
            cbLine.ValueMember = "LineName";
        }
        private void loadProcess()
        {
            var line = new ListBoxView();
            line.processID = 0;
            line.processName = "--Select--";

            var listProcess = new List<ListBoxView>();
            listProcess = LINEPROCESS_DAL.Instance.getProcessScanQRByLot(cbLot.Text);
            listProcess.Add(line);
            listProcess = listProcess.OrderBy(x => x.processID).ToList();

            cbProcessName.DataSource = listProcess;
            cbProcessName.DisplayMember = "processName";
            cbProcessName.ValueMember = "processID";
        }

        private void frmCombineBarCodeVsUnit_Load(object sender, EventArgs e)
        {
            lblTotal.Text = "";
            lblUserTotal.Text = "";
            ClearLabel();
            loadLineName();
            cbLine.Focus();
        }

        private void cbLine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cbLine.Text.Equals("--Select--"))
            {
                lblLine.Text = "OK";
                lblLine.ForeColor = Color.Green;
                cbLot.Enabled = true;
                loadLotforCombobox();
            }
        }

        private void iconbtnReset01_Click(object sender, EventArgs e)
        {
            if (cbLine.Enabled == false)
            {
                cbLine.Enabled = true;
            }
            lblLine.Text = string.Empty;
            cbLine.Text = "--Select--";
            cbLine.Focus();
        }

        private void cbLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cbLot.Text.Equals("--Select--"))
            {
                lblLot.Text = "OK";
                lblLot.ForeColor = Color.Green;
                cbProcessName.Enabled = true;
                loadProcess();
            }
        }

        private void iconbtnReset02_Click(object sender, EventArgs e)
        {
            if (cbLot.Enabled == false)
            {
                cbLot.Enabled = true;
            }
            lblLot.Text = string.Empty;
            cbLot.Text = "--Select--";
            cbLot.Focus();
        }

        private void cbProcessName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cbProcessName.Text.Equals("--Select--"))
            {
                lblProcess.Text = "OK";
                lblProcess.ForeColor = Color.Green;
                txtEmployeeID.Enabled = true;
                txtEmployeeID.Focus();
            }
        }

        private bool checkEmployee()
        {
			if (!txtEmployeeID.Text.Trim().Equals(""))
			{
				lblOperator.Text = "OK";
				lblOperator.ForeColor = Color.Green;				
			}
			else
			{
				lblOperator.Text = "NG";				
				lblOperator.ForeColor = Color.Red;
                return false;
			}
			return true;
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            // bắn QR code của công nhân
            if (Keys.Enter == e.KeyCode)
            {
                if (checkEmployee())
                {                   
                    txtQRCode.Focus();
                }
                else
                {                   
                    txtEmployeeID.Focus();                  
                }
            }
        }

        private void iconbtnReset03_Click(object sender, EventArgs e)
        {
            // Làm lại khi bắn sai công nhân
            lblOperator.Text = string.Empty;
            txtEmployeeID.Text = string.Empty;
            txtEmployeeID.Focus();
        }
        private string checkProcess(List<UV_LINEPROCESS> lstProcess, string qrcode, long currentProcessId)
        {
            string message = "";
            // Find the index of the current process in the list
            int currentIndex = lstProcess.FindIndex(p => p.ProcessId == currentProcessId);
            // Check if the current process is the first or last step
            if (currentIndex == 0)
            {
                message = "0";
            }
            else if (currentIndex == lstProcess.Count - 1)
            {

                // Nếu là bước cuối cùng thì kiểm tra xem bước trước nó đã thực hiện chưa?
                long previousProcessId = lstProcess[currentIndex - 1].ProcessId;
                var recordProcess = new List<UV_LINEPROCESS_HISTORY>();
                recordProcess = LINEPROCESSHISTORY_DAL.Instance.checkProcessScannedQRCode(qrcode, previousProcessId);
                if (recordProcess.Count > 0)
                {
                    message = "1";
                }
                else
                {
                    message = "Chưa qua công đoạn trước đó: " + lstProcess[currentIndex - 1].ProcessName;  // Chưa qua công đoạn trước đó
                }
            }
            else
            {
                foreach (var process in lstProcess)
                {
                    // Nếu nó không phải là bước đầu tiên và bước cuối cùng thì kiểm tra xem bước trước nó đã thực hiện chưa
                    // Nếu là bước cuối cùng thì kiểm tra xem bước trước nó đã thực hiện chưa?
                    long previousProcessId = lstProcess[currentIndex - 1].ProcessId;
                    var recordProcess = new List<UV_LINEPROCESS_HISTORY>();
                    recordProcess = LINEPROCESSHISTORY_DAL.Instance.checkProcessScannedQRCode(qrcode, previousProcessId);
                    if (recordProcess.Count > 0)
                    {
                        message = "2";
                        break;
                    }
                    else
                    {
                        message = "Chưa qua công đoạn trước đó: " + lstProcess[currentIndex - 1].ProcessName;  // Chưa qua công đoạn trước đó
                        break;
                    }
                }
            }

            return message;
        }
        private bool isOKData()
        {
            if (cbLine.Text.Equals("--Select--"))
            {
                MessageBox.Show("Phải nhập tên chuyền sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLine.Focus();
                return false;
            }
            if (cbLot.Text.Equals(""))
            {
                MessageBox.Show("Phải nhập LOT sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLot.Focus();
                return false;
            }
            if (cbProcessName.Text.Equals("") || cbProcessName.Text.Equals("[None]"))
            {
                MessageBox.Show("Phải chọn công đoạn sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbProcessName.Focus();
                return false;
            }          
            if (!checkEmployee())
            {
                //MessageBox.Show("ID của công nhân thực hiện công đoạn không để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtEmployeeID.Focus();
                return false;
            }
            if (!checkQRCode())
            {
                //MessageBox.Show("Phải có ít nhất một số QRCode để combine thành Barcode ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtQRCode.Focus();
                return false;
            }
            if (!checkUnicode())
            {
                //MessageBox.Show("Unit code không được để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtUnitcode.Focus();
                return false;
            }
            return true;
        }
        private void SaveData()
        {
            if (isOKData())
            {
                var history = new UV_LINEPROCESS_HISTORY();
                history.LineName = cbLine.Text;
                history.Lot = cbLot.Text;
                history.ProcessId = long.Parse(cbProcessName.SelectedValue.ToString());
                var processInfo = LINEPROCESS_DAL.Instance.getProcessInfo(history.ProcessId);
                history.ProcessName = processInfo.ProcessName;
                history.LineName = cbLine.Text;
                history.OperatorID = txtEmployeeID.Text.Trim();
                history.CreatedBy = Program.UserId;
                history.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                history.QrCode00 = txtQRCode.Text.Trim();
                history.Other01=txtUnitcode.Text.Trim();
              
                string message = "";
                message = LINEPROCESSHISTORY_DAL.Instance.Add(history);

                if (message != "")
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pictureBoxNG.Visible = true;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                    pictureBoxNG.Visible = false;
                    txtQRCode.SelectAll();
                    txtQRCode.Focus();
                    return;
                }
                else
                {
                    //PrintLabel(history.QrCode00);
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESSHISTORY_DAL.Instance.getListProcessByUser(Program.UserId));
                    pictureBoxOK.Visible = true;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                    pictureBoxOK.Visible = false;
                    AfterSave();
                }
            }
        }
		private bool IsStringNumeric(string input)
		{
			// Regular expression pattern to match numeric characters
			string pattern = @"^\d+$";

			// Create a Regex object with the pattern
			Regex regex = new Regex(pattern);

			// Check if the input matches the pattern
			return regex.IsMatch(input);
		}
		private void AfterSave()
        {
            cbLine.Enabled = false;
            cbLot.Enabled = false;
            cbProcessName.Enabled = false;
            txtEmployeeID.Enabled = false;
            txtUnitcode.ReadOnly = true;
            txtQRCode.ReadOnly = false;
            txtQRCode.Text = "";
            txtQRCode.Focus();
        }
        private bool checkQRCode()
        {
			bool isNumeric = IsStringNumeric(txtQRCode.Text.Trim());
			if (txtQRCode.Text.Trim().Equals(""))
            {
				lblQRCode.Text = "NG";
				lblQRCode.ForeColor = Color.Red;
				return false;
			}
            if (!isNumeric)
            {
				lblQRCode.Text = "NG";
				lblQRCode.ForeColor = Color.Red;
				return false;
			}
			           
			// Kiểm tra xem đã được bắn lần nào ở công đoạn này chưa?
			// ( sử dụng tên lot / processid/ qrcode để kiểm tra)
			var checkQR = new UV_LINEPROCESS_HISTORY();
			//checkQR = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtQRCode.Text.Trim(), cbLot.Text, long.Parse(cbProcessName.SelectedValue.ToString()));
			checkQR = LINEPROCESSHISTORY_DAL.Instance.checkSannedBarcode(txtQRCode.Text.Trim(), long.Parse(cbProcessName.SelectedValue.ToString()));
			if (checkQR != null)
			{
				//MessageBox.Show("Công đoạn này đã được nhập vào csdl bởi: " + checkQR.CreatedBy + "\n"
				//	+ "Ngày: " + checkQR.CreatedDate + "\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);	
				//	
                lblQRCode.Text = "NG";
				lblQRCode.ForeColor = Color.Red;
				return false;
			}
			// Kiểm tra xem đã qua công đoạn trước đó chưa hay nó là công đoạn đầu tiên.
			long currentProcess = long.Parse(cbProcessName.SelectedValue.ToString());
			var processList = LINEPROCESS_DAL.Instance.getProcessList(cbLot.Text);
			string checkMessage = checkProcess(processList, txtQRCode.Text.Trim(), currentProcess);
			if (checkMessage == "0" ||
				checkMessage == "1" ||
				checkMessage == "2")
			{
				// Là công đoạn đầu tiên
				// MessageBox.Show("Đây là công đoạn đầu tiên");
				// Kiểm tra xem có trùng nhau hay không?
				lblQRCode.Text = "OK";
				lblQRCode.ForeColor = Color.Green;
				txtQRCode.ReadOnly = true;
				txtUnitcode.ReadOnly = false;
				
                //txtUnitcode.Focus();
			}			
			else
			{
				// Chua qua công đoạn trước đó
				// MessageBox.Show(checkMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				lblQRCode.Text = "NG";
				lblQRCode.ForeColor = Color.Red;
                //txtQRCode.Focus();
                //txtQRCode.SelectAll();
                return false;
			}			
			return true;
        }

        private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                if ( checkQRCode())
                {
                    txtUnitcode.Focus();
                }
                else
                {
                    txtQRCode.SelectAll();
                    txtQRCode.Focus();
                }
                /*
                // Kiểm tra xem đã được bắn lần nào ở công đoạn này chưa?
                // ( sử dụng tên lot / processid/ qrcode để kiểm tra)
                var checkQR = new UV_LINEPROCESS_HISTORY();
                //checkQR = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtQRCode.Text.Trim(), cbLot.Text, long.Parse(cbProcessName.SelectedValue.ToString()));
                checkQR = LINEPROCESSHISTORY_DAL.Instance.checkSannedBarcode(txtQRCode.Text.Trim());
				if (checkQR != null)
                {
                    MessageBox.Show("Công đoạn này đã được nhập vào csdl bởi: " + checkQR.CreatedBy + "\n"
                        + "Ngày: " + checkQR.CreatedDate + "\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQRCode.Focus();
                    txtQRCode.SelectAll();
                    return;
                }
                // Kiểm tra xem đã qua công đoạn trước đó chưa hay nó là công đoạn đầu tiên.
                long currentProcess = long.Parse(cbProcessName.SelectedValue.ToString());
                var processList = LINEPROCESS_DAL.Instance.getProcessList(cbLot.Text);
                string checkMessage = checkProcess(processList, txtQRCode.Text.Trim(), currentProcess);
                if (checkMessage == "0" ||
					checkMessage == "1" ||
					checkMessage == "2")
                {
                    // Là công đoạn đầu tiên
                    // MessageBox.Show("Đây là công đoạn đầu tiên");
                    // Kiểm tra xem có trùng nhau hay không?
                    lblQRCode.Text = "OK";
                    lblQRCode.ForeColor = Color.Green;
                    txtQRCode.ReadOnly = true;
                    txtUnitcode.ReadOnly = false;
                    txtUnitcode.Focus();
                }
                //else if (checkMessage == "1")
                //{
                //    // Là công đoạn cuối cùng
                //    //MessageBox.Show("Đây là công đoạn cuối cùng");
                //    lblQRCode.Text = "OK";
                //    lblQRCode.ForeColor = Color.Green;
                //    txtQRCode.ReadOnly = true;
                //    txtUnitcode.ReadOnly = false;
                //    txtUnitcode.Focus();
                //    //txtQRCode.Focus();
                //    //txtQRCode.SelectAll();
                //}
                //else if (checkMessage == "2")
                //{
                //    // Đã qua công đoạn trước đó
                //    //MessageBox.Show("Đã qua công đoạn trước đó");
                //    lblQRCode.Text = "OK";
                //    lblQRCode.ForeColor = Color.Green;
                //    txtQRCode.ReadOnly = true;
                //    txtUnitcode.ReadOnly = false;
                //    txtUnitcode.Focus();
                //    //txtQRCode.Focus();
                //    //txtQRCode.SelectAll();
                //}
                else
                {
                    // Chua qua công đoạn trước đó
                    MessageBox.Show(checkMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblQRCode.Text = "NG";
                    lblQRCode.ForeColor = Color.Red;
                    txtQRCode.Focus();
                    txtQRCode.SelectAll();
                }  
                */
            }
        }

        private bool checkUnicode()
        {
			if (!txtUnitcode.Text.Equals(""))
			{
				// Kiểm tra Unitcode có khác barcode không?
				if (txtUnitcode.Text.Trim().Equals(txtQRCode.Text.Trim()))
				{
					//MessageBox.Show("Unit không được giống với QR code!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					lblUnitCode.Text = "NG";
					lblUnitCode.ForeColor = Color.Red;
					//txtUnitcode.SelectAll();
					//txtUnitcode.Focus();
					return false;
				}

                // Kiểm tra xem Unitcode có chưa yymmdd không? Loại bỏ trường hợp bắn cả unitcode và barcode vào 
                var date = CommonDAL.Instance.getSqlServerDatetime();
                string cdate=date.Year.ToString().Substring(2,2)+date.Month.ToString("00")+date.Day.ToString("00");

                if (txtUnitcode.Text.Trim().Equals(cdate))
                {
					lblUnitCode.Text = "NG";
					lblUnitCode.ForeColor = Color.Red;
                    return false;
				}
				
				// Kiểm tra xem Unit đã được dùng lần nào chưa?
				// Nếu được dùng rồi thì báo lỗi ở lần bắn gần nhất.
				// Kiểm tra ở cột Other01

				bool checkUnit = false;
				checkUnit = LINEPROCESSHISTORY_DAL.Instance.checkUnitSerial(txtUnitcode.Text.Trim());
				if (checkUnit == false)
				{
					lblUnitCode.Text = "OK";
					lblUnitCode.ForeColor = Color.Green;
					// Kiểm tra xem có những công đoạn nào chưa đươc kiểm tra

					//SaveData();
					//txtUnitcode.Text = "";
				}
				else
				{
					lblUnitCode.Text = "NG";
					lblUnitCode.ForeColor = Color.Red;
                    //txtUnitcode.SelectAll();
                    //txtUnitcode.Focus();
                    return false;
				}
			}
			else
			{
				lblUnitCode.Text = "NG";
				lblUnitCode.ForeColor = Color.Red;
                //txtUnitcode.Focus();
                return false;
			}
            return true;
		}

        private void txtUnitcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                if (checkUnicode())
                {
                    SaveData();
                    txtUnitcode.Text = "";
                }
                else
                {
                    txtUnitcode.Focus();
                    txtUnitcode.SelectAll();
                }
				/*
                if (!txtUnitcode.Text.Equals(""))
                {
                    // Kiểm tra Unitcode có khác barcode không?
                    if (txtUnitcode.Text.Trim().Equals(txtQRCode.Text.Trim()))
                    {
                        MessageBox.Show("Unit không được giống với QR code!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUnitcode.SelectAll();
                        txtUnitcode.Focus();
                        return;
                    }
                    else
                    {
						// Kiểm tra xem Unit đã được dùng lần nào chưa?
						// Nếu được dùng rồi thì báo lỗi ở lần bắn gần nhất.
						// Kiểm tra ở cột Other01

						bool checkUnit = false;
						checkUnit = LINEPROCESSHISTORY_DAL.Instance.checkUnitSerial(txtUnitcode.Text.Trim());
						if (checkUnit == false)
						{
							lblUnitCode.Text = "OK";
							lblUnitCode.ForeColor = Color.Green;
							// Kiểm tra xem có những công đoạn nào chưa đươc kiểm tra

							SaveData();
							txtUnitcode.Text = "";
						}
						else
						{
							lblUnitCode.Text = "NG";
							lblUnitCode.ForeColor = Color.Red;
							txtUnitcode.SelectAll();
							txtUnitcode.Focus();
						}
					}
					
                }
                else
                {
                    lblUnitCode.Text = "NG";
                    lblUnitCode.ForeColor = Color.Red;
                    txtUnitcode.Focus() ;
                }
                */
			}
        }

		private void btnRepair_Click(object sender, EventArgs e)
		{
			Program.getLine = cbLine.Text;
			Program.getLot = cbLot.Text;
			Program.getProcessId = long.Parse(cbProcessName.SelectedValue.ToString());
			var frmRepair = new frmRepairIssueByLine();
			frmRepair.ShowDialog();
			return;
		}
	}
}
