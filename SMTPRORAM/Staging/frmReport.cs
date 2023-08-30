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
using UnidenDAL.Staging;

namespace SMTPRORAM.Staging
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            inventorytotal.Text = UVInputDAL.Instance.InventoryStock().ToString();
        }

        private void btTotalInventory_Click(object sender, EventArgs e)
        {
            inventorytotal.Text = UVInputDAL.Instance.InventoryStock().ToString();
        }

        private void btInventory_Click(object sender, EventArgs e)
        {          
            dgView.DataSource = UVInputDAL.Instance.DisplayInventory(txtLocation.Text,txtLot.Text,txtModel.Text,txtPeno.Text,txtPcbname.Text,maskedTextBox2.Text);
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btInputAll_Click(object sender, EventArgs e)
        {

            dgView.DataSource = UVInputDAL.Instance.DisplayInputSearch(txtLocation.Text, txtLot.Text, txtModel.Text, txtPeno.Text, txtPcbname.Text, maskedTextBox2.Text);
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void btOutputAll_Click(object sender, EventArgs e)
        {
            dgView.DataSource = UVOutPutDAL.Instance.DisplayOutPutSearch(txtToLine.Text, txtChange.Text, maskedTextBox1.Text);
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void btToExcel_Click(object sender, EventArgs e)
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
