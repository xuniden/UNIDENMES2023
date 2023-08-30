using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.MENU
{
	public class COM21_DAL
	{
		UVEntities _entities = new UVEntities();
		private static COM21_DAL instance;
		public static COM21_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new COM21_DAL();
				return instance;
			}
		}
		public COM21_DAL() { }

		public string Add(UVASSY_COM21 com21)
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_COM21.Add(com21);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message= ex.Message;
			}
			return message;
		}

		public List<UVASSY_COM21> GetAllByUser(string user, string lot)
		{
			return _entities.UVASSY_COM21.Where(p=>p.Lot==lot && p.CreatedBy==user)
				.OrderByDescending(p=>p.CreatedDate)
				.ToList();
		}
	}
}
