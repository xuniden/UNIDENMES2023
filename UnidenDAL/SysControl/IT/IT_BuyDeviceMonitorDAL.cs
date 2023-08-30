using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl.IT
{
    public class IT_BuyDeviceMonitorDAL
    {
        UVEntities _entities = new UVEntities();
        private static IT_BuyDeviceMonitorDAL instance;

        public static IT_BuyDeviceMonitorDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new IT_BuyDeviceMonitorDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public IT_BuyDeviceMonitorDAL() { }
        public bool Add(IT_BuyDeviceMonitor itDevices)
        {
            try
            {
                _entities.IT_BuyDeviceMonitor.Add(itDevices);
                _entities.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Update(IT_BuyDeviceMonitor itDevices)
        {
            var iupdate = _entities.IT_BuyDeviceMonitor.Where(p => p.SubDbNumber == itDevices.SubDbNumber).FirstOrDefault();
            try
            {                
                iupdate.Model = itDevices.Model;
                iupdate.DDescription = itDevices.DDescription;
                iupdate.Qty = itDevices.Qty;
                iupdate.ReceiverDate = itDevices.ReceiverDate;
                iupdate.IssueDate = itDevices.IssueDate;
                iupdate.ByPrice = itDevices.ByPrice;
                iupdate.Remark = itDevices.Remark;
                iupdate.Supplier = itDevices.Supplier;
                iupdate.UpdatedDate = itDevices.UpdatedDate;
                iupdate.UpdatedBy = itDevices.UpdatedBy;
                _entities.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public IT_BuyDeviceMonitor getBuyDevicesByDbNumber(string dbnumber)
        {
            return _entities.IT_BuyDeviceMonitor.Where(p=>p.SubDbNumber==dbnumber).FirstOrDefault();    
        }
        public bool UpdateQty(IT_BuyDeviceMonitor buyDevice)
        {
            var de=_entities.IT_BuyDeviceMonitor.Where(p=>p.SubDbNumber== buyDevice.SubDbNumber).FirstOrDefault();
            try
            {
                de.IssueQty = de.IssueQty + 1;
                de.UpdatedBy=buyDevice.UpdatedBy;
                de.UpdatedDate=buyDevice.UpdatedDate;
                _entities.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        
        public DataTable getInfoSubDbNumber(string SubDbNumber)
        {
            DataTable result = new DataTable();

            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_BuyDeviceMonitor_GetValueCombobox";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SubDbNumber", SubDbNumber));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    result.Load(reader);
                }
            }
            return result;
        }
        public DataTable getSearchListByDevices(string search)
        {
            DataTable result = new DataTable();

            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_BuyDeviceMonitor_SearchByDevices";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@search", search));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    result.Load(reader);
                }
            }
            return result;
        }

        public DataTable getListByDevices()
        {
            DataTable result = new DataTable();

            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_BuyDeviceMonitor_ListByDevices";
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@SubDbNumber", SelectedValue));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    result.Load(reader);
                }
            }
            return result;
        }
        public IT_BuyDeviceMonitor checkExist(string subDbNumber)
        {
            return _entities.IT_BuyDeviceMonitor.Where(p => p.SubDbNumber == subDbNumber).FirstOrDefault();
        }
        public DataTable getSelectedValue(string SelectedValue)
        {
            DataTable result = new DataTable();

            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_BuyDeviceMonitor_SelectedValue";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SubDbNumber", SelectedValue));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    result.Load(reader);
                }
            }
            return result;
        }
        public DataTable getListSubDbNumber()
        {
            DataTable result = new DataTable();            
                 
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_BuyDeviceMonitor_DisplayCombobox";
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
                    result.Load(reader);
                }
            }
            return result;
        }
    }
}
