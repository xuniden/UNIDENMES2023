using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMTPROGRAM_Da;

namespace SMTPROGRAM_Bu
{
    public class Insert_Program_Services
    {
        public static readonly Insert_Program_Controller db = new Insert_Program_Controller();
        public static void INSERT_PROGRAM_Insert(Insert_Program_Info data)
        {
            db.INSERT_PROGRAM_Insert(data);
        }
        public static DataTable INSER_PROGRAM_CheckKeyUpload(string InProgram)
        {
            return db.INSER_PROGRAM_CheckKeyUpload(InProgram);
        }

        public static void INSERT_PROGRAM_DeleteByKey(string InProgram)
        {
            db.INSERT_PROGRAM_DeleteByKey(InProgram);
        }

        public static DataTable INSER_PROGRAM_CheckKeyPosition ( string InProgram, string InPosition)
        {
            return db.INSER_PROGRAM_CheckKeyPosition(InProgram, InPosition);
        }
        public static DataTable INSERT_PROGRAM_CheckPartcode(string InProgram, string InPosition, string InPartcode)
        {
            return db.INSERT_PROGRAM_CheckPartcode(InProgram, InPosition, InPartcode);
        }
    }
}
