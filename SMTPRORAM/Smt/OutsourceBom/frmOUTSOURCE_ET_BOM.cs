using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Smt.OutSource;
using UnidenDAL;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;
using UnidenDAL.Smt.OutsourceBom;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.IO;
using ExcelDataReader;
using Z.Dapper.Plus;
using System.Data.SqlClient;

namespace SMTPRORAM.Smt.OutsourceBom
{
    public partial class frmOUTSOURCE_ET_BOM : Form
    {
        UVEntities em = new UVEntities();
        public frmOUTSOURCE_ET_BOM()
        {
            InitializeComponent();
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            var lst = new List<OUTSOURCE_ET_BOM>();
            lst = OUTSOURCE_ET_BOM_DAL.Instance.getAll();
            if (lst.Count>0)
            {
                lblProcess.Visible = true;
                lblProcess.Text = "Đang xóa dữ liệu .....................";
                lblProcess.Update();

                bool chek=OUTSOURCE_ET_BOM_DAL.Instance.DeleteAll();
                if (chek==true)
                {
                    MessageBox.Show("Đã xóa xong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblProcess.Visible=false;
                    CommonDAL.Instance.ClearDataGridView(dgView);
                    return;
                }
                else
                {
                    MessageBox.Show("Không xóa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblProcess.Visible = false;
                    return;
                }                
            }
            else
            {
                MessageBox.Show("Đã xóa xong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void iconbtnExportCSV_Click(object sender, EventArgs e)
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
                    if (dgView.Rows.Count > 0)
                    {
                        CommonDAL.Instance.writeCSV(dgView, filename);
                        MessageBox.Show("Đã export xong !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để download !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            //dgView.DataSource = dt;
            if (dt!=null)
            {
                List<OUTSOURCE_ET_BOM> etboms = new List<OUTSOURCE_ET_BOM>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var etbom= new OUTSOURCE_ET_BOM();
                    etbom.ID = i + 1;
                    etbom.Plant = dt.Rows[i]["Plant"].ToString();
                    etbom.OrderNo = dt.Rows[i]["Order"].ToString();
                    etbom.Parts = dt.Rows[i]["Material"].ToString();
                    etbom.Qty = double.Parse(dt.Rows[i]["Requirement Quantity (EINHEIT)"].ToString());
                    etboms.Add(etbom);
                }               
                var _entities = new UVEntities();
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    _entities.OUTSOURCE_ET_BOM.AddRange(etboms);
                    _entities.SaveChanges();
                    lblProcess.Visible = false;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                
                dgView.DataSource = etboms;
            }
        }
        DataTableCollection tableCollection;

        private void iconbtnBrowse_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog(){Filter= "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    tableCollection=CommonDAL.Instance.BrowserExcelToCombobox(txtFilename.Text);
                    cbSheet.Items.Clear();
                    foreach (DataTable table in tableCollection)
                        cbSheet.Items.Add(table.TableName); //add sheet to combo
                    //using (var stream=File.Open(openFileDialog.FileName,FileMode.Open,FileAccess.Read))
                    //{
                    //    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    //    {
                    //        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    //        {
                    //            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    //        });
                    //        tableCollection = result.Tables;
                    //        cbSheet.Items.Clear();
                    //        foreach (DataTable table in tableCollection)
                    //            cbSheet.Items.Add(table.TableName); //add sheet to combo
                    //    }
                    //}    
                }
            }    
        }

        private void frmOUTSOURCE_ET_BOM_Load(object sender, EventArgs e)
        {
            lblProcess.Text = "";
            lblProcess.Visible = false;
            if (OUTSOURCE_ET_BOM_DAL.Instance.getAll().Count>0)
            {
                CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_ET_BOM_DAL.Instance.getAll());
            }
            else
            {
                MessageBox.Show("No data found !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void iconbtnView_Click(object sender, EventArgs e)
        {
            //CommonDAL.Instance.ClearDataGridView(dgView);
            CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_ET_BOM_DAL.Instance.getListUVLot());
        }
    }
}
