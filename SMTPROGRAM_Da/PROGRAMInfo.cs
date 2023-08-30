using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPROGRAM_Da
{
    public class PROGRAMInfo
    {

        //public PROGRAMInfo( string programpartlist, string fdrno, string partscode)
        //{
        //    this.programpartlist = programpartlist;
        //    this.fdrno = fdrno;
        //    this.partscode = partscode;
        //}
        //public PROGRAMInfo(DataRow row)
        //{
        //    this.programpartlist = row["programpartlist"].ToString();
        //    this.fdrno = row["fdrno"].ToString();
        //    this.partscode = row["partscode"].ToString();
        //}
        public string programpartlist { get; set; }
        public string fdrno { get; set; }
        public string partscode { get; set; }
        public string ndesc { get; set; }
        public string usage { get; set; }
        public string rp { get; set; }
        public string rep1 { get; set; }
        public string rep2 { get; set; }
        public string rep3 { get; set; }
        public string rep4 { get; set; }
        public string rep5 { get; set; }
        public string reqqty { get; set; }
        public string datecode { get; set; }
        public string dateupdate { get; set; }
    }

}
