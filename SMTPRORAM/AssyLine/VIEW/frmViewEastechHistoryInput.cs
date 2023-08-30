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
using UnidenDAL.AssyLine.ETASSY;
using UnidenDAL.AssyLine.MENU;
using UnidenDAL.AssyLine.REPAIR;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.VIEW
{
	public partial class frmViewEastechHistoryInput : Form
	{
		private List<UVASSY_EASTECHHISTORY> allData;
		private int totalPages = 1;
		public frmViewEastechHistoryInput()
		{
			InitializeComponent();
		}

		private void frmViewEastechHistoryInput_Load(object sender, EventArgs e)
		{
			LoadModel();
		}

		private void LoadModel()
		{
			cbModel.DataSource = EASTECHPCBCODE_DAL.Instance.getModel();
			cbModel.DisplayMember = "Model";
			cbModel.ValueMember = "Model";
		}
		private void LoadData(List<UVASSY_EASTECHHISTORY> lstData)
		{
			List<UVASSY_EASTECHHISTORY> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dgView, pagedData);
			int totalRecords = allData.Count;
			labelTotalRecords.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";

		}
		private void SearchDataByDate(string search, DateTime dtfrom, DateTime dtto)
		{
			allData = EASTECHHISTORY_DALL.Instance.searchByModelvsDate(search, dtfrom, dtto);
		}
		private void btTimKiem_Click(object sender, EventArgs e)
		{
			SearchDataByDate(cbModel.Text.Trim(), dtPick1.Value.Date, dtPick2.Value.Date);
		}

		private void SearchDataByModel(string search)
		{
			allData = EASTECHHISTORY_DALL.Instance.searchByModel(search);
		}
		private void btLoad_Click(object sender, EventArgs e)
		{
			SearchDataByModel(cbModel.Text.Trim());
		}

		private void btDownload_Click(object sender, EventArgs e)
		{
			try
			{
				string filename = "";

				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.InitialDirectory = @"D:\";
				saveFileDialog1.Title = "Save Csv Files";
				saveFileDialog1.DefaultExt = "csv";
				saveFileDialog1.Filter = "Csv files (*.csv)|*.csv";
				saveFileDialog1.FilterIndex = 1;
				saveFileDialog1.RestoreDirectory = true;
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					filename = saveFileDialog1.FileName;
					CommonDAL.Instance.WriteCSV(allData, filename);
					MessageBox.Show("Đã Export Thành Công !!!");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
				throw;
			}
		}
	}
}
