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
using UnidenDAL.AssyLine.ETASSY;
using Microsoft.VisualBasic.FileIO;
using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Wordprocessing;

namespace SMTPRORAM.AssyLine.ETASSY
{
	public partial class frmPCBCodeSetup : Form
	{
		private int Id = 0;
		private bool AddFlag = false;
		private int totalPages = 1;
		private List<SYS_UserButtonFunction> lstUBFunction;
		private List<UVASSY_EASTECHPCBCODE> allData;
		
		public frmPCBCodeSetup()
		{
			InitializeComponent();
		}
		private void frmPCBCodeSetup_Load(object sender, EventArgs e)
		{
			allData = EASTECHPCBCODE_DAL.Instance.GetAll();
			LoadData(allData);
			showHideControll(true);
			ResetControll();

			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}
		private void LoadData(List<UVASSY_EASTECHPCBCODE> lstData)
		{			
			List<UVASSY_EASTECHPCBCODE> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridView, pagedData);
			int totalRecords = allData.Count;
			labelTotalRecords.Text=totalRecords.ToString();
			int totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";

		}
		void _enable(bool t)
		{
			txtPcbCode.Enabled = t;
			txtModel.Enabled = t;
			cbStatus.Enabled = t;
		}

		void ResetControll()
		{
			txtModel.Text = string.Empty;
			txtPcbCode.Text = string.Empty;
			cbStatus.Text = "--Select--";

			txtModel.Enabled=false;
			txtPcbCode.Enabled=false;
			cbStatus.Enabled=false;			
		}
		void showHideControll(bool t)
		{
			iconbtnAdd.Visible = t;
			iconbtnEdit.Visible = t;
			iconbtnDelete.Visible = t;
			iconbtnCancel.Visible = !t;
			iconbtnSave.Visible = !t;
		}

		private bool checkModel()
		{
			if (string.IsNullOrEmpty(txtModel.Text.Trim()))
			{
				MessageBox.Show("Không được để trống MODEL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtModel.Focus();
				return false;
			}
			return true;
		}
		private bool checkPCBCode()
		{
			if (string.IsNullOrEmpty(txtPcbCode.Text.Trim()))
			{
				MessageBox.Show("Không được để trống PCB CODE", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPcbCode.Focus();
				return false;
			}
			return true;
		}
		private bool checkStatus()
		{
			if (cbStatus.Text.Trim().Equals("--Select--"))
			{
				MessageBox.Show("Hãy chọn trạng thái", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbStatus.Focus();
				return false;
			}
			return true;
		}

		private bool isOkdata()
		{
			if (!checkModel())
			{
				return false;
			}
			if (!checkPCBCode())
			{
				return false;
			}
			if (!checkStatus())
			{
				return false;
			}
			return true;
		}

		private void txtModel_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkModel())
				{
					txtPcbCode.Enabled = true;
					txtPcbCode.Focus();
				}
				else
				{
					txtModel.Focus();
				}
			}
		}

