using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.SysControl;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.Smt.Output;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Jig;
using UnidenDAL.Smt.Repair;
using System.Web.Services.Description;

namespace SMTPRORAM.Smt.DataControl
{
	public partial class frmAOIErrorRecord : Form
	{
		private string program = "";
		private string linename = "";
		private int usage = 0;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmAOIErrorRecord()
		{
			InitializeComponent();
		}

		private void setDefaultControl()
		{
			program = "";
			txtQRCode.Text = "";
			txtVitri.Text = "";
			cbMaloi.Text = "--Select--";
			txtLoi.Text = "";
			txtpartcode.Text = "";
			txtsoluong.Text = "";
			lbl_01.Text = "";
			lbl_02.Text = "";
			lbl_03.Text = "";
			lbl_04.Text = "";
			lbl_05.Text = "";
			txtQRCode.Focus();
		}

		private void frmAOIErrorRecord_Load(object sender, EventArgs e)
		{			
			setDefaultControl();
			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}
		private bool checkQRCode()
		{
			// Kiểm tra xem QR này đã được bắn ở AOI chưa?
			if (txtQRCode.Text.Trim().Equals(""))
			{
				lbl_01.Text = "NG";
				lbl_01.ForeColor = System.Drawing.Color.Red;
				txtQRCode.Focus();
				return false;
			}
			else
			{
				var checkExist = new EASTECH_SMT_OUTPUT();
				checkExist=SmtAOIQrCodeOutputDAL.Instance.checkQRCodeExist(txtQRCode.Text.Trim());
				if (checkExist!=null)
				{
					lbl_01.Text = "OK";
					lbl_01.ForeColor = System.Drawing.Color.Green;
					program = checkExist.programkey;
					linename = checkExist.LineName;
					txtVitri.Focus();
				}
				else
				{
					lbl_01.Text = "NG";
					lbl_01.ForeColor = System.Drawing.Color.Red;
					txtQRCode.Focus();
					return false;
				}
			}
			// Nếu được bắn rồi thì lấy program của nó.

			return true;
		}

		private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				checkQRCode();
			}
		}

		private bool checkVitri()
		{
			if (program!="")
			{
				if (txtVitri.Text.Trim().Equals(""))
				{
					lbl_02.Text = "NG";
					lbl_02.ForeColor = System.Drawing.Color.Red;
					txtVitri.Focus();
					return false;
				}
				else
				{
					var dt = new DataTable();
					dt = SmtProgramDAL.Instance.getPartAndUsageByRefNo(program, txtVitri.Text.Trim());
					if (dt.Rows.Count>1)
					{
						MessageBox.Show("Cần kiểm tra lại dữ liệu: \n Hãy gửi cho IT: "+ program+ "\n Vị trí: " + txtVitri.Text.Trim(),
							"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtVitri.Focus();
						return false;
					}
					else if (dt.Rows.Count<1)
					{
						lbl_02.Text = "NG";
						lbl_02.ForeColor = System.Drawing.Color.Red;
						txtVitri.Focus();
						return false;
					}
					else
					{
						lbl_02.Text = "OK";
						lbl_02.ForeColor = System.Drawing.Color.Green;
						txtpartcode.Text = dt.Rows[0].Field<string>("partscode");
						LoadMaloi();
						cbMaloi.Focus();
						
					}
					
				}
			}
			return true;
		}

		private void LoadMaloi()
		{
			var lstError = SmtRepairErrorCode_DAL.Instance.getListErrorCodeByUserDept(Program.Dept);
			var Error = new Smt_Repair_Error_Code();
			Error.Ky_Hieu = "--Select--";
			lstError.Add(Error);
			cbMaloi.DataSource = lstError.OrderBy(p => p.Ky_Hieu).ToList();
			cbMaloi.DisplayMember = "Ky_Hieu";
			cbMaloi.ValueMember = "Ky_Hieu";
		}


		private void txtVitri_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) 
			{
				checkVitri();
			}

		}

		private bool checkMaloi()
		{
			if (!cbMaloi.Text.Trim().Equals("--Select--"))
			{
				var check = SmtRepairErrorCode_DAL.Instance.getNoiDungLoiByKyHieu(cbMaloi.Text.Trim(), Program.Dept);
				if (check != null)
				{
					txtLoi.Text = check.Noi_Dung_Loi;
					lbl_03.Text = "OK";
					lbl_03.ForeColor = System.Drawing.Color.Green;
					txtsoluong.Focus();
				}
				else
				{
					lbl_03.Text = "NG";
					lbl_03.ForeColor = System.Drawing.Color.Red;
					cbMaloi.Focus();
					return false;
				}
			}
			return true;
		}
		private void cbMaloi_SelectionChangeCommitted(object sender, EventArgs e)
		{
			checkMaloi();
		}

		private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Verify that the pressed key isn't CTRL or any non-numeric digit
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private bool checkSoluong()
		{
			if (txtsoluong.Text.Trim().Equals(""))
			{
				lbl_05.Text = "NG";
				lbl_05.ForeColor = System.Drawing.Color.Red;
				txtsoluong.SelectAll();
				txtsoluong.Focus();
				return false;
			}
			else
			{
				try
				{
					if (int.Parse(txtsoluong.Text.Trim()) > 0)
					{
						iconbtnSave.Focus();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
			return true;
		}
		private void txtsoluong_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				checkSoluong();
			}
		}

		private bool IsOKData()
		{
			if (!checkQRCode())
			{
				return false;
			}
			if (!checkVitri())
			{
				return false;
			}
			if (!checkMaloi())
			{
				return false;
			}
			if (!checkSoluong())
			{
				return false;
			}
			return true;
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{

			if (IsOKData())
			{
				
				var proInfo= SmtProgramDAL.Instance.getByProgram(program);
				var error = new SMT_AOI_ERROR_RECORD
				{
					Program = program,
					Model = proInfo.Model,
					Lot = proInfo.LotNo,
					Line = linename,
					QRCode = txtQRCode.Text.Trim(),
					ErrorPosition = txtVitri.Text.Trim(),
					ErrorPart = txtpartcode.Text.Trim(),
					ErrorCode = cbMaloi.Text.Trim(),
					ErrorDesc = txtLoi.Text.Trim(),
					ErrorQty = int.Parse(txtsoluong.Text.Trim()),
					CreatedBy = Program.UserId,
					CreatedDate = CommonDAL.Instance.getSqlServerDatetime()
				};				
				try
				{
					string message=SMT_AOI_ERROR_RECORD_DAL.Instance.Add(error);
					if (message!="")
					{
						MessageBox.Show("Đã có lỗi không thể save: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else
					{
						setDefaultControl();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã có lỗi không thể save: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
