using SMTPROGRAM_Bu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.SysControl.Setup;
using UnidenDTO;

namespace SMTPRORAM.Smt.DataControl
{
    public partial class frmViewUploadHistory : Form
    {
        //private int export=0 ;
        private List<PROGRAM> lstResult;
        public frmViewUploadHistory()
        {
            InitializeComponent();
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            DateTime start = txtstart.Value.Date;
            DateTime endd = txtend.Value.Date;

            TimeSpan diff = endd.Subtract(start);
            if (diff.TotalDays > 0)
            {
                // Lấy dữ liệu theo ngày đưa vào và dữ liệu theo PROGRAM PARTS LIST
                //export = 1;
                try
                {
                    lstResult= new List<PROGRAM>();
                    lstResult = SmtProgramDAL.Instance.getListByDate(start, endd);
                    if (lstResult.Count>0)
                    {
                        CommonDAL.Instance.ShowDataGridView(dgView, lstResult.Take(1000).ToList());
                       
                        lblCount.Text = lstResult.Count.ToString();
                    }
                    
                    else
                    {
                        MessageBox.Show("Không có dữ liệu !!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }
        }

        private void btnSearchProgram_Click(object sender, EventArgs e)
        {
            try
            {
               // export = 2;
                lstResult = new List<PROGRAM>();
                lstResult = SmtProgramDAL.Instance.getListByProgram(txtpartlist.Text.Trim());
                if (lstResult.Count > 0)
                {
                    CommonDAL.Instance.ShowDataGridView(dgView,lstResult.Take(1000).ToList());
                    lblCount.Text = lstResult.Count.ToString();
                    
                }

                else
                {
                    MessageBox.Show("Không có dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnSearchPart_Click(object sender, EventArgs e)
        {
            try
            {
                //export = 3;
                lstResult = new List<PROGRAM>();
                lstResult = SmtProgramDAL.Instance.getListByPartCode(txtPart.Text.Trim());
                if (lstResult.Count > 0)
                {
                    CommonDAL.Instance.ShowDataGridView(dgView, lstResult.Take(2000).ToList());
                    lblCount.Text = lstResult.Count.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (txtDeleteKey.Text.Trim().Equals(""))
            {
                MessageBox.Show("Hãy nhập tên chương trình cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                result = SmtProgramDAL.Instance.deleteProgramByKey(txtDeleteKey.Text.Trim());
                if (result == true)
                {
                    MessageBox.Show("Đã xóa thành công dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Khi xóa dữ liệu ở đây sẽ phải xóa trong cả UV_MODELINFO
                    string message = "";
                    message=MODELLOTINFO_DAL.Instance.DeleteByProgram(txtDeleteKey.Text.Trim());
                    if (message!="")
                    {
                        MessageBox.Show("Không xóa được dữ liệu ở Model Lot Infor: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Không xóa được dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            try
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
                    if (lstResult.Count>0)
                    {
                        CommonDAL.Instance.WriteCSV(lstResult, filename);
                        MessageBox.Show("Đã Export Thành Công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để export !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                throw;
            }
        }
    }
}
