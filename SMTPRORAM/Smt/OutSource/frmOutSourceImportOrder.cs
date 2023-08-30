using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;
using UnidenDAL.Smt.OutSource;
using UnidenDAL;
using UnidenDTO;
using Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.Smt.OutSource
{
    public partial class frmOutSourceImportOrder : Form
    {
        
        public frmOutSourceImportOrder()
        {
            InitializeComponent();
        }

        
        private void SearchOrderNo(string search)
        {
            if (search=="")
            {
                CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getTatCaDuLieu());
                lblCount.Text = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getTatCaDuLieu().Count().ToString();
            }
            else
            {
                CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getTimKiemTheoOrder(search));
                lblCount.Text= SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getTimKiemTheoOrder(search).Count().ToString();
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SearchOrderNo(txtSearch.Text.Trim());
            }
            
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            SearchOrderNo(txtSearch.Text.Trim());
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (!txtOrder.Equals(""))
            {
                // Kiểm tra xem có số order này trong csdl không?
                // Nếu có thì cho phép xóa
                var lst=SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getTimKiemTheoListOrder(txtOrder.Text.Trim());
                if ( lst.Count>0)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa:  "+ lst.Count + " dòng dữ liệu không ???", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.RemoveRange(lst))
                        {
                            MessageBox.Show("Đã xóa thành công Order: " + txtOrder.Text.Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {

                            MessageBox.Show("Không xóa thành công Order: " + txtOrder.Text.Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }                    
                }
            }
        }

        private void frmOutSourceImportOrder_Load(object sender, EventArgs e)
        {
            lblCount.Text = "";
            lblProcess.Visible = false;
            lblProcess.Text = "";
        }
        DataTableCollection tableCollection;
        private void iconbtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    tableCollection = CommonDAL.Instance.BrowserExcelToCombobox(txtFilename.Text);
                    cbSheet.Items.Clear();
                    foreach (System.Data.DataTable table in tableCollection)
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

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            //dgView.DataSource = dt;
            if (dt != null)
            {
                List<SMT_OUTSOURCE_ORDER_IMPORT> orderImports = new List<SMT_OUTSOURCE_ORDER_IMPORT>();
                lblProcess.Visible = true;
                lblProcess.Text = "Đang đọc dữ liệu ............";
                lblProcess.Update();
                DateTime date = new DateTime();
                date= CommonDAL.Instance.getSqlServerDatetime();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        var orderImport = new SMT_OUTSOURCE_ORDER_IMPORT();
                        orderImport.ID = i + 1;
                        orderImport.Plant = dt.Rows[i]["Plant"].ToString();
                        orderImport.OrderNo = dt.Rows[i]["Order"].ToString();
                        orderImport.Partcode = dt.Rows[i]["Material"].ToString();
                        orderImport.Qty = float.Parse(dt.Rows[i]["Requirement Quantity (EINHEIT)"].ToString());
                        orderImport.LotSize = long.Parse(dt.Rows[i]["LotSize"].ToString());
                        orderImport.Week = int.Parse(dt.Rows[i]["Week"].ToString());
                        orderImport.CreatedBy = Program.UserId;
                        orderImport.CreatedDate = date;
                        orderImport.UpdateDate = date;
                        //if (i>71078)
                        //{
                        //    MessageBox.Show("Check");
                        //}
                        orderImports.Add(orderImport);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                   
                }
                var _entities = new UVEntities();
                lblProcess.Visible = false;
                CommonDAL.Instance.BeginTransaction();
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    _entities.SMT_OUTSOURCE_ORDER_IMPORT.AddRange(orderImports);
                    _entities.SaveChanges();
                    CommonDAL.Instance.CommitTransaction();
                    lblProcess.Visible = false;
                }
                catch (Exception ex)
                {
                    CommonDAL.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgView.DataSource = orderImports;
            }
        }

        private void iconbtnShowMrp_Click(object sender, EventArgs e)
        {
            dgView.DataSource = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getBeforeMRPData();
        }

        private void iconbtnExport_Click(object sender, EventArgs e)
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
