using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using DataTable = System.Data.DataTable;

namespace UnidenDAL.SysControl.IT
{
    public class ITDevicesManagement_DAL
    {
        UVEntities _entities = new UVEntities();
        private static ITDevicesManagement_DAL instance;

        public static ITDevicesManagement_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ITDevicesManagement_DAL();
                return instance;
            }
            //set => instance = value; 
        }
        public ITDevicesManagement_DAL() { }

        public List<IT_DevicesManagement> getListDevices()
        {
            return _entities.IT_DevicesManagement.ToList();                    
        }
        
        public DataTable getListDevicesStockOnly()
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_DevicesManagement_GetStockOnly";
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@QRCode", QRCode));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
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
        public DataTable getListDevicesAll()
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_DevicesManagement_GetAll";
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@QRCode", QRCode));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
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
        public DataTable getLastSerialDesktopLaptop()
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_IT_getLastOfMaTBDesktopLaptop";
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@MaTB", search));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
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
        public DataTable getLastMaTBOtherDevices(string LoaiTB)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_IT_getLastOfMaTBOtherDevices";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@LoaiTB", LoaiTB));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
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
        public DataTable getListDevicesAll(string search)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_DevicesManagement_SearchByMaTB";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaTB", search));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
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

        
        public List<IT_DevicesManagement> getListDevices(string search)
        {
            return _entities.IT_DevicesManagement.Where(p=>p.MaTB.Contains(search)
            || p.TenTB.Contains(search)
            || p.Model.Contains(search)
            || p.MotaTB.Contains(search)
            || p.ServiceCode.Contains(search)
            || p.ServiceTag.Contains(search)
            || p.Supplier.Contains(search)
            || p.MacAddress.Contains(search)
            ).ToList();
        }
        public IT_DevicesManagement checkExist(string MaTB)
        {
            return _entities.IT_DevicesManagement.Where(p => p.MaTB == MaTB).FirstOrDefault();
        }
        // Kiểm tra xem thiết bị này đã bị xuất đi chưa?
        public IT_DevicesManagement checkDeviceAvailable(string MaTB)
        {
            return _entities.IT_DevicesManagement.Where(p => p.MaTB == MaTB && p.Stock==true).FirstOrDefault();
        }
        public List<IT_DevicesManagement> getDevicesByNoteDbNumber(string noteDbnumber)
        {
            return _entities.IT_DevicesManagement.Where(p=>p.NoteDBNumber==noteDbnumber).ToList();
        }
        public bool Add(IT_DevicesManagement itDevices)
        {
            try
            {
                _entities.IT_DevicesManagement.Add(itDevices);
                _entities.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }
        }
        public bool UpdateIssueReturn(IT_DevicesManagement itDevices)
        {
            var iupdate = _entities.IT_DevicesManagement.Where(p => p.MaTB == itDevices.MaTB).FirstOrDefault();
            try
            {

                iupdate.Stock = itDevices.Stock;
                iupdate.UpdatedDate = itDevices.UpdatedDate;
                iupdate.UpdateBy = itDevices.UpdateBy;
                _entities.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Update(IT_DevicesManagement itDevices)
        {
            var iupdate = _entities.IT_DevicesManagement.Where(p => p.MaTB == itDevices.MaTB).FirstOrDefault();
            try
            {
                iupdate.TenTB=itDevices.TenTB;
                iupdate.Model = itDevices.Model;
                iupdate.MotaTB = itDevices.MotaTB;
                iupdate.NoteDBNumber = itDevices.NoteDBNumber;
                iupdate.Dept=itDevices.Dept;
                iupdate.Loc = itDevices.Loc;
                iupdate.Status = itDevices.Status;
                iupdate.BuyDate = itDevices.BuyDate;
                iupdate.ServiceTag = itDevices.ServiceTag;
                iupdate.ServiceCode=itDevices.ServiceCode;
                iupdate.MacAddress = itDevices.MacAddress;
                iupdate.LoaiTB = itDevices.LoaiTB;
                iupdate.Supplier = itDevices.Supplier;
                iupdate.Remark = itDevices.Remark;
                iupdate.UpdatedDate = itDevices.UpdatedDate;
                iupdate.UpdateBy = itDevices.UpdateBy;                
                _entities.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
