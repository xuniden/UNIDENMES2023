using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl.IT
{
    public class HienThiLoaiThietBi
    {
        public long Id { get; set; }
        public string LoaiTB { get; set; }
        public string MotaTB { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class ITDevicesType_DAL
    {
        UVEntities _entities = new UVEntities();
        private static ITDevicesType_DAL instance;

        public static ITDevicesType_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ITDevicesType_DAL();
                return instance;
            }
            //set => instance = value; 
        }
        public ITDevicesType_DAL() { }

        public List<HienThiLoaiThietBi> getListDevicesType()
        {
            return (from a in _entities.IT_DevicesType
                    select new HienThiLoaiThietBi
                    {
                        Id=a.ID,
                        LoaiTB = a.LoaiTB,
                        MotaTB=a.MotaTB,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        UpdatedBy = a.UpdatedBy,
                        UpdatedDate = a.UpdatedDate
                    }).ToList();
        }
        public List<HienThiLoaiThietBi> getListDevicesType(string search)
        {
            return (from a in _entities.IT_DevicesType.Where(p=>p.LoaiTB.Contains(search)||p.MotaTB.Contains(search))
                    select new HienThiLoaiThietBi
                    {
                        Id = a.ID,
                        LoaiTB = a.LoaiTB,
                        MotaTB = a.MotaTB,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        UpdatedBy = a.UpdatedBy,
                        UpdatedDate = a.UpdatedDate
                    }).ToList();
        }

        public bool Add(IT_DevicesType iT_DevicesType)
        {
            try
            {
                _entities.IT_DevicesType.Add(iT_DevicesType);
                _entities.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool Update(IT_DevicesType iT_DevicesType)
        {
            var itType = _entities.IT_DevicesType.Where(p => p.LoaiTB == iT_DevicesType.LoaiTB).FirstOrDefault();
            try
            {
                itType.MotaTB = iT_DevicesType.MotaTB;
                itType.UpdatedBy = iT_DevicesType.UpdatedBy;
                itType.UpdatedDate = iT_DevicesType.UpdatedDate;    
                _entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IT_DevicesType checkExist(string LoaiTb)
        {
            return _entities.IT_DevicesType.Where(p => p.LoaiTB == LoaiTb).FirstOrDefault();
        }

    }
}
