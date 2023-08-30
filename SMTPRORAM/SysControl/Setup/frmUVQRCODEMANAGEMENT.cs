using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.SysControl.IT;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;

namespace SMTPRORAM.SysControl.Setup
{
    public partial class frmUVQRCODEMANAGEMENT : Form
    {
        public frmUVQRCODEMANAGEMENT()
        {
            InitializeComponent();
        }

        private void tabControlCreate_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControlCreate.TabPages[e.Index];
            Color col = e.Index == 0 ? Color.Aqua : Color.Yellow;
            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }
        private void resetControl()
        {
            cbModel.Text = "--Select--";
            cbPcbCode.Text = "[None]";
            txtPCBTYPE.Text = "";
            cbEndOfYear.Text = "";
            cbWeek.Text = "";
            cbDayInWeek.Text = "";
            numericFrom.Value = 1;
            numericTo.Value = 1;
        }
        private void LoadFactoryCode()
        {
            DataTable dtFactoryCode= new DataTable();
            dtFactoryCode = FACTORY_DAL.Instance.getFactoryList();
            List<UV_FACTORY> lstFactoryCode =new List<UV_FACTORY>();
            lstFactoryCode = CommonDAL.Instance.ConvertDataTable<UV_FACTORY>(dtFactoryCode);

            var factoryCode = new UV_FACTORY();
            factoryCode.FACTORYCODE = "U";
            factoryCode.FACTORYNAME= "UNIDEN VIET NAM";

            lstFactoryCode.Add(factoryCode);
            cbFactoryCode.DataSource = lstFactoryCode.OrderBy(p =>p.FACTORYCODE).ToList();
            cbFactoryCode.DisplayMember = "FACTORYCODE";
            cbFactoryCode.ValueMember = "FACTORYCODE";
        }
        
        private void LoadModel()
        {
            DataTable dtModel = new DataTable();
            dtModel=MODELLOTINFO_DAL.Instance.getModelForCreateUVQRCODE();
            DataRow dataRow = dtModel.NewRow();
            dataRow["Model"] = "--Select--";
            dtModel.Rows.InsertAt(dataRow, 0);
            //lstModel.Add(model);
            //lstModel = lstModel.OrderBy(x => x.ModelName1).ToList();
            cbModel.DataSource = dtModel;
            cbModel.DisplayMember = "Model";
            cbModel.ValueMember = "Model";
        }

