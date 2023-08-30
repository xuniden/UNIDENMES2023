using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMTPROGRAM_Da;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Bu
{
    public class Uv_Department_Services
    {
        public static readonly Uv_Department_Controller db = new Uv_Department_Controller();
        public static void UvDepartment(int Option, Uv_Department_Info inf)
        {
            db.UvDepartment(Option, inf);
        }
        public static DataTable UvDepartment_TimKiem(int Option, Uv_Department_Info inf)
        {
            return db.UvDepartment_Timkiem(Option, inf);
        }
    }
}
