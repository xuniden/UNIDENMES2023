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
using UnidenDAL.Jig;
using UnidenDAL.Jig.JIG;
using System.IO;

namespace SMTPRORAM.Jig.JIG
{
	public partial class frmJIGRepairHistory : Form
	{
		private bool AddFlag = false;
		private bool EditFlag = false;
		private string userConf = "";
		private List<SYS_UserButtonFunction> lstUBFunction;
		private long Id = 0;
		public frmJIGRepairHistory()
		{
			InitializeComponent();
		}

		private void frmJIGRepairHistory_Load(object sender, EventArgs e)
		{
			_enable(false);
			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

			// Load first 5 days of history from today
			ShowHistoryByUser();
			LoadCombobox();
		}
		void _enable(bool t)
		{
			txtControlNo.Enabled = t;
			dateTimePicker1.Enabled = t;
			richRepairReason.Enabled = t;
			richRepairAction.Enabled = t;
			cbVitri.Enabled = t;
			txtLKTT.Enabled = t;
			txtRemark.Enabled = t;
			txtPahtImage01.Enabled = t;
			txtPahtImage02.Enabled = t;
		}

		void ResetControll()
		{
			txtControlNo.Text = "";
			richRepairReason.Text = "";
			richRepairAction.Text = "";
			cbVitri.Text = "";
			txtLKTT.Text = "";
			txtRemark.Text = "";
			txtPahtImage01.Text = "";
			txtPahtImage02.Text = "";
			pBTruoc.Image = null;
			pBSau.Image = null;
		}
		void showHideControll(bool t)
		{
			iconbtnAdd.Visible = !t;
			iconbtnEdit.Visible = t;
			iconbtnDelete.Visible = t;
			iconbtnCancel.Visible = !t;
			iconbtnSave.Visible = !t;
		}
		private void ShowHistoryByUser()
		{
			CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, JIGHREPAIRE_DAL.Instance.getHistoryByUser(Program.UserId));
		}
		private void searchData(string search)
		{
			if (search.Equals(""))
			{
				MessageBox.Show("Nhập dữ liệu cần tìm kiếm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				JIGREPAIRHISTORY_DAL.Instance.searchData(search);
			}
		}
		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Enter)
			{
				string inputString = txtControlNo.Text.Trim();
				char[] separator = { ';' };
				string[] result = inputString.Split(separator);
				txtSearch.Text = result[0];
				searchData(txtSearch.Text);
			}
		}

		private void icobtnSearch_Click(object sender, EventArgs e)
		{
			searchData(txtSearch.Text);
		}

		private void iconbtnAdd_Click(object sender, EventArgs e)
		{
			AddFlag = true;
			EditFlag = false;
			//showHideControll(false);
			iconbtnAdd.Visible = false;
			iconbtnCancel.Visible = true;
			iconbtnEdit.Visible = false;
			iconbtnSave.Visible = true;
			_enable(true);
			ResetControll();
		}

		private void iconbtnCancel_Click(object sender, EventArgs e)
		{
			AddFlag = false;
			EditFlag = false;
			//showHideControll(true);
			iconbtnAdd.Visible = true;
			iconbtnCancel.Visible = true;
			iconbtnEdit.Visible = false;
			iconbtnSave.Visible = false;

			_enable(false);
			ResetControll();
		}

		private void iconbtnExportCsv_Click(object sender, EventArgs e)
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
					CommonDAL.Instance.writeCSV(dgView, filename);
					MessageBox.Show("Đã Export Thành Công !!!");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
				throw;
			}
		}

		private void iconbtnEdit_Click(object sender, EventArgs e)
		{
			if (Id > 0 && userConf == Program.UserId)
			{
				AddFlag = false;
				EditFlag = true;
				_enable(true);
				//showHideControll(false);
				iconbtnAdd.Visible = false;
				iconbtnCancel.Visible = true;
				iconbtnEdit.Visible = false;
				iconbtnSave.Visible = true;
				txtControlNo.Enabled = false;
			}
			else
			{
				MessageBox.Show("Phải chọn dữ liệu để sửa, đúng với user đã tạo ra?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		private bool IsDataOK()
		{
			if (txtControlNo.Text.Trim().Equals(""))
			{
				MessageBox.Show("Mã thiết bị cần hiệu chỉnh !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtControlNo.Focus();
				return false;
			}
			if (richRepairReason.Text.Trim().Equals(""))
			{
				MessageBox.Show("Nguyên nhân không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				richRepairReason.Focus();
				return false;
			}
			if (richRepairAction.Text.Trim().Equals(""))
			{
				MessageBox.Show("Các khăc phục không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				richRepairReason.Focus();
				return false;
			}
			return true;
		}
		private bool IsImagePathValid(string imagePath)
		{
			try
			{
				using (var image = Image.FromFile(imagePath))
				{
					return true; // Valid image file
				}
			}
			catch (OutOfMemoryException)
			{
				// The file is not a valid image
				return false;
			}
			catch (FileNotFoundException)
			{
				// The file does not exist
				return false;
			}
			catch (ArgumentException)
			{
				// The file path is invalid
				return false;
			}
		}

		private void iconbtnSave_Click(object sender, EventArgs e)
		{
			if (IsDataOK())
			{
				var repairHistory = new JIGH_REPAIRHISTORY();
				repairHistory.ControlNo = txtControlNo.Text;
				repairHistory.RepairDate = dateTimePicker1.Value.Date;
				repairHistory.RepairReason = richRepairReason.Text.Trim();
				repairHistory.RepairAction = richRepairAction.Text.Trim();
				repairHistory.RepairMaterial = txtLKTT.Text.Trim();
				repairHistory.RepairPosition = cbVitri.Text.Trim();
				repairHistory.RStatus=cbStatus.Text.Trim();
				if (!txtPahtImage01.Text.Equals(""))
				{
					if (IsImagePathValid(txtPahtImage01.Text))
					{
						byte[] imageData1;
						using (var stream = new MemoryStream())
						{
							using (var image = Image.FromFile(txtPahtImage01.Text))
							{
								image.Save(stream, image.RawFormat); // Save the image using its original format
								imageData1 = stream.ToArray();
								repairHistory.ImgBeforeRepair = imageData1;
							}
						}
					}
				}
				if (!txtPahtImage02.Text.Equals(""))
				{
					if (IsImagePathValid(txtPahtImage02.Text))
					{
						byte[] imageData2;
						using (var stream = new MemoryStream())
						{
							using (var image = Image.FromFile(txtPahtImage02.Text))
							{
								image.Save(stream, image.RawFormat); // Save the image using its original format
								imageData2 = stream.ToArray();
								repairHistory.ImgAfterRepair = imageData2;
							}
						}
					}
				}
				repairHistory.CreatedBy = Program.UserId;
				repairHistory.Remark = txtRemark.Text;
				repairHistory.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
				try
				{
					if (AddFlag == true && EditFlag == false)
					{
						string message = "";
						message = JIGHREPAIRE_DAL.Instance.Add(repairHistory);
						if (message == "")
						{
							string mes = "";
							mes = JIGHCALDEVICES_DAL.Instance.UpdateSStatus(repairHistory.ControlNo, repairHistory.RStatus, repairHistory.CreatedDate);
							if (mes != "")
							{
								MessageBox.Show("Không update được tình trạng JIG vào bảng quản lý JIG\n " +
									"Hãy thông báo cho IT biết để xử lý !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							ShowHistoryByUser();
							ResetControll();
							_enable(false);
							AddFlag = false;
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra khi cập nhật ngày hiệu chỉnh !!!" + message,
													"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					if (AddFlag == false && EditFlag == true && Id > 0)
					{
						repairHistory.Id = Id;
						string message = "";
						message = JIGHREPAIRE_DAL.Instance.Update(repairHistory);
						if (message == "")
						{
							string mes = "";
							mes = JIGHCALDEVICES_DAL.Instance.UpdateSStatus(repairHistory.ControlNo, repairHistory.RStatus, repairHistory.CreatedDate);
							if (mes != "")
							{
								MessageBox.Show("Không update được tình trạng JIG vào bảng quản lý JIG\n " +
									"Hãy thông báo cho IT biết để xử lý !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							ShowHistoryByUser();
							ResetControll();
							_enable(false);
							AddFlag = false;
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra khi cập nhật ngày hiệu chỉnh !!!" + message,
													"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

					}

				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã có lỗi xảy ra khi cập nhật ngày hiệu chỉnh !!!" + ex.Message,
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

			}
		}

		private void txtControlNo_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter == e.KeyCode)
			{
				if (txtControlNo.Text.Trim().Equals(""))
				{
					MessageBox.Show("Hãy nhập mã thiết bị cần hiệu chỉnh !!!",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
				{
					var jigDvc = new JIGH_CALDEVICES();
					string inputString = txtControlNo.Text.Trim();
					char[] separator = { ';' };
					string[] result = inputString.Split(separator);
					if (!result[0].Equals(""))
					{
						txtControlNo.Text = result[0];
						jigDvc = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(txtControlNo.Text.Trim());
						if (jigDvc != null)
						{
							richRepairReason.Focus();
						}
						else
						{
							MessageBox.Show("Không có mã này trong cơ sở dư liệu ",
								"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							txtControlNo.SelectAll();
							txtControlNo.Focus();
							return;
						}
					}
				}

			}
		}
		private void LoadCombobox()
		{
			var lstLoc = JIGLOCATION_DAL.Instance.getListLocation();
			var loc = new ShowDisplay();
			loc.LocName = "[None]";
			lstLoc.Add(loc);
			cbVitri.DataSource = lstLoc.OrderBy(p => p.LocName).ToList();
			cbVitri.DisplayMember = "LocName";
			cbVitri.ValueMember = "LocName";
		}
		private void txtControlNo_Validating(object sender, CancelEventArgs e)
		{
			if (txtControlNo.Text.Trim().Equals(""))
			{
				MessageBox.Show("Hãy nhập mã thiết bị cần hiệu chỉnh !!!",
					"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else
			{
				var jigDvc = new JIGH_CALDEVICES();
				string inputString = txtControlNo.Text.Trim();
				char[] separator = { ';' };
				string[] result = inputString.Split(separator);
				if (!result[0].Equals(""))
				{
					txtControlNo.Text = result[0];
					jigDvc = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(txtControlNo.Text.Trim());
					if (jigDvc != null)
					{
						richRepairReason.Focus();
					}
					else
					{
						MessageBox.Show("Không có mã này trong cơ sở dư liệu ",
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						txtControlNo.SelectAll();
						txtControlNo.Focus();
						return;
					}
				}
			}
		}

		private void iconbtnTimage_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
				openFileDialog.Title = "Select an Image";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string imagePath = openFileDialog.FileName;
					txtPahtImage01.Text = imagePath;
					pBTruoc.Image = Image.FromFile(imagePath);
				}
			}
		}

		private void iconbtnSimage_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
				openFileDialog.Title = "Select an Image";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string imagePath = openFileDialog.FileName;
					txtPahtImage02.Text = imagePath;
					pBSau.Image = Image.FromFile(imagePath);
				}
			}
		}

		private void dgView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			AddFlag = false;
			iconbtnAdd.Visible = false;
			iconbtnCancel.Visible = true;
			iconbtnEdit.Visible = true;
			iconbtnSave.Visible = true;

			DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
			Id = long.Parse(row.Cells[0].Value.ToString());

			var eqRepair = new JIGH_REPAIRHISTORY();
			eqRepair = JIGHREPAIRE_DAL.Instance.getById(Id);
			txtControlNo.Text = eqRepair.ControlNo;
			richRepairReason.Text = eqRepair.RepairReason;
			richRepairAction.Text = eqRepair.RepairAction;
			cbVitri.Text = eqRepair.RepairPosition;
			txtLKTT.Text = eqRepair.RepairMaterial;
			txtRemark.Text = eqRepair.Remark;
			dateTimePicker1.Value = eqRepair.RepairDate;
			if (eqRepair.ImgBeforeRepair != null)
			{
				using (var stream = new MemoryStream(eqRepair.ImgBeforeRepair))
				{
					pBTruoc.Image = Image.FromStream(stream);
				}
			}
			else
			{
				pBTruoc.Image = null;
			}

			if (eqRepair.ImgAfterRepair != null)
			{
				using (var stream = new MemoryStream(eqRepair.ImgAfterRepair))
				{
					pBSau.Image = Image.FromStream(stream);
				}
			}
			else
			{
				pBSau.Image = null;
			}
			userConf = eqRepair.CreatedBy;
			//MessageBox.Show(Id.ToString());
		}

		private void pBTruoc_Click(object sender, EventArgs e)
		{
			// Get the clicked image from the PictureBox
			Image clickedImage = pBTruoc.Image;

			// Create a new form or dialog
			Form popupForm = new Form();
			popupForm.StartPosition = FormStartPosition.CenterParent;

			// Create a new PictureBox control on the popup form
			PictureBox popupPictureBox = new PictureBox();
			popupPictureBox.Dock = DockStyle.Fill;
			popupPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			popupPictureBox.Image = clickedImage;

			// Add the PictureBox control to the popup form
			popupForm.Controls.Add(popupPictureBox);

			// Set the size of the popup form based on the size of the clicked image
			popupForm.ClientSize = clickedImage.Size;

			// Show the popup form as a dialog
			popupForm.ShowDialog();
		}

		private void pBSau_Click(object sender, EventArgs e)
		{
			// Get the clicked image from the PictureBox
			Image clickedImage = pBSau.Image;

			// Create a new form or dialog
			Form popupForm = new Form();
			popupForm.StartPosition = FormStartPosition.CenterParent;

			// Create a new PictureBox control on the popup form
			PictureBox popupPictureBox = new PictureBox();
			popupPictureBox.Dock = DockStyle.Fill;
			popupPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			popupPictureBox.Image = clickedImage;

			// Add the PictureBox control to the popup form
			popupForm.Controls.Add(popupPictureBox);

			// Set the size of the popup form based on the size of the clicked image
			popupForm.ClientSize = clickedImage.Size;

			// Show the popup form as a dialog
			popupForm.ShowDialog();
		}
	}
}
