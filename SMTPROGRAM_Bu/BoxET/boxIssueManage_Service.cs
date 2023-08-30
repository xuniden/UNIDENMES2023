using SMTPROGRAM_Da.BoxET;
using System;
using System.Data;

namespace SMTPROGRAM_Bu.BoxET
{
    public class boxIssueManage_Service
    {
        public static readonly boxIssueManage_Control db = new boxIssueManage_Control();

        public static void boxIssueManage_Insert(boxIssueManage boxIssueManage)
        {
            db.boxIssueManage_Insert(boxIssueManage);
        }
        public static DataTable boxIssueManage_getListByUserAndDate(string IssueBy)
        {
            return db.boxIssueManage_getListByUserAndDate(IssueBy);
        }
        public static DataTable boxIssueManage_CheckExists(string IssueSerial)
        {
            return db.boxIssueManage_CheckExists(IssueSerial);
        }
        public static void boxIssueManage_UpdateByStatus(string IssueSerial, bool IssueStatus)
        {
            db.boxIssueManage_UpdateByStatus(IssueSerial, IssueStatus);
        }
        public static DataTable boxReportManage(int Option, string Serial, DateTime fromDate, DateTime toDate)
        {
            return db.boxReportManage(Option, Serial, fromDate, toDate);
        }

        public static DataTable boxETManage_IssueNotReutn()
        {
            return db.boxETManage_IssueNotReutn();
        }
    }
}
