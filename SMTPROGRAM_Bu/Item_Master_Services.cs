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
    public class Item_Master_Services
    {
        public readonly static Item_Master_Controll db = new Item_Master_Controll();

        public static void PART_DESC_Insert (Item_Master_Info data)
        {
            db.PART_DESC_Insert(data);
        }

        public static void PART_DESC_Update(Item_Master_Info data)
        {
            db.PART_DESC_Update(data);
        }

        public static void PART_DESC_DeletebyPartcode(Item_Master_Info da)
    {
        db.PART_DESC_DeletebyPartcode(da);
    }
        public static void PART_DESC_Delete()
        {
            db.PART_DESC_Delete();
        }
        public static DataTable PART_DESC_GetbyParcode(Item_Master_Info data)
        {
            return db.PART_DESC_GetbyParcode(data);
        }

        public static DataTable PART_DESC_GetbyAll()
        {
            return db.PART_DESC_GetbyAll();
        }
    }
}
