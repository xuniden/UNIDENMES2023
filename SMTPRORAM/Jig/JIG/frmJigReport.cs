using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Jig.JIG;

namespace SMTPRORAM.Jig.JIG
{
	public partial class frmJigReport : Form
	{
		public frmJigReport()
		{
			InitializeComponent();
		}

		private void iconbtnReport_Click(object sender, EventArgs e)
		{
			DateTime start;
			DateTime end;
			start = dateTimePickerFrom.Value.Date;
			end = dateTimePickerTo.Value.Date;
			TimeSpan diff = end.Subtract(start);
			if (diff.TotalDays >= 0)
			{
				var dt= new DataTable();
				dt= JIGHCALDEVICES_DAL.Instance.getBySearchJIG(start, end);
				if (dt.Rows.Count > 0)
				{
					lbltotalIn.Text=dt.Rows.Count.ToString();
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
				}
				else
				{
					dgView.DataSource = null;
					lbltotalIn.Text = "0";
				}
				
			}
		}
	}
}
