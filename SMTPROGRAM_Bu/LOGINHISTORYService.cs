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
    public class LOGINHISTORYService
    {

        public static readonly LOGINHISTORYDAL db = new LOGINHISTORYDAL();

        #region Insert Data
        public static void LOGINHISTORY_Insert(LOGINHISTORYInfo data)
        {
            db.LOGINHISTORY_Insert(data);

        }
        #endregion

        #region Update Data
        public static void LOGINHISTORY_Update(LOGINHISTORYInfo data)
        {
            db.LOGINHISTORY_Update(data);

        }
        #endregion

        #region Delete Data
        public static void LOGINHISTORY_Delete(LOGINHISTORYInfo data)
        {
            db.LOGINHISTORY_Delete(data);

        }
        #endregion

        #region Get By ID
        public static DataTable LOGINHISTORY_GetByID(LOGINHISTORYInfo data)
        {
            return db.LOGINHISTORY_GetByID(data);

        }
        #endregion

        #region Get By All
        public static DataTable LOGINHISTORY_GetByAll()
        {
            return db.LOGINHISTORY_GetByAll();

        }
        #endregion

        #region Get By Top
        public static DataTable LOGINHISTORY_GetByTop(string Top, string Where, string Order)
        {
            return db.LOGINHISTORY_GetByTop(Top, Where, Order);

        }
        #endregion

        #region Get By Top
        public static DataTable LOGINHISTORY_Search(string Condition)
        {
            return db.LOGINHISTORY_Search(Condition);

        }
        #endregion

    }

}
