using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
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
using UnidenDAL.Smt.Input;
using UnidenDAL;

namespace SMTPRORAM.Smt.Input
{
    public partial class frmFViewIQCCheckerResult : Form
    {
        public frmFViewIQCCheckerResult()
        {
            InitializeComponent();
        }
		private void ShowData(string programName, string lineName)
		{
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
			if (programName != null && lineName != null)
			{
				txtProgram.Text = programName;
				txtLine.Text = lineName;
				lblTong.Text = SmtProgramDAL.Instance.getListByPro(programName).Count.ToString();
				var missingData = EASTECH_PROGRAMHISTORY_DAL.Instance.checkMissingListParts(programName, lineName);
				var currentData = EASTECH_PROGRAMHISTORY_DAL.Instance.getCurrentListParts(programName, lineName);
				if (missingData.Rows.Count > 0)
				{
					lblThieu.Text = missingData.Rows.Count.ToString();
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dataGridView1, missingData);
				}
				if (currentData.Rows.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dataGridView2, currentData);
				}
			}
			else
			{
				txtProgram.Focus();
			}
		}

		private void frmFViewIQCCheckerResult_Load(object sender, EventArgs e)
        {
			lblThieu.Text = "";
			lblTong.Text = "";
			string programName = frmFUserCheck.programName;
			string lineName = frmFUserCheck.lineName;
			ShowData(programName, lineName);
			#region Old Code
			/*
			var dg = new DataTable();
            var csv = new PROGRAMInfo();
            csv.programpartlist = Program.abcprogramkey;
            dg = PROGRAMService.PROGRAM_GetByID(csv);
            if (dg.Rows.Count > 0)
            {
                lblTong.Text = dg.Rows.Count.ToString();
            }

            if (!Program.abcprogramkey.Equals("") && !Program.abclinename.Equals(""))
            {
                var dtt = new DataTable();
                dtt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_Checker_Mistake(Program.abcprogramkey, Program.abclinename);
                var dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_Checker(Program.abcprogramkey, Program.abclinename);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                    return;
                }
                if (dtt.Rows.Count > 0)
                {
                    lblThieu.Text = dtt.Rows.Count.ToString();
                    dataGridView2.DataSource = dtt;
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {

                }
            }
            else
            {
                txtProgram.Focus();
            }
            */
			#endregion
		}

		private void button1_Click(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(txtProgram.Text.Trim()) && !string.IsNullOrEmpty(txtLine.Text.Trim()))
			{
				ShowData(txtProgram.Text.Trim(), txtLine.Text.Trim());
				#region Old Code
				/*
				var dg = new DataTable();
                var csv = new PROGRAMInfo();
                csv.programpartlist = txtProgram.Text;
                dg = PROGRAMService.PROGRAM_GetByID(csv);
                if (dg.Rows.Count > 0)
                {
                    lblTong.Text = dg.Rows.Count.ToString();
                }

                var dtt = new DataTable();
                dtt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_Checker_Mistake(txtProgram.Text, txtLine.Text);
                if (dtt.Rows.Count > 0)
                {
                    lblThieu.Text = dtt.Rows.Count.ToString();
                    dataGridView2.DataSource = dtt;
                    dataGridView2.AutoResizeColumns();
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {

                }

                var dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_Checker(txtProgram.Text, txtLine.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                    return;
                }
                */
				#endregion
			}
			else
			{
				MessageBox.Show("Nhập dữ liệu vào khi tìm kiếm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtProgram.Focus();
                return;
			}
		}

        private void btDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string filename = "";
                var dt = new DataTable();
                dt = Common_ClassBu.GetQrCodeNotYetScan(1, "", "");
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"D:\";
                saveFileDialog1.Title = "Save Csv Files";              
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "Text files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    if (dt.Rows.Count > 0)
                    {
                        Common.writeCSV(dataGridView1, filename);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu");
                        return;
                    }

                }
            }
        }

		private void txtLine_KeyDown(object sender, KeyEventArgs e)
		{
            if (Keys.Enter==e.KeyCode)
            {
				ShowData(txtProgram.Text.Trim(), txtLine.Text.Trim());
			}			
		}
	}
}
