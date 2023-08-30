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
using UnidenDTO;

namespace SMTPRORAM.Smt.Input
{
	public partial class frmNewIPQCCheck : Form
	{
		public static long id { get; private set; }
		public static string program { get; private set; }
		public static string linename { get; private set; }
		public static string fdrno { get; private set; }
		public static string partcode { get; private set; }
		public static string partcode2 { get; private set; }
		public static string datecode { get; private set; }
		public static int usage { get; private set; }
		public static int qty { get; private set; }
		public static string IDMaterial { get; private set; }
		public static string IDMaterial2 { get; private set; }


		private long IdLogcal;
		public frmNewIPQCCheck()
		{
			InitializeComponent();
		}
		private void defaultControl()
		{
			txtLine.Text = "";			
			txtprogram.Text = "";
			txtfeeder.Text = "";			
			txtLine.Focus();
		}
		private void setControls()
		{
			txtfeeder.Text = "";			
			txtfeeder.Focus();
		}
		private void frmNewIPQCCheck_Load(object sender, EventArgs e)
		{
			defaultControl();
			lblRecord.Text = "0";
		}
		
		private void SearchData()
		{
			if (txtLine.Text.Equals(""))
			{
				MessageBox.Show("Nhập Line Cần kiểm tra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtLine.Focus();
				return;
			}

			if (txtprogram.Text.Equals(""))
			{
				MessageBox.Show("Nhập chương trình cần kiểm tra ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtprogram.Focus();
				return;
			}			
			else
			{			
				var dt= new DataTable();
				dt= UV_SMT_STD_OP_HISTORY_DAL.Instance.IPQCCheckResult(txtLine.Text.Trim(), txtprogram.Text.Trim(), txtfeeder.Text.Trim());
				if (dt.Rows.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
					lblRecord.Text = dt.Rows.Count.ToString();
				}
				else
				{
					txtfeeder.SelectAll();
					txtfeeder.Focus();
				}
			}
		}

		

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			SearchData();
		}	

		private void txtLine_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				txtprogram.Focus();
			}
		}

		private void txtprogram_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				txtfeeder.Focus();
			}
		}

		private void txtfeeder_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SearchData();
			}
		}

		private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgView.RowCount > 0)
			{
				DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
				program = row.Cells[2].Value.ToString();
				linename = row.Cells[1].Value.ToString();
				id =long.Parse(row.Cells[0].Value.ToString());
				fdrno = row.Cells[3].Value.ToString();
				partcode = row.Cells[4].Value.ToString();
				partcode2 = row.Cells[5].Value.ToString();
				//qty =int.Parse( row.Cells[6].Value.ToString());
				//datecode = row.Cells[7].Value.ToString();
				//usage =int.Parse( row.Cells[9].Value.ToString());
				IDMaterial = row.Cells[13].Value.ToString();
				IDMaterial2 = row.Cells[14].Value.ToString();

				if (!program.Equals("")&&!linename.Equals("")&&!fdrno.Equals(""))
				{
					var frmIPQCConfirm = new frmIPQCConfirm();
					frmIPQCConfirm.ShowDialog();

					// Khở tạo lại 2 grid view
					var dt1 = new DataTable();
					var dt2 = new DataTable();
					dt1 = UV_SMT_STD_OP_HISTORY_DAL.Instance.IPQCCheckResult(linename, program, "");
					dt2 = UV_SMT_STD_OP_HISTORY_DAL.Instance.IPQCCheckResultAfterChecked(linename, program, Program.UserId);
					lblRecord.Text=dt1.Rows.Count.ToString();
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt1);
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgResult, dt2);
					// Truy cập vào TextBox trong frmIPQCConfirm
					//TextBox textBox1 = frmIPQCConfirm.Controls.Find("txtcheckPartcode", true).FirstOrDefault() as TextBox;
					//if (textBox1 != null)
					//{
					//	// Thực hiện các thao tác với TextBox
					//	textBox1.Focus();
					//}
				}
			}
		}

		private void dgResult_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			if (e.RowIndex >= dgView.FirstDisplayedScrollingRowIndex && e.RowIndex < (dgView.FirstDisplayedScrollingRowIndex + dgView.DisplayedRowCount(true)))
			{				
				DataGridViewRow row = dgView.Rows[e.RowIndex];
				string checkResult = row.Cells[7].Value.ToString();				
				if (checkResult=="NG")
				{
					// Thiết lập màu nền cho dòng dữ liệu
					row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
					// row.DefaultCellStyle.ForeColor = Color.White;
				}
			}
		}
	}
}
