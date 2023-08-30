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
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Smt.Input;
using UnidenDTO;

namespace SMTPRORAM.Smt.Input
{
    public partial class frmF_Combine_Program : Form
    {
        public frmF_Combine_Program()
        {
            InitializeComponent();
        }
        public class NewList
        {
            long Id { get; set; }
            string programpartlist { get; set; }
            string fdrno { get; set; }
            string partscode { get; set; }
            string checkedby { get; set; }
            DateTime checkedtime { get; set; }
            int Solanthaylinhkien { get; set; }
            long SoPCBCothedung { get; set; }
            string remark1 { get; set; }
            string remark2 { get; set; }
            string remark3 { get; set; }
            long counts { get; set; }
        }
        private void frmF_Combine_Program_Load(object sender, EventArgs e)
        {
            lwait.Visible = false;
			lprogram.Text = string.Empty;
			loldline.Text = string.Empty;
			lnewline.Text = string.Empty;
			lblProgram2.Text = string.Empty;

			cbNewLine.Text = "--Select--";
			cbOldLine.Text = "--Select--";

			txtProgram.Text = string.Empty;
			txtProgram2.Text = string.Empty;
			txtProgram.Focus();
			#region Old Code
			/*
			lprogram.Text = ""; lblProgram2.Text = "";
            DataTable dt = new DataTable();
            dt = Smt_Line_Services.Smt_GetAllLine();
            if (dt.Rows.Count > 0)
            {
                cbNewLine.DataSource = dt;
                cbNewLine.DisplayMember = "LineName";
                cbNewLine.ValueMember = "LineName";
            }
            else
            {
                MessageBox.Show("Không có Line nào trong CSDL");
                return;
            }
            */
			#endregion
		}

