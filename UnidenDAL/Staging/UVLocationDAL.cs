using System;
using System.Collections.Generic;
using System.Linq;
using UnidenDTO;

namespace UnidenDAL.Staging
{
    public class getLocation
    {
        public long ID { get; set; }
        public string Loc { get; set; }
    }
    public class Location
    {
        public long ID { get; set; }
        public string Loc { get; set; }
        public string LocName { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class UVLocationDAL
    {
        UVEntities _entities = new UVEntities();
        private static UVLocationDAL instance;
        public static UVLocationDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UVLocationDAL();
                return instance;
            }
        }
        public UVLocationDAL() { }

        public UV_STAGING_LOCATION getByLocationByID(long ID)
        {
            return _entities.UV_STAGING_LOCATION.Where(p => p.ID == ID).FirstOrDefault();

        }
        public List<getLocation> getByLocation(string location)
        {
            return (from a in _entities.UV_STAGING_LOCATION.Where(p => p.LocRemark == location)
                    select new getLocation
                    {
                        ID = a.ID,
                        Loc = a.Loc
                    })
                   .ToList();
        }
        public List<Location> getAllLocation()
        {
            return (from a in _entities.UV_STAGING_LOCATION
                    select new Location
                    {
                        ID = a.ID,
                        Loc = a.Loc,
                        LocName = a.LocName,
                        Remark = a.LocRemark,
                        CreatedDate = a.CreatedDate
                    }).ToList();
        }
        public List<Location> getAllLocation(string search)
        {
            return (from a in _entities.UV_STAGING_LOCATION.Where(p => p.Loc.Contains(search)
                    || p.LocName.Contains(search)
                    || p.LocRemark.Contains(search))
                    select new Location
                    {
                        ID = a.ID,
                        Loc = a.Loc,
                        LocName = a.LocName,
                        Remark = a.LocRemark,
                        CreatedDate = a.CreatedDate
                    }).ToList();
        }
        public bool Remove(long Id)
        {
            var loc = new UV_STAGING_LOCATION();
            loc = _entities.UV_STAGING_LOCATION.Where(p => p.ID == Id).FirstOrDefault();
            if (loc != null)
            {
                _entities.UV_STAGING_LOCATION.Remove(loc);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Add(UV_STAGING_LOCATION location)
        {
            try
            {
                _entities.UV_STAGING_LOCATION.Add(location);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(UV_STAGING_LOCATION location)
        {

            var _loc = _entities.UV_STAGING_LOCATION.Where(p => p.ID == location.ID).FirstOrDefault();
            if (_loc != null)
            {
                try
                {
                    _loc.Loc = location.Loc;
                    _loc.ID = location.ID;
                    _loc.LocName = location.LocName;
                    _loc.CreatedDate = location.CreatedDate;
                    _loc.LocRemark = location.LocRemark;
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
        public bool CheckLocExist(string locCode)
        {
            var lstLoc = _entities.UV_STAGING_LOCATION.Where(p => p.Loc == locCode).ToList();
            if (lstLoc.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
