using SMTPROGRAM_Da.BoxET;
using SMTPROGRAM_Bu.BoxET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMTPROGRAM_Bu;

namespace SMTPRORAM.BoxET
{
        public partial class FIssueBoxManage : Form
    {
        public FIssueBoxManage()
        {
            InitializeComponent();
        }
        private void FIssueBoxManage_Load(object sender, EventArgs e)
        {
            chkCheck.Checked = false;
            txtBoxWight.Visible = false;
            lblResult.Text = "";
            txtBoxWight.Focus();
            chkUpload.Checked = false;
            txtFile.Enabled = false;
            btnSelectFile.Enabled = false;
            btnUpload.Enabled = false;
        }
       
        public static IEnumerable<string> ReadLines(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
        
        private void LoadData()
        {
            var dt= boxIssueManage_Service.boxIssueManage_getListByUserAndDate(Program.username);
            if (dt.Rows.Count>0)
            {
                dataGridView.DataSource = dt;
                dataGridView.AutoResizeColumns();
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }           
        }
        private void chkUpload_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (chkUpload.Checked == true)
            {
                txtFile.Enabled = true;
                btnUpload.Enabled = true;
                btnSelectFile.Enabled = true;
                txtFile.Focus();
            }
            else
            {
                txtFile.Enabled = false;
                btnUpload.Enabled = false;
                btnSelectFile.Enabled = false;
                txtBarcode.Focus();
            }
        }

        private void btnSelectFile_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    txtFile.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            // Duyệt text file lấy số barcode
            // Kiểm tra xem số barcode này có trong csdl không?
            // + Nếu có thì save lại --> chuyển trạng thái của bảng Serial thành true ( tức là đã issue)
            // + Nếu không có trong csld thì thông báo và tiếp tục thực hiện các QR code khác
            if (!txtFile.Text.Equals(""))
            {


                var obj = new boxIssueManage();
                var boxM = new boxETManage();
                var results = from str in ReadLines(txtFile.Text).ToArray()
                              let tmp = str.Split(';')
                              select str;
                var query = results.ToList();
                var dt = new DataTable();
                for (int i = 0; i < query.Count; i++)
                {
                    try
                    {
                        string[] fields = query[i].Split(';');
                        obj.IssueSerial = fields[0].ToUpper().ToString();
                        obj.IssueWight= float.Parse(fields[0].ToString());
                        dt = boxETManage_Service.boxETManage_CheckExists(fields[0].ToUpper().ToString());
                        if (dt.Rows.Count > 0 && bool.Parse(dt.Rows[0]["Status"].ToString()) == false)
                        {
                            obj.IssueBy = Program.username;
                            obj.IssueStatus = true;

                            boxM.Serial = obj.IssueSerial;
                            boxM.Status = true;
                            boxIssueManage_Service.boxIssueManage_Insert(obj);
                            boxETManage_Service.boxETManage_UpdateStatus(boxM);
                        }
                        else
                        {
                            MessageBox.Show("Số BarCode này đã được issue đi nhưng chưa trả lại: " + fields[0].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }

                }
                MessageBox.Show("Upload finished !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFile.Text = "";
                txtFile.Focus();
                LoadData();
            }
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            var frm = new SMTPRORAM.BoxET.FBoxReport();
            frm.Show();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var obj = new boxIssueManage();
                var boxM = new boxETManage();
                var dt = new DataTable();
                if (string.IsNullOrEmpty(txtLine.Text.Trim()))
                {
                    MessageBox.Show("Line Không được để trống " , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    txtLine.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtModel.Text.Trim()))
                {
                    MessageBox.Show("Model Không được để trống " , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtModel.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtMarket.Text.Trim()))
                {
                    MessageBox.Show("Thị trường Không được để trống " , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMarket.Focus();
                    return;
                }
                if (cbPcbType.Text.Equals("") || cbPcbType.Text.Equals("[None]"))
                {
                    MessageBox.Show("PCB không được để [None] ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbPcbType.Focus();
                    return;
                }
                if (chkCheck.Checked == true)
                {
                    
                    if (txtBoxWight.Text.Equals("") || txtBoxWight.Text.Equals("[None]")||float.Parse(txtBoxWight.Text.Trim())<=0)
                    {
                        MessageBox.Show("Trọng lương không để trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBoxWight.Focus();
                        return;
                    }
                }
               
                dt = boxETManage_Service.boxETManage_CheckExists(txtBarcode.Text);
                if (dt.Rows.Count > 0 && bool.Parse(dt.Rows[0]["Status"].ToString()) == false)
                {
                    obj.IssueSerial = txtBarcode.Text.Trim();
                    obj.IssueBy = Program.username;
                    obj.IssueStatus = true;
                    if (chkCheck.Checked==true)
                    {
                        obj.IssueWight = float.Parse(txtBoxWight.Text.Trim());
                    }
                    else
                    {
                        obj.IssueWight = 0;
                    }
                    obj.Line = txtLine.Text;
                    obj.Model = txtModel.Text;
                    obj.Market = txtMarket.Text;
                    obj.PCBType = cbPcbType.Text;
                    boxM.Serial = txtBarcode.Text.Trim();
                    boxM.Status = true;
                    boxIssueManage_Service.boxIssueManage_Insert(obj);
                    boxETManage_Service.boxETManage_UpdateStatus(boxM);
                    //txtLine.Enabled = false;
                    //txtModel.Enabled = false;
                    //txtMarket.Enabled = false;
                    //cbPcbType.Enabled = false;
                    lblResult.Text = "OK";
                    lblResult.Font = new Font("Serif", 36, FontStyle.Bold);
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(50);                    
                    txtBarcode.Text = "";
                    txtBoxWight.Text = "";
                    if (chkCheck.Checked == true)
                    {
                        txtBoxWight.Focus();
                    }
                    else
                    {
                        txtBarcode.Focus();
                    }                    
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Số BarCode này đã được issue đi nhưng chưa trả lại: " + txtBarcode.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarcode.SelectAll();
                    txtBarcode.Focus();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt = SessionLogin_Services.tbl_SessionLogin_Select(Program.username);
            if (dt.Rows.Count > 0)
            {
                SessionLogin_Services.tbl_SessionLogin_Delete(Program.username);
            }
            Application.Exit();
        }

        private void txtBoxWight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBoxWight_Validating(object sender, CancelEventArgs e)
        {
            if (txtBoxWight.Text.Equals(""))
            {
                MessageBox.Show("Không để để trống trọng lượng box", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxWight.Focus();
                txtBoxWight.SelectAll();
            }
            else
            {
                txtBarcode.Focus();
            }
        }

        private void txtBoxWight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (txtBoxWight.Text.Equals("")|| double.Parse(txtBoxWight.Text)<=0)
                {
                    MessageBox.Show("Không để để trống trọng lượng box hoặc trọng lượng phải >0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBoxWight.Focus();
                    txtBoxWight.SelectAll();
                }
                else
                {
                    txtBarcode.Focus();
                }
            }
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheck.Checked==true)
            {
                txtBoxWight.Visible = true;
            }
            else
            {
                txtBoxWight.Visible = false;
            }
        }
    }
}
