using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Staging_Line_Controller:SqlDataProvider
    {
        //sp_staging_Line

        public DataTable staging_Line(string Remark)
        {
            using (var cmd = new SqlCommand("sp_staging_Line", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void staging_Line_IUD(int Option, string Id, string Lot, string Remark)
        {
            using (var cmd = new SqlCommand("sp_staging_Line_IUD", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Parameters.Add(new SqlParameter("@Lot", Lot));
                cmd.Parameters.Add(new SqlParameter("@Remark", Remark));                
                cmd.ExecuteNonQuery();
            }
        }

        // sp_staging_Line_R
        public DataTable staging_Line_R()
        {
            using (var cmd = new SqlCommand("sp_staging_Line_R", GetConnection()))
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
