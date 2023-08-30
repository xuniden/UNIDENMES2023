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
using UnidenDAL.AssyLine.UG;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.UG
{
	public partial class frmBCard : Form
	{
		public frmBCard()
		{
			InitializeComponent();
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

		private void btProcess_Click(object sender, EventArgs e)
		{
			bool flag = true;			
			if (string.IsNullOrEmpty(txtBrowser.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây");
				txtBrowser.Focus();
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtBrowser.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					// check before import
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 2)
						{
							flag = false;
							break;
						}						
					}
				}
				if (flag)
				{
					using (TextFieldParser parser1 = new TextFieldParser(txtBrowser.Text))
					{
						var lstAddData= new List<UVASSY_BCARDDATA>();
						var datetime = CommonDAL.Instance.getSqlServerDatetime();
						parser1.ReadLine();
						parser1.TextFieldType = FieldType.Delimited;
						parser1.SetDelimiters(",");						
						while (!parser1.EndOfData)
						{
							string[] fields = parser1.ReadFields();
							var bcard = new UVASSY_BCARDDATA
							{
								BCard = fields[0].ToString(),
								BCard15 = fields[1].ToString(),
								ImportDate = datetime
							};
							lstAddData.Add(bcard);
						}
						string message= BCARDDATA_DAL.Instance.AddRange(lstAddData);
						if (string.IsNullOrEmpty(message))
						{
							CommonDAL.Instance.ShowDataGridView(dgView, BCARDDATA_DAL.Instance.getListBcard());
							MessageBox.Show("Finished Import");
							return;
						}
						else
						{
							MessageBox.Show("Đã có lỗi xảy ra khi import dữ liệu !!!\n" + message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							return;
						}
					}
				}					
			}
		}
	}
}
