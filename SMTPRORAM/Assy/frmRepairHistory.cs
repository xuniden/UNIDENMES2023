using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.SysControl;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.Assy;
using UnidenDAL.Assy.Setup;
using UnidenDAL.Staging;
using Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.Assy
{
	public partial class frmRepairHistory : Form
	{
		private string errorVNDesc;
		private string errorENDesc;
		UVEntities _entities;
		DataTableCollection tableCollection;
		bool AddFlag = false;
		private long Id = 0;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmRepairHistory()
		{
			InitializeComponent();
			_entities = new UVEntities();
		}
		private void loadControl()
		{
			txtQrCode.Text = "";
			cbErrorCode.Enabled = false;
			txtNGPosition.Enabled = false;
			cbCauseDept.Enabled = false;
			cbCauseCode.Enabled = false;
			txtQrCode.Focus();
		}

		private void frmRepairHistory_Load(object sender, EventArgs e)
		{
			loadControl();
			txtQrCode.Focus();
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
			CommonDAL.Instance.ShowDataGridView(dgView, LINEREPAIRHISTORY_DAL.Instance.getListHistoryByUser(Program.UserId));
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

		private void loadCauseCode()
		{
			var line = new UV_LINECAUSECODE();
			line.CauseCode = "--Select--";
			var listLine = new List<UV_LINECAUSECODE>();
			listLine = LINECAUSECODE_DAL.Instance.getListCauseCode();
			listLine.Insert(0, line); // Add "--Select--" item at the beginning of the list
									  //alistLine = 
			cbCauseCode.DataSource = listLine.OrderBy(x => x.ID).ToList();
			cbCauseCode.DisplayMember = "CauseCode";
			cbCauseCode.ValueMember = "CauseCode";
		}

		private void loadCauseDept()
		{
			var line = new UV_LINECAUSEDEPT();
			line.DeptCode = "--Select--";
			var listLine = new List<UV_LINECAUSEDEPT>();
			listLine = LINECAUSEDEPT_DAL.Instance.getListCauseDept();
			listLine.Insert(0, line); // Add "--Select--" item at the beginning of the list
									  //alistLine = 
			cbCauseDept.DataSource = listLine.OrderBy(x => x.ID).ToList();
			cbCauseDept.DisplayMember = "DeptCode";
			cbCauseDept.ValueMember = "DeptCode";
		}
		private bool checkQRcode2()
		{
			if (!txtQrCode.Text.Trim().Equals(""))
			{
				// Kiểm tra xem đã được leader nhập vào danh sách sửa chưa?
				var lineErrRecord = new UV_LINEERRORRECORD();
				lineErrRecord = LINEERRORRECORD_DAL.Instance.checkQRCode(txtQrCode.Text.Trim());
				if (lineErrRecord != null) // Đã nhập vào rồi thì cho sửa
				{
					//txtLot.Text = lineErrRecord.Lot;
					//var model = new UV_MODELLOTINFO();
					//model = _entities.UV_MODELLOTINFO.Where(p => p.Lot == lineErrRecord.Lot).FirstOrDefault();
					//txtModel.Text = model.Model;
					//// Load Error code
					//cbErrorCode.Enabled = true;
					//loadErrorCode();
					//cbErrorCode.Focus();
					//txtQrCode.Enabled = false;

				}
				else // Trường hợp leader chưa nhập vào thì thông báo
				{
					MessageBox.Show("Chưa được leader nhập vào danh sách repair ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//txtQrCode.SelectAll();
					//txtQrCode.Focus();
					return false;
				}
			}
			else
			{
				MessageBox.Show("Nhập dữ QR cần sửa vào ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//txtQrCode.Focus();
				return false;
			}
			return true;
		}
		private bool checkQRcode()
		{
			if (!txtQrCode.Text.Trim().Equals(""))
			{
				// Kiểm tra xem đã được leader nhập vào danh sách sửa chưa?
				var lineErrRecord = new UV_LINEERRORRECORD();
				lineErrRecord = LINEERRORRECORD_DAL.Instance.checkQRCode(txtQrCode.Text.Trim());
				if (lineErrRecord != null) // Đã nhập vào rồi thì cho sửa
				{
					txtLot.Text = lineErrRecord.Lot;
					var model = new UV_MODELLOTINFO();
					model = _entities.UV_MODELLOTINFO.Where(p => p.Lot == lineErrRecord.Lot).FirstOrDefault();
					txtModel.Text = model.Model;
					// Load Error code
					cbErrorCode.Enabled = true;
					loadErrorCode();
					cbErrorCode.Focus();
					txtQrCode.Enabled = false;

				}
				else // Trường hợp leader chưa nhập vào thì thông báo
				{
					MessageBox.Show("Chưa được leader nhập vào danh sách repair ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//txtQrCode.SelectAll();
					//txtQrCode.Focus();
					return false;
				}
			}
			else
			{
				MessageBox.Show("Nhập dữ QR cần sửa vào ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//txtQrCode.Focus();
				return false;
			}
			return true;
		}

		private void txtQrCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (checkQRcode())
				{
					cbErrorCode.Focus();
				}
				else
				{
					txtQrCode.SelectAll();
					txtQrCode.Focus();
				}
				/*
				if (!txtQrCode.Text.Trim().Equals(""))
				{
					// Kiểm tra xem đã được leader nhập vào danh sách sửa chưa?
					var lineErrRecord = new UV_LINEERRORRECORD();
					lineErrRecord = LINEERRORRECORD_DAL.Instance.checkQRCode(txtQrCode.Text.Trim());
					if (lineErrRecord!=null) // Đã nhập vào rồi thì cho sửa
					{
						txtLot.Text=lineErrRecord.Lot;
						var model= new UV_MODELLOTINFO();
						model=_entities.UV_MODELLOTINFO.Where(p=>p.Lot==lineErrRecord.Lot).FirstOrDefault();
						txtModel.Text = model.Model;
						// Load Error code
						cbErrorCode.Enabled = true;
						loadErrorCode();						
						cbErrorCode.Focus();
						txtQrCode.Enabled = false;

					}
					else // Trường hợp leader chưa nhập vào thì thông báo
					{
						MessageBox.Show("Chưa được leader nhập vào danh sách repair ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						txtQrCode.SelectAll();
						txtQrCode.Focus();						
					}
				}
				else 
				{
					MessageBox.Show("Nhập dữ QR cần sửa vào ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
					txtQrCode.Focus();					
				}
				*/
			}
		}
		
		private bool checkErrorCode()
		{
			var checkErrCode = new UV_LINEERRORCODE();
			checkErrCode = LINEERRORCODE_DAL.Instance.checkExistsErrorCode(cbErrorCode.Text);
			if (checkErrCode == null)
			{
				MessageBox.Show("Mã lỗi này không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//cbErrorCode.SelectAll();
				//cbErrorCode.Focus();
				return false;
			}
			else
			{
				errorENDesc = checkErrCode.ErrorENDescription;
				errorVNDesc = checkErrCode.ErrorVNDescription;
				cbErrorCode.Enabled = false;
				//txtNGPosition.Enabled = true;
				//txtNGPosition.Focus();
			}
			return true;
		}
		
		private void cbErrorCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (checkErrorCode())
				{
					txtNGPosition.Enabled = true;
					txtNGPosition.Focus();
				}
				else
				{
					cbErrorCode.SelectAll();
					cbErrorCode.Focus();
				}
			}
		}
		private bool checkNGPosition2()
		{
			if (txtNGPosition.Text.Equals(""))
			{
				MessageBox.Show("Nhập dữ liệu vào vị trí lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//txtNGPosition.Focus();
				return false;
			}
			else
			{
				txtNGPosition.Enabled = false;
				cbCauseCode.Enabled = true;
				//loadCauseCode();

			}
			return true;
		}
		private bool checkNGPosition()
		{
			if (txtNGPosition.Text.Equals(""))
			{
				MessageBox.Show("Nhập dữ liệu vào vị trí lỗi","Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
				//txtNGPosition.Focus();
				return false;
			}
			else
			{
				txtNGPosition.Enabled=false;
				cbCauseCode.Enabled = true;
				loadCauseCode();
				
			}
			return true;
		}
		

		private void txtNGPosition_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (checkNGPosition())
				{
					cbCauseCode.Focus();
				}
				else
				{
					txtNGPosition.Focus();
				}
			}
		}
		private bool checkCauseCode2()
		{
			var checkCauseCode = new UV_LINECAUSECODE();
			checkCauseCode = LINECAUSECODE_DAL.Instance.checkExistsCauseCode(cbCauseCode.Text);
			if (checkCauseCode == null)
			{
				MessageBox.Show("Mã lỗi này không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//cbCauseCode.SelectAll();
				//cbCauseCode.Focus();
				return false;
			}
			else
			{
				cbCauseCode.Enabled = false;
				cbCauseDept.Enabled = true;
				//loadCauseDept();
				//cbCauseDept.Focus();

			}
			return true;
		}
		private bool checkCauseCode()
		{
			var checkCauseCode = new UV_LINECAUSECODE();
			checkCauseCode = LINECAUSECODE_DAL.Instance.checkExistsCauseCode(cbCauseCode.Text);
			if (checkCauseCode == null)
			{
				MessageBox.Show("Mã lỗi này không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//cbCauseCode.SelectAll();
				//cbCauseCode.Focus();
				return false;
			}
			else
			{
				cbCauseCode.Enabled=false;
				cbCauseDept.Enabled=true;
				loadCauseDept();
				//cbCauseDept.Focus();

			}
			return true;
		}
		
		private void cbCauseCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (checkCauseCode())
				{
					cbCauseDept.Focus();
				}
				else
				{
					cbCauseCode.SelectAll();
					cbCauseCode.Focus();
				}
			}
			
		}

		private bool checkCauseDept()
		{
			var checkDept = new UV_LINECAUSEDEPT();
			checkDept = LINECAUSEDEPT_DAL.Instance.checkExistsCauseDept(cbCauseDept.Text);
			if (checkDept == null)
			{
				MessageBox.Show("Mã lỗi này không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			else
			{
				cbCauseDept.Enabled=false;
				iconbtnSave.Focus();
			}
			return true;
		}
	

		private void cbCauseDept_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				if(checkCauseDept())
				{
					iconbtnSave.Focus();
				}
				else
				{
					cbCauseDept.SelectAll();
					cbCauseDept.Focus();
				}
			}
		}

		private bool isOKData()
		{
			if (!checkQRcode2())
			{
				//MessageBox.Show("Phải nhập QR hoặc Barcode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//txtQrCode.Focus();
				return false;
			}
			if (!checkNGPosition2())
			{
				//MessageBox.Show("Phải nhập vị trí lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//txtNGPosition.Focus();
				return false;
			}
			if (!checkCauseCode2())
			{
				//MessageBox.Show("Phải nhập nguyên nhân lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//cbCauseCode.Focus();
				return false;
			}
			if (!checkErrorCode())
			{
				//MessageBox.Show("Phải nhập mã lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//cbErrorCode.Focus();
				return false;
			}
			if (!checkCauseDept())
			{
				//MessageBox.Show("Phải nhập bộ phận gây ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				//cbCauseDept.Focus();
				return false;
			}
			return true;	
		}


		private void ResetControl()
		{
			txtQrCode.Enabled = true;
			txtQrCode.Text = "";
			txtNGPosition.Text = "";
			txtLot.Text = "";
			txtModel.Text = "";
			cbErrorCode.Text = "--Select--";
			cbCauseCode.Text = "--Select--";
			cbCauseDept.Text = "--Select--";
			loadErrorCode();
			loadErrorCode();
			loadCauseCode();
			loadCauseDept();

			txtQrCode.Focus();
		}


		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (isOKData())
			{
				var repairHistory = new UV_LINEREPAIRHISTORY();
				repairHistory.Lot = txtLot.Text;
				repairHistory.Model = txtModel.Text;
				repairHistory.QRCode00 = txtQrCode.Text;
				repairHistory.CauseCode = cbCauseCode.Text.ToUpper();
				repairHistory.ErrorCode = cbErrorCode.Text;
				repairHistory.ErrorENDesc = errorENDesc;
				repairHistory.ErrorVNDesc = errorVNDesc;
				repairHistory.ErrorPosition = txtNGPosition.Text.Trim();
				repairHistory.CauseDept = cbCauseDept.Text.ToUpper();
				repairHistory.CreatedBy = Program.UserId;
				repairHistory.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
				string message = "";
				message = LINEREPAIRHISTORY_DAL.Instance.Add(repairHistory);
				if (message == "")
				{
					// Hiển thị thông tin theo user
					CommonDAL.Instance.ShowDataGridView(dgView, LINEREPAIRHISTORY_DAL.Instance.getListHistoryByUser(Program.UserId));
					ResetControl();
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			ResetControl();
		}
		private void searchData(string search)
		{
			if (search.Equals(""))
			{
				MessageBox.Show("Nhập điều kiện cần tìm kiếm Barcode/Lot/ProcessName/LineName/CreatedBy","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				var lst = new List<UV_LINEERRORRECORD>();
				lst=LINEERRORRECORD_DAL.Instance.SearchData(search);
				if (lst.Count>0)
				{
					if (lst.Count>1000)
					{
						CommonDAL.Instance.ShowDataGridView(dgView, lst.Take(1000));
						MessageBox.Show("Kết quả tìm kiếm >1000 bản ghi \n " +
							"Chỉ lấy 1000 bản ghi.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
					
				}
				else
				{
					MessageBox.Show("Không tìm thấy dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
		}
		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			searchData(txtSearch.Text);
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				searchData(txtSearch.Text);
			}
		}
	}
}
