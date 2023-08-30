using Microsoft.VisualBasic.FileIO;
using QRCoder;
using SMTPRORAM.AssyLine.CrystalReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.AssyLine.VIEW;
using UnidenDTO;

namespace SMTPRORAM.AssyLine.VIEW
{
	public partial class frmPrintQRCode : Form
	{
		public frmPrintQRCode()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open CSV File";
			theDialog.Filter = "CSV files|*.csv";
			theDialog.InitialDirectory = @"C:\";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = theDialog.FileName;
				txtpath.Text = filename;
				// string[] filelines = File.ReadAllLines(filename);
			}
		}

		private void btView_Click(object sender, EventArgs e)
		{
			var lstPrint= PRINTQRCODE_DAL.Instance.getListPrint();
			QRCrystalReport cp = new QRCrystalReport();
			int i = lstPrint.Count;
			cp.SetDataSource(lstPrint);
			crystalReportViewer.ReportSource = cp;
			crystalReportViewer.Refresh();
		}

		private void btnCreateQRCode_Click(object sender, EventArgs e)
		{
			int x = int.Parse(textBox1.Text);
			if (x <= 0)
			{
				MessageBox.Show("Nhập sai dữ liệu !!!");
				textBox1.Focus();
				textBox1.SelectAll();
				return;
			}
			else
			{
				// xóa hết csdl cũ
				var lstOldQR = PRINTQRCODE_DAL.Instance.getListPrint();
				string message=PRINTQRCODE_DAL.Instance.DeleteRange(lstOldQR);
				if (!string.IsNullOrEmpty(message))
				{
					MessageBox.Show("Đã không xóa được bản ghi cũ để tạo bản ghi mới: \n" + message,
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				
				// Tạo dữ liệu ghi vào csdl;
				int k = int.Parse(txtQT.Text);
				if (k <= 0)
				{
					MessageBox.Show("Dữ liệu bị sai QT!!!");
					return;
				}
				else
				{
					// tính số thùng linh kiên.
					int i = (x / k);
					int ii = x % k;
					if (ii > 0)
					{
						i = i + 1;
					}

					if (i > 0)
					{
						try
						{
							var lstAddNew = new List<UVASSY_QRCODELABEL>();
							for (int j = 1; j <= i; j++)
							{
								var addNew = new UVASSY_QRCODELABEL
								{
									Supplier = "UNIDEN VIETNAM Ltd",
									SupplierAdd = "Lot 5.1 Tan Truong IZ, Tan Truong Comu, Cam Giang Dist, Hai Duong VN.",
									Market = txtModel.Text,
									PN = txtPN.Text,
									LN = txtLN.Text.Trim().ToUpper(),
									PD = txtPD.Text,
									ED = txtED.Text,
									UT = txtUT.Text,
									SC = txtSC.Text,
									BoxNo = j.ToString("0000")
								};
								int qq = 0;
							
								if (j == i && ii > 0)
								{									
									addNew.QT = ii;
									qq = ii;
								}
								else
								{
									addNew.QT = int.Parse(txtQT.Text);
									qq = int.Parse(txtQT.Text);
								}								
								
								string qcode = "";
								//qcode = txtModel.Text +","+ txtPN.Text + "," + txtLN.Text + "," + txtPD.Text + "," + txtED.Text + "," + txtQT.Text + "," + txtUT.Text + "," + txtSC.Text;
								qcode = txtModel.Text + "," + txtPN.Text + "," + txtLN.Text + "," + txtPD.Text + "," + txtED.Text + "," + qq + "," + txtUT.Text + "," + txtSC.Text;
								QRCodeGenerator qr = new QRCodeGenerator();
								QRCodeData dr = qr.CreateQrCode(qcode, QRCodeGenerator.ECCLevel.Q);
								QRCode qc = new QRCode(dr);
								pictureBox1.Image = qc.GetGraphic(5);
								MemoryStream stream = new MemoryStream();
								pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
								byte[] pic = stream.ToArray();
								addNew.Images = pic;
								lstAddNew.Add(addNew);								
							}

							string message2 = PRINTQRCODE_DAL.Instance.AddRange(lstAddNew);
							if (!string.IsNullOrEmpty(message2))
							{
								MessageBox.Show("Đã không thể tạo được QR code \n" + message2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}
							else
							{
								MessageBox.Show("Finished !!!");
								return;
							}

						}
						catch (Exception ex)
						{
							MessageBox.Show("đã có lỗi: " + ex.Message);
							return;
						}
						
					}
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			bool flag = true;			
			if (string.IsNullOrEmpty(txtpath.Text.Trim()))
			{
				MessageBox.Show("Hãy Nhập File cần Import vào đây");
				return;
			}
			else
			{
				using (TextFieldParser parser = new TextFieldParser(txtpath.Text))
				{
					parser.ReadLine();
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");
					// check before import
					while (!parser.EndOfData)
					{
						//Processing row
						string[] fields = parser.ReadFields();
						if (fields.Length != 5)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					using (TextFieldParser parser1 = new TextFieldParser(txtpath.Text))
					{
						parser1.ReadLine();
						parser1.TextFieldType = FieldType.Delimited;
						parser1.SetDelimiters(",");
						var addNewList = new List<UVASSY_IMPORTQRCODE>();
						while (!parser1.EndOfData)
						{
							string[] fields = parser1.ReadFields();
							var addNew = new UVASSY_IMPORTQRCODE
							{
								Market = fields[0].ToString().Trim(),
								PN = fields[1].ToString().Trim(),
								QT = int.Parse(fields[2].ToString().Trim()),
								UT = fields[3].ToString().Trim(),
								SC = fields[4].ToString().Trim()
							};
							addNewList.Add(addNew);
						}					
						string message=IMPORTQRCODE_DAL.Instance.AddRange(addNewList);
						if (string.IsNullOrEmpty(message))
						{
							MessageBox.Show("Finished !!!");
							return;
						}
						else
						{
							MessageBox.Show("đã có lỗi xảy ra khi import file : \n" +message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							return;
						}
					}
				}
				
			}
		}

		private void txtModel_KeyDown(object sender, KeyEventArgs e)
		{
			txtModel.Text = txtModel.Text.Trim().ToUpper();
			if (e.KeyValue == 13)
			{
				if (txtModel.Text.Equals(""))
				{
					MessageBox.Show("Nhập dữ liệu vào !!!");
					txtModel.Focus();
				}
				else
				{
					var checkModel=IMPORTQRCODE_DAL.Instance.checkModel(txtModel.Text.Trim());
					if (checkModel!=null)
					{
						txtPN.Text = checkModel.PN;
						txtQT.Text = checkModel.QT.ToString();
						txtUT.Text = checkModel.UT;
						txtSC.Text = checkModel.SC;
						// CultureInfo ci = new CultureInfo("ja-JP");
						txtPD.Text = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy-MM-dd");
						//txtPD.Text=dtt.ToString("yyyy-MM-dd",ci);
						DateTime today = CommonDAL.Instance.getSqlServerDatetime();
						DateTime sixMonthsBack = today.AddMonths(6);
						txtED.Text = sixMonthsBack.ToString("yyyy-MM-dd");

					}
					else
					{
						MessageBox.Show("Không có dữ liệu trong csdl !!!");
						txtModel.Focus();
						txtModel.SelectAll();
					}
				}
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
			{ e.Handled = true; }
		}

		
	}
}
