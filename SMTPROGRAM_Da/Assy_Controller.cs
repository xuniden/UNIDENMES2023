using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class Assy_Controller:SqlDataProvider
    {
        //=====Operator Process=======================
        public void A_OperatorProcess_Insert( Assy_Info assy)
        {
            using (var cmd = new SqlCommand("sp_AssyOperatorProcessSetup_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OperatorProcess", assy.OperatorProcess));
                cmd.Parameters.Add(new SqlParameter("@Status", assy.Status));
                cmd.Parameters.Add(new SqlParameter("@SetupDate", assy.SetupDate));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable A_OperatorProcess_Select()
        {
            using (var cmd = new SqlCommand("sp_AssyOperatorProcessSetup_Select", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //========================Type PCB=====================
        public void A_TypePcb_Insert(Assy_Info assy)
        {
            using (var cmd = new SqlCommand("sp_ATypePcb_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TypePcb", assy.TypePcb));
                cmd.Parameters.Add(new SqlParameter("@Status", assy.Status));
                cmd.Parameters.Add(new SqlParameter("@SetupDate", assy.SetupDate));
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable A_TypePcb_Select()
        {
            using (var cmd = new SqlCommand("sp_ATypePcb_Select", GetConnection()))
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
