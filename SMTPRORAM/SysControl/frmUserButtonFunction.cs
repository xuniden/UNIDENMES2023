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
    public partial class frmUserButtonFunction : Form
    {
        private string User = "";
        bool doubleCheckGridview = false;
        private bool bIsAutoCheck = false;
        private bool bIsClickCheckAll = false;
        private int nCheckedItemsCount = 0;
        public frmUserButtonFunction()
        {
            InitializeComponent();
        }
        private void ListViewAddItem()
        {
            listViewButtonFunc.Items.Clear();
            listViewButtonFunc.Columns.Add("     Mô tả chức năng", 200, HorizontalAlignment.Left);
            listViewButtonFunc.Columns.Add(" Button", 120, HorizontalAlignment.Left);
            listViewButtonFunc.CheckBoxes = true;
            var listButtonFunc = SYSButtonDAL.Instance.getListButton();
            foreach (var button in listButtonFunc)
            {
                ListViewItem item = new ListViewItem(button.ButtonDesc);
                item.SubItems.Add(button.ButtonId);
                listViewButtonFunc.Items.Add(item);
            }
        }

        private void frmUserButtonFunction_Load(object sender, EventArgs e)
        {
            dgUser.DataSource = SYSUserDAL.Instance.getListUsers();
            dgUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (bIsAutoCheck) return;

            bIsClickCheckAll = true;
            if (chkAll.Checked)
                nCheckedItemsCount = listViewButtonFunc.Items.Count;
            else
                nCheckedItemsCount = 0;

            for (int i = 0; i < listViewButtonFunc.Items.Count; i++)
            {
                listViewButtonFunc.Items[i].Checked = chkAll.Checked;
            }

            bIsClickCheckAll = false;
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            var lst = SYSUserDAL.Instance.findUser(txtSearch.Text.Trim());
            if (lst.Count > 0)
            {
                dgUser.DataSource = lst;
                dgUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được tìm thấy :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewButtonFunc.Items.Count; i++)
            {
                var userButton = new SYS_UserButtonFunction();
                userButton.UserId = User;
                userButton.ButtonDesc = listViewButtonFunc.Items[i].Text;
                userButton.ButtonId = listViewButtonFunc.Items[i].SubItems[1].Text;
                userButton.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                userButton.UpdatedDate = userButton.CreatedDate;
                if (listViewButtonFunc.Items[i].Checked == true)
                {
                    userButton.AccessStatus = true;
                }
                else
                {
                    userButton.AccessStatus = false;
                }
                SYSButtonFunctionDAL.Instance.AddorUpdateFunction(userButton);
            }
            dgButtonFunction.DataSource = SYSButtonFunctionDAL.Instance.getByUserId(User);
            dgButtonFunction.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            MessageBox.Show("Lưu thành công vào csdl ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void listViewButtonFunc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount++;
            }
            else
            {
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount--;

            }

            if (bIsClickCheckAll == false)
            {
                bIsAutoCheck = true;
                if (nCheckedItemsCount < listViewButtonFunc.Items.Count)
                    chkAll.Checked = false;
                else
                    chkAll.Checked = true;
                bIsAutoCheck = false;
            }
        }

        private void dgUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string UserId = "";
            bool IsDisable;
            DataGridViewRow row = dgUser.SelectedCells[0].OwningRow;
            UserId = row.Cells["UserId"].Value.ToString();
            IsDisable = row.Cells["IsDisable"].Value.ToString() == string.Empty ? true : bool.Parse(row.Cells["IsDisable"].Value.ToString());
            if (IsDisable == false)
            {
                doubleCheckGridview = true;

                User = UserId;
                var curList = SYSButtonFunctionDAL.Instance.getButtonFunction(UserId);
                DataSet ds = new DataSet();
                var Menu = new UserRight();

                listViewButtonFunc.Items.Clear();
                listViewButtonFunc.Columns.Add("     Mô tả chức năng", 200, HorizontalAlignment.Left);
                listViewButtonFunc.Columns.Add(" Button", 120, HorizontalAlignment.Left);
                listViewButtonFunc.CheckBoxes = true;

                foreach (var button in curList)
                {
                    ListViewItem item = new ListViewItem(button.ButtonDesc);
                    item.SubItems.Add(button.ButtonId);
                    if (button.AccessStatus == true)
                    {
                        item.Checked = true;
                    }
                    listViewButtonFunc.Items.Add(item);
                }
                dgButtonFunction.DataSource = SYSButtonFunctionDAL.Instance.getByUserId(UserId);
                dgButtonFunction.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                doubleCheckGridview = false;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                var lst = SYSUserDAL.Instance.findUser(txtSearch.Text.Trim());
                if (lst.Count > 0)
                {
                    dgUser.DataSource = lst;
                    dgUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào được tìm thấy :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
