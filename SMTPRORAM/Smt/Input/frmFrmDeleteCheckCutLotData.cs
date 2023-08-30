using SMTPROGRAM_Bu;
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
using UnidenDAL.Smt.Input;
using ZedGraph;

namespace SMTPRORAM.Smt.Input
{
    public partial class frmFrmDeleteCheckCutLotData : Form
    {
        public frmFrmDeleteCheckCutLotData()
        {
            InitializeComponent();
        }
        private void ShowDataCutLot(string programName, string lineName)
        {
			if (programName != null && lineName != null)
			{
				var dtt = new DataTable();
				dtt = EASTECH_PROGRAMHISTORY_DAL.Instance.getCutLotData(programName, lineName);
				if (dtt.Rows.Count > 0)
				{
					lblkiemtra.Text = dtt.Rows.Count.ToString();
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dtt);
				}
			}
			else
			{
				txtProgram.Focus();
			}
		}

        private void frmFrmDeleteCheckCutLotData_Load(object sender, EventArgs e)
        {
            string programName = frmFUserCheck.programName;
            string lineName=frmFUserCheck.lineName;
            lblkiemtra.Text = "";               
            ShowDataCutLot(programName, lineName);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowDataCutLot(txtProgram.Text.Trim(), txtLine.Text.Trim());   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu này không ???", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
				List<long> IdList = new List<long>();
                if (dgView.Rows.Count>0)
                {                    
					foreach (DataGridViewRow item in dgView.Rows)
					{
						IdList.Add(long.Parse(item.Cells["Id"].Value.ToString()));						
					}
                    if (IdList.Count>0)
                    {
                       string message= EASTECH_PROGRAMHISTORY_DAL.Instance.DeleteCutLotDataNotUse(IdList);
                        if (string.IsNullOrEmpty(message))
                        {
							ShowDataCutLot(txtProgram.Text.Trim(), txtLine.Text.Trim());
						}
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra: "+message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            return;
                        }
					}
				}
				//foreach (DataGridViewRow item in dgView.Rows)
    //            {
    //                long Id = long.Parse(item.Cells["Id"].Value.ToString());
    //                EastechHistory_Services.EastechHistory_DelCutLotQtyFeeder(Id);
    //            }

                //if (!Program.chuyenLineprokey.Equals("") && !Program.chuyenLineNewLine.Equals(""))
                //{
                //    var dtt = new DataTable();
                //    dtt = EastechHistory_Services.EastechHistory_CheckCutLotQtyFeeder(Program.chuyenLineprokey, Program.chuyenLineNewLine);
                //    if (dtt.Rows.Count > 0)
                //    {
                //        lblkiemtra.Text = dtt.Rows.Count.ToString();
                //        dgView.DataSource = dtt;
                //        dgView.AutoResizeColumns();
                //        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //    }
                //    else
                //    {
                //        dgView.DataSource = null;
                //        MessageBox.Show("Đã xóa xong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                //else if (!txtProgram.Text.Equals("") && !txtLine.Text.Equals(""))
                //{
                //    var dtt = new DataTable();
                //    dtt = EastechHistory_Services.EastechHistory_CheckCutLotQtyFeeder(txtProgram.Text, txtLine.Text);
                //    if (dtt.Rows.Count > 0)
                //    {
                //        lblkiemtra.Text = dtt.Rows.Count.ToString();
                //        dgView.DataSource = dtt;
                //        dgView.AutoResizeColumns();
                //        dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //    }
                //    else
                //    {
                //        dgView.DataSource = null;
                //        MessageBox.Show("Đã xóa xong dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}

            }
        }
    }
}
