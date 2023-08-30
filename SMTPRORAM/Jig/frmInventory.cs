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
using EzioDll;
using UnidenDTO;
using System.IO.Ports;

namespace SMTPRORAM.Jig
{
    public partial class frmInventory : Form
    {
        GodexPrinter Printer = new GodexPrinter();
        private string PrintName = "";
        private bool flagUpdate=false;
        public frmInventory()
        {
            InitializeComponent();
        }
        void ResetControll()
        {
            
            txtControlNo.Text = "";
            txtEqName.Text = "";
            txtDevicesDesc.Text = "";
            cbCalType.Text = "[None]";
            txtSerial.Text = "";
            txtModel.Text = "";
            txtMaker.Text = "";
            dtpCalDate.Text = "";
            cbJigSecCode.Text = "";
            cbJigLocName.Text = "";
            txtSStatus.Text = "";
            txtNGDetail.Text = "";
            txtUseStatus.Text = "";
            dtpPurDate.Text = "";
            txtImportCond.Text = "";
            txtOrigin.Text = "";
            txtOldControlNo.Text = "";
            txtBookvalue.Text = "";
            txtInvoiceNo.Text = "";
            txtFACode1.Text = "";
            txtFACode2.Text = "";
            txtRemark.Text = "";
        }
        private void LoadComboboxData()
        {
            var lstCaltype = JIGCALTYPE_DAL.Instance.getListCalType();
            var calType = new ShowDetail();
            calType.CalType = "[None]";
            lstCaltype.Add(calType);
            cbCalType.DataSource = lstCaltype.OrderBy(p => p.CalType).ToList();
            cbCalType.DisplayMember = "CalType";
            cbCalType.ValueMember = "CalType";

            var lstSection = JIGSECTION_DAL.Instance.getListSection();
            var section = new ShowView();
            section.JigSecCode = "[None]";
            lstSection.Add(section);
            cbJigSecCode.DataSource = lstSection.OrderBy(p => p.JigSecCode).ToList();
            cbJigSecCode.DisplayMember = "JigSecCode";
            cbJigSecCode.ValueMember = "JigSecCode";

            var lstLocation = JIGLOCATION_DAL.Instance.getListLocation();
            var location = new ShowDisplay();
            location.LocName = "[None]";
            lstLocation.Add(location);
            cbJigLocName.DataSource = lstLocation.OrderBy(p => p.LocName).ToList();
            cbJigLocName.DisplayMember = "LocName";
            cbJigLocName.ValueMember = "LocName";
        }
        private void LoadNewDevices()
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewNew, jigCalNewDAL.Instance.getNewDevices(CommonDAL.Instance.getSqlServerDatetime()));
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
			cbMaCty.Text = "--Select--";
			txtSearch.Focus();
            LoadComboboxData();
            LoadNewDevices();
            getListDeviceByDate();
            try
            {
                FindPrinter_USB();
                // Find Com Port
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
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy máy in: "+ ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;                
            }
            
        }

        private void iconbtnTim_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                MessageBox.Show("Hãy nhập thông tin cần tìm kiếm [Control No or Serial]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                CommonDAL.Instance.ShowDataGridView(dgViewOld, JIGCALDEVICES_DAL.Instance.getListCalDevicesByControlOrSerial(txtSearch.Text));
                txtSearch.Focus();
            }
            
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                if (txtSearch.Text.Equals(""))
                {
                    MessageBox.Show("Hãy nhập thông tin cần tìm kiếm [Control No or Serial]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearch.Focus();
                    return;
                }
                else
                {
					string inputString = txtSearch.Text.Trim();
					char[] separator = { ';' };
					string[] result = inputString.Split(separator);
					txtSearch.Text = result[0];
					CommonDAL.Instance.ShowDataGridView(dgViewOld, JIGCALDEVICES_DAL.Instance.getListCalDevicesByControlOrSerial(txtSearch.Text));
                    txtSearch.Focus();
                }
            }
        }

        private void dgViewOld_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgViewOld.Rows.Count>0)
            {
                DataGridViewRow row = dgViewOld.SelectedCells[0].OwningRow;                                
                txtControlNo.Text = row.Cells["ControlNo"].Value.ToString();
                txtEqName.Text = row.Cells["EqName"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtSerial.Text = row.Cells["SerialNumber"].Value.ToString();
                cbCalType.Text = row.Cells["CalType"].Value.ToString();
                txtMaker.Text = row.Cells["Maker"].Value.ToString();
                dtpCalDate.Text = row.Cells["CalDate"].Value.ToString();
                cbJigSecCode.Text = row.Cells["JigSecCode"].Value.ToString();
                cbJigLocName.Text = row.Cells["LocName"].Value.ToString();
                txtSStatus.Text = row.Cells["SStatus"].Value.ToString();
                txtUseStatus.Text = row.Cells["UseStatus"].Value.ToString();
                dtpPurDate.Text = row.Cells["PurDate"].Value.ToString();
                txtImportCond.Text = row.Cells["ImportCond"].Value.ToString();
                txtOrigin.Text = row.Cells["Origin"].Value.ToString();

                txtNGDetail.Text = row.Cells["NGDetail"].Value.ToString();
                txtDevicesDesc.Text = row.Cells["DevicesDesc"].Value.ToString();
                txtOldControlNo.Text = row.Cells["OldControlNo"].Value.ToString();
                txtFACode1.Text = row.Cells["FACode1"].Value.ToString();
                txtFACode2.Text = row.Cells["FACode2"].Value.ToString();
                txtRemark.Text = row.Cells["Remark"].Value.ToString();
                txtBookvalue.Text = row.Cells["BookValue"].Value.ToString();
                txtInvoiceNo.Text = row.Cells["InvoiceNo"].Value.ToString();
                
            }
        }
        private void FindPrinter_USB()
        {
            Cbo_USB.Items.Clear();
            List<string> PrinterList = GodexPrinter.GetPrinter_USB();
            for (int i = 0; i < PrinterList.Count; i++)
                Cbo_USB.Items.Add(PrinterList[i]);
            if (Cbo_USB.Items.Count > 0)
                Cbo_USB.SelectedIndex = 0;
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
            //else if (RBtn_COM.Checked == true)
            //{
            //    if (Cbo_COM.SelectedItem != null)
            //    {
            //        Printer.Open(Cbo_COM.SelectedItem.ToString());
            //        Printer.SetBaudrate(int.Parse(Txt_Baud.Text));
            //    }
            //}
        }
        private bool IsDataOK()
        {
            if (flagUpdate==true)
            {
				if (txtControlNo.Text.Trim().Equals(""))
				{
					MessageBox.Show("ControlNO không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtControlNo.Focus();
					return false;
				}
			}            
            if (txtEqName.Text.Trim().Equals(""))
            {
                MessageBox.Show("EQName không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEqName.Focus();
                return false;
            }
            if (txtModel.Text.Trim().Equals(""))
            {
                MessageBox.Show(" Model không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
                return false;
            }
            if (txtSerial.Text.Trim().Equals(""))
            {
                MessageBox.Show(" Serial Number không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerial.Focus();
                return false;
            }
            if (cbCalType.Text.Trim().Equals("") || cbCalType.Text == "[None]")
            {
                MessageBox.Show(" CalType không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCalType.Focus();
                return false;
            }           
            
            if (txtMaker.Text.Trim().Equals(""))
            {
                MessageBox.Show(" Maker không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaker.Focus();
                return false;
            }
            if (cbJigSecCode.Text.Trim().Equals("") || cbJigSecCode.Text == "[None]")
            {
                MessageBox.Show(" cbJigSecCode không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbJigSecCode.Focus();
                return false;
            }
            if (cbJigLocName.Text.Trim().Equals("") || cbJigLocName.Text == "[None]")
            {
                MessageBox.Show(" cbJigLocName không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbJigLocName.Focus();
                return false;
            }
            if (txtSStatus.Text.Trim().Equals(""))
            {
                MessageBox.Show(" SStatus không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSStatus.Focus();
                return false;
            }
            if (txtUseStatus.Text.Trim().Equals(""))
            {
                MessageBox.Show(" UseStatus không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUseStatus.Focus();
                return false;
            }

            if (txtImportCond.Text.Trim().Equals(""))
            {
                MessageBox.Show(" ImportCond không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImportCond.Focus();
                return false;
            }

            if (txtOrigin.Text.Trim().Equals(""))
            {
                MessageBox.Show(" Origin không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrigin.Focus();
                return false;
            }
            if (cbMaCty.Text.Trim().Equals("--Select--"))
            {
				MessageBox.Show("Phải chọn mã công ty !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbMaCty.Focus();
				return false;
			}
            return true;
        }
        private void getListDeviceByDate()
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewNew,jigCalNewDAL.Instance.getNewDevices(CommonDAL.Instance.getSqlServerDatetime()));
        }
        private void iconbtnPrint_Click(object sender, EventArgs e)
        {
            //string test = "UVEQ-000001";
            //MessageBox.Show(test.Substring(5, 6));
            // ghi chu
            if (flagUpdate==true)
            {
                DialogResult dialogResult = MessageBox.Show("Có đúng bạn muốn sửa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult==DialogResult.No)
                {
                    flagUpdate = false;
                    ResetControll();
                }
            }

            if (IsDataOK())
            {
                //string qrcode = "UVEQ-000000001;RE COMMUNICATION TEST SET;SP-6789;HLAB5001132100010";
                //string csString = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H11\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,47,5,2,M0,8,3,40,0\r\nUVEQ-000000001;SP-6789;HLAB5001132100010\r\nAB,118,48,1,1,0,0E,SP-0000001\r\nAB,118,79,1,1,0,0E,Uniden VN\r\nAB,118,113,1,1,0,0E,UVEQ-00000001\r\nAB,18,16,1,1,0,0E,RE COMMUNICATION TEST SET\r\nE\r\n";
               
                try
                {
                    // In nhã dán vào thiết bị
                    ConnectPrinter();
                    Printer.Open(PortType.USB);
                    // Lưu thông tin cần in vào csdl mới.
                    var jigNew = new JIG_CALDEVICES_NEW();
                    var jigAdd = new JIG_CALDEVICES();
                    //jigNew.ControlNo= txtControlNo.Text;
                    jigNew.EqName= txtEqName.Text;
                    jigAdd.EqName= txtEqName.Text;

                    jigNew.Model= txtModel.Text;
                    jigAdd.Model = txtModel.Text;

                    jigNew.SerialNumber=txtSerial.Text;
                    jigAdd.SerialNumber=txtSerial.Text;

                    jigNew.CalType = cbCalType.Text;
                    jigAdd.CalType = cbCalType.Text;

                    jigNew.Maker=txtMaker.Text;
                    jigAdd.Maker = txtMaker.Text;

                    jigNew.CalDate = dtpCalDate.Value.Date;
                    jigAdd.CalDate = dtpCalDate.Value.Date;

                    jigNew.JigSecCode = cbJigSecCode.Text;
                    jigAdd.JigSecCode= cbJigSecCode.Text;

                    jigNew.LocName=cbJigLocName.Text;
                    jigAdd.LocName= cbJigLocName.Text;

                    jigNew.SStatus= txtSStatus.Text;
                    jigAdd.SStatus= txtSStatus.Text;

                    jigNew.UseStatus= txtUseStatus.Text;
                    jigAdd.UseStatus= txtUseStatus.Text;

                    jigNew.PurDate=dtpPurDate.Value.Date;
                    jigAdd.PurDate=dtpPurDate.Value.Date;

                    jigNew.ImportCond=txtImportCond.Text;
                    jigAdd.ImportCond   =txtImportCond.Text;

                    jigNew.Origin=txtOrigin.Text;
                    jigAdd.Origin = txtOrigin.Text;


                    jigNew.NGDetail= txtNGDetail.Text;
                    jigAdd.NGDetail= txtNGDetail.Text;

                    jigNew.DevicesDesc= txtDevicesDesc.Text;
                    jigAdd.DevicesDesc= txtDevicesDesc.Text;

                    jigNew.OldControlNo = txtOldControlNo.Text;
                    jigAdd.OldControlNo= txtOldControlNo.Text;

                    jigNew.FACode1=txtFACode1.Text;
                    jigAdd.FACode1=txtFACode1.Text;

                    jigNew.FACode2=txtFACode2.Text; 
                    jigAdd.FACode2=txtFACode2.Text;

                    jigNew.Remark=txtRemark.Text;
                    jigAdd.Remark = txtRemark.Text;

                    jigNew.BookValue=txtBookvalue.Text;
                    jigAdd.BookValue=txtBookvalue.Text;

                    jigNew.InvoiceNo=txtInvoiceNo.Text;
                    jigAdd.InvoiceNo=txtInvoiceNo.Text;

                    // 
                    var date = new DateTime();
                    date= CommonDAL.Instance.getSqlServerDatetime();
                    jigNew.Real = true;
                    jigAdd.Real = true;

                    jigNew.CreatedBy = Program.UserId;
                    jigAdd.CreatedBy = Program.UserId;

                    jigNew.CreatedDate = date;
                    jigAdd.CreatedDate= date;

                    jigNew.UpdatedDate = date;
                    jigAdd.UpdatedDate = date;

                    if (flagUpdate==true)
                    {
                        var dt = new DataTable();
						//dt = jigCalNewDAL.Instance.getNewDeviceControNo();
						//jigNew.ControlNo = dt.Rows[0]["ControlNo"].ToString();
						//
						jigNew.ControlNo= txtControlNo.Text;
                        string mess01 = jigCalNewDAL.Instance.Update(jigNew);
						string mess02 = JIGCALDEVICES_DAL.Instance.Update(jigAdd);
						if (mess01 !=""&& mess02!="")
                        {
                            MessageBox.Show("Sửa bản ghi thành công !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information );
                            flagUpdate=false;                                                       
                        }
                        else
                        {
                            MessageBox.Show("Không sửa được bản ghi !!!. \n " +
                                "Đã có lỗi xảy ra: " + mess01 + "  "+mess02, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            flagUpdate = false;
                            ResetControll();
                            return;
                        }
                    }
                    else
                    {
                        var dt = new DataTable();
                        //dt = jigCalNewDAL.Instance.getNewDeviceControNo();
                        //dt = JIGCALDEVICES_DAL.Instance.getNewDeviceControNoAuto();
                        dt = jigCalNewDAL.Instance.getNewDeviceControNo_New(cbMaCty.Text);
						int seqNumber = 0;
                        string controlNoNew = "";


						var checkExistSerial = new JIG_CALDEVICES_NEW();
						var checkExistSerial01 = new JIG_CALDEVICES();

						checkExistSerial = jigCalNewDAL.Instance.checkCalDevicesExistBySerial(jigNew.SerialNumber);
						// checkExistSerial01 = JIGCALDEVICES_DAL.Instance.checkCalDevicesExistBySerial(jigAdd.SerialNumber);
						//if (checkExistSerial != null && checkExistSerial01 != null)
						//if (checkExistSerial != null && checkExistSerial01 != null&&
						//	checkExistSerial.SerialNumber.Length>4 && checkExistSerial01.SerialNumber.Length>4)
							if (checkExistSerial != null &&
							checkExistSerial.SerialNumber.Length > 4 )
							{
							MessageBox.Show("Số Serial No: " + jigAdd.SerialNumber + " này đã có trong csdl với Control No:  " + checkExistSerial01.ControlNo +"\n\n"+

								"Số Serial No: " + jigNew.SerialNumber + " này đã có trong csdl với Control No:  " + checkExistSerial.ControlNo, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						if (dt.Rows.Count>0)
                        {
                            seqNumber=int.Parse( dt.Rows[0]["ControlNo"].ToString().Substring(5,6));
                            seqNumber = seqNumber + 1;
                            controlNoNew = cbMaCty.Text.Trim()+"-" + seqNumber.ToString("000000");
                            txtControlNo.Text = controlNoNew;
                        }
                        else 
                        {
                            seqNumber = 0;
                            seqNumber = seqNumber + 1;
                            controlNoNew = cbMaCty.Text.Trim() + "-" + seqNumber.ToString("000000");
                            txtControlNo.Text = controlNoNew;
                        }
                        jigNew.ControlNo = controlNoNew;
                        jigAdd.ControlNo = controlNoNew;

                        string message = jigCalNewDAL.Instance.Add(jigNew);

						if (message!="")
                        {                        
							MessageBox.Show("Không thêm thành công vào csdl \n" +
                                "Có lỗi xảy ra: "+ message,"Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
						}
                        string mess = JIGCALDEVICES_DAL.Instance.Add(jigAdd);
						if (mess!="")
                        {                      
							MessageBox.Show("Không thêm thành công vào csdl chính. \n" +
                                "Có lỗi xảy ra:  "+ mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
                    string csString = "";
                    if (cbMaCty.Text=="UVEQ")
                    {
						string qrcode = txtControlNo.Text.Trim() + ";" + txtEqName.Text.Trim() + ";" + txtModel.Text.Trim() + ";" + txtSerial.Text.Trim();
						string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,47,5,2,M0,8,3," + qrcode.Length + ",0\r\n";
						//string qrcode = txtControlNo.Text.Trim() + ";" + txtEqName.Text.Trim() + ";" + txtModel.Text.Trim() + ";" + txtSerial.Text.Trim();
						string csString1 = "\r\nAB,118,48,1,1,0,0E,";
						string model = txtModel.Text.Trim();
						string csString2 = "\r\nAB,118,79,1,1,0,0E,";
						string serial = txtSerial.Text.Trim();
						string scString3 = "\r\nAB,118,113,1,1,0,0E,";
						string controlNo = txtControlNo.Text.Trim();
						string csString4 = "\r\nAB,18,16,1,1,0,0E,";
						string controlName = txtEqName.Text.Trim();
						string csString5 = "\r\nE\r\n";
						 csString = csString0 + qrcode + csString1 + model + csString2 + serial + scString3 + controlNo + csString4 + controlName + csString5;

					}
                    else
                    {
						string qrcode = txtControlNo.Text.Trim() + ";" + txtEqName.Text.Trim() + ";" + txtModel.Text.Trim() + ";" + txtSerial.Text.Trim();
						string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,36,5,2,M0,8,3," + qrcode.Length + ",0\r\n";
						//string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,36,5,2,M0,8,3,40,0\r\nUVEQ-000000001;SP-6789;HLAB5001132100010" +
      //                      "\r\nAB,118,38,1,1,0,0E," +
      //                      "SP-0000001" +
      //                      "\r\nAB,118,69,1,1,0,0E," +
      //                      "Uniden VN" +
      //                      "\r\nAB,118,103,1,1,0,0E," +
      //                      "UVEQ-00000001" +
      //                      "\r\nAA,18,12,1,1,0,0E," +
      //                      "RE COMMUNICATION TEST SET" +
      //                      "\r\nE";

						//string qrcode = txtControlNo.Text.Trim() + ";" + txtEqName.Text.Trim() + ";" + txtModel.Text.Trim() + ";" + txtSerial.Text.Trim();
						string csString1 = "\r\nAB,118,38,1,1,0,0E,";
						string model = txtModel.Text.Trim();
						string csString2 = "\r\nAB,118,69,1,1,0,0E,";
						string serial = txtSerial.Text.Trim();
						string scString3 = "\r\nAB,118,103,1,1,0,0E,";
						string controlNo = txtControlNo.Text.Trim();
						string csString4 = "\r\nAA,18,12,1,1,0,0E,";
						string controlName = txtEqName.Text.Trim();
						string csString5 = "\r\nE\r\n";
						csString = csString0 + qrcode + csString1 + model + csString2 + serial + scString3 + controlNo + csString4 + controlName + csString5;

					}

					

					

					Printer.Command.Send(csString);
                    //Printer.Command.End();
                    ResetControll();
                    txtSearch.Text = "";
                    txtSearch.Focus();
                    getListDeviceByDate();
                    Printer.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không kết nối được với máy in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }                     
            
        }

        private void dgViewNew_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgViewNew.Rows.Count>0)
            {
                flagUpdate = true;
                DataGridViewRow row = dgViewNew.SelectedCells[0].OwningRow;
                txtControlNo.Text = row.Cells["ControlNo"].Value.ToString();
                txtEqName.Text = row.Cells["EqName"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtSerial.Text = row.Cells["SerialNumber"].Value.ToString();
                cbCalType.Text = row.Cells["CalType"].Value.ToString();
                txtMaker.Text = row.Cells["Maker"].Value.ToString();
                dtpCalDate.Text = row.Cells["CalDate"].Value.ToString();
                cbJigSecCode.Text = row.Cells["JigSecCode"].Value.ToString();
                cbJigLocName.Text = row.Cells["LocName"].Value.ToString();
                txtSStatus.Text = row.Cells["SStatus"].Value.ToString();
                txtUseStatus.Text = row.Cells["UseStatus"].Value.ToString();
                dtpPurDate.Text = row.Cells["PurDate"].Value.ToString();
                txtImportCond.Text = row.Cells["ImportCond"].Value.ToString();
                txtOrigin.Text = row.Cells["Origin"].Value.ToString();

                txtNGDetail.Text = row.Cells["NGDetail"].Value.ToString();
                txtDevicesDesc.Text = row.Cells["DevicesDesc"].Value.ToString();
                txtOldControlNo.Text = row.Cells["OldControlNo"].Value.ToString();
                txtFACode1.Text = row.Cells["FACode1"].Value.ToString();
                txtFACode2.Text = row.Cells["FACode2"].Value.ToString();
                txtRemark.Text = row.Cells["Remark"].Value.ToString();
                txtBookvalue.Text = row.Cells["BookValue"].Value.ToString();
                txtInvoiceNo.Text = row.Cells["InvoiceNo"].Value.ToString();
            }            
        }

        private void iconbtnNew_Click(object sender, EventArgs e)
        {
            flagUpdate=false;
        }
    }
}
