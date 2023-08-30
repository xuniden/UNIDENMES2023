using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Staging_HsQty_Controller:SqlDataProvider
    {
        public void Staging_HsQty_Insert(Staging_HsQty_Info data)
        {
            using (var cmd = new SqlCommand("Staging_HsQty_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Lot", data.Lot));
                cmd.Parameters.Add(new SqlParameter("@Item", data.Item));
                cmd.Parameters.Add(new SqlParameter("@HsQty", data.HsQty));
                cmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));                
                cmd.ExecuteNonQuery();
            }
        }

        public void Staging_HsQty_Edit(Staging_HsQty_Info data)
        {
            using (var cmd = new SqlCommand("Staging_HsQty_Edit", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                cmd.Parameters.Add(new SqlParameter("@Lot", data.Lot));
                cmd.Parameters.Add(new SqlParameter("@Item", data.Item));
                cmd.Parameters.Add(new SqlParameter("@HsQty", data.HsQty));
                cmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable Staging_HsQty_GetById(string Id)
        {
            using (var cmd = new SqlCommand("Staging_HsQty_GetById", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void Staging_HsQty_DeleteById(string Id)
        {
            using (var cmd = new SqlCommand("Staging_HsQty_DeleteById", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id",Id));               
                cmd.ExecuteNonQuery();
            }
        }

        public void Staging_HsQty_DeleteAll()
        {
            using (var cmd = new SqlCommand("Staging_HsQty_DeleteAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Staging_HsQty_SearchByLot(string Lot)
        {
            using (var cmd = new SqlCommand("Staging_HsQty_SearchByLot", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Lot", Lot));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_staging_HsQtyItem

        public DataTable staging_HsQtyItem(string Lot)
        {
            using (var cmd = new SqlCommand("sp_staging_HsQtyItem", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Lot", Lot));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_staging_HsQty

        public DataTable staging_HsQty(string Lot, string Item)
        {
            using (var cmd = new SqlCommand("sp_staging_HsQty", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Lot", Lot));
                cmd.Parameters.Add(new SqlParameter("@Item", Item));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable Staging_HsQty_GetAll()
        {
            using (var cmd = new SqlCommand("Staging_HsQty_GetAll", GetConnection()))
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
