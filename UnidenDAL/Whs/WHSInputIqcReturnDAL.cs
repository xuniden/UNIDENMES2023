using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.whs;
using UnidenDTO;

namespace UnidenDAL.Whs
{
    public class WHSInputIqcReturnDAL
    {
        UVEntities _entities = new UVEntities();
        private static WHSInputIqcReturnDAL instance;
        public static WHSInputIqcReturnDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new WHSInputIqcReturnDAL();
                return instance;
            }
        }
        public WHSInputIqcReturnDAL() { }
        public List<WHS_INPUT_IQC_RETURN> getListAll()
        {
            return _entities.WHS_INPUT_IQC_RETURN.OrderByDescending(p => p.CreatedDate).ToList();
        }

        public List<WHS_INPUT_IQC_RETURN>  getListSearch(string search)
        {
            return _entities.WHS_INPUT_IQC_RETURN.Where(
                p => p.ID.Contains(search)
                || p.SUPPILER.Contains(search)
                || p.LYDOTHUHOI.Contains(search)
                || p.PARTCODE.Contains(search)).ToList();
        }
        public bool CheckExistID(string ID)
        {
            var lst = new List<WHS_INPUT_IQC_RETURN>();
            lst = _entities.WHS_INPUT_IQC_RETURN.Where(p => p.ID == ID).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add(WHS_INPUT_IQC_RETURN input)
        {
            try
            {
                _entities.WHS_INPUT_IQC_RETURN.Add(input);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Update(WHS_INPUT_IQC_RETURN updateById)
        {
            try
            {
                var updateMonitor = new WHS_INPUT_IQC_RETURN();
                updateMonitor = _entities.WHS_INPUT_IQC_RETURN.Where(p => p.ID == updateById.ID).FirstOrDefault();
                if (updateMonitor != null)
                {
                    updateMonitor.ID = updateById.ID;
                    updateMonitor.NGAYTHUHOI = updateById.NGAYTHUHOI;
                    updateMonitor.SUPPILER = updateById.SUPPILER;
                    updateMonitor.QTY = updateById.QTY;
                    updateMonitor.LYDOTHUHOI = updateById.LYDOTHUHOI;
                    updateMonitor.NGUOITHUHOI = updateById.NGUOITHUHOI;
                    updateMonitor.PARTCODE = updateById.PARTCODE;
                  
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
                var updateMonitor = new WHS_INPUT_IQC_RETURN();
                updateMonitor = _entities.WHS_INPUT_IQC_RETURN.Where(p => p.ID == ID).FirstOrDefault();
                if (updateMonitor != null)
                {
                    _entities.WHS_INPUT_IQC_RETURN.Remove(updateMonitor);
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

