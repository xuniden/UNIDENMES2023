using DocumentFormat.OpenXml.EMMA;
using SMTPROGRAM_Bu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Smt.Input;
using UnidenDTO;

namespace SMTPRORAM.Smt.Input
{
	public partial class frmIPQCConfirm : Form
	{
		private int originalCursorPosition;
		private long id = 0;
		public frmIPQCConfirm()
		{
			InitializeComponent();			
		}

		private void chkPanasonic_Click(object sender, EventArgs e)
		{
			if (chkPanasonic.Checked == true)
			{
				txtPcbSheet.Enabled = true;
				txtPcbSheet.Focus();
			}
			else
			{
				txtPcbSheet.Text = "";
				txtPcbSheet.Enabled = false;
			}
		}

		private void txtPcbSheet_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private bool checkPcbSheet()
		{
			if(txtPcbSheet.Text.Trim().Equals(""))
			{
				MessageBox.Show("Hãy nhập số lượng vào đây ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPcbSheet.Focus();
				return false;
			}	
			return true;
		}

		//private void txtPcbSheet_Validating(object sender, CancelEventArgs e)
		//{
		//	if (txtPcbSheet.Text.Trim().Equals(""))
		//	{
		//		MessageBox.Show("Hãy nhập số lượng vào đây ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//		txtPcbSheet.Focus();
		//		e.Cancel = true;
		//	}
		//}

		private void frmIPQCConfirm_Load(object sender, EventArgs e)
		{
			txtPcbSheet.Enabled = false;
			//txtcheckDatecode.Enabled = false;
			//txtcheckQty.Enabled = false;
			lbl_01.Text = "";
			lbl_02.Text = "";
			lbl_03.Text = "";
			lbl_04.Text = "";
			
			//originalCursorPosition= txtcheckPartcode.SelectionStart;
			//txtcheckPartcode.SelectionStart= originalCursorPosition;

			txtLine.Text = frmNewIPQCCheck.linename;
			txtprogram.Text=frmNewIPQCCheck.program;
			txtFeeder.Text= frmNewIPQCCheck.fdrno;
			txtpart1.Text = frmNewIPQCCheck.partcode;
			txtpart2.Text = frmNewIPQCCheck.partcode2;
			txtusage.Text = frmNewIPQCCheck.usage.ToString();
			txtqty.Text = frmNewIPQCCheck.qty.ToString();
			txtdatec.Text = frmNewIPQCCheck.datecode;
			txtIDMaterialOld.Text = frmNewIPQCCheck.IDMaterial;
			txtIDMaterialNew.Text = frmNewIPQCCheck.IDMaterial2;

			id =frmNewIPQCCheck.id;

			txtcheckPartcode.Focus();
			SendKeys.Send("{Tab}");
		}

		private void txtPcbSheet_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode == Keys.Tab)
			{
				if (checkPcbSheet())
				{
					txtcheckPartcode.Focus();
				}
				else
				{
					txtPcbSheet.Focus();
				}
				
			}
		}

		private bool checkPartcode()
		{
			//int check;
			if (txtcheckPartcode.Text.Trim().Equals(""))
			{
				lbl_01.Text = "NG";
				lbl_01.ForeColor = System.Drawing.Color.Red;
				return false;
			}
			else
			{

				string inputString = txtcheckPartcode.Text.Trim();
				char[] separator = { ';' };
				string[] result = inputString.Split(separator);
				
				if (result.Length == 1)
				{
					txtcheckPartcode.Text = result[0];					
				}
				else
				{
					txtcheckPartcode.Text = result[1];								
				}

				//check = PROGRAMService.PROGRAM_CheckPartcode(txtprogram.Text.Trim(), txtFeeder.Text.Trim(), txtcheckPartcode.Text.Trim());
				var checkP = SmtProgramDAL.Instance.checkPartcodeCutLot(txtprogram.Text.Trim(), txtFeeder.Text.Trim(), txtcheckPartcode.Text.Trim());
				if (checkP!=null && (txtcheckPartcode.Text.Trim().Equals(txtpart1.Text.Trim()) || txtcheckPartcode.Text.Trim().Equals(txtpart2.Text.Trim())))
				{
					if (result.Length==1)
					{
						txtcheckQty.Focus();
					}
					else
					{
						//if (result[0].Equals(txtIDMaterialNew.Text.Trim()))
						//{
						
						txtIDMaterialCurr.Text = result[0];
						txtcheckDatecode.Text = result[2];
						txtcheckQty.Text = result[4];
						txtcheckDesc.Focus();
							
						CommonDAL.Instance.SetStatusLabels(lbl_02, "OK");
						CommonDAL.Instance.SetStatusLabels(lbl_03, "OK");
						
						//}
						//else
						//{
						//	MessageBox.Show("ID cuộn linh kiện mới không giống nhau. ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
						//	return false;
						//}						
					}
					CommonDAL.Instance.SetStatusLabels(lbl_01, "OK");					
					//return true;
				}
				else
				{
					//MessageBox.Show("Hãy báo điều này với quản lý của bạn \n\n " +
					//	"Một vấn đề lớn có thể đang xảy ra là mã linh kiện đã bị thay nhầm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					CommonDAL.Instance.SetStatusLabels(lbl_01, "NG");
					txtcheckPartcode.Focus();
					txtcheckPartcode.SelectAll();
					return false;
					//txtcheckPartcode.Focus();
					//txtcheckPartcode.SelectAll();
					//txtcheckPartcode.SelectionStart = originalCursorPosition;				
				}
			}			
			return true;
		}

