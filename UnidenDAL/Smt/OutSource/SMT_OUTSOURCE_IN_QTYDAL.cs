using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Smt.Output;
using UnidenDTO;

namespace UnidenDAL.Smt.OutSource
{
    public class TonKhoList
    {
        public string Partcode { get; set; }
        public double Qty { get; set; }
    }
    public class SMT_OUTSOURCE_IN_QTYDAL
    {
        UVEntities _entities = new UVEntities();
        private static SMT_OUTSOURCE_IN_QTYDAL instance;
        public static SMT_OUTSOURCE_IN_QTYDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SMT_OUTSOURCE_IN_QTYDAL();
                return instance;
            }
        }
        public SMT_OUTSOURCE_IN_QTYDAL() { }
        public List<SMT_OUTSOURCE_IN_QTY> getUploadList()
        {
            DateTime dt = CommonDAL.Instance.getSqlServerDatetime();
            return _entities.SMT_OUTSOURCE_IN_QTY.Where(c=>c.UpdatedDate.Year==dt.Year 
            && c.UpdatedDate.Month==dt.Month
            && c.UpdatedDate.Day==dt.Day).ToList();
        }
        public List<SMT_OUTSOURCE_IN_QTY> danhsachMacoQty(string partcode)
        {
            return _entities.SMT_OUTSOURCE_IN_QTY.Where(p => p.PartCode == partcode && p.Qty > 0).OrderBy(p => p.DateCode).ToList();
        }
        public List<SMT_OUTSOURCE_IN_QTY>getTimKiemTheoPart(string partcode)
        {
            if (partcode=="")
            {
                return _entities.SMT_OUTSOURCE_IN_QTY.ToList();
            }
            else
            {
                return _entities.SMT_OUTSOURCE_IN_QTY.Where(p => p.PartCode.Contains( partcode)).ToList();
            }            
        }
        public SMT_OUTSOURCE_IN_QTY getPartQty(string partcode)
        {
            return _entities.SMT_OUTSOURCE_IN_QTY.Where(p => p.PartCode == partcode && p.Qty > 0).FirstOrDefault();
        }
        public List<TonKhoList> getTonKhoList()
        {
            return _entities.SMT_OUTSOURCE_IN_QTY.GroupBy(l => l.PartCode)
                .Select(cl => new TonKhoList
                {
                    Partcode = cl.FirstOrDefault().PartCode,
                    Qty = cl.Sum(c => c.Qty)
                }).ToList();
        }
        public bool Add(SMT_OUTSOURCE_IN_QTY smtIn)
        {
            try
            {
                _entities.SMT_OUTSOURCE_IN_QTY.Add(smtIn);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
           
        }

        public bool UpdateQty(SMT_OUTSOURCE_IN_QTY inQty)
        {
            var upQty=_entities.SMT_OUTSOURCE_IN_QTY.Where(p=>p.ID==inQty.ID).FirstOrDefault();
            try
            {               
                upQty.Qty = inQty.Qty;
                upQty.UpdatedDate = inQty.UpdatedDate;
                upQty.CreatedBy = inQty.CreatedBy;
                upQty.Remark1 = inQty.Remark1;
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
