using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da
{
    public class Smt_Repair_Info
    {
        public string Id { get; set; }
        public string   Model { get; set; }
        public string Dept { get; set; }
        public string Pcb_No { get; set; }
        public string Part_Code { get; set; }
        public string Position { get; set; }
        public string DateT { get; set; }
        public string Ky_Hieu { get; set; }
        public string Noi_Dung_Loi { get; set; }

        public string CauseError { get; set; }
        public string CauseDesc { get; set; }
    }
}
