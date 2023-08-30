using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da.BoxET
{
    public class boxETManage
    {
        public long Id { get; set; }
        public string Serial { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
        public bool Status {get;set;}
        public string BarCode { get; set; }
    }
}
