using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMTPROGRAM_Da;
using System.Data;
using System.Data.SqlClient;

namespace SMTPROGRAM_Bu
{
    public class Assy_Services
    {
        public static readonly Assy_Controller db = new Assy_Controller();
        //=====Operator Process=======================
        public static void A_OperatorProcess_Insert(Assy_Info assy)
        {
            db.A_OperatorProcess_Insert(assy);
        }
        public static DataTable A_OperatorProcess_Select()
        {
            return db.A_OperatorProcess_Select();
        }

        //========================Type PCB=====================

        public static void A_TypePcb_Insert(Assy_Info assy)
        {
            db.A_TypePcb_Insert(assy);
        }

        public static DataTable A_TypePcb_Select()
        {
            return db.A_TypePcb_Select();
        }
    }
}
