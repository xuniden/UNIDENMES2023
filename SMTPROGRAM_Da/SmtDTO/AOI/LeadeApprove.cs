using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da.SmtDTO.AOI
{
    public class LeadeApprove
    {
        private static LeadeApprove instance;
        public static LeadeApprove Instance
        {
            get
            {
                if (instance == null) instance = new LeadeApprove();
                return LeadeApprove.instance;
            }
            private set { LeadeApprove.instance = value; }
        }
        private LeadeApprove() { }
        
    }
}
