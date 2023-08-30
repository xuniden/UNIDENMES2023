using DocumentFormat.OpenXml.VariantTypes;
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
using UnidenDAL.AssyLine.MENU;
using UnidenDAL.Smt.Output;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.MENU
{
	public partial class frmCOM21 : Form
	{
		private string dboxbarcode = "";
		private string chkdb = "";
		private int cunit = 0;
		private int icount = 0;
		private int mcount = 0;
		public frmCOM21()
		{
			InitializeComponent();
		}

		private void frmCOM21_Load(object sender, EventArgs e)
		{
			pb2OK.Visible = false;
			pb2NG.Visible = false;
			pb1OK.Visible = false;
			pb1NG.Visible = false;	

		
			txtLine.Text = "";
			txtChkDbox.Text = "";
			txtModel.Text = "";
			txtUnitCnt.Text = "";
			txtChkDbox2.Text = "";
			txtChkDbox.Enabled = false;
			txtChkDbox2.Enabled = false;
			txtLine.Enabled = false;

			LoadLot();
			cbLot.Focus();
		}
		private void LoadLot()
		{
			var listLot = LOTCONTROL_DAL.Instance.listLots();
			cbLot.DataSource = listLot;
			cbLot.DisplayMember = "Lot";
			cbLot.ValueMember = "Lot";
		}

		private void cbLot_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbLot.SelectedItem is groupLot selectLot)
			{
				if (cbLot.Text.Equals("--Select--"))
				{
					MessageBox.Show("Hãy chọn LOT","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					cbLot.Focus();
					return;
				}
				else
				{
					var checkLot=LOTCONTROL_DAL.Instance.checkExistLot(cbLot.Text);					
					if (checkLot!=null)
					{
						txtModel.Text = checkLot.Model;
						txtUnitCnt.Text = checkLot.UnitCtn.ToString();
						cunit = checkLot.UnitCtn;
						dboxbarcode = checkLot.Dbox_Barcode;
						txtLine.Enabled = true;
						txtLine.Focus();						
					}
					else
					{
						MessageBox.Show("LOT này chưa được setup trong LOT CONTROL");
						cbLot.Focus();
						return;
					}
				}
			}
		}

		private void txtLine_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (string.IsNullOrEmpty(txtLine.Text.Trim()))
				{
					MessageBox.Show("Hãy Nhập tên LINE vào đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					txtLine.Focus();
					return;
				}
				else
				{
					txtLine.Enabled = false;
					txtChkDbox.Enabled = true;
					txtChkDbox.Focus();
				}
			}
		}

		private void txtChkDbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{				
				if (txtChkDbox.Text.Trim().Equals( dboxbarcode))
				{
					icount = icount + 1;
					pb1OK.Visible = true;
					pb1NG.Visible = false;

					//txtChkDbox.Text = "Check DBOX: (" + icount + " / " + cunit + " ) OK.";
					//txtChkDbox.SelectAll();
					//if (icount >= cunit)
					//{
					txtChkDbox2.Enabled = true;
					txtChkDbox2.Focus();
					txtChkDbox.Enabled = false;
					//}
				}
				else
				{
					pb1NG.Visible = true;
					pb1OK.Visible = false;
					txtChkDbox.Text = "NHẬP SAI !!!!";
					txtChkDbox.Focus();
					txtChkDbox.SelectAll();
				}
			}
		}

		private void txtChkDbox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				if (dboxbarcode.Contains(txtChkDbox2.Text.Trim()))
				{
					mcount = mcount + 1;
					pb2OK.Visible = true;
					pb2NG.Visible = false;
					chkdb = txtChkDbox2.Text.Trim();
					//txtChkDbox2.Text = "Check DBOX: (" + mcount + " / " + cunit + " ) OK.";
					txtChkDbox2.SelectAll();
					//if (mcount >= cunit)
					//{
					// Ghi lại dữ liệu tự động					

					var addNew = new UVASSY_COM21
					{
						Lot = cbLot.Text.Trim(),
						Line = txtLine.Text.Trim(),
						Model = txtModel.Text.Trim(),
						Unit = int.Parse(txtUnitCnt.Text.Trim()),
						Dbox_barcode = dboxbarcode,
						Dbox_check = chkdb,
						CreatedBy = Program.UserId,
						CreatedDate = CommonDAL.Instance.getSqlServerDatetime()
					};
					string message = COM21_DAL.Instance.Add(addNew);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.ShowDataGridView(dgView,COM21_DAL.Instance.GetAllByUser(Program.UserId, cbLot.Text.Trim()));
						txtChkDbox.Text = "";
						txtChkDbox2.Text = "";
						txtLine.Enabled = false;						
						txtChkDbox2.Enabled = false;
						txtChkDbox.Enabled = true;
						pb2OK.Visible = false;
						pb2NG.Visible = false;
						pb1OK.Visible = false;
						pb1NG.Visible = false;		
						txtChkDbox.Focus();
						icount = 0;
						mcount = 0;
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra khi lưu thông tin check: " +message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					
				}
				else
				{
					pb2NG.Visible = true;
					pb2OK.Visible = false;
					txtChkDbox2.Text = "NHẬP SAI !!!!";
					txtChkDbox2.Focus();
					txtChkDbox2.SelectAll();
				}
			}
		}
	}
}
