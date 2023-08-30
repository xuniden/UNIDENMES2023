using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.VisualBasic.FileIO;
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
using UnidenDAL;

namespace SMTPRORAM.Smt.Repair
{
    public partial class frmF_Smt_Repair_Data : Form
    {
        int Id = 0;
        public frmF_Smt_Repair_Data()
        {
            InitializeComponent();
        }

        private void btBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open CSV File";
            theDialog.Filter = "CSV files|*.csv";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;
                txtPath.Text = filename;
                // string[] filelines = File.ReadAllLines(filename);
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            bool flag = true;
            var csv = new Smt_Repair_Info();
            if (txtPath.Text.Trim().Equals("") || txtPath.Text.Trim() == null)
            {
                MessageBox.Show("Hãy Nhập File cần Import vào đây");
                return;
            }
            else
            {
                using (TextFieldParser parser = new TextFieldParser(txtPath.Text))
                {
                    parser.ReadLine();
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    // check before import
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        string[] fields = parser.ReadFields();
                        if (fields[0].Equals("")&& fields[1].Equals("")&& fields[2].Equals("")&& fields[3].Equals(""))
                        {
                            flag = false;
                        }
                    }
                }
                using (TextFieldParser parser1 = new TextFieldParser(txtPath.Text))
                {
                    parser1.ReadLine();
                    parser1.TextFieldType = FieldType.Delimited;
                    parser1.SetDelimiters(",");
                    if (flag == true)
                    {
                        while (!parser1.EndOfData)
                        {
                            string[] fields = parser1.ReadFields();
                            csv.Model = fields[0].ToString().ToUpper().Trim();
                            csv.Pcb_No = fields[1].ToString().ToUpper().Trim();
                            csv.Part_Code = fields[2].ToString().ToUpper().Trim();
                            csv.Position = fields[3].ToString().ToUpper().Trim();
                            //csv.DateT = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                            csv.DateT = CommonDAL.Instance.getSqlServerDatetime().ToString();
                            Smt_Repair_Services.Smt_Repair_Bom_Insert(csv);
                        }
                        DisplayData();
                        MessageBox.Show("Finished!!!");
                    }
                    else
                    {
                        MessageBox.Show("File Import đã có lỗi: ");
                    }

                }
            }
        }
        private void DisplayData()
        {
            try
            {
                var csv = new Smt_Repair_Info();
                csv.Pcb_No = "";
                csv.Position = "";
                DataTable dt = new DataTable();
                dt = Smt_Repair_Services.Smt_Repair_Bom_ViewAll(1, csv);
                if (dt.Rows.Count > 0)
                {
                    dgView.DataSource = dt;
                    dgView.AutoResizeColumns();
                    dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu : ");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi :" + ex.Message);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Model và PCB có cùng nhau không?
            var csv = new Smt_Repair_Info();
            csv.Model = textBox2.Text.Trim().ToUpper();
            csv.Pcb_No = textBox3.Text.Trim().ToUpper();
            DataTable dt = new DataTable();
            dt = Smt_Repair_Services.Smt_Repair_Bom_Check(3, csv);
            // Nếu có dữ liệu thì tiến hành xóa
            if (dt.Rows.Count > 0)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Smt_Repair_Services.Smt_Repair_Bom_Delete(csv);
                        MessageBox.Show("Đã xóa hết dữ liệu cần xóa !!!");
                    }
                    //else if (dialogResult == DialogResult.No)
                    //{
                    //    //do something else
                    //}
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra:  " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            textBox2.Text = textBox2.Text.ToUpper().Trim();
            if (e.KeyValue == 13)
            {
                var csv = new Smt_Repair_Info();
                csv.Model = textBox2.Text;
                csv.Pcb_No = "";
                DataTable dt = new DataTable();
                dt = Smt_Repair_Services.Smt_Repair_Bom_Check(1, csv);
                if (dt.Rows.Count > 0)
                {
                    textBox3.Text = dt.Rows[0].Field<string>("Pcb_No");
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Model này");
                    return;
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            textBox3.Text = textBox3.Text.ToUpper().Trim();
            if (e.KeyValue == 13)
            {
                var csv = new Smt_Repair_Info();
                csv.Model = "";
                csv.Pcb_No = textBox3.Text;
                DataTable dt = new DataTable();
                dt = Smt_Repair_Services.Smt_Repair_Bom_Check(2, csv);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy Model này");
                    return;
                }
                else
                {
                    btDelete.Focus();
                }
            }
        }

        private void btB_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open CSV File";
            theDialog.Filter = "CSV files|*.csv";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = theDialog.FileName;
                txtbrowser.Text = filename;
                // string[] filelines = File.ReadAllLines(filename);
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            bool flag = true;
            var csv = new Smt_Repair_Info();
            if (txtbrowser.Text.Trim().Equals("") || txtbrowser.Text.Trim() == null)
            {
                MessageBox.Show("Hãy Nhập File cần Import vào đây");
                return;
            }
            else
            {
                using (TextFieldParser parser = new TextFieldParser(txtbrowser.Text))
                {
                    parser.ReadLine();
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    // check before import
                    while (!parser.EndOfData)
                    {
                        //Processing row
                        string[] fields = parser.ReadFields();
                        if (fields.Length != 3)
                        {
                            flag = false;
                        }
                    }
                }
                using (TextFieldParser parser1 = new TextFieldParser(txtbrowser.Text))
                {
                    parser1.ReadLine();
                    parser1.TextFieldType = FieldType.Delimited;
                    parser1.SetDelimiters(",");
                    if (flag == true)
                    {
                        while (!parser1.EndOfData)
                        {
                            string[] fields = parser1.ReadFields();
                            csv.Ky_Hieu = fields[0].ToString().ToUpper().Trim();
                            csv.Noi_Dung_Loi = fields[1].ToString().Trim();
                            csv.Dept = fields[2].ToString().Trim();
                            csv.DateT = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                            Smt_Repair_Services.Smt_Repair_Error_Code_Insert(csv);
                        }
                        display();
                        MessageBox.Show("Finished!!!");
                    }
                    else
                    {
                        MessageBox.Show("File Import đã có lỗi: ");
                    }

                }
            }
        }
        private void display()
        {
            try
            {
                DataTable dt = new DataTable();
                var csv = new Smt_Repair_Info();
                csv.Ky_Hieu = "";
                csv.Dept = Program.Dept;
                dt = Smt_Repair_Services.Smt_Repair_Error_Code_ViewAll(1, csv);
                if (dt.Rows.Count > 0)
                {
                    dataGridView.DataSource = dt;
                    dataGridView.AutoResizeColumns();
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btRe_Click(object sender, EventArgs e)
        {
            display();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var csv = new Smt_Repair_Info();
                csv.Id = Id.ToString();
                csv.Ky_Hieu = textBox4.Text.Trim().ToUpper();
                csv.Dept = txtDept.Text;
                csv.Noi_Dung_Loi = richTextBox1.Text;
                csv.DateT = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                Smt_Repair_Services.Smt_Repair_Error_Code_Update(csv);
                MessageBox.Show("Update Thành công ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var csv = new Smt_Repair_Info();
                csv.Id = Id.ToString();
                Smt_Repair_Services.Smt_Repair_Error_Code_Delete(csv);
                MessageBox.Show("Xóa OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
            }
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox4.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDept.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dgView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dgView.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dgView.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            var csv = new Smt_Repair_Info();
            csv.Model = textBox2.Text.Trim().ToUpper();
            csv.Pcb_No = textBox3.Text.Trim().ToUpper();
            DataTable dt = new DataTable();
            dt = Smt_Repair_Services.Smt_Repair_Bom_Check(3, csv);
            // Nếu có dữ liệu thì tiến hành xóa
            if (dt.Rows.Count > 0)
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView,dt);
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }

        private void iconbtnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count>0)
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
        }

        private void iconbtnExport_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count > 0)
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
        }
    }
}
