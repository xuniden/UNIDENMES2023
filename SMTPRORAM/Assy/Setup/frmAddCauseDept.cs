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
using UnidenDAL.Assy.Setup;

namespace SMTPRORAM.Assy.Setup
{
	public partial class frmAddCauseDept : Form
	{
		DataTableCollection tableCollection;
		bool AddFlag = false;
		private long Id = 0;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmAddCauseDept()
		{
			InitializeComponent();
		}
		void _enable(bool t)
		{
			txtDept.Enabled = t;		
		}

		void ResetControll()
		{
			txtDept.Text = "";			
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
				CommonDAL.Instance.ShowDataGridView(dgView, LINECAUSEDEPT_DAL.Instance.searchData(search));
			}
		}
		private void frmAddCauseDept_Load(object sender, EventArgs e)
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
			txtDept.Focus();
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			_enable(true);
			txtDept.Enabled = false;
			showHideControll(false);
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{
			if (Id > 0)
			{
				if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					var delDept = new UV_LINECAUSEDEPT();
					delDept.ID = Id;
					delDept.DeptCode = txtDept.Text.Trim();							
					string message;
					message = LINECAUSEDEPT_DAL.Instance.Delete(delDept.DeptCode);
					if (message == "")
					{
						MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				CommonDAL.Instance.ShowDataGridView(dgView, LINECAUSEDEPT_DAL.Instance.getListCauseDept());
				showHideControll(true);
				ResetControll();
				_enable(false);
			}
		}
		private bool IsDataOK()
		{
			if (txtDept.Text.Trim().Equals(""))
			{
				MessageBox.Show("Dept Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtDept.Focus();
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
					var causeDept = new UV_LINECAUSEDEPT();
					causeDept.DeptCode = txtDept.Text.Trim();				
					causeDept.CreatedBy = Program.UserId;
					causeDept.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
					var checkExist = new UV_LINECAUSEDEPT();
					checkExist = LINECAUSEDEPT_DAL.Instance.checkExistsCauseDept(txtDept.Text.Trim());
					if (checkExist != null)
					{
						MessageBox.Show("Đã tôn Tại process Name: " + checkExist.DeptCode, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else
					{
						message = LINECAUSEDEPT_DAL.Instance.Add(causeDept);
						if (message == "")
						{
							MessageBox.Show("Save OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							CommonDAL.Instance.ShowDataGridView(dgView, LINECAUSEDEPT_DAL.Instance.getListCauseDept());
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
						var causeDept = new UV_LINECAUSEDEPT();
						causeDept.DeptCode = txtDept.Text.Trim();						
						causeDept.UpdatedBy = Program.UserId;
						causeDept.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
						message = LINECAUSEDEPT_DAL.Instance.Update(causeDept);
						if (message == "")
						{
							MessageBox.Show("Sửa  OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							CommonDAL.Instance.ShowDataGridView(dgView, LINEERRORCODE_DAL.Instance.getListErrorCode());
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
				txtDept.Text = row.Cells["DeptCode"].Value.ToString();
				
			}
		}
	}
}
