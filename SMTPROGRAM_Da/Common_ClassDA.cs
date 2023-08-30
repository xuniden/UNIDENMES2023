using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SMTPROGRAM_Da
{
    public class Common_ClassDA:SqlDataProvider
    {
        //[sp_QrCodeNotYetScan]
        public DataTable GetQrCodeNotYetScan(int Option, string FromDate, string ToDate)
        {
            using (var cmd = new SqlCommand("sp_QrCodeNotYetScan", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DateTime getServerDateTime()
        {
            using (var cmd = new SqlCommand("sp_getServerDateTime", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;               
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return DateTime.Parse( dt.Rows[0][0].ToString());
            }
        }

    }
}
