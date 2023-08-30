using DocumentFormat.OpenXml.Office2010.Drawing.Charts;
using DocumentFormat.OpenXml.VariantTypes;
using SMTPRORAM.Smt.Output;
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
using UnidenDAL.Assy;
using UnidenDAL.Assy.Setup;
using UnidenDTO;

namespace SMTPRORAM.Assy
{
	public partial class frmDeleteByBarcode : Form
	{
		
		//private string Lot;
		//private string Line;
		//private long processId = 0;
		//private string processName;
		//private bool flagDelete = false;
		public frmDeleteByBarcode()
		{
			InitializeComponent();			
		}
		
		
		private void InitData()
		{
			txtSearch.Text = "";
			txtReason.Text = "";
			txtSearch.Focus();
		}
		private void frmDeleteByBarcode_Load(object sender, EventArgs e)
		{
			//Lot= frmCombineQRCode.lot; 
			//Line= frmCombineQRCode.line;
			//processId = frmCombineQRCode.processId;
			//if (processId!=0)
			//{
			//	var lineProcess = new UV_LINEPROCESS();
			//	lineProcess=LINEPROCESS_DAL.Instance.getProcessNameByProcessId(processId);
			//	processName=lineProcess.ProcessName;
			//}
			InitData();
		}
		

		private void Search(string search)
		{
			if (search=="")
			{
				MessageBox.Show("Barcode này không có trong CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSearch.Focus();
				return;
			}
			else
			{
				CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView,LINEPROCESSHISTORY_DAL.Instance.searchBarcodeToDelete(search));
			}
		}
		private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				Search(txtSearch.Text.Trim());
				// Kiểm tra xem Barcode này đã có trong csdl chưa? vào có thuộc lot đó không?
				//var lineProcess = new UV_LINEPROCESS_HISTORY();
				//lineProcess = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtSearch.Text, Lot, processId);
				//if (lineProcess!=null)
				//{
				//	txtReason.Focus();
				//	flagDelete=true;
				//}
				//else
				//{
				//	MessageBox.Show("Barcode này không có trong CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//	txtSearch.SelectAll();
				//	txtSearch.Focus();					
				//}
			}			
		}
		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			Search(txtSearch.Text.Trim());
		}
		private bool isOKData()
		{
			//if (flagDelete==false)
			//{
			//	MessageBox.Show("Barcode này không có trong CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//	txtSearch.SelectAll();
			//	txtSearch.Focus();
			//	return false;
			//}
			if (txtReason.Text.Equals(""))
			{
				MessageBox.Show("Phải nhập lý do xóa !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);				
				txtReason.Focus();
				return false;
			}
			return true;
		}

		private void iconbtnDelete_Click(object sender, EventArgs e)
		{
			if (isOKData())
			{
				foreach (DataGridViewRow row in dgView.Rows)
				{
					string messsage2 = "";
					long ID =long.Parse(row.Cells[0].Value.ToString());
					var uvlineProcess= LINEPROCESSHISTORY_DAL.Instance.getAllInfo(ID);
					if (uvlineProcess!=null)
					{
						var deleteBarcode = new UV_DELETEBARCODE();
						deleteBarcode.DeleteBar = uvlineProcess.QrCode00;
						deleteBarcode.Reason = txtReason.Text;
						deleteBarcode.Lot = uvlineProcess.Lot;
						deleteBarcode.LineName = uvlineProcess.LineName;
						deleteBarcode.ProcessID = uvlineProcess.ProcessId;
						deleteBarcode.ProcessName = uvlineProcess.ProcessName;
						deleteBarcode.CreatedBy = Program.UserId;
						deleteBarcode.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
						messsage2 = DELETEBARCODE_DAL.Instance.Add(deleteBarcode);
						if (messsage2 == "")
						{
							string message = "";
							message = LINEPROCESSHISTORY_DAL.Instance.DeleteBarcode(txtSearch.Text, uvlineProcess.Lot, uvlineProcess.ProcessId);
							if (message == "")
							{
								
							}
							else
							{
								MessageBox.Show("Đã thêm được dữ liệu vào Delete nhưng chưa xóa được dữ liệu tạo ra trước đó ở History", "Thông báo",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu vào lịch sửa xóa barcode", "Thông báo",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}
					}					
				}		

			}
		}

		private void frmDeleteByBarcode_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Kiểm tra xem dữ liệu đã được thêm vào csdl chưa?
			// Nếu chưa được thêm thì không cho đóng form
			//string message = "";
			//message=DELETEBARCODE_DAL.Instance.checkBeforeClose(txtSearch.Text,		Lot,processId);
			//if (message!="")			
			//{

			//	MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu vào lịch sửa xóa barcode", "Thông báo",
			//			MessageBoxButtons.OK, MessageBoxIcon.Information);
			//	e.Cancel = true;
			//}
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		
	}
}
