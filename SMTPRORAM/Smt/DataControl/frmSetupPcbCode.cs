using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.Smt.DataControl
{
    public partial class frmSetupPcbCode : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        int Id = 0;
        public frmSetupPcbCode()
        {
            InitializeComponent();
        }

        private void frmSetupPcbCode_Load(object sender, EventArgs e)
        {
            DisplayViewData();
            cbStatus.Text = "[None]";
            showHideControll(true);
            _enable(false);
            // Load Div by DivCode vs DivId
            LoadModel();
            LoadPcbType();

            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        private void DisplayViewData()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, SmtSetupPcbCodeDAL.Instance.getPcbCodeList().OrderByDescending(p=>p.DateT).Take(1000).ToList());
        }
        void _enable(bool t)
        {
            cbModel.Enabled = t;
            cbPcbType.Enabled = t;
            cbStatus.Enabled = t;
            txtPcbcode.Enabled = t;
        }

        void ResetControll()
        {
            cbModel.Text = "";
            cbPcbType.Text = "";
            cbStatus.Text = "";
            txtPcbcode.Text = "";
            LoadModel();
            LoadPcbType();            
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        private void LoadModel()
        {
            var model = new ModelName();
            model.ModelName1 = "[None]";
            //var lstModel = SmtSetupPcbCodeDAL.Instance.getModelList();
            DataTable dt = new DataTable();
            dt = SmtSetupPcbCodeDAL.Instance.getModelForRegistorPCBCode();
            DataRow dataRow = dt.NewRow();
            dataRow["Model"] = "--Select--";
            dt.Rows.InsertAt(dataRow,0);
            //lstModel.Add(model);
            //lstModel = lstModel.OrderBy(x => x.ModelName1).ToList();
            cbModel.DataSource = dt;
            cbModel.DisplayMember = "Model";
            cbModel.ValueMember = "Model";
        }
        private void LoadPcbType()
        {
            var pcbType = new PcbType();
            pcbType.PcbType1 = "[None]";           
            var lstPcbType = SmtSetupPcbCodeDAL.Instance.getPcbTypeList();
            lstPcbType.Add(pcbType);
            lstPcbType = lstPcbType.OrderBy(x => x.PcbType1).ToList();
            cbPcbType.DataSource = lstPcbType;
            cbPcbType.DisplayMember = "PcbType1";
            cbPcbType.ValueMember = "PcbType1";
        }

        private void cbModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void cbPcbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender, e);
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            cbModel.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {

            if (Id > 0)
            {
                AddFlag = false;
                _enable(true);
                showHideControll(false);
                cbModel.Focus();
            }
            else
            {
                MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool flag = SmtSetupPcbCodeDAL.Instance.Remove(Id);
                    if (flag == true)
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayViewData();
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
            if (cbModel.Text.Trim().Equals("")  || cbModel.Text == "--Select--")
            {
                MessageBox.Show("Model không được để trống hoặc --Select--!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbModel.Focus();
                return false;
            }
            
            if (cbPcbType.Text.Trim().Equals("") || cbPcbType.Text == "[None]")
            {
                MessageBox.Show("PCB TYPE không được để trống hoặc [None] !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPcbType.Focus();
                return false;
            }
            if (cbStatus.Text.Trim().Equals("")|| cbPcbType.Text == "[None]")
            {
                MessageBox.Show("Status Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbStatus.Focus();
                return false;
            }
            if (txtPcbcode.Text.Trim().Equals("") )
            {
                MessageBox.Show("PCB CODE Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPcbcode.Focus();
                return false;
            }
            else
            {
                if (cbModel.Text.Trim().Substring(0, 1) == "U" && txtPcbcode.Text.Trim().Length != 8)
                {
                    MessageBox.Show("Với Model của Uniden thì PCBCODE = 8 ký tự", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPcbcode.Focus();
                    txtPcbcode.SelectAll();
                    return false;
                }
            }
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var pcbCode = new tbl_EastechPCBCode();
                pcbCode.PcbKey = cbModel.Text+txtPcbcode.Text.Trim()+cbPcbType.Text+cbStatus.Text;
                pcbCode.Model = cbModel.Text;
                if (pcbCode.Model.StartsWith("U"))
                {
                    pcbCode.PCBCode = txtPcbcode.Text.Trim()+"-UV";
                }
                else
                {
                    pcbCode.PCBCode = txtPcbcode.Text.Trim();
                }                           
                pcbCode.PcbType = cbPcbType.Text;
                pcbCode.Statuc = cbStatus.Text;
                pcbCode.DateT = CommonDAL.Instance.getSqlServerDatetime();
                bool checkExist = SmtSetupPcbCodeDAL.Instance.checkExistPcbKey(pcbCode.PcbKey);
                if (AddFlag && checkExist==false)
                {
                    if (SmtSetupPcbCodeDAL.Instance.Add(pcbCode))
                    {
                        MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    pcbCode.Id = Id;
                    if (SmtSetupPcbCodeDAL.Instance.Update(pcbCode))
                    {
                        MessageBox.Show("Update thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                AddFlag = false;
                DisplayViewData();
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
        }
        private void SearchData()
        {
            if (txtSearch.Text.Trim().Equals("") )
            {
                DisplayViewData();
            }
            else
            {
                CommonDAL.Instance.ShowDataGridView(dgView, SmtSetupPcbCodeDAL.Instance.getSearchByString(txtSearch.Text.Trim()));
            }
        }

        private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id = int.Parse(row.Cells["Id"].Value.ToString());
                cbModel.Text = row.Cells["Model"].Value.ToString();
                cbPcbType.Text = row.Cells["PcbType"].Value.ToString();
                cbStatus.Text= row.Cells["Statuc"].Value.ToString();
                txtPcbcode.Text= row.Cells["PCBCode"].Value.ToString();
            }
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
               
                SearchData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            SearchData();
        }

        private void cbModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Khi thay đổi giá trị lựa chọn thì sẽ hiển thị đúng loại pcb tương ứng
            string model = "";
            model = cbModel.Text;
            if (!model.Equals("") ||
                !model.Equals("--Select--"))
            {
                if (model.Substring(0, 1).ToUpper() == "U")
                {
                    // Lấy hết type của hàng UV
                    DataTable dt = new DataTable();
                    dt = SmtSetupPcbCodeDAL.Instance.getModelForUVorOtherPCBTYPE(1);
                    cbPcbType.DataSource = dt;
                    cbPcbType.DisplayMember = "PcbType";
                    cbPcbType.ValueMember = "PcbType";
                }
                else
                {
                    // Chỉ lấy hàng không phải của UV
                    DataTable dt = new DataTable();
                    dt = SmtSetupPcbCodeDAL.Instance.getModelForUVorOtherPCBTYPE(2);
                    cbPcbType.DataSource = dt;
                    cbPcbType.DisplayMember = "PcbType";
                    cbPcbType.ValueMember = "PcbType";
                }
            }
        }
    }
}
