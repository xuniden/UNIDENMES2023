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
using UnidenDTO;

namespace SMTPRORAM.Whs
{
    public partial class frmInLottagIqcLabel : Form
    {
        private List<WHS_RECEIVING_INPUT> lst;
        public frmInLottagIqcLabel()
        {
            InitializeComponent();
        }

        private void frmInLottagIqcLabel_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            // reportViewer1.LocalReport.ReportEmbeddedResource= filePath;

            ResourceManager.GetResourceInfo("Report_Lottag_Iqc_Label.rdlc", "SMTPRORAM.Resources");
            if (ResourceManager.resourceExists == false)
                return;

            //Loads packages.config in Bin/Debug
            ResourceManager.LoadResource("Report_Lottag_Iqc_Label.rdlc");
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Report_Lottag_Iqc_Label.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = filePath;


            lst = new List<WHS_RECEIVING_INPUT>();
            lst = frmReceivingInput.lst;
            this.reportViewer1.LocalReport.ReportPath = filePath;

            ReportDataSource reportDataSource = new ReportDataSource("DataSetPrintLottag", lst);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();

        }
    }
}
