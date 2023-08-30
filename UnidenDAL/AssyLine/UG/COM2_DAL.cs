using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.UG
{
	public class COM2_DAL
	{
		UVEntities _entities = new UVEntities();
		private static COM2_DAL instance;
		public static COM2_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new COM2_DAL();
				return instance;
			}
		}
		public COM2_DAL() { }
		
		public string Update(UVASSY_COM2 com2)
		{
			string message=string.Empty;
			try
			{
				var update = _entities.UVASSY_COM2.Where(p => p.Lot == com2.Lot && p.BatchNo == com2.BatchNo).FirstOrDefault();
				if (update != null)
				{
					update.ErrorDetail = com2.ErrorDetail;
					update.ErrorStatus= com2.ErrorStatus;
					update.ChangeBatchTo= com2.ChangeBatchTo;
					update.CreatedDate= com2.CreatedDate;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public string Add(UVASSY_COM2 com2)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_COM2.Add(com2);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public string AddRange(List<UVASSY_COM2> com2s)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_COM2.AddRange(com2s);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public UVASSY_COM2 checkDboxCom2(string dbox, string lot)
		{
			return _entities.UVASSY_COM2.Where(p => p.Dbox_No == dbox && p.Lot == lot).FirstOrDefault();
		}
		public List<UVASSY_COM2> GetAllByUser(string user, string lot)
		{
			return _entities.UVASSY_COM2
				.Where(p => p.Lot == lot && p.CreatedBy == user)
				.OrderByDescending(p => p.CreatedDate)
				.ToList();
		}

		public int getMaxCTN(string Line, string Lot, string remark1)
		{
			int maxCTN = 0;
			var result = _entities.UVASSY_COM2
				.Where(p => p.Line == Line && p.Lot == Lot && p.Remark1 == remark1)
				.OrderByDescending(p => p.Ctn_No)
				.FirstOrDefault();
			if (result != null)
			{
				maxCTN = result.Ctn_No;
			}
			return maxCTN;
		}	

		public UVASSY_COM2 getBatchNumber(string line, string lot , int ctnNo, string remark1)
		{
			return _entities.UVASSY_COM2
				.Where(p => p.Line == line && p.Lot == lot && p.Remark1 == remark1 && p.Ctn_No == ctnNo)
				.FirstOrDefault();
		}

		public UVASSY_COM2 checkExistCartonByLot(string lot, int ctnNo)
		{
			return _entities.UVASSY_COM2
				.Where(p=>p.Lot==lot && p.Ctn_No==ctnNo)
				.FirstOrDefault();
		}

		public UVASSY_COM2 checkExistBatchByLot(string lot, string batch)
		{
			return _entities.UVASSY_COM2
				.Where(p => p.Lot == lot && p.BatchNo == batch)
				.FirstOrDefault();
		}

		public UVASSY_COM2 checkCombine(string batch, int ctnNo, string lot, string rework)
		{
			return _entities.UVASSY_COM2
				.Where(p=>p.BatchNo==batch && p.Lot==lot && p.Ctn_No==ctnNo && p.Remark1==rework)
				.FirstOrDefault();

		}

		public UVASSY_COM2 checkExistLot(string lot)
		{
			return _entities.UVASSY_COM2
				.Where(p=>p.Lot==lot)
				.FirstOrDefault();
		}

		public List<UVASSY_COM2> SearchData(string lot, DateTime from, DateTime to)
		{
			var query = _entities.UVASSY_COM2.AsQueryable();

			if (!string.IsNullOrEmpty(lot))
			{
				query = query.Where(p => p.Lot == lot);

				if (from <= to)
				{
					query = query.Where(p =>
						(p.CreatedDate.HasValue && p.CreatedDate.Value >= from) &&
						(p.CreatedDate.HasValue && p.CreatedDate.Value <= to)
					);
				}
			}
			else if (from <= to)
			{
				query = query.Where(p =>
					(p.CreatedDate.HasValue && p.CreatedDate.Value >= from) &&
					(p.CreatedDate.HasValue && p.CreatedDate.Value <= to)
				);
			}

			return query.ToList();
		}
	}
}
