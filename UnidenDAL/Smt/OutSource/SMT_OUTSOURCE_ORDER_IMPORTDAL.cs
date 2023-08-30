using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnidenDTO;

namespace UnidenDAL.Smt.OutSource
{
    public class PartsList
    {
        public string OrderNo { get; set; }
        public string Partcode { get; set; }
        public double Qty { get; set; }  
        public double LotSize { get; set; }
        public double MaterialPerPcb { get; set; }
    }
    public class OutPartsList
    {
        public string OrderNo { get; set; }
        public string Partcode { get; set; }
        public double Qty { get; set; }
        public double MaterialPerPcb { get; set; }
        public int OutputQty { get; set; }
        public double Solinhkiencandung { get; set; }
        public double LotSize { get; set; }
       
    }
    public class SMT_OUTSOURCE_ORDER_IMPORTDAL
    {
        UVEntities _entities = new UVEntities();
        private static SMT_OUTSOURCE_ORDER_IMPORTDAL instance;
        public static SMT_OUTSOURCE_ORDER_IMPORTDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SMT_OUTSOURCE_ORDER_IMPORTDAL();
                return instance;
            }
        }
        public SMT_OUTSOURCE_ORDER_IMPORTDAL() { }

        public DataTable getBeforeMRPData()
        {
            // Query for items with price greater than 9.99.
            //var query = from i in _entities.Smt_OutSource_Mrp().ToList()                        
            //            orderby i.Partcode
            //            select i;

            //foreach (var item in query)
            //{
            //    item.t
            //}
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {                
                command.CommandText = "Smt_OutSource_Mrp";
                command.CommandType = CommandType.StoredProcedure;                
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            DataTable dnew = new DataTable();
            //for (int k = 0;  k < dt.Columns.Count-2; k++)
            for (int k = 0; k <2; k++)
            {
                dnew.Columns.Add(dt.Columns[k].ColumnName);
            }
            dnew.Columns.Add("Conlai");
            for (int k = 2; k < dt.Columns.Count ; k++)
            {
                dnew.Columns.Add(dt.Columns[k].ColumnName);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dnew.NewRow();
                double InQty = 0;
                InQty= dt.Rows[i][1].ToString() == "" ? 0 : double.Parse(dt.Rows[i][1].ToString());
                string Partcode = "";
                Partcode= dt.Rows[i][0].ToString();                
                row[0] = Partcode;
                row[1] = InQty;
                for (int j = 2; j < dt.Columns.Count; j++)
                {
                    double qty = 0;
                    qty=dt.Rows[i][j].ToString() == "" ? 0 : double.Parse(dt.Rows[i][j].ToString());
                    if (qty==0)
                    {
                        row[2] = InQty;
                        row[j+1] = qty;
                    }
                    if (qty>0)
                    {
                        double hieu = 0;
                        hieu = InQty - qty;
                        if (hieu > 0)
                        {
                            row[j+1] = qty;
                        }
                        else
                        {
                            row[j + 1] = hieu;
                        }
                        row[2]=InQty = hieu;
                    }
                }
                //if (InQty<totalQty)
                //{
                //    for (int j = 2; j < dt.Columns.Count; j++)
                //    {                      
                //        row[j] = (InQty - (dt.Rows[i][j].ToString() == "" ? 0 : double.Parse(dt.Rows[i][j].ToString()))).ToString();
                //    }
                //}
                dnew.Rows.Add(row);
            }
            return dnew;
        }
        //public List<PartsList> getListLinhKienTheoOrder(string Order)
        //{
        //    return _entities.SMT_OUTSOURCE_ORDER_IMPORT.Where(p=>p.OrderNo==Order & p.Qty>0).GroupBy(c=>c.Partcode)
        //        .Select(cl=>new PartsList
        //        {
        //            OrderNo=cl.FirstOrDefault().OrderNo,
        //            Partcode=cl.FirstOrDefault().Partcode ,
        //            Qty=cl.Sum(c=>c.Qty),
        //            LotSize=cl.Sum(c=>c.LotSize),
        //            MaterialPerPcb=cl.Sum(c=>c.Qty)/cl.Sum(c=>c.LotSize)
        //        }).ToList();
        //}
        public DataTable CheckMatrialByOrderVsOutputQty(string order,long outputQty)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "Smt_OutSource_CheckMatrialByOrderVsOutputQty";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OrderNo", order));
                command.Parameters.Add(new SqlParameter("@OutputQty", outputQty));

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
        public List<PartsList> KiemTraLinhKienTheoOrder(string order)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "Smt_OutSource_KiemtralinhkientheoOrder";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OrderNo", order));

                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            List<PartsList> partList = new List<PartsList>();
            partList = CommonDAL.Instance.ConvertDataTable<PartsList>(dt);
            return partList;
        }
        public List<PartsList> getListLinhKienTheoOrderNew(string order)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "Smt_OutSource_getMaterialByOrderNo";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OrderNo", order));
             
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            List<PartsList> partList = new List<PartsList>();
            partList =CommonDAL.Instance.ConvertDataTable<PartsList>(dt); 
            return partList;
        }

        public List<OutPartsList> getListLinhKienTheoOrderAndOutput(string order,long OutputQty)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "Smt_OutSource_getMaterialByOrderNoAndOutput";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@OrderNo", order));
                command.Parameters.Add(new SqlParameter("@OutputQty", OutputQty));

                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            List<OutPartsList> outPartList = new List<OutPartsList>();
            outPartList = CommonDAL.Instance.ConvertDataTable<OutPartsList>(dt);
            return outPartList;
        }

        public List<PartsList> getListLinhKienTheoOrder(string Order)
        {
            return _entities.SMT_OUTSOURCE_ORDER_IMPORT.Where(p => p.OrderNo == Order & p.Qty > 0).GroupBy(c => c.Partcode)
                .Select(cl => new PartsList
                {
                    OrderNo=cl.FirstOrDefault().OrderNo,
                    Partcode = cl.FirstOrDefault().Partcode,
                    Qty = cl.Sum(c => c.Qty),
                    LotSize = cl.FirstOrDefault().LotSize, //cl.Sum(c => c.LotSize),
                    MaterialPerPcb = cl.Sum(c => c.Qty) / cl.FirstOrDefault().LotSize
                }).ToList();
        }
        public SMT_OUTSOURCE_ORDER_IMPORT LayQtyTheoOrderNo(string orderno)
        {
            return _entities.SMT_OUTSOURCE_ORDER_IMPORT.Where(p => p.OrderNo == orderno).FirstOrDefault();
        }
        public SMT_OUTSOURCE_ORDER_IMPORT LayLotsizeTheoOrderNo(string orderno)
        {
            return _entities.SMT_OUTSOURCE_ORDER_IMPORT.Where(p => p.OrderNo == orderno).FirstOrDefault();
        }
        public bool KiemtraOrderDaTonTaiChua(string orderno)
        {
            var lst = new List<SMT_OUTSOURCE_ORDER_IMPORT>();
            lst = _entities.SMT_OUTSOURCE_ORDER_IMPORT.Where(p => p.OrderNo == orderno).ToList();
            if (lst.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<SMT_OUTSOURCE_ORDER_IMPORT>getTimKiemTheoOrder(string OrderNo)
        {
            return (from a in _entities.SMT_OUTSOURCE_ORDER_IMPORT
                   where OrderNo.Contains(a.OrderNo)
                    || OrderNo.Contains(a.Partcode)
            select a).OrderBy(p=>p.OrderNo).ToList();
        }
        public List<SMT_OUTSOURCE_ORDER_IMPORT> getTimKiemTheoListOrder(string OrderNo)
        {
            var results = (from n in _entities.SMT_OUTSOURCE_ORDER_IMPORT
                           where OrderNo.Contains(n.OrderNo)
                           select n).ToList();
            return results;
            
        }
        public List<SMT_OUTSOURCE_ORDER_IMPORT> getTatCaDuLieu()
        {
            return _entities.SMT_OUTSOURCE_ORDER_IMPORT.Take(5000).ToList();
        }
        public List<SMT_OUTSOURCE_ORDER_IMPORT> getUploadList()
        {
            DateTime dt = CommonDAL.Instance.getSqlServerDatetime();
            return _entities.SMT_OUTSOURCE_ORDER_IMPORT.Where(c => c.UpdateDate.Year == dt.Year
            && c.UpdateDate.Month == dt.Month
            && c.UpdateDate.Day == dt.Day).ToList();
        }
        public bool Add(SMT_OUTSOURCE_ORDER_IMPORT imprt)
        {
            try
            {
                _entities.SMT_OUTSOURCE_ORDER_IMPORT.Add(imprt);
                _entities.SaveChanges();
                return true;    
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool RemoveRange(List<SMT_OUTSOURCE_ORDER_IMPORT> lst)
        {
            try
            {
                _entities.SMT_OUTSOURCE_ORDER_IMPORT.RemoveRange(lst);
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
