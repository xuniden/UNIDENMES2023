using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;

namespace SMTPRORAM.SysControl.Setup
{
    public partial class frmFACTORY : Form
    {
        private DataTable dataTable; // Khai báo biến để lưu trữ dữ liệu
        public frmFACTORY()
        {
            InitializeComponent();
            getFacotryList();
            dgView.AllowUserToAddRows = true;
            dgView.AllowUserToDeleteRows = true;
            dgView.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgView.MultiSelect = false;
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            // Thêm một dòng mới vào DataGridView
            //dgView.Rows.Add();
            getFacotryList();
            // Kiểm tra xem có dòng mới hay không
            if (dgView.NewRowIndex >= 0)
            {
                // Nếu có, chọn dòng mới
                dgView.ClearSelection();
                dgView.Rows[dgView.NewRowIndex].Selected = true;
                dgView.CurrentCell = dgView.Rows[dgView.NewRowIndex].Cells[0];
            }
            dgView.AllowUserToAddRows = true;
            dgView.Rows[dgView.NewRowIndex].Selected = true;
            dgView.CurrentCell = dgView.Rows[dgView.NewRowIndex].Cells[0];
            dgView.BeginEdit(true);
        }

        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            dgView.EndEdit();
            dgView.AllowUserToAddRows = false;

            // Lưu dữ liệu xuống CSDL tại đây

