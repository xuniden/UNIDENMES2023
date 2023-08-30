using ClosedXML.Excel;
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

namespace SMTPRORAM.Assy.ET
{
    public partial class frmFAssyToEastech : Form
    {
        float firstWidth;
        float firstHeight;
        public frmFAssyToEastech()
        {
            InitializeComponent();
        }

        private void frmFAssyToEastech_Load(object sender, EventArgs e)
        {
            dateFrom.Format = DateTimePickerFormat.Custom;
            dateFrom.CustomFormat = "yyyy/MM/dd HH:mm";

            dateTo.Format = DateTimePickerFormat.Custom;
            dateTo.CustomFormat = "yyyy/MM/dd HH:mm";

            firstWidth = this.Size.Width;
            firstHeight = this.Size.Height;

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
            if (dateFrom.Text != "" && dateTo.Text != "")
            {
                DateTime start = dateFrom.Value;
                DateTime endd = dateTo.Value;
                //MessageBox.Show(" " + start);
                //MessageBox.Show(" " + endd);
                TimeSpan diff = endd.Subtract(start);
                if (diff.TotalDays >= 0)
                {
                    try
                    {
                        string filename = "";
                        var dtmain = new DataTable();
                        var dtpsu = new DataTable();
                        var dtamp = new DataTable();
                        var ds = new DataSet();
                        dtmain = AssyOperatorProcess_Services.AssyOperatorProcessData_GetMIAN(cbModel.Text, cbPcbtype.Text, start, endd);
                        //MessageBox.Show(" " + dtmain.Rows.Count);
                        ds.Tables.Add(dtmain);
                        if (dtmain.Rows.Count > 0)
                        {
                            dgView.DataSource = dtmain;
                        }


                        dtamp = AssyOperatorProcess_Services.AssyOperatorProcessData_GetAMP(cbModel.Text, cbPcbtype.Text, start, endd);
                        //MessageBox.Show(" " + dtamp.Rows.Count);
                        ds.Tables.Add(dtamp);
                        if (dtamp.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dtamp;
                        }
                        dtpsu = AssyOperatorProcess_Services.AssyOperatorProcessData_GetPSU(cbModel.Text, cbPcbtype.Text, start, endd);
                        //MessageBox.Show(" " + dtpsu.Rows.Count);
                        ds.Tables.Add(dtpsu);
                        if (dtpsu.Rows.Count > 0)
                        {
                            dataGridView2.DataSource = dtpsu;
                        }


                        var sheetNames = new List<string>() { "Main", "AMP", "PSU" };
                        //string fileName = "Example.xlsx";

                        XLWorkbook wbook = new XLWorkbook();
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.InitialDirectory = @"D:\";
                        saveFileDialog1.Title = "Save Excel Files";
                        saveFileDialog1.DefaultExt = "xlsx";
                        saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFileDialog1.FilterIndex = 1;
                        saveFileDialog1.RestoreDirectory = true;
                        string tmp = "";
                        tmp = cbModel.Text + "_" + dateFrom.Text + "_" + dateTo.Text;
                        tmp = tmp.Replace("/", "").Replace(":", "").Replace(" ", "_");
                        saveFileDialog1.FileName = tmp;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {

                            filename = saveFileDialog1.FileName;

                            //XLWorkbook wb = new XLWorkbook();
                            //for (int i = 0; i < ds.Tables.Count; i++)
                            //{
                            //    wb.Worksheets.Add(ds.Tables[i], ds.Tables[i].TableName);
                            //}
                            //string filePath = "";
                            //if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            //{
                            //    filePath = folderBrowserDialog1.SelectedPath;
                            //}
                            //wb.SaveAs(filePath + "\\DataGridViewExport.xlsx");


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
                            //Stream spreadsheetStream = new MemoryStream();
                            wbook.SaveAs(filename);
                            // spreadsheetStream.Position = 0;


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
