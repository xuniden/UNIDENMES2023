using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace UnidenDAL.Smt.DataControl
{
    public class CutLotQtyFeeder
    {
      public long ID { get; set; }
      public string fdrno { get; set; }
      public string partscode { get; set; }
      public string ndesc { get; set; }
      public int reqqty { get; set; }
      public int usage { get; set; }
      public int Solanthaylinhkien { get; set; }
      public int SoPCBCothedung { get; set; }
      public string remark1 { get; set; }
    }
    public class CombineData
    {
      public string   programpartlist { get; set; }
      public string fdrno { get; set; }
      public string partscode { get; set;        }
      public int usage { get; set; }
      public int Solanthaylinhkien { get; set; }
      public int SoPCBCothedung { get; set; }
      public int counts { get; set; }
      public string remark2 { get; set; }
    }
    public class ProgramQR
    {        
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
    public class newProgram
    {
        public long row_num { get; set; }
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
    public class ProgramLine
    {
        public string programlist { get; set; }
        public string line { get; set; }
    }
    public class SmtProgramHistoryNewDAL
    {
        UVEntities _entities = new UVEntities();
        private static SmtProgramHistoryNewDAL instance;
        public static SmtProgramHistoryNewDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtProgramHistoryNewDAL();
                return instance;
            }
        }

        public SmtProgramHistoryNewDAL() { }
        public List<ProgramLine>getProgramLine(string program)
        {
            return (from a in _entities.sp_SmtHistory_ByProgram(program)
                    select new ProgramLine
                    {
                        programlist = a.programpartlist,
                        line = a.remark1
                    }).ToList();
        }

        public int getCountByProgramAndLine(string program, string line)
        {
            //select COUNT(counts) as checkcount
            //from dbo.EASTECH_PROGRAMHISTORY A with(nolock)
            //where programpartlist = @programpartlist and remark1 = @remark1    and counts> 0
            return _entities.EASTECH_PROGRAMHISTORY.Where(p =>
                    p.programpartlist == program
                && p.remark1 == line
                && p.counts > 0
                ).Count();
        }
        public List<newProgram> getCombineNonQRProgram(string program1, string program2, string oldLine)
        {
            return (from a in _entities.sp_Smt_CombineProgramNonQRCode(program1,program2,oldLine)
                    select new  newProgram
                    {
                        row_num=(long) a.row_num,
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
                        Solanthaylinhkien=a.Solanthaylinhkien,
                        SoPCBCothedung=a.SoPCBCothedung,
                        remark1=a.remark1,
                        remark2=a.remark2,
                        remark3=a.remark3,
                        counts=(int)a.counts

                    }).ToList();
        }
        public List<ProgramQR> getCombineQRProgram(string program1, string program2, string oldLine)
        {
            return (from a in _entities.sp_Smt_CombineProgramQRCode(program1, program2, oldLine)
                    select new ProgramQR
                    {
                        Id = a.Id,
                        programpartlist = a.programpartlist,
                        fdrno = a.fdrno,
                        partscode = a.partscode,
                        ndesc = a.ndesc,
                        usage = (int)a.usage,
                        checkedby = a.checkedby,
                        checkedtime = a.checkedtime,
                        reqqty = a.reqqty,
                        datecode = a.datecode,
                        Solanthaylinhkien = a.Solanthaylinhkien,
                        SoPCBCothedung = a.SoPCBCothedung,
                        remark1 = a.remark1,
                        remark2 = a.remark2,
                        remark3 = a.remark3,
                        counts = (int)a.counts

                    }).ToList();
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

                throw;
            }
        }
        public void UpdateCombine(long Id, int reqqty, int Sopcb )
        {
            //Update EASTECH_PROGRAMHISTORY
            //SET
            //reqqty = @reqqty,
            //SoPCBCothedung = @SoPCBCothedung
            //where Id = @Id
            var oldHistory = _entities.EASTECH_PROGRAMHISTORY.Where(p => p.Id == Id).FirstOrDefault();
            if (oldHistory!=null)
            {
                try
                {
                    oldHistory.reqqty = reqqty;
                    oldHistory.SoPCBCothedung = Sopcb;
                    oldHistory.Id = Id;
                    _entities.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void Remove(long Id)
        {
            var del= new EASTECH_PROGRAMHISTORY();
            del=_entities.EASTECH_PROGRAMHISTORY.Where(p=>p.Id==Id ).FirstOrDefault();
            if (del!=null)
            {
                try
                {
                    _entities.EASTECH_PROGRAMHISTORY.Remove(del);
                    _entities.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }    
        public List<CombineData> CheckCombineLine(string program, string line)
        {
            //select programpartlist, fdrno, partscode, usage, Solanthaylinhkien, SoPCBCothedung, counts, remark2
            //from dbo.EASTECH_PROGRAMHISTORY
            //where programpartlist = @programpartlist and
            //remark1 = @remark1 and SoPCBCothedung > 0 and SoPCBCothedung-counts > 0
            //order by fdrno , Solanthaylinhkien
            return (from a in _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == program
            && p.remark1 == line
            && p.SoPCBCothedung > 0
            && (p.SoPCBCothedung - p.counts) > 0
            )
                    select new CombineData
                    {
                        programpartlist = a.programpartlist,
                        fdrno = a.fdrno,
                        partscode = a.partscode,    
                        usage=(int)a.usage,
                        Solanthaylinhkien=a.Solanthaylinhkien,
                        SoPCBCothedung=a.SoPCBCothedung,
                        counts=(int)a.counts,
                        remark2=a.remark2
                    }).ToList();       
        }

        public List<CutLotQtyFeeder> CheckCutLotQtyFeeder(string program, string newLine)
        {
            //select ID, fdrno, partscode, ndesc, reqqty, usage, Solanthaylinhkien, SoPCBCothedung, remark1
            //from dbo.EASTECH_PROGRAMHISTORY
            //where programpartlist = @programkey
            //and remark1 = @NewLine
            //and reqqty = 0
            //order by fdrno ,Solanthaylinhkien
            return (from a in _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == program
                    && p.remark1 == newLine
                    && p.reqqty == 0)
                    select new CutLotQtyFeeder
                    {
                        ID = a.Id,
                        fdrno = a.fdrno,
                        partscode = a.partscode,
                        ndesc = a.ndesc,
                        reqqty = a.reqqty,
                        usage = (int)a.usage,
                        Solanthaylinhkien = a.Solanthaylinhkien,
                        SoPCBCothedung = a.SoPCBCothedung,
                        remark1 = a.remark1
                    }).ToList();
        }
    }
}
