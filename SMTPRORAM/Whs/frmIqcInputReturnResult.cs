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
using UnidenDAL.Whs;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace SMTPRORAM.Whs
{
    public partial class frmIqcInputReturnResult : Form
    {
        private List<SYS_UserButtonFunction> lstUBFunction;
        public frmIqcInputReturnResult()
        {
            InitializeComponent();
        }

        private void frmIqcInputReturnResult_Load(object sender, EventArgs e)
        {
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            iconbtnEnable.Enabled = false;
            iconbtnSave.Enabled = false;
            iconbtnPaste.Enabled = false;
            iconbtnDelete.Enabled = false;
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
                    string _ID;

                    _ID = str[0].ToString();

                    if (!_ID.Equals(""))
                    {
                        bool _CheckExistID;
                        var rcInput = new WHS_IQC_INPUT_RETURN_RESULT();
                        _CheckExistID = WHSIqcInputReturnResultDAL.Instance.CheckExistID(_ID);
                        if (!_CheckExistID)
                        {
                            rcInput.ID = str[0].ToString().Trim();
                            rcInput.PARTCODE = str[1].ToString().Trim();
                            rcInput.IQCRESULT = str[2].ToString().Trim().ToUpper();
                            
                            if (str[3].ToString().Trim() == "")
                            {
                                rcInput.CHECKEDDATE = null;
                            }
                            else
                            {
                                rcInput.CHECKEDDATE = DateTime.Parse(str[3].ToString().Trim());
                            }
                            if (str[4].ToString().Trim() == "")
                            {
                                rcInput.RETURNDDATE = null;
                            }
                            else
                            {
                                rcInput.RETURNDDATE = DateTime.Parse(str[4].ToString().Trim());
                            }                          

                            rcInput.CreatedBy = Program.username;
                            rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSIqcInputReturnResultDAL.Instance.Add(rcInput);
                        }
                        else
                        {
                            rcInput.ID = str[0].ToString().Trim();
                            rcInput.PARTCODE = str[1].ToString().Trim();
                            rcInput.IQCRESULT = str[2].ToString().Trim();

                            if (str[3].ToString().Trim() == "")
                            {
                                rcInput.CHECKEDDATE = null;
                            }
                            else
                            {
                                rcInput.CHECKEDDATE = DateTime.Parse(str[3].ToString().Trim());
                            }
                            if (str[4].ToString().Trim() == "")
                            {
                                rcInput.RETURNDDATE = null;
                            }
                            else
                            {
                                rcInput.RETURNDDATE = DateTime.Parse(str[4].ToString().Trim());
                            }

                            rcInput.CreatedBy = Program.username;                            
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSIqcInputReturnResultDAL.Instance.Update(rcInput);
                        }
                    }
                    
                    progressBar.Value = rCnt;
                    j = 0;
                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, WHSIqcInputReturnResultDAL.Instance.getListAll());
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
                CommonDAL.Instance.ShowDataGridView(dgView, WHSInputIqcReturnDAL.Instance.getListAll());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSInputIqcReturnDAL.Instance.getListSearch(txtSearch.Text));
                dgView.Columns["ID"].ReadOnly = true;
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Search();
        }

        private void iconbtnEditmode_Click(object sender, EventArgs e)
        {
            iconbtnEnable.Enabled = true;
            dgView.ReadOnly = false;
            iconbtnSave.Enabled = true;
            iconbtnPaste.Enabled = true;
            iconbtnDelete.Enabled = true;
        }

        private void iconbtnEnable_Click(object sender, EventArgs e)
        {
            CommonDAL.Instance.ClearDataGridView(dgView);
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
                    dgView.Columns.Add("PARTCODE", "PARTCODE");
                    dgView.Columns.Add("IQCRESULT", "IQCRESULT");
                    dgView.Columns.Add("CHECKEDDATE", "CHECKEDDATE");
                    dgView.Columns.Add("RETURNDDATE", "RETURNDDATE");                    

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
                        var rcInput = new WHS_IQC_INPUT_RETURN_RESULT();
                        if (!row.IsNewRow)
                        {
                            rcInput.ID = row.Cells["ID"].Value.ToString();
                            if (row.Cells["PARTCODE"].Value == null || row.Cells["PARTCODE"].Value.ToString() == "")
                            {
                                rcInput.PARTCODE = "";
                            }
                            else
                            {
                                rcInput.PARTCODE = row.Cells["PARTCODE"].Value.ToString();
                            }
                            if (row.Cells["IQCRESULT"].Value == null || row.Cells["IQCRESULT"].Value.ToString() == "")
                            {
                                rcInput.IQCRESULT = "";
                            }
                            else
                            {
                                rcInput.IQCRESULT = row.Cells["IQCRESULT"].Value.ToString().ToUpper();
                            }
                            if (row.Cells["CHECKEDDATE"].Value == null|| row.Cells["CHECKEDDATE"].Value.ToString() == "")
                            {
                                rcInput.CHECKEDDATE = null;
                            }
                            else
                            {
                                rcInput.CHECKEDDATE = DateTime.Parse(row.Cells["CHECKEDDATE"].Value.ToString());
                            }
                            if (row.Cells["RETURNDDATE"].Value == null || row.Cells["RETURNDDATE"].Value.ToString()=="")
                            {
                                rcInput.RETURNDDATE = null;
                            }
                            else
                            {
                                rcInput.RETURNDDATE = DateTime.Parse(row.Cells["RETURNDDATE"].Value.ToString());
                            }

                            rcInput.CreatedBy = Program.UserId;
                            try
                            {
                                if (WHSIqcInputReturnResultDAL.Instance.CheckExistID(rcInput.ID) == true)
                                {
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSIqcInputReturnResultDAL.Instance.Update(rcInput);
                                }
                                else
                                {
                                    rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSIqcInputReturnResultDAL.Instance.Add(rcInput);
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
        private void disableButton(bool t)
        {
            iconbtnEditmode.Enabled = !t;
            iconbtnEnable.Enabled = t;
            iconbtnSave.Enabled = t;
            iconbtnPaste.Enabled = t;
            iconbtnDelete.Enabled = t;
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                string ID = row.Cells["ID"].Value.ToString();
                bool result = WHSIqcInputReturnResultDAL.Instance.Remove(ID);
                if (result)
                {
                    MessageBox.Show("Đã xóa xong !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Không xóa được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void saveEditDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iconbtnEditmode.Enabled == true)
            {
                if (dgView.RowCount > 0)
                {

                    var updateRs = new WHS_IQC_INPUT_RETURN_RESULT();
                    DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                    updateRs.ID = row.Cells["ID"].Value.ToString();                    
                    if (row.Cells["PARTCODE"].Value == null)
                    {
                        updateRs.PARTCODE = "";
                    }
                    else
                    {
                        updateRs.PARTCODE = row.Cells["PARTCODE"].Value.ToString();
                    }
                    if (row.Cells["IQCRESULT"].Value == null)
                    {
                        updateRs.IQCRESULT = "";
                    }
                    else
                    {
                        updateRs.IQCRESULT = row.Cells["IQCRESULT"].Value.ToString();
                    }

                   
                    if (row.Cells["CHECKEDDATE"].Value == null)
                    {
                        updateRs.CHECKEDDATE = null;
                    }
                    else
                    {
                        updateRs.CHECKEDDATE = DateTime.Parse(row.Cells["CHECKEDDATE"].Value.ToString());
                    }

                    if (row.Cells["RETURNDDATE"].Value == null)
                    {
                        updateRs.RETURNDDATE = null;
                    }
                    else
                    {
                        updateRs.RETURNDDATE = DateTime.Parse(row.Cells["RETURNDDATE"].Value.ToString());
                    }
                    
                    updateRs.CreatedBy = Program.UserId;
                    updateRs.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    bool result = WHSIqcInputReturnResultDAL.Instance.Update(updateRs);
                    if (result)
                    {
                        MessageBox.Show("Update thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Update không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có quyền lưu dữ liệu này ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
