using DocumentFormat.OpenXml.Office2010.Drawing.Charts;
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
using UnidenDAL.Smt.Output;
using UnidenDAL.SysControl;
using UnidenDTO;
using static UnidenDAL.Smt.Output.SmtAOIQrCodeOutputDAL;

namespace SMTPRORAM.Smt.Output
{
    public partial class frmAOIQrcodeOutput : Form
    {
        UVEntities _entities = new UVEntities();
        public frmAOIQrcodeOutput()
        {
            InitializeComponent();
        }
        private void LoadListView()
        {
            this.listView1.Columns.Add("QR Code", 180, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Số LK", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Số QR", 1200, HorizontalAlignment.Left);
        }
        private void LoadAllPCBCodeActive()
        {
            var pcbCode = new GetPCBCode();
            pcbCode.PCBCode = "[None]";
            var lstPCBCode = SmtSetupPcbCodeDAL.Instance.getPCBCodeAll();
            lstPCBCode.Add(pcbCode);
            cbPcbCode.DataSource = lstPCBCode.OrderBy(p => p.PCBCode).ToList();
            cbPcbCode.DisplayMember = "PCBCode";
            cbPcbCode.ValueMember = "PCBCode";
        }
        private void frmAOIQrcodeOutput_Load(object sender, EventArgs e)
        {
            LoadAllPCBCodeActive();
            LoadListView();

            lblviewcount.Text = "";
            lbprog.Text = "";
            lbprg2.Text = "";
            lblCount.Text = "";
            var dept = UVDeptDAL.Instance.getDeptByID(Program.DeptID);
            if (dept!=null)
            {
                lblDept.Text = dept.DeptCode;
            }
            else
            {
                MessageBox.Show("Người dùng không thuộc bộ phận nào","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            lblchecker.Text = Program.UserId;

            cbPcbCode.Focus();
            lblQrcode.Text = "";
            lbline.Text = "";
            lblprogram1.Text = "";
            lblprogram2.Text = "";
        }

        private void cbPcbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbPcbCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!cbPcbCode.Text.Equals("")||cbPcbCode.Text.Trim()!="[None]")
            {
                var dt = new tbl_EastechPCBCode();
                dt = SmtSetupPcbCodeDAL.Instance.getPcbInfo(cbPcbCode.Text);
                if (dt!=null)
                {
                    txtModel.Text =dt.Model;
                    txtPcbType.Text = dt.PcbType;

                }
                else
                {
                    //MessageBox.Show("Không có dữ liệu !!!");
                    //return;
                }
            }
            
        }

