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
using UnidenDAL.Smt.Input;
using UnidenDTO;

namespace SMTPRORAM.Smt.Input
{
	public partial class NewFrmOperator_Check : Form
	{
		private bool _isChecked = false;
		private string IDMaterial = "";
		private string IDMaterial2 = "";
		public NewFrmOperator_Check()
		{
			InitializeComponent();
		}
		private void setDefaultLabel()
		{
			lbl_01.Text = "";
			lbl_02.Text = "";
			lbl_03.Text = "";
			lbl_04.Text = "";
			lbl_05.Text = "";
			txtLineName.Text = "";
			txtfdrno.Text = "";
			txtprgpartlist.Text = "";
			txtpartcode.Text = "";
			txtpartcode2.Text = "";
			txtLineName.Enabled = true;
			txtprgpartlist.Enabled = true;
			txtLineName.Focus();
		}
		private void ResetTextBox()
		{
			txtLineName.Enabled = false;
			txtprgpartlist.Enabled = false;
			txtfdrno.Enabled = true;
			txtpartcode.Enabled = true;
			txtpartcode2.Enabled = true;
			txtfdrno.Text = "";
			txtpartcode.Text = "";
			txtpartcode2.Text = "";
			lbl_03.Text = "";
			lbl_04.Text = "";
			lbl_05.Text = "";
			txtfdrno.Focus();
		}

		private void NewFrmOperator_Check_Load(object sender, EventArgs e)
		{
			checkBox.Checked = false;
			txtLineName.Focus();
			setDefaultLabel();
		}
		#region Sự kiện của LineName
		private bool checkLineName()
		{
			//checkLineName(txtLineName.Text);
			if (txtLineName.Text.Equals(""))
			{
				//MessageBox.Show("Phải nhập tên LINE", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				lbl_01.Text = "NG";
				lbl_01.ForeColor = System.Drawing.Color.Red;
				return false;
			}
			else
			{
				DataTable dt = new DataTable();
				dt = Smt_Linename_Services.Linename(txtLineName.Text.Trim());
				if (dt.Rows.Count > 0)
				{
					lbl_01.Text = "OK";
					lbl_01.ForeColor = System.Drawing.Color.Green;
				}
				else
				{
					//MessageBox.Show("Không có tên Line này trong csdl. Hãy Kiểm tra lại");
					lbl_01.Text = "NG";
					lbl_01.ForeColor = System.Drawing.Color.Red;
					return false;
				}
			}
			return true;
		}