        private void frmUVQRCODEMANAGEMENT_Load(object sender, EventArgs e)
        {
            // lấy các thông tin điền vào các control khi khởi tạo
            var date = CommonDAL.Instance.getSqlServerDatetime();
            int Year = int.Parse(date.Year.ToString().Substring(3, 1));
            if (Year==0)
            {
                cbEndOfYear.Text = "Q-->0";
            }
            if (Year == 1)
            {
                cbEndOfYear.Text = "R-->1";
            }
            if (Year == 2)
            {
                cbEndOfYear.Text = "S-->2";
            }
            if (Year == 3)
            {
                cbEndOfYear.Text = "T-->3";
            }
            if (Year == 4)
            {
                cbEndOfYear.Text = "U-->4";
            }
            if (Year == 5)
            {
                cbEndOfYear.Text = "V-->5";
            }
            if (Year == 6)
            {
                cbEndOfYear.Text = "W-->6";
            }
            if (Year == 7)
            {
                cbEndOfYear.Text = "X-->7";
            }
            if (Year == 8)
            {
                cbEndOfYear.Text = "Y-->8";
            }
            if (Year == 9)
            {
                cbEndOfYear.Text = "Z-->9";
            }

            // lấy tuần hiện tại 
           
            CultureInfo ci = CultureInfo.CurrentCulture;
            int weekNum = ci.Calendar.GetWeekOfYear(date, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            cbWeek.Text = weekNum.ToString("00");

            // Lấy ngày của tuần
            int dayNumber = (int)date.DayOfWeek ;
            cbDayInWeek.Text = dayNumber.ToString();

            tabControlCreate.TabPages.Remove(tabPageSearch);
            lblQRSample.Text = "";
            LoadFactoryCode();
            LoadModel();
        }
        private bool IsOKData()
        {
            if (cbFactoryCode.Text.Equals(""))
            {
                MessageBox.Show("Phải chọn FACTORY CODE", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFactoryCode.Focus();
                return false;
            }
            if (cbEndOfYear.Text.Equals(""))
            {
                MessageBox.Show("Phải chọn END OF YEAR", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbEndOfYear.Focus();
                return false;
            }
            if (cbWeek.Text.Equals(""))
            {
                MessageBox.Show("Phải chọn WEEK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbWeek.Focus();
                return false;
            }
            if (cbDayInWeek.Text.Equals(""))
            {
                MessageBox.Show("Phải chọn DAY IN WEEK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDayInWeek.Focus();
                return false;
            }

            if (cbModel.Text.Trim().Equals(""))
            {
                MessageBox.Show("Phải Model MODEL bao gồm 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbModel.Focus();
                return false;
            }
            else
            {
                int lengModel = cbModel.Text.Trim().Substring(1,5).Length;
                if (lengModel!=5)
                {
                    MessageBox.Show("Phải MODEL chỉ nhập 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbModel.Focus();
                    return false;
                }                
            }
            if (cbPcbCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Phải có PCB Code", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPcbCode.Focus();
                return false;
            }
            if (txtPCBTYPE.Text.Trim().Equals(""))
            {
                MessageBox.Show("Phải có PCB TYPE", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPcbCode.Focus();
                return false;
            }
            if (int.Parse(numericFrom.Value.ToString())>int.Parse(numericTo.Value.ToString()))
            {
                MessageBox.Show("Bắt đầu từ số phải < đến số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericFrom.Focus();
                return false;
            }
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsOKData())
            {
                var lstQrcode = new List<tbl_EstechSerialGeneral>();
                var date = new DateTime();
                date= CommonDAL.Instance.getSqlServerDatetime();
                StringBuilder sbQrcode = new StringBuilder();
                var pcbKey = new DataTable();
                pcbKey=PcbType_DAL.Instance.getPcbTypeisKeyforCreateQRCode( txtPCBTYPE.Text);
                string isKey= pcbKey.Rows[0].Field<string>("isKey");
                string QRCode=cbFactoryCode.Text+cbModel.Text.Trim().Substring(1,5)+ isKey + cbEndOfYear.Text.Trim().Substring(0,1)+cbWeek.Text.Trim()+cbDayInWeek.Text.Trim();

                for (int i = int.Parse(numericFrom.Value.ToString()); 
                    i <= int.Parse(numericTo.Value.ToString()); i++)
                {
                    var cqrcode = new tbl_EstechSerialGeneral();
                    cqrcode.ModelCode = cbFactoryCode.Text;
                    cqrcode.Model = cbModel.Text.Trim();
                    cqrcode.EndOfYear = cbEndOfYear.Text.Substring(0, 1);
                    cqrcode.WeeksInYear = cbWeek.Text;
                    cqrcode.DaysOfWeek = cbDayInWeek.Text;
                    
                    cqrcode.DateT = date;
                    cqrcode.PCBCode=cbPcbCode.Text;
                    
                    cqrcode.TypeOfProduct=txtPCBTYPE.Text;
                    cqrcode.SerialOfProduct = i;
                    cqrcode.Serial_Number=QRCode+ i.ToString("0000");
                    sbQrcode.Append(QRCode+i.ToString("0000"));
                    if (i < int.Parse(numericTo.Value.ToString()) )
                    {
                        sbQrcode.Append(",");
                    }
                    lstQrcode.Add(cqrcode);
                }
                DataTable dtcheck= new DataTable();
                dtcheck= EstechSerialGeneral_DAL.Instance.CheckExistsQRCode(sbQrcode);
                if (dtcheck.Rows.Count>0)
                {
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewCreate, dtcheck);
                    MessageBox.Show("Trên hệ thông đã tạo các dữ liệu sau rồi ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string message = "";
                    message = EstechSerialGeneral_DAL.Instance.AddList(lstQrcode);
                    if (message=="")
                    {
                        MessageBox.Show("Đã thêm thành công vào csdl","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewCreate, 
                            EstechSerialGeneral_DAL.Instance.getListQRcodeCreated(cbModel.Text,cbPcbCode.Text,cbEndOfYear.Text.Substring(0,1)
                            ,cbWeek.Text,cbDayInWeek.Text,int.Parse(numericFrom.Value.ToString()),int.Parse(numericTo.Value.ToString())));
                        numericTo.Value = 1;
                        numericFrom.Value = 1;
                        cbModel.Text = "--Select--";
                        cbPcbCode.Text = "";
                        txtPCBTYPE.Text = "";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đã không thể thêm vào csdl: "+ message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            resetControl();
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            resetControl();
            cbFactoryCode.Focus();
        }

        private void cbFactoryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbEndOfYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbWeek_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbDayInWeek_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }
        private void search(string search)
        {
            if (search.Equals(""))
            {
                MessageBox.Show("Nhập giá trị cần tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgViewCreate, EstechSerialGeneral_DAL.Instance.searchByQrcodeModel(search));
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                search(txtSearch.Text.Trim());
            }

        }

        private void iconbtnSeach_Click(object sender, EventArgs e)
        {
            search(txtSearch.Text.Trim());
        }

        private void cbModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Lấy PCB code từ tbl_EastechPCBCode
            var getPCBCode = new List<GetPCBCode>();
            getPCBCode = SmtSetupPcbCodeDAL.Instance.getPCBCodeByModel(cbModel.Text.Trim());
            cbPcbCode.DataSource=getPCBCode;
            cbPcbCode.DisplayMember = "PCBCode";
            cbPcbCode.ValueMember = "PCBCode";
        }

        private void cbPcbCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            // Khi mà chọn xong PCB code thì sẽ tự hiển thị PCBTYPE
            var pcbType= new tbl_EastechPCBCode();
            pcbType= SmtSetupPcbCodeDAL.Instance.getPCBTypeByModelAndPCBCode(cbModel.Text,cbPcbCode.Text);
            if (pcbType!=null)
            {
                txtPCBTYPE.Text = pcbType.PcbType;
            }

        }

        private void iconbtnExportCSV_Click(object sender, EventArgs e)
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
                    CommonDAL.Instance.writeCSV(dgViewCreate, filename);
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
