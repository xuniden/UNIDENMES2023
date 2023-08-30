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
    public class PROGRAMService
    {

        public static readonly PROGRAMDAL db = new PROGRAMDAL();

        public static int PROGRAM_CheckPartcode(string pgl, string feed, string partcode)
        {
            return db.PROGRAM_CheckPartcode(pgl, feed, partcode);
        }
        public static int PROGRAM_CheckFeed(string pgl, string feed)
        {
            return db.PROGRAM_CheckFeed(pgl,feed);
        }
        public static int PROGRAM_CheckPRGList(string pgl)
        {
            return db.PROGRAM_CheckPRGList(pgl);
        }

        public static int PROGRAM_CheckKeyUpload(string pgrpartslist)
        {
            return db.PROGRAM_CheckKeyUpload(pgrpartslist);
        }
        public static DataTable PROGRAM_SearchByPartList(int option,string pr, string dt1, string dt2)
        {
            return db.PROGRAM_SearchByPartList(option,pr, dt1, dt2);
        }

        public static DataTable PROGRAM_CheckInput(PROGRAMInfo data)
        {
          return   db.PROGRAM_CheckInput(data);
        }


        #region Insert Data
        public static void PROGRAM_Insert(PROGRAMInfo data)
        {
            db.PROGRAM_Insert(data);

        }
        #endregion

        #region Update Data
        public static void PROGRAM_Update(PROGRAMInfo data)
        {
            db.PROGRAM_Update(data);

        }
        #endregion

        #region Delete Data
        public static void PROGRAM_Delete(PROGRAMInfo data)
        {
            db.PROGRAM_Delete(data);

        }
        #endregion

        #region Delete Program By Key
        public static void PROGRAM_DeleteByKey(PROGRAMInfo data)
        {
            db.PROGRAM_Delete(data);

        }
        #endregion

        #region Get By ID
        public static DataTable PROGRAM_GetByID(PROGRAMInfo data)
        {
            return db.PROGRAM_GetByID(data);

        }
        #endregion

        #region Get By All
        public static DataTable PROGRAM_GetByAll()
        {
            return db.PROGRAM_GetByAll();

        }
        #endregion

        #region Get By Top
        public static DataTable PROGRAM_GetByTop(string Top, string Where, string Order)
        {
            return db.PROGRAM_GetByTop(Top, Where, Order);

        }
        #endregion

        #region Get By Top
        public static DataTable PROGRAM_Search(string Condition)
        {
            return db.PROGRAM_Search(Condition);

        }
        #endregion
        public static DataTable PROGRAM_GetByProgramKey(string ProgramKey)
        {
            return db.PROGRAM_GetByProgramKey(ProgramKey);
        }

        public static DataTable PROGRAM_GetPositionByProgramAndPartcode(string ProgramKey, string PartCode)
        {
            return db.PROGRAM_GetPositionByProgramAndPartcode(ProgramKey, PartCode);
        }
    }

}
