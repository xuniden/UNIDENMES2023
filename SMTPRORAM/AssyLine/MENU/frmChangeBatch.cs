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
using UnidenDAL.AssyLine.MENU;
using UnidenDAL.AssyLine.UG;
using static ClosedXML.Excel.XLPredefinedFormat;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.MENU
{
	public partial class frmChangeBatch : Form
	{
		private string Reason = "";
		private bool flag;
		public frmChangeBatch()
		{
			InitializeComponent();
		}

		private void frmChangeBatch_Load(object sender, EventArgs e)
		{
			CreateAll();
		}
		private void CreateAll()
		{
			txtLot.Enabled = false;
			txtBatch.Enabled = false;
			txtCurrentBatch.Enabled = false;
			cbChangeTo.Enabled = false;
			rtReason.Enabled = false;
			btUpdate.Enabled = false;
			cbSelect.Focus();
		}

		private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cbSelect.Text.Trim()))
			{
				MessageBox.Show("Hãy chọn loại dữ liệu để thay đổi");
				cbSelect.Focus();
				return;
			}
			else
			{
				if (cbSelect.Text == "2.COM2")
				{
					flag = true;
					txtLot.Enabled = true;
					txtLot.Focus();
					cbSelect.Enabled = false;
				}
				else
				{
					flag = false;
					txtLot.Enabled = true;
					txtLot.Focus();
					cbSelect.Enabled = false;
				}
			}
		}
		private void CheckLotInput()
		{
			if (string.IsNullOrEmpty(txtLot.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập LOT Vào đây");
				txtLot.Focus();
				txtLot.SelectAll();
				return;
			}
			else
			{
				if (flag == true)
				{
					var checkLot = COM2_DAL.Instance.checkExistLot(txtLot.Text.Trim());
					if (checkLot == null)
					{
						MessageBox.Show("Lot Này chưa được thiết lập");
						txtLot.Focus();
						txtLot.SelectAll();
						return;
					}
					else
					{
						txtBatch.Enabled = true;
						txtBatch.Focus();
						txtLot.Enabled = false;
					}
				}
				else
				{
					var checkSaveLot = CBSAVEDATA_DAL.Instance.checkExistLot(txtLot.Text.Trim());
					if (checkSaveLot == null)
					{
						MessageBox.Show("Lot Này chưa có trong CSDL");
						txtLot.Focus();
						txtLot.SelectAll();
						return;
					}
					else
					{
						txtBatch.Enabled = true;
						txtBatch.Focus();
						txtLot.Enabled = false;
					}
				}
			}
		}

		private void txtLot_Validating(object sender, CancelEventArgs e)
		{
			CheckLotInput();
		}

		private void txtLot_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CheckLotInput();
			}
		}
		private void CheckBatchByLot()
		{
			if (string.IsNullOrEmpty(txtBatch.Text.Trim()))
			{
				MessageBox.Show("Phải nhập số batch vào đây");
				txtBatch.Focus();
				txtBatch.SelectAll();
				return;
			}
			else
			{
				if (flag == true)
				{
					var checkLotBatch = COM2_DAL.Instance.checkExistBatchByLot(txtLot.Text.Trim(), txtBatch.Text.Trim());
					if (checkLotBatch == null)
					{
						MessageBox.Show("Không có Batch này trong LOT: " + txtLot.Text);
						txtBatch.Focus();
						txtBatch.SelectAll();
						return;
					}
					else
					{
						txtCurrentBatch.Text = checkLotBatch.ErrorStatus;
						Reason = checkLotBatch.ErrorDetail;
						txtBatch.Enabled = false;
						cbChangeTo.Enabled = true;
						cbChangeTo.Focus();
					}
				}
				else
				{

					var checkLotBatch = CBSAVEDATA_DAL.Instance.checkLotvsBatch(txtLot.Text.Trim(), txtBatch.Text.Trim());
					{
						if (checkLotBatch == null)
						{
							MessageBox.Show("Không có Batch này trong LOT: " + txtLot.Text);
							txtBatch.Focus();
							txtBatch.SelectAll();
							return;
						}
						else
						{
							txtCurrentBatch.Text = checkLotBatch.ErrorStatus;
							Reason = checkLotBatch.ErrorDetail;
							txtBatch.Enabled = false;
							cbChangeTo.Enabled = true;
							cbChangeTo.Focus();
						}
					}
				}
			}
		}

		private void txtBatch_Validating(object sender, CancelEventArgs e)
		{
			CheckBatchByLot();
		}

		private void txtBatch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CheckBatchByLot();
			}
		}

		private void cbChangeTo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cbChangeTo.Text .Trim()))
			{
				MessageBox.Show("Hãy chọn NG hoặc OK ");
				cbChangeTo.Focus();
				return;
			}
			else if (cbChangeTo.Text.Trim().Equals(txtCurrentBatch.Text.Trim()))
			{
				MessageBox.Show("Hãy Chọn Trạng thái của Batch thay thế phải khác với Batch hiện tại");
				cbChangeTo.Focus();
				return;
			}
			else
			{
				rtReason.Enabled = true;
				rtReason.Focus();
			}
		}

		private void CheckReasonChange()
		{
			if (string.IsNullOrEmpty(rtReason.Text.Trim()))
			{
				MessageBox.Show("Hãy nhập lý do thay đổi tại đây");
				rtReason.Focus();
				rtReason.SelectAll();
				return;
			}
			else
			{
				btUpdate.Enabled = true;
				btUpdate.Focus();
			}

		}

		private void rtReason_Validating(object sender, CancelEventArgs e)
		{
			CheckReasonChange();
		}

		private void rtReason_KeyDown(object sender, KeyEventArgs e)
		{
			if(Keys.Enter == e.KeyCode)
			{
				CheckReasonChange();
			}
		}

		private void btUpdate_Click(object sender, EventArgs e)
		{
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			if (flag == true)
			{
				try
				{
					var addCom2 = new UVASSY_COM2
					{
						Lot = txtLot.Text.Trim(),
						BatchNo = txtBatch.Text.Trim(),
						CreatedDate = datetime,
						ChangeBatchTo = null,
						ErrorDetail = Reason + "--" + datetime + "-->" + rtReason.Text.Trim(),
						ErrorStatus = cbChangeTo.Text.Trim()
					};
					string message = COM2_DAL.Instance.Update(addCom2);
					if (string.IsNullOrEmpty(message))
					{
						MessageBox.Show("Đã cập nhật thành công !!!!");
						CommonDAL.Instance.ShowDataGridView(dgView, COM2_DAL.Instance.GetAllByUser(Program.UserId, txtLot.Text.Trim()));
						CreateAll();
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra: \n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã có lỗi xảy ra:  " + ex.Message);
					return;
				}

			}
			else
			{
				try
				{

					var csvSaveData = new UVASSY_CBSAVEDATA
					{
						Lot = txtLot.Text.Trim(),
						BatchNo = txtBatch.Text.Trim(),
						CreatedDate = datetime,
						ChangeBatchTo = null,
						ErrorDetail = Reason + "--" + datetime + "-->" + rtReason.Text.Trim(),
						ErrorStatus = cbChangeTo.Text
					};
					string message = CBSAVEDATA_DAL.Instance.Update(csvSaveData);
					if (string.IsNullOrEmpty(message))
					{
						MessageBox.Show("Đã cập nhật thành công !!!!");
						CommonDAL.Instance.ShowDataGridView(dgView, CBSAVEDATA_DAL.Instance.getDatabyLotvsUser(txtLot.Text.Trim(), Program.UserId));
						CreateAll();
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra: \n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã có lỗi xảy ra:  " + ex.Message);
					return;
				}
			}
		}
	}
}
