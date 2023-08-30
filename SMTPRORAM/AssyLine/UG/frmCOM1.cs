using DocumentFormat.OpenXml.Wordprocessing;
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
using UnidenDAL.AssyLine.UG;
using UnidenDAL.Smt.Output;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.UG
{	
	public partial class frmCOM1 : Form
	{
		private string startnum = "";
		private string endnum = "";
		private int totalPages = 1;
		private List<SYS_UserButtonFunction> lstUBFunction;
		private List<UVASSY_COM1> allData;
		public frmCOM1()
		{
			InitializeComponent();
		}

		private void frmCOM1_Load(object sender, EventArgs e)
		{
			lbl00.Text = string.Empty;
			lbl01.Text = string.Empty;
			lbl02.Text = string.Empty;
			lbl03.Text = string.Empty;
			lbl04.Text = string.Empty;

			LoadLot();
			cbLot.Focus();
			txtLine.Enabled = false;
		}

		private void LoadLot()
		{
			cbLot.DataSource= MODEL_DAL.Instance.listLots();
			cbLot.DisplayMember = "Lot";
			cbLot.ValueMember = "Lot";
		}
		private void ResetControll()
		{
			txtDBox.Focus();
			txtDBox.Text = "";
			txtBCard.Text = "";
			txtUnit.Text = "";
			txtDBox.Enabled = true;
			txtBCard.Enabled = false;
			txtUnit.Enabled = false;
			
			lbl02.Text=string.Empty;
			lbl03.Text=string.Empty;
			lbl04.Text=string.Empty;
		}

		private bool checkLot()
		{
			if (cbLot.Text.Equals("--Select--"))
			{
				CommonDAL.Instance.SetStatusLabels(lbl00, "NG");
				return false;
			}			
			return true;
		}
		private void cbLot_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbLot.SelectedItem is groupLot selectedLot)
			{
				if (selectedLot.Lot.Equals("--Select--"))
				{
					CommonDAL.Instance.SetStatusLabels(lbl00, "NG");
					cbLot.Focus();
					return;
				}
				else
				{
					var lotControl= LOTCONTROL_DAL.Instance.checkExistLot(selectedLot.Lot);
					if (lotControl==null)
					{
						CommonDAL.Instance.SetStatusLabels(lbl00, "NG");
						cbLot.Focus();
						return ;
					}
					else
					{
						CommonDAL.Instance.SetStatusLabels(lbl00, "OK");
						startnum = lotControl.Start_Number;
						endnum = lotControl.End_Number;
						txtLine.Enabled = true;
						txtLine.Focus();
					}					
				}
			}
		}

		private bool checkLine()
		{			
			if (string.IsNullOrEmpty(txtLine.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl01, "NG");
				txtLine.Focus();				
				return false;
			}			
			return true;
		}

		private void txtLine_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(checkLine())
				{
					cbLot.Enabled = false;
					CommonDAL.Instance.SetStatusLabels(lbl01, "OK");
					txtLine.Enabled=false;
					txtDBox.Enabled = true; 
					txtDBox.Focus();
				}
				else 
				{
					txtLine.Focus(); 
					txtLine.SelectAll();
				}	
			}
		}

		private bool checkDbox()
		{			
			
			if (string.IsNullOrEmpty(txtDBox.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl02, "NG");
				return false;
			}
			if (txtDBox.TextLength <13)
			{
				CommonDAL.Instance.SetStatusLabels(lbl02, "NG");
				return false;
			}

			if (txtDBox.TextLength > startnum.Length || txtDBox.TextLength > endnum.Length)
			{
				CommonDAL.Instance.SetStatusLabels(lbl02, "NG");
				return false;
			}
			// Kiểm tra xem dữ liệu nhập vào đã có trong dữ liệu đã nhập chưa???
			var checkDboxLot = COM1_DAL.Instance.checkDboxCom1(txtDBox.Text.Trim(), cbLot.Text.Trim());
			if (checkDboxLot!=null)
			{
				CommonDAL.Instance.SetStatusLabels(lbl02, "NG");
				return false;
			}
			else
			{
				int nums; int nume;
				Int32.TryParse(startnum.Substring(5, 6), out nums);
				Int32.TryParse(endnum.Substring(5, 6), out nume);
				int numdbox;				
				Int32.TryParse(txtDBox.Text.Trim().Substring(5, 6).ToString(), out numdbox);
				if (numdbox < nums || numdbox > nume)
				{
					CommonDAL.Instance.SetStatusLabels(lbl02, "NG");
					return false;					
				}
				
			}
			return true;
		}

		private void txtDBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkDbox())
				{
					CommonDAL.Instance.SetStatusLabels(lbl02, "OK");
					txtDBox.Enabled = false;
					txtBCard.Enabled = true;
					txtBCard.Focus();
				}
				else 
				{
					txtDBox.Focus();
					txtDBox.SelectAll(); 
				}
			}
		}

		private bool checkBCard()
		{			
			if (string.IsNullOrEmpty(txtBCard.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl03, "NG");
				return false;
			}
			if (txtBCard.Text.Trim().Length<15)
			{
				CommonDAL.Instance.SetStatusLabels(lbl03, "NG");
				return false;
			}
			string bcard = txtBCard.Text.Trim().Substring(0, 15).ToString();
			var checkBcarddata = BCARDDATA_DAL.Instance.checkBCardData(bcard);
			if (checkBcarddata == null)
			{
				CommonDAL.Instance.SetStatusLabels(lbl03, "NG");
				return false;
			}

			var checkdata = COM1_DAL.Instance.checkBCardCom1(txtBCard.Text.Trim(), cbLot.Text.Trim());
			if (checkdata != null)
			{
				CommonDAL.Instance.SetStatusLabels(lbl03, "NG");
				return false;
			}
			

			return true;
		}
		private void txtBCard_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkBCard())
				{
					CommonDAL.Instance.SetStatusLabels(lbl03, "OK");
					txtBCard.Enabled = false;
					txtUnit.Enabled = true;
					txtUnit.Focus();
				}
				else
				{
					txtBCard.Focus();
					txtBCard.SelectAll();
				}
			}
		}

		private bool checkUnit()
		{
			if (string.IsNullOrEmpty(txtUnit.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl04, "NG");
				return false;
			}						
			if (!txtUnit.Text.Trim().Equals(txtDBox.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl04, "NG");
				return false;
			}	
			
			return true;
		}

		private void txtUnit_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (checkUnit())
				{
					CommonDAL.Instance.SetStatusLabels(lbl04, "OK");
					txtUnit.Enabled = false;
					SaveData();
				}
				else
				{
					txtUnit.Focus();
					txtUnit.SelectAll();
				}
			}
		}
		private bool isOKData()
		{
			if (!checkLot())
			{
				return false;
			}
			if (!checkLine())
			{
				return false;
			}
			if (!checkDbox())
			{
				return false;
			}
			if (!checkBCard())
			{
				return false;
			}
			if (!checkUnit())
			{
				return false;
			}
			return true;
		}
		private void LoadData()
		{
			int totalRecords = COM1_DAL.Instance.countRecordByUser(Program.UserId);
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";
			labelTotalRecords.Text = totalRecords.ToString();
			List<UVASSY_COM1> pagedData = COM1_DAL.Instance.GetDataByPageByUser(Program.currentPage, Program.pageSize, Program.UserId);
			dataGridView.DataSource = pagedData;
		}
		private void SaveData()
		{
			if (isOKData())
			{
				var addNew = new UVASSY_COM1
				{
					Lot = cbLot.Text.Trim(),
					Line = txtLine.Text.Trim(),
					Dbox_Serial = txtDBox.Text.Trim(),
					Bcard_Serial = txtBCard.Text.Trim(),
					Serial_No = txtUnit.Text.Trim(),
					CreatedBy = Program.UserId,
					CreatedDate = CommonDAL.Instance.getSqlServerDatetime()
				};
				string message= COM1_DAL.Instance.Add(addNew);
				if (string.IsNullOrEmpty(message))
				{
					ResetControll();
					LoadData();
				}
				else
				{
					MessageBox.Show("Đã có lỗi xảy ra: " + message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (Program.currentPage>1)
			{
				Program.currentPage--;
				LoadData();
			}
		}

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			if(Program.currentPage>=totalPages)
			{
				Program.currentPage = totalPages;
			}
			Program.currentPage++;
			LoadData();
		}

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadData();
		}

		private void iconbtnLast_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadData();
		}
	}
}
