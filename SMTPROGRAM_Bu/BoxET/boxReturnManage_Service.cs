using SMTPROGRAM_Da.BoxET;
using System.Data;

namespace SMTPROGRAM_Bu.BoxET
{
    public class boxReturnManage_Service
    {
        public static readonly boxReturnManage_Control db = new boxReturnManage_Control();

        public static void boxIssueManage_Insert(boxReturnManage boxReturnManage )
        {
            db.boxReturnManage_Insert(boxReturnManage);
        }
        public static DataTable boxReturnManage_getListByUserAndDate(string ReturnBy)
        {
            return db.boxReturnManage_getListByUserAndDate(ReturnBy);
        }
    }
}
