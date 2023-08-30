using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTPRORAM.Smt.Repair
{
    public partial class frmF_Smt_Repair_Result : Form
    {
        public frmF_Smt_Repair_Result()
        {
            InitializeComponent();
        }
        bool flag = false;
        int Id = 0;
        private void frmF_Smt_Repair_Result_Load(object sender, EventArgs e)
        {
            lblUsser.Text = Program.username;
            lblId.Text = "";
            lblDept.Text = Program.Dept;
            txtSoluong.Text = "1";
            txtQRCode.Focus();
            // Load dữ liệu vào combobox
            DataTable dt = new DataTable();
            var csv = new Smt_Repair_Info();
            if (lblDept.Text == "SCL")
            {
                csv.Dept = "ASSY";
            }
            else
            {
                csv.Dept = lblDept.Text;
            }

            if (lblDept.Text == "SMT")
            {
                lblBophan.Visible = false;
                lblNguyenNhan.Visible = false;
                cbBophan.Visible = false;
                cbCauseError.Visible = false;
                txtCauseErrorDesc.Visible = false;
            }
            else
            {
                var cau = new DataTable();
                cau = Smt_Repair_Services.Smt_Repair_Cause_ViewAll();
                if (cau.Rows.Count > 0)
                {
                    cbCauseError.DataSource = cau;
                    cbCauseError.DisplayMember = "CauseError";
                    cbCauseError.ValueMember = "CauseError";
                }

                var er = new DataTable();
                er = Smt_Repair_Services.Smt_Repaire_DeptCause_ViewAll();
                if (er.Rows.Count > 0)
                {
                    cbBophan.DataSource = er;
                    cbBophan.DisplayMember = "DeptError";
                    cbBophan.ValueMember = "DeptError";
                }
            }
            csv.Ky_Hieu = "";
            csv.Noi_Dung_Loi = "";
            dt = Smt_Repair_Services.Smt_Repair_Error_Code_ViewAll(1, csv);
            if (dt.Rows.Count > 0)
            {
                cbLoaiLoi.DataSource = dt;
                cbLoaiLoi.DisplayMember = "Ky_Hieu";
                cbLoaiLoi.ValueMember = "Ky_Hieu";
            }
            else
            {
                //MessageBox.Show("Chưa có dữ liệu trong hệ thống");
                //return;
            }

        }

        private void txtVitri_Validating(object sender, CancelEventArgs e)
        {
            txtVitri.Text = txtVitri.Text.ToUpper().Trim();

            // Lấy Thông tin Part code trong BOM Repaire
            DataTable dt = new DataTable();
            var csv = new Smt_Repair_Info();
            csv.Pcb_No = txtPCBno.Text;
            csv.Position = txtVitri.Text;
            dt = Smt_Repair_Services.Smt_Repair_Bom_ViewAll(3, csv);
            if (dt.Rows.Count > 0 && dt.Rows.Count < 2)
            {
                txtPartcode.Text = dt.Rows[0].Field<string>("Part_Code");
            }
            else
            {
                MessageBox.Show("Có thể có nhiều Hơn hoặc không có dữ liệu của vị trí này: " + dt.Rows.Count);
                return;
            }
        }
        private void restcontrol()
        {
            txtQRCode.Text = "";
            txtVitri.Text = "";
            txtSoluong.Text = "1";
            txtPartcode.Text = "";
            txtnoidung.Text = "";
            txtPCBno.Text = "";
            txtNguoi1.Text = "";
            txtNgay1.Text = "";
            txtnguoi2.Text = "";
            txtNgay2.Text = "";
            txtQRCode.Focus();
        }

        private void txtQRCode1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtVitri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                // Lấy Thông tin Part code trong BOM Repaire
                DataTable dt = new DataTable();
                var csv = new Smt_Repair_Info();
                csv.Pcb_No = txtPCBno.Text;
                csv.Position = txtVitri.Text.Trim();
                dt = Smt_Repair_Services.Smt_Repair_Bom_ViewAll(3, csv);
                if (dt.Rows.Count > 0 && dt.Rows.Count < 2)
                {
                    txtPartcode.Text = dt.Rows[0].Field<string>("Part_Code");
                }
                else
                {
                    MessageBox.Show("Có thể có nhiều Hơn hoặc không có dữ liệu của vị trí này: " + dt.Rows.Count);
                    return;
                }
            }
        }
        private void UpdateView()
        {
            DataTable dt = new DataTable();
            var csv = new Smt_Repair_Result_Info();
            csv.QRCode = "";
            csv.Err_Position = "";
            csv.Remark1 = "";
            csv.Part_Code = "";
            csv.Ky_Hieu = "";
            csv.Nguoi_Sua2 = Program.username;
            dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewAll(8, csv, "", "");
            if (dt.Rows.Count > 0)
            {
                dgViewQR.DataSource = dt;
                dgViewQR.AutoResizeColumns();
                dgViewQR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu !!!");
                return;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var csv = new Smt_Repair_Result_Info();
            csv.QRCode = "";
            csv.Err_Position = "";
            csv.Remark1 = "";
            csv.Part_Code = "";
            csv.Ky_Hieu = "";
            csv.Nguoi_Sua2 = Program.username;
            dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewAll(8, csv, "", "");
            if (dt.Rows.Count > 0)
            {
                dgViewQR.DataSource = dt;
                dgViewQR.AutoResizeColumns();
                dgViewQR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu !!!");
                return;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {

            if (txtQRCode1.Text.Equals(""))
            {
                MessageBox.Show("Nhập dữ liệu vào đây ");
                txtQRCode1.Focus();
            }
            else
            {
                var csv = new Smt_Repair_Result_Info();
                csv.QRCode = txtQRCode1.Text;
                csv.Err_Position = "";
                csv.Remark1 = "";
                csv.Part_Code = "";
                csv.Ky_Hieu = "";
                csv.Nguoi_Sua2 = Program.username;
                DataTable dt = new DataTable();
                dt = Smt_Repair_Result_Services.Smt_Repair_Result_ViewAll(2, csv, "", "");
                if (dt.Rows.Count > 0)
                {
                    dgViewQR.DataSource = dt;
                    dgViewQR.AutoResizeColumns();
                    dgViewQR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Không có trong csdl ");
                    return;
                }
            }
        }

        private void dgViewQR_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            flag = true;
            Id = Convert.ToInt32(dgViewQR.Rows[e.RowIndex].Cells[0].Value.ToString());
            lblId.Text = Id.ToString();
            txtQRCode.Text = dgViewQR.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtVitri.Text = dgViewQR.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPartcode.Text = dgViewQR.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbLoaiLoi.Text = dgViewQR.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtnoidung.Text = dgViewQR.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSoluong.Text = dgViewQR.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtNguoi1.Text = dgViewQR.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtNgay1.Text = dgViewQR.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtnguoi2.Text = dgViewQR.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtNgay2.Text = dgViewQR.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtPCBno.Text = dgViewQR.Rows[e.RowIndex].Cells[11].Value.ToString();

            cbCauseError.Text = dgViewQR.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtCauseErrorDesc.Text = dgViewQR.Rows[e.RowIndex].Cells[13].Value.ToString();
            cbBophan.Text = dgViewQR.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtQRCode.Enabled = false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra lại các thông tin trước khi save

            DataTable dt = new DataTable();
            dt = EastechOutputHistory_Services.EastechOutputHistory_Smt_CheckQRCode(txtQRCode.Text);
            if (dt.Rows.Count > 0)
            {
                string Pcbno = "";
                Pcbno = dt.Rows[0].Field<string>("Remark2");
                // Kiểm tra nếu Pcb No mà # trống thì lấy thông tin trong bảng BOM Repaire
                if (Pcbno.Length > 14)
                {
                    Pcbno = Pcbno.Substring(0, 14);
                }
                if (Pcbno != txtPCBno.Text)
                {
                    MessageBox.Show("Kiểm tra lại dữ liệu QR Code ");
                    txtQRCode.Focus();
                    txtQRCode.SelectAll();
                    return;
                }

            }
            else
            {
                MessageBox.Show("Không tìm thấy số QR code này trên hệ thống !!!");
                return;
            }

            txtVitri.Text = txtVitri.Text.ToUpper().Trim();
            // Lấy Thông tin Part code trong BOM Repaire
            var dtt = new DataTable();
            var csv = new Smt_Repair_Info();
            csv.Dept = lblDept.Text;
            csv.Ky_Hieu = cbLoaiLoi.Text;
            csv.Pcb_No = txtPCBno.Text;
            csv.Position = txtVitri.Text;
            dtt = Smt_Repair_Services.Smt_Repair_Bom_ViewAll(3, csv);
            if (dtt.Rows.Count > 0 && dtt.Rows.Count < 2)
            {
                string part = dtt.Rows[0].Field<string>("Part_Code");
                if (part != txtPartcode.Text)
                {
                    MessageBox.Show("Kiểm tra lại dữ liệu Vị Trí ");
                    txtVitri.Focus();
                    txtVitri.SelectAll();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Có thể có nhiều Hơn hoặc không có dữ liệu của vị trí này: " + dtt.Rows.Count);
                return;
            }
            if (int.Parse(txtSoluong.Text) < 1)
            {
                MessageBox.Show("Số lượng lỗi không đúng");
                txtSoluong.Focus();
                txtSoluong.SelectAll();
                return;
            }
            // thực hiện save
            try
            {
                var obj = new Smt_Repair_Result_Info();
                obj.Id = lblId.Text;
                obj.QRCode = txtQRCode.Text;
                obj.Err_Position = txtVitri.Text;
                obj.Part_Code = txtPartcode.Text;
                obj.Ky_Hieu = cbLoaiLoi.Text;
                if (lblDept.Text == "SCL")
                {
                    csv.Dept = "ASSY";
                }
                var mala = new DataTable();
                mala = Smt_Repair_Services.Smt_Repair_Error_Code_ViewAll(2, csv);
                if (mala.Rows.Count > 0)
                {
                    obj.Noi_Dung = mala.Rows[0].Field<string>("Noi_Dung_Loi");
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu về Loại Lỗi này");
                    return;
                }
                obj.So_Luong = txtSoluong.Text;
                obj.Remark1 = txtPCBno.Text;

                if (lblDept.Text == "ASSY" || lblDept.Text == "SCL")
                {
                    obj.Remark2 = cbCauseError.Text;
                    var mal = new DataTable();
                    mal = Smt_Repair_Services.Smt_Repair_Cause_ViewByCode(cbCauseError.Text);
                    if (mal.Rows.Count > 0)
                    {
                        obj.Remark3 = mal.Rows[0].Field<string>("CauseDesc");
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu Nguyên nhân này");
                        return;
                    }
                    obj.Remark4 = cbBophan.Text;
                }
                else
                {
                    obj.Remark2 = "";
                    obj.Remark3 = "";
                    obj.Remark4 = "";
                }
                if (flag == false)
                {
                    obj.Nguoi_Sua = Program.username;
                    obj.DateT = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    obj.Nguoi_Sua2 = Program.username;
                    obj.DateT2 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                }
                else
                {
                    obj.Nguoi_Sua = txtNguoi1.Text;
                    obj.DateT = txtNgay1.Text;
                    obj.Nguoi_Sua2 = Program.username;
                    obj.DateT2 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                }

                obj.Remark5 = lblDept.Text;
                if (flag == false)
                {
                    Smt_Repair_Result_Services.Smt_Repair_Result_Insert(obj);
                    UpdateView();
                }
                else
                {
                    Smt_Repair_Result_Services.Smt_Repair_Result_Update(obj);
                    UpdateView();
                    txtQRCode.Enabled = true;
                }

                restcontrol();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi:  " + ex.Message);
                return;
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtSoluong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSave.Focus();
                SendKeys.Send("Enter");
            }
        }

        private void cbCauseError_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt = Smt_Repair_Services.Smt_Repair_Cause_ViewByCode(cbCauseError.Text);
            if (dt.Rows.Count > 0)
            {
                txtCauseErrorDesc.Text = dt.Rows[0].Field<string>("CauseDesc");
            }
        }

        private void cbLoaiLoi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var csv = new Smt_Repair_Info();
            csv.Dept = lblDept.Text;
            csv.Ky_Hieu = cbLoaiLoi.Text;
            var dt = new DataTable();
            dt = Smt_Repair_Services.Smt_Repair_Error_Code_ViewAll(2, csv);
            if (dt.Rows.Count > 0)
            {
                txtnoidung.Text = dt.Rows[0].Field<string>("Noi_Dung_Loi");
            }
            else
            {
                MessageBox.Show("Không có loại lỗi này trong csdl !!!!");
                return;
            }
        }

        private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
        {
            //txtQRCode.Text = txtQRCode.Text.Trim().ToUpper();
            if (e.KeyCode == Keys.Enter)
            {
                // Lấy thông PCB No tin từ dữ liệu bắn QR code
                DataTable dt = new DataTable();
                dt = EastechOutputHistory_Services.EastechOutputHistory_Smt_CheckQRCode(txtQRCode.Text);
                if (dt.Rows.Count > 0)
                {
                    string Pcbno = "";
                    Pcbno = dt.Rows[0].Field<string>("Remark2");
                    if (Pcbno.Length > 14)
                    {
                        Pcbno = Pcbno.Substring(0, 14);
                    }
                    // Kiểm tra nếu Pcb No mà # trống thì lấy thông tin trong bảng BOM Repaire
                    if (Pcbno.Length > 0)
                    {
                        txtPCBno.Text = Pcbno.ToString();
                        txtVitri.Focus();
                    }
                    else
                    {
                        MessageBox.Show("PCB này Không tồn tại với QR code này");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy số QR code này trên hệ thống !!!");
                    return;
                }
            }
        }
    }
}
