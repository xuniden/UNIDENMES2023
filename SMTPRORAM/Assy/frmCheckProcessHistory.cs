using DocumentFormat.OpenXml.Office2010.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Management;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UnidenDAL;
using UnidenDAL.Assy;
using UnidenDAL.Assy.Setup;
using UnidenDAL.Jig;
using UnidenDAL.Jig.JIG;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Staging;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;

namespace SMTPRORAM.Assy
{
    public partial class frmCheckProcessHistory : Form
    {
        private bool flagInsert=false;
        private bool flagSmt=false;
        private string[] ArrEQC;
        private string[] ArrJIG;
        private string[] ArrOSG;
        private string[] ArrMTE;
        private int Index = 0;
        private int IndexEQC = 0;
        private int IndexJIG = 0;
        private int IndexOSG = 0;
        private int IndexMTE = 0;
        public frmCheckProcessHistory()
        {
            InitializeComponent();
        }
        private void resetLabel()
        {
            lblLine.Text = string.Empty;
            lblLot.Text = string.Empty;
            lblOperator.Text = string.Empty;
            lblEq.Text = string.Empty;
            lblJIG.Text = string.Empty;
            lblOSG.Text = string.Empty;
            lblProcess.Text = string.Empty;
            lblMetarial.Text = string.Empty;
            lblQRCode.Text = string.Empty;
            pictureBoxNG.Visible=false;
            pictureBoxOK.Visible=false;
        }
        private void SetDefaultRun()
        {
            cbLot.Enabled = false;
            cbProcessName.Enabled = false;
            txtEmployeeID.Enabled = false;
            checkEQ.Checked = true;
            checkJIG.Checked = true;
            checkOSG.Checked = true;
            checkMTE.Checked = true;
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
        private void frmCheckProcessHistory_Load(object sender, EventArgs e)
        {
            resetLabel();
            SetDefaultRun();
            loadLineName();
            cbLine.Focus();
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
				//txtEmployeeID.Focus();
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
					checkEQ.Checked = false;
					numEQ.Focus();
					numEQ.Select();
					SendKeys.Send("{Tab}");
				}
                else
                {
                    txtEmployeeID.Focus();
                    txtEmployeeID.SelectAll();
                }
                //if (!txtEmployeeID.Text.Trim().Equals(""))
                //{
                //    lblOperator.Text = "OK";
                //    lblOperator.ForeColor = Color.Green;
                //    checkEQ.Checked = false;
                //    numEQ.Focus();
                //    numEQ.Select();
                //    SendKeys.Send("{Tab}");
                //}
                //else
                //{
                //    lblOperator.Text = "NG";
                //    txtEmployeeID.Focus();
                //    lblOperator.ForeColor = Color.Red;
                //}
            }
        }

        private void iconbtnReset03_Click(object sender, EventArgs e)
        {
            // Làm lại khi bắn sai công nhân
            lblOperator.Text = string.Empty;
            txtEmployeeID.Text = string.Empty;
            txtEmployeeID.Focus();
        }

