using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTPRORAM
{
    public partial class FAssyLineChecker : Form
    {
        public FAssyLineChecker()
        {
            InitializeComponent();
        }

        private void FAssyLineChecker_Load(object sender, EventArgs e)
        {
            lblChecker.Text = "";
            lblDateTime.Text = "";
            lblTotalRecord.Text = "";
            cbModel.Focus();
            txtMarket.Text = "";
            txtQrCode.Text = "";
        }
    }
}
