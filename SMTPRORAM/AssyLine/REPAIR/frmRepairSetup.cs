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
using UnidenDAL.Smt.DataControl;
using FontAwesome.Sharp;
using DocumentFormat.OpenXml.Office2010.Excel;
using UnidenDAL.AssyLine.REPAIR;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Forms.TextBox;

namespace SMTPRORAM.AssyLine.REPAIR
{
	public partial class frmRepairSetup : Form
	{
		private int Id01 = 0;
		private bool AddFlag01 = false;

		private int Id02 = 0;
		private bool AddFlag02 = false;

		private int Id03 = 0;
		private bool AddFlag03 = false;

		private int Id04 = 0;
		private bool AddFlag04 = false;

		private int Id05 = 0;
		private bool AddFlag05 = false;

		private int totalPages = 1;
		private List<SYS_UserButtonFunction> lstUBFunction;
		private List<UVASSY_DEPTCODE> allDataDept;
		private List<UVASSY_CAUSECODE> allDataCause;
		private List<UVASSY_DEFECTCODE> allDataDefect;
		private List<UVASSY_REASONCODE> allDataReason;
		private List<UVASSY_ERRORCODE> allDataError;
		public frmRepairSetup()
		{
			InitializeComponent();			
		}

		private void frmRepairSetup_Load(object sender, EventArgs e)
		{
			showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
			ResetControll(txtDefectCode, txtDefectDesc);
			labelTotalRecords.Text=string.Empty;
			labelPageInfo.Text=string.Empty;
			allDataDefect = DEFECTCODE_DAL.Instance.getAllInfo();
			LoadData01(allDataDefect);


			showHideControll(iconbtnAddR, iconbtnEditR, iconbtnDeleteR, iconbtnCancelR, iconbtnSaveR, true);
			ResetControll(txtReasonCode, txtReasonDesc);
			labelTotalRecordsR.Text = string.Empty;
			labelPageInfoR.Text = string.Empty;
			allDataReason = REASONCODE_DAL.Instance.getAllInfo();
			LoadDataReason(allDataReason);


			showHideControll(iconbtnAddC, iconbtnEditC, iconbtnDeleteC, iconbtnCancelC, iconbtnSaveC, true);
			ResetControll(txtCauseCode, txtCauseDesc);
			labelTotalRecordsC.Text = string.Empty;
			labelPageInfoC.Text = string.Empty;
			allDataCause= CAUSECODE_DAL.Instance.getAllInfo();
			LoadDataCauseCode(allDataCause);


			showHideControll(iconbtnAddD, iconbtnEditD, iconbtnDeleteD, iconbtnCancelD, iconbtnSaveD, true);
			ResetControll(txtDeptCode, txtDeptDesc);
			labelTotalRecordsD.Text = string.Empty;
			labelPageInfoD.Text = string.Empty;
			allDataDept = DEPTCODE_DAL.Instance.getAllInfo();
			LoadDataDept(allDataDept);


			showHideControll(iconbtnAddE, iconbtnEditE, iconbtnDeleteE, iconbtnCancelE, iconbtnSaveE, true);
			ResetControll(txtErrorCode, txtErrorDesc);
			labelTotalRecordsE.Text = string.Empty;
			labelPageInfoE.Text = string.Empty;
			allDataError = ERRORCODE_DAL.Instance.getAllInfo();
			LoadDataError(allDataError);


			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}

		void _enable(TextBox txt1, TextBox txt2, bool t)
		{
			txt1.Enabled = t;
			txt2.Enabled = t;			
		}

		void ResetControll(TextBox txt1, TextBox txt2)
		{
			txt1.Text = string.Empty;
			txt2.Text = string.Empty;


			txt1.Enabled = false;
			txt2.Enabled = false;
			
		}
		void showHideControll(IconButton add, IconButton edit, IconButton delete, IconButton cancel, IconButton save, bool t)
		{
			add.Visible = t;
			edit.Visible = t;
			delete.Visible = t;
			cancel.Visible = !t;
			save.Visible = !t;
		}