            // Lưu các dòng mới được thêm vào CSDL
            var uvFactoryLst= new List<UV_FACTORY>();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    var uvFactory = new UV_FACTORY();
                    DateTime date = CommonDAL.Instance.getSqlServerDatetime();
                    uvFactory.FACTORYCODE = row["FACTORYCODE"].ToString();
                    uvFactory.FACTORYNAME = row["FACTORYNAME"].ToString();
                    uvFactory.FSTATUS = false;
                    uvFactory.CREATEDDATE = date;
                    uvFactory.CREATEDBY = "admin";
                    uvFactory.UPDATEDDATE= date;
                    uvFactory.UPDATEDBY = "admin";
                    uvFactoryLst.Add(uvFactory);
                }
            }
            CommonDAL.Instance.BeginTransaction();
            try
            {
                FACTORY_DAL.Instance.AddList(uvFactoryLst);
                getFacotryList();
            }
            catch 
            {
                CommonDAL.Instance.RollbackTransaction();                
            }
            CommonDAL.Instance.CommitTransaction();
        }
        private void getFacotryList()
        {
            dataTable = FACTORY_DAL.Instance.getFactoryList();
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView,dataTable);
        }

        private void frmFACTORY_Load(object sender, EventArgs e)
        {
            
        }

        private void dgView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex>=0)
            {
                if (this.dgView.Columns[e.ColumnIndex].Name == "CREATEDDATE" ||
               this.dgView.Columns[e.ColumnIndex].Name == "CREATEDBY" ||
               this.dgView.Columns[e.ColumnIndex].Name == "UPDATEDDATE" ||
               this.dgView.Columns[e.ColumnIndex].Name == "UPDATEDBY" ||
               this.dgView.Columns[e.ColumnIndex].Name == "FSTATUS")
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.Gray;
                    e.CellStyle.SelectionBackColor = Color.LightGray;
                    e.CellStyle.SelectionForeColor = Color.Gray;
                    e.CellStyle.WrapMode = DataGridViewTriState.True;
                    dgView.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                }
            }
           
        }

        private void dgView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var currentCell = dgView.CurrentCell;
            var currentRowIndex = currentCell.RowIndex;
            var currentColumnIndex = currentCell.ColumnIndex;

            if (e.RowIndex == currentRowIndex && e.ColumnIndex == currentColumnIndex + 1 && currentColumnIndex != dgView.Columns.Count - 1)
            {
                var nextCell = dgView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];

                if (string.IsNullOrEmpty(currentCell.EditedFormattedValue.ToString()))
                {
                    e.Cancel = true;
                    dgView.CurrentCell = currentCell;
                    MessageBox.Show("Please fill in the current cell.");
                }
                else if (string.IsNullOrEmpty(nextCell.Value?.ToString()))
                {
                    e.Cancel = true;
                    dgView.CurrentCell = nextCell;
                    MessageBox.Show("Please fill in the next cell.");
                }
            }
            else if (e.RowIndex == currentRowIndex + 1 && e.ColumnIndex == 0)
            {
                var previousRow = dgView.Rows[e.RowIndex - 1];
                var previousCell = previousRow.Cells[dgView.Columns.Count - 1];

                if (string.IsNullOrEmpty(previousCell.Value?.ToString()))
                {
                    e.Cancel = true;
                    dgView.CurrentCell = previousCell;
                    MessageBox.Show("Please fill in the previous row.");
                }
            }
            //try
            //{
            //    if (e.ColumnIndex == 0 || e.ColumnIndex == 1) // Kiểm tra các trường bắt buộc
            //    {
            //        //DataGridViewRow row = dgView.Rows[e.RowIndex];
            //        //if (row.Cells["FACTORYCODE"].Value.ToString().Equals("")|| 
            //        //    string.IsNullOrEmpty(row.Cells["FACTORYCODE"].Value.ToString())||
            //        //    string.IsNullOrWhiteSpace(row.Cells["FACTORYCODE"].Value.ToString()))                    
            //        //{
            //        //    e.Cancel = true; // Hủy bỏ việc xác nhận ô hiện tại
            //        //    dgView.Rows[e.RowIndex].ErrorText = "Giá trị không được để trống";
            //        //}
            //        //if (row.Cells["FACTORYNAME"].Value.ToString().Equals("") ||
            //        //   string.IsNullOrEmpty(row.Cells["FACTORYNAME"].Value.ToString()) ||
            //        //   string.IsNullOrWhiteSpace(row.Cells["FACTORYNAME"].Value.ToString()))
            //        //{
            //        //    e.Cancel = true; // Hủy bỏ việc xác nhận ô hiện tại
            //        //    dgView.Rows[e.RowIndex].ErrorText = "Giá trị không được để trống";
            //        //}
            //        // MessageBox.Show(e.FormattedValue.ToString());

            //        if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            //        {
            //            e.Cancel = true; // Hủy bỏ việc xác nhận ô hiện tại
            //            dgView.Rows[e.RowIndex].ErrorText = "Giá trị không được để trống";
            //            //e.Handled = true;
            //        }



            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


        }

        private void dgView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dgView.Columns.Count - 1 && e.RowIndex != dgView.Rows.Count - 1)
            //{
            //    dgView.CurrentCell = dgView[0, e.RowIndex + 1];
            //}
            //if (dgView.Columns[e.ColumnIndex].Name == "FACTORYCODE")
            //{
            //    var currentRow = dgView.Rows[e.RowIndex];
            //    var factoryValue = currentRow.Cells["FACTORYCODE"].Value;
            //    var factoryNameValue = currentRow.Cells["FACTORYNAME"].Value;

            //    if (string.IsNullOrEmpty(factoryValue?.ToString()) || string.IsNullOrEmpty(factoryNameValue?.ToString()))
            //    {
            //        dgView.Rows[e.RowIndex].ErrorText = "Please fill in both Factory and FactoryName";

            //        // Set focus to the cell that needs to be edited
                    
            //        if (string.IsNullOrEmpty(factoryValue?.ToString()))
            //        {
            //            dgView.CurrentCell = currentRow.Cells["FACTORYCODE"];
            //        }
            //        else
            //        {
            //            dgView.CurrentCell = currentRow.Cells["FACTORYNAME"];
            //        }

            //        dgView.BeginEdit(true);
            //    }
            //    else
            //    {
            //        dgView.Rows[e.RowIndex].ErrorText = string.Empty;
            //        dgView.EndEdit();
            //    }
            //}


            // Xóa thông báo lỗi khi người dùng sửa chữa giá trị ô
            dgView.Rows[e.RowIndex].ErrorText = string.Empty; 
            if (e.RowIndex >= 0 && dgView.Columns[e.ColumnIndex].Name == "FACTORYCODE" ||
                e.RowIndex >= 0 && dgView.Columns[e.ColumnIndex].Name == "FACTORYNAME")
            {
                DataGridViewCell cell = dgView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = cell.FormattedValue.ToString().ToUpper();
                cell.Value = value;
            }
            int iColumn = dgView.CurrentCell.ColumnIndex;
            int iRow = dgView.CurrentCell.RowIndex;

            if (iColumn == 1) // chỉ thực hiện khi ở cột thứ 2
            {
                //e.SuppressKeyPress = true; // chặn ký tự Enter hiển thị trong ô
                dgView.CurrentCell = dgView[0, iRow]; // chuyển đến ô đầu tiên của dòng tiếp theo
                dgView.BeginEdit(true); // bắt đầu chỉnh sửa ô mới
            }
        }

        private void dgView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgView.Columns[e.ColumnIndex].Name == "FACTORYCODE")
            {
                var currentRow = dgView.Rows[e.RowIndex];
                var factoryValue = currentRow.Cells["FACTORYCODE"].Value;
                var factoryNameValue = currentRow.Cells["FACTORYNAME"].Value;

                if (string.IsNullOrEmpty(factoryValue?.ToString()) || string.IsNullOrEmpty(factoryNameValue?.ToString()))
                {
                    dgView.Rows[e.RowIndex].ErrorText = "Please fill in both Factory and FactoryName";

                    // Set focus to the cell that needs to be edited
                    if (string.IsNullOrEmpty(factoryValue?.ToString()))
                    {
                        dgView.CurrentCell = currentRow.Cells["FACTORYCODE"];
                    }
                    else
                    {
                        dgView.CurrentCell = currentRow.Cells["FACTORYNAME"];
                    }

                    dgView.BeginEdit(true);
                }
                else
                {
                    dgView.Rows[e.RowIndex].ErrorText = string.Empty;
                    dgView.EndEdit();
                }
            }
        }

        
    }
}