		private void txtLineName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (checkLineName())
				{
					txtprgpartlist.Focus();
				}
				else
				{				

					txtLineName.Focus();
					txtLineName.SelectAll();
				}
			}
		}

		private void bt0_Click(object sender, EventArgs e)
		{
			lbl_01.Text = "";
			txtLineName.Enabled = true;
			txtLineName.Text = "";
			txtLineName.Focus();
		}
		#endregion

		#region sự kiện kiểm tra của Program
		private bool checkProgram()
		{
			if (txtprgpartlist.Text.Trim().Equals(""))
			{
				lbl_02.Text = "NG";
				lbl_02.ForeColor = System.Drawing.Color.Red;
				return false;
			}
			else
			{
				int chk;
				chk = PROGRAMService.PROGRAM_CheckPRGList(txtprgpartlist.Text.Trim());
				if (chk == 1)
				{					
					lbl_02.Text = "OK";
					lbl_02.ForeColor = System.Drawing.Color.Green;
				}
				else
				{
					lbl_02.Text = "NG";
					lbl_02.ForeColor = System.Drawing.Color.Red;
					return false;
				}
			}
			return true;
		}
		private void txtprgpartlist_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkProgram())
				{
					txtfdrno.Focus();
				}
				else
				{
					txtprgpartlist.Focus();
					txtprgpartlist.SelectAll();
				}
			}
		}
		private void bt1_Click(object sender, EventArgs e)
		{
			lbl_02.Text = "";
			txtprgpartlist.Enabled = true;
			txtprgpartlist.Text = "";
			txtprgpartlist.Focus();
		}

		#endregion

		#region sự kiện kiểm tra của Feeder
		private bool checkFeeder()
		{
			//checkFeederNo(txtfdrno.Text.Trim());
			if (txtfdrno.Text.Trim().Equals(""))
			{
				lbl_03.Text = "NG";
				lbl_03.ForeColor = System.Drawing.Color.Red;
				return false;
			}
			else
			{
				int chk;
				chk = PROGRAMService.PROGRAM_CheckFeed(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim());
				if (chk == 1)
				{
					lbl_03.Text = "OK";
					lbl_03.ForeColor = System.Drawing.Color.Green;
				}
				else
				{
					lbl_03.Text = "NG";
					lbl_03.ForeColor = System.Drawing.Color.Red;
					return false;
				}
			}
			return true;
		}
		private void txtfdrno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkFeeder())
				{
					txtpartcode.Focus();
				}
				else
				{
					txtpartcode.Focus();
					txtpartcode.SelectAll();
				}
			}
		}
		private void bt2_Click(object sender, EventArgs e)
		{
			lbl_03.Text = "";			
			txtfdrno.Text = "";
			txtfdrno.Focus();
		}

		#endregion

		#region sự kiện kiểm tra của Partcode trước
		private bool checkPartcode()
		{
			//checkPartcode(txtpartcode.Text.Trim());
			// Trước đó là độ dài partcode >11 ( partcode chuẩn của Uniden)
			if (txtpartcode.Text.Trim().Equals(""))
			{
				lbl_04.Text = "NG";
				lbl_04.ForeColor = System.Drawing.Color.Red;
				return false;
			}
			else
			{

				string inputString = txtpartcode.Text.Trim();
				char[] separator = { ';' };
				string[] result = inputString.Split(separator);
				if (result.Length == 1) 
				{ 
					txtpartcode.Text = result[0];
					IDMaterial = null;
				}
				else
				{
					txtpartcode.Text = result[1];
					IDMaterial= result[0];
				}



				if (txtpartcode.Text.Trim().Length > 16)
				{
					txtpartcode.Text = txtpartcode.Text.Trim().Substring(0, 16);
				}
				//txtpartcode.Text = txtpartcode.Text.ToUpper();			
				int chk;
				if (txtpartcode.Text.Trim().Length >= 9 && txtpartcode.Text.Trim().Length <= 16)
				{
					chk = PROGRAMService.PROGRAM_CheckPartcode(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtpartcode.Text.Trim());
					if (chk == 1)
					{
						//IDMaterial = result[0];
						lbl_04.Text = "OK";
						lbl_04.ForeColor = System.Drawing.Color.Green;
					}
					else
					{
						lbl_04.Text = "NG";
						lbl_04.ForeColor = System.Drawing.Color.Red;
						return false;
					}
				}
				else
				{
					//MessageBox.Show("Partcode chỉ có 9->16 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					lbl_04.Text = "NG";
					lbl_04.ForeColor = System.Drawing.Color.Red;
					return false;
				}
			}
			return true;
		}
		private void txtpartcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkPartcode())
				{
					if (checkBox.Checked==true)
					{
						btSave.PerformClick();
					}
					else
					{
						txtpartcode2.Focus();
					}					
				}
				else
				{
					txtpartcode.Focus();
					txtpartcode.SelectAll();
				}
			}
		}

		private void bt3_Click(object sender, EventArgs e)
		{
			lbl_04.Text = "";
			txtpartcode.Text = "";
			txtpartcode.Focus();
		}
		#endregion

		#region sự kiện kiểm tra của partcode sau
		private bool checkPartcode2()
		{
			// checkPartcode(txtpartcode.Text.Trim());
			// Trước đó là độ dài partcode >11 ( partcode chuẩn của Uniden)
			if (txtpartcode2.Text.Trim().Equals(""))
			{
				lbl_05.Text = "NG";
				lbl_05.ForeColor = System.Drawing.Color.Red;
				return false;
			}
			else
			{

				string inputString = txtpartcode2.Text.Trim();
				char[] separator = { ';' };
				string[] result = inputString.Split(separator);
				if (result.Length == 1)
				{
					txtpartcode2.Text = result[0];
					IDMaterial2 = null;
				}
				else
				{
					txtpartcode2.Text = result[1];
					IDMaterial2 = result[0];
				}


				if (txtpartcode2.Text.Trim().Length > 16)
				{
					txtpartcode2.Text = txtpartcode2.Text.Trim().Substring(0, 16);
				}
				//txtpartcode.Text = txtpartcode.Text.ToUpper();			
				int chk;
				if (txtpartcode2.Text.Trim().Length >= 9 && txtpartcode2.Text.Trim().Length <= 16)
				{
					chk = PROGRAMService.PROGRAM_CheckPartcode(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtpartcode2.Text.Trim());
					if (chk == 1)
					{
						
						lbl_05.Text = "OK";
						lbl_05.ForeColor = System.Drawing.Color.Green;
					}
					else
					{
						lbl_05.Text = "NG";
						lbl_05.ForeColor = System.Drawing.Color.Red;
						return false;
					}
				}
				else
				{
					//MessageBox.Show("Partcode chỉ có 9->16 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					lbl_05.Text = "NG";
					lbl_05.ForeColor = System.Drawing.Color.Red;
					return false;
				}
			}
			return true;
		}
		private void txtpartcode2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkPartcode2())
				{
					btSave.PerformClick();
				}
				else
				{
					//_isChecked = true;
					//btSave.PerformClick();

					txtpartcode2.Focus();
					txtpartcode2.SelectAll();
				}
			}
		}

		private void bt4_Click(object sender, EventArgs e)
		{
			lbl_05.Text = "";
			txtpartcode2.Text = "";
			txtpartcode2.Focus();
		}
		#endregion

		#region Kiểm tra lại các control xem đã ok chưa
		private bool IsOKData()
		{
			if (!checkLineName())
			{
				return false;
			}
			if (!checkProgram())
			{
				return false;
			}
			if (!checkFeeder())
			{
				return false;
			}
			if (!checkPartcode())
			{
				return false;
			}
			if (checkBox.Checked == false)
			{
				if (!checkPartcode2())
				{
					return false;
				}
				if (IDMaterial2==IDMaterial&&IDMaterial!=null&&IDMaterial2!=null)
				{
					return false;
				}
			}

			return true;
		}
		#endregion
		private void btSave_Click(object sender, EventArgs e)
		{
			if (IsOKData())
			{
				var data = new UV_SMT_STD_OP_HISTORY();
				data.changedby = Program.UserId;
				data.changedtime=CommonDAL.Instance.getSqlServerDatetime();
				data.linename = txtLineName.Text.Trim();
				data.programpartlist = txtprgpartlist.Text;
				data.fdrno = txtfdrno.Text.Trim();
				data.partscode=txtpartcode.Text.Trim();
				data.IDMaterial=IDMaterial;
				if (checkBox.Checked==true)
				{
					data.partscode2 = null;
					data.resultFinal = "NONEED_IPQC";
				}
				else
				{
					data.IDMaterial2=IDMaterial2;
					data.partscode2 = txtpartcode2.Text.Trim();
					data.resultFinal = "WAIT_IPQC";
				}
				
				
				string message = "";
				//if (_isChecked)
				//{
				//	message = UV_SMT_STD_OP_HISTORY_DAL.Instance.Add(data);
				//	CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, UV_SMT_STD_OP_HISTORY_DAL.Instance.OperatorCheck(data.linename, data.programpartlist, Program.UserId));
				//	_isChecked = false;
				//}
				//else
				//{
				message = UV_SMT_STD_OP_HISTORY_DAL.Instance.Add(data);
				if (message == "")
				{
					IDMaterial = null;
					IDMaterial2 = null;
					// Hiển thị danh sách theo người dùng và line
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, UV_SMT_STD_OP_HISTORY_DAL.Instance.OperatorCheck(data.linename, data.programpartlist, Program.UserId));
					try
					{
						SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.OK);
						sndPlay.Play();
					}
					catch (Exception ek)
					{
						MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + ek.Message);
					}
					ResetTextBox();
					if (checkBox.Checked==true)
					{
						txtpartcode2.Enabled = false;
						bt4.Enabled=false;
					}
					else
					{
						txtpartcode2.Enabled = true;
						bt4.Enabled = true;
					}
					
				}
				else
				{
					IDMaterial = null;
					IDMaterial2 = null;
					//MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					try
					{
						SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.NG);
						sndPlay.Play();
					}
					catch (Exception exx)
					{
						MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + exx.Message);
					}
					return;
				}
				//}		

			}
		}

		private void btClear_Click(object sender, EventArgs e)
		{
			setDefaultLabel();
		}

		private void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox.Checked==true)
			{
				txtpartcode2.Enabled = false;
				bt4.Enabled = false;
			}
			else
			{
				txtpartcode2.Enabled=true;
				bt4.Enabled = true;
			}
		}
	}
}
