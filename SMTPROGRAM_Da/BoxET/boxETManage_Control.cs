using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da.BoxET
{
    public class boxETManage_Control:SqlDataProvider
    {
        public void boxETManage_Insert(boxETManage data)
        {
            using (var cmd = new SqlCommand("sp_boxETManage_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Serial", data.Serial));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", data.CreatedBy));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@BarCode", data.BarCode));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable boxETManage_CheckExists(string Serial)
        {
            using (var cmd = new SqlCommand("sp_boxETManage_CheckExists", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Serial", Serial));               
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable boxETManage_getNumberOfSerial(string boxType)
        {
            using (var cmd = new SqlCommand("sp_boxETManage_getNumberOfSerial", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@boxType", boxType));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable boxETManage_getLastOfSerial(string boxType)
        {
            using (var cmd = new SqlCommand("sp_boxETManage_getLastOfSerial", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@boxType", boxType));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable boxETManage_PrintBarcode(string fromSerial, string toSerial)
        {
            using (var cmd = new SqlCommand("sp_boxETManage_PrintBarcode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fromSerial", fromSerial));
                cmd.Parameters.Add(new SqlParameter("@toSerial", toSerial));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
		

		public void boxETManage_UpdateStatus(boxETManage data)
        {
            using (var cmd = new SqlCommand("sp_boxETManage_UpdateStatus", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Serial", data.Serial));               
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));               
                cmd.ExecuteNonQuery();
            }
        }
    }
}
