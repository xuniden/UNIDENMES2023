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
using UnidenDAL.SysControl;
using UnidenDTO;

namespace SMTPRORAM.SysControl
{
    public partial class frmButtonFunction : Form
    {
        bool AddFlag = false;
        public frmButtonFunction()
        {
            InitializeComponent();
        }
        void _enable(bool t)
        {
            txtButtonId.Enabled = t;
            txtButtonDesc.Enabled = t;
        }

        void ResetControll()
        {
            txtButtonId.Text = "";
            txtButtonDesc.Text = "";
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }

        private void frmButtonFunction_Load(object sender, EventArgs e)
        {
            dgButton.DataSource = SYSButtonDAL.Instance.getListButton();
            dgButton.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            showHideControll(true);
            _enable(false);
        }

        private void dgButton_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgButton.RowCount > 0)
            {
                DataGridViewRow row = dgButton.SelectedCells[0].OwningRow;
                txtButtonId.Text = row.Cells["ButtonId"].Value.ToString();
                txtButtonDesc.Text = row.Cells["ButtonDesc"].Value.ToString();
            }
        }
        private bool IsDataOK()
        {
            if (txtButtonId.Text.Trim().Equals(""))
            {
                MessageBox.Show("Button ID không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtButtonDesc.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mô tả Button không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtButtonDesc.SelectAll();
                txtButtonDesc.Focus();
                return false;
            }

            return true;
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {

            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            showHideControll(true);
            _enable(false);
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {
                var button = new SYS_ButtonFunction();
                button.ButtonId = txtButtonId.Text;
                button.ButtonDesc = txtButtonDesc.Text;

                if (AddFlag)
                {
                    if (SYSButtonDAL.Instance.checkExistButton(txtButtonId.Text.Trim()))
                    {
                        MessageBox.Show("Button Id này đã  có trong csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtButtonId.SelectAll();
                        txtButtonId.Focus();
                        return;
                    }
                    else
                    {
                        button.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        button.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        if (SYSButtonDAL.Instance.Add(button))
                        {
                            MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    button.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    if (SYSButtonDAL.Instance.EditButton(button))
                    {
                        MessageBox.Show("Ghi thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ghi không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                AddFlag = false;
                dgButton.DataSource = SYSButtonDAL.Instance.getListButton();
                dgButton.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (!txtButtonId.Text.Trim().Equals(""))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var button = new SYS_ButtonFunction();
                    button = SYSButtonDAL.Instance.findButton(txtButtonId.Text.Trim());
                    if (button != null)
                    {
                        SYSButtonDAL.Instance.Delete(button);
                    }
                    else

                    {

                    }
                }
            }
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            _enable(true);
            txtButtonId.Enabled = false;
            showHideControll(false);
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            var lst = SYSButtonDAL.Instance.findButtonById(txtSearch.Text.Trim());
            if (lst.Count > 0)
            {
                dgButton.DataSource = lst;
                dgButton.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được tìm thấy :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
