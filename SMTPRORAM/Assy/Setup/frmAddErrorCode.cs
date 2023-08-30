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
using System.Windows.Forms.DataVisualization.Charting;
using UnidenDAL.Jig.JIG;

namespace SMTPRORAM.Assy.Setup
{
	public partial class frmAddErrorCode : Form
	{
		DataTableCollection tableCollection;
		bool AddFlag = false;
		private long Id = 0;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmAddErrorCode()
		{
			InitializeComponent();
		}
		void _enable(bool t)
		{
			txtErrorCode.Enabled = t;
			txtErrorENDesc.Enabled = t;
			txtErrorVNDesc.Enabled = t;
			chkIsDisable.Enabled = t;
		}

		void ResetControll()
		{
			txtErrorCode.Text = "";
			txtErrorENDesc.Text = "";
			txtErrorVNDesc.Text = "";
			chkIsDisable.Checked = false;
		}
		void showHideControll(bool t)
		{
			iconbtnAdd.Visible = t;
			iconbtnEdit.Visible = t;
			iconbtnDelete.Visible = t;
			iconbtnCancel.Visible = !t;
			iconbtnSave.Visible = !t;
		}
		private void frmAddErrorCode_Load(object sender, EventArgs e)
		{
			showHideControll(true);
			_enable(false);
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
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
				CommonDAL.Instance.ShowDataGridView(dgView, LINEERRORCODE_DAL.Instance.searchData(search));
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			Search(txtSearch.Text);
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				Search(txtSearch.Text);
			}
		}

