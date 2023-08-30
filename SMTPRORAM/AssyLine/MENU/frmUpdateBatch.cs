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
using UnidenDTO;

namespace SMTPRORAM.AssyLine.MENU
{

	public partial class frmUpdateBatch : Form
	{
		private bool flag;
		public frmUpdateBatch()
		{
			InitializeComponent();
		}

		private void frmUpdateBatch_Load(object sender, EventArgs e)
		{
			ResetAll();
		}
		private void ResetAll()
		{
			cbSelect.Enabled = true;
			txtBatch.Enabled = false;
			txtLot.Enabled = false;
			btUpdate.Enabled = false;
			rtDefect.Enabled = false;
			txtBatch.Text = "";
			txtLot.Text = "";
			rtDefect.Text = "";
			cbSelect.Text = "";
		}

		private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cbSelect.Text.Trim()))
			{
				MessageBox.Show("Hãy lựa chọn phù hợp");
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
					var checkLot=COM2_DAL.Instance.checkExistLot(txtLot.Text.Trim());
					if (checkLot==null)
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
					if (checkSaveLot==null)
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

		private void txtLot_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
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
					var checkLotBatch=COM2_DAL.Instance.checkExistBatchByLot(txtLot.Text.Trim(), txtBatch.Text.Trim());	
					if (checkLotBatch==null)
					{
						MessageBox.Show("Không có Batch này trong LOT: " + txtLot.Text);
						txtBatch.Focus();
						txtBatch.SelectAll();
						return;
					}
					else
					{
						rtDefect.Enabled = true;
						rtDefect.Focus();
						txtBatch.Enabled = false;
					}
				}
				else
				{
					
					var checkLotBatch = CBSAVEDATA_DAL.Instance.checkLotvsBatch(txtLot.Text.Trim(), txtBatch.Text.Trim());
					{
						if (checkLotBatch==null)
						{
							MessageBox.Show("Không có Batch này trong LOT: " + txtLot.Text);
							txtBatch.Focus();
							txtBatch.SelectAll();
							return;
						}
						else
						{
							rtDefect.Enabled = true;
							rtDefect.Focus();
							txtBatch.Enabled = false;
						}
					}
				}
			}
		}

		private void txtBatch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CheckBatchByLot();
			}
		}
		private void CheckErrorBy()
		{
			
			if (string.IsNullOrEmpty(txtBatch.Text.Trim()))
			{
				MessageBox.Show("Phải Lý do vào vào đây");
				rtDefect.Focus();
				rtDefect.SelectAll();
				return;
			}
			else
			{
				rtDefect.Enabled = true;
				rtDefect.Focus();
				btUpdate.Enabled = true;
			}
		}

		private void rtDefect_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CheckErrorBy();
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
						ErrorDetail = rtDefect.Text.Trim(),
						ErrorStatus = "NG"
					};
					string message = COM2_DAL.Instance.Update(addCom2);
					if (string.IsNullOrEmpty(message))
					{
						MessageBox.Show("Đã cập nhật thành công !!!!");
						CommonDAL.Instance.ShowDataGridView(dgView, COM2_DAL.Instance.GetAllByUser(Program.UserId, txtLot.Text.Trim()));
						ResetAll();
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra: \n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã có lỗi xảy ra: \n" + ex.Message);
					return;
				}				
									
			}
			else
			{
				try
				{
					
					var csvSaveData = new UVASSY_CBSAVEDATA
					{
						Lot=txtLot.Text.Trim(),
						BatchNo=txtBatch.Text.Trim(),
						CreatedDate=datetime,
						ChangeBatchTo = null,
						ErrorDetail=rtDefect.Text.Trim(),
						ErrorStatus="NG"
					};
					string message = CBSAVEDATA_DAL.Instance.Update(csvSaveData);
					if (string.IsNullOrEmpty(message))
					{
						MessageBox.Show("Đã cập nhật thành công !!!!");
						CommonDAL.Instance.ShowDataGridView(dgView, CBSAVEDATA_DAL.Instance.getDatabyLotvsUser( txtLot.Text.Trim(), Program.UserId));
						ResetAll();
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra: \n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}					
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã có lỗi xảy ra:  \n" + ex.Message);
					return;
				}
			}
		}
	}
}
