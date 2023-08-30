using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;

namespace SMTPRORAM
{
    public partial class F_KiemTraSoSerialTaoRa : Form
    {
        public F_KiemTraSoSerialTaoRa()
        {
            InitializeComponent();
        }

        private void F_KiemTraSoSerialTaoRa_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = Pcb_Code_Services.PCBCode_GetModel();
            if (dt.Rows.Count >= 1)
            {
                cbModel.DataSource = dt;
                cbModel.DisplayMember = "Model";
                cbModel.ValueMember = "Model";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu !!!");
                return;
            }
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            cbModel.Text = cbModel.Text.Trim().ToUpper();
            if (cbModel.Text.Equals(""))
            {
                MessageBox.Show("Hãy Nhập Model vào ");
                cbModel.Focus();
                return;
            }
            else
            {
                if (cbYear.Text.Equals("") && cbMonth.Text.Equals("") && cbDay.Text.Equals(""))
                {
                    System.Data.DataTable dt = new DataTable();
                    dt = General_Serial_Services.GeneralSerial_SearchByModel(1, cbModel.Text, "", "", "","");
                    if (dt.Rows.Count > 0)
                    {
                        lbcount.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu của model: " + cbModel.Text);
                        cbModel.Focus();
                        return;
                    }

                }
                else if (!cbYear.Text.Equals("") && cbMonth.Text.Equals("") && cbDay.Text.Equals(""))
                {
                    System.Data.DataTable dt = new DataTable();
                    dt = General_Serial_Services.GeneralSerial_SearchByModel(2, cbModel.Text, cbYear.Text, "", "", "");
                    if (dt.Rows.Count > 0)
                    {
                        lbcount.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu của model: " + cbModel.Text + " Năm :" + cbYear.Text);
                        cbModel.Focus();
                        return;
                    }
                }
                else if (!cbYear.Text.Equals("") && !cbMonth.Text.Equals("") && cbDay.Text.Equals(""))
                {
                    System.Data.DataTable dt = new DataTable();
                    dt = General_Serial_Services.GeneralSerial_SearchByModel(3, cbModel.Text, cbYear.Text, cbMonth.Text, "", "");
                    if (dt.Rows.Count > 0)
                    {
                        lbcount.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu của model: " + cbModel.Text + " Năm :" + cbYear.Text + " Tháng :" + cbMonth.Text);
                        cbModel.Focus();
                        return;
                    }
                }
                else if (!cbYear.Text.Equals("") && !cbMonth.Text.Equals("") && !cbDay.Text.Equals(""))
                {
                    System.Data.DataTable dt = new DataTable();
                    dt = General_Serial_Services.GeneralSerial_SearchByModel(4, cbModel.Text, cbYear.Text, cbMonth.Text, cbDay.Text,"");
                    if (dt.Rows.Count > 0)
                    {
                        lbcount.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu của model: " + cbModel.Text + " Năm :" + cbYear.Text + " Tháng :" + cbMonth.Text + " Ngày :" + cbDay.Text);
                        cbModel.Focus();
                        return;
                    }
                }
                else if (cbYear.Text.Equals("") && !cbMonth.Text.Equals("") && cbDay.Text.Equals(""))
                {
                    System.Data.DataTable dt = new DataTable();
                    dt = General_Serial_Services.GeneralSerial_SearchByModel(5, cbModel.Text, "", cbMonth.Text, "","");
                    if (dt.Rows.Count > 0)
                    {
                        lbcount.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu của model: " + cbModel.Text + " Tháng :" + cbMonth.Text);
                        cbModel.Focus();
                        return;
                    }
                }

                else if (cbYear.Text.Equals("") && cbMonth.Text.Equals("") && !cbDay.Text.Equals(""))
                {
                    System.Data.DataTable dt = new DataTable();
                    dt = General_Serial_Services.GeneralSerial_SearchByModel(6, cbModel.Text, "", "", cbDay.Text,"");
                    if (dt.Rows.Count > 0)
                    {
                        lbcount.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu của model: " + cbModel.Text + " Ngày :" + cbDay.Text);
                        cbModel.Focus();
                        return;
                    }
                }

                else if (!cbYear.Text.Equals("") && cbMonth.Text.Equals("") && !cbDay.Text.Equals(""))
                {
                    System.Data.DataTable dt = new DataTable();
                    dt = General_Serial_Services.GeneralSerial_SearchByModel(7, cbModel.Text, cbYear.Text, "", cbDay.Text,"");
                    if (dt.Rows.Count > 0)
                    {
                        lbcount.Text = dt.Rows.Count.ToString();
                        dgView.DataSource = dt;
                        dgView.AutoResizeColumns();
                        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu của model: " + cbModel.Text + " Ngày :" + cbDay.Text);
                        cbModel.Focus();
                        return;
                    }
                }
            }
        }

        private void btExport_Click(object sender, EventArgs e)
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

        private void btKiemtra_Click(object sender, EventArgs e)
        {
            cbModel.Text = cbModel.Text.Trim().ToUpper();
            cbYear.Text = cbYear.Text.Trim().ToUpper();
            cbMonth.Text = cbMonth.Text.Trim().ToUpper();
            cbDay.Text = cbDay.Text.Trim().ToUpper();
            //if (!cbDay.Text.Equals("")&&!cbMonth.Text.Equals("")&&!cbYear.Text.Equals("")&&!cbModel.Text.Equals(""))
            //{
            DataTable dt = new DataTable();
            dt = General_Serial_Services.GeneralSerial_SearchByModel(8, "", "", "", "","");
            if (dt.Rows.Count > 0)
            {
                lbcount.Text = dt.Rows.Count.ToString();
                dgView.DataSource = dt;
                dgView.AutoResizeColumns();
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu !!!");
                return;
            }
            //}
            //else
            //{
            //    MessageBox.Show("");
            //}
        }

        private void btall_Click(object sender, EventArgs e)
        {
            cbModel.Text = cbModel.Text.Trim().ToUpper();
            if (!cbModel.Text.Equals(""))
            {
                DataTable dt = new DataTable();
                dt = General_Serial_Services.GeneralSerial_SearchByModel(9, cbModel.Text, "", "", "","");
                if (dt.Rows.Count > 0)
                {
                    lbcount.Text = dt.Rows.Count.ToString();
                    dgView.DataSource = dt;
                    dgView.AutoResizeColumns();
                    dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu !!!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Hãy Nhập Model Để Load Dữ Liệu");
                cbModel.Focus();
                return;
            }
        }
    }
    
}
