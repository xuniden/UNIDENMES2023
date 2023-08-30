using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Insert_Program_Controller :SqlDataProvider
    {
        //sp_INSERT_PROGRAM_Insert
        #region Thêm dữ liệu vào bảng dữ liệu
        public void INSERT_PROGRAM_Insert(Insert_Program_Info data)
        {
            using (var cmd = new SqlCommand("sp_INSERT_PROGRAM_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InProgram", data.InProgram));
                cmd.Parameters.Add(new SqlParameter("@InPosition", data.InPosition));
                cmd.Parameters.Add(new SqlParameter("@InPartcode", data.InPartcode));
                cmd.Parameters.Add(new SqlParameter("@InDesc", data.InDesc));
                cmd.Parameters.Add(new SqlParameter("@InUsage", data.InUsage));
                cmd.Parameters.Add(new SqlParameter("@InRP", data.InRP));
                cmd.Parameters.Add(new SqlParameter("@InRep1", data.InRep1));
                cmd.Parameters.Add(new SqlParameter("@InRep2", data.InRep2));
                cmd.Parameters.Add(new SqlParameter("@InRep3", data.InRep3));
                cmd.Parameters.Add(new SqlParameter("@InRep4", data.InRep4));
                cmd.Parameters.Add(new SqlParameter("@InRep5", data.InRep5));
                cmd.Parameters.Add(new SqlParameter("@InReqty", data.InReqty));
                cmd.Parameters.Add(new SqlParameter("@InDatecode", data.InDatecode));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        //sp_INSERT_PROGRAM_DeleteByKey
        #region Xóa dữ liệu theo Program Key
        public void INSERT_PROGRAM_DeleteByKey(string InProgram)
        {
            using (var cmd = new SqlCommand("sp_INSERT_PROGRAM_DeleteByKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@InProgram", InProgram));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        //sp_INSER_PROGRAM_CheckKeyUpload
        #region Kiểm tra Program Key khi upload. Nếu có rồi thì phải xóa đi upload lại.
        public DataTable INSER_PROGRAM_CheckKeyUpload(string InProgram)
        {
            SqlCommand cmd = new SqlCommand("sp_INSER_PROGRAM_CheckKeyUpload", SqlDataProvider.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@InProgram", InProgram));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion


        //sp_INSER_PROGRAM_CheckKeyPosition
        #region Kiểm tra position theo program key
        public DataTable INSER_PROGRAM_CheckKeyPosition(string Inprogram, string position)
        {
            SqlCommand cmd = new SqlCommand("sp_INSER_PROGRAM_CheckKeyPosition", SqlDataProvider.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@InProgram", Inprogram));
            cmd.Parameters.Add(new SqlParameter("@InPosition", position));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        #endregion

        //sp_INSERT_PROGRAM_CheckPartcode
        public DataTable INSERT_PROGRAM_CheckPartcode(string InProgram, string InPosition, string InPartcode)
        {
            SqlCommand cmd = new SqlCommand("sp_INSERT_PROGRAM_CheckPartcode", SqlDataProvider.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@InProgram", InProgram));
            cmd.Parameters.Add(new SqlParameter("@InPosition", InPosition));
            cmd.Parameters.Add(new SqlParameter("@InPartcode", InPartcode));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
