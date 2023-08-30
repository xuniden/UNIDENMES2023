using Microsoft.Office.Interop.Excel;
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
using UnidenDAL.AssyLine;
using UnidenDAL.Smt.DataControl;
using UnidenDTO;

namespace SMTPRORAM.AssyLine
{
	public partial class frmLotControlSetup : Form
	{
		private long Id = 0;
		private bool AddFlag = false;
		public frmLotControlSetup()
		{
			InitializeComponent();
		}
		private void frmLotControlSetup_Load(object sender, EventArgs e)
		{
			ResetControll();
			showHideControll(true);
			CommonDAL.Instance.ShowDataGridView(dataGridView, LOTCONTROL_DAL.Instance.getListLotControl());
		}
		void _enable(bool t)
		{
			txtLot.Enabled = t;
			numericLotsize.Enabled = t;
			numericUnit.Enabled = t;
			txtStartNumber.Enabled = t;
			txtEndNumber.Enabled = t;
			txtDbox.Enabled = t;
			txtCtn.Enabled = t;
		}

		void ResetControll()
		{

			txtLot.Text = string.Empty;
			txtModel.Text = string.Empty;
			numericLotsize.Value = 0;
			numericUnit.Value = 0;
			txtStartNumber.Text = string.Empty;
			txtEndNumber.Text = string.Empty;
			txtDbox.Text = string.Empty;
			txtCtn.Text = string.Empty;

			txtLot.Enabled = false;
			txtModel.Enabled = false;
			numericLotsize.Enabled = false;
			numericUnit.Enabled = false;			
			txtStartNumber.Enabled = false;
			txtEndNumber.Enabled = false;
			txtDbox.Enabled = false;
			txtCtn.Enabled = false;			
			txtLot.Focus();		

		}
		void showHideControll(bool t)
		{
			iconbtnAdd.Visible = t;			
			iconbtnCancel.Visible = !t;
			iconbtnSave.Visible = !t;
			iconbtnEdit.Visible = t;
		}

		private bool checkLot()
		{
			if (string.IsNullOrEmpty(txtLot.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập Lot Vào Đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtLot.SelectAll();
				txtLot.Focus();
				return false;
			}
			if (txtLot.TextLength != 6)
			{
				MessageBox.Show("LOT Phải có 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLot.SelectAll();
				txtLot.Focus();
				return false;
			}
			var modelLot=MODEL_DAL.Instance.checkExistLot(txtLot.Text.Trim());
			if (modelLot==null)
			{
				MessageBox.Show("LOT chưa được được thêm vào trong phần quản lý MODEL LOT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLot.SelectAll();
				txtLot.Focus();
				return false;
			}	
			var checkLotControl=LOTCONTROL_DAL.Instance.checkExistLot(txtLot.Text.Trim());
			if (checkLotControl!=null && AddFlag==true)
			{
				MessageBox.Show("LOT đã được thêm vào csdl. Hãy tìm kiếm thông tin theo LOT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLot.SelectAll();
				txtLot.Focus();
				return false;
			}	
			return true;
		}
		private bool checkLotsize()
		{
			if ((int)numericLotsize.Value<=0)
			{
				MessageBox.Show("Lotsize không được <=0","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);				
				numericLotsize.Focus();				
				return false;
			}
			return true;
		}

		private bool checkUnit()
		{
			if ((int)numericUnit.Value <= 0)
			{
				MessageBox.Show("Unit không được <= 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				numericUnit.Focus();
				return false;
			}
			return true;
		}

		private bool checkStartNumber()
		{
			if (string.IsNullOrEmpty(txtStartNumber.Text.Trim()) ||  txtStartNumber.Text.Length > 13)
			{
				MessageBox.Show("Hãy nhập đúng START NUMBER\n START NUMBER < 13 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtStartNumber.Focus();
				return false;
			}

			return true;
		}
		private bool checkEndNumber()
		{
			if (string.IsNullOrEmpty(txtEndNumber.Text.Trim()) || txtEndNumber.TextLength > 13)
			{
				MessageBox.Show("Hãy Nhập Đúng END NUMBER \n END NUMBER < 13 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtEndNumber.Focus();
				return false;
			}

			return true;
		}

		private bool checkDBox()
		{
			if (string.IsNullOrEmpty(txtDbox.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập số DBOX vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDbox.Focus();
				return false;
			}

			return true;
		}
		private bool checkCTN()
		{
			if (string.IsNullOrEmpty(txtCtn.Text.Trim()) ) 
			{
				MessageBox.Show("Hãy Nhập số CTN vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDbox.Focus();
				return false;
			}

			return true;
		}

		private void txtLot_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (checkLot())
				{
					// Lấy thông tin Model,
					var getModel=MODEL_DAL.Instance.checkExistLot(txtLot.Text.Trim());
					txtModel.Text = getModel.Model;
					numericLotsize.Enabled = true;
					numericLotsize.Focus();
				}
				else
				{
					txtLot.Focus();
					txtLot.SelectAll();
				}
			}
		}
		private void numericLotsize_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (checkLotsize())
				{
					numericUnit.Enabled = true;
					numericUnit.Focus();
				}
				else
				{
					numericLotsize.Focus();
				}
			}
		}
		private void numericUnit_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (checkUnit())
				{
					txtStartNumber.Enabled = true;
					txtStartNumber.Focus();
				}
				else
				{
					numericUnit.Focus();
				}
			}
		}
		private void txtStartNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if(checkStartNumber())
				{
					txtEndNumber.Enabled = true;
					txtEndNumber.Focus();	
				}
				else
				{
					txtStartNumber.Focus();
				}
			}
		}

		private void txtEndNumber_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				if (checkEndNumber())
				{
					txtDbox.Enabled = true;
					txtDbox.Focus();
				}
				else
				{
					txtEndNumber.Focus();
				}
			}
		}

