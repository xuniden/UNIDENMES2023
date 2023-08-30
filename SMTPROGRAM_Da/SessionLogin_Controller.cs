using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class SessionLogin_Controller:SqlDataProvider
    {
        public void tbl_SessionLogin_Insert(SessionLogin_Info data)
        {
            using (var cmd = new SqlCommand("tbl_SessionLogin_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", data.UserId));
                cmd.Parameters.Add(new SqlParameter("@LoginTime", data.LoginTime));
                cmd.Parameters.Add(new SqlParameter("@Dept", data.Dept));
                cmd.Parameters.Add(new SqlParameter("@HostName", data.HostName));
                cmd.Parameters.Add(new SqlParameter("@IpAddress", data.IpAddress));
                cmd.ExecuteNonQuery();
            }
        }

        public void tbl_SessionLogin_Delete (string UserId)
        {
            using (var cmd = new SqlCommand("tbl_SessionLogin_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable tbl_SessionLogin_Select(string UserId)
        {
            using (var cmd = new SqlCommand("tbl_SessionLogin_Select", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", UserId));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        //tbl_SessionLogin_GetAll

        public DataTable tbl_SessionLogin_GetAll()
        {
            using (var cmd = new SqlCommand("tbl_SessionLogin_GetAll", GetConnection()))
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
