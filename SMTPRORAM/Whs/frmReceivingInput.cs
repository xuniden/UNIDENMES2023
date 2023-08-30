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
using UnidenDAL.SysControl;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace SMTPRORAM.Whs
{
    public partial class frmReceivingInput : Form
    {
        public static List<WHS_RECEIVING_INPUT> lst;
        public static List<WHS_LOCATION> lstLoc;
        private List<SYS_UserButtonFunction> lstUBFunction;
        public frmReceivingInput()
        {
            InitializeComponent();
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgView.Rows.Count > 0)
                {


                    foreach (DataGridViewRow row in dgView.Rows)
                    {
                        var RecInput = new WHS_RECEIVING_INPUT();
                        if (!row.IsNewRow)
                        {
                            RecInput.ID = row.Cells["ID"].Value.ToString();
                            RecInput.SK_INVOICE = row.Cells["SK_INVOICE"].Value.ToString();
                            RecInput.RECEIVED_DATE = DateTime.Parse(row.Cells["RECEIVED_DATE"].Value.ToString());
                            RecInput.SUPPLIER_INVOICE = row.Cells["SUPPLIER_INVOICE"].Value.ToString();
                            RecInput.SUPPLIER = row.Cells["SUPPLIER"].Value.ToString();
                            RecInput.SUPPLIER_CODE = row.Cells["SUPPLIER_CODE"].Value.ToString();
                            RecInput.SUPPLIER_GROUP = row.Cells["SUPPLIER_GROUP"].Value.ToString();
                            RecInput.PARTS_CODE = row.Cells["PARTS_CODE"].Value.ToString();
                            RecInput.PARTS_DESC = row.Cells["PARTS_DESC"].Value.ToString();
                            RecInput.PARTS_SPEC = row.Cells["PARTS_SPEC"].Value.ToString();
                            RecInput.PURCHASE_ORDER = row.Cells["PURCHASE_ORDER"].Value.ToString();
                            RecInput.QTY = long.Parse(row.Cells["QTY"].Value.ToString());
                            RecInput.VLOCATION = row.Cells["VLOCATION"].Value.ToString();
                            RecInput.IQC_STATUS = row.Cells["IQC_STATUS"].Value.ToString();
                            RecInput.ONHAND = row.Cells["ONHAND"].Value.ToString().Equals("") ? 0 : long.Parse(row.Cells["ONHAND"].Value.ToString());
                            if (row.Cells["USE_DATE"].Value == null || row.Cells["USE_DATE"].Value.ToString().Equals(""))
                            {
                                RecInput.USE_DATE = null;
                            }
                            else
                            {
                                RecInput.USE_DATE = DateTime.Parse(row.Cells["USE_DATE"].Value.ToString());
                            }
                            RecInput.LOT_NO = row.Cells["LOT_NO"].Value.ToString();
                            RecInput.REMARK = row.Cells["REMARK"].Value.ToString();

                            RecInput.CreatedBy = Program.UserId;
                            try
                            {
                                if (WHSReceivingInputDAL.Instance.CheckExistID(RecInput.ID))
                                {
                                    RecInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSReceivingInputDAL.Instance.Update(RecInput);
                                }
                                else
                                {
                                    RecInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    RecInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSReceivingInputDAL.Instance.Add(RecInput);
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
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmReceivingInput_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);

            dgView.ReadOnly = true;
            iconbtnEnable.Enabled = false;
            iconbtnSave.Enabled = false;
            iconbtnViewReport.Enabled = false;
            iconbtnPaste.Enabled = false;
        }

        private void iconbtnViewReport_Click(object sender, EventArgs e)
        {
            var lstPrint = new List<WHS_RECEIVING_INPUT>();
            if (dgView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgView.Rows)
                {
                    var RecInput = new WHS_RECEIVING_INPUT();
                    if (!row.IsNewRow)
                    {
                        RecInput.ID = row.Cells["ID"].Value.ToString();
                        RecInput.SK_INVOICE = row.Cells["SK_INVOICE"].Value.ToString();
                        RecInput.RECEIVED_DATE = DateTime.Parse(row.Cells["RECEIVED_DATE"].Value.ToString());
                        RecInput.SUPPLIER_INVOICE = row.Cells["SUPPLIER_INVOICE"].Value.ToString();
                        RecInput.SUPPLIER = row.Cells["SUPPLIER"].Value.ToString();
                        RecInput.SUPPLIER_CODE = row.Cells["SUPPLIER_CODE"].Value.ToString();
                        RecInput.SUPPLIER_GROUP = row.Cells["SUPPLIER_GROUP"].Value.ToString();
                        RecInput.PARTS_CODE = row.Cells["PARTS_CODE"].Value.ToString();
                        RecInput.PARTS_DESC = row.Cells["PARTS_DESC"].Value.ToString();
                        RecInput.PARTS_SPEC = row.Cells["PARTS_SPEC"].Value.ToString();
                        RecInput.PURCHASE_ORDER = row.Cells["PURCHASE_ORDER"].Value.ToString();
                        RecInput.QTY = long.Parse(row.Cells["QTY"].Value.ToString());
                        RecInput.VLOCATION = row.Cells["VLOCATION"].Value.ToString();
                        RecInput.IQC_STATUS = row.Cells["IQC_STATUS"].Value.ToString();
                        RecInput.ONHAND = row.Cells["ONHAND"].Value.ToString().Equals("") ? 0 : long.Parse(row.Cells["ONHAND"].Value.ToString());
                        if (row.Cells["USE_DATE"].Value == null || row.Cells["USE_DATE"].Value.ToString().Equals(""))
                        {
                            RecInput.USE_DATE = null;
                        }
                        else
                        {
                            RecInput.USE_DATE = DateTime.Parse(row.Cells["USE_DATE"].Value.ToString());
                        }
                        RecInput.LOT_NO = row.Cells["LOT_NO"].Value.ToString();
                        RecInput.REMARK = row.Cells["REMARK"].Value.ToString();
                        lstPrint.Add(RecInput);
                    }

                }
                lst = lstPrint;
                frmViewLottagReport Child = new frmViewLottagReport();
                Child.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            if (!txtFile.Text.Equals(""))
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
                    string[] str = new string[18];
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
                    string _ID;

                    _ID = str[0].ToString();

                    if (!_ID.Equals(""))
                    {

                        bool _CheckExistID;
                        var rcInput = new WHS_RECEIVING_INPUT();
                        _CheckExistID = WHSReceivingInputDAL.Instance.CheckExistID(_ID);

                        rcInput.ID = str[0].ToString().Trim();
                        rcInput.SK_INVOICE = str[1].ToString().Trim();
                        rcInput.RECEIVED_DATE = DateTime.Parse(str[2].ToString().Trim());
                        rcInput.SUPPLIER_INVOICE = str[3].ToString().Trim();
                        rcInput.SUPPLIER = str[4].ToString().Trim();
                        rcInput.SUPPLIER_CODE = str[5].ToString().Trim();
                        rcInput.SUPPLIER_GROUP = str[6].ToString().Trim();
                        rcInput.PARTS_CODE = str[7].ToString().Trim();
                        rcInput.PARTS_DESC = str[8].ToString().Trim();
                        rcInput.PARTS_SPEC = str[9].ToString().Trim();
                        rcInput.PURCHASE_ORDER = str[10].ToString().Trim();
                        rcInput.QTY = long.Parse(str[11].ToString().Trim());
                        rcInput.VLOCATION = str[12].ToString().Trim();
                        rcInput.IQC_STATUS = str[13].ToString().Trim();
                        rcInput.ONHAND = str[14].ToString().Trim().Equals("") ? 0 : long.Parse(str[14].ToString().Trim());
                        if (str[15].ToString().Trim().Equals("") || string.IsNullOrEmpty(str[15].ToString().Trim()))
                        {
                            rcInput.USE_DATE = null;
                        }
                        else
                        {
                            rcInput.USE_DATE = DateTime.Parse(str[15].ToString().Trim());
                        }

                        rcInput.LOT_NO = str[16].ToString().Trim();
                        rcInput.REMARK = str[17].ToString().Trim();

                        rcInput.CreatedBy = Program.UserId;
                        if (_CheckExistID == false)
                        {
                            rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSReceivingInputDAL.Instance.Add(rcInput);
                        }
                        else
                        {
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSReceivingInputDAL.Instance.Update(rcInput);
                        }
                    }
                    progressBar.Value = rCnt;
                    j = 0;

                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, WHSReceivingInputDAL.Instance.getAllInput());
                //DisplayViewData();
                txtFile.Text = "";
                progressBar.Visible = false;
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                CommonDAL.Instance.releaseObject(xlWorkSheet);
                CommonDAL.Instance.releaseObject(xlWorkBook);
                CommonDAL.Instance.releaseObject(xlApp);
            }
        }

        private void iconbtnEnable_Click(object sender, EventArgs e)
        {
            CommonDAL.Instance.ClearDataGridView(dgView);
        }
        private void checkGridView()
        {
            if (iconbtnEditmode.Enabled == true)
            {
                dgView.ReadOnly = false;
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Equals(""))
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSReceivingInputDAL.Instance.getAllInput());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {

                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSReceivingInputDAL.Instance.getAllInput(txtSearch.Text));
                dgView.Columns["ID"].ReadOnly = true;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (txtSearch.Text.Trim().Equals(""))
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSReceivingInputDAL.Instance.getAllInput());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSReceivingInputDAL.Instance.getAllInput(txtSearch.Text));
                dgView.Columns["ID"].ReadOnly = true;
            }
        }

        private void iconbtnEditmode_Click(object sender, EventArgs e)
        {
            iconbtnEnable.Enabled = true;
            dgView.ReadOnly = false;
            iconbtnSave.Enabled = true;
            iconbtnViewReport.Enabled = true;
            iconbtnPaste.Enabled = true;
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
                    dgView.Columns.Add("SK_INVOICE", "SK_INVOICE");
                    dgView.Columns.Add("RECEIVED_DATE", "RECEIVED_DATE");
                    dgView.Columns.Add("SUPPLIER_INVOICE", "SUPPLIER_INVOICE");
                    dgView.Columns.Add("SUPPLIER", "SUPPLIER");
                    dgView.Columns.Add("SUPPLIER_CODE", "SUPPLIER_CODE");
                    dgView.Columns.Add("SUPPLIER_GROUP", "SUPPLIER_GROUP");
                    dgView.Columns.Add("PARTS_CODE", "PARTS_CODE");
                    dgView.Columns.Add("PARTS_DESC", "PARTS_DESC");
                    dgView.Columns.Add("PARTS_SPEC", "PARTS_SPEC");
                    dgView.Columns.Add("PURCHASE_ORDER", "PURCHASE_ORDER");
                    dgView.Columns.Add("QTY", "QTY");
                    dgView.Columns.Add("VLOCATION", "VLOCATION");
                    dgView.Columns.Add("IQC_STATUS", "IQC_STATUS");
                    dgView.Columns.Add("ONHAND", "ONHAND");
                    dgView.Columns.Add("USE_DATE", "USE_DATE");
                    dgView.Columns.Add("LOT_NO", "LOT_NO");
                    dgView.Columns.Add("REMARK", "REMARK");
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

        private void iconbtnIqcLabel_Click(object sender, EventArgs e)
        {
            var lstPrint = new List<WHS_RECEIVING_INPUT>();
            if (dgView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgView.Rows)
                {
                    var RecInput = new WHS_RECEIVING_INPUT();
                    if (!row.IsNewRow)
                    {
                        RecInput.ID = row.Cells["ID"].Value.ToString();
                        RecInput.SK_INVOICE = row.Cells["SK_INVOICE"].Value.ToString();
                        RecInput.RECEIVED_DATE = DateTime.Parse(row.Cells["RECEIVED_DATE"].Value.ToString());
                        RecInput.SUPPLIER_INVOICE = row.Cells["SUPPLIER_INVOICE"].Value.ToString();
                        RecInput.SUPPLIER = row.Cells["SUPPLIER"].Value.ToString();
                        RecInput.SUPPLIER_CODE = row.Cells["SUPPLIER_CODE"].Value.ToString();
                        RecInput.SUPPLIER_GROUP = row.Cells["SUPPLIER_GROUP"].Value.ToString();
                        RecInput.PARTS_CODE = row.Cells["PARTS_CODE"].Value.ToString();
                        RecInput.PARTS_DESC = row.Cells["PARTS_DESC"].Value.ToString();
                        RecInput.PARTS_SPEC = row.Cells["PARTS_SPEC"].Value.ToString();
                        RecInput.PURCHASE_ORDER = row.Cells["PURCHASE_ORDER"].Value.ToString();
                        RecInput.QTY = long.Parse(row.Cells["QTY"].Value.ToString());
                        RecInput.VLOCATION = row.Cells["VLOCATION"].Value.ToString();
                        RecInput.IQC_STATUS = row.Cells["IQC_STATUS"].Value.ToString();
                        RecInput.ONHAND = row.Cells["ONHAND"].Value.ToString().Equals("") ? 0 : long.Parse(row.Cells["ONHAND"].Value.ToString());
                        if (row.Cells["USE_DATE"].Value == null || row.Cells["USE_DATE"].Value.ToString().Equals(""))
                        {
                            RecInput.USE_DATE = null;
                        }
                        else
                        {
                            RecInput.USE_DATE = DateTime.Parse(row.Cells["USE_DATE"].Value.ToString());
                        }
                        RecInput.LOT_NO = row.Cells["LOT_NO"].Value.ToString();
                        RecInput.REMARK = row.Cells["REMARK"].Value.ToString();
                        lstPrint.Add(RecInput);
                    }

                }
                lst = lstPrint;
                frmInLottagIqcLabel Child = new frmInLottagIqcLabel();
                Child.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void iconbtnInlistreturn_Click(object sender, EventArgs e)
        {
            var lstPrint = new List<WHS_RECEIVING_INPUT>();
            if (dgView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgView.Rows)
                {
                    var RecInput = new WHS_RECEIVING_INPUT();
                    if (!row.IsNewRow)
                    {
                        RecInput.ID = row.Cells["ID"].Value.ToString();
                        RecInput.SK_INVOICE = row.Cells["SK_INVOICE"].Value.ToString();
                        RecInput.RECEIVED_DATE = DateTime.Parse(row.Cells["RECEIVED_DATE"].Value.ToString());
                        RecInput.SUPPLIER_INVOICE = row.Cells["SUPPLIER_INVOICE"].Value.ToString();
                        RecInput.SUPPLIER = row.Cells["SUPPLIER"].Value.ToString();
                        RecInput.SUPPLIER_CODE = row.Cells["SUPPLIER_CODE"].Value.ToString();
                        RecInput.SUPPLIER_GROUP = row.Cells["SUPPLIER_GROUP"].Value.ToString();
                        RecInput.PARTS_CODE = row.Cells["PARTS_CODE"].Value.ToString();
                        RecInput.PARTS_DESC = row.Cells["PARTS_DESC"].Value.ToString();
                        RecInput.PARTS_SPEC = row.Cells["PARTS_SPEC"].Value.ToString();
                        RecInput.PURCHASE_ORDER = row.Cells["PURCHASE_ORDER"].Value.ToString();
                        RecInput.QTY = long.Parse(row.Cells["QTY"].Value.ToString());
                        RecInput.VLOCATION = row.Cells["VLOCATION"].Value.ToString();
                        RecInput.IQC_STATUS = row.Cells["IQC_STATUS"].Value.ToString();
                        RecInput.ONHAND = row.Cells["ONHAND"].Value.ToString().Equals("") ? 0 : long.Parse(row.Cells["ONHAND"].Value.ToString());
                        if (row.Cells["USE_DATE"].Value == null || row.Cells["USE_DATE"].Value.ToString().Equals(""))
                        {
                            RecInput.USE_DATE = null;
                        }
                        else
                        {
                            RecInput.USE_DATE = DateTime.Parse(row.Cells["USE_DATE"].Value.ToString());
                        }
                        RecInput.LOT_NO = row.Cells["LOT_NO"].Value.ToString();
                        RecInput.REMARK = row.Cells["REMARK"].Value.ToString();
                        lstPrint.Add(RecInput);
                    }

                }
                lst = lstPrint;
                frmViewInListReturn Child = new frmViewInListReturn();
                Child.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var lstPrint = new List<WHS_RECEIVING_INPUT>();
            var lstLocation = new List<WHS_LOCATION>();
            if (dgView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgView.Rows)
                {
                    var RecInput = new WHS_RECEIVING_INPUT();
                    var Relocation = new WHS_LOCATION();
                    if (!row.IsNewRow)
                    {
                        RecInput.ID = row.Cells["ID"].Value.ToString();
                        RecInput.SK_INVOICE = row.Cells["SK_INVOICE"].Value.ToString();
                        RecInput.RECEIVED_DATE = DateTime.Parse(row.Cells["RECEIVED_DATE"].Value.ToString());
                        RecInput.SUPPLIER_INVOICE = row.Cells["SUPPLIER_INVOICE"].Value.ToString();
                        RecInput.SUPPLIER = row.Cells["SUPPLIER"].Value.ToString();
                        RecInput.SUPPLIER_CODE = row.Cells["SUPPLIER_CODE"].Value.ToString();
                        RecInput.SUPPLIER_GROUP = row.Cells["SUPPLIER_GROUP"].Value.ToString();
                        RecInput.PARTS_CODE = row.Cells["PARTS_CODE"].Value.ToString(); 
                        RecInput.PARTS_DESC = row.Cells["PARTS_DESC"].Value.ToString();
                        RecInput.PARTS_SPEC = row.Cells["PARTS_SPEC"].Value.ToString();
                        RecInput.PURCHASE_ORDER = row.Cells["PURCHASE_ORDER"].Value.ToString();
                        RecInput.QTY = long.Parse(row.Cells["QTY"].Value.ToString());
                        RecInput.VLOCATION = row.Cells["VLOCATION"].Value.ToString();
                        RecInput.IQC_STATUS = row.Cells["IQC_STATUS"].Value.ToString();
                        RecInput.ONHAND = row.Cells["ONHAND"].Value.ToString().Equals("") ? 0 : long.Parse(row.Cells["ONHAND"].Value.ToString());
                        if (row.Cells["USE_DATE"].Value == null || row.Cells["USE_DATE"].Value.ToString().Equals(""))
                        {
                            RecInput.USE_DATE = null;
                        }
                        else
                        {
                            RecInput.USE_DATE = DateTime.Parse(row.Cells["USE_DATE"].Value.ToString());
                        }
                        RecInput.LOT_NO = row.Cells["LOT_NO"].Value.ToString();
                        RecInput.REMARK = row.Cells["REMARK"].Value.ToString();
                        lstPrint.Add(RecInput);
                        var loc  = WHSLocationDAL.Instance.getKeyPersonByPartcode(RecInput.PARTS_CODE);
                        Relocation.ID = loc.ID;
                        Relocation.LocationCode = loc.LocationCode;
                        Relocation.Partcode = loc.Partcode;
                        Relocation.Position = loc.Position;
                        Relocation.Groups = loc.Groups;
                        Relocation.KeyPerson = loc.KeyPerson;
                        Relocation.Remark= loc.Remark;
                        Relocation.CreatedBy = loc.CreatedBy;
                        Relocation.CreatedDate = loc.CreatedDate;
                        Relocation.UpdatedDate = loc.UpdatedDate;
                        lstLocation.Add(Relocation);
                        
                    }

                }
                lst = lstPrint;
                lstLoc = lstLocation;
                frmViewReceivingInListGiaoHang Child = new frmViewReceivingInListGiaoHang();
                Child.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
