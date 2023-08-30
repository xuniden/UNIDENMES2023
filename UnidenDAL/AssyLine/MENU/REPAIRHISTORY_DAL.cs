using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.AssyLine.ETASSY;
using UnidenDTO;

namespace UnidenDAL.AssyLine.MENU
{
	public class REPAIRHISTORY_DAL
	{
		UVEntities _entities = new UVEntities();
		private static REPAIRHISTORY_DAL instance;
		public static REPAIRHISTORY_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new REPAIRHISTORY_DAL();
				return instance;
			}
		}
		public REPAIRHISTORY_DAL() { }

		public UVASSY_REPAIRHISTORY checkRepairCode(string repairCode)
		{
			return _entities.UVASSY_REPAIRHISTORY
				.Where(p=>p.RepairCode == repairCode)
				.FirstOrDefault();
		}

		public string Add(UVASSY_REPAIRHISTORY history) 
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_REPAIRHISTORY.Add(history);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public List<UVASSY_REPAIRHISTORY> getAllInforByUser(string model,string userId)
		{
			return _entities.UVASSY_REPAIRHISTORY
				.Where(p => p.CreatedBy == userId && p.Model == model)
				.OrderByDescending(p => p.CreatedDate)
				.ToList();
		}

		public DataTable getSamsungRepairHistory(DateTime startdate, DateTime endate)
		{
			var dt = new System.Data.DataTable();
			if (startdate<=endate)
			{
				using (var command = _entities.Database.Connection.CreateCommand())
				{
					command.CommandText = "sp_uvassy_SamsungRepairReport";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("@startdate", startdate));
					command.Parameters.Add(new SqlParameter("@enddate", endate));
					if (command.Connection.State != ConnectionState.Open)
					{
						command.Connection.Open();
					}
					using (var reader = command.ExecuteReader())
					{
						dt.Load(reader);
					}
				}
			}			
			return dt;
		}
	}
}
