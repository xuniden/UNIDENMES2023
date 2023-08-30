using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.OutSource
{
    public class SumOutPut
    {
        public string OrderNo { get; set; }
        public long OutQty { get; set; }
    }
    public class SMT_OUTSOURCE_OUTPUTDAL
    {
        UVEntities _entities = new UVEntities();
        private static SMT_OUTSOURCE_OUTPUTDAL instance;
        public static SMT_OUTSOURCE_OUTPUTDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SMT_OUTSOURCE_OUTPUTDAL();
                return instance;
            }
        }
        public SMT_OUTSOURCE_OUTPUTDAL() { }
        

        public List<SMT_OUTSOURCE_OUTPUT>lstOutputByUserDate(string UserId)
        {
            DateTime dt;
            dt=CommonDAL.Instance.getSqlServerDatetime();
            return _entities.SMT_OUTSOURCE_OUTPUT.Where(c=>c.CreatedBy==UserId
            && (c.CreatedDate.Year==dt.Year
                && c.CreatedDate.Month==dt.Month
                && c.CreatedDate.Day==dt.Day)).ToList();
        }

        public bool KiemtraOrderClosed(string orderno)
        {
            var lst = new List<SMT_OUTSOURCE_OUTPUT>();
            lst = _entities.SMT_OUTSOURCE_OUTPUT.Where(p => p.OrderNo==orderno && p.OrderStatus == true).ToList();
            if (lst.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public SumOutPut QtyOutputTheoOrderNo(string Orderno)
        {
            return (_entities.SMT_OUTSOURCE_OUTPUT.Where(p => p.OrderNo == Orderno).GroupBy(l => l.OrderNo)
                .Select(cl => new SumOutPut
                {
                    OrderNo = cl.FirstOrDefault().OrderNo,
                    OutQty = cl.Sum(c => c.OuputQty)
                })).FirstOrDefault();
        }


        public SMT_OUTSOURCE_OUTPUT LaydulieutheoOrder(string order)
        {
            return _entities.SMT_OUTSOURCE_OUTPUT.Where(p => p.OrderNo == order).FirstOrDefault();
        }
        public bool KiemTraOrderNo(string OrderNo)
        {
            var lst = _entities.SMT_OUTSOURCE_OUTPUT.Where(p => p.OrderNo == OrderNo).ToList();
            if (lst.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<SMT_OUTSOURCE_OUTPUT> HienThiTatCa()
        {
            return _entities.SMT_OUTSOURCE_OUTPUT.OrderByDescending(p => p.UpdatedDate).ToList();
        }
        public List<SMT_OUTSOURCE_OUTPUT> HienThiDuLieuTheoUserVaNgayThang(string userid)
        {
            DateTime dt = CommonDAL.Instance.getSqlServerDatetime();
            return _entities.SMT_OUTSOURCE_OUTPUT.Where(c=>c.CreatedBy==userid &&(c.UpdatedDate.Year == dt.Year
            && c.UpdatedDate.Month == dt.Month
            && c.UpdatedDate.Day == dt.Day)
            ).ToList();
        }
        public bool KiemTraCoTonTaiKhongTheoID(long ID)
        {
            var lst= _entities.SMT_OUTSOURCE_OUTPUT.Where(p => p.ID == ID).ToList();
            if (lst.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(SMT_OUTSOURCE_OUTPUT ouput)
        {
            try
            {
                _entities.SMT_OUTSOURCE_OUTPUT.Add(ouput);
                _entities.SaveChanges();
                // Xử lý trừ toàn bộ linh kiện đã sửa dụng cho lot này
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Update(SMT_OUTSOURCE_OUTPUT output)
        {
            var ou = new SMT_OUTSOURCE_OUTPUT();
            ou = _entities.SMT_OUTSOURCE_OUTPUT.Where(p => p.ID == output.ID).FirstOrDefault();
            if (ou!=null)
            {
                ou.OrderNo=output.OrderNo;
                ou.OuputQty=output.OuputQty;
                ou.OrderStatus = output.OrderStatus;
                ou.Remark = output.Remark;
                ou.DeliveryDate = output.DeliveryDate;
                ou.UpdatedDate = output.UpdatedDate;
                ou.CreatedBy = output.CreatedBy;
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<SMT_OUTSOURCE_OUTPUT> TimKiemDuLieu(String search)
        {
            if (search=="")
            {
                return _entities.SMT_OUTSOURCE_OUTPUT.ToList();
            }
            else
            {
                return _entities.SMT_OUTSOURCE_OUTPUT.Where(p=>p.OrderNo==search).ToList();
            }
        }

        public DataTable getSearchData(DateTime FromDate, DateTime ToDate)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "Smt_OurSource_SearchOutputByDate";
                command.CommandType = CommandType.StoredProcedure;                
                command.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
    }
}
