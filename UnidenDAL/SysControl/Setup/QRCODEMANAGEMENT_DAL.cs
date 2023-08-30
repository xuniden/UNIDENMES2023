using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl.Setup
{
    public class QRCODEMANAGEMENT_DAL
    {
        UVEntities _entities = new UVEntities();
        private static QRCODEMANAGEMENT_DAL instance;

        public static QRCODEMANAGEMENT_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QRCODEMANAGEMENT_DAL();
                return instance;
            }
            //set => instance = value; 
        }
        public QRCODEMANAGEMENT_DAL() { }
        public bool Add(UV_QRCODEMANAGEMENT qrcodemanagement)
        {
            try
            {
                _entities.UV_QRCODEMANAGEMENT.Add(qrcodemanagement);
                _entities.SaveChanges();
                return true;
            }
            catch 
            {
                return false;                
            }
        }

        public bool AddList(List<UV_QRCODEMANAGEMENT> lstQrcode)
        {
            try
            {
                _entities.UV_QRCODEMANAGEMENT.AddRange(lstQrcode);
                _entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public UV_QRCODEMANAGEMENT checkQrCodeExists(string qrcode)
        {
            return _entities.UV_QRCODEMANAGEMENT.Where(p=>p.QRCODE==qrcode).FirstOrDefault();
        }
        public DataTable CheckExistsQRCode(StringBuilder sbQRcode)
        {
            var dt = new DataTable();
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
        public DataTable getListQRcodeByUser(string qrcode, string user)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_getListQRcodeByUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@qrcode", qrcode));
                command.Parameters.Add(new SqlParameter("@user", user));
                
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
        public DataTable searchByQrcodeModel(string search)
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
        //
    }
}
