using DocumentFormat.OpenXml.Spreadsheet;
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
using UnidenDAL.Staging;
using UnidenDAL.SysControl;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;

namespace SMTPRORAM.Assy
{
	public partial class frmRepairIssueByLine : Form
	{
		DataTableCollection tableCollection;
		private bool AddFlag = false;
		DataTable dt;
		private long Id = 0;
		private List<SYS_UserButtonFunction> lstUBFunction;
		private bool flagRepair=false;

		private string _line = string.Empty;
		private string _lot=string.Empty;
		private long processId = 0;
		private string processName = "";
		private void InitData()
		{
			txtBarcode.Enabled = true;
			txtBarcode.Text = "";
			cbProcess.Text = "--Select--";
			cbProcess.Enabled = false;
			cbErrorCode.Text = "--Select--";
			cbErrorCode.Enabled = false;
			cbLineName.Text = "--Select--";
			cbLineName.Enabled = false;
			txtLOT.Enabled = false;
			txtENDescription.Text = "";
			txtVNDescription.Text = "";
			txtReason.Enabled = false;
			txtReason.Text = "";
			txtBarcode.Focus();		
		}
	
		public frmRepairIssueByLine()
		{
			InitializeComponent();			
		}

		private void frmRepairIssueByLine_Load(object sender, EventArgs e)
		{
			LoadData();			
			//_line = Program.getLine;
			//_lot = Program.getLot;
			//processId = Program.getProcessId;
			//if (processId != 0)
			//{
			//	var lineProcess = new UV_LINEPROCESS();
			//	lineProcess = LINEPROCESS_DAL.Instance.getProcessNameByProcessId(processId);
			//	processName = lineProcess.ProcessName;
			//}
			InitData();
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
			txtReason.Enabled=false;
		}
		private bool checkBarcode2()
		{
			// Kiểm tra xem Barcode này đã có trong csdl chưa? vào có thuộc lot đó không?
			var lineProcess = new UV_LINEPROCESS_HISTORY();
			//lineProcess = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtBarcode.Text, _lot, processId);

			var mdList= new UV_MODELLOTINFO();
			mdList = MODELLOTINFO_DAL.Instance.getInfoByQRCode(txtBarcode.Text);


			lineProcess = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtBarcode.Text);
			if (lineProcess != null)
			{
				cbLineName.Enabled = false;
				flagRepair = true;
			}
			else 
			{
				if (mdList!=null)
				{
					cbLineName.Enabled = true;
					flagRepair = true;
				}
				else
				{
					MessageBox.Show("Barcode này không có trong CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}	
			
			return true;
		}
		private bool checkBarcode()
		{
			// Kiểm tra xem Barcode này đã có trong csdl chưa? vào có thuộc lot đó không?
			var lineProcess = new UV_LINEPROCESS_HISTORY();
			//lineProcess = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtBarcode.Text, _lot, processId);
			var mdlist= new UV_MODELLOTINFO();
			

			lineProcess = LINEPROCESSHISTORY_DAL.Instance.checkSannedQRCode(txtBarcode.Text);
			if (lineProcess != null)
			{
				_lot = lineProcess.Lot;
				_line = lineProcess.LineName;

				txtBarcode.Enabled = false;
				loadProcess(_lot);
				cbProcess.Enabled = true;
				cbProcess.Focus();
				flagRepair = true;
			}
			else 
			{
				mdlist = MODELLOTINFO_DAL.Instance.getInfoByQRCode(txtBarcode.Text);
				if (mdlist!=null)
				{
					txtBarcode.Enabled = false;
					cbLineName.Enabled = true;
					_lot = mdlist.Lot;
					txtLOT.Text = _lot;
					cbLineName.Focus();
					loadLineName();
				}
				else
				{
					MessageBox.Show("Barcode này không có trong CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}			
			}	
			
			return true;
		}
		private void loadLineName()
		{
			var line = new ViewCombobox();
			line.LineName = "--Select--";


			var listLine = new List<ViewCombobox>();
			listLine = UVProLineDAL.Instance.getLineNotSMTDeptID(10001);
			listLine.Insert(0, line); // Add "--Select--" item at the beginning of the list
									  //alistLine = 
			cbLineName.DataSource = listLine.OrderBy(x => x.ID).ToList();
			cbLineName.DisplayMember = "LineName";
			cbLineName.ValueMember = "LineName";
		}
		private void cbLineName_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!cbLineName.Text.Equals("--Select--"))
			{
				loadProcess(_lot);
				cbProcess.Enabled = true;
				cbProcess.Focus();
				flagRepair = true;
			}
		}
		private void cbLineName_KeyDown(object sender, KeyEventArgs e)
		{
            if (true)
            {
				loadProcess(_lot);
				cbProcess.Enabled = true;
				cbProcess.Focus();
			}
            
		}

		private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				if ( checkBarcode())
				{
					//cbProcess.Focus();
				}
				else
				{
					txtBarcode.SelectAll();
					txtBarcode.Focus();
				}
			}
		}
		//private void cbProcess_SelectionChangeCommitted(object sender, EventArgs e)
		//{
		//	if (cbProcess.Text!="--Select--")
		//	{				
		//		cbProcess.Enabled = false;
		//		processId = long.Parse(cbProcess.SelectedValue.ToString());
		//		if (processId != 0)
		//		{
		//			var lineProcess = new UV_LINEPROCESS();
		//			lineProcess = LINEPROCESS_DAL.Instance.getProcessNameByProcessId(processId);
		//			processName = lineProcess.ProcessName;
		//		}
		//		loadErrorCode();
		//		cbErrorCode.Enabled = true;
		//		cbErrorCode.Focus();				
		//	}
		//	else
		//	{
		//		MessageBox.Show("Hãy chọn Công đoạn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//		cbProcess.SelectAll();
		//		cbProcess.Focus();
		//	}
		//}
		private bool isOKData()
		{
			if (!checkBarcode2())
			{
				return false;
			}
			if (flagRepair == false)
			{
				MessageBox.Show("Barcode này không có trong CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtBarcode.SelectAll();
				txtBarcode.Focus();
				return false;
			}
			if (cbErrorCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Phải nhập mã lỗi vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbErrorCode.Focus();
				return false;
			}			
			else
			{
				if (cbErrorCode.Text.Equals("Other"))
				{
					if (txtReason.Text.Trim().Equals(""))
					{
						MessageBox.Show("Phải nhập lý do !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtReason.Focus();
						return false;
					}
				}
			}
			if (MODELLOTINFO_DAL.Instance.getInfoByQRCode(txtBarcode.Text.Trim())!=null)
			{
				if (cbLineName.Text.Equals("--Select--"))
				{
					MessageBox.Show("Phải nhập tên line !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					cbLineName.Focus();
					return false;
				}
			}
			if (cbProcess.Text.Equals("--Select--"))
			{
				MessageBox.Show("Phải nhập công đoạn vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbProcess.Focus();
				return false;
			}
			
			return true;
		}
		private void LoadData()
		{
			CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESSHISTORY_DAL.Instance.getDDRHistory(Program.UserId));
		}
		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (isOKData())
			{
				string messsage2 = "";
				var sendRepairBarcode = new UV_LINEERRORRECORD();
				sendRepairBarcode.BarVsQr = txtBarcode.Text;
				sendRepairBarcode.ErrorCode = cbErrorCode.Text;
				var errorDetail=LINEERRORCODE_DAL.Instance.checkExistsErrorCode(sendRepairBarcode.ErrorCode);
				sendRepairBarcode.ErrorVNDescription = errorDetail.ErrorVNDescription;
				sendRepairBarcode.ErrorENDescription = errorDetail.ErrorENDescription;
				sendRepairBarcode.Reason = txtReason.Text;
				
				
				sendRepairBarcode.Lot = _lot;
				var cmList = MODELLOTINFO_DAL.Instance.getInfoByQRCode(txtBarcode.Text.Trim());
				if (cmList!=null)
				{
					sendRepairBarcode.LineName = cbLineName.Text;
				}
				else
				{
					sendRepairBarcode.LineName = _line;
				}
				
				sendRepairBarcode.ProcessID = processId;
				sendRepairBarcode.ProcessName = processName;
				
				
				sendRepairBarcode.CreatedBy = Program.UserId;
				sendRepairBarcode.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
				messsage2 = LINEERRORRECORD_DAL.Instance.Add(sendRepairBarcode);
				if (messsage2 == "")
				{
					//this.Close();					
					MessageBox.Show("Đã ghi thành công DDR: " + messsage2, "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					InitData();					
					// Hiển thị dữ liệu sau khi nhập theo thứ tự mới đến cũ.
					LoadData();
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu vào DDR: " + messsage2, "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

			}
		}
		private void loadErrorCode()
		{
			var line = new UV_LINEERRORCODE();
			line.ErrorCode = "--Select--";
			var listLine = new List<UV_LINEERRORCODE>();
			listLine = LINEERRORCODE_DAL.Instance.getListErrorCode();
			listLine.Insert(0, line); // Add "--Select--" item at the beginning of the list
									  //alistLine = 
			cbErrorCode.DataSource = listLine.OrderBy(x => x.ID).ToList();
			cbErrorCode.DisplayMember = "ErrorCode";
			cbErrorCode.ValueMember = "ErrorCode";
		}
		private void loadProcess( string lot)
		{
			var process = new UV_LINEPROCESS();
			process.ProcessName = "--Select--";
			var lstProcess = new List<UV_LINEPROCESS>();
			lstProcess = LINEPROCESS_DAL.Instance.getAllProcessByLot(lot);
			lstProcess.Insert(0, process); // Add "--Select--" item at the beginning of the list
									  //alistLine = 
			cbProcess.DataSource = lstProcess.OrderBy(x => x.ProcessId).ToList();
			cbProcess.DisplayMember = "ProcessName";
			cbProcess.ValueMember = "ProcessId";
		}
		private void processADJ( string lot)
		{
			var processAdj = new UV_LINEPROCESS();
			processAdj = LINEPROCESS_DAL.Instance.checkProcessNameByLot(lot,cbProcess.Text.Trim());
			if (processAdj == null)
			{
				MessageBox.Show("Tên công đoạn này không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbProcess.SelectAll();
				cbProcess.Focus();
			}
			else
			{
				processId = long.Parse(cbProcess.SelectedValue.ToString());
				if (processId != 0)
				{
					var lineProcess = new UV_LINEPROCESS();
					lineProcess = LINEPROCESS_DAL.Instance.getProcessNameByProcessId(processId);
					processName = lineProcess.ProcessName;
				}
				cbProcess.Enabled = false;
				loadErrorCode();
				cbErrorCode.Enabled = true;
				cbErrorCode.Focus();
			}
		}
		private void checkErrorCode()
		{
			var checkErrCode = new UV_LINEERRORCODE();
			checkErrCode = LINEERRORCODE_DAL.Instance.checkExistsErrorCode(cbErrorCode.Text);
			if (checkErrCode == null)
			{
				MessageBox.Show("Mã lỗi này không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbErrorCode.SelectAll();
				cbErrorCode.Focus();
			}
			else
			{
				if (cbErrorCode.Text.Equals("Other"))
				{
					txtReason.Enabled = true;
					txtReason.Focus();
				}
				txtVNDescription.Text = checkErrCode.ErrorVNDescription;
				txtENDescription.Text = checkErrCode.ErrorENDescription;
				cbErrorCode.Enabled = false;	
				iconbtnSave.Focus();
			}
		}
		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			InitData();
		}

		private void cbErrorCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				checkErrorCode();
			}
		}

		private void cbErrorCode_Validating(object sender, CancelEventArgs e)
		{
			checkErrorCode();
		}

		private void cbProcess_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				processADJ(_lot);
			}
		}

		private void cbProcess_Validating(object sender, CancelEventArgs e)
		{
			processADJ(_lot);
		}

		
	}
}
