using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDTO;

namespace SMTPRORAM.Smt.DataControl
{
    public partial class frmViewChangeMaterialHistory : Form
    {
        private string search;
		private int currentPage = 1;
		private int recordsPerPage = 100;
		private int totalPages;
        private List<EASTECH_PROGRAMHISTORY> lstResult;
        public frmViewChangeMaterialHistory()
        {
            InitializeComponent();
        }      

        private void LoadDataByPage(int Option, int page, string search)
		{
			
            if (Option==1) // Part
            {
				var lstResult = SmtEtProgramHistoryDAL.Instance.searchByPartAndProgramPagesEntity(1,page, recordsPerPage, search);
				if (lstResult.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridView(dgView, lstResult);
				}
			}
            else // Program
            {
				var lstResult = SmtEtProgramHistoryDAL.Instance.searchByPartAndProgramPagesEntity(2, page, recordsPerPage, search);
				if (lstResult.Count > 0)
				{
					CommonDAL.Instance.ShowDataGridView(dgView, lstResult);
				}
			}
            
		}

		private void SearchByPart(int Option,string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Nhập Part cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtPart.Focus();
				return;
            }
            else
            {
                long totalRecords = 0;
				currentPage = 1;
				if (Option==1)
                {
					totalRecords = SmtEtProgramHistoryDAL.Instance.CountSearchPartAndProgram(1, search);
					if (totalRecords > 0)
					{						
						LoadDataByPage(1,currentPage, search);
					}
				}
				if (Option==2)
				{
					totalRecords = SmtEtProgramHistoryDAL.Instance.CountSearchPartAndProgram(2, search);
					if (totalRecords > 0)
					{						
						LoadDataByPage(2, currentPage, search);
					}
				}
				totalPages = ((int)(totalRecords / recordsPerPage) + 1);
				lblcurrentPage.Text = currentPage.ToString();
				lbltotalPages.Text = totalPages.ToString();
				lblCount.Text = totalRecords.ToString();				
            }
        }

        private void btnSearchPart_Click(object sender, EventArgs e)
        {
			search = txtPart.Text.Trim();
            if (cbSelectSearch.Text.Equals("--Select--"))
            {
                MessageBox.Show("Chọn tìm kiếm theo Key hay Part","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cbSelectSearch.Focus();
                return;
            }
			if (cbSelectSearch.Text.Equals("Program Key"))
			{                
				SearchByPart(2, search);
			}
			if (cbSelectSearch.Text.Equals("Part code"))
			{
				SearchByPart(1, search);
			}
			#region Old Code
			/*
			if (txtPart.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhập Partcode cần tìm vào đây !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPart.Focus();
                return;
            }
            else
            {
               DataTable dt= new DataTable();
                dt = SmtEtProgramHistoryDAL.Instance.searchByPart(txtPart.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
                    lblCount.Text = dt.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            */
			#endregion
		}

		private void btExport_Click(object sender, EventArgs e)
        {
           
            string filename = "";

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Title = "Save Csv Files";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "Csv files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
				var lstResult = new List<EASTECH_PROGRAMHISTORY>();
				if (cbSelectSearch.Text.Equals("Program Key"))
				{
					lstResult=SmtEtProgramHistoryDAL.Instance.DownloadData(1, txtPart.Text.Trim());
				}
				if (cbSelectSearch.Text.Equals("Part code"))
				{
					lstResult=SmtEtProgramHistoryDAL.Instance.DownloadData(1, txtPart.Text.Trim());
				}
				if (lstResult.Count>0)
				{
					try
					{
						CommonDAL.Instance.WriteCSV(lstResult, filename);
						MessageBox.Show("Export Finished !!!");
					}
					catch (Exception ex)
					{
						MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
						
				}
                //if (dgView.Rows.Count > 0)
                //{
                //    CommonDAL.Instance.writeCSV(dgView, filename);
                //    MessageBox.Show("Đã Export Thành Công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Không có dữ liệu để export !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }           
        }

		private void iconbtnNext_Click(object sender, EventArgs e)
		{
			currentPage++;
			if (currentPage>totalPages)
			{
				currentPage = totalPages;
			}
			lblcurrentPage.Text = currentPage.ToString();
			if (cbSelectSearch.Text.Equals("Program Key"))
            {
				LoadDataByPage(2,currentPage, search);
			}
			if (cbSelectSearch.Text.Equals("Part code"))
			{
				LoadDataByPage(1, currentPage, search);
			}


		}

		private void iconbtnBefore_Click(object sender, EventArgs e)
		{
			if (currentPage > 1)
			{
				currentPage--;
				lblcurrentPage.Text = currentPage.ToString();
				if (cbSelectSearch.Text.Equals("Program Key"))
				{
					LoadDataByPage(2, currentPage, search);
				}
				if (cbSelectSearch.Text.Equals("Part code"))
				{
					LoadDataByPage(1, currentPage, search);
				}
			}
		}

		private void txtPart_KeyDown(object sender, KeyEventArgs e)
		{
            if (Keys.Enter==e.KeyCode)
            {
				search = txtPart.Text.Trim();
				if (cbSelectSearch.Text.Equals("Program Key"))
				{
					LoadDataByPage(1, currentPage, search);
				}
				if (cbSelectSearch.Text.Equals("Part code"))
				{
					LoadDataByPage(2, currentPage, search);
				}
			}
		}

		private void frmViewChangeMaterialHistory_Load(object sender, EventArgs e)
		{
            cbSelectSearch.Text = "--Select--";
		}
	}
}