		private void iconbtnAdd_Click(object sender, EventArgs e)
		{
			AddFlag = true;
			showHideControll(false);
			_enable(true);
			ResetControll();
			txtErrorCode.Focus();
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			_enable(true);
			txtErrorCode.Enabled = false;
			showHideControll(false);
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{
			if (Id > 0)
			{
				if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					var delErrorCode = new UV_LINEERRORCODE();
					delErrorCode.ID = Id;
					delErrorCode.ErrorCode = txtErrorCode.Text.Trim();
					delErrorCode.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
					delErrorCode.UpdatedBy = Program.UserId;
					delErrorCode.IsDelete = true;
					string message;
					message = LINEERRORCODE_DAL.Instance.Delete(delErrorCode);
					if (message == "")
					{
						MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				CommonDAL.Instance.ShowDataGridView(dgView, LINEERRORCODE_DAL.Instance.getListErrorCode());
				showHideControll(true);
				ResetControll();
				_enable(false);
			}
		}
		private bool IsDataOK()
		{
			
			if (txtErrorCode.Text.Trim().Equals("") )
			{
				MessageBox.Show("Error Code Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtErrorCode.Focus();
				return false;
			}
			if (txtErrorENDesc.Text.Trim().Equals(""))
			{
				MessageBox.Show("Mô tả tiếng anh không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtErrorENDesc.Focus();
				return false;
			}
			if (txtErrorVNDesc.Text.Trim().Equals(""))
			{
				MessageBox.Show("Mô tả tiếng việt không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtErrorVNDesc.Focus();
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
					var lineError = new UV_LINEERRORCODE();
					lineError.ErrorCode = txtErrorCode.Text;
					lineError.ErrorVNDescription = txtErrorVNDesc.Text;
					lineError.ErrorENDescription = txtErrorENDesc.Text;
					lineError.IsDelete = false;
					lineError.CreatedBy = Program.UserId;
					lineError.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
					var checkExist = new UV_LINEERRORCODE();
					checkExist = LINEERRORCODE_DAL.Instance.checkExistsErrorCode(txtErrorCode.Text.Trim());
					if (checkExist != null)
					{
						MessageBox.Show("Đã tôn Tại process Name: " + checkExist.ErrorCode, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					else
					{
						message = LINEERRORCODE_DAL.Instance.Add(lineError);
						if (message == "")
						{
							MessageBox.Show("Save OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							CommonDAL.Instance.ShowDataGridView(dgView, LINEERRORCODE_DAL.Instance.getListErrorCode());
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
						var lineProcess = new UV_LINEERRORCODE();
						lineProcess.ErrorCode = txtErrorCode.Text;
						lineProcess.ErrorVNDescription = txtErrorVNDesc.Text;
						lineProcess.ErrorENDescription = txtErrorENDesc.Text;
						lineProcess.IsDelete = chkIsDisable.Checked;
						lineProcess.UpdatedBy = Program.UserId;						
						lineProcess.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
						message = LINEERRORCODE_DAL.Instance.Update(lineProcess);
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

		private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgView.RowCount > 0)
			{
				DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
				Id = long.Parse(row.Cells["ID"].Value.ToString());
				txtErrorCode.Text = row.Cells["ErrorCode"].Value.ToString();
				txtErrorENDesc.Text = row.Cells["ErrorENDescription"].Value.ToString();
				txtErrorVNDesc.Text= row.Cells["ErrorVNDescription"].Value.ToString();
				chkIsDisable.Checked = bool.Parse(row.Cells["IsDelete"].Value.ToString());
			}
		}

		private void iconbtnBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					txtFilename.Text = openFileDialog.FileName;
					tableCollection = CommonDAL.Instance.BrowserExcelToCombobox(txtFilename.Text);
					cbSheet.Items.Clear();
					foreach (System.Data.DataTable table in tableCollection)
						cbSheet.Items.Add(table.TableName); //add sheet to combo                    
				}
			}
		}

		private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<string> CheckControl = new List<string>();
			System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
			var _entities = new UVEntities();

			int count = 0;
			//dgView.DataSource = dt;
			if (dt != null)
			{
				List<UV_LINEERRORCODE> lstError = new List<UV_LINEERRORCODE>();
				lblProcess.Visible = true;
				lblProcess.Text = "Đang đọc dữ liệu từ file excel .....";
				lblProcess.Update();
				DateTime date = CommonDAL.Instance.getSqlServerDatetime();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					var errorCodes = new UV_LINEERRORCODE();
					errorCodes.ErrorCode = dt.Rows[i]["ErrorCode"].ToString().ToUpper();
					errorCodes.ErrorVNDescription = dt.Rows[i]["ErrorVNDescription"].ToString().ToUpper();
					errorCodes.ErrorENDescription = dt.Rows[i]["ErrorENDescription"].ToString().ToUpper();
					errorCodes.IsDelete = false;
					errorCodes.CreatedBy = Program.UserId;
					errorCodes.CreatedDate = date;				
					// Kiểm tra xem đã tồn tại mã lỗi này chưa?
					var checkExits = new UV_LINEERRORCODE();
					checkExits = LINEERRORCODE_DAL.Instance.checkExistsErrorCode(errorCodes.ErrorCode);
					if (checkExits == null)
					{
						lstError.Add(errorCodes);
					}
					else
					{
						CheckControl.Add( errorCodes.ErrorCode);						
					}					
				}

				lblProcess.Visible = false;
				try
				{
					lblProcess.Visible = true;
					lblProcess.Text = "Đang import data vào csdl .....";
					lblProcess.Update();
					string message = "";
					message = LINEERRORCODE_DAL.Instance.AddRange(lstError);
					if (message != "")
					{
						MessageBox.Show("Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else
					{
						if (CheckControl.Count != 0)
						{
							string control = "";
							for (int i = 0; i < CheckControl.Count; i++)
							{
								control += CheckControl[i] + "\n";
							}
							MessageBox.Show("Các mã sau đã có trong csdl: \n" + control, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					lblProcess.Visible = false;

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
					throw;
				}
				txtFilename.Text = "";
				cbSheet.Text = "";
				dgView.DataSource = lstError;
			}
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			showHideControll(true);
			_enable(false);
			ResetControll();
		}
	}
}
