using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UnidenDAL;
using UnidenDAL.Jig;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.Jig
{
    public partial class frmCalHistory : Form
    {
		
		private bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        private long Id = 0;
        
        DataTableCollection tableCollection;
        public frmCalHistory()
        {
            InitializeComponent();
			
		}
        void _enable(bool t)
        {
            txtControlNo.Enabled = t;
            txtReason.Enabled = t;
        }

        void ResetControll()
        {
            txtControlNo.Text = "";
            txtReason.Text = "";           
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void frmCalHistory_Load(object sender, EventArgs e)
        {
			
			//autoScaleMonitor.AdjustControls(this.Controls, scaleRatio);

			//txtSearch.Text= frmJIGCALDEVICES.sendControlNo;
			if (frmJIGCALDEVICES.sendControlNo!=null)
            {
                CommonDAL.Instance.ShowDataGridView(dgView, JIGCALHISTORY_DAL.Instance.getListControlByControlNo(frmJIGCALDEVICES.sendControlNo));
            }

            _enable(false);
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        
        private void btUploadD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtUpload.Text = openFileDialog.FileName;
                    tableCollection = CommonDAL.Instance.BrowserExcelToCombobox(txtUpload.Text);
                    cbSheet.Items.Clear();
                    foreach (System.Data.DataTable table in tableCollection)
                        cbSheet.Items.Add(table.TableName); //add sheet to combo                    
                }
            }
        }

        private void iconbtnUpload_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            var _entities = new UVEntities();
            progressBar1.Maximum = dt.Rows.Count;
            if (dt != null)
            {
                var lstCalHistorys = new List<JIG_CALHISTORY>();
                
                List<JIG_CALDEVICES> jigCals = new List<JIG_CALDEVICES>();
                DateTime date = CommonDAL.Instance.getSqlServerDatetime();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var jigCal = new JIG_CALDEVICES();
                    var calHistory = new JIG_CALHISTORY();
                    jigCal.ControlNo = dt.Rows[i]["ControlNo"].ToString();
                    calHistory.ControlNo = jigCal.ControlNo;
                    calHistory.Reason = dt.Rows[i]["Reason"].ToString() ;
                    calHistory.Remark = dt.Rows[i]["Remark"].ToString();
                    if (JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(jigCal.ControlNo) != null)
                    {
                        jigCal.CalDate = DateTime.Parse(dt.Rows[i]["CalDate"].ToString());                       
                        jigCal.CreatedBy = Program.UserId;
                        jigCal.UpdatedDate = date;

                        calHistory.CalDate = jigCal.CalDate;
                        calHistory.CreatedBy = jigCal.CreatedBy;
                        calHistory.CreatedDate= date;
                        
                        try
                        {
                            JIGCALDEVICES_DAL.Instance.UpdateHC(jigCal);
                            JIGCALHISTORY_DAL.Instance.Add(calHistory);
                            lstCalHistorys.Add(calHistory);
                        }
                        catch (Exception exx)
                        {
                            MessageBox.Show(exx.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        progressBar1.PerformStep();
                    }
                }
                dgView.DataSource = lstCalHistorys;
            }
        }
        private void searchData(string search)
        {          
            CommonDAL.Instance.ShowDataGridView(dgView, JIGCALHISTORY_DAL.Instance.getListControlByControlNo(search));
        }
        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập dữ liệu cần tìm kiếm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                searchData(txtSearch.Text);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                if (txtSearch.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Nhập dữ liệu cần tìm kiếm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearch.Focus();
                    return;
                }
                else
                {
                    searchData(txtSearch.Text);
                }
            }
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                txtControlNo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            showHideControll(true);
            _enable(false);
            ResetControll();
        }
        private bool IsDataOK()
        {
            if (txtControlNo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã thiết bị cần hiệu chỉnh !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtControlNo.Focus();
                return false;
            }
            if (txtReason.Text.Trim().Equals(""))
            {
                MessageBox.Show("Lý do hiệu chỉnh là gì !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReason.Focus();
                return false;
            }
            
            return true;
        }
        private void ShowHistoryByUser()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, JIGCALHISTORY_DAL.Instance.getHistoryUpdateCalDate(Program.UserId));
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK())
            {
                var jigCal = new JIG_CALDEVICES();
                jigCal.ControlNo= txtControlNo.Text;
                jigCal.CalDate = dateTimePicker1.Value.Date;
                jigCal.CreatedBy = Program.UserId;
                jigCal.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();

                var calHistory = new JIG_CALHISTORY();
                calHistory.ControlNo= txtControlNo.Text;
                calHistory.CalDate= dateTimePicker2.Value.Date;
                calHistory.CreatedBy = Program.UserId;
                calHistory.CreatedDate= CommonDAL.Instance.getSqlServerDatetime();
                calHistory.Reason = txtReason.Text;
                calHistory.Remark = "";
                try
                {
                    JIGCALDEVICES_DAL.Instance.UpdateHC(jigCal);
                    JIGCALHISTORY_DAL.Instance.Add(calHistory);
                    ShowHistoryByUser();
                    ResetControll();
                    _enable(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra khi cập nhật ngày hiệu chỉnh !!!" + ex.Message,
                        "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void txtControlNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                if (txtControlNo.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Hãy nhập mã thiết bị cần hiệu chỉnh !!!",
                        "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var jigHistory= new JIG_CALHISTORY();
                    jigHistory= JIGCALHISTORY_DAL.Instance.checkExistsEqControl(txtControlNo.Text.Trim());
                    if (jigHistory!=null)
                    {
                        dateTimePicker2.Value = jigHistory.CalDate;
                    }
                    else
                    {
                        MessageBox.Show("Không có mã này trong cơ sở dư liệu ",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                
            }
        }

        private void iconbtnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"D:\";
                saveFileDialog1.Title = "Save Csv Files";
                saveFileDialog1.DefaultExt = "csv";
                saveFileDialog1.Filter = "Csv files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    CommonDAL.Instance.writeCSV(dgView, filename);
                    MessageBox.Show("Đã Export Thành Công !!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                throw;
            }
        }

        
    }
}
