using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.Input
{
	public class PROGRAMHISTORY_DAL
	{
		UVEntities _entities = new UVEntities();
		private static PROGRAMHISTORY_DAL instance;
		public static PROGRAMHISTORY_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new PROGRAMHISTORY_DAL();
				return instance;
			}
		}
		public PROGRAMHISTORY_DAL() { }

		public string Add(PROGRAMHISTORY history) 
		{
			string message = "";
			try
			{
				_entities.PROGRAMHISTORies.Add(history);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
	}
}
