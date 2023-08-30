using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
    public class SmtProgramDAL
    {
        UVEntities _entities = new UVEntities();
        private static SmtProgramDAL instance;
        public static SmtProgramDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtProgramDAL();
                return instance;
            }
        }
        public SmtProgramDAL() { }

        public bool deleteProgramByKey(string program)
        {
            var lst = new List<PROGRAM>();
            lst = _entities.PROGRAMs.Where(p => p.programpartlist == program).ToList();            
            long chkls = _entities.PROGRAMHISTORies.Where(p => p.programpartlist == program).ToList().Count;
            if (lst.Count>0 && chkls<=0)
            {
                _entities.PROGRAMs.RemoveRange(lst);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
       
		public PROGRAM getByProgram(string program)
		{
			return _entities.PROGRAMs.Where(p => p.programpartlist == program).FirstOrDefault();
		}

		public PROGRAM checkFeeder(string program, string feeder)
		{
			return _entities.PROGRAMs.Where(p => p.programpartlist == program && p.fdrno == feeder).FirstOrDefault();
		}
		public PROGRAM checkPartcodeCutLot(string program, string feeder, string partcode)
		{
			return _entities.PROGRAMs.Where(p => p.programpartlist == program && p.fdrno == feeder && (
			p.partscode == partcode
			|| p.rep1 == partcode
			|| p.rep2 == partcode
			|| p.rep3 == partcode
			|| p.rep4 == partcode
			|| p.rep5 == partcode)).FirstOrDefault();
		}
		

		public List<PROGRAM>getListByDate(DateTime datefrom, DateTime dateto)
        {
            return _entities.PROGRAMs.Where(p => DateTime.Parse(p.dateupdate).Year >= datefrom.Year &&
            DateTime.Parse(p.dateupdate).Month >= datefrom.Month &&
            DateTime.Parse(p.dateupdate).Day >= datefrom.Day)
                .Where(p => DateTime.Parse(p.dateupdate).Year <= dateto.Year &&
            DateTime.Parse(p.dateupdate).Month >= dateto.Month &&
            DateTime.Parse(p.dateupdate).Day >= dateto.Day).ToList();
        }
        public List<PROGRAM> getListByPro(string program)
        {
            return _entities.PROGRAMs.Where(p => p.programpartlist==program).ToList();
        }
        public List<PROGRAM> getListByProgram(string program)
        {
            return _entities.PROGRAMs.Where(p =>p.programpartlist.Contains(program)).ToList();
        }
        public List<PROGRAM> getListByPartCode(string partcode)
        {
            return _entities.PROGRAMs.Where(p => p.partscode.Contains(partcode)).ToList();
        }
        public List<PROGRAM> getFeederByProgram(string program, string fdno)
        {
            return _entities.PROGRAMs.Where(p=>p.programpartlist==program&& p.fdrno==fdno).ToList();
        }
        public List<PROGRAM> checkPartcode(string program, string fdrno, string partcode)
        {
            //SELECT* FROM PROGRAM with(nolock) WHERE
            //programpartlist = @programpartlist   and
            //fdrno = @fdrno   and
            //(partscode = @partscode   OR
            // rep1 = @partscode or
            // rep2 = @partscode or
            // rep3 = @partscode or
            // rep4 = @partscode or
            // rep5 = @partscode)

            return _entities.PROGRAMs.Where(p => p.programpartlist == program
            && p.fdrno == fdrno
            &&
            (
            p.partscode == partcode
            || p.rep1 == partcode
            || p.rep2==partcode
            || p.rep3==partcode
            || p.rep4==partcode
            || p.rep5==partcode)).ToList();
        }

        public List<PROGRAM> getPositionByProgramAndPartCode(string program, string partcode)
        {           
            return _entities.PROGRAMs.Where(p => p.programpartlist == program           
            &&
            (
                p.partscode == partcode
                || p.rep1 == partcode
                || p.rep2 == partcode
                || p.rep3 == partcode
                || p.rep4 == partcode
                || p.rep5 == partcode)
             ).ToList();
        }

		#region Lấy thông tin của mã và số lượng dùng từ việc nhập vị trí linh kiện
        public DataTable getPartAndUsageByRefNo(string program, string refno)
        {				
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_smt_getPartAndUsageByRefNo";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@program", program));
				command.Parameters.Add(new SqlParameter("@refNo", refno));
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

		//PROGRAM_CheckInput

		#region Lấy thông tin của mã và số lượng dùng từ việc nhập vị trí linh kiện
		public DataTable PROGRAM_CheckInput(string program, string refno, string partcode)
		{			
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_PROGRAM_CheckInput";
				command.CommandType = CommandType.StoredProcedure;				
				command.Parameters.Add(new SqlParameter("@programpartlist", program));
				command.Parameters.Add(new SqlParameter("@fdrno", refno));
				command.Parameters.Add(new SqlParameter("@partscode", partcode));

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
