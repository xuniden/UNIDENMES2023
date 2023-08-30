using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using SMTPRORAM.Smt.Output;

namespace SMTPRORAM
{
    
    static class Program
    {
		public static long Auto_number;

		public static string getLine = "";
        public static string getLot = "";
        public static long getProcessId = 0;
        public static int currentPage=1;
        public static int pageSize = 100;

		public static string UserId = "";
        public static string FullName = "";
        public static long DeptID = 0;
        public static string Dept = "";
        

        public static long ProBOM1= 0;
        public static long ProBOM2 = 0;


        public static string username;       
        public static string linename="";

        public static string abcprogramkey="";
        public static string abclinename = "";

        public static string chuyenLineprokey = "";
        public static string chuyenLineNewLine = "";

      
        public static DataTable dtpro_1;
        public static DataTable dtpro_2;
        public static DataTable dprogram1;
        public static DataTable dprogram2;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new Assy.Report.frmHistoryByUnitSerial());

            SysControl.frmLogin loginForm = new SysControl.frmLogin();
            Application.Run(loginForm);
            if (loginForm.UserSuccessfullyAuthenticated)
            {
                Application.Run(new frmMain());
            }

        }
	}
}

