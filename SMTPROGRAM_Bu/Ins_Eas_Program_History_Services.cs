using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Bu
{
    public class Ins_Eas_Program_History_Services 
    {
        public static readonly Ins_Eas_Program_History_Controller db = new Ins_Eas_Program_History_Controller();

        public static void INSERT_PROGRAMHISTORY_Insert(Ins_Eas_Program_History_Info data)
        {
            db.INSERT_PROGRAMHISTORY_Insert(data);
        }
    }
}
