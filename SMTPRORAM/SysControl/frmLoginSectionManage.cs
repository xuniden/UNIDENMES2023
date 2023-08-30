using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Ink;
using UnidenDAL;
using UnidenDAL.SysControl;

namespace SMTPRORAM.SysControl
{
    public partial class frmLoginSectionManage : Form
    {
        private string UserId = "";
        public frmLoginSectionManage()
        {
            InitializeComponent();
        }

        private void frmLoginSectionManage_Load(object sender, EventArgs e)
        {
            CommonDAL.Instance.ShowDataGridView(dgView, SessionLoginDAL.Instance.getListSection());
        }

        private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                UserId = row.Cells["UserId"].Value.ToString();
                //MessageBox.Show(UserId);
            }
        }

        private void iconbtnKill_Click(object sender, EventArgs e)
        {
            if (UserId!="")
            {
                SessionLoginDAL.Instance.Remove(UserId);
                CommonDAL.Instance.ShowDataGridView(dgView, SessionLoginDAL.Instance.getListSection());
                UserId = "";
            }
        }

        private void killSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserId != "")
            {
                SessionLoginDAL.Instance.Remove(UserId);
                CommonDAL.Instance.ShowDataGridView(dgView, SessionLoginDAL.Instance.getListSection());
                UserId = "";
            }
        }
        private void Search(string search)
        {
           
           CommonDAL.Instance.ShowDataGridView(dgView, SessionLoginDAL.Instance.getListSesstion(search));
           
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text.Trim());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                Search(txtSearch.Text.Trim());
            }
        }

        private void iconbtnKillAll_Click(object sender, EventArgs e)
        {
            string message = "";
            message = SessionLoginDAL.Instance.KillAllSession();
            if (message == "")
            {
                MessageBox.Show("All Session Removed", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Error: " +message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
