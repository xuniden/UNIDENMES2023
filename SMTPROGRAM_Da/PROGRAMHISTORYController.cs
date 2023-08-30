using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class PROGRAMHISTORYDAL : SqlDataProvider
    {

        #region Insert Data
        #region Get By ID
        public DataTable PROGRAMHISTORY_SearchByParts(string pr, string dt1, string dt2)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_SearchByParts", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", pr));
                cmd.Parameters.Add(new SqlParameter("@starttime", dt1));
                cmd.Parameters.Add(new SqlParameter("@endtime", dt2));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable PROGRAMHISTORY_SearchByPartCode(string partcode)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_SearchByPartCode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@partscode", partcode));               
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable PROGRAMHISTORY_SearchByPartCodeNew(string partcode, string StartDate, string EndDate)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_SearchByPartCodeNew", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@partscode", partcode));
                cmd.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                cmd.Parameters.Add(new SqlParameter("@EndDate", EndDate));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable PROGRAMHISTORY_SearchByParts01( string dt1, string dt2)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_SearchByParts01", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add(new SqlParameter("@starttime", dt1));
                cmd.Parameters.Add(new SqlParameter("@endtime", dt2));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        #endregion
        public void PROGRAMHISTORY_Insert(PROGRAMHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));
                cmd.Parameters.Add(new SqlParameter("@ndesc", data.ndesc));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));
                cmd.Parameters.Add(new SqlParameter("@checkedby", data.checkedby));
                cmd.Parameters.Add(new SqlParameter("@checkedtime", data.checkedtime));
                cmd.Parameters.Add(new SqlParameter("@rp", data.rp));
                cmd.Parameters.Add(new SqlParameter("@rep1", data.rep1));
                cmd.Parameters.Add(new SqlParameter("@rep2", data.rep2));
                cmd.Parameters.Add(new SqlParameter("@rep3", data.rep3));
                cmd.Parameters.Add(new SqlParameter("@rep4", data.rep4));
                cmd.Parameters.Add(new SqlParameter("@rep5", data.rep5));
                cmd.Parameters.Add(new SqlParameter("@reqqty", data.reqqty));
                cmd.Parameters.Add(new SqlParameter("@datecode", data.datecode));
                cmd.Parameters.Add(new SqlParameter("@changedby", data.changedby));
                cmd.Parameters.Add(new SqlParameter("@changedtime", data.changedtime));

				//cmd.Parameters.Add(new SqlParameter("@IDMetarial", data.IDMetarial));
				//cmd.Parameters.Add(new SqlParameter("@Field01", data.Field01));
				//cmd.Parameters.Add(new SqlParameter("@Field02", data.Field02));
				cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Update Data
        public void PROGRAMHISTORY_Update(PROGRAMHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));
                cmd.Parameters.Add(new SqlParameter("@ndesc", data.ndesc));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));
                cmd.Parameters.Add(new SqlParameter("@checkedby", data.checkedby));
                cmd.Parameters.Add(new SqlParameter("@checkedtime", data.checkedtime));
                cmd.Parameters.Add(new SqlParameter("@rp", data.rp));
                cmd.Parameters.Add(new SqlParameter("@rep1", data.rep1));
                cmd.Parameters.Add(new SqlParameter("@rep2", data.rep2));
                cmd.Parameters.Add(new SqlParameter("@rep3", data.rep3));
                cmd.Parameters.Add(new SqlParameter("@rep4", data.rep4));
                cmd.Parameters.Add(new SqlParameter("@rep5", data.rep5));
                cmd.Parameters.Add(new SqlParameter("@reqqty", data.reqqty));
                cmd.Parameters.Add(new SqlParameter("@datecode", data.datecode));
                cmd.Parameters.Add(new SqlParameter("@changedby", data.changedby));
                cmd.Parameters.Add(new SqlParameter("@changedtime", data.changedtime));

				//cmd.Parameters.Add(new SqlParameter("@IDMetarial", data.IDMetarial));
				//cmd.Parameters.Add(new SqlParameter("@Field01", data.Field01));
				//cmd.Parameters.Add(new SqlParameter("@Field02", data.Field02));
				cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Delete Data
        public void PROGRAMHISTORY_Delete(PROGRAMHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Get By ID
        public DataTable PROGRAMHISTORY_GetByID(PROGRAMHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_GetByID", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Get By All
        public DataTable PROGRAMHISTORY_GetByAll()
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_GetByAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Get by Top
        public DataTable PROGRAMHISTORY_GetByTop(string Top, string Where, string Order)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_GetByTop", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@Top", Top));
                cmd.Parameters.Add(new SqlParameter("@Where", Where));
                cmd.Parameters.Add(new SqlParameter("@Order", Order));
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Search
        public DataTable PROGRAMHISTORY_Search(string Condition)
        {
            using (var cmd = new SqlCommand("sp_PROGRAMHISTORY_Search", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@Condition", Condition));
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
