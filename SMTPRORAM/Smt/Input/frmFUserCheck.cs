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
    public partial class frmFUserCheck : Form
    {
        public static string programName { get;private set; }
        public static string lineName { get;private set; }
        private string[] result;
		private int panaQty = 0;
		ResizeForm _form;
        public static int total = 0;
        public static string position = "";
        public frmFUserCheck()
        {
            InitializeComponent();
            _form = new ResizeForm(this);
            this.Load += _Load;
            this.Resize += _Resize;
        }
        private void _Load(object sender, EventArgs e)
        {
            txtPcbSheet.Enabled = false;
            _form._get_initial_size();
        }
        private void _Resize(object sender, EventArgs e)
        {
            _form._resize();
        }


        private void frmFUserCheck_Load(object sender, EventArgs e)
        {
            lblDept.Text = Program.Dept;          
            lblusername.Text = Program.username;
            pictureBoxNG.Visible = false;
            pictureBoxOK.Visible = false;

            lbl_01.Text = "";
			lbl_02.Text = "";
			lbl_03.Text = "";
			lbl_04.Text = "";
			lbl_05.Text = "";
			lbl_06.Text = "";
		}
        private void ClearConditon()
        {
            this.txtfdrno.Text = "";
            this.txtpartcode.Text = "";
            this.txtqty.Text = "";
            this.txtdesc.Text = "";
            this.txtdatecode.Text = "";            
            this.txtfdrno.Focus();
            lbl_01.Text = "";
            lbl_02.Text = "";
            lbl_03.Text = "";
            lbl_04.Text = "";
            lbl_05.Text = "";
            lbl_06.Text = "";
        }
        private void ClearText()
        {
            txtLineName.Text = "";
            this.txtprgpartlist.Text = "";
            this.txtfdrno.Text = "";
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
		private bool isOKData()
		{
			int outParse;
			if (!checkProgram())
			{
				return false;
			}
			if (!checkFeeder())
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
			if (chkPanasonic.Checked == true)
			{

				if (string.IsNullOrEmpty(txtPcbSheet.Text.Trim()))
				{
					MessageBox.Show("Hãy nhập số lượng PCB/1 Sheet vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtPcbSheet.Focus();
					return false;
				}
				if (int.Parse(txtPcbSheet.Text.Trim().ToString()) <= 0)
				{
					MessageBox.Show("Số lượng PCB / Set phải >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtPcbSheet.Focus();
					txtPcbSheet.SelectAll();
					return false;
				}
				else
				{
					try
					{
						panaQty = int.Parse(txtPcbSheet.Text.Trim().ToString()) * int.Parse(txtqty.Text.Trim().ToString());
					}
					catch (Exception ex)
					{
						MessageBox.Show("Đã có lỗi khi tính toán số lượng PCB có thể dùng:  " + ex.Message, "Thông báo",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}

				}
			}
			else
			{
				panaQty = int.Parse(txtqty.Text.Trim());
			}
			return true;
		}
		private void btSave_Click(object sender, EventArgs e)
        {
			#region Old code
			//int outParse;
			//if (txtprgpartlist.Text.Trim().Equals("") || String.IsNullOrEmpty(txtprgpartlist.Text.Trim()))
			//{
			//    MessageBox.Show("Hãy điền thông tin vào ô bên PROGRAM PARTS LIST");
			//    txtprgpartlist.Focus();
			//}
			//else if (txtfdrno.Text.Trim().Equals("") || String.IsNullOrEmpty(txtfdrno.Text.Trim()))
			//{
			//    MessageBox.Show("Hãy điền thông tin vào ô bên FEEDER NO");
			//    txtfdrno.Focus();
			//}
			//else if (txtpartcode.Text.Trim().Equals("") || String.IsNullOrEmpty(txtpartcode.Text.Trim()))
			//{
			//    MessageBox.Show("Hãy điền thông tin vào ô bên PARTS CODE");
			//    txtpartcode.Focus();
			//}

			//else if (txtqty.Text.Trim().Equals("") || String.IsNullOrEmpty(txtpartcode.Text.Trim()))
			//{
			//    MessageBox.Show("Hãy điền số lượng vào");
			//    txtqty.Focus();
			//}
			//else if (!int.TryParse(txtqty.Text, out outParse))
			//{
			//    MessageBox.Show("Hãy nhập số vào ô này");
			//    txtqty.Focus();
			//}
			//else if (txtLineName.Text.Trim().Equals("") || String.IsNullOrEmpty(txtLineName.Text.Trim()))
			//{
			//    MessageBox.Show("Hãy điền tên Line vào ");
			//    txtLineName.Focus();
			//}
			//else if (txtdatecode.Text.Trim().Equals(""))
			//{
			//    MessageBox.Show("Nhập Date code vào ");
			//    txtdatecode.Focus();
			//}
			//else if (txtdesc.Text.Trim().Equals(""))
			//{
			//    MessageBox.Show("Nhập Mô tả linh kiện vào ");
			//    txtdesc.Focus();
			//}
			//// Khi tất cả giá trị cần thiết đã được điền đầy đủ 
			////thì tiến hành kiểm tra thông tin đưa vào

			#endregion
			if (isOKData())
            {
				var datetime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd HH:mm:ss");

				var getProgramInfo = SmtProgramDAL.Instance.checkPartcodeCutLot(txtprgpartlist.Text.Trim(),
					txtfdrno.Text.Trim(),
					txtpartcode.Text.Trim());


				if (getProgramInfo != null)
				{
					var proHistory = new PROGRAMHISTORY
					{
						programpartlist = txtprgpartlist.Text.Trim(),
						fdrno = txtfdrno.Text.Trim(),
						partscode = txtpartcode.Text.Trim(),
						ndesc = txtdesc.Text.Trim(),
						usage = getProgramInfo.usage,
						checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper(),
						checkedtime = datetime,
						rp = getProgramInfo.rp,
						rep1 = getProgramInfo.rep1,
						rep2 = getProgramInfo.rep2,
						rep3 = getProgramInfo.rep3,
						rep4 = getProgramInfo.rep4,
						rep5 = getProgramInfo.rep5,
						datecode = txtdatecode.Text.Trim(),
						reqqty = panaQty,
						changedby = Program.Dept,
						changedtime = ""
					};
					// proHistory.reqqty = (panaQty > 0) ? panaQty : int.Parse(txtqty.Text.Trim());

					var etHistory = new EASTECH_PROGRAMHISTORY
					{
						programpartlist = txtprgpartlist.Text.Trim(),
						fdrno = txtfdrno.Text.Trim(),
						partscode = txtpartcode.Text.Trim(),
						ndesc = txtdesc.Text.Trim(),
						usage = getProgramInfo.usage,
						checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper(),
						checkedtime = datetime,
						datecode = txtdatecode.Text.Trim(),
						pkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim() + "_" + txtfdrno.Text.Trim() + "_" + txtpartcode.Text.Trim(),
						psubkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim().ToUpper() + "_" + txtfdrno.Text.Trim(),
						reqqty = panaQty,
						remark1 = txtLineName.Text.Trim(),
						remark2 = Program.Dept,
						remark3 = "",
						counts = 0
					};
					//etHistory.reqqty = (panaQty > 0) ? panaQty : int.Parse(txtqty.Text.Trim());
					var NumberOfChangedMeterial = EASTECH_PROGRAMHISTORY_DAL.Instance.getMaxSolanthaylinhkien(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtLineName.Text.Trim());
					etHistory.Solanthaylinhkien = (NumberOfChangedMeterial == null) ? 1 : NumberOfChangedMeterial.Solanthaylinhkien + 1;
					if (panaQty > 0 && getProgramInfo.usage > 0)
					{
						etHistory.SoPCBCothedung = (int)(panaQty / getProgramInfo.usage);
					}
					if (panaQty > 0 && getProgramInfo.usage == 0)
					{
						etHistory.SoPCBCothedung = panaQty;
					}
					/*
                    if (panaQty==0 && int.Parse(txtqty.Text.Trim())>0 && getProgramInfo.usage>0)
                    {
                        etHistory.SoPCBCothedung=(int)(int.Parse(txtqty.Text.Trim())/getProgramInfo.usage);
					}
                    if (panaQty==0 && int.Parse(txtqty.Text.Trim()) > 0 && getProgramInfo.usage == 0)
                    {
						etHistory.SoPCBCothedung = int.Parse(txtqty.Text.Trim());
					}
                    */

					string message = EASTECH_PROGRAMHISTORY_DAL.Instance.InsertETHistoryVsProgramHistory(proHistory, etHistory);
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
						rep4 =  "",
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
				#region Old Code
				/*
                PROGRAMInfo data = new PROGRAMInfo();
                DataTable dt = new DataTable();
                data.programpartlist = txtprgpartlist.Text.Trim();
                data.fdrno = txtfdrno.Text.Trim();
                data.partscode = txtpartcode.Text.Trim();
                dt = PROGRAMService.PROGRAM_CheckInput(data);
                if (dt.Rows.Count > 0 && dt.Rows.Count < 2)
                {
                    try
                    {
                        PROGRAMHISTORYInfo p = new PROGRAMHISTORYInfo();
                        EastechHistory_Info es = new EastechHistory_Info();
                        p.programpartlist = txtprgpartlist.Text.Trim();
                        p.fdrno = txtfdrno.Text.Trim();
                        p.partscode = txtpartcode.Text.Trim();
                        p.ndesc = txtdesc.Text.Trim();

                        // Eastech
                        es.programpartlist = txtprgpartlist.Text.Trim();
                        es.fdrno = txtfdrno.Text.Trim();
                        es.partscode = txtpartcode.Text.Trim();
                        es.ndesc = txtdesc.Text.Trim();
                        //if (txtdesc.Text.Trim().Equals("") || string.IsNullOrEmpty(txtdesc.Text.Trim()))
                        //{
                        //    if (dt.Rows[0].Field<string>("ndesc").Equals("")||string.IsNullOrEmpty(dt.Rows[0].Field<string>("ndesc")))
                        //    {
                        //        p.ndesc = "";
                        //        es.ndesc = "";
                        //    }
                        //    else
                        //    {
                        //        p.ndesc = dt.Rows[0].Field<string>("ndesc");
                        //        es.ndesc = dt.Rows[0].Field<string>("ndesc");
                        //    }
                        //}
                        //else
                        //{
                        //    p.ndesc = txtdesc.Text.Trim();
                        //    es.ndesc = txtdesc.Text.Trim();
                        //}

                        if (string.IsNullOrEmpty(dt.Rows[0].Field<int>("usage").ToString()) || dt.Rows[0].Field<int>("usage").Equals(""))
                        {
                            p.usage = "0";
                            es.usage = "0";
                        }
                        else
                        {
                            p.usage = dt.Rows[0].Field<int>("usage").ToString();
                            es.usage = dt.Rows[0].Field<int>("usage").ToString();
                        }

                        p.checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper();
                        p.checkedtime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd hh:mm:ss");

                        es.checkedby = Program.username + " OK" + " " + txtLineName.Text.Trim().ToUpper();
                        es.checkedtime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd hh:mm:ss");

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
                        //if (txtqty.Text.Trim().Equals(""))
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0].Field<int>("reqqty").ToString()))
                        //    {
                        //        p.reqqty = dt.Rows[0].Field<int>("reqqty").ToString();
                        //        es.reqqty = dt.Rows[0].Field<int>("reqqty").ToString();
                        //    }
                        //}
                        //else
                        //{
                        //    p.reqqty = txtqty.Text.Trim().ToString();
                        //    es.reqqty = txtqty.Text.Trim().ToString();
                        //}
                        if (chkPanasonic.Checked == true)
                        {
                            if (txtPcbSheet.Text.Trim().Equals("") || string.IsNullOrEmpty(txtPcbSheet.Text.Trim()))
                            {
                                MessageBox.Show("Hãy nhập số lượng PCB/1 Sheet vào");
                                return;
                            }
                            else if (int.Parse(txtPcbSheet.Text.Trim().ToString()) <= 0)
                            {
                                MessageBox.Show("Số lượng PCB phải >0");
                                return;
                            }
                            else
                            {
                                int x = int.Parse(txtPcbSheet.Text.Trim().ToString()) * int.Parse(txtqty.Text.Trim().ToString());
                                p.reqqty = x.ToString();
                                es.reqqty = x.ToString();
                            }
                        }
                        else
                        {
                            p.reqqty = txtqty.Text;
                            es.reqqty = txtqty.Text;
                        }


                        p.datecode = txtdatecode.Text;
                        es.datecode = txtdatecode.Text;
                        //if (txtdatecode.Text.Trim().Equals(""))
                        //{
                        //    p.datecode = "";
                        //    es.datecode = "";
                        //}
                        //else
                        //{
                        //    p.datecode = txtdatecode.Text.Trim().ToString();
                        //    es.datecode = txtdatecode.Text.Trim().ToString();
                        //}
                        p.changedby = Program.Dept;
                        p.changedtime = "";

                        //Lay du lieu dua vao bang history
                        PROGRAMHISTORYService.PROGRAMHISTORY_Insert(p);

                        // Lấy dữ liệu vào bảng của EASTECH.
                        es.pkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim() + "_" + txtfdrno.Text.Trim() + "_" + txtpartcode.Text.Trim();
                        es.psubkey = txtprgpartlist.Text.Trim() + "_" + txtLineName.Text.Trim().ToUpper() + "_" + txtfdrno.Text.Trim();
                        // Kiểm tra xem Psubkey lần cuối cùng bắn là số bao nhiêu 
                        // Sau đó sẽ tăng thêm để phục vụ việc lấy dữ liệu sang pcb
                        // Và tính toán chia số lượng link kiện cho từng pcb
                        DataTable uu = new DataTable();
                        uu = EastechHistory_Services.EastechHistory_GetNumberPartcodeChange(es.psubkey);
                        int num = 0;
                        if (uu.Rows.Count > 0)
                        {
                            num = uu.Rows[0].Field<int>("Solanthaylinhkien");
                        }
                        else
                        { num = 0; }
                        // tăng thêm số lần thay linh kiện cho program + line và feeder 
                        // cho dù đó là lần đầu hay lần thứ bao nhiêu thì vẫn tăng lên 1 lần
                        num = num + 1;
                        es.Solanthaylinhkien = num.ToString();

                        // tính toán xem với số lượng linh kiện này thì sẽ làm được bao nhiêu pcb

                        int pcbnum = 0;
                        if (chkPanasonic.Checked == true)
                        {
                            if ((int.Parse(es.usage) != 0 && int.Parse(txtqty.Text.Trim()) != 0) || (int.Parse(es.usage) != 0 && int.Parse(txtqty.Text.Trim()) == 0))
                            {
                                pcbnum = (int.Parse(txtPcbSheet.Text.Trim().ToString()) * int.Parse(txtqty.Text.Trim().ToString())) / int.Parse(es.usage);
                                es.SoPCBCothedung = pcbnum.ToString();
                                es.remark1 = txtLineName.Text.Trim(); es.remark2 = Program.Dept; es.remark3 = ""; es.counts = "0";
                                // Chỉ thêm vào csdl khi mà số lượng dùng và số lượng linh kiện nhập lớn hơn 0
                                EastechHistory_Services.EastechHistory_Insert(es);
                            }
                            if (int.Parse(es.usage) == 0)
                            {
                                pcbnum = int.Parse(txtPcbSheet.Text.Trim().ToString()) * int.Parse(txtqty.Text.Trim().ToString()); //   / int.Parse(es.usage);
                                es.SoPCBCothedung = pcbnum.ToString();
                                es.remark1 = txtLineName.Text.Trim(); es.remark2 = Program.Dept; es.remark3 = ""; es.counts = "0";
                                // Chỉ thêm vào csdl khi mà số lượng dùng và số lượng linh kiện nhập lớn hơn 0
                                EastechHistory_Services.EastechHistory_Insert(es);
                            }
                        }
                        else
                        {
                            if ((int.Parse(es.usage) != 0 && int.Parse(txtqty.Text.Trim()) != 0) || (int.Parse(es.usage) != 0 && int.Parse(txtqty.Text.Trim()) == 0))
                            {
                                pcbnum = int.Parse(txtqty.Text.Trim()) / int.Parse(es.usage);
                                es.SoPCBCothedung = pcbnum.ToString();
                                es.remark1 = txtLineName.Text.Trim(); es.remark2 = Program.Dept; es.remark3 = ""; es.counts = "0";
                                // Chỉ thêm vào csdl khi mà số lượng dùng và số lượng linh kiện nhập lớn hơn 0
                                EastechHistory_Services.EastechHistory_Insert(es);
                            }
                            if (int.Parse(es.usage) == 0)
                            {
                                pcbnum = int.Parse(txtqty.Text.Trim()); //   / int.Parse(es.usage);
                                es.SoPCBCothedung = pcbnum.ToString();
                                es.remark1 = txtLineName.Text.Trim(); es.remark2 = Program.Dept; es.remark3 = ""; es.counts = "0";
                                // Chỉ thêm vào csdl khi mà số lượng dùng và số lượng linh kiện nhập lớn hơn 0
                                EastechHistory_Services.EastechHistory_Insert(es);
                            }
                        }

                        // Có trường hợp useage ==0  ===> Trường hợp này thì có thể sản xuất vô vàn mạch --> cho max= qty
                        // Trường hợp qty =0 là cắt lot  và usage !=0 thì làm bt như trường hợp trên, vì khi đó số mạch làm được =0 
                        // Không ảnh hưởng đến dữ liệu
                        // Phải xử lý 2 trường hợp này.




                        ClearConditon();
                        lblStatus.Text = "OK";
                        lblStatus.Font = new Font("Serif", 104, FontStyle.Bold);
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        // Play sound

                        //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                        //try
                        //{
                        //    //string currentDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                        //    var current = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        //    current = current + "\\OK.wav";
                        //    player.SoundLocation = current;
                        //    player.Play();
                        //}
                        //catch (Exception)
                        //{

                        //}
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
                    pr.checkedtime = CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy/MM/dd hh:mm:ss");
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
                    lblStatus.Text = "NG";
                    lblStatus.Font = new Font("Serif", 104, FontStyle.Bold);
                    lblStatus.ForeColor = System.Drawing.Color.Red;                   
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
                */
				#endregion
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
		}

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            ClearText();
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
                    lineName=txtLineName.Text.Trim();
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
            // txtprgpartlist.Text = txtprgpartlist.Text.ToUpper();
            if (e.KeyCode == Keys.Enter)
            {
                if(checkProgram())
                {
					txtfdrno.Focus();
				}
                else
                {
					txtprgpartlist.Focus();
					txtprgpartlist.SelectAll();
				}
				#region Old Code
                /*
				//var chk = PROGRAMService.PROGRAM_CheckPRGList(txtprgpartlist.Text.Trim());
				var chk = SmtProgramDAL.Instance.getByProgram(txtprgpartlist.Text.Trim());
				if (chk !=null)
                {
                    Program.abcprogramkey = txtprgpartlist.Text;
                    Program.abclinename = txtLineName.Text;                 
					CommonDAL.Instance.SetStatusLabels(lbl_01, "OK");
					txtfdrno.Focus();
                }
                else
                {                    
					CommonDAL.Instance.SetStatusLabels(lbl_01, "NG");
					txtprgpartlist.Focus();
                    txtprgpartlist.SelectAll();
                }
                */
				#endregion
			}
		}

		private bool checkFeeder()
		{
			if (txtfdrno.Text.Trim().Equals("") || String.IsNullOrEmpty(txtfdrno.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lbl_02, "NG");
				return false;
			}
			else
			{
				//var chk = PROGRAMService.PROGRAM_CheckFeed(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim());
				var chk = SmtProgramDAL.Instance.checkFeeder(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim());

				if (chk != null)
				{
					CommonDAL.Instance.SetStatusLabels(lbl_02, "OK");
				}
				else
				{
					CommonDAL.Instance.SetStatusLabels(lbl_02, "NG");
					return false;
				}
			}
			return true;
		}
		private void txtfdrno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(checkFeeder())
                {
					txtpartcode.Focus();
				}
                else
                {
					txtfdrno.Focus();
					txtfdrno.SelectAll();
				}
				#region Old Code
				/*
				//var chk = PROGRAMService.PROGRAM_CheckFeed(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim());
				var chk = SmtProgramDAL.Instance.checkFeeder(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim());
				if (chk != null)
				{
					CommonDAL.Instance.SetStatusLabels(lbl_02, "OK");
					txtpartcode.Focus();
                }
                else
                {                   
					CommonDAL.Instance.SetStatusLabels(lbl_02, "NG");
					txtfdrno.Focus();
                    txtfdrno.SelectAll();
                }
                */
				#endregion
			}
		}

        private bool checkPartcode()
        {
			if (string.IsNullOrEmpty(txtpartcode.Text.Trim()) )
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
				var check = SmtProgramDAL.Instance.checkPartcodeCutLot(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtpartcode.Text.Trim());
				if (check != null)
				{   
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
			if (e.KeyCode == Keys.Enter)
			{
				if(checkPartcode())
                {
                    if (result.Length==1)
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
			}
			#region Old Code
			/*
            // Trước đó là độ dài partcode >11 ( partcode chuẩn của Uniden)
            //if (txtpartcode.Text.Length > 16)
            //{
            //    txtpartcode.Text = txtpartcode.Text.Trim().Substring(0, 16);
            //}
            //txtpartcode.Text = txtpartcode.Text.ToUpper();
            //if (e.KeyCode == Keys.Enter)
            //{


            //    int chk;
            //    if (txtpartcode.Text.Trim().Length >= 9 && txtpartcode.Text.Trim().Length <= 16)
            //    {
            //        chk = PROGRAMService.PROGRAM_CheckPartcode(txtprgpartlist.Text.Trim(), txtfdrno.Text.Trim(), txtpartcode.Text.Trim());
            //        if (chk == 1)
            //        {
            //            lbl_03.Text = "OK";
            //            lbl_03.ForeColor = System.Drawing.Color.Green;
            //            txtqty.Focus();
            //        }
            //        else
            //        {
            //            lbl_03.Text = "NG";
            //            lbl_03.ForeColor = System.Drawing.Color.Red;
            //            txtpartcode.Focus();
            //            txtpartcode.SelectAll();
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Partcode chỉ có 9->16 ký tự");
            //        lbl_03.Text = "NG";
            //        lbl_03.ForeColor = System.Drawing.Color.Red;
            //        txtpartcode.Focus();
            //        txtpartcode.SelectAll();
            //    }

            //}
            */
			#endregion
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
            
		private bool checkDatecode()
		{
			if (string.IsNullOrEmpty(txtdatecode.Text.Trim()))
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
				if (checkDesc())
				{
					btSave.PerformClick();
				}
				else
				{
					txtdesc.Focus();
					txtdesc.SelectAll();
				}
			}
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            lbl_01.Text = "";
            txtprgpartlist.Text = "";
            txtprgpartlist.Focus();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            lbl_02.Text = "";
            txtfdrno.Text = "";
            txtfdrno.Focus();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            lbl_03.Text = "";
            txtpartcode.Text = "";
            txtpartcode.Focus();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            txtqty.Text = "";
            txtqty.Focus();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            lbl_05.Text = "";
            txtdatecode.Text = "";
            txtdatecode.Focus();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            lbl_06.Text = "";
            txtdesc.Text = "";
            txtdesc.Focus();
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            txtLineName.Text = "";
            txtprgpartlist.Text = "";
            txtLineName.Focus();
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

      

        private void btChuyenLot_Click(object sender, EventArgs e)
        {
            frmFChuyenLineSMT fv = new frmFChuyenLineSMT();
            fv.Show();
        }

        private void btUpdateQty_Click(object sender, EventArgs e)
        {
            //F_Update_CutLot_ChangeLine fv = new F_Update_CutLot_ChangeLine();
            //fv.Show();
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btCombine_Click(object sender, EventArgs e)
        {
            frmF_Combine_Program fv = new frmF_Combine_Program();
            fv.Show();
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            frmFViewIQCCheckerResult fv = new frmFViewIQCCheckerResult();
            fv.Show();
        }

        private void txtPcbSheet_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void chkPanasonic_Click(object sender, EventArgs e)
        {
            if (chkPanasonic.Checked == true)
            {
                txtPcbSheet.Enabled = true;
                txtPcbSheet.Focus();
            }
            else
            {
                txtPcbSheet.Text = "";
                txtPcbSheet.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmFrmDeleteCheckCutLotData fv = new frmFrmDeleteCheckCutLotData();
            fv.Show();
        }

		
	}
}
