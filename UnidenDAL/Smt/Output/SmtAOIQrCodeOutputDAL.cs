using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Smt.DataControl;
using UnidenDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UnidenDAL.Smt.Output
{
    public class SmtAOIQrCodeOutputDAL
    {
        public class SearchOutput
        {
            public string QRCODE { get; set; }
            public string PROGRAM { get; set; }
            public string FEEDER { get; set; }
            public string LINENAME { get; set; }
            public string MODEL { get; set; }
            public string PARTCODE { get; set; }
            public string NDESC { get; set; }
            public string DATECODE { get; set; }
            public string USAGE { get; set; }
            public string DATE { get; set; }
            public string USERID { get; set; }
            public string PCBNAME { get; set; }
            public string PCBTYPE { get; set; }
            public string DEPT { get; set; }
            public string CHECK2PRO { get; set; }

        }
        public class IPQCChecker
        {
           public string partscode { get; set; }
            public string fdrno { get; set; }
            public string ndesc { get; set; }
            public int SoPCBCothedung { get; set; }
            public int counts { get; set; }
            public int Solanthaylinhkien { get; set; }
            public string remark1 { get; set; }
        }
        public class MistakeMaterial
        {
            public string fdrno { get; set; }
            public string partcode { get;set; }
            public string desc { get; set; }
        }
        public class SelectValue
        {
            public int row_num { get; set; }
			public long Id { get; set; }
            public string programpartlist { get; set; } 
            public string fdrno { get; set; }
			public string partscode { get; set; }
            public string ndesc { get; set; }
            public int usage { get; set; }
            public string checkedby { get; set; }
            public string checkedtime { get; set; }
            public int reqqty { get; set; }
            public string datecode { get; set; }
            public int Solanthaylinhkien { get; set; }
            public int SoPCBCothedung { get; set; }
            public string remark1 { get; set; }
            public string remark2 { get; set; }
            public string remark3 { get; set; }
            public int counts { get; set; }
        }

        UVEntities _entities = new UVEntities();
        private static SmtAOIQrCodeOutputDAL instance;
        public static SmtAOIQrCodeOutputDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtAOIQrCodeOutputDAL();
                return instance;
            }
        }
        public SmtAOIQrCodeOutputDAL() { }

		#region Download Data
		public List<EASTECH_SMT_OUTPUT> DownloadData(int Option, string search,DateTime frm, DateTime to)
		{
			var lstResult = new List<EASTECH_SMT_OUTPUT>();
			if (Option == 1)
			{
				lstResult = _entities.EASTECH_SMT_OUTPUT.Where(p => p.QRCode == search && p.DateT >= frm && p.DateT <= to).ToList();
			}
			if (Option == 2)
			{
				lstResult = _entities.EASTECH_SMT_OUTPUT.Where(p => p.Partcode == search && p.DateT >= frm && p.DateT <= to).ToList();
			}
			//if (Option == 3)
			//{
			//	lstResult = _entities.EASTECH_SMT_OUTPUT.Where(p => p.Model == search).ToList();
			//}
			return lstResult;
		}
		#endregion


		#region Đếm số dữ liệu tìm thấy theo partcode
		public long CountSearchPartAndProgram(int Option, string search, DateTime from, DateTime to)
		{
            long countRecords = 0;
			if (Option == 1)
			{
				countRecords= _entities.EASTECH_SMT_OUTPUT.Where(p => p.QRCode == search && (!p.DateT.HasValue || (p.DateT >= from && p.DateT <= to))).Count();
			}
			if(Option==2)
			{
				countRecords= _entities.EASTECH_SMT_OUTPUT.Where(p => p.Partcode == search && (!p.DateT.HasValue || (p.DateT >= from && p.DateT <= to))).Count();
			}
            if (Option==3)
            {             
				countRecords= _entities.EASTECH_SMT_OUTPUT.Where(p => p.Model == search && (!p.DateT.HasValue || (p.DateT >= from && p.DateT <= to))).Count();

				//string sqlQuery = "SELECT COUNT(*) FROM EASTECH_SMT_OUTPUT WHERE Model = @search AND DateT >= @from AND DateT <= @to";
				//countRecords = _entities.Database.SqlQuery<int>(sqlQuery,
				//	new SqlParameter("@search", search),
				//	new SqlParameter("@from", from),
				//	new SqlParameter("@to", to))
				//	.FirstOrDefault();
				//countRecords = _entities.EASTECH_SMT_OUTPUT.AsNoTracking().Count(p => p.Model == search && p.DateT >= from && p.DateT <= to);

			}
            return countRecords;
		}
		#endregion

		#region Tìm kiếm và phân trang theo part
		public List<EASTECH_SMT_OUTPUT> searchByQRModelPartPagesEntity(int Option, int pageNumber, int RecordPerPage, string search, DateTime from, DateTime to)
		{
			var lstResult = new List<EASTECH_SMT_OUTPUT>();
			int startIndex = (pageNumber - 1) * RecordPerPage;
			if (Option == 1)
			{
				lstResult = _entities.EASTECH_SMT_OUTPUT.Where(p => p.QRCode == search &&
                                                                         p.DateT>=from &&
                                                                         p.DateT<=to)
						.OrderBy(p => p.QRCode) // Replace with the actual property to order by
						.Skip(startIndex)
						.Take(RecordPerPage)						
						.ToList();
			}
			if (Option == 2)
			{
				lstResult = _entities.EASTECH_SMT_OUTPUT.Where(p => p.Partcode == search &&
																		 p.DateT >= from &&
																		 p.DateT <= to)
						.OrderBy(p => p.Partcode) // Replace with the actual property to order by
						.Skip(startIndex)
						.Take(RecordPerPage)						
						.ToList();
			}
			if (Option == 3)
			{
				lstResult = _entities.EASTECH_SMT_OUTPUT.Where(p => p.Model == search &&
																		 p.DateT >= from &&
																		 p.DateT <= to)
						.OrderBy(p => p.Partcode) // Replace with the actual property to order by
						.Skip(startIndex)
						.Take(RecordPerPage)
						.ToList();
			}
			return lstResult;
		}
		#endregion


		#region Thêm dữ liệu và Output và update count ở history
		public string AddRangeAndUpdate(List<EASTECH_SMT_OUTPUT> outputList, List<long> idListToUpdate)
		{
			string message = "";

			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					AddOutputRecords(outputList);
					UpdateSecondTable(idListToUpdate);
					_entities.SaveChanges(); // Save changes for both additions and updates
					dbContextTransaction.Commit();
				}
				catch (Exception ex)
				{
					dbContextTransaction.Rollback();
					message = ex.Message;
				}
			}
			return message;
		}

		private void AddOutputRecords(List<EASTECH_SMT_OUTPUT> outputList)
		{
			_entities.EASTECH_SMT_OUTPUT.AddRange(outputList);
		}

		private void UpdateSecondTable(List<long> idListToUpdate)
		{
			foreach (var itemId in idListToUpdate)
			{
				var recordToUpdate = _entities.EASTECH_PROGRAMHISTORY.FirstOrDefault(e => e.Id == itemId);
				if (recordToUpdate != null)
				{
					recordToUpdate.counts += 1;
				}
			}
		}
		#endregion

		public int GetMaterialPerPCBByUser(string remark, string programKey1, string programKey2)
		{
			var count = _entities.EASTECH_SMT_OUTPUT
				.Where(e => e.Remark == remark && (e.programkey == programKey1 || e.programkey == programKey2))
				.GroupBy(e => e.QRCode)
				.Count();
			return count;
		}

		public int GetQRCodeCountByUserAndDate(string remark, string qrCode, string programKey1, string programKey2, DateTime dateT)
		{
			var count = _entities.EASTECH_SMT_OUTPUT
		                .Where(e => e.Remark == remark && e.QRCode == qrCode &&
					                (e.programkey == programKey1 || e.programkey == programKey2) &&
					                (e.DateT.HasValue && e.DateT.Value.Date.ToString("yyyy/MM/dd") == dateT.Date.ToString("yyyy/MM/dd")))
		                .Count();
			return count;
		}

		public bool checkLineName(string linename)
        {
            var lstLine = _entities.SMT_LINE.Where(p => p.LineName == linename).ToList();
            if (lstLine.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkProgramHistory(string program)
        {
            var lstProgram = _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == program).ToList();
            if (lstProgram.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<EASTECH_PROGRAMHISTORY> getProgramHistoryByKeyLineName(string program, string linename)
        {
            return _entities.EASTECH_PROGRAMHISTORY.Where(
                p => p.programpartlist == program
             && p.remark1 == linename
             && (p.SoPCBCothedung - p.counts) > 0
             ).OrderBy(p=>p.psubkey).ThenBy(p=>p.Solanthaylinhkien).ToList();
        }
        public tbl_EstechSerialGeneral getSerialInfo(string QrCode, string model)
        {
            return _entities.tbl_EstechSerialGeneral.Where(
                p => p.Serial_Number == QrCode &&
                p.Model == model
                ).FirstOrDefault();
        }
        public List<EASTECH_SMT_OUTPUT> getOutputInfo(string QrCode, string check2face)
        {
            return _entities.EASTECH_SMT_OUTPUT.Where(
                p => p.QRCode == QrCode &&
                p.Remark4 == check2face
                ).ToList();
        }

        public List<EASTECH_SMT_OUTPUT> getOutputInfoByQrCodeAndDept(string Qrcode, string dept)
        {
            return _entities.EASTECH_SMT_OUTPUT.Where(p=>p.QRCode==Qrcode
            && p.Remark3==dept).ToList();
        }

		#region Kiểm tra QR code đã được bắn lần nào theo bộ phận chưa
		public EASTECH_SMT_OUTPUT checkQRCodeByDept(string qrcode, string dept)
        {
            return _entities.EASTECH_SMT_OUTPUT.Where(p => p.QRCode == qrcode && p.Remark3 == dept).FirstOrDefault();
		}
		#endregion
		#region Kiểm tra QR code đã được bắn mặt 2 lần nào chưa
		public EASTECH_SMT_OUTPUT checkQRCodeScan2Face(string qrcode, string face2)
		{
			return _entities.EASTECH_SMT_OUTPUT.Where(p => p.QRCode == qrcode && p.Remark4 == face2).FirstOrDefault();
		}
		#endregion



		public List<SelectValue> GetSelectValues(string program, string line)
        {
            return (from a in _entities.sp_EastechOutputHistory_SelectCheckByProkey(program, line)
                    select new SelectValue
                    {
                        row_num= (int)a.row_num,
                        Id=a.Id,
                        programpartlist=a.programpartlist,
                        fdrno=a.fdrno,
                        partscode=a.partscode,
                        ndesc=a.ndesc,
                        usage=(int)a.usage,
                        checkedby=a.checkedby,
                        checkedtime=a.checkedtime,
                        reqqty=a.reqqty,
                        datecode=a.datecode,
                        Solanthaylinhkien =a.Solanthaylinhkien,
                        SoPCBCothedung=a.SoPCBCothedung,
                        remark1=a.remark1,
                        remark2=a.remark2,
                        remark3=a.remark3,
                        counts=(int)a.counts

                    }).ToList();
        }
        public bool Add (EASTECH_SMT_OUTPUT output)
        {
            try
            {
                _entities.EASTECH_SMT_OUTPUT.Add(output);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(long Id)
        {
            var _hisotryUpdate = _entities.EASTECH_PROGRAMHISTORY.Where(p => p.Id ==Id ).FirstOrDefault();
            if (_hisotryUpdate != null)
            {
                try
                {
                    _hisotryUpdate.counts = _hisotryUpdate.counts+1;
                    _entities.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        

        public int CountByChecker(string program1, string program2, string userid)
        {            
            var query = _entities.sp_SmtOuput_CountByChecker (program1, program2, userid).Count();
            return query;

        }
        public int CountQRCodeByUser(string program1, string program2, string Qrcode, string userid, DateTime createddate)
        {
            var query = _entities.sp_SmtOuput_CountQrCodeByUser(program1, program2,Qrcode ,userid, createddate).Count();
            return query;

        }

        public List<MistakeMaterial> getMistakeMaterial(string program , string line)
        {
            return (from a in _entities.sp_Smt_CheckMistakeMaterial(program,line)
                   select new MistakeMaterial
                   {
                       fdrno=a.fdrno,
                       partcode=a.partscode,
                       desc=a.ndesc
                   }).ToList();
        }

        public List<IPQCChecker>getIPQCChecker(string program, string line)
        {
            return (from a in _entities.sp_SmtIPQCChecker(program,line)
                    select new IPQCChecker
                    {
                        partscode=a.partscode,
                        fdrno=a.fdrno,
                        ndesc=a.ndesc,
                        SoPCBCothedung=a.SoPCBCothedung,
                        Solanthaylinhkien=a.Solanthaylinhkien,
                        counts=(int)a.counts,
                        remark1=a.remark1
                    }).ToList();
        }
        public List<SearchOutput> SearchQRCodeByDateNew(string QRCode, DateTime sdate, DateTime edate)
        {
            var query = (from a in _entities.sp_smt_output_searchBydate(QRCode,sdate,edate).ToList()
                         select new SearchOutput
                         {
                             QRCODE=a.QRCode,
                             PROGRAM=a.programkey,
                             FEEDER=a.Feeder,
                             LINENAME=a.LineName,
                             MODEL=a.Model,
                             PARTCODE=a.Partcode,
                             NDESC=a.NDesc,
                             DATECODE=a.DateCode,
                             USAGE=a.usage.ToString(),
                             DATE=a.DateT.ToString(),
                             USERID=a.UserId,
                             PCBNAME=a.PCBName,
                             PCBTYPE=a.PCBType,
                             DEPT=a.Dept,
                             CHECK2PRO=a.Check2Pro
                         }).ToList();
            return query;
        }


        public DataTable SearchQrcodeByDate(string QRCode,DateTime sdate, DateTime edate)
        {           
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_smt_output_searchBydate";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@QRCode", QRCode));
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
        public DataTable SearchModelByDate(string Model, DateTime sdate, DateTime edate)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_smt_output_searchByModel";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Model", Model));
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
        public DataTable SearchPartCodeByDate(string Partcode, DateTime sdate, DateTime edate)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_smt_output_searchByPartcode";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Partcode", Partcode));
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
        public DataTable getDataForChart()
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_smt_output_getDataForChart";
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

        public EASTECH_SMT_OUTPUT checkQRCodeExist(string QRCode)
        {
            return _entities.EASTECH_SMT_OUTPUT.Where(p=>p.QRCode==QRCode).FirstOrDefault();
        }

		public int GetQRCodeCountByUserAndDateNEW(string pgkey1, string pgkey2, string QRCode, string Remark, DateTime DateT)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechOutputHistory_ListQrByUserNew";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@programkey1", pgkey1));
				command.Parameters.Add(new SqlParameter("@programkey2", pgkey2));
				command.Parameters.Add(new SqlParameter("@QRCode", QRCode));
				command.Parameters.Add(new SqlParameter("@Remark", Remark));
				command.Parameters.Add(new SqlParameter("@DateT", DateT));
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}
			return int.Parse(dt.Rows[0]["QRCodeCount"].ToString());
		}
		
	}
}
