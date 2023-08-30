using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
    public class SmtProgramHistoryDAL
    {

        UVEntities _entities = new UVEntities();
        private static SmtProgramHistoryDAL instance;
        public static SmtProgramHistoryDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtProgramHistoryDAL();
                return instance;
            }
        }
       
        public SmtProgramHistoryDAL() { }
        public string Add(PROGRAMHISTORY proHistory)
        {
            string message = "";
            try
            {
                _entities.PROGRAMHISTORies.Add(proHistory);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;               
            }
            return message;
        }
        public List<PROGRAMHISTORY> getListByProgram(string program)
        {
            return _entities.PROGRAMHISTORies.Where(p => p.programpartlist.Contains(program)).ToList();
        }
        public List<PROGRAMHISTORY> getListByPartCode(string partcode)
        {
            return _entities.PROGRAMHISTORies.Where(p => p.partscode.Contains(partcode)).ToList();
        }
		#region Kiểm tra xem chương trình này có không?
		public PROGRAMHISTORY checkProgramName(string programName)
		{
			return _entities.PROGRAMHISTORies.Where(p => p.programpartlist == programName).FirstOrDefault();
		}
		#endregion
	}
}
