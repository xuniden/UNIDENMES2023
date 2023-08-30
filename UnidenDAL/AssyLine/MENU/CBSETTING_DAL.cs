using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine
{    
    public class CBSETTING_DAL
    {

        UVEntities _entities = new UVEntities();
        private static CBSETTING_DAL instance;
        public static CBSETTING_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CBSETTING_DAL();
                return instance;
            }
        }

        public CBSETTING_DAL() { }


		public List<groupLot> listLots()
		{
			var selectOption = new groupLot { Lot = "--Select--" };
			var result = _entities.UVASSY_CBSETTING
				.GroupBy(e => new { e.LOT })
				.Select(g => new groupLot
				{
					Lot = g.Key.LOT
				})
				.ToList();
			result.Insert(0, selectOption);
			result = result.OrderBy(e => e.Lot).ToList();
			return result;
		}

		public int searchCount(string search)
        {
			return _entities.UVASSY_CBSETTING
			.Where(p => p.LOT.Contains(search) || p.MODEL.Contains(search))
            .Count();

		}
        public List<UVASSY_CBSETTING>getListBySearchCondition(string search, int page, int pageSize)
        {
			int startIndex = (page - 1) * pageSize;
			return _entities.UVASSY_CBSETTING
                .Where(p => p.LOT.Contains(search) || p.MODEL.Contains(search))
                .OrderBy(p => p.LOT)
                .Skip(startIndex)
                .Take(pageSize)
                .ToList();
        }

		public List<UVASSY_CBSETTING> LoadData(int page, int pageSize)
		{
			int startIndex = (page - 1) * pageSize;
			return _entities.UVASSY_CBSETTING				
				.OrderByDescending(p => p.CreatedDate)
				.Skip(startIndex)
				.Take(pageSize)
				.ToList();
		}
		public UVASSY_CBSETTING getInfoByLot(string lot)
        {
            return _entities.UVASSY_CBSETTING.Where(p => p.LOT == lot).FirstOrDefault();
        }
        public string Add(UVASSY_CBSETTING cbSetting)
        { 
            string message= string.Empty;
            try
            {
                _entities.UVASSY_CBSETTING.Add(cbSetting);
                _entities.SaveChanges();                
            }
            catch (Exception ex)
            {
                message=ex.Message;
            }
            return message;
        }
        public string Update(UVASSY_CBSETTING cbSetting)
        {
            string message= string.Empty;
            var cbUpdate = _entities.UVASSY_CBSETTING.Where(p => p.LOT == cbSetting.LOT).FirstOrDefault();
            if (cbUpdate != null)
            {
                try
                {
                    cbUpdate.MODEL = cbSetting.MODEL;                                        
                    cbUpdate.LOTSIZE = cbSetting.LOTSIZE;
                    cbUpdate.DBOX_CARTON = cbSetting.DBOX_CARTON;
                    cbUpdate.UNIT_DBOX=cbSetting.UNIT_DBOX;
                    cbUpdate.CHECK_TYPE = cbSetting.CHECK_TYPE;
                    cbUpdate.DBOX_SERIAL=cbSetting.DBOX_SERIAL; ;
                    cbUpdate.MODEL_SERIAL=cbSetting.MODEL_SERIAL; 
                    _entities.SaveChanges();                    
                }
                catch (Exception ex)
                {
                    message=ex.Message;
                }
            }
            return message;
        }
        public List<UVASSY_CBSETTING> getList()
        {
            return _entities.UVASSY_CBSETTING.ToList();
        }
        public string Delete(UVASSY_CBSETTING cbSetting)
        {
            string message = string.Empty;
            try
            {
                _entities.UVASSY_CBSETTING.Remove(cbSetting);
                _entities.SaveChanges();              
            }
            catch (Exception ex)
            {
                message = ex.Message;     
            }
            return message;
        }
    }
}
