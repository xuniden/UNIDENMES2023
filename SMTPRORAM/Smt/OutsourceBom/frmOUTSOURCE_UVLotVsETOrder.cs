using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Smt.OutsourceBom;
using UnidenDAL;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.Smt.OutsourceBom
{
    public partial class frmOUTSOURCE_UVLotVsETOrder : Form
    {
        public frmOUTSOURCE_UVLotVsETOrder()
        {
            InitializeComponent();
        }       

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            var lst = new List<OUTSOURCE_UVLotVsETOrder>();
            lst = OUTSOURCE_UVLotVsETOrderDAL.Instance.getAll();
            if (lst.Count > 0)
            {
                bool chek = OUTSOURCE_UVLotVsETOrderDAL.Instance.DeleteAll();
                if (chek == true)
                {
                    MessageBox.Show("Đã xóa xong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Không xóa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }
        private void Search(string search)
        {
            CommonDAL.Instance.ShowDataGridView(dgView,OUTSOURCE_UVLotVsETOrderDAL.Instance.getListLotOrderNo(search));
        }
        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search(txtSearch.Text.Trim());
            }
            
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
                    foreach (DataTable table in tableCollection)
                        cbSheet.Items.Add(table.TableName); //add sheet to combo
                    //using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
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
            DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            //dgView.DataSource = dt;
            if (dt != null)
            {
                lblProcess.Visible = true;
                lblProcess.Text = "Đang đọc file excel  .....";
                lblProcess.Update();
                var uvboms = new List<OUTSOURCE_UVLotVsETOrder>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var uvbom = new OUTSOURCE_UVLotVsETOrder();
                    if (dt.Rows[i]["Lot"].ToString().Length>3)
                    {
                        uvbom.UModel = dt.Rows[i]["U-model"].ToString();
                        uvbom.Lot = dt.Rows[i]["Lot"].ToString();
                        uvbom.Status = dt.Rows[i]["Status"].ToString();
                        uvbom.MaterialCode = dt.Rows[i]["WO Material code"].ToString();
                        uvbom.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        uvbom.CreatedBy = Program.UserId;
                        uvboms.Add(uvbom);
                    }                    
                }
                lblProcess.Text = "";
                var _entities = new UVEntities();
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    _entities.OUTSOURCE_UVLotVsETOrder.AddRange(uvboms);
                    _entities.SaveChanges();
                    lblProcess.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                dgView.DataSource = uvboms;
            }
        }

        private void frmOUTSOURCE_UVLotVsETOrder_Load(object sender, EventArgs e)
        {
            CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_UVLotVsETOrderDAL.Instance.getAll());
        }
    }
}
