using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using ExcelDataReader.Log;

namespace UnidenDAL.AssyLine.REPAIR
{
	
	public class REPAIRKEYIN_DAL
	{
		UVEntities _entities = new UVEntities();
		private static REPAIRKEYIN_DAL instance;
		public static REPAIRKEYIN_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new REPAIRKEYIN_DAL();
				return instance;
			}
		}
		public REPAIRKEYIN_DAL() { }


		public string Add(UVASSY_REPAIREKEYIN repairKeyin)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_REPAIREKEYIN.Add(repairKeyin);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public string AddRange(List<UVASSY_REPAIREKEYIN> repairKeyins)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_REPAIREKEYIN.AddRange(repairKeyins);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public UVASSY_REPAIREKEYIN checkKey(string key)
		{
			return _entities.UVASSY_REPAIREKEYIN.Where(p=>p.R_Remark_2 == key).FirstOrDefault();
		}

		public List<UVASSY_REPAIREKEYIN> getListDataByUser(string userId)
		{
			return _entities.UVASSY_REPAIREKEYIN
				.Where(p=>p.CreatedBy == userId)
				.OrderByDescending(p=>p.CreatedDate)
				.Take(200)
				.ToList();
		}

		public List<UVASSY_REPAIREKEYIN> searchByDate(string search, DateTime fromdate, DateTime todate)
		{
			var query = _entities.UVASSY_REPAIREKEYIN.AsQueryable();
			if (!string.IsNullOrEmpty(search))
			{
				query = query.Where(p => p.Dept == search);
				if (fromdate <= todate)
				{
					query = query.Where(p =>
						(p.CreatedDate.HasValue && p.CreatedDate.Value >= fromdate) &&
						(p.CreatedDate.HasValue && p.CreatedDate.Value <= todate)
					);
				}
			}			

			return query.ToList();
		}

		public List<UVASSY_REPAIREKEYIN> searchData(int option,string search)
		{
			var query = _entities.UVASSY_REPAIREKEYIN.AsQueryable();
			if (option==1 && !string.IsNullOrEmpty(search))
			{
				query = query.Where(p => p.R_Lot.Contains(search));				
			}
			if (option == 2 && !string.IsNullOrEmpty(search))
			{
				query = query.Where(p => p.Repaire_Code.Contains(search));
			}
			return query.ToList();
		}
		
	}
}
