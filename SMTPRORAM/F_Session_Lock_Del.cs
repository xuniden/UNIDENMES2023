using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;


namespace SMTPRORAM
{
    public partial class F_Session_Lock_Del : Form
    {
        public F_Session_Lock_Del()
        {
            InitializeComponent();
        }

        private void F_Session_Lock_Del_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt = SessionLogin_Services.tbl_SessionLogin_GetAll();
            if (dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns(); 
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Khong co du lieu");
                return;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtuserid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();            
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (!txtuserid.Text.Equals(""))
            {
                SessionLogin_Services.tbl_SessionLogin_Delete(txtuserid.Text);
                MessageBox.Show("Delet Ok");
            }
            
        }
    }
}
