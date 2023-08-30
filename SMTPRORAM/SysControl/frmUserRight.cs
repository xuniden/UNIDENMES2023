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
    public partial class frmUserRight : Form
    {
        private string User = "";
        UVEntities _entities = new UVEntities();
        bool doubleCheckGridview = false;
        public frmUserRight()
        {
            InitializeComponent();
        }
        private void LoadUserList()
        {
            dgUser.DataSource = SYSUserDAL.Instance.getListUsers();
        }

        private void frmUserRight_Load(object sender, EventArgs e)
        {
            if (frmUser.userID!="")
            {
                txtSearch.Text = frmUser.userID;
                SendKeys.Send("{Enter}");
            }
            else
            {
                LoadUserList();
            }
            
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            //if (txtSearch.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("Hãy nhập điều kiện tìm kiếm vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSearch.Focus();
            //    return;
            //}
            //else
            //{
            var lst = SYSUserDAL.Instance.findUser(txtSearch.Text.Trim());
            if (lst.Count > 0)
            {
                dgUser.DataSource = lst;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được tìm thấy :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //}
        }
        bool busy = false;

        private void treeViewMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (busy) return;
            busy = true;
            try
            {
                checkNodes(e.Node, e.Node.Checked);
                checkParent(e.Node, e.Node.Level);
            }
            finally
            {
                busy = false;
            }
        }
        private void checkParent(TreeNode node, int level)
        {
            if (doubleCheckGridview == true)
            {

            }
            else
            {
                var nextParent = node.Parent;
                while (level > 0)
                {
                    if (level == 0)
                    {
                        node.Checked = true;
                        break;
                    }
                    else
                    {
                        nextParent.Checked = true;
                        nextParent = nextParent.Parent;
                        level--;
                    }
                }
            }
        }
        private void checkNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                checkNodes(child, check);
            }
        }
        public void PopulateTree(DataRow dr, TreeNode pNode)
        {
            foreach (DataRow row in dr.GetChildRows("rsParentChild"))
            {
                TreeNode cChild = new TreeNode("  " + row["MenuDesc"].ToString());
                cChild.Tag = row["MenuId"].ToString();
                pNode.Nodes.Add(cChild);
                cChild.Name = row["Parent"].ToString();
                cChild.Checked = row["AccessMenu"].ToString() == string.Empty ? false : bool.Parse(row["AccessMenu"].ToString());
                //Recursively build the tree
                PopulateTree(row, cChild);
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
                var curList = SYSUserMenuFuctionDAL.Instance.getUserRight(UserId);
                DataSet ds = new DataSet();
                var Menu = new UserRight();
                //List<UserRight> lst = new List<UserRight>();
                var dt = new DataTable("UserRight");
                dt = CommonDAL.Instance.ToDataTable(curList.ToList());
                ds.Tables.Add(dt);
                ds.Relations.Add("rsParentChild", ds.Tables["UserRight"].Columns["MenuId"],
                ds.Tables["UserRight"].Columns["Parent"]);


                treeViewMenu.Nodes.Clear();
                foreach (DataRow dr in ds.Tables["UserRight"].Rows)
                {
                    if (dr["Parent"] == DBNull.Value)
                    {
                        TreeNode root = new TreeNode("  " + dr["MenuDesc"].ToString());
                        root.Tag = dr["MenuId"].ToString();
                        root.Name = dr["Parent"].ToString();
                        root.Checked = dr["AccessMenu"].ToString() == string.Empty ? false : bool.Parse(dr["AccessMenu"].ToString());
                        treeViewMenu.Nodes.Add(root);
                        treeViewMenu.CheckBoxes = true;
                        PopulateTree(dr, root);
                    }
                }
                treeViewMenu.ExpandAll();
                doubleCheckGridview = false;
            }
            dgUserRight.DataSource = SYSUserMenuFuctionDAL.Instance.getByUserId(UserId);
            dgUserRight.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
        private void checkParent1(TreeNode node, int level)
        {
            var nextParent = node.Parent;
            while (level > 0)
            {
                if (level == 0)
                {
                    node.Checked = true;
                    break;
                }
                else
                {
                    nextParent.Checked = true;
                    nextParent = nextParent.Parent;
                    level--;
                }
            }
        }
        private void printRecursive(TreeNode myTreeNode)
        {
            foreach (TreeNode node in myTreeNode.Nodes)
            {
                var userFunction = new SYS_UserMenuFuction();
                userFunction.UserId = User;
                userFunction.MenuId = node.Tag.ToString();
                userFunction.MenuDesc = node.Text;
                userFunction.Parent = node.Name;
                userFunction.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                if (node.Checked == true)
                {
                    //MessageBox.Show(node.Tag.ToString()+ node.Text);
                    userFunction.AccessMenu = true;
                    SYSUserMenuFuctionDAL.Instance.AddorUpdateFunction(userFunction);
                    printRecursive(node);
                }
                else
                {
                    userFunction.AccessMenu = false;
                    SYSUserMenuFuctionDAL.Instance.AddorUpdateFunction(userFunction);
                    printRecursive(node);
                }
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = treeViewMenu.Nodes;
            foreach (TreeNode n in nodes)
            {
                //MessageBox.Show(n.Tag.ToString() + n.Text);
                var userFunction = new SYS_UserMenuFuction();
                userFunction.UserId = User;
                userFunction.MenuId = n.Tag.ToString();
                userFunction.MenuDesc = n.Text;
                userFunction.Parent = n.Name;
                userFunction.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();

                if (n.Checked == true)
                {
                    //MessageBox.Show(node.Tag.ToString()+ node.Text);
                    userFunction.AccessMenu = true;
                    SYSUserMenuFuctionDAL.Instance.AddorUpdateFunction(userFunction);
                    printRecursive(n);
                }
                else
                {
                    userFunction.AccessMenu = false;
                    SYSUserMenuFuctionDAL.Instance.AddorUpdateFunction(userFunction);
                    printRecursive(n);
                }
                printRecursive(n);
            }

            // Hiển thị giá trị sang view phân quyền:
            dgUserRight.DataSource = SYSUserMenuFuctionDAL.Instance.getByUserId(User);
            dgUserRight.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            MessageBox.Show("Đã lưu thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                var lst = SYSUserDAL.Instance.findUser(txtSearch.Text.Trim());
                if (lst.Count > 0)
                {
                    dgUser.DataSource = lst;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào được tìm thấy :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
    }
}
