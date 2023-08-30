using DocumentFormat.OpenXml.Office2010.Excel;
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
using UnidenDAL.Assy;

namespace SMTPRORAM.Assy.Setup
{
	public partial class frmEditUnitByBarcode : Form
	{
		private long ID;
		public frmEditUnitByBarcode()
		{
			InitializeComponent();
		}
		private void frmEditUnitByBarcode_Load(object sender, EventArgs e)
		{
			txtSearch.Text = "";
		}
		private void Search(string search)
		{
			if (search =="")
			{
				MessageBox.Show("Nhập barcode cần tìm !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			else
			{
				CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView,LINEPROCESSHISTORY_DAL.Instance.editUnitCodeByBarcode(search));
			}
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				Search(txtSearch.Text.Trim());
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			Search(txtSearch.Text.Trim());
		}

		private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (dgView.RowCount > 0)
			{
				DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
				ID = int.Parse(row.Cells["ID"].Value.ToString());
				txtBarcode.Text = row.Cells["Barcode"].Value.ToString();
				txtUnitCode.Text = row.Cells["UnitCode"].Value.ToString();
			}
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			txtBarcode.Text = "";
			txtUnitCode.Text = "";
			ID = 0;
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (ID>0)
			{
				string bar = "";
				string unit = "";
				bar=txtBarcode.Text;
				unit=txtUnitCode.Text;
				string message = "";
				message = LINEPROCESSHISTORY_DAL.Instance.EditUnitCode(ID, txtUnitCode.Text.Trim(), Program.UserId, CommonDAL.Instance.getSqlServerDatetime());
				if (message=="")
				{
					MessageBox.Show("Đã sửa thành công,Hãy chú ý sửa đúng và không trùng Unitcode với barcode khác !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtBarcode.Enabled = true;
					txtBarcode.Text = "";
					txtUnitCode.Text = "";
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESSHISTORY_DAL.Instance.ShowEditedUnitcode(bar,unit));
					return;
				}

			}
			else
			{
				MessageBox.Show("Không có dữ liệu để Save !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
	}
}