		private bool checkOldProgram()
		{
			//var checkProgram = SmtProgramHistoryDAL.Instance.checkProgramName(txtProgram.Text.Trim());
			var checkEtProgram = EASTECH_PROGRAMHISTORY_DAL.Instance.GetProgramLineName(txtProgram.Text.Trim());
			//if (checkProgram != null && checkEtProgram.Count > 0)
			//{

			//}
			if (checkEtProgram.Count > 0)
			{

			}
			else
			{
				//MessageBox.Show("Chưa có Chương trình này trong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);				
				return false;
			}
			return true;
		}
		private void lineSMTList()
		{
			var lstLineSMT = SmtLineDAL.Instance.getListSMTLine();

			if (lstLineSMT.Count > 0)
			{
				// Create a default item "--Select--"
				var defaultItem = new SMT_LINE { LineName = "--Select--" };
				// Add the default item and sort the rest of the items by LineName
				lstLineSMT.Insert(0, defaultItem);
				lstLineSMT = lstLineSMT.OrderBy(item => item.Id).ToList();

				cbNewLine.DataSource = lstLineSMT;
				cbNewLine.DisplayMember = "LineName";
				cbNewLine.ValueMember = "LineName";
			}
			else
			{
				MessageBox.Show("Không có Line nào trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

		}

		private void LoadOldLine()
		{
			var checkEtProgram = EASTECH_PROGRAMHISTORY_DAL.Instance.GetProgramLineName(txtProgram.Text.Trim());
			if (checkEtProgram.Count > 0)
			{
				// Create a default item "--Select--"
				var defaultItem = new ProgramLineName { LineName = "--Select--" };
				// Add the default item and sort the rest of the items by LineName
				checkEtProgram.Insert(0, defaultItem);
				checkEtProgram = checkEtProgram.OrderBy(item => item.LineName).ToList();

				cbOldLine.DataSource = checkEtProgram;
				cbOldLine.DisplayMember = "LineName";
				cbOldLine.ValueMember = "LineName";
			}
			else
			{
				MessageBox.Show("Không có Line nào trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}
		private void txtProgram_KeyDown(object sender, KeyEventArgs e)
        {
            // Phải kiểm tra xem dữ liệu đó có trong history của smt proram chưa???
            // Phải kiểm tra xem dữ liệu đó có trong history của eastech history chưa???            
            if (e.KeyCode == Keys.Enter)
            {
				if (checkOldProgram())
				{
					CommonDAL.Instance.SetStatusLabels(lprogram, "OK");
					LoadOldLine();
					cbOldLine.Focus();
				}
				else
				{
					CommonDAL.Instance.SetStatusLabels(lprogram, "NG");
					txtProgram.Focus();
					txtProgram.SelectAll();
				}
				#region Old Code
				/*
                txtProgram.Text = txtProgram.Text.Trim().ToUpper();
                var dt = new DataTable();
                var du = new DataTable();
                //PROGRAMHISTORYInfo cs = new PROGRAMHISTORYInfo();
                var cs = new PROGRAMInfo();
                cs.programpartlist = txtProgram.Text;
                //dt = PROGRAMHISTORYService.PROGRAMHISTORY_GetByID(cs);
                dt = PROGRAMService.PROGRAM_GetByID(cs);
                du = EastechHistory_Services.EastechHistory_CheckProgKey(txtProgram.Text);
                if ((dt.Rows.Count < 0 && du.Rows.Count > 0) || (dt.Rows.Count > 0 && du.Rows.Count < 0) || (dt.Rows.Count < 0 && du.Rows.Count < 0))
                {
                    MessageBox.Show("Chưa có Chương trình này trong dữ liệu P1 !!!");
                    lprogram.Text = "NG";
                    lprogram.ForeColor = System.Drawing.Color.Red;
                    txtProgram.Focus();
                    txtProgram.SelectAll();

                }
                else if (dt.Rows.Count > 0 && du.Rows.Count > 0)
                {
                    // Lấy thông tin Line của hệ thống đưa vào combo box
                    DataTable bu = new DataTable();
                    bu = EastechHistory_Services.EastechHistory_CheckProgKey(txtProgram.Text);
                    cbOldLine.DataSource = bu;
                    cbOldLine.DisplayMember = "remark1";
                    cbOldLine.ValueMember = "remark1";
                    lprogram.Text = "OK";
                    lprogram.ForeColor = System.Drawing.Color.Green;
                    SendKeys.Send("{TAB}");
                }
                */
				#endregion
			}
		}

		private bool checkNewProgram()
		{
			if (string.IsNullOrEmpty(txtProgram2.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lblProgram2, "NG");
				return false;
			}
			if (txtProgram2.Text.Equals(txtProgram.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lblProgram2, "NG");
				return false;
			}

			var checkPro = SmtProgramDAL.Instance.getByProgram(txtProgram2.Text);
			if (checkPro != null)
			{
				CommonDAL.Instance.SetStatusLabels(lblProgram2, "OK");
			}
			else
			{
				CommonDAL.Instance.SetStatusLabels(lblProgram2, "NG");
				return false;
			}

			return true;
		}

		private void txtProgram2_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem line này đã có trong Program list chưa?
            // Nếu chưa có thì không chuyển đư
            if (e.KeyCode == Keys.Enter)
            {
				if (checkNewProgram())
				{
					lineSMTList();
					cbNewLine.Focus();
				}
				else
				{
					txtProgram2.SelectAll();
					txtProgram2.Focus();
				}
				#region Old Code
				/*
				var dt = new DataTable();
                var cs = new PROGRAMInfo();
                cs.programpartlist = txtProgram2.Text;
                dt = PROGRAMService.PROGRAM_GetByID(cs);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Chưa có Chương trình này trong dữ liệu P1 !!!");
                    lblProgram2.Text = "NG";
                    lblProgram2.ForeColor = System.Drawing.Color.Red;
                    txtProgram2.Focus();
                    txtProgram2.SelectAll();
                }
                else
                {
                    lprogram.Text = "OK";
                    lprogram.ForeColor = System.Drawing.Color.Green;
                }
                */
				#endregion

			}
		}

		private bool IsOKData()
		{
			if (txtProgram.Text.Equals(""))
			{
				MessageBox.Show("Nhập tên chương trình muốn chuyển !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtProgram.Focus();
				return false;
			}
			if (txtProgram2.Text.Equals(""))
			{
				MessageBox.Show("Nhập chương trình mới !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtProgram2.Focus();
				return false;
			}
			if (cbNewLine.Text.Equals(""))
			{
				MessageBox.Show("Chọn line muốn combine tới !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbNewLine.Focus();
				return false;
			}
			if (txtProgram.Text == txtProgram2.Text)
			{
				MessageBox.Show("Chương trình cũ và chương trình mới  không được trùng nhau !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtProgram.Focus();
				return false;
			}
			if (cbNewLine.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn line cần chuyển !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbNewLine.Focus();
				return false;
			}
			if (cbNewLine.Text.Substring(0, 2) == "IN")
			{
				MessageBox.Show("Không thể chuyển sang line của INSERT !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbNewLine.Focus();
				return false;
			}
			if (cbOldLine.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn line cần chuyển !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbOldLine.Focus();
				return false;
			}
			if (cbOldLine.Text.Substring(0, 2) == "IN")
			{
				MessageBox.Show("Không chọn line của INSERT !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbOldLine.Focus();
				return false;
			}
			return true;
		}
		private void btChuyenLine_Click(object sender, EventArgs e)
        {
            lwait.Visible = true;
			if (IsOKData())
			{
				var lstETList = new List<EASTECH_PROGRAMHISTORY>();
				var getdt = new DataTable();
				// Lấy dữ liệu BOM của chương trình mới
				var lstNewBOM = SmtProgramDAL.Instance.getListByPro(txtProgram2.Text.Trim());
				var lstMeterial = EASTECH_PROGRAMHISTORY_DAL.Instance.checkMeterialByProgramAndLineName(txtProgram.Text.Trim(), cbOldLine.Text.Trim());

				if (lstNewBOM.Count > 0 && lstMeterial.Count > 0)
				{
					// Kiểm tra xem chương trình cũ có scan QR hay không?
					var checkScanQRorNot = EASTECH_PROGRAMHISTORY_DAL.Instance.checkLineScanQRorNotScanQRCode(txtProgram.Text.Trim(), cbOldLine.Text.Trim());
					var datetime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss");
					if (checkScanQRorNot == null) // Không dùng QR code
					{
						getdt = EASTECH_PROGRAMHISTORY_DAL.Instance.getListRecordNeedTransferToNewLine(1,
																										txtProgram2.Text.Trim(),
																										txtProgram.Text.Trim(),
																										cbOldLine.Text);
						if (getdt.Rows.Count > 0)
						{
							try
							{
								// dùng for vì phải lấy usge mới không giống useage của chương trình cũ
								foreach (var row in lstNewBOM)
								{
									foreach (DataRow nrow in getdt.Rows)
									{
										if (row.fdrno == nrow["fdrno"].ToString())
										{
											var newHistory = new EASTECH_PROGRAMHISTORY
											{
												Id = long.Parse(nrow["Id"].ToString()),
												programpartlist = txtProgram2.Text.Trim(),
												pkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + row.fdrno + "_" + nrow["partscode"].ToString(),
												psubkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + row.fdrno,
												fdrno = row.fdrno,
												partscode = nrow["partscode"].ToString(),
												ndesc = nrow["ndesc"].ToString(),
												usage = row.usage,  // Thay đổi số usage
												checkedby = nrow["checkedby"].ToString(),
												checkedtime = datetime,
												reqqty = int.Parse(nrow["reqqty"].ToString()),
												datecode = nrow["datecode"].ToString(),
												Solanthaylinhkien = int.Parse(nrow["Solanthaylinhkien"].ToString()),
												// Khi usage thay đổi thì số pcb có thể dùng cũng phải thay đổi
												SoPCBCothedung = (int)(int.Parse(nrow["reqqty"].ToString()) / row.usage),      //int.Parse(nrow["SoPCBCothedung"].ToString()), 
												remark1 = cbNewLine.Text,
												remark2 = Program.Dept,
												remark3 = "Combine from: " + txtProgram.Text + " Line: " + cbOldLine.Text + " To: " + txtProgram2.Text + "  Line: " + cbNewLine.Text,
												counts = 0
											};
											lstETList.Add(newHistory);
										}
									}
								}
								if (lstETList.Count > 0)
								{
									string message = "";
									// Khi chuyển những feeder giống nhau sang thì mặc định là 
									// + chương trình mới và chương trình cũ đều dùng chung 1 part hoặc part thay thế.
									message = EASTECH_PROGRAMHISTORY_DAL.Instance.InsertUpdateRange(lstETList);
									if (string.IsNullOrEmpty(message))
									{
										MessageBox.Show("Đã Combine thành công !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
										dataGridView1.DataSource = null;
										dataGridView1.DataSource = lstETList;
										dataGridView1.Refresh();
										txtProgram.Text = string.Empty;
										txtProgram2.Text = string.Empty;
										txtProgram.Focus();
										return;
									}
									else
									{
										MessageBox.Show("Đã có lỗi xảy ra dữ liệu đã được rollback: " + message, "Thông báo", MessageBoxButtons.OK,
											MessageBoxIcon.Information);
										return;
									}
								}
								else
								{
									MessageBox.Show("Không có dữ liệu nào được combine từ chương trình: " + txtProgram.Text + "\n"
												   + "Line: " + cbOldLine.Text + "\n"
												   + "sang chương trình mới: " + txtProgram2.Text + "\n"
												   + "Line: " + cbNewLine.Text);
									return;
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show("Đã có lỗi xảy ra trong quá trình lấy dữ liệu nonQR: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}
						else
						{
							MessageBox.Show("Không có dữ liệu để combine chương trình----------!!!  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					else // Chương trình có bắn QR code
					{
						getdt = EASTECH_PROGRAMHISTORY_DAL.Instance.getListRecordNeedTransferToNewLine(2,
																										txtProgram2.Text.Trim(),
																										txtProgram.Text.Trim(),
																										cbOldLine.Text);
						if (getdt.Rows.Count > 0)
						{
							try
							{
								foreach (var row in lstNewBOM)
								{
									foreach (DataRow nrow in getdt.Rows)
									{
										if (row.fdrno == nrow["fdrno"].ToString())
										{
											var newHistory = new EASTECH_PROGRAMHISTORY
											{
												Id = long.Parse(nrow["Id"].ToString()),
												programpartlist = txtProgram2.Text.Trim(),
												pkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + row.fdrno + "_" + nrow["partscode"].ToString(),
												psubkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + row.fdrno,
												fdrno = row.fdrno,
												partscode = nrow["partscode"].ToString(),
												ndesc = nrow["ndesc"].ToString(),
												usage = row.usage,  // Thay đổi số usage
												checkedby = nrow["checkedby"].ToString(),
												checkedtime = datetime,
												reqqty = (int.Parse(nrow["SoPCBCothedung"].ToString()) - int.Parse(nrow["counts"].ToString())) * int.Parse(nrow["usage"].ToString()),
												datecode = nrow["datecode"].ToString(),
												Solanthaylinhkien = int.Parse(nrow["Solanthaylinhkien"].ToString()),
												// Khi usage thay đổi thì số pcb có thể dùng cũng phải thay đổi
												SoPCBCothedung = (int)((int.Parse(nrow["SoPCBCothedung"].ToString()) - int.Parse(nrow["counts"].ToString())) * int.Parse(nrow["usage"].ToString()) / row.usage),
												remark1 = cbNewLine.Text,
												remark2 = Program.Dept,
												remark3 = "Combine from qr: " + txtProgram.Text + " Line: " + cbOldLine.Text + " To: " + txtProgram2.Text + "  Line: " + cbNewLine.Text,
												counts = 0
											};
											lstETList.Add(newHistory);
										}
									}
								}
								if (lstETList.Count > 0)
								{
									string message = "";
									message = EASTECH_PROGRAMHISTORY_DAL.Instance.InsertUpdateRangeQR(lstETList);
									if (string.IsNullOrEmpty(message))
									{
										MessageBox.Show("Đã combine thành công !!! ", "Thông báo", MessageBoxButtons.OK,
										   MessageBoxIcon.Information);
										dataGridView1.DataSource = null;
										dataGridView1.DataSource = lstETList;
										dataGridView1.Refresh();
										txtProgram.Text = string.Empty;
										txtProgram2.Text = string.Empty;
										txtProgram.Focus();
										return;
									}
									else
									{
										MessageBox.Show("Đã có lỗi xảy ra dữ liệu đã được rollback: " + message, "Thông báo", MessageBoxButtons.OK,
											MessageBoxIcon.Information);
										return;
									}
								}
								else
								{
									MessageBox.Show("Không có dữ liệu nào được combine QR từ chương trình: " + txtProgram.Text + "\n"
												   + "Line: " + cbOldLine.Text + "\n"
												   + "sang chương trình mới: " + txtProgram2.Text + "\n"
												   + "Line: " + cbNewLine.Text);
									return;
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show("Đã có lỗi xảy ra trong quá trình lấy dữ liệu QR: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Chương trình mới chưa được upload lên BOM", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtProgram2.SelectAll();
					txtProgram2.Focus();
					return;
				}

			}

			#region Old Code
			/*
			if (txtProgram.Text.Equals(""))
            {
                MessageBox.Show("Không dữ liệu Program nguồn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProgram.Focus();
            }
            if (cbOldLine.Text.Equals(""))
            {
                MessageBox.Show("Không dữ liệu Line Nguồn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbOldLine.Focus();
            }
            if (txtProgram2.Text.Equals(""))
            {
                MessageBox.Show("Không dữ liệu Program nguồn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProgram2.Focus();
            }
            if (cbNewLine.Text.Equals(""))
            {
                MessageBox.Show("Không dữ liệu Line Nguồn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNewLine.Focus();
            }
            if (txtProgram.Text == txtProgram2.Text)
            {
                MessageBox.Show("Chương trình cũ và chương trình mới  không được trùng nhau !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProgram.Focus();
            }

            // bắt đầu xử lý 
            var du = new DataTable();
            var cs = new PROGRAMInfo();
            cs.programpartlist = txtProgram2.Text;
            du = PROGRAMService.PROGRAM_GetByID(cs); // Lấy toàn bộ dữ liệu BOM của chương trình mới

            // Lấy dữ liệu Linh kiện còn trong hệ thống với ctrinh đang chay
            var ds = new PROGRAMHISTORYInfo();
            var dt = new DataTable();
            // Kiểm tra xem có dữ liệu không
            dt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, cbOldLine.Text);
            //int chk =EastechHistory_Services.EastechHistory_CheckProgKeyLineName_UV(txtProgram.Text, cbOldLine.Text);
            int checkcount = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_UV_20220517(txtProgram.Text, cbOldLine.Text);

            
            /*------Ghi chú các làm ---------------*/
			// Nếu check =1 tức là hàng của Uniden hoặc hàng không bắn QR code thì chỉ chuyển lần cuối cùng thay linh kiện sang
			// Nếu check =0 tức là hàng có bắn QR code thì sẽ chuyển những feeder còn số lượng sang ctrinh mới

			// Lấy dữ liệu còn lại của Program cũ sang program mới
			// Các Feeder giống nhau
			// Sử dụng feeder của chương trình mới
			/*

            if (cbNewLine.Text.Substring(0, 2) == "IN")
            {
                MessageBox.Show("Không thể chuyển sang Line của INSERT !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNewLine.Focus();
                return;
            }
            if (du.Rows.Count > 0 && dt.Rows.Count > 0)
            {
                if (checkcount == 0) // Đây là hàng không bắn QR code nên sẽ chuyển dữ liệu lần cuối cùng sang
                {
                    // Chỉ lấy lần thay linh kiện cuối cùng để đưa sang chương trình mới
                    var getdt = new DataTable();
                    getdt = EastechHistory_Services.EastechHistory_CombineProgramNonQRCode(txtProgram2.Text, txtProgram.Text, cbOldLine.Text);
                    try
                    {
                        if (getdt.Rows.Count > 0)
                        {
                            // dùng for vì phải lấy usge mới từ chương trình mới sang bản ghi mới.
                            foreach (DataRow row in du.Rows)
                            {
                                foreach (DataRow nrow in getdt.Rows)
                                {
                                    if (row["fdrno"].ToString() == nrow["fdrno"].ToString())
                                    {
                                        //// Thêm bản ghi mới vào IPQC history
                                        //// Update dữ liệu lên bản ghi cũ thông qua số Id
                                        //// Lấy usage mới từ chương trình mới
                                        //int usage = int.Parse(row["usage"].ToString());
                                        //// Tính số lượng linh kiện còn lại của chương trình cũ.
                                        //int newPcbCothedung = (int.Parse(nrow["SoPCBCothedung"].ToString()) - int.Parse(nrow["counts"].ToString())) * int.Parse(nrow["usage"].ToString()) / usage;
                                        //string newNdesc = row["ndesc"].ToString();
                                        //int newReqqty = (int.Parse(nrow["SoPCBCothedung"].ToString()) - int.Parse(nrow["counts"].ToString())) * int.Parse(nrow["usage"].ToString());
                                        //int OldReqqty = int.Parse(nrow["counts"].ToString()) * int.Parse(nrow["usage"].ToString());
                                        //int OldPcbCothedung = int.Parse(nrow["counts"].ToString());
                                        var newHistory = new EastechHistory_Info();
                                        newHistory.programpartlist = txtProgram2.Text;
                                        newHistory.pkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + nrow["fdrno"].ToString() + "_" + nrow["partscode"].ToString();
                                        newHistory.psubkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + nrow["fdrno"].ToString();
                                        newHistory.fdrno = nrow["fdrno"].ToString();
                                        newHistory.partscode = nrow["partscode"].ToString();
                                        newHistory.ndesc = row["ndesc"].ToString();
                                        newHistory.usage = row["usage"].ToString();
                                        newHistory.checkedby = nrow["checkedby"].ToString();
                                        newHistory.checkedtime = Common_ClassBu.getServerDateTime().ToString("yyyy/MM/dd HH:mm:ss");
                                        newHistory.reqqty = nrow["reqqty"].ToString();
                                        newHistory.datecode = nrow["datecode"].ToString();
                                        newHistory.Solanthaylinhkien = nrow["Solanthaylinhkien"].ToString();
                                        newHistory.SoPCBCothedung = nrow["SoPCBCothedung"].ToString();
                                        newHistory.remark1 = cbNewLine.Text;
                                        newHistory.remark2 = Program.Dept;
                                        newHistory.remark3 = "Combine từ: " + txtProgram.Text + " Line: " + cbOldLine.Text + " Tới: " + txtProgram2.Text + "  Line: " + cbNewLine.Text;
                                        newHistory.counts = "0";
                                        EastechHistory_Services.EastechHistory_Insert(newHistory);
                                        // Update vào chương trình cũ số PCB có thể dùng = counts
                                        // và reqqty= số pcb có thể dùng * usage
                                        EastechHistory_Services.EastechHistory_UpdateCombine(long.Parse(nrow["Id"].ToString()), int.Parse(nrow["reqqty"].ToString()), 0);
                                    }

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu để combine chương trình----------!!!  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Có lỗi xảy ra khi COMBINE Không QR code----------!!!  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
                else // Đây là hàng bắn QR code lên sẽ chuyển toàn bộ dữ liệu còn lại sang
                {
                    // Lấy được toàn bộ dữ liệu của chương trình mới có feeder = feeder của chương trình cũ.
                    var newdt = new DataTable();
                    newdt = EastechHistory_Services.EastechHistory_CombineProgramQRCode(txtProgram2.Text, txtProgram.Text, cbOldLine.Text);
                    if (newdt.Rows.Count > 0)
                    {
                        try
                        {
                            if (newdt.Rows.Count > 0)
                            {
                                // dùng for vì phải lấy usge mới từ chương trình mới sang bản ghi mới.
                                foreach (DataRow row in du.Rows)
                                {
                                    foreach (DataRow nrow in newdt.Rows)
                                    {
                                        if (row["fdrno"].ToString() == nrow["fdrno"].ToString())
                                        {
                                            // Thêm bản ghi mới vào IPQC history
                                            // Update dữ liệu lên bản ghi cũ thông qua số Id
                                            // Lấy usage mới từ chương trình mới
                                            int usage = int.Parse(row["usage"].ToString());
                                            // Tính số lượng linh kiện còn lại của chương trình cũ.
                                            int newPcbCothedung = (int.Parse(nrow["SoPCBCothedung"].ToString()) - int.Parse(nrow["counts"].ToString())) * int.Parse(nrow["usage"].ToString()) / usage;
                                            string newNdesc = row["ndesc"].ToString();
                                            int newReqqty = (int.Parse(nrow["SoPCBCothedung"].ToString()) - int.Parse(nrow["counts"].ToString())) * int.Parse(nrow["usage"].ToString());
                                            int OldReqqty = int.Parse(nrow["counts"].ToString()) * int.Parse(nrow["usage"].ToString());
                                            int OldPcbCothedung = int.Parse(nrow["counts"].ToString());
                                            var newHistory = new EastechHistory_Info();
                                            newHistory.programpartlist = txtProgram2.Text;
                                            newHistory.pkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + nrow["fdrno"].ToString() + "_" + nrow["partscode"].ToString();
                                            newHistory.psubkey = txtProgram2.Text + "_" + cbNewLine.Text + "_" + nrow["fdrno"].ToString();
                                            newHistory.fdrno = nrow["fdrno"].ToString();
                                            newHistory.partscode = nrow["partscode"].ToString();
                                            newHistory.ndesc = row["ndesc"].ToString();
                                            newHistory.usage = row["usage"].ToString();
                                            newHistory.checkedby = nrow["checkedby"].ToString();
                                            newHistory.checkedtime = Common_ClassBu.getServerDateTime().ToString("yyyy/MM/dd HH:mm:ss");
                                            newHistory.reqqty = newReqqty.ToString();
                                            newHistory.datecode = nrow["datecode"].ToString();
                                            newHistory.Solanthaylinhkien = nrow["Solanthaylinhkien"].ToString();
                                            newHistory.SoPCBCothedung = newPcbCothedung.ToString();
                                            newHistory.remark1 = cbNewLine.Text;
                                            newHistory.remark2 = Program.Dept;
                                            newHistory.remark3 = "Combine từ: " + txtProgram.Text + " Line: " + cbOldLine.Text + " Tới: " + txtProgram2.Text + "  Line: " + cbNewLine.Text;
                                            newHistory.counts = "0";
                                            EastechHistory_Services.EastechHistory_Insert(newHistory);
                                            // Update vào chương trình cũ số PCB có thể dùng = counts
                                            // và reqqty= số pcb có thể dùng * usage
                                            EastechHistory_Services.EastechHistory_UpdateCombine(long.Parse(nrow["Id"].ToString()), int.Parse(OldReqqty.ToString()), int.Parse(OldPcbCothedung.ToString()));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu để combine chương trình----------!!!  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi COMBINE có QR code----------!!!  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để COMBINE ----------!!!  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            else
            {
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("Không có dữ liệu để chuyển !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lwait.Visible = false;
                    return;
                }
                else
                {
                    MessageBox.Show("Chương trình Đích không có trong csdl", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lwait.Visible = false;
                    return;
                }

            }
            var datatablecombine = new DataTable();
            datatablecombine = EastechHistory_Services.EastechHistory_CheckCombineLine(txtProgram2.Text, cbNewLine.Text);
            if (datatablecombine.Rows.Count > 0)
            {
                dataGridView1.DataSource = datatablecombine;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            lwait.Visible = false;
            MessageBox.Show("Finished!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
			#endregion
		}

		private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void cbOldLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbOldLine.Text.Equals("--Select--"))
			{
				CommonDAL.Instance.SetStatusLabels(loldline, "NG");
			}
			else
			{
				CommonDAL.Instance.SetStatusLabels(loldline, "OK");
			}
		}

		private void cbNewLine_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbNewLine.Text.Equals("--Select--"))
			{
				CommonDAL.Instance.SetStatusLabels(lnewline, "NG");
			}
			else
			{
				CommonDAL.Instance.SetStatusLabels(lnewline, "OK");
			}
		}
	}
}
