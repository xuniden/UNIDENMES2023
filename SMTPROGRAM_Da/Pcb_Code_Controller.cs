using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Pcb_Code_Controller :SqlDataProvider
    {
        public void PCBCode_Insert(Pcb_Code_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PcbKey", data.PcbKey));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@PCBCode", data.PCBCode));
                cmd.Parameters.Add(new SqlParameter("@PcbType", data.PcbType));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }

        }

        public void PCBCode_Update(int id, Pcb_Code_Info data)
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id.ToString()));
                cmd.Parameters.Add(new SqlParameter("@PcbKey", data.PcbKey));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@PCBCode", data.PCBCode));
                cmd.Parameters.Add(new SqlParameter("@PcbType", data.PcbType));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@DateT", data.DateT));
                cmd.ExecuteNonQuery();
            }

        }

        public DataTable PCBCode_CheckKey(string PcbKey)
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_CheckKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PcbKey", PcbKey.ToString()));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }
        //sp_EastechPCBCode_GetPcbCode
        public DataTable EastechPCBCode_GetPcbCode()
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_GetPcbCode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //sp_EastechPCBCode_SearchByPcbCode
        public DataTable EastechPCBCode_SearchByPcbCode(string pcbcode)
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_SearchByPcbCode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PcbCode", pcbcode));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable PCBCode_Search(string Model)
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_Search", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }


        public DataTable PCBCode_GetPCBCodeByModel(string Model)
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_GetPCBCodeByModel", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        public DataTable PCBCode_GetModel()
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_GetModel", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }

        public void PCBCode_DelById(int id)
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_DelById", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id.ToString()));
                cmd.ExecuteNonQuery();
            }

        }
        public DataTable PCBCode_GetbyAll()
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void PCBCode_DeleteAll()
        {
            using (var cmd = new SqlCommand("sp_EastechPCBCode_DeleteAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }

        }
    }
}
