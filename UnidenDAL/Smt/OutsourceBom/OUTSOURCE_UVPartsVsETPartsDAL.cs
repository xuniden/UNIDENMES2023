using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.OutsourceBom
{
    public class OUTSOURCE_UVPartsVsETPartsDAL
    {
        UVEntities _entities = new UVEntities();
        public static OUTSOURCE_UVPartsVsETPartsDAL instance;
        public static OUTSOURCE_UVPartsVsETPartsDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OUTSOURCE_UVPartsVsETPartsDAL();
                return instance;
            }
        }
        public OUTSOURCE_UVPartsVsETPartsDAL() { }

        public OUTSOURCE_UVPartsVsETParts UVPartToETPart(string uvpart)
        {
           return _entities.OUTSOURCE_UVPartsVsETParts.Where(p=>p.Name == uvpart).FirstOrDefault();
        }
        public List<OUTSOURCE_UVPartsVsETParts> getPart(string partcode)
        {
            if (partcode.Equals(""))
            {
               return _entities.OUTSOURCE_UVPartsVsETParts.Take(10000).ToList();
            }
            else
            {
              return  _entities.OUTSOURCE_UVPartsVsETParts.Where(p => p.Name.Contains(partcode)
            || p.ETParts.Contains(partcode)).ToList();
            }
        }
        public bool checkPartExist(string partcode)
        {
            var lst = _entities.OUTSOURCE_UVPartsVsETParts.Where(p => p.Name == partcode).ToList();
            if (lst.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(OUTSOURCE_UVPartsVsETParts smt)
        {
            try
            {
                _entities.OUTSOURCE_UVPartsVsETParts.Add(smt);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<OUTSOURCE_UVPartsVsETParts> getAll()
        {
            return _entities.OUTSOURCE_UVPartsVsETParts.ToList();
        }


        public bool DeleteAll()
        {
            try
            {
                _entities.OutSource_Delete_UVETParts();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteAll(List<OUTSOURCE_UVPartsVsETParts> lst)
        {
            try
            {
                _entities.OUTSOURCE_UVPartsVsETParts.RemoveRange(lst);
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
