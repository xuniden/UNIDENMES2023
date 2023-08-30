using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Whs
{
    public class WHSIqcInputReturnResultDAL
    {
        UVEntities _entities = new UVEntities();
        private static WHSIqcInputReturnResultDAL instance;
        public static WHSIqcInputReturnResultDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new WHSIqcInputReturnResultDAL();
                return instance;
            }
        }
        public WHSIqcInputReturnResultDAL() { }
        public List<WHS_IQC_INPUT_RETURN_RESULT> getListAll()
        {
            return _entities.WHS_IQC_INPUT_RETURN_RESULT.OrderByDescending(p => p.CreatedDate).ToList();
        }

        public List<WHS_IQC_INPUT_RETURN_RESULT> getListSearch(string search)
        {
            return _entities.WHS_IQC_INPUT_RETURN_RESULT.Where(
                p => p.ID.Contains(search)                
                || p.PARTCODE.Contains(search)).ToList();
        }
        public bool CheckExistID(string ID)
        {
            var lst = new List<WHS_IQC_INPUT_RETURN_RESULT>();
            lst = _entities.WHS_IQC_INPUT_RETURN_RESULT.Where(p => p.ID == ID).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add(WHS_IQC_INPUT_RETURN_RESULT input)
        {
            try
            {
                _entities.WHS_IQC_INPUT_RETURN_RESULT.Add(input);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Update(WHS_IQC_INPUT_RETURN_RESULT updateById)
        {
            try
            {
                var updateMonitor = new WHS_IQC_INPUT_RETURN_RESULT();
                updateMonitor = _entities.WHS_IQC_INPUT_RETURN_RESULT.Where(p => p.ID == updateById.ID).FirstOrDefault();
                if (updateMonitor != null)
                {
                    updateMonitor.ID = updateById.ID;                   
                    updateMonitor.PARTCODE = updateById.PARTCODE;
                    updateMonitor.IQCRESULT = updateById.IQCRESULT;
                    updateMonitor.CHECKEDDATE = updateById.CHECKEDDATE;
                    updateMonitor.RETURNDDATE = updateById.RETURNDDATE;                

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
                var updateMonitor = new WHS_IQC_INPUT_RETURN_RESULT();
                updateMonitor = _entities.WHS_IQC_INPUT_RETURN_RESULT.Where(p => p.ID == ID).FirstOrDefault();
                if (updateMonitor != null)
                {
                    _entities.WHS_IQC_INPUT_RETURN_RESULT.Remove(updateMonitor);
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
