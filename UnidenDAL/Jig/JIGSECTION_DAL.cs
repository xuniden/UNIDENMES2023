using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Jig
{
    public class ShowView
    {
        public long Id { get; set; }
        public long DeptID { get; set; }
        public string JigSecCode { get; set; }
        public string JigSecDesc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDisable { get; set; }
    }
    public class JIGSECTION_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGSECTION_DAL instance;
        public static JIGSECTION_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGSECTION_DAL();
                return instance;
            }
        }

        public JIGSECTION_DAL() { }

        public List<ShowView> getListSection()
        {
            return ( from a in  _entities.JIG_SECTION
                     select new ShowView
                     {
                         Id = a.Id,
                         DeptID = a.DeptID,
                         JigSecCode = a.JigSecCode,
                         JigSecDesc = a.JigSecDesc,
                         CreatedBy = a.CreatedBy,
                         CreatedDate = a.CreatedDate,
                         UpdatedDate = a.UpdatedDate,
                         IsDisable = a.IsDisable
                     }).ToList();
        }
        public List<ShowView> getListSection( string search)
        {
            return (from a in _entities.JIG_SECTION.Where(p => p.JigSecCode.Contains(search) || p.JigSecDesc.Contains(search))
                    select new ShowView
                    {
                        Id = a.Id,
                        DeptID = a.DeptID,
                        JigSecCode = a.JigSecCode,
                        JigSecDesc = a.JigSecDesc,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        UpdatedDate = a.UpdatedDate,
                        IsDisable = a.IsDisable
                    }).ToList();
        }
        public JIG_SECTION checkLocExist(string secCode)
        {
            return _entities.JIG_SECTION.Where(p => p.JigSecCode == secCode).FirstOrDefault();
        }
        public bool Add(JIG_SECTION jigSec)
        {
            try
            {
                _entities.JIG_SECTION.Add(jigSec);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Remove(long Id)
        {
            var sec = new JIG_SECTION();
            sec = _entities.JIG_SECTION.Where(p => p.Id == Id).FirstOrDefault();
            if (sec != null)
            {
                sec.IsDisable = true;
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(JIG_SECTION jigSec)
        {
            var sec = _entities.JIG_SECTION.Where(p => p.Id == jigSec.Id).FirstOrDefault();
            if (sec != null)
            {
                try
                {
                    sec.JigSecDesc = jigSec.JigSecDesc;
                    sec.UpdatedDate = jigSec.UpdatedDate;
                    sec.IsDisable = jigSec.IsDisable;
                    sec.CreatedBy = jigSec.CreatedBy;
                    sec.DeptID = jigSec.DeptID;
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
