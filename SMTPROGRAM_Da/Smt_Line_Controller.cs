using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Smt_Line_Controller:SqlDataProvider
    {
        public DataTable Linename(string linename)
        {
            using (var cmd = new SqlCommand("sp_smt_checklinename", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add(new SqlParameter("@Linename", linename));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable Smt_GetAllLine()
        {
            using (var cmd = new SqlCommand("sp_smt_GetAllLine", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_smt_output_search
        public DataTable Smt_output_SearchByQRCode(string QRcode)
        {
            using (var cmd = new SqlCommand("sp_smt_output_search", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QRCode", QRcode));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //sp_smt_output_searchBydate
        public DataTable Smt_output_SearchByDate(string Fromdate, string todate)
        {
            using (var cmd = new SqlCommand("sp_smt_output_searchBydate", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FromDate", Fromdate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", todate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        //sp_smt_output_searchByKey
        public DataTable Smt_output_SearchByProgramkey(int opt, string program, string Fromdate, string todate)
        {
            using (var cmd = new SqlCommand("sp_smt_output_searchByKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@option", opt));
                cmd.Parameters.Add(new SqlParameter("@programkey", program));
                cmd.Parameters.Add(new SqlParameter("@FromDate", Fromdate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", todate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_smt_output_searchByKey
        public DataSet Smt_output_SearchByProgramkeyDataset(int opt, string program, string Fromdate, string todate)
        {
            using (var cmd = new SqlCommand("sp_smt_output_searchByKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@option", opt));
                cmd.Parameters.Add(new SqlParameter("@programkey", program));
                cmd.Parameters.Add(new SqlParameter("@FromDate", Fromdate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", todate));
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


        //sp_smt_output_searchByModel
        public DataTable Smt_output_SearchByModel(int opt, string Model, string Fromdate, string todate)
        {
            using (var cmd = new SqlCommand("sp_smt_output_searchByModel", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@option", opt));
                cmd.Parameters.Add(new SqlParameter("@Model", Model));
                cmd.Parameters.Add(new SqlParameter("@FromDate", Fromdate));
                cmd.Parameters.Add(new SqlParameter("@ToDate", todate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
