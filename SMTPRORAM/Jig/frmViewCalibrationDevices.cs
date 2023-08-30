using DocumentFormat.OpenXml.Office2010.Excel;
using EzioDll;
using Microsoft.Office.Interop.Excel;
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
using UnidenDAL.Jig;
using UnidenDAL.Smt.DataControl;

namespace SMTPRORAM.Jig
{
    public partial class frmViewCalibrationDevices : Form
    {
        private string ControlNo = "";
        private string txtEqName = "";
        private string SerialNumber = "";
        private string Model = "";
        public static string sendControlNo { get; private set; }
        public frmViewCalibrationDevices()
        {
            InitializeComponent();
        }
        private void LoadSampleData()
        {
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, JIGCALDEVICES_DAL.Instance.getjig_eq_getListEQ(1, ""));
        }
        private void frmViewCalibrationDevices_Load(object sender, EventArgs e)
        {
            LoadSampleData();
            txtSearch.Focus();
            try
            {
              CommonDAL.Instance.FindPrinter_USB(Cbo_USB);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy máy in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                Search(txtSearch.Text.Trim());
            }
        }
        private void Search(string search)
        {
            if (search=="")
            {
                MessageBox.Show("Nhập dữ liệu cần tìm ControlNo or Model", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                var dt= new System.Data.DataTable();
                dt = JIGCALDEVICES_DAL.Instance.getjig_eq_getListEQ(2, search);
                if (dt.Rows.Count>0)
                {
                    lblTotal.Text=dt.Rows.Count.ToString();
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
				}
                else
                {
					MessageBox.Show("Không tìm thấy dữ liệu !!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtSearch.Focus();
					lblTotal.Text = "0";
				}

            }
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text.Trim());
        }

        private void dgView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgView.RowCount > 0)
            //{
            //    DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
            //    sendControlNo = row.Cells["ControlNo"].Value.ToString();
            //    if (!sendControlNo.Equals(""))
            //    {
            //        var frmJIGINOUT = new frmJIGINOUT();
            //        frmJIGINOUT.ShowDialog();
            //    }
            //}
        }

        private void iconbtnPrint_Click(object sender, EventArgs e)
        {
            var Printer= new GodexPrinter();

            if (ControlNo!=""&& txtEqName!=""&& SerialNumber!=""&& Model!="")
            {
                CommonDAL.Instance.ConnectPrinter(RBtn_USB,Cbo_USB);
                Printer.Open(PortType.USB);
                string csString = "";

				if (ControlNo.Substring(0, 4) == "UVEQ")
                {
                    string qrcode = ControlNo + ";" + txtEqName + ";" + Model + ";" + SerialNumber;
                    string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,47,5,2,M0,8,3," + qrcode.Length + ",0\r\n";

                    string csString1 = "\r\nAB,118,48,1,1,0,0E,";
                    string model = Model;
                    string csString2 = "\r\nAB,118,79,1,1,0,0E,";
                    string serial = SerialNumber;
                    string scString3 = "\r\nAB,118,113,1,1,0,0E,";
                    string controlNo = ControlNo;
                    string csString4 = "\r\nAB,18,16,1,1,0,0E,";
                    string controlName = txtEqName;
                    string csString5 = "\r\nE\r\n";
                    csString = csString0 + qrcode + csString1 + model + csString2 + serial + scString3 + controlNo + csString4 + controlName + csString5;
                }
				else
                {
					string qrcode = ControlNo + ";" + txtEqName + ";" + Model + ";" + SerialNumber;
					string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,36,5,2,M0,8,3," + qrcode.Length + ",0\r\n";
					//string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,36,5,2,M0,8,3,40,0\r\nUVEQ-000000001;SP-6789;HLAB5001132100010" +
					//                      "\r\nAB,118,38,1,1,0,0E," +
					//                      "SP-0000001" +
					//                      "\r\nAB,118,69,1,1,0,0E," +
					//                      "Uniden VN" +
					//                      "\r\nAB,118,103,1,1,0,0E," +
					//                      "UVEQ-00000001" +
					//                      "\r\nAA,18,12,1,1,0,0E," +
					//                      "RE COMMUNICATION TEST SET" +
					//                      "\r\nE";

					//string qrcode = txtControlNo.Text.Trim() + ";" + txtEqName.Text.Trim() + ";" + txtModel.Text.Trim() + ";" + txtSerial.Text.Trim();
					string csString1 = "\r\nAB,118,38,1,1,0,0E,";
                    string model = Model;
					string csString2 = "\r\nAB,118,69,1,1,0,0E,";
                    string serial = SerialNumber;
					string scString3 = "\r\nAB,118,103,1,1,0,0E,";
                    string controlNo = ControlNo;
					string csString4 = "\r\nAA,18,12,1,1,0,0E,";
                    string controlName = txtEqName;
					string csString5 = "\r\nE\r\n";
					csString = csString0 + qrcode + csString1 + model + csString2 + serial + scString3 + controlNo + csString4 + controlName + csString5;

				}
				Printer.Command.Send(csString);
                ControlNo = "";
                txtEqName = "";
                SerialNumber = "";
                Model = "";
                Printer.Close();
            }
           
        }

        private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgView.Rows.Count>0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;                
                 ControlNo = row.Cells["ControlNo"].Value.ToString();
                 txtEqName = row.Cells["EqName"].Value.ToString();                
                 SerialNumber = row.Cells["SerialNumber"].Value.ToString();
                 Model = row.Cells["Model"].Value.ToString();
            }
        }
    }
}
