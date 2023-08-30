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
    public partial class frmFChuyenLineSMT : Form
    {
        public frmFChuyenLineSMT()
        {
            InitializeComponent();
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
		private void frmFChuyenLineSMT_Load(object sender, EventArgs e)
        {
			// Load dữ liệu của Line vào combobox.
			lprogram.Text = string.Empty;
			loldline.Text = string.Empty;
			lnewline.Text = string.Empty;

			cbNewLine.Text = "--Select--";
			cbOldLine.Text = "--Select--";
			lwait.Visible = false;
			txtProgram.Text = string.Empty;
			txtProgram.Focus();
			#region Old Code
			/*
			lwait.Visible = false;
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
                MessageBox.Show("Không có Line nào trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
			#endregion
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
		private bool checkProgram()
		{
			//var checkProgram = SmtProgramHistoryDAL.Instance.checkProgramName(txtProgram.Text.Trim());
			var checkEtProgram = EASTECH_PROGRAMHISTORY_DAL.Instance.GetProgramLineName(txtProgram.Text.Trim());
			if (checkEtProgram.Count > 0)
			{

			}
			//if (checkProgram != null && checkEtProgram.Count > 0)
			//{

			//}
			else
			{
				//MessageBox.Show("Chưa có Chương trình này trong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);				
				return false;
			}
			return true;
		}
		private void txtProgram_KeyDown(object sender, KeyEventArgs e)
        {
            // Phải kiểm tra xem dữ liệu đó có trong history của smt proram chưa???
            // Phải kiểm tra xem dữ liệu đó có trong history của eastech history chưa???            
            if (e.KeyCode == Keys.Enter)
            {
				if (checkProgram())
				{
					CommonDAL.Instance.SetStatusLabels(lprogram, "OK");
					LoadOldLine();
					lineSMTList();
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
                DataTable dt = new DataTable();
                DataTable du = new DataTable();
                PROGRAMHISTORYInfo cs = new PROGRAMHISTORYInfo();
                cs.programpartlist = txtProgram.Text;
                dt = PROGRAMHISTORYService.PROGRAMHISTORY_GetByID(cs);
                du = EastechHistory_Services.EastechHistory_CheckProgKey(txtProgram.Text);
                if ((dt.Rows.Count < 0 && du.Rows.Count > 0) || (dt.Rows.Count > 0 && du.Rows.Count < 0) || (dt.Rows.Count < 0 && du.Rows.Count < 0))
                {
                    MessageBox.Show("Chưa có Chương trình này trong dữ liệu P1 !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
		private bool isOkData()
		{
			if (!checkProgram())
			{
				CommonDAL.Instance.SetStatusLabels(lprogram, "NG");
				return false;
			}
			if (cbOldLine.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn Line", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (cbNewLine.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn Line Cần chuyển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (cbNewLine.Text.Equals(cbOldLine.Text) && cbOldLine.Text.Equals("--Select--"))
			{
				MessageBox.Show("Chọn Line Cần chuyển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (cbNewLine.Text.Substring(0, 2) == "IN" || cbOldLine.Text.Substring(0, 2) == "IN")
			{
				MessageBox.Show("Không chuyển Line ở trong INSERT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (cbNewLine.Text.Equals(cbOldLine.Text))
			{
				MessageBox.Show("Không thể chuyển line giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			if (cbOldLine.Text.Equals(cbNewLine.Text))
			{
				MessageBox.Show("Không thể chuyển line giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			return true;
		}
		private void btProcess_Click(object sender, EventArgs e)
        {
			// xử lý thông tin theo program key + psubkey + Line 
			// Lấy toàn bộ thông tin của Program + Line
			lwait.Visible = true;
            #region Old Code
            /*
			if (txtProgram.Text.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống Proram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProgram.Focus();
            }
            if (cbNewLine.Text.Substring(0, 2) == "IN")
            {
                MessageBox.Show("Không thể cắt Lot sang Line Của INSERT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cbNewLine.Text == cbOldLine.Text)
            {
                MessageBox.Show("Không thể cắt Lot sang cùng 1 Line được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            #endregion
            if (isOkData())
            {
				var getdt = new DataTable();
				var lstEtHistory = new List<EASTECH_PROGRAMHISTORY>();
				var datetime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss");

				DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn Chuyển Line Không ???", "Cảnh Báo", MessageBoxButtons.YesNo);
				if (rs == DialogResult.Yes)
				{					
					var dt = new DataTable();
					// dt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, cbOldLine.Text);
					dt = EASTECH_PROGRAMHISTORY_DAL.Instance.getListRecordByProgramAndLineName(txtProgram.Text.Trim(), cbOldLine.Text.Trim());

					// int chk = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_UV(txtProgram.Text, cbOldLine.Text);
					// int checkcount = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_UV_20220517(txtProgram.Text, cbOldLine.Text);
					var checkScanQRorNot = EASTECH_PROGRAMHISTORY_DAL.Instance.checkLineScanQRorNotScanQRCode(txtProgram.Text.Trim(), cbOldLine.Text.Trim());
					if (dt.Rows.Count > 0)
					{
						// Đã có dữ liệu trong hệ thống. Tiến hành xử lý dữ liệu
						//1. Tính toán số linh kiện còn lại để chuyển sang line mới
						//2. Update số linh kiện của Line cũ để không cho bắn tiếp						
						if (checkScanQRorNot == null) // Hàng không bắn QR code
						{
							// Nếu không scan qr code thì sẽ chuyển lần thay linh kiện cuối cùng sang line mới.
							// Những lần trước đó thì không thực hiện chuyển
							// getdt = EastechHistory_Services.EastechHistory_CombineProgramNonQRCode(txtProgram.Text, txtProgram.Text, cbOldLine.Text);
							getdt = EASTECH_PROGRAMHISTORY_DAL.Instance.getListRecordNeedTransferToNewLine(1,
																										 txtProgram.Text.Trim(),
																										 txtProgram.Text.Trim(),
																										 cbOldLine.Text);
							try
							{
								if (getdt.Rows.Count > 0)
								{
									// Không phải lấy số usage sang lên dùng 1 vòng lặp for							

									foreach (DataRow item in getdt.Rows)
									{
										var newHistory = new EASTECH_PROGRAMHISTORY
										{
											Id = long.Parse(item["Id"].ToString()),
											programpartlist = txtProgram.Text.Trim(),
											pkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + item["fdrno"].ToString() + "_" + item["partscode"].ToString(),
											psubkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + item["fdrno"].ToString(),
											fdrno = item["fdrno"].ToString(),
											partscode = item["partscode"].ToString(),
											ndesc = item["ndesc"].ToString(),
											usage = int.Parse(item["usage"].ToString()),
											checkedby = item["checkedby"].ToString(),
											checkedtime = datetime,
											reqqty = int.Parse(item["reqqty"].ToString()),
											datecode = item["datecode"].ToString(),
											Solanthaylinhkien = int.Parse(item["Solanthaylinhkien"].ToString()),
											SoPCBCothedung = int.Parse(item["SoPCBCothedung"].ToString()),
											remark1 = cbNewLine.Text,
											remark2 = Program.Dept,
											remark3 = "Cut Lot from: " + txtProgram.Text + " Line: " + cbOldLine.Text + "---> To Line: " + cbNewLine.Text,
											counts = 0
										};
										lstEtHistory.Add(newHistory);
									}								
									string message = "";
									message = EASTECH_PROGRAMHISTORY_DAL.Instance.InsertUpdateRange(lstEtHistory);
									if (string.IsNullOrEmpty(message))
									{
										MessageBox.Show("Đã chuyển Line thành công !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
										dataGridView1.DataSource = null;
										dataGridView1.DataSource = lstEtHistory;
										dataGridView1.Refresh();
										txtProgram.Text = string.Empty;
										cbNewLine.Text = "--Select--";
										cbOldLine.Text = "--Select--";
										lprogram.Text = string.Empty;
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
									MessageBox.Show("Không có dữ liệu để cut Lot chương trình----------!!!  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show("Đã có lỗi xảy ra khi chạy chương trình No QR code:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw;
							}
						}
						else
						{
							//getdt = EastechHistory_Services.EastechHistory_CombineProgramQRCode(txtProgram.Text, txtProgram.Text, cbOldLine.Text);
							getdt = EASTECH_PROGRAMHISTORY_DAL.Instance.getListRecordNeedTransferToNewLine(2,
																										txtProgram.Text.Trim(),
																										txtProgram.Text.Trim(),
																										cbOldLine.Text);
							try
							{
								if (getdt.Rows.Count > 0)
								{
									foreach (DataRow row in getdt.Rows)
									{

										// Tính số lượng linh kiện còn lại của chương trình cũ.
										int newPcbCothedung = (int.Parse(row["SoPCBCothedung"].ToString()) - int.Parse(row["counts"].ToString()));
										int newReqqty = (int.Parse(row["SoPCBCothedung"].ToString()) - int.Parse(row["counts"].ToString())) * int.Parse(row["usage"].ToString());
										int OldReqqty = int.Parse(row["counts"].ToString()) * int.Parse(row["usage"].ToString());
										int OldPcbCothedung = int.Parse(row["counts"].ToString());

										var newHistory = new EASTECH_PROGRAMHISTORY
										{
											Id = long.Parse(row["Id"].ToString()),
											programpartlist = txtProgram.Text.Trim(),
											pkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + row["fdrno"].ToString() + "_" + row["partscode"].ToString(),
											psubkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + row["fdrno"].ToString(),
											fdrno = row["fdrno"].ToString(),
											partscode = row["partscode"].ToString(),
											ndesc = row["ndesc"].ToString(),
											usage = int.Parse(row["usage"].ToString()),
											checkedby = row["checkedby"].ToString(),
											checkedtime = datetime,
											reqqty = newReqqty,
											datecode = row["datecode"].ToString(),
											Solanthaylinhkien = int.Parse(row["Solanthaylinhkien"].ToString()),
											SoPCBCothedung = newPcbCothedung,
											remark1 = cbNewLine.Text,
											remark2 = Program.Dept,
											remark3 = "Cut Lot from: " + txtProgram.Text + " Line: " + cbOldLine.Text + " To Line: " + cbNewLine.Text,
											counts = 0
										};
										lstEtHistory.Add(newHistory);										
									}
									string message = "";
									message = EASTECH_PROGRAMHISTORY_DAL.Instance.InsertUpdateRangeQR(lstEtHistory);
									if (string.IsNullOrEmpty(message))
									{
										MessageBox.Show("Đã chuyển Line thành công !!! ", "Thông báo", MessageBoxButtons.OK,
										   MessageBoxIcon.Information);
										dataGridView1.DataSource = null;
										dataGridView1.DataSource = lstEtHistory;
										dataGridView1.Refresh();
										txtProgram.Text = string.Empty;
										cbNewLine.Text = "--Select--";
										cbOldLine.Text = "--Select--";
										lprogram.Text = string.Empty;
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
									MessageBox.Show("Không có dữ liệu để cut Lot:  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return;
								}

								//EastechHistory_Services.EastechHistory_UpdateQtyCount_New(txtProgram.Text.Trim(), cbNewLine.Text, cbOldLine.Text);
							}
							catch (Exception ex)
							{
								MessageBox.Show("Đã có lỗi xảy ra khi chạy chương trình:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
								throw;
							}
						}
						lwait.Visible = false;
						MessageBox.Show("Đã Chuyển Xong !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Không có dữ liệu của chương trình và Line này. Hãy Kiểm tra lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				else
				{
					MessageBox.Show("Không thực hiện việc chuyển Line Cut Lot !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

			}
			#region Old Code
            /*
			DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn Chuyển Line Không ???", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                Program.chuyenLineprokey = txtProgram.Text;
                Program.chuyenLineNewLine = cbNewLine.Text;
                var dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, cbOldLine.Text);
                // int chk = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_UV(txtProgram.Text, cbOldLine.Text);
                int checkcount = EastechHistory_Services.EastechHistory_CheckProgKeyLineName_UV_20220517(txtProgram.Text, cbOldLine.Text);
                if (dt.Rows.Count > 0)
                {
                    // Đã có dữ liệu trong hệ thống. Tiến hành xử lý dữ liệu
                    //1. Tính toán số linh kiện còn lại để chuyển sang line mới
                    //2. Update số linh kiện của Line cũ để không cho bắn tiếp
                    var csv = new EastechHistory_Info();
                    var backup = new EastechHistory_Info();
                    if (checkcount == 0) // Hàng không bắn QR code
                    {
                        var getdt = new DataTable();
                        getdt = EastechHistory_Services.EastechHistory_CombineProgramNonQRCode(txtProgram.Text, txtProgram.Text, cbOldLine.Text);
                        try
                        {
                            if (getdt.Rows.Count > 0)
                            {
                                // Không phải lấy số usage sang lên dùng 1 vòng lặp for
                                foreach (DataRow item in getdt.Rows)
                                {
                                    var newHistory = new EastechHistory_Info();
                                    newHistory.programpartlist = txtProgram.Text;
                                    newHistory.pkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + item["fdrno"].ToString() + "_" + item["partscode"].ToString();
                                    newHistory.psubkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + item["fdrno"].ToString();
                                    newHistory.fdrno = item["fdrno"].ToString();
                                    newHistory.partscode = item["partscode"].ToString();
                                    newHistory.ndesc = item["ndesc"].ToString();
                                    newHistory.usage = item["usage"].ToString();
                                    newHistory.checkedby = item["checkedby"].ToString();
                                    newHistory.checkedtime = Common_ClassBu.getServerDateTime().ToString("yyyy/MM/dd HH:mm:ss");
                                    newHistory.reqqty = item["reqqty"].ToString();
                                    newHistory.datecode = item["datecode"].ToString();
                                    newHistory.Solanthaylinhkien = item["Solanthaylinhkien"].ToString();
                                    newHistory.SoPCBCothedung = item["SoPCBCothedung"].ToString();
                                    newHistory.remark1 = cbNewLine.Text;
                                    newHistory.remark2 = Program.Dept;
                                    newHistory.remark3 = "Cut Lot from: " + txtProgram.Text + " Line: " + cbOldLine.Text + " Tới Line: " + cbNewLine.Text;
                                    newHistory.counts = "0";
                                    EastechHistory_Services.EastechHistory_Insert(newHistory);
                                    // Update vào chương trình cũ số PCB có thể dùng = counts
                                    // và reqqty= số pcb có thể dùng * usage
                                    EastechHistory_Services.EastechHistory_UpdateCombine(long.Parse(item["Id"].ToString()), 0, 0);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu để cut Lot chương trình----------!!!  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            //EastechHistory_Services.EastechHistory_UpdateQtyCount_New_UV(txtProgram.Text.Trim(), cbNewLine.Text, cbOldLine.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi chạy chương trình No QR code:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                    else
                    {
                        var newdt = new DataTable();
                        newdt = EastechHistory_Services.EastechHistory_CombineProgramQRCode(txtProgram.Text, txtProgram.Text, cbOldLine.Text);
                        try
                        {
                            if (newdt.Rows.Count > 0)
                            {
                                foreach (DataRow row in newdt.Rows)
                                {
                                    int usage = int.Parse(row["usage"].ToString());
                                    // Tính số lượng linh kiện còn lại của chương trình cũ.
                                    int newPcbCothedung = (int.Parse(row["SoPCBCothedung"].ToString()) - int.Parse(row["counts"].ToString()));
                                    int newReqqty = (int.Parse(row["SoPCBCothedung"].ToString()) - int.Parse(row["counts"].ToString())) * int.Parse(row["usage"].ToString());
                                    int OldReqqty = int.Parse(row["counts"].ToString()) * int.Parse(row["usage"].ToString());
                                    int OldPcbCothedung = int.Parse(row["counts"].ToString());
                                    var newHistory = new EastechHistory_Info();
                                    newHistory.programpartlist = txtProgram.Text;
                                    newHistory.pkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + row["fdrno"].ToString() + "_" + row["partscode"].ToString();
                                    newHistory.psubkey = txtProgram.Text + "_" + cbNewLine.Text + "_" + row["fdrno"].ToString();
                                    newHistory.fdrno = row["fdrno"].ToString();
                                    newHistory.partscode = row["partscode"].ToString();
                                    newHistory.ndesc = row["ndesc"].ToString();
                                    newHistory.usage = row["usage"].ToString();
                                    newHistory.checkedby = row["checkedby"].ToString();
                                    newHistory.checkedtime = Common_ClassBu.getServerDateTime().ToString("yyyy/MM/dd HH:mm:ss");
                                    newHistory.reqqty = newReqqty.ToString();
                                    newHistory.datecode = row["datecode"].ToString();
                                    newHistory.Solanthaylinhkien = row["Solanthaylinhkien"].ToString();
                                    newHistory.SoPCBCothedung = newPcbCothedung.ToString();
                                    newHistory.remark1 = cbNewLine.Text;
                                    newHistory.remark2 = Program.Dept;
                                    newHistory.remark3 = "Cut Lot from: " + txtProgram.Text + " Line: " + cbOldLine.Text + " Tới Line: " + cbNewLine.Text;
                                    newHistory.counts = "0";
                                    EastechHistory_Services.EastechHistory_Insert(newHistory);
                                    // Update vào chương trình cũ số PCB có thể dùng = counts
                                    // và reqqty= số pcb có thể dùng * usage
                                    EastechHistory_Services.EastechHistory_UpdateCombine(long.Parse(row["Id"].ToString()), int.Parse(OldReqqty.ToString()), int.Parse(OldPcbCothedung.ToString()));
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu để cut Lot:  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            //EastechHistory_Services.EastechHistory_UpdateQtyCount_New(txtProgram.Text.Trim(), cbNewLine.Text, cbOldLine.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi chạy chương trình:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                    lwait.Visible = false;
                    MessageBox.Show("Đã Chuyển Xong !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu của chương trình và Line này. Hãy Kiểm tra lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không thực hiện việc chuyển Line Cut Lot !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
