using SMTPROGRAM_Bu;
using SMTPROGRAM_Bu.BoxET;
using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTPRORAM.BoxET
{
    public partial class FBoxReport : Form
    {
        public FBoxReport()
        {
            InitializeComponent();
        }

        private void FBoxReport_Load(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
            txtBarcode.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker1.Value.Date;
            DateTime toDate = dateTimePicker2.Value.Date;
            if (!txtBarcode.Text.Equals(""))
            {
                var dt = new DataTable();
                dt = boxIssueManage_Service.boxReportManage(1, txtBarcode.Text, fromDate, toDate);
                if (dt.Rows.Count>0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            else
            {
                var dt = new DataTable();
                dt = boxIssueManage_Service.boxReportManage(0, txtBarcode.Text, fromDate, toDate);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string filename = "";
                DateTime fromDate = dateTimePicker1.Value.Date;
                DateTime toDate = dateTimePicker2.Value.Date;

                var dt = new DataTable();
                if (txtBarcode.Text.Equals(""))
                {
                    dt = boxIssueManage_Service.boxReportManage(0,txtBarcode.Text,fromDate,toDate);
                }
                else
                {
                    dt = boxIssueManage_Service.boxReportManage(1, txtBarcode.Text, fromDate, toDate);
                }
                
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"D:\";
                saveFileDialog1.Title = "Save Csv Files";
                //saveFileDialog1.CheckFileExists = true;
                //saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "Text files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    if (dt.Rows.Count > 0)
                    {
                        Common.writeCSV(dataGridView1, filename);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu");
                        return;
                    }

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueNotReturn_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt = boxIssueManage_Service.boxETManage_IssueNotReutn();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
    }
}
