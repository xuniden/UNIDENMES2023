using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SMTPROGRAM_Bu;
using SMTPROGRAM_Da;

namespace SMTPRORAM
{
    public partial class F_Update_CutLot_ChangeLine : Form
    {
        public F_Update_CutLot_ChangeLine()
        {
            InitializeComponent();
        }

        private void F_Update_CutLot_ChangeLine_Load(object sender, EventArgs e)
        {
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = Program.username;
            
        }

        private void txtprogram_KeyDown(object sender, KeyEventArgs e)
        {
            txtprogram.Text = txtprogram.Text.Trim().ToUpper();
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckProgKey(txtprogram.Text);
                if (dt.Rows.Count>0 )
                {
                    label10.Text = "OK";
                    label10.ForeColor = System.Drawing.Color.Green;
                    txtprogram.Enabled = false;
                    SendKeys.Send("{TAB}");                    
                }
                else
                {
                    MessageBox.Show("Chưa có Chương trình này trong dữ liệu P1 !!!");
                    label10.Text = "NG";
                    label10.ForeColor = System.Drawing.Color.Red;
                    txtprogram.Focus();
                    txtprogram.SelectAll();
                }
            }
        }

        private void txtfeeder_KeyDown(object sender, KeyEventArgs e)
        {
            txtfeeder.Text = txtfeeder.Text.Trim().ToUpper();
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckFeeder(txtprogram.Text,    txtfeeder.Text);
                if (dt.Rows.Count>0)
                {
                    label11.Text = "OK";
                    label11.ForeColor = System.Drawing.Color.Green;                    
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    MessageBox.Show("Chưa có Chương trình này trong dữ liệu P1 !!!");
                    label11.Text = "NG";
                    label11.ForeColor = System.Drawing.Color.Red;
                    txtfeeder.Focus();
                    txtfeeder.SelectAll();
                }
            }
            
        }

        private void txtpart_KeyDown(object sender, KeyEventArgs e)
        {
            txtpart.Text = txtpart.Text.Trim().ToUpper();
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckPartscode(txtprogram.Text, txtfeeder.Text,txtpart.Text);
                if (dt.Rows.Count > 0)
                {
                    label12.Text = "OK";
                    label12.ForeColor = System.Drawing.Color.Green;
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    MessageBox.Show("Chưa có Chương trình này trong dữ liệu P1 !!!");
                    label12.Text = "NG";
                    label12.ForeColor = System.Drawing.Color.Red;
                    txtfeeder.Focus();
                    txtfeeder.SelectAll();
                }
            }
        }

        private void txtLineName_KeyDown(object sender, KeyEventArgs e)
        {
            txtLineName.Text = txtLineName.Text.Trim().ToUpper();
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt = EastechHistory_Services.EastechHistory_CheckLinename(txtprogram.Text, txtfeeder.Text, txtpart.Text,txtLineName.Text);
                if (dt.Rows.Count > 0)
                {
                    label13.Text = "OK";
                    label13.ForeColor = System.Drawing.Color.Green;
                    cbnumber.DataSource = dt;
                    cbnumber.DisplayMember = "Solanthaylinhkien";
                    cbnumber.ValueMember = "Solanthaylinhkien";
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    MessageBox.Show("Chưa có Chương trình này trong dữ liệu P1 !!!");
                    label13.Text = "NG";
                    label13.ForeColor = System.Drawing.Color.Red;
                    txtfeeder.Focus();
                    txtfeeder.SelectAll();
                }
            }
        }

        private void cbnumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x;
            x=int.Parse(cbnumber.Text.Trim().ToString());
            DataTable dt = new DataTable();
            dt = EastechHistory_Services.EastechHistory_GetQty(txtprogram.Text, txtfeeder.Text, txtpart.Text, txtLineName.Text, x);
            if (dt.Rows.Count>0)
            {
                txtqty.Text = dt.Rows[0]["Solanthaylinhkien"].ToString();
                txtDatecode.Text= dt.Rows[0]["datecode"].ToString();
                txtDesc.Text= dt.Rows[0]["ndesc"].ToString();
                txtUsage.Text= dt.Rows[0]["usage"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu !!!");
                return;
            }
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int x=0; int y = 0;
            x = int.Parse(txtqty.Text.Trim());
            y = int.Parse(txtUsage.Text.Trim());
            if (x<0 || txtqty.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không nhập giá trị nhỏ hơn 0 !!!");
                txtqty.Focus();
                return;
            }
            else
            {
                if (txtDatecode.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Không được để trống ô này !!!");
                    txtDatecode.Focus();
                    return;
                }
                else
                {
                    if (txtDesc.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Không được để trống ô này !!!");
                        txtDesc.Focus();
                        return;
                    }
                    else
                    {
                        // thực hiện ghi lại dữ liệu vào csdl
                        var obj = new EastechHistory_Info();
                        // tính lại số lượng pcb có thể dùng
                        // = Qty/usage
                        int sopcb = 0;
                        if (x>0 )
                        {
                            if (y>0)
                            {
                                sopcb = x / y;
                            }
                            else if (y==0)
                            {
                                sopcb = x;
                            }
                            else
                            {
                                MessageBox.Show("Dữ liệu không đúng F_Update_CutLot_ChangeLine !!!");
                                return;
                            }                            
                        }
                        //else
                        //{
                        //    MessageBox.Show("Dữ Qty không đúng F_Update_CutLot_ChangeLine !!!");
                        //    return;
                        //}
                        //----------------------------
                        obj.programpartlist = txtprogram.Text;
                       // obj.pkey = ""; //prop+line+feeder+partcode
                       // obj.psubkey = ""; // prog+line+feeder
                        obj.fdrno = txtfeeder.Text;
                        obj.partscode = txtpart.Text;
                        obj.ndesc = txtDesc.Text;
                        //obj.usage=""
                        obj.checkedby = Program.username;
                        obj.checkedtime = DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss");
                        obj.reqqty = txtqty.Text;
                        obj.datecode = txtDatecode.Text;
                        obj.Solanthaylinhkien = cbnumber.Text;
                        obj.SoPCBCothedung = sopcb.ToString();
                        obj.remark1 = txtLineName.Text.Trim().ToUpper();
                        try
                        {
                            EastechHistory_Services.EastechHistory_UpdateAfter_CutLot_ChangeLine(obj);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra tại F_Update_CutLot_ChangeLine !!! " + ex.Message);
                            return;
                        }

                    }
                }
            }
        }
    }
}
