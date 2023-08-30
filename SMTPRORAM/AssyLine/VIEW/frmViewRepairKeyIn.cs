using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.AssyLine.UG;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.AssyLine.REPAIR;

namespace SMTPRORAM.AssyLine.VIEW
{
	public partial class frmViewRepairKeyIn : Form
	{
		private List<UVASSY_REPAIREKEYIN> allData;
		private int totalPages = 1;
		public frmViewRepairKeyIn()
		{
			InitializeComponent();
		}

		private void btLotLoad_Click(object sender, EventArgs e)
		{
			SearchDataByDate(cbSelect.Text.Trim(), dtpFrom.Value.Date, dtpTo.Value.Date);
		}
		private void LoadData(List<UVASSY_REPAIREKEYIN> lstData)
		{
			List<UVASSY_REPAIREKEYIN> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dgView, pagedData);
			int totalRecords = allData.Count;
			labelTotalRecords.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";

		}
		private void SearchDataByDate(string dept, DateTime dtfrom, DateTime dtto)
		{
			allData = REPAIRKEYIN_DAL.Instance.searchByDate(dept, dtfrom, dtto);
		}

		private void searchData(int option, string search)
		{
			allData = REPAIRKEYIN_DAL.Instance.searchData(option, search);
		}
		private void btnSeach_Click(object sender, EventArgs e)
		{
			if (cbFind.Text.Equals("Repair Code"))
			{
				searchData(2,txtLot.Text.Trim());
			}
			if (cbFind.Text.Equals("Lot"))
			{
				searchData(1, txtLot.Text.Trim());
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
			if (Program.currentPage >= totalPages)
			{
				Program.currentPage = totalPages;
			}
			else
			{
				Program.currentPage++;
			}
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

		private void btDownloadCSV_Click(object sender, EventArgs e)
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
