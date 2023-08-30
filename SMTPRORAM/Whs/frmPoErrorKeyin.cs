using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.whs;
using UnidenDAL;
using UnidenDTO;
using Excel = Microsoft.Office.Interop.Excel;
using UnidenDAL.Whs;
using System.Text.RegularExpressions;
using UnidenDAL.SysControl;

namespace SMTPRORAM.Whs
{
    public partial class frmPoErrorKeyin : Form
    {
        private List<SYS_UserButtonFunction> lstUBFunction;
        public frmPoErrorKeyin()
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
                    string[] str = new string[14];
                    for (cCnt = 1; cCnt <= 14; cCnt++)
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
                        var rcInput = new WHS_PO_ERROR_KEYIN();
                        _CheckExistID = WHSPoErrorAndKeyinDAL.Instance.CheckExistID(_ID);
                        if (!_CheckExistID)
                        {
                            rcInput.ID = str[0].ToString().Trim();
                            
                            if (str[1].ToString().Trim() == "" || string.IsNullOrEmpty(str[1].ToString().Trim()))
                            {
                                rcInput.DELIVERY_DATE = null;
                            }
                            else
                            {
                                rcInput.DELIVERY_DATE = DateTime.Parse(str[1].ToString().Trim());
                            }
                           
                            rcInput.SUPPLIER_CODE = str[2].ToString().Trim();
                            rcInput.SUPPLIER_NAME = str[3].ToString().Trim();
                            rcInput.PARTSCODE = str[4].ToString().Trim();
                            rcInput.SANKYU_INVOIE = str[5].ToString().Trim();
                            rcInput.INVOICE_NO = str[6].ToString().Trim();
                            rcInput.PO_NO = str[7].ToString().Trim();
                            if (str[8].ToString().Trim() == "" )
                            {
                                rcInput.INVOICE_QTY = 0;
                            }
                            else
                            {
                                rcInput.INVOICE_QTY = long.Parse(str[8].ToString().Trim());
                            }
                            if (str[9].ToString().Trim() == "")
                            {
                                rcInput.KEYIN_QTY = 0;
                            }
                            else
                            {
                                rcInput.KEYIN_QTY = long.Parse(str[9].ToString().Trim());
                            }
                            if (str[10].ToString().Trim() == "")
                            {
                                rcInput.NO_KEYIN_QTY = 0;
                            }
                            else
                            {
                                rcInput.NO_KEYIN_QTY = long.Parse(str[10].ToString().Trim());
                            }

                           
                            rcInput.RESOLVED = str[11].ToString().Trim();
                            rcInput.STATUS = str[12].ToString().Trim();
                            if (str[13].ToString().Trim() == "" || string.IsNullOrEmpty(str[13].ToString().Trim()))
                            {
                                rcInput.FINISHED_DATE = null;
                            }
                            else
                            {
                                rcInput.FINISHED_DATE = DateTime.Parse(str[13].ToString().Trim());
                            }
                            rcInput.CreatedBy = Program.username;
                            rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSPoErrorAndKeyinDAL.Instance.Add(rcInput);
                        }
                        else
                        {
                            rcInput.ID = str[0].ToString().Trim();
                            if (str[1].ToString().Trim() == "" || string.IsNullOrEmpty(str[1].ToString().Trim()))
                            {
                                rcInput.DELIVERY_DATE = null;
                            }
                            else
                            {
                                rcInput.DELIVERY_DATE = DateTime.Parse(str[1].ToString().Trim());
                            }
                            rcInput.SUPPLIER_CODE = str[2].ToString().Trim();
                            rcInput.SUPPLIER_NAME = str[3].ToString().Trim();
                            rcInput.PARTSCODE = str[4].ToString().Trim();
                            rcInput.SANKYU_INVOIE = str[5].ToString().Trim();
                            rcInput.INVOICE_NO = str[6].ToString().Trim();
                            rcInput.PO_NO = str[7].ToString().Trim();
                            if (str[8].ToString().Trim() == "")
                            {
                                rcInput.INVOICE_QTY = 0;
                            }
                            else
                            {
                                rcInput.INVOICE_QTY = long.Parse(str[8].ToString().Trim());
                            }
                            if (str[9].ToString().Trim() == "")
                            {
                                rcInput.KEYIN_QTY = 0;
                            }
                            else
                            {
                                rcInput.KEYIN_QTY = long.Parse(str[9].ToString().Trim());
                            }
                            if (str[10].ToString().Trim() == "")
                            {
                                rcInput.NO_KEYIN_QTY = 0;
                            }
                            else
                            {
                                rcInput.NO_KEYIN_QTY = long.Parse(str[10].ToString().Trim());
                            }
                            rcInput.RESOLVED = str[11].ToString().Trim();
                            rcInput.STATUS = str[12].ToString().Trim();
                            if (str[13].ToString().Trim()==""|| string.IsNullOrEmpty(str[13].ToString().Trim()))
                            {
                                rcInput.FINISHED_DATE = null;
                            }
                            else
                            {
                                rcInput.FINISHED_DATE = DateTime.Parse(str[13].ToString().Trim());
                            }
                            
                            rcInput.CreatedBy = Program.username;
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSPoErrorAndKeyinDAL.Instance.Update(rcInput);
                        }
                        

                    }
                    progressBar.Value = rCnt;
                    j = 0;
                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, WHSPoErrorAndKeyinDAL.Instance.getAllPOError());
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
                CommonDAL.Instance.ShowDataGridView(dgView, WHSPoErrorAndKeyinDAL.Instance.getAllPOError());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSPoErrorAndKeyinDAL.Instance.getAllPOErrorBySearch(txtSearch.Text));
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
                    dgView.Columns.Add("DELIVERY_DATE", "DELIVERY_DATE");
                    dgView.Columns.Add("SUPPLIER_CODE", "SUPPLIER_CODE");
                    dgView.Columns.Add("SUPPLIER_NAME", "SUPPLIER_NAME");
                    dgView.Columns.Add("PARTSCODE", "PARTSCODE");
                    dgView.Columns.Add("SANKYU_INVOIE", "SANKYU_INVOIE");
                    dgView.Columns.Add("INVOICE_NO", "INVOICE_NO");
                    dgView.Columns.Add("PO_NO", "PO_NO");
                    dgView.Columns.Add("INVOICE_QTY", "INVOICE_QTY");
                    dgView.Columns.Add("KEYIN_QTY", "KEYIN_QTY");
                    dgView.Columns.Add("NO_KEYIN_QTY", "NO_KEYIN_QTY");
                    dgView.Columns.Add("RESOLVED", "RESOLVED");
                    dgView.Columns.Add("ID", "ID");
                    dgView.Columns.Add("STATUS", "STATUS");
                    dgView.Columns.Add("FINISHED_DATE", "FINISHED_DATE");
                    
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
                        var rcInput = new WHS_PO_ERROR_KEYIN();
                        if (!row.IsNewRow)
                        {
                            rcInput.ID = row.Cells["ID"].Value.ToString();


                            if (row.Cells["DELIVERY_DATE"].Value == null)
                            {
                                rcInput.DELIVERY_DATE = null;
                            }
                            else
                            {
                                rcInput.DELIVERY_DATE = DateTime.Parse(row.Cells["DELIVERY_DATE"].Value.ToString());
                            }

                            if (string.IsNullOrEmpty(row.Cells["SUPPLIER_CODE"].Value.ToString()))
                            {
                                rcInput.SUPPLIER_CODE = "";
                            }
                            else
                            {
                                rcInput.SUPPLIER_CODE = row.Cells["SUPPLIER_CODE"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["SUPPLIER_NAME"].Value.ToString()))
                            {
                                rcInput.SUPPLIER_NAME = "";
                            }
                            else
                            {
                                rcInput.SUPPLIER_NAME = row.Cells["SUPPLIER_NAME"].Value.ToString();
                            }


                            if (string.IsNullOrEmpty(row.Cells["PARTSCODE"].Value.ToString()))
                            {
                                rcInput.PARTSCODE = "";
                            }
                            else
                            {
                                rcInput.PARTSCODE = row.Cells["PARTSCODE"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["SANKYU_INVOIE"].Value.ToString()))
                            {
                                rcInput.SANKYU_INVOIE = "";
                            }
                            else
                            {
                                rcInput.SANKYU_INVOIE = row.Cells["SANKYU_INVOIE"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["INVOICE_NO"].Value.ToString()))
                            {
                                rcInput.INVOICE_NO = "";
                            }
                            else
                            {
                                rcInput.INVOICE_NO = row.Cells["INVOICE_NO"].Value.ToString();
                            }

                            if (string.IsNullOrEmpty(row.Cells["PO_NO"].Value.ToString()))
                            {
                                rcInput.PO_NO = "";
                            }
                            else
                            {
                                rcInput.PO_NO = row.Cells["PO_NO"].Value.ToString();
                            }



                            if (string.IsNullOrEmpty(row.Cells["INVOICE_QTY"].Value.ToString()) || row.Cells["INVOICE_QTY"].Value.ToString().Equals(""))
                            {
                                rcInput.INVOICE_QTY = 0;
                            }
                            else
                            {
                                rcInput.INVOICE_QTY = long.Parse(row.Cells["INVOICE_QTY"].Value.ToString());
                            }
                            if (string.IsNullOrEmpty(row.Cells["KEYIN_QTY"].Value.ToString()) || row.Cells["KEYIN_QTY"].Value.ToString().Equals(""))
                            {
                                rcInput.KEYIN_QTY = 0;
                            }
                            else
                            {
                                rcInput.KEYIN_QTY = long.Parse(row.Cells["KEYIN_QTY"].Value.ToString());
                            }
                            if (string.IsNullOrEmpty(row.Cells["NO_KEYIN_QTY"].Value.ToString()) || row.Cells["NO_KEYIN_QTY"].Value.ToString().Equals(""))
                            {
                                rcInput.NO_KEYIN_QTY = 0;
                            }
                            else
                            {
                                rcInput.NO_KEYIN_QTY = long.Parse(row.Cells["NO_KEYIN_QTY"].Value.ToString());
                            }
                            if (string.IsNullOrEmpty(row.Cells["RESOLVED"].Value.ToString()))
                            {
                                rcInput.RESOLVED = "";
                            }
                            else
                            {
                                rcInput.RESOLVED = row.Cells["RESOLVED"].Value.ToString();
                            }
                            if (string.IsNullOrEmpty(row.Cells["STATUS"].Value.ToString()))
                            {
                                rcInput.STATUS = "";
                            }
                            else
                            {
                                rcInput.STATUS = row.Cells["STATUS"].Value.ToString();
                            }


                            if (row.Cells["FINISHED_DATE"].Value == null)
                            {
                                rcInput.FINISHED_DATE = null;
                            }
                            else
                            {
                                rcInput.FINISHED_DATE = DateTime.Parse(row.Cells["FINISHED_DATE"].Value.ToString());
                            }

                            rcInput.CreatedBy = Program.UserId;



                            try
                            {
                                if (WHSPoErrorAndKeyinDAL.Instance.CheckExistID(rcInput.ID) == true)
                                {
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSPoErrorAndKeyinDAL.Instance.Update(rcInput);
                                }
                                else
                                {
                                    rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSPoErrorAndKeyinDAL.Instance.Add(rcInput);
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
        }

        private void frmPoErrorKeyin_Load(object sender, EventArgs e)
        {
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            iconbtnEnable.Enabled = false;
            iconbtnSave.Enabled = false;
            iconbtnPaste.Enabled = false;
        }
    }
}
