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
using Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.Smt.OutsourceBom
{
    public partial class frmOUTSOURCE_UVPartsVsETParts : Form
    {
        public frmOUTSOURCE_UVPartsVsETParts()
        {
            InitializeComponent();
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            var lst = new List<OUTSOURCE_UVPartsVsETParts>();
            lst = OUTSOURCE_UVPartsVsETPartsDAL.Instance.getAll();
            if (lst.Count > 0)
            {
                bool chek = OUTSOURCE_UVPartsVsETPartsDAL.Instance.DeleteAll();
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
            CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_UVPartsVsETPartsDAL.Instance.getPart(search));
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
                    foreach (System.Data.DataTable table in tableCollection)
                        cbSheet.Items.Add(table.TableName); //add sheet to combo                    
                }
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            //dgView.DataSource = dt;
            if (dt != null)
            {
                lblProcess.Visible = true;
                lblProcess.Text = "Đang đọc file excel  .....";
                lblProcess.Update();
                var uvetparts = new List<OUTSOURCE_UVPartsVsETParts>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var parts = new OUTSOURCE_UVPartsVsETParts();
                    parts.Type = dt.Rows[i]["Type"].ToString();
                    parts.Name = dt.Rows[i]["Name"].ToString();
                    parts.Revision = dt.Rows[i]["Revision"].ToString();
                    parts.Title = dt.Rows[i]["Title"].ToString();
                    parts.ETParts = dt.Rows[i]["UB-Description"].ToString();
                    parts.Spect = dt.Rows[i]["Spec"].ToString();
                    parts.Status = dt.Rows[i]["Status"].ToString();
                    parts.WFProcess = dt.Rows[i]["WF Process"].ToString();
                    parts.Ref = dt.Rows[i]["Ref"].ToString();
                    parts.Model = dt.Rows[i]["Owner Model"].ToString();
                    parts.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    parts.CreatedBy = Program.UserId;
                    uvetparts.Add(parts);
                }
                lblProcess.Text = "";
                var _entities = new UVEntities();
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    _entities.OUTSOURCE_UVPartsVsETParts.AddRange(uvetparts);
                    _entities.SaveChanges();
                    lblProcess.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                dgView.DataSource = uvetparts;
            }
        }

        private void frmOUTSOURCE_UVPartsVsETParts_Load(object sender, EventArgs e)
        {
            CommonDAL.Instance.ShowDataGridView(dgView, OUTSOURCE_UVPartsVsETPartsDAL.Instance.getAll());
        }
    }
}
