using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UnidenDAL.Assy.Setup;
using UnidenDTO;

namespace UnidenDAL.Assy
{
	public class LINEREPAIRHISTORY_DAL
	{
		UVEntities _entities = new UVEntities();
		private static LINEREPAIRHISTORY_DAL instance;
		public static LINEREPAIRHISTORY_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new LINEREPAIRHISTORY_DAL();
				return instance;
			}
		}
		public LINEREPAIRHISTORY_DAL() { }

		public string Add(UV_LINEREPAIRHISTORY history)
		{
			string message = "";
			try
			{
				_entities.UV_LINEREPAIRHISTORY.Add(history);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public List<UV_LINEREPAIRHISTORY> getListHistoryByUser(string userId) { 
		
			return _entities.UV_LINEREPAIRHISTORY.Where(p=>p.CreatedBy == userId).OrderByDescending(p=>p.CreatedDate).Take(500).ToList();
		}

		
		#region Lấy danh sách top 5 nguyên nhân lỗi theo Lot
		public DataTable TopCauseErrorForLot(string lot)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_TopCauseErrorForLot";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@lot", lot));
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}
			return dt;
		}
		#endregion
	}
}