		private void iconbtnAdd_Click(object sender, EventArgs e)
		{
			AddFlag01 = true;
			showHideControll(iconbtnAdd,iconbtnEdit,iconbtnDelete,iconbtnCancel,iconbtnSave, false);			
			ResetControll(txtDefectCode, txtDefectDesc);
			_enable(txtDefectCode, txtDefectDesc, true);
			txtDefectCode.Focus();
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			AddFlag01 = false;
			_enable(txtDefectCode, txtDefectDesc, true);
			txtDefectCode.Enabled = false;
			showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, false);
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{
			if (Id01 > 0)
			{
				string message = DEFECTCODE_DAL.Instance.Remove(Id01);
				if (string.IsNullOrEmpty(message))
				{
					allDataDefect = DEFECTCODE_DAL.Instance.getAllInfo();
					LoadData01(allDataDefect);
					ResetControll(txtDefectCode, txtDefectDesc);
					showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtDefectCode.Text.Trim()))
			{
				MessageBox.Show("Nhập giá trị vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDefectCode.Focus();
				return;
			}
			else
			{
				var checkExist= DEFECTCODE_DAL.Instance.checkExistEfectCode(txtDefectCode.Text.Trim());
				if (checkExist!=null && AddFlag01==true)
				{
					MessageBox.Show("Effect code này đã có trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtDefectCode.Focus();
					return;
				}
			}		
			
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var newRecord = new UVASSY_DEFECTCODE
			{
				Defect_Code = txtDefectCode.Text,
				Defect_Desc = txtDefectDesc.Text				
			};
			if (AddFlag01 == true)
			{
				newRecord.CreatedBy = Program.UserId;
				newRecord.CreatedDate = datetime;
				string message = DEFECTCODE_DAL.Instance.Add(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataDefect = DEFECTCODE_DAL.Instance.getAllInfo();
					LoadData01(allDataDefect);
					ResetControll(txtDefectCode,txtDefectDesc);
					showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if (AddFlag01 == false && Id01 > 0)
			{
				newRecord.ID = Id01;
				newRecord.UpdatedDate = datetime;
				newRecord.UpdatedBy = Program.UserId;
				newRecord.Defect_Desc = txtDefectDesc.Text.Trim();
				string message = DEFECTCODE_DAL.Instance.Update(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataDefect = DEFECTCODE_DAL.Instance.getAllInfo();
					LoadData01(allDataDefect);
					ResetControll(txtDefectCode, txtDefectDesc);
					showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, true);					
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi Update dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			
		}
		private void LoadData01(List<UVASSY_DEFECTCODE> lstData)
		{
			List<UVASSY_DEFECTCODE> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridView01, pagedData);
			int totalRecords = lstData.Count;
			labelTotalRecords.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";
		}
		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			ResetControll(txtDefectCode, txtDefectDesc);
			showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadData01(allDataDefect);
			}
		}

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadData01(allDataDefect);
		}

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			if (Program.currentPage>=totalPages)
			{
				Program.currentPage = totalPages;
			}
			else
			{
				Program.currentPage++;
			}			
			LoadData01(allDataDefect);
		}
	

