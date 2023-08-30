using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.whs;
using UnidenDTO;

namespace SMTPRORAM.Whs
{
    public partial class frmViewReceivingInListGiaoHang : Form
    {
        private List<WHS_RECEIVING_INPUT> lst;
        private List<WHS_LOCATION> lstLoc;
        public frmViewReceivingInListGiaoHang()
        {
            InitializeComponent();
        }

        private void frmViewReceivingInListGiaoHang_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            // reportViewer1.LocalReport.ReportEmbeddedResource= filePath;

            ResourceManager.GetResourceInfo("Report_Receiving_In_List_giaohang.rdlc", "SMTPRORAM.Resources");
            if (ResourceManager.resourceExists == false)
                return;

            //Loads packages.config in Bin/Debug
            ResourceManager.LoadResource("Report_Receiving_In_List_giaohang.rdlc");
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Report_Receiving_In_List_giaohang.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = filePath;


            lst = new List<WHS_RECEIVING_INPUT>();
            lst = frmReceivingInput.lst;
            lstLoc= new List<WHS_LOCATION>();
            lstLoc = frmReceivingInput.lstLoc;
            this.reportViewer1.LocalReport.ReportPath = filePath;

            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", lst);
            ReportDataSource reportDataSource2 = new ReportDataSource("DataSet2", lstLoc);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.RefreshReport();

        }
    }
}
