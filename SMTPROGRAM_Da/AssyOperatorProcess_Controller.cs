using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class AssyOperatorProcess_Controller:SqlDataProvider
    {
        public void AssyOperatorProcess_Insert(AssyOperatorProcess_Info data)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Market", data.Market));
                cmd.Parameters.Add(new SqlParameter("@TypePcb", data.TypePcb));
                cmd.Parameters.Add(new SqlParameter("@Process", data.Process));
                cmd.Parameters.Add(new SqlParameter("@QrCode", data.QrCode));
                cmd.Parameters.Add(new SqlParameter("@Checker", data.Checker));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", data.Remark2));
                cmd.Parameters.Add(new SqlParameter("@Remark3", data.Remark3));
                cmd.Parameters.Add(new SqlParameter("@Wireless", data.Wireless));
				cmd.Parameters.Add(new SqlParameter("@Wireless", data.Wireless));
				cmd.Parameters.Add(new SqlParameter("@LineName", data.LineName));
				cmd.ExecuteNonQuery();
            }
        }
        //sp_A_OperatorProcessData_Update

        public void AssyOperatorProcess_Update(AssyOperatorProcess_Info data)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Market", data.Market));
                cmd.Parameters.Add(new SqlParameter("@TypePcb", data.TypePcb));
                cmd.Parameters.Add(new SqlParameter("@Process", data.Process));
                cmd.Parameters.Add(new SqlParameter("@QrCode", data.QrCode));
                cmd.Parameters.Add(new SqlParameter("@Checker", data.Checker));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", data.Remark2));
                cmd.Parameters.Add(new SqlParameter("@Remark3", data.Remark3));
				cmd.Parameters.Add(new SqlParameter("@LineName", data.LineName));
				cmd.ExecuteNonQuery();
            }
        }
        //sp_A_OperatorProcessData_CoutByUser
        public DataTable AssyOperatorProcessData_CoutByUser(string Checker, string DateT)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_CoutByUser", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Checker", Checker));
                cmd.Parameters.Add(new SqlParameter("@DateT", DateT));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //------------
        public int AssyOperatorProcessData_CheckFCT(string FSerial, string FRemark)
        {
            using (var cmd = new SqlCommand("sp_A_EastechCheckFCT_GetData", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FSerial", FSerial));
                cmd.Parameters.Add(new SqlParameter("@FRemark", FRemark));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count;
            }
        }
        //sp_A_OperatorProcessData_GetModel
        public DataTable AssyOperatorProcessData_GetModel(string Model, string TypePCB, DateTime FromDate, DateTime ToDate )
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_GetModel", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@TypePCB", TypePCB));
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //sp_A_OperatorProcessData_GetMAIN
        public DataTable AssyOperatorProcessData_GetMAIN(string Model, string TypePCB, DateTime FromDate, DateTime ToDate)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_GetMAIN", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@TypePCB", TypePCB));
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //sp_A_OperatorProcessData_GetModel
        public DataTable AssyOperatorProcessData_GetAMP(string Model, string TypePCB, DateTime FromDate, DateTime ToDate)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_GetAMP", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@TypePCB", TypePCB));
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //sp_A_OperatorProcessData_GetModel
        public DataTable AssyOperatorProcessData_GetPSU(string Model, string TypePCB, DateTime FromDate, DateTime ToDate)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_GetPSU", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@TypePCB", TypePCB));
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //sp_A_OperatorProcessData_GetModelAll
        public DataTable AssyOperatorProcessData_GetModelAll(string Model)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_GetModelAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_A_OperatorProcessData_GetSearch
        public DataTable AssyOperatorProcessData_GetSearch(string Model, string TypePCB, string FromDate, string ToDate)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_GetSearch", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@TypePCB", TypePCB));
                cmd.Parameters.Add(new SqlParameter("@FromDate", FromDate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", ToDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_A_OperatorProcessData_CheckProcess
        public DataTable AssyOperatorProcessData_CheckProcess(string QrCode ,string Process)
        {
            using (var cmd = new SqlCommand("sp_A_OperatorProcessData_CheckProcess", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QrCode", QrCode));
                cmd.Parameters.Add(new SqlParameter("@Process", Process));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable A_EastechCheckFCT_MAIN(string QRCode)
        {
            using (var cmd = new SqlCommand("sp_A_EastechCheckFCT_MAIN", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", QRCode));                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
