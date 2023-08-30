using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.SysControl;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.whs;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace SMTPRORAM.Whs
{
    public partial class frmWhsIn : Form
    {
        private List<SYS_UserButtonFunction> lstUBFunction;

        public frmWhsIn()
        {
            InitializeComponent();
        }

        private void frmWhsIn_Load(object sender, EventArgs e)
        {
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            iconbtnEnable.Enabled = false;
            iconbtnSave.Enabled = false;
            iconbtnPaste.Enabled = false;
        }
        private void disableButton(bool t)
        {
            iconbtnEditmode.Enabled = !t;
            iconbtnEnable.Enabled = t;
            iconbtnSave.Enabled = t;
            iconbtnPaste.Enabled = t;
        }

        private void iconbtnEditmode_Click(object sender, EventArgs e)
        {
            iconbtnEnable.Enabled = true;
            dgView.ReadOnly = false;
            iconbtnSave.Enabled = true;
            iconbtnPaste.Enabled = true;
        }
       

        private void iconbtnEnable_Click(object sender, EventArgs e)
        {
            CommonDAL.Instance.ClearDataGridView(dgView);
        }

        private void iconbtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Please Select Excel File to Import |*.xlsx;*.xls";
            op.Title = "Select Excel";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = op.FileName;
            }
        }

        private void iconbtnUpload_Click(object sender, EventArgs e)
        {
            if (txtFile.Text.Trim().Equals(""))
            {


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
                progressBar.Maximum = range.Rows.Count;
                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    string[] str = new string[3];
                    for (cCnt = 1; cCnt <= 3; cCnt++)
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
                    string _ID;

                    _ID = str[0].ToString();

                    if (!_ID.Equals(""))
                    {
                        bool _checkParentID;
                        bool _CheckExistID;
                        var rcInput = new WHS_TRANSFER_LOTTAG();
                        _CheckExistID = WHSTransferLottagDAL.Instance.CheckExistID(_ID);
                        _checkParentID = WHSTransferLottagDAL.Instance.checkParentID(_ID);

                        //-------WHS transfer IQC-----------
                        rcInput.ID = str[0].ToString().Trim();




                        //---------WHS keyin -----------

                        rcInput.Whs_In_By = str[1].ToString().Trim();
                        rcInput.Whs_In_Date = DateTime.Parse(str[2].ToString().Trim());
                        rcInput.Whs_In_CreatedBy = Program.UserId;



                        if (_checkParentID == true && _CheckExistID == true)
                        {
                            var RInfo = WHSTransferLottagDAL.Instance.getRecordInfo(rcInput.ID);
                            // Trường hợp này là chuyển từ WHS->IQC->Keyin
                            if (RInfo.Whs_CreatedBy != null &&
                                RInfo.Iqc_Lottag_Status != null &&
                                RInfo.Iqc_Check_Status != null &&
                                RInfo.Whs_In_CreatedDate == null)
                            {
                                rcInput.Whs_In_CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                rcInput.Whs_In_UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                WHSTransferLottagDAL.Instance.Update(rcInput, 3, 3);
                            }
                            // Trường hợp này là cập nhật trực tiếp WHS->Keyin
                            if (RInfo.Whs_CreatedBy == null &&
                                RInfo.Iqc_Lottag_Status == null &&
                                RInfo.Iqc_Check_Status == null &&
                                RInfo.Whs_In_CreatedDate != null)
                            {

                                rcInput.Whs_In_UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                WHSTransferLottagDAL.Instance.Update(rcInput, 3, 0);
                            }
                        }
                        // Thêm mới từ WHS->Keyin
                        if (_checkParentID == true && _CheckExistID == false)
                        {
                            rcInput.Whs_In_CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            rcInput.Whs_In_UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSTransferLottagDAL.Instance.Add(rcInput);
                        }
                    }
                    progressBar.Value = rCnt;
                    j = 0;
                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllWhsIn());
                txtFile.Text = "";
                progressBar.Visible = false;
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                CommonDAL.Instance.releaseObject(xlWorkSheet);
                CommonDAL.Instance.releaseObject(xlWorkBook);
                CommonDAL.Instance.releaseObject(xlApp);
            }
        }
        private void Search()
        {
            if (txtSearch.Text.Trim().Equals(""))
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllWhsIn());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllWhsIn(txtSearch.Text));
                dgView.Columns["ID"].ReadOnly = true;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Search();
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void iconbtnPaste_Click(object sender, EventArgs e)
        {
            try
            {
                DataObject o = (DataObject)Clipboard.GetDataObject();
                if (o.GetDataPresent(DataFormats.Text))
                {
                    dgView.Columns.Clear();
                    string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                    int totCols = pastedRows[0].Split(new char[] { '\t' }).Length;
                    dgView.Columns.Add("ID", "ID");
                    dgView.Columns.Add("Whs_In_By", "Whs_In_By");
                    dgView.Columns.Add("Whs_In_Date", "Whs_In_Date");

                    string[] pastedRowCells;
                    int newRowIndex;
                    foreach (string pastedRow in pastedRows)
                    {
                        pastedRowCells = pastedRow.Split(new char[] { '\t' });
                        newRowIndex = dgView.Rows.Add();
                        for (int i = 0; i < totCols; i++)
                        {
                            dgView.Rows[newRowIndex].Cells[i].Value = pastedRowCells[i];
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgView.Rows.Count > 0)
                {


                    foreach (DataGridViewRow row in dgView.Rows)
                    {
                        var rcInput = new WHS_TRANSFER_LOTTAG();
                        if (!row.IsNewRow)
                        {
                            rcInput.ID = row.Cells["ID"].Value.ToString();

                            //------------------


                            //------------------


                            //--------------------

                            rcInput.Whs_In_By = row.Cells["Whs_In_By"].Value.ToString();
                            rcInput.Whs_In_Date = DateTime.Parse(row.Cells["Whs_In_Date"].Value.ToString());
                            rcInput.Whs_In_CreatedBy = Program.UserId;


                            try
                            {
                                if (WHSTransferLottagDAL.Instance.checkParentID(rcInput.ID) == true &&
                                    WHSTransferLottagDAL.Instance.CheckExistID(rcInput.ID) == true)
                                {
                                    var RInfo = WHSTransferLottagDAL.Instance.getRecordInfo(rcInput.ID);
                                    // Trường hợp này là chuyển từ WHS->IQC->Keyin
                                    if (RInfo.Whs_CreatedBy != null &&
                                        RInfo.Iqc_Lottag_Status != null &&
                                        RInfo.Iqc_Check_Status != null)
                                    {
                                        rcInput.Whs_In_UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                        WHSTransferLottagDAL.Instance.Update(rcInput, 3, 0);
                                    }
                                    // Trường hợp này là cập nhật trực tiếp WHS->Keyin
                                    else if (RInfo.Whs_CreatedBy == null &&
                                        RInfo.Iqc_Lottag_Status == null &&
                                        RInfo.Iqc_Check_Status == null &&
                                        RInfo.Whs_In_CreatedBy != null)
                                    {

                                        rcInput.Whs_In_UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                        WHSTransferLottagDAL.Instance.Update(rcInput, 3, 0);
                                    }
                                    else
                                    {
                                        MessageBox.Show("WHS không nhận được hàng hãy kiểm tra lại số ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                // Thêm mới từ WHS->Keyin
                                if (WHSTransferLottagDAL.Instance.checkParentID(rcInput.ID) == true &&
                                    WHSTransferLottagDAL.Instance.CheckExistID(rcInput.ID) == false)
                                {
                                    rcInput.Whs_In_CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    rcInput.Whs_In_UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSTransferLottagDAL.Instance.Add(rcInput);
                                }


                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                    }
                }
                MessageBox.Show("Đã ghi xong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                disableButton(false);
                //clearDgView();
                //CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllIqcLottag());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SaveEditDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
