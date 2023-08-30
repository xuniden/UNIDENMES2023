using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTPRORAM.Assy.ET
{
    
    public partial class frmFAssyDownload : Form
    {
        float firstWidth;
        float firstHeight;
        public frmFAssyDownload()
        {
            InitializeComponent();
        }

        private void frmFAssyDownload_Load(object sender, EventArgs e)
        {
            firstWidth = this.Size.Width;
            firstHeight = this.Size.Height;
            lbltongso.Text = "";
            var pcbModel = new DataTable();
            pcbModel = Pcb_Code_Services.PCBCode_GetModel();
            if (pcbModel.Rows.Count > 0)
            {
                cbModel.DataSource = pcbModel;
                cbModel.DisplayMember = "Model";
                cbModel.ValueMember = "Model";
            }
            var typePcb = new DataTable();
            typePcb = Assy_Services.A_TypePcb_Select();
            if (typePcb.Rows.Count > 0)
            {
                cbPcbtype.DataSource = typePcb;
                cbPcbtype.DisplayMember = "TypePcb";
                cbPcbtype.ValueMember = "TypePcb";
            }

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!cbModel.Text.Equals(""))
            {
                if (!cbPcbtype.Text.Equals(""))
                {
                    if (dateFrom.Text != "" && dateTo.Text != "")
                    {
                        try
                        {
                            DateTime start = dateFrom.Value;
                            DateTime endd = dateTo.Value;
                            //DateTime start = dateFrom.Value.Date;
                            //DateTime endd = dateTo.Value.Date;
                            TimeSpan diff = endd.Subtract(start);
                            if (diff.TotalDays >= 0)
                            {
                                var dt = new DataTable();
                                //dt = AssyOperatorProcess_Services.AssyOperatorProcessData_GetModel(cbModel.Text, cbPcbtype.Text, start.ToString("yyyy/MM/dd"), endd.ToString("yyyy/MM/dd"));
                                dt = AssyOperatorProcess_Services.AssyOperatorProcessData_GetModel(cbModel.Text, cbPcbtype.Text, start, endd);
                                if (dt.Rows.Count > 0)
                                {
                                    lbltongso.Text = dt.Rows.Count.ToString();
                                }
                                if (dt.Rows.Count > 5000)
                                {
                                    MessageBox.Show("Dữ liệu quá lớn hãy Export ra csv File", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    dgView.DataSource = dt;
                                    dgView.AutoResizeColumns();
                                    dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
        }

        private void btModelSearch_Click(object sender, EventArgs e)
        {
            if (!cbModel.Text.Equals(""))
            {
                try
                {
                    var dt = new DataTable();
                    dt = AssyOperatorProcess_Services.AssyOperatorProcessData_GetModelAll(cbModel.Text);
                    if (dt.Rows.Count > 0)
                    {
                        lbltongso.Text = dt.Rows.Count.ToString();
                    }
                    if (dt.Rows.Count > 5000)
                    {
                        MessageBox.Show("Dữ liệu quá lớn hãy Export ra csv File","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                        return;
                    }
                    else
                    {
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                MessageBox.Show("Nhập dữ liệu Model", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbModel.Focus();
                return;
            }
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            int sheetIndex = 0;
            DateTime date = GetServerDateTime_Services.getServerDateTime();
            if (dateFrom.Text != "" && dateTo.Text != "")
            {
                DateTime start = dateFrom.Value;
                DateTime endd = dateTo.Value;
                TimeSpan diff = endd.Subtract(start);
                if (diff.TotalDays >= 0)
                {
                    var dt = new DataTable();
                    dt = AssyOperatorProcess_Services.AssyOperatorProcessData_GetModel(cbModel.Text, cbPcbtype.Text, start, endd);
                    if (dt.Rows.Count > 0)
                    {
                        ResourceManager.GetResourceInfo("sony_template.xlsx", "SMTPRORAM.Resources");
                        if (ResourceManager.resourceExists == false)
                            return;
                        try
                        {
                            string fname;
                            fname = cbModel.Text.ToUpper();
                            fname = fname.Replace("/", "-");
                            fname = fname + "_" + dateFrom.Value.ToString("yyyy-MM-dd HH-mm") + "_" + dateTo.Value.ToString("yyyy-MM-dd HH-mm");

                            DateTime time = GetServerDateTime_Services.getServerDateTime();
                            string st = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString();
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
                            sfd.FileName = fname + ".xlsx";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                ResourceManager.LoadResource(sfd.FileName);
                                Cursor.Current = Cursors.WaitCursor;
                                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(sfd.FileName);
                                if (cbPcbtype.SelectedValue.ToString() == "AMP")
                                {
                                    sheetIndex = 3;
                                }
                                if (cbPcbtype.SelectedValue.ToString() == "MAIN")
                                {
                                    sheetIndex = 2;
                                }
                                if (cbPcbtype.SelectedValue.ToString() == "KEY")
                                {
                                    sheetIndex = 4;
                                }
                                if (cbPcbtype.SelectedValue.ToString() == "PSU")
                                {
                                    sheetIndex = 5;
                                }

                                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[sheetIndex];
                                //xlWorksheet.Activate();
                                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                                int StartRow = 8;
                                int  i = 0;
                                for (i = 0; i < dgView.Rows.Count; i++)
                                {
                                    xlWorksheet.Cells[StartRow + i, 2] = i + 1; // No
                                    xlWorksheet.Cells[StartRow + i, 3] = dateFrom.Value.Date.ToString("yyyy/MM/dd"); // Date                    
                                    xlWorksheet.Cells[StartRow + i, 4] = cbModel.Text;// Model
                                    xlWorksheet.Cells[StartRow + i, 5] = dgView[3, i].Value;//dt.Rows[i]["QrCode"].ToString(); // Serial
                                    //xlWorksheet.Cells[StartRow + i, 6] = dgView[6, i].Value;// dt.Rows[i]["APP"].ToString().Equals("") ? "" : "OK";// dt.Rows[i]["APP"].ToString(); // APP               
                                    
                                    if (dgView[5, i].Value.Equals("") || string.IsNullOrEmpty(dgView[5, i].Value.ToString())) //APP
                                    {
                                        xlWorksheet.Cells[StartRow + i, 6] = "";
                                    }
                                    else
                                    {
                                        xlWorksheet.Cells[StartRow + i, 6] = "OK";// dgView[6, i].Value;
                                    }
                                    if (dgView[7, i].Value.Equals("") || string.IsNullOrEmpty(dgView[7, i].Value.ToString()))  // FCT
                                    {
                                        xlWorksheet.Cells[StartRow + i, 7] = "";
                                    }
                                    else
                                    {
                                        xlWorksheet.Cells[StartRow + i, 7] = "OK";// dgView[7, i].Value;
                                    }
                                    if (dgView[8, i].Value.Equals("") || string.IsNullOrEmpty(dgView[8, i].Value.ToString())) //OUTPUT
                                    {
                                        xlWorksheet.Cells[StartRow + i, 8] = "";
                                    }
                                    else
                                    {
                                        xlWorksheet.Cells[StartRow + i, 8] = "OK";// dgView[8, i].Value;
                                    }
                                    if (sheetIndex == 5)
                                    {
                                        if (dgView[6, i].Value.Equals("") || string.IsNullOrEmpty(dgView[6, i].Value.ToString())) // HI-POT
                                        {
                                            xlWorksheet.Cells[StartRow + i, 9] = "";
                                        }
                                        else
                                        {
                                            xlWorksheet.Cells[StartRow + i, 9] = "OK"; //dgView[9, i].Value;
                                        }
                                    }
                                    //xlWorksheet.Cells[StartRow + i, 7] = dgView[8, i].Value;//dt.Rows[i]["FCT"].ToString().Equals("") ? "" : "OK";//dt.Rows[i]["FCT"].ToString(); // FCT
                                    //xlWorksheet.Cells[StartRow + i, 8] = dgView[9, i].Value; //dt.Rows[i]["OUTPUT"].ToString().Equals("") ? "" : "OK"; /// dt.Rows[i]["OUTPUT"].ToString(); // OUPUT
                                    //xlWorksheet.Cells[StartRow + i, 9] = dgView[7, i].Value; //dt.Rows[i]["HIPOT"].ToString().Equals("") ? "" : "OK"; //dt.Rows[i]["HIPOT"].ToString(); // Wireless
                                }
                                xlWorksheet.Cells[4, 2] = "Date: " + date.ToString("yyyy/MM/dd");
                                xlWorksheet.Cells[4, 2].Font.Size = 14;
                                xlWorksheet.Cells[4, 7] = "MODEL: " + cbModel.Text;
                                xlWorksheet.Cells[4, 7].Font.Size = 14;
                                string part = dt.Rows[1]["PCBCode"].ToString();
                                xlWorksheet.Cells[5, 5] = "Part no: " + part.Substring(0, part.Length - 4);
                                xlWorksheet.Cells[5, 5].Font.Size = 14;
                                xlApp.Visible = false;
                                xlApp.UserControl = false;
                                xlWorkbook.Save();
                                //cleanup
                                GC.Collect();
                                GC.WaitForPendingFinalizers();

                                //release com objects to fully kill excel process from running in the background
                                Marshal.ReleaseComObject(xlRange);
                                Marshal.ReleaseComObject(xlWorksheet);

                                //close and release
                                xlWorkbook.Close();
                                Marshal.ReleaseComObject(xlWorkbook);

                                //quit and release
                                xlApp.Quit();
                                Marshal.ReleaseComObject(xlApp);
                                // Set cursor as default arrow
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Kết thúc download dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để download !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Kiểm tra ngày nhập !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btExportModelSearch_Click(object sender, EventArgs e)
        {
            if (!cbModel.Text.Equals(""))
            {
                try
                {
                    string filename = "";
                    DataTable dt = new DataTable();
                    dt = AssyOperatorProcess_Services.AssyOperatorProcessData_GetModelAll(cbModel.Text);
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
                        MessageBox.Show("Đã Export Thành Công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    throw;
                }
            }
        }

        private void btDaily_Click(object sender, EventArgs e)
        {
            if (dateFrom.Text != "" && dateTo.Text != "")
            {
                DateTime start = dateFrom.Value.Date;
                DateTime endd = dateTo.Value.Date;
                TimeSpan diff = endd.Subtract(start);
                if (diff.TotalDays >= 0)
                {
                    try
                    {
                        string filename = "";
                        DataTable dt = new DataTable();
                        dt = AssyOperatorProcess_Services.AssyOperatorProcessData_GetSearch(cbModel.Text, cbPcbtype.Text, start.ToString(), endd.ToString());
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
                            MessageBox.Show("Đã Export Thành Công !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra ngày nhập !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btDaily_SizeChanged(object sender, EventArgs e)
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
    }
}
