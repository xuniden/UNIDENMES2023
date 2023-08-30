using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl
{
    public class UVDiv
    {
        public long DivID { get; set; }
        public string DivCode { get; set; }
        public string DivDesc { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class UVDivDAL
    {

        UVEntities _entities = new UVEntities();
        private static UVDivDAL instance;


        public static UVDivDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new UVDivDAL();
                return instance;
            }
        }
        public UVDivDAL() { }

        public List<UVDiv> getAllDiv()
        {
            List<UVDiv> result = new List<UVDiv>();
            return result = (from a in _entities.UV_DIV.OrderByDescending(p => p.CreatedDate)
                             select new UVDiv
                             {
                                 DivID = a.DivID,
                                 DivCode = a.DivCode,
                                 DivDesc = a.DivDesc,
                                 CreatedDate = a.CreatedDate
                             }).ToList();
        }
        public List<UVDiv> SearchDiv(string div)
        {
            return (from a in _entities.UV_DIV.Where(p => p.DivCode.Contains(div) || p.DivDesc.Contains(div))
                    select new UVDiv
                    {
                        DivID = a.DivID,
                        DivCode = a.DivCode,
                        DivDesc = a.DivDesc,
                        CreatedDate = a.CreatedDate

                    }).ToList();
        }
        public bool CheckDivExist(string divcode)
        {
            var lstDiv = _entities.UV_DIV.Where(p => p.DivCode == divcode).ToList();
            if (lstDiv.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UV_DIV getDivByID(long divId)
        {
            return _entities.UV_DIV.Where(p => p.DivID == divId).FirstOrDefault();
        }
        public bool RemoveDiv(long Id)
        {
            var div = new UV_DIV();
            div = _entities.UV_DIV.Where(p => p.DivID == Id).FirstOrDefault();
            if (div != null)
            {
                _entities.UV_DIV.Remove(div);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Add(UV_DIV uvDiv)
        {
            try
            {
                _entities.UV_DIV.Add(uvDiv);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(UV_DIV uvDiv)
        {
            var div = new UV_DIV();
            div = _entities.UV_DIV.Where(p => p.DivID == uvDiv.DivID).FirstOrDefault();
            if (div != null)
            {
                try
                {
                    div.DivCode = uvDiv.DivCode;
                    div.DivDesc = uvDiv.DivDesc;
                    div.CreatedDate = uvDiv.CreatedDate;
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
