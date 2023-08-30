using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Data;
using UnidenDTO;
using System;
using System.Linq;

namespace UnidenDAL.Jig
{
    public class JIGREPAIRHISTORY_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGREPAIRHISTORY_DAL instance;
        public static JIGREPAIRHISTORY_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGREPAIRHISTORY_DAL();
                return instance;
            }
        }
        public JIGREPAIRHISTORY_DAL() { }

        public JIG_REPAIRHISTORY getById(long Id)
        {
            return _entities.JIG_REPAIRHISTORY.Where(p=>p.Id== Id).FirstOrDefault();    
        }

        public System.Data.DataTable searchData(string search)
        {   
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_Eq_repairSearch";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@search",search));
                
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
        //sp_Eq_historyByUser

        public System.Data.DataTable getHistoryByUser(string user)
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_Eq_historyByUser";
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
        public string Add(JIG_REPAIRHISTORY repairHistory)
        {
            string message = "";
            try
            {
                _entities.JIG_REPAIRHISTORY.Add(repairHistory);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

		public string Update(JIG_REPAIRHISTORY repairHistory)
		{
			string message = "";
			var upRepair = new JIG_REPAIRHISTORY();
            upRepair = _entities.JIG_REPAIRHISTORY.Where(p => p.Id == repairHistory.Id).FirstOrDefault();
            if (upRepair!=null)
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
	}
}
