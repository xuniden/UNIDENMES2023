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
    public partial class frmINPUT : Form
    {
        bool flagEdit = false;
        long ID = 0;
        public frmINPUT()
        {
            InitializeComponent();
        }
        private void EmptyControl()
        {
            txtBarcode.Text = "";
            cbLocation.Text = "";
            cbSmtLine.Text = "";
            cbLot.Text = "";
            cbPeNo.Text = "";
            cbPcbName.Text = "";
            cbProgram.Text = "";
            txtInputQty.Text = "";
            txtRemark.Text = "";
            txtModel.Text = "";
            txtHsQty.Text = "";
            txtBarcode.Focus();
        }

        private void frmINPUT_Load(object sender, EventArgs e)
        {
            txtBarcode.Select();
            txtBarcode.Focus();
            dgInput.DataSource = UVInputDAL.Instance.getAllItemByKeyinPersonCurrentDate(Program.UserId, CommonDAL.Instance.getSqlServerDatetime());
            dgInput.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
        private void ClearCombobox()
        {
            cbSmtLine.DataSource = null;
            cbProgram.DataSource = null;
            cbLocation.DataSource = null;
        }
        private void LoadComboboxData()
        {
            // Lấy dữ liệu Location
            var lstLocation = UVLocationDAL.Instance.getByLocation("LOCATION");
            var nLoc = new getLocation();
            nLoc.ID = 0;
            nLoc.Loc = "[None]";
            lstLocation.Add(nLoc);
            cbLocation.DataSource = lstLocation.OrderBy(p => p.Loc).ToList();
            cbLocation.DisplayMember = "Loc";
            cbLocation.ValueMember = "ID";


            // Lấy dữ liệu SMT Line            
            // Dept SMT code 10001
            var lstLine = UVProLineDAL.Instance.getLineByDeptID(10001);
            var nLine = new ViewCombobox();
            nLine.ID = 0;
            nLine.LineName = "[None]";
            lstLine.Add(nLine);
            cbSmtLine.DataSource = lstLine.OrderBy(p => p.LineName).ToList();
            cbSmtLine.DisplayMember = "LineName";
            cbSmtLine.ValueMember = "ID";

            // Lấy dữ liệu LOT
            var lstLot = UVPcbListDAL.Instance.getLotGroupBy();
            var nLot = new LotGroup();
            nLot.Lot = "[None]";
            lstLot.Add(nLot);
            cbLot.DataSource = lstLot.OrderBy(p => p.Lot).ToList();
            cbLot.DisplayMember = "Lot";
            cbLot.ValueMember = "Lot";

            // Lấy dữ liệu Location
            var lstLocation1 = UVLocationDAL.Instance.getByLocation("PROGRAM");
            var nLoc1 = new getLocation();
            nLoc1.ID = 0;
            nLoc1.Loc = "[None]";
            lstLocation1.Add(nLoc1);
            cbProgram.DataSource = lstLocation1.OrderBy(p => p.Loc).ToList();
            cbProgram.DisplayMember = "Loc";
            cbProgram.ValueMember = "ID";
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
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

        }
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKeyinPerson.Text = Program.UserId;
                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    MessageBox.Show("Không được để trống Barcode");
                    txtBarcode.Focus();
                }
                else
                {
                    // Kiểm tra định dạng của Barcode.
                    // 
                    if (checkBarcode(txtBarcode.Text) == true)
                    {
                        // Kiểm tra xem mã này đã có trong csdl chưa? Nếu có rồi thì thông báo và không cho nhập                      
                        if (UVInputDAL.Instance.CheckExistBarcode(txtBarcode.Text.Trim()) == true)
                        {
                            var confirmResult = MessageBox.Show("Bạn có muốn sửa dữ liệu không ???",
                                     "Xác nhận sửa dữ liệu !!!",
                                     MessageBoxButtons.YesNo);
                            if (confirmResult == DialogResult.Yes)
                            {
                                flagEdit = true;
                                var input = new UV_STAGING_INPUT();
                                input = UVInputDAL.Instance.getInfoByBarcode(txtBarcode.Text.Trim());
                                if (input != null)
                                {
                                    ClearCombobox();
                                    LoadComboboxData();
                                    cbLocation.Text = input.Location;
                                    cbSmtLine.Text = input.SmtLine;
                                    cbLot.Text = input.Lot;
                                    cbPeNo.Text = input.PeNo;
                                    cbPcbName.Text = input.PcbName;
                                    cbProgram.Text = input.Program;
                                    txtInputQty.Text = input.InputQty.ToString();
                                    txtRemark.Text = input.Remark;
                                    txtModel.Text = input.Model;
                                    txtHsQty.Text = input.HsQty.ToString();
                                    txtKeyinPerson.Text = Program.UserId;
                                }
                                else
                                {
                                    MessageBox.Show("Không có Barcode này trong csdl !!!");
                                    txtBarcode.Focus();
                                    txtBarcode.SelectAll();
                                }
                                // If 'Yes', do something here.
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã không sửa thông tin của Barcode này !!!");
                                txtBarcode.Text = "";
                                txtBarcode.Focus();

                                // If 'No', do something here.
                            }

                        }
                        else
                        {
                            ClearCombobox();
                            LoadComboboxData();
                            cbLocation.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không đúng định dạng Barcode");
                        txtBarcode.Focus();
                    }

                }
                // Nếu chưa có thì cho nhập bình thường
            }
        }

        private void cbLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbSmtLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbPeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbPcbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbProgram_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }
        private void DisplayGirlView()
        {
            CommonDAL.Instance.ShowDataGridView(dgInput, UVInputDAL.Instance.getAllItemByKeyinPerson(Program.UserId));
            //dgInput.DataSource = UVInputDAL.Instance.getAllItemByKeyinPerson(Program.UserId);
            //dgInput.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void DisplayDataGrilViewByUser()
        {
            CommonDAL.Instance.ShowDataGridView(dgInput, UVInputDAL.Instance.getAllItemByKeyinPersonCurrentDate(Program.UserId, CommonDAL.Instance.getSqlServerDatetime()));
        }

        private void cbLot_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbLot.Text))
            {
                var pcblist = UVPcbListDAL.Instance.getDataByLot(cbLot.Text.Trim());
                if (pcblist != null)
                {
                    txtModel.Text = pcblist.Model;
                    txtHsQty.Text = pcblist.HsQty.ToString();

                    // Cùng 1 lot nhưng có nhiều PENO phải list ra danh sách các PENO

                    var lstPeno = UVPcbListDAL.Instance.getAllPeNoByLot(cbLot.Text.Trim());
                    var pe = new PeNoView();
                    pe.PeNo = "[None]";
                    lstPeno.Add(pe);
                    cbPeNo.DataSource = lstPeno.OrderBy(p => p.PeNo).ToList();
                    cbPeNo.DisplayMember = "PeNo";
                    cbPeNo.ValueMember = "PeNo";
                }
                else
                {
                    //MessageBox.Show("Không có dữ liệu trong CSDL !!!");
                    //cbLot.Focus();
                }
            }
            else
            {
                // MessageBox.Show("Hãy chọn LOT !!!");
                //cbLot.Focus();
            }
        }

        private void cbPeNo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbPeNo.Text))
            {

                var pename = UVPcbListDAL.Instance.getAllPcbNameByLot(cbLot.Text, cbPeNo.Text);
                if (pename.Count > 0)
                {

                    cbPcbName.DataSource = pename;
                    cbPcbName.DisplayMember = "pcbName";
                    cbPcbName.ValueMember = "pcbName";
                }
                else
                {
                    cbPcbName.DataSource = null;
                }
            }
            else
            {
                //MessageBox.Show("Hãy chọn PE NO !!!");
                //cbPeNo.Focus();
            }
        }

        private void txtInputQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgInput_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgInput.RowCount > 0)
            {
                DataGridViewRow row = dgInput.SelectedCells[0].OwningRow;
                ID = long.Parse(row.Cells["ID"].Value.ToString());
                if (ID > 0)
                {
                    flagEdit = true;
                    ClearCombobox();
                    LoadComboboxData();
                    txtBarcode.Text = row.Cells["Barcode"].Value.ToString();
                    cbLocation.Text = row.Cells["Location"].Value.ToString();
                    cbSmtLine.Text = row.Cells["SmtLine"].Value.ToString();
                    cbLot.Text = row.Cells["Lot"].Value.ToString();
                    txtModel.Text = row.Cells["Model"].Value.ToString();
                    cbPeNo.Text = row.Cells["PeNo"].Value.ToString();
                    cbProgram.Text = row.Cells["Program"].Value.ToString();
                    //cbProgram.SelectedValue = locInfo2.ID.ToString();

                    cbPcbName.Text = row.Cells["PcbName"].Value.ToString();
                    txtHsQty.Text = row.Cells["HsQty"].Value.ToString();


                    txtInputQty.Text = row.Cells["InputQty"].Value.ToString();
                    txtKeyinPerson.Text = row.Cells["KeyInPerson"].Value.ToString();
                    txtRemark.Text = row.Cells["Remark"].Value.ToString();
                }

            }
        }
        private bool IsOKData()
        {
            if (checkBarcode(txtBarcode.Text) == false)
            {
                MessageBox.Show("Kiểm tra lại Barcode không đúng định dạng: xxxxxx-yyyyyyyy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarcode.SelectAll();
                txtBarcode.Focus();
                return false;
            }
            if (cbLocation.Text.Trim().Equals("[None]") || string.IsNullOrEmpty(cbLocation.Text))
            {
                MessageBox.Show("Kiểm tra lại Location", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLocation.SelectAll();
                cbLocation.Focus();
                return false;
            }
            if (cbSmtLine.Text.Trim().Equals("[None]") || string.IsNullOrEmpty(cbLocation.Text))
            {
                MessageBox.Show("Kiểm tra lại SMT LINE", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbSmtLine.SelectAll();
                cbSmtLine.Focus();
                return false;
            }
            if (cbLot.Text.Trim().Equals("[None]") || string.IsNullOrEmpty(cbLocation.Text))
            {
                MessageBox.Show("Kiểm tra lại LOT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLot.SelectAll();
                cbLot.Focus();
                return false;
            }
            if (cbPeNo.Text.Trim().Equals("[None]") || string.IsNullOrEmpty(cbLocation.Text))
            {
                MessageBox.Show("Kiểm tra lại PENO", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPeNo.SelectAll();
                cbPeNo.Focus();
                return false;
            }
            if (cbPcbName.Text.Trim().Equals("[None]") || string.IsNullOrEmpty(cbLocation.Text))
            {
                MessageBox.Show("Kiểm tra lại PCB NAME", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPcbName.SelectAll();
                cbPcbName.Focus();
                return false;
            }
            if (int.Parse(txtInputQty.Text) <= 0)
            {
                MessageBox.Show("Kiểm tra lại INPUT QTY", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInputQty.SelectAll();
                txtInputQty.Focus();
                return false;
            }
            return true;
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsOKData() == true)
            {
                try
                {
                    var csv = new UV_STAGING_INPUT();
                    csv.Barcode = txtBarcode.Text;
                    csv.Location = cbLocation.Text;
                    csv.SmtLine = cbSmtLine.Text;
                    csv.Lot = cbLot.Text;
                    csv.PeNo = cbPeNo.Text;
                    csv.PcbName = cbPcbName.Text;
                    csv.Program = cbProgram.Text;
                    csv.InputQty = int.Parse(txtInputQty.Text.Trim());
                    csv.Model = txtModel.Text;
                    csv.HsQty = int.Parse(txtHsQty.Text.Trim());
                    csv.KeyInPerson = Program.UserId;
                    csv.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (string.IsNullOrEmpty(txtRemark.Text))
                    {
                        csv.Remark = "";
                    }
                    else
                    {
                        csv.Remark = txtRemark.Text;
                    }
                    if (flagEdit == true)
                    {
                        // Kiểm tra xem số lượng Input phải lớn hơn tổng số lượng output
                        long outTotal = UVOutPutDAL.Instance.totalOutByBarcode(txtBarcode.Text.Trim());

                        if (csv.InputQty < outTotal)
                        {
                            MessageBox.Show("Số lượng sửa phải lớn hơn số lượng đã xuất:" + outTotal + "cho BARCODE này"
                                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtInputQty.Focus();
                            txtInputQty.SelectAll();
                        }
                        else
                        {
                            UVInputDAL.Instance.Update(csv);
                            txtBarcode.Enabled = true;
                            flagEdit = false;
                        }
                    }
                    else
                    {
                        UVInputDAL.Instance.Add(csv);
                    }
                    //DisplayGirlView();
                    DisplayDataGrilViewByUser();
                    EmptyControl();
                    //MessageBox.Show("Đã Save Thành công");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra !!!" + ex.Message);
                    throw;
                }
            }
        }
    }
}
