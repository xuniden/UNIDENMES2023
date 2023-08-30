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
    public class PROGRAMHISTORYService
    {

        public static readonly PROGRAMHISTORYDAL db = new PROGRAMHISTORYDAL();

        public static DataTable PROGRAMHISTORY_SearchByParts(string pr, string dt1, string dt2)
        {
            return db.PROGRAMHISTORY_SearchByParts(pr,dt1,dt2);

        }
        public static DataTable PROGRAMHISTORY_SearchByPartCode(string partcode)
        {
            return db.PROGRAMHISTORY_SearchByPartCode(partcode);
        }
        public static DataTable PROGRAMHISTORY_SearchByPartCodeNew(string partcode, string StartDate, string EndDate)
        {
            return db.PROGRAMHISTORY_SearchByPartCodeNew(partcode, StartDate,EndDate);
        }
        public static DataTable PROGRAMHISTORY_SearchByParts01( string dt1, string dt2)
        {
            return db.PROGRAMHISTORY_SearchByParts01( dt1, dt2);

        }
        #region Insert Data
        public static void PROGRAMHISTORY_Insert(PROGRAMHISTORYInfo data)
        {
            db.PROGRAMHISTORY_Insert(data);

        }
        #endregion

        #region Update Data
        public static void PROGRAMHISTORY_Update(PROGRAMHISTORYInfo data)
        {
            db.PROGRAMHISTORY_Update(data);

        }
        #endregion

        #region Delete Data
        public static void PROGRAMHISTORY_Delete(PROGRAMHISTORYInfo data)
        {
            db.PROGRAMHISTORY_Delete(data);

        }
        #endregion

        #region Get By ID
        public static DataTable PROGRAMHISTORY_GetByID(PROGRAMHISTORYInfo data)
        {
            return db.PROGRAMHISTORY_GetByID(data);

        }
        #endregion

        #region Get By All
        public static DataTable PROGRAMHISTORY_GetByAll()
        {
            return db.PROGRAMHISTORY_GetByAll();

        }
        #endregion

        #region Get By Top
        public static DataTable PROGRAMHISTORY_GetByTop(string Top, string Where, string Order)
        {
            return db.PROGRAMHISTORY_GetByTop(Top, Where, Order);

        }
        #endregion

        #region Get By Top
        public static DataTable PROGRAMHISTORY_Search(string Condition)
        {
            return db.PROGRAMHISTORY_Search(Condition);

        }
        #endregion

    }

}
