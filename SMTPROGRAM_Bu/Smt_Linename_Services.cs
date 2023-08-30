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
    public class Smt_Linename_Services
    {
        public static readonly Smt_Line_Controller db = new Smt_Line_Controller();
        public static DataTable Linename(string linename)
        {
            return db.Linename(linename);
        }
    }
}
