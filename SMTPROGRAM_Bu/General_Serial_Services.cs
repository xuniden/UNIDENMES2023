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
    public class General_Serial_Services
    {
        public static readonly General_Serial_Controller db = new General_Serial_Controller();
        public static DataTable EstechSerialGeneral_Market()
        {
            return db.EstechSerialGeneral_Market();
        }

        public static void GeneralSerial_Insert(General_Serial_Info data)
        {
            db.GeneralSerial_Insert(data);
        }

        public static void GeneralSerial_Update(General_Serial_Info data, int Id)
        {
            db.GeneralSerial_Update(data, Id);
        }

        public static DataTable GeneralSerial_ModelList()
        {
            return db.GeneralSerial_ModelList();
        }
        public static void GeneralSerial_Delete()
        {
            db.GeneralSerial_Delete();
        }

        public static DataTable GeneralSerial_GetbyAll()
        {
            return db.GeneralSerial_GetbyAll();
        }

        public static DataTable bGeneralSerial_GetbySerial(General_Serial_Info data)
        {
            return db.GeneralSerial_GetbySerial(data);
        }
        public static DataTable GeneralSerial_CheckDoubleSerail()
        {
            return db.GeneralSerial_CheckDoubleSerail();
        }

        public static DataTable GeneralSerial_SearchByModel(int Opt, String Model, string TypeOfProduct, string EndOfYear, string WeeksInYear, string DaysOfWeek)
        {
            return db.GeneralSerial_SearchByModel(Opt, Model, TypeOfProduct, EndOfYear, WeeksInYear, DaysOfWeek);
        }

        public static DataTable GeneralSerial_CheckSerial( string Serial_Number, string Model)
        {
            return db.GeneralSerial_CheckSerial(Serial_Number, Model);
        }

        //====================================================================================

        public static void GeneralSerial_Insert_tmp(General_Serial_Info data)
        {
            db.GeneralSerial_Insert_tmp(data);
        }
        public static void GeneralSerial_Delete_tmp()
        {
            db.GeneralSerial_Delete_tmp();
        }
        public static DataTable GeneralSerial_GetbyAll_Tmp()
        {
            return db.GeneralSerial_GetbyAll_Tmp();
        }

        public static void EstechSerialGeneral_tmp_To_Main()
        {
            db.EstechSerialGeneral_tmp_To_Main();
        }
    }
}
