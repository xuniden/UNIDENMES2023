using SMTPROGRAM_Bu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;

namespace SMTPRORAM.Smt.DataControl
{
    public partial class frmCreateQRCode : Form
    {
        public frmCreateQRCode()
        {
            InitializeComponent();
        }
        private void LoadModel()
        {
            var model = new ModelName();
            model.ModelName1 = "[None]";
            var lstModel = SmtSetupPcbCodeDAL.Instance.getModelList();
            lstModel.Add(model);
            lstModel = lstModel.OrderBy(x => x.ModelName1).ToList();
            cbModel.DataSource = lstModel;
            cbModel.DisplayMember = "ModelName1";
            cbModel.ValueMember = "ModelName1";


			var date = CommonDAL.Instance.getSqlServerDatetime();
			int Year = int.Parse(date.Year.ToString().Substring(3, 1));
            cbEndOfYear.Text=Year.ToString();

			// lấy tuần hiện tại 

			CultureInfo ci = CultureInfo.CurrentCulture;
			int weekNum = ci.Calendar.GetWeekOfYear(date, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
			cbWeekOfYear.Text = weekNum.ToString("00");

			// Lấy ngày của tuần
			int dayNumber = (int)date.DayOfWeek ;
			cbDayOfWeek.Text = dayNumber.ToString();
		}
        private void frmCreateQRCode_Load(object sender, EventArgs e)
        {
            LoadModel();
        }
        private void cbModel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!cbModel.Text.Trim().Equals(""))
            {
                var modelname = SmtSetupPcbCodeDAL.Instance.getModelCode(cbModel.Text.Trim());
                if (modelname != null)
                {
                    txtModelCode.Text = modelname.ModelCode;
                    // Load Pcbcode theo model 
                    var pcbLstCode = SmtSetupPcbCodeDAL.Instance.getPCBCodeByModel(cbModel.Text.Trim());
                    var pcbCode = new GetPCBCode();
                    pcbCode.PCBCode = "[None]";
                    pcbLstCode.Add(pcbCode);
                    pcbLstCode = pcbLstCode.OrderBy(x => x.PCBCode).ToList();
                    cbPcbCode.DataSource = pcbLstCode;
                    cbPcbCode.DisplayMember = "PCBCode";
                    cbPcbCode.ValueMember = "PCBCode";
                }
            }
        }
        

        private void cbModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbPcbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbTypeOfProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbEndOfYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbWeekOfYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbDayOfWeek_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }
        private bool IsDataOK()
        {
            if (txtModelCode.Text.Equals("")|| txtModelCode.Text =="[None]")
            {
                MessageBox.Show("Hãy Model", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbModel.Focus();
                return false;
            }
            if (txtModelCode.Text.Equals(""))
            {
                MessageBox.Show("Hãy Model", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbModel.Focus();
                return false;
            }
            if (cbPcbCode.Text.Equals("") || cbPcbCode.Text == "[None]")
            {
                MessageBox.Show("Hãy chọn PCB code", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbPcbCode.Focus();
                return false;
            }
            if (cbTypeOfProduct.Text.Equals(""))
            {
                MessageBox.Show("Hãy chọn Năm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cbTypeOfProduct.Focus();
                return false;
            }            
            if (cbEndOfYear.Text.Equals(""))
            {
                MessageBox.Show("Hãy chọn Tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEndOfYear.Focus();
                return false;
            }
            if (cbWeekOfYear.Text.Equals(""))
            {
                MessageBox.Show("Hãy tuần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbWeekOfYear.Focus();
                return false;
            }
                   
            if (cbDayOfWeek.Text.Equals(""))
            {
                MessageBox.Show("Hãy Ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbDayOfWeek.Focus();
                return false;
            }
            if (Convert.ToInt32(numericUpDownFrom.Value)>=Convert.ToInt32(numericUpDownTo.Value))
            {
                MessageBox.Show("Phải nhập tạo đến số lớn hơn tạo từ số !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numericUpDownTo.Focus();
                return false;
            }
            return true;
        }
        private void clearDgView()
        {
            dgView.DataSource = null;
            dgView.DataBindings.Clear();
            dgView.Columns.Clear();
            dgView.Rows.Clear();
            dgView.Update();
            dgView.Refresh();
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK())
            {
                // Clear hết dữ liệu trên gridview
                clearDgView();

                // Tạo ra danh sách 
                var lstSerial= new List<tbl_EstechSerialGeneral>();
				StringBuilder sbQrcode = new StringBuilder();
				DateTime dateTime = CommonDAL.Instance.getSqlServerDatetime();
				for (int i=Convert.ToInt32(numericUpDownFrom.Value); i <= Convert.ToInt32(numericUpDownTo.Value); i++)
                {
                    
                    string num = i.ToString("00000");
                    string serialNumber = "U" + txtModelCode.Text.Trim() + 
                        cbTypeOfProduct.Text.Substring(0, 1) + 
                        cbEndOfYear.Text + 
                        cbWeekOfYear.Text + 
                        cbDayOfWeek.Text + num;
                    var serial = new tbl_EstechSerialGeneral
                    {
                        Serial_Number = serialNumber,
                        Model = cbModel.Text,
                        ModelCode = txtModelCode.Text,
                        PCBCode = cbPcbCode.Text,
                        TypeOfProduct = cbTypeOfProduct.Text.Substring(0, 1),
                        EndOfYear = cbEndOfYear.Text,
                        WeeksInYear = cbWeekOfYear.Text,
                        DaysOfWeek = cbDayOfWeek.Text,
                        SerialOfProduct = int.Parse(num),
                        DateT = dateTime
                    };
					
					sbQrcode.Append(serialNumber + i.ToString("0000"));
					if (i < int.Parse(numericUpDownTo.Value.ToString()))
					{
						sbQrcode.Append(",");
					}
					lstSerial.Add(serial);
                }
                // Đem danh sách so sánh với csdl xem nó có trùng không?
                // Nếu chỉ cần 1 phân tử trùng thì thông báo và không lưu
                // CommonDAL.Instance.ShowDataGridView(dgView, lstSerial);
                //bool checkExist = SmtGeneralQrCodeDAL.Instance.CheckListSerialExist(lstSerial);
				DataTable dtcheck = new DataTable();
				dtcheck = EstechSerialGeneral_DAL.Instance.CheckExistsQRCode(sbQrcode);
				if (dtcheck.Rows.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dtcheck);
					MessageBox.Show("Trên hệ thông đã tạo các dữ liệu sau rồi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
                {
                    try
                    {
                        bool success = SmtGeneralQrCodeDAL.Instance.AddRange(lstSerial);
                        if (success)
                        {
                            MessageBox.Show("Đã thêm thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CommonDAL.Instance.ShowDataGridView(dgView, lstSerial);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Không thêm thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        
                    }

                }

            }
        }

        private void btExport_Click(object sender, EventArgs e)
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
                    if (dgView.Rows.Count>0)
                    {
                        CommonDAL.Instance.writeCSV(dgView, filename);
                        MessageBox.Show("Đã export xong !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để download !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }

        
    }
}
