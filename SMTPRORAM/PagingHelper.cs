using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDTO;

namespace SMTPRORAM
{
	public static class PagingHelper
	{
		public static List<T> GetPagedList<T>(List<T> data, int pageNumber, int pageSize)
		{
			int skip = (pageNumber - 1) * pageSize;
			return data.Skip(skip).Take(pageSize).ToList();
		}
		//private void LoadData()
		//{
		//	List<UVASSY_EASTECHQRWIRELESS> pagedData = PagingHelper.GetPagedList(allData, currentPage, pageSize);
		//	dataGridView1.DataSource = pagedData;

		//	int totalRecords = allData.Count;
		//	int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
		//	labelPageInfo.Text = $"Page {currentPage} of {totalPages}";
		//}
		public static DataTable GetPagedDataTable(DataTable sourceTable, int pageNumber, int pageSize)
		{
			DataTable pagedTable = sourceTable.Clone();
			int startIndex = (pageNumber - 1) * pageSize;

			for (int i = startIndex; i < startIndex + pageSize && i < sourceTable.Rows.Count; i++)
			{
				pagedTable.ImportRow(sourceTable.Rows[i]);
			}
			return pagedTable;
		}

		//private void LoadData()
		//{
		//	DataTable pagedData = GetPagedDataTable(allData, currentPage, pageSize);
		//	dataGridView1.DataSource = pagedData;

		//	int totalRecords = allData.Rows.Count;
		//	int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
		//	labelPageInfo.Text = $"Page {currentPage} of {totalPages}";
		//}

		public static List<T> GetPagedData<T>(IQueryable<T> query, int pageNumber, int pageSize)
		{
			int skip = (pageNumber - 1) * pageSize;
			return query.Skip(skip).Take(pageSize).ToList();
		}

		//private void LoadData()
		//{
		//	using (YourDbContext context = new YourDbContext())
		//	{
		//		IQueryable<YourEntity> query = context.YourEntities;

		//		List<YourEntity> pagedData = PagingHelper.GetPagedData(query, currentPage, pageSize);
		//		dataGridView1.DataSource = pagedData;

		//		int totalPages = PagingHelper.GetTotalPageCount(query, pageSize);
		//		labelPageInfo.Text = $"Page {currentPage} of {totalPages}";
		//	}
		//}


		public static int GetTotalPageCount<T>(IQueryable<T> query, int pageSize)
		{
			int totalRecords = query.Count();
			int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
			return totalPages;
		}
	}
}
