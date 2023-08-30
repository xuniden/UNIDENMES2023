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
    public class Pcb_Code_Services
    {
        public static readonly Pcb_Code_Controller db = new Pcb_Code_Controller();
        public static void PCBCode_Insert(Pcb_Code_Info data)
        {
            db.PCBCode_Insert(data);
        }

        public static void PCBCode_Update(int id, Pcb_Code_Info data)
        {
            db.PCBCode_Update(id, data);
        }

        public static DataTable PCBCode_CheckKey(string PcbKey)
        {
            return db.PCBCode_CheckKey(PcbKey);
        }

        public static DataTable PCBCode_Search(string Model)
        {
            return db.PCBCode_Search(Model);
        }
        public static DataTable PCBCode_GetModel()
        {
            return db.PCBCode_GetModel();
        }

        public static DataTable PCBCode_GetPCBCodeByModel(string Model)
        {
            return db.PCBCode_GetPCBCodeByModel(Model);
        }

        public static void PCBCode_DelById(int id)
        {
            db.PCBCode_DelById(id);
        }
        public static DataTable PCBCode_GetbyAll()
        {
            return db.PCBCode_GetbyAll();
        }
        public static void PCBCode_DeleteAll()
        {
            db.PCBCode_DeleteAll();
        }
        public static DataTable EastechPCBCode_SearchByPcbCode(string pcbcode)
        {
            return db.EastechPCBCode_SearchByPcbCode(pcbcode);
        }
        public static DataTable EastechPCBCode_GetPcbCode()
        {
            return db.EastechPCBCode_GetPcbCode();
        }
    }
}