        private void checkEQ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEQ.Checked)
            {
                numEQ.Value = 0;
                numEQ.Enabled = false;
                txtEqName.Text = string.Empty;
                txtEqName.Enabled = false;
            }
            else
            {
                numEQ.Enabled = true;
                txtEqName.Enabled = false;
            }
        }

        private void checkJIG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkJIG.Checked)
            {
                numJIG.Value = 0;
                numJIG.Enabled = false;
                txtJig.Text = string.Empty;
                txtJig.Enabled = false;
            }
            else
            {
                numJIG.Enabled = true;
                txtJig.Enabled = false;
            }
        }

        private void checkOSG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOSG.Checked)
            {
                numOSG.Enabled = false;
                numEQ.Value = 0;
                txtOsg.Enabled = false;
                txtOsg.Text = string.Empty;
            }
            else
            {
                numOSG.Enabled = true;
                txtOsg.Enabled = false;
            }
        }

        private void checkMTE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMTE.Checked)
            {
                numMetarial.Value = 0;
                numMetarial.Enabled = false;
                txtMaterial.Text = string.Empty;
                txtMaterial.Enabled = false;
            }
            else
            {
                numMetarial.Enabled = true;
                txtMaterial.Enabled = false;
            }
        }

        private void numEQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Index = 0;
                if ((int)numEQ.Value != 0)
                {
                    IndexEQC = (int)numEQ.Value;
					ArrEQC = new string[IndexEQC];
                    // numEQ.ReadOnly = true; 
                    txtEqName.Enabled = true;
                    txtEqName.ReadOnly = false;
                    txtEqName.Focus();
                }
                else
                {
                    txtEqName.Enabled = false;
                }
            }
        }

        private void txtEqName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // int spt = (int)numEQ.Value;
                int spt = IndexEQC;
				string inputString = txtEqName.Text.Trim();
                char[] separator = { ';' };
                string[] result = inputString.Split(separator);
                string value = result[0];
                if (LINEPROCESSHISTORY_DAL.Instance.checkDataAsTable("JIG_CALDEVICES", "ControlNo", value))
                {
                    bool check = false;
                    check = CheckDoubleInput(ArrEQC, value);
                    if (check)
                    {
                        txtEqName.Text = "";
                        if (Index == spt)
                        {
                            lblEq.Text = "OK";
                            lblEq.ForeColor = Color.Green;
                            txtEqName.Text = "Check : (" + spt + " / " + spt + " ) OK.";
                            txtEqName.ReadOnly = true;
                            if (checkJIG.Checked==false&&(int)numJIG.Value>0)
                            {
                                Index = 0;
                                txtJig.Focus();
                            }
                            else if (checkOSG.Checked==false&&(int)numOSG.Value>0)
                            {
								Index = 0;
								txtOsg.Focus();
                            }
                            else if (checkMTE.Checked==false&&(int)numMetarial.Value>0)
                            {
								Index = 0;
								txtMaterial.Focus();
                            }
                            else
                            {
								Index = 0;
								SendKeys.Send("{Tab}");
							}
                            
                        }
                        else
                        {
                            txtEqName.Text = "Check : (" + Index + " / " + spt + " ) OK.";
                            txtEqName.SelectAll();
                        }
                    }
                    else
                    {
                        lblEq.Text = "NG";
                        lblEq.ForeColor = Color.Red;
                        txtEqName.Text = "Trùng giá trị";
                        txtEqName.Focus();
                        txtEqName.SelectAll();
                    }

                }
                else
                {
                    lblEq.Text = "NG";
                    lblEq.ForeColor = Color.Red;
                    txtEqName.Text = "Không tồn tại";
                    txtEqName.Focus();
                    txtEqName.SelectAll();
                    return;
                }
            }
        }

        private void iconbtnReset04_Click(object sender, EventArgs e)
        {
            checkEQ.Checked = false;
            numEQ.Value = 0;
            IndexEQC = 0;
            txtEqName.Enabled = false;
            txtEqName.ReadOnly=false;
            txtEqName.Text = string.Empty;
            ArrEQC = new string[] { };
            numEQ.Focus();
        }

        private void numJIG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Index = 0;
                if ((int)numJIG.Value != 0)
                {
                    IndexJIG = (int)numJIG.Value;
					ArrJIG = new string[IndexJIG];
                    //numJIG.ReadOnly = true;
                    txtJig.Enabled = true;
                    txtJig.Focus();
                }
                else
                {
                    txtJig.Enabled = false;
                }
            }
        }

        private void txtJig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //int spt = (int)numJIG.Value;
                int spt = IndexJIG;
				string inputString = txtJig.Text.Trim();
                char[] separator = { ';' };
                string[] result = inputString.Split(separator);
                string value = result[0];
                if (LINEPROCESSHISTORY_DAL.Instance.checkDataAsTable("JIGH_CALDEVICES", "ControlNo", value))
                {
                    bool check = false;
                    check = CheckDoubleInput(ArrJIG, value);
                    if (check)
                    {
                        txtJig.Text = "";
                        if (Index == spt)
                        {
                            lblJIG.Text = "OK";
                            lblJIG.ForeColor = Color.Green;
                            txtJig.Text = "Check : (" + spt + " / " + spt + " ) OK.";
                            txtJig.ReadOnly = true;


						    if (checkOSG.Checked==false && (int)numOSG.Value > 0)
							{
								Index = 0;
								txtOsg.Focus();
							}
							else if (checkMTE.Checked==false && (int)numMetarial.Value > 0)
							{
								Index = 0;
								txtMaterial.Focus();
							}
							else
							{
								Index = 0;
								SendKeys.Send("{Tab}");
							}
						}
                        else
                        {
                            txtJig.Text = "Đã nhập lần: " + Index + "Tổng số: " + spt;
                            txtJig.SelectAll();
                        }
                    }
                    else
                    {
                        lblJIG.Text = "NG";
                        lblJIG.ForeColor = Color.Red;
                        txtJig.Text = "Trùng giá trị";
                        txtJig.Focus();
                        txtJig.SelectAll();
                    }

                }
                else
                {
                    lblJIG.Text = "NG";
                    lblJIG.ForeColor = Color.Red;
                    txtJig.Text = "Không tồn tại";
                    txtJig.Focus();
                    txtJig.SelectAll();
                    return;
                }
            }
        }

        private void iconbtnReset05_Click(object sender, EventArgs e)
        {
            checkJIG.Checked = false;
            numJIG.Value = 0;
            IndexJIG = 0;
            txtJig.Enabled = false;
            txtJig.Text = string.Empty;
            ArrJIG = new string[] { };
            numJIG.Focus();
        }

        private void numOSG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Index = 0;
                if ((int)numOSG.Value != 0)
                {
                    IndexOSG = (int)numOSG.Value;
					ArrOSG = new string[IndexOSG];
                    txtOsg.Enabled = true;
                    txtOsg.Focus();
                    //numOSG.ReadOnly = true;
                }
                else
                {
                    txtOsg.Enabled = false;
                }
            }
        }

        private void txtOsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool checkk = true;
                //int spt = (int)numOSG.Value;
                int spt = IndexOSG;

				string inputString = txtOsg.Text.Trim();
                char[] separator = { ';' };
                string[] result = inputString.Split(separator);
                string value = result[0];
                if (checkk)
                {
                    bool check = false;
                    check = CheckDoubleInput(ArrOSG, value);
                    if (check)
                    {
                        txtOsg.Text = "";
                        if (Index == spt)
                        {
                            lblOSG.Text = "OK";
                            lblOSG.ForeColor = Color.Green;
                            txtOsg.Text = "Check : (" + spt + " / " + spt + " ) OK.";
                            txtOsg.ReadOnly = true;
							if (checkMTE.Checked==false && (int)numMetarial.Value > 0)
							{
								Index = 0;
								txtMaterial.Focus();
							}
							else
							{
								Index = 0;
								SendKeys.Send("{Tab}");
							}
							
                        }
                        else
                        {
                            txtOsg.Text = "Đã nhập lần: " + Index + "Tổng số: " + spt;
                            txtOsg.SelectAll();
                        }
                    }
                    else
                    {
                        lblOSG.Text = "NG";
                        lblOSG.ForeColor = Color.Red;
                        txtOsg.Text = "Trùng giá trị";
                        txtOsg.Focus();
                        txtOsg.SelectAll();
                    }

                }
                else
                {
                    lblOSG.Text = "NG";
                    lblOSG.ForeColor = Color.Red;
                    txtOsg.Text = "Không tồn tại";
                    txtOsg.Focus();
                    txtOsg.SelectAll();
                    return;
                }
            }
        }

        private void iconbtnReset06_Click(object sender, EventArgs e)
        {
            checkOSG.Checked = false;
            numOSG.Value = 0;
            IndexOSG = 0;
            txtOsg.Enabled = false;
            txtOsg.Text = string.Empty;
            ArrOSG = new string[] { };
            numOSG.Focus();
        }

        private void numMetarial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Index = 0;
                if ((int)numMetarial.Value != 0)
                {
                    IndexMTE = (int)numMetarial.Value;
					ArrMTE = new string[IndexMTE];
                    txtMaterial.Enabled = true;
                    txtMaterial.Focus();
                    //numMetarial.ReadOnly = true;
                }
                else
                {
                    txtMaterial.Enabled = false;
                }
            }
        }

        private void txtMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool checkk = true;
                //int spt = (int)numMetarial.Value;
                int spt = IndexMTE;
				string inputString = txtMaterial.Text.Trim();
                char[] separator = { ';' };
                string[] result = inputString.Split(separator);
                string value = result[0];
                //if (LINEPROCESSNONHISTORY_DAL.Instance.checkDataAsTable("JIGH_CALDEVICES", "ControlNo", value))
                if (checkk)
                {
                    bool check = false;
                    check = CheckDoubleInput(ArrOSG, value);
                    if (check)
                    {
                        txtMaterial.Text = "";
                        if (Index == spt)
                        {
                            lblMetarial.Text = "OK";
                            lblMetarial.ForeColor = Color.Green;
                            txtMaterial.Text = "Check : (" + spt + " / " + spt + " ) OK.";
                            txtMaterial.ReadOnly = true;
							Index = 0;
							txtQRCode.Focus();
                        }
                        else
                        {
                            txtMaterial.Text = "Đã nhập lần: " + Index + "Tổng số: " + spt;
                            txtMaterial.SelectAll();
                        }
                    }
                    else
                    {
                        lblMetarial.Text = "NG";
                        lblMetarial.ForeColor = Color.Red;
                        txtMaterial.Text = "Trùng giá trị";
                        txtMaterial.Focus();
                        txtMaterial.SelectAll();
                    }

                }
                else
                {
                    lblMetarial.Text = "NG";
                    lblMetarial.ForeColor = Color.Red;
                    txtMaterial.Text = "Không tồn tại";
                    txtMaterial.Focus();
                    txtMaterial.SelectAll();
                    return;
                }
            }
        }

        private void iconbtnReset07_Click(object sender, EventArgs e)
        {
            checkMTE.Checked = false;
            numMetarial.Value = 0;
            IndexMTE = 0;
            txtMaterial.Enabled = false;
            txtMaterial.Text = string.Empty;
            ArrMTE = new string[] { };
            numMetarial.Focus();
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
            if (cbLot.Text.Equals("--Select--"))
            {
                MessageBox.Show("Phải nhập LOT sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLot.Focus();
                return false;
            }
            if (cbProcessName.Text.Equals("") || cbProcessName.Text.Equals("--Select--"))
            {
                MessageBox.Show("Phải chọn công đoạn sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbProcessName.Focus();
                return false;
            }
            if (txtEmployeeID.Text.Equals(""))
            {
                MessageBox.Show("ID của công nhân thực hiện công đoạn không để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmployeeID.Focus();
                return false;
            }
            if (txtEqName.Text.Equals("") &&
                txtJig.Text.Equals("") &&
                txtOsg.Text.Equals("") &&
                txtMaterial.Text.Equals(""))
            {
                MessageBox.Show("Phải nhập ít nhất một giá trị trong Thiết bị hoặc JIg hoặc OSG hoặc Vật Liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                history.GroupProcess = processInfo.GroupProcess;
                history.LineName=cbLine.Text;
                history.OperatorID = txtEmployeeID.Text.Trim();
                history.CreatedBy = Program.UserId;
                history.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                history.QrCode00 = txtQRCode.Text.Trim();
                if ((int)numEQ.Value > 0)
                {
                    for (int i = 0; i < ArrEQC.Length && i < 10; i++)
                    {
                        string eqControlValue = ArrEQC[i];
                        // retrieve the info from other table based on Eqcontrol value
                        var calDevice = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(eqControlValue);
                        if (calDevice != null)
                        {
                            string EqName = calDevice.EqName;
                            DateTime? CalDate = calDevice.CalDate;
                            history.GetType().GetProperty($"EqControl{i + 1:00}")?.SetValue(history, eqControlValue);
                            history.GetType().GetProperty($"EqControlName{i + 1:00}")?.SetValue(history, EqName);
                            history.GetType().GetProperty($"EqCalDate{i + 1:00}")?.SetValue(history, CalDate);
                        }
                        else
                        {
                            history.GetType().GetProperty($"EqControl{i + 1:00}")?.SetValue(history, eqControlValue);
                        }
                    }
                }
                if ((int)numJIG.Value > 0)
                {
                    for (int i = 0; i < ArrJIG.Length && i < 10; i++)
                    {
                        string eqControlValue = ArrJIG[i];
                        var calDevice = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(eqControlValue);
                        if (calDevice != null)
                        {
                            string EqName = calDevice.EqName;
                            DateTime? CalDate = calDevice.MakeDate;

                            history.GetType().GetProperty($"JigControl{i + 1:00}")?.SetValue(history, eqControlValue);
                            history.GetType().GetProperty($"JigName{i + 1:00}")?.SetValue(history, EqName);
                            history.GetType().GetProperty($"JigCreate{i + 1:00}")?.SetValue(history, CalDate);
                        }
                        else
                        {
                            history.GetType().GetProperty($"JigControl{i + 1:00}")?.SetValue(history, eqControlValue);
                        }
                    }
                }
                if ((int)numOSG.Value > 0)
                {
                    for (int i = 0; i < ArrOSG.Length && i < 10; i++)
                    {
                        if (!string.IsNullOrEmpty(ArrOSG[i]))
                        {
                            history.GetType().GetProperty($"OSG{i + 1:00}")?.SetValue(history, ArrOSG[i]);
                        }
                    }
                }
                if ((int)numMetarial.Value > 0)
                {
                    for (int i = 0; i < ArrMTE.Length && i < 10; i++)
                    {
                        if (!string.IsNullOrEmpty(ArrMTE[i]))
                        {
                            history.GetType().GetProperty($"Material{i + 1:00}")?.SetValue(history, ArrMTE[i]);
                        }
                    }
                }

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
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESSHISTORY_DAL.Instance.getListProcessByUser(Program.UserId));                    
                    pictureBoxOK.Visible = true;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                    pictureBoxOK.Visible = false;
                    AfterSave();
                }
            }
        }
        private void AfterSave()
        {
            cbLine.Enabled = false;
            cbLot.Enabled = false;
            cbProcessName.Enabled = false;
            txtEmployeeID.Enabled = false;
            numEQ.Enabled = false;
            numJIG.Enabled = false;
            numOSG.Enabled = false;
            numMetarial.Enabled = false;

            txtQRCode.Text = "";
            txtQRCode.Focus();
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
                    var checkQR = new UV_LINEPROCESS_HISTORY();
                    checkQR= LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtQRCode.Text.Trim(),cbLot.Text,long.Parse(cbProcessName.SelectedValue.ToString()));
                    if (checkQR!=null)
                    {
                        MessageBox.Show("Công đoạn này đã được nhập vào csdl bởi: " + checkQR.CreatedBy + "\n"
                            + "Ngày: " + checkQR.CreatedDate + "\n","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtQRCode.Focus();
                        txtQRCode.SelectAll();
                        return;
                    }
                    // Kiểm tra xem đã qua công đoạn trước đó chưa hay nó là công đoạn đầu tiên.
                    long currentProcess = long.Parse(cbProcessName.SelectedValue.ToString());
					// Lấy group process theo current process ( UV_LINEPROCESS)
					string groupProcess = LINEPROCESS_DAL.Instance.getProcessDetail(currentProcess).GroupProcess;

					//var processList = LINEPROCESS_DAL.Instance.getProcessList(cbLot.Text);
					var processList = LINEPROCESS_DAL.Instance.getProcessListByGroup(cbLot.Text,groupProcess);
					string checkMessage = checkProcess(processList, txtQRCode.Text.Trim(), currentProcess);
                    if (checkMessage == "0" ||
						checkMessage == "1" ||
						checkMessage == "2")
                    {
                        // Là công đoạn đầu tiên
                        // MessageBox.Show("Đây là công đoạn đầu tiên");
                        SaveData();
                        //txtQRCode.Focus();
                        //txtQRCode.SelectAll();

                    }
                    //else if (checkMessage == "1")
                    //{
                    //    // Là công đoạn cuối cùng
                    //    //MessageBox.Show("Đây là công đoạn cuối cùng");
                    //    SaveData();
                    //    //txtQRCode.Focus();
                    //    //txtQRCode.SelectAll();
                    //}
                    //else if (checkMessage == "2")
                    //{
                    //    // Đã qua công đoạn trước đó
                    //    //MessageBox.Show("Đã qua công đoạn trước đó");
                    //    SaveData();
                    //    //txtQRCode.Focus();
                    //    //txtQRCode.SelectAll();
                    //}
                    else
                    {
                        // Chua qua công đoạn trước đó
                        MessageBox.Show(checkMessage,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtQRCode.Focus();
                        txtQRCode.SelectAll();
                        
                    }
                }
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
