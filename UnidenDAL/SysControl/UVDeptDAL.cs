using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl
{

    public class ViewDept
    {
        public long DeptID { get; set; }
        public string DeptCode { get; set; }
        public string DeptDesc { get; set; }
        public string DivCode { get; set; }
        public long DivID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class UVDeptDAL
    {
        UVEntities _entities = new UVEntities();
        private static UVDeptDAL instance;


        public static UVDeptDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UVDeptDAL();
                return instance;
            }
        }
        public UVDeptDAL() { }
        public List<UV_DEPT> getListDept()
        {
            return _entities.UV_DEPT.OrderBy(p => p.DeptCode).ToList();
        }

        public List<ViewDept> getAllDept()
        {
            var query = (from a in _entities.UV_DEPT.OrderByDescending(p => p.CreatedDate)
                    .Include(p => p.UV_DIV.DivDesc)
                         select new ViewDept
                         {
                             DeptID = a.DeptID,
                             DeptCode = a.DeptCode,
                             DeptDesc = a.DeptDesc,
                             DivID = a.DivID,
                             DivCode = a.UV_DIV.DivCode,
                             CreatedDate = a.CreatedDate
                         }).ToList();
            return query;

        }
        public List<ViewDept> getAllDept(string search)
        {
            var query = (from a in _entities.UV_DEPT.Where(p => p.DeptCode.Contains(search) || p.DeptDesc.Contains(search)).OrderByDescending(p => p.CreatedDate)
                   .Include(p => p.UV_DIV.DivDesc)
                         select new ViewDept
                         {
                             DeptID = a.DeptID,
                             DeptCode = a.DeptCode,
                             DeptDesc = a.DeptDesc,
                             DivID = a.DivID,
                             DivCode = a.UV_DIV.DivCode,
                             CreatedDate = a.CreatedDate
                         }).ToList();
            return query;
        }
        public bool CheckDeptExist(string deptcode)
        {
            var lstDept = _entities.UV_DEPT.Where(p => p.DeptCode == deptcode).ToList();
            if (lstDept.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckDivIdExist(long divID)
        {
            var lstDiv = _entities.UV_DIV.Where(p => p.DivID == divID).ToList();
            if (lstDiv.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UV_DEPT checkExist(string deptcode)
        {
            return _entities.UV_DEPT.Where(p => p.DeptCode == deptcode).FirstOrDefault();
        }
        public bool RemoveDept(long Id)
        {
            var dept = new UV_DEPT();
            dept = _entities.UV_DEPT.Where(p => p.DeptID == Id).FirstOrDefault();
            if (dept != null)
            {
                _entities.UV_DEPT.Remove(dept);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Add(UV_DEPT uvDept)
        {
            try
            {
                _entities.UV_DEPT.Add(uvDept);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(UV_DEPT uvDept)
        {

            var dept = _entities.UV_DEPT.Where(p => p.DeptID == uvDept.DeptID).FirstOrDefault();
            if (dept != null)
            {
                try
                {
                    dept.DeptID = uvDept.DeptID;
                    dept.DeptCode = uvDept.DeptCode;
                    dept.DeptDesc = uvDept.DeptDesc;
                    dept.DivID = uvDept.DivID;
                    dept.CreatedDate = uvDept.CreatedDate;
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

        public UV_DEPT getDeptByID(long deptId)
        {
            return _entities.UV_DEPT.Where(p => p.DeptID == deptId).FirstOrDefault();
        }
    }
}
