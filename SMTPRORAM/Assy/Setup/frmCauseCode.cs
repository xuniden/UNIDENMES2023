using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Assy.Setup;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.SysControl;

namespace SMTPRORAM.Assy.Setup
{
	public partial class frmCauseCode : Form
	{
		DataTableCollection tableCollection;
		bool AddFlag = false;
		private long Id = 0;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmCauseCode()
		{
			InitializeComponent();
		}
		void _enable(bool t)
		{
			txtCauseCode.Enabled = t;
		}

		void ResetControll()
		{
			txtCauseCode.Text = "";
		}
		void showHideControll(bool t)
		{
			iconbtnAdd.Visible = t;
			iconbtnEdit.Visible = t;
			iconbtnDelete.Visible = t;
			iconbtnCancel.Visible = !t;
			iconbtnSave.Visible = !t;
		}
		private void Search(string search)
		{
			if (search.Equals(""))
			{
				MessageBox.Show("Hãy nhập điều kiện tìm kiếm vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSearch.Focus();
				return;
			}
			else
			{
				CommonDAL.Instance.ShowDataGridView(dgView, LINECAUSECODE_DAL.Instance.searchData(search));
			}
		}
		private void frmCauseCode_Load(object sender, EventArgs e)
		{
			showHideControll(true);
			_enable(false);
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				Search(txtSearch.Text);
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			Search(txtSearch.Text);
		}

		private void iconbtnAdd_Click(object sender, EventArgs e)
		{
			AddFlag = true;
			showHideControll(false);
			_enable(true);
			ResetControll();
			txtCauseCode.Focus();
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			_enable(true);
			txtCauseCode.Enabled = false;
			showHideControll(false);
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{
			if (Id > 0)
			{
				if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					var delCauseCode = new UV_LINECAUSECODE();
					delCauseCode.ID = Id;
					delCauseCode.CauseCode = txtCauseCode.Text.Trim();
					string message;
					message = LINECAUSECODE_DAL.Instance.Delete(delCauseCode.CauseCode);
					if (message == "")
					{
						MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				CommonDAL.Instance.ShowDataGridView(dgView, LINECAUSECODE_DAL.Instance.getListCauseCode());
				showHideControll(true);
				ResetControll();
				_enable(false);
			}
		}
		private bool IsDataOK()
		{
			if (txtCauseCode.Text.Trim().Equals(""))
			{
				MessageBox.Show("Dept Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtCauseCode.Focus();
				return false;
			}
			return true;
		}
		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (IsDataOK() == true)
			{
				string message = "";
				if (AddFlag)
				{
					var causeCode = new UV_LINECAUSECODE();
					causeCode.CauseCode = txtCauseCode.Text.Trim();
					causeCode.CreatedBy = Program.UserId;
					causeCode.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
					var checkExist = new UV_LINECAUSECODE();
					checkExist = LINECAUSECODE_DAL.Instance.checkExistsCauseCode(txtCauseCode.Text.Trim());
					if (checkExist != null)
					{
						MessageBox.Show("Đã tôn Tại Mã lỗi này: " + checkExist.CauseCode, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else
					{
						message = LINECAUSECODE_DAL.Instance.Add(causeCode);
						if (message == "")
						{
							MessageBox.Show("Save OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							CommonDAL.Instance.ShowDataGridView(dgView, LINECAUSECODE_DAL.Instance.getListCauseCode());
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
				else
				{
					if (Id > 0)
					{
						var causeCode = new UV_LINECAUSECODE();
						causeCode.CauseCode = txtCauseCode.Text.Trim();
						causeCode.UpdatedBy = Program.UserId;
						causeCode.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
						message = LINECAUSECODE_DAL.Instance.Update(causeCode);
						if (message == "")
						{
							MessageBox.Show("Sửa  OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							CommonDAL.Instance.ShowDataGridView(dgView, LINECAUSECODE_DAL.Instance.getListCauseCode());
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra khi sửa bản ghi: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							//return;
						}
					}
				}
				AddFlag = false;
				showHideControll(true);
				ResetControll();
				_enable(false);
			}
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			showHideControll(true);
			_enable(false);
			ResetControll();
		}

		private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgView.RowCount > 0)
			{
				DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
				Id = long.Parse(row.Cells["ID"].Value.ToString());
				txtCauseCode.Text = row.Cells["CauseCode"].Value.ToString();

			}
		}
	}
}
