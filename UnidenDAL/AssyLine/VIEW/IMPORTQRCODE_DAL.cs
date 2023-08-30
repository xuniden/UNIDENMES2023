using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.AssyLine.UG;
using UnidenDTO;

namespace UnidenDAL.AssyLine.VIEW
{
	public class IMPORTQRCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static IMPORTQRCODE_DAL instance;
		public static IMPORTQRCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new IMPORTQRCODE_DAL();
				return instance;
			}
		}
		public IMPORTQRCODE_DAL() { }

		public string AddRange(List<UVASSY_IMPORTQRCODE> list)
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_IMPORTQRCODE.AddRange(list);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message= ex.Message;	
			}

			return message;
		}

		public UVASSY_IMPORTQRCODE checkModel(string model)
		{
			return _entities.UVASSY_IMPORTQRCODE
				.Where(p=>p.Market==model)
				.FirstOrDefault();
		}
	}
}
