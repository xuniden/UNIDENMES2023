using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.OutsourceBom
{
    public class OUTSOURCE_UVLotVsETOrderDAL
    {

        UVEntities _entities = new UVEntities();
        private static OUTSOURCE_UVLotVsETOrderDAL instance;
        public static OUTSOURCE_UVLotVsETOrderDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OUTSOURCE_UVLotVsETOrderDAL();
                return instance;
            }
        }
        public OUTSOURCE_UVLotVsETOrderDAL() { }
        public List<OUTSOURCE_UVLotVsETOrder> getListLotOrderNo(string search)
        {
            if (search.Equals(""))
            {
                return _entities.OUTSOURCE_UVLotVsETOrder.Take(10000).ToList();
            }
            else
            {
                return _entities.OUTSOURCE_UVLotVsETOrder.Where(
                p => p.Lot.Contains(search)
                || p.MaterialCode.EndsWith(search)).ToList();
            }
            
        }
        public bool CheckExistLot(string Lot)
        {
            var lst= _entities.OUTSOURCE_UVLotVsETOrder.Where(x => x.Lot == Lot).ToList();
            if (lst.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(OUTSOURCE_UVLotVsETOrder smt)
        {
            try
            {
                _entities.OUTSOURCE_UVLotVsETOrder.Add(smt);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<OUTSOURCE_UVLotVsETOrder> getAll()
        {
            return _entities.OUTSOURCE_UVLotVsETOrder.ToList();
        }
        public bool DeleteAll()
        {
            try
            {
                _entities.OutSource_Delete_UVETLot();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteAll(List<OUTSOURCE_UVLotVsETOrder> lst)
        {
            try
            {
                _entities.OUTSOURCE_UVLotVsETOrder.RemoveRange(lst);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
