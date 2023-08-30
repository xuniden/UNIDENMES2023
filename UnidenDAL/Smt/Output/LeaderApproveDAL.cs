using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.Output
{
    public class LeaderApproveDAL
    {
        UVEntities _entities = new UVEntities();
        private static LeaderApproveDAL instance;
        public static LeaderApproveDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LeaderApproveDAL();
                return instance;
            }
        }
        public LeaderApproveDAL() { }

       public bool Add(EASTECH_ERROR_APPROVE approveError)
        {
            try
            {
                _entities.EASTECH_ERROR_APPROVE.Add(approveError);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update(EASTECH_ERROR_APPROVE approveError)
        {
            var uapprove= _entities.EASTECH_ERROR_APPROVE.Where(p=>p.StaffID==approveError.StaffID).FirstOrDefault();
            if (uapprove != null)
            {
                try
                {
                    uapprove.StaffName = approveError.StaffName;
                    uapprove.ActiveStatus = approveError.ActiveStatus;
                    _entities.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Remove(string staffId)
        {
            var uapprove = _entities.EASTECH_ERROR_APPROVE.Where(p => p.StaffID == staffId).FirstOrDefault();
            if (uapprove != null)
            {
                try
                {                   
                    uapprove.ActiveStatus = false;
                    _entities.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<EASTECH_ERROR_APPROVE> getListAll()
        {
            return _entities.EASTECH_ERROR_APPROVE.OrderBy(p=>p.CreatedDate).ToList();
        }
        public List<EASTECH_ERROR_APPROVE> getListAllBySearch(string search)
        {
            return _entities.EASTECH_ERROR_APPROVE.Where(p=>p.StaffID.Contains(search)|| p.StaffID.Contains(search)).ToList();
        }
        public List<EASTECH_ERROR_APPROVE> getByStaffID(string staffId)
        {
            return _entities.EASTECH_ERROR_APPROVE.Where(p => p.StaffID==staffId).ToList();
        }

        public EASTECH_ERROR_APPROVE checkApproveStaffID(string staffId)
        {
            return _entities.EASTECH_ERROR_APPROVE.Where(p=>p.StaffID==staffId && p.ActiveStatus==false).FirstOrDefault();
        }
    }
}
