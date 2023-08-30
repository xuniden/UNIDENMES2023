using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SMTPROGRAM_Da
{
    public class Ins_Eas_Program_History_Controller:SqlDataProvider
    {
        //sp_INSERT_PROGRAMHISTORY_Insert
        #region Thêm dữ liệu vào bảng Inser Prgram history 
        public void INSERT_PROGRAMHISTORY_Insert(Ins_Eas_Program_History_Info data)
        {
            using (var cmd = new SqlCommand("sp_INSERT_PROGRAMHISTORY_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InProgram", data.InProgram));
                cmd.Parameters.Add(new SqlParameter("@InPosition", data.InPosition));
                cmd.Parameters.Add(new SqlParameter("@InPartcode", data.InPartcode));
                cmd.Parameters.Add(new SqlParameter("@InDesc", data.InDesc));
                cmd.Parameters.Add(new SqlParameter("@InUsage", data.InUsage));
                cmd.Parameters.Add(new SqlParameter("@InCheckBy", data.InCheckBy));
                cmd.Parameters.Add(new SqlParameter("@InCheckTime", data.InCheckTime));
                cmd.Parameters.Add(new SqlParameter("@InRP", data.InRP));
                cmd.Parameters.Add(new SqlParameter("@InRep1", data.InRep1));
                cmd.Parameters.Add(new SqlParameter("@InRep21", data.InRep2));
                cmd.Parameters.Add(new SqlParameter("@InRep3", data.InRep3));
                cmd.Parameters.Add(new SqlParameter("@InRep4", data.InRep4));
                cmd.Parameters.Add(new SqlParameter("@InRep5", data.InRep5));
                cmd.Parameters.Add(new SqlParameter("@InReqty", data.InReqty));
                cmd.Parameters.Add(new SqlParameter("@InDatecode", data.InDatecode));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", data.Remark2));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        //sp_INSERT_PROGRAMHISTORY_DeleteByKey
        #region Xóa dữ liệu theo Program key
        public void INSERT_PROGRAMHISTORY_DeleteByKey(string InProgram)
        {
            using (var cmd = new SqlCommand("sp_INSERT_PROGRAMHISTORY_DeleteByKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InProgram", InProgram));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion


        //sp_INSERT_PROGRAMHISTORY_SelectByKey
        #region Lấy dữ liệu theo Program key
        public DataTable INSERT_PROGRAMHISTORY_SelectByKey(string InProgram)
        {
            using (var cmd = new SqlCommand("sp_INSERT_PROGRAMHISTORY_SelectByKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InProgram", InProgram));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
