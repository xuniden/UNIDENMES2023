using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Smt.DataControl;
using UnidenDTO;

namespace UnidenDAL.Jig
{
    public class ShowDisplay
    {
        public long Id { get; set; }
        public string LocName { get; set; }
        public string LocDesc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDisable { get; set; }

    }
    public class JIGLOCATION_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGLOCATION_DAL instance;
        public static JIGLOCATION_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGLOCATION_DAL();
                return instance;
            }
        }

        public JIGLOCATION_DAL() { }

        public List<ShowDisplay> getListLocation()
        {
            return (from a in  _entities.JIG_LOCATION
                    select new ShowDisplay
                    {
                        Id = a.Id,
                        LocName=a.LocName,
                        LocDesc=a.LocDesc,
                        CreatedBy=a.CreatedBy,
                        CreatedDate=a.CreatedDate,
                        UpdatedDate=a.UpdatedDate,
                        IsDisable=a.IsDisable
                    }).ToList();
        }
        public List<ShowDisplay> getListLocation(string search)
        {
            return (from a in _entities.JIG_LOCATION.Where(p => p.IsDisable == false&& (p.LocName.Contains(search)||p.LocDesc.Contains(search))).OrderBy(p=>p.LocName)
                select new ShowDisplay
                {
                    Id = a.Id,
                    LocName = a.LocName,
                    LocDesc = a.LocDesc,
                    CreatedBy = a.CreatedBy,
                    CreatedDate = a.CreatedDate,
                    UpdatedDate = a.UpdatedDate,
                    IsDisable = a.IsDisable
                }).ToList();
        }
        public bool Remove(long Id)
        {
            var loc = new JIG_LOCATION();
            loc = _entities.JIG_LOCATION.Where(p => p.Id == Id).FirstOrDefault();
            if (loc != null)
            {
                loc.IsDisable = true;
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public JIG_LOCATION checkLocExist(string Loc)
        {
            return _entities.JIG_LOCATION.Where(p => p.LocName == Loc).FirstOrDefault();           
        }
        public bool Add(JIG_LOCATION jigLoc)
        {
            try
            {
                _entities.JIG_LOCATION.Add(jigLoc);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(JIG_LOCATION jigLoc)
        {
            var loc = _entities.JIG_LOCATION.Where(p => p.Id == jigLoc.Id).FirstOrDefault();
            if (loc != null)
            {
                try
                {
                    loc.LocDesc = jigLoc.LocDesc;
                    loc.UpdatedDate = jigLoc.UpdatedDate;
                    loc.IsDisable = jigLoc.IsDisable;
                    loc.CreatedBy = jigLoc.CreatedBy;
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
