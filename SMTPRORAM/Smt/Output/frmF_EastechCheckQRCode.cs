using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
using SMTPRORAM.Smt.DataControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Smt.Input;
using UnidenDAL.Smt.Output;
using UnidenDTO;
using ZedGraph;
using static ClosedXML.Excel.XLPredefinedFormat;
using static System.Data.Entity.Infrastructure.Design.Executor;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;

namespace SMTPRORAM.Smt.Output
{
    public partial class frmF_EastechCheckQRCode : Form
    {
        private int firstCheck = 1;
        public int Prodcount = 0;
        private List<EASTECH_PROGRAMHISTORY> lstETHistory01;
        private List<PROGRAM> lstProgram01;
		private List<EASTECH_PROGRAMHISTORY> lstETHistory02;
		private List<PROGRAM> lstProgram02;
		private int checkProgram01 = 0;
        private int coutProgram02 = 0;
		private int checkProgram02 = 0;
		public static long newID { get; private set; }
        public static string messageError { get; private set; }
        public frmF_EastechCheckQRCode()
        {
            InitializeComponent();
        }

        private void LoadPCBCode()
        {
            var lstPCBCode = EastechPCBCode_DAL.Instance.getListPCBCode();
            if (lstPCBCode.Count>0)
            {
                cbPcbCode.DataSource = lstPCBCode;
				cbPcbCode.DisplayMember = "PCBCode";
				cbPcbCode.ValueMember = "PCBCode";
			}
		}
        private void frmF_EastechCheckQRCode_Load(object sender, EventArgs e)
        {
            btSave.Visible = false;
            // Each SubItem object requires a column, so add three columns.
            this.listView1.Columns.Add("QR Code", 190, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Số LK", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Số QR", 120, HorizontalAlignment.Left);
            cbModel.Text = "--Select--";
           

			lblviewcount.Text = "";
            lbprog.Text = "";
            lbprg2.Text = "";
            lblCount.Text = "";
            lblDept.Text = Program.Dept;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            //lblchecker.Text = Program.username;

            lblchecker.Text = Program.UserId;

            LoadPCBCode();
			#region Old Code
			/*
			System.Data.DataTable dt = new System.Data.DataTable();
            //dt = Pcb_Code_Services.PCBCode_GetModel();
            dt = Pcb_Code_Services.EastechPCBCode_GetPcbCode();
            if (dt.Rows.Count >= 1)
            {
                cbPcbCode.DataSource = dt;
                cbPcbCode.DisplayMember = "PCBCode";
                cbPcbCode.ValueMember = "PCBCode";
            }
            else
            {
                //MessageBox.Show("Không có dữ liệu !!!");
                //return;
            }
			//cbp.Items.Clear();
            */
			#endregion
			cbPcbCode.Focus();
            lbe.Text = "";
            lbline.Text = "";
            lbp.Text = "";
            label7.Text = "";
			cbPcbCode.Text = "--Select--";
		}

		#region Old Code not use
		/*
        private void DisplayProduct2(string pgkey1, string pgkey2, string qrcode, string user, DateTime DateT)
        {
            var dt = new DataTable();
            dt = EastechOutputHistory_Services.EastechOutputHistory_ListQrByUser2(pgkey1, pgkey2, qrcode, user, DateT);
            if (dt.Rows.Count > 0)
            {
                lblviewcount.Text = dt.Rows.Count.ToString();
            }
            else
            {

            }
        }
        private int CountProduct()
        {
            int ProductCount = 0;
            ProductCount = EastechOutputHistory_Services.EastechOutputHistory_Count(txtProgram.Text, Program.username);
            return Prodcount = ProductCount;
        }

        private void CountProduct2(string pgkey1, string pgkey2, string remark)
        {
            var dt = new DataTable();
            dt = EastechOutputHistory_Services.EastechHOutistory_Count2(pgkey1, pgkey2, remark);
            if (dt.Rows.Count > 0)
            {
                lblCount.Text = dt.Rows.Count.ToString();
            }

        }
        */
		#endregion

		private void ResetAll()
        {
            var datetime = CommonDAL.Instance.getSqlServerDatetime();  
            txtLinename.Enabled = false;
            txtProgram.Enabled = false;
            txtprogram2.Enabled = false;
            cbPcbCode.Enabled = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            checkBox1.Enabled = false;
            Application.DoEvents();
            System.Threading.Thread.Sleep(50);
			pictureBox1.Visible = false;
            lblCount.Text = EASTECH_PROGRAMHISTORY_DAL.Instance.EastechHOutistory_CountQRCodeByUser(txtProgram.Text, txtprogram2.Text, Program.username).ToString();

			//lblCount.Text = EastechOutputHistory_Services.EastechHOutistory_CountQRCodeByUser(txtProgram.Text, txtprogram2.Text, Program.username).ToString();
			// lblCount.Text = SmtAOIQrCodeOutputDAL.Instance.GetMaterialPerPCBByUser(Program.username, txtProgram.Text.Trim(), txtprogram2.Text.Trim()).ToString();


			//lblviewcount.Text = EastechOutputHistory_Services.EastechOutputHistory_CountMaterialOfQRcode(txtProgram.Text, txtprogram2.Text, txtQRCode.Text, Program.username, Common_ClassBu.getServerDateTime()).ToString();
			// lblviewcount.Text = SmtAOIQrCodeOutputDAL.Instance.GetQRCodeCountByUserAndDate(Program.username,txtQRCode.Text.Trim(), txtProgram.Text.Trim(), txtprogram2.Text.Trim(), datetime).ToString();

			lblviewcount.Text = SmtAOIQrCodeOutputDAL.Instance.GetQRCodeCountByUserAndDateNEW(txtProgram.Text, txtprogram2.Text, txtQRCode.Text, Program.UserId, datetime).ToString() ;
			listView1.View = System.Windows.Forms.View.Details;
            listView1.Items.Insert(0, (new ListViewItem(new string[] { txtQRCode.Text, lblviewcount.Text, lblCount.Text })));
            listView1.GridLines = true;
			lbe.Text = "";
			//txtQRCode.Text = string.Empty;
			//txtQRCode.Focus();
		}

        private void cbPcbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ComboBox cb = (ComboBox)sender;
            //cb.DroppedDown = true;
            //string strFindStr = "";
            //if (e.KeyChar == (char)8)
            //{
            //    if (cb.SelectionStart <= 1)
            //    {
            //        cb.Text = "";
            //        return;
            //    }

            //    if (cb.SelectionLength == 0)
            //        strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
            //    else
            //        strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            //}
            //else
            //{
            //    if (cb.SelectionLength == 0)
            //        strFindStr = cb.Text + e.KeyChar;
            //    else
            //        strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            //}
            //int intIdx = -1;
            //// Search the string in the ComboBox list.
            //intIdx = cb.FindString(strFindStr);
            //if (intIdx != -1)
            //{
            //    cb.SelectedText = "";
            //    cb.SelectedIndex = intIdx;
            //    cb.SelectionStart = strFindStr.Length;
            //    cb.SelectionLength = cb.Text.Length;
            //    e.Handled = true;
            //}
            //else
            //    e.Handled = true;
        }
		private void LoadModel(string PCBCode)
		{
			var lstModel = EastechPCBCode_DAL.Instance.getModelPCBType(PCBCode);
			if (lstModel.Count > 0)
			{
				cbModel.DataSource = lstModel;
				cbModel.DisplayMember = "Model";
				cbModel.ValueMember = "Model";
			}			
		}
	
