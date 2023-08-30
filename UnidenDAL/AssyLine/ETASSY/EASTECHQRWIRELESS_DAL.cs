using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.ETASSY
{
	public class EASTECHQRWIRELESS_DAL
	{
		UVEntities _entities = new UVEntities();
		private static EASTECHQRWIRELESS_DAL instance;
		public static EASTECHQRWIRELESS_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new EASTECHQRWIRELESS_DAL();
				return instance;
			}
		}

		public EASTECHQRWIRELESS_DAL() { }
		
		public string Add(UVASSY_EASTECHQRWIRELESS wirelessQr)
		{
			string message=string.Empty; 
			try
			{
				_entities.UVASSY_EASTECHQRWIRELESS.Add(wirelessQr);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string AddRange(List<UVASSY_EASTECHQRWIRELESS> wirelessQrs)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_EASTECHQRWIRELESS.AddRange(wirelessQrs);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public List<UVASSY_EASTECHQRWIRELESS> getListWirelessQRData()
		{
			return _entities.UVASSY_EASTECHQRWIRELESS
				.OrderByDescending(p=>p.CreatedDate)				
				.ToList();
		}

		public int getTotalRecords()
		{
			return _entities.UVASSY_EASTECHQRWIRELESS.Count();
		}

		public List<UVASSY_EASTECHQRWIRELESS> searchData(string search)
		{
			return _entities.UVASSY_EASTECHQRWIRELESS
				.Where(p=>p.Model.Contains(search)
						|| p.Partcode.Contains(search)
						|| p.QRWireless.Contains(search))
				.ToList();
		}
	}
}
