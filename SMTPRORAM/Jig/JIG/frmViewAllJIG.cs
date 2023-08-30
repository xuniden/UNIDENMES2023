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
using UnidenDAL.Jig.JIG;
using UnidenDAL.Smt.DataControl;

namespace SMTPRORAM.Jig.JIG
{
    public partial class frmViewAllJIG : Form
    {
        public static string sendControlNo { get;private set; }
        private string ControlNo = "";
        private string txtEqName = "";
        private string MakeDate = "";
        private string Model = "";
        public frmViewAllJIG()
        {
            InitializeComponent();
        }
        private void LoadSampleData()
        {
            var dt= new System.Data.DataTable();
            dt = JIGHCALDEVICES_DAL.Instance.getjig_eq_getListJIG(1, "");
            lblTotal.Text = dt.ToString();
			CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
        }
        private void frmViewAllJIG_Load(object sender, EventArgs e)
        {
            lblTotal.Text = "";
           
            try
            {
                CommonDAL.Instance.FindPrinter_USB(Cbo_USB);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy máy in: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (frmHJIGDEVICES.sendControl!=null && frmHJIGDEVICES.sendControl!="")
            {
                txtSearch.Text = frmHJIGDEVICES.sendControl;
                iconbtnSearch.PerformClick();
            }
            else
            {
                LoadSampleData();
            }
            

        }

        private void Search(string search)
        {
            if (string.IsNullOrEmpty(search)||search.Equals(""))
            {
                MessageBox.Show("Nhập điều kiện tìm kiếm vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var dt= new System.Data.DataTable();
                dt = JIGHCALDEVICES_DAL.Instance.getListJIG(search);
                if (dt.Rows.Count>0)
                {
					lblTotal.Text = dt.Rows.Count.ToString();
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
				}
                else
                {
					MessageBox.Show("Không tìm thấy dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtSearch.Focus();
					lblTotal.Text = "0";
				}
               
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                Search(txtSearch.Text.Trim());
            }
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text.Trim());
        }

        private void dgView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (dgView.RowCount > 0)
            //{
            //    DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
            //    sendControlNo = row.Cells["ControlNo"].Value.ToString();
            //    if (!sendControlNo.Equals(""))
            //    {
            //        var frmINOUTJIG = new frmINOUTJIG();
            //        frmINOUTJIG.ShowDialog();
            //    }
            //}
        }

        private void iconbtnPrint_Click(object sender, EventArgs e)
        {
            var Printer = new GodexPrinter();
            string Control = "";
            string Model = "";
            string CName = "";
            DataGridViewRow row = dgView.SelectedCells[0].OwningRow;

            Control = row.Cells["ControlNo"].Value.ToString();
            CName = row.Cells["EqName"].Value.ToString();
            Model = row.Cells["Model"].Value.ToString();


            if (Control != "" && CName != "" && Model != "" )
            {
                CommonDAL.Instance.ConnectPrinter(RBtn_USB, Cbo_USB);
                Printer.Open(PortType.USB);
				//"^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S4\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW18,47,5,2,M0,8,3,27,0\r\nUVJE-0064-KY01;UT630F-17314\r\nAA,19,16,1,1,0,0E,MIC CHECK JIG(JIG ESD)\r\nAC,107,47,1,1,0,0E,UT630F-17314\r\nAC,107,92,1,1,0,0E,UVJE-0064-KY01\r\nE"
				//string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S4\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW18,47,5,2,M0,8,3,27,0\r\n";
				string qrcode = Control + ";" + Model;
				//string csString1 = "\r\nAA,19,16,1,1,0,0E,";
				////Ten GoLabel
				//string csString2 = "\r\nAC,107,47,1,1,0,0E,";
				////Control No
				//string scString3 = "\r\nAC,107,92,1,1,0,0E,";
				////Model
				//string csString4 = "\r\nE\r\n";

				//string csString = csString0 + qrcode + csString1 + CName + csString2 + Model + scString3 + Control + csString4;
				string csString = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H12\r\n^P1\r\n^S4\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW20,52,5,2,M0,8,3," + qrcode.Length +",0\r\n" + qrcode + "\r\nAA,22,16,1,1,0,0E," + CName + "\r\nAC,110,47,1,1,0,0E," + Model + "\r\nAC,110,92,1,1,0,0E," + Control + "\r\nE\r\n";
				Printer.Command.Send(csString);
                Control = "";
                CName = "";
                //MakeDate = "";
                Model = "";
                Printer.Close();
            }
        }

        private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgView.Rows.Count > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                ControlNo = row.Cells["ControlNo"].Value.ToString();
                txtEqName = row.Cells["EqName"].Value.ToString();
                MakeDate = row.Cells["MakeDate"].Value.ToString();
                Model = row.Cells["Model"].Value.ToString();
            }
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
