using EzioDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Assy;
using UnidenDAL.Assy.Setup;
using UnidenDAL.Jig;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Staging;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;

namespace SMTPRORAM.Assy
{
    public partial class frmCombineQRCode : Form
    {
        public static string lot { get;private set; }
        public static string line { get;private set; }
        public static long processId { get; private set; } = 0;
        private bool flagInsert = false;
        GodexPrinter Printer = new GodexPrinter();
        private string[] ArrQRC;
        private int Index = 0;
        public frmCombineQRCode()
        {
            InitializeComponent();
        }
        private void ClearLabel()
        {
            lblLine.Text = string.Empty;
            lblLot.Text = string.Empty;
            lblProcess.Text = string.Empty;
            lblOperator .Text = string.Empty;
            lblQRCode.Text = string.Empty;
            pictureBoxNG.Visible = false;
            pictureBoxOK.Visible    = false;
        }
        private void FindPrinter_USB()
        {
            Cbo_USB.Items.Clear();
            List<string> PrinterList = GodexPrinter.GetPrinter_USB();
            for (int i = 0; i < PrinterList.Count; i++)
                Cbo_USB.Items.Add(PrinterList[i]);
            if (Cbo_USB.Items.Count > 0)
                Cbo_USB.SelectedIndex = 0;

            string[] ComPrinter = SerialPort.GetPortNames();
            if (ComPrinter != null)
            {
                Cbo_COM.Items.Clear();
                for (int i = 0; i < ComPrinter.Length; i++)
                    Cbo_COM.Items.Add(ComPrinter[i]);
                if (Cbo_COM.Items.Count > 0)
                    Cbo_COM.SelectedIndex = 0;
            }
        }
        private void ConnectPrinter()
        {
            if (RBtn_USB.Checked == true)
            {
                if (Cbo_USB.SelectedIndex > -1)
                    Printer.OpenUSB(Cbo_USB.SelectedItem.ToString());
                else
                    Printer.Open(PortType.USB);
            }
            else if (RBtn_COM.Checked == true)
            {
                if (Cbo_COM.SelectedItem != null)
                {
                    Printer.Open(Cbo_COM.SelectedItem.ToString());
                    Printer.SetBaudrate(int.Parse(Txt_Baud.Text));
                }
            }
        }
        private void frmCombineQRCode_Load(object sender, EventArgs e)
        {
            lblUserTotal.Text = "";
            lblTotal.Text = "";
            try
            {
                FindPrinter_USB();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Không tìm thấy máy in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearLabel();
            loadLineName();
            cbLine.Focus();
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
        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            // bắn QR code của công nhân
            if (Keys.Enter == e.KeyCode)
            {
                if (!txtEmployeeID.Text.Trim().Equals(""))
                {
                    lblOperator.Text = "OK";
                    lblOperator.ForeColor = Color.Green;
                    numQR.Focus();
                }
                else
                {
                    lblOperator.Text = "NG";
                    txtEmployeeID.Focus();
                    lblOperator.ForeColor = Color.Red;
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


        private bool CheckDoubleInput(string[] arr, string value)
        {
            bool check = false;
            if (Array.Exists(arr, element => element == value))
            {
                //MessageBox.Show("Nhập trùng giá trị !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                check = false;
            }
            else
            {
                arr[Index] = value;
                Index++;
                check = true;
            }
            return check;
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
            if ((int)numQR.Value<=0)
            {
                MessageBox.Show("Số lần nhập QR Code phải lơn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numQR.Focus();
                return false;
            }
            if (txtEmployeeID.Text.Equals(""))
            {
                MessageBox.Show("ID của công nhân thực hiện công đoạn không để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return false;
            }
            if ( txtQRCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Phải có ít nhất một số QRCode để combine thành Barcode ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                txtQRCode.Focus();
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

                if ((int)numQR.Value > 0)
                {
                    for (int i = 0; i < ArrQRC.Length && i < 10; i++)
                    {

                        if (!string.IsNullOrEmpty(ArrQRC[i]))
                        {
                            string eqControlValue = ArrQRC[i];
                            history.GetType().GetProperty($"QrCode{i + 1:00}")?.SetValue(history, eqControlValue);                            
                        }
                    }
                }
                // Tìm giá trị lớn nhất của AutoNumber là số tiếp theo được lưu vào
                // Auto number sẽ là 1 chuỗi gồm: yymmddxxxxx (23042200001)
                var dt = new DataTable();
                dt = LINEPROCESSHISTORY_DAL.Instance.getNewAutoID();
                history.QrCode00 = dt.Rows[0]["MyColumn"].ToString();

                string message = "";
                message = LINEPROCESSHISTORY_DAL.Instance.Add(history);

                if (message != "")
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pictureBoxNG.Visible = true;
                    Application.DoEvents();
					ArrQRC = new string[(int)numQR.Value];
					System.Threading.Thread.Sleep(300);
                    pictureBoxNG.Visible = false;
                    txtQRCode.SelectAll();
                    txtQRCode.Focus();
                    return;
                }
                else
                {
                    PrintLabel(history.QrCode00);
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESSHISTORY_DAL.Instance.getListProcessByUser(Program.UserId));
                    lblUserTotal.Text = LINEPROCESSHISTORY_DAL.Instance.getTotalByUsser(cbLot.Text.Trim(), txtEmployeeID.Text.Trim()).ToString();
                    lblTotal.Text = LINEPROCESSHISTORY_DAL.Instance.getTotalByLot(cbLot.Text.Trim()).ToString();
					pictureBoxOK.Visible = true;
					ArrQRC = new string[(int)numQR.Value];
					Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                    pictureBoxOK.Visible = false;
                    AfterSave();
                }
            }
        }
        private void PrintLabel(string barcode)
        {
            CommonDAL.Instance.ConnectPrinter(RBtn_USB, Cbo_USB);
            Printer.Open(PortType.USB);
			string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q10,3\r\n^W37\r\n^H11\r\n^P1\r\n^S4\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nBQ,33,15,2,6,28,0,3,";
			//string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H8\r\n^P1\r\n^S4\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nBA3,19,25,2,5,64,0,7,";
            string csString4 = "\r\nE\r\n";
            string csString = csString0 + barcode + csString4;
            Printer.Command.Send(csString);          
            Printer.Close();
        }
        private void numQR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Index = 0;
                if ((int)numQR.Value != 0)
                {
                    ArrQRC = new string[(int)numQR.Value];
                    // numEQ.ReadOnly = true; 
                    txtQRCode.Enabled = true;
                    txtQRCode.ReadOnly = false;
                    txtQRCode.Focus();
                }
                else
                {
                    txtQRCode.Enabled = false;
                }
            }
        }
        private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {                
                // Kiểm tra xem QR này có trong CSDL QR đã tạo không?
                var checkExitsQR = SmtGeneralQrCodeDAL.Instance.checkExistQRCode(txtQRCode.Text.Trim());
                if (checkExitsQR == null)
                {
                    MessageBox.Show("QR Code này chưa được tạo !!!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQRCode.Focus();
                    txtQRCode.SelectAll();
                    return;
                }
                else
                {
                    // Kiểm tra xem QR này đã được bắn tại SMT hay Insert chưa
                    bool checkSMT = false;
                    bool checkINSERT = false;
                    checkSMT = LINEPROCESSHISTORY_DAL.Instance.checkSMTvsINSERTQRCodeScanned(txtQRCode.Text.Trim(), "SMT");
                    checkINSERT = LINEPROCESSHISTORY_DAL.Instance.checkSMTvsINSERTQRCodeScanned(txtQRCode.Text.Trim(), "INSERT");
                    if (!checkSMT)
                    {
                        MessageBox.Show("PCB này chưa được scan tại SMT ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQRCode.Focus();
                        txtQRCode.SelectAll();
                        return;
                    }
                    // Nếu không cần qua InSER thì chỉ cần xác nhận 1 lần
                    if (flagInsert == false)
                    {
                        if (!checkINSERT)
                        {
                            DialogResult result = MessageBox.Show("Mạch loại này không cần qua INSERT ??? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (result == DialogResult.Yes)
                            {
                                flagInsert = true;
                                goto RunTo;
                            }
                            else
                            {
                                txtQRCode.Focus();
                                txtQRCode.SelectAll();
                                return;
                            }
                        }
                    }
                RunTo:
                    // Kiểm tra xem đã được bắn lần nào ở công đoạn này chưa?
                    // ( sử dụng tên lot / processid/ qrcode để kiểm tra)

                    // Xảy ra trường hợp.
                    // + Mã QR này đã được combine với 1 số barcode khác --> Hiển thị được số barcode
                    //  - Giải quyết trường hợp này thì phải tìm tất cả số barcode rồi xóa toàn bộ dữ liệu và bắn lại
                    // 


                    var checkQR = new UV_LINEPROCESS_HISTORY();
                    checkQR = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode01(txtQRCode.Text.Trim(), cbLot.Text, long.Parse(cbProcessName.SelectedValue.ToString()));
                    if (checkQR != null)
                    {
                        MessageBox.Show("Công đoạn này đã được nhập vào csdl bởi: " + checkQR.CreatedBy + "\n"
                            + "Ngày: " + checkQR.CreatedDate + "\n"
                            + "Barcode: " + checkQR.QrCode00 + "\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQRCode.Focus();
                        txtQRCode.SelectAll();
                        return;
                    }
                    // Kiểm tra xem QR này đã được combine với mã barcode nào chưa?
                    // Lấy select mã QR với 10 só QR trong csdl nếu trả lại giá trị thì đã combine rồi.
                    var dt= new DataTable();
                    dt= LINEPROCESSHISTORY_DAL.Instance.checkQRUniqueCombine(txtQRCode.Text.Trim());
                    if (dt.Rows.Count>0)
                    {
						MessageBox.Show("Mã QR này đã được combine với Barcode: " + dt.Rows[0]["CreatedBy"].ToString() + "\n"
						   + "Ngày: " + dt.Rows[0]["CreatedDate"].ToString() + "\n"
                           + "Barcode: " + dt.Rows[0]["QrCode00"].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtQRCode.Focus();
						txtQRCode.SelectAll();
						return;
					}

                    // Kiểm tra xem đã qua công đoạn trước đó chưa hay nó là công đoạn đầu tiên.
                    long currentProcess = long.Parse(cbProcessName.SelectedValue.ToString());

					// Lấy group process theo current process ( UV_LINEPROCESS)
					string groupProcess = LINEPROCESS_DAL.Instance.getProcessDetail(currentProcess).GroupProcess;

					 var processList = LINEPROCESS_DAL.Instance.getProcessListByGroup(cbLot.Text, groupProcess);
					//var processList = LINEPROCESS_DAL.Instance.getProcessList(cbLot.Text);
                    string checkMessage = checkProcess(processList, txtQRCode.Text.Trim(), currentProcess);

                    if (checkMessage == "0" ||
						checkMessage == "1" ||
						checkMessage == "2")
                    {
                        // Là công đoạn đầu tiên
                        // MessageBox.Show("Đây là công đoạn đầu tiên");
                        // Kiểm tra xem có trùng nhau hay không?
                        CheckBeforeSave();
                    }
                    //else if (checkMessage == "1")
                    //{
                    //    // Là công đoạn cuối cùng
                    //    //MessageBox.Show("Đây là công đoạn cuối cùng");
                    //    CheckBeforeSave();
                    //    //txtQRCode.Focus();
                    //    //txtQRCode.SelectAll();
                    //}
                    //else if (checkMessage == "2")
                    //{
                    //    // Đã qua công đoạn trước đó
                    //    //MessageBox.Show("Đã qua công đoạn trước đó");
                    //    CheckBeforeSave();
                    //    //txtQRCode.Focus();
                    //    //txtQRCode.SelectAll();
                    //}
                    else
                    {
                        // Chua qua công đoạn trước đó
                        MessageBox.Show(checkMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQRCode.Focus();
                        txtQRCode.SelectAll();

                    }
                }
            }
        }
        private void CheckBeforeSave()
        {
            int spt = (int)numQR.Value;
            bool check = false;

			



			check = CheckDoubleInput(ArrQRC, txtQRCode.Text.Trim());
            if (check)
            {
                txtQRCode.Text = "";
                if (Index == spt)
                {
                    lblQRCode.Text = "OK";
                    lblQRCode.ForeColor = Color.Green;
                    txtQRCode.Text = "Check : (" + spt + " / " + spt + " ) OK.";
                    txtQRCode.ReadOnly = true;
                    SaveData();
                    //SendKeys.Send("{Tab}");
                }
                else
                {
                    txtQRCode.Text = "Check : (" + Index + " / " + spt + " ) OK.";
                    txtQRCode.SelectAll();
                }
            }
            else
            {
                lblQRCode.Text = "NG";
                lblQRCode.ForeColor = Color.Red;
                txtQRCode.Text = "Trùng giá trị";
                txtQRCode.Focus();
                txtQRCode.SelectAll();
            }
        }
        private void AfterSave()
        {
            cbLine.Enabled = false;
            cbLot.Enabled = false;
            cbProcessName.Enabled = false;
            txtEmployeeID.Enabled = false;
            numQR.Enabled = false;
            ArrQRC= new string[(int)numQR.Value];
            Index = 0;
            txtQRCode.ReadOnly = false;
            txtQRCode.Text = "";
            txtQRCode.Focus ();
        }

		private void btnDeleteBarcode_Click(object sender, EventArgs e)
		{
            lot = cbLot.Text;
            processId=long.Parse(cbProcessName.SelectedValue.ToString());
            line=cbLine.Text;
            var frmDelete = new frmDeleteByBarcode();            
            frmDelete.ShowDialog();
			CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESSHISTORY_DAL.Instance.getListProcessByUser(Program.UserId));
			return;
        }

		private void btnRepair_Click(object sender, EventArgs e)
		{
            if (cbProcessName.Text.Trim().Equals("") || string.IsNullOrEmpty(cbProcessName.SelectedValue?.ToString()))
            {

            }
            else {
				Program.getLine = cbLine.Text;
				Program.getLot = cbLot.Text;
				Program.getProcessId = long.Parse(cbProcessName.SelectedValue.ToString());
				var frmRepair = new frmRepairIssueByLine();
				frmRepair.ShowDialog();
				return;
			}
			
		}

		
	}
}
