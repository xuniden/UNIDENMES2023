using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Smt.OutSource;
using UnidenDTO;

namespace UnidenDAL.Smt.OutsourceBom
{
    public class ExportDiffETBOMvsUVBOM
    {
        public string Umodel { get; set; }
        public string LotNo { get; set; }
        public string OrderNo { get; set; }
        public string UVParts { get; set; }
        public string UVETParts { get; set; }
        public string ETBOMDelete { get; set; }
        public string UVParts2 { get; set; }
        public string ETParts { get; set; }
        public string ETBOMAdd { get; set; }   
        public double Qty { get; set; }
    }
    public class OUTSOURCE_UV_BOM_DAL
    {
        UVEntities _entities = new UVEntities();
        private static OUTSOURCE_UV_BOM_DAL instance;
        public static OUTSOURCE_UV_BOM_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OUTSOURCE_UV_BOM_DAL();
                return instance;
            }
        }
        public OUTSOURCE_UV_BOM_DAL() { }

        public List<ExportDiffETBOMvsUVBOM> getDiffBOMUVvsET() 
        {
            return (from a in _entities.OutSource_UVBOM_ETBOM()
                   select new ExportDiffETBOMvsUVBOM
                   {
                       Umodel=a.UModel,
                       LotNo=a.LotNo,
                       OrderNo=a.OrderNo,
                       UVParts=a.UVParts,
                       UVETParts=a.UVETParts,
                       ETBOMDelete=a.ETBOMDelete,   
                       UVParts2=a.UVParts2,
                       ETParts=a.ETParts,
                       ETBOMAdd=a.ETBOMAdd,
                       Qty=(double)a.Qty
                   }).ToList();
        }
        public bool Add(OUTSOURCE_UV_BOM smt)
        {
            try
            {
                _entities.OUTSOURCE_UV_BOM.Add(smt);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<OUTSOURCE_UV_BOM> getAll()
        {
            return _entities.OUTSOURCE_UV_BOM.ToList();
        }

        public bool DeleteAll(List<OUTSOURCE_UV_BOM> lst)
        {
            try
            {
                _entities.OUTSOURCE_UV_BOM.RemoveRange(lst);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteAll()
        {
            try
            {
                _entities.OutSource_Delete_UVBOM();                
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
