using DocumentFormat.OpenXml.Math;
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
using UnidenDAL.AssyLine;
using UnidenDAL.AssyLine.MENU;
using UnidenDTO;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace SMTPRORAM.AssyLine.MENU
{
	public partial class frmCBCheckData : Form
	{
		private int chkdboxcarton;
		private int chkunit;
		private  string[] achkunit;
		private System.DateTime[] datetime;
		private bool Check_All;
		private int achk = 0;
		private string Remark1 = "";
		private int ctn = 0;
		private string select;


		private int icount = 0;
		private int jcount = 0;
		private int hcount = 0;
		private int kcount = 0;
		private string[] temp1 = new string[100];
		private string[] temp2 = new string[100];
		public frmCBCheckData()
		{
			InitializeComponent();
		}

		private void frmCBCheckData_Load(object sender, EventArgs e)
		{
			// Không hiển thị NG OK khi khởi tạo Form
			pBoxNg01.Visible = false;
			pBoxNg02.Visible = false;
			pBoxNg03.Visible = false;
			pBoxNg04.Visible = false;
			pBoxNg05.Visible = false;

			pBoxOk01.Visible = false;
			pBoxOk02.Visible = false;
			pBoxOk03.Visible = false;
			pBoxOk04.Visible = false;
			pBoxOk05.Visible = false;

			lbl1.Visible = false;
			lblCarton.Visible = false;
			lblbatch.Visible = false;
			lblCarton.Text= string.Empty;
			lblbatch.Text = string.Empty;

			grCarton.Enabled = false;
			Auto_Ctn.Enabled = false;

			CHECK_MODEL.Enabled = false;
			txtBatch.Enabled = false;
			DBOX_SERIAL.Enabled = false;
			INPUT_SERIAL.Enabled = false;
			CHECK_SERIAL.Enabled = false;
			CHECK_SERIAL2.Enabled = false;			
			CTN_TXT.Enabled = true;
			chkNew.Enabled = true;
			chkRework.Enabled = true;
			btBatch.Enabled = false;

			grside.Enabled = false;
			groupBox1.Enabled = false;
			Program.Auto_number = 0;
			chkNew.Focus();

		}
		private void LoadLot()
		{
			cbLot.DataSource = CBSETTING_DAL.Instance.listLots();
			cbLot.DisplayMember = "Lot";
			cbLot.ValueMember = "Lot";
		}

		private void txtLine_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtLine.Text.Trim()))
			{
				MessageBox.Show("Hãy tên điền LINE trước khi chọn LOT ");
				txtLine.Focus();
				return;
			}
			else
			{
				LoadLot();
				txtLine.Enabled = false;
				cbLot.Focus();
			}
		}		

		private void cbLot_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbLot.SelectedItem is groupLot selectedLot)
			{
				if (selectedLot.Lot.Equals("--Select--"))
				{
					MessageBox.Show("Hãy chọn đúng LOT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					cbLot.Focus();
					return;
				}
				else
				{
					var checkLot = CBSETTING_DAL.Instance.getInfoByLot(selectedLot.Lot);
					if (checkLot != null)
					{
						CheckCartonNumber(txtLine.Text.Trim(), cbLot.Text.Substring(0, 6));
						txtModel.Text = checkLot.MODEL;
						txtModelSerial.Text=checkLot.MODEL_SERIAL;
						txtDboxSerial.Text = checkLot.DBOX_SERIAL;
						txtUnits.Text = (checkLot.UNIT_DBOX * checkLot.DBOX_CARTON).ToString();

						chkdboxcarton = checkLot.DBOX_CARTON;
						chkunit = checkLot.UNIT_DBOX * checkLot.DBOX_CARTON;

						// Khai báo 2 biến toàn cục để lưu trữ dữ liệu
						achkunit = new string[chkunit];
						datetime = new System.DateTime[chkunit];

						if (checkLot.CHECK_TYPE == "2.Check All (Carton/Dbox/Unit)")
						{
							Check_All = true;
							grside.Enabled = true;
							// grside.Enabled = false;
							//SendKeys.Send("{TAB}");
							txtLine.Enabled = false;
							cbSelect.Focus();
							//cbSelect.Text = "Two-side carton / Hai mặt carton";
							cbLot.Enabled = false;
						}
						else
						{
							Check_All = false;
							cbSelect.Text = "One-side carton / Một mặt carton";
							grside.Enabled = false;
							label10.Visible = false;
							label11.Visible = false;
							label9.Visible = false;
							INPUT_SERIAL.Visible = false;
							CHECK_SERIAL.Visible = false;
							CHECK_SERIAL2.Visible = false;
						}
					}
				}
			}
		}

		private void cbAuto_Manual_SelectedValueChanged(object sender, EventArgs e)
		{
			cbLot.Enabled = false;
			if (cbAuto_Manual.Text == "Auto / Điền số tự động")
			{
				achk = 1;
				if (Remark1 == "New")
				{
					grCarton.Enabled = true;
					CTN_TXT.Enabled = true;
					CTN_TXT.Text = (ctn + 1).ToString();
					CTN_TXT.Focus();
					DialogResult r = MessageBox.Show("Bạn có muốn thiết lập số bắt đầu không???", "Xác Nhận", MessageBoxButtons.YesNo);
					if (r == DialogResult.Yes)
					{
						grCarton.Enabled = true;
						CTN_TXT.Enabled = true;
						//int x = 0;
						//Int32.TryParse(CTN_TXT.Text, out x);
						//Program.Auto_number = x;
						CTN_TXT.Focus();
						CTN_TXT.SelectAll();
					}
					else
					{
						//CTN_TXT.Text = (Program.Auto_number + 1).ToString();
						txtBatch.Enabled = true;
						txtBatch.Focus();
						//CHECK_MODEL.Enabled = true;
						//CHECK_MODEL.Focus();
						Auto_Ctn.Enabled = false;
					}
				}
				else
				{
					grCarton.Enabled = true;
					CTN_TXT.Enabled = true;
					CTN_TXT.Focus();
				}

			}
			else
			{
				achk = 0;
				CHECK_MODEL.Enabled = false;
				grCarton.Enabled = true;
				CTN_TXT.Enabled = true;
				CTN_TXT.Focus();
			}
		}

		private void CTN_TXT_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(CTN_TXT.Text.Trim()))
			{
				DialogResult result = MessageBox.Show("Bạn có muốn chọn lại không???", "Xác nhận", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					cbAuto_Manual.Focus();
				}
				else
				{
					CTN_TXT.Focus();
				}
			}
			else
			{
				// Kiểm tra số carton đã có trong scdl chưa??? ( bao gồm cả new và rework)
				
				string Keys = cbLot.Text.Substring(0, 6).ToUpper() + int.Parse(CTN_TXT.Text.Trim()).ToString() + Remark1;
				var checkKey = CBSAVEDATA_DAL.Instance.checkKey(Keys);
				if (checkKey != null)
				{
					if (Remark1=="New")
					{
						MessageBox.Show("Số Carton này đã có trong CSDL");
						CTN_TXT.Focus();
						CTN_TXT.SelectAll();
					}
					else
					{
						grCarton.Enabled = false;
						//SendKeys.Send("{TAB}");
						txtBatch.Enabled = true;
						txtBatch.Focus();
						btBatch.Enabled = true;
						//CHECK_MODEL.Enabled = true;
						//CHECK_MODEL.Focus();
						Auto_Ctn.Enabled = false;
					}
				}
				else
				{
					grCarton.Enabled = false;
					//SendKeys.Send("{TAB}");
					txtBatch.Enabled = true;
					btBatch.Enabled = true;
					txtBatch.Focus();
					//CHECK_MODEL.Enabled = true;
					//CHECK_MODEL.Focus();
					Auto_Ctn.Enabled = false;
				}				
			}
		}

		private void CTN_TXT_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Không cho phép nhập các ký tự không phải là số
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private void CTN_TXT_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (string.IsNullOrEmpty(CTN_TXT.Text.Trim()))
				{
					DialogResult result = MessageBox.Show("Bạn có muốn chọn lại không???", "Xác nhận", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						cbAuto_Manual.Focus();
					}
					else
					{
						CTN_TXT.Focus();
					}
				}
				else
				{
					// Kiểm tra số carton đã có trong scdl chưa??? ( bao gồm cả new và rework)

					string Keys = cbLot.Text.Substring(0, 6).ToUpper() + int.Parse(CTN_TXT.Text.Trim()).ToString() + Remark1;
					var checkKey = CBSAVEDATA_DAL.Instance.checkKey(Keys);
					if (checkKey != null)
					{
						if (Remark1 == "New")
						{
							MessageBox.Show("Số Carton này đã có trong CSDL");
							CTN_TXT.Focus();
							CTN_TXT.SelectAll();
						}
						else
						{
							grCarton.Enabled = false;
							//SendKeys.Send("{TAB}");
							txtBatch.Enabled = true;
							txtBatch.Focus();
							btBatch.Enabled = true;
							//CHECK_MODEL.Enabled = true;
							//CHECK_MODEL.Focus();
							Auto_Ctn.Enabled = false;
						}
					}
					else
					{
						grCarton.Enabled = false;
						//SendKeys.Send("{TAB}");
						txtBatch.Enabled = true;
						btBatch.Enabled = true;
						txtBatch.Focus();
						//CHECK_MODEL.Enabled = true;
						//CHECK_MODEL.Focus();
						Auto_Ctn.Enabled = false;
					}
				}
			}	
		}

		private void CHECK_MODEL_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{				
				if (CHECK_MODEL.Text.Trim().Equals(txtModelSerial.Text.Trim()))
				{
					pBoxOk01.Visible = true;
					pBoxNg01.Visible = false;
					DBOX_SERIAL.Enabled = true;
					CHECK_MODEL.Enabled = false;
				}
				else
				{
					pBoxNg01.Visible = true;
					pBoxOk01.Visible = false;
					CHECK_MODEL.Text = "NHẬP SAI !!!!";
					CHECK_MODEL.Focus();
					CHECK_MODEL.SelectAll();
				}

			}
		}

		private void DBOX_SERIAL_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (DBOX_SERIAL.Text.Trim().Equals(txtDboxSerial.Text.Trim()))
				{
					icount = icount + 1;
					pBoxOk02.Visible = true;
					pBoxNg02.Visible = false;
					//INPUT_SERIAL.Enabled = true;
					DBOX_SERIAL.Text = "Check DBOX: (" + icount + " / " + chkdboxcarton + " ) OK.";
					DBOX_SERIAL.SelectAll();
					if (icount >= chkdboxcarton)
					{
						if (Check_All == true)
						{
							DBOX_SERIAL.Enabled = false;
							INPUT_SERIAL.Enabled = true;
							INPUT_SERIAL.Focus();
						}
						else
						{
							//SAVE_DATA.Enabled = true;
							//SAVE_DATA.Focus();
							//SendKeys.Send("{ENTER}");
							SAVE_DATA();
						}

					}
				}
				else
				{
					pBoxNg02.Visible = true;
					pBoxOk02.Visible = false;
					DBOX_SERIAL.Text = "NHẬP SAI !!!!";
					DBOX_SERIAL.Focus();
					DBOX_SERIAL.SelectAll();

				}

			}
		}

		private void INPUT_SERIAL_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{				
				if (string.IsNullOrEmpty(INPUT_SERIAL.Text.Trim()))
				{
					INPUT_SERIAL.Text = "NHẬP SAI SỐ SERIAL";
					INPUT_SERIAL.Focus();
					INPUT_SERIAL.SelectAll();
				}
				else
				{
					// Kiểm tra xem Lot và số serial này đã có trong csdl chưa? 
					//string search = "";
					//CBSaveData_Info sf = new CBSaveData_Info();
					//sf.Keys2 = cbLot.Text.Substring(0, 6).ToUpper() + INPUT_SERIAL.Text.Trim().ToUpper() + Program.Remark1;

					string Keys2 = cbLot.Text.Substring(0, 6).ToUpper() + INPUT_SERIAL.Text.Trim().ToString() + Remark1;
					var checkKey2 = CBSAVEDATA_DAL.Instance.checkKey2(Keys2);

					//DataTable dt = new DataTable();

					//sf.Lot = cbLot.Text.ToUpper();
					//search = INPUT_SERIAL.Text.Trim().ToUpper();
					//sf.Unit_Serial = INPUT_SERIAL.Text.Trim().ToUpper();
					//sf.Carton = CTN_TXT.Text;


					// xử lý hàng rework nhiều lần                       
					//dt = CBSaveData_Service.CBSaveData_GetByLotSerial(sf);
					if (checkKey2 !=null)
					{
						//add neww 2019/01/22                        
						if (Remark1 == "ReWork")
						{
							int ck = 0;
							for (int i = 0; i <= jcount; i++)
							{
								if (achkunit[i] == INPUT_SERIAL.Text.Trim())
								{
									pBoxNg03.Visible = true;
									pBoxOk03.Visible = false;
									INPUT_SERIAL.Text = "TRÙNG TEM SỐ!!!";
									INPUT_SERIAL.Focus();
									INPUT_SERIAL.SelectAll();
									ck = 1;
									break;
								}
							}
							// Nếu kiểm tra mà không có trong csdl và không nhập trùng thì lưu vào mảng dữ liệu
							if (ck == 0)
							{
								achkunit[jcount] = INPUT_SERIAL.Text.ToUpper().Trim();
								datetime[jcount] = CommonDAL.Instance.getSqlServerDatetime();
								jcount = jcount + 1;
								pBoxNg03.Visible = false;
								pBoxOk03.Visible = true;
								INPUT_SERIAL.Text = "INPUT OK: (" + jcount + "/" + chkunit + ") Units";
								INPUT_SERIAL.Focus();
								INPUT_SERIAL.SelectAll();
							}

						}
						//-------------------------------

						else
						{
							pBoxNg03.Visible = true;
							pBoxOk03.Visible = false;
							INPUT_SERIAL.Text = "TRÙNG TEM SỐ!!!";
							INPUT_SERIAL.Focus();
							INPUT_SERIAL.SelectAll();
						}

					}
					// Nếu chưa có thì kiểm tra tiếp xem đã nhập lần nào mới chưa?
					else
					{
						int ck = 0;
						for (int i = 0; i <= jcount; i++)
						{
							if (achkunit[i] == INPUT_SERIAL.Text.Trim())
							{
								pBoxNg03.Visible = true;
								pBoxOk03.Visible = false;
								INPUT_SERIAL.Text = "TRÙNG TEM SỐ!!!";
								INPUT_SERIAL.Focus();
								INPUT_SERIAL.SelectAll();
								ck = 1;
								break;
							}
						}
						// Nếu kiểm tra mà không có trong csdl và không nhập trùng thì lưu vào mảng dữ liệu
						if (ck == 0)
						{
							achkunit[jcount] = INPUT_SERIAL.Text.Trim();
							datetime[jcount] = CommonDAL.Instance.getSqlServerDatetime();
							jcount = jcount + 1;
							pBoxNg03.Visible = false;
							pBoxOk03.Visible = true;
							INPUT_SERIAL.Text = "INPUT OK: (" + jcount + "/" + chkunit + ") Units";
							INPUT_SERIAL.Focus();
							INPUT_SERIAL.SelectAll();
						}

					}

					if (jcount >= chkunit)
					{
						INPUT_SERIAL.Enabled = false;
						CHECK_SERIAL.Enabled = true;
						CHECK_SERIAL.Focus();
					}
				}

			}
		}

		private void CHECK_SERIAL_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{				
				if (string.IsNullOrEmpty(CHECK_SERIAL.Text.Trim()))
				{
					CHECK_SERIAL.Focus();
					CHECK_SERIAL.SelectAll();					
				}
				else
				{
					int ck = 0;
					for (int i = 0; i < chkunit; i++)
					{
						if (achkunit[i] == CHECK_SERIAL.Text.Trim())
						{
							ck = 1;
							break;
						}
					}
					if (ck == 1)
					{
						if (hcount > 0)
						{
							int kh = 0;
							for (int j = 0; j < hcount; j++)
							{
								if (temp1[j] == CHECK_SERIAL.Text.Trim())
								{
									kh = 1;
									break;
								}
							}
							if (kh == 1)
							{
								pBoxNg04.Visible = true;
								pBoxOk04.Visible = false;
								CHECK_SERIAL.Text = "TRÙNG SERIAL !!!";
								CHECK_SERIAL.Focus();
								CHECK_SERIAL.SelectAll();
							}
							else
							{
								pBoxNg04.Visible = false;
								pBoxOk04.Visible = true;
								temp1[hcount] = CHECK_SERIAL.Text.Trim().ToUpper();
								hcount = hcount + 1;
								CHECK_SERIAL.Text = "CHECK OK: (" + hcount + "/" + chkunit + ") Units";
								CHECK_SERIAL.Focus();
								CHECK_SERIAL.SelectAll();
							}

						}
						else
						{
							pBoxNg04.Visible = false;
							pBoxOk04.Visible = true;
							temp1[hcount] = CHECK_SERIAL.Text.Trim().ToUpper();
							hcount = hcount + 1;
							CHECK_SERIAL.Text = "CHECK OK: (" + hcount + "/" + chkunit + ") Units";
							CHECK_SERIAL.Focus();
							CHECK_SERIAL.SelectAll();
						}
					}
					else
					{
						pBoxNg04.Visible = true;
						pBoxOk04.Visible = false;
						CHECK_SERIAL.Text = "SAI SERIAL !!!";
						DialogResult r = MessageBox.Show("Bạn có muốn làm lại tất cả không ???", "Xác Nhận", MessageBoxButtons.YesNo);
						if (r == DialogResult.Yes)
						{
							INPUT_SERIAL.Text = "";
							INPUT_SERIAL.Enabled = true;
							CHECK_SERIAL.Text = "";
							CHECK_SERIAL.Enabled = false;
							INPUT_SERIAL.Focus();
							achkunit = new string[chkunit];
							jcount = 0;
							hcount = 0;
						}
						else
						{
							//hcount = 0;
							CHECK_SERIAL.Focus();
							CHECK_SERIAL.SelectAll();
						}

					}
					if (hcount >= chkunit)
					{
						if (select == "Two-side carton / Hai mặt carton")
						{
							CHECK_SERIAL.Enabled = false;
							CHECK_SERIAL2.Enabled = true;
							CHECK_SERIAL2.Focus();
						}
						else
						{
							CHECK_SERIAL.Enabled = false;
							//SAVE_DATA.Enabled = true;
							//SAVE_DATA.Focus();
							//SendKeys.Send("{ENTER}");
							SAVE_DATA();
						}

					}
				}

			}
		}

		private void CHECK_SERIAL2_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{				
				if (string.IsNullOrEmpty(CHECK_SERIAL2.Text.Trim()))
				{
					CHECK_SERIAL2.Text = "NHẬP SAI SỐ SERIAL";
					CHECK_SERIAL2.Focus();
					CHECK_SERIAL2.SelectAll();

				}
				else
				{
					int ck = 0;
					for (int i = 0; i < chkunit; i++)
					{
						if (achkunit[i] == CHECK_SERIAL2.Text.Trim())
						{
							ck = 1;
							break;
						}
					}
					if (ck == 1)
					{
						if (kcount > 0)
						{
							int kh = 0;
							for (int j = 0; j < kcount; j++)
							{
								if (temp2[j] == CHECK_SERIAL2.Text.Trim())
								{
									kh = 1;
									break;
								}
							}
							if (kh == 1)
							{
								pBoxNg05.Visible = true;
								pBoxOk05.Visible = false;
								CHECK_SERIAL2.Text = "TRÙNG SERIAL !!!";
								CHECK_SERIAL2.Focus();
								CHECK_SERIAL2.SelectAll();
							}
							else
							{
								pBoxNg05.Visible = false;
								pBoxOk05.Visible = true;
								temp2[kcount] = CHECK_SERIAL2.Text.Trim();
								kcount = kcount + 1;
								CHECK_SERIAL2.Text = "CHECK OK: (" + kcount + "/" + chkunit + ") Units";
								CHECK_SERIAL2.Focus();
								CHECK_SERIAL2.SelectAll();
							}

						}
						else
						{
							pBoxNg05.Visible = false;
							pBoxOk05.Visible = true;
							temp2[kcount] = CHECK_SERIAL2.Text.Trim();
							kcount = kcount + 1;
							CHECK_SERIAL2.Text = "CHECK OK: (" + kcount + "/" + chkunit + ") Units";
							if (kcount >= 6)
							{
								CHECK_SERIAL2.Enabled = false;
								//SAVE_DATA.Enabled = true;
								//SAVE_DATA.Focus();
								//SendKeys.Send("{ENTER}");
								SAVE_DATA();
							}
							CHECK_SERIAL2.Focus();
							CHECK_SERIAL2.SelectAll();
						}
					}
					else
					{
						pBoxNg05.Visible = true;
						pBoxOk05.Visible = false;
						CHECK_SERIAL2.Text = "SAI SERIAL !!!";
						CHECK_SERIAL2.Focus();
						CHECK_SERIAL2.SelectAll();
					}
					if (kcount >= chkunit)
					{
						CHECK_SERIAL2.Enabled = false;
						//SAVE_DATA.Enabled = true;
						//SAVE_DATA.Focus();
						//SendKeys.Send("{ENTER}");
						SAVE_DATA();
					}
				}

			}
		}
		private void SAVE_DATA()
		{			
			lblbatch.Text = "";
			lblCarton.Text = "";
			if (select == "Two-side carton / Hai mặt carton")
			{		
				var lstAddNew=new List<UVASSY_CBSAVEDATA>();
				var datecreate = CommonDAL.Instance.getSqlServerDatetime();
				for (int i = 0; i < chkunit; i++)
				{
					var saveData = new UVASSY_CBSAVEDATA
					{
						Line= txtLine.Text.Trim(),
						Lot= cbLot.Text.Substring(0, 6),
						Model= txtModel.Text.Trim(),
						Unit_Carton=int.Parse(txtUnits.Text.Trim()),
						Model_Serial=txtModelSerial.Text.Trim() + "--->" + CHECK_MODEL.Text,
						Carton=int.Parse(CTN_TXT.Text.Trim()),
						PackingID=null,
						Dbox_Serial= txtDboxSerial.Text.Trim() + "--->" + DBOX_SERIAL.Text,
						Remark = Remark1,
						Keys = cbLot.Text.Substring(0, 6).ToUpper() + CTN_TXT.Text.Trim() + Remark1,
						BatchNo = txtBatch.Text.Trim(),
						ChangeBatchTo =null,
						ErrorDetail=null,
						ErrorStatus="OK",
						Unit_Serial = achkunit[i].ToString(),
						Keys2 = cbLot.Text.Substring(0, 6).ToUpper() + achkunit[i].ToString() + Remark1,
						Date_Time = datetime[i],
						CreatedBy=Program.UserId,
						CreatedDate= datecreate
					};
					lstAddNew.Add(saveData);					
				}
				string message=CBSAVEDATA_DAL.Instance.AddRange(lstAddNew);
				if (string.IsNullOrEmpty(message))
				{
					Reset01();
					CommonDAL.Instance.ShowDataGridView(dgView, CBSAVEDATA_DAL.Instance.LoadDataByLotvsUser(cbLot.Text.Trim(), txtLine.Text.Trim(), Program.UserId, txtModelSerial.Text.Trim(), txtDboxSerial.Text.Trim()));
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra trong khi lưu dữ liệu: " + message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				// Reset về mặc định				
				
			}
			else
			{				
				var lstAddNew = new List<UVASSY_CBSAVEDATA>();
				var datecreate = CommonDAL.Instance.getSqlServerDatetime();
				for (int i = 0; i < chkunit; i++)
				{
					var saveData = new UVASSY_CBSAVEDATA
					{
						Line = txtLine.Text.Trim(),
						Lot = cbLot.Text.Substring(0, 6),
						Model = txtModel.Text.Trim(),
						Unit_Carton = int.Parse(txtUnits.Text.Trim()),
						Model_Serial = txtModelSerial.Text.Trim() + "--->" + CHECK_MODEL.Text,
						Carton = int.Parse(CTN_TXT.Text.Trim()),
						PackingID = null,
						Dbox_Serial = txtDboxSerial.Text.Trim() + "--->" + DBOX_SERIAL.Text,
						Remark = Remark1,
						Keys = cbLot.Text.Substring(0, 6).ToUpper() + CTN_TXT.Text.Trim() + Remark1,
						BatchNo = txtBatch.Text.Trim(),
						ChangeBatchTo = Remark1 == "ReWork" ? "OK":null,
						ErrorDetail = null,
						ErrorStatus = "OK",

						Unit_Serial = Check_All==true? achkunit[i].ToString() : "CHECK_DBOX_" + (i + 1),
						Keys2 = Check_All == true ? cbLot.Text.Substring(0, 6).ToUpper() + achkunit[i].ToString() + Remark1: cbLot.Text.Substring(0, 6).ToUpper() + "CHECK_DBOX_" + (i + 1) + Remark1,
						Date_Time = datetime[i],

						CreatedBy = Program.UserId,
						CreatedDate = datecreate
					};
					lstAddNew.Add(saveData);
				}
				string message = CBSAVEDATA_DAL.Instance.AddRange(lstAddNew);
				if (string.IsNullOrEmpty(message))
				{
					Reset02();
					CommonDAL.Instance.ShowDataGridView(dgView, CBSAVEDATA_DAL.Instance.LoadDataByLotvsUser(cbLot.Text.Trim(), txtLine.Text.Trim(), Program.UserId, txtModelSerial.Text.Trim(), txtDboxSerial.Text.Trim()));
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra trong khi lưu dữ liệu: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				// Reset về mặc định			
				
			}
		}

		private void Reset01()
		{
			icount = 0;
			jcount = 0;
			hcount = 0;
			kcount = 0;
			CHECK_MODEL.Text = "";
			DBOX_SERIAL.Text = "";
			INPUT_SERIAL.Text = "";
			CHECK_SERIAL.Text = "";
			CHECK_SERIAL2.Text = "";

			pBoxNg01.Visible = false;
			pBoxNg02.Visible = false;
			pBoxNg03.Visible = false;
			pBoxNg04.Visible = false;
			pBoxNg05.Visible = false;

			pBoxOk01.Visible = false;
			pBoxOk02.Visible = false;
			pBoxOk03.Visible = false;
			pBoxOk04.Visible = false;
			pBoxOk05.Visible = false;

			chkNew.Enabled = false;
			chkRework.Enabled = false;

			lbl1.Visible = false;
			lblCarton.Visible = false;

			string[] temp1 = new string[100];
			string[] temp2 = new string[100];
			if (achk == 1)
			{
				CTN_TXT.Text = (int.Parse(CTN_TXT.Text.Trim()) + 1).ToString();
				CHECK_MODEL.Enabled = true;
				CHECK_MODEL.Focus();
			}
			else
			{
				grCarton.Enabled = true;
				CTN_TXT.Enabled = true;
				CTN_TXT.Text = "";
				CTN_TXT.Focus();
				//CHECK_MODEL.Enabled = true;
			}
		}
		private void Reset02()
		{
			icount = 0;
			jcount = 0;
			hcount = 0;
			kcount = 0;
			CHECK_MODEL.Text = "";
			DBOX_SERIAL.Text = "";
			INPUT_SERIAL.Text = "";
			CHECK_SERIAL.Text = "";
			CHECK_SERIAL2.Text = "";

			pBoxNg01.Visible = false;
			pBoxNg02.Visible = false;
			pBoxNg03.Visible = false;
			pBoxNg04.Visible = false;
			pBoxNg05.Visible = false;

			pBoxOk01.Visible = false;
			pBoxOk02.Visible = false;
			pBoxOk03.Visible = false;
			pBoxOk04.Visible = false;
			pBoxOk05.Visible = false;

			lbl1.Visible = false;
			lblCarton.Visible = false;

			chkNew.Enabled = false;
			chkRework.Enabled = false;
			string[] temp1 = new string[100];
			string[] temp2 = new string[100];
			if (achk == 1)
			{
				CTN_TXT.Text = (int.Parse(CTN_TXT.Text.Trim()) + 1).ToString();
				CHECK_MODEL.Enabled = true;
				CHECK_MODEL.Focus();
				DBOX_SERIAL.Enabled = false;
			}
			else
			{
				grCarton.Enabled = true;
				DBOX_SERIAL.Enabled = false;
				CTN_TXT.Enabled = true;
				CTN_TXT.Text = "";
				CTN_TXT.Focus();
			}
		}

		private void cbSelect_SelectedValueChanged(object sender, EventArgs e)
		{
			//One-side carton / Một mặt carton
			//Two-side carton / Hai mặt carton
			if (string.IsNullOrEmpty(cbSelect.Text.Trim()))
			{
				MessageBox.Show("Hãy lựa chọn ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			if (cbSelect.Text == "Two-side carton / Hai mặt carton")
			{
				select = "Two-side carton / Hai mặt carton";
				Auto_Ctn.Enabled = true;
				grside.Enabled = false;
				CHECK_SERIAL2.Visible = true;
				//txtLine.Enabled = false;                   
				SendKeys.Send("{ENTER}");
				cbAuto_Manual.Focus();
				//cbLot.Enabled = false;
			}
			else
			{
				select = "One-side carton / Một mặt carton";
				Auto_Ctn.Enabled = true;
				label11.Visible = false;
				grside.Enabled = false;
				CHECK_SERIAL2.Visible = false;
				//txtLine.Enabled = false;                   
				SendKeys.Send("{ENTER}");
				cbAuto_Manual.Focus();
				//cbLot.Enabled = false;
			}
		}

		private void chkNew_Click(object sender, EventArgs e)
		{
			if (chkNew.Checked == true)
			{
				chkRework.Checked = false;
				Remark1 = "New";
				groupBox1.Enabled = true;
				chkNew.Enabled = false;
				chkRework.Enabled = false;
			}
			else
			{
				chkRework.Checked = true;
				Remark1 = "ReWork";

				groupBox1.Enabled = true;
				chkNew.Enabled = false;
				chkRework.Enabled = false;
			}
		}

		private void chkRework_Click(object sender, EventArgs e)
		{
			if (chkRework.Checked == true)
			{
				chkNew.Checked = false;
				Remark1 = "ReWork";

				groupBox1.Enabled = true;
				chkNew.Enabled = false;
				chkRework.Enabled = false;
			}
			else
			{
				chkNew.Checked = true;
				Remark1 = "New";

				groupBox1.Enabled = true;
				chkNew.Enabled = false;
				chkRework.Enabled = false;
			}
		}
		private void CheckCartonNumber(string Line, string Lot)
		{
			if (chkNew.Checked == true)
			{				
				try
				{
					int x;
					x = CBSAVEDATA_DAL.Instance.getMaxCartonNumber(Lot,Line);
					lbl1.Visible = true;
					lblCarton.Visible = true;
					lblCarton.Text = x.ToString();
					var checkBatch = CBSAVEDATA_DAL.Instance.checkBatch(Lot, Line, x);
					lblbatch.Text = checkBatch.BatchNo.ToString();
					ctn = x;

				}
				catch (Exception exx)
				{
					ctn = 0;
					MessageBox.Show("Đã có lỗi xảy ra: " + exx.Message);
					return;
				}
			}
		}

		private void btBatch_Click(object sender, EventArgs e)
		{
			txtBatch.Enabled = true;
			txtBatch.Focus();
			txtBatch.SelectAll();
		}
		private void CheckBatch()
		{			
			if (string.IsNullOrEmpty(txtBatch.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập số Batch");
				txtBatch.Focus();
				txtBatch.SelectAll();
			}
			else
			{
				CHECK_MODEL.Enabled = true;
				CHECK_MODEL.Focus();
				txtBatch.Enabled = false;
			}
		}

		private void txtBatch_Validating(object sender, CancelEventArgs e)
		{
			CheckBatch();
		}

		private void txtBatch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				CheckBatch();
			}			
		}
	}
}
