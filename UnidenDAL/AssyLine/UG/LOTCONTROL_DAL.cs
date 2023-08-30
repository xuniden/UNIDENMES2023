using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine
{
	public class LOTCONTROL_DAL
	{
		UVEntities _entities = new UVEntities();
		private static LOTCONTROL_DAL instance;
		public static LOTCONTROL_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new LOTCONTROL_DAL();
				return instance;
			}
		}

		public LOTCONTROL_DAL() { }

		public string Add(UVASSY_LOTCONTROL lOTCONTROL)
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_LOTCONTROL.Add(lOTCONTROL);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string AddRange(List<UVASSY_LOTCONTROL> lstLotControls)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_LOTCONTROL.AddRange(lstLotControls);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Update(UVASSY_LOTCONTROL lOTCONTROL) 
		{ 
			string message= string.Empty;
			try
			{
				var update=_entities.UVASSY_LOTCONTROL.Where(p=>p.LotID==lOTCONTROL.LotID).FirstOrDefault();
				if (update!=null)
				{
					update.Lotsize=lOTCONTROL.Lotsize;
					update.UnitCtn=lOTCONTROL.UnitCtn;
					update.Start_Number=lOTCONTROL.Start_Number;
					update.End_Number	=lOTCONTROL.End_Number;
					update.Dbox_Barcode = lOTCONTROL.Dbox_Barcode;
					update.Carton_Barcode = lOTCONTROL.Carton_Barcode;
					update.UpdatedBy=lOTCONTROL.UpdatedBy;
					update.UpdatedDate=lOTCONTROL.UpdatedDate;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;	
			}
			return message;
		}
		public UVASSY_LOTCONTROL checkExistLot(string lot)
		{
			return _entities.UVASSY_LOTCONTROL.Where(p => p.Lot.Equals(lot)).FirstOrDefault();
		}

		public List<UVASSY_LOTCONTROL> getListLotControl()
		{
			return _entities.UVASSY_LOTCONTROL.OrderByDescending(p=>p.CreatedDate).ToList();
		}

		public List<UVASSY_LOTCONTROL> getListLotControlByUpdateDate()
		{
			return _entities.UVASSY_LOTCONTROL.OrderByDescending(p => p.UpdatedDate).ToList();
		}

		public List<UVASSY_LOTCONTROL> searchData(string search)
		{
			return _entities.UVASSY_LOTCONTROL.Where(p=>p.Lot.Contains(search) ||
			p.Model.Contains(search)||
			p.Start_Number.Equals(search)||
			p.End_Number.Equals(search)||
			p.Dbox_Barcode.Contains(search)||
			p.Carton_Barcode.Contains(search)).ToList();	
		}

		public List<groupLot> listLots()
		{
			var selectOption = new groupLot { Lot = "--Select--" };
			var result = _entities.UVASSY_LOTCONTROL
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
	}
}
