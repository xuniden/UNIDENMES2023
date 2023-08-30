using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Smt_Repair_Controller :SqlDataProvider
    {
        // Smt_Repair_Bom
        #region Insert
        public void Smt_Repair_Bom_Insert(Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Bom_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Pcb_No", data.Pcb_No));
                cmd.Parameters.Add(new SqlParameter("@Part_Code", data.Part_Code));
                cmd.Parameters.Add(new SqlParameter("@Position", data.Position));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Delete
        public void Smt_Repair_Bom_Delete(Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Bom_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Pcb_No", data.Pcb_No));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        //sp_Smt_Repair_Bom_ViewAll

        public DataTable Smt_Repair_Bom_ViewAll(int Option,Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Bom_ViewAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@Pcb_No", data.Pcb_No));
                cmd.Parameters.Add(new SqlParameter("@Position", data.Position));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable Smt_Repair_Bom_Check(int Option, Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Bom_Check", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Pcb_No", data.Pcb_No));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Smt_Repair_Error_Code
        /*sp_Smt_Repair_Error_Code_Insert
        sp_Smt_Repair_Error_Code_Delete
        sp_Smt_Repair_Error_Code_Update
        sp_Smt_Repair_Error_Code_ViewAll */
        #region Smt_Repair_Error_Code Insert
        public void Smt_Repair_Error_Code_Insert(Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Error_Code_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Ky_Hieu", data.Ky_Hieu));
                cmd.Parameters.Add(new SqlParameter("@Dept", data.Dept));
                cmd.Parameters.Add(new SqlParameter("@Noi_Dung_Loi", data.Noi_Dung_Loi));                
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Smt_Repair_Error_Code Delete
        public void Smt_Repair_Error_Code_Delete(Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Error_Code_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));                
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        public DataTable Smt_Repair_Error_Code_ViewAll(int Option,Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Error_Code_ViewAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@Dept", data.Dept));
                cmd.Parameters.Add(new SqlParameter("@Ky_Hieu", data.Ky_Hieu));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Smt_Repair_Error_Code_Update( Smt_Repair_Info data)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Error_Code_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Ky_Hieu", data.Ky_Hieu));
                cmd.Parameters.Add(new SqlParameter("@Dept", data.Dept));
                cmd.Parameters.Add(new SqlParameter("@Noi_Dung_Loi", data.Noi_Dung_Loi));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }
        }

        //sp_Smt_Repair_Cause_ViewAll
        public DataTable Smt_Repair_Cause_ViewAll()
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Cause_ViewAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;              
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_Smt_Repaire_DeptCause_ViewAll

        public DataTable Smt_Repaire_DeptCause_ViewAll()
        {
            using (var cmd = new SqlCommand("sp_Smt_Repaire_DeptCause_ViewAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable Smt_Repair_Cause_ViewByCode(string CauseError)
        {
            using (var cmd = new SqlCommand("sp_Smt_Repair_Cause_ViewByCode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CauseError", CauseError));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
