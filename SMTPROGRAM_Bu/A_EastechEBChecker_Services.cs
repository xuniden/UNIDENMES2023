using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Bu
{
    public class A_EastechEBChecker_Services
    {
        public static readonly A_EastechEBChecker_Controller db = new A_EastechEBChecker_Controller();
        public static void A_EastechEBChecker_Insert(A_EastechEBChecker_Info data)
        {
            db.A_EastechEBChecker_Insert(data);
        }
        public static void A_EastechEBChecker_Update(A_EastechEBChecker_Info data)
        {
            db.A_EastechEBChecker_Update(data);
        }

        public static DataTable A_EastechEBChecker_Check(string Serial)
        {
            return db.A_EastechEBChecker_Check(Serial);
        }
    }
}
