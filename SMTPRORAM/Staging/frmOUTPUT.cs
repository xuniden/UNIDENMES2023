using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Staging;
using UnidenDAL;
using UnidenDTO;

namespace SMTPRORAM.Staging
{
    public partial class frmOUTPUT : Form
    {
        private bool flagedit = false;
        private long ID = 0;
        public frmOUTPUT()
        {
            InitializeComponent();
        }
        private Boolean checkBarcode(string Barcode)
        {
            if (Barcode.Length < 15)
            {
                return false;
            }
            else if (Barcode.Length == 15)
            {
                {
                    if (Barcode.Substring(0, 6).All(char.IsDigit))
                    {
                        if (Barcode.Contains("-"))
                        {
                            if ((Barcode.Substring(7, Barcode.Length - 7).All(char.IsDigit)
                            && Barcode.Substring(7, Barcode.Length - 7).Length == 8))
                            {
                                return true;
                            }
                            else
                            {
                                //MessageBox.Show("BARCODE không đúng. 8 Ký tự cuối không phải là số hoặc không đủ 8 ký tự !!!");
                                return false;
                            }
                        }
                        else
                        {
                            //MessageBox.Show("BARCODE không đúng. Barcode không có ký tự '-' !!!");
                            return false;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("BARCODE không đúng. 6 Ký tự đầu không phải là số !!!");
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

        }

        private void frmOUTPUT_Load(object sender, EventArgs e)
        {

            lblInventory.Text = "";
            lblUserID.Text = Program.UserId.ToString();
            DisplayDataG();
            txtbarcode.Select();
            txtbarcode.Focus();
        }
        private void EmptyController()
        {
            txtbarcode.Text = "";
            txtsmtqty.Text = "";
            txtsclqty.Text = "";
            cbToLine.Text = "";
            cbChangTargetLot.Text = "";
            txtRemark.Text = "";
            txtbarcode.Focus();
        }
        private void DisplayDataG()
        {
            dgouput.DataSource = UVOutPutDAL.Instance.getAllItemByKeyinPersonCurrentDate(Program.UserId,
                CommonDAL.Instance.getSqlServerDatetime());
            dgouput.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void DisplayOutPutHistory()
        {
            dgView.DataSource = UVOutPutDAL.Instance.getAllOutPutByBarcode(txtbarcode.Text.Trim());
            dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void LoadComboboxData()
        {
            // Lấy dữ liệu ASSY Line
            // 
            cbToLine.DataSource = null;
            var lstLine = UVProLineDAL.Instance.getLineNotSMTDeptID(10001);
            var nLine = new ViewCombobox();
            nLine.ID = 0;
            nLine.LineName = "[None]";
            lstLine.Add(nLine);
            cbToLine.DataSource = lstLine.OrderBy(p => p.LineName).ToList();
            cbToLine.DisplayMember = "LineName";
            cbToLine.ValueMember = "LineName";

            // Lấy dữ liệu LOT
            cbChangTargetLot.DataSource = null;
            var lstLot = UVPcbListDAL.Instance.getLotGroupBy();
            var nLot = new LotGroup();
            nLot.Lot = "[None]";
            lstLot.Add(nLot);
            cbChangTargetLot.DataSource = lstLot.OrderBy(p => p.Lot).ToList();
            cbChangTargetLot.DisplayMember = "Lot";
            cbChangTargetLot.ValueMember = "Lot";

        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBarcode(txtbarcode.Text) == true)
                {
                    LoadComboboxData();

                    // Lấy dữ liệu theo Barcode ở Input đưa vào gridview
                    // lấy dữ liệu tồn kho.

                    var InputInfo = new UV_STAGING_INPUT();
                    InputInfo = UVInputDAL.Instance.getInfoByBarcode(txtbarcode.Text.Trim());
                    if (InputInfo != null)
                    {
                        // Input Infomation
                        txtLot.Text = InputInfo.Lot;
                        txtModel.Text = InputInfo.Model;
                        txtPeno.Text = InputInfo.PeNo;
                        txtprogram.Text = InputInfo.Program;
                        txtpcbname.Text = InputInfo.PcbName;
                        txtinputqty.Text = InputInfo.InputQty.ToString();
                        // Output fixed value
                        //txtChangeTargetLot.Text= dt.Rows[0]["Lot"].ToString();
                        txtsmtqty.Text = InputInfo.InputQty.ToString();
                        // Kiểm tra xem đã output bao nhiêu lần để hiển thị lên View
                        DisplayOutPutHistory();
                        long invqty = UVOutPutDAL.Instance.QtyInventory(txtbarcode.Text.Trim());
                        lblInventory.Text = invqty.ToString();
                        txtsclqty.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Không có BARCODE Này trong CSDL INPUT !!!");
                        txtbarcode.SelectAll();
                        txtbarcode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("BARCODE Không đúng !!!");
                    txtbarcode.SelectAll();
                    txtbarcode.Focus();
                }
            }
        }

        private void cbToLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void txtsclqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private bool DataIsOK()
        {
            if (checkBarcode(txtbarcode.Text) != true)
            {
                MessageBox.Show("BARCODE không đúng định dạng: 000000-XXXXXXXX", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbarcode.Focus();
                txtbarcode.SelectAll();
                return false;
            }
            if (txtsmtqty.Text.Trim().Equals("") || string.IsNullOrEmpty(txtsmtqty.Text))
            {
                MessageBox.Show("QTY SMT đang không có dữ liệu, hãy kiểm tra lại BARCODE !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbarcode.Focus();
                txtbarcode.SelectAll();
                return false;
            }
            if (txtsclqty.Text.Trim().Equals("") || string.IsNullOrEmpty(txtsclqty.Text))
            {
                MessageBox.Show("QTY SCL đang không có dữ liệu Hoặc dữ liệu =0 !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsclqty.Focus();
                txtsclqty.SelectAll();
                return false;
            }
            if (long.Parse(txtsclqty.Text) <= 0)
            {
                MessageBox.Show("QTY SCL đang không có dữ liệu Hoặc dữ liệu =0 !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsclqty.Focus();
                txtsclqty.SelectAll();
                return false;
            }
            if (cbToLine.Text.Trim().Equals("") || string.IsNullOrEmpty(cbToLine.Text))
            {
                MessageBox.Show("TO LINE Không có dữ liệu !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbToLine.Focus();
                cbToLine.SelectAll();
                return false;
            }
            if (cbToLine.Text.Trim().Equals("[None]"))
            {
                MessageBox.Show("TO LINE Không có dữ liệu !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbToLine.Focus();
                cbToLine.SelectAll();
                return false;
            }
            if (cbChangTargetLot.Text.Trim().Equals("") || cbChangTargetLot.Text.Trim().Equals("[None]") || string.IsNullOrEmpty(cbChangTargetLot.Text))
            {
                MessageBox.Show("BARCODE không đúng định dạng hoặc không có trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbarcode.Focus();
                txtbarcode.SelectAll();
                return false;
            }


            if (long.Parse(lblInventory.Text) < long.Parse(txtsclqty.Text.Trim()))
            {
                MessageBox.Show("Số lượng xuất đi phải nhỏ hơn hoặc bằng số lượng tồn kho !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsclqty.Focus();
                txtsclqty.SelectAll();
                return false;
            }
            return true;
        }

        

        private void dgouput_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgouput.RowCount > 0)
            {
                DataGridViewRow row = dgouput.SelectedCells[0].OwningRow;
                ID = long.Parse(row.Cells["ID"].Value.ToString());
                if (ID > 0)
                {
                    flagedit = true;
                    LoadComboboxData();
                    txtbarcode.Enabled = false;
                    txtbarcode.Text = row.Cells["Barcode"].Value.ToString();
                    txtsmtqty.Text = row.Cells["QtySMT"].Value.ToString();
                    txtsclqty.Text = row.Cells["QtySCL"].Value.ToString();
                    cbToLine.Text = row.Cells["ToLine"].Value.ToString();
                    cbChangTargetLot.Text = row.Cells["ChangeTargetLot"].Value.ToString();
                    txtRemark.Text = row.Cells["Remark"].Value.ToString();
                    long invqty = UVOutPutDAL.Instance.QtyInventory(txtbarcode.Text.Trim());
                    lblInventory.Text = invqty.ToString();
                }

            }
        }

        private void cbChangTargetLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void txtsclqty_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem giá trị nhập vào có lớn hơn tồn kho còn lại không?
            // Nếu lớn hơn thì không cho nhập
            if (e.KeyValue == 13)
            {
                if (string.IsNullOrEmpty(txtsclqty.Text))
                {
                    MessageBox.Show("Nhập số lượng OUTPUT vào !!!");
                    txtsclqty.Focus();
                }
                else
                {
                    if (long.Parse(txtsclqty.Text) <= 0)
                    {
                        MessageBox.Show("Nhập giá trị không đúng !!!");
                        txtsclqty.Focus();
                        txtsclqty.SelectAll();
                    }
                    else
                    {
                        long sclqty = long.Parse(txtsclqty.Text);

                        if (sclqty > long.Parse(lblInventory.Text))
                        {
                            MessageBox.Show("Số lượng nhập không được vượt quá số lượng tồn kho !!!");
                            txtsclqty.Focus();
                            txtsclqty.SelectAll();
                        }
                        else
                        {
                            cbToLine.Focus();
                        }
                    }

                }
            }
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (DataIsOK() == true)
            {
                try
                {
                    var output = new UV_STAGING_OUTPUT();
                    output.Barcode = txtbarcode.Text;
                    output.QtySMT = int.Parse(txtsmtqty.Text.Trim().ToString());
                    output.QtySCL = int.Parse(txtsclqty.Text.Trim().ToString());
                    output.ToLine = cbToLine.Text;
                    output.ChangeTargetLot = cbChangTargetLot.Text;
                    output.KeyInPerson = Program.UserId;
                    output.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (string.IsNullOrEmpty(txtRemark.Text))
                    {
                        output.Remark = "";
                    }
                    else
                    {
                        output.Remark = txtRemark.Text;
                    }
                    if (flagedit == true && ID != 0)
                    {
                        output.ID = ID;
                        UVOutPutDAL.Instance.Update(output);
                        txtbarcode.Enabled = true;
                        flagedit = false;
                        ID = 0;
                    }
                    else
                    {
                        UVOutPutDAL.Instance.Add(output);
                    }
                    DisplayDataG();
                    DisplayOutPutHistory();
                    long invqty = UVOutPutDAL.Instance.QtyInventory(txtbarcode.Text.Trim());
                    lblInventory.Text = invqty.ToString();
                    EmptyController();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra trong khi thêm dữ liệu vào CSDL OUPUT: " + ex.Message);
                    throw;
                }
            }
        }
    }
}
