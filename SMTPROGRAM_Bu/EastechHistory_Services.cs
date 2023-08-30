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
    public class EastechHistory_Services
    {
        public static readonly EastechHistory_Controller db = new EastechHistory_Controller();
        public static void EastechHistory_BKInsert(EastechHistory_Info data)
        {
            db.EastechHistory_BKInsert(data);
        }
        public static DataTable EastechHistory_CombineProgramNonQRCode(string New_programpartlist, string Old_programpartlist, string Old_Line)
        {
            return db.EastechHistory_CombineProgramNonQRCode(New_programpartlist, Old_programpartlist, Old_Line);
         }
        public static void EastechHistory_UpdateCombine(long Id, int reqqty, int SoPCBCothedung)
        {
            db.EastechHistory_UpdateCombine(Id, reqqty, SoPCBCothedung);
        }
        public static void EastechHistory_Insert(EastechHistory_Info data)
        {
            db.EastechHistory_Insert(data);
        }
        public static void EastechHistory_UpdateAfter_CutLot_ChangeLine(EastechHistory_Info data)
        {
            db.EastechHistory_UpdateAfter_CutLot_ChangeLine(data);
        }
        public static void EastechHistory_UpdateQtyCount(string psubkey, int qty, int Solanthaylinhkien,  int sopcb, int counts )
        {
            db.EastechHistory_UpdateQtyCount(psubkey, qty, Solanthaylinhkien,sopcb, counts);
        }
        public static DataTable EastechHistory_GetNumberPartcodeChange(string psubkey)
        {
            return db.EastechHistory_GetNumberPartcodeChange(psubkey);
        }
        public static DataTable EastechHistory_CheckProgKeyLineName(string program, string linename)
        {
            return db.EastechHistory_CheckProgKeyLineName(program, linename);
        }
        public static int EastechHistory_CheckProgKeyLineName_UV(string program, string Linename)
        {
            return db.EastechHistory_CheckProgKeyLineName_UV(program, Linename);
        }
        public static int EastechHistory_CheckProgKeyLineName_UV_20220517(string program, string Linename)
        {
            return db.EastechHistory_CheckProgKeyLineName_UV_20220517(program, Linename);
        }
        public static DataTable EastechHistory_CombineProgramQRCode(string Newprogram, string Oldprogram, string OldLine)
        {
            return db.EastechHistory_CombineProgramQRCode(Newprogram, Oldprogram, OldLine);
        }

        public static DataTable EastechHistory_CheckProgKeyLineName_Checker(string program, string Linename)
        {
            return db.EastechHistory_CheckProgKeyLineName_Checker(program, Linename);
        }

        public static DataTable EastechHistory_CheckProgKeyLineName_Checker_Mistake(string program, string Linename)
        {
            return db.EastechHistory_CheckProgKeyLineName_Checker_Mistake(program, Linename);
        }
        public static DataTable EastechHistory_CheckCutLotQtyFeeder(string program, string NewLinename)
        {
            return db.EastechHistory_CheckCutLotQtyFeeder(program, NewLinename);
        }
        public static void EastechHistory_DelCutLotQtyFeeder(long Id)
        {
            db.EastechHistory_DelCutLotQtyFeeder(Id);
        }
        public static DataTable EastechHistory_CheckProgKeyLineName_Checker_StillHave(string program, string Linename)
        {
            return db.EastechHistory_CheckProgKeyLineName_Checker_StillHave(program, Linename);
        }

        public static DataTable EastechHistory_CheckProgKey(string program)
        {
            return db.EastechHistory_CheckProgKey(program);
        }
        public static void EastechHistory_UpdateCounts(long Id,  int counts)
        {
            db.EastechHistory_UpdateCounts(Id,  counts);
        }

        public static DataTable EastechHistory_CheckFeeder(string programpartlist,string fdrno)
        {
           return db.EastechHistory_CheckFeeder(programpartlist,fdrno);
        }
        public static DataTable EastechHistory_CheckPartscode(string programpartlist, string fdrno, string partscode)
        {
            return db.EastechHistory_CheckPartscode(programpartlist, fdrno, partscode);
        }
        public static DataTable EastechHistory_CheckLinename(string programpartlist, string fdrno, string partscode, string remark1)
        {
            return db.EastechHistory_CheckLinename(programpartlist, fdrno, partscode, remark1);
        }
        public static DataTable EastechHistory_GetQty(string programpartlist, string fdrno, string partscode, string remark1, int Solanthaylinhkien)
        {
            return db.EastechHistory_GetQty(programpartlist, fdrno, partscode, remark1, Solanthaylinhkien);
        }
        public static DataTable EastechHistory_getinfo(string program, string remark1)
        {
            return db.EastechHistory_getinfo(program, remark1);
        }

        public static DataTable EastechHistory_CheckCombineLine(string program, string Linename)
        {
            return db.EastechHistory_CheckCombineLine(program, Linename);
        }

        public static void EastechHistory_InsertUpdateQtyCount(string NewProgram, string NewLineName, string OldProgram, string OldLineName, string VCheckedBy, string VDept)
        {
            db.EastechHistory_InsertUpdateQtyCount(NewProgram, NewLineName, OldProgram, OldLineName, VCheckedBy, VDept);
        }

        public static void EastechHistory_InsertUpdateQtyCount_UV(string NewProgram, string NewLineName, string OldProgram, string OldLineName, string VCheckedBy, string VDept)
        {
            db.EastechHistory_InsertUpdateQtyCount_UV(NewProgram, NewLineName, OldProgram, OldLineName, VCheckedBy, VDept);
        }

        public static void EastechHistory_UpdateQtyCount_New(string program, string NewLine, string OldLine)
        {
            db.EastechHistory_UpdateQtyCount_New(program, NewLine, OldLine);
        }
        public static void EastechHistory_UpdateQtyCount_New_UV(string program, string NewLine, string OldLine)
        {
            db.EastechHistory_UpdateQtyCount_New_UV(program, NewLine, OldLine);
        }
        #region Update count by ID sp_EastechOutputHistory_UpdatetSelectData
        public static void sp_EastechOutputHistory_UpdatetSelectData(long Id)
        {
            db.sp_EastechOutputHistory_UpdatetSelectData(Id);
        }
            #endregion 
    }
}
