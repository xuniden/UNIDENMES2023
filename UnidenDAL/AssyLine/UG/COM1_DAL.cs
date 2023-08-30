using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.UG
{
	
	public class COM1_DAL
	{
		UVEntities _entities = new UVEntities();
		private static COM1_DAL instance;
		public static COM1_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new COM1_DAL();
				return instance;
			}
		}

		public COM1_DAL() { }

		public UVASSY_COM1 checkExistLot(string lot)
		{
			return _entities.UVASSY_COM1.Where(p=>p.Lot== lot).FirstOrDefault();
		}


		public List<groupLot> listLots()
		{
			var selectOption = new groupLot { Lot = "--Select--" };
			var result = _entities.UVASSY_COM1
				.GroupBy(e => new { e.Lot })
				.Select(g => new groupLot
				{
					Lot = g.Key.Lot
				})
				.ToList();
			result.Insert(0, selectOption);
			result = result.OrderBy(e => e.Lot).ToList();
			return result;
		}

		public string Add(UVASSY_COM1 com1 )
		{
			string message= string.Empty;
			try
			{
				_entities.UVASSY_COM1.Add(com1);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public UVASSY_COM1 checkDboxCom1(string dbox, string lot)
		{
			return _entities.UVASSY_COM1.Where(p=>p.Dbox_Serial == dbox && p.Lot==lot).FirstOrDefault();
		}
		public UVASSY_COM1 checkBCardCom1(string bcard, string lot)
		{
			return _entities.UVASSY_COM1.Where(p => p.Bcard_Serial == bcard && p.Lot == lot).FirstOrDefault();
		}
		public int countRecord()
		{
			return _entities.UVASSY_COM1.Count();
		}
		public int countRecordByUser(string createdBy)
		{
			return _entities.UVASSY_COM1.Where(p=>p.CreatedBy== createdBy).Count();
		}
		public List<UVASSY_COM1> GetDataByPage(int page, int recordsPerPage)
		{
			int startIndex = (page - 1) * recordsPerPage;			
			return _entities.UVASSY_COM1
					.OrderByDescending(p=>p.CreatedDate)					
					.Skip(startIndex)
					.Take(recordsPerPage)
					.ToList();
			
		}

		public List<UVASSY_COM1> GetDataByPageByUser(int page, int recordsPerPage,string createdBy)
		{
			int startIndex = (page - 1) * recordsPerPage;
			return _entities.UVASSY_COM1
					.Where(p=>p.CreatedBy== createdBy)
					.OrderByDescending(p => p.CreatedDate)
					.Skip(startIndex)
					.Take(recordsPerPage)
					.ToList();

		}
	}
}
