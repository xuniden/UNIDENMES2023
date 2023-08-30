using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da.BoxET
{
    public class boxIssueManage_Control:SqlDataProvider
    {
        public void boxIssueManage_Insert(boxIssueManage data)
        {
            using (var cmd = new SqlCommand("sp_boxIssueManage_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IssueSerial", data.IssueSerial));
                cmd.Parameters.Add(new SqlParameter("@IssueBy", data.IssueBy));
                cmd.Parameters.Add(new SqlParameter("@IssueWight", data.IssueWight));
                cmd.Parameters.Add(new SqlParameter("@IssueStatus", data.IssueStatus));
                cmd.Parameters.Add(new SqlParameter("@Line", data.Line));
                cmd.Parameters.Add(new SqlParameter("@Model", data.Model));
                cmd.Parameters.Add(new SqlParameter("@Market", data.Market));
                cmd.Parameters.Add(new SqlParameter("@PCBType", data.PCBType));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable boxIssueManage_getListByUserAndDate(string IssueBy)
        {
            using (var cmd = new SqlCommand("sp_boxIssueManage_getListByUserAndDate", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IssueBy", IssueBy));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable boxIssueManage_CheckExists(string IssueSerial)
        {
            using (var cmd = new SqlCommand("sp_boxIssueManage_CheckExists", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IssueSerial", IssueSerial));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public  void boxIssueManage_UpdateByStatus(string IssueSerial, bool IssueStatus)
        {
            using (var cmd = new SqlCommand("sp_boxIssueManage_UpdateByStatus", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IssueSerial", IssueSerial));
                cmd.Parameters.Add(new SqlParameter("@IssueStatus", IssueStatus));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable boxReportManage(int Option, string Serial, DateTime fromDate, DateTime toDate)
        {
            using (var cmd = new SqlCommand("sp_boxReportManage", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Option", Option));
                cmd.Parameters.Add(new SqlParameter("@Serial", Serial));
                cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                cmd.Parameters.Add(new SqlParameter("@toDate", toDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //sp_boxETManage_IssueNotReutn
        public DataTable boxETManage_IssueNotReutn()
        {
            using (var cmd = new SqlCommand("sp_boxETManage_IssueNotReutn", GetConnection()))
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
