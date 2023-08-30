using FontAwesome.Sharp;
using Microsoft.VisualBasic.FileIO;
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
using UnidenDAL.AssyLine.REPAIR;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.REPAIR
{
	public partial class frmRepairModel : Form
	{
		private int Id01 = 0;
		private bool AddFlag01 = false;
		private int totalPages = 1;
		private List<SYS_UserButtonFunction> lstUBFunction;
		private List<UVASSY_REPAIRMODEL> allData;
		public frmRepairModel()
		{
			InitializeComponent();
		}	

		private void frmRepairModel_Load(object sender, EventArgs e)
		{
			showHideControll(iconbtnAdd,  iconbtnDelete, iconbtnCancel, iconbtnSave, true);
			ResetControll(txtShortModel);
			labelTotalRecords.Text = string.Empty;
			labelPageInfo.Text = string.Empty;
			allData = REPAIRMODEL_DAL.Instance.getAllInfo();
			LoadData(allData);

			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}
		void _enable(TextBox txt1, bool t)
		{
			txt1.Enabled = t;			
		}

		void ResetControll(TextBox txt1)
		{
			txt1.Text = string.Empty;
			txt1.Enabled = false;
		}
		void showHideControll(IconButton add,  IconButton delete, IconButton cancel, IconButton save, bool t)
		{
			add.Visible = t;			
			delete.Visible = t;
			cancel.Visible = !t;
			save.Visible = !t;
		}
		private void iconbtnAdd_Click(object sender, EventArgs e)
		{
			AddFlag01 = true;
			showHideControll(iconbtnAdd,  iconbtnDelete, iconbtnCancel, iconbtnSave, false);
			ResetControll(txtShortModel);
			_enable(txtShortModel, true);
			txtShortModel.Focus();
		}
		private void LoadData(List<UVASSY_REPAIRMODEL> lstData)
		{
			List<UVASSY_REPAIRMODEL> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridView, pagedData);
			int totalRecords = lstData.Count;
			labelTotalRecords.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";
		}
		private void iconbtnDelete_Click(object sender, EventArgs e)
		{

			if (Id01 > 0)
			{
				string message = REPAIRMODEL_DAL.Instance.Remove(Id01);
				if (string.IsNullOrEmpty(message))
				{
					allData = REPAIRMODEL_DAL.Instance.getAllInfo();
					LoadData(allData);
					ResetControll(txtShortModel);
					showHideControll(iconbtnAdd,  iconbtnDelete, iconbtnCancel, iconbtnSave, true);
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
			if (string.IsNullOrEmpty(txtShortModel.Text.Trim()))
			{
				MessageBox.Show("Nhập giá trị vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtShortModel.Focus();
				return;
			}
			else
			{
				var checkExist = REPAIRMODEL_DAL.Instance.checkExistShortModel(txtShortModel.Text.Trim());
				if (checkExist != null && AddFlag01 == true)
				{
					MessageBox.Show("ShortModel code này đã có trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtShortModel.Focus();
					return;
				}
			}

			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var newRecord = new UVASSY_REPAIRMODEL
			{
				ShortModel = txtShortModel.Text,				
			};
			if (AddFlag01 == true)
			{
				newRecord.CreatedBy = Program.UserId;
				newRecord.CreatedDate = datetime;
				string message = REPAIRMODEL_DAL.Instance.Add(newRecord);
				if (string.IsNullOrEmpty(message))
				{
					allData = REPAIRMODEL_DAL.Instance.getAllInfo();
					LoadData(allData);
					ResetControll(txtShortModel);
					showHideControll(iconbtnAdd, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}			
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			ResetControll(txtShortModel);
			showHideControll(iconbtnAdd, iconbtnDelete, iconbtnCancel, iconbtnSave, true);
		}

		private void iconbtnLoadAll_Click(object sender, EventArgs e)
		{
			allData = REPAIRMODEL_DAL.Instance.getAllInfo();
			LoadData(allData);
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
			var lstAdd = new List<UVASSY_REPAIRMODEL>();
			
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
						if (fields.Length != 1)
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
						var csv = new UVASSY_REPAIRMODEL
						{
							ShortModel = fields[0].ToString()							
						};
						var checkE = REPAIRMODEL_DAL.Instance.checkExistShortModel(csv.ShortModel);
						if (checkE == null)
						{
							csv.CreatedDate = datetime;
							csv.CreatedBy = Program.UserId;
							lstAdd.Add(csv);
						}						
					}

					string message = REPAIRMODEL_DAL.Instance.AddRange(lstAdd);
					if (string.IsNullOrEmpty(message))
					{
						txtBrowser.Text = string.Empty;
						MessageBox.Show("Đã import dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						allData = REPAIRMODEL_DAL.Instance.getAllInfo();
						LoadData(allData);
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

		private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView.RowCount > 0)
			{
				DataGridViewRow row = dataGridView.SelectedCells[0].OwningRow;
				Id01 = int.Parse(row.Cells["ID"].Value.ToString());
				txtShortModel.Text = row.Cells["ShortModel"].Value.ToString();				
			}
		}
	}
}
