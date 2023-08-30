using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Bu
{
    public class PcbType_Services
    {
        public static readonly PcbType_Controller db = new PcbType_Controller();
        public static DataTable PcbType_GetAll()
        {
            return db.PcbType_GetAll();
        }
            
    }
}
