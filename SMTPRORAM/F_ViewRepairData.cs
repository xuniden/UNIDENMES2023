using SMTPROGRAM_Bu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMTPROGRAM_Da;

namespace SMTPRORAM
{
    public partial class F_ViewRepairData : Form
    {
        float firstWidth;
        float firstHeight;
        public F_ViewRepairData()
        {
            InitializeComponent();
        }

        private void F_ViewRepairData_Load(object sender, EventArgs e)
        {
            firstWidth = this.Size.Width;
            firstHeight = this.Size.Height;
        }

        private void btSeach_Click(object sender, EventArgs e)
        {
            if (cbDept.Text.Equals(""))
            {
                MessageBox.Show("Chọn Bộ Phận");
                cbDept.Focus();
                return;
            }
            else
            {
                var dt = new DataTable();
                dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewByDept(cbDept.Text);
                if (dt.Rows.Count>0)
                {
                    dgView.DataSource = dt;
                    dgView.AutoResizeColumns();
                    dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                    return;
                }
            }
        }

        private void btToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";
                var dt = new DataTable();
                dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewByDept(cbDept.Text);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"D:\";
                saveFileDialog1.Title = "Save Csv Files";
                //saveFileDialog1.CheckFileExists = true;
                //saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "Csv files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    Common.ToCSV(dt, filename);
                    MessageBox.Show("Đã Export Thành Công !!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                throw;
            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            var cs = new Smt_Repair_Result_Info();
            if (txtQRCode.Text.Equals(""))
            {
                MessageBox.Show("Nhập QR Code");
                txtQRCode.Focus();
                return;
            }
            else
            {
                
                var dt = new DataTable();
                cs.QRCode = txtQRCode.Text;
                cs.Err_Position = "";
                cs.Remark1 = "";
                cs.Part_Code = "";
                cs.Ky_Hieu = "";
                cs.Nguoi_Sua2 = "";
                dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewAll(2, cs, "", "");
                if (dt.Rows.Count > 0)
                {
                    dgView.DataSource = dt;
                    dgView.AutoResizeColumns();
                    dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                    return;
                }
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (txtQRCode.Text.Equals(""))
            {
                MessageBox.Show("Nhập QR Code");
                txtQRCode.Focus();
                return;
            }
            else
            {
                try
                {
                    string filename = "";
                    var cs = new Smt_Repair_Result_Info();
                    var dt = new DataTable();                    
                    cs.QRCode = txtQRCode.Text;
                    cs.Err_Position = "";
                    cs.Remark1 = "";
                    cs.Part_Code = "";
                    cs.Ky_Hieu = "";
                    cs.Nguoi_Sua2 = "";
                    dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewAll(2, cs, "", "");
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"D:\";
                    saveFileDialog1.Title = "Save Csv Files";
                    //saveFileDialog1.CheckFileExists = true;
                    //saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.DefaultExt = "csv";
                    saveFileDialog1.Filter = "Csv files (*.csv)|*.csv";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filename = saveFileDialog1.FileName;
                        Common.ToCSV(dt, filename);
                        MessageBox.Show("Đã Export Thành Công !!!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                    throw;
                }
            }
        }

        private void F_ViewRepairData_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {

            }
            else
            {
                float size1 = (this.Size.Width / firstWidth);
                float size2 = (this.Size.Height / firstHeight);
                SizeF scale = new SizeF(size1, size2);
                firstWidth = this.Size.Width;
                firstHeight = this.Size.Height;
                foreach (Control control in this.Controls)
                {
                    control.Font = new Font(control.Font.FontFamily, (control.Font.Size) * ((size1 + size2) / 2));
                    control.Scale(scale);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
