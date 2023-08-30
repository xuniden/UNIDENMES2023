using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Assy.Setup
{
	public class GROUP_PROCESS_DAL
	{
		UVEntities _entities = new UVEntities();
		private static GROUP_PROCESS_DAL instance;
		public static GROUP_PROCESS_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new GROUP_PROCESS_DAL();
				return instance;
			}
		}
		public GROUP_PROCESS_DAL() { }
		public List<UV_GROUP_PROCESS> getListGroupProcess()
		{
			return _entities.UV_GROUP_PROCESS.OrderBy(p=>p.GroupName).ToList();
		}
	}
}
