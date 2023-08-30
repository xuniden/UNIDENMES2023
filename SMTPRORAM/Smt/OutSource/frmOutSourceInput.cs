using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Whs;
using UnidenDAL;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;
using UnidenDAL.Smt.OutSource;
using DocumentFormat.OpenXml.Office2010.CustomUI;


namespace SMTPRORAM.Smt.OutSource
{
    public partial class frmOutSourceInput : Form
    {
        private string pathFile = "";
        public frmOutSourceInput()
        {
            InitializeComponent();
        }

        private void iconbtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Please Select Excel File to Import |*.xlsx;*.xls";
            op.Title = "Select Excel";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = op.FileName;
                pathFile = System.IO.Path.GetDirectoryName(op.FileName);
            }
        }

        private void iconbtnUpload_Click(object sender, EventArgs e)
        {
            if (!txtFile.Text.Trim().Equals(""))
            {
                string fileError = "Import_Error_" + CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
                string fileFullPath = pathFile + "\\" + fileError;
                progressBar.Visible = true;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                int j = 0;
                int rCnt = 0;
                int cCnt = 0;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(txtFile.Text.Trim(), 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;
                progressBar.Minimum = 0;
               
                var inQtyList = new List<SMT_OUTSOURCE_IN_QTY>();
                string keyImport ="Import_Data_"+ CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy-MM-dd-H-mm-ss");
                DateTime date = new DateTime();
                date = CommonDAL.Instance.getSqlServerDatetime();
                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    var rcInput = new SMT_OUTSOURCE_IN_QTY();
                    string[] str = new string[5];
                    for (cCnt = 1; cCnt <= 5; cCnt++)
                    {
                        if (!string.IsNullOrEmpty((range.Cells[rCnt, cCnt] as Excel.Range).Text) || (range.Cells[rCnt, cCnt] as Excel.Range).Text == "")
                        {
                            str[j] = (range.Cells[rCnt, cCnt] as Excel.Range).Text;
                            j = j + 1;
                        }
                        else
                        {
                            str[j] = "";
                            j = j + 1;
                        }
                    }
                    string Partcode;
                    Partcode = str[0].ToString();
                    if (!Partcode.Equals(""))
                    {

                        if (CheckData(str[0].ToString(), str[1].ToString(), str[2].ToString()))
                        {
                            //var rcInput = new SMT_OUTSOURCE_IN_QTY();
                            //rcInput.PartCode = str[0].ToString().Trim();
                            //rcInput.DateCode = DateTime.Parse(str[1].ToString().Trim());
                            //rcInput.Qty = double.Parse(str[2].ToString().Trim());
                            //// Xử lý khi upload trừ tồn kho
                            //if (rcInput.Qty<0)
                            //{
                            //    // Kiểm tra xem Part này có trong hệ thống chưa và tồn kho có >0 không?
                            //    var checkQty = new SMT_OUTSOURCE_IN_QTY();
                            //    checkQty = SMT_OUTSOURCE_IN_QTYDAL.Instance.getPartQty(rcInput.PartCode);
                            //    if (checkQty!=null)
                            //    {

                            //    }

                            //    // Khi có tồn kho > 0 thì tiến hành trừ dữ liệu đi
                            //}
                            ////=============================
                            //rcInput.Remark1 = str[3].ToString().Trim();
                            //rcInput.Remark2 = keyImport;
                            //rcInput.CreatedBy = Program.username;
                            //rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            //rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            //SMT_OUTSOURCE_IN_QTYDAL.Instance.Add(rcInput);


                            rcInput.PartCode = str[0].ToString().Trim();
                            rcInput.DateCode = DateTime.Parse(str[1].ToString().Trim());
                            rcInput.Qty = double.Parse(str[2].ToString().Trim());
                            rcInput.Remark1 = str[3].ToString().Trim();
                            rcInput.Remark2 = keyImport;
                            rcInput.CreatedBy = Program.username;
                            rcInput.CreatedDate = date;
                            rcInput.UpdatedDate = date;
                            inQtyList.Add(rcInput);
                        }
                        else
                        {
                            //string writeLine = str[0].ToString() + ";" + str[1].ToString() + ";" + str[2].ToString();
                            //CommonDAL.Instance.WriteTextError(fileFullPath, writeLine);
                            MessageBox.Show("Dữ liệu đã có lỗi, hãy kiểm tra dữ liệu dòng:  " + rCnt + " trong file excel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã có lỗi, hãy kiểm tra dữ liệu dòng:  " + rCnt + " trong file excel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //progressBar.Value = rCnt;
                    j = 0;
                }
                string message = "";
                progressBar.Maximum = inQtyList.Count;
                int processCount = 0;
                message = checkTonkho(inQtyList);
                if (message=="")
                {
                    DateTime dat = new DateTime();
                    date = CommonDAL.Instance.getSqlServerDatetime();
                    foreach (var inQty in inQtyList)
                    {
                        processCount++;
                        if (inQty.Qty < 0)
                        {
                            // Kiểm tra xem part đó có trong csdl không? có thì có số lượng > số lượng cần trừ không?                            
                            var cotonKhos = SMT_OUTSOURCE_IN_QTYDAL.Instance.danhsachMacoQty(inQty.PartCode);
                            var solinhkiencantru = inQty.Qty * -1;
                            foreach (var cotonkho in cotonKhos)
                            {
                                var updateQty = new SMT_OUTSOURCE_IN_QTY();
                                updateQty.ID = cotonkho.ID;
                                updateQty.CreatedBy = Program.UserId;
                                updateQty.UpdatedDate = dat;
                                updateQty.PartCode = inQty.PartCode;
                                double soconlai = cotonkho.Qty - solinhkiencantru;
                                if (soconlai >= 0)
                                {
                                    updateQty.Qty = soconlai ;
                                    updateQty.Remark1 = cotonkho.Remark1 + "  -->  " + inQty.Remark1 + "  -> Qty: " + -1*solinhkiencantru;
                                    SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(updateQty);
                                    break;
                                }
                                else
                                {
                                    solinhkiencantru = soconlai * -1;
                                    updateQty.Remark1 = cotonkho.Remark1 + "  -->  " + inQty.Remark1 + "  -> Qty: " + cotonkho.Qty * -1; ;
                                    updateQty.Qty = 0; // là vì nó trừ đi số lượng còn lại                            
                                    SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(updateQty);
                                }
                            }                            
                        }
                        else
                        {
                            SMT_OUTSOURCE_IN_QTYDAL.Instance.Add(inQty);
                        }
                        progressBar.Value = processCount;
                    }
                }
                else
                {
                    MessageBox.Show( message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_IN_QTYDAL.Instance.getUploadList());
                txtFile.Text = "";
                progressBar.Visible = false;
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                CommonDAL.Instance.releaseObject(xlWorkSheet);
                CommonDAL.Instance.releaseObject(xlWorkBook);
                CommonDAL.Instance.releaseObject(xlApp);
            }
        }

        private string checkTonkho(List<SMT_OUTSOURCE_IN_QTY> lstTonKho)
        {
            string message = "";
            foreach (var inQty in lstTonKho)
            {
                if (inQty.Qty >= 0)
                {
                    message = "";
                }
                else
                {
                    var tonkhoPart = new TonKhoList();
                    tonkhoPart = SMT_OUTSOURCE_IN_QTYDAL.Instance.getTonKhoList().Where(p => p.Partcode == inQty.PartCode).FirstOrDefault();
                    if (tonkhoPart != null)
                    {
                        if (tonkhoPart.Qty >= -1 * inQty.Qty)
                        {
                            message = "";
                        }
                        else
                        {
                            return message = "Không đủ số lượng tồn kho để trả lại: " + "\n\n"
                                + "Partcode: " + inQty.PartCode + "\n"
                                + "Tồn kho hiện tại: " + tonkhoPart.Qty;
                        }
                    }
                    else
                    {
                        return message = "Không có dữ liệu tồn kho cho part: " + inQty.PartCode;
                    }
                }
            }
            return message;
        }
        private bool CheckData(string Partcode, string date, string qty)
        {
            if (Partcode == "")
            {
                return false;
            }
            if (IsDateTime(date) == false)
            {
                return false;
            }
            if (qty == ""|| double.TryParse(qty,out double tmp)==false)
            {
                return false;
            }
            return true;
        }
        public bool IsDateTime(string date)
        {
            if (string.IsNullOrEmpty(date) || date.Equals("")) return false;
            return DateTime.TryParse(date, out DateTime dateTime);
        }

        private void frmOutSourceInput_Load(object sender, EventArgs e)
        {

        }


        private void iconbtnTonKho_Click(object sender, EventArgs e)
        {
            CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_IN_QTYDAL.Instance.getTonKhoList());
        }

        private void Search(string search)
        {
            CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_IN_QTYDAL.Instance.getTimKiemTheoPart(search));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search(txtSearch.Text);
            }
            
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        
    }
}
