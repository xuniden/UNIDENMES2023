using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class ModelName_Controller:SqlDataProvider
    {
        public DataTable ModelName_GetAll()
        {
            using (var cmd = new SqlCommand("sp_ModelName_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;               
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
