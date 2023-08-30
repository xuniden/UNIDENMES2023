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
using UnidenDAL.AssyLine.UG;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.VIEW
{
	public partial class frmViewUGCOM2 : Form
	{
		private List<UVASSY_COM2> allData;
		private int totalPages = 1;
		public frmViewUGCOM2()
		{
			InitializeComponent();
		}
		private void LoadData(List<UVASSY_COM2> lstData)
		{
			List<UVASSY_COM2> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dgView, pagedData);
			int totalRecords = allData.Count;
			labelTotalRecords.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";

		}
		private void SearchData(string lot, DateTime dtfrom, DateTime dtto) 
		{
			allData=COM2_DAL.Instance.SearchData(lot,dtfrom,dtto);
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

		private void txtLot_KeyDown(object sender, KeyEventArgs e)
		{
			if((e.KeyCode == Keys.Enter) )
			{
				SearchData(txtLot.Text.Trim(), dtpFrom.Value.Date, dtpTo.Value.Date);
			}	
		}

		private void btLotLoad_Click(object sender, EventArgs e)
		{
			SearchData(txtLot.Text.Trim(), dtpFrom.Value.Date, dtpTo.Value.Date);
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
