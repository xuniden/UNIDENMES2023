using DocumentFormat.OpenXml.Drawing.Diagrams;
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
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Smt.Output;
using UnidenDTO;

namespace SMTPRORAM.Smt.View
{
    public partial class frmFViewByQRCode : Form
    {
		private string search;
		private int currentPage = 1;
		private int recordsPerPage = 100;
		private int totalPages;
		private List<EASTECH_SMT_OUTPUT> lstResult;
		public frmFViewByQRCode()
        {
            InitializeComponent();
        }

        private void frmFViewByQRCode_Load(object sender, EventArgs e)
        {
            lblRecod.Text = "";
            cbSelect.Text = "--Select--";
        }
		private void LoadDataByPage(int Option, int page, string search, DateTime frm, DateTime to)
		{
			if (Option == 1) // QR
			{
				lstResult = SmtAOIQrCodeOutputDAL.Instance.searchByQRModelPartPagesEntity(1, page, recordsPerPage, search,frm,to);
				if (lstResult.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridView(dgView, lstResult);
				}
			}
			if(Option==2) // Part
			{
				lstResult = SmtAOIQrCodeOutputDAL.Instance.searchByQRModelPartPagesEntity(2, page, recordsPerPage, search, frm, to);
				if (lstResult.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridView(dgView, lstResult);
				}
			}
			//if (Option == 3) // Model
			//{
			//	lstResult = SmtAOIQrCodeOutputDAL.Instance.searchByQRModelPartPagesEntity(3, page, recordsPerPage, search, frm, to);
			//	if (lstResult.Count > 0)
			//	{
			//		CommonDAL.Instance.ShowDataGridView(dgView, lstResult);
			//	}
			//}
		}

