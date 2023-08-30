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
using DocumentFormat.OpenXml.Office2010.Excel;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace SMTPRORAM.Whs
{
    public partial class frmMonitorFedexDhlOther : Form
    {
        private List<SYS_UserButtonFunction> lstUBFunction;
        public frmMonitorFedexDhlOther()
        {
            InitializeComponent();
        }

        private void frmMonitorFedexDhlOther_Load(object sender, EventArgs e)
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
                    string[] str = new string[9];
                    for (cCnt = 1; cCnt <= 9; cCnt++)
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
                        var rcInput = new WHS_MONITOR_FEDEX_DHL_OTHER();
                        _CheckExistID = WHSMonitorFedexDhlOtherDAL.Instance.CheckExistID(_ID);
                        if (!_CheckExistID)
                        {
                            rcInput.ID = str[0].ToString().Trim();

                            if (str[1].ToString().Trim() == "" )
                            {
                                rcInput.FWR_TYPE = null;
                            }
                            else
                            {
                                rcInput.FWR_TYPE = str[1].ToString().Trim();
                            }
                            if (str[2].ToString().Trim() == "" )
                            {
                                rcInput.DATE = null;
                            }
                            else
                            {
                                rcInput.DATE = DateTime.Parse(str[2].ToString().Trim());
                            }
                            rcInput.SK_INVOICE = str[3].ToString().Trim();
                            rcInput.INVOICE_NAME = str[4].ToString().Trim();
                            rcInput.SUPPLIER_NAME = str[5].ToString().Trim();
                            rcInput.CTN = int.Parse(str[6].ToString().Trim());
                            rcInput.REMARK = str[7].ToString().Trim();
                            rcInput.REMARK2 = str[8].ToString().Trim();
                            
                            rcInput.CreatedBy = Program.username;
                            rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSMonitorFedexDhlOtherDAL.Instance.Add(rcInput);
                        }
                        else
                        {
                            rcInput.ID = str[0].ToString().Trim();

                            if (str[1].ToString().Trim() == "")
                            {
                                rcInput.FWR_TYPE = null;
                            }
                            else
                            {
                                rcInput.FWR_TYPE = str[1].ToString().Trim();
                            }
                            if (str[2].ToString().Trim() == "")
                            {
                                rcInput.DATE = null;
                            }
                            else
                            {
                                rcInput.DATE = DateTime.Parse(str[2].ToString().Trim());
                            }
                            rcInput.SK_INVOICE = str[3].ToString().Trim();
                            rcInput.INVOICE_NAME = str[4].ToString().Trim();
                            rcInput.SUPPLIER_NAME = str[5].ToString().Trim();
                            rcInput.CTN = int.Parse(str[6].ToString().Trim());
                            rcInput.REMARK = str[7].ToString().Trim();
                            rcInput.REMARK2 = str[8].ToString().Trim();

                            rcInput.CreatedBy = Program.username;                            
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSMonitorFedexDhlOtherDAL.Instance.Update(rcInput);
                        }


                    }
                    progressBar.Value = rCnt;
                    j = 0;
                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, WHSMonitorFedexDhlOtherDAL.Instance.getListAll());
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
                CommonDAL.Instance.ShowDataGridView(dgView, WHSMonitorFedexDhlOtherDAL.Instance.getListAll());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSMonitorFedexDhlOtherDAL.Instance.getListSearch(txtSearch.Text));
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
                    dgView.Columns.Add("FWR_TYPE", "FWR_TYPE");
                    dgView.Columns.Add("DATE", "DATE");
                    dgView.Columns.Add("SK_INVOICE", "SK_INVOICE");
                    dgView.Columns.Add("INVOICE_NAME", "INVOICE_NAME");
                    dgView.Columns.Add("SUPPLIER_NAME", "SUPPLIER_NAME");
                    dgView.Columns.Add("CTN", "CTN");
                    dgView.Columns.Add("REMARK", "REMARK");
                    dgView.Columns.Add("REMARK2", "REMARK2");                   

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
                        var rcInput = new WHS_MONITOR_FEDEX_DHL_OTHER();
                        if (!row.IsNewRow)
                        {
                            rcInput.ID = row.Cells["ID"].Value.ToString();


                            if (row.Cells["FWR_TYPE"].Value == null)
                            {
                                rcInput.FWR_TYPE = "";
                            }
                            else
                            {
                                rcInput.FWR_TYPE = row.Cells["FWR_TYPE"].Value.ToString();
                            }

                            if (row.Cells["DATE"].Value == null)
                            {
                                rcInput.DATE = null;
                            }
                            else
                            {
                                rcInput.DATE = DateTime.Parse(row.Cells["DATE"].Value.ToString());
                            }

                            if (string.IsNullOrEmpty(row.Cells["SK_INVOICE"].Value.ToString()))
                            {
                                rcInput.SK_INVOICE = "";
                            }
                            else
                            {
                                rcInput.SK_INVOICE = row.Cells["SK_INVOICE"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["INVOICE_NAME"].Value.ToString()))
                            {
                                rcInput.INVOICE_NAME = "";
                            }
                            else
                            {
                                rcInput.INVOICE_NAME = row.Cells["INVOICE_NAME"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["SUPPLIER_NAME"].Value.ToString()))
                            {
                                rcInput.SUPPLIER_NAME = "";
                            }
                            else
                            {
                                rcInput.SUPPLIER_NAME = row.Cells["SUPPLIER_NAME"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["CTN"].Value.ToString()))
                            {
                                rcInput.CTN = 0;
                            }
                            else
                            {
                                rcInput.CTN =int.Parse(row.Cells["CTN"].Value.ToString());
                            }

                            if (string.IsNullOrEmpty(row.Cells["REMARK"].Value.ToString()))
                            {
                                rcInput.REMARK = "";
                            }
                            else
                            {
                                rcInput.REMARK = row.Cells["REMARK"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["REMARK2"].Value.ToString()))
                            {
                                rcInput.REMARK2 = "";
                            }
                            else
                            {
                                rcInput.REMARK2 = row.Cells["REMARK2"].Value.ToString();
                            }
                            rcInput.CreatedBy = Program.UserId;
                            try
                            {
                                if (WHSMonitorFedexDhlOtherDAL.Instance.CheckExistID(rcInput.ID) == true)
                                {
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSMonitorFedexDhlOtherDAL.Instance.Update(rcInput);
                                }
                                else
                                {
                                    rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSMonitorFedexDhlOtherDAL.Instance.Add(rcInput);
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

        private void saveEditDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (iconbtnEditmode.Enabled==true)
            {
                if (dgView.RowCount > 0)
                {
                    
                    var updateRs = new WHS_MONITOR_FEDEX_DHL_OTHER();
                    DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                    updateRs.ID  = row.Cells["ID"].Value.ToString();
                    updateRs.FWR_TYPE = row.Cells["FWR_TYPE"].Value.ToString();
                    if (row.Cells["DATE"].Value == null)
                    {
                        updateRs.DATE = null;
                    }
                    else 
                    {
                        updateRs.DATE=DateTime.Parse( row.Cells["DATE"].Value.ToString()); 
                    }
                    if (row.Cells["SK_INVOICE"].Value == null)
                    {
                        updateRs.SK_INVOICE = "";
                    }
                    else
                    {
                        updateRs.SK_INVOICE = row.Cells["SK_INVOICE"].Value.ToString();
                    }
                    if (row.Cells["INVOICE_NAME"].Value == null)
                    {
                        updateRs.INVOICE_NAME = "";
                    }
                    else
                    {
                        updateRs.INVOICE_NAME = row.Cells["INVOICE_NAME"].Value.ToString();
                    }
                    if (row.Cells["SUPPLIER_NAME"].Value == null)
                    {
                        updateRs.SUPPLIER_NAME = "";
                    }
                    else
                    {
                        updateRs.SUPPLIER_NAME = row.Cells["SUPPLIER_NAME"].Value.ToString();
                    }
                    if (row.Cells["CTN"].Value == null)
                    {
                        updateRs.CTN = 0;
                    }
                    else
                    {
                        updateRs.CTN = int.Parse(row.Cells["CTN"].Value.ToString());
                    }
                    if (row.Cells["REMARK"].Value == null)
                    {
                        updateRs.REMARK = "";
                    }
                    else
                    {
                        updateRs.REMARK = row.Cells["REMARK"].Value.ToString();
                    }
                    if (row.Cells["REMARK2"].Value == null)
                    {
                        updateRs.REMARK2 = "";
                    }
                    else
                    {
                        updateRs.REMARK2 = row.Cells["REMARK2"].Value.ToString();
                    }
                    updateRs.CreatedBy = Program.UserId;
                    updateRs.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    bool result= WHSMonitorFedexDhlOtherDAL.Instance.Update(updateRs);
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

        private void dgView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgView.Columns["ID"].ReadOnly = true;
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count>0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                string ID = row.Cells["ID"].Value.ToString();
                bool result = WHSMonitorFedexDhlOtherDAL.Instance.Remove(ID);
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
    }
}
