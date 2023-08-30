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
using UnidenDAL.Jig.JIG;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.Jig.JIG
{
    public partial class frmINOUTJIG : Form
    {
        private bool flagCheck = false;
        private string InOutFlag = "";
        private bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        private long Id = 0;
        private string controNo = "";
        public frmINOUTJIG()
        {
            InitializeComponent();
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
        }

        void ResetControll()
        {
            txtControlNo.Text = "";
            cbFromLoc.Text = "[None]";
            cbFromSec.Text = "[None]";
            cbFixLocation.Text = "[None]";
			txtPIC.Text = "";
            txtApprove.Text = "";
            txtRemark.Text = "";
            cbToLoc.Text = "[None]";
            cbToSec.Text = "[None]";
        }
        void ResetControll2()
        {
            txtControlNo.Text = "";
            cbFromLoc.Text = "[None]";
            cbFromSec.Text = "[None]";
            cbFixLocation.Text = "[None]";
			txtRemark.Text = "";
            cbToLoc.Text = "[None]";
            cbToSec.Text = "[None]";
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
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

            cbFixLocation.DataSource = lstLoc.OrderBy(p => p.LocName).ToList() ;
            cbFixLocation.DisplayMember= "LocName";
            cbFixLocation.ValueMember = "LocName";

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
        private void showInOutByUserId()
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, JIGHINOUT_DAL.Instance.getListJigInOutDaily(Program.UserId));
        }
        private void frmINOUTJIG_Load(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            txtControlNo.Focus();
            showInOutByUserId();
            //LoadCombobox();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
            LoadCombobox();
            if (frmViewAllJIG.sendControlNo != null &&frmViewAllJIG.sendControlNo!="")
            {                
                txtControlNo.Text = frmViewAllJIG.sendControlNo;
                SendKeys.Send("{ENTER}");
            }
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
				var calDevices = new JIGH_CALDEVICES();
				var calDevices2Status = new JIGH_CALDEVICES();
				calDevices = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(result[0].ToString());
                
				
				// Kiểm tra tình tạng thiết bị có và không phải NG thì cho xuất

				var lastOut = new JIGH_INOUT();
				lastOut = JIGHINOUT_DAL.Instance.getLastOutJig(calDevices.ControlNo);
				var jigFixlocation = new JIGH_CALDEVICES();
				jigFixlocation = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(calDevices.ControlNo);
				if (calDevices != null && !calDevices.SStatus.Contains("NG"))
				{
					if (calDevices.Real == true) // Vẫn trong phòng JIG
					{
						//InOutFlag = "OUT";
						cbFromSec.Text = calDevices.JigSecCode;
						cbFromLoc.Text = calDevices.LocName;
						cbFixLocation.Text = calDevices.FixLocation;
						txtPIC.Focus();
					}
					else // Đã xuất ra sản xuất rồi --> Ngầm hiểu là trả lại phòng JIG
					{
						if (lastOut == null)
						{
							MessageBox.Show("Đã có sự nhầm lẫn trong quá trình thêm dữ liệu", "Thông báo",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
						else
						{
                            //InOutFlag = "IN";		
                            //
                            string nLoc = "";
							cbFromSec.Text = lastOut.ToSecCode;
                            nLoc= lastOut.ToLocCode;
                            cbFromLoc.Text =nLoc ; //calDevices.LocName;
                            cbFromLoc.SelectedValue=nLoc ; 
                            cbFromLoc.Text=nLoc ;

							cbFixLocation.Text = jigFixlocation.FixLocation;
							cbToSec.Text = calDevices.JigSecCode;

							cbToLoc.Text = calDevices.LocName;
							txtPIC.Focus();
						}

					}
				}
				else
				{
					MessageBox.Show("Mã này không có trong csdl  hoặc tình trạng JIG đang là NG !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtControlNo.Focus();
					txtControlNo.SelectAll();
					return false;
				}
			}
            return true;
		}

        private void txtControlNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                    var calDevices = new JIGH_CALDEVICES();
                    calDevices = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(result[0].ToString());
                    if (calDevices != null)
                    {    
                        if (calDevices.Real == true) // Vẫn trong phòng JIG
                        {
                            //InOutFlag = "OUT";
                            cbFromSec.Text = calDevices.JigSecCode;
                            cbFromLoc.Text = calDevices.LocName;
                            cbFixLocation.Text = calDevices.FixLocation;
                            txtPIC.Focus();
                        }
                        else // Đã xuất ra sản xuất rồi --> Ngầm hiểu là trả lại phòng JIG
                        {
                            var lastOut = new JIGH_INOUT();
                            lastOut = JIGHINOUT_DAL.Instance.getLastOutJig(calDevices.ControlNo);
                            var jigFixlocation = new JIGH_CALDEVICES();
							jigFixlocation= JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(calDevices.ControlNo);

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

                                cbFixLocation.Text = jigFixlocation.FixLocation;

                                cbToSec.Text = calDevices.JigSecCode;
                                cbToLoc.Text = calDevices.LocName;

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
			var calDevices = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(txtControlNo.Text.Trim());
            if (calDevices == null)
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
            //if (cbToSec.Text.Equals(cbFromSec.Text))
            //{
            //    MessageBox.Show("From Section và To Section không được giống nhau !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cbToSec.Focus();
            //    return false;
            //}
            //if (cbFromLoc.Text.Equals(cbToLoc.Text))
            //{
            //    MessageBox.Show("From Location và To Location không được giống nhau !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cbFromLoc.Focus();
            //    return false;
            //}
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var jigInOut = new JIGH_INOUT();
                jigInOut.ControlNo = txtControlNo.Text.Trim();
                jigInOut.FromLocCode = cbFromLoc.Text.Trim();
                jigInOut.FromSecCode = cbFromSec.Text.Trim();
                jigInOut.PIC = txtPIC.Text.Trim();
                jigInOut.Appr = txtApprove.Text.Trim();
                jigInOut.ToLocCode = cbToLoc.Text.Trim();
                jigInOut.ToSecCode = cbToSec.Text.Trim();
                jigInOut.Remark = txtRemark.Text.Trim();
                //jigInOut.InOut_Type = InOutFlag;
                jigInOut.CreatedBy = Program.UserId;
                jigInOut.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();

                if (cbToSec.Text == "EQUIPMENT" || cbToSec.Text=="JIG")
                {
                    jigInOut.InOut_Type = "IN";
                    string message = JIGHINOUT_DAL.Instance.Add(jigInOut);
                    if (message != "")
                    {
                        MessageBox.Show("Đã có lỗi xảy ra OUT " + message, "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // Update thêm vị trí mới nhất vào master
                        // Real: true =1  nghĩa là đang có trong kho
                        // Real: false=0  nghĩa là đã xuất ra xs
                        JIGHCALDEVICES_DAL.Instance.UpdateRealIN(jigInOut.ControlNo, true,cbToSec.Text,cbToLoc.Text,cbFixLocation.Text,Program.UserId,CommonDAL.Instance.getSqlServerDatetime());
                    }
                    //JIGINOUT_DAL.Instance.Add(jigInOut);

                }
                else
                {
                    jigInOut.InOut_Type = "OUT";
                    string message = JIGHINOUT_DAL.Instance.Add(jigInOut);
                    if (message != "")
                    {
                        MessageBox.Show("Đã có lỗi xảy ra IN " + message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //JIGHCALDEVICES_DAL.Instance.UpdateReal(jigInOut.ControlNo, false);
						JIGHCALDEVICES_DAL.Instance.UpdateRealOUT(jigInOut.ControlNo, false,cbToSec.Text,cbToLoc.Text, Program.UserId, CommonDAL.Instance.getSqlServerDatetime());
					}

                }
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

       
    }
}
