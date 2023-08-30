using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Smt.DataControl;
using UnidenDTO;

namespace UnidenDAL.Smt.Repair
{
	public class SmtRepairErrorCode_DAL
	{
		UVEntities _entities = new UVEntities();
		private static SmtRepairErrorCode_DAL instance;
		public static SmtRepairErrorCode_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new SmtRepairErrorCode_DAL();
				return instance;
			}
		}

		public SmtRepairErrorCode_DAL() { }

		public List<Smt_Repair_Error_Code> getListErrorCodeByUserDept(string dept)
		{
			return _entities.Smt_Repair_Error_Code.Where(p=>p.Dept == dept).ToList();
		}

		public Smt_Repair_Error_Code getNoiDungLoiByKyHieu(string kyHieu, string dept)
		{
			return _entities.Smt_Repair_Error_Code.Where(p=>p.Ky_Hieu==kyHieu&&p.Dept==dept).FirstOrDefault();
		}
	}
}
