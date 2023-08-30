using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.AssyLine.REPAIR;
using UnidenDAL.Smt.Input;
using UnidenDAL.Smt.Output;
using UnidenDTO;

namespace UnidenDAL.AssyLine
{
	public class groupLot
	{
		public string Lot { get; set; }
	}
	public class MODEL_DAL
	{
		UVEntities _entities = new UVEntities();
		private static MODEL_DAL instance;
		public static MODEL_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new MODEL_DAL();
				return instance;
			}
		}
		public MODEL_DAL() { }

		public List<groupLot> listLots()
		{
			try
			{
				var selectOption = new groupLot { Lot = "--Select--" };
				var result = _entities.UVASSY_MODEL
					.GroupBy(e => new { e.Lot })
					.Select(g => new groupLot
					{
						Lot = g.Key.Lot
					})
					.ToList();
				result.Insert(0, selectOption);
				var re = result.OrderBy(e => e.Lot).ToList();
				return re;
			}
			catch (Exception ex) 
			{
				Console.WriteLine("An error occurred: " + ex.Message);
				return new List<groupLot>();
			}
			
		}

		public UVASSY_MODEL getModelByLot(string lot)
		{
			return _entities.UVASSY_MODEL.Where(p=>p.Lot == lot).FirstOrDefault();
		}

		public List<UVASSY_MODEL> searchData(string searchCondition)
		{
			return _entities.UVASSY_MODEL.Where(p=>p.Lot.Contains(searchCondition) || p.Model.Contains(searchCondition)).ToList();
		}

		public string AddRange(List<UVASSY_MODEL> models)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_MODEL.AddRange(models);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Add(UVASSY_MODEL mODEL)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_MODEL.Add(mODEL);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public string Update(UVASSY_MODEL mODEL)
		{
			string message = string.Empty;
			try
			{
				var updata=_entities.UVASSY_MODEL.Where(p=>p.Lot==mODEL.Lot).FirstOrDefault();
				if (updata!=null)
				{
					updata.Model = mODEL.Model;
					updata.UpdateBy=mODEL.UpdateBy;
					updata.UpdatedDate = mODEL.UpdatedDate;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;	
		}
		public UVASSY_MODEL checkExistLot(string lot)
		{
			return _entities.UVASSY_MODEL.Where(p=>p.Lot.Equals(lot)).FirstOrDefault();
		}

		public List<UVASSY_MODEL> getListModelLot()
		{
			return _entities.UVASSY_MODEL.OrderByDescending(p=>p.CreatedDate).ToList();
		}
		public List<UVASSY_MODEL> getListModelLotUpdate()
		{
			return _entities.UVASSY_MODEL.OrderByDescending(p => p.UpdatedDate).ToList();
		}
	}
}