		private void iconbtnLast_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadData01(allDataDefect);
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
				txtBrowser.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btImport_Click(object sender, EventArgs e)
		{
			bool flag = true;
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var lstAdd = new List<UVASSY_DEFECTCODE>();
			var lstUpdate = new List<UVASSY_DEFECTCODE>();
			if (string.IsNullOrEmpty(txtBrowser.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBrowser.Focus();
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtBrowser.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 2)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag == false)
				{
					MessageBox.Show("Dữ liệu import bị lỗi. \n Hãy kiểm tra lại dữ liệu khi import", "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				using (TextFieldParser parser1 = new TextFieldParser(txtBrowser.Text))
				{
					parser1.ReadLine();
					parser1.TextFieldType = FieldType.Delimited;
					parser1.SetDelimiters(",");
					while (!parser1.EndOfData)
					{
						string[] fields = parser1.ReadFields();
						var csv = new UVASSY_DEFECTCODE
						{							
							Defect_Code=fields[0].ToString(),
							Defect_Desc = fields[1].ToString()	
						};
						var checkE=DEFECTCODE_DAL.Instance.checkExistEfectCode(csv.Defect_Code);
						if (checkE==null)
						{
							csv.CreatedDate = datetime;
							csv.CreatedBy = Program.UserId;
							lstAdd.Add(csv);
						}
						else
						{
							csv.ID = checkE.ID;
							csv.UpdatedDate = datetime;
							csv.UpdatedBy = Program.UserId;
							lstUpdate.Add(csv);							
						}
					}

					string message = DEFECTCODE_DAL.Instance.AddUpdateRange(lstAdd,lstUpdate);
					if (string.IsNullOrEmpty(message))
					{
						txtBrowser.Text = string.Empty;
						MessageBox.Show("Đã import dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						allDataDefect = DEFECTCODE_DAL.Instance.getAllInfo();
						LoadData01(allDataDefect);
						return;
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
		}

		private void dataGridView01_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView01.RowCount > 0)
			{
				DataGridViewRow row = dataGridView01.SelectedCells[0].OwningRow;
				Id01 = int.Parse(row.Cells["ID"].Value.ToString());
				txtDefectCode.Text = row.Cells["Defect_Code"].Value.ToString();
				txtDefectDesc.Text = row.Cells["Defect_Desc"].Value.ToString();				
			}
		}
		
		private void iconbtnLoadAll_Click(object sender, EventArgs e)
		{
			allDataDefect = DEFECTCODE_DAL.Instance.getAllInfo();
			LoadData01(allDataDefect);
		}





		private void LoadDataReason(List<UVASSY_REASONCODE> lstData)
		{
			List<UVASSY_REASONCODE> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridViewR, pagedData);
			int totalRecords = lstData.Count;
			labelTotalRecordsR.Text=totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfoR.Text = $"Page {Program.currentPage} of {totalPages}";

		}

		private void iconbtnAddR_Click(object sender, EventArgs e)
		{
			AddFlag02 = true;
			showHideControll(iconbtnAddR, iconbtnEditR, iconbtnDeleteR, iconbtnCancelR, iconbtnSaveR, false);
			ResetControll(txtReasonCode, txtReasonDesc);
			_enable(txtReasonCode, txtReasonDesc, true);
			txtReasonCode.Focus();
		}

		private void iconbtnEditR_Click(object sender, EventArgs e)
		{
			AddFlag02 = false;
			_enable(txtReasonCode, txtReasonDesc, true);
			txtReasonCode.Enabled = false;
			showHideControll(iconbtnAddR, iconbtnEditR, iconbtnDeleteR, iconbtnCancelR, iconbtnSaveR, false);
		}

		private void iconbtnDeleteR_Click(object sender, EventArgs e)
		{
			if (Id02 > 0)
			{
				string message = REASONCODE_DAL.Instance.Remove(Id02);
				if (string.IsNullOrEmpty(message))
				{
					allDataReason = REASONCODE_DAL.Instance.getAllInfo();
					LoadDataReason(allDataReason);
					ResetControll(txtReasonCode, txtReasonDesc);
					showHideControll(iconbtnAddR, iconbtnEditR, iconbtnDeleteR, iconbtnCancelR, iconbtnSaveR, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnSaveR_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtReasonCode.Text.Trim()))
			{
				MessageBox.Show("Nhập giá trị vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtReasonCode.Focus();
				return;
			}
			else
			{
				var checkExist = REASONCODE_DAL.Instance.checkExistEfectCode(txtReasonCode.Text.Trim());
				if (checkExist != null && AddFlag02 == true)
				{
					MessageBox.Show("Effect code này đã có trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtReasonCode.Focus();
					return;
				}
			}

			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var newRecord = new UVASSY_REASONCODE
			{
				Reason_Code = txtReasonCode.Text,
				Reason_Desc = txtReasonDesc.Text
			};
			if (AddFlag02 == true)
			{
				newRecord.CreatedBy = Program.UserId;
				newRecord.CreatedDate = datetime;
				string message = REASONCODE_DAL.Instance.Add(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataReason= REASONCODE_DAL.Instance.getAllInfo();
					LoadDataReason(allDataReason);
					ResetControll(txtReasonCode, txtReasonDesc);
					showHideControll(iconbtnAddR, iconbtnEditR, iconbtnDeleteR, iconbtnCancelR, iconbtnSaveR, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if (AddFlag02 == false && Id02 > 0)
			{
				newRecord.ID = Id02;
				newRecord.UpdatedDate = datetime;
				newRecord.UpdatedBy = Program.UserId;
				newRecord.Reason_Desc = txtReasonDesc.Text.Trim();
				string message = REASONCODE_DAL.Instance.Update(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataReason = REASONCODE_DAL.Instance.getAllInfo();
					LoadDataReason(allDataReason);
					ResetControll(txtReasonCode, txtReasonDesc);
					showHideControll(iconbtnAddR, iconbtnEditR, iconbtnDeleteR, iconbtnCancelR, iconbtnSaveR, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi Update dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}

		}

		private void iconbtnCancelR_Click(object sender, EventArgs e)
		{
			ResetControll(txtReasonCode, txtReasonDesc);
			showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
		}

		private void iconbtnLoadAllR_Click(object sender, EventArgs e)
		{
			allDataReason = REASONCODE_DAL.Instance.getAllInfo();
			LoadDataReason(allDataReason);
		}

		private void btBrowserR_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtBrowserR.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btImportR_Click(object sender, EventArgs e)
		{
			bool flag = true;
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var lstAdd = new List<UVASSY_REASONCODE>();
			var lstUpdate = new List<UVASSY_REASONCODE>();
			if (string.IsNullOrEmpty(txtBrowserR.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBrowserR.Focus();
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtBrowserR.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 2)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag == false)
				{
					MessageBox.Show("Dữ liệu import bị lỗi. \n Hãy kiểm tra lại dữ liệu khi import", "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				using (TextFieldParser parser1 = new TextFieldParser(txtBrowserR.Text))
				{
					parser1.ReadLine();
					parser1.TextFieldType = FieldType.Delimited;
					parser1.SetDelimiters(",");
					while (!parser1.EndOfData)
					{
						string[] fields = parser1.ReadFields();
						var csv = new UVASSY_REASONCODE
						{
							Reason_Code = fields[0].ToString(),
							Reason_Desc = fields[1].ToString()
						};
						var checkE = REASONCODE_DAL.Instance.checkExistEfectCode(csv.Reason_Code);
						if (checkE == null)
						{
							csv.CreatedDate = datetime;
							csv.CreatedBy = Program.UserId;
							lstAdd.Add(csv);
						}
						else
						{
							csv.ID = checkE.ID;
							csv.UpdatedDate = datetime;
							csv.UpdatedBy = Program.UserId;
							lstUpdate.Add(csv);
						}
					}

					string message = REASONCODE_DAL.Instance.AddUpdateRange(lstAdd, lstUpdate);
					if (string.IsNullOrEmpty(message))
					{
						txtBrowserR.Text = "";
						MessageBox.Show("Đã import dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						allDataReason = REASONCODE_DAL.Instance.getAllInfo();
						LoadDataReason(allDataReason);
						return;
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
		}

		private void iconbtnPrevR_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadDataReason(allDataReason);
			}
		}

		private void iconbtnNextR_Click(object sender, EventArgs e)
		{
			if (Program.currentPage >= totalPages)
			{
				Program.currentPage = totalPages;
			}
			else
			{
				Program.currentPage++;
			}
			LoadDataReason(allDataReason);
		}

		private void iconbtnFirstR_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadDataReason(allDataReason);
		}

		private void iconbtnLastR_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadDataReason(allDataReason);
		}

		private void dataGridViewR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewR.RowCount > 0)
			{
				DataGridViewRow row = dataGridViewR.SelectedCells[0].OwningRow;
				Id02 = int.Parse(row.Cells["ID"].Value.ToString());
				txtReasonCode.Text = row.Cells["Reason_Code"].Value.ToString();
				txtReasonDesc.Text = row.Cells["Reason_Desc"].Value.ToString();
			}
		}




		private void LoadDataCauseCode(List<UVASSY_CAUSECODE> lstData)
		{
			List<UVASSY_CAUSECODE> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridViewC, pagedData);
			int totalRecords = lstData.Count;
			labelTotalRecordsC.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfoC.Text = $"Page {Program.currentPage} of {totalPages}";

		}

		private void iconbtnAddC_Click(object sender, EventArgs e)
		{
			AddFlag03 = true;
			showHideControll(iconbtnAddC, iconbtnEditC, iconbtnDeleteC, iconbtnCancelC, iconbtnSaveC, false);
			ResetControll(txtCauseCode, txtCauseDesc);
			_enable(txtCauseCode, txtCauseDesc, true);
			txtCauseCode.Focus();
		}

		private void iconbtnEditC_Click(object sender, EventArgs e)
		{
			AddFlag03 = false;
			_enable(txtCauseCode, txtCauseDesc, true);
			txtCauseCode.Enabled = false;
			showHideControll(iconbtnAddC, iconbtnEditC, iconbtnDeleteC, iconbtnCancelC, iconbtnSaveC, false);
		}

		private void iconbtnDeleteC_Click(object sender, EventArgs e)
		{
			if (Id03 > 0)
			{
				string message = CAUSECODE_DAL.Instance.Remove(Id03);
				if (string.IsNullOrEmpty(message))
				{
					allDataCause = CAUSECODE_DAL.Instance.getAllInfo();
					LoadDataCauseCode(allDataCause);
					ResetControll(txtCauseCode, txtCauseDesc);
					showHideControll(iconbtnAddC, iconbtnEditC, iconbtnDeleteC, iconbtnCancelC, iconbtnSaveC, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnSaveC_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtCauseCode.Text.Trim()))
			{
				MessageBox.Show("Nhập giá trị vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCauseCode.Focus();
				return;
			}
			else
			{
				var checkExist = CAUSECODE_DAL.Instance.checkExistEfectCode(txtCauseCode.Text.Trim());
				if (checkExist != null && AddFlag03 == true)
				{
					MessageBox.Show("Effect code này đã có trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtCauseCode.Focus();
					return;
				}
			}

			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var newRecord = new UVASSY_CAUSECODE
			{
				Cause_Code = txtCauseCode.Text,
				Cause_Desc = txtCauseDesc.Text
			};
			if (AddFlag03 == true)
			{
				newRecord.CreatedBy = Program.UserId;
				newRecord.CreatedDate = datetime;
				string message = CAUSECODE_DAL.Instance.Add(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataCause = CAUSECODE_DAL.Instance.getAllInfo();
					LoadDataCauseCode(allDataCause);
					ResetControll(txtCauseCode, txtCauseDesc);
					showHideControll(iconbtnAddC, iconbtnEditC, iconbtnDeleteC, iconbtnCancelC, iconbtnSaveC, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if (AddFlag03 == false && Id03 > 0)
			{
				newRecord.ID = Id03;
				newRecord.UpdatedDate = datetime;
				newRecord.UpdatedBy = Program.UserId;
				newRecord.Cause_Desc = txtCauseDesc.Text.Trim();
				string message = CAUSECODE_DAL.Instance.Update(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataCause= CAUSECODE_DAL.Instance.getAllInfo();
					LoadDataCauseCode(allDataCause);
					ResetControll(txtCauseCode, txtCauseDesc);
					showHideControll(iconbtnAddC, iconbtnEditC, iconbtnDeleteC, iconbtnCancelC, iconbtnSaveC, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi Update dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}

		}

		private void iconbtnCancelC_Click(object sender, EventArgs e)
		{
			ResetControll(txtCauseCode, txtCauseDesc);
			showHideControll(iconbtnAddC, iconbtnEditC, iconbtnDeleteC, iconbtnCancelC, iconbtnSaveC, true);
		}

		private void iconbtnLoadAllC_Click(object sender, EventArgs e)
		{
			allDataCause = CAUSECODE_DAL.Instance.getAllInfo();
			LoadDataCauseCode(allDataCause);
		}

		private void btnBrowserC_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtBrowserC.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btnImportC_Click(object sender, EventArgs e)
		{
			bool flag = true;
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var lstAdd = new List<UVASSY_CAUSECODE>();
			var lstUpdate = new List<UVASSY_CAUSECODE>();
			if (string.IsNullOrEmpty(txtBrowserC.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBrowserC.Focus();
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtBrowserC.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 2)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag == false)
				{
					MessageBox.Show("Dữ liệu import bị lỗi. \n Hãy kiểm tra lại dữ liệu khi import", "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				using (TextFieldParser parser1 = new TextFieldParser(txtBrowserC.Text))
				{
					parser1.ReadLine();
					parser1.TextFieldType = FieldType.Delimited;
					parser1.SetDelimiters(",");
					while (!parser1.EndOfData)
					{
						string[] fields = parser1.ReadFields();
						var csv = new UVASSY_CAUSECODE
						{
							Cause_Code = fields[0].ToString(),
							Cause_Desc = fields[1].ToString()
						};
						var checkE = CAUSECODE_DAL.Instance.checkExistEfectCode(csv.Cause_Code);
						if (checkE == null)
						{
							csv.CreatedDate = datetime;
							csv.CreatedBy = Program.UserId;
							lstAdd.Add(csv);
						}
						else
						{
							csv.ID = checkE.ID;
							csv.UpdatedDate = datetime;
							csv.UpdatedBy = Program.UserId;
							lstUpdate.Add(csv);
						}
					}

					string message = CAUSECODE_DAL.Instance.AddUpdateRange(lstAdd, lstUpdate);
					if (string.IsNullOrEmpty(message))
					{
						txtBrowserC.Text = "";
						MessageBox.Show("Đã import dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						allDataCause = CAUSECODE_DAL.Instance.getAllInfo();
						LoadDataCauseCode(allDataCause);
						return;
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
		}

		private void iconbtnPrevC_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadDataCauseCode(allDataCause);
			}
		}

		private void iconbtnNextC_Click(object sender, EventArgs e)
		{
			if (Program.currentPage >= totalPages)
			{
				Program.currentPage = totalPages;
			}
			else
			{
				Program.currentPage++;
			}
			LoadDataCauseCode(allDataCause);
		}

		

		private void iconbtnFirstC_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadDataCauseCode(allDataCause);
		}

		private void iconbtnLastC_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadDataCauseCode(allDataCause);
		}

		private void dataGridViewC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewC.RowCount > 0)
			{
				DataGridViewRow row = dataGridViewC.SelectedCells[0].OwningRow;
				Id03 = int.Parse(row.Cells["ID"].Value.ToString());
				txtCauseCode.Text = row.Cells["Cause_Code"].Value.ToString();
				txtCauseDesc.Text = row.Cells["Cause_Desc"].Value.ToString();
			}
		}

		private void iconbtnAddD_Click(object sender, EventArgs e)
		{
			AddFlag04 = true;
			showHideControll(iconbtnAddD, iconbtnEditD, iconbtnDeleteD, iconbtnCancelD, iconbtnSaveD, false);
			ResetControll(txtDeptCode, txtDeptDesc);
			_enable(txtDeptCode, txtDeptDesc, true);
			txtDeptCode.Focus();
		}

		private void iconbtnEditD_Click(object sender, EventArgs e)
		{
			AddFlag04 = false;
			_enable(txtDeptCode, txtDeptDesc, true);
			txtDeptCode.Enabled = false;
			showHideControll(iconbtnAddD, iconbtnEditD, iconbtnDeleteD, iconbtnCancelD, iconbtnSaveD, false);
		}
		private void LoadDataDept(List<UVASSY_DEPTCODE> lstData)
		{
			List<UVASSY_DEPTCODE> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridViewD, pagedData);
			int totalRecords = lstData.Count;
			labelTotalRecordsD.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfoD.Text = $"Page {Program.currentPage} of {totalPages}";

		}
		private void iconbtnDeleteD_Click(object sender, EventArgs e)
		{
			if (Id04 > 0)
			{
				string message = DEPTCODE_DAL.Instance.Remove(Id03);
				if (string.IsNullOrEmpty(message))
				{
					allDataDept = DEPTCODE_DAL.Instance.getAllInfo();
					LoadDataDept(allDataDept);
					ResetControll(txtDeptCode, txtDeptDesc);
					showHideControll(iconbtnAddD, iconbtnEditD, iconbtnDeleteD, iconbtnCancelD, iconbtnSaveD, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnSaveD_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtDeptCode.Text.Trim()))
			{
				MessageBox.Show("Nhập giá trị vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDeptCode.Focus();
				return;
			}
			else
			{
				var checkExist = DEPTCODE_DAL.Instance.checkExistEfectCode(txtReasonCode.Text.Trim());
				if (checkExist != null && AddFlag02 == true)
				{
					MessageBox.Show("DEPT code này đã có trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtDeptCode.Focus();
					return;
				}
			}

			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var newRecord = new UVASSY_DEPTCODE
			{
				DeptCode = txtDeptCode.Text,
				DeptDesc = txtDeptDesc.Text
			};
			if (AddFlag04 == true)
			{
				newRecord.CreatedBy = Program.UserId;
				newRecord.CreatedDate = datetime;
				string message = DEPTCODE_DAL.Instance.Add(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataDept= DEPTCODE_DAL.Instance.getAllInfo();
					LoadDataDept(allDataDept);
					ResetControll(txtDeptCode, txtDeptDesc);
					showHideControll(iconbtnAddD, iconbtnEditD, iconbtnDeleteD, iconbtnCancelD, iconbtnSaveD,  true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if (AddFlag04 == false && Id04 > 0)
			{
				newRecord.ID = Id04;
				newRecord.UpdatedDate = datetime;
				newRecord.UpdatedBy = Program.UserId;
				newRecord.DeptDesc = txtDeptDesc.Text.Trim();
				string message = DEPTCODE_DAL.Instance.Update(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataDept = DEPTCODE_DAL.Instance.getAllInfo();
					LoadDataDept(allDataDept);
					ResetControll(txtDeptCode, txtDeptDesc);
					showHideControll(iconbtnAddD, iconbtnEditD, iconbtnDeleteD, iconbtnCancelD, iconbtnSaveD, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi Update dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnCancelD_Click(object sender, EventArgs e)
		{
			ResetControll(txtReasonCode, txtReasonDesc);
			showHideControll(iconbtnAdd, iconbtnEdit, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
		}

		private void iconbtnLoadAllD_Click(object sender, EventArgs e)
		{
			allDataDept = DEPTCODE_DAL.Instance.getAllInfo();
			LoadDataDept(allDataDept);
		}

		private void btnBrowserD_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtBrowserD.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btnImportD_Click(object sender, EventArgs e)
		{
			bool flag = true;
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var lstAdd = new List<UVASSY_DEPTCODE>();
			var lstUpdate = new List<UVASSY_DEPTCODE>();
			if (string.IsNullOrEmpty(txtBrowserD.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBrowserD.Focus();
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtBrowserD.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 2)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag == false)
				{
					MessageBox.Show("Dữ liệu import bị lỗi. \n Hãy kiểm tra lại dữ liệu khi import", "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				using (TextFieldParser parser1 = new TextFieldParser(txtBrowserD.Text))
				{
					parser1.ReadLine();
					parser1.TextFieldType = FieldType.Delimited;
					parser1.SetDelimiters(",");
					while (!parser1.EndOfData)
					{
						string[] fields = parser1.ReadFields();
						var csv = new UVASSY_DEPTCODE
						{
							DeptCode = fields[0].ToString(),
							DeptDesc = fields[1].ToString()
						};
						var checkE = DEPTCODE_DAL.Instance.checkExistEfectCode(csv.DeptCode);
						if (checkE == null)
						{
							csv.CreatedDate = datetime;
							csv.CreatedBy = Program.UserId;
							lstAdd.Add(csv);
						}
						else
						{
							csv.ID = checkE.ID;
							csv.UpdatedDate = datetime;
							csv.UpdatedBy = Program.UserId;
							lstUpdate.Add(csv);
						}
					}

					string message = DEPTCODE_DAL.Instance.AddUpdateRange(lstAdd, lstUpdate);
					if (string.IsNullOrEmpty(message))
					{
						txtBrowserD.Text = "";
						MessageBox.Show("Đã import dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						allDataDept = DEPTCODE_DAL.Instance.getAllInfo();
						LoadDataDept(allDataDept);
						return;
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
		}

		private void iconbtnPrevD_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadDataDept(allDataDept);
			}
		}

		private void iconbtnNextD_Click(object sender, EventArgs e)
		{
			if (Program.currentPage>=totalPages)
			{
				Program.currentPage = totalPages;				
			}
			else
			{
				Program.currentPage++;
			}
			LoadDataDept(allDataDept);
		}

		private void iconbtnFirstD_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadDataDept(allDataDept);
		}

		private void iconbtnLastD_Click(object sender, EventArgs e)
		{
			Program.currentPage=totalPages;
			LoadDataDept(allDataDept);
		}
		private void dataGridViewD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewD.RowCount > 0)
			{
				DataGridViewRow row = dataGridViewD.SelectedCells[0].OwningRow;
				Id04 = int.Parse(row.Cells["ID"].Value.ToString());
				txtDeptCode.Text = row.Cells["DeptCode"].Value.ToString();
				txtDeptDesc.Text = row.Cells["DeptDesc"].Value.ToString();
			}
		}









		private void iconbtnAddE_Click(object sender, EventArgs e)
		{
			AddFlag05 = true;
			showHideControll(iconbtnAddE, iconbtnEditE, iconbtnDeleteE, iconbtnCancelE, iconbtnSaveE, false);
			ResetControll(txtErrorCode, txtErrorDesc);
			_enable(txtErrorCode, txtErrorDesc, true);
			txtErrorCode.Focus();
		}

		private void iconbtnEditE_Click(object sender, EventArgs e)
		{
			AddFlag05 = false;
			_enable(txtErrorCode, txtErrorDesc, true);
			txtErrorCode.Enabled = false;
			showHideControll(iconbtnAddE, iconbtnEditE, iconbtnDeleteE, iconbtnCancelE, iconbtnSaveE, false);
		}

		private void iconbtnDeleteE_Click(object sender, EventArgs e)
		{
			if (Id05 > 0)
			{
				string message = ERRORCODE_DAL.Instance.Remove(Id05);
				if (string.IsNullOrEmpty(message))
				{
					allDataError = ERRORCODE_DAL.Instance.getAllInfo();
					LoadDataError(allDataError);
					ResetControll(txtErrorCode, txtErrorDesc);
					showHideControll(iconbtnAddE, iconbtnEditE, iconbtnDeleteE, iconbtnCancelE, iconbtnSaveE, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void LoadDataError(List<UVASSY_ERRORCODE> lstData)
		{
			List<UVASSY_ERRORCODE> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridView2, pagedData);
			int totalRecords = lstData.Count;
			labelTotalRecordsE.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfoE.Text = $"Page {Program.currentPage} of {totalPages}";
		}

		private void iconbtnSaveE_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtErrorCode.Text.Trim()))
			{
				MessageBox.Show("Nhập giá trị vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtErrorCode.Focus();
				return;
			}
			else
			{
				var checkExist = ERRORCODE_DAL.Instance.checkExistEfectCode(txtErrorCode.Text.Trim());
				if (checkExist != null && AddFlag02 == true)
				{
					MessageBox.Show("ERROR code này đã có trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtErrorCode.Focus();
					return;
				}
			}

			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var newRecord = new UVASSY_ERRORCODE
			{
				ErrorCode = txtErrorCode.Text,
				ErrorDesc = txtErrorDesc.Text
			};
			if (AddFlag04 == true)
			{
				newRecord.CreatedBy = Program.UserId;
				newRecord.CreatedDate = datetime;
				string message = ERRORCODE_DAL.Instance.Add(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataError = ERRORCODE_DAL.Instance.getAllInfo();
					LoadDataError(allDataError);
					ResetControll(txtErrorCode, txtErrorDesc);
					showHideControll(iconbtnAddE, iconbtnEditE, iconbtnDeleteE, iconbtnCancelE, iconbtnSaveE, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			if (AddFlag05 == false && Id05 > 0)
			{
				newRecord.ID = Id05;
				newRecord.UpdatedDate = datetime;
				newRecord.UpdatedBy = Program.UserId;
				newRecord.ErrorDesc = txtErrorDesc.Text.Trim();
				string message = ERRORCODE_DAL.Instance.Update(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allDataError = ERRORCODE_DAL.Instance.getAllInfo();
					LoadDataError(allDataError);
					ResetControll(txtErrorCode, txtErrorDesc);
					showHideControll(iconbtnAddE, iconbtnEditE, iconbtnDeleteE, iconbtnCancelE, iconbtnSaveE, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi Update dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnCancelE_Click(object sender, EventArgs e)
		{
			ResetControll(txtErrorCode, txtErrorDesc);
			showHideControll(iconbtnAddE, iconbtnEditE, iconbtnDeleteE, iconbtnCancelE, iconbtnSaveE, true);
		}

		private void iconbtnLoadAllE_Click(object sender, EventArgs e)
		{
			allDataError = ERRORCODE_DAL.Instance.getAllInfo();
			LoadDataError(allDataError);
		}

		private void btnBrowserE_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtBrowserE.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btnImportE_Click(object sender, EventArgs e)
		{
			bool flag = true;
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var lstAdd = new List<UVASSY_ERRORCODE>();
			var lstUpdate = new List<UVASSY_ERRORCODE>();
			if (string.IsNullOrEmpty(txtBrowserE.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBrowserE.Focus();
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtBrowserE.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 2)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag == false)
				{
					MessageBox.Show("Dữ liệu import bị lỗi. \n Hãy kiểm tra lại dữ liệu khi import", "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				using (TextFieldParser parser1 = new TextFieldParser(txtBrowserE.Text))
				{
					parser1.ReadLine();
					parser1.TextFieldType = FieldType.Delimited;
					parser1.SetDelimiters(",");
					while (!parser1.EndOfData)
					{
						string[] fields = parser1.ReadFields();
						var csv = new UVASSY_ERRORCODE
						{
							ErrorCode = fields[0].ToString(),
							ErrorDesc = fields[1].ToString()
						};
						var checkE = ERRORCODE_DAL.Instance.checkExistEfectCode(csv.ErrorCode);
						if (checkE == null)
						{
							csv.CreatedDate = datetime;
							csv.CreatedBy = Program.UserId;
							lstAdd.Add(csv);
						}
						else
						{
							csv.ID = checkE.ID;
							csv.UpdatedDate = datetime;
							csv.UpdatedBy = Program.UserId;
							lstUpdate.Add(csv);
						}
					}

					string message = ERRORCODE_DAL.Instance.AddUpdateRange(lstAdd, lstUpdate);
					if (string.IsNullOrEmpty(message))
					{
						txtBrowserE.Text = "";
						MessageBox.Show("Đã import dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						allDataError = ERRORCODE_DAL.Instance.getAllInfo();
						LoadDataError(allDataError);
						return;
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
		}

		private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewC.RowCount > 0)
			{
				DataGridViewRow row = dataGridView2.SelectedCells[0].OwningRow;
				Id03 = int.Parse(row.Cells["ID"].Value.ToString());
				txtErrorCode.Text = row.Cells["ErrorCode"].Value.ToString();
				txtErrorDesc.Text = row.Cells["ErrorDesc"].Value.ToString();
			}
		}
		private void searchData(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập thông tin cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				allDataDefect=DEFECTCODE_DAL.Instance.searchAllInfo(search);
				LoadData01(allDataDefect);
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


		private void searchDataR(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập thông tin cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				allDataReason = REASONCODE_DAL.Instance.searchAllInfo(search);
				LoadDataReason(allDataReason);
			}
		}
		private void iconbtnSearchR_Click(object sender, EventArgs e)
		{
			searchDataR(txtSearchR.Text.Trim());
		}

		private void txtSearchR_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				searchDataR(txtSearchR.Text.Trim());
			}
		}

		private void iconbtnNextE_Click(object sender, EventArgs e)
		{
			if (Program.currentPage >= totalPages)
			{
				Program.currentPage = totalPages;
			}
			else
			{
				Program.currentPage++;
			}
			LoadDataError(allDataError);
		}

		private void iconbtnPrevE_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadDataError(allDataError);
			}
		}

		private void iconbtnFirstE_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadDataError(allDataError);
		}

		private void iconbtnLastE_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadDataError(allDataError);
		}


		private void searchDataC(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập thông tin cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				allDataCause = CAUSECODE_DAL.Instance.searchAllInfo(search);
				LoadDataCauseCode(allDataCause);
			}
		}
		private void txtSearchC_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				searchDataC(txtSearchC.Text.Trim());
			}
		}

		private void iconbtnSearchC_Click(object sender, EventArgs e)
		{
			searchDataC(txtSearchC.Text.Trim());
		}


		private void searchDataD(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập thông tin cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				allDataDept = DEPTCODE_DAL.Instance.searchAllInfo(search);
				LoadDataDept(allDataDept);
			}
		}

		private void txtSearchD_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				searchDataD(txtSearchD.Text.Trim());
			}
		}

		private void iconbtnSearchD_Click(object sender, EventArgs e)
		{
			searchDataD(txtSearchD.Text.Trim());
		}


		private void searchDataE(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập thông tin cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				allDataError = ERRORCODE_DAL.Instance.searchAllInfo(search);
				LoadDataError(allDataError);
			}
		}
		private void txtSearchE_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				searchDataE(txtSearchE.Text.Trim());
			}
		}

		private void iconbtnSearchE_Click(object sender, EventArgs e)
		{
			searchDataE(txtSearchE.Text.Trim());
		}
	}
}
