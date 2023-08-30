using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class General_Serial_Controller : SqlDataProvider
    {
        //sp_EstechSerialGeneral_Market
        public DataTable EstechSerialGeneral_Market()
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_Market", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void GeneralSerial_Insert(General_Serial_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechGeneralSerial_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Serial_Number", data.Serial_Number));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@ModelCode", data.ModelCode));
                cmd.Parameters.Add(new SqlParameter("@PCBCode", data.PCBCode));                
                cmd.Parameters.Add(new SqlParameter("@TypeOfProduct", data.TypeOfProduct));
                cmd.Parameters.Add(new SqlParameter("@EndOfYear", data.EndOfYear));
                cmd.Parameters.Add(new SqlParameter("@WeeksInYear", data.WeeksInYear));
                cmd.Parameters.Add(new SqlParameter("@DaysOfWeek", data.DaysOfWeek));
                cmd.Parameters.Add(new SqlParameter("@SerialOfProduct", data.SerialOfProduct));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }

        }
        public void GeneralSerial_Update(General_Serial_Info data, int Id)
        {
            using (var cmd = new SqlCommand("sp_EastechGeneralSerial_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));                
                cmd.Parameters.Add(new SqlParameter("@Serial_Number", data.Serial_Number));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@ModelCode", data.ModelCode));
                cmd.Parameters.Add(new SqlParameter("@PCBCode", data.PCBCode));
                cmd.Parameters.Add(new SqlParameter("@TypeOfProduct", data.TypeOfProduct));
                cmd.Parameters.Add(new SqlParameter("@EndOfYear", data.EndOfYear));
                cmd.Parameters.Add(new SqlParameter("@WeeksInYear", data.WeeksInYear));
                cmd.Parameters.Add(new SqlParameter("@DaysOfWeek", data.DaysOfWeek));
                cmd.Parameters.Add(new SqlParameter("@SerialOfProduct", data.SerialOfProduct));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }

        }

        public DataTable GeneralSerial_ModelList()
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_ModelList", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void GeneralSerial_Delete()
        {
            using (var cmd = new SqlCommand("sp_GeneralSerial_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GeneralSerial_GetbyAll()
        {
            using (var cmd = new SqlCommand("sp_EastechGeneralSerial_GetbyAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GeneralSerial_GetbySerial(General_Serial_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechGeneralSerial_GetbySerial", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Serial_Number", data.Serial_Number));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable GeneralSerial_CheckDoubleSerail()
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_CheckSerial", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GeneralSerial_SearchByModel(int Opt, String Model, string TypeOfProduct, string EndOfYear, string WeeksInYear, string DaysOfWeek)
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_Search", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Opt));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@TypeOfProduct", TypeOfProduct));
                cmd.Parameters.Add(new SqlParameter("@EndOfYear", EndOfYear));
                cmd.Parameters.Add(new SqlParameter("@WeeksInYear", WeeksInYear));
                cmd.Parameters.Add(new SqlParameter("@DaysOfWeek", DaysOfWeek));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GeneralSerial_CheckSerial(string Serial_Number, string model)
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_Check", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Serial_Number", Serial_Number));
                cmd.Parameters.Add(new SqlParameter("@Model", model));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



        //=====================================================================

        public void GeneralSerial_Insert_tmp(General_Serial_Info data)
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_Insert_tmp", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Serial_Number", data.Serial_Number));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@ModelCode", data.ModelCode));
                cmd.Parameters.Add(new SqlParameter("@PCBCode", data.PCBCode));
                cmd.Parameters.Add(new SqlParameter("@TypeOfProduct", data.TypeOfProduct));
                cmd.Parameters.Add(new SqlParameter("@EndOfYear", data.EndOfYear));
                cmd.Parameters.Add(new SqlParameter("@WeeksInYear", data.WeeksInYear));
                cmd.Parameters.Add(new SqlParameter("@DaysOfWeek", data.DaysOfWeek));
                cmd.Parameters.Add(new SqlParameter("@SerialOfProduct", data.SerialOfProduct));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }

        }

        public void GeneralSerial_Delete_tmp()
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_Delete_tmp", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GeneralSerial_GetbyAll_Tmp()
        {//sp_EstechSerialGeneral_GetbyAll_tmp
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_GetbyAll_tmp", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }
        public void EstechSerialGeneral_tmp_To_Main()
        {
            using (var cmd = new SqlCommand("sp_EstechSerialGeneral_tmp_To_Main", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }

        }
    }
}
