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
using Excel = Microsoft.Office.Interop.Excel;
using UnidenDAL.whs;

namespace SMTPRORAM.Whs
{
    public partial class frmWhs_Lottag_Iqc : Form
    {
        private List<SYS_UserButtonFunction> lstUBFunction;

        public frmWhs_Lottag_Iqc()
        {
            InitializeComponent();
        }

        private void frmWhs_Lottag_Iqc_Load(object sender, EventArgs e)
        {
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            iconbtnEnable.Enabled = false;
            iconbtnSave.Enabled = false;
            iconbtnPaste.Enabled = false;
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
            if (!txtFile.Text.Trim().Equals(""))
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

                        //------------------
                        rcInput.ID = str[0].ToString().Trim();
                        rcInput.Whs_Lottag_Iqc_Date = DateTime.Parse(str[1].ToString().Trim());
                        rcInput.Whs_Position = str[2].ToString().Trim();
                        rcInput.Whs_CreatedBy = Program.UserId;

                        //------------------
                        rcInput.Iqc_Lottag_Date = null;
                        rcInput.Iqc_Lottag_Status = null;
                        rcInput.Iqc_CreatedBy = null;
                        rcInput.Iqc_CreatedDate = null;
                        rcInput.Iqc_UpdateDate = null;
                        //------------------

                        rcInput.Iqc_Check_Status = null;
                        rcInput.Iqc_Check_Checker = null;
                        rcInput.Iqc_Check_Date = null;
                        rcInput.Iqc_Check_CreatedBy = null;
                        rcInput.Iqc_Check_CreatedDate = null;
                        rcInput.Iqc_Check_UpdatedDate = null;
                        //--------------------

                        rcInput.Whs_In_By = null;
                        rcInput.Whs_In_Date = null;
                        rcInput.Whs_In_CreatedBy = null;
                        rcInput.Whs_In_CreatedDate = null;
                        rcInput.Whs_In_UpdatedDate = null;

                        if (_checkParentID == true && _CheckExistID == false)
                        {
                            rcInput.Whs_CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            rcInput.Whs_UpdateDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSTransferLottagDAL.Instance.Add(rcInput);
                        }
                        if (_checkParentID == true && _CheckExistID == true)
                        {
                            rcInput.Whs_UpdateDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSTransferLottagDAL.Instance.Update(rcInput, 0, 0);
                        }
                    }
                    progressBar.Value = rCnt;
                    j = 0;
                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllWhsLottagIQC());
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
                CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllWhsLottagIQC());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllWhsLottagIQC(txtSearch.Text));
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
                foreach (DataGridViewRow row in dgView.Rows)
                {
                    var rcInput = new WHS_TRANSFER_LOTTAG();
                    if (!row.IsNewRow)
                    {
                        rcInput.ID = row.Cells["ID"].Value.ToString();
                        rcInput.Whs_Lottag_Iqc_Date = DateTime.Parse(row.Cells["Whs_Lottag_Iqc_Date"].Value.ToString());
                        rcInput.Whs_Position = row.Cells["Whs_Position"].Value.ToString();
                        rcInput.Whs_CreatedBy = Program.UserId;
                        rcInput.Whs_CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        rcInput.Whs_UpdateDate = CommonDAL.Instance.getSqlServerDatetime();
                        //------------------
                        rcInput.Iqc_Lottag_Date = null;
                        rcInput.Iqc_Lottag_Status = null;
                        rcInput.Iqc_CreatedBy = null;
                        rcInput.Iqc_CreatedDate = null;
                        rcInput.Iqc_UpdateDate = null;
                        //------------------

                        rcInput.Iqc_Check_Status = null;
                        rcInput.Iqc_Check_Checker = null;
                        rcInput.Iqc_Check_Date = null;
                        rcInput.Iqc_Check_CreatedBy = null;
                        rcInput.Iqc_Check_CreatedDate = null;
                        rcInput.Iqc_Check_UpdatedDate = null;

                        //--------------------

                        rcInput.Whs_In_By = null;
                        rcInput.Whs_In_Date = null;
                        rcInput.Whs_In_CreatedBy = null;
                        rcInput.Whs_In_CreatedDate = null;
                        rcInput.Whs_In_UpdatedDate = null;

                        try
                        {
                            if (WHSTransferLottagDAL.Instance.checkParentID(rcInput.ID) == true &&
                                WHSTransferLottagDAL.Instance.CheckExistID(rcInput.ID) == true)
                            {
                                rcInput.Whs_UpdateDate = CommonDAL.Instance.getSqlServerDatetime();
                                WHSTransferLottagDAL.Instance.Update(rcInput, 0, 0);
                            }
                            if (WHSTransferLottagDAL.Instance.checkParentID(rcInput.ID) == true &&
                                 WHSTransferLottagDAL.Instance.CheckExistID(rcInput.ID) == false)
                            {
                                rcInput.Whs_CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                rcInput.Whs_UpdateDate = CommonDAL.Instance.getSqlServerDatetime();
                                WHSTransferLottagDAL.Instance.Add(rcInput);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                MessageBox.Show("Đã ghi xong dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSTransferLottagDAL.Instance.getAllWhsLottagIQC());
                disableButton(false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void disableButton(bool t)
        {
            iconbtnEditmode.Enabled = !t;
            iconbtnEnable.Enabled = t;
            iconbtnSave.Enabled = t;
            iconbtnPaste.Enabled = t;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
