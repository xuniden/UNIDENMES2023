using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SMTPROGRAM_Da
{
    public class Ins_Eas_History_Controller :SqlDataProvider
    {
        public DataTable INS_EAS_PROGRAM_OUTPUT_CheckSubKeyNumber(string InPsubkey)
        {
            using (var cmd = new SqlCommand("sp_INS_EAS_PROGRAM_OUTPUT_CheckSubKeyNumberr", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InPsubkey", InPsubkey));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void INS_EAS_PROGRAM_OUTPUT_Insert( Ins_Eas_History_Info data)
        {
            using (var cmd = new SqlCommand("sp_INS_EAS_PROGRAM_OUTPUT_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InProgram", data.InProgram));
                cmd.Parameters.Add(new SqlParameter("@InPkey", data.InPkey));
                cmd.Parameters.Add(new SqlParameter("@InPsubkey", data.InPsubkey));
                cmd.Parameters.Add(new SqlParameter("@InPosition", data.InPosition));
                cmd.Parameters.Add(new SqlParameter("@InPartcode", data.InPartcode));
                cmd.Parameters.Add(new SqlParameter("@InDesc", data.InDesc));
                cmd.Parameters.Add(new SqlParameter("@InUsage", data.InUsage));
                cmd.Parameters.Add(new SqlParameter("@InCheckedby", data.InCheckedby));
                cmd.Parameters.Add(new SqlParameter("@InCheckedtime", data.InCheckedtime));               
                cmd.Parameters.Add(new SqlParameter("@InQty", data.InQty));
                cmd.Parameters.Add(new SqlParameter("@InDatecode", data.InDatecode));
                cmd.Parameters.Add(new SqlParameter("@InSolanthaylinhkien", data.InSolanthaylinhkien));
                cmd.Parameters.Add(new SqlParameter("@InSoPCBCothedung", data.InSoPCBCothedung));
                cmd.Parameters.Add(new SqlParameter("@remark1", data.remark1));
                cmd.Parameters.Add(new SqlParameter("@remark2", data.remark2));
                cmd.Parameters.Add(new SqlParameter("@remark3", data.remark3));
                cmd.Parameters.Add(new SqlParameter("@counts", data.counts));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
