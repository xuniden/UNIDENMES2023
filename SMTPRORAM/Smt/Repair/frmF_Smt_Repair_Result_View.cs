using ClosedXML.Excel;
using SMTPROGRAM_Bu;
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

namespace SMTPRORAM.Smt.Repair
{
    public partial class frmF_Smt_Repair_Result_View : Form
    {
        public frmF_Smt_Repair_Result_View()
        {
            InitializeComponent();
        }

        private void frmF_Smt_Repair_Result_View_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt = Smt_Repair_Result_Services.sp_Smt_Repair_Result_GroupDept();
            if (dt.Rows.Count > 0)
            {
                cbDept.DataSource = dt;
                cbDept.DisplayMember = "Remark5";
                cbDept.ValueMember = "Remark5";
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewByDept(cbDept.Text);
            if (dt.Rows.Count > 0)
            {
                dgView.DataSource = dt;
                dgView.AutoResizeColumns();
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu");
                return;
            }
        }

        private void btDownload_Click(object sender, EventArgs e)
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
            if (dFrom.Text != "" && dTo.Text != "")
            {
                DateTime start = dFrom.Value.Date;
                DateTime endd = dTo.Value.Date;
                TimeSpan diff = endd.Subtract(start);
                if (diff.TotalDays >= 0)
                {
                    try
                    {
                        var dt = new DataTable();
                        dt = Smt_Repair_Result_Services.sp_Smt_Repair_Result_SearchByDeptDate(cbDept.Text, start.ToString("yyyy/MM/dd"), endd.ToString("yyyy/MM/dd"));
                        if (dt.Rows.Count > 0)
                        {
                            dgView.DataSource = dt;
                            dgView.AutoResizeColumns();
                            dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra ngày nhập !!!");
                    return;
                }
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            if (dFrom.Text != "" && dTo.Text != "")
            {
                DateTime start = dFrom.Value.Date;
                DateTime endd = dTo.Value.Date;
                TimeSpan diff = endd.Subtract(start);
                if (diff.TotalDays >= 0)
                {
                    try
                    {
                        var sheetNames = new List<string>() { "Download" };
                        string filename = "";
                        var dts = new DataTable();
                        var ds = new DataSet();
                        dts = Smt_Repair_Result_Services.sp_Smt_Repair_Result_SearchByDeptDate(cbDept.Text, start.ToString("yyyy/MM/dd"), endd.ToString("yyyy/MM/dd"));
                        if (dts.Rows.Count > 0)
                        {
                            ds.Tables.Add(dts);
                        }

                        XLWorkbook wbook = new XLWorkbook();
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.InitialDirectory = @"D:\";
                        saveFileDialog1.Title = "Save Excel Files";
                        saveFileDialog1.DefaultExt = "xlsx";
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.RestoreDirectory = true;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            filename = saveFileDialog1.FileName;

                            for (int k = 0; k < ds.Tables.Count; k++)
                            {
                                DataTable dt = ds.Tables[k];
                                IXLWorksheet Sheet = wbook.Worksheets.Add(sheetNames[k]);
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    Sheet.Cell(1, (i + 1)).Value = dt.Columns[i].ColumnName;
                                }
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dt.Columns.Count; j++)
                                    {
                                        Sheet.Cell((i + 2), (j + 1)).Value = dt.Rows[i][j].ToString();
                                    }
                                }
                            }
                            wbook.SaveAs(filename);
                            MessageBox.Show("Đã Export Thành Công !!!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra ngày nhập !!!");
                    return;
                }
            }
        }
    }
}
