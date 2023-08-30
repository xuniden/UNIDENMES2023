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
   public class AssyOperatorProcess_Services
    {
        public static readonly AssyOperatorProcess_Controller db = new AssyOperatorProcess_Controller();
        public static void AssyOperatorProcess_Insert(AssyOperatorProcess_Info data)
        {
            db.AssyOperatorProcess_Insert(data);
        }

        public static int AssyOperatorProcessData_CheckFCT(string FSerial, string FRemark)
        {
            return db.AssyOperatorProcessData_CheckFCT(FSerial, FRemark);
        }
        
            public static void AssyOperatorProcess_Update(AssyOperatorProcess_Info data)
        {
            db.AssyOperatorProcess_Update(data);
        }

        //public static void AssyOperatorProcess_InsertNew(AssyOperatorProcess_Info data)
        //{
        //    db.AssyOperatorProcess_InsertNew(data);
        //}

        //public static void AssyOperatorProcess_UpdateNew(AssyOperatorProcess_Info data)
        //{
        //    db.AssyOperatorProcess_UpdateNew(data);
        //}
        public static DataTable AssyOperatorProcessData_CoutByUser(string Checker, string DateT)
        {
            return db.AssyOperatorProcessData_CoutByUser(Checker, DateT);
        }
        public static DataTable AssyOperatorProcessData_CheckProcess(string QrCode,string Process)
        {
            return db.AssyOperatorProcessData_CheckProcess(QrCode,Process);
        }
        public static DataTable AssyOperatorProcessData_GetModel(string Model, string TypePCB, DateTime FromDate, DateTime ToDate)
        {
            return db.AssyOperatorProcessData_GetModel(Model, TypePCB, FromDate, ToDate);
        }
        public static DataTable AssyOperatorProcessData_GetMIAN(string Model, string TypePCB, DateTime FromDate, DateTime ToDate)
        {
            return db.AssyOperatorProcessData_GetMAIN(Model, TypePCB, FromDate, ToDate);
        }
        public static DataTable AssyOperatorProcessData_GetAMP(string Model, string TypePCB, DateTime FromDate, DateTime ToDate)
        {
            return db.AssyOperatorProcessData_GetAMP(Model, TypePCB, FromDate, ToDate);
        }
        public static DataTable AssyOperatorProcessData_GetPSU(string Model, string TypePCB, DateTime FromDate, DateTime ToDate)
        {
            return db.AssyOperatorProcessData_GetPSU(Model, TypePCB, FromDate, ToDate);
        }

        public static DataTable AssyOperatorProcessData_GetModelAll(string Model)
        {
            return db.AssyOperatorProcessData_GetModelAll(Model);
        }
        public static DataTable AssyOperatorProcessData_GetSearch(string Model, string TypePCB, string FromDate, string ToDate)
        {
            return db.AssyOperatorProcessData_GetSearch(Model, TypePCB, FromDate, ToDate);
        }
        public static DataTable A_EastechCheckFCT_MAIN(string QRCode)
        {
            return db.A_EastechCheckFCT_MAIN(QRCode);
        }
    }
}
