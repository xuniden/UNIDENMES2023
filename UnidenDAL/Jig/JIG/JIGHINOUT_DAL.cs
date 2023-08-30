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
    public class JIGHINOUT_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGHINOUT_DAL instance;
        public static JIGHINOUT_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGHINOUT_DAL();
                return instance;
            }
        }
        public JIGHINOUT_DAL() { }
        public List<JIGH_INOUT> getInOutBySearch(string search)
        {
            return _entities.JIGH_INOUT.Where(p => p.CreatedBy.Contains(search)
                    || p.ControlNo.Contains(search)
                    || p.FromLocCode.Contains(search)
                    || p.FromSecCode.Contains(search)
                    || p.ToSecCode.Contains(search)
                    || p.ToLocCode.Contains(search)
                    || p.PIC.Contains(search)).OrderByDescending(p => p.CreatedDate).ToList();           
        }
		//sp_Jig_InOutReportOnline
		public DataTable getInOutDeviceOnline(string search)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_JigH_InOutReportOnline";
				command.CommandType = CommandType.StoredProcedure;				
				command.Parameters.Add(new SqlParameter("@Search", search));
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

		public DataTable SearchInOutByDate(int Option, string ControlNo, DateTime sdate, DateTime edate)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_JigH_InOutReport";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Option", Option));
                command.Parameters.Add(new SqlParameter("@ControlNo", ControlNo));
                command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                command.Parameters.Add(new SqlParameter("@ToDate", edate));
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
        public DataTable getListJigInOutDaily(string UserId)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_JigH_InOutDaily";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserId", UserId));
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
        public JIGH_INOUT getLastOutJig(string controlNo)
        {
            return _entities.JIGH_INOUT.Where(p => p.ControlNo == controlNo).OrderByDescending(q => q.CreatedDate).FirstOrDefault();
        }
        public string Add(JIGH_INOUT jigInOut)
        {
            string message = "";
            try
            {
                _entities.JIGH_INOUT.Add(jigInOut);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
