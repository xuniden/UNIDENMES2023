using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.SysControl;

namespace SMTPRORAM.SysControl
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            dgMenu.DataSource = SYSMenuDAL.Instance.getListMenu();
            dgMenu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
    }
}
