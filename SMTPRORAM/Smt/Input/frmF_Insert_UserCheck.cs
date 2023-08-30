using DocumentFormat.OpenXml.Spreadsheet;
using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Smt.Input;
using UnidenDTO;
using Font = System.Drawing.Font;

namespace SMTPRORAM.Smt.Input
{
    public partial class frmF_Insert_UserCheck : Form
    {
		private string[] result;
		public static string programName { get; private set; }
        public static string lineName { get; private set; }
		ResizeForm _form;
        public frmF_Insert_UserCheck()
        {
            InitializeComponent();
            _form = new ResizeForm(this);
            this.Load += _Load;
            this.Resize += _Resize;
            lblusername.Text = Program.username;
        }
        private void _Load(object sender, EventArgs e)
        {
            _form._get_initial_size();
        }
        private void _Resize(object sender, EventArgs e)
        {
            _form._resize();
        }
        private void ClearText()
        {
            txtLineName.Text = "";
            this.txtprgpartlist.Text = "";
            //this.txtPosition.Text = "";
            this.txtpartcode.Text = "";
            this.txtqty.Text = "";
            this.txtdesc.Text = "";
            this.txtdatecode.Text = "";
           
            this.txtLineName.Focus();
            lbl_01.Text = "";
            lbl_02.Text = "";
            lbl_03.Text = "";
            lbl_04.Text = "";
            lbl_05.Text = "";
            lbl_06.Text = "";
        }
               
        private void ClearConditon()
        {
            this.txtpartcode.Text = "";
            this.txtqty.Text = "";
            this.txtdesc.Text = "";
            this.txtdatecode.Text = "";

            txtfdrno.Text = "";            
            txtpartcode.Focus();

            lbl_01.Text = "";
            lbl_02.Text = "";
            lbl_03.Text = "";
            lbl_04.Text = "";
            lbl_05.Text = "";
            lbl_06.Text = "";
        }
        private void frmF_Insert_UserCheck_Load(object sender, EventArgs e)
        {
			lbl_01.Text = "";
			lbl_02.Text = "";
			lbl_03.Text = "";
			lbl_04.Text = "";
			lbl_05.Text = "";
			lbl_06.Text = "";
			txtfdrno.Enabled = false;

			pictureBoxOK.Visible = false;
			pictureBoxNG.Visible = false;

			if (Program.Dept != "INSERT")
            {
				MessageBox.Show("Chỉ sử dụng cho bộ phận INSERT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
            txtLineName.Focus();
            lblusername.Text = Program.username;
            lblDept.Text = Program.Dept;
        }

		private bool checkLineName()
		{
			var checkLine = SmtLineDAL.Instance.checkSMTLine(txtLineName.Text.Trim());
			if (checkLine == null)
			{
				MessageBox.Show("Không có tên Line này trong csdl. Hãy Kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}
			return true;
		}
		private void txtLineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
				if (e.KeyCode == Keys.Enter)
				{
					if (checkLineName())
					{
						txtprgpartlist.Focus();

					}
					else
					{
						txtLineName.SelectAll();
						txtLineName.Focus();
					}
					#region Old code
					/*
					// Kiểm tra xem Line có trong csdl không?
					// Nếu không có thì không cho qua.
					//txtLineName.Text = txtLineName.Text.Trim().ToUpper();
					DataTable dt = new DataTable();
					dt = Smt_Linename_Services.Linename(txtLineName.Text);
					if (dt.Rows.Count > 0)
					{
						SendKeys.Send("{TAB}");
					}
					else
					{
						MessageBox.Show("Không có tên Line này trong csdl. Hãy Kiểm tra lại");
						txtLineName.Text = "";
						txtLineName.Focus();
					}
					*/
					#endregion
				}

			}
        }

		private bool checkDatecode()
		{
			if (string.IsNullOrEmpty(txtdatecode.Text.Trim()) )
			{
				CommonDAL.Instance.SetStatusLabels(lbl_05, "NG");
				return false;
			}
			else
			{
				CommonDAL.Instance.SetStatusLabels(lbl_05, "OK");
			}
			return true;
		}


		private void txtdatecode_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter)
			{
				if (checkDatecode())
				{
					txtdesc.Focus();
				}
				else
				{
					txtdatecode.Focus();
					txtdatecode.SelectAll();
				}
				#region Old Code
				/*
				if (txtdatecode.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Phải Nhập Date code vào đây");
                    lbl_05.Text = "NG";
                    lbl_05.ForeColor = System.Drawing.Color.Red;
                    txtdatecode.Focus();
                }
                else
                {
                    // Do what you want to do if numeric
                    lbl_05.Text = "OK";
                    lbl_05.ForeColor = System.Drawing.Color.Green;
                    txtdesc.Focus();
                }
                */
				#endregion
			}
		}

