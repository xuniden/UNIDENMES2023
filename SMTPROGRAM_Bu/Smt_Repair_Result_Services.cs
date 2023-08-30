using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace SMTPROGRAM_Bu
{
    public class Smt_Repair_Result_Services
    {
        public static readonly Smt_Repair_Result_Controller db = new Smt_Repair_Result_Controller();
        public static void Smt_Repair_Result_Insert(Smt_Repair_Result_Info data)
        {
            db.Smt_Repair_Result_Insert(data);
        }

        public static void Smt_Repair_Result_Update(Smt_Repair_Result_Info data)
        {
            db.Smt_Repair_Result_Update(data);

        }

        public static void Smt_Repair_Result_Delete(Smt_Repair_Result_Info data)
        {
            db.Smt_Repair_Result_Delete(data);

        }

        public static DataTable Smt_Repair_Result_ViewAll(int Option, Smt_Repair_Result_Info data, string DateFrom, string DateTo)
        {
            return db.Smt_Repair_Result_ViewAll(Option, data, DateFrom, DateTo);
        }
        public static DataTable Smt_Repair_Result_ViewByDept(string Dept)
        {
            return db.Smt_Repair_Result_ViewByDept(Dept);
        }

        public static DataTable sp_Smt_Repair_Result_GroupDept()
        {
            return db.sp_Smt_Repair_Result_GroupDept();
        }

        public static DataTable sp_Smt_Repair_Result_SearchByDeptDate(string Dept, string From, string Too)
        {
            return db.sp_Smt_Repair_Result_SearchByDeptDate(Dept, From, Too);
        }
    }
}
