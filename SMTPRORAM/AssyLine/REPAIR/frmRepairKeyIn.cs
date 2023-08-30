using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.VisualBasic.FileIO;
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
using UnidenDAL.AssyLine;
using UnidenDAL.AssyLine.REPAIR;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.REPAIR
{
	public partial class frmRepairKeyIn : Form
	{
		private int ID;
		private bool inp = true;
		private bool edit = false;
		private string remark = "";
		private string chk = "";
		public frmRepairKeyIn()
		{
			InitializeComponent();			
		}

		private void frmRepairKeyIn_Load(object sender, EventArgs e)
		{
			grDepartment.Enabled = true;
			grInput.Enabled = false;
			grSave.Enabled = true;
			btSaveClose.Visible = false;
			LoadReasonCode();
			LoadCauseCodeRepair();
			LoadLot();
			LoadDefectCode();
		}
		private void LoadReasonCode()
		{
			cbReasonCode.DataSource = REASONCODE_DAL.Instance.getReasonCodeForCombobox();
			cbReasonCode.DisplayMember = "Reason_Code";
			cbReasonCode.ValueMember = "Reason_Code";
		}

		private void LoadCauseCodeRepair()
		{
			cbCauseCode.DataSource=CAUSECODEREPAIR_DAL.Instance.getCauseCodeForCombobox();
			cbCauseCode.DisplayMember = "CauseCode";
			cbCauseCode.ValueMember = "CauseCode";
		}

		private void LoadLot()
		{
			cbLot.DataSource = MODEL_DAL.Instance.listLots();
			cbLot.DisplayMember = "Lot";
			cbLot.ValueMember = "Lot";
		}

		private void LoadDefectCode()
		{
			cbDefectCode.DataSource = DEFECTCODE_DAL.Instance.listDefectCode();
			cbDefectCode.DisplayMember = "DefectCode";
			cbDefectCode.ValueMember = "DefectCode";
		}

		private void DisableAll()
		{
			txtLine.Enabled = false;
			txtTechnicalID.Enabled = false;
			txtModel.Enabled = false;
			cbLot.Enabled = false;
			txtRepairBarcode.Enabled = false;
			cbDefectCode.Enabled = false;
			txtPartLocation.Enabled = false;
			txtNgQty.Enabled = false;
			txtADJNo.Enabled = false;
			cbReasonCode.Enabled = false;
			cbCauseCode.Enabled = false;
		}
		private void EnabeSMT()
		{
			lblPCBname.Visible = true;
			lblPCBno.Visible = true;
			lblPCSNo.Visible = true;

			txtPCBName.Visible = true;
			txtPCBNo.Visible = true;
			txtPCSNo.Visible = true;

			txtPCBName.Text = "";
			txtPCBNo.Text = "";
			txtPCSNo.Text = "";

			lblDefect.Visible = false;
			lblAdjno.Visible = false;
			cbDefectCode.Visible = false;
			txtADJNo.Visible = false;

		}
		private void DisableSMT()
		{
			lblPCBname.Visible = false;
			lblPCBno.Visible = false;
			lblPCSNo.Visible = false;

			txtPCBName.Visible = false;
			txtPCBNo.Visible = false;
			txtPCSNo.Visible = false;

			lblDefect.Visible = true;
			lblAdjno.Visible = true;
			cbDefectCode.Visible = true;
			txtADJNo.Visible = true;

			txtADJNo.Text = "";
			

		}
		private void ClearAll1()
		{
			LoadDefectCode();
			txtPartLocation.Clear();
			txtNgQty.Clear();
			txtADJNo.Clear();
			cbDefectCode.Enabled = false;
			txtPartLocation.Enabled = false;
			txtNgQty.Enabled = false;
			txtADJNo.Enabled = false;
			cbReasonCode.Enabled = false;
			cbCauseCode.Enabled = false;
		}

		private void ClearAll2()
		{
			txtLine.Clear();
			txtTechnicalID.Clear();
			txtModel.Clear();
			LoadLot();
			txtRepairBarcode.Clear();
			LoadDefectCode();
			txtPCBName.Clear();
			txtPCBNo.Clear();
			txtPCSNo.Clear();
			txtPartLocation.Clear();
			txtNgQty.Clear();
			txtADJNo.Clear();
			txtLine.Focus();
		}
		private void ChkChoseEnableSMT()
		{
			lblPCBname.Visible = true;
			lblPCBno.Visible = true;
			lblPCSNo.Visible = true;

			txtPCBName.Visible = true;
			txtPCBNo.Visible = true;
			txtPCSNo.Visible = true;

			lblDefect.Visible = false;
			lblAdjno.Visible = false;
			cbDefectCode.Visible = false;
			txtADJNo.Visible = false;
		}

		private void ChkChoseDisableSMT()
		{
			lblPCBname.Visible = false;
			lblPCBno.Visible = false;
			lblPCSNo.Visible = false;

			txtPCBName.Visible = false;
			txtPCBNo.Visible = false;
			txtPCSNo.Visible = false;

			lblDefect.Visible = true;
			lblAdjno.Visible = true;
			cbDefectCode.Visible = true;
			txtADJNo.Visible = true;

		}

		private void EnableEdit()
		{
			dtpNgay.Enabled = true;
			txtLine.Enabled = true;
			txtTechnicalID.Enabled = true;
			cbLot.Enabled = true;
			txtRepairBarcode.Enabled = true;
			if (chkAssy.Checked == true || chkScl.Checked == true)
			{
				txtPCBNo.Enabled = false;
				txtPCBNo.Enabled = false;
				txtPCBName.Enabled = false;
				cbDefectCode.Enabled = true;
				txtADJNo.Enabled = true;
			}
			else
			{
				txtPCBNo.Enabled = true;
				txtPCBNo.Enabled = true;
				txtPCBName.Enabled = true;
				cbDefectCode.Enabled = false;
				txtADJNo.Enabled = false;
			}
			txtPartLocation.Enabled = true;
			txtNgQty.Enabled = true;
			cbReasonCode.Enabled = true;
			cbCauseCode.Enabled = true;

		}

		private void chkAssy_Click(object sender, EventArgs e)
		{
			chkScl.Checked = false;
			chkSMT.Checked = false;
			groupBox1.Visible = false;
			chk = "ASSY";
			grInput.Enabled = true;
			DisableSMT();
			dtpNgay.Select();
		}

		private void chkScl_Click(object sender, EventArgs e)
		{
			chkAssy.Checked = false;
			chkSMT.Checked = false;
			groupBox1.Visible = false;
			chk = "SCL";
			grInput.Enabled = true;
			DisableSMT();
			dtpNgay.Select();
		}

		private void chkSMT_Click(object sender, EventArgs e)
		{
			chkScl.Checked = false;
			chkAssy.Checked = false;
			chk = "SMT";
			groupBox1.Visible = true;
			grInput.Enabled = true;
			// cho phep nhâp PCS No, PCB No và PCB Name
			EnabeSMT();

			dtpNgay.Select();
		}

		private void cbLot_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbLot.SelectedItem is groupLot  selectLot)
			{
				//if (selectLot.Lot.Equals("--Select--"))
				//{
				//	MessageBox.Show("Chọn LOT","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
				//	cbLot.Focus();
				//	return;
				//}
				//else
				//{
					var getModel=MODEL_DAL.Instance.checkExistLot(selectLot.Lot);
					if (getModel != null)
					{
						txtModel.Text = getModel.Model;
					}
				//}
			}
		}

		private void txtNgQty_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
		}

		private void btSaveNext_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtLine.Text.Trim()))
			{
				MessageBox.Show("Nhập tên LINE vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtLine.Focus();
				txtLine.SelectAll();
				return;
			}
			if (string.IsNullOrEmpty(txtTechnicalID.Text.Trim()))
			{
				MessageBox.Show("Hãy nhập ID nhân viên sửa vào đây !!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtTechnicalID.Focus();
				txtTechnicalID.SelectAll();
				return;
			}
			if (string.IsNullOrEmpty(txtRepairBarcode.Text.Trim()))
			{
				MessageBox.Show("Hãy nhập mã code cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtRepairBarcode.Focus();
				txtRepairBarcode.SelectAll();
				return;
			}
			if (string.IsNullOrEmpty(txtPartLocation.Text.Trim()))
			{
				MessageBox.Show("Nhập dữ liệu vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtPartLocation.Focus();
				txtPartLocation.SelectAll();
				return;
			}
			if (chkSMT.Checked == true)
			{
				// Kiểm tra giá trị nhập của PCS, PCB PCB name				
				if (string.IsNullOrEmpty(txtPCSNo.Text.Trim()))
				{
					MessageBox.Show("Hãy nhập giá trị vào PCS No !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPCSNo.Focus();
					txtPCSNo.SelectAll();
					return;
				}				
				if (string.IsNullOrEmpty(txtPCBNo.Text.Trim()))
				{
					MessageBox.Show("Hãy nhập giá trị vào PCB No !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPCBNo.Focus();
					txtPCBNo.SelectAll();
					return;
				}
				if (string.IsNullOrEmpty(txtPCBName.Text.Trim()))
				{
					MessageBox.Show("Hãy nhập giá trị vào PCB Name !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPCBName.Focus();
					txtPCBName.SelectAll();
					return;
				}
			}
			else
			{
				// Kiểm tra ADJ No				
				if (string.IsNullOrEmpty(txtADJNo.Text.Trim()))
				{
					MessageBox.Show("Nhập dữ liệu vào ADJ NO. !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtADJNo.Focus();
					txtADJNo.SelectAll();
					return;
				}
			}
			string keys = "";
			var datetime = CommonDAL.Instance.getSqlServerDatetime();
			var addRepair = new UVASSY_REPAIREKEYIN();
			addRepair.R_Date = datetime;
			addRepair.R_Line = txtLine.Text.Trim();
			addRepair.R_Person=txtTechnicalID.Text.Trim();
			addRepair.R_Model=txtModel.Text.Trim();
			addRepair.Repaire_Code=txtRepairBarcode.Text.Trim();
			if (chkSMT.Checked == true)
			{
				keys = chkSMT.Text.Trim();
				chk = "SMT";
				addRepair.PCBName = txtPCBName.Text;
				addRepair.PCBNo = txtPCBNo.Text;
				addRepair.PCSNo = txtPCSNo.Text;
				addRepair.Defect_Code = "";
				addRepair.R_ADJ_No = "";
			}
			else
			{
				if (cbDefectCode.Text.Equals("[--Select--]"))
				{
					MessageBox.Show("Chọn đúng DEFECT CODE !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					cbDefectCode.Focus();
					return;
				}
				else
				{
					addRepair.Defect_Code=cbDefectCode.Text;
				}
				addRepair.R_ADJ_No = txtADJNo.Text;
				addRepair.PCBName = "";
				addRepair.PCBNo = "";
				addRepair.PCSNo = "";
			}
			if (chkAssy.Checked == true)
			{
				keys = chkAssy.Text.Trim();
				chk = "ASSY";
			}
			if (chkScl.Checked == true)
			{
				keys = chkScl.Text.Trim();
				chk = "SCL";
			}
			addRepair.Dept = chk.ToString();
			addRepair.R_Part_NG_Location = txtPartLocation.Text;
			addRepair.R_NG_Qty =int.Parse(txtNgQty.Text.Trim());
			addRepair.Reason_Code = cbReasonCode.Text;
			addRepair.Cause_Code = cbCauseCode.Text;
			keys = keys + txtModel.Text.Trim() + cbLot.Text.Trim() + txtRepairBarcode.Text.Trim() + txtPartLocation.Text.Trim();
			addRepair.R_Remark_1 = cbDefectCode.Text;
			addRepair.R_Remark_2 = keys;
			addRepair.R_Remark_3 = datetime.ToString("yyyy/mm/dd HH:mm:ss");
			addRepair.CreatedBy = Program.UserId;
			addRepair.CreatedDate = datetime;

			var checkKey = REPAIRKEYIN_DAL.Instance.checkKey(keys);
			string message = string.Empty;
			if (checkKey == null)
			{
				message = REPAIRKEYIN_DAL.Instance.Add(addRepair);
				if (string.IsNullOrEmpty(message))
				{
					CommonDAL.Instance.ShowDataGridView(dgView,REPAIRKEYIN_DAL.Instance.getListDataByUser(Program.UserId));
					txtRepairBarcode.Focus();
					txtRepairBarcode.SelectAll();
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu. \n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				if (chkSMT.Checked==true&&checkKey.Reason_Code!=cbReasonCode.Text)
				{
					message = REPAIRKEYIN_DAL.Instance.Add(addRepair);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.ShowDataGridView(dgView, REPAIRKEYIN_DAL.Instance.getListDataByUser(Program.UserId));
						txtRepairBarcode.Focus();
						txtRepairBarcode.SelectAll();
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi thêm dữ liệu. \n" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
		}

		private void btBrowser_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtBrowser.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btImport_Click(object sender, EventArgs e)
		{
			bool flag = true;			
			if (string.IsNullOrEmpty(txtBrowser.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				txtBrowser.Focus();
				flag = false;
				return;
			}			
			using (TextFieldParser parser = new TextFieldParser(txtBrowser.Text))
			{
				parser.ReadLine();
				parser.TextFieldType = FieldType.Delimited;
				parser.SetDelimiters(",");
				// check before import
				long count = 0;
				while (!parser.EndOfData)
				{
					//Processing row
					count = count + 1;
					string[] fields = parser.ReadFields();
					if (fields.Length != 12)
					{
						MessageBox.Show("Kiểm tra dòng thứ : " + count + "\n Thiếu dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						flag = false;
						break;
					}
					else
					{
						// Kiểm tra xem có đúng kiểu dữ liệu không?
						DateTime datet;
						if (!DateTime.TryParse(fields[0].Trim().ToString(), out datet))
						{
							MessageBox.Show("Có lỗi xảy ra ngày tháng không đúng: " + count, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							flag = false;
							break;
						}
						if (fields[1].Trim().Length != 4)
						{
							MessageBox.Show("Tên Line nhập không đúng: " + count, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							flag = false;
							break;
						}
						if (fields[3].Trim().Length != 6)
						{
							MessageBox.Show("LOT phải có 6 Ký tự: " + count);
							flag = false;
							break;
						}
						if (fields[4].Trim().Length != 6)
						{
							MessageBox.Show("Model phải có 6 Ký tự: " + count);
							flag = false;
							break;
						}
						if (fields[5].Trim().Length == 0)
						{
							MessageBox.Show("Barcode phải có Ký tự: " + count);
							flag = false;
							break;
						}
						if (fields[6].Trim().Length == 0)
						{
							MessageBox.Show("PCB No Ký tự: " + count);
							flag = false;
							break;
						}
						if (fields[7].Trim().Length == 0)
						{
							MessageBox.Show("PCB name phải có Ký tự: " + count);
							flag = false;
							break;
						}
						if (fields[8].Trim().Length == 6)
						{
							MessageBox.Show("Vị trí phải có ký tự: " + count);
							flag = false;
							break;
						}
						int qty;
						if (!Int32.TryParse(fields[9].Trim().ToString(), out qty))
						{
							MessageBox.Show("Phải nhập số: " + count);
							flag = false;
							break;
						}
						if (Convert.ToInt32(fields[9].Trim().ToString()) < 0)
						{
							MessageBox.Show("Số phai lớn hơn 0: " + count);
							flag = false;
							break;
						}
						if (fields[10].Trim().Length == 0)
						{
							MessageBox.Show("Nguyên nhân là mã code: " + count);
							flag = false;
							break;
						}
						if (fields[11].Trim().Length == 0)
						{
							MessageBox.Show("Bộ phận phải khác trống: " + count);
							flag = false;
							break;
						}
					}
				}
			}
			if (flag == true)
			{
				using (TextFieldParser parser1 = new TextFieldParser(txtBrowser.Text))
				{
					parser1.ReadLine();
					parser1.TextFieldType = FieldType.Delimited;
					parser1.SetDelimiters(",");
					if (flag == true)
					{
						var lstAdd = new List<UVASSY_REPAIREKEYIN>();
						var datetime = CommonDAL.Instance.getSqlServerDatetime();
						while (!parser1.EndOfData)
						{
							string[] fields = parser1.ReadFields();
							var obj = new UVASSY_REPAIREKEYIN
							{
								R_Date = DateTime.Parse(fields[0].ToString()),
								R_Line = fields[1].ToString(),
								R_Person = fields[2].ToString(),
								R_Lot = fields[3].ToString(),
								R_Model = fields[4].ToString(),
								Repaire_Code = fields[5].ToString(),
								PCBName = fields[7].ToString(),
								PCBNo = fields[6].ToString(),
								PCSNo = "0",
								Defect_Code = "",
								R_ADJ_No = "",
								Dept = "SMT",
								R_Part_NG_Location = fields[8].ToString(),
								R_NG_Qty = int.Parse(fields[9].ToString()),
								Reason_Code = fields[10].ToString(),
								Cause_Code = fields[11].ToString(),
								R_Remark_1 = "",
								R_Remark_2 = "SMT" + fields[4].ToString() + fields[3].ToString() + fields[5].ToString() + fields[8].ToString(),
								R_Remark_3 = DateTime.Now.ToString(),
								CreatedBy = Program.UserId,
								CreatedDate = datetime
							};
							lstAdd.Add(obj);							
						}
						string message=REPAIRKEYIN_DAL.Instance.AddRange(lstAdd);
						if (string.IsNullOrEmpty(message))
						{
							CommonDAL.Instance.ShowDataGridView(dgView, REPAIRKEYIN_DAL.Instance.getListDataByUser(Program.UserId));
							MessageBox.Show("Finished!!!");
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra. \n" +  message);
							return;
						}
						
						
					}
					else
					{
						MessageBox.Show("File Import đã có lỗi: ");
					}

				}
			}
		}

		private void btClear_Click(object sender, EventArgs e)
		{

		}
	}
}
