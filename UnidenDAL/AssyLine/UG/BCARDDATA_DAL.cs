using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.UG
{
	
	public class BCARDDATA_DAL
	{
		UVEntities _entities = new UVEntities();
		private static BCARDDATA_DAL instance;
		public static BCARDDATA_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new BCARDDATA_DAL();
				return instance;
			}
		}
		public BCARDDATA_DAL() { }		
		public string AddRange(List<UVASSY_BCARDDATA> datas)
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_BCARDDATA.AddRange(datas);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public UVASSY_BCARDDATA checkBCardData(string bcard15)
		{
			return _entities.UVASSY_BCARDDATA.Where(p=>p.BCard15 == bcard15).FirstOrDefault();
		}

		public List<UVASSY_BCARDDATA> getListBcard()
		{
			return _entities.UVASSY_BCARDDATA
				.OrderByDescending(p=>p.ImportDate)
				.Take(500)
				.ToList();
		}
	}
}
