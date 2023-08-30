using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Bu
{
    public class GetServerDateTime_Services
    {
        public static readonly GetServerDateTime db = new GetServerDateTime();
        public static DateTime getServerDateTime()
        {
            return db.getServerDateTime();
        }
    }
}
