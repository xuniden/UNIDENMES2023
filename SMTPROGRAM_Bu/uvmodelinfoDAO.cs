using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Bu
{
    public class uvmodelinfoDAO
    {
        private static uvmodelinfoDAO instance;

        public static uvmodelinfoDAO Instance
        {
            get { if (instance == null) instance = new uvmodelinfoDAO(); return uvmodelinfoDAO.instance; }
            private set { uvmodelinfoDAO.instance = value; }
        }
        private uvmodelinfoDAO() { }
    }
}
