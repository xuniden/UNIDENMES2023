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
    public class PcbType_DAL
    {
        UVEntities _entities = new UVEntities();
        private static PcbType_DAL instance;

        public static PcbType_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PcbType_DAL();
                return instance;
            }
            //set => instance = value; 
        }
        public PcbType_DAL() { }
        public System.Data.DataTable getPcbTypeisKeyforCreateQRCode(string pcbType)
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "usp_pcbTypeForUVQRCode";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@pcbType", pcbType));
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
