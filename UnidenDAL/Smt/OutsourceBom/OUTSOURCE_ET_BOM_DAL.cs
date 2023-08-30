using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.OutsourceBom
{
    public class ExportUvLotCSV
    {
        public string ORDER_NO { get; set; }
        public string NOTE_TEXT { get; set; }
        public string RELEASE_NO { get; set; }
        public string SEQUENCE_NO { get; set; }
        public string CONTRACT { get; set; }
        public string SCHED_DIRECTION_DB { get; set; }
        //public string ETOrderNo { get; set; }

    }
    public class OUTSOURCE_ET_BOM_DAL
    {
        UVEntities _entities = new UVEntities();
        private static OUTSOURCE_ET_BOM_DAL instance;
        public static OUTSOURCE_ET_BOM_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OUTSOURCE_ET_BOM_DAL();
                return instance;
            }
        }
        public OUTSOURCE_ET_BOM_DAL() { }

        public bool DeleteAll()
        {
            try
            {
                _entities.OutSource_Delete_ETBOM();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<ExportUvLotCSV>getListUVLot()
        {
            //var lst = new List<ExportUvLotCSV>();
            return (from a in _entities.OutSource_ExportUVLotToDownload()
                    select new ExportUvLotCSV
                    {
                        ORDER_NO = a.ORDER_NO,
                        NOTE_TEXT = a.NOTE_TEXT,
                        RELEASE_NO = a.RELEASE_NO,
                        SEQUENCE_NO= a.SEQUENCE_NO,
                        CONTRACT=a.CONTRACT,
                        SCHED_DIRECTION_DB = a.SCHED_DIRECTION_DB,
                        //ETOrderNo = a.OrderNo                       

                    }).OrderBy(p=>p.ORDER_NO).ToList();

        }
        public List<OUTSOURCE_ET_BOM> getAll()
        {
            return _entities.OUTSOURCE_ET_BOM.ToList();
        }

        public bool DeleteAll(List<OUTSOURCE_ET_BOM> lst)
        {
            try
            {
                _entities.OUTSOURCE_ET_BOM.RemoveRange(lst);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Add(OUTSOURCE_ET_BOM smt)
        {
            try
            {
                _entities.OUTSOURCE_ET_BOM.Add(smt);
                _entities.SaveChanges();
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