		private void txtDbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				if (checkDBox())
				{
					txtCtn.Enabled = true;
					txtCtn.Focus();
				}
				else
				{
					txtDbox.Focus();
				}
			}
		}

		private void txtCtn_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				if (checkCTN())
				{
					iconbtnSave.PerformClick();
				}
				else
				{
					txtCtn.Focus();
				}
			}
		}

		private bool isOKdata()
		{
			if (!checkLot())
			{
				return false;
			}
			if (!checkLotsize())
			{
				return false;
			}
			if (!checkUnit())
			{
				return false;
			}
			if (!checkStartNumber())
			{
				return false;
			}
			if (!checkEndNumber())
			{
				return false;
			}
			if (!checkDBox())
			{
				return false;
			}
			if (!checkCTN())
			{
				return false;
			}			
			return true;
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			if (isOKdata())
			{
				var lotControl = new UVASSY_LOTCONTROL
				{
					Lot = txtLot.Text.Trim(),
					Model = txtModel.Text.Trim(),
					Lotsize = (int)numericLotsize.Value,
					UnitCtn = (int)numericUnit.Value,
					Start_Number = txtStartNumber.Text.Trim(),
					End_Number = txtEndNumber.Text.Trim(),
					Dbox_Barcode = txtDbox.Text.Trim(),
					Carton_Barcode = txtCtn.Text.Trim(),
					CreatedBy = Program.UserId,
					CreatedDate = datetime
				};
				if(AddFlag==true)
				{
					string message=LOTCONTROL_DAL.Instance.Add(lotControl);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.ShowDataGridView(dataGridView, LOTCONTROL_DAL.Instance.getListLotControl());
						ResetControll();
						showHideControll(true);
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu LOT CONTROL: "+ message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
				}
				if (AddFlag==false && !string.IsNullOrEmpty(txtLot.Text.Trim()) && Id>0)
				{
					lotControl.LotID = Id;
					lotControl.UpdatedBy = Program.UserId;
					lotControl.UpdatedDate = datetime;
					string message = LOTCONTROL_DAL.Instance.Update(lotControl);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.ShowDataGridView(dataGridView, LOTCONTROL_DAL.Instance.getListLotControlByUpdateDate());
						ResetControll();
						showHideControll(true);
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi Update dữ liệu LOT CONTROL: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			txtLot.Enabled = true;
			txtLot.Focus();
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			_enable(true);
			txtLot.Enabled = false;
			showHideControll(false);
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			showHideControll(true);
			_enable(false);
		}
		private void SearchData(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập giá trị cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSearch.Focus();
				return;
			}
			else
			{
				CommonDAL.Instance.ShowDataGridView(dataGridView, LOTCONTROL_DAL.Instance.searchData(search));
			}
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				SearchData(txtSearch.Text.Trim());
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			SearchData(txtSearch.Text.Trim());
		}

		private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridView.RowCount > 0)
			{
				DataGridViewRow row = dataGridView.SelectedCells[0].OwningRow;
				Id=long.Parse( row.Cells["LotID"].Value.ToString());
				txtLot.Text = row.Cells["Lot"].Value.ToString();
				txtModel.Text = row.Cells["Model"].Value.ToString();
				numericLotsize.Value = int.Parse(row.Cells["Lotsize"].Value.ToString());
				numericUnit.Value = int.Parse(row.Cells["UnitCtn"].Value.ToString());
				txtStartNumber.Text = row.Cells["Start_Number"].Value.ToString();
				txtEndNumber.Text = row.Cells["End_Number"].Value.ToString();
				txtDbox.Text =row.Cells["Dbox_Barcode"].Value.ToString();
				txtCtn.Text = row.Cells["Carton_Barcode"].Value.ToString();
			}
		}
	}
}
