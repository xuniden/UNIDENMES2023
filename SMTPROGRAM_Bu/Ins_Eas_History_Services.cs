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
   public class Ins_Eas_History_Services
    {
        public static readonly Ins_Eas_History_Controller db= new Ins_Eas_History_Controller();

        
        public static DataTable INS_EAS_PROGRAM_OUTPUT_CheckSubKeyNumber(string InPsubkey)
        {
            return db.INS_EAS_PROGRAM_OUTPUT_CheckSubKeyNumber(InPsubkey);
        }

        public static void INS_EAS_PROGRAM_OUTPUT_Insert(Ins_Eas_History_Info data)
        {
            db.INS_EAS_PROGRAM_OUTPUT_Insert(data);
        }


    }
}
