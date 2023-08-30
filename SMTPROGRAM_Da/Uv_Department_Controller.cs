using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Uv_Department_Controller:SqlDataProvider
    {
        public void UvDepartment(int Option, Uv_Department_Info inf)
        {
            using (var cmd = new SqlCommand("sp_uv_Department", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@ID", inf.ID));
                cmd.Parameters.Add(new SqlParameter("@Dept", inf.Dept));
                cmd.Parameters.Add(new SqlParameter("@DeptDes", inf.DeptDes));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable UvDepartment_Timkiem(int Option, Uv_Department_Info inf)
        {
            using (var cmd = new SqlCommand("sp_uv_Department", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@ID", inf.ID));
                cmd.Parameters.Add(new SqlParameter("@Dept", inf.Dept));
                cmd.Parameters.Add(new SqlParameter("@DeptDes", inf.DeptDes));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
