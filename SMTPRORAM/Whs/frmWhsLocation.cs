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
using System.Text.RegularExpressions;

namespace SMTPRORAM.Whs
{
    public partial class frmWhsLocation : Form
    {

        public static List<WHS_LOCATION> lst;
        private List<SYS_UserButtonFunction> lstUBFunction;

        public frmWhsLocation()
        {
            InitializeComponent();
        }

        private void frmWhsLocation_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem button có được enable hay không?
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
                    string[] str = new string[6];
                    for (cCnt = 1; cCnt <= 6; cCnt++)
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
                        var rcInput = new WHS_LOCATION();
                        _CheckExistID = WHSLocationDAL.Instance.CheckExistID(_ID);

                        rcInput.LocationCode = str[0].ToString().Trim();
                        rcInput.Partcode = str[1].ToString().Trim();
                        rcInput.Position = str[2].ToString().Trim();
                        rcInput.Groups = str[3].ToString().Trim();
                        rcInput.KeyPerson = str[4].ToString().Trim();
                        rcInput.Remark = str[5].ToString().Trim();
                        if (string.IsNullOrEmpty(str[5].ToString().Trim()) || str[5].ToString().Trim().Equals(""))
                        {
                            rcInput.Remark = "";
                        }
                        else
                        {
                            rcInput.Remark = str[5].ToString().Trim();
                        }
                        rcInput.CreatedBy = Program.UserId;
                        if (_CheckExistID == false)
                        {
                            rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSLocationDAL.Instance.Add(rcInput);
                        }
                        else
                        {
                            rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                            WHSLocationDAL.Instance.Update(rcInput);
                        }
                    }
                    progressBar.Value = rCnt;
                    j = 0;

                }
                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, WHSLocationDAL.Instance.getAllInput());
                txtFile.Text = "";
                progressBar.Visible = false;
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                CommonDAL.Instance.releaseObject(xlWorkSheet);
                CommonDAL.Instance.releaseObject(xlWorkBook);
                CommonDAL.Instance.releaseObject(xlApp);
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Equals(""))
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSLocationDAL.Instance.getAllInput());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSLocationDAL.Instance.getAllInput(txtSearch.Text));
                dgView.Columns["ID"].ReadOnly = true;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Trim().Equals(""))
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSLocationDAL.Instance.getAllInput());
                dgView.Columns["ID"].ReadOnly = true;
            }
            else
            {
                CommonDAL.Instance.ClearDataGridView(dgView);
                CommonDAL.Instance.ShowDataGridView(dgView, WHSLocationDAL.Instance.getAllInput(txtSearch.Text));
                dgView.Columns["ID"].ReadOnly = true;
            }
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
                    dgView.Columns.Add("LocationCode", "LocationCode");
                    dgView.Columns.Add("Partcode", "Partcode");
                    dgView.Columns.Add("Position", "Position");
                    dgView.Columns.Add("Groups", "Groups");
                    dgView.Columns.Add("KeyPerson", "KeyPerson");
                    dgView.Columns.Add("Remark", "Remark");
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
                        var rcInput = new WHS_LOCATION();
                        if (!row.IsNewRow)
                        {
                            rcInput.LocationCode = row.Cells["LocationCode"].Value.ToString();
                            rcInput.Partcode = row.Cells["Partcode"].Value.ToString();
                            rcInput.Position = row.Cells["Position"].Value.ToString();
                            rcInput.Groups = row.Cells["Groups"].Value.ToString();
                            rcInput.KeyPerson = row.Cells["KeyPerson"].Value.ToString();
                            if (row.Cells["Remark"].Value == null || row.Cells["Remark"].Value.ToString().Equals(""))
                            {
                                rcInput.Remark = "";
                            }
                            else
                            {
                                rcInput.Remark = row.Cells["Remark"].Value.ToString();
                            }


                            rcInput.CreatedBy = Program.UserId;
                            try
                            {
                                if (WHSLocationDAL.Instance.CheckExistID(rcInput.LocationCode))
                                {
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSLocationDAL.Instance.Update(rcInput);
                                }
                                else
                                {
                                    rcInput.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    rcInput.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                                    WHSLocationDAL.Instance.Add(rcInput);
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
    }
}
