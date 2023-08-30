using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMTPROGRAM_Da;
namespace SMTPROGRAM_Bu
{
    public class USERService
    {

        public static readonly USERDAL db = new USERDAL();
        public static int CheckLogin(string username, string password)
        {
            return db.CheckLogin(username, password);
        }

        #region Insert Data
        public static void USER_Insert(UserInfo data)
        {
            db.USER_Insert(data);

        }
        #endregion

        #region Update Data
        public static void USER_Update(UserInfo data)
        {
            db.USER_Update(data);

        }
        #endregion

        #region Delete Data
        public static void USER_Delete(UserInfo data)
        {
            db.USER_Delete(data);

        }
        #endregion
        #region Get By UserName
        public static DataTable USER_GetByUser(UserInfo data)
        {
            return db.USER_GetByUser(data);
        }
        #endregion
        #region Get By ID
        //public static DataTable USER_GetByID(UserInfo data)
        //{
        //    return db.USER_GetByID(data);

        //}
        #endregion

        #region Get By All
        public static DataTable USER_GetByAll()
        {
            return db.USER_GetByAll();

        }
        #endregion

        #region Get By Top
        public static DataTable USER_GetByTop(string Top, string Where, string Order)
        {
            return db.USER_GetByTop(Top, Where, Order);

        }
        #endregion

        #region Get By Top
        public static DataTable USER_Search(string Condition)
        {
            return db.USER_Search(Condition);

        }
        #endregion

    }

}
