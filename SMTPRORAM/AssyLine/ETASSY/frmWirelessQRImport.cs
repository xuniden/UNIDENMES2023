using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.AssyLine.ETASSY;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.ETASSY
{
	public partial class frmWirelessQRImport : Form
	{	
		private int totalPages;
		private List<UVASSY_EASTECHQRWIRELESS> lstResult;
		private List<SYS_UserButtonFunction> lstUBFunction;
		public frmWirelessQRImport()
		{
			InitializeComponent();
		}

		private void frmWirelessQRImport_Load(object sender, EventArgs e)
		{
			lstResult = EASTECHQRWIRELESS_DAL.Instance.getListWirelessQRData();
			LoadDataPaging(lstResult);

			// Kiểm tra xem button có được enable hay không?
			lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
			var lst = CommonDAL.Instance.AllSubControls(this).ToList();
			CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
		}

		private void LoadDataPaging(List<UVASSY_EASTECHQRWIRELESS> lstdata)
		{
			List<UVASSY_EASTECHQRWIRELESS> pagedData = PagingHelper.GetPagedList(lstdata, Program.currentPage, Program.pageSize);
			dataGridView.DataSource = pagedData;
			int totalRecords = lstResult.Count;
			totalPages = (int)Math.Ceiling((double)totalRecords / Program.pageSize);
			labelPageInfo.Text = $"Page {Program.currentPage} of {totalPages}";
			labelTotalRecords.Text = totalRecords.ToString();
		}
		private void btFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtPath.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btUpload_Click(object sender, EventArgs e)
		{
			bool flag = true;			
			if (string.IsNullOrEmpty(txtPath.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtPath.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					// check before import
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 3)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					using (TextFieldParser parser1 = new TextFieldParser(txtPath.Text))
					{
						var datetime = CommonDAL.Instance.getSqlServerDatetime();
						var lstWirelessQR= new List<UVASSY_EASTECHQRWIRELESS>();
						parser1.ReadLine();
						parser1.TextFieldType = FieldType.Delimited;
						parser1.SetDelimiters(",");
						while (!parser1.EndOfData)
						{
							string[] fields = parser1.ReadFields();
							var wirelessQR = new UVASSY_EASTECHQRWIRELESS
							{
								KeyCode = fields[0].ToString() + "--" + fields[2].ToString(),
								Model = fields[0].ToString(),
								Partcode = fields[1].ToString(),
								QRWireless = fields[2].ToString(),
								CreatedBy=Program.UserId,
								CreatedDate=datetime
							};
							lstWirelessQR.Add(wirelessQR);								
						}
						string message=EASTECHQRWIRELESS_DAL.Instance.AddRange(lstWirelessQR);
						if (string.IsNullOrEmpty(message))
						{
							dataGridView.DataSource = null;
							MessageBox.Show("Impport finished !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							lstResult=lstWirelessQR.ToList();
							LoadDataPaging(lstResult);							
							return;
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra: "+ message,"Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
							return;
						}				
					}
				}	
				else
				{
					dataGridView.DataSource = null;
					MessageBox.Show("Dữ liệu import vào không đúng, Hãy kiểm tra lại.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
			}
		}

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			Program.currentPage++;
			LoadDataPaging(lstResult);
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (Program.currentPage > 1)
			{
				Program.currentPage--;
				LoadDataPaging(lstResult);
			}
		}

		private void iconbtnLast_Click(object sender, EventArgs e)
		{
			Program.currentPage = totalPages;
			LoadDataPaging(lstResult);
		}

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
			Program.currentPage =1;
			LoadDataPaging(lstResult);
		}

		private void searchData(string search)
		{
			if (string.IsNullOrEmpty(search))
			{
				MessageBox.Show("Nhập dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSearch.Focus();
				return;
			}
			else
			{
				lstResult = EASTECHQRWIRELESS_DAL.Instance.searchData(search);
				if (lstResult.Count > 0)
				{
					LoadDataPaging(lstResult);
				}
				else
				{
					MessageBox.Show("Không có dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtSearch.Focus();
					return;
				}
			}
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (Keys.Enter==e.KeyCode)
			{
				searchData(txtSearch.Text.Trim());
			}
		}

		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			searchData(txtSearch.Text.Trim());
		}
	}
}
