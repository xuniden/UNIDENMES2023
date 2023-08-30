using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Excel;
using SMTPROGRAM_Bu;
using SMTPRORAM.SysControl.IT;
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
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Smt.Output;
using UnidenDTO;

namespace SMTPRORAM.Smt.Output
{
    public partial class frmCheckOutputErrorAndApprove : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }  



        bool closeForm =false;
        private readonly frmF_EastechCheckQRCode frm1; //readonly is optional (For safety purposes)
        private long Id = 0;
        public frmCheckOutputErrorAndApprove(frmF_EastechCheckQRCode frm)
        {
            InitializeComponent();
            frm1 = frm;
        }        

        private void frmCheckOutputErrorAndApprove_Load(object sender, EventArgs e)
        {
            lblApprove.Text =string.Empty;
            lblRemark.Text = string.Empty;
            richTextBox.Text = frmF_EastechCheckQRCode.messageError;
            Id = frmF_EastechCheckQRCode.newID;
            
        }
        private bool checkRemark()
        {
            if(string.IsNullOrEmpty(txtRemark.Text.Trim()))
            {
                CommonDAL.Instance.SetStatusLabels(lblRemark, "NG");
                txtRemark.Focus();
                return false;
            }
            return true;

        }
        private bool checkApprove()
        {

			if (string.IsNullOrEmpty(txtApprove.Text.Trim()))
			{
				CommonDAL.Instance.SetStatusLabels(lblApprove, "NG");
				txtApprove.Focus();
				return false;
			}
            var checkApprove= LeaderApproveDAL.Instance.checkApproveStaffID(txtApprove.Text.Trim());
            if (checkApprove==null)
            {
				CommonDAL.Instance.SetStatusLabels(lblApprove, "NG");
				txtApprove.Focus();
				return false;
			}		
			return true;
        }

        private bool isOKData()
        {
            if (!checkRemark())
            {
                return false;
            }
            if (!checkApprove())
            {
                return false;
            }
            return true;
        }
        private void iconbtnApprove_Click(object sender, EventArgs e)
        {
            if (isOKData())
            {
                var upNew = new EASTECH_ERROR_LOG_APPROVE
                {
                    ApprovedDate = CommonDAL.Instance.getSqlServerDatetime(),
                    Aprroved = txtApprove.Text.Trim(),
                    Remark = txtApprove.Text.Trim(),
                    ID = Id
                };
                string message = EASTECH_ERROR_LOG_APPROVE_DAL.Instance.Update(upNew);
                if (string.IsNullOrEmpty(message))
                {
					this.Close();
				}
                else
                {
					MessageBox.Show("Đã có lỗi xảy ra: " +message+ " liên hệ IT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				#region Old Code
				/*
				var dt = new System.Data.DataTable();
				dt = EastechOutputHistory_Services.LeaderEastechErrorLogCheckID(txtApprove.Text.Trim());
				if (dt.Rows.Count > 0)
				{
					try
					{
						EastechOutputHistory_Services.EastechErrorLog_Update(Id, txtApprove.Text.Trim(), txtRemark.Text.Trim(), DateTime.Now);
						// closeForm = true;
						this.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message + " liên hệ IT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
                */
				#endregion
			}
		}
		private void frmCheckOutputErrorAndApprove_FormClosing(object sender, FormClosingEventArgs e)
		{
            var checkSuccess = EASTECH_ERROR_LOG_APPROVE_DAL.Instance.checkUpdateSuccess(Id);
            if (checkSuccess!=null && string.IsNullOrEmpty(checkSuccess.Aprroved))
            {
				e.Cancel = true;
				MessageBox.Show("Chưa nhập thông tin xác nhận lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			#region
            /*
			// Kiểm tra xem đã update được thông tin chưa?
			// Nếu chưa update được thông tin thì không cho đóng form
			var dt = new System.Data.DataTable();
			dt = EastechOutputHistory_Services.EastechErrorLog_CheckUpdate(Id);
			if (dt.Rows.Count > 0)
			{
				if (string.IsNullOrEmpty(dt.Rows[0]["Aprroved"].ToString()))
				{
					e.Cancel = true;
					MessageBox.Show("Chưa nhập thông tin xác nhận lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (dt.Rows[0]["Aprroved"].ToString().Trim().Equals(""))
				{
					e.Cancel = true;
					MessageBox.Show("Chưa nhập thông tin xác nhận lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
            */
			#endregion
		}
	}
}