		private void txtcheckPartcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter  ||  e.KeyCode==Keys.Tab)
			{
				checkPartcode();
				//if (checkPartcode())
				//{
				//	txtcheckQty.Focus();
				//}
				//else
				//{
				//	txtcheckPartcode.Focus();
				//	txtcheckPartcode.SelectAll();
				//}
			}
		}
		//private void txtcheckPartcode_Validating(object sender, CancelEventArgs e)
		//{
		//	// Lưu vị trí con trỏ hiện tại
		//	// originalCursorPosition = txtcheckPartcode.SelectionStart;
		//	// Kiểm tra với program + fdrno + partcode này có trong csdl không?
		//	// Kiểm tra part này có giống với part1 hoặc part 2 không?
		//	int check;
		//	check = PROGRAMService.PROGRAM_CheckPartcode(txtprogram.Text.Trim(), txtFeeder.Text.Trim(), txtcheckPartcode.Text.Trim());
		//	if (check == 1 && (txtcheckPartcode.Text.Trim().Equals(txtpart1.Text.Trim()) || txtcheckPartcode.Text.Trim().Equals(txtpart2.Text.Trim())))
		//	{
		//		lbl_01.Text = "OK";
		//		lbl_01.ForeColor = System.Drawing.Color.Green;
		//		txtcheckQty.Enabled = true;
		//		txtcheckQty.Focus();
		//	}
		//	else
		//	{
		//		MessageBox.Show("Hãy báo điều này với quản lý của bạn \n\n "+
		//			"Một vấn đề lớn có thể đang xảy ra là mã linh kiện đã bị thay nhầm !!!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
		//		lbl_01.Text = "NG";
		//		lbl_01.ForeColor = System.Drawing.Color.Red;
		//		txtcheckPartcode.Focus();
		//		txtcheckPartcode.SelectAll();
		//		//txtcheckPartcode.SelectionStart = originalCursorPosition;				
		//	}
		//}
		private bool checkQty()		
		{
			if (txtcheckQty.Text.Trim().Equals(""))
			{				
				CommonDAL.Instance.SetStatusLabels(lbl_02, "NG");
				return false;
			}
			else
			{
				if (chkPanasonic.Checked == true)
				{
					if (txtPcbSheet.Text.Trim().Equals("") || string.IsNullOrEmpty(txtPcbSheet.Text.Trim()))
					{
						MessageBox.Show("Hãy nhập số lượng PCB/1 Sheet vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtPcbSheet.Focus();
						return false;
					}
					else if (int.Parse(txtPcbSheet.Text.Trim().ToString()) <= 0)
					{
						MessageBox.Show("Số lượng PCB phải >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtPcbSheet.Focus();
						return false;
					}
					else
					{
						int x = int.Parse(txtPcbSheet.Text.Trim().ToString()) * int.Parse(txtcheckQty.Text.Trim().ToString());
						txtTempQty.Text = x.ToString();
						CommonDAL.Instance.SetStatusLabels(lbl_02, "OK");
					}
				}
				else
				{
					txtTempQty.Text = txtcheckQty.Text.Trim();
					CommonDAL.Instance.SetStatusLabels(lbl_02, "OK");
				}
			}
			

			//if (txtTempQty.Text.Trim().Equals(txtqty.Text.Trim()))
			//{
			//	lbl_02.Text = "OK";
			//	lbl_02.ForeColor = System.Drawing.Color.Green;				
			//}
			//else
			//{

			//	DialogResult lkResult = MessageBox.Show("Hãy kiểm tra lại số lượng, Line Panasonic cần check và điền vào Số PCB /Set \n\n" +
			//		"Bạn có muốn giữ nguyên số lượng này không? ", "Thông báo", MessageBoxButtons.YesNo);
			//	if (lkResult == DialogResult.Yes)
			//	{
			//		lbl_02.Text = "OK";
			//		lbl_02.ForeColor = System.Drawing.Color.Green;					
			//	}
			//	else
			//	{
			//		lbl_02.Text = "NG";
			//		lbl_02.ForeColor = System.Drawing.Color.Red;					
			//		return false;					
			//	}
			//}
			return true;
		}
		private void txtcheckQty_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
				if (checkQty())
				{
					txtcheckDatecode.Focus();
				}
				else
				{
					txtcheckQty.Focus();
					txtcheckQty.SelectAll();
				}
			}
		}
		
		private void txtcheckQty_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private bool checkDateCode()
		{
			//if (txtcheckDatecode.Text.Trim().Equals(txtdatec.Text.Trim()))
			//{
			//	lbl_03.Text = "OK";
			//	lbl_03.ForeColor = System.Drawing.Color.Green;
			//	//iconbtnSave.Focus();				
			//}
			//else
			//{
			//	DialogResult lkResult = MessageBox.Show("Hãy kiểm tra lại Date code \n\n" +
			//		"Bạn có muốn giữ nguyên DateCode Này không? ", "Thông báo", MessageBoxButtons.YesNo);
			//	if (lkResult == DialogResult.Yes)
			//	{
			//		lbl_03.Text = "OK";
			//		lbl_03.ForeColor = System.Drawing.Color.Green;
			//	}
			//	else
			//	{
			//		lbl_03.Text = "NG";
			//		lbl_03.ForeColor = System.Drawing.Color.Red;
			//		//txtcheckDatecode.Focus();
			//		return false;
			//	}
			//}
			if (txtcheckDatecode.Text.Trim().Equals(""))
			{				
				CommonDAL.Instance.SetStatusLabels(lbl_03, "NG");
				//txtcheckDatecode.Focus();
				return false;
			}
			else
			{
				CommonDAL.Instance.SetStatusLabels(lbl_03, "OK");
			}
			return true;
		}
		private void txtcheckDatecode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
				if (checkDateCode())
				{
					txtcheckDesc.Focus();
				}
				else
				{
					txtcheckDatecode.Focus();
					txtcheckDatecode.SelectAll();
				}
			}
		}	

		private bool checkDesc()
		{
			if (txtcheckDesc.Text.Trim().Equals(""))
			{
				CommonDAL.Instance.SetStatusLabels(lbl_04, "NG");
				//txtcheckDatecode.Focus();
				return false;
			}
			else
			{
				CommonDAL.Instance.SetStatusLabels(lbl_04, "OK");
			}
			return true;
		}
		private void txtcheckDesc_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
				if (checkDesc())
				{
					iconbtnSave.PerformClick();
				}
				else
				{
					txtcheckDesc.Focus();
					txtcheckDesc.SelectAll();
				}
			}
		}

		private bool isOKData()
		{
			if (!checkPartcode())
			{
				return false;
			}
			if (!checkQty())
			{
				return false;
			}
			if (!checkDateCode())
			{
				return false;
			}
			if (!checkDesc())
			{
				return false;
			}
			if (id==0)
			{
				return false;
			}	
			return true;
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (isOKData())
			{
				#region Old Code
				//	var proInfo = new PROGRAM();
				//	proInfo = SmtProgramDAL.Instance.getByProgram(txtprogram.Text.Trim());
				//	var date = CommonDAL.Instance.getSqlServerDatetime();
				//	var upData = new UV_SMT_STD_OP_HISTORY();
				//	var getOldDataa= new UV_SMT_STD_OP_HISTORY();
				//	upData.Id=id;
				//	upData.ipqcCheckedBy = Program.UserId;
				//	upData.ipqcCheckedDate = date;
				//	upData.ipqcCheckedQty = int.Parse(txtTempQty.Text.Trim());
				//	upData.ipqcCheckedDesc = txtcheckDesc.Text.Trim();
				//	upData.ipqcCheckedDateCode =txtcheckDatecode.Text;
				//	upData.ipqcCheckPartcode = txtcheckPartcode.Text.Trim();
				//	upData.ipqcCheckedStatus = "OK";
				//	upData.usage = proInfo.usage;
				//	upData.ipqcCheckedDesc=txtcheckDesc.Text.Trim();


				//	upData.resultFinal = "IPQC_OK";
				//	string message = "";
				//	message = UV_SMT_STD_OP_HISTORY_DAL.Instance.Update(upData);
				//	if (message=="")
				//	{
				//		// Sau khi update xong dữ liệu ở đây thì sẽ insert dữ liệu vào bảng 
				//		// EASTECH_PROGRAMHISTORY và PROGRAMHISTORY



				//		var etHistory = new EASTECH_PROGRAMHISTORY();
				//		var pgHistory = new PROGRAMHISTORY();
				//		etHistory.programpartlist = txtprogram.Text.Trim();				

				//		etHistory.pkey = etHistory.programpartlist + "_" + txtLine.Text.Trim() + "_" + txtFeeder.Text.Trim() + "_" + txtcheckPartcode.Text.Trim();
				//		etHistory.psubkey = etHistory.programpartlist + "_" + txtLine.Text.Trim() + "_" + txtFeeder.Text.Trim();

				//		etHistory.fdrno = txtFeeder.Text.Trim();
				//		etHistory.partscode= txtcheckPartcode.Text.Trim();
				//		etHistory.ndesc = txtcheckDesc.Text.Trim();
				//		etHistory.usage = proInfo.usage;
				//		etHistory.checkedby = Program.UserId  +" OK" + " " + txtLine.Text.Trim();
				//		etHistory.checkedtime = date.ToString("yyyy/MM/dd hh:mm:ss");
				//		etHistory.reqqty = int.Parse(txtTempQty.Text.Trim());
				//		etHistory.datecode = txtcheckDatecode.Text.Trim();
				//		var dt = new DataTable();
				//		dt = EASTECH_PROGRAMHISTORY_DAL.Instance.getMaxOfSolanthaylinhkien(etHistory.psubkey);
				//		if (dt.Rows.Count>0)
				//		{
				//			etHistory.Solanthaylinhkien = dt.Rows[0].Field<int>("Solanthaylinhkien") +1;// int.Parse(dt.Rows[0][1].ToString());
				//		}
				//		else
				//		{
				//			etHistory.Solanthaylinhkien = 1;
				//		}
				//		int x = etHistory.reqqty;
				//		int y = int.Parse(etHistory.usage.ToString());
				//		int z = x / y;
				//		etHistory.SoPCBCothedung = z;
				//		etHistory.remark1 = txtLine.Text.Trim();
				//		etHistory.remark2 = Program.Dept;
				//		etHistory.remark3 = "";
				//		etHistory.counts = 0;

				//		pgHistory.programpartlist = txtprogram.Text.Trim();
				//		pgHistory.fdrno= txtFeeder.Text.Trim();
				//		pgHistory.partscode = txtcheckPartcode.Text.Trim();
				//		pgHistory.ndesc = txtcheckDesc.Text.Trim();
				//		pgHistory.usage = proInfo.usage;
				//		pgHistory.checkedby = Program.UserId + " OK" + " " + txtLine.Text.Trim();
				//		pgHistory.checkedtime = date.ToString("yyyy/MM/dd hh:mm:ss");

				//		pgHistory.rp = proInfo.rp;
				//		pgHistory.rep1 = proInfo.rep1;
				//		pgHistory.rep2 = proInfo.rep2;
				//		pgHistory.rep3 = proInfo.rep3;
				//		pgHistory.rep4 = proInfo.rep4;
				//		pgHistory.rep5 = proInfo.rep5;
				//		pgHistory.reqqty = int.Parse(txtTempQty.Text.Trim());
				//		pgHistory.datecode= txtcheckDatecode.Text;
				//		pgHistory.changedby = Program.Dept;


				//		string messageET = "";
				//		string messageUV = "";
				//		CommonDAL.Instance.BeginTransaction();
				//		messageUV = PROGRAMHISTORY_DAL.Instance.Add(pgHistory);
				//		if (messageUV=="")
				//		{
				//			messageET = EASTECH_PROGRAMHISTORY_DAL.Instance.Add(etHistory);
				//			if (messageET!="")
				//			{
				//				CommonDAL.Instance.RollbackTransaction();
				//				try
				//				{	
				//					SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.NG);
				//					sndPlay.Play();
				//				}
				//				catch (Exception exx)
				//				{
				//					MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + exx.Message);
				//				}
				//				MessageBox.Show("Đã có lỗi xảy ra khi ktra dữ liệu IPQC 02 \n" +
				//					"Hãy báo lại cho IT để fix lỗi trước khi làm tiếp. ","Thông báo",
				//					MessageBoxButtons.OK, MessageBoxIcon.Error);
				//				return;
				//			}
				//			else
				//			{
				//				CommonDAL.Instance.CommitTransaction();
				//				try
				//				{								
				//					SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.OK);
				//					sndPlay.Play();
				//				}
				//				catch (Exception ek)
				//				{
				//					MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + ek.Message);
				//				}
				//				this.Close();
				//			}
				//		}
				//		else
				//		{
				//			try
				//			{
				//				SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.NG);
				//				sndPlay.Play();
				//			}
				//			catch (Exception exx)
				//			{
				//				MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + exx.Message);
				//			}
				//			MessageBox.Show("Đã có lỗi xảy ra khi ktra dữ liệu IPQC 01 \n" +
				//					"Hãy báo lại cho IT để fix lỗi trước khi làm tiếp. ", "Thông báo",
				//					MessageBoxButtons.OK, MessageBoxIcon.Error);
				//			return;
				//		}					
				//	}
				//	else
				//	{
				//		try
				//		{
				//			SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.NG);
				//			sndPlay.Play();
				//		}
				//		catch (Exception exx)
				//		{
				//			MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + exx.Message);
				//		}
				//		MessageBox.Show("Đã có lỗi xảy ra trong quá trình update dữ liệu \n\n"
				//			+ "Hãy liên lạc bộ phận IT để xử lý lỗi !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				//		return;
				//	}

				#endregion

				var proInfo = SmtProgramDAL.Instance.getByProgram(txtprogram.Text.Trim());
				var date = CommonDAL.Instance.getSqlServerDatetime();

				var upData = new UV_SMT_STD_OP_HISTORY
				{
					Id = id,
					ipqcCheckedBy = Program.UserId,
					ipqcCheckedDate = date,
					ipqcCheckedQty = int.Parse(txtTempQty.Text.Trim()),
					ipqcCheckedDesc = txtcheckDesc.Text.Trim(),
					ipqcCheckedDateCode = txtcheckDatecode.Text,
					ipqcCheckPartcode = txtcheckPartcode.Text.Trim(),
					ipqcCheckedStatus = "OK",
					usage = proInfo.usage,
					resultFinal = "IPQC_OK"
				};
				string message = UV_SMT_STD_OP_HISTORY_DAL.Instance.Update(upData);
				if (!string.IsNullOrEmpty(message))
				{
					HandleUpdateError(message);
					return;
				}

				var etHistory = new EASTECH_PROGRAMHISTORY
				{
					programpartlist = txtprogram.Text.Trim(),
					pkey = $"{txtprogram.Text.Trim()}_{txtLine.Text.Trim()}_{txtFeeder.Text.Trim()}_{txtcheckPartcode.Text.Trim()}",
					psubkey = $"{txtprogram.Text.Trim()}_{txtLine.Text.Trim()}_{txtFeeder.Text.Trim()}",
					fdrno = txtFeeder.Text.Trim(),
					partscode = txtcheckPartcode.Text.Trim(),
					ndesc = txtcheckDesc.Text.Trim(),
					usage = proInfo.usage,
					checkedby = $"{Program.UserId} OK {txtLine.Text.Trim()}",
					checkedtime = date.ToString("yyyy/MM/dd hh:mm:ss"),
					reqqty = int.Parse(txtTempQty.Text.Trim()),
					datecode = txtcheckDatecode.Text
				};
				var checkMax = EASTECH_PROGRAMHISTORY_DAL.Instance.getMaxSolanthaylinhkien(etHistory.psubkey,etHistory.fdrno,txtLine.Text.Trim());
				if (checkMax != null)
				{
					etHistory.Solanthaylinhkien = checkMax.Solanthaylinhkien + 1;
				}
				else
				{
					etHistory.Solanthaylinhkien = 1;
				}
				int x = etHistory.reqqty;
				int y = int.Parse(etHistory.usage.ToString());
				int z = x / y;
				etHistory.SoPCBCothedung = z;
				etHistory.remark1 = txtLine.Text.Trim();
				etHistory.remark2 = Program.Dept;
				etHistory.remark3 = "";
				etHistory.counts = 0;

				var pgHistory = new PROGRAMHISTORY
				{
					programpartlist = txtprogram.Text.Trim(),
					fdrno = txtFeeder.Text.Trim(),
					partscode = txtcheckPartcode.Text.Trim(),
					ndesc = txtcheckDesc.Text.Trim(),
					usage = proInfo.usage,
					checkedby = $"{Program.UserId} OK {txtLine.Text.Trim()}",
					checkedtime = date.ToString("yyyy/MM/dd HH:mm:ss"),
					rp = proInfo.rp,
					rep1 = proInfo.rep1,
					rep2 = proInfo.rep2,
					rep3 = proInfo.rep3,
					rep4 = proInfo.rep4,
					rep5 = proInfo.rep5,
					reqqty = int.Parse(txtTempQty.Text.Trim()),
					datecode = txtcheckDatecode.Text,
					changedby = Program.Dept
				};			

				string messageFished =EASTECH_PROGRAMHISTORY_DAL.Instance.InsertETHistoryVsProgramHistory(pgHistory, etHistory);
				if (string.IsNullOrEmpty(messageFished))
				{
					PlaySound(SMTPRORAM.Properties.Resources.OK);
					this.Close();
				}
				else
				{
					MessageBox.Show($"Đã có lỗi xảy ra khi update dữ liệu đứng máy: {messageFished}");
					PlaySound(SMTPRORAM.Properties.Resources.NG);
					this.Close();
				}
				#region Old Code
				/*
				using (var transaction = new CommonDAL())
				{
					try
					{
						transaction.BeginTransaction();
						messageUV = PROGRAMHISTORY_DAL.Instance.Add(pgHistory);
						if (string.IsNullOrEmpty(messageUV))
						{
							messageET = EASTECH_PROGRAMHISTORY_DAL.Instance.Add(etHistory);
							if (!string.IsNullOrEmpty(messageET))
							{
								HandleAddError(transaction);
								return;
							}
							else
							{
								transaction.CommitTransaction();
								PlaySound(SMTPRORAM.Properties.Resources.OK);
								this.Close();
							}
						}
						else
						{
							HandleAddError(transaction);
							return;
						}
					}
					catch (Exception)
					{
						HandleExceptionAndRollback(transaction);
						return;
					}
				}
				*/
				#endregion 
			}

		}
		private void HandleExceptionAndRollback(CommonDAL transaction)
		{
			transaction.RollbackTransaction();
			return;
		}
		private void HandleUpdateError(string message)
		{
			PlaySound(SMTPRORAM.Properties.Resources.NG);
			MessageBox.Show($"Đã có lỗi xảy ra khi update dữ liệu đứng máy: {message}");
			MessageBox.Show("Đã có lỗi xảy ra trong quá trình update dữ liệu\n\n"
				+ "Hãy liên lạc bộ phận IT để xử lý lỗi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private void PlaySound(System.IO.Stream soundStream)
		{
			try
			{
				SoundPlayer sndPlay = new SoundPlayer(soundStream);
				sndPlay.Play();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã có lỗi xảy ra FUserCheck: {ex.Message}");
			}
		}

		private void HandleAddError(CommonDAL transaction)
		{
			transaction.RollbackTransaction();
			PlaySound(SMTPRORAM.Properties.Resources.NG);
			MessageBox.Show("Đã có lỗi xảy ra khi ktra dữ liệu IPQC 02\n"
				+ "Hãy báo lại cho IT để fix lỗi trước khi làm tiếp. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

	}
}
