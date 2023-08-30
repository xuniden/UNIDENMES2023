using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace UnidenDAL.SysControl.Setup
{
    public class EstechSerialGeneral_DAL
    {
        UVEntities _entities = new UVEntities();
        private static EstechSerialGeneral_DAL instance;

        public static EstechSerialGeneral_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new EstechSerialGeneral_DAL();
                return instance;
            }
            //set => instance = value; 
        }
        public EstechSerialGeneral_DAL() { }

        public bool Add(tbl_EstechSerialGeneral qrcodemanagement)
        {
            try
            {
                _entities.tbl_EstechSerialGeneral.Add(qrcodemanagement);
                _entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string AddList(List<tbl_EstechSerialGeneral> lstQrcode)
        {
            string message = "";
            try
            {
                _entities.tbl_EstechSerialGeneral.AddRange(lstQrcode);
                _entities.SaveChanges();
                message = "";
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public tbl_EstechSerialGeneral checkQrCodeExists(string qrcode)
        {
            return _entities.tbl_EstechSerialGeneral.Where(p => p.Serial_Number == qrcode).FirstOrDefault();
        }
        public System.Data.DataTable CheckExistsQRCode(StringBuilder sbQRcode)
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_CheckExistsQRCode";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@qrcodeList", sbQRcode.ToString()));
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
        #region Không sử dụng
        //public DataTable getListQRcodeByUser(string qrcode, string user)
        //{
        //    var dt = new DataTable();
        //    using (var command = _entities.Database.Connection.CreateCommand())
        //    {
        //        command.CommandText = "usp_getListQRcodeByUser";
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@qrcode", qrcode));
        //        command.Parameters.Add(new SqlParameter("@user", user));

        //        if (command.Connection.State != ConnectionState.Open)
        //        {
        //            command.Connection.Open();
        //        }
        //        using (var reader = command.ExecuteReader())
        //        {
        //            dt.Load(reader);
        //        }
        //    }
        //    return dt;
        //}
        #endregion
        public System.Data.DataTable searchByQrcodeModel(string search)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_searchByQrcodeModel";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@search", search));

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
        public System.Data.DataTable getListQRcodeCreated(string model, string pcbcode,string endOfyear, string weekInyear,string dayOfweek,int fromNumber, int toNumber)
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_getListQRcodeCreated";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@model", model));
                command.Parameters.Add(new SqlParameter("@pcbcode", pcbcode));
                command.Parameters.Add(new SqlParameter("@endofyear", endOfyear));
                command.Parameters.Add(new SqlParameter("@weekinyear", weekInyear));
                command.Parameters.Add(new SqlParameter("@dayOfweek", dayOfweek));
                command.Parameters.Add(new SqlParameter("@FromserialOfproduct", fromNumber));
                command.Parameters.Add(new SqlParameter("@ToserialOfproduct", toNumber));

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
