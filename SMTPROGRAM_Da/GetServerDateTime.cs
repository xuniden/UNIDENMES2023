using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da
{
    public class GetServerDateTime : SqlDataProvider
    {
        public DateTime getServerDateTime()
        {
            using (var cmd = new SqlCommand("sp_getServerDateTime", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return DateTime.Parse(dt.Rows[0][0].ToString());
            }
        }
    }
}
