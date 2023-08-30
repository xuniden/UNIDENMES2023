using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace UnidenDAL.Staging
{
        public class ViewCombobox
    {
        public long ID { get; set; }
        public string LineName { get; set; }
    }
    public class ViewProdLine
    {
        public long ID { get; set; }
        public string LineName { get; set; }
        public string DeptCode { get; set; }
        public long DeptId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    public class UVProLineDAL
    {
        UVEntities _entities = new UVEntities();
        private static UVProLineDAL instance;
        public static UVProLineDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UVProLineDAL();
                return instance;
            }
        }
        public UVProLineDAL() { }
        public UV_PRO_LINE getProdLineByID(long Id)
        {
            return _entities.UV_PRO_LINE.Where(p => p.ID == Id).FirstOrDefault();
        }
        public List<ViewCombobox> getLineByDeptID(long deptid)
        {
            return (from a in _entities.UV_PRO_LINE.Where(p => p.DeptID == deptid)
                    select new ViewCombobox
                    {
                        ID = a.ID,
                        LineName = a.LineName
                    }).OrderBy(x=>x.LineName). ToList();
        }
        
        public List<ViewCombobox> getLineNotSMTDeptID(long deptid)
        {
            return (from a in _entities.UV_PRO_LINE.Where(p => p.DeptID != deptid)
                    select new ViewCombobox
                    {
                        ID = a.ID,
                        LineName = a.LineName
                    }).OrderBy(x => x.LineName).ToList();
        }
        public List<ViewProdLine> getAllProdLine()
        {
            return (from a in _entities.UV_PRO_LINE
                    select new ViewProdLine
                    {
                        ID = a.ID,
                        LineName = a.LineName,
                        DeptCode = a.UV_DEPT.DeptCode,
                        DeptId = a.UV_DEPT.DeptID,
                        CreatedDate = (DateTime)a.CreateDate
                    }).ToList();
        }
        public bool RemoveProdLine(long Id)
        {
            var prodLine = new UV_PRO_LINE();
            prodLine = _entities.UV_PRO_LINE.Where(p => p.ID == Id).FirstOrDefault();
            if (prodLine != null)
            {
                _entities.UV_PRO_LINE.Remove(prodLine);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Add(UV_PRO_LINE prodLine)
        {
            try
            {
                _entities.UV_PRO_LINE.Add(prodLine);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(UV_PRO_LINE prodLine)
        {

            var dept = _entities.UV_PRO_LINE.Where(p => p.ID == prodLine.ID).FirstOrDefault();
            if (dept != null)
            {
                try
                {
                    dept.LineName = prodLine.LineName;
                    dept.ID = prodLine.ID;
                    dept.DeptID = prodLine.DeptID;
                    dept.CreateDate = prodLine.CreateDate;
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
        public bool CheckLineNameExist(string lineName)
        {
            var lstLineName = _entities.UV_PRO_LINE.Where(p => p.LineName == lineName).ToList();
            if (lstLineName.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UV_PRO_LINE CheckLineName(string lineName)
        {
            return _entities.UV_PRO_LINE.Where(p => p.LineName == lineName).FirstOrDefault();           
        }
        public bool CheckDeptIdExist(long deptID)
        {
            var lstDiv = _entities.UV_DEPT.Where(p => p.DeptID == deptID).ToList();
            if (lstDiv.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<ViewProdLine> getAllProdLine(string search)
        {
            return (from a in _entities.UV_PRO_LINE.Where(p => p.LineName.Contains(search))
                    select new ViewProdLine
                    {
                        ID = a.ID,
                        LineName = a.LineName,
                        DeptCode = a.UV_DEPT.DeptCode,
                        DeptId = a.UV_DEPT.DeptID,
                        CreatedDate = (DateTime)a.CreateDate
                    }).ToList();
        }
    }
}
