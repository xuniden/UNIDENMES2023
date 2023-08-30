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
using UnidenDAL.AssyLine.ETASSY;
using UnidenDAL.AssyLine.MENU;
using UnidenDAL.AssyLine.REPAIR;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.MENU
{
	public partial class frmEastechSerialControl : Form
	{
		public frmEastechSerialControl()
		{
			InitializeComponent();
		}

		private void frmEastechSerialControl_Load(object sender, EventArgs e)
		{
			lbcheck.Text = "";
			txtWirelessQR.Enabled = false;
			txtRepairCode.Enabled = false;
			pictureBoxOK.Visible = false;
			pictureBoxNG.Visible = false;
			LoadModel();
		}

		private void LoadModel()
		{
			cbModel.DataSource = EASTECHSERIALGENERAL_DAL.Instance.listModel();
			cbModel.DisplayMember = "Model";
			cbModel.ValueMember = "Model";
		}

		private void txtSerial_KeyDown(object sender, KeyEventArgs e)
		{
			cbModel.Enabled = false;
			cbPcbtype.Enabled = false;
			if (Keys.Enter==e.KeyCode)
			{
				if (txtSerial.Text.Trim().Length <= 28)
				{					
					if (string.IsNullOrEmpty(txtSerial.Text.Trim()))
					{
						txtSerial.Focus();
						txtSerial.SelectAll();
					}
					else
					{
						btSave.Focus();
						SendKeys.Send("{ENTER}");
					}
				}
				else
				{
					MessageBox.Show("Số serial không lớn hơn 28 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtSerial.SelectAll();
					txtSerial.Focus();
				}
			}
		}

		private void chkbox_CheckedChanged(object sender, EventArgs e)
		{
			if (chkbox.Checked == true)
			{
				txtWirelessQR.Enabled = true;
			}
			else
			{
				txtWirelessQR.Enabled = false;
			}
		}

		private void txtWirelessQR_KeyDown(object sender, KeyEventArgs e)
		{
			// Kiểm tra xem QR đã có trong csld chưa?
			// Nếu chưa có thì thông báo 
			if (Keys.Enter==e.KeyCode)
			{
				if (txtWirelessQR.Text.Length >= 35)
				{
					string KeyCode = "";
					txtWirelessQR.Text = txtWirelessQR.Text.Trim();
					//KeyCode = cbModel.Text + "--" + txtWirelessQR.Text;
					//var dt = new DataTable();
					//dt = WirelessQR_Services.QRWireless_CheckKeyCode(KeyCode);
					//if (dt.Rows.Count < 1)
					//{
					//    MessageBox.Show("WIRELESS QR Không có trong CSDL");
					//    txtWirelessQR.Focus();
					//    txtWirelessQR.SelectAll();
					//}
					//else
					//{
					//    txtWirelessQR.Enabled = false;
					//    txtSerial.Focus();
					//}
					txtWirelessQR.Enabled = false;
					txtSerial.Focus();
				}
				else
				{
					MessageBox.Show("WIRELESS QR Không để trống hoặc không nhỏ hơn 40 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtWirelessQR.SelectAll();
					txtWirelessQR.Focus();
				}

			}
		}

		private void chkRepairCode_CheckedChanged(object sender, EventArgs e)
		{
			if (chkRepairCode.Checked == true)
			{
				txtRepairCode.Enabled = true;
			}
			else
			{
				txtRepairCode.Enabled = false;
			}
		}

		private void txtRepairCode_KeyDown(object sender, KeyEventArgs e)
		{
			// Kiểm tra xem QR đã có trong csld chưa?
			// Nếu chưa có thì thông báo 
			if (e.KeyCode==Keys.Enter)
			{	
				var checkRepairCode = REPAIRHISTORY_DAL.Instance.checkRepairCode(txtRepairCode.Text.Trim());
				if (checkRepairCode!=null)
				{
					if (chkbox.Checked == true)
					{
						txtWirelessQR.Focus();
					}
					else
					{
						txtSerial.Focus();
					}
				}
				else
				{
					MessageBox.Show("chưa qua công đoạn bắn Repair code hãy quay lại công đoạn trên !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtRepairCode.SelectAll();
					txtRepairCode.Focus();
					return;
				}
			}
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			// Kiem tra xem da nhap du thong tin chua
			var chkrepairCode = REPAIRHISTORY_DAL.Instance.checkRepairCode(txtRepairCode.Text.Trim().ToUpper());
			
			if (chkRepairCode.Checked == true && chkRepairCode==null)
			{
				MessageBox.Show("Mã repair này chưa được bắn hay quay trở lại công đoạn bắn Repair ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtRepairCode.Focus();
				txtRepairCode.SelectAll() ;
				return;
			}
			if (chkbox.Checked == true)
			{
				if (string.IsNullOrEmpty(txtWirelessQR.Text.Trim()))
				{
					MessageBox.Show("Không để trống WirelesssQR ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtWirelessQR.Focus();
					return;
				}

			}
			if (chkRepairCode.Checked == true)
			{
				if (string.IsNullOrEmpty(txtRepairCode.Text.Trim()))
				{
					MessageBox.Show("Không để trống Repoair Code ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtRepairCode.Focus();
					return;
				}
				else
				{					
					var checkCreateRepairCode = REPAIRGENERALCODE_DAL.Instance.checkExistRepairCode(txtRepairCode.Text.Trim());
					if (checkCreateRepairCode==null)
					{
						MessageBox.Show("Sai RepairCode ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						txtRepairCode.Focus();
						txtRepairCode.SelectAll();
						return;
					}
				}
			}
			if (string.IsNullOrEmpty(cbModel.Text.Trim()))
			{
				MessageBox.Show("Hay nhap MODEL Vao !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbModel.Focus();
				return;
			}
			if (string.IsNullOrEmpty(cbPcbtype.Text.Trim()))
			{
				MessageBox.Show("Hay chon PCB Type Vao !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbPcbtype.Focus();
				return;
			}
			if (string.IsNullOrEmpty(txtSerial.Text.Trim()))
			{
				MessageBox.Show("Hay SERIAL Vao !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtSerial.Focus();
				return;
			}
			
			// Kiem tra xem so serial với Model nay cao trong csldl khong???
			// Neu ko co thi xoa di de nhap so serial moi						
			var checkSerialvsModel= EASTECHSERIALGENERAL_DAL.Instance.checkSerialvsModel(txtSerial.Text.Trim(), cbModel.Text);
			if (checkSerialvsModel == null)
			{
				pictureBoxNG.Visible = true;
				pictureBoxOK.Visible = false;
				lbcheck.Text = txtSerial.Text;
				Application.DoEvents();
				System.Threading.Thread.Sleep(1000);
				pictureBoxNG.Visible = false;				
				txtSerial.Focus();
				txtSerial.SelectAll();
			}
			else // nếu có trong csdl số serial rồi, thì kiểm tra tiếp xem đã được bắn lần nào chưa???
			{ 
				var checkSerialvsModelHistory= EASTECHHISTORY_DALL.Instance.checkSerialvsModel(txtSerial.Text.Trim(),cbModel.Text);
				if (checkSerialvsModelHistory!=null)// Đã có trong csdl thì update
				{
					DialogResult rs = MessageBox.Show("Thông báo", "Đã có trong CSDL. Bạn muốn Cập nhật hay không ???", MessageBoxButtons.YesNo);
					if (rs == DialogResult.Yes)
					{
						var update = new UVASSY_EASTECHHISTORY
						{
							Model = cbModel.Text,
							Lot = string.IsNullOrEmpty(txtWirelessQR.Text.Trim()) ? null : txtWirelessQR.Text.Trim(),
							RepairCode = string.IsNullOrEmpty(txtRepairCode.Text.Trim()) ? null : txtRepairCode.Text.Trim(),
							Type_Base = cbPcbtype.Text,
							Serial_Number = txtSerial.Text.Trim(),
							CreatedDate = CommonDAL.Instance.getSqlServerDatetime(),
							CreatedBy=Program.UserId
						};

						string message = EASTECHHISTORY_DALL.Instance.Update(update);
						if (string.IsNullOrEmpty(message))
						{
							CommonDAL.Instance.ShowDataGridView(dgView,
							EASTECHHISTORY_DALL.Instance.getDataByUser(Program.UserId));
							pictureBoxNG.Visible = false;
							pictureBoxOK.Visible = true;
							lbcheck.Text = txtSerial.Text;
							Application.DoEvents();
							System.Threading.Thread.Sleep(1000);
							pictureBoxOK.Visible = false;
							if (chkbox.Checked == true && chkRepairCode.Checked == false)
							{
								txtWirelessQR.Enabled = true;
								txtSerial.Text = "";
								txtWirelessQR.Text = "";
								txtWirelessQR.Focus();
							}
							if (chkRepairCode.Checked == true && chkbox.Checked == false)
							{
								txtRepairCode.Enabled = true;
								txtSerial.Text = "";
								txtRepairCode.Text = "";
								txtRepairCode.Focus();
							}
							if (chkRepairCode.Checked == true && chkbox.Checked == true)
							{
								txtRepairCode.Enabled = true;
								txtSerial.Text = "";
								txtWirelessQR.Text = "";
								txtWirelessQR.Enabled = true;
								txtRepairCode.Text = "";
								txtRepairCode.Focus();
							}
							if (chkRepairCode.Checked == false && chkbox.Checked == false)
							{
								txtSerial.Text = "";
								txtSerial.Focus();
							}
						}
						else
						{
							pictureBoxNG.Visible = true;
							pictureBoxOK.Visible = false;
							lbcheck.Text = txtSerial.Text;
							Application.DoEvents();
							System.Threading.Thread.Sleep(1000);
							pictureBoxNG.Visible = false;
							MessageBox.Show("Đã có lỗi xảy ra khi update: \n " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
					if (rs == DialogResult.No)
					{
						txtSerial.Text = "";
						txtSerial.Focus();
					}
				}
				else // Chưa có thì thêm mới
				{
					var addNew = new UVASSY_EASTECHHISTORY
					{
						Model = cbModel.Text,
						Lot = string.IsNullOrEmpty(txtWirelessQR.Text.Trim()) ? cbModel.Text.Trim() : txtWirelessQR.Text.Trim(),
						RepairCode = string.IsNullOrEmpty(txtRepairCode.Text.Trim()) ? null : txtRepairCode.Text.Trim(),
						Type_Base = cbPcbtype.Text,
						Serial_Number = txtSerial.Text.Trim(),
						CreatedDate = CommonDAL.Instance.getSqlServerDatetime(),
						CreatedBy = Program.UserId
					};
					string message = EASTECHHISTORY_DALL.Instance.Add(addNew);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.ShowDataGridView(dgView,
							EASTECHHISTORY_DALL.Instance.getDataByUser(Program.UserId));
						pictureBoxNG.Visible = false;
						pictureBoxOK.Visible = true;
						lbcheck.Text = txtSerial.Text;
						Application.DoEvents();
						System.Threading.Thread.Sleep(1000);
						pictureBoxOK.Visible = false;
						if (chkbox.Checked == true && chkRepairCode.Checked == false)
						{
							txtWirelessQR.Enabled = true;
							txtSerial.Text = "";
							txtWirelessQR.Text = "";
							txtWirelessQR.Focus();
						}
						if (chkRepairCode.Checked == true && chkbox.Checked == false)
						{
							txtRepairCode.Enabled = true;
							txtSerial.Text = "";
							txtRepairCode.Text = "";
							txtRepairCode.Focus();
						}
						if (chkRepairCode.Checked == true && chkbox.Checked == true)
						{
							txtRepairCode.Enabled = true;
							txtSerial.Text = "";
							txtWirelessQR.Text = "";
							txtWirelessQR.Enabled = true;
							txtRepairCode.Text = "";
							txtRepairCode.Focus();
						}
						if (chkRepairCode.Checked == false && chkbox.Checked == false)
						{
							txtSerial.Text = "";
							txtSerial.Focus();
						}
					}
					else
					{
						pictureBoxNG.Visible = true;
						pictureBoxOK.Visible = false;
						lbcheck.Text = txtSerial.Text;
						Application.DoEvents();
						System.Threading.Thread.Sleep(1000);
						pictureBoxOK.Visible = false;
						MessageBox.Show("Đã có lỗi xảy ra: \n " + message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
				}
			}
		}
	}
}
