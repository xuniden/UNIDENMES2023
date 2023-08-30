using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da.BoxET
{
    public class boxReturnManage_Control : SqlDataProvider 
    {
        public void boxReturnManage_Insert(boxReturnManage data)
        {
            using (var cmd = new SqlCommand("sp_boxReturnManage_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.Add(new SqlParameter("@ReturnSerial", data.ReturnSerial));
                cmd.Parameters.Add(new SqlParameter("@ReturnBy", data.ReturnBy));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable boxReturnManage_getListByUserAndDate(string ReturnBy)
        {
            using (var cmd = new SqlCommand("sp_boxReturnManage_getListByUserAndDate", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ReturnBy", ReturnBy));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        
    }
}
