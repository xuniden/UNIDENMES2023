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
	public partial class frmCutLot : Form
	{
		private List<EASTECH_PROGRAMHISTORY> etHistoryList = new List<EASTECH_PROGRAMHISTORY>();
		public frmCutLot()
		{
			InitializeComponent();
		}

		private void frmCutLot_Load(object sender, EventArgs e)
		{
			lbl_01.Text = string.Empty;
			lbl_02.Text = string.Empty;
			lbl_03.Text = string.Empty;
			lbl_04.Text = string.Empty;
			txtLineName.Text = string.Empty;
			txtprgpartlist.Text = string.Empty;
			txtfdrno.Text = string.Empty;
			txtpartcode.Text = string.Empty;
			txtLineName.Focus();
		}
		private void SetStatusLabels(Label lbl, string status)
		{
			lbl.Text = status;
			lbl.ForeColor = status == "OK" ? System.Drawing.Color.Green : System.Drawing.Color.Red;
		}
		private bool checkSMTLine()
		{
			if (string.IsNullOrEmpty(txtLineName.Text.Trim()))
			{
				SetStatusLabels(lbl_01, "NG");
				txtLineName.Focus();
				return false;
			}			
			var smtLine = SmtLineDAL.Instance.checkSMTLine(txtLineName.Text.Trim().ToUpper());
			if (smtLine == null)
			{
				return false;
			}
			return true;
		}

		private void txtLineName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				// Kiểm tra xem Line có trong csdl không?
				// Nếu không có thì không cho qua.
				// txtLineName.Text = txtLineName.Text.Trim().ToUpper();
				if (checkSMTLine())
				{
					SetStatusLabels(lbl_01, "OK");
					txtprgpartlist.Focus();
				}
				else
				{
					SetStatusLabels(lbl_01, "NG");
					txtLineName.SelectAll();
					txtLineName.Focus();
				}
			}
		}
		private bool checkProgram()
		{
			if (string.IsNullOrEmpty(txtprgpartlist.Text.Trim()))
			{
				SetStatusLabels(lbl_02, "NG");
				txtprgpartlist.Focus();
				return false;
			}			
			var checkProgram = SmtProgramDAL.Instance.getByProgram(txtprgpartlist.Text.Trim());
			if (checkProgram == null)
			{
				return false;
			}
			return true;
		}

		private void txtprgpartlist_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkProgram())
				{
					SetStatusLabels(lbl_02, "OK");
					txtfdrno.Focus();
				}
				else
				{
					SetStatusLabels(lbl_02, "NG");
					txtprgpartlist.Focus();
					txtprgpartlist.SelectAll();
				}
			}
		}
		private bool checkFeeder()
		{
			if (string.IsNullOrEmpty(txtfdrno.Text.Trim()))
			{
				SetStatusLabels(lbl_03, "NG");
				txtfdrno.Focus();
				return false;
			}			
			var checkFeeder = SmtProgramDAL.Instance.checkFeeder(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim());
			if (checkFeeder == null)
			{
				return false;
			}
			return true;
		}

		private void txtfdrno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkFeeder())
				{
					SetStatusLabels(lbl_03, "OK");
					txtpartcode.Focus();
				}
				else
				{
					SetStatusLabels(lbl_03, "NG");
					txtfdrno.Focus();
					txtfdrno.SelectAll();
				}
			}
		}
		private bool checkPartcode()
		{
			if (string.IsNullOrEmpty(txtpartcode.Text.Trim()))
			{
				SetStatusLabels(lbl_04, "NG");
				txtpartcode.Focus();
				return false;
			}
			
			string inputString = txtpartcode.Text.Trim();
			char[] separator = { ';' };
			string[] result = inputString.Split(separator);
			if (result.Length == 1)
			{
				txtpartcode.Text = result[0];
			}
			else
			{
				txtpartcode.Text = result[1];
			}
			var checkPartcode = SmtProgramDAL.Instance.checkPartcodeCutLot(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtpartcode.Text.Trim());

			if (checkPartcode == null)
			{
				SetStatusLabels(lbl_04, "NG");
				txtpartcode.Focus();
				return false;
			}
			return true;
		}

		private void txtpartcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				if (checkPartcode())
				{
					SetStatusLabels(lbl_04, "OK");
					SaveDataCutLot();
				}
				else
				{
					SetStatusLabels(lbl_04, "NG");
					txtpartcode.Focus();
				}
			}
		}
		private bool isOKData()
		{
			if (!checkSMTLine())
			{
				SetStatusLabels(lbl_01, "NG");
				txtLineName.Focus();
			}
			if (!checkProgram())
			{
				SetStatusLabels(lbl_02, "NG");
				txtprgpartlist.Focus();
			}
			if (!checkFeeder())
			{
				SetStatusLabels(lbl_03, "NG");
				txtfdrno.Focus();
			}
			if (!checkPartcode())
			{
				SetStatusLabels(lbl_04, "NG");
				txtpartcode.Focus();
			}
			return true;
		}
		private void SaveDataCutLot()
		{
			if (isOKData())
			{
				var dataBOM = SmtProgramDAL.Instance.checkPartcodeCutLot(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtpartcode.Text.Trim());
				if (dataBOM != null)
				{
					var proHistory = new PROGRAMHISTORY
					{
						programpartlist = txtprgpartlist.Text.Trim(),
						fdrno = txtfdrno.Text.Trim(),
						partscode = txtpartcode.Text.Trim(),
						ndesc = dataBOM.ndesc,
						usage = dataBOM.usage,
						checkedby = Program.UserId + " OK" + " " + txtLineName.Text.Trim().ToUpper(),
						checkedtime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss"),
						rp = dataBOM.rp,
						rep1 = dataBOM.rep1,
						rep2 = dataBOM.rep2,
						rep3 = dataBOM.rep3,
						rep4 = dataBOM.rep4,
						rep5 = dataBOM.rep5,
						reqqty = 0,
						datecode = "Cut lot",
						changedby = Program.Dept,
						changedtime = ""
					};

					var etHistory = new EASTECH_PROGRAMHISTORY
					{
						programpartlist = txtprgpartlist.Text.Trim(),
						fdrno = txtfdrno.Text.Trim(),
						partscode = txtpartcode.Text.Trim(),
						ndesc = dataBOM.ndesc,
						usage = dataBOM.usage,
						checkedby = Program.UserId + " OK" + " " + txtLineName.Text.Trim().ToUpper(),
						checkedtime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss"),
						reqqty = 0,
						datecode = "Cut lot",
						pkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim() + "_" + txtfdrno.Text.Trim() + "_" + txtpartcode.Text.Trim(),
						psubkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim().ToUpper() + "_" + txtfdrno.Text.Trim(),
						SoPCBCothedung = 0,
						remark1 = txtLineName.Text.Trim(),
						remark2 = Program.Dept,
						remark3 = "",
						counts = 0,
					};
					var checkMax = EASTECH_PROGRAMHISTORY_DAL.Instance.getMaxSolanthaylinhkien(etHistory.programpartlist,etHistory.fdrno,etHistory.remark1);
					if (checkMax != null)
					{
						etHistory.Solanthaylinhkien = checkMax.Solanthaylinhkien + 1;
					}
					else
					{
						etHistory.Solanthaylinhkien = 1;
					}
					etHistoryList.Add(etHistory);
					string message = EASTECH_PROGRAMHISTORY_DAL.Instance.InsertETHistoryVsProgramHistory(proHistory, etHistory);

					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.OK);
						dataGridView1.DataSource = null;
						dataGridView1.DataSource = etHistoryList;
						dataGridView1.Refresh();
						txtLineName.Enabled = false;
						txtprgpartlist.Enabled = false;
						lbl_03.Text = string.Empty;
						lbl_04.Text = string.Empty;
						txtfdrno.Text = string.Empty;
						txtpartcode.Text = string.Empty;
						txtfdrno.Focus();
					}
					else
					{
						CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					#region Old Code
					/*
					string messageET = "";
					string messageUV = "";
					using (var transaction = new CommonDAL())
					{
						try
						{
							transaction.BeginTransaction();
							messageUV = PROGRAMHISTORY_DAL.Instance.Add(proHistory);
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
									dataGridView1.DataSource = null;
									dataGridView1.DataSource = etHistoryList;
									dataGridView1.Refresh();
									txtLineName.Enabled = false;
									txtprgpartlist.Enabled = false;
									txtfdrno.Text = string.Empty;
									txtpartcode.Text = string.Empty;
									lbl_03.Text = string.Empty;
									lbl_04.Text = string.Empty;
									txtfdrno.Focus();
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
				else
				{
					MessageBox.Show("Không tìm thấy dữ liệu có program: " + txtprgpartlist.Text.Trim() + "\n"
						+ "Feeder: " + txtfdrno.Text.Trim() + "\n"
						+ "Partcode: " + txtpartcode.Text.Trim());
					return;
				}

			}
		}
		private void HandleAddError(CommonDAL transaction)
		{
			transaction.RollbackTransaction();
			CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
			MessageBox.Show("Đã có lỗi xảy ra khi ktra dữ liệu CUT LOT \n"
				+ "Hãy báo lại cho IT để fix lỗi trước khi làm tiếp. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private void HandleExceptionAndRollback(CommonDAL transaction)
		{
			transaction.RollbackTransaction();
			return;
		}
		
	}
}
