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
using UnidenDAL.AssyLine.MENU;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.VIEW
{
	public partial class frmViewSamsungRepair : Form
	{
		private DataTable dtTable;
		private int totalPages = 1;
		public frmViewSamsungRepair()
		{
			InitializeComponent();
		}
		private void LoadData(DataTable lstData)
		{
			DataTable pagedData = PagingHelper.GetPagedDataTable(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, pagedData);
			int totalRecords = dtTable.Rows.Count;
			labelTotalRecords.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";

		}
		private void search(DateTime startdate, DateTime enddate)
		{
			dtTable=REPAIRHISTORY_DAL.Instance.getSamsungRepairHistory(startdate, enddate);
		}
		private void btnSearch_Click(object sender, EventArgs e)
		{
			search(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadData(dtTable);
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
			LoadData(dtTable);
		}

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadData(dtTable);
		}

		private void iconbtnLast_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadData(dtTable);
		}
	}
}
