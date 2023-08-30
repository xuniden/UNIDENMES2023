using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da.BoxET
{
    public class boxIssueManage
    {
        public long Id { get; set; }
        public string IssueSerial { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueBy { get; set; }
        public float IssueWight { get; set; }
        public bool IssueStatus { get; set; }
        public string Line { get; set; }
        public string Model { get; set; }
        public string Market { get; set; }
        public string PCBType { get; set; }
    }
}
