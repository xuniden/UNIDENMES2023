using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Assy;
using UnidenDAL;
using UnidenDTO;
using Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.Assy
{
	public partial class frmAddRepairIssueByLine : Form
	{
		UVEntities _entities;
		public frmAddRepairIssueByLine()
		{
			InitializeComponent();
		}
		private void frmAddRepairIssueByLine_Load(object sender, EventArgs e)
		{
			_entities = new UVEntities();
		}
		private void searchData(string search)
		{
			if (search.Equals(""))
			{
				MessageBox.Show("Nhập điều kiện cần tìm kiếm Barcode/Lot/ProcessName/LineName/CreatedBy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				var lst = new List<UV_LINEERRORRECORD>();
				lst = LINEERRORRECORD_DAL.Instance.SearchData(search);
				if (lst.Count > 0)
				{
					if (lst.Count > 1000)
					{
						CommonDAL.Instance.ShowDataGridView(dgView, lst.Take(1000));
						MessageBox.Show("Kết quả tìm kiếm >1000 bản ghi \n " +
							"Chỉ lấy 1000 bản ghi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				searchData(txtSearch.Text);
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			searchData(txtSearch.Text);
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
					//loadErrorCode();
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
			if (checkQRcode())
			{
				cbErrorCode.Focus();
			}
			else
			{
				txtQrCode.SelectAll();
				txtQrCode.Focus();
			}
		}

		
	}
}