		private void SearchByPart(int Option, string search, DateTime frm, DateTime to)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập Part cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtQRCode.Focus();
				return;
			}
			else
			{
				long totalRecords = 0;
				currentPage = 1;
				if (Option == 1)
				{
					totalRecords = SmtAOIQrCodeOutputDAL.Instance.CountSearchPartAndProgram(1, search ,frm,to);
					if (totalRecords > 0)
					{
						LoadDataByPage(1, currentPage, search,frm,to);
					}
				}
				if (Option == 2)
				{
					totalRecords = SmtAOIQrCodeOutputDAL.Instance.CountSearchPartAndProgram(2, search, frm, to);
					if (totalRecords > 0)
					{
						LoadDataByPage(2, currentPage, search, frm, to);
					}
				}
				//if (Option == 3)
				//{
				//	totalRecords = SmtAOIQrCodeOutputDAL.Instance.CountSearchPartAndProgram(3, search, frm, to);
				//	if (totalRecords > 0)
				//	{
				//		LoadDataByPage(3, currentPage, search, frm, to);
				//	}
				//}
				totalPages = ((int)(totalRecords / recordsPerPage) + 1);
				lbltotalPages.Text = totalPages.ToString();
				lblCurrentPage.Text = currentPage.ToString();				
				lblRecod.Text = totalRecords.ToString();
			}
		}


		private void btFind_Click(object sender, EventArgs e)
		{
			
			DateTime start = dtp_1.Value.Date;
			DateTime endd = dtp_2.Value.Date;
			if (cbSelect.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn loại tìm kiếm theo Model, Qrcode, Partcode ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbSelect.Focus();
				return;
			}
			else
			{			
				TimeSpan diff = endd.Subtract(start);
				if (diff.TotalDays >= 0)
				{
					if (string.IsNullOrEmpty(txtQRCode.Text.Trim()))
					{
						MessageBox.Show("Nhập giá trị cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtQRCode.Focus();
						return;
					}
					else
					{
						search = txtQRCode.Text.Trim();
						if (cbSelect.Text.Equals("QRCode"))
						{
							SearchByPart(1,search ,start,endd);
						}
						if (cbSelect.Text.Equals("Partcode"))
						{
							SearchByPart(2, search, start, endd);
						}
						//if (cbSelect.Text.Equals("Model"))
						//{
						//	SearchByPart(3, search, start, endd);
						//}
					}
				}
				else
				{
					MessageBox.Show("Nhập ngày không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					dtp_2.Focus();
					return;
				}
			}
			
			
			if (txtQRCode.Text.Trim().Equals(""))
			{
				MessageBox.Show("QRCode không được để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			/*
			//DateTime start = dtp_1.Value.Date;
			//DateTime endd = dtp_2.Value.Date;
			//TimeSpan diff = endd.Subtract(start);
			//if (diff.TotalDays >= 0)
			//{
			//	try
			//	{
			//		var dt = new DataTable();
			//		dt = SmtAOIQrCodeOutputDAL.Instance.SearchQrcodeByDate(txtQRCode.Text.Trim(), start, endd);
			//		//var q = SmtAOIQrCodeOutputDAL.Instance.SearchQRCodeByDateNew(txtQRCode.Text.Trim(), start, endd);
			//		//if (q.Count>0)
			//		//{
			//		//    lblRecod.Text = q.Count.ToString();
			//		//    CommonDAL.Instance.ShowDataGridView(dgView, q);
			//		//}
			//		if (dt.Rows.Count > 0)
			//		{
			//			lblRecod.Text = dt.Rows.Count.ToString();
			//			dgView.DataSource = dt;
			//			dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			//		}
			//		else
			//		{
			//			MessageBox.Show("Không tìm thấy dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//			return;
			//		}

			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Đã có lỗi xảy ra:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//		return;
			//	}
			//}
			//else
			//{
			//	MessageBox.Show("Nhập ngày không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//	return;
			//}
			*/
		}
		//private void btDownload_Click(object sender, EventArgs e)
		//{
		//    try
		//    {
		//        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
		//        excel.Visible = true;
		//        Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
		//        Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
		//        int StartCol = 1;
		//        int StartRow = 1;
		//        int j = 0, i = 0;

		//        DateTime time = DateTime.Now;
		//        string st = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString();
		//        SaveFileDialog sfd = new SaveFileDialog();
		//        sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
		//        sfd.FileName = "Export_Data_" + st + ".xlsx";
		//        if (sfd.ShowDialog() == DialogResult.OK)
		//        {
		//            //Write Headers
		//            for (j = 0; j < dgView.Columns.Count; j++)
		//            {
		//                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
		//                myRange.Value2 = dgView.Columns[j].HeaderText;
		//            }

		//            StartRow++;

		//            //Write datagridview content
		//            for (i = 0; i < dgView.Rows.Count; i++)
		//            {
		//                for (j = 0; j < dgView.Columns.Count; j++)
		//                {
		//                    try
		//                    {
		//                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
		//                        myRange.Value2 = dgView[j, i].Value == null ? "" : dgView[j, i].Value;
		//                    }
		//                    catch
		//                    {
		//                        ;
		//                    }
		//                }
		//            }

		//            workbook.SaveAs(sfd.FileName);
		//            excel.Quit();
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show(ex.ToString());
		//    }
		//}

		private void btToCsv_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count > 0)
            {
                string filename = "";
                var dt = new DataTable();
                DateTime start = dtp_1.Value.Date;
                DateTime endd = dtp_2.Value.Date;
                dt = SmtAOIQrCodeOutputDAL.Instance.SearchQrcodeByDate(txtQRCode.Text.Trim(), start, endd);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"D:\";
                saveFileDialog1.Title = "Save Csv Files";
                //saveFileDialog1.CheckFileExists = true;
                //saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "Text files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
					filename = saveFileDialog1.FileName;
					var lstResult22 = new List<EASTECH_SMT_OUTPUT>();
					if (cbSelect.Text.Equals("QRCode"))
					{
						lstResult22 = SmtAOIQrCodeOutputDAL.Instance.DownloadData(1, txtQRCode.Text.Trim(),dtp_1.Value.Date,dtp_2.Value.Date);
					}
					if (cbSelect.Text.Equals("Partcode"))
					{
						lstResult22 = SmtAOIQrCodeOutputDAL.Instance.DownloadData(2, txtQRCode.Text.Trim(), dtp_1.Value.Date, dtp_2.Value.Date);
					}
					if (lstResult22.Count > 0)
					{
						try
						{
							CommonDAL.Instance.WriteCSV(lstResult22, filename);
							MessageBox.Show("Export Finished !!!");
						}
						catch (Exception ex)
						{
							MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}

					}
					//filename = saveFileDialog1.FileName;
					//if (dt.Rows.Count > 0)
					//{
					//    Common.writeCSV(dgView, filename);
					//}
					//else
					//{
					//    MessageBox.Show("Không có dữ liệu");
					//    return;
					//}

				}
            }
        }

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			currentPage++;
			if (currentPage > totalPages)
			{
				currentPage = totalPages;
			}
			lblCurrentPage.Text = currentPage.ToString();
			if (cbSelect.Text.Equals("QRCode"))
			{
				LoadDataByPage(1, currentPage, search,dtp_1.Value.Date,dtp_2.Value.Date);
			}
			if (cbSelect.Text.Equals("Partcode"))
			{
				LoadDataByPage(2, currentPage, search, dtp_1.Value.Date, dtp_2.Value.Date);
			}
			//if (cbSelect.Text.Equals("Model"))
			//{
			//	LoadDataByPage(3, currentPage, search, dtp_1.Value.Date, dtp_2.Value.Date);
			//}
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (currentPage > 1)
			{
				currentPage--;
				lblCurrentPage.Text = currentPage.ToString();
				if (cbSelect.Text.Equals("QRCode"))
				{
					LoadDataByPage(1, currentPage, search, dtp_1.Value.Date, dtp_2.Value.Date);
				}
				if (cbSelect.Text.Equals("Partcode"))
				{
					LoadDataByPage(2, currentPage, search, dtp_1.Value.Date, dtp_2.Value.Date);
				}
				//if (cbSelect.Text.Equals("Model"))
				//{
				//	LoadDataByPage(3, currentPage, search, dtp_1.Value.Date, dtp_2.Value.Date);
				//}
			}
		}
	}
}