		private void cbPcbCode_SelectedValueChanged(object sender, EventArgs e)
		{
            if (cbPcbCode.SelectedItem is PcbCodeGroupBy selectedPCBCode)
            {
                if (selectedPCBCode.PCBCode.Equals("--Select--"))
                {
					cbPcbCode.Focus();
					return;
				}
                else
                {
					LoadModel(cbPcbCode.Text.Trim());
				}
            }
			
			#region Old Code
			/*
            //lbPCB_No.Text = cbPcbCode.Text;
            var dt = new DataTable();
            dt = Pcb_Code_Services.EastechPCBCode_SearchByPcbCode(cbPcbCode.Text);
            if (dt.Rows.Count > 0)
            {
				//txtModel.Text = dt.Rows[0].Field<string>("Model");
				txtPcbType.Text = dt.Rows[0].Field<string>("PcbType");				
			    cbModel.DataSource = dt;
			    cbModel.DisplayMember = "Model";
			    cbModel.ValueMember = "Model";				
			}
            else
            {
                //MessageBox.Show("Không có dữ liệu !!!");
                //return;
            }
            */
			#endregion
		}
		
		private void cbModel_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbModel.SelectedItem is PCBCodeToModel selectedPCB)
			{
                //MessageBox.Show("Hãy chọn Model", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string model=selectedPCB.Model;
                if (model.Equals("--Select--"))
                {
					cbModel.Focus();
                    txtPcbType.Text = string.Empty;
					return;
				}
                else
                {
					var getType = EastechPCBCode_DAL.Instance.getPCBType(cbPcbCode.Text.Trim(), cbModel.Text.Trim());
					if (getType != null)
					{
						txtPcbType.Text = getType.PcbType;
					}
					else
					{
						//MessageBox.Show("Chọn PCB Code và Model không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						cbModel.Focus();
						txtPcbType.Text = string.Empty;
						return;
					}
				}				
			}			
		}

		private bool checkLineName()
        {
            if (string.IsNullOrEmpty(txtLinename.Text.Trim()))
            {
                CommonDAL.Instance.SetStatusLabels(lbline, "NG");
                return false;
            }
            var checkLine = SmtLineDAL.Instance.checkSMTLine(txtLinename.Text.Trim());
            if (checkLine==null)
            {
				CommonDAL.Instance.SetStatusLabels(lbline, "NG");
                return false;
			}
            else
            {
				CommonDAL.Instance.SetStatusLabels(lbline, "OK");				
			}
            return true;
        }

        private void txtLinename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkLineName())
                {
					string b = "";
					b = txtLinename.Text.Substring(0, 2);
					if (b == "BM" || b == "IN")
					{
						txtprogram2.Enabled = false;    
                        if (b=="IN")
                        {
                            checkBox1.Enabled = false;
                        }
                        else
                        {
                            checkBox1.Enabled = true;
						}
					}
					else
					{
						txtprogram2.Enabled = true;
					}
					txtProgram.Focus();
				}
                else
                {
					txtLinename.Focus();					
				}

				#region Old code
				/*
				// Kiểm tra xem Line này có trong csdl không?
				if (txtLinename.Text.Equals(""))
                {
                    MessageBox.Show("Hãy nhập Line name vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbline.Text = "NG";
                    lbline.ForeColor = System.Drawing.Color.Red;
                    txtLinename.Focus();
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = Smt_Linename_Services.Linename(txtLinename.Text);
                    if (dt.Rows.Count < 1)
                    {
                        MessageBox.Show("Line Này chưa có trong csdl!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbline.Text = "NG";
                        lbline.ForeColor = System.Drawing.Color.Red;
                        txtLinename.Focus();
                        txtLinename.SelectAll();
                        return;
                    }
                    else
                    {
                        string b = "";
                        b = txtLinename.Text.Substring(0, 2);
                        if (b == "BM" || b == "IN")
                        {
                            txtprogram2.Enabled = false;
                        }
                        else
                        {
                            txtprogram2.Enabled = true;
                        }
                        lbline.Text = "OK";
                        lbline.ForeColor = System.Drawing.Color.Green;
                        SendKeys.Send("^A");
                        txtProgram.Focus();
                    }               
				}
                 */
				#endregion
			}
		}

        private bool checkProgram()
        {
            if ( string.IsNullOrEmpty(txtProgram.Text.Trim()))
            {
                CommonDAL.Instance.SetStatusLabels(lbp, "NG");
                return false;
            }
             lstETHistory01=EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(txtProgram.Text.Trim(),txtLinename.Text.Trim());
             lstProgram01 = SmtProgramDAL.Instance.getListByPro(txtProgram.Text.Trim());

            if (lstETHistory01.Count<1 || lstProgram01.Count<1)
            {
				CommonDAL.Instance.SetStatusLabels(lbp, "NG");
				return false;
			}
            if (lstProgram01.Count>0 && lstETHistory01.Count>0)
            {
				string b = "";
				b = txtLinename.Text.Substring(0, 2); // Lấy 2 ký tự bắt đầu của tên Line                        
				if (b == "IN")
				{
                    // Kiểm tra chương trình này với PCB có giống nhau không?
					string pcb = cbPcbCode.Text.Substring(0, 8);
					if (!txtProgram.Text.Contains(pcb))
					{
						CommonDAL.Instance.SetStatusLabels(lbp, "NG");                        
						return false;
					}
					else
					{
						CommonDAL.Instance.SetStatusLabels(lbp, "OK");						
					}
				}
				else
				{
					CommonDAL.Instance.SetStatusLabels(lbp, "OK");
					lbprog.Text = lstProgram01.Count.ToString();
				}
			}  
			return true;
        }

        private void txtProgram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkProgram())
                {
					string b = "";
					b = txtLinename.Text.Substring(0, 2);
                    if (b=="IN"||b=="BM")
                    {
                        txtQRCode.Focus();
                    }
                    else
                    {
                        txtprogram2.Focus();
                    }
				}
                else
                {
                    txtProgram.Focus();
                    txtProgram.SelectAll();
                }

				#region Old code
                /*
				if (txtProgram.Text.Equals("") || string.IsNullOrEmpty(txtProgram.Text))
                {
                    MessageBox.Show("Hãy nhập dữ liệu vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbp.Text = "NG";
                    lbp.ForeColor = System.Drawing.Color.Red;
                    txtProgram.Focus();
                    return;
                }
                else
                {
                    // Kiểm tra xem ctrinh này có trong csdl không???
                    Program.dprogram1 = new DataTable();
                    Program.dprogram1 = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, txtLinename.Text);
                    Program.dtpro_1 = new DataTable();
                    Program.dtpro_1 = PROGRAMService.PROGRAM_GetByProgramKey(txtProgram.Text);
                    lbprog.Text = Program.dtpro_1.Rows.Count.ToString();
                    //dt = EastechHistory_Services.EastechHistory_CheckProgKey(txtProgram.Text.Trim());
                    if (Program.dprogram1.Rows.Count < 1 || Program.dtpro_1.Rows.Count < 1)
                    {
                        MessageBox.Show("Chương trình này chưa được tạo trong csdl "+"\n"+
                            "hoặc Không có linh kiện để bắn. Hãy Liên hệ bộ phận IT",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lbp.Text = "NG";
                        lbp.ForeColor = System.Drawing.Color.Red;
                        txtProgram.SelectAll();
                        txtProgram.Focus();
                        return;
                    }
                    else
                    {
                        string b = "";
                        b = txtLinename.Text.Substring(0, 2); // Lấy 2 ký tự bắt đầu của tên Line                        
                        if (b == "IN")
                        {
                            // Kiểm tra chương trình này với PCB có giống nhau không?
                            string pcb = cbPcbCode.Text.Substring(0, 8); 


                            if (!txtProgram.Text.Contains(pcb))
                            {
                                MessageBox.Show("PCB Code Không thuộc chương trình này !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtProgram.Clear();
                                txtProgram.Focus();
                                return;
                            }
                            else
                            {
                                lbp.Text = "OK";
                                lbp.ForeColor = System.Drawing.Color.Green;
                                //SendKeys.Send("^A");
                                txtQRCode.Focus();
                            }

                        }                        
                        else
                        {

                            if (b == "BM")
                            {
                                lbp.Text = "OK";
                                lbp.ForeColor = System.Drawing.Color.Green;
                                //SendKeys.Send("^A");
                                txtQRCode.Focus();
                            }
                            else
                            {
                                lbp.Text = "OK";
                                lbp.ForeColor = System.Drawing.Color.Green;
                                //SendKeys.Send("^A");
                                txtprogram2.Focus();
                            }
                        }
                    }
                }
                */
				#endregion
			}
		}

        private bool checkProgram2()
        {
            if (string.IsNullOrEmpty(txtprogram2.Text.Trim()))
            {
                CommonDAL.Instance.SetStatusLabels(label7, "NG");
                return false;
            }
			lstETHistory02 = EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(txtprogram2.Text.Trim(), txtLinename.Text.Trim());
			lstProgram02 = SmtProgramDAL.Instance.getListByPro(txtprogram2.Text.Trim());
			if (lstETHistory02.Count < 1 || lstProgram02.Count < 1)
			{
				CommonDAL.Instance.SetStatusLabels(lbp, "NG");
				return false;
			}
            if (lstProgram02.Count > 0 && lstETHistory02.Count > 0)
            {
				CommonDAL.Instance.SetStatusLabels(lbp, "OK");
				lbprg2.Text = lstProgram02.Count.ToString();
			}            
            return true;
        }
        private void txtprogram2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkProgram2())
                {
                    txtQRCode.Focus();
                }
                else
                {
                    txtprogram2.Focus();
                    txtprogram2.SelectAll();
                }
				#region Old Code
                /*
				//txtprogram2.Text = txtprogram2.Text.Trim().ToUpper();
				if (txtProgram.Text.Equals(""))
                {
                    MessageBox.Show("Hãy nhập dữ liệu vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label7.Text = "NG";
                    label7.ForeColor = System.Drawing.Color.Red;
                    txtprogram2.Focus();
                    return;
                }
                else
                {
                    // Kiểm tra xem ctrinh này có trong csdl không???
                    Program.dprogram2 = new DataTable();
                    Program.dprogram2 = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtprogram2.Text, txtLinename.Text);
                    Program.dtpro_2 = new DataTable();
                    Program.dtpro_2 = PROGRAMService.PROGRAM_GetByProgramKey(txtprogram2.Text);
                    lbprg2.Text = Program.dtpro_2.Rows.Count.ToString();
                    //dt = EastechHistory_Services.EastechHistory_CheckProgKey(txtProgram.Text.Trim());
                    if (Program.dprogram2.Rows.Count < 1 || Program.dtpro_2.Rows.Count < 1)
                    {
                        MessageBox.Show("Chuong trình này chưa được tạo trong csdl hoặc Không có linh kiện." +"\n"+
                            "Hãy Liên hệ bộ phận IT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        label7.Text = "NG";
                        label7.ForeColor = System.Drawing.Color.Red;
                        txtprogram2.Focus();
                        return;
                    }
                    else
                    {
                        string b = "";
                        b = txtLinename.Text.Substring(0, 2);                       
                        label7.Text = "OK";
                        label7.ForeColor = System.Drawing.Color.Green;
                        //SendKeys.Send("^A");
                        txtQRCode.Focus();
                        //}                        
                    }
                }
                */
				#endregion
			}
		}
                
		private void txtLinename_Validating(object sender, CancelEventArgs e)
        {
			if (checkLineName())
			{
				string b = "";
				b = txtLinename.Text.Substring(0, 2);
				if (b == "BM" || b == "IN")
				{
					txtprogram2.Enabled = false;
                    if (b=="IN")
                    {
                        checkBox1.Enabled = false;
                    }
                    else
                    {
						checkBox1.Enabled = true;
					}
				}
				else
				{
					txtprogram2.Enabled = true;
				}
				txtProgram.Focus();
			}
			else
			{
				txtLinename.Focus();
			}
			#region Old Code
			/*
			txtLinename.Text = txtLinename.Text.Trim().ToUpper();
            // Kiểm tra xem Line này có trong csdl không?
            if (txtLinename.Text.Equals("") || string.IsNullOrEmpty(txtLinename.Text))
            {
                MessageBox.Show("Hãy nhập Line name vào đây !!!");
                lbline.Text = "NG";
                lbline.ForeColor = System.Drawing.Color.Red;
                txtLinename.Focus();
            }
            else
            {
                DataTable dt = new DataTable();
                dt = Smt_Linename_Services.Linename(txtLinename.Text);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Line Này chưa có trong csdl!!!");
                    lbline.Text = "NG";
                    lbline.ForeColor = System.Drawing.Color.Red;
                    txtLinename.SelectAll();
                    txtLinename.Focus();
                }
                else
                {
                    string b = "";
                    b = txtLinename.Text.Substring(0, 2);

                    if (b == "BM" || b == "IN")
                    {
                        txtprogram2.Enabled = false;
                    }
                    else
                    {
                        txtprogram2.Enabled = true;
                    }
                    lbline.Text = "OK";
                    lbline.ForeColor = System.Drawing.Color.Green;
                    //SendKeys.Send("^A");
                    txtProgram.Focus();
                }
            }
            */
			#endregion
		}
		private bool CheckPersonScanQR(string lineName, string deptName)
		{
			bool check = false;
			if (lineName.StartsWith("IN"))
			{
				check = deptName.StartsWith("IN");                
			}
			else if (lineName.StartsWith("TM") || lineName.StartsWith("BM"))
			{
				check = deptName.StartsWith("SM");
			}
			return check;
		}      

        private bool isOKdata()
        {
            if (!checkLineName())
            {
                return false;
            }
            if (!string.IsNullOrEmpty(txtProgram.Text.Trim()))
            {
				if (!checkProgram())
				{
					return false;
				}
			}           
            if (!string.IsNullOrEmpty(txtprogram2.Text.Trim()))
            {
				if (!checkProgram2())
				{
					return false;
				}
			}            
            return true;
        }

        private bool checkQRCode()
        {
            // Chỉ kiểm tra đầy đủ 1 lần khi bắn QR đầu tiên
            
            if(firstCheck==1)
            {
                firstCheck += 1;
                if (!isOKdata())
                {
     //               if (string.IsNullOrEmpty(txtprogram2.Text.Trim()))
     //               {
					//	firstCheck += 1;
     //                   //return true;
					//}
     //               else
     //               {
						firstCheck = 1;
						return false;
					//}
                    
                }                
            }   
            //===
            if (!CheckPersonScanQR(txtLinename.Text.Trim(),Program.Dept))
            {
                CommonDAL.Instance.SetStatusLabels(lbe, "NG");
                return false;
            }
            if (string.IsNullOrEmpty(txtQRCode.Text.Trim()))
            {
				CommonDAL.Instance.SetStatusLabels(lbe, "NG");
				return false;
			}
            // Kiểm tra xem QR này đã được tạo trong csdl chưa
            var checkQR= SmtGeneralQrCodeDAL.Instance.checkExistQRCode(txtQRCode.Text.Trim(),cbModel.Text.Trim());
            var newLog = new EASTECH_ERROR_LOG_APPROVE
            {
                StaffID = Program.UserId,
                Dept = Program.Dept,
                LineName = txtLinename.Text.Trim(),
                CreatedDate = CommonDAL.Instance.getSqlServerDatetime(),
                QRCode = txtQRCode.Text.Trim()
            };

			if (checkQR!=null) // Đã được tạo trong csdl rồi
            {
                // Kiểm tra xem PCB có giống nhau không
                if (checkQR.PCBCode!=cbPcbCode.Text.Trim())
                {
					messageError = "Sai PCB hoặc sai QR code. Hãy Kiểm tra lại PCB Code không giống nhau giữa PCB Code và Setup QR Code : " + txtQRCode.Text;
                    newLog.ErrorDetail = messageError;
					newID = EASTECH_ERROR_LOG_APPROVE_DAL.Instance.AddReturnID(newLog);	
					Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
					frm.ShowDialog();
					CommonDAL.Instance.SetStatusLabels(lbe, "NG");
					return false;
				}
                else // Giống nhau thì ok
                {
                    // Kiểm tra xem đã được lưu lần nào vào csdl chưa?
                    var checkQrvsDept = SmtAOIQrCodeOutputDAL.Instance.checkQRCodeByDept(txtQRCode.Text.Trim(), Program.Dept);
                    if (checkQrvsDept!=null) // Đã có trong csdl rồi
                    {
                        // Kiểm tra xem có tích vào bắn 2 mặt không?
                        if (checkBox1.Checked==false) // Không tích vào bắn 2 mặt
                        {
							messageError = "Đã có dữ liệu trong hệ thống: " + txtQRCode.Text +
												  " Ngày tháng đã bắn " + checkQrvsDept.DateT;
                            newLog.ErrorDetail = messageError;
							CommonDAL.Instance.SetStatusLabels(lbe, "NG");
							newID = EASTECH_ERROR_LOG_APPROVE_DAL.Instance.AddReturnID(newLog);							
							Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
							frm.ShowDialog();
							return false;
						}
                        else // Nếu tích vào bắn mặt 2
                        {
                            var checkScan2Face = SmtAOIQrCodeOutputDAL.Instance.checkQRCodeScan2Face(txtQRCode.Text.Trim(), "2Face2");
                            if (checkScan2Face!=null) // 
                            {
								messageError = "Đã có dữ liệu QR mặt 2 trong hệ thống: " + txtQRCode.Text +
												  "Ngày tháng đã bắn " + checkScan2Face.DateT;
                                CommonDAL.Instance.SetStatusLabels(lbe, "NG");
								newLog.ErrorDetail = messageError;
								newID = EASTECH_ERROR_LOG_APPROVE_DAL.Instance.AddReturnID(newLog);								
								Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
								frm.ShowDialog();
								return false;
							}
                            else
                            {
								CommonDAL.Instance.SetStatusLabels(lbe, "OK");
                                //face2 = "2Face2";
							}
						}
                    }
                    else
                    {
						CommonDAL.Instance.SetStatusLabels(lbe, "OK");
                        //face2 = null;
					}
				}
            }
            else
            {				
				messageError = "Model: " + cbModel.Text + " Serial:  " + txtQRCode.Text + "Chưa được tạo trong csdl";
				newLog.ErrorDetail = messageError;
				newID = EASTECH_ERROR_LOG_APPROVE_DAL.Instance.AddReturnID(newLog);
				CommonDAL.Instance.SetStatusLabels(lbe, "NG");				
				Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
				frm.ShowDialog();				
				return false;
			}
			return true;
        }
        private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkQRCode())
                {                    
                    try
                    {
						txtQRCode.Enabled = false;
						SavetoDatabase();
						txtQRCode.Enabled = true;                        
						txtQRCode.Text = string.Empty;
						txtQRCode.Focus();
					}
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error detail: " + ex.Message,"Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtQRCode.Enabled = true;
						txtQRCode.Text = string.Empty;
						txtQRCode.Focus();
						return;
					}
                }
                else
                {
                    txtQRCode.Focus();
                }
				#region Old Code
                /*
				// Kiểm tra line name với bộ phận của người bắn phải cùng ở bộ phận
				if (!CheckPersonScanQR(txtLinename.Text.Trim(),Program.Dept))
                {
                    MessageBox.Show("Bạn đang ở bộ phận : "+ Program.Dept + " Không thể thực hiện công việc tại Line: " + txtLinename.Text.Trim(),
                        "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // =================================================================
                //txtQRCode.ReadOnly = true;
                //txtQRCode.Text = txtQRCode.Text.Trim().ToUpper();
                //txtQRCode.ReadOnly = true;
                txtQRCode.Enabled = false;
                if (txtQRCode.Text.Equals("") || string.IsNullOrEmpty(txtQRCode.Text))
                {
                    MessageBox.Show("Nhập mã QR code vào đây !!!","Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbe.Text = "NG";
                    lbe.ForeColor = System.Drawing.Color.Red;
                    txtQRCode.Enabled = true;
                    txtQRCode.Focus();
                    return;
                }
                else
                {
                    // Kiểm tra xem Mã QR này đã có trong csdl chưa? 
                    // cơ sở dữ liệu ở đây là csdl đã được tạo ra khi làm QRCode hay chưa?
                    var di = new DataTable();
                    di = General_Serial_Services.GeneralSerial_CheckSerial(txtQRCode.Text, cbModel.Text);
                    if (di.Rows.Count > 0)
                    {
                        // Kiểm tra xem PCB type vs PCB code có đúng không?
                        if (cbPcbCode.Text != di.Rows[0].Field<string>("PCBCode").ToString())
                        {
                            //MessageBox.Show("Sai PCB " + "\n"
                            //    +"Hãy Kiểm tra lại PCB Code không giống nhau giữa PCB Code và Setup QR Code",
                            //    "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            messageError = "Sai PCB hoặc sai QR code. Hãy Kiểm tra lại PCB Code không giống nhau giữa PCB Code và Setup QR Code : "+txtQRCode.Text;                                                      
                            newID=EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept,txtLinename.Text ,messageError, CommonDAL.Instance.getSqlServerDatetime(), txtQRCode.Text.Trim());
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();
                            Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
                            
                            frm.ShowDialog();
                            return;
                        }
                        else
                        {
                            // Kiểm tra QRCode này đã được bắn lần nào chưa???                            
                            var dt = new DataTable();
                            //dt = EastechOutputHistory_Services.EastechOutputHistory_Smt_CheckQRCode(txtQRCode.Text);
                            dt = EastechOutputHistory_Services.EastechHistory_smt_CheckQRCodeRemark(txtQRCode.Text, Program.Dept);
                            if (dt.Rows.Count > 0)
                            {
                                // Nếu đã được bắn 1 lần ở SMT rồi
                                // Kiểm tra xem có tích vào bắn 2 mặt không?
                                if (checkBox1.Checked == false)
                                {
                                    //MessageBox.Show("Đã có dữ liệu trong hệ thống, Lưu ý không update dữ liệu;  " + txtQRCode.Text + "\n" 
                                    //    +"Ngày tháng đã bắn " + dt.Rows[0].Field<DateTime>("DateT"),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    messageError = "Đã có dữ liệu trong hệ thống: " + txtQRCode.Text +
                                                   " Ngày tháng đã bắn " + dt.Rows[0].Field<DateTime>("DateT");
                                    lbe.Text = "NG";
                                    lbe.ForeColor = System.Drawing.Color.Red;                                   
                                    newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime(),txtQRCode.Text.Trim());
                                    txtQRCode.Enabled = true;
                                    txtQRCode.Clear();
                                    txtQRCode.Focus();
                                    Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);

                                    frm.ShowDialog();
                                    return ;
                                }
                                else
                                {
                                    // Nếu check vào mặt 2 thì cho bắn 1 lần.
                                    // Nếu checked==true thì ghi "2Face2" vào Remark4
                                    // sau đó kiểm tra xem nếu QR code này đã "2Face2" thì không cho bắn nữa.
                                    var dqrcode = new DataTable();
                                    //dqrcode = EastechOutputHistory_Services.EastechOutputHistory_Check2Face(txtQRCode.Text);
                                    // Kiểm tra xem QR code này đã bắn mặt 2 lần nào chưa
                                    dqrcode = EastechOutputHistory_Services.EastechOutputHistory_Check2FaceNew(txtQRCode.Text, "2Face2");
                                    //int n = 0;
                                    //n = dqrcode.Rows.Count;
                                    if (dqrcode.Rows.Count > 0) // đã bắn rồi
                                    {
                                        //MessageBox.Show("Đã có dữ liệu trong hệ thống, Lưu ý không update dữ liệu;" + txtQRCode.Text +"\n" 
                                        //    +"Ngày tháng đã bắn " + dqrcode.Rows[0].Field<DateTime>("DateT"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        messageError = "Đã có dữ liệu trong hệ thống: " + txtQRCode.Text +
                                                   "Ngày tháng đã bắn " + dt.Rows[0].Field<DateTime>("DateT");
                                        lbe.Text = "NG";
                                        lbe.ForeColor = System.Drawing.Color.Red;
                                       

                                        newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime(),txtQRCode.Text.Trim());
                                        txtQRCode.Enabled = true;
                                        txtQRCode.Clear();
                                        txtQRCode.Focus();
                                        Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);

                                        frm.ShowDialog();
                                        return;
                                    }
                                    else // chưa bắn
                                    {
                                        lbe.Text = "OK";
                                        lbe.ForeColor = System.Drawing.Color.Green;                                       
                                        SavetoDatabase();
										//drawChart(); // Update kết quả vẽ hình tròn
									}                                   
                                }
                            }
                            else
                            {
                                lbe.Text = "OK";
                                lbe.ForeColor = System.Drawing.Color.Green;                              
                                SavetoDatabase();
                               
                                //drawChart();// Update kết quả vẽ hình tròn

							}
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Model: " + txtModel.Text +"\n"
                        //                + " Serial:  " + txtQRCode.Text+ "\n"
                        //                + "Chưa được tạo trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        messageError = "Model: " + cbModel.Text + " Serial:  " + txtQRCode.Text + "Chưa được tạo trong csdl";
                        newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime(),txtQRCode.Text.Trim());
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        cbPcbCode.Focus();
                        Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
                        frm.ShowDialog();
                        return;
                    }
                }
                */
				#endregion
			}
		}
        private void SaveData(string li, string program, string lineName, System.DateTime datetime,List<EASTECH_SMT_OUTPUT> lstAdd, List<long> lstIdUpdate)
        {
			var lstProLineName = EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(program,lineName);
			var lstProgram = SmtProgramDAL.Instance.getListByPro(program);

			if (lstProgram.Count > 0 && lstProLineName.Count > 0)
			{
				var lstMeterial = EASTECH_PROGRAMHISTORY_DAL.Instance.getListMeterialAvailable(program,lineName);
				if (lstMeterial.Rows.Count > lstProgram.Count - 3)
				{
					foreach (DataRow row in lstMeterial.Rows)
					{
						var newData = new EASTECH_SMT_OUTPUT
						{
							QRCode = txtQRCode.Text.Trim(),
							programkey = txtProgram.Text.Trim(),
							Feeder = row["fdrno"].ToString(),
							LineName = txtLinename.Text.Trim(),
							Partcode = row["partscode"].ToString(),
							NDesc = row["ndesc"].ToString(),
							DateCode = row["datecode"].ToString(),
							usage = int.Parse(row["usage"].ToString()),
							DateT = datetime,
							Model = cbModel.Text.Trim(),
							Remark = lblchecker.Text,
							Remark1 = txtPcbType.Text,
							Remark2 = cbPcbCode.Text,
							Remark3 = lblDept.Text,
							Remark4 = null,
							Remark5 = null
						};
						lstIdUpdate.Add(long.Parse(row["Id"].ToString()));
						lstAdd.Add(newData);
					}
					string message = SmtAOIQrCodeOutputDAL.Instance.AddRangeAndUpdate(lstAdd, lstIdUpdate);
					if (string.IsNullOrEmpty(message))
					{
						ResetAll();
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + message,
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtQRCode.SelectAll();
						txtQRCode.Focus();
					}
				}
				else
				{
					MessageBox.Show("Thiếu : " + (lstProgram.Count - lstMeterial.Rows.Count) + " mã linh kiện",
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtQRCode.SelectAll();
					txtQRCode.Focus();
				}
			}
			else
			{
				MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtQRCode.SelectAll();
				txtQRCode.Focus();
			}
		}
        private void SavetoDatabase()
        {
            var lstIdUpdate = new List<long>();
			var lstAdd = new List<EASTECH_SMT_OUTPUT>();
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var newLog = new EASTECH_ERROR_LOG_APPROVE
			{
				StaffID = Program.UserId,
				Dept = Program.Dept,
				LineName = txtLinename.Text.Trim(),
				CreatedDate = CommonDAL.Instance.getSqlServerDatetime(),
				QRCode = txtQRCode.Text.Trim()
			};

			string li = "";
			li = txtLinename.Text.Substring(0, 2);
            if (li=="IN")
            {
    //            var lstProLineName=EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(txtProgram.Text.Trim(),txtLinename.Text.Trim());
				//var lstProgram = SmtProgramDAL.Instance.getListByPro(txtProgram.Text.Trim());
                if (lstProgram01.Count>0 && lstETHistory01.Count > 0)
                {
					var checkQrvsDept = SmtAOIQrCodeOutputDAL.Instance.checkQRCodeByDept(txtQRCode.Text.Trim(), "SMT");
                    if (checkQrvsDept==null)
                    {
						pictureBox2.Visible = true;
						Application.DoEvents();
						System.Threading.Thread.Sleep(300);
						pictureBox2.Visible = false;

						messageError = "QR Code Này chưa được bắn ở SMT!!!";
						newLog.ErrorDetail = messageError;
						newID = EASTECH_ERROR_LOG_APPROVE_DAL.Instance.AddReturnID(newLog);
						CommonDAL.Instance.SetStatusLabels(lbe, "NG");
						Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
						frm.ShowDialog();
                        return;					
					}
                    else
                    {
                        var lstMeterial=EASTECH_PROGRAMHISTORY_DAL.Instance.getListMeterialAvailable(txtProgram.Text.Trim(),txtLinename.Text.Trim());
                        if (lstMeterial.Rows.Count>lstProgram01.Count-3)
                        {                           
							foreach (DataRow row in lstMeterial.Rows)
							{
                                var newData = new EASTECH_SMT_OUTPUT
                                {
                                    QRCode = txtQRCode.Text.Trim(),
                                    programkey = txtProgram.Text.Trim(),
                                    Feeder = row["fdrno"].ToString(),
                                    LineName = txtLinename.Text.Trim(),
                                    Partcode = row["partscode"].ToString(),
                                    NDesc = row["ndesc"].ToString(),
                                    DateCode = row["datecode"].ToString(),
                                    usage = int.Parse(row["usage"].ToString()),
                                    DateT = datetime,
                                    Model = cbModel.Text.Trim(),
                                    Remark = lblchecker.Text,
                                    Remark1 = txtPcbType.Text,
                                    Remark2 = cbPcbCode.Text,
                                    Remark3 = lblDept.Text,
									Remark4 = checkBox1.Checked ? "2Face2" : null,
									Remark5 =null                                
                                };
                                lstIdUpdate.Add(long.Parse(row["Id"].ToString()));
								lstAdd.Add(newData);
							}
							string message=SmtAOIQrCodeOutputDAL.Instance.AddRangeAndUpdate(lstAdd, lstIdUpdate);
                            if (string.IsNullOrEmpty(message))
                            {
								ResetAll();
							}
                            else
                            {
								MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " +message
							   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
								txtQRCode.SelectAll();
								txtQRCode.Focus();
								return;
							}
						}
                        else
                        {
							MessageBox.Show("Thiếu : " + (lstProgram01.Count - lstMeterial.Rows.Count) + " mã linh kiện",
								   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							txtQRCode.SelectAll();
							txtQRCode.Focus();
							return;
						}
                    }
				}
                else
                {
					MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!"
						, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQRCode.SelectAll();
                    txtQRCode.Focus();
					return;
				}

			}
            if (li=="BM")
            {
				//var lstProLineName = EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(txtProgram.Text.Trim(), txtLinename.Text.Trim());
				//var lstProgram = SmtProgramDAL.Instance.getListByPro(txtProgram.Text.Trim());
                if (lstProgram01.Count > 0 && lstETHistory01.Count > 0)
                {
					var lstMeterial = EASTECH_PROGRAMHISTORY_DAL.Instance.getListMeterialAvailable(txtProgram.Text.Trim(), txtLinename.Text.Trim());
					if (lstMeterial.Rows.Count > lstProgram01.Count - 3)
					{
						foreach (DataRow row in lstMeterial.Rows)
						{
							var newData = new EASTECH_SMT_OUTPUT
							{
								QRCode = txtQRCode.Text.Trim(),
								programkey = txtProgram.Text.Trim(),
								Feeder = row["fdrno"].ToString(),
								LineName = txtLinename.Text.Trim(),
								Partcode = row["partscode"].ToString(),
								NDesc = row["ndesc"].ToString(),
								DateCode = row["datecode"].ToString(),
								usage = int.Parse(row["usage"].ToString()),
								DateT = datetime,
								Model = cbModel.Text.Trim(),
								Remark = lblchecker.Text,
								Remark1 = txtPcbType.Text,
								Remark2 = cbPcbCode.Text,
								Remark3 = lblDept.Text,
								Remark4 = checkBox1.Checked ? "2Face2" : null,
								Remark5 = null
							};
							lstIdUpdate.Add(long.Parse(row["Id"].ToString()));
							lstAdd.Add(newData);
						}
						string message = SmtAOIQrCodeOutputDAL.Instance.AddRangeAndUpdate(lstAdd, lstIdUpdate);
						if (string.IsNullOrEmpty(message))
						{
							ResetAll();
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + message
						   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtQRCode.SelectAll();
							txtQRCode.Focus();
							return;
						}
					}
					else
					{
						MessageBox.Show("Thiếu : " + (lstProgram01.Count - lstMeterial.Rows.Count) + " mã linh kiện",
							   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						txtQRCode.SelectAll();
						txtQRCode.Focus();
						return;
					}
				}
                else
                {
					MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!"
						, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtQRCode.SelectAll();
					txtQRCode.Focus();
					return;
				}
			}
            if (li == "TM")
            {
                //var lstProLineName = EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                //var lstProgram = SmtProgramDAL.Instance.getListByPro(txtProgram.Text.Trim());
                if (lstProgram01.Count > 0 && lstETHistory01.Count > 0)
                {
                    var lstMeterial = EASTECH_PROGRAMHISTORY_DAL.Instance.getListMeterialAvailable(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                    if (lstMeterial.Rows.Count > lstProgram01.Count - 3)
                    {
                        foreach (DataRow row in lstMeterial.Rows)
                        {
                            var newData = new EASTECH_SMT_OUTPUT
                            {
                                QRCode = txtQRCode.Text.Trim(),
                                programkey = txtProgram.Text.Trim(),
                                Feeder = row["fdrno"].ToString(),
                                LineName = txtLinename.Text.Trim(),
                                Partcode = row["partscode"].ToString(),
                                NDesc = row["ndesc"].ToString(),
                                DateCode = row["datecode"].ToString(),
                                usage = int.Parse(row["usage"].ToString()),
                                DateT = datetime,
                                Model = cbModel.Text.Trim(),
                                Remark = lblchecker.Text,
                                Remark1 = txtPcbType.Text,
                                Remark2 = cbPcbCode.Text,
                                Remark3 = lblDept.Text,
								Remark4 = checkBox1.Checked ? "2Face2" : null,
								Remark5 = null
                            };
                            lstIdUpdate.Add(long.Parse(row["Id"].ToString()));
                            lstAdd.Add(newData);
                        }
                        string message = SmtAOIQrCodeOutputDAL.Instance.AddRangeAndUpdate(lstAdd, lstIdUpdate);
                        if (string.IsNullOrEmpty(message))
                        {
                            if (string.IsNullOrEmpty(txtprogram2.Text.Trim()))
                            {
                                ResetAll();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + message
                           , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtQRCode.SelectAll();
                            txtQRCode.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thiếu : " + (lstProgram01.Count - lstMeterial.Rows.Count) + " mã linh kiện",
                               "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQRCode.SelectAll();
                        txtQRCode.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!"
                        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQRCode.SelectAll();
                    txtQRCode.Focus();
                    return;
                }
                if (!txtprogram2.Text.Equals(""))
                {
					//var lstProLineName02 = EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(txtprogram2.Text.Trim(), txtLinename.Text.Trim());
					//var lstProgram02 = SmtProgramDAL.Instance.getListByPro(txtprogram2.Text.Trim());
					if (lstProgram02.Count > 0 && lstETHistory02.Count > 0)
					{
						var lstMeterial = EASTECH_PROGRAMHISTORY_DAL.Instance.getListMeterialAvailable(txtprogram2.Text.Trim(), txtLinename.Text.Trim());
						if (lstMeterial.Rows.Count > lstProgram02.Count - 3)
						{
							foreach (DataRow row in lstMeterial.Rows)
							{
								var newData = new EASTECH_SMT_OUTPUT
								{
									QRCode = txtQRCode.Text.Trim(),
									programkey = txtprogram2.Text.Trim(),
									Feeder = row["fdrno"].ToString(),
									LineName = txtLinename.Text.Trim(),
									Partcode = row["partscode"].ToString(),
									NDesc = row["ndesc"].ToString(),
									DateCode = row["datecode"].ToString(),
									usage = int.Parse(row["usage"].ToString()),
									DateT = datetime,
									Model = cbModel.Text.Trim(),
									Remark = lblchecker.Text,
									Remark1 = txtPcbType.Text,
									Remark2 = cbPcbCode.Text,
									Remark3 = lblDept.Text,
									Remark4 = checkBox1.Checked ? "2Face2" : null,
									Remark5 = null
								};
								lstIdUpdate.Add(long.Parse(row["Id"].ToString()));
								lstAdd.Add(newData);
							}
							string message = SmtAOIQrCodeOutputDAL.Instance.AddRangeAndUpdate(lstAdd, lstIdUpdate);
							if (string.IsNullOrEmpty(message))
							{								
								ResetAll();								
							}
							else
							{
								MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + message
							   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
								txtQRCode.SelectAll();
								txtQRCode.Focus();
								return;
							}
						}
						else
						{
							MessageBox.Show("Thiếu : " + (lstProgram02.Count - lstMeterial.Rows.Count) + " mã linh kiện",
								   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							txtQRCode.SelectAll();
							txtQRCode.Focus();
							return;
						}
					}
					else
					{
						MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!"
							, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtQRCode.SelectAll();
						txtQRCode.Focus();
						return;
					}
				}
            }
		}


        private void SavetoDatabase_old()
        {

            string li = "";
            li = txtLinename.Text.Substring(0, 2);
            var saveOutput = new EastechOutputHistory_Info();
            saveOutput.QRCode = txtQRCode.Text;
            saveOutput.LineName = txtLinename.Text;
            saveOutput.Model = cbModel.Text;
            saveOutput.Remark = lblchecker.Text;
            saveOutput.Remark1 = txtPcbType.Text;
            saveOutput.Remark2 = cbPcbCode.Text;
            saveOutput.Remark3 = lblDept.Text;
            if (checkBox1.Checked == true)
            {
                saveOutput.Remark4 = "2Face2";
            }
            else
            {
                saveOutput.Remark4 = "";
            }
            saveOutput.Remark5 = "";

            if (li == "IN")
            {
                // Sau mỗi lần ghi dữ liệu thì nó sẽ tự động kiểm tra xem còn linh kiện không? nếu không còn
                DataTable dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, txtLinename.Text);
                // Đã check proceduce chạy nhanh 1

                if (Program.dtpro_1.Rows.Count > 0 && dt.Rows.Count > 0)
                {
                    // Kiểm tra xem dữ liệu đã được bắn ở SMT chưa??
                    // Nếu chưa được bắn ở SMT thì thông báo
                    var dg = new DataTable();
                    //dt = EastechOutputHistory_Services.EastechOutputHistory_Smt_CheckQRCode(txtQRCode.Text);
                    dg = EastechOutputHistory_Services.EastechHistory_smt_CheckQRCodeRemark(txtQRCode.Text, "SMT");
                    if (dg.Rows.Count < 1)
                    {
                        pictureBox2.Visible = true;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(300);
                        pictureBox2.Visible = false;
                       // MessageBox.Show("QR Code Này chưa được bắn ở SMT !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        messageError = "QR Code Này chưa được bắn ở SMT!!!";
                        newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime(), txtQRCode.Text.Trim());
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        txtQRCode.Focus();
                        Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
                        frm.ShowDialog();
                        return;
                    }
                    else
                    {
                        try
                        {
                            var getdt = new DataTable();
                            getdt = EastechOutputHistory_Services.EastechHistory_getSelectedData(txtProgram.Text, txtLinename.Text);
                            if (getdt.Rows.Count >= Program.dtpro_1.Rows.Count - 3)
                            {
                                string ids = "'";
                                foreach (DataRow row in getdt.Rows)
                                {
                                    ids = ids + row["Id"].ToString() + "','";
                                    saveOutput.programkey = txtProgram.Text;
                                    saveOutput.Feeder = row["fdrno"].ToString();
                                    saveOutput.Partcode = row["partscode"].ToString();
                                    saveOutput.NDesc = row["ndesc"].ToString();
                                    saveOutput.DateCode = row["datecode"].ToString();
                                    saveOutput.usage = row["usage"].ToString();
                                    EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                    EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                                }
                                //ids = ids.Substring(0, ids.Length - 2);
                                //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                                ResetAll();
                            }
                            else
                            {
                                MessageBox.Show("Thiếu nhiều linh kiện: " + (Program.dtpro_1.Rows.Count - getdt.Rows.Count) + " con",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //messageError = "Thiếu nhiều linh kiện:" + (Program.dtpro_1.Rows.Count - getdt.Rows.Count) + " con";                                 

                                txtQRCode.Enabled = true;
                                txtQRCode.Clear();
                                txtQRCode.Focus();

                                //newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime());
                                //Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
                                //frm.ShowDialog();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message
                                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        finally
                        {
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();                            
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!"
                        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQRCode.Enabled = true;
                    txtQRCode.Clear();
                    txtQRCode.Focus();
                    return;
                }
            }
            else if (li == "BM")
            {
                /* Lấy dữ liệu bắn được từ công nhân khi thay linh kiện với tên chương trình bên trên*/
                var dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, txtLinename.Text);
                // Kiểm tra xem cả 2 dữ liệu này đều >0 (nghãi là phải có dữ liệu thì mới làm)
                if (Program.dtpro_1.Rows.Count > 0 && dt.Rows.Count > 0)
                {
                    try
                    {
                        var getdt = new DataTable();
                        getdt = EastechOutputHistory_Services.EastechHistory_getSelectedData(txtProgram.Text, txtLinename.Text);
                        if (getdt.Rows.Count >= Program.dtpro_1.Rows.Count - 3)
                        {
                            
                            foreach (DataRow row in getdt.Rows)
                            {
                                //ids = ids + row["Id"].ToString() + "','";
                                saveOutput.programkey = txtProgram.Text;
                                saveOutput.Feeder = row["fdrno"].ToString();
                                saveOutput.Partcode = row["partscode"].ToString();
                                saveOutput.NDesc = row["ndesc"].ToString();
                                saveOutput.DateCode = row["datecode"].ToString();
                                saveOutput.usage = row["usage"].ToString();
                                EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                            }
                            //ids = ids.Substring(0, ids.Length - 2);
                            //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                            ResetAll();
                        }
                        else
                        {
                           MessageBox.Show("Thiếu nhiều linh kiện: " + (Program.dtpro_1.Rows.Count - getdt.Rows.Count) + " con",
                               "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //messageError = "Thiếu nhiều linh kiện:" + (Program.dtpro_1.Rows.Count - getdt.Rows.Count) + " con";
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();
                            //newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime());
                            //Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
                            //frm.ShowDialog();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message,
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    finally
                    {
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        txtQRCode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQRCode.Enabled = true;
                    txtQRCode.Clear();
                    txtQRCode.Focus();
                    return;
                }

            }
            else if (li == "TM")
            {
                var dgg = new DataTable();
                dgg = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, txtLinename.Text);

                if (Program.dtpro_1.Rows.Count > 0 && dgg.Rows.Count > 0)
                {
                    try
                    {
                        var getdt = new DataTable();
                        getdt = EastechOutputHistory_Services.EastechHistory_getSelectedData(txtProgram.Text, txtLinename.Text);
                        if (getdt.Rows.Count >= Program.dtpro_1.Rows.Count - 3)
                        {
                            string ids = "'";
                            foreach (DataRow row in getdt.Rows)
                            {
                                ids = ids + row["Id"].ToString() + "','";
                                saveOutput.programkey = txtProgram.Text;
                                saveOutput.Feeder = row["fdrno"].ToString();
                                saveOutput.Partcode = row["partscode"].ToString();
                                saveOutput.NDesc = row["ndesc"].ToString();
                                saveOutput.DateCode = row["datecode"].ToString();
                                saveOutput.usage = row["usage"].ToString();
                                EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                            }
                            //ids = ids.Substring(0, ids.Length - 2);
                            //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                            if (txtprogram2.Text.Equals(""))
                            {
                                ResetAll();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thiếu nhiều linh kiện: " + (Program.dtpro_1.Rows.Count - getdt.Rows.Count) + " con",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //messageError = "Thiếu nhiều linh kiện:" + (Program.dtpro_1.Rows.Count - getdt.Rows.Count) + " con";

                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();

                            //newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime());
                            //Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
                            //frm.ShowDialog();
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message, 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //finally
                    //{
                    //    txtQRCode.Enabled = true;
                    //    txtQRCode.Clear();
                    //    txtQRCode.Focus();
                    //}
                }
                else
                {
                    MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQRCode.Enabled = true;
                    txtQRCode.Clear();
                    txtQRCode.Focus();
                    return;
                }
                var dtt = new DataTable();
                dtt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtprogram2.Text, txtLinename.Text);

                if (!txtprogram2.Text.Equals(""))
                {
                    if (Program.dtpro_2.Rows.Count > 0 && dtt.Rows.Count > 0)
                    {
                        try
                        {
                            var getdt = new DataTable();
                            getdt = EastechOutputHistory_Services.EastechHistory_getSelectedData(txtprogram2.Text, txtLinename.Text);
                            if (getdt.Rows.Count >= Program.dtpro_2.Rows.Count - 3)
                            {
                                string ids = "'";
                                foreach (DataRow row in getdt.Rows)
                                {
                                    ids = ids + row["Id"].ToString() + "','";
                                    saveOutput.programkey = txtprogram2.Text;
                                    saveOutput.Feeder = row["fdrno"].ToString();
                                    saveOutput.Partcode = row["partscode"].ToString();
                                    saveOutput.NDesc = row["ndesc"].ToString();
                                    saveOutput.DateCode = row["datecode"].ToString();
                                    saveOutput.usage = row["usage"].ToString();
                                    EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                    EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                                }

                                //ids = ids.Substring(0, ids.Length - 2);
                                //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                                ResetAll();
                            }
                            else
                            {
                                MessageBox.Show("Thiếu nhiều linh kiện: " + (Program.dtpro_1.Rows.Count - getdt.Rows.Count) + " con",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //messageError = "Thiếu nhiều linh kiện:" + (Program.dtpro_2.Rows.Count - getdt.Rows.Count) + " con";
                                txtQRCode.Enabled = true;
                                txtQRCode.Clear();
                                txtQRCode.Focus();

                                //newID = EastechOutputHistory_Services.EastechErrorLog(Program.UserId, Program.Dept, txtLinename.Text, messageError, CommonDAL.Instance.getSqlServerDatetime());
                                //Smt.Output.frmCheckOutputErrorAndApprove frm = new Smt.Output.frmCheckOutputErrorAndApprove(this);
                                //frm.ShowDialog();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //finally
                        //{
                        //    txtQRCode.Enabled = true;
                        //    txtQRCode.Clear();
                        //    txtQRCode.Focus();
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        txtQRCode.Focus();
                        return;
                    }
                }

            }

        }

		private void iconbtnKeyIn_Click(object sender, EventArgs e)
		{
            frmAOIErrorRecord frm= new frmAOIErrorRecord();
            frm.ShowDialog();
		}

		// Vẽ chart hình trong thể hiện % NG và % OK
		private void CreatePieChart2(string title, Control controlPie, string ChartName, double percentOK,double percentNG)
		{
			// Assuming 'datatable' is your DataTable

			// Create a Chart control
			Chart chart1 = new Chart();
			chart1.Size = new System.Drawing.Size(300,200);
			chart1.ChartAreas.Add(ChartName);
			chart1.Series.Clear();  // Clear any existing series


			// Add a new series
			chart1.Series.Add("Trang thái sản phẩm");
			chart1.Series["Trang thái sản phẩm"].Points.AddXY("OK", percentOK);
			chart1.Series["Trang thái sản phẩm"].Points.AddXY("NG", percentNG);

			//chart1.Titles.Add("Tỷ lệ OK/NG");
			chart1.Titles.Add(title);
			chart1.Legends.Add("Legend");
			chart1.Legends["Legend"].Docking = Docking.Bottom;
			chart1.Series["Trang thái sản phẩm"].IsValueShownAsLabel = true;
			chart1.Series["Trang thái sản phẩm"].ChartType = SeriesChartType.Pie;
			controlPie.Controls.Add(chart1);

		}
        private void drawChart()
        {
            try
            {
				string result = SMT_AOI_ERROR_RECORD_DAL.Instance.GetTotalCounts(txtProgram.Text.Trim(), txtprogram2.Text.Trim());
				char[] separator = { ';' };
				string[] kq = result.Split(separator);
				//float percentOK = float.Parse(result[0].ToString());
				//float percentNG = float.Parse(result[1].ToString());
				//double percentOK = Math.Round(((double)(float.Parse(result[0].ToString()) - float.Parse(result[1].ToString())) / float.Parse(result[0].ToString())) * 100, 2);
				//double percentNG = Math.Round(((double)float.Parse(result[1].ToString()) / float.Parse(result[0].ToString())) * 100, 2);
				double percentOK = Math.Round((double)((float.Parse(kq[0].ToString()) - float.Parse(kq[1].ToString())) / float.Parse(kq[0].ToString())) * 100, 2);
				double percentNG = Math.Round((double)(float.Parse(kq[1].ToString()) / float.Parse(kq[0].ToString())) * 100, 2);
				flowLayoutPanel1.Controls.Clear();
				CreatePieChart2("Tỷ lệ OK /NG", flowLayoutPanel1, "Persen", percentOK, percentNG);
			}
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi vẽ biểu đồ: " + ex.Message,"Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

		}

		
	}
}
