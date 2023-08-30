using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace UnidenDAL.AssyLine.MENU
{
	public class EASTECHHISTORY_DALL
	{
		UVEntities _entities = new UVEntities();
		private static EASTECHHISTORY_DALL instance;
		public static EASTECHHISTORY_DALL Instance
		{
			get
			{
				if (instance == null)
					instance = new EASTECHHISTORY_DALL();
				return instance;
			}
		}
		public EASTECHHISTORY_DALL() { }

		public string Add(UVASSY_EASTECHHISTORY history)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_EASTECHHISTORY.Add(history);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public UVASSY_EASTECHHISTORY checkSerialvsModel(string serial, string model)
		{
			return _entities.UVASSY_EASTECHHISTORY
				.Where(p=>p.Serial_Number == serial && p.Model==model)
				.FirstOrDefault();
		}
		public string Update( UVASSY_EASTECHHISTORY history)
		{
			string message = string.Empty;
			try
			{
				var update= _entities.UVASSY_EASTECHHISTORY
					.Where(p=>p.Serial_Number==history.Serial_Number && p.Model==history.Model)
					.FirstOrDefault();
				if (update!=null)
				{
					update.Lot = history.Lot;
					update.Type_Base = history.Type_Base;
					update.CreatedDate= history.CreatedDate;
					update.RepairCode= history.RepairCode;
					update.CreatedBy = history.CreatedBy;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public List<UVASSY_EASTECHHISTORY> getDataByUser(string user)
		{
			return _entities.UVASSY_EASTECHHISTORY
				.Where(p=>p.CreatedBy==user)
				.OrderByDescending(p=>p.CreatedDate)
				.ToList();
		}

		public List<UVASSY_EASTECHHISTORY> searchByModelvsDate(string search, DateTime from, DateTime to)
		{
			var query=_entities.UVASSY_EASTECHHISTORY.AsQueryable();
			if (!search.Contains("--Select--") )
			{
				query=query.Where(p=>p.Model==search);
				if (from<=to)
				{
					query = query.Where(p =>
					(p.CreatedDate.HasValue && p.CreatedDate.Value >= from) &&
						(p.CreatedDate.HasValue && p.CreatedDate.Value <= to)
					);
				}
			}

			return query.ToList();
		}

		public List<UVASSY_EASTECHHISTORY> searchByModel(string search)
		{
			var query = _entities.UVASSY_EASTECHHISTORY.AsQueryable();
			if (!search.Contains("--Select--"))
			{
				query = query.Where(p => p.Model == search);				
			}
			return query.ToList();
		}
	}
}
