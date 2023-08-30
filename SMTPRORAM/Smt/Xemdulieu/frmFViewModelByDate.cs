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
using UnidenDAL.Smt.Output;

namespace SMTPRORAM.Smt.Xemdulieu
{
    public partial class frmFViewModelByDate : Form
    {
        public frmFViewModelByDate()
        {
            InitializeComponent();
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            lblRecod.Text = "";
            if (txtModel.Text.Trim().Equals(""))
            {
                MessageBox.Show("Partcode không được để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime start = dtp_1.Value.Date;
            DateTime endd = dtp_2.Value.Date;
            TimeSpan diff = endd.Subtract(start);
            if (diff.TotalDays >= 0)
            {
                try
                {
                    var dt = new DataTable();
                    dt = SmtAOIQrCodeOutputDAL.Instance.SearchModelByDate(txtModel.Text.Trim(), start, endd);
                    if (dt.Rows.Count > 0)
                    {
                        lblRecod.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nhập ngày không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void frmFViewModelByDate_Load(object sender, EventArgs e)
        {
            lblRecod.Text = "";
        }

        private void btToCsv_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count > 0)
            {
                string filename = "";
                var dt = new DataTable();
                DateTime start = dtp_1.Value.Date;
                DateTime endd = dtp_2.Value.Date;
                dt = SmtAOIQrCodeOutputDAL.Instance.SearchModelByDate(txtModel.Text.Trim(), start, endd);
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
                        Common.writeCSV(dgView, filename);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu");
                        return;
                    }

                }
            }
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                DateTime time = DateTime.Now;
                string st = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
                sfd.FileName = "Export_Data_" + st + ".xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //Write Headers
                    for (j = 0; j < dgView.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = dgView.Columns[j].HeaderText;
                    }

                    StartRow++;

                    //Write datagridview content
                    for (i = 0; i < dgView.Rows.Count; i++)
                    {
                        for (j = 0; j < dgView.Columns.Count; j++)
                        {
                            try
                            {
                                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                                myRange.Value2 = dgView[j, i].Value == null ? "" : dgView[j, i].Value;
                            }
                            catch
                            {
                                ;
                            }
                        }
                    }

                    workbook.SaveAs(sfd.FileName);
                    excel.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
