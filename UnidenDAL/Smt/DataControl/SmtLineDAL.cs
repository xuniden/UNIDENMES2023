using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
    public class SmtLineDAL
    {
        UVEntities _entities = new UVEntities();
        private static SmtLineDAL instance;
        public static SmtLineDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtLineDAL();
                return instance;
            }
        }

        public SmtLineDAL() { }
		#region Lấy danh sách các line của SMT
		public List<SMT_LINE>getListSMTLine()
        {
            return _entities.SMT_LINE.OrderBy(p=>p.LineName).ToList();
        }
		#endregion

		#region Kiểm tra tên line có trong csdl không?
		public SMT_LINE checkSMTLine(string lineName)
		{
			return _entities.SMT_LINE.Where(p => p.LineName == lineName).FirstOrDefault();
		}
		#endregion

		#region Lấy danh sách line SMT không chưa line Insert
		public List<SMT_LINE> getListSMTLineWithoutInsert()
        {
            return _entities.SMT_LINE.Where(p => !p.LineName.Substring(0,2).Contains("IN")).ToList();
        }
		#endregion

	}
}