        private void txtLinename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {   
                // Kiểm tra xem Line này có trong csdl không?
                if (txtLinename.Text.Equals(""))
                {
                    MessageBox.Show("Hãy nhập Line name vào đây !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    lbline.Text = "NG";
                    lbline.ForeColor = System.Drawing.Color.Red;
                    txtLinename.Focus();
                    return;
                }
                else
                {
                    bool checklistLine = SmtAOIQrCodeOutputDAL.Instance.checkLineName(txtLinename.Text.Trim());                    
                    if (!checklistLine)
                    {
                        MessageBox.Show("Line Này chưa có trong csdl!!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        lbline.Text = "NG";
                        lbline.ForeColor = System.Drawing.Color.Red;
                        txtLinename.Focus();
                        txtLinename.SelectAll();
                    }
                    else
                    {
                        string b = "";
                        b = txtLinename.Text.Substring(0, 2);
                        if (b == "BM" || b == "IN")
                        {
                            txtprogram2.Enabled = false;
                        }
                        else
                        {
                            txtprogram2.Enabled = true;
                        }
                        lbline.Text = "OK";
                        lbline.ForeColor = System.Drawing.Color.Green;                        
                        txtProgram.Focus();
                    }
                }
            }
        }

        private void txtProgram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                if (txtProgram.Text.Equals("") )
                {
                    MessageBox.Show("Hãy nhập tên chương trình vào đây !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    lblprogram1.Text = "NG";
                    lblprogram1.ForeColor = System.Drawing.Color.Red;
                    txtProgram.Focus();
                }
                else
                {
                    // Kiểm tra xem chương trình này đã được tạo trong BOM chưa?
                    var lstProBom = SmtProgramDAL.Instance.getListByProgram(txtProgram.Text.Trim());
                    var lstProHistory = SmtAOIQrCodeOutputDAL.Instance.getProgramHistoryByKeyLineName(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                    if (lstProBom.Count<1)
                    {
                        MessageBox.Show("Chương trình này chưa được tạo trong csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblprogram1.Text = "NG";
                        lblprogram1.ForeColor = System.Drawing.Color.Red;
                        txtProgram.SelectAll();
                        txtProgram.Focus();
                    }
                    if (lstProHistory.Count<1)
                    {
                        MessageBox.Show("Chương trình này không có dữ liệu thay linh kiện !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblprogram1.Text = "NG";
                        lblprogram1.ForeColor = System.Drawing.Color.Red;
                        txtProgram.SelectAll();
                        txtProgram.Focus();
                    }
                    // Kiểm tra xem ctrinh này đã có trong lịch sử thay linh kiện chưa???
                    lbprog.Text = lstProBom.Count.ToString();

                    //Program.dprogram1 = new DataTable();
                    //Program.dprogram1 = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtProgram.Text, txtLinename.Text);
                    //Program.dtpro_1 = new DataTable();
                    //Program.dtpro_1 = PROGRAMService.PROGRAM_GetByProgramKey(txtProgram.Text);
                    //lbprog.Text = Program.dtpro_1.Rows.Count.ToString();
                    ////dt = EastechHistory_Services.EastechHistory_CheckProgKey(txtProgram.Text.Trim());
                    //if (Program.dprogram1.Rows.Count < 1 || Program.dtpro_1.Rows.Count < 1)
                    //{
                    //    MessageBox.Show("Chương trình này chưa được tạo trong csdl hoặc Không có linh kiện để bắn. Hãy Liên hệ bộ phận IT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    lblprogram1.Text = "NG";
                    //    lblprogram1.ForeColor = System.Drawing.Color.Red;
                    //    txtProgram.SelectAll();
                    //    txtProgram.Focus();
                    //}
                   
                    string b = "";
                    b = txtLinename.Text.Substring(0, 2); // Lấy 2 ký tự bắt đầu của tên Line                        
                    if (b == "IN")
                    {
                        // Kiểm tra chương trình này với PCB có giống nhau không?
                        string pcb = cbPcbCode.Text.Substring(0, 14);
                        if (!txtProgram.Text.Contains(pcb))
                        {
                            MessageBox.Show("PCB Code Không thuộc chương trình này !!!!");
                            txtProgram.Clear();
                            txtProgram.Focus();
                        }
                        else
                        {
                            lblprogram1.Text = "OK";
                            lblprogram1.ForeColor = System.Drawing.Color.Green;                           
                            txtQRCode.Focus();
                        }

                    }                        
                    else
                    {

                        if (b == "BM")
                        {
                            lblprogram1.Text = "OK";
                            lblprogram1.ForeColor = System.Drawing.Color.Green;                           
                            txtQRCode.Focus();
                        }
                        else
                        {
                            lblprogram1.Text = "OK";
                            lblprogram1.ForeColor = System.Drawing.Color.Green;                           
                            txtprogram2.Focus();
                        }
                    }
                    
                }
            }
        }

        private void txtprogram2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                if (txtprogram2.Text.Equals(""))
                {
                    MessageBox.Show("Hãy tên chương trình 2 vào đây !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    lblprogram2.Text = "NG";
                    lblprogram2.ForeColor = System.Drawing.Color.Red;
                    txtprogram2.Focus();
                }
                else
                {
                    var lstProBom2 = SmtProgramDAL.Instance.getListByProgram(txtprogram2.Text.Trim());
                    var lstProHistory2 = SmtAOIQrCodeOutputDAL.Instance.getProgramHistoryByKeyLineName(txtprogram2.Text.Trim(), txtLinename.Text.Trim());

                    if (lstProBom2.Count < 1)
                    {
                        MessageBox.Show("Chương trình 2 này chưa được tạo trong csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblprogram2.Text = "NG";
                        lblprogram2.ForeColor = System.Drawing.Color.Red;
                        txtprogram2.SelectAll();
                        txtprogram2.Focus();
                    }
                    if (lstProHistory2.Count < 1)
                    {
                        MessageBox.Show("Chương trình 2 này không có dữ liệu thay linh kiện !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblprogram2.Text = "NG";
                        lblprogram2.ForeColor = System.Drawing.Color.Red;
                        txtprogram2.SelectAll();
                        txtprogram2.Focus();
                    }
                    // Kiểm tra xem ctrinh này đã có trong lịch sử thay linh kiện chưa???
                    lbprg2.Text = lstProBom2.Count.ToString();


                    // Kiểm tra xem ctrinh này có trong csdl không???
                    //Program.dprogram2 = new DataTable();
                    //Program.dprogram2 = EastechHistory_Services.EastechHistory_CheckProgKeyLineName(txtprogram2.Text, txtLinename.Text);
                    //Program.dtpro_2 = new DataTable();
                    //Program.dtpro_2 = PROGRAMService.PROGRAM_GetByProgramKey(txtprogram2.Text);
                    //lbprg2.Text = Program.dtpro_2.Rows.Count.ToString();                    
                    //if (Program.dprogram2.Rows.Count < 1 || Program.dtpro_2.Rows.Count < 1)
                    //{
                    //    MessageBox.Show("Chuong trình này chưa được tạo trong csdl hoặc Không có linh kiện. Hãy Liên hệ bộ phận IT");
                    //    lblprogram2.Text = "NG";
                    //    lblprogram2.ForeColor = System.Drawing.Color.Red;
                    //    txtprogram2.Focus();
                    //}
                    //else
                    //{
                    string b = "";
                    b = txtLinename.Text.Substring(0, 2);                        
                    lblprogram2.Text = "OK";
                    lblprogram2.ForeColor = System.Drawing.Color.Green;                        
                    txtQRCode.Focus();                        
                    //}
                }
            }
        }

        private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                txtQRCode.Enabled = false;
                if (txtQRCode.Text.Equals(""))
                {
                    MessageBox.Show("Nhập mã QR code vào đây !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    lblQrcode.Text = "NG";
                    lblQrcode.ForeColor = System.Drawing.Color.Red;
                    txtQRCode.Enabled = true;
                    txtQRCode.Focus();
                }
                else
                {
                    // Kiểm tra xem Mã QR này đã được tao ra trong csdl chưa? 
                    var serialInfo=SmtAOIQrCodeOutputDAL.Instance.getSerialInfo(txtQRCode.Text.Trim(), txtModel.Text.Trim());
                    if (serialInfo==null)
                    {
                        MessageBox.Show("Model: " + txtModel.Text + " Serial:  " + txtQRCode.Text + "Chưa được tạo trong csdl","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        cbPcbCode.Focus();
                    }
                    else
                    {
                        if (serialInfo.PCBCode!=cbPcbCode.Text.Trim())
                        {
                            MessageBox.Show("Hãy Kiểm tra lại PCB Code không giống nhau giữa PCB Code và Setup QR Code","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();
                        }
                        else
                        {
                            // Kiểm tra xem QR này đã được bắn đầu ra lần nào chưa?
                            var lstByQrcodeDept = SmtAOIQrCodeOutputDAL.Instance.getOutputInfoByQrCodeAndDept(txtQRCode.Text.Trim(), lblDept.Text);
                            var outInfo = new EASTECH_SMT_OUTPUT();
                            outInfo = lstByQrcodeDept.FirstOrDefault();
                            if (lstByQrcodeDept.Count>0)
                            {
                                // Đã được bắn 1 lần ở smt rồi
                                // Kiểm tra xem có tích vào bắn mặt 2 không?
                                if (checkBox1.Checked==false) // Không tích vào bắn mặt 2
                                {
                                    MessageBox.Show("Đã có dữ liệu trong hệ thống ở mặt 1: " + txtQRCode.Text + "Ngày tháng đã bắn " + outInfo.DateT,
                                        "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                    lblQrcode.Text = "NG";
                                    lblQrcode.ForeColor = System.Drawing.Color.Red;
                                    txtQRCode.Enabled = true;
                                    txtQRCode.Clear();
                                    txtQRCode.Focus();
                                }
                                else // Nếu được tích vào bắn mặt 2
                                {
                                    // Kiểm tra xem đã có dữ liệu mặt 2 chưa?
                                    var lstByQrCodeCheck2Face = SmtAOIQrCodeOutputDAL.Instance.getOutputInfoByQrCodeAndDept(txtQRCode.Text.Trim(), "2Face2");
                                    var out2Face = lstByQrCodeCheck2Face.FirstOrDefault();
                                    if (lstByQrCodeCheck2Face.Count>0)
                                    {
                                        MessageBox.Show("Đã có dữ liệu bắn 2 mặt trong hệ thống: " + txtQRCode.Text + "Ngày tháng đã bắn " + out2Face.DateT,
                                            "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                        lblQrcode.Text = "NG";
                                        lblQrcode.ForeColor = System.Drawing.Color.Red;
                                        txtQRCode.Enabled = true;
                                        txtQRCode.Clear();
                                        txtQRCode.Focus();
                                    }
                                    else
                                    {
                                        lblQrcode.Text = "OK";
                                        lblQrcode.ForeColor = System.Drawing.Color.Green;                                        
                                        SavetoDatabase();
                                       
                                    }
                                }
                            }
                            else
                            {

                                lblQrcode.Text = "OK";
                                lblQrcode.ForeColor = System.Drawing.Color.Green;
                                //btSave.Focus();
                                //btsave2.Focus();
                                //SendKeys.Send("{Enter}");
                                SavetoDatabase();
                            }
                        }
                    }
                    
                }
            }
        }
        private void SavetoDatabase()
        {
            string li = "";
            li = txtLinename.Text.Substring(0, 2);
            var saveOutput = new EASTECH_SMT_OUTPUT();
            saveOutput.QRCode = txtQRCode.Text;
            saveOutput.LineName = txtLinename.Text;
            saveOutput.Model = txtModel.Text;
            saveOutput.Remark = lblchecker.Text;
            saveOutput.Remark1 = txtPcbType.Text;
            saveOutput.Remark2 = cbPcbCode.Text;
            saveOutput.Remark3 = lblDept.Text;
            if (checkBox1.Checked == true)
            {
                saveOutput.Remark4 = "2Face2";
            }
            else
            {
                saveOutput.Remark4 = "";
            }
            saveOutput.Remark5 = "";
            if (li == "IN")
            {
                // Sau mỗi lần ghi dữ liệu thì nó sẽ tự động kiểm tra xem còn linh kiện không? nếu không còn
                var lstProHistory = SmtAOIQrCodeOutputDAL.Instance.getProgramHistoryByKeyLineName(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                if (int.Parse(lbprog.Text) > 0 && lstProHistory.Count > 0)
                {
                    var lstByQrcodeDept = SmtAOIQrCodeOutputDAL.Instance.getOutputInfoByQrCodeAndDept(txtQRCode.Text.Trim(), "SMT");
                    if (lstByQrcodeDept.Count < 1)
                    {
                        pictureBox2.Visible = true;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(300);
                        pictureBox2.Visible = false;
                        MessageBox.Show("QR Code Này chưa được bắn ở SMT !!!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        txtQRCode.Focus();
                    }
                    else
                    {
                        try
                        {
                            var lstGetMaterial = new List<SelectValue>();
                            lstGetMaterial = SmtAOIQrCodeOutputDAL.Instance.GetSelectValues(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                            if (lstGetMaterial.Count >= int.Parse(lbprog.Text) - 3)
                            {
                                string ids = "'";
                                foreach (var item in lstGetMaterial)
                                {
                                    ids = ids + item.Id + "','";
                                    saveOutput.programkey = txtProgram.Text;
                                    saveOutput.Feeder = item.fdrno;
                                    saveOutput.Partcode = item.partscode;
                                    saveOutput.NDesc = item.ndesc;
                                    saveOutput.DateCode = item.datecode;
                                    saveOutput.DateT = CommonDAL.Instance.getSqlServerDatetime();
                                    saveOutput.usage = item.usage;
                                    try
                                    {
                                        SmtAOIQrCodeOutputDAL.Instance.Add(saveOutput);
                                        SmtAOIQrCodeOutputDAL.Instance.Update(item.Id);
                                    }
                                    catch (Exception)
                                    {
                                        //MessageBox.Show("Đã có lỗi xảy ra khi input dữ liệu đầu ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        throw;
                                    }

                                    // EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                    // EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                                }
                                //ids = ids.Substring(0, ids.Length - 2);
                                //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                                if (txtprogram2.Text.Trim().Equals(""))
                                {
                                    ResetAll();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Thiếu nhiều linh kiện: " + (int.Parse(lbprog.Text) - lstGetMaterial.Count) + " con", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtQRCode.Enabled = true;
                                txtQRCode.Clear();
                                txtQRCode.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                        finally
                        {
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();
                        }
                    }
                }
            }
            if (li=="BM")
            {
                // Sau mỗi lần ghi dữ liệu thì nó sẽ tự động kiểm tra xem còn linh kiện không? nếu không còn
                var lstProHistory = SmtAOIQrCodeOutputDAL.Instance.getProgramHistoryByKeyLineName(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                if (int.Parse(lbprog.Text) > 0 && lstProHistory.Count > 0)
                {        
                    try
                    {
                        var lstGetMaterial = new List<SelectValue>();
                        lstGetMaterial = SmtAOIQrCodeOutputDAL.Instance.GetSelectValues(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                        if (lstGetMaterial.Count >= int.Parse(lbprog.Text) - 3)
                        {
                            string ids = "'";
                            foreach (var item in lstGetMaterial)
                            {
                                ids = ids + item.Id + "','";
                                saveOutput.programkey = txtProgram.Text;
                                saveOutput.Feeder = item.fdrno;
                                saveOutput.Partcode = item.partscode;
                                saveOutput.NDesc = item.ndesc;
                                saveOutput.DateCode = item.datecode;
                                saveOutput.DateT = CommonDAL.Instance.getSqlServerDatetime();
                                saveOutput.usage = item.usage;
                                try
                                {
                                    SmtAOIQrCodeOutputDAL.Instance.Add(saveOutput);
                                    SmtAOIQrCodeOutputDAL.Instance.Update(item.Id);
                                }
                                catch (Exception)
                                {
                                    //MessageBox.Show("Đã có lỗi xảy ra khi input dữ liệu đầu ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }

                                // EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                // EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                            }
                            //ids = ids.Substring(0, ids.Length - 2);
                            //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                            if (txtprogram2.Text.Trim().Equals(""))
                            {
                                ResetAll();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Thiếu nhiều linh kiện: " + (int.Parse(lbprog.Text) - lstGetMaterial.Count) + " con", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                    finally
                    {
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        txtQRCode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQRCode.Enabled = true;
                    txtQRCode.Clear();
                    txtQRCode.Focus();
                }
            }
            if (li=="TM")
            {
                // Sau mỗi lần ghi dữ liệu thì nó sẽ tự động kiểm tra xem còn linh kiện không? nếu không còn
                var lstProHistory = SmtAOIQrCodeOutputDAL.Instance.getProgramHistoryByKeyLineName(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                if (int.Parse(lbprog.Text) > 0 && lstProHistory.Count > 0)
                {
                    try
                    {
                        var lstGetMaterial = new List<SelectValue>();
                        lstGetMaterial = SmtAOIQrCodeOutputDAL.Instance.GetSelectValues(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                        if (lstGetMaterial.Count >= int.Parse(lbprog.Text) - 3)
                        {
                            string ids = "'";
                            foreach (var item in lstGetMaterial)
                            {
                                ids = ids + item.Id + "','";
                                saveOutput.programkey = txtProgram.Text;
                                saveOutput.Feeder = item.fdrno;
                                saveOutput.Partcode = item.partscode;
                                saveOutput.NDesc = item.ndesc;
                                saveOutput.DateCode = item.datecode;
                                saveOutput.DateT = CommonDAL.Instance.getSqlServerDatetime();
                                saveOutput.usage = item.usage;
                                try
                                {
                                    SmtAOIQrCodeOutputDAL.Instance.Add(saveOutput);
                                    SmtAOIQrCodeOutputDAL.Instance.Update(item.Id);
                                }
                                catch (Exception)
                                {
                                    //MessageBox.Show("Đã có lỗi xảy ra khi input dữ liệu đầu ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw;
                                }

                                // EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                // EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                            }
                            //ids = ids.Substring(0, ids.Length - 2);
                            //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                            if (txtprogram2.Text.Trim().Equals(""))
                            {
                                ResetAll();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Thiếu nhiều linh kiện: " + (int.Parse(lbprog.Text) - lstGetMaterial.Count) + " con", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                    finally
                    {
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        txtQRCode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQRCode.Enabled = true;
                    txtQRCode.Clear();
                    txtQRCode.Focus();
                }

                if (!txtprogram2.Text.Equals(""))
                {
                    var lstProHistory2 = SmtAOIQrCodeOutputDAL.Instance.getProgramHistoryByKeyLineName(txtprogram2.Text.Trim(), txtLinename.Text.Trim());
                    if (int.Parse(lbprg2.Text)>0&&lstProHistory2.Count>0)
                    {
                        try
                        {
                            var lstGetMaterial = new List<SelectValue>();
                            lstGetMaterial = SmtAOIQrCodeOutputDAL.Instance.GetSelectValues(txtProgram.Text.Trim(), txtLinename.Text.Trim());
                            if (lstGetMaterial.Count >= int.Parse(lbprog.Text) - 3)
                            {
                                string ids = "'";
                                foreach (var item in lstGetMaterial)
                                {
                                    ids = ids + item.Id + "','";
                                    saveOutput.programkey = txtprogram2.Text;
                                    saveOutput.Feeder = item.fdrno;
                                    saveOutput.Partcode = item.partscode;
                                    saveOutput.NDesc = item.ndesc;
                                    saveOutput.DateCode = item.datecode;
                                    saveOutput.DateT = CommonDAL.Instance.getSqlServerDatetime();
                                    saveOutput.usage = item.usage;
                                    try
                                    {
                                        SmtAOIQrCodeOutputDAL.Instance.Add(saveOutput);
                                        SmtAOIQrCodeOutputDAL.Instance.Update(item.Id);
                                    }
                                    catch (Exception)
                                    {
                                        //MessageBox.Show("Đã có lỗi xảy ra khi input dữ liệu đầu ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        throw;
                                    }

                                    // EastechOutputHistory_Services.sp_EastechOutputHistory_InsertSelectData(saveOutput);
                                    // EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(long.Parse(row["Id"].ToString()));
                                }
                                //ids = ids.Substring(0, ids.Length - 2);
                                //EastechHistory_Services.sp_EastechOutputHistory_UpdatetSelectData(ids);
                                if (!txtprogram2.Text.Trim().Equals(""))
                                {
                                    ResetAll();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Thiếu nhiều linh kiện: " + (int.Parse(lbprog.Text) - lstGetMaterial.Count) + " con", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtQRCode.Enabled = true;
                                txtQRCode.Clear();
                                txtQRCode.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra, Hãy Chụp lại và gửi cho bộ phận IT: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                        finally
                        {
                            txtQRCode.Enabled = true;
                            txtQRCode.Clear();
                            txtQRCode.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa có chương trình trong csdl hoặc Không có linh kiện trong hệ thống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQRCode.Enabled = true;
                        txtQRCode.Clear();
                        txtQRCode.Focus();
                    }
                }
            }            
        }
        
        private void ResetAll()
        {
            lblQrcode.Text = "";           
            lblprogram1.Text = "";
            lblprogram2.Text = "";
            txtLinename.Enabled = false;
            txtProgram.Enabled = false;
            txtprogram2.Enabled = false;
            cbPcbCode.Enabled = false;
            checkBox1.Enabled = false;
            pictureBox1.Visible = true;          
            Application.DoEvents();
            System.Threading.Thread.Sleep(50);
            lblCount.Text = SmtAOIQrCodeOutputDAL.Instance.CountByChecker(txtProgram.Text, txtprogram2.Text, Program.username).ToString();
            pictureBox1.Visible = false;     
            lblviewcount.Text = SmtAOIQrCodeOutputDAL.Instance.CountQRCodeByUser(txtProgram.Text, txtprogram2.Text, txtQRCode.Text, Program.username, CommonDAL.Instance.getSqlServerDatetime()).ToString();
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Items.Insert(0, (new ListViewItem(new string[] { txtQRCode.Text, lblviewcount.Text, lblCount.Text })));
            listView1.GridLines = true;
            txtQRCode.Enabled = true;
            txtQRCode.Clear();
            txtQRCode.Focus();
        }
    }
}