        private void btClear_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            lbl_06.Text = "";
            txtdesc.Text = "";
            txtdesc.Focus();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            lbl_05.Text = "";
            txtdatecode.Text = "";
            txtdatecode.Focus();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            lbl_04.Text = "";
            txtqty.Text = "0";
            txtqty.Focus();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            lbl_03.Text = "";
            txtpartcode.Text = "";
            txtpartcode.Focus();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            lbl_01.Text = "";
            txtprgpartlist.Text = "";
            txtprgpartlist.Focus();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            txtLineName.Text = "";
            txtprgpartlist.Text = "";
            txtLineName.Enabled = true;
            txtprgpartlist.Enabled = true;
            txtLineName.Focus();
        }

        private void btn_CutLot_Click(object sender, EventArgs e)
        {
            txtqty.Text = "0";
            txtdatecode.Select();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // how many rows and columns do we have
            // in the picture used
            const int maxrows = 4;
            const int maxcols = 3;

            // based on each position (numbered from left to right, top to bottom)
            // what character do we want to add the textbox 
            var chars = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '/', 'A' };

            // on which row and col is clicked, based on the mouse event
            // which hold the X and Y value of the coordinates relative to 
            // the control.
            var row = (e.Y * maxrows) / this.pictureBox1.Height;
            var col = (e.X * maxcols) / this.pictureBox1.Width;

            // calculate the position in the char array
            var scancode = row * maxcols + col;

