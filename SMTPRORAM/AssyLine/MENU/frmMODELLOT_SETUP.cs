using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.AssyLine;
using UnidenDAL;
using UnidenDTO;
using Microsoft.VisualBasic.FileIO;

namespace SMTPRORAM.AssyLine
{
	public partial class frmMODELLOT_SETUP : Form
	{
		bool AddFlag = false;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmMODELLOT_SETUP()
		{
			InitializeComponent();
		}
		private void frmMODELLOT_SETUP_Load(object sender, EventArgs e)
		{
			_enable(false);
			showHideControll(true);
		}
		void _enable(bool t)
		{
			txtLot.Enabled = t;
			txtModel.Enabled = t;
		}

		void ResetControll()
		{
			txtModel.Text = "";
			txtLot.Text = "";			
			txtLot.Focus();
		}
		void showHideControll(bool t)
		{
			iconbtnAdd.Visible = t;
			iconbtnEdit.Visible = t;
			iconbtnDelete.Visible = t;
			iconbtnCancel.Visible = !t;
			iconbtnSave.Visible = !t;
		}
		private void SearchData(string search)
		{
			if (search.Equals(""))
			{
				MessageBox.Show("Hãy nhập điều kiện tìm kiếm vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSearch.Focus();
				return;
			}
			else
			{
				CommonDAL.Instance.ShowDataGridView(dataGridView, MODEL_DAL.Instance.searchData(search));
			}
		}
	

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				SearchData(txtSearch.Text.Trim());
			}
		}

		private void iconbtnAdd_Click(object sender, EventArgs e)
		{
			AddFlag = true;
			showHideControll(false);
			_enable(true);
			ResetControll();
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			_enable(true);
			txtLot.Enabled = false;
			showHideControll(false);
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{

		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			showHideControll(true);
			_enable(false);
		}

		private bool checkLot()
		{
			if (txtLot.Text.Trim().Length!=6)
			{
				MessageBox.Show("LOT phải có 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);		
				txtLot.SelectAll();
				txtLot.Focus();
				return false;
			}
			else
			{
				txtModel.Focus();
			}
			return true;
		}
		private bool checkModel()
		{
			if (txtModel.Text.Trim().Length != 6)
			{
				MessageBox.Show("MODEL phải có 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtModel.SelectAll();
				txtModel.Focus();
				return false;
			}
			else
			{
				iconbtnSave.Focus();
			}
			return true;
		}
		private bool isOkData()
		{
			if(!checkLot())
			{
				return false;
			}
			if (!checkModel())
			{
				return false;
			}
			return true;
		}
		private void txtLot_KeyDown(object sender, KeyEventArgs e)
		{
			if(Keys.Enter==e.KeyCode)
			{
				checkLot();
			}	
		}
		private void txtModel_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				checkModel();
			}
		}
		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if(isOkData())
			{
				var newModel = new UVASSY_MODEL
				{
					Model = txtModel.Text.Trim(),
					Lot= txtLot.Text.Trim(),
					CreatedBy=Program.UserId,
					CreatedDate= CommonDAL.Instance.getSqlServerDatetime()
				};
				var checkExistLot=MODEL_DAL.Instance.checkExistLot(txtLot.Text.Trim());
				if (checkExistLot==null && AddFlag==true)
				{
					string message=MODEL_DAL.Instance.Add(newModel);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.ShowDataGridView(dataGridView, MODEL_DAL.Instance.getListModelLot());
						ResetControll();
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm mới dữ liệu: "+message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtLot.Focus();
						return;
					}
				}
				if (checkExistLot != null && AddFlag == false)
				{
					newModel.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
					newModel.CreatedBy= Program.UserId;
					string message=MODEL_DAL.Instance.Update(newModel);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.ShowDataGridView(dataGridView, MODEL_DAL.Instance.getListModelLotUpdate());
						ResetControll();
						showHideControll(true);
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi update dữ liệu: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtLot.Focus();
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
				txtLot.Text = row.Cells["Lot"].Value.ToString();				
				txtModel.Text = row.Cells["Model"].Value.ToString();
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			SearchData(txtSearch.Text.Trim());
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
			if (string.IsNullOrEmpty(txtBrowser.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtBrowser.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					// check before import
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 2)
						{
							flag = false;
							break;
						}
						else
						{
							if (string.IsNullOrEmpty(fields[0]) || string.IsNullOrEmpty(fields[1]))
							{
								flag = false;
								break;
							}	
						}
					}
				}
				var datetime = CommonDAL.Instance.getSqlServerDatetime();
				var lstAdd= new List<UVASSY_MODEL>();
				if (flag)
				{
					using (TextFieldParser parser1 = new TextFieldParser(txtBrowser.Text))
					{
						parser1.ReadLine();
						parser1.TextFieldType = FieldType.Delimited;
						parser1.SetDelimiters(",");
						while (!parser1.EndOfData)
						{
							string[] fields = parser1.ReadFields();
							var csv = new UVASSY_MODEL
							{
								Lot = fields[1].ToString(),
								Model = fields[0].ToString(),
								CreatedBy = Program.UserId,
								CreatedDate = datetime
							};
							if (MODEL_DAL.Instance.checkExistLot(csv.Lot)==null)
							{
								lstAdd.Add(csv);
							}								
						}
						string message=MODEL_DAL.Instance.AddRange(lstAdd);
						if (string.IsNullOrEmpty(message))
						{
							MessageBox.Show("Import thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							CommonDAL.Instance.ShowDataGridView(dataGridView, MODEL_DAL.Instance.getListModelLot());
							txtBrowser.Text=string.Empty;
							return;
						}
						else
						{
							MessageBox.Show("Import có lỗi:  "+ message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
				}
				else
				{
					MessageBox.Show("Dữ liệu import không đúng định dạng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				
			}
		}
	}
}
