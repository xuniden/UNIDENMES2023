using SMTPROGRAM_Bu;
using SMTPROGRAM_Bu.BoxET;
using SMTPROGRAM_Da.BoxET;
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

namespace SMTPRORAM.BoxET
{
    public partial class FReturnBoxManage : Form
    {
        public FReturnBoxManage()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var dt = boxReturnManage_Service.boxReturnManage_getListByUserAndDate(Program.username);
            if (dt.Rows.Count > 0)
            {
                dataGridView.DataSource = dt;
                dataGridView.AutoResizeColumns();
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
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
        private void FReturnBoxManage_Load(object sender, EventArgs e)
        {
            lblResult.Text = "";
            txtBarcode.Focus();
            chkUpload.Checked = false;
            txtFile.Enabled = false;
            btnSelectFile.Enabled = false;
            btnUpload.Enabled = false;
        }

       

        private void txtBarcode_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var boxReturn = new boxReturnManage();
                var boxIssue = new boxIssueManage();
                var boxM = new boxETManage();
                var dt = new DataTable();
                var dtchk = new DataTable();
                dtchk = boxETManage_Service.boxETManage_CheckExists(txtBarcode.Text.Trim());
                if (dtchk.Rows.Count > 0)
                {
                    boxReturn.ReturnSerial = txtBarcode.Text.Trim();
                    boxReturn.ReturnBy = Program.username;
                    boxM.Serial = txtBarcode.Text.Trim();
                    boxM.Status = false;
                    boxReturnManage_Service.boxIssueManage_Insert(boxReturn);
                    dt = boxIssueManage_Service.boxIssueManage_CheckExists(txtBarcode.Text);
                    if (dt.Rows.Count > 0)
                    {
                        boxETManage_Service.boxETManage_UpdateStatus(boxM);
                        boxIssueManage_Service.boxIssueManage_UpdateByStatus(txtBarcode.Text.Trim(), false);
                    }
                    lblResult.Text = "OK";
                    lblResult.Font = new Font("Serif", 36, FontStyle.Bold);
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(50);
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Số BarCode:" + txtBarcode.Text+ " chưa được đăng ký: " , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarcode.SelectAll();
                    txtBarcode.Focus();
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var frm = new SMTPRORAM.BoxET.FBoxReport();
            frm.Show();
        }

        private void chkUpload_CheckStateChanged(object sender, EventArgs e)
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Duyệt text file lấy số barcode
            // Kiểm tra xem số barcode này có trong csdl không?
            // + Nếu có thì save lại --> chuyển trạng thái của bảng Serial thành true ( tức là đã issue)
            // + Nếu không có trong csld thì thông báo và tiếp tục thực hiện các QR code khác
            if (!txtFile.Text.Equals(""))
            {


                var boxReturn = new boxReturnManage();
                var boxIssue = new boxIssueManage();
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
                        string[] fields = query[i].Split(',');
                        //dt = boxIssueManage_Service.boxIssueManage_CheckExists(fields[0]);
                        //if (dt.Rows.Count > 0)
                        //{
                            boxReturn.ReturnSerial = fields[0].ToUpper().ToString();
                            boxReturn.ReturnBy = Program.username;

                            boxM.Serial = boxReturn.ReturnSerial;
                            boxM.Status = false;

                            boxReturnManage_Service.boxIssueManage_Insert(boxReturn);
                            dt = boxIssueManage_Service.boxIssueManage_CheckExists(fields[0]);
                            if (dt.Rows.Count > 0)
                            {
                                boxETManage_Service.boxETManage_UpdateStatus(boxM);
                                boxIssueManage_Service.boxIssueManage_UpdateByStatus(fields[0], false);
                            }

                        //}
                        //else
                        //{
                        //    //MessageBox.Show("Số BarCode chưa được issue đi: " + txtBarcode.Text.Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    string rFileName = Path.GetFileNameWithoutExtension(txtFile.Text);
                        //    rFileName = rFileName + "_Error";
                        //    string currentDirectory = Path.GetDirectoryName(txtFile.Text);
                        //    string fileName = currentDirectory+ "\\"+rFileName+".txt";
                          
                        //    try
                        //    {
                        //        // Check if file already exists. If yes, delete it.     
                        //        if (!File.Exists(fileName))
                        //        {
                        //            using (var txtFile = File.AppendText(fileName))
                        //            {
                        //                txtFile.WriteLine(fields[0]);
                        //            }
                        //        }
                        //        else if (File.Exists(fileName))
                        //        {
                        //            using (var txtFile = File.AppendText(fileName))
                        //            {
                        //                txtFile.WriteLine(fields[0]);
                        //            }
                        //        }
                        //    }
                        //    catch (Exception Ex)
                        //    {
                        //        Console.WriteLine(Ex.ToString());
                        //    }
                        //}
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

        private void btnSelectFile_Click(object sender, EventArgs e)
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
    }
}