            // if the active control is a TextBox ...
            if (this.ActiveControl is TextBox)
            {
                if (scancode == 11)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    return;
                }
                else
                {
                    // ... add the char to the Text.
                    // add error and bounds checking as well as 
                    // handling of special chars like delete/backspace/left/right
                    // if added and needed
                    this.ActiveControl.Text += chars[scancode];
                }
            }
        }

		private bool checkDesc()
		{
			if (string.IsNullOrEmpty(txtdesc.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl_06, "NG");
				return false;
			}
			else
			{
				CommonDAL.Instance.SetStatusLabels(lbl_06, "OK");
			}
			return true;
		}
		private void txtdesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
				if (e.KeyCode == Keys.Enter)
				{
					if (checkDesc())
					{
						btSave.PerformClick();
					}
					else
					{
						txtdesc.Focus();
						txtdesc.SelectAll();
					}
					#region Old Code
					/*
					if (txtdesc.Text.Trim().Equals(""))
					{
						MessageBox.Show("Phải Nhập Mô tả vào đây");
						lbl_06.Text = "NG";
						lbl_06.ForeColor = System.Drawing.Color.Red;
						txtdesc.Focus();
					}
					else
					{
						lbl_06.Text = "OK";
						lbl_06.ForeColor = System.Drawing.Color.Green;
						btSave.Focus();
						SendKeys.Send("{Enter}");
					}
					*/
					#endregion
				}

			}
        }

		private bool isOKData()
		{
			if (!checkProgram())
			{
				return false;
			}
			if (!checkPartcode())
			{
				return false;
			}
			if (!checkQty())
			{
				return false;
			}
			if (!checkLineName())
			{
				return false;
			}
			if (!checkDatecode())
			{
				return false;
			}
			if (!checkDesc())
			{
				return false;
			}
			return true;
		}

		private void btSave_Click(object sender, EventArgs e)
        {
			if (isOKData())
			{
				var datetime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss");
				var checkListPro = SmtProgramDAL.Instance.getPositionByProgramAndPartCode(txtprgpartlist.Text.Trim(), txtpartcode.Text.Trim());
				if (checkListPro.Count > 0)
				{
					var lstProHistory = new List<PROGRAMHISTORY>();
					var lstEtHistory = new List<EASTECH_PROGRAMHISTORY>();
					int total = 0;
					List<string> positionList = new List<string>();
					List<int> usageList = new List<int>();
					int qty = int.Parse(txtqty.Text);

					//string[] position = new string[dt.Rows.Count];
					foreach (var item in checkListPro)
					{
						usageList.Add((int)item.usage);
						positionList.Add(item.fdrno);
						total += (int)item.usage;
					}
					int oneQty = (int)(qty / total);
					for (int j = 0; j < positionList.Count; j++)
					{
						var proHistory = new PROGRAMHISTORY
						{
							programpartlist = txtprgpartlist.Text.Trim(),
							partscode = txtpartcode.Text.Trim(),
							ndesc = txtdesc.Text.Trim(),
							datecode = txtdatecode.Text,
							checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper(),
							checkedtime = datetime,
							rp = checkListPro.FirstOrDefault().rp,
							rep1 = checkListPro.FirstOrDefault().rep1,
							rep2 = checkListPro.FirstOrDefault().rep2,
							rep3 = checkListPro.FirstOrDefault().rep3,
							rep4 = checkListPro.FirstOrDefault().rep4,
							rep5 = checkListPro.FirstOrDefault().rep5,
							changedby = Program.Dept,
							changedtime = ""
						};
						var etHistory = new EASTECH_PROGRAMHISTORY
						{
							programpartlist = txtprgpartlist.Text.Trim(),
							partscode = txtpartcode.Text.Trim(),
							ndesc = txtdesc.Text.Trim(),
							datecode = txtdatecode.Text,
							checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper(),
							checkedtime = datetime,
							remark1 = txtLineName.Text.Trim(),
							remark2 = Program.Dept,
							remark3 = "",
							counts = 0
						};

						proHistory.fdrno = positionList[j];
						proHistory.usage = usageList[j];

						etHistory.fdrno = positionList[j];
						etHistory.usage = usageList[j];
						etHistory.pkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim() + "_" + positionList[j] + "_" + txtpartcode.Text.Trim();
						etHistory.psubkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim().ToUpper() + "_" + positionList[j].ToString();

						var NumberOfChangedMeterial = EASTECH_PROGRAMHISTORY_DAL.Instance.getMaxSolanthaylinhkien(txtprgpartlist.Text.Trim(), positionList[j].ToString(), txtLineName.Text.Trim());
						etHistory.Solanthaylinhkien = (NumberOfChangedMeterial == null) ? 1 : NumberOfChangedMeterial.Solanthaylinhkien + 1;

						proHistory.reqqty = oneQty * usageList[j];
						etHistory.reqqty = oneQty * usageList[j];
						etHistory.SoPCBCothedung = oneQty;

						lstEtHistory.Add(etHistory);
						lstProHistory.Add(proHistory);
					}
					string message = EASTECH_PROGRAMHISTORY_DAL.Instance.InsertRangeETHistoryVsProgramHistory(lstProHistory, lstEtHistory);
					if (string.IsNullOrEmpty(message))
					{
						ClearConditon();
						pictureBoxOK.Visible = true;
						Application.DoEvents();
						System.Threading.Thread.Sleep(300);
						pictureBoxOK.Visible = false;
						CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.OK);
					}
					else
					{
						MessageBox.Show("Không thể ghi bản ghi OK này vào csdl. Có lỗi: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						pictureBoxNG.Visible = true;
						Application.DoEvents();
						System.Threading.Thread.Sleep(300);
						pictureBoxNG.Visible = false;
						CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
						return;
					}
				}
				else
				{
					var proHistory = new PROGRAMHISTORY
					{
						programpartlist = txtprgpartlist.Text.Trim(),
						fdrno = txtfdrno.Text.Trim(),
						partscode = txtpartcode.Text.Trim(),
						ndesc = "",
						usage = 0,
						checkedby = Program.username + " NG" + " " + txtLineName.Text.Trim().ToUpper(),
						checkedtime = datetime,
						rp = "",
						rep1 = "",
						rep2 = "",
						rep3 = "",
						rep4 = "",
						rep5 = "",
						datecode = "",
						changedby = Program.Dept,
						changedtime = ""
					};

					string message = SmtProgramHistoryDAL.Instance.Add(proHistory);
					if (string.IsNullOrEmpty(message))
					{
						CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
						pictureBoxNG.Visible = true;
						Application.DoEvents();
						System.Threading.Thread.Sleep(300);
						pictureBoxNG.Visible = false;
						CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
					}
					else
					{
						MessageBox.Show("Không thể ghi lỗi này vào CSDL !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						pictureBoxNG.Visible = true;
						Application.DoEvents();
						System.Threading.Thread.Sleep(300);
						pictureBoxNG.Visible = false;
						CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
						return;
					}
				}
			}
			else
			{
				CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
				pictureBoxNG.Visible = true;
				Application.DoEvents();
				System.Threading.Thread.Sleep(300);
				pictureBoxNG.Visible = false;
				CommonDAL.Instance.PlaySound(SMTPRORAM.Properties.Resources.NG);
			}
			#region Old code
			/*
			int outParse;
            if (txtprgpartlist.Text.Trim().Equals("") || String.IsNullOrEmpty(txtprgpartlist.Text.Trim()))
            {
                MessageBox.Show("Hãy điền thông tin vào ô bên PROGRAM PARTS LIST");
                txtprgpartlist.Focus();
            }
            else if (txtfdrno.Text.Trim().Equals("") || String.IsNullOrEmpty(txtfdrno.Text.Trim()))
            {
                MessageBox.Show("Hãy điền thông tin vào ô bên vị trí linh kiện");
                txtfdrno.Focus();
            }
            else if (txtpartcode.Text.Trim().Equals("") || String.IsNullOrEmpty(txtpartcode.Text.Trim()))
            {
                MessageBox.Show("Hãy điền thông tin vào ô bên PARTS CODE");
                txtpartcode.Focus();
            }

            else if (txtqty.Text.Trim().Equals("") || String.IsNullOrEmpty(txtqty.Text.Trim()))
            {
                MessageBox.Show("Hãy điền số lượng vào");
                txtqty.Focus();
            }
            else if (!Int32.TryParse(txtqty.Text, out outParse))
            {
                MessageBox.Show("Hãy nhập số vào ô này");
                txtqty.Focus();
            }
            else if (txtLineName.Text.Trim().Equals("") || String.IsNullOrEmpty(txtLineName.Text.Trim()))
            {
                MessageBox.Show("Hãy điền tên Line vào ");
                txtLineName.Focus();
            }
            else if (txtdatecode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập Date code vào ");
                txtdatecode.Focus();
            }
            else if (txtdesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập Mô tả vào !!! ");
                txtdesc.Focus();
            }

            // Khi tất cả giá trị cần thiết đã được điền đầy đủ 
            //thì tiến hành kiểm tra thông tin đưa vào
            else
            {
                var dt = new DataTable();
                dt = PROGRAMService.PROGRAM_GetPositionByProgramAndPartcode(txtprgpartlist.Text, txtpartcode.Text);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        PROGRAMHISTORYInfo p = new PROGRAMHISTORYInfo();
                        EastechHistory_Info es = new EastechHistory_Info();

                        p.programpartlist = txtprgpartlist.Text.Trim();
                        //p.fdrno = txtPosition.Text.Trim();
                        p.partscode = txtpartcode.Text.Trim();
                        p.ndesc = txtdesc.Text;
                        p.datecode = txtdatecode.Text;
                        //p.reqqty = txtqty.Text;
                        // Eastech
                        es.programpartlist = txtprgpartlist.Text.Trim();
                        // es.fdrno = txtfdrno.Text.Trim();
                        es.partscode = txtpartcode.Text.Trim();
                        es.ndesc = txtdesc.Text;
                        es.datecode = txtdatecode.Text;
                        //es.InQty = txtqty.Text;                     
                        //if (string.IsNullOrEmpty(dt.Rows[0].Field<int>("InUsage").ToString())|| dt.Rows[0].Field<int>("InUsage").ToString().Equals(""))
                        //{
                        //    p.InUsage = "0";
                        //    es.InUsage = "0";
                        //}
                        //else
                        //{
                        //    p.InUsage = dt.Rows[0].Field<int>("InUsage").ToString();
                        //    es.InUsage = dt.Rows[0].Field<int>("InUsage").ToString();
                        //}
                        p.checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper();
                        p.checkedtime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

                        es.checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper();
                        es.checkedtime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

                        if (String.IsNullOrEmpty(dt.Rows[0].Field<string>("rp")) || dt.Rows[0].Field<string>("rp").Equals(""))
                        {
                            p.rp = "";
                        }
                        else
                        {
                            p.rp = dt.Rows[0].Field<string>("rp").ToString();
                        }

                        //p.rep1 = dt.Rows[0].Field<string>("rep1").ToString();

                        if (string.IsNullOrEmpty(dt.Rows[0].Field<string>("rep1")) || dt.Rows[0].Field<string>("rep1").Equals(""))
                        {
                            p.rep1 = "";
                        }
                        else
                        {
                            p.rep1 = dt.Rows[0].Field<string>("rep1").ToString();
                        }
                        if (String.IsNullOrEmpty(dt.Rows[0].Field<string>("rep2")) || dt.Rows[0].Field<string>("rep2").Equals(""))
                        {
                            p.rep2 = "";
                        }
                        else
                        {
                            p.rep2 = dt.Rows[0].Field<string>("rep2").ToString();
                        }
                        if (String.IsNullOrEmpty(dt.Rows[0].Field<string>("rep3")) || dt.Rows[0].Field<string>("rep3").Equals(""))
                        {
                            p.rep3 = "";
                        }
                        else
                        {
                            p.rep3 = dt.Rows[0].Field<string>("rep3").ToString();
                        }
                        if (String.IsNullOrEmpty(dt.Rows[0].Field<string>("rep4")) || dt.Rows[0].Field<string>("rep4").Equals(""))
                        {
                            p.rep4 = "";
                        }
                        else
                        {
                            p.rep4 = dt.Rows[0].Field<string>("rep4").ToString();
                        }
                        if (String.IsNullOrEmpty(dt.Rows[0].Field<string>("rep5")) || dt.Rows[0].Field<string>("rep5").Equals(""))
                        {
                            p.rep5 = "";
                        }
                        else
                        {
                            p.rep5 = dt.Rows[0].Field<string>("rep5").ToString();
                        }
                        p.changedby = Program.Dept;
                        p.changedtime = "";

                        // Xử lý các thứ trong này dùng cho 1 và nhiều vị trí
                        var datas = new DataTable();
                        datas = PROGRAMService.PROGRAM_GetPositionByProgramAndPartcode(txtprgpartlist.Text, txtpartcode.Text);
                        int total = 0;
                        string[] position = new string[datas.Rows.Count];
                        int[] usage = new int[datas.Rows.Count];
                        if (datas.Rows.Count > 0)
                        {
                            //string[] position = new string[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                usage[i] = datas.Rows[i].Field<int>("usage");
                                position[i] = dt.Rows[i].Field<string>("fdrno");
                                total = total + datas.Rows[i].Field<int>("usage");
                            }
                        }
                        int qty = int.Parse(txtqty.Text);

                        int oneQty = qty / total;
                        for (int i = 0; i < position.Length; i++)
                        {
                            p.fdrno = position[i].ToString();
                            p.usage = usage[i].ToString();

                            es.fdrno = position[i].ToString();
                            es.usage = usage[i].ToString();

                            es.pkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim() + "_" + position[i].ToString() + "_" + txtpartcode.Text.Trim();
                            es.psubkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim().ToUpper() + "_" + position[i].ToString();

                            var uu = new DataTable();
                            uu = EastechHistory_Services.EastechHistory_GetNumberPartcodeChange(es.psubkey);
                            int num = 0;
                            if (uu.Rows.Count > 0)
                            {
                                num = uu.Rows[0].Field<int>("Solanthaylinhkien") + 1;
                            }
                            else
                            { num = 1; }

                            es.Solanthaylinhkien = num.ToString();

                            // tính toán xem với số lượng linh kiện này thì sẽ làm được bao nhiêu pcb
                            p.reqqty = (oneQty * int.Parse(usage[i].ToString())).ToString();
                            es.reqqty = (oneQty * int.Parse(usage[i].ToString())).ToString();
                            es.SoPCBCothedung = (oneQty * int.Parse(usage[i].ToString())).ToString();
                            es.remark1 = txtLineName.Text.Trim(); es.remark2 = Program.Dept; es.remark3 = ""; es.counts = "0";

                            PROGRAMHISTORYService.PROGRAMHISTORY_Insert(p);
                            EastechHistory_Services.EastechHistory_Insert(es);
                        }
                        txtLineName.Enabled = false;
                        txtprgpartlist.Enabled = false;
                        ClearConditon();
                        txtpartcode.Focus();
                        pictureBoxOK.Visible = true;
						System.Threading.Thread.Sleep(300);
						pictureBoxOK.Visible = false;

						try
                        {
                            SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.OK);
                            sndPlay.Play();
                        }
                        catch (Exception ek)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + ek.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi FUserCheck: " + ex.Message);
                        //throw;
                    }

                }
                else
                {
                    PROGRAMHISTORYInfo pr = new PROGRAMHISTORYInfo();
                    pr.programpartlist = txtprgpartlist.Text.Trim();
                    pr.fdrno = txtfdrno.Text.Trim();
                    pr.partscode = txtpartcode.Text.Trim();
                    pr.checkedby = Program.username + " NG" + "  " + txtLineName.Text;
                    pr.checkedtime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    pr.changedby = "";
                    pr.changedtime = "";
                    pr.usage = "0";
                    pr.rp = "";
                    pr.rep1 = "";
                    pr.rep2 = "";
                    pr.rep3 = "";
                    pr.rep4 = "";
                    pr.rep5 = "";
                    pr.reqqty = "0";
                    pr.ndesc = "";
                    pr.datecode = "";
                    PROGRAMHISTORYService.PROGRAMHISTORY_Insert(pr);
					pictureBoxNG.Visible = true;
					System.Threading.Thread.Sleep(300);
					pictureBoxNG.Visible = false;
					try
                    {
                        SoundPlayer sndPlay = new SoundPlayer(SMTPRORAM.Properties.Resources.NG);
                        sndPlay.Play();
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra FUserCheck: " + exx.Message);
                    }

                }

            }
            */
			#endregion
		}


		private bool checkProgram()
		{
			if (txtprgpartlist.Text.Trim().Equals("") || String.IsNullOrEmpty(txtprgpartlist.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl_01, "NG");
				return false;
			}
			else
			{
				var chk = SmtProgramDAL.Instance.getByProgram(txtprgpartlist.Text.Trim());
				if (chk != null)
				{
					programName = txtprgpartlist.Text.Trim();
					lineName = txtLineName.Text.Trim();
					CommonDAL.Instance.SetStatusLabels(lbl_01, "OK");
				}
				else
				{
					CommonDAL.Instance.SetStatusLabels(lbl_01, "NG");
					return false;
				}
			}
			return true;
		}
		private void txtprgpartlist_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter)
			{

				if (checkProgram())
				{
					txtpartcode.Focus();
				}
				else
				{
					txtprgpartlist.Focus();
					txtprgpartlist.SelectAll();
				}
				#region Old Code
				/*
				int chk;
                chk = PROGRAMService.PROGRAM_CheckPRGList(txtprgpartlist.Text.Trim());
                if (chk == 1)
                {
                    lbl_01.Text = "OK";
                    lbl_01.ForeColor = System.Drawing.Color.Green;
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    lbl_01.Text = "NG";
                    lbl_01.ForeColor = System.Drawing.Color.Red;
                    SendKeys.Send("^A");
                    txtprgpartlist.Focus();
                }
                */
				#endregion
			}
		}

		private bool checkPartcode()
		{
			if (string.IsNullOrEmpty(txtpartcode.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl_01, "NG");
				return false;
			}
			else
			{
				string inputString = txtpartcode.Text.Trim();
				char[] separator = { ';' };
				result = inputString.Split(separator);

				if (result.Length == 1)
				{
					txtpartcode.Text = result[0];
				}
				else
				{
					txtpartcode.Text = result[1];
				}

				//check = PROGRAMService.PROGRAM_CheckPartcode(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtpartcode.Text.Trim());
				var checkListPro = SmtProgramDAL.Instance.getPositionByProgramAndPartCode(txtprgpartlist.Text.Trim(), txtpartcode.Text.Trim());
				if (checkListPro != null)
				{
					var position = checkListPro.Select(item => item.fdrno.ToString()).ToArray();
					txtfdrno.Text = string.Join(",", position);

					if (result.Length > 1)
					{
						txtdatecode.Text = result[2];
						CommonDAL.Instance.SetStatusLabels(lbl_05, "OK");
						txtqty.Text = result[4];
						CommonDAL.Instance.SetStatusLabels(lbl_04, "OK");
					}
					CommonDAL.Instance.SetStatusLabels(lbl_03, "OK");
				}
				else
				{
					//MessageBox.Show("Hãy báo điều này với quản lý của bạn \n\n " +
					//	"Một vấn đề lớn có thể đang xảy ra là mã linh kiện đã bị thay nhầm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					CommonDAL.Instance.SetStatusLabels(lbl_03, "NG");
					return false;
					//txtcheckPartcode.Focus();
					//txtcheckPartcode.SelectAll();
					//txtcheckPartcode.SelectionStart = originalCursorPosition;				
				}
			}
			return true;
		}
		private void txtpartcode_KeyDown(object sender, KeyEventArgs e)
        {
            // Trước đó là độ dài partcode >11 ( partcode chuẩn của Uniden)
            //if (txtpartcode.Text.Length > 16)
            //{
            //    txtpartcode.Text = txtpartcode.Text.Trim().Substring(0,16);
            //}

            if (e.KeyCode == Keys.Enter)
            {
				if (Program.Dept == "INSERT") // Nếu là Insert thì tiến hành lấy vị trí của part dự vào partcode + program
				{
					if (checkPartcode())
					{
						if (result.Length == 1)
						{
							txtqty.Focus();
						}
						else
						{
							txtdesc.Focus();
						}
					}
					else
					{
						txtpartcode.Focus();
						txtpartcode.SelectAll();
					}
					#region Old Code
					/*
					if (txtpartcode.Text.Trim().Equals(""))
                    {
                        lbl_01.Text = "NG";
                        lbl_01.ForeColor = System.Drawing.Color.Red;
                        //return false;
                    }
                    else
                    {
						string inputString = txtpartcode.Text.Trim();
						char[] separator = { ';' };
						string[] result = inputString.Split(separator);

						if (result.Length == 1)
						{
							txtpartcode.Text = result[0];
						}
						else
						{
							txtpartcode.Text = result[1];
						}
						var dt = new DataTable();
                        dt = PROGRAMService.PROGRAM_GetPositionByProgramAndPartcode(txtprgpartlist.Text, txtpartcode.Text);
                        // Điền vị trí vào 
                        if (dt.Rows.Count > 0)
                        {							
							//int total = 0;
							//int[]  usage = new int[dt.Rows.Count];
							string[] position = new string[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //usage[i] = dt.Rows[i].Field<int>("usage");
                                position[i] = dt.Rows[i].Field<string>("fdrno");
                                //total = total + dt.Rows[i].Field<int>("usage");
                            }
							if (result.Length == 1)
							{
								txtqty.Focus();
							}
                            else
                            {
								txtdatecode.Text = result[2];
								txtqty.Text = result[4];
								txtdesc.Focus();

								lbl_04.Text = "OK";
								lbl_04.ForeColor = System.Drawing.Color.Green;

								lbl_05.Text = "OK";
								lbl_05.ForeColor = System.Drawing.Color.Green;
							}
							txtfdrno.Text = string.Join(",", position);
                            lbl_03.Text = "OK";
                            lbl_03.ForeColor = System.Drawing.Color.Green;
                            //txtqty.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Không có PartCode này trong CSDL ");
							lbl_03.Text = "NG";
							lbl_03.ForeColor = System.Drawing.Color.Red;
							txtpartcode.Focus();
							txtpartcode.SelectAll();

							txtfdrno.Text = "";
                            txtpartcode.Focus();
                            txtpartcode.Text = "";
                        }
                    }
                    */
					#endregion
				}
                else
                {
                    MessageBox.Show("Không phải bộ phận INSERT không làm cái này !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
			}
        }

		private bool checkQty()
		{
			if (string.IsNullOrEmpty(txtqty.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl_04, "NG");
				return false;
			}
			else
			{

				int outParse;
				var str = txtqty.Text;
				var getNumbers = (from t in str
								  where char.IsDigit(t)
								  select t).ToArray();
				txtqty.Text = new string(getNumbers);

				// Check if the point entered is numeric or not
				if (int.TryParse(txtqty.Text, out outParse))
				{
					// Do what you want to do if numeric
					CommonDAL.Instance.SetStatusLabels(lbl_04, "OK");
				}
				else
				{
					// Do what you want to do if not numeric
					// MessageBox.Show("Chỉ nhập số vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					CommonDAL.Instance.SetStatusLabels(lbl_04, "NG");
					return false;
				}
			}

			return true;
		}
		private void txtqty_KeyDown(object sender, KeyEventArgs e)
        {

			if (e.KeyCode == Keys.Enter)
			{
				if (checkQty())
				{
					txtdatecode.Focus();
				}
				else
				{
					txtqty.Focus();
					txtqty.SelectAll();
				}

			}
		}

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            frmFViewIQCCheckerResult fv = new frmFViewIQCCheckerResult();
            fv.Show();
        }
    }
}
