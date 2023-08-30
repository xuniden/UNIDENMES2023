using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.AssyLine.REPAIR;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.REPAIR
{
	public partial class frmCreateRepairCode : Form
	{
		private int totalPages = 1;
		private List<UVASSY_REPAIRGENERALCODE> allData;
		public frmCreateRepairCode()
		{
			InitializeComponent();
		}
		private void frmCreateRepairCode_Load(object sender, EventArgs e)
		{
			cbDept.Text = "--Select--";
			cbYear.Text = "--Select--";
			allData =REPAIRGENERALCODE_DAL.Instance.getAllInfo();
			if (allData == null)
			{
				totalPages = 1;
				Program.currentPage = 1;
				labelTotalRecords.Text = "0";
			}
			else
			{
				LoadData(allData);
			}
		}
		private bool isOKData()
		{
			if (string.IsNullOrEmpty(cbDept.Text) || cbDept.Text.Equals("--Select--"))
			{
				MessageBox.Show("Nhập dữ liệu vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cbDept.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(cbYear.Text) || cbYear.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn năm cần tạo !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cbYear.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtID.Text) || txtID.Text.Equals(""))
			{
				MessageBox.Show("Nhập ID người tạo !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtID.Focus();
				return false;
			}
			if ((int)numericUpDown1.Value > (int)numericUpDown2.Value)
			{
				MessageBox.Show("Nhập sai giá trị !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				numericUpDown1.Focus();
				return false;
			}
			if ((int)numericUpDown2.Value - (int)numericUpDown1.Value > 1000)
			{
				MessageBox.Show("Không tạo quá 1000 tem mỗi lần !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				numericUpDown2.Focus();
				return false;
			}
			if (txtID.Text.Trim().Length != 5)
			{
				MessageBox.Show("ID phải có 5 ký tự !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtID.Focus();
				return false;
			}
			return true;
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			if (isOKData())
			{
				// Tạo ra 1 chuỗi ký tự để tìm kiếm trong csdl xem có chưa
				// Nếu chưa có mới tạo tem, có rồi thì thông báo
				var datetime=CommonDAL.Instance.getSqlServerDatetime();
				var lstAdd= new List<UVASSY_REPAIRGENERALCODE>();
				string keyCompare = "";
				for (int i = (int)numericUpDown1.Value; i <= (int)(numericUpDown2.Value); i++)
				{
					keyCompare = keyCompare + "'" + cbDept.Text + cbYear.Text.Substring(0, 1) + txtID.Text + "-" + i.ToString("00000") + "',";
					var data = new UVASSY_REPAIRGENERALCODE
					{
						RepairCode = cbDept.Text + cbYear.Text.Substring(0, 1) + txtID.Text + "-" + i.ToString("00000"),
						CreatedBy = Program.UserId,
						CreatedDate = datetime
					};
					lstAdd.Add(data);
				}
				keyCompare = keyCompare.Substring(0, keyCompare.Length - 1) + ")";

				var dt = REPAIRGENERALCODE_DAL.Instance.CheckRepairCodeList(keyCompare);
				if (dt.Rows.Count > 0)
				{
					MessageBox.Show("Dữ liệu đã được tạo rồi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					dataGridView.DataSource = null;
					dataGridView.DataSource = dt;
					numericUpDown1.Focus();
					return;
				}
				else
				{					
					string message=REPAIRGENERALCODE_DAL.Instance.AddRange(lstAdd);
					if (string.IsNullOrEmpty(message))
					{
						allData=REPAIRGENERALCODE_DAL.Instance.getAllInfo();
						LoadData(allData);
						MessageBox.Show("Đã tạo xong mã Repair code !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Đã có lỗi xảy ra !!!" + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					
				}
			}			
		}
		private void LoadData(List<UVASSY_REPAIRGENERALCODE> lstData)
		{
			List<UVASSY_REPAIRGENERALCODE> pagedData = PagingHelper.GetPagedList(lstData, Program.currentPage, Program.pageSize);
			CommonDAL.Instance.ShowDataGridView(dataGridView, pagedData);
			int totalRecords = lstData.Count;
			labelTotalRecords.Text = totalRecords.ToString();
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadData(allData);
			}
		}

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			if (Program.currentPage >= totalPages)
			{
				Program.currentPage = totalPages;
			}
			else
			{
				Program.currentPage++;
			}
			LoadData(allData);
		}

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
			Program.currentPage = 1;
			LoadData(allData);
		}

		private void iconbtnLast_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadData(allData);
		}


		private void searchData(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập dữ liệu cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else
			{
				allData=REPAIRGENERALCODE_DAL.Instance.searchAllInfo(search);
				LoadData(allData);
			}	
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			searchData(txtSearch.Text.Trim());
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				searchData(txtSearch.Text.Trim());
			}
		}

		private void btnHuy_Click(object sender, EventArgs e)
		{
			cbDept.Text = "--Select--";
			cbYear.Text = "--Select--";
			txtID.Text=string.Empty;
			numericUpDown1.Value = 0;
			numericUpDown2.Value = 0;
		}
	}
}
