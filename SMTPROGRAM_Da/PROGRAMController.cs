using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class PROGRAMDAL : SqlDataProvider
    {
        #region Check Partcode
        public int PROGRAM_CheckPartcode(string pgl, string feed, string partcode)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_CheckInput", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", pgl));
                cmd.Parameters.Add(new SqlParameter("@fdrno", feed));
                cmd.Parameters.Add(new SqlParameter("@partscode", partcode));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return 1;
                }
                return -1;
            }

        }
        #endregion
        #region Check Feed
        public int PROGRAM_CheckFeed(string pgl, string feed)
        {
            //sp_PROGRAM_CheckPRGList
            SqlCommand cmd = new SqlCommand("sp_PROGRAM_CheckFeed", SqlDataProvider.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@programpartlist", pgl));
            cmd.Parameters.Add(new SqlParameter("@fdrno", feed));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        #endregion
        #region Check Program Part List
        public int PROGRAM_CheckPRGList(string pgl)
        {
            //sp_PROGRAM_CheckPRGList
            SqlCommand cmd = new SqlCommand("sp_PROGRAM_CheckPRGList", SqlDataProvider.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@programpartlist", pgl));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }
        #endregion


        public int PROGRAM_CheckKeyUpload(string pgrpartslist)
        {
            SqlCommand cmd = new SqlCommand("sp_PROGRAM_CheckKeyUpload", SqlDataProvider.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@programpartlist", pgrpartslist));            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            return -1;
        }

        #region Insert Data
//sp_PROGRAM_CheckInput
        public DataTable PROGRAM_SearchByPartList(int option,string pr, string dt1, string dt2)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_SearchByPartList", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@option", option));
                cmd.Parameters.Add(new SqlParameter("@programpartlist", pr));
                cmd.Parameters.Add(new SqlParameter("@start", dt1));
                cmd.Parameters.Add(new SqlParameter("@endd", dt2));
                //cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }
        public DataTable PROGRAM_CheckInput(PROGRAMInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_CheckInput", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));                
                //cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

        }
        public void PROGRAM_Insert(PROGRAMInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));
                cmd.Parameters.Add(new SqlParameter("@ndesc", data.ndesc));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));
                cmd.Parameters.Add(new SqlParameter("@rp", data.rp));
                cmd.Parameters.Add(new SqlParameter("@rep1", data.rep1));
                cmd.Parameters.Add(new SqlParameter("@rep2", data.rep2));
                cmd.Parameters.Add(new SqlParameter("@rep3", data.rep3));
                cmd.Parameters.Add(new SqlParameter("@rep4", data.rep4));
                cmd.Parameters.Add(new SqlParameter("@rep5", data.rep5));
                cmd.Parameters.Add(new SqlParameter("@reqqty", data.reqqty));
                cmd.Parameters.Add(new SqlParameter("@datecode", data.datecode));
                cmd.Parameters.Add(new SqlParameter("@dateupdate", data.dateupdate));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Update Data
        public void PROGRAM_Update(PROGRAMInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.Parameters.Add(new SqlParameter("@fdrno", data.fdrno));
                cmd.Parameters.Add(new SqlParameter("@partscode", data.partscode));
                cmd.Parameters.Add(new SqlParameter("@ndesc", data.ndesc));
                cmd.Parameters.Add(new SqlParameter("@usage", data.usage));
                cmd.Parameters.Add(new SqlParameter("@rp", data.rp));
                cmd.Parameters.Add(new SqlParameter("@rep1", data.rep1));
                cmd.Parameters.Add(new SqlParameter("@rep2", data.rep2));
                cmd.Parameters.Add(new SqlParameter("@rep3", data.rep3));
                cmd.Parameters.Add(new SqlParameter("@rep4", data.rep4));
                cmd.Parameters.Add(new SqlParameter("@rep5", data.rep5));
                cmd.Parameters.Add(new SqlParameter("@reqqty", data.reqqty));
                cmd.Parameters.Add(new SqlParameter("@datecode", data.datecode));
                cmd.Parameters.Add(new SqlParameter("@dateupdate", data.dateupdate));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Delete Data
        public void PROGRAM_Delete(PROGRAMInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Delete Program By Key
        public void PROGRAM_DeleteByKey(PROGRAMInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_DeleteByKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@programpartlist", data.programpartlist));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Get By ID
        public DataTable PROGRAM_GetByID(PROGRAMInfo data)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_GetByID", GetConnection()))
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
        public DataTable PROGRAM_GetByAll()
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_GetByAll", GetConnection()))
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
        public DataTable PROGRAM_GetByTop(string Top, string Where, string Order)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_GetByTop", GetConnection()))
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
        public DataTable PROGRAM_Search(string Condition)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_Search", GetConnection()))
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

        // sp_PROGRAM_GetByProgramKey
        #region Tim kiếm dữ liệu theo tên chương trình
        public DataTable PROGRAM_GetByProgramKey(string ProgramKey)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_GetByProgramKey", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@programpartlist", ProgramKey));
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        // sp_PROGRAM_GetPositionByProgramAndPartcode
        #region Tim kiếm dữ liệu theo tên chương trình và partcode để lấy ra nhiều vị trí cho insert
        public DataTable PROGRAM_GetPositionByProgramAndPartcode(string ProgramKey, string PartCode)
        {
            using (var cmd = new SqlCommand("sp_PROGRAM_GetPositionByProgramAndPartcode", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@programpartlist", ProgramKey));
                cmd.Parameters.Add(new SqlParameter("@partscode", PartCode));
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
