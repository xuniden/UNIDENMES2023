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
using UnidenDAL.Jig;

namespace SMTPRORAM.Jig
{
    public partial class frmJIGReport : Form
    {
        private int InCount = 0;
        private int OutCount = 0;
        public frmJIGReport()
        {
            InitializeComponent();
        }

        private void getInOutHistory(DateTime start, DateTime end)
        {
            DataTable dt = new DataTable();
            dt=JIGINOUT_DAL.Instance.SearchInOutByDate(2, "", start, end);
            if (dt.Rows.Count>0)
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
                CountInOut(dt);
			}
            
        }
		private void CountInOut(DataTable datatable)
		{
			InCount = 0; OutCount = 0;
			foreach (DataRow row in datatable.Rows)
			{
				string checkValue = row[0].ToString(); // Replace "check" with your actual field name

				if (checkValue == "IN")
				{
					InCount++;
				}
				else if (checkValue == "OUT")
				{
					OutCount++;
				}
			}
			lbltotalIn.Text = InCount.ToString();
			lbltotalOut.Text = OutCount.ToString();
		}
		private void iconbtnTim_Click(object sender, EventArgs e)
        {
            DateTime start;
            DateTime end;
            start = dateTimePickerFrom.Value.Date;
            end = dateTimePickerTo.Value.Date;
            TimeSpan diff = end.Subtract(start);
            if (diff.TotalDays >= 0)
            {
                getInOutHistory(start,end);
            }
        }
        private void frmJIGReport_Load(object sender, EventArgs e)
        {
            lbltotalOut.Text = "0";
            lbltotalIn.Text = "0";
            DateTime ste = CommonDAL.Instance.getSqlServerDatetime();
            getInOutHistory(CommonDAL.Instance.getSqlServerDatetime(), CommonDAL.Instance.getSqlServerDatetime());
        }

        private void iconbtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"D:\";
                saveFileDialog1.Title = "Save Csv Files";
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "Csv files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    CommonDAL.Instance.writeCSV(dgView, filename);
                    MessageBox.Show("Đã Export Thành Công !!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                throw;
            }
        }


        private void Search()
        {
			if (txtSearch.Text.Trim().Equals(""))
			{
				MessageBox.Show("Nhập nội dung cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSearch.Focus();
			}
			else
			{				
			    var dt= new     DataTable();
                dt= JIGINOUT_DAL.Instance.getInOutDeviceOnline(txtSearch.Text.Trim());
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
                CountInOut(dt);
			}
		}
        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            Search();
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode==Keys.Enter)
            {
                Search();
			}
		}
	}
}
