using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Jig.JIG
{
	public class JIGHREPAIRE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static JIGHREPAIRE_DAL instance;
		public static JIGHREPAIRE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new JIGHREPAIRE_DAL();
				return instance;
			}
		}
		public JIGHREPAIRE_DAL() { }

		public System.Data.DataTable searchData(string search)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Jig_repairSearch";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@search", search));

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

		public System.Data.DataTable getHistoryByUser(string user)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Jig_historyByUser";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@user", user));

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
		public string Add(JIGH_REPAIRHISTORY repairHistory)
		{
			string message = "";
			try
			{
				_entities.JIGH_REPAIRHISTORY.Add(repairHistory);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public string Update(JIGH_REPAIRHISTORY repairHistory)
		{
			string message = "";
			var upRepair = new JIGH_REPAIRHISTORY();
			upRepair = _entities.JIGH_REPAIRHISTORY.Where(p => p.Id == repairHistory.Id).FirstOrDefault();
			if (upRepair != null)
			{
				try
				{
					upRepair.RepairDate = repairHistory.RepairDate;
					upRepair.RepairReason = repairHistory.RepairReason;
					upRepair.RepairAction = repairHistory.RepairAction;
					upRepair.ImgBeforeRepair = repairHistory.ImgBeforeRepair;
					upRepair.ImgAfterRepair = repairHistory.ImgAfterRepair;
					upRepair.Remark = repairHistory.Remark;
					upRepair.RStatus = repairHistory.RStatus;
					upRepair.RepairPosition = repairHistory.RepairPosition;
					upRepair.RepairMaterial = repairHistory.RepairMaterial;
					upRepair.CreatedBy = repairHistory.CreatedBy;
					upRepair.CreatedDate = repairHistory.CreatedDate;

					_entities.SaveChanges();
					message = "";
				}
				catch (Exception ex)
				{
					message = ex.Message;
				}
			}
			return message;
		}
		public JIGH_REPAIRHISTORY getById(long Id)
		{
			return _entities.JIGH_REPAIRHISTORY.Where(p => p.Id == Id).FirstOrDefault();
		}
	}
}
