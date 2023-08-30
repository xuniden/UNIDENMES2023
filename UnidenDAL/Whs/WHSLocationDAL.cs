using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.whs
{
    public class WHSLocationDAL
    {
        UVEntities _entities = new UVEntities();
        private static WHSLocationDAL instance;
        public static WHSLocationDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new WHSLocationDAL();
                return instance;
            }
        }
        public WHSLocationDAL() { }
        public List<WHS_LOCATION> getAllInput(string search)
        {
            return _entities.WHS_LOCATION.Where(
                p => p.LocationCode.Contains(search)
                || p.Partcode.Contains(search)
                || p.Position.Contains(search)
                || p.Groups.Contains(search)
                || p.KeyPerson.Contains(search)
                || p.Remark.Contains(search)
                ).Take(1000).ToList();
        }
        public WHS_LOCATION getKeyPersonByPartcode(string partcode)
        {
            return _entities.WHS_LOCATION.Where(p => p.Partcode == partcode).FirstOrDefault();
        }
        public List<WHS_LOCATION> getAllInput()
        {
            return _entities.WHS_LOCATION.OrderByDescending(p => p.CreatedDate).Take(5000).ToList();
        }
        public bool CheckExistID(string locationCode)
        {
            var lst = _entities.WHS_LOCATION.Where(x => x.LocationCode == locationCode).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(WHS_LOCATION inputData)
        {
            try
            {
                _entities.WHS_LOCATION.Add(inputData);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(WHS_LOCATION inputData)
        {

            var _inputData = _entities.WHS_LOCATION.Where(p => p.LocationCode == inputData.LocationCode).FirstOrDefault();
            if (_inputData != null)
            {
                try
                {
                    _inputData.LocationCode = inputData.LocationCode;
                    _inputData.Partcode = inputData.Partcode;
                    _inputData.Position = inputData.Position;
                    _inputData.Groups = inputData.Groups;
                    _inputData.KeyPerson = inputData.KeyPerson;
                    _inputData.Remark = inputData.Remark;
                    _inputData.UpdatedDate = inputData.UpdatedDate;
                    _inputData.CreatedBy = inputData.CreatedBy;
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
    }
}
