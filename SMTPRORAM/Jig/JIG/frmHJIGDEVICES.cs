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
using UnidenDAL.Jig;
using UnidenDAL.Jig.JIG;
using System.Windows.Forms.DataVisualization.Charting;

namespace SMTPRORAM.Jig.JIG
{
    public partial class frmHJIGDEVICES : Form
    {

		private int currentPage = 1;
		private int recordsPerPage = 100;
		private int totalPages;
		private List<JIGH_CALDEVICES> lstResult;


		DataTableCollection tableCollection;
        private bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        public static string sendControl { get; private set; }

        private long Id = 0;
        private string controNo = "";
        public frmHJIGDEVICES()
        {
            InitializeComponent();
        }

        private void frmHJIGDEVICES_Load(object sender, EventArgs e)
        {
            lblProcess.Text = "";
            dtpMakeDate.ShowCheckBox=true;
            dtpMakeDate.Checked = false;
            dtpRepairDate.ShowCheckBox=true;
            dtpRepairDate.Checked = false;
            dtpPurDate.ShowCheckBox=true;
            dtpPurDate.Checked = false;

            _enable(false);
            LoadComboboxData();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        private void LoadComboboxData()
        {
            var lstSection = JIGSECTION_DAL.Instance.getListSection();
            var section = new ShowView();
            section.JigSecCode = "[None]";
            lstSection.Add(section);
            cbJigSecCode.DataSource = lstSection.OrderBy(p => p.JigSecCode).ToList();
            cbJigSecCode.DisplayMember = "JigSecCode";
            cbJigSecCode.ValueMember = "JigSecCode";

           
            var lstLoc = JIGLOCATION_DAL.Instance.getListLocation();
            var loc = new ShowDisplay();
            loc.LocName = "[None]";
            lstLoc.Add(loc);
            cbJigLocName.DataSource = lstLoc.OrderBy(p => p.LocName).ToList();
            cbJigLocName.DisplayMember = "LocName";
            cbJigLocName.ValueMember = "LocName";

			cbFixLocation.DataSource = lstLoc.OrderBy(p => p.LocName).ToList();
			cbFixLocation.DisplayMember = "LocName";
			cbFixLocation.ValueMember = "LocName";
		}
        void _enable(bool t)
        {
            txtControlNo.Enabled = t;
            txtEqName.Enabled = t;         
            txtModel.Enabled = t;
            txtMaker.Enabled = t;
            dtpMakeDate.Enabled = t;
            dtpRepairDate.Enabled = t;
            cbJigSecCode.Enabled = t;
            cbJigLocName.Enabled = t;
            txtSStatus.Enabled = t;
            txtNGDetail.Enabled = t;          
            dtpPurDate.Enabled = t;
            txtImportCond.Enabled = t;
            txtRemark.Enabled = t;                      
        }

        void ResetControll()
        {
            txtControlNo.Text = "";
            txtEqName.Text = "";          
            txtModel.Text = "";
            txtMaker.Text = "";
            dtpMakeDate.Text = "";
            dtpRepairDate.Text = "";
            cbJigSecCode.Text = "";
            cbJigLocName.Text = "";
            txtSStatus.Text = "";
            txtNGDetail.Text = "";          
            dtpPurDate.Text = "";
            txtImportCond.Text = "";
            txtRemark.Text = "";         
          
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void showListJIG()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, JIGHCALDEVICES_DAL.Instance.getListJIGDevice());
        }
		private void LoadDataByPage(int page, string search)
		{
			var lstResult = JIGHCALDEVICES_DAL.Instance.searchByQRModelPartPagesEntity(page, recordsPerPage, search);
			if (lstResult.Count > 0)
			{
				CommonDAL.Instance.ShowDataGridView(dgView, lstResult);
			}
		}
		private void searchData(string search)
        {

			long totalRecords = 0;
			currentPage = 1;
			totalRecords = JIGHCALDEVICES_DAL.Instance.CountSearch(search);
			if (totalRecords > 0)
			{
				LoadDataByPage(currentPage, search);
			}

			totalPages = ((int)(totalRecords / recordsPerPage) + 1);
			lblCurrentPage.Text = currentPage.ToString();
			lbltotalPages.Text = totalPages.ToString();
			lblRecod.Text = totalRecords.ToString();

			//if (search.Equals(""))
   //         {
   //             MessageBox.Show("Nhập giá trị cần tìm",
   //                 "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
   //             return;
   //         }
   //         else
   //         {
   //             CommonDAL.Instance.ShowDataGridView(dgView, JIGHCALDEVICES_DAL.Instance.getListJIGDevice(search));
   //         }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
				string inputString = txtSearch.Text.Trim();
				char[] separator = { ';' };
				string[] result = inputString.Split(separator);
				txtSearch.Text = result[0];
				searchData(txtSearch.Text.Trim());
            }

        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
			string inputString = txtSearch.Text.Trim();
			char[] separator = { ';' };
			string[] result = inputString.Split(separator);
			txtSearch.Text = result[0];
			searchData(txtSearch.Text.Trim());
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            txtControlNo.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                //txtControlNo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (!txtControlNo.Equals(""))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string message = JIGHCALDEVICES_DAL.Instance.Remove(controNo);
                    if (message =="")
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showListJIG();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        private bool IsDataOK()
        {
            if (txtControlNo.Text.Trim().Equals(""))
            {
                MessageBox.Show("ControlNO không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtControlNo.Focus();
                return false;
            }
            if (txtEqName.Text.Trim().Equals(""))
            {
                MessageBox.Show("EQName không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEqName.Focus();
                return false;
            }            
            if (txtModel.Text.Trim().Equals(""))
            {
                MessageBox.Show(" Model không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
                return false;
            }
            
            if (cbJigSecCode.Text.Trim().Equals("") || cbJigSecCode.Text == "[None]")
            {
                MessageBox.Show(" cbJigSecCode không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbJigSecCode.Focus();
                return false;
            }
            if (cbJigLocName.Text.Trim().Equals("") || cbJigLocName.Text == "[None]")
            {
                MessageBox.Show(" cbJigLocName không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbJigLocName.Focus();
                return false;
            }
			if (cbFixLocation.Text.Trim().Equals("") || cbFixLocation.Text == "[None]")
			{
				MessageBox.Show(" Fix Location không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbFixLocation.Focus();
				return false;
			}
			return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var jigCal = new JIGH_CALDEVICES();
                
                jigCal.ControlNo = txtControlNo.Text.Trim();
                jigCal.EqName = txtEqName.Text.Trim();              
                jigCal.Model = txtModel.Text.Trim();
                jigCal.Maker = txtMaker.Text.Trim();
                if (dtpMakeDate.Checked)
                {
                    jigCal.MakeDate = dtpMakeDate.Value.Date;                    
                }
                else
                {
                    jigCal.MakeDate = null;
                }
                if (dtpRepairDate.Checked)
                {
                    jigCal.RepairDate = dtpRepairDate.Value.Date;
                }
                else
                {
                    jigCal.RepairDate = null;
                }
                jigCal.JigSecCode = cbJigSecCode.SelectedValue.ToString();
                jigCal.LocName = cbJigLocName.SelectedValue.ToString();
                jigCal.FixLocation=cbFixLocation.SelectedValue.ToString();
                jigCal.SStatus = txtSStatus.Text.Trim();
                jigCal.NGDetail = txtNGDetail.Text.Trim();               
                jigCal.Remark = txtRemark.Text.Trim();
                if (dtpPurDate.Checked)
                {
                    jigCal.PurDate = dtpPurDate.Value.Date;
                }
                else
                {
                    jigCal.PurDate = null;
                }
                jigCal.ImportCond = txtImportCond.Text.Trim();              
                jigCal.Real = true;
                jigCal.CreatedBy = Program.UserId;
                jigCal.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                var checkExist = new JIGH_CALDEVICES();
               
                checkExist = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(jigCal.ControlNo);
               
                if (AddFlag == true && checkExist == null)
                {
                    if (checkExist == null)
                    {                        
                        //jigCal.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        string message = JIGHCALDEVICES_DAL.Instance.Add(jigCal);
                        if (message=="")
                        {
                            MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;
                        }
                        else
                        {
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Số Control No này đã có trong csdl: " + jigCal.ControlNo, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
					var checkExist2 = new List<JIGH_CALDEVICES>();

					checkExist2 = JIGHCALDEVICES_DAL.Instance.checkCalDevicesList(jigCal.ControlNo);
                    if (checkExist2.Count==1)
                    {
                        jigCal.Id = Id;
						string message = JIGHCALDEVICES_DAL.Instance.Update(jigCal);
						if (message == "")
						{
                            Id = 0;
							MessageBox.Show("Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							//return;
						}
						else
						{
							MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//return;
						}
						
					}
                    else
                    {
						MessageBox.Show("Đã bị trùng với Control No khác !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
					}

				}
                AddFlag = false;
                showListJIG();
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            showHideControll(true);
            _enable(false);
            ResetControll();
        }

        private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id = int.Parse(row.Cells["Id"].Value.ToString());
                controNo = row.Cells["ControlNo"].Value.ToString();
                txtControlNo.Text = row.Cells["ControlNo"].Value.ToString();
                txtEqName.Text = row.Cells["EqName"].Value.ToString();
              
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtMaker.Text = row.Cells["Maker"].Value.ToString();
                if (row.Cells["MakeDate"].Value==null)
                {
                    dtpMakeDate.Text = null;
                }
                else
                {
                    dtpMakeDate.Text = row.Cells["MakeDate"].Value.ToString();
                }
                if (row.Cells["RepairDate"].Value==null)
                {
                    dtpRepairDate.Text = null;
                }
                

                cbJigSecCode.Text = row.Cells["JigSecCode"].Value.ToString();
                cbJigLocName.Text = row.Cells["LocName"].Value.ToString();
                if (row.Cells["FixLocation"].Value==null || string.IsNullOrEmpty(row.Cells["FixLocation"].Value.ToString()))
                {
                    cbFixLocation.Text = "[None]";

				}
                else
                {
					cbFixLocation.Text = row.Cells["FixLocation"].Value.ToString();
				}
                
				txtSStatus.Text = row.Cells["SStatus"].Value.ToString();
                txtNGDetail.Text = row.Cells["NGDetail"].Value.ToString();
               
                txtRemark.Text = row.Cells["Remark"].Value.ToString();
                if (row.Cells["PurDate"].Value==null)
                {
                    dtpPurDate.Text = null;
                }
                else
                {
                    dtpPurDate.Text = row.Cells["PurDate"].Value.ToString();
                }
                
                txtImportCond.Text = row.Cells["ImportCond"].Value.ToString();
              
            }
        }

        private void iconbtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    tableCollection = CommonDAL.Instance.BrowserExcelToCombobox(txtFilename.Text);
                    cbSheet.Items.Clear();
                    foreach (System.Data.DataTable table in tableCollection)
                        cbSheet.Items.Add(table.TableName); //add sheet to combo                    
                }
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] CheckControl = new string[] { };
            System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            var _entities = new UVEntities();
            
            int count = 0;
            //dgView.DataSource = dt;
            if (dt != null)
            {
                List<JIGH_CALDEVICES> jigCals = new List<JIGH_CALDEVICES>();
                lblProcess.Visible = true;
                lblProcess.Text = "Đang đọc dữ liệu từ file excel .....";
                lblProcess.Update();
                DateTime date = CommonDAL.Instance.getSqlServerDatetime();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var jigCal = new JIGH_CALDEVICES();
                    jigCal.ControlNo = dt.Rows[i]["ControlNo"].ToString();
                    jigCal.EqName = dt.Rows[i]["EqName"].ToString();                   
                    jigCal.Model = dt.Rows[i]["Model"].ToString();
                    jigCal.Maker = dt.Rows[i]["Maker"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[i]["MakeDate"].ToString())|| dt.Rows[i]["MakeDate"].ToString().Equals(""))
                    {
                        jigCal.MakeDate = null;
                    }
                    else
                    {
                        jigCal.MakeDate = DateTime.Parse(dt.Rows[i]["MakeDate"].ToString());
                    }
                    if (string.IsNullOrEmpty(dt.Rows[i]["RepairDate"].ToString()) || dt.Rows[i]["RepairDate"].ToString().Equals(""))
                    {
                        jigCal.RepairDate = null;
                    }
                    else
                    {
                        jigCal.RepairDate = DateTime.Parse(dt.Rows[i]["RepairDate"].ToString());
                    }
                    jigCal.JigSecCode = dt.Rows[i]["JigSecCode"].ToString();
                    jigCal.LocName = dt.Rows[i]["LocName"].ToString();

					jigCal.FixLocation = dt.Rows[i]["FixLocation"].ToString();

					jigCal.SStatus = dt.Rows[i]["SStatus"].ToString();
                    jigCal.NGDetail = dt.Rows[i]["NGDetail"].ToString();                   
                    jigCal.Remark = dt.Rows[i]["Remark"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[i]["PurDate"].ToString()) || dt.Rows[i]["PurDate"].ToString().Equals(""))
                    {
                        jigCal.PurDate = null;
                    }
                    else
                    {
                        jigCal.PurDate = DateTime.Parse(dt.Rows[i]["PurDate"].ToString());
                    }                    
                    jigCal.ImportCond = dt.Rows[i]["ImportCond"].ToString();
                   
                    jigCal.Real = true;
                    jigCal.CreatedBy = Program.UserId;
                    jigCal.CreatedDate = date;
                    jigCal.UpdatedBy = null;
                    jigCal.UpdatedDate = null;
                    // Kiểm tra xem JIG này đã tồn tại trong JIG chưa.
                    var checkExits = new JIGH_CALDEVICES();
                    checkExits = JIGHCALDEVICES_DAL.Instance.checkCalDevicesExist(jigCal.ControlNo);
                    if (checkExits==null)
                    {
                        jigCals.Add(jigCal);
                    }
                    else
                    {
                        CheckControl[count] = jigCal.ControlNo;
                    }

                   
                    //_entities.JIG_CALDEVICES.Add(jigCal);
                    //_entities.SaveChanges();
                }

                lblProcess.Visible = false;
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    string message = "";
                    message= JIGHCALDEVICES_DAL.Instance.AddRange(jigCals);
                    if (message!="")
                    {
                        MessageBox.Show("Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (CheckControl.Length!=0)
                        {
                            string control = "";
                            for (int i = 0; i < CheckControl.Length; i++)
                            {
                                control += CheckControl[i]+"\n";
                            }
                            MessageBox.Show("Các mã sau đã có trong csdl: \n" + control,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);                           
                        }
                        
                    }
                    lblProcess.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

                dgView.DataSource = jigCals;
            }
        }

        private void cbJigSecCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbJigLocName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void printLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
            Id = int.Parse(row.Cells["Id"].Value.ToString());
            sendControl = row.Cells["ControlNo"].Value.ToString();
            if (sendControl!="")
            {
                var frmViewAll = new frmViewAllJIG();
                frmViewAll.ShowDialog();
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

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
			currentPage = 1;
			lblCurrentPage.Text = currentPage.ToString();
			LoadDataByPage(currentPage, txtSearch.Text.Trim());
		}

		private void iconbtnPrev_Click(object sender, EventArgs e)
		{
			if (currentPage > 1)
			{
				currentPage--;
				lblCurrentPage.Text = currentPage.ToString();
				LoadDataByPage(currentPage, txtSearch.Text.Trim());
			}
		}

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			currentPage++;
			if (currentPage > totalPages)
			{
				currentPage = totalPages;
			}
			lblCurrentPage.Text = currentPage.ToString();
			LoadDataByPage(currentPage, txtSearch.Text.Trim());
		}

		private void iconbtnLast_Click(object sender, EventArgs e)
		{
			currentPage = totalPages;
			lblCurrentPage.Text = currentPage.ToString();
			LoadDataByPage(currentPage, txtSearch.Text.Trim());
		}

		private void iconbtnExport_Click(object sender, EventArgs e)
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
				var lstResult2 = new List<ShowCalDevices>();
				lstResult2 = JIGCALDEVICES_DAL.Instance.DownloadData(txtSearch.Text.Trim());

				if (lstResult2.Count > 0)
				{
					try
					{
						CommonDAL.Instance.WriteCSV(lstResult2, filename);
						MessageBox.Show("Export Finished !!!");
					}
					catch (Exception ex)
					{
						MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

				}
			}
		}
	}
}
