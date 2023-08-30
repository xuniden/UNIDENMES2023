using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Drawing.Charts;
using Microsoft.Office.Interop.Excel;
using Microsoft.ReportingServices.Interfaces;
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
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.AssyLine
{
    public partial class frmSetupCBModel : Form
    {
        private bool AddFlag = false;
        private long Id;
		private int totalPages = 1;
		private List<SYS_UserButtonFunction> lstUBFunction;
        public frmSetupCBModel()
        {
            InitializeComponent();
        }
		private void frmSetupCBModel_Load(object sender, EventArgs e)
		{
            ResetControll();
            _enable(false);
            showHideControll(true);
			LoadLot();
            LoadData();
			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}
        
		private void cbLot_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbLot.SelectedItem is groupLot selectedLot)
			{
				if (selectedLot.Lot.Equals("--Select--"))
				{					
                    txtModel.Text=string.Empty;
					cbLot.Focus();
					return;
				}
				else
				{
					var lotControl = LOTCONTROL_DAL.Instance.checkExistLot(selectedLot.Lot);
					if (lotControl == null)
					{
						txtModel.Text = string.Empty;
						cbLot.Focus();
						return;
                    }
					else
					{
						txtModel.Text = lotControl.Model.ToString();
					}
				}
			}
		}
		void _enable(bool t)
        {          
            cbLot.Enabled = t;
            numericLotsize.Enabled = t;
            numericDboxQty.Enabled = t;
            numericUnitQty.Enabled = t;
            cbModelType.Enabled = t;
            txtBarcodeDbox.Enabled = t;
            txtBarcodeCarton.Enabled = t;
        }

        void ResetControll()
        {
            lbl00.Text =string.Empty;
			lbl01.Text = string.Empty;
			lbl02.Text = string.Empty;
			lbl03.Text = string.Empty;
			lbl04.Text = string.Empty;
			lbl05.Text = string.Empty;
			lbl06.Text = string.Empty;
			lbl07.Text = string.Empty;

			txtModel.Text = string.Empty;
            cbLot.Text = "--Select--";
            numericLotsize.Value = 0;
            numericDboxQty.Value = 0;
            numericUnitQty.Value = 1;
            cbModelType.Text = string.Empty;
            txtBarcodeDbox.Text = string.Empty;
            txtBarcodeCarton.Text = string.Empty;



        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
		private void LoadLot()
		{
			cbLot.DataSource = MODEL_DAL.Instance.listLots();
			cbLot.DisplayMember = "Lot";
			cbLot.ValueMember = "Lot";
		}

		private void LoadDataSearch()
		{
			List<UVASSY_CBSETTING> pagedData = CBSETTING_DAL.Instance.getListBySearchCondition(txtSearch.Text.Trim(),Program.currentPage,Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dgView, pagedData);
			int totalRecords = CBSETTING_DAL.Instance.searchCount(txtSearch.Text.Trim());
			labelTotalRecords.Text = totalRecords.ToString();
			int totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";
		}
		private void LoadData()
		{
			List<UVASSY_CBSETTING> pagedData = CBSETTING_DAL.Instance.LoadData( Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dgView, pagedData);									
			labelPageInfo.Text = $"Page {Program.currentPage} of {Program.currentPage}";
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
                LoadDataSearch();
			}
        }

        private bool IsDataOK()
        {
			if (cbLot.Text.Trim().Equals("--Select--"))
			{
				MessageBox.Show("Lot không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommonDAL.Instance.SetStatusLabels(lbl00, "NG");
				cbLot.Focus();
				return false;
			}           
			else
            {
				var checkExist = CBSETTING_DAL.Instance.getInfoByLot(cbLot.Text);
				if (checkExist != null && AddFlag==true)
				{
					MessageBox.Show("LOT này đã có trong csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					CommonDAL.Instance.SetStatusLabels(lbl00, "NG");
					cbLot.SelectAll();
					cbLot.Focus();
					return false;
				}
			}
			if ((int)numericLotsize.Value < 1)
			{
				MessageBox.Show("Lotsize >0 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CommonDAL.Instance.SetStatusLabels(lbl01, "NG");
				numericLotsize.Focus();
				return false;
			}
			if (txtModel.Text.Trim().Equals(""))
			{
				MessageBox.Show("Model không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CommonDAL.Instance.SetStatusLabels(lbl02, "NG");
				cbLot.Focus();
				return false;
			}			

            if ((int)numericDboxQty.Value<1)
            {
                MessageBox.Show("DBOX-QTY phải > 0 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CommonDAL.Instance.SetStatusLabels(lbl03, "NG");
				numericDboxQty.Focus();
                return false;
            }
            if ((int)numericUnitQty.Value<1 )
            {
                MessageBox.Show("UNIT-QTY > 0 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUnitQty.Focus();
				CommonDAL.Instance.SetStatusLabels(lbl04, "NG");
				return false;
            }

            if (string.IsNullOrEmpty(cbModelType.Text.Trim()))
            {
                MessageBox.Show("CHECK MODEL TYPE không được để trống hoặc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CommonDAL.Instance.SetStatusLabels(lbl05, "NG");
				cbModelType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtBarcodeDbox.Text.Trim()))
            {
                MessageBox.Show("BARCODE ON D-BOX không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CommonDAL.Instance.SetStatusLabels(lbl06, "NG");
				txtBarcodeDbox.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtBarcodeCarton.Text.Trim()))
            {
                MessageBox.Show("BARCODE CARTON không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CommonDAL.Instance.SetStatusLabels(lbl07, "NG");
				txtBarcodeCarton.Focus();
                return false;
            }
            return true;
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
			cbLot.Enabled = false;
			showHideControll(false);
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{
			if (!cbLot.Text.Trim().Equals("") && Id > 0)
			{
				if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					var delByLot = new UVASSY_CBSETTING();
					delByLot = CBSETTING_DAL.Instance.getInfoByLot(cbLot.Text.Trim());
					if (delByLot != null)
					{
						string message = CBSETTING_DAL.Instance.Delete(delByLot);
						if (string.IsNullOrEmpty(message))
						{
							MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							AddFlag = false;
							showHideControll(true);
							ResetControll();
							_enable(false);
							LoadData();
							return;
						}
						else
						{
							MessageBox.Show("Không xóa được dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}
					else
					{
						MessageBox.Show("Bạn đã không chọn dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
			}
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			showHideControll(true);
			_enable(false);
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (IsDataOK())
			{
				var cbSetting = new UVASSY_CBSETTING
				{
					LOT = cbLot.Text.Trim(),
					MODEL = txtModel.Text.Trim(),
					DBOX_CARTON = (int)numericDboxQty.Value,
					UNIT_DBOX = (int)numericUnitQty.Value,
					CHECK_TYPE = cbModelType.Text.Trim(),
					DBOX_SERIAL = txtBarcodeDbox.Text.Trim(),
					MODEL_SERIAL = txtBarcodeCarton.Text.Trim(),
					LOTSIZE = (int)numericLotsize.Value,
					CreatedBy = Program.UserId,
					CreatedDate = CommonDAL.Instance.getSqlServerDatetime()
				};
				if (AddFlag)
				{
					string message = CBSETTING_DAL.Instance.Add(cbSetting);
					if (string.IsNullOrEmpty(message))
					{
						AddFlag = false;
						showHideControll(true);
						ResetControll();
						_enable(false);
						LoadData();
					}
					else
					{
						MessageBox.Show("Thêm mới không thành công vào csdl \n Chi tiết lỗi: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

				}
				if (AddFlag == false && Id > 0)
				{
					string message = CBSETTING_DAL.Instance.Update(cbSetting);
					if (string.IsNullOrEmpty(message))
					{
						AddFlag = false;
						showHideControll(true);
						ResetControll();
						_enable(false);
						LoadData();
					}
					else
					{
						MessageBox.Show("Ghi không thành công vào csdl \n Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

				}

			}
		}

		private void dgView_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
		{
			if (dgView.RowCount > 0)
			{
				DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
				Id = long.Parse(row.Cells["ID"].Value.ToString());
				cbLot.Text = row.Cells["LOT"].Value.ToString();
				numericLotsize.Value = int.Parse(row.Cells["LOTSIZE"].Value.ToString());
				txtModel.Text = row.Cells["MODEL"].Value.ToString();
				numericDboxQty.Value = int.Parse(row.Cells["DBOX_CARTON"].Value.ToString());
				numericUnitQty.Value = int.Parse(row.Cells["UNIT_DBOX"].Value.ToString());
				cbModelType.Text = row.Cells["CHECK_TYPE"].Value.ToString();
				txtBarcodeDbox.Text = row.Cells["DBOX_SERIAL"].Value.ToString();
				txtBarcodeCarton.Text = row.Cells["MODEL_SERIAL"].Value.ToString();
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			Search(txtSearch.Text.Trim());
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				Search(txtSearch.Text.Trim());
			}
			
		}
	}
}
