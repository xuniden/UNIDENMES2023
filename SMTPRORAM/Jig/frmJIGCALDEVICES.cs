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
using Microsoft.Office.Interop.Excel;
using EzioDll;
using UnidenDAL.Smt.DataControl;

namespace SMTPRORAM.Jig
{
    public partial class frmJIGCALDEVICES : Form
	{
		private int currentPage = 1;
		private int recordsPerPage = 100;
		private int totalPages;
		private List<ShowCalDevices> lstResult;

		private bool realflag;
		GodexPrinter Printer = new GodexPrinter();
		public static string sendControlNo { get; private set; }
        public frmJIGCALDEVICES()
        {
            InitializeComponent();
			
		}
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        string controNo = "";
        private void frmJIGCALDEVICES_Load(object sender, EventArgs e)
        {
            //autoScaleMonitor.AdjustControls(this.Controls, scaleRatio);
            lblCurrentPage.Text = string.Empty;
            lbltotalPages.Text = string.Empty;
            lblRecod.Text = string.Empty;

			lblProcess.Text = "";
            _enable(false);
            LoadComboboxData();
            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        void _enable(bool t)
        {
            txtControlNo.Enabled = t;
            txtEqName.Enabled = t;
            txtDevicesDesc.Enabled = t;
            cbCalType.Enabled = t;
            txtSerialNumber.Enabled = t;
            txtModel.Enabled = t;
            txtMaker.Enabled = t;
            dtpCalDate.Enabled = t;
            cbJigSecCode.Enabled = t;
            cbJigLocName.Enabled = t;
            txtSStatus.Enabled = t;
            txtNGDetail.Enabled = t;
            txtUseStatus.Enabled = t;
            dtpPurDate.Enabled = t;
            txtImportCond.Enabled = t;
            txtOrigin.Enabled = t;
            txtOldControlNo.Enabled = t;
            txtBookvalue.Enabled = t;
            txtInvoiceNo.Enabled = t;
            txtFACode1.Enabled = t;
            txtFACode2.Enabled = t;
            txtRemark.Enabled = t;            
        }

        void ResetControll()
        {
            txtControlNo.Text = "";
            txtEqName.Text = "";
            txtDevicesDesc.Text ="";
            cbCalType.Text ="[None]";
            txtSerialNumber.Text ="";
            txtModel.Text = "";
            txtMaker.Text = "";
            dtpCalDate.Text = "";
            cbJigSecCode.Text = "";
            cbJigLocName.Text = "";
            txtSStatus.Text = "";
            txtNGDetail.Text = "";
            txtUseStatus.Text = "";
            dtpPurDate.Text = "";
            txtImportCond.Text = "";
            txtOrigin.Text = "";
            txtOldControlNo.Text ="";
            txtBookvalue.Text = "";
            txtInvoiceNo.Text = "";
            txtFACode1.Text = "";
            txtFACode2.Text = "";
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
        private void showListCalDevices(string controlNo)
        {
            CommonDAL.Instance.ShowDataGridView(dgView, JIGCALDEVICES_DAL.Instance.getListCalDevicesByEdit(controlNo));
        }

		private void LoadDataByPage( int page, string search)
		{			
			var lstResult = JIGCALDEVICES_DAL.Instance.searchByQRModelPartPagesEntity( page, recordsPerPage, search);
			if (lstResult.Count > 0)
			{
				CommonDAL.Instance.ShowDataGridView(dgView, lstResult);
			}
		}




		private void searchData(string search)
        {
			long totalRecords = 0;
			currentPage = 1;			
			totalRecords = JIGCALDEVICES_DAL.Instance.CountSearch(search);
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
   //            // CommonDAL.Instance.ShowDataGridView(dgView, JIGCALDEVICES_DAL.Instance.getListCalDevices());
   //         }
   //         else
   //         {
   //             CommonDAL.Instance.ShowDataGridView(dgView, JIGCALDEVICES_DAL.Instance.getListCalDevices(search));
   //         }

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
                txtControlNo.Enabled = false;
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
                    bool flag = JIGCALDEVICES_DAL.Instance.Remove(controNo);
                    bool flagNew = jigCalNewDAL.Instance.Remove(controNo);

					if (flag == true &&flagNew==true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //showListCalDevices();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        private bool IsDataOK()
        {
            
            if (AddFlag==false)
            {
                if (txtControlNo.Text.Trim().Equals(""))
                {
					MessageBox.Show("ControlNO không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtControlNo.Focus();
					return false;
				}               
            }
            else
            {
                if (cbMaCty.Text.Trim().Equals(""))
                {
					MessageBox.Show("Phải chọn loại mã cần thêm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					cbMaCty.Focus();
					return false;
				}
            }
            if (txtEqName.Text.Trim().Equals(""))
            {
                MessageBox.Show("EQName không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEqName.Focus();
                return false;
            }
            if (cbCalType.Text.Trim().Equals("")||cbCalType.Text == "[None]")
            {
                MessageBox.Show(" CalType không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCalType.Focus();
                return false;
            }
            if (txtSerialNumber.Text.Trim().Equals("") )
            {
                MessageBox.Show(" Serial Number không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerialNumber.Focus();
                return false;
            }
            if (txtModel.Text.Trim().Equals("") )
            {
                MessageBox.Show(" Model không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModel.Focus();
                return false;
            }
            if (txtMaker.Text.Trim().Equals("") )
            {
                MessageBox.Show(" Maker không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaker.Focus();
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
            if (txtSStatus.Text.Trim().Equals("") )
            {
                MessageBox.Show(" SStatus không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSStatus.Focus();
                return false;
            }
            if (txtDevicesDesc.Text.Trim().Equals("") )
            {
                MessageBox.Show(" DevicesDesc không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDevicesDesc.Focus();
                return false;
            }
            if (txtUseStatus.Text.Trim().Equals(""))
            {
                MessageBox.Show(" UseStatus không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUseStatus.Focus();
                return false;
            }
            if (txtImportCond.Text.Trim().Equals(""))
            {
                MessageBox.Show(" ImportCond không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImportCond.Focus();
                return false;
            }
            if (txtOrigin.Text.Trim().Equals(""))
            {
                MessageBox.Show(" Origin không được để trống hoặc là None !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrigin.Focus();
                return false;
            }           
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK()==true)
            {
                var jigCal = new JIG_CALDEVICES();
                var jigCalNew= new JIG_CALDEVICES_NEW();
               // jigCal.ControlNo = txtControlNo.Text.Trim();
                jigCal.EqName = txtEqName.Text.Trim();
                jigCalNew.EqName= txtEqName.Text.Trim();

				jigCal.CalType = cbCalType.SelectedValue.ToString();
				jigCalNew.CalType = cbCalType.SelectedValue.ToString();

				jigCal.SerialNumber = txtSerialNumber.Text.Trim();
				jigCalNew.SerialNumber = txtSerialNumber.Text.Trim();
				
                jigCal.Model = txtModel.Text.Trim();
				jigCalNew.Model = txtModel.Text.Trim();

				jigCal.Maker = txtMaker.Text.Trim();
				jigCalNew.Maker = txtMaker.Text.Trim();

				jigCal.CalDate = dtpCalDate.Value;
				jigCalNew.CalDate = dtpCalDate.Value;

				jigCal.JigSecCode = cbJigSecCode.SelectedValue.ToString();
				jigCalNew.JigSecCode = cbJigSecCode.SelectedValue.ToString();

				jigCal.LocName = cbJigLocName.SelectedValue.ToString();
				jigCalNew.LocName = cbJigLocName.SelectedValue.ToString();

				jigCal.SStatus = txtSStatus.Text.Trim();
				jigCalNew.SStatus = txtSStatus.Text.Trim();

				jigCal.NGDetail = txtNGDetail.Text.Trim();
				jigCalNew.NGDetail = txtNGDetail.Text.Trim();

				jigCal.DevicesDesc = txtDevicesDesc.Text.Trim();
				jigCalNew.DevicesDesc = txtDevicesDesc.Text.Trim();

				jigCal.Remark = txtRemark.Text.Trim();
				jigCalNew.Remark = txtRemark.Text.Trim();

                jigCal.UseStatus=txtUseStatus.Text.Trim();
				jigCalNew.UseStatus = txtUseStatus.Text.Trim();

				jigCal.PurDate = dtpPurDate.Value;
				jigCalNew.PurDate = dtpPurDate.Value;

				jigCal.ImportCond = txtImportCond.Text.Trim();
				jigCalNew.ImportCond = txtImportCond.Text.Trim();

				jigCal.Origin = txtOrigin.Text.Trim();
				jigCalNew.Origin = txtOrigin.Text.Trim();

				jigCal.OldControlNo = txtOldControlNo.Text.Trim();
				jigCalNew.OldControlNo = txtOldControlNo.Text.Trim();

				jigCal.BookValue=txtBookvalue.Text.Trim();
				jigCalNew.BookValue = txtBookvalue.Text.Trim();

				jigCal.InvoiceNo= txtInvoiceNo.Text.Trim();
				jigCalNew.InvoiceNo = txtInvoiceNo.Text.Trim();

				jigCal.FACode1 = txtFACode1.Text.Trim();
				jigCalNew.FACode1 = txtFACode1.Text.Trim();

				jigCal.FACode2 = txtFACode2.Text.Trim();
				jigCalNew.FACode2 = txtFACode2.Text.Trim();

				jigCal.CreatedBy = Program.UserId;
				jigCalNew.CreatedBy = Program.UserId;

				jigCal.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
				jigCalNew.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();


				var checkExist = new JIG_CALDEVICES();
                var checkExistSerial = new JIG_CALDEVICES();
                checkExist = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(jigCal.ControlNo);
                checkExistSerial= JIGCALDEVICES_DAL.Instance.checkCalDevicesExistBySerial(jigCal.SerialNumber);
                if (checkExist != null)
                {
					MessageBox.Show("Số Control No này đã có trong csdl: " + jigCal.ControlNo, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
                if (checkExistSerial != null)
                {
                    if (checkExistSerial.SerialNumber.Length>4)
                    {
						MessageBox.Show("Số Serial No: " + jigCal.SerialNumber + " này đã có trong csdl với Control No:  " + checkExistSerial.ControlNo, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}					
				}
				if (AddFlag==true && checkExist == null && checkExistSerial.SerialNumber.Length<=4)
                {
					jigCal.Real = true;
					jigCalNew.Real=true;

					jigCal.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
					jigCalNew.UpdatedDate= CommonDAL.Instance.getSqlServerDatetime();

					var dt = new System.Data.DataTable();
					//dt = jigCalNewDAL.Instance.getNewDeviceControNo();
					//dt = JIGCALDEVICES_DAL.Instance.getNewDeviceControNoAuto();
					dt = jigCalNewDAL.Instance.getNewDeviceControNo_New(cbMaCty.Text);
					int seqNumber = 0;
					string controlNoNew = "";

					//if (dt.Rows.Count > 0)
					//{
					//	seqNumber = int.Parse(dt.Rows[0]["ControlNo"].ToString().Substring(5, 6));
					//	seqNumber = seqNumber + 1;
					//	controlNoNew = "UVEQ-" + seqNumber.ToString("000000");
					//	txtControlNo.Text = controlNoNew;
					//}
					//else
					//{
					//	seqNumber = 0;
					//	seqNumber = seqNumber + 1;
					//	controlNoNew = "UVEQ-" + seqNumber.ToString("000000");
					//	txtControlNo.Text = controlNoNew;
					//}
					if (dt.Rows.Count > 0)
					{
						seqNumber = int.Parse(dt.Rows[0]["ControlNo"].ToString().Substring(5, 6));
						seqNumber = seqNumber + 1;
						controlNoNew = cbMaCty.Text.Trim() + "-" + seqNumber.ToString("000000");
						txtControlNo.Text = controlNoNew;
					}
					else
					{
						seqNumber = 0;
						seqNumber = seqNumber + 1;
						controlNoNew = cbMaCty.Text.Trim() + "-" + seqNumber.ToString("000000");
						txtControlNo.Text = controlNoNew;
					}

					jigCal.ControlNo = controlNoNew;
                    jigCalNew.ControlNo=controlNoNew;

                    string mes01 = JIGCALDEVICES_DAL.Instance.Add(jigCal);
                    string mes02 = jigCalNewDAL.Instance.Add(jigCalNew);
					if (mes01!=null&& mes02!=null)
                    {
                        MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới không thành công vào csdl. \n" +
                            "Có lỗi xảy ra: " + mes01 + "   " + mes02, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }                    
                }
                else
                {
                    jigCal.ControlNo = controNo;
                    jigCalNew.ControlNo = controNo;

                    jigCal.Real = realflag;
                    jigCalNew.Real = realflag;

                    jigCal.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    jigCalNew.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
					if (!controNo.Equals(""))
                    {
                        string mess01 = JIGCALDEVICES_DAL.Instance.Update(jigCal);
                        string mess02 = jigCalNewDAL.Instance.Update(jigCalNew);

						if ( mess01!=""&& mess02!="")
                        {
                            MessageBox.Show("Update thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							showListCalDevices(jigCal.ControlNo);
							//return;
						}
                        else
                        {
                            MessageBox.Show("Update không thành công vào csdl.\n" +
                                "Có lỗi xảy ra: "+ mess01 + "   "+ mess02, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn dữ liệu để sửa :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // MessageBox.Show("Hiện tại không cho phép sửa dữ liệu :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                AddFlag = false;               
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
                cbCalType.Text = row.Cells["CalType"].Value.ToString();
                txtSerialNumber.Text = row.Cells["SerialNumber"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtMaker.Text = row.Cells["Maker"].Value.ToString();
                dtpCalDate.Text = row.Cells["CalDate"].Value.ToString();

                cbJigSecCode.Text = row.Cells["JigSecCode"].Value.ToString();
                cbJigLocName.Text = row.Cells["LocName"].Value.ToString();
                txtSStatus.Text = row.Cells["SStatus"].Value.ToString();
                txtNGDetail.Text = row.Cells["NGDetail"].Value.ToString();
                txtDevicesDesc.Text = row.Cells["DevicesDesc"].Value.ToString();
                txtRemark.Text = row.Cells["Remark"].Value.ToString();
                txtUseStatus.Text = row.Cells["UseStatus"].Value.ToString();
                dtpPurDate.Text = row.Cells["PurDate"].Value.ToString();
                txtImportCond.Text = row.Cells["ImportCond"].Value.ToString();
                txtOrigin.Text = row.Cells["Origin"].Value.ToString();
                txtOldControlNo.Text = row.Cells["OldControlNo"].Value.ToString();
                txtBookvalue.Text= row.Cells["BookValue"].Value.ToString();
                txtInvoiceNo.Text= row.Cells["InvoiceNo"].Value.ToString();
                txtFACode1.Text = row.Cells["FACode1"].Value.ToString();
                txtFACode2.Text = row.Cells["FACode2"].Value.ToString();
                realflag=bool.Parse( row.Cells["Real"].Value.ToString());
			}
        }
        private void LoadComboboxData()
        {
            var lstCaltype = JIGCALTYPE_DAL.Instance.getListCalType();
            var calType = new ShowDetail();
            calType.CalType = "[None]";            
            lstCaltype.Add(calType);
            cbCalType.DataSource = lstCaltype.OrderBy(p=> p.CalType).ToList();
            cbCalType.DisplayMember = "CalType";
            cbCalType.ValueMember = "CalType";

            var lstSection = JIGSECTION_DAL.Instance.getListSection();
            var section = new ShowView();
            section.JigSecCode = "[None]";
            lstSection.Add(section);
            cbJigSecCode.DataSource = lstSection.OrderBy(p => p.JigSecCode).ToList();
            cbJigSecCode.DisplayMember = "JigSecCode";
            cbJigSecCode.ValueMember = "JigSecCode";

            var lstLocation = JIGLOCATION_DAL.Instance.getListLocation();
            var location = new ShowDisplay();
            location.LocName = "[None]";
            lstLocation.Add(location);
            cbJigLocName.DataSource = lstLocation.OrderBy(p => p.LocName).ToList();
            cbJigLocName.DisplayMember = "LocName";
            cbJigLocName.ValueMember = "LocName";
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!txtSearch.Text.Trim().Equals(""))
                {
					string inputString = txtSearch.Text.Trim();
					char[] separator = { ';' };
					string[] result = inputString.Split(separator);
                    txtSearch.Text = result[0];
					searchData(txtSearch.Text.Trim());
					//CommonDAL.Instance.ShowDataGridView(dgView, JIGCALDEVICES_DAL.Instance.getListCalDevices(txtSearch.Text.Trim()));
				}
                else
                {
                    MessageBox.Show("Nhập dữ liệu vào ô tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
             searchData(txtSearch.Text.Trim());
        }
        DataTableCollection tableCollection;
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
            System.Data.DataTable dt = tableCollection[cbSheet.SelectedItem.ToString()];
            var _entities = new UVEntities();
            //dgView.DataSource = dt;
            if (dt != null)
            {
                List<JIG_CALDEVICES> jigCals = new List<JIG_CALDEVICES>();
                lblProcess.Visible = true;
                lblProcess.Text = "Đang đọc dữ liệu từ file excel .....";
                lblProcess.Update();
                DateTime date= CommonDAL.Instance.getSqlServerDatetime();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var jigCal = new JIG_CALDEVICES();
                    jigCal.ControlNo = dt.Rows[i]["ControlNo"].ToString();
                    jigCal.EqName = dt.Rows[i]["EqName"].ToString();

                    jigCal.CalType = dt.Rows[i]["CalType"].ToString();
                    jigCal.SerialNumber = dt.Rows[i]["SerialNumber"].ToString();
                    jigCal.Model = dt.Rows[i]["Model"].ToString();
                    jigCal.Maker = dt.Rows[i]["Maker"].ToString();
                    jigCal.CalDate =DateTime.Parse( dt.Rows[i]["CalDate"].ToString());
                    jigCal.JigSecCode = dt.Rows[i]["JigSecCode"].ToString();
                    jigCal.LocName = dt.Rows[i]["LocName"].ToString();
                    jigCal.SStatus = dt.Rows[i]["SStatus"].ToString();
                    jigCal.NGDetail = dt.Rows[i]["NGDetail"].ToString();
                    jigCal.DevicesDesc = dt.Rows[i]["DevicesDesc"].ToString();
                    jigCal.Remark = dt.Rows[i]["Remark"].ToString();
                    jigCal.UseStatus = dt.Rows[i]["UseStatus"].ToString();
                    jigCal.PurDate =DateTime.Parse( dt.Rows[i]["PurDate"].ToString());
                    jigCal.ImportCond = dt.Rows[i]["ImportCond"].ToString();
                    jigCal.Origin = dt.Rows[i]["Origin"].ToString();
                    jigCal.OldControlNo = dt.Rows[i]["OldControlNo"].ToString();
                    jigCal.BookValue = dt.Rows[i]["BookValue"].ToString();
                    jigCal.InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString();
                    jigCal.FACode1 = dt.Rows[i]["FACode1"].ToString();
                    jigCal.FACode2 = dt.Rows[i]["FACode2"].ToString();
                    jigCal.Real = true;
                    jigCal.CreatedBy = Program.UserId;
                    jigCal.CreatedDate = date;
                    jigCal.UpdatedDate = date;
                    jigCals.Add(jigCal);
                    //_entities.JIG_CALDEVICES.Add(jigCal);
                    //_entities.SaveChanges();
                }
                
                lblProcess.Visible = false;
                try
                {
                    lblProcess.Visible = true;
                    lblProcess.Text = "Đang import data vào csdl .....";
                    lblProcess.Update();
                    _entities.JIG_CALDEVICES.AddRange(jigCals);
                    _entities.SaveChanges();
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

        private void cbCalType_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbJigSecCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbJigLocName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonDAL.Instance.ExportToExcelFromDgView(dgView);
            //if (dgView.Rows.Count > 0)
            //{
            //    Microsoft.Office.Interop.Excel.Application  XcelApp = new Microsoft.Office.Interop.Excel.Application();
            //    XcelApp.Application.Workbooks.Add(Type.Missing);
            //    for (int i = 1; i < dgView.Columns.Count + 1; i++)
            //    {
            //        XcelApp.Cells[1, i] = dgView.Columns[i - 1].HeaderText;
            //    }
            //    for (int i = 0; i < dgView.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dgView.Columns.Count; j++)
            //        {
            //            XcelApp.Cells[i + 2, j + 1] = dgView.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    XcelApp.Columns.AutoFit();
            //    XcelApp.Visible = true;
            //}
        }

        private void dgView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                sendControlNo= row.Cells["ControlNo"].Value.ToString();
                if (!sendControlNo.Equals(""))
                {
                    var frmCalHistory = new frmCalHistory();                    
                    frmCalHistory.ShowDialog();
                }
            }
        }
		
		private void printLableToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dgView.RowCount > 0)
			{
				DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
				sendControlNo = row.Cells["ControlNo"].Value.ToString();
				if (!sendControlNo.Equals(""))
				{
                    var dcm = new JIG_CALDEVICES();
                    dcm = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(sendControlNo);					
					Printer.Open(PortType.USB);

					string qrcode =dcm.ControlNo + ";" + dcm.EqName + ";" + dcm.Model + ";" + dcm.SerialNumber;
					string csString0 = "^XSETCUT,DOUBLECUT,0\r\n^Q18,3\r\n^W50\r\n^H13\r\n^P1\r\n^S3\r\n^AD\r\n^C1\r\n^R0\r\n~Q+0\r\n^O0\r\n^D0\r\n^E18\r\n~R255\r\n^L\r\nDy2-me-dd\r\nTh:m:s\r\nW17,47,5,2,M0,8,3," + qrcode.Length + ",0\r\n";
					//string qrcode = txtControlNo.Text.Trim() + ";" + txtEqName.Text.Trim() + ";" + txtModel.Text.Trim() + ";" + txtSerial.Text.Trim();
					string csString1 = "\r\nAB,118,48,1,1,0,0E,";
					string model = dcm.Model;
					string csString2 = "\r\nAB,118,79,1,1,0,0E,";
					string serial = dcm.SerialNumber;
					string scString3 = "\r\nAB,118,113,1,1,0,0E,";
                    string controlNo = dcm.ControlNo;
					string csString4 = "\r\nAB,18,16,1,1,0,0E,";
					string controlName = dcm.EqName;
					string csString5 = "\r\nE\r\n";
					string csString = csString0 + qrcode + csString1 + model + csString2 + serial + scString3 + controlNo + csString4 + controlName + csString5;

					Printer.Command.Send(csString);
					//Printer.Command.End();			
					Printer.Close();
				}
			}

			
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
		    LoadDataByPage( currentPage, txtSearch.Text.Trim());
			
		}

		private void iconbtnFirst_Click(object sender, EventArgs e)
		{
            currentPage = 1;
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
