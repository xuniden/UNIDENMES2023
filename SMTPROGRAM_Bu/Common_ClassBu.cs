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
    public class Common_ClassBu
    {
        public static readonly Common_ClassDA db = new Common_ClassDA();
        public static DataTable GetQrCodeNotYetScan(int Option, string FromDate, string ToDate)
        {
            return db.GetQrCodeNotYetScan(Option, FromDate, ToDate);
        }
        public static DateTime getServerDateTime()
        {
            return db.getServerDateTime();
        }
    }
}
