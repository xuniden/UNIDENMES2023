using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Bu
{
    public class ModelName_Services
    {
        public static readonly ModelName_Controller db = new ModelName_Controller();
        public static DataTable ModelName_GetAll()
        {
          return  db.ModelName_GetAll();
        }
    }
}
