using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Whs
{
    public class WHSMonitorFedexDhlOtherDAL
    {
        UVEntities _entities = new UVEntities();
        private static WHSMonitorFedexDhlOtherDAL instance;
        public static WHSMonitorFedexDhlOtherDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new WHSMonitorFedexDhlOtherDAL();
                return instance;
            }
        }
        public WHSMonitorFedexDhlOtherDAL() { }
        public bool CheckExistID(string ID)
        {
            var lst = new List<WHS_MONITOR_FEDEX_DHL_OTHER>();
            lst = _entities.WHS_MONITOR_FEDEX_DHL_OTHER.Where(p => p.ID == ID).ToList();
            if (lst.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<WHS_MONITOR_FEDEX_DHL_OTHER> getListAll()
        {
            return _entities.WHS_MONITOR_FEDEX_DHL_OTHER.OrderByDescending(p => p.CreatedDate).ToList();
        }

        public List<WHS_MONITOR_FEDEX_DHL_OTHER> getListSearch( string search)
        {
            return _entities.WHS_MONITOR_FEDEX_DHL_OTHER.Where(                
                p=>p.ID.Contains(search)
                || p.SK_INVOICE.Contains(search)
                || p.INVOICE_NAME.Contains(search)
                || p.SUPPLIER_NAME.Contains(search)
                ).OrderByDescending(p => p.CreatedDate).ToList();
        }

        public bool Add(WHS_MONITOR_FEDEX_DHL_OTHER input)
        {
            try
            {
                _entities.WHS_MONITOR_FEDEX_DHL_OTHER.Add(input);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Update(WHS_MONITOR_FEDEX_DHL_OTHER updateById)
        {
            try
            {
                var updateMonitor=new WHS_MONITOR_FEDEX_DHL_OTHER();
                updateMonitor = _entities.WHS_MONITOR_FEDEX_DHL_OTHER.Where(p => p.ID == updateById.ID).FirstOrDefault();
                if (updateMonitor != null)
                {
                    updateMonitor.ID = updateById.ID;
                    updateMonitor.FWR_TYPE = updateById.FWR_TYPE;
                    updateMonitor.DATE = updateById.DATE;
                    updateMonitor.SK_INVOICE = updateById.SK_INVOICE;
                    updateMonitor.INVOICE_NAME = updateById.INVOICE_NAME;
                    updateMonitor.SUPPLIER_NAME = updateById.SUPPLIER_NAME;
                    updateMonitor.CTN = updateById.CTN;
                    updateMonitor.REMARK = updateById.REMARK;
                    updateMonitor.REMARK2 = updateById.REMARK2;
                    updateMonitor.CreatedBy = updateById.CreatedBy;
                    updateMonitor.UpdatedDate = updateById.UpdatedDate;                    
                    _entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                    
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Remove(string ID)
        {
            try
            {
                var updateMonitor = new WHS_MONITOR_FEDEX_DHL_OTHER();
                updateMonitor = _entities.WHS_MONITOR_FEDEX_DHL_OTHER.Where(p => p.ID == ID).FirstOrDefault();
                if (updateMonitor!=null)
                {
                    _entities.WHS_MONITOR_FEDEX_DHL_OTHER.Remove(updateMonitor);
                    _entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
