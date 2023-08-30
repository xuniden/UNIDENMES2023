using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Bu
{
    public class SessionLogin_Services
    {
        public static readonly SessionLogin_Controller db = new SessionLogin_Controller();
        public static void tbl_SessionLogin_Insert(SessionLogin_Info data)
        {
            db.tbl_SessionLogin_Insert(data);
        }

        public static void tbl_SessionLogin_Delete(string UserId)
        {
            db.tbl_SessionLogin_Delete(UserId);
        }
        public static DataTable tbl_SessionLogin_Select(string UserId)
        {
            return db.tbl_SessionLogin_Select(UserId);
        }

        public static DataTable tbl_SessionLogin_GetAll()
        {
            return db.tbl_SessionLogin_GetAll();
        }


    }
}
