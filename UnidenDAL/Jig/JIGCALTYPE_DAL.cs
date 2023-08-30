using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Jig
{
    public class ShowDetail
    {
        public long Id { get; set; }    
        public string CalType { get; set; }
        public string CalDesc { get; set; }
        public int Cycle { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDisable { get; set; }
    }
    public class JIGCALTYPE_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGCALTYPE_DAL instance;
        public static JIGCALTYPE_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGCALTYPE_DAL();
                return instance;
            }
        }

        public JIGCALTYPE_DAL() { }

        public List<ShowDetail> getListCalType()
        {
            return (from a in _entities.JIG_CALTYPE
                   select new ShowDetail
                   {
                       Id = a.Id,
                       CalType = a.CalType,
                       CalDesc = a.CalDesc,
                       Cycle = a.Cycle,
                       CreatedBy = a.CreatedBy,
                       CreatedDate = a.CreatedDate,
                       UpdatedDate = a.UpdatedDate,
                       IsDisable = a.IsDisable
                   }).ToList();
        }
        public List<ShowDetail> getListCalType(string search)
        {
            return (from a in _entities.JIG_CALTYPE.Where(p=>p.CalType.Contains(search)||p.CalDesc.Contains(search))
                    select new ShowDetail
                    {
                        Id = a.Id,
                        CalType = a.CalType,
                        CalDesc = a.CalDesc,
                        Cycle = a.Cycle,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        UpdatedDate = a.UpdatedDate,
                        IsDisable = a.IsDisable
                    }).ToList();
        }
        public bool Remove(long Id)
        {
            var calType = new JIG_CALTYPE();
            calType = _entities.JIG_CALTYPE.Where(p => p.Id == Id).FirstOrDefault();
            if (calType != null)
            {
                calType.IsDisable = true;
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public JIG_CALTYPE checkCalTypeExist(string calType)
        {
            return _entities.JIG_CALTYPE.Where(p => p.CalType == calType).FirstOrDefault();
        }
        public bool Add(JIG_CALTYPE calType)
        {
            try
            {
                _entities.JIG_CALTYPE.Add(calType);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(JIG_CALTYPE calType)
        {
            var type = _entities.JIG_CALTYPE.Where(p => p.Id == calType.Id).FirstOrDefault();
            if (type != null)
            {
                try
                {
                    type.CalDesc = calType.CalDesc;
                    type.UpdatedDate = calType.UpdatedDate;
                    type.IsDisable = calType.IsDisable;
                    type.Cycle = calType.Cycle;
                    type.CreatedBy = calType.CreatedBy;
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
