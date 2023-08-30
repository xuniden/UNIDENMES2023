using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Item_Master_Controll:SqlDataProvider
    {
        public void PART_DESC_Insert(Item_Master_Info data)
        {
            using (var cmd = new SqlCommand("sp_PART_DESC_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Partcode", data.Partcode));
                cmd.Parameters.Add(new SqlParameter("@Partname", data.Partname));
                cmd.Parameters.Add(new SqlParameter("@Partspec", data.Partspec));
                cmd.Parameters.Add(new SqlParameter("@Cur", data.Cur));
                cmd.Parameters.Add(new SqlParameter("@Price", data.Price));
                cmd.Parameters.Add(new SqlParameter("@Mpq", data.Mpq));
                cmd.Parameters.Add(new SqlParameter("@dateupdate", data.dateupdate));
                cmd.ExecuteNonQuery();
            }

        }

        public void PART_DESC_Update(Item_Master_Info data)
        {
            using (var cmd = new SqlCommand("sp_PART_DESC_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Partcode", data.Partcode));
                cmd.Parameters.Add(new SqlParameter("@Partname", data.Partname));
                cmd.Parameters.Add(new SqlParameter("@Partspec", data.Partspec));
                cmd.Parameters.Add(new SqlParameter("@Cur", data.Cur));
                cmd.Parameters.Add(new SqlParameter("@Price", data.Price));
                cmd.Parameters.Add(new SqlParameter("@Mpq", data.Mpq));
                cmd.Parameters.Add(new SqlParameter("@dateupdate", data.dateupdate));
                cmd.ExecuteNonQuery();
            }

        }

        public void PART_DESC_Delete()
        {
            using (var cmd = new SqlCommand("sp_PART_DESC_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.ExecuteNonQuery();
            }

        }
        
        public void PART_DESC_DeletebyPartcode(Item_Master_Info data)
        {
            using (var cmd = new SqlCommand("sp_PART_DESC_DeletebyPartcode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Partcode", data.Partcode));
                cmd.ExecuteNonQuery();
            }

        }

        public DataTable PART_DESC_GetbyParcode(Item_Master_Info data)
        {
            using (var cmd = new SqlCommand("sp_PART_DESC_GetbyParcode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Partcode", data.Partcode));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable PART_DESC_GetbyAll()
        {
            using (var cmd = new SqlCommand("sp_PART_DESC_GetbyAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
