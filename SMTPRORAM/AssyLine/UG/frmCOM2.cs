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
using UnidenDAL.AssyLine.UG;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.UG
{
	public partial class frmCOM2 : Form
	{
		private string startnum = "";
		private string endnum = "";
		private string nr1 = "";
		private bool automanual = false;
		private int ctn = 0;
		private int unit = 0;
		private string[] chkdbox;
		private DateTime[] datetime;
		private string[] temp;
		private int jcount = 0;
		private int hcount = 0;
		private int icount = 0;
		private int mcount = 0;
		private int kcount = 0;
		private string dboxbarcode = "";
		private string cartonbarcode = "";
		public frmCOM2()
		{
			InitializeComponent();
		}
		private void ResetInput()
		{
			cbNewRework.Focus();
			cbLot.Enabled = false;
			txtLine.Enabled = false;
			cbCartonNumber.Enabled = false;
			txtCarton.Enabled = false;
			txtBatchno.Enabled = false;
			txtDbox.Enabled = false;
			txtChkSerial.Enabled = false;
			txtChkDbox.Enabled = false;
			//txtChkDbox2.Enabled = false;
			txtChkCtn.Enabled = false;			
			btBatchNo.Enabled = true;
			//checkBox1.Enabled = true;

			pb1OK.Visible = false;
			pb2OK.Visible = false;
			pb3OK.Visible = false;
			pb4OK.Visible = false;
			//pb5OK.Visible = false;

			pb1NG.Visible = false;
			pb2NG.Visible = false;
			pb3NG.Visible = false;
			pb4NG.Visible = false;
			//pb5NG.Visible = false;
		}
		private void frmCOM2_Load(object sender, EventArgs e)
		{
			lblBatchNo.Text =string.Empty;
			lblCarton.Text =string.Empty;
			
			ResetInput();
		}

		private void LoadLot()
		{
			cbLot.DataSource=MODEL_DAL.Instance.listLots();
			cbLot.DisplayMember = "Lot";
			cbLot.ValueMember = "Lot";
		}

		private void cbNewRework_SelectedValueChanged(object sender, EventArgs e)
		{
			/*
             * 1. Làm Hàng Mới (NEW)
               2. Sửa Lại Hàng (ReWork)
             */
			if (string.IsNullOrEmpty(cbNewRework.Text.Trim()))
			{
				MessageBox.Show("Hãy lựa chọn LÀM MỚI hay LÀM LẠI","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				cbNewRework.Focus();
				return;
			}
			else
			{
				LoadLot();
				if (cbNewRework.Text == "1. Làm Hàng Mới (NEW)")
				{
					//MessageBox.Show("Selected:  " + cbNewRework.Text);
					nr1 = "New";
					cbLot.Enabled = true; 					;
					cbLot.Focus();
					cbNewRework.Enabled = false;
				}
				else
				{
					nr1 = "ReWork";
					cbLot.Enabled = true;					
					cbLot.Focus();
					cbNewRework.Enabled = false;
					//MessageBox.Show("Selected:  " + cbNewRework.Text);
				}
			}

			//MessageBox.Show("Selected:  " + cbNewRework.Text);
		}

		private void cbLot_SelectedValueChanged(object sender, EventArgs e)
		{			
			
			if (cbLot.Text.Equals("--Select--"))
			{
				MessageBox.Show("Hãy Nhập LOT vào đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				cbLot.Focus();
				return;
			}
			else
			{
				//
				// Kiểm tra xem LOT này có cần qua COM 1 hay không????
				if (chkUG325.Checked) // Phải có trong COM 1 thì mới bắn được
				{
					// Kiểm tra xem lot này đã được làm ở COM1 chưa?
					var checkCOM1 = COM1_DAL.Instance.checkExistLot(cbLot.Text.Trim());

					if (checkCOM1==null)
					{
						MessageBox.Show("LOT này hiện chưa có trong COM1 \n" +
							"Phải nhập dữ liệu COM1 trước.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
						cbLot.Focus();
						cbLot.SelectAll();
						return;
					}
					else
					{
						var checkLotControl=LOTCONTROL_DAL.Instance.checkExistLot(cbLot.Text.Trim());						
						if (checkLotControl!=null)
						{
							txtModel.Text =checkLotControl.Model;
							txtUnitCnt.Text = checkLotControl.UnitCtn.ToString();
							startnum = checkLotControl.Start_Number;
							endnum = checkLotControl.End_Number;
							dboxbarcode = checkLotControl.Dbox_Barcode;
							cartonbarcode = checkLotControl.Carton_Barcode;

							
							chkdbox = new string[checkLotControl.UnitCtn];
							datetime = new DateTime[checkLotControl.UnitCtn];
							temp = new string[checkLotControl.UnitCtn];

							cbNewRework.Enabled = false;
							txtLine.Enabled = true;
							txtLine.Focus();
							cbLot.Enabled = false;
						}
						else
						{
							MessageBox.Show("LOT này chưa được setup trong LOT CONTROL");
							cbLot.Focus();							
							cbNewRework.Enabled = false;
							return;
						}
					}
				}
				else
				{
					var checkLotControl = LOTCONTROL_DAL.Instance.checkExistLot(cbLot.Text.Trim());
					if (checkLotControl!=null)
					{
						txtModel.Text = checkLotControl.Model;
						txtUnitCnt.Text = checkLotControl.UnitCtn.ToString();
						startnum = checkLotControl.Start_Number;
						endnum = checkLotControl.End_Number;
						dboxbarcode = checkLotControl.Dbox_Barcode;
						cartonbarcode = checkLotControl.Carton_Barcode;


						chkdbox = new string[checkLotControl.UnitCtn];
						datetime = new DateTime[checkLotControl.UnitCtn];
						temp = new string[checkLotControl.UnitCtn];

						cbNewRework.Enabled = false;
						txtLine.Enabled = true;
						txtLine.Focus();
						cbLot.Enabled = false;
					}
					else
					{
						MessageBox.Show("LOT này chưa được setup trong LOT CONTROL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						cbLot.Focus();
						cbNewRework.Enabled = false;
						return;
					}
				}
			}
			
		}

		private void txtLine_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{				
				if (string.IsNullOrEmpty(txtLine.Text.Trim()))
				{
					MessageBox.Show("Hãy Nhập tên LINE vào đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtLine.Focus();
					return;
				}
				else
				{
					if (nr1 == "New")
					{
						// Lấy số carton hiện có theo line, lot và theo loại làm new hay là rework
						// Nếu đã làm ở đây rồi thì số carton sẽ tự tăng lên 1 đơn vị, làm lần đầu thì số carton sẽ là 1
						var maxCTN=COM2_DAL.Instance.getMaxCTN(txtLine.Text.Trim(),cbLot.Text,nr1);
						ctn = maxCTN;
					
						lblCarton.Visible = true;
						lblCarton.Text = maxCTN.ToString();						
						if (maxCTN <= 0)
						{
							lblBatchNo.Text = "Chưa có BATCH ";
						}
						else
						{
							var getBatchNo=COM2_DAL.Instance.getBatchNumber(txtLine.Text.Trim(),cbLot.Text,maxCTN,nr1);
							lblBatchNo.Text = getBatchNo.BatchNo.ToString();
						}
					}
					cbCartonNumber.Enabled = true;
					cbCartonNumber.Focus();
					txtLine.Enabled = false;
				}

			}
		}

		private void cbCartonNumber_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cbCartonNumber.Text.Trim()))
			{
				MessageBox.Show("Hãy lựa chọn hình thức nhập số CARTON","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				cbCartonNumber.Focus();
				return;
			}
			else
			{
				// 1. Auto Number
				// 2. Manual Number
				if (cbCartonNumber.Text == "1. Auto Number")
				{
					automanual = true;
					if (nr1 == "New")
					{
						txtCarton.Text = (ctn + 1).ToString();
						DialogResult r = MessageBox.Show("Bạn có muốn thiết lập số bắt đầu không???", "Xác Nhận", MessageBoxButtons.YesNo);
						if (r == DialogResult.Yes)
						{
							txtCarton.Enabled = true;
							txtCarton.Focus();
							txtCarton.SelectAll();
						}
						else
						{
							// Kiểm tra xem số này đã có trong csdl chưa???						
							var checkCarton = COM2_DAL.Instance.checkExistCartonByLot(cbLot.Text, int.Parse(txtCarton.Text.Trim()));
							if (checkCarton!=null)
							{
								if (nr1 == "New")
								{
									MessageBox.Show("Số Carton này đã có trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
									txtCarton.Enabled = true;
									txtCarton.Focus();
									txtCarton.SelectAll();
								}
								else
								{
									txtBatchno.Enabled = true;
									txtBatchno.Focus();
									txtCarton.Enabled = false;
									cbCartonNumber.Enabled = false;
								}
							}
							else
							{
								txtBatchno.Enabled = true;
								txtBatchno.Focus();
								txtCarton.Enabled = false;
								cbCartonNumber.Enabled = false;
							}
						}
					}
					else
					{
						txtBatchno.Enabled = false;
						txtCarton.Enabled = true;
						txtCarton.Focus();
						txtCarton.SelectAll();
					}
				}
				else
				{
					automanual = false;
					txtBatchno.Enabled = false;
					txtCarton.Enabled = true;
					txtCarton.Focus();
					txtCarton.SelectAll();
				}

			}
		}

		private void txtCarton_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{				
				// Kiểm tra xem số này đã có trong csdl chưa???						
				var checkCarton = COM2_DAL.Instance.checkExistCartonByLot(cbLot.Text, int.Parse(txtCarton.Text.Trim()));
				if (checkCarton!=null)
				{
					if (nr1 == "New")
					{
						MessageBox.Show("Số Carton này đã có trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtCarton.Focus();
						txtCarton.SelectAll();
						return;
					}
					else
					{
						if (string.IsNullOrEmpty(txtBatchno.Text.Trim()))
						{
							txtBatchno.Enabled = true;
							txtBatchno.Focus();
							txtCarton.Enabled = false;
							cbCartonNumber.Enabled = false;
						}
						else
						{
							// Kiểm tra số batch + số carton + Lot + rework nếu có rồi thì nhập số carton khác							
							var checkCombine=COM2_DAL.Instance.checkCombine(txtBatchno.Text.Trim(),int.Parse(txtCarton.Text.Trim()),cbLot.Text, nr1);
							if (checkCombine!=null)
							{
								MessageBox.Show("Số CARTON đã nhập rồi, Bạn phải nhập số CARTON khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
								txtCarton.Focus();
								txtCarton.SelectAll();
							}
							else
							{
								txtCarton.Enabled = false;
								cbCartonNumber.Enabled = false;
								txtDbox.Enabled = true;
								txtDbox.Focus();
							}

						}

					}

				}
				else
				{
					if (txtBatchno.Text != "")
					{
						txtDbox.Enabled = true;
						txtDbox.Focus();
						txtCarton.Enabled = false;
						cbCartonNumber.Enabled = false;
					}
					else
					{
						txtBatchno.Enabled = true;
						txtBatchno.Focus();
						txtCarton.Enabled = false;
						cbCartonNumber.Enabled = false;
					}

				}
			}
		}

		private void txtBatchno_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{				
				if (string.IsNullOrEmpty(txtBatchno.Text.Trim()))
				{
					MessageBox.Show("Hãy nhập số BATCH vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtBatchno.Focus();
					return;
				}
				else
				{
					// Kiểm tra xem Batch này đã có trong LOT này chưa????
					if (nr1 == "New")
					{
						var checkBatch=COM2_DAL.Instance.checkExistBatchByLot(cbLot.Text,txtBatchno.Text.Trim());
						if (checkBatch!=null)
						{
							if (chkBatchNo.Checked == false)
							{
								MessageBox.Show("BATCH này đã có trong LOT: " + cbLot.Text + " Nếu muốn nhập BATCH này hãy check vào LÀM TIẾP", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								txtBatchno.Focus();
								txtBatchno.SelectAll();
								return;
							}
							else
							{
								txtBatchno.Enabled = false;
								txtDbox.Enabled = true;
								txtDbox.Focus();
							}

						}
						else
						{
							txtBatchno.Enabled = false;
							txtDbox.Enabled = true;
							txtDbox.Focus();
						}
					}
					else
					{
						// Cần kiểm tra xem cùng 1 lot, số carton, batch và là hàng rework thì số carton không thể trùng nhau????

						// Chú ý là phải làm hết số carton mới được dừng chuyền nếu không sẽ không nhập được dữ liệu						
						var checkCombine = COM2_DAL.Instance.checkCombine(txtBatchno.Text.Trim(), int.Parse(txtCarton.Text.Trim()), cbLot.Text, nr1);
						if (checkCombine!=null)
						{
							DialogResult r = MessageBox.Show("Đã có số CARTON và BATCH này trong csdl ReWork, Bạn có muốn nhập số BATCH khác không???", "Xác Nhận", MessageBoxButtons.YesNo);
							if (r == DialogResult.Yes)
							{
								txtBatchno.Focus();
								txtBatchno.SelectAll();
							}
							else
							{
								txtBatchno.Text = "";
								txtBatchno.Enabled = false;
								txtCarton.Enabled = true;
								txtCarton.Focus();
								txtCarton.SelectAll();
							}
						}
						else
						{
							txtBatchno.Enabled = false;
							txtDbox.Enabled = true;
							txtDbox.Focus();
						}
						//---------------------------------------------------------------------------------------------------------
					}

				}
			}
		}

		private void btBatchNo_Click(object sender, EventArgs e)
		{
			txtBatchno.Enabled = true;
			txtBatchno.Text = "";
			txtBatchno.Focus();
			chkBatchNo.Checked = false;
		}

		private void txtDbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{		
				#region Kiểm tra với hàng UG325/UG328 ...
				if (chkUG325.Checked)
				{
					// check với COM1 Xem dữ liệu đã có chưa??? 
					// Check với dữ liệu COM2 xem đã có chưa??? Nếu có rồi mà là Rework thì bỏ qua( trường hợp rework nhiều lần).					
					var checkDboxCom1= COM1_DAL.Instance.checkDboxCom1(txtDbox.Text.Trim(),cbLot.Text.Trim());
					if (checkDboxCom1==null)
					{
						MessageBox.Show("Dữ liệu này chưa được nhập trong COM1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtDbox.Focus();
						txtDbox.SelectAll();
					}
					else
					{
						// Check xem trong COM2 đã có dữ liệu này chưa????						
						var checkDboxCom2=COM2_DAL.Instance.checkDboxCom2(txtDbox.Text.Trim(), cbLot.Text.Trim());
						if (checkDboxCom2!=null)
						{
							if (nr1 == "ReWork")
							{
								int ck = 0;
								for (int i = 0; i <= jcount; i++)
								{
									if (chkdbox[i] == txtDbox.Text)
									{
										pb1NG.Visible = true;
										pb1OK.Visible = false;
										txtDbox.Text = "TRÙNG SỐ DBOX!!!";
										txtDbox.Focus();
										txtDbox.SelectAll();
										ck = 1;
										break;
									}
								}
								// Nếu kiểm tra mà không có trong csdl và không nhập trùng thì lưu vào mảng dữ liệu
								if (ck == 0)
								{
									chkdbox[jcount] = txtDbox.Text;
									datetime[jcount] = CommonDAL.Instance.getSqlServerDatetime();
									jcount = jcount + 1;
									pb1NG.Visible = false;
									pb1OK.Visible = true;
									txtDbox.Text = "INPUT OK: (" + jcount + "/" + unit + ") Units";
									txtDbox.Focus();
									txtDbox.SelectAll();
								}
							}
							else
							{
								pb1NG.Visible = true;
								pb1OK.Visible = false;
								txtDbox.Text = "SỐ DBOX ĐÃ CÓ!!!";
								txtDbox.Focus();
								txtDbox.SelectAll();
							}
						}
						else
						{
							#region Kiểm tra dữ liệu xem có nhập trùng không
							// Lưu DBOX vào mảng và kiểm tra xem có nhập trùng không???
							int ck = 0;
							for (int i = 0; i <= jcount; i++)
							{
								if (chkdbox[i] == txtDbox.Text)
								{
									pb1NG.Visible = true;
									pb1OK.Visible = false;
									txtDbox.Text = "TRÙNG SỐ DBOX !!!";
									txtDbox.Focus();
									txtDbox.SelectAll();
									ck = 1;
									break;
								}
							}
							// Nếu kiểm tra mà không có trong csdl và không nhập trùng thì lưu vào mảng dữ liệu
							if (ck == 0)
							{
								chkdbox[jcount] = txtDbox.Text.ToUpper().Trim();
								datetime[jcount] = CommonDAL.Instance.getSqlServerDatetime();
								jcount = jcount + 1;
								pb1NG.Visible = false;
								pb1OK.Visible = true;
								txtDbox.Text = "INPUT OK: (" + jcount + "/" + unit + ") DBOXs";
								txtDbox.Focus();
								txtDbox.SelectAll();
							}
							#endregion
						}
						if (jcount >= unit)
						{
							txtDbox.Enabled = false;
							txtChkSerial.Enabled = true;
							txtChkSerial.Focus();
						}
					}

				}
				#endregion
				#region Kiểm tra với hàng UG57...
				else
				{
					// Check với LOT CONTROL xem dữ liệu có nằm trong khoảng thiết lập không???                       
					if (txtDbox.TextLength > startnum.Length || txtDbox.TextLength > endnum.Length)
					{
						MessageBox.Show("Nhập sai dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtDbox.Focus();
						txtDbox.SelectAll();
						return;
					}
					else
					{
						// Check xem trong COM2 đã có dữ liệu này chưa????						
						var checkDboxCom2 = COM2_DAL.Instance.checkDboxCom2(txtDbox.Text.Trim(), cbLot.Text.Trim());
						if (checkDboxCom2!=null)
						{
							if (nr1 == "ReWork")
							{
								int ck = 0;
								for (int i = 0; i <= jcount; i++)
								{
									if (chkdbox[i] == txtDbox.Text)
									{
										pb1NG.Visible = true;
										pb1OK.Visible = false;
										txtDbox.Text = "TRÙNG SỐ DBOX!!!";
										txtDbox.Focus();
										txtDbox.SelectAll();
										ck = 1;
										break;
									}
								}
								// Nếu kiểm tra mà không có trong csdl và không nhập trùng thì lưu vào mảng dữ liệu
								if (ck == 0)
								{
									chkdbox[jcount] = txtDbox.Text;
									datetime[jcount] = CommonDAL.Instance.getSqlServerDatetime();
									jcount = jcount + 1;
									pb1NG.Visible = false;
									pb1OK.Visible = true;
									txtDbox.Text = "INPUT OK: (" + jcount + "/" + unit + ") Units";
									txtDbox.Focus();
									txtDbox.SelectAll();
								}
							}
							else
							{
								pb1NG.Visible = true;
								pb1OK.Visible = false;
								txtDbox.Text = "SỐ DBOX ĐÃ CÓ!!!";
								txtDbox.Focus();
								txtDbox.SelectAll();
							}

						}
						else
						{
							string s1 = ""; string e1 = "";
							s1 = startnum.Substring(0, 5).ToString();
							e1 = txtDbox.Text.Trim().Substring(0, 5);
							if (s1 != e1)
							{
								MessageBox.Show("Dữ liệu nhập vào không giống với dữ liệu đã được thiết lập:  " + s1);
								txtDbox.Focus();
								txtDbox.SelectAll();
							}
							else
							{
								int nums; int nume;
								Int32.TryParse(startnum.Substring(5, 6), out nums);
								Int32.TryParse(endnum.Substring(5, 6), out nume);
								int numdbox;
								Int32.TryParse(txtDbox.Text.Trim().Substring(5, 6).ToString(), out numdbox);
								if (numdbox < nums || numdbox > nume)
								{
									MessageBox.Show("Số DBOX nằm ngoài khoảng thiết lập của LOT CONTROL");
									txtDbox.Focus();
									txtDbox.SelectAll();
								}
								else
								{
									#region Kiểm tra dữ liệu xem có nhập trùng không
									// Lưu DBOX vào mảng và kiểm tra xem có nhập trùng không???
									int ck = 0;
									for (int i = 0; i <= jcount; i++)
									{
										if (chkdbox[i] == txtDbox.Text)
										{
											pb1NG.Visible = true;
											pb1OK.Visible = false;
											txtDbox.Text = "TRUNG SỐ DBOX !!!";
											txtDbox.Focus();
											txtDbox.SelectAll();
											ck = 1;
											break;
										}
									}
									// Nếu kiểm tra mà không có trong csdl và không nhập trùng thì lưu vào mảng dữ liệu
									if (ck == 0)
									{
										chkdbox[jcount] = txtDbox.Text.ToUpper().Trim();
										datetime[jcount] = CommonDAL.Instance.getSqlServerDatetime();
										jcount = jcount + 1;
										pb1NG.Visible = false;
										pb1OK.Visible = true;
										txtDbox.Text = "INPUT OK: (" + jcount + "/" + unit + ") DBOXs";
										txtDbox.Focus();
										txtDbox.SelectAll();
									}
									#endregion
								}

							}
						}
						if (jcount >= unit)
						{
							txtDbox.Enabled = false;
							txtChkSerial.Enabled = true;
							txtChkSerial.Focus();
						}
					}
				}
				#endregion
				
			}	
		}

		private void txtChkSerial_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (string.IsNullOrEmpty(txtChkSerial.Text.Trim()))
				{
					MessageBox.Show("Phải nhập dữ liệu vào đây");
					txtChkSerial.Focus();
					txtChkSerial.SelectAll();
					return;
				}
				else
				{
					int ck = 0;
					for (int i = 0; i < unit; i++)
					{
						if (chkdbox[i] == txtChkSerial.Text.Trim())
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
								if (temp[j] == txtChkSerial.Text)
								{
									kh = 1;
									break;
								}
							}
							if (kh == 1)
							{
								pb2NG.Visible = true;
								pb2OK.Visible = false;
								txtChkSerial.Text = "TRÙNG SERIAL !!!";
								txtChkSerial.Focus();
								txtChkSerial.SelectAll();
							}
							else
							{
								pb2NG.Visible = false;
								pb2OK.Visible = true;
								temp[hcount] = txtChkSerial.Text;
								hcount = hcount + 1;
								txtChkSerial.Text = "CHECK OK: (" + hcount + "/" + unit + ") Units";
								txtChkSerial.Focus();
								txtChkSerial.SelectAll();
							}

						}
						else
						{
							pb2NG.Visible = false;
							pb2OK.Visible = true;
							temp[hcount] = txtChkSerial.Text;
							hcount = hcount + 1;
							txtChkSerial.Text = "CHECK OK: (" + hcount + "/" + unit + ") Units";
							txtChkSerial.Focus();
							txtChkSerial.SelectAll();
						}
					}
					else
					{
						pb2NG.Visible = true;
						pb2OK.Visible = false;
						txtChkSerial.Text = "SAI SERIAL !!!";
						//DialogResult r = MessageBox.Show("Bạn có muốn làm lại tất cả không ???", "Xác Nhận", MessageBoxButtons.YesNo);
						//if (r == DialogResult.Yes)
						//{
						//    INPUT_SERIAL.Text = "";
						//    INPUT_SERIAL.Enabled = true;
						//    CHECK_SERIAL.Text = "";
						//    CHECK_SERIAL.Enabled = false;
						//    INPUT_SERIAL.Focus();
						//    Program.achkunit = new string[Program.chkunit];
						//    jcount = 0;
						//    hcount = 0;
						//}
						//else
						//{
						//hcount = 0;
						txtChkSerial.Focus();
						txtChkSerial.SelectAll();
						//}

					}
					if (hcount >= unit)
					{
						//if (Program.select == "Two-side carton / Hai mặt carton")
						//{
						//    CHECK_SERIAL.Enabled = false;
						//    CHECK_SERIAL2.Enabled = true;
						//    CHECK_SERIAL2.Focus();
						//}
						//else
						//{
						txtChkSerial.Enabled = false;
						txtChkDbox.Enabled = true;
						txtChkDbox.Focus();
						//SAVE_DATA.Enabled = true;
						//SAVE_DATA.Focus();
						//SendKeys.Send("{ENTER}");
						//}

					}
				}
			}
		}

		private void txtChkDbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (txtChkDbox.Text.Trim().Equals(dboxbarcode))
				{
					icount = icount + 1;
					pb3OK.Visible = true;
					pb3NG.Visible = false;

					txtChkDbox.Text = "Check DBOX: (" + icount + " / " + unit + " ) OK.";
					txtChkDbox.SelectAll();
					if (icount >= unit)
					{
						// 2022/10/06 check thêm mặt 2 của dbox
						//if (checkBox1.Checked==true)
						//{
						//    txtChkDbox2.Enabled = true;
						//    txtChkDbox2.Focus();
						//    txtChkDbox.Enabled = false;
						//}
						//else
						//{ 
						txtChkCtn.Enabled = true;
						txtChkCtn.Focus();
						txtChkDbox.Enabled = false;
						//}
					}
				}
				else
				{
					pb3NG.Visible = true;
					pb3OK.Visible = false;
					txtChkDbox.Text = "NHẬP SAI !!!!";
					txtChkDbox.Focus();
					txtChkDbox.SelectAll();
				}
			}
		}

		private void txtChkCtn_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				txtChkCtn.Text = txtChkCtn.Text.Trim().ToUpper();
				if (txtChkCtn.Text == cartonbarcode)
				{
					pb4OK.Visible = true;
					pb4NG.Visible = false;					
					txtChkCtn.Enabled = false;
					SAVEDATA();
				}
				else
				{
					pb4NG.Visible = true;
					pb4OK.Visible = false;
					txtChkCtn.Text = "NHẬP SAI !!!!";
					txtChkCtn.Focus();
					txtChkCtn.SelectAll();

				}
			}
		}

		private void SAVEDATA()
		{
			lblBatchNo.Text = "";
			lblCarton.Text = "";
			var lstAddNews= new List<UVASSY_COM2>();
			
			for (int i = 0; i < unit; i++)
			{
				var addNewCom2 = new UVASSY_COM2
				{
					Lot = cbLot.Text,
					Line = txtLine.Text.Trim(),
					Remark3 = txtModel.Text.Trim(),
					Per_Ctn = int.Parse(txtUnitCnt.Text.Trim()),
					Ctn_No = int.Parse(txtCarton.Text.Trim()),
					Option2 = Program.UserId,

					Dbox_Barcode = dboxbarcode,
					Ctn_Code = txtChkCtn.Text.Trim(),
					Remark1 = nr1,
					Remark2 = null,
					ErrorDetail = null,
					ChangeBatchTo = null,
					ErrorStatus = "OK",
					CreatedBy = Program.UserId,
					Dbox_No = chkdbox[i].ToString(),
					CreatedDate = datetime[i]
				};		
				lstAddNews.Add(addNewCom2);				
			}
			string message= COM2_DAL.Instance.AddRange(lstAddNews);
			if (string.IsNullOrEmpty(message))
			{
				RestSave();
				CommonDAL.Instance.ShowDataGridView(dgView,
					COM2_DAL.Instance.GetAllByUser(Program.UserId, cbLot.Text));
			}
			else
			{
				MessageBox.Show("Đã có lỗi xảy ra trong quá trình lưu dữ liệu: \n " +message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}			
		}
		private void RestSave()
		{
			// Reset về mặc định
			icount = 0; jcount = 0; hcount = 0; kcount = 0; mcount = 0;
			txtDbox.Text = "";
			txtChkSerial.Text = "";
			txtChkDbox.Text = "";
			//txtChkDbox2.Text = "";
			txtChkCtn.Text = "";

			pb1NG.Visible = false;
			pb1OK.Visible = false;
			pb2NG.Visible = false;
			pb2OK.Visible = false;
			pb3NG.Visible = false;
			pb3OK.Visible = false;
			pb4NG.Visible = false;
			pb4OK.Visible = false;
			//pb5NG.Visible = false;
			//pb5OK.Visible = false;

			chkBatchNo.Checked = false;

			temp = new string[unit];
			chkdbox = new string[unit];
			datetime = new DateTime[unit];

			if (cbCartonNumber.Text == "1. Auto Number")
			{
				int x;
				Int32.TryParse(txtCarton.Text, out x);
				txtCarton.Text = (x + 1).ToString();
				txtDbox.Enabled = true;
				txtDbox.Focus();
			}
			else
			{
				txtCarton.Enabled = true;
				txtCarton.Text = "";
				txtCarton.Focus();
			}
		}
	}
}
