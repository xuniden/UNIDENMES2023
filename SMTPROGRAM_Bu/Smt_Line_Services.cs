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
    public class Smt_Line_Services
    {
        public static readonly Smt_Line_Controller db = new Smt_Line_Controller();
        public static DataTable Linename( string linename)
        {
            return db.Linename(linename);
        }

        public static DataTable Smt_GetAllLine()
        {
            return db.Smt_GetAllLine();
        }
        public static DataTable Smt_output_SearchByQRCode(string QRCode)
        {
            return db.Smt_output_SearchByQRCode(QRCode);
        }
        public static DataTable Smt_output_SearchByDate(string fromdate, string todate)
        {
            return db.Smt_output_SearchByDate(fromdate, todate);
        }
        public static DataTable Smt_output_SearchByProgramkey(int opt, string program, string fromdate, string todate)
        {
            return db.Smt_output_SearchByProgramkey(opt, program, fromdate, todate);
        }
        public static DataSet Smt_output_SearchByProgramkeyDataset(int opt, string program, string Fromdate, string todate)
        {
            return db.Smt_output_SearchByProgramkeyDataset(opt, program, Fromdate, todate);
        }


        public static DataTable Smt_output_SearchByModel(int opt, string Model, string fromdate, string todate)
        {
            return db.Smt_output_SearchByModel(opt, Model, fromdate, todate);
        }
    }
}
