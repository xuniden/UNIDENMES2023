using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
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
using UnidenDTO;

namespace SMTPRORAM.Assy.ET
{
    public partial class frmAssyETCheckProcess : Form
    {
        public static string Rem1 = "";
        public static string Rem2 = "";
        public static string Rem3 = "";
        private float firstWidth;
        private float firstHeight;
        public frmAssyETCheckProcess()
        {
            InitializeComponent();
        }

        private void frmAssyETCheckProcess_Load(object sender, EventArgs e)
        {
            firstWidth = this.Size.Width;
            firstHeight = this.Size.Height;

            btSave.Enabled = false;
            ok.Visible = false;
            NG.Visible = false;
            txtWireless.Text = "";
            txtWireless.Enabled = false;
            // Each SubItem object requires a column, so add three columns.
            this.listView1.Columns.Add("STT", 80, HorizontalAlignment.Left);
			this.listView1.Columns.Add("Line ", 80, HorizontalAlignment.Left);
			this.listView1.Columns.Add("Model", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Market", 130, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Type PCB", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("QR Code", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Date", 150, HorizontalAlignment.Left);

            txtQrCode.Text = "";

            var cbbMarket = new DataTable();
            cbbMarket = General_Serial_Services.EstechSerialGeneral_Market();
            if (cbbMarket.Rows.Count > 0)
            {
                cbMarket.DataSource = cbbMarket;
                cbMarket.DisplayMember = "Market";
                cbMarket.ValueMember = "Market";
            }

            lblChecker.Text = Program.username;
            lblNgayThang.Text = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd");
            lblSoLuong.Text = "0";
            var pcbModel = new DataTable();
            pcbModel = Pcb_Code_Services.PCBCode_GetModel();
            if (pcbModel.Rows.Count > 0)
            {
                cbModel.DataSource = pcbModel;
                cbModel.DisplayMember = "Model";
                cbModel.ValueMember = "Model";
            }
            var typePcb = new DataTable();
            typePcb = Assy_Services.A_TypePcb_Select();
            if (typePcb.Rows.Count > 0)
            {
                cbTypePcb.DataSource = typePcb;
                cbTypePcb.DisplayMember = "TypePcb";
                cbTypePcb.ValueMember = "TypePcb";
            }

            var Process = new DataTable();
            Process = Assy_Services.A_OperatorProcess_Select();
            if (Process.Rows.Count > 0)
            {
                cbProcess.DataSource = Process;
                cbProcess.DisplayMember = "OperatorProcess";
                cbProcess.ValueMember = "OperatorProcess";
            }
			//cbModel.Focus();
			AutoResizeListViewColumns(listView1);
			txtLineName.Focus();
        }

		private void cbProcess_SelectedValueChanged(object sender, EventArgs e)
		{
			if (chkWireless.Checked == true)
			{
				txtWireless.Focus();
			}
			else
			{
				txtQrCode.Focus();
			}
		}
		private void ResetAll()
		{
			int counts = 0;
			cbModel.Enabled = false;
			cbMarket.Enabled = false;
			cbTypePcb.Enabled = false;
			cbProcess.Enabled = false;
			var cdt = new DataTable();
			cdt = AssyOperatorProcess_Services.AssyOperatorProcessData_CoutByUser(lblChecker.Text, CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss"));
			lblSoLuong.Text = cdt.Rows.Count.ToString();
			counts = cdt.Rows.Count;
			listView1.View = View.Details;
			listView1.Items.Insert(0, (new ListViewItem(new string[] { counts.ToString(),txtLineName.Text, cbModel.Text, cbMarket.Text, cbTypePcb.Text, txtQrCode.Text, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") })));
			//counts = counts + 1;
			listView1.GridLines = true;
			btSave.Enabled = false;
			txtQrCode.Text = "";
			if (chkWireless.Checked == true)
			{
				txtWireless.Enabled = true;
				txtWireless.Text = "";
				txtWireless.Focus();
			}
			else
			{
				txtWireless.Enabled = false;
				txtWireless.Text = "";
				txtQrCode.Focus();
			}
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			if (txtLineName.Text.Equals(""))
			{
				MessageBox.Show("Nhập tên line chính sác vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtLineName.Focus();
				return;
			}
			if (chkWireless.Checked == true)
			{
				if (string.IsNullOrEmpty(txtWireless.Text.Trim()) || txtWireless.Text.Trim().Length == 15)
				{
					MessageBox.Show("Nhập dữ liệu đúng vào Wireless (Wireless không chứ 15 ký tự ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtWireless.SelectAll();
					txtWireless.Focus();
					NG.Visible = true;
					Application.DoEvents();
					System.Threading.Thread.Sleep(300);
					NG.Visible = false;
					return;
				}
			}
			if (cbMarket.Text.Equals(""))
			{
				MessageBox.Show("Nhập dữ liệu đúng vào Market ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cbMarket.Focus();
				NG.Visible = true;
				Application.DoEvents();
				System.Threading.Thread.Sleep(300);
				NG.Visible = false;
				return;
			}
			else
			{
				if (string.IsNullOrEmpty(txtQrCode.Text.Trim()))
				{
					MessageBox.Show("QR Code Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtQrCode.Focus();
					NG.Visible = true;
					Application.DoEvents();
					System.Threading.Thread.Sleep(300);
					NG.Visible = false;
					return;
				}
				else
				{
					var assyET = new A_OperatorProcessData();
					var assy = new AssyOperatorProcess_Info();
					assy.LineName = txtLineName.Text.Trim();
					assy.Model = cbModel.Text;
					assy.Market = cbMarket.Text;
					assy.TypePcb = cbTypePcb.Text;
					assy.Process = cbProcess.Text;
					assy.QrCode = txtQrCode.Text;
					assy.Checker = lblChecker.Text;
					if (chkWireless.Checked == true)
					{
						assy.Wireless = txtWireless.Text.Trim();
					}
					else
					{
						assy.Wireless = "";
					}
					assy.DateT = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss");

					// Kiểm tra xem nó đã qua INSERT Hay Chưa??
					if (cbProcess.Text == "APP")
					{
						//assy.Remark3 = "APP";
						assy.Remark2 = "APP";
						var dg = new DataTable();
						dg = EastechOutputHistory_Services.EastechHistory_smt_CheckQRCodeRemark(txtQrCode.Text, "INSERT");
						if (dg.Rows.Count > 0)
						{

							assy.Remark1 = "INSERT PASSED";
						}
						else
						{
							assy.Remark1 = "FAIL INSERT";
						}
						assy.Remark3 = "";
						// Kiểm tra xem đã làm chưa? chưa làm thì lưu làm rồi thì báo là đã làm rồi
						var dgg = new DataTable();
						dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
						try
						{
							if (dgg.Rows.Count > 0)
							{
								MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
								txtQrCode.Clear();
								txtQrCode.Focus();
								return;
								//DialogResult dialogResult = MessageBox.Show("Bạn có muốn ghi đè lên:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo", MessageBoxButtons.YesNo);
								//if (dialogResult == DialogResult.Yes)
								//{
								//    AssyOperatorProcess_Services.AssyOperatorProcess_Update(assy);  
								//    ok.Visible = true;
								//    Application.DoEvents();
								//    System.Threading.Thread.Sleep(300);
								//    ok.Visible = false;
								//    // Update List View
								//    ResetAll();
								//}
								//else if (dialogResult == DialogResult.No)
								//{
								//    txtQrCode.Clear();
								//    txtQrCode.Focus();
								//    return;
								//}                             

							}
							else
							{
								AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
								ok.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								ok.Visible = false;
								// Update List View
								ResetAll();								
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
							return;
						}
					}
					if (cbProcess.Text == "HIPOT" && cbTypePcb.Text == "PSU")
					{
						var dg = new DataTable();
						dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
						if (dg.Rows.Count > 0)
						{
							assy.Remark1 = "";
							assy.Remark2 = "";
							assy.Remark3 = "HIPOT";
							try
							{
								// Kiểm tra xem đã bắn chưa?? Nếu bắn rồi thì thông báo và không lưu

								var dgg = new DataTable();
								dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");
								if (dgg.Rows.Count > 0)
								{
									MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
									txtQrCode.Clear();
									txtQrCode.Focus();
									return;
								}
								else
								{
									AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
									// Update List View
									ok.Visible = true;
									Application.DoEvents();
									System.Threading.Thread.Sleep(300);
									ok.Visible = false;
									ResetAll();
									AutoResizeListViewColumns(listView1);
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
								throw;
							}
						}
						else
						{
							MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
							NG.Visible = true;
							Application.DoEvents();
							System.Threading.Thread.Sleep(300);
							NG.Visible = false;
							txtQrCode.Text = "";
							txtQrCode.Focus();
							return;
						}

					}
					if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "PSU")
					{
						// Kiểm tra xem đã qua hết các công đoạn chưa???
						var dg = new DataTable();
						var di = new DataTable();
						var ditt = new DataTable();
						int fct = 0;
						fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "PSU");
						dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
						ditt = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");
						// Bỏ qua công đoạn với thị trường EC1 //2021-01-17


						if (cbModel.Text.Substring(0, 2) == "EC")
						{
							// Kiểm tra xem đã qua APP chưa??
							if (dg.Rows.Count < 0)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							// Yêu cầu thêm công đoạn check HiPOT //2022-10-28  
							else if (ditt.Rows.Count < 0)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn HIPOT ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							// Kiểm tra xem đã được check ở công đoạn FCT chưa?
							else if (fct < 1)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn FCT ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}

							//----------------------------------------
							else
							{
								assy.Remark2 = "";
								assy.Remark1 = "";
								assy.Remark3 = "OUTPUT";
								try
								{
									// Kiểm tra xem đã bắn chưa??
									var dgg = new DataTable();
									dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
									if (dgg.Rows.Count > 0)
									{
										MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
										txtQrCode.Clear();
										txtQrCode.Focus();
										return;
									}
									else
									{
										AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
										// Update List View
										ok.Visible = true;
										Application.DoEvents();
										System.Threading.Thread.Sleep(300);
										ok.Visible = false;
										ResetAll();										
									}
								}
								catch (Exception ex)
								{
									MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
									throw;
								}
							}

						}
						//---------------------------------------------------------------
						else
						{

							di = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");
							if (dg.Rows.Count > 0 && di.Rows.Count < 1)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn HIPOT ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();

								return;
							}
							else if (dg.Rows.Count < 1 && dg.Rows.Count > 0)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							else if (dg.Rows.Count < 1 && dg.Rows.Count < 1)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP và HIPOT ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							else if (fct < 0)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn check FCT ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							else
							{
								assy.Remark2 = "";
								assy.Remark1 = "";
								assy.Remark3 = "OUTPUT";
								try
								{
									// Kiểm tra xem đã bắn chưa??
									var dgg = new DataTable();
									dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
									if (dgg.Rows.Count > 0)
									{
										MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
										txtQrCode.Clear();
										txtQrCode.Focus();
										return;
									}
									else
									{
										AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
										// Update List View
										ok.Visible = true;
										Application.DoEvents();
										System.Threading.Thread.Sleep(300);
										ok.Visible = false;
										ResetAll();										
									}
								}
								catch (Exception ex)
								{
									MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
									throw;
								}
							}
						}
					}
					if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "MAIN")
					{
						// Kiểm tra xem đã qua hết các công đoạn chưa???
						if (cbModel.Text.Substring(0, 2) == "EC")
						{
							var dg = new DataTable();
							dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
							int fct = 0;
							fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "MAIN");
							if (dg.Rows.Count < 1)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							else if (fct < 1)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn FCT ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							else
							{
								assy.Remark2 = "";
								assy.Remark1 = "";
								assy.Remark3 = "OUTPUT";

								// Kiểm tra xem thị trường ở FCT với ở APP có giống nhau không
								// 1) Lấy code market từ công đoạn check FCT ở dạng 00, 01,....
								//    Sau đó so sánh để lấy ra ký hiệu Market của nó ở dạng E12,CN4,... theo QRcode
								// 2) Lấy ký hiệu market từ công đoạn check APP ở dạng E12,CN4,...
								// 3) Lấy 1 và 2 so sánh với nhau --> Nếu khớp thì save không thì báo không trùng nhau.
								// [sp_A_EastechCheckFCT_MAIN]
								bool checkFlag = false;
								var checkdt = AssyOperatorProcess_Services.A_EastechCheckFCT_MAIN(txtQrCode.Text.Trim());
								if (checkdt.Rows.Count > 0)
								{
									foreach (DataRow row in checkdt.Rows)
									{
										if (row["checkFlag"].ToString() == "True")
										{
											checkFlag = true;
											break;
										}
									}
								}
								else
								{
									MessageBox.Show("Không có dữ liệu trong CSDL !!!");
									return;
								}
								if (checkFlag == true)
								{
									try
									{
										// Kiểm tra xem đã bắn chưa??
										var dgg = new DataTable();
										dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
										if (dgg.Rows.Count > 0)
										{
											MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
											txtQrCode.Clear();
											txtQrCode.Focus();
											return;
										}
										else
										{
											AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
											// Update List View
											ok.Visible = true;
											Application.DoEvents();
											System.Threading.Thread.Sleep(300);
											ok.Visible = false;
											ResetAll();											
										}
									}
									catch (Exception ex)
									{
										MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
										throw;
									}
								}
								else
								{
									MessageBox.Show("Sai thị trường cần kiểm tra lại, Hãy liên lạc với người quản lý  !!!");
									NG.Visible = true;
									Application.DoEvents();
									System.Threading.Thread.Sleep(300);
									NG.Visible = false;
									txtQrCode.Text = "";
									txtQrCode.Focus();
									return;
								}
							}
						}
						else
						{
							// Kiểm tra xem đã qua hết các công đoạn chưa???
							var dg = new DataTable();
							dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
							int fct = 0;
							fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "MAIN");
							if (dg.Rows.Count < 1)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							else if (fct < 1)
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn FCT ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
							else
							{
								assy.Remark2 = "";
								assy.Remark1 = "";
								assy.Remark3 = "OUTPUT";
								try
								{
									// Kiểm tra xem đã bắn chưa??
									var dgg = new DataTable();
									dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
									if (dgg.Rows.Count > 0)
									{
										MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
										txtQrCode.Clear();
										txtQrCode.Focus();
										return;
									}
									else
									{
										AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
										// Update List View
										ok.Visible = true;
										Application.DoEvents();
										System.Threading.Thread.Sleep(300);
										ok.Visible = false;
										ResetAll();										
									}
								}
								catch (Exception ex)
								{
									MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
									throw;
								}
							}
						}

					}
					if (cbProcess.Text == "HIPOT" && cbTypePcb.Text == "AMP")
					{
						if (cbModel.Text.Trim().Substring(0, 2) == "CD")
						{
							var dg = new DataTable();
							dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
							if (dg.Rows.Count > 0)
							{
								assy.Remark1 = "";
								assy.Remark2 = "";
								assy.Remark3 = "HIPOT";
								try
								{
									// Kiểm tra xem đã bắn chưa?? Nếu bắn rồi thì thông báo và không lưu

									var dgg = new DataTable();
									dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");
									if (dgg.Rows.Count > 0)
									{
										MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
										txtQrCode.Clear();
										txtQrCode.Focus();
										return;
									}
									else
									{
										AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
										// Update List View
										ok.Visible = true;
										Application.DoEvents();
										System.Threading.Thread.Sleep(300);
										ok.Visible = false;
										ResetAll();										
									}
								}
								catch (Exception ex)
								{
									MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
									throw;
								}
							}
							else
							{
								MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								txtQrCode.Text = "";
								txtQrCode.Focus();
								return;
							}
						}
					}
					if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "AMP")
					{
						// Kiểm tra xem đã qua hết các công đoạn chưa???
						var dg = new DataTable();
						var dg2 = new DataTable();
						int fct = 0;
						//fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "AMP");
						fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "AMP");
						dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
						dg2 = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");

						if (dg.Rows.Count < 1)
						{
							MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
							NG.Visible = true;
							Application.DoEvents();
							System.Threading.Thread.Sleep(300);
							NG.Visible = false;
							txtQrCode.Text = "";
							txtQrCode.Focus();
							return;
						}
						else
						{
							// Kiểm tra nếu là model EC thì phải thêm công đoạn check FCT
							if (cbModel.Text.Substring(0, 2) == "EC")
							{
								if (fct < 1)
								{
									MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn check AMP ");
									NG.Visible = true;
									Application.DoEvents();
									System.Threading.Thread.Sleep(300);
									NG.Visible = false;
									txtQrCode.Text = "";
									txtQrCode.Focus();
									return;
								}
								else
								{
									assy.Remark2 = "";
									assy.Remark1 = "";
									assy.Remark3 = "OUTPUT";
									try
									{
										// Kiểm tra xem đã bắn chưa??
										var dgg = new DataTable();
										dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
										if (dgg.Rows.Count > 0)
										{
											MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
											txtQrCode.Clear();
											txtQrCode.Focus();
											return;
										}
										else
										{
											AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
											// Update List View
											ok.Visible = true;
											Application.DoEvents();
											System.Threading.Thread.Sleep(300);
											ok.Visible = false;
											ResetAll();
											AutoResizeListViewColumns(listView1);
										}
									}
									catch (Exception ex)
									{
										MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
										throw;
									}
								}
							}
							// Không phải là model EC thì bỏ qua check FCT
							else
							{
								if (dg2.Rows.Count < 1)
								{
									MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn HIPOT ");
									NG.Visible = true;
									Application.DoEvents();
									System.Threading.Thread.Sleep(300);
									NG.Visible = false;
									txtQrCode.Text = "";
									txtQrCode.Focus();
									return;
								}
								else
								{
									assy.Remark2 = "";
									assy.Remark1 = "";
									assy.Remark3 = "OUTPUT";
									try
									{
										// Kiểm tra xem đã bắn chưa??
										var dgg = new DataTable();
										dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
										if (dgg.Rows.Count > 0)
										{
											MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
											txtQrCode.Clear();
											txtQrCode.Focus();
											return;
										}
										else
										{
											AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
											// Update List View
											ok.Visible = true;
											Application.DoEvents();
											System.Threading.Thread.Sleep(300);
											ok.Visible = false;
											ResetAll();											
										}
									}
									catch (Exception ex)
									{
										MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
										throw;
									}
								}

							}
						}
					}
					if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "OTHER")
					{
						// Kiểm tra xem đã qua hết các công đoạn chưa???
						var dg = new DataTable();
						dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");

						if (dg.Rows.Count < 1)
						{
							MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
							NG.Visible = true;
							Application.DoEvents();
							System.Threading.Thread.Sleep(300);
							NG.Visible = false;
							txtQrCode.Text = "";
							txtQrCode.Focus();
							return;
						}
						else
						{
							assy.Remark2 = "";
							assy.Remark1 = "";
							assy.Remark3 = "OUTPUT";
							try
							{
								// Kiểm tra xem đã bắn chưa??
								var dgg = new DataTable();
								dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
								if (dgg.Rows.Count > 0)
								{
									MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
									txtQrCode.Clear();
									txtQrCode.Focus();
									return;
								}
								else
								{
									AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
									// Update List View
									ok.Visible = true;
									Application.DoEvents();
									System.Threading.Thread.Sleep(300);
									ok.Visible = false;
									ResetAll();
									AutoResizeListViewColumns(listView1);
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
								throw;
							}
						}
					}
				}
			}
		}

		private void txtQrCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				if (txtQrCode.Text.Equals(""))
				{
					MessageBox.Show("QR Code Không được để trống");
					txtQrCode.Focus();
					return;
				}
				else
				{
					// Kiểm tra xem QR code này có trong csdl không???
					var chkmodel = new DataTable();
					chkmodel = General_Serial_Services.GeneralSerial_CheckSerial(txtQrCode.Text, cbModel.Text);
					if (chkmodel.Rows.Count < 1)
					{
						MessageBox.Show("QR Code Không có trong CSDL ");
						txtQrCode.SelectAll();
						txtQrCode.Focus();
						return;
					}
					else
					{
						// Khi có trong csdl rồi thì kiểm tra tiếp xem Market có giống nhau không??
						//string market = chkmodel.Rows[0].Field<string>("PCBCode").Substring(chkmodel.Rows[0].Field<string>("PCBCode").Length - 3, 3);
						string str = chkmodel.Rows[0].Field<string>("PCBCode");
						string market = str.Substring(str.LastIndexOf("-") + 1);

						//MessageBox.Show(market);
						if (cbMarket.Text != market)
						{
							MessageBox.Show("Không giống Market với hệ thống !!!");
							NG.Visible = true;
							Application.DoEvents();
							System.Threading.Thread.Sleep(300);
							NG.Visible = false;
							return;
						}
						else if (cbTypePcb.Text == "MAIN") // Kiểm tra xem có đúng PCB type Không MAIN--> U7600M// PSU U7600P
						{
							string mt = txtQrCode.Text.Substring(0, 6);
							if (!mt.Contains("M"))
							{
								MessageBox.Show("Serial code không dành cho PCB Type MAIN !!!");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								return;
							}
							else
							{
								btSave.Enabled = true;
								btSave.Focus();

								SendKeys.Send("{Enter}");
							}
						}
						else if (cbTypePcb.Text == "PSU")
						{
							string mt = txtQrCode.Text.Substring(0, 6);
							if (!mt.Contains("P"))
							{
								MessageBox.Show("Serial code không dành cho PCB Type PSU !!!");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								return;
							}
							else
							{
								btSave.Enabled = true;
								btSave.Focus();
								SendKeys.Send("{Enter}");
							}
						}
						else if (cbTypePcb.Text == "AMP")
						{
							string mt = txtQrCode.Text.Substring(0, 6);
							if (!mt.Contains("A"))
							{
								MessageBox.Show("Serial code không dành cho PCB Type AMP !!!");
								NG.Visible = true;
								Application.DoEvents();
								System.Threading.Thread.Sleep(300);
								NG.Visible = false;
								return;
							}
							else

							{
								btSave.Enabled = true;
								btSave.Focus();
								SendKeys.Send("{Enter}");
							}
						}
						else
						{
							btSave.Enabled = true;
							btSave.Focus();
							SendKeys.Send("{Enter}");
						}
					}
				}

				//if (cbProcess.Text == "APP")
				//{
				//    //assy.Remark3 = "APP";
				//    Rem2 = "APP";
				//    var dg = new DataTable();
				//    dg = EastechOutputHistory_Services.EastechHistory_smt_CheckQRCodeRemark(txtQrCode.Text, "INSERT");
				//    if (dg.Rows.Count > 0)
				//    {

				//        Rem1 = "INSERT PASSED";
				//    }
				//    else
				//    {
				//        Rem1 = "FAIL INSERT";
				//    }
				//}
				//else if (cbProcess.Text == "HIPOT")
				//{
				//    var dg = new DataTable();
				//    dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
				//    if (dg.Rows.Count > 0)
				//    {
				//       Rem2 = "HIPOT";
				//    }
				//    else
				//    {
				//        MessageBox.Show("QR Code: " + txtQrCode.Text+   "  Chưa qua công đoạn APP ");
				//        txtQrCode.Text = "";
				//        txtQrCode.Focus();                        
				//    }
				//}
				//else if (cbProcess.Text == "OUTPUT")
				//{
				//    // Kiểm tra xem đã qua hết các công đoạn chưa???
				//    var dg = new DataTable();
				//    var di = new DataTable();
				//    dg= AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
				//    di= AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");

				//}
			}
		}

		private void btDownload_Click(object sender, EventArgs e)
		{
			frmFAssyDownload ft = new frmFAssyDownload();
			ft.Show();
		}

		private void txtWireless_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				if (txtWireless.Text.Trim().Length == 15)
				{
					MessageBox.Show("Wireless phải khác 15 ký tự (Wireless không chứ 15 ký tự) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				txtQrCode.Focus();
			}
		}

		private void chkWireless_CheckedChanged(object sender, EventArgs e)
		{
			if (chkWireless.Checked == true)
			{
				txtWireless.Enabled = true;
			}
			else
			{
				txtWireless.Enabled = false;
			}
		}
		private void AutoResizeListViewColumns(ListView listView)
		{
			// Loop through all columns and set their width to fit the content.
			foreach (ColumnHeader column in listView.Columns)
			{
				column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}

		//private void cbProcess_SelectedValueChanged(object sender, EventArgs e)
		//{
		//	if (chkWireless.Checked == true)
		//	{
		//		txtWireless.Focus();
		//	}
		//	else
		//	{
		//		txtQrCode.Focus();
		//	}
		//}
		//private void ResetAll()
		//      {
		//          int counts = 0;
		//          cbModel.Enabled = false;
		//          cbMarket.Enabled = false;
		//          cbTypePcb.Enabled = false;
		//          cbProcess.Enabled = false;
		//          var cdt = new DataTable();
		//          cdt = AssyOperatorProcess_Services.AssyOperatorProcessData_CoutByUser(lblChecker.Text, CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss"));
		//          lblSoLuong.Text = cdt.Rows.Count.ToString();
		//          counts = cdt.Rows.Count;
		//          listView1.View = View.Details;
		//          listView1.Items.Insert(0, (new ListViewItem(new string[] { counts.ToString(),txtLine.Text, cbModel.Text, cbMarket.Text, cbTypePcb.Text, txtQrCode.Text, CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss") })));
		//          //counts = counts + 1;
		//          listView1.GridLines = true;
		//          btSave.Enabled = false;
		//          txtQrCode.Text = "";
		//          if (chkWireless.Checked == true)
		//          {
		//              txtWireless.Enabled = true;
		//              txtWireless.Text = "";
		//              txtWireless.Focus();
		//          }
		//          else
		//          {
		//              txtWireless.Enabled = false;
		//              txtWireless.Text = "";
		//              txtQrCode.Focus();
		//          }
		//      }

		//      private void frmAssyETCheckProcess_SizeChanged(object sender, EventArgs e)
		//      {
		//          //try
		//          //{
		//          //    if (this.WindowState == FormWindowState.Minimized)
		//          //    {

		//          //    }
		//          //    else
		//          //    {
		//          //        float size1 = this.Size.Width / firstWidth;
		//          //        float size2 = this.Size.Height / firstHeight;
		//          //        SizeF scale = new SizeF(size1, size2);
		//          //        firstWidth = this.Size.Width;
		//          //        firstHeight = this.Size.Height;
		//          //        //MessageBox.Show("kich thuong" + firstWidth);
		//          //        //MessageBox.Show("kich thuong" + firstHeight);

		//          //        foreach (Control control in this.Controls)
		//          //        {
		//          //            control.Font = new Font(control.Font.FontFamily, control.Font.Size * ((size1 + size2) / 2));
		//          //            control.Scale(scale);
		//          //        }
		//          //    }
		//          //}
		//          //catch (Exception)
		//          //{
		//          //    throw;
		//          //}
		//      }

		//      private void chkWireless_CheckedChanged(object sender, EventArgs e)
		//      {
		//          if (chkWireless.Checked == true)
		//          {
		//              txtWireless.Enabled = true;
		//          }
		//          else
		//          {
		//              txtWireless.Enabled = false;
		//          }
		//      }

		//      private void txtWireless_KeyDown(object sender, KeyEventArgs e)
		//      {
		//          if (e.KeyValue == 13)
		//          {
		//              if (txtWireless.Text.Trim().Length ==15)
		//              {
		//                  MessageBox.Show("Wireless phải khác 15 ký tự ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//                  return;
		//              }
		//              txtQrCode.Focus();
		//          }
		//      }

		//      private void btThoat_Click(object sender, EventArgs e)
		//      {
		//          //var dt = new DataTable();
		//          //dt = SessionLogin_Services.tbl_SessionLogin_Select(Program.username);
		//          //if (dt.Rows.Count > 0)
		//          //{
		//          //    SessionLogin_Services.tbl_SessionLogin_Delete(Program.username);
		//          //}
		//          //this.Hide();
		//          //Flogin fm = new Flogin();
		//          //fm.Show();
		//      }

		//      private void frmAssyETCheckProcess_FormClosing(object sender, FormClosingEventArgs e)
		//      {
		//          // Kiểm tra xem có session của user này không? Nếu có thì xóa
		//          //var dt = new DataTable();
		//          //dt = SessionLogin_Services.tbl_SessionLogin_Select(Program.username);
		//          //if (dt.Rows.Count > 0)
		//          //{
		//          //    SessionLogin_Services.tbl_SessionLogin_Delete(Program.username);
		//          //}
		//          //Application.Exit();
		//      }

		//      private void txtQrCode_KeyDown(object sender, KeyEventArgs e)
		//      {
		//          if (e.KeyValue == 13)
		//          {
		//              if (txtQrCode.Text.Equals(""))
		//              {
		//                  MessageBox.Show("QR Code Không được để trống");
		//                  txtQrCode.Focus();
		//                  return;
		//              }
		//              else
		//              {
		//                  // Kiểm tra xem QR code này có trong csdl không???
		//                  var chkmodel = new DataTable();
		//                  chkmodel = General_Serial_Services.GeneralSerial_CheckSerial(txtQrCode.Text, cbModel.Text);
		//                  if (chkmodel.Rows.Count < 1)
		//                  {
		//                      MessageBox.Show("QR Code Không có trong CSDL ");
		//                      txtQrCode.SelectAll();
		//                      txtQrCode.Focus();
		//                      return;
		//                  }
		//                  else
		//                  {
		//                      // Khi có trong csdl rồi thì kiểm tra tiếp xem Market có giống nhau không??
		//                      string market = chkmodel.Rows[0].Field<string>("PCBCode").Substring(chkmodel.Rows[0].Field<string>("PCBCode").Length - 3, 3);
		//                      //MessageBox.Show(market);
		//                      if (cbMarket.Text != market)
		//                      {
		//                          MessageBox.Show("Không giống Market với hệ thống !!!");
		//                          NG.Visible = true;
		//                          Application.DoEvents();
		//                          System.Threading.Thread.Sleep(300);
		//                          NG.Visible = false;
		//                          return;
		//                      }
		//                      else if (cbTypePcb.Text == "MAIN") // Kiểm tra xem có đúng PCB type Không MAIN--> U7600M// PSU U7600P
		//                      {
		//                          string mt = txtQrCode.Text.Substring(0, 6);
		//                          if (!mt.Contains("M"))
		//                          {
		//                              MessageBox.Show("Serial code không dành cho PCB Type MAIN !!!");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              return;
		//                          }
		//                          else
		//                          {
		//                              btSave.Enabled = true;
		//                              btSave.Focus();

		//                              SendKeys.Send("{Enter}");
		//                          }
		//                      }
		//                      else if (cbTypePcb.Text == "PSU")
		//                      {
		//                          string mt = txtQrCode.Text.Substring(0, 6);
		//                          if (!mt.Contains("P"))
		//                          {
		//                              MessageBox.Show("Serial code không dành cho PCB Type PSU !!!");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              return;
		//                          }
		//                          else
		//                          {
		//                              btSave.Enabled = true;
		//                              btSave.Focus();
		//                              SendKeys.Send("{Enter}");
		//                          }
		//                      }
		//                      else if (cbTypePcb.Text == "AMP")
		//                      {
		//                          string mt = txtQrCode.Text.Substring(0, 6);
		//                          if (!mt.Contains("A"))
		//                          {
		//                              MessageBox.Show("Serial code không dành cho PCB Type AMP !!!");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              return;
		//                          }
		//                          else
		//                          {
		//                              btSave.Enabled = true;
		//                              btSave.Focus();
		//                              SendKeys.Send("{Enter}");
		//                          }
		//                      }
		//                      else
		//                      {
		//                          btSave.Enabled = true;
		//                          btSave.Focus();
		//                          SendKeys.Send("{Enter}");
		//                      }
		//                  }
		//              }

		//              //if (cbProcess.Text == "APP")
		//              //{
		//              //    //assy.Remark3 = "APP";
		//              //    Rem2 = "APP";
		//              //    var dg = new DataTable();
		//              //    dg = EastechOutputHistory_Services.EastechHistory_smt_CheckQRCodeRemark(txtQrCode.Text, "INSERT");
		//              //    if (dg.Rows.Count > 0)
		//              //    {

		//              //        Rem1 = "INSERT PASSED";
		//              //    }
		//              //    else
		//              //    {
		//              //        Rem1 = "FAIL INSERT";
		//              //    }
		//              //}
		//              //else if (cbProcess.Text == "HIPOT")
		//              //{
		//              //    var dg = new DataTable();
		//              //    dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
		//              //    if (dg.Rows.Count > 0)
		//              //    {
		//              //       Rem2 = "HIPOT";
		//              //    }
		//              //    else
		//              //    {
		//              //        MessageBox.Show("QR Code: " + txtQrCode.Text+   "  Chưa qua công đoạn APP ");
		//              //        txtQrCode.Text = "";
		//              //        txtQrCode.Focus();                        
		//              //    }
		//              //}
		//              //else if (cbProcess.Text == "OUTPUT")
		//              //{
		//              //    // Kiểm tra xem đã qua hết các công đoạn chưa???
		//              //    var dg = new DataTable();
		//              //    var di = new DataTable();
		//              //    dg= AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
		//              //    di= AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");

		//              //}
		//          }
		//      }

		//      private void btSave_Click(object sender, EventArgs e)
		//      {
		//          if (chkWireless.Checked == true)
		//          {
		//              if (txtWireless.Text.Trim().Equals("") || txtWireless.Text.Trim().Length < 20)
		//              {
		//                  MessageBox.Show("Nhập dữ liệu đúng vào Wireless ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//                  txtWireless.SelectAll();
		//                  txtWireless.Focus();
		//                  NG.Visible = true;
		//                  Application.DoEvents();
		//                  System.Threading.Thread.Sleep(300);
		//                  NG.Visible = false;
		//                  return;
		//              }
		//          }
		//          if (cbMarket.Text.Equals(""))
		//          {
		//              MessageBox.Show("Nhập dữ liệu đúng vào Market ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//              cbMarket.Focus();
		//              NG.Visible = true;
		//              Application.DoEvents();
		//              System.Threading.Thread.Sleep(300);
		//              NG.Visible = false;
		//              return;
		//          }
		//          else
		//          {
		//              if (txtQrCode.Text.Equals(""))
		//              {
		//                  MessageBox.Show("QR Code Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//                  txtQrCode.Focus();
		//                  NG.Visible = true;
		//                  Application.DoEvents();
		//                  System.Threading.Thread.Sleep(300);
		//                  NG.Visible = false;
		//                  return;
		//              }
		//              else
		//              {
		//                  var assy = new AssyOperatorProcess_Info();
		//                  assy.Model = cbModel.Text;
		//                  assy.Market = cbMarket.Text;
		//                  assy.TypePcb = cbTypePcb.Text;
		//                  assy.Process = cbProcess.Text;
		//                  assy.QrCode = txtQrCode.Text;
		//                  assy.Checker = lblChecker.Text;
		//                  if (chkWireless.Checked == true)
		//                  {
		//                      assy.Wireless = txtWireless.Text.Trim();
		//                  }
		//                  else
		//                  {
		//                      assy.Wireless = "";
		//                  }
		//                  assy.DateT = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

		//                  // Kiểm tra xem nó đã qua INSERT Hay Chưa??
		//                  if (cbProcess.Text == "APP")
		//                  {
		//                      //assy.Remark3 = "APP";
		//                      assy.Remark2 = "APP";
		//                      var dg = new DataTable();
		//                      dg = EastechOutputHistory_Services.EastechHistory_smt_CheckQRCodeRemark(txtQrCode.Text, "INSERT");
		//                      if (dg.Rows.Count > 0)
		//                      {

		//                          assy.Remark1 = "INSERT PASSED";
		//                      }
		//                      else
		//                      {
		//                          assy.Remark1 = "FAIL INSERT";
		//                      }
		//                      assy.Remark3 = "";
		//                      // Kiểm tra xem đã làm chưa? chưa làm thì lưu làm rồi thì báo là đã làm rồi
		//                      var dgg = new DataTable();
		//                      dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
		//                      try
		//                      {
		//                          if (dgg.Rows.Count > 0)
		//                          {
		//                              MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                              txtQrCode.Clear();
		//                              txtQrCode.Focus();
		//                              return;
		//                              //DialogResult dialogResult = MessageBox.Show("Bạn có muốn ghi đè lên:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo", MessageBoxButtons.YesNo);
		//                              //if (dialogResult == DialogResult.Yes)
		//                              //{
		//                              //    AssyOperatorProcess_Services.AssyOperatorProcess_Update(assy);  
		//                              //    ok.Visible = true;
		//                              //    Application.DoEvents();
		//                              //    System.Threading.Thread.Sleep(300);
		//                              //    ok.Visible = false;
		//                              //    // Update List View
		//                              //    ResetAll();
		//                              //}
		//                              //else if (dialogResult == DialogResult.No)
		//                              //{
		//                              //    txtQrCode.Clear();
		//                              //    txtQrCode.Focus();
		//                              //    return;
		//                              //}                             

		//                          }
		//                          else
		//                          {
		//                              AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                              ok.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              ok.Visible = false;
		//                              // Update List View
		//                              ResetAll();
		//                          }
		//                      }
		//                      catch (Exception ex)
		//                      {
		//                          MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                          throw;
		//                      }
		//                  }
		//                  if (cbProcess.Text == "HIPOT" && cbTypePcb.Text == "PSU")
		//                  {
		//                      var dg = new DataTable();
		//                      dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
		//                      if (dg.Rows.Count > 0)
		//                      {
		//                          assy.Remark1 = "";
		//                          assy.Remark2 = "";
		//                          assy.Remark3 = "HIPOT";
		//                          try
		//                          {
		//                              // Kiểm tra xem đã bắn chưa?? Nếu bắn rồi thì thông báo và không lưu

		//                              var dgg = new DataTable();
		//                              dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");
		//                              if (dgg.Rows.Count > 0)
		//                              {
		//                                  MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                  txtQrCode.Clear();
		//                                  txtQrCode.Focus();
		//                                  return;
		//                              }
		//                              else
		//                              {
		//                                  AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                  // Update List View
		//                                  ok.Visible = true;
		//                                  Application.DoEvents();
		//                                  System.Threading.Thread.Sleep(300);
		//                                  ok.Visible = false;
		//                                  ResetAll();
		//                              }
		//                          }
		//                          catch (Exception ex)
		//                          {
		//                              MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                              throw;
		//                          }
		//                      }
		//                      else
		//                      {
		//                          MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
		//                          NG.Visible = true;
		//                          Application.DoEvents();
		//                          System.Threading.Thread.Sleep(300);
		//                          NG.Visible = false;
		//                          txtQrCode.Text = "";
		//                          txtQrCode.Focus();
		//                          return;
		//                      }

		//                  }
		//                  if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "PSU")
		//                  {
		//                      // Kiểm tra xem đã qua hết các công đoạn chưa???
		//                      var dg = new DataTable();
		//                      var di = new DataTable();
		//                      var ditt = new DataTable();
		//                      int fct = 0;
		//                      fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "PSU");
		//                      dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
		//                      ditt = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");
		//                      // Bỏ qua công đoạn với thị trường EC1 //2021-01-17


		//                      if (cbModel.Text.Substring(0, 2) == "EC")
		//                      {
		//                          // Kiểm tra xem đã qua APP chưa??
		//                          if (dg.Rows.Count < 0)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          // Yêu cầu thêm công đoạn check HiPOT //2022-10-28  
		//                          else if (ditt.Rows.Count < 0)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn HIPOT ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          // Kiểm tra xem đã được check ở công đoạn FCT chưa?
		//                          else if (fct < 1)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn FCT ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }

		//                          //----------------------------------------
		//                          else
		//                          {
		//                              assy.Remark2 = "";
		//                              assy.Remark1 = "";
		//                              assy.Remark3 = "OUTPUT";
		//                              try
		//                              {
		//                                  // Kiểm tra xem đã bắn chưa??
		//                                  var dgg = new DataTable();
		//                                  dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
		//                                  if (dgg.Rows.Count > 0)
		//                                  {
		//                                      MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                      txtQrCode.Clear();
		//                                      txtQrCode.Focus();
		//                                      return;
		//                                  }
		//                                  else
		//                                  {
		//                                      AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                      // Update List View
		//                                      ok.Visible = true;
		//                                      Application.DoEvents();
		//                                      System.Threading.Thread.Sleep(300);
		//                                      ok.Visible = false;
		//                                      ResetAll();
		//                                  }
		//                              }
		//                              catch (Exception ex)
		//                              {
		//                                  MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                                  throw;
		//                              }
		//                          }

		//                      }
		//                      //---------------------------------------------------------------
		//                      else
		//                      {

		//                          di = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "HIPOT");
		//                          if (dg.Rows.Count > 0 && di.Rows.Count < 1)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn HIPOT ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();

		//                              return;
		//                          }
		//                          else if (dg.Rows.Count < 1 && dg.Rows.Count > 0)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          else if (dg.Rows.Count < 1 && dg.Rows.Count < 1)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP và HIPOT ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          else if (fct < 0)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn check FCT ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          else
		//                          {
		//                              assy.Remark2 = "";
		//                              assy.Remark1 = "";
		//                              assy.Remark3 = "OUTPUT";
		//                              try
		//                              {
		//                                  // Kiểm tra xem đã bắn chưa??
		//                                  var dgg = new DataTable();
		//                                  dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
		//                                  if (dgg.Rows.Count > 0)
		//                                  {
		//                                      MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                      txtQrCode.Clear();
		//                                      txtQrCode.Focus();
		//                                      return;
		//                                  }
		//                                  else
		//                                  {
		//                                      AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                      // Update List View
		//                                      ok.Visible = true;
		//                                      Application.DoEvents();
		//                                      System.Threading.Thread.Sleep(300);
		//                                      ok.Visible = false;
		//                                      ResetAll();
		//                                  }
		//                              }
		//                              catch (Exception ex)
		//                              {
		//                                  MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                                  throw;
		//                              }
		//                          }
		//                      }
		//                  }
		//                  if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "MAIN")
		//                  {
		//                      // Kiểm tra xem đã qua hết các công đoạn chưa???
		//                      if (cbModel.Text.Substring(0, 2) == "EC")
		//                      {
		//                          var dg = new DataTable();
		//                          dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
		//                          int fct = 0;
		//                          fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "MAIN");
		//                          if (dg.Rows.Count < 1)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          else if (fct < 1)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn FCT ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          else
		//                          {
		//                              assy.Remark2 = "";
		//                              assy.Remark1 = "";
		//                              assy.Remark3 = "OUTPUT";

		//                              // Kiểm tra xem thị trường ở FCT với ở APP có giống nhau không
		//                              // 1) Lấy code market từ công đoạn check FCT ở dạng 00, 01,....
		//                              //    Sau đó so sánh để lấy ra ký hiệu Market của nó ở dạng E12,CN4,... theo QRcode
		//                              // 2) Lấy ký hiệu market từ công đoạn check APP ở dạng E12,CN4,...
		//                              // 3) Lấy 1 và 2 so sánh với nhau --> Nếu khớp thì save không thì báo không trùng nhau.
		//                              // [sp_A_EastechCheckFCT_MAIN]
		//                              bool checkFlag = false;
		//                              var checkdt = AssyOperatorProcess_Services.A_EastechCheckFCT_MAIN(txtQrCode.Text.Trim());
		//                              if (checkdt.Rows.Count > 0)
		//                              {
		//                                  foreach (DataRow row in checkdt.Rows)
		//                                  {
		//                                      if (row["checkFlag"].ToString() == "True")
		//                                      {
		//                                          checkFlag = true;
		//                                          break;
		//                                      }
		//                                  }
		//                              }
		//                              else
		//                              {
		//                                  MessageBox.Show("Không có dữ liệu trong CSDL !!!");
		//                                  return;
		//                              }
		//                              if (checkFlag == true)
		//                              {
		//                                  try
		//                                  {
		//                                      // Kiểm tra xem đã bắn chưa??
		//                                      var dgg = new DataTable();
		//                                      dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
		//                                      if (dgg.Rows.Count > 0)
		//                                      {
		//                                          MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                          txtQrCode.Clear();
		//                                          txtQrCode.Focus();
		//                                          return;
		//                                      }
		//                                      else
		//                                      {
		//                                          AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                          // Update List View
		//                                          ok.Visible = true;
		//                                          Application.DoEvents();
		//                                          System.Threading.Thread.Sleep(300);
		//                                          ok.Visible = false;
		//                                          ResetAll();
		//                                      }
		//                                  }
		//                                  catch (Exception ex)
		//                                  {
		//                                      MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                                      throw;
		//                                  }
		//                              }
		//                              else
		//                              {
		//                                  MessageBox.Show("Sai thị trường cần kiểm tra lại, Hãy liên lạc với người quản lý  !!!");
		//                                  NG.Visible = true;
		//                                  Application.DoEvents();
		//                                  System.Threading.Thread.Sleep(300);
		//                                  NG.Visible = false;
		//                                  txtQrCode.Text = "";
		//                                  txtQrCode.Focus();
		//                                  return;
		//                              }
		//                          }
		//                      }
		//                      else
		//                      {
		//                          // Kiểm tra xem đã qua hết các công đoạn chưa???
		//                          var dg = new DataTable();
		//                          dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");
		//                          int fct = 0;
		//                          fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "MAIN");
		//                          if (dg.Rows.Count < 1)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          else if (fct < 1)
		//                          {
		//                              MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn FCT ");
		//                              NG.Visible = true;
		//                              Application.DoEvents();
		//                              System.Threading.Thread.Sleep(300);
		//                              NG.Visible = false;
		//                              txtQrCode.Text = "";
		//                              txtQrCode.Focus();
		//                              return;
		//                          }
		//                          else
		//                          {
		//                              assy.Remark2 = "";
		//                              assy.Remark1 = "";
		//                              assy.Remark3 = "OUTPUT";
		//                              try
		//                              {
		//                                  // Kiểm tra xem đã bắn chưa??
		//                                  var dgg = new DataTable();
		//                                  dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
		//                                  if (dgg.Rows.Count > 0)
		//                                  {
		//                                      MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                      txtQrCode.Clear();
		//                                      txtQrCode.Focus();
		//                                      return;
		//                                  }
		//                                  else
		//                                  {
		//                                      AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                      // Update List View
		//                                      ok.Visible = true;
		//                                      Application.DoEvents();
		//                                      System.Threading.Thread.Sleep(300);
		//                                      ok.Visible = false;
		//                                      ResetAll();
		//                                  }
		//                              }
		//                              catch (Exception ex)
		//                              {
		//                                  MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                                  throw;
		//                              }
		//                          }
		//                      }

		//                  }
		//                  if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "AMP")
		//                  {
		//                      // Kiểm tra xem đã qua hết các công đoạn chưa???
		//                      var dg = new DataTable();
		//                      int fct = 0;
		//                      //fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "AMP");
		//                      fct = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckFCT(txtQrCode.Text, "AMP");
		//                      dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");

		//                      if (dg.Rows.Count < 1)
		//                      {
		//                          MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
		//                          NG.Visible = true;
		//                          Application.DoEvents();
		//                          System.Threading.Thread.Sleep(300);
		//                          NG.Visible = false;
		//                          txtQrCode.Text = "";
		//                          txtQrCode.Focus();
		//                          return;
		//                      }
		//                      else
		//                      {
		//                          // Kiểm tra nếu là model EC thì phải thêm công đoạn check FCT
		//                          if (cbModel.Text.Substring(0, 2) == "EC")
		//                          {
		//                              if (fct < 1)
		//                              {
		//                                  MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn check AMP ");
		//                                  NG.Visible = true;
		//                                  Application.DoEvents();
		//                                  System.Threading.Thread.Sleep(300);
		//                                  NG.Visible = false;
		//                                  txtQrCode.Text = "";
		//                                  txtQrCode.Focus();
		//                                  return;
		//                              }
		//                              else
		//                              {
		//                                  assy.Remark2 = "";
		//                                  assy.Remark1 = "";
		//                                  assy.Remark3 = "OUTPUT";
		//                                  try
		//                                  {
		//                                      // Kiểm tra xem đã bắn chưa??
		//                                      var dgg = new DataTable();
		//                                      dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
		//                                      if (dgg.Rows.Count > 0)
		//                                      {
		//                                          MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                          txtQrCode.Clear();
		//                                          txtQrCode.Focus();
		//                                          return;
		//                                      }
		//                                      else
		//                                      {
		//                                          AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                          // Update List View
		//                                          ok.Visible = true;
		//                                          Application.DoEvents();
		//                                          System.Threading.Thread.Sleep(300);
		//                                          ok.Visible = false;
		//                                          ResetAll();
		//                                      }
		//                                  }
		//                                  catch (Exception ex)
		//                                  {
		//                                      MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                                      throw;
		//                                  }
		//                              }
		//                          }
		//                          // Không phải là model EC thì bỏ qua check FCT
		//                          else
		//                          {
		//                              assy.Remark2 = "";
		//                              assy.Remark1 = "";
		//                              assy.Remark3 = "OUTPUT";
		//                              try
		//                              {
		//                                  // Kiểm tra xem đã bắn chưa??
		//                                  var dgg = new DataTable();
		//                                  dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
		//                                  if (dgg.Rows.Count > 0)
		//                                  {
		//                                      MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                      txtQrCode.Clear();
		//                                      txtQrCode.Focus();
		//                                      return;
		//                                  }
		//                                  else
		//                                  {
		//                                      AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                      // Update List View
		//                                      ok.Visible = true;
		//                                      Application.DoEvents();
		//                                      System.Threading.Thread.Sleep(300);
		//                                      ok.Visible = false;
		//                                      ResetAll();
		//                                  }
		//                              }
		//                              catch (Exception ex)
		//                              {
		//                                  MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                                  throw;
		//                              }
		//                          }
		//                      }
		//                  }
		//                  if (cbProcess.Text == "OUTPUT" && cbTypePcb.Text == "OTHER")
		//                  {
		//                      // Kiểm tra xem đã qua hết các công đoạn chưa???
		//                      var dg = new DataTable();
		//                      dg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "APP");

		//                      if (dg.Rows.Count < 1)
		//                      {
		//                          MessageBox.Show("QR Code: " + txtQrCode.Text + "  Chưa qua công đoạn APP ");
		//                          NG.Visible = true;
		//                          Application.DoEvents();
		//                          System.Threading.Thread.Sleep(300);
		//                          NG.Visible = false;
		//                          txtQrCode.Text = "";
		//                          txtQrCode.Focus();
		//                          return;
		//                      }
		//                      else
		//                      {
		//                          assy.Remark2 = "";
		//                          assy.Remark1 = "";
		//                          assy.Remark3 = "OUTPUT";
		//                          try
		//                          {
		//                              // Kiểm tra xem đã bắn chưa??
		//                              var dgg = new DataTable();
		//                              dgg = AssyOperatorProcess_Services.AssyOperatorProcessData_CheckProcess(txtQrCode.Text, "OUTPUT");
		//                              if (dgg.Rows.Count > 0)
		//                              {
		//                                  MessageBox.Show("Đã có dữ liệu trên hệ thống:" + dgg.Rows[0].Field<string>("QrCode") + " Thời gian: " + dgg.Rows[0].Field<DateTime>("DateT").ToString() + "   không? ", "Thông Báo");
		//                                  txtQrCode.Clear();
		//                                  txtQrCode.Focus();
		//                                  return;
		//                              }
		//                              else
		//                              {
		//                                  AssyOperatorProcess_Services.AssyOperatorProcess_Insert(assy);
		//                                  // Update List View
		//                                  ok.Visible = true;
		//                                  Application.DoEvents();
		//                                  System.Threading.Thread.Sleep(300);
		//                                  ok.Visible = false;
		//                                  ResetAll();
		//                              }
		//                          }
		//                          catch (Exception ex)
		//                          {
		//                              MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
		//                              throw;
		//                          }
		//                      }
		//                  }
		//              }
		//          }
		//      }



		//      private void btDownload_Click(object sender, EventArgs e)
		//      {
		//          frmFAssyDownload ft = new frmFAssyDownload();
		//          ft.Show();
		//      }
	}
}
