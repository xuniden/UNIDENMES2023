using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMTPROGRAM_Da;
using System.Diagnostics;

namespace SMTPROGRAM_Bu
{    
    public class Smt_Repair_Services
    {
        public static readonly Smt_Repair_Controller db = new Smt_Repair_Controller();
        public static void Smt_Repair_Bom_Insert(Smt_Repair_Info data)
        {
            db.Smt_Repair_Bom_Insert(data);
        }
        public static void Smt_Repair_Bom_Delete(Smt_Repair_Info data)
        {
            db.Smt_Repair_Bom_Delete(data);
        }
        public static DataTable Smt_Repair_Bom_ViewAll(int Option, Smt_Repair_Info data           )
        {
            return db.Smt_Repair_Bom_ViewAll(Option, data);
        }

        public static DataTable Smt_Repair_Bom_Check(int Option, Smt_Repair_Info data)
        {
            return db.Smt_Repair_Bom_Check(Option, data);
        }
        //-------------------------------------------------------

        public static void Smt_Repair_Error_Code_Insert(Smt_Repair_Info data)
        {
            db.Smt_Repair_Error_Code_Insert(data);
        }
        public static void Smt_Repair_Error_Code_Delete(Smt_Repair_Info data)
        {
            db.Smt_Repair_Error_Code_Delete(data);
        }

        public static void Smt_Repair_Error_Code_Update(Smt_Repair_Info data)
        {
            db.Smt_Repair_Error_Code_Update(data);
        }

        public static DataTable Smt_Repair_Error_Code_ViewAll(int Option, Smt_Repair_Info data)
        {
            return db.Smt_Repair_Error_Code_ViewAll(Option, data);
        }

        public static DataTable Smt_Repaire_DeptCause_ViewAll()
        {
            return db.Smt_Repaire_DeptCause_ViewAll();
        }
        public static DataTable Smt_Repair_Cause_ViewAll()
        {
            return db.Smt_Repair_Cause_ViewAll();
        }
        public static DataTable Smt_Repair_Cause_ViewByCode(string CauseError)
        {
            return db.Smt_Repair_Cause_ViewByCode(CauseError);
        }
    }
}
