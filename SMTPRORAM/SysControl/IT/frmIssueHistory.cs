using Microsoft.Office.Interop.Excel;
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
using UnidenDAL.SysControl.IT;

namespace SMTPRORAM.SysControl.IT
{
    public partial class frmIssueHistory : Form
    {
        public frmIssueHistory()
        {
            InitializeComponent();
        }
        private void LoadLogTransAll()
        {
            string Matb = "";
            Matb=frmITDeviceManagement.maTB;
            //MessageBox.Show(Matb);
            var dt = new System.Data.DataTable();
            if (Matb==null|| Matb.Equals(""))
            {
                dt = IT_DevicesTransactionDAL.Instance.getListLogTranBySearch(1, "");
                if (dt.Rows.Count > 0)
                {
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
                }
                else
                {
                    MessageBox.Show("Không có lịch sử giao nhận thiết bị được tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                dt = IT_DevicesTransactionDAL.Instance.getListLogTranBySearch(2, Matb);
                if (dt.Rows.Count > 0)
                {
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
                }
                else
                {
                    MessageBox.Show("Không có lịch sử giao nhận thiết bị được tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }          
            
        }
        private void frmIssueHistory_Load(object sender, EventArgs e)
        {
            LoadLogTransAll();
        }

        private void Search(int option, string search)
        {
            if (search.Equals(""))
            {
                LoadLogTransAll();
            }
            else
            {
                var dt = new System.Data.DataTable();
                dt = IT_DevicesTransactionDAL.Instance.getListLogTranBySearch(2, search);                
                if (dt.Rows.Count > 0)
                {
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
                }
                else
                {
                    MessageBox.Show("Không có lịch sử giao nhận thiết bị được tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                Search(2, txtSearch.Text.Trim());
            }
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            Search(2, txtSearch.Text.Trim());
        }
    }
}
