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
using UnidenDAL.AssyLine.MENU;
using UnidenDAL.AssyLine.REPAIR;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.REPAIR
{
	public partial class frmKeyinSamsungRepair : Form
	{
		public frmKeyinSamsungRepair()
		{
			InitializeComponent();
		}

		
		private void frmKeyinSamsungRepair_Load(object sender, EventArgs e)
		{
			LoadErrorCode();
			LoadCauseCode();
			LoadDeptCode();
			LoadShortModel();
			LoadPcbType();
			cbModel.Focus();
		}

		private void LoadErrorCode()
		{
			cbErrorCode.DataSource=ERRORCODE_DAL.Instance.getErrorCodeForCombobox();
			cbErrorCode.DisplayMember = "ErrorCode";
			cbErrorCode.ValueMember = "ErrorCode";
		}
		private void LoadCauseCode()
		{
			cbCauseCode.DataSource=CAUSECODE_DAL.Instance.getCauseCodeForCombobox();
			cbCauseCode.DisplayMember = "CauseCode";
			cbCauseCode.ValueMember = "CauseCode";
		}
		private void LoadDeptCode()
		{
			cbDeptCode.DataSource = DEPTCODE_DAL.Instance.getDeptCodeForCombobox();
			cbDeptCode.DisplayMember = "DeptCode";
			cbDeptCode.ValueMember = "DeptCode";
		}
		private void LoadShortModel()
		{
			cbModel.DataSource=REPAIRMODEL_DAL.Instance.getRepairModelForCombobox();
			cbModel.DisplayMember = "ShortModel";
			cbModel.ValueMember = "ShortModel";
		}

		private void LoadPcbType()
		{
			cbPCBType.DataSource=PCBTYPE_DAL.Instance.getListPcbType();
			cbPCBType.DisplayMember = "PCBTYPE";
			cbPCBType.ValueMember = "PCBTYPE";
		}

		private bool checkRepaircode()
		{
			// Kiểm tra xem nó có trong csdl không? Nếu không có thì thông báo.
			if (string.IsNullOrEmpty(txtRepairCode.Text))
			{
				MessageBox.Show("Không được để trống RepairCode !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtRepairCode.Focus();
				return false;
			}			
			var checkRepaire = REPAIRGENERALCODE_DAL.Instance.checkExistRepairCode(txtRepairCode.Text.Trim());
			if (checkRepaire!=null)
			{
				cbErrorCode.Focus();
			}
			else
			{
				MessageBox.Show("RepaireCode không có trong CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtRepairCode.Focus();
				txtRepairCode.SelectAll();
				return false;
			}

			// Kiểm tra xem đã được nhập lần nào chưa?			

			var checkRepairHis=REPAIRHISTORY_DAL.Instance.checkRepairCode(txtRepairCode.Text.Trim());
			if (checkRepairHis!=null)
			{
				MessageBox.Show("RepaireCode đã được nhập vào csdl !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtRepairCode.Focus();
				txtRepairCode.SelectAll();
				return false;
			}

			return true;
		}

		private void txtRepairCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (checkRepaircode())
			{
				cbErrorCode.Focus();
			}
			else
			{
				txtRepairCode.Focus();
				txtRepairCode.SelectAll();
			}
		}
		private bool checkModel()
		{
			var checkModel=REPAIRMODEL_DAL.Instance.checkExistShortModel(cbModel.Text.Trim());
			if (checkModel!=null)
			{
				MessageBox.Show("Không được để trống hoặc phải nhập đúng Model !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (cbPCBType.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn PCB TYPE !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbPCBType.Focus();
				return;
			}
			if (cbModel.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn sai Model !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbModel.Focus();
				return;
			}
			if (!checkRepaircode())
			{
				//MessageBox.Show("Không được để trống Repaire Code !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//txtRepairCode.Focus();
				return;
			}
			
			if (cbErrorCode.Text.Equals("--Select--") )
			{
				MessageBox.Show("Chọn sai Mã lỗi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbErrorCode.Focus();
				return;
			}				
			if (string.IsNullOrEmpty(txtNGPosition.Text.Trim()) )
			{
				MessageBox.Show("Không được để trống Vị trí LK NG !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtNGPosition.Focus();
				return;
			}
			
			if (cbCauseCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn sai Nguyên nhân lỗi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbCauseCode.Focus();
				return;
			}
			if (cbDeptCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn sai Bộ phận !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbDeptCode.Focus();
				return;
			}

			var addHistory = new UVASSY_REPAIRHISTORY
			{
				Model=cbModel.Text,
				RepairCode=txtRepairCode.Text.Trim(),
				ErrorCode=cbErrorCode.Text,
				ErrorPosition=txtNGPosition.Text.Trim(),
				CauseCode=cbCauseCode.Text.Trim(),
				DeptCode=cbDeptCode.Text.Trim(),
				PCBType=cbPCBType.Text,
				Qty= (int)numericUpDown1.Value,
				CreatedDate=CommonDAL.Instance.getSqlServerDatetime(),
				CreatedBy=Program.UserId,
				Remark=null
			};
			string message=REPAIRHISTORY_DAL.Instance.Add(addHistory);
			if (string.IsNullOrEmpty(message))
			{
				ResetControlAfterSave();
				CommonDAL.Instance.ShowDataGridView(dgView,REPAIRHISTORY_DAL.Instance.getAllInforByUser(cbModel.Text,Program.UserId));
			}
			else
			{
				MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu. \n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
		}
		private void ResetControlAfterSave()
		{
			LoadErrorCode();
			LoadCauseCode();
			LoadDeptCode();
			LoadShortModel();
			LoadPcbType();
			txtRepairCode.Text =string.Empty;
			txtNGPosition.Text =string.Empty;
			numericUpDown1.Value = 1;
			txtRepairCode.Focus();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			ResetControlAfterSave();
		}
	}
}
