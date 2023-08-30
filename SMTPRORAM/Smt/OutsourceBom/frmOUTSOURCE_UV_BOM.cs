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
using Excel = Microsoft.Office.Interop.Excel;
using UnidenDAL;
using UnidenDTO;
using ExcelDataReader;
using System.IO;

namespace SMTPRORAM.Smt.OutsourceBom
{
    public partial class frmOUTSOURCE_UV_BOM : Form
    {
        public frmOUTSOURCE_UV_BOM()
        {
            InitializeComponent();
        }
        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            var lst = new List<OUTSOURCE_UV_BOM>();
            lst = OUTSOURCE_UV_BOM_DAL.Instance.getAll();
            if (lst.Count > 0)
            {
                bool chek = OUTSOURCE_UV_BOM_DAL.Instance.DeleteAll();
                if (chek == true)
                {
                    MessageBox.Show("Đã xóa xong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonDAL.Instance.ClearDataGridView(dgView);
                    return;
                }
                else
                {
                    MessageBox.Show("Không xóa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }

        private void iconbtnDiffBOM_Click(object sender, EventArgs e)
        {
            //CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_UV_BOM_DAL.Instance.getDiffBOMUVvsET());
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
        DataTableCollection tableCollection;
        private void iconbtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    tableCollection= CommonDAL.Instance.BrowserExcelToCombobox(txtFilename.Text);                    
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

        private void frmOUTSOURCE_UV_BOM_Load(object sender, EventArgs e)
        {
            lblProcess.Text = "";
            lblProcess.Visible = false;
            if (OUTSOURCE_UV_BOM_DAL.Instance.getAll().Count>0)
            {
                CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_UV_BOM_DAL.Instance.getAll());
            }
            else
            {
                MessageBox.Show("No data found !!!","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            //dgView.DataSource = dt;
            if (dt != null)
            {
                var uvboms = new List<OUTSOURCE_UV_BOM>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var uvbom = new OUTSOURCE_UV_BOM();
                    uvbom.ID = i + 1;
                    uvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    uvbom.Model = dt.Rows[i]["Model"].ToString();
                    uvbom.Parts = dt.Rows[i]["Uvparts"].ToString();
                    uvbom.ETPart = dt.Rows[i]["Etparts"].ToString();
                    #region Không dùng replace part
                    //if (dt.Rows[i]["Rp1"].ToString().Length>0)
                    //{
                    //    var UvToEtPart = new OUTSOURCE_UVPartsVsETParts();
                    //    UvToEtPart = OUTSOURCE_UVPartsVsETPartsDAL.Instance.UVPartToETPart(dt.Rows[i]["Rp1"].ToString());
                    //    if (UvToEtPart != null)
                    //    {
                    //        var aduvbom = new OUTSOURCE_UV_BOM();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Model = dt.Rows[i]["Model"].ToString();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Parts = UvToEtPart.Name;
                    //        aduvbom.ETPart = UvToEtPart.ETParts;
                    //        uvboms.Add(aduvbom);
                    //    }
                    //}
                    //if (dt.Rows[i]["Rp2"].ToString().Length > 0)
                    //{
                    //    var UvToEtPart = new OUTSOURCE_UVPartsVsETParts();
                    //    UvToEtPart = OUTSOURCE_UVPartsVsETPartsDAL.Instance.UVPartToETPart(dt.Rows[i]["Rp2"].ToString());
                    //    if (UvToEtPart != null)
                    //    {
                    //        var aduvbom = new OUTSOURCE_UV_BOM();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Model = dt.Rows[i]["Model"].ToString();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Parts = UvToEtPart.Name;
                    //        aduvbom.ETPart = UvToEtPart.ETParts;
                    //        uvboms.Add(aduvbom);
                    //    }
                    //}
                    //if (dt.Rows[i]["Rp3"].ToString().Length > 0)
                    //{
                    //    var UvToEtPart = new OUTSOURCE_UVPartsVsETParts();
                    //    UvToEtPart = OUTSOURCE_UVPartsVsETPartsDAL.Instance.UVPartToETPart(dt.Rows[i]["Rp3"].ToString());
                    //    if (UvToEtPart != null)
                    //    {
                    //        var aduvbom = new OUTSOURCE_UV_BOM();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Model = dt.Rows[i]["Model"].ToString();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Parts = UvToEtPart.Name;
                    //        aduvbom.ETPart = UvToEtPart.ETParts;
                    //        uvboms.Add(aduvbom);
                    //    }
                    //}
                    //if (dt.Rows[i]["Rp4"].ToString().Length > 0)
                    //{
                    //    var UvToEtPart = new OUTSOURCE_UVPartsVsETParts();
                    //    UvToEtPart = OUTSOURCE_UVPartsVsETPartsDAL.Instance.UVPartToETPart(dt.Rows[i]["Rp4"].ToString());
                    //    if (UvToEtPart != null)
                    //    {
                    //        var aduvbom = new OUTSOURCE_UV_BOM();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Model = dt.Rows[i]["Model"].ToString();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Parts = UvToEtPart.Name;
                    //        aduvbom.ETPart = UvToEtPart.ETParts;
                    //        uvboms.Add(aduvbom);
                    //    }
                    //}
                    //if (dt.Rows[i]["Rp5"].ToString().Length > 0)
                    //{
                    //    var UvToEtPart = new OUTSOURCE_UVPartsVsETParts();
                    //    UvToEtPart = OUTSOURCE_UVPartsVsETPartsDAL.Instance.UVPartToETPart(dt.Rows[i]["Rp5"].ToString());
                    //    if (UvToEtPart != null)
                    //    {
                    //        var aduvbom = new OUTSOURCE_UV_BOM();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Model = dt.Rows[i]["Model"].ToString();
                    //        aduvbom.LotNo = dt.Rows[i]["Order No"].ToString();
                    //        aduvbom.Parts = UvToEtPart.Name;
                    //        aduvbom.ETPart = UvToEtPart.ETParts;
                    //        uvboms.Add(aduvbom);
                    //    }
                    //}
                    #endregion
                    uvboms.Add(uvbom);
                }
                var _entities = new UVEntities();
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    _entities.OUTSOURCE_UV_BOM.AddRange(uvboms);
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //dgView.DataSource = OUTSOURCE_UV_BOM_DAL.Instance.getDiffBOMUVvsET();
            CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_UV_BOM_DAL.Instance.getDiffBOMUVvsET());
        }
    }
}
