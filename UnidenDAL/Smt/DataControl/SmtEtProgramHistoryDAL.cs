using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using System.Runtime.Remoting.Contexts;

namespace UnidenDAL.Smt.DataControl
{
    public class HistoryDisplay
    {
		public long Id { get; set; }
		public string programpartlist { get; set; }		
		public string fdrno { get; set; }
		public string partscode { get; set; }
		public string ndesc { get; set; }
		public Nullable<int> usage { get; set; }
		public string checkedby { get; set; }
		public string checkedtime { get; set; }
		public int reqqty { get; set; }
		public string datecode { get; set; }
		public int Solanthaylinhkien { get; set; }
		public int SoPCBCothedung { get; set; }
		public string Line { get; set; }
		public string Dept { get; set; }
		public string remark3 { get; set; }
		public Nullable<int> counts { get; set; }
	}
    public class SmtEtProgramHistoryDAL
    {
        UVEntities _entities = new UVEntities();
        private static SmtEtProgramHistoryDAL instance;
        public static SmtEtProgramHistoryDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtEtProgramHistoryDAL();
                return instance;
            }
        }

        public SmtEtProgramHistoryDAL() { }
        		

		public DataTable searchByProgram(string program)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_smt_searchByProgram";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@program", program));
               
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
		#region Đếm số dữ liệu tìm thấy theo partcode
		public long CountSearchPartAndProgram(int Option,string search)
        {
            if (Option==1)
            {
				return _entities.EASTECH_PROGRAMHISTORY.Where(p => p.partscode == search).Count();
			}
            else
            {
				return _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == search).Count();
			}
            
        }
		#endregion

		#region Download Data
        public List<EASTECH_PROGRAMHISTORY> DownloadData(int Option, string search)
        {
            var lstResult= new  List<EASTECH_PROGRAMHISTORY>();
            if (Option==1)
            {
                lstResult=_entities.EASTECH_PROGRAMHISTORY.Where(p=>p.partscode== search).ToList();
            }
            if (Option==2)
            {
				lstResult = _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == search).ToList();
			}
            return lstResult;
        }
		#endregion


		#region Tìm kiếm và phân trang theo part
		public List<HistoryDisplay> searchByPartAndProgramPagesEntity(int Option, int pageNumber, int RecordPerPage, string search)
		{
            var lstResult= new List<HistoryDisplay>();
			int startIndex = (pageNumber - 1) * RecordPerPage;
			if (Option==1)
            {
                lstResult = _entities.EASTECH_PROGRAMHISTORY.Where(p => p.partscode == search)
                        .OrderBy(p => p.programpartlist) // Replace with the actual property to order by
                        .Skip(startIndex)
                        .Take(RecordPerPage)
                        .Select(p => new HistoryDisplay 
                        { 
                            Id = p.Id,
                            programpartlist = p.programpartlist,
                            fdrno = p.fdrno,
                            partscode = p.partscode,
                            ndesc = p.ndesc,
                            usage = p.usage,
                            checkedby = p.checkedby,
                            checkedtime = p.checkedtime,
                            reqqty = p.reqqty,
                            datecode = p.datecode,
                            Solanthaylinhkien=p.Solanthaylinhkien,
                            SoPCBCothedung=p.SoPCBCothedung,
                            Line=p.remark1,
                            Dept=p.remark2,
                            remark3 = p.remark3,
                            counts = p.counts
                        })
			            .ToList();
			}
			if (Option == 2)
			{
				lstResult = _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == search)
					    .OrderBy(p => p.programpartlist) // Replace with the actual property to order by
						.Skip(startIndex)
						.Take(RecordPerPage)
						 .Select(p => new HistoryDisplay
						 {
							 Id = p.Id,
							 programpartlist = p.programpartlist,
							 fdrno = p.fdrno,
							 partscode = p.partscode,
							 ndesc = p.ndesc,
							 usage = p.usage,
							 checkedby = p.checkedby,
							 checkedtime = p.checkedtime,
							 reqqty = p.reqqty,
							 datecode = p.datecode,
							 Solanthaylinhkien = p.Solanthaylinhkien,
							 SoPCBCothedung = p.SoPCBCothedung,
							 Line = p.remark1,
							 Dept = p.remark2,
							 remark3 = p.remark3,
							 counts = p.counts
						 })
						.ToList();
			}
            return lstResult;
		}
		#endregion


		#region Tìm kiếm và phân trang theo part
		public DataTable searchByPartAndProgramPages(int Option,int pageNumber, int RecordPerPage, string search)
        {
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_smt_searchHistoryByPart";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Option", Option));
				command.Parameters.Add(new SqlParameter("@PageNumber", pageNumber));
				command.Parameters.Add(new SqlParameter("@RecordsPerPage", RecordPerPage));
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
		#endregion
		public DataTable searchByPart(string part)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_smt_searchByPart";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@part", part));

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

        
        public void Add(EASTECH_PROGRAMHISTORY etHistory)
        {
            try
            {
                _entities.EASTECH_PROGRAMHISTORY.Add(etHistory);
                _entities.SaveChanges();
            }
            catch (Exception)
            {

               
            }
        }
        //select psubkey, Solanthaylinhkien from dbo.EASTECH_PROGRAMHISTORY with(nolock)
        //where psubkey= @psubkey

        //group by psubkey, Solanthaylinhkien
        //order by Solanthaylinhkien desc

        public EASTECH_PROGRAMHISTORY getMaxSolanthaylinhkien(string psubkey)
        {
            return _entities.EASTECH_PROGRAMHISTORY.Where(p => p.psubkey == psubkey).OrderByDescending(p=>p.Solanthaylinhkien).FirstOrDefault();
        }
    }
}
