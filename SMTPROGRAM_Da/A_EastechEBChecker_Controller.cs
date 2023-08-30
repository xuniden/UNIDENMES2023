using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class A_EastechEBChecker_Controller:SqlDataProvider
    {
        public void A_EastechEBChecker_Insert(A_EastechEBChecker_Info data)
        {
            using (var cmd = new SqlCommand("A_EastechEBChecker_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));
                cmd.Parameters.Add(new SqlParameter("@State1", data.State1));
                cmd.Parameters.Add(new SqlParameter("@State2", data.State2));
                cmd.Parameters.Add(new SqlParameter("@Searial", data.Searial));
                cmd.Parameters.Add(new SqlParameter("@ZipCode", data.ZipCode));
                cmd.Parameters.Add(new SqlParameter("@Status01", data.Status01));
                cmd.Parameters.Add(new SqlParameter("@Status02", data.Status02));
                cmd.Parameters.Add(new SqlParameter("@Status03", data.Status03));
                cmd.Parameters.Add(new SqlParameter("@Status04", data.Status04));
                cmd.Parameters.Add(new SqlParameter("@Status05", data.Status05));
                cmd.Parameters.Add(new SqlParameter("@Status06", data.Status06));
                cmd.Parameters.Add(new SqlParameter("@Status07", data.Status07));
                cmd.Parameters.Add(new SqlParameter("@Status08", data.Status08));
                cmd.Parameters.Add(new SqlParameter("@Status09", data.Status09));
                cmd.Parameters.Add(new SqlParameter("@Status10", data.Status10));
                cmd.Parameters.Add(new SqlParameter("@UserName", data.UserName));
                cmd.ExecuteNonQuery();
            }
        }
        //A_EastechEBChecker_Update

        public void A_EastechEBChecker_Update(A_EastechEBChecker_Info data)
        {
            using (var cmd = new SqlCommand("A_EastechEBChecker_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));
                cmd.Parameters.Add(new SqlParameter("@State1", data.State1));
                cmd.Parameters.Add(new SqlParameter("@State2", data.State2));
                cmd.Parameters.Add(new SqlParameter("@Searial", data.Searial));
                cmd.Parameters.Add(new SqlParameter("@ZipCode", data.ZipCode));
                cmd.Parameters.Add(new SqlParameter("@Status01", data.Status01));
                cmd.Parameters.Add(new SqlParameter("@Status02", data.Status02));
                cmd.Parameters.Add(new SqlParameter("@Status03", data.Status03));
                cmd.Parameters.Add(new SqlParameter("@Status04", data.Status04));
                cmd.Parameters.Add(new SqlParameter("@Status05", data.Status05));
                cmd.Parameters.Add(new SqlParameter("@Status06", data.Status06));
                cmd.Parameters.Add(new SqlParameter("@Status07", data.Status07));
                cmd.Parameters.Add(new SqlParameter("@Status08", data.Status08));
                cmd.Parameters.Add(new SqlParameter("@Status09", data.Status09));
                cmd.Parameters.Add(new SqlParameter("@Status10", data.Status10));
                cmd.Parameters.Add(new SqlParameter("@UserName", data.UserName));
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable A_EastechEBChecker_Check(string searial)
        {
            using (var cmd = new SqlCommand("A_EastechEBChecker_Check", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Searial", searial));               
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
