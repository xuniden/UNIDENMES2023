using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Jig
{
    public class ShowInOut
    {
        public long Id { get; set; }
        public string InOut_Type { get; set; }
        public string ControlNo { get; set; }
        public DateTime CalDate { get; set; }
        public string FromSecCode { get; set; }
        public string FromLocCode { get; set; }
        public string ToSecCode { get; set; }
        public string ToLocCode { get; set; }
        public string PIC { get; set; }
        public string Appr { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class JIGINOUT_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGINOUT_DAL instance;
        public static JIGINOUT_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGINOUT_DAL();
                return instance;
            }
        }
        public JIGINOUT_DAL() { }
        public DataTable SearchInOutByDate(int Option,string ControlNo ,DateTime sdate, DateTime edate)
        {
            //using (var cmd = new SqlCommand("sp_smt_output_searchBydate",SMTPROGRAM_Da.SqlDataProvider.GetConnection()))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;                                
            //    cmd.Parameters.Add(new SqlParameter("@QRCode", QRCode));
            //    cmd.Parameters.Add(new SqlParameter("@FromDate", sdate));
            //    cmd.Parameters.Add(new SqlParameter("@ToDate", edate));
            //    var da = new SqlDataAdapter(cmd);
            //    var dt = new DataTable();
            //    da.Fill(dt);
            //    return dt;
            //}
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_Jig_InOutReport";                
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
        public DataTable getListJigOnline()
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_JIG_ListJIGOnLine";
                command.CommandType = CommandType.StoredProcedure;     
                
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
                command.CommandText = "sp_Jig_InOutDaily";
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
        public List<ShowInOut> getInOutBySearch(string search)
        {
            return (from a in _entities.JIG_INOUT.Where(p => p.CreatedBy.Contains(search)
                    || p.ControlNo.Contains(search)
                    || p.FromLocCode.Contains(search)
                    || p.FromSecCode.Contains(search)
                    || p.ToSecCode.Contains(search)
                    || p.ToLocCode.Contains(search)
                    || p.PIC.Contains(search))

                    select new ShowInOut
                    {
                        Id = a.Id,
                        ControlNo = a.ControlNo,
                        InOut_Type = a.InOut_Type,
                        FromLocCode = a.FromLocCode,
                        FromSecCode = a.FromSecCode,
                        ToLocCode = a.ToLocCode,
                        ToSecCode = a.ToSecCode,
                        PIC = a.PIC,
                        Appr = a.Appr,
                        Remark = a.Remark,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate
                    }).OrderByDescending(p => p.CreatedDate).ToList();
        }

		//sp_Jig_InOutReportOnline
		public DataTable getInOutDeviceOnline(string search)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Jig_InOutReportOnline";
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


		public List<ShowInOut> getInOutByUserId(string UserId)
        {
            var date = CommonDAL.Instance.getSqlServerDatetime();
            return (from a in _entities.JIG_INOUT.Where(p=>p.CreatedBy==UserId && 
                    (
                        p.CreatedDate.Year==date.Year
                        && p.CreatedDate.Month==date.Month
                        && p.CreatedDate.Day==date.Day
                        )
                    )
                    select new ShowInOut
                    {
                        Id = a.Id,
                        ControlNo = a.ControlNo,                        
                        InOut_Type = a.InOut_Type,
                        FromLocCode = a.FromLocCode,
                        FromSecCode = a.FromSecCode,
                        ToLocCode = a.ToLocCode,
                        ToSecCode = a.ToSecCode,
                        PIC=a.PIC,
                        Appr=a.Appr,
                        Remark=a.Remark,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate
                    }).OrderByDescending(p=>p.CreatedDate).ToList();
        }
        public JIG_INOUT getLastOutJig(string controlNo)
        {
            return _entities.JIG_INOUT.Where(p => p.ControlNo == controlNo).OrderByDescending(q => q.CreatedDate).FirstOrDefault();
        }
        public string Add(JIG_INOUT jigInOut)
        {
            string message = "";
            try
            {
                _entities.JIG_INOUT.Add(jigInOut);
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
