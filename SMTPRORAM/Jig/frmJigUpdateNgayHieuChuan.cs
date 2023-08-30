using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Smt.DataControl;
using UnidenDAL;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;
using UnidenDAL.Jig;

namespace SMTPRORAM.Jig
{
    public partial class frmJigUpdateNgayHieuChuan : Form
    {
        private class UpdateCal
        {
            public string ControlNo { get; set; }
            public DateTime CalDate { get; set; }
            public string CreatedBy { get; set; }
        }
            
        public frmJigUpdateNgayHieuChuan()
        {
            InitializeComponent();
            progressBar1.Visible= false;
        }
        DataTableCollection tableCollection;
        private void btUploadD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtUpload.Text = openFileDialog.FileName;
                    tableCollection = CommonDAL.Instance.BrowserExcelToCombobox(txtUpload.Text);
                    cbSheet.Items.Clear();
                    foreach (System.Data.DataTable table in tableCollection)
                        cbSheet.Items.Add(table.TableName); //add sheet to combo                    
                }
            }
        }

        private void iconbtnUpload_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            var _entities = new UVEntities();
            progressBar1.Maximum= dt.Rows.Count;
            if (dt != null)
            {
                var UpdateOk= new List<UpdateCal>();
                var update= new UpdateCal();
                List<JIG_CALDEVICES> jigCals = new List<JIG_CALDEVICES>();               
                DateTime date = CommonDAL.Instance.getSqlServerDatetime();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var jigCal = new JIG_CALDEVICES();
                    jigCal.ControlNo = dt.Rows[i]["ControlNo"].ToString();
                    update.ControlNo=jigCal.ControlNo;
                    if (JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(jigCal.ControlNo)!=null)
                    {
                        jigCal.CalDate = DateTime.Parse(dt.Rows[i]["CalDate"].ToString());
                        update.CalDate = jigCal.CalDate;                        
                        jigCal.CreatedBy = Program.UserId;
                        update.CreatedBy = jigCal.CreatedBy;
                        jigCal.UpdatedDate = date;
                        try
                        {
                            JIGCALDEVICES_DAL.Instance.UpdateHC(jigCal);
                            UpdateOk.Add(update); 
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show(exx.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }                       
                        progressBar1.PerformStep();
                    }           
                }
                dgView.DataSource = UpdateOk;
            }
        }
    }
}
