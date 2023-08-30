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
using UnidenDAL.SysControl.Setup;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.Smt.DataControl
{
    public partial class frmUploadBOM : Form
    {
        public frmUploadBOM()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btUploadD_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Please Select Excel File to Import |*.xlsx;*.xls";            
            op.Title = "Select Excel";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtUpload.Text = op.FileName;
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            //Boolean chk = false;
            string[] str = new string[18];
            // Thay đổi thêm Model/Lot/Lotsize
            int j = 0;
            int rCnt = 0;
            int cCnt = 0;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(txtUpload.Text.Trim(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;
                progressBar1.Maximum = range.Rows.Count;
                string checkkey;
                int chkkey;
                checkkey = (range.Cells[2, 1] as Excel.Range).Text;
                chkkey = SmtUploadBomDAL.Instance.CheckProgramByKey(checkkey.ToString().Trim()).Count;
                if (chkkey > 0)
                {
                    MessageBox.Show("Đã tồn tại key trên hệ thống, Hãy Kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    var lstPROGRAM= new List<PROGRAM>();
                    DateTime date = CommonDAL.Instance.getSqlServerDatetime();
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        for (cCnt = 1; cCnt <= 18; cCnt++)
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
                        var obj = new PROGRAM();
                        // Check double key                   
                        obj.programpartlist = str[0].ToString();
                        obj.fdrno = str[1].ToString();
                        obj.partscode = str[2].ToString();
                        obj.ndesc = str[3].ToString();
                        obj.usage = int.Parse(str[4].ToString());
                        obj.rp = str[5].ToString();
                        obj.rep1 = str[6].ToString();
                        obj.rep2 = str[7].ToString();
                        obj.rep3 = str[8].ToString();
                        obj.rep4 = str[9].ToString();
                        obj.rep5 = str[10].ToString();
                        if (str[11].ToString().Equals(""))
                        {
                            obj.reqqty = 0;
                        }
                        else
                        {
                            obj.reqqty = int.Parse(str[11].ToString());
                        }                  
                        
                        obj.datecode = str[12].ToString();
                        obj.dateupdate = date.ToString();
                        obj.Model = str[13].ToString();
                        obj.LotNo = str[14].ToString();
                        obj.LotSize =int.Parse( str[15].ToString());
                        obj.PCB_TYPE = str[16].ToString().Trim();
                        obj.RefNo= str[17].ToString().ToUpper();
                        //SmtUploadBomDAL.Instance.Add(obj);
                        lstPROGRAM.Add(obj);
                        j = 0;
                        progressBar1.PerformStep();
                    }
                    //CommonDAL.Instance.BeginTransaction();
                    string message = "";
                    string message2 = "";
                    message =SmtUploadBomDAL.Instance.AddList(lstPROGRAM);
                    // ghi dữ liệu vào MODELLOTINFOR
                    var modelLotInfo= new UV_MODELLOTINFO();
                    var checkModelLotInfo = new UV_MODELLOTINFO();
                    modelLotInfo.ProgramKey = (range.Cells[2, 1] as Excel.Range).Text;
                    modelLotInfo.Model= (range.Cells[2, 14] as Excel.Range).Text;                   
                    if (modelLotInfo.Model != "")
                    {
                        modelLotInfo.BModel = (range.Cells[2, 14] as Excel.Range).Text;
                        modelLotInfo.Lot = (range.Cells[2, 15] as Excel.Range).Text;
                        modelLotInfo.LotSize = int.Parse((range.Cells[2, 16] as Excel.Range).Text);
                        modelLotInfo.CreatedDate = date;
                        modelLotInfo.UpdatedDate = date;
                        modelLotInfo.CreatedBy = Program.UserId;
                        checkModelLotInfo = MODELLOTINFO_DAL.Instance.checkExitsProgramKey(modelLotInfo.ProgramKey);                       
                        if (checkModelLotInfo == null)
                        {
                            message2 = MODELLOTINFO_DAL.Instance.Add(modelLotInfo);
                        }
                        else
                        {
                            message2 = MODELLOTINFO_DAL.Instance.Update(modelLotInfo);
                        }
                    }
                    else
                    {
                        message2 = "";
                    }
                   
                    if (message==""&&message2=="")
                    {
                        //CommonDAL.Instance.CommitTransaction();
                        MessageBox.Show("Kết thúc Upload dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xlWorkBook.Close(true, null, null);
                        xlApp.Quit();
                        CommonDAL.Instance.releaseObject(xlWorkSheet);
                        CommonDAL.Instance.releaseObject(xlWorkBook);
                        CommonDAL.Instance.releaseObject(xlApp);
                        progressBar1.Value = 0;
                    }
                    else
                    {
                        //CommonDAL.Instance.RollbackTransaction();
                        MessageBox.Show("Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //throw;
            }

        }

       
    }
}
