using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Smt_Repair_Result_Controller:SqlDataProvider
    {
        // sp_Smt_Repair_Result_Insert
        #region Insert
        public void Smt_Repair_Result_Insert(Smt_Repair_Result_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Result_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", data.QRCode));
                cmd.Parameters.Add(new SqlParameter("@Err_Position", data.Err_Position));
                cmd.Parameters.Add(new SqlParameter("@Part_Code", data.Part_Code));
                cmd.Parameters.Add(new SqlParameter("@Ky_Hieu", data.Ky_Hieu));
                cmd.Parameters.Add(new SqlParameter("@Noi_Dung", data.Noi_Dung));
                cmd.Parameters.Add(new SqlParameter("@So_Luong", data.So_Luong));
                cmd.Parameters.Add(new SqlParameter("@Nguoi_Sua", data.Nguoi_Sua));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.Parameters.Add(new SqlParameter("@Nguoi_Sua2", data.Nguoi_Sua2));
                cmd.Parameters.Add(new SqlParameter("@DateT2", data.DateT2));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", data.Remark2));
                cmd.Parameters.Add(new SqlParameter("@Remark3", data.Remark3));
                cmd.Parameters.Add(new SqlParameter("@Remark4", data.Remark4));
                cmd.Parameters.Add(new SqlParameter("@Remark5", data.Remark5));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        // sp_Smt_Repair_Result_Update
        #region Update
        public void Smt_Repair_Result_Update(Smt_Repair_Result_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Result_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@QRCode", data.QRCode));
                cmd.Parameters.Add(new SqlParameter("@Err_Position", data.Err_Position));
                cmd.Parameters.Add(new SqlParameter("@Part_Code", data.Part_Code));
                cmd.Parameters.Add(new SqlParameter("@Ky_Hieu", data.Ky_Hieu));
                cmd.Parameters.Add(new SqlParameter("@Noi_Dung", data.Noi_Dung));
                cmd.Parameters.Add(new SqlParameter("@So_Luong", data.So_Luong));               
                cmd.Parameters.Add(new SqlParameter("@Nguoi_Sua2", data.Nguoi_Sua2));
                cmd.Parameters.Add(new SqlParameter("@DateT2", data.DateT2));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Remark2", data.Remark2));
                cmd.Parameters.Add(new SqlParameter("@Remark3", data.Remark3));
                cmd.Parameters.Add(new SqlParameter("@Remark4", data.Remark4));
                cmd.Parameters.Add(new SqlParameter("@Remark5", data.Remark5));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        // sp_Smt_Repair_Result_Delete
        #region Delete
        public void Smt_Repair_Result_Delete(Smt_Repair_Result_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Result_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", data.QRCode));
                cmd.Parameters.Add(new SqlParameter("@Err_Position", data.Err_Position));               
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));                
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        // sp_Smt_Repair_Result_ViewAll
        #region Delete
        public DataTable Smt_Repair_Result_ViewAll(int Option,Smt_Repair_Result_Info data,string DateFrom, string DateTo)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Result_ViewAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@QRCode", data.QRCode));
                cmd.Parameters.Add(new SqlParameter("@Err_Position", data.Err_Position));
                cmd.Parameters.Add(new SqlParameter("@Remark1", data.Remark1));
                cmd.Parameters.Add(new SqlParameter("@Part_Code", data.Part_Code));
                cmd.Parameters.Add(new SqlParameter("@Ky_Hieu", data.Ky_Hieu));
                cmd.Parameters.Add(new SqlParameter("@Nguoi_Sua2", data.Nguoi_Sua2));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", DateFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", DateTo));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        
             public DataTable Smt_Repair_Result_ViewByDept( string Dept)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Result_ViewByDept", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Dept", Dept));               
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_Smt_Repair_Result_GroupDept

        public DataTable sp_Smt_Repair_Result_GroupDept()
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Result_GroupDept", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;               
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_Smt_Repair_Result_SearchByDeptDate

        public DataTable sp_Smt_Repair_Result_SearchByDeptDate(string Dept, string From, string Too)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Result_SearchByDeptDate", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Dept", Dept));
                cmd.Parameters.Add(new SqlParameter("@From", From));
                cmd.Parameters.Add(new SqlParameter("@To", Too));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