		private void txtPcbCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkPCBCode())
				{
					cbStatus.Enabled = true;
					cbStatus.Focus();
				}
				else
				{
					txtPcbCode.Focus();
				}
			}
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (isOkdata())
			{
				var datetime = CommonDAL.Instance.getSqlServerDatetime();
				var newRecord = new UVASSY_EASTECHPCBCODE
				{
					PcbKey = txtModel.Text.Trim()+txtPcbCode.Text.Trim()+ cbStatus.Text.Trim(),
					Model = txtModel.Text.Trim(),
					PCBCode = txtPcbCode.Text.Trim(),
					Status=cbStatus.Text.Trim(),					
				};
				if (AddFlag==true)
				{
					newRecord.CreatedBy = Program.UserId;
					newRecord.CreatedDate = datetime;
					string message= EASTECHPCBCODE_DAL.Instance.Add(newRecord);
					if (string.IsNullOrEmpty(message))
					{
						allData = EASTECHPCBCODE_DAL.Instance.GetAll();
						LoadData(allData);
						ResetControll();
						showHideControll(true);
						txtModel.Enabled = true;

					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information );
						return;
					}
				}
				if (AddFlag==false&&Id>0)
				{
					newRecord.Id = Id;
					newRecord.UpdatedDate = datetime;
					newRecord.UpdatedBy = Program.UserId;
					string message=EASTECHPCBCODE_DAL.Instance.Update(newRecord);
					if (string.IsNullOrEmpty(message))
					{
						allData = EASTECHPCBCODE_DAL.Instance.GetAll();
						LoadData(allData);
						ResetControll();
						showHideControll(true);
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi Update dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}

		}

		private void iconbtnAdd_Click(object sender, EventArgs e)
		{
			AddFlag = true;
			showHideControll(false);
			_enable(true);
			ResetControll();
			txtModel.Enabled = true;
			txtModel.Focus();
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			_enable(true);
			txtModel.Enabled = false;
			showHideControll(false);
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{
			if (Id>0)
			{
				string message = EASTECHPCBCODE_DAL.Instance.Delete(Id);
				if (string.IsNullOrEmpty(message))
				{
					allData = EASTECHPCBCODE_DAL.Instance.GetAll();
					LoadData(allData);
					ResetControll();
					showHideControll(true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			ResetControll();
			showHideControll(true);
		}

		private void searchData(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSearch.Focus();
				return;
			}
			else
			{
				allData = EASTECHPCBCODE_DAL.Instance.searchData(search);
				LoadData(allData);
			}
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				searchData(txtSearch.Text.Trim());
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			searchData(txtSearch.Text.Trim());
		}

		private void btBrowser_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtpath.Text = filename;				
			}
		}

		private void btImport_Click(object sender, EventArgs e)
		{
			bool flag = true;
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var lstAdd= new List<UVASSY_EASTECHPCBCODE>();
			if (string.IsNullOrEmpty(txtpath.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtpath.Focus();
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtpath.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");					
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 3)
						{
							flag = false;
							break;
						}					
					}
				}
				if (flag==false)
				{
					MessageBox.Show("Dữ liệu import bị lỗi. \n Hãy kiểm tra lại dữ liệu khi import","Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				using (TextFieldParser parser1 = new TextFieldParser(txtpath.Text))
				{
					parser1.ReadLine();
					parser1.TextFieldType = FieldType.Delimited;
					parser1.SetDelimiters(",");					
					while (!parser1.EndOfData)
					{
						string[] fields = parser1.ReadFields();
						var csv = new UVASSY_EASTECHPCBCODE
						{
							PcbKey = fields[0].ToString() + fields[1].ToString() + fields[2].ToString(),
							Model = fields[0].ToString(),
							PCBCode = fields[1].ToString(),
							Status = fields[2].ToString(),
							CreatedDate = datetime,
							CreatedBy = Program.UserId
						};
						lstAdd.Add(csv);						
					}
					
					string message= EASTECHPCBCODE_DAL.Instance.AddRange(lstAdd);
					if (string.IsNullOrEmpty(message))
					{
						txtpath.Text = "";
						MessageBox.Show("Đã import dữ liệu thành công ","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtpath.Focus();
						return;
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu "+ message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}									
			}
		}

		private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView.RowCount > 0)
			{
				DataGridViewRow row = dataGridView.SelectedCells[0].OwningRow;
				Id=int.Parse( row.Cells["Id"].Value.ToString());
				txtModel.Text = row.Cells["Model"].Value.ToString();
				txtPcbCode.Text = row.Cells["PCBCode"].Value.ToString();
				cbStatus.Text = row.Cells["Status"].Value.ToString();
			}
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadData(allData);
			}
		}

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			Program.currentPage++;
			LoadData(allData);
		}

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadData(allData);
		}

		private void iconbtnLast_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadData(allData);
		}
	}
}
