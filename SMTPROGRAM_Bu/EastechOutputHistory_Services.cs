using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMTPROGRAM_Da;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace SMTPROGRAM_Bu
{
    public class EastechOutputHistory_Services
    {
        public static readonly EastechOutputHistory_Controller db = new EastechOutputHistory_Controller();
        public static void EastechOutputHistory_AllInsertUpdateCount(string QrCode, string programpartlist, string LineName, string Model, string Remark, string Remark1, string Remark2, string Remark3, string Remark4, string Remark5)
        {
            db.EastechOutputHistory_AllInsertUpdateCount(QrCode, programpartlist, LineName, Model, Remark, Remark1, Remark2, Remark3, Remark4, Remark5);
        }
        public static void EastechOutputHistory_Insert(EastechOutputHistory_Info data)
        {
            db.EastechOutputHistory_Insert(data);
        }
        public static DataTable EastechOutputHistory_Smt_CheckQRCode(string QRCode)
        {
            return db.EastechOutputHistory_Smt_CheckQRCode(QRCode);
        }

        public static DataTable EastechHistory_smt_CheckQRCodeRemark(string QRCode, string Remark3)
        {
            return db.EastechHistory_smt_CheckQRCodeRemark(QRCode,Remark3);
        }

        public static int EastechOutputHistory_Count(string programkey, string Remark)
        {
            return db.EastechHOutistory_Count(programkey, Remark);
        }
        public static DataTable EastechHOutistory_Count2(string pgkey1, string pgkey2, string remark)
        {
            return db.EastechHOutistory_Count2(pgkey1, pgkey2, remark);
        }

        public static DataTable EastechOutputHistory_ListQrByUser(string programkey, string QRCode, string Remark)
        {
            return db.EastechOutputHistory_ListQrByUser(programkey, QRCode, Remark);
        }
        public static DataTable EastechOutputHistory_ListQrByUser2(string pgkey1, string pgkey2, string QRCode, string Remark, DateTime DateT)
        {
            return db.EastechOutputHistory_ListQrByUser2(pgkey1, pgkey2, QRCode, Remark,DateT);
        }
        public static long EastechOutputHistory_CountMaterialOfQRcode(string pgkey1, string pgkey2, string QRCode, string Remark, DateTime DateT)
        {
            return db.EastechOutputHistory_CountMaterialOfQRcode(pgkey1, pgkey2, QRCode, Remark, DateT);
        }
        public static DataTable EastechOutputHistory_ListQrByUser1(string programkey,  string Remark)
        {
            return db.EastechOutputHistory_ListQrByUser1(programkey, Remark);
        }

        public static DataTable EastechOutputHistory_CheckMatPcb(string programkey)
        {
            return db.EastechOutputHistory_CheckMatPcb(programkey);
        }
        public static DataTable EastechOutputHistory_Check2Face(string qrcode)
        {
            return db.EastechOutputHistory_Check2Face(qrcode);
        }
        public static DataTable EastechOutputHistory_Check2FaceNew(string qrcode, string Remark4)
        {
            return db.EastechOutputHistory_Check2FaceNew(qrcode, Remark4);
        }
        public static DataTable EastechHistory_smt_CheckQRCodeFeeder(string Program,string qrcode, string feeder)
        {
            return db.EastechHistory_smt_CheckQRCodeFeeder(Program, qrcode, feeder);
        }
        public static DataTable EastechHistory_getSelectedData(string Program, string Remark1)
        {
            return db.EastechHistory_getSelectedData(Program, Remark1);
        }
        public static void sp_EastechOutputHistory_InsertSelectData(EastechOutputHistory_Info data)
        {
            db.sp_EastechOutputHistory_InsertSelectData(data);
        }
        public static long EastechHOutistory_CountQRCodeByUser(string pgkey1, string pgkey2, string Remark)
        {
            return db.EastechHOutistory_CountQRCodeByUser(pgkey1, pgkey2, Remark);
        }

        public static long EastechErrorLog(string staffid, string dept, string linename,string errordetail, DateTime createddate,string QrCode)
        {
            return db.EastechErrorLog(staffid, dept,linename, errordetail, createddate,QrCode);
        }
        public static void EastechErrorLog_Update(long id, string approve, string remark, DateTime approvedate)
        {
            db.EastechErrorLog_Update(id,approve, remark, approvedate);
        }
        public static DataTable EastechErrorLog_CheckUpdate(long Id)
        {
            return db.EastechErrorLog_CheckUpdate(Id);
        }


        public static DataTable LeaderEastechErrorLogCheckID(string staffId)
        {
            return db.LeaderEastechErrorLogCheckID(staffId);
        }
        public void AddApproveStaff(string staffid, string staffname)
        {
            db.AddApproveStaff(staffid, staffname);
        }
    }
}
