using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDTO;

namespace SMTPRORAM.Whs
{
    public partial class frmViewLottagReport : Form
    {
        private List<WHS_RECEIVING_INPUT> lst;
        public frmViewLottagReport()
        {
            InitializeComponent();
        }

        private void frmViewLottagReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            
           // reportViewer1.LocalReport.ReportEmbeddedResource= filePath;

            ResourceManager.GetResourceInfo("Report_Lottag_Iqc_Urgent.rdlc", "SMTPRORAM.Resources");
            if (ResourceManager.resourceExists == false)
                return;

            //Loads packages.config in Bin/Debug
            ResourceManager.LoadResource("Report_Lottag_Iqc_Urgent.rdlc");
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Report_Lottag_Iqc_Urgent.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = filePath;


            lst = new List<WHS_RECEIVING_INPUT>();
            lst = frmReceivingInput.lst;
            this.reportViewer1.LocalReport.ReportPath =filePath;

            ReportDataSource reportDataSource = new ReportDataSource("DataSetPrintLottag", lst);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();

        }
        public static void ApplyFontAllText(ReportDocument rapport, Font style)
        {

            foreach (ReportObject obj in rapport.ReportDefinition.ReportObjects)
            {
                if (obj.GetType().Name.Equals("FieldObject"))
                {

                    ((FieldObject)obj).ApplyFont(style);

                }
                //else if (obj.GetType().Name.Equals("FieldObject"))
                //{
                //    ((FieldObject)obj).ApplyFont(style);
                //}
            }
        }
        private void iconbtnPrintView_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
