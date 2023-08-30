using SMTPROGRAM_Da.BoxET;
using System.Data;

namespace SMTPROGRAM_Bu.BoxET
{
    public class boxETManage_Service
    {
        public static readonly boxETManage_Control db = new boxETManage_Control();

        public static void boxETManage_Insert(boxETManage boxETManage)
        {
            db.boxETManage_Insert(boxETManage);
        }
        public static DataTable boxETManage_CheckExists(string Serial)
        {
            return db.boxETManage_CheckExists(Serial);
        }
        public static DataTable boxETManage_getNumberOfSerial(string boxType)
        {
            return db.boxETManage_getNumberOfSerial(boxType);
        }
        public static DataTable boxETManage_getLastOfSerial(string boxType)
        {
            return db.boxETManage_getLastOfSerial(boxType);
        }
        public static DataTable boxETManage_PrintBarcode(string fromSerial, string toSerial)
        {
            return db.boxETManage_PrintBarcode(fromSerial, toSerial);
        }
        public static void boxETManage_UpdateStatus(boxETManage boxETManage)
        {
            db.boxETManage_UpdateStatus(boxETManage);
        }
    }
}
