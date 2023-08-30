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
using UnidenDAL.AssyLine.ETASSY;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.SysControl.Setup;
using UnidenDAL.Smt.Output;

namespace SMTPRORAM.AssyLine.ETASSY
{
	public partial class frmGeneralSerial : Form
	{
		private int Id = 0;
		private bool AddFlag = false;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmGeneralSerial()
		{
			InitializeComponent();
		}

		private void Init()
		{
			cbModel.Text = "--Select--";
			cbManuoc.Text = "--Select--";
			cbPCBType.Text = "--Select--";
			cbFactoryCode.Text = "--Select--";
			cbPCBCode.Text = "--Select--";
			cbYCode.Text = "--Select--";
			cbMCode.Text = "--Select--";
			cbDCode.Text = "--Select--";

			numericFrom.Value = 0;
			numericTo.Value = 0;
			
		}
		private void frmGeneralSerial_Load(object sender, EventArgs e)
		{
			Init();
			LoadModel();
			

			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}

		private void LoadModel()
		{
			var lstModel = EASTECHPCBCODE_DAL.Instance.getModel();
			cbModel.DataSource= lstModel;
			cbModel.DisplayMember = "Model";
			cbModel.ValueMember = "Model";
		}

		private bool isOKData()
		{
			if (cbModel.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbModel.Focus();
				return false;
			}
			if (cbManuoc.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbManuoc.Focus();
				return false;
			}
			if (cbPCBType.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbPCBType.Focus();
				return false;
			}
			if (cbPCBCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbPCBCode.Focus();
				return false;
			}
			if (cbFactoryCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbFactoryCode.Focus();
				return false;
			}
			if (cbYCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbYCode.Focus();
				return false;
			}
			if (cbMCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbMCode.Focus();
				return false;
			}
			if (cbDCode.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn dữ liệu đúng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cbDCode.Focus();
				return false;
			}
			if ((int)numericFrom.Value<=0)
			{
				MessageBox.Show("In từ số phải >0 ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				numericFrom.Focus();
				return false;
			}
			if ((int)numericTo.Value <= 0)
			{
				MessageBox.Show("In tới số phải >0 ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				numericTo.Focus();
				return false;
			}
			if ((int)numericTo.Value<=(int)numericFrom.Value)
			{
				MessageBox.Show("In tới số phải > In từ số ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				numericTo.Focus();
				return false;
			}

			return true;
		}
		private void clearDgView()
		{
			dataGridView.DataSource = null;
			dataGridView.DataBindings.Clear();
			dataGridView.Columns.Clear();
			dataGridView.Rows.Clear();
			dataGridView.Update();
			dataGridView.Refresh();
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (isOKData())
			{
				var datetime = CommonDAL.Instance.getSqlServerDatetime();
				var lstAddNew = new List<UVASSY_EASTECHSERIALGENERAL>();
				clearDgView();
				StringBuilder sbQrcode = new StringBuilder();
				DateTime dateTime = CommonDAL.Instance.getSqlServerDatetime();
				for (int i = (int)numericFrom.Value; i <= (int)numericTo.Value; i++)
				{
					string num = i.ToString("0000");
					var newAdd = new UVASSY_EASTECHSERIALGENERAL
					{
						Serial_Number= cbManuoc.Text + cbPCBType.Text + cbPCBCode.Text + cbFactoryCode.Text + cbYCode.Text + cbMCode.Text + cbDCode.Text + num,
						Model=cbModel.Text,
						CCode=cbManuoc.Text,
						PCBType=cbPCBType.Text,
						PCBCode=cbPCBCode.Text,
						FCode=cbFactoryCode.Text,
						YCode=cbYCode.Text,
						MCode=cbMCode.Text,
						DCode=cbDCode.Text,
						NCode=i,
						CreatedBy=Program.UserId,
						CreatedDate=dateTime
					};
					sbQrcode.Append(cbManuoc.Text + cbPCBType.Text + cbPCBCode.Text + cbFactoryCode.Text + cbYCode.Text + cbMCode.Text + cbDCode.Text + num);
					if (i < (int)numericTo.Value)
					{
						sbQrcode.Append(",");
					}
					lstAddNew.Add(newAdd);
				}
				DataTable dtcheck = new DataTable();
				dtcheck = EASTECHSERIALGENERAL_DAL.Instance.uvassyCheckExistsQRCode(sbQrcode);
				if (dtcheck.Rows.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dataGridView, dtcheck);
					MessageBox.Show("Trên hệ thông đã có dữ liệu sau: ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
				{					
					string success = EASTECHSERIALGENERAL_DAL.Instance.AddRange(lstAddNew);
					if (string.IsNullOrEmpty(success))
					{
						MessageBox.Show("Đã thêm thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						CommonDAL.Instance.ShowDataGridView(dataGridView, lstAddNew);
						return;
					}
					else
					{
						MessageBox.Show("Không thêm thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}	
				}
			}
		}

		private void btExport_Click(object sender, EventArgs e)
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
					if (dataGridView.Rows.Count > 0)
					{
						CommonDAL.Instance.writeCSV(dataGridView, filename);
						MessageBox.Show("Đã export xong !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Không có dữ liệu để download !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				throw;
			}
		}

		private void cbModel_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbModel.SelectedItem is GroupModel selectedModel)
			{
				string model = selectedModel.Model;
				var modelname = EASTECHPCBCODE_DAL.Instance.getPCBCodeByModel(cbModel.Text.Trim());
				if (modelname != null)
				{			
					cbPCBCode.DataSource = modelname;
					cbPCBCode.DisplayMember = "PcbCode";
					cbPCBCode.ValueMember = "PcbCode";
				}
			}
		}
	}
}
