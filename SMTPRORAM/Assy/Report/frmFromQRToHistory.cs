using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Assy;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SMTPRORAM.Assy.Report
{
	public partial class frmFromQRToHistory : Form
	{
		public frmFromQRToHistory()
		{
			InitializeComponent();
		}
		private void Search()
		{
			string result = "";
			if (txtUnitCode.Text.Trim().Equals(""))
			{
				MessageBox.Show("Nhập dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtUnitCode.Focus();
				return;
			}
			else
			{
				result = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep01(txtUnitCode.Text.Trim());
				if (result != "")
				{
					StringBuilder result01 = new StringBuilder();
					result01 = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep02(result);
					if (result01 != null)
					{
						var dt = new DataTable();
						var dtDept = new DataTable();
						dt = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep03(result01, 1);
						CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewSMT, dt);
						dtDept = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep03(result01, 2);
						CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewDept, dtDept);

						var dtAssy = new DataTable();
						dtAssy = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep04(result, result01);
						CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewAssy, dtAssy);

						string lot = dtAssy.Rows[0]["Lot"].ToString();

						var dtRepairSMT = new DataTable();
						dtRepairSMT = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep05(result01);
						CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewRepairSMT, dtRepairSMT);

						var dtRepairAssy = new DataTable();
						result01= result01.Append( ",'"+ result+"'");
						dtRepairAssy = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep06(result01);
						CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewRepairAssy, dtRepairAssy);

						// Hiển thị toàn bộ thiết bị sử dụng cho line.

						var dtM = new DataTable();						
						dtM = LINEERRORRECORD_DAL.Instance.SearchByUnitCodeStep07(lot);
						CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewJ, dtM);

					}
				}
				else
				{
					MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}			
		}
		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void txtUnitCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				Search();
			}
		}

		private void iconbtnExport_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Excel Files|*.xlsx";
				saveFileDialog.Title = "Save Excel File";
				saveFileDialog.FileName = "output.xlsx"; // Default file name

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;
					ExportToExcel(filePath, dgViewSMT, dgViewJ, dgViewAssy, dgViewDept, dgViewRepairSMT, dgViewRepairAssy);
					MessageBox.Show("Export to Excel completed successfully!");
				}
			}
		}
		private void ExportToExcel(string filePath, params DataGridView[] dataGridViews)
		{
			ExcelPackage.LicenseContext = LicenseContext.Commercial;
			using (var package = new ExcelPackage(new FileInfo(filePath)))
			{
				foreach (var dataGridView in dataGridViews)
				{
					if (dataGridView.Rows.Count>0)
					{
						// Create a new worksheet for each DataGridView
						var worksheet = package.Workbook.Worksheets.Add(dataGridView.Name);

						// Write the column headers to the Excel sheet
						for (int col = 0; col < dataGridView.Columns.Count; col++)
						{
							worksheet.Cells[1, col + 1].Value = dataGridView.Columns[col].HeaderText;
						}

						// Write the data rows to the Excel sheet
						for (int row = 0; row < dataGridView.Rows.Count; row++)
						{
							for (int col = 0; col < dataGridView.Columns.Count; col++)
							{
								worksheet.Cells[row + 2, col + 1].Value = dataGridView.Rows[row].Cells[col].Value;
							}
						}
					}					
				}
				package.Save();
			}
		}

	}
}
