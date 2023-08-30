using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Smt.DataControl;

namespace SMTPRORAM.Assy.Report
{
	public partial class frmHistoryByUnitSerial : Form
	{
		public frmHistoryByUnitSerial()
		{
			InitializeComponent();
		}

		private void iconButton1_Click(object sender, EventArgs e)
		{
			string result=SMT_AOI_ERROR_RECORD_DAL.Instance.GetTotalCounts("4501803118-6PSU-B0B0BAM20V0R0", "");
		}
	}
}
