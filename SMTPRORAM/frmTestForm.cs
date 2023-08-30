using SMTPROGRAM_Bu;
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
    public partial class frmTestForm : Form
    {
        public frmTestForm()
        {
            InitializeComponent();
        }

        private void frmTestForm_Load(object sender, EventArgs e)
        {
            var dataTable= new DataTable();
            dataTable = Pcb_Code_Services.EastechPCBCode_GetPcbCode();
            
            if (dataTable.Rows.Count >= 1)
            {
                cbPcbCode.DataSource = dataTable;
                cbPcbCode.DisplayMember = "PCBCode";
                //cbPcbCode.ValueMember = "PCBCode";
            }
        }

        private void cbPcbCode_TextUpdate(object sender, EventArgs e)
        {
            //string searchText = cbPcbCode.Text.Trim().ToLower();

            //// Get the original data source
            //DataTable originalData = ((DataTable)cbPcbCode.DataSource).Copy();

            //// Filter the data based on the user's input
            //DataTable filteredData = originalData.AsEnumerable()
            //    .Where(row => row.Field<string>("PCBCode").ToLower().Contains(searchText))
            //    .CopyToDataTable();

            //// Set the filtered data as the new data source for the ComboBox
            //cbPcbCode.DataSource = filteredData;
            //cbPcbCode.DisplayMember = "PCBCode";
            //cbPcbCode.ValueMember = "PCBCode";
        }
        private string searchString = "";
        private void cbPcbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if  (e.KeyChar == Convert.ToChar(Keys.Return)) // If Enter key is pressed, perform search
            {
                DataTable originalData = ((DataTable)cbPcbCode.DataSource).Copy();

                // Filter the data based on the search string
                DataTable filteredData = originalData.AsEnumerable()
                    .Where(row => row.Field<string>("PCBCode").ToLower().Contains(searchString.ToLower()))
                    .CopyToDataTable();

                cbPcbCode.DataSource = filteredData;
                cbPcbCode.DisplayMember = "PCBCode";
                cbPcbCode.ValueMember = "PCBCode";

                searchString = ""; // Clear the search string
            }
            else
            {
                searchString += e.KeyChar; // Add the pressed key to the search string
            }
        }
    }
}
