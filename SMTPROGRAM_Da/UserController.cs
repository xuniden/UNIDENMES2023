using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Da
{
    public class USERDAL : SqlDataProvider
    {
        public int CheckLogin(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("sp_TBLUSER_CheckLogin", SqlDataProvider.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
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
        public void USER_Insert(UserInfo data)
        {
            using (var cmd = new SqlCommand("sp_TBLUSER_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add(new SqlParameter("@username", data.username));
                cmd.Parameters.Add(new SqlParameter("@password", data.password));
                cmd.Parameters.Add(new SqlParameter("@fullname", data.fullname));
                cmd.Parameters.Add(new SqlParameter("@idnumber", data.idnumber));
                cmd.Parameters.Add(new SqlParameter("@permission", data.permission));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));
                cmd.Parameters.Add(new SqlParameter("@Dept", data.Dept));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Update Data
        public void USER_Update(UserInfo data)
        {
            using (var cmd = new SqlCommand("sp_TBLUSER_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add(new SqlParameter("@username", data.username));
                cmd.Parameters.Add(new SqlParameter("@password", data.password));
                cmd.Parameters.Add(new SqlParameter("@fullname", data.fullname));
                cmd.Parameters.Add(new SqlParameter("@idnumber", data.idnumber));
                cmd.Parameters.Add(new SqlParameter("@permission", data.permission));
                cmd.Parameters.Add(new SqlParameter("@Status", data.Status));
                cmd.Parameters.Add(new SqlParameter("@CreateDate", data.CreateDate));
                cmd.Parameters.Add(new SqlParameter("@Dept", data.Dept));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion

        #region Delete Data
        public void USER_Delete(UserInfo data)
        {
            using (var cmd = new SqlCommand("sp_TBLUSER_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", data.username));
                cmd.ExecuteNonQuery();
            }

        }
        #endregion
        #region Get By Username
        public DataTable USER_GetByUser(UserInfo data)
        {
            using (var cmd = new SqlCommand("sp_TBLUSER_GetByUser", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", data.username));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
        #region Get By ID
        //public DataTable USER_GetByID(UserInfo data)
        //{
        //    using (var cmd = new SqlCommand("sp_TBLUSER_GetByID", GetConnection()))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@username", data.username));
        //        var da = new SqlDataAdapter(cmd);
        //        var dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}
        #endregion

        #region Get By All
        public DataTable USER_GetByAll()
        {
            using (var cmd = new SqlCommand("sp_TBLUSER_GetByAll", GetConnection()))
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
        public DataTable USER_GetByTop(string Top, string Where, string Order)
        {
            using (var cmd = new SqlCommand("sp_TBLUSER_GetByTop", GetConnection()))
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
        public DataTable USER_Search(string username)
        {
            using (var cmd = new SqlCommand("sp_TBLUSER_Search", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}
