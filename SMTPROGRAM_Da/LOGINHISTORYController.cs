using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class LOGINHISTORYDAL : SqlDataProvider
    {

        #region Insert Data
        public void LOGINHISTORY_Insert(LOGINHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_LOGINHISTORY_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", data.ID));
                cmd.Parameters.Add(new SqlParameter("@LOGINTIME", data.LOGINTIME));
                cmd.Parameters.Add(new SqlParameter("@LONGINUSER", data.LONGINUSER));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Update Data
        public void LOGINHISTORY_Update(LOGINHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_LOGINHISTORY_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", data.ID));
                cmd.Parameters.Add(new SqlParameter("@LOGINTIME", data.LOGINTIME));
                cmd.Parameters.Add(new SqlParameter("@LONGINUSER", data.LONGINUSER));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Delete Data
        public void LOGINHISTORY_Delete(LOGINHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_LOGINHISTORY_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", data.ID));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Get By ID
        public DataTable LOGINHISTORY_GetByID(LOGINHISTORYInfo data)
        {
            using (var cmd = new SqlCommand("sp_LOGINHISTORY_GetByID", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", data.ID));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region Get By All
        public DataTable LOGINHISTORY_GetByAll()
        {
            using (var cmd = new SqlCommand("sp_LOGINHISTORY_GetByAll", GetConnection()))
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
        public DataTable LOGINHISTORY_GetByTop(string Top, string Where, string Order)
        {
            using (var cmd = new SqlCommand("sp_LOGINHISTORY_GetByTop", GetConnection()))
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
        public DataTable LOGINHISTORY_Search(string Condition)
        {
            using (var cmd = new SqlCommand("sp_LOGINHISTORY_Search", GetConnection()))
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
