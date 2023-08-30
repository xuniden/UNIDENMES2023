using RJCodeAdvance.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.SysControl;
using UnidenDAL;
using UnidenDTO;
using SMTPRORAM.Smt.Input;
using ZedGraph;
using System.Windows.Forms.DataVisualization.Charting;
using UnidenDAL.Smt.Output;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using AxisType = ZedGraph.AxisType;

namespace SMTPRORAM
{
    public partial class frmMain : Form
    {
        private int borderSize = 2;
        private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
        private Form activeForm;
        private Button curentButton;
        UVEntities _entites = new UVEntities();
        public frmMain()
        {
            InitializeComponent();
            //CollapseMenu();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(98, 102, 244);
            btnCloseChildForm.Visible = false;
        }
        private void DrawChart(DataTable dataTable, Panel panel)
        {
            // Khởi tạo ZedGraphControl
            ZedGraphControl zedGraphControl = new ZedGraphControl();

            // Thiết lập thuộc tính cho ZedGraphControl
            zedGraphControl.Dock = DockStyle.Fill;

            // Lấy danh sách điểm
            PointPairList pointPairList = GetPointPairList(dataTable);

            // Khởi tạo đường curve
            LineItem curve = new LineItem("", pointPairList, Color.Red, SymbolType.None, 3.0f);

            // Lấy biểu đồ
            GraphPane graphPane = zedGraphControl.GraphPane;

            // Đặt tiêu đề cho biểu đồ
            graphPane.Title.Text = "SMT Program Output";
            graphPane.Title.FontSpec.FontColor = Color.Blue;

            // Đặt tên cho trục x và y
            graphPane.XAxis.Title.Text = "Model";
            graphPane.XAxis.Title.FontSpec.FontColor = Color.Blue;
            graphPane.YAxis.Title.Text = "Total Count";
            graphPane.YAxis.Title.FontSpec.FontColor = Color.Blue;

            // Đặt giá trị cho trục x
            string[] labels = new string[pointPairList.Count];
            for (int i = 0; i < pointPairList.Count; i++)
            {
                labels[i] = pointPairList[i].Tag.ToString();
            }
            graphPane.XAxis.Scale.TextLabels = labels;
            graphPane.XAxis.Type = AxisType.Text;

            // Thêm curve vào biểu đồ
            graphPane.CurveList.Add(curve);

            // Vẽ biểu đồ
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();

            // Thêm ZedGraphControl vào Panel
            panel.Controls.Add(zedGraphControl);
        }
        private PointPairList GetPointPairList(DataTable dataTable)
        {
            var pointPairList = new PointPairList();

            foreach (DataRow row in dataTable.Rows)
            {
                var model = row["Model"].ToString();

                var INSERT = (int)row["INSERT"];
                var SMT= (int)row["SMT"];

                var label = $"{model} ({INSERT}, {SMT})";

                pointPairList.Add(new PointPair(pointPairList.Count + 1,500000, label));
            }

            return pointPairList;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
           // var chart = DrawChart() as Control;
           // DataTable dataTable = SmtAOIQrCodeOutputDAL.Instance.getDataForChart();
           // DrawChart(dataTable, panelSMT);
            
            var lstButtonUserRight = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lstButtonUserRightNew = SYSButtonFunctionDAL.Instance.getByUserId(Program.UserId);



            var lstUserRight = SYSUserMenuFuctionDAL.Instance.getUserFunction(Program.UserId);
            var lstUserRightNew = SYSUserMenuFuctionDAL.Instance.getUserFunctionNew(Program.UserId);
            var lstMenuFunction = SYSMenuDAL.Instance.getListMenu();
            if (Program.username.ToLower()!="admin")
            {
                DisableAllMenuFunction(rjSystem0101, lstMenuFunction, rjSystem01);
                DisableAllMenuFunction(rjSmt0101, lstMenuFunction, rjSmt01);
                DisableAllMenuFunction(rjWhs0101, lstMenuFunction, rjWhs01);
                DisableAllMenuFunction(rjAssy0101, lstMenuFunction, rjAssy01);
                DisableAllMenuFunction(rjPe0101, lstMenuFunction, rjPe01);

                ShowMeunuFunction(rjSystem0101, lstUserRightNew, rjSystem01);
                ShowMeunuFunction(rjSmt0101, lstUserRightNew, rjSmt01);
                ShowMeunuFunction(rjWhs0101, lstUserRightNew,rjWhs01);
                ShowMeunuFunction(rjAssy0101, lstUserRightNew, rjAssy01);
                ShowMeunuFunction(rjPe0101, lstUserRightNew,rjPe01);
            }     
            ShowMeunuFunction(rjSystem0101, lstUserRight, rjSystem01);
            ShowMeunuFunction(rjSmt0101, lstUserRight, rjSmt01);
            ShowMeunuFunction(rjWhs0101, lstUserRight, rjWhs01);
            ShowMeunuFunction(rjAssy0101, lstUserRight, rjAssy01);
            ShowMeunuFunction(rjPe0101, lstUserRight, rjPe01);
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override void WndProc(ref Message message)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            //const int WM_SYSCOMMAND = 0x0112;
            //const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            //const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (message.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref message);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)message.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(message.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                message.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                message.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                message.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                message.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                message.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                message.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                message.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                message.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            if (message.Msg == WM_NCCALCSIZE && message.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
            //if (message.Msg == WM_SYSCOMMAND)
            //{
            //    /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
            //    /// Quote:
            //    /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
            //    /// are used internally by the system.To obtain the correct result when testing 
            //    /// the value of wParam, an application must combine the value 0xFFF0 with the 
            //    /// wParam value by using the bitwise AND operator.
            //    int wParam = (message.WParam.ToInt32() & 0xFFF0);
            //    if (wParam == SC_MINIMIZE)  //Before
            //        formSize = this.ClientSize;
            //    if (wParam == SC_RESTORE)// Restored form(Before)
            //        this.Size = formSize;
            //}
            base.WndProc(ref message);
        }
       
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) // Collapse menu
            {
                panelMenu.Width = 60;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else // Expand menu
            {
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "    " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }




        private void Open_DropdownMenu(RJDropdownMenu dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev)
                => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);
        }

        private void DropdownMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
                if (dropdownMenu.Visible)
                    ctrl.BackColor = Color.FromArgb(159, 161, 224);
                else
                    ctrl.BackColor = Color.FromArgb(98, 102, 224);
            }
        }
       
       

       

       
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (curentButton != (Button)btnSender)
                {
                    DisableButton();
                    //Color color = (Button)btnSender;
                    curentButton = (Button)btnSender;
                    curentButton.BackColor = Color.FromArgb(51, 51, 76);
                    curentButton.ForeColor = Color.White;
                    curentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void OpenChildFormM(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitle.Text = childForm.Text;
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.PowderBlue; //Color.FromArgb(51, 51, 76); // 0, 150, 136
            curentButton = null;
            btnCloseChildForm.Visible = false;
        }
        private void DisableAllMenuFunction(RJDropdownMenu Menu, List<SYS_MenuFunction> ltsMenuFunction , Button iconbtn)
        {
            foreach (ToolStripMenuItem parent in Menu.Items)
            {
                foreach (var item1 in ltsMenuFunction)
                {
                    if (parent.Name == item1.MenuId)
                    {
                        parent.Visible = false;
                        iconbtn.Visible = false;
                    }
                }
                foreach (ToolStripMenuItem children1 in parent.DropDownItems)
                {
                    foreach (var item2 in ltsMenuFunction)
                    {
                        if (children1.Name == item2.MenuId )
                        {
                            children1.Visible = false;
                        }
                    }
                    foreach (ToolStripMenuItem children2 in children1.DropDownItems)
                    {
                        foreach (var item3 in ltsMenuFunction)
                        {
                            if (children2.Name == item3.MenuId )
                            {
                                children2.Visible = false;
                            }
                        }
                    }
                }
            }
        }


        private void ShowMeunuFunction(RJDropdownMenu Menu, List<SYS_UserMenuFuction> ltsUMFunction,Button iconbtMaxParent)
        {
            //====================
            foreach (ToolStripMenuItem parent in Menu.Items)
            {
                foreach (var item in ltsUMFunction)
                {
                    if (parent.Name == item.MenuId && item.AccessMenu == true)
                    {
                        parent.Visible = true;                        
                        iconbtMaxParent.Visible = true;
                    }
                }
                foreach (ToolStripMenuItem children1 in parent.DropDownItems)
                {
                    foreach (var item in ltsUMFunction)
                    {
                        if (children1.Name == item.MenuId && item.AccessMenu == true)
                        {
                            children1.Visible = true;
                        }
                    }
                    foreach (ToolStripMenuItem children2 in children1.DropDownItems)
                    {
                        foreach (var item in ltsUMFunction)
                        {
                            if (children2.Name == item.MenuId && item.AccessMenu == true)
                            {
                                children2.Visible = true;
                            }
                        }
                    }
                }
            }
           // ====================
            //foreach (ToolStripMenuItem parent in Menu.Items)
            //{
            //    foreach (var item in ltsUMFunction)
            //    {
            //        if (parent.Name == item.MenuId && item.AccessMenu != true)
            //        {
            //            parent.Visible = false;
            //        }
            //    }
            //    foreach (ToolStripMenuItem children1 in parent.DropDownItems)
            //    {
            //        foreach (var item in ltsUMFunction)
            //        {
            //            if (children1.Name == item.MenuId && item.AccessMenu != true)
            //            {
            //                children1.Visible = false;
            //            }
            //        }
            //        foreach (ToolStripMenuItem children2 in children1.DropDownItems)
            //        {
            //            foreach (var item in ltsUMFunction)
            //            {
            //                if (children2.Name == item.MenuId && item.AccessMenu != true)
            //                {
            //                    children2.Visible = false;
            //                }
            //            }
            //        }
            //    }
            //}
        }
        private void UpdateMenu(RJDropdownMenu Menu)
        {
            foreach (ToolStripMenuItem parent in Menu.Items)
            {
                var menuP = new SYS_MenuFunction();
                menuP.MenuId = parent.Name;
                menuP.MenuDesc = parent.Text;
                menuP.Parent = null;
                menuP.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                menuP.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                //_entites.SYS_MenuFunction.AddOrUpdate(menuP);
                SYSMenuDAL.Instance.AddorUpdateMenu(menuP);
                // _entites.SYSMenus.Add(menuP);//.AddOrUpdate(menuP);

                foreach (ToolStripMenuItem children1 in parent.DropDownItems)
                {
                    var menuC1 = new SYS_MenuFunction();
                    menuC1.MenuId = children1.Name;
                    menuC1.MenuDesc = children1.Text;
                    menuC1.Parent = parent.Name;

                    menuC1.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    menuC1.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    SYSMenuDAL.Instance.AddorUpdateMenu(menuC1);
                    //_entites.SYS_MenuFunction.AddOrUpdate(menuC1);

                    foreach (ToolStripMenuItem children2 in children1.DropDownItems)
                    {
                        var menuC2 = new SYS_MenuFunction();
                        menuC2.MenuId = children2.Name;
                        menuC2.MenuDesc = children2.Text;
                        menuC2.Parent = children1.Name;

                        menuC2.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        menuC2.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        //_entites.SYS_MenuFunction.AddOrUpdate(menuC2);
                        SYSMenuDAL.Instance.AddorUpdateMenu(menuC2);


                    }
                }
            }
        }
       
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;                
                if (formSize.Height==0&&formSize.Width==0)
                {
                    frmMain fm= new frmMain();
                    this.Size = fm.Size;                  
                }
                else
                {
                    this.Size= formSize;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            bool logout = SessionLoginDAL.Instance.Remove(Program.UserId);
            if (logout != true)
            {
                MessageBox.Show("Không xóa được Login Section", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Application.Exit();
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void rjSystem01_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjSystem0101, sender);
        }

        private void rjSmt01_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjSmt0101, sender);
        }

        private void rjWhs01_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjWhs0101, sender);
        }

        private void rjAssy01_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjAssy0101, sender);
        }


        private void rjSystem01010102_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmUser());
        }

        private void rjSystem01010101_Click(object sender, EventArgs e)
        {
            UpdateMenu(rjSystem0101);
            UpdateMenu(rjSmt0101);
            UpdateMenu(rjWhs0101);
            UpdateMenu(rjAssy0101);
            UpdateMenu(rjPe0101);
            //_entites.SaveChanges();
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmMenu());
        }

        private void rjSystem01010103_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmUserRight());
        }

        private void rjSystem01010104_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmButtonFunction());
        }

        private void rjSystem01010105_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmUserButtonFunction());
        }

        private void rjSystem01010201_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmDiv());
        }

        private void rjSystem01010202_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmDept());
        }

        private void rjSystem01010301_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Staging.frmPro_Line());
        }

        private void rjSmt01010101_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Staging.frmPcbList());
        }

        private void rjSmt01010102_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Staging.frmLocation());
        }

        private void rjSmt01010103_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Staging.frmINPUT());
        }

        private void rjSmt01010104_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Staging.frmOUTPUT());
        }

        private void rjSmt01010105_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Staging.frmReport());
        }

        private void iconbtnRestart_Click(object sender, EventArgs e)
        {
            bool logout = SessionLoginDAL.Instance.Remove(Program.UserId);
            if (logout != true)
            {
                MessageBox.Show("Không xóa được Login Section", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Application.Restart();
        }

        private void iconbtnChangePassword_Click(object sender, EventArgs e)
        {
            SysControl.frmChangePassword frm = new SysControl.frmChangePassword();
            frm.Show();
        }

        private void iconBtnExit_Click(object sender, EventArgs e)
        {
            bool logout = SessionLoginDAL.Instance.Remove(Program.UserId);
            if (logout!=true)
            {
                MessageBox.Show("Không xóa được Login Section", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }            
            Application.Exit();           
        }

        private void rjWhs01010101_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmReceivingInput());
        }

        private void rjWhs01010102_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmWhsLocation());
        }

        private void rjWhs01010103_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmWhs_Lottag_Iqc());
        }

        private void rjWhs01010104_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmIqc_Lottag());
        }

        private void rjWhs01010105_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmIqc_Result());
        }

        private void rjWhs01010106_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmWhsIn());
        }

        private void rjSmt0101020101_Click(object sender, EventArgs e)
        {
            //btnCloseChildForm.Visible = true;
            //OpenChildFormM(new Smt.DataControl.frmUploadBOM());
            Smt.DataControl.frmUploadBOM frm = new Smt.DataControl.frmUploadBOM();
            frm.Show();
        }

        private void rjSmt0101020102_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.DataControl.frmViewUploadHistory());
        }

        private void rjSmt0101020103_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.DataControl.frmViewChangeMaterialHistory());
        }

        private void rjSmt0101020201_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.DataControl.frmSetupPcbCode());
        }

        private void rjSmt0101020202_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.DataControl.frmCreateQRCode());
        }

        private void rjSmt01010203_Click(object sender, EventArgs e)
        {
            //btnCloseChildForm.Visible = true;
            //OpenChildFormM(new Smt.Output.frmAOIQrcodeOutput());

            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Output.frmF_EastechCheckQRCode());
        }

      

        private void rjSmt010104_Click(object sender, EventArgs e)
        {
            frmF_Insert_UserCheck frm = new frmF_Insert_UserCheck();
            frm.Show();
        }

        private void rjSmt010103_Click(object sender, EventArgs e)
        {
            //btnCloseChildForm.Visible = true;
            //OpenChildFormM(new Smt.Input.frmIPQCCheck());
            frmFUserCheck fv = new frmFUserCheck();
            fv.Show();

            //Smt.Input.frmIPQCCheck frm = new Smt.Input.frmIPQCCheck();
            //frm.Show();
        }

        private void rjWhs01010107_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmPoErrorKeyin());
        }

        private void rjAssy01010101_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.ET.frmAssyETCheckProcess());
        }

        private void rjAssy01010102_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.ET.frmFAssyToEastech());
        }

        private void rjSmt01010501_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Repair.frmF_Smt_Repair_Data());
        }

        private void rjSmt01010502_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Repair.frmF_Smt_Repair_Result());
        }

        private void rjSmt01010503_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Repair.frmF_Smt_Repair_Result_View());
        }

        private void downloadDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.ET.frmFAssyDownload());
        }

        private void rjSmt01010601_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.View.frmFViewByQRCode());
        }

        private void rjSystem010104_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.frmLoginSectionManage());
        }

        private void rjWhs01010108_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmMonitorFedexDhlOther());
        }

        private void rjWhs01010109_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmInputIqcReturn());
        }

        private void rjWhs01010110_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Whs.frmIqcInputReturnResult());
        }

        private void rjAssy01010201_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new BoxET.FBoxETManage());
        }

        private void rjAssy01010202_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new BoxET.FIssueBoxManage());
        }

        private void rjAssy01010203_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new BoxET.FReturnBoxManage());
        }

        private void rjAssy01010204_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new BoxET.FBoxReport());
        }

        private void rjSmt01010701_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.OutSource.frmOutSourceInput());
        }

        private void importDữLiệuOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.OutSource.frmOutSourceImportOrder());
        }

        private void nhậpKếtQuảXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.OutSource.frmOutSourceOutPut());
        }

        private void rjSmt01010804_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.OutsourceBom.frmOUTSOURCE_ET_BOM());
        }

        private void rjSmt01010803_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.OutsourceBom.frmOUTSOURCE_UV_BOM());
        }

        private void rjSmt01010802_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.OutsourceBom.frmOUTSOURCE_UVPartsVsETParts());
        }

        private void rjSmt01010801_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.OutsourceBom.frmOUTSOURCE_UVLotVsETOrder());
        }

        private void rjSmt01010602_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Xemdulieu.frmFViewModelByDate());
        }

        private void rjSmt01010603_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Xemdulieu.frmFViewPartByDate());
        }

        private void rjAssy01010301_Click(object sender, EventArgs e)
        {
            //btnCloseChildForm.Visible = true;
            //OpenChildFormM(new AssyLine.frmModelLotInfo());
        }

        private void rjAssy01010302_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new AssyLine.frmSetupCBModel());
        }

        private void rjPe01_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjPe0101, sender);
        }

        private void rjPe01010101_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmJIGLocation());
        }

        private void rjPe01010102_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmJIGSection());
        }

        private void rjPe01010103_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmJIGCalType());
        }

        private void rjPe01010104_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmJIGCALDEVICES());
        }

        private void rjPe01010105_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmJIGINOUT());
        }

        private void rjPe01010106_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmJIGDenHieuChuan());
        }

        private void rjSystem01010501_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.IT.frmLoaiThietBi());
        }

        private void rjSystem01010502_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.IT.frmITDeviceManagement());
        }

        private void rjSystem01010503_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.IT.frmBuyDeviceMonitor());
        }

        private void rjPe01010107_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmJIGReport());
        }

        private void rjSystem01010504_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.IT.frmIssueHistory());
        }

        private void rjSmt01010204_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Output.frmLeaderApprove());
        }

        private void rjPe01010108_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmCalHistory());
        }

        private void rjPe01010109_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmInventory());
        }

        private void rjSystem01010601_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.Setup.frmFACTORY());
        }

        private void rjSystem01010602_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new SysControl.Setup.frmUVQRCODEMANAGEMENT());
        }

        private void rjAssy01010303_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.Setup.frmSetupProcessLine());
        }

        private void rjAssy010104_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.frmCheckNonProcessHistory());
        }

        private void rjPe01010201_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.JIG.frmHLocation());
        }

        private void rjPe01010202_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.JIG.frmHJIGDEVICES());
        }

        private void rjPe01010110_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmViewCalibrationDevices());
        }

        private void rjPe01010204_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.JIG.frmViewAllJIG());
        }

        private void rjPe01010203_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.JIG.frmINOUTJIG());
        }

        private void rjPe01010205_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.JIG.frmJIGHReport());
        }

        private void rjAssy010105_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.frmCheckProcessHistory());
        }

        private void rjPe01010111_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Jig.frmEQRepairHistory());
        }

        private void rjAssy010106_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.frmCombineQRCode());
        }

        private void rjAssy010107_Click(object sender, EventArgs e)
        {
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Assy.frmCombineBarCodeVsUnit());
        }

		private void rjAssy01010304_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.Setup.frmAddErrorCode());
		}

		private void rjAssy01010306_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.Setup.frmAddCauseDept());
		}

		private void rjAssy01010305_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.Setup.frmCauseCode());
		}

		private void rjAssy010108_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.frmRepairHistory());
		}

		private void rjSmt010109_Click(object sender, EventArgs e)
		{
            //btnCloseChildForm.Visible = true;
            //         OpenChildFormM(new Smt.Input.frmSmt_StdOp_History());

            //frmSmt_StdOp_History fv = new frmSmt_StdOp_History();
            //fv.Show();
            btnCloseChildForm.Visible = true;
            OpenChildFormM(new Smt.Input.NewFrmOperator_Check());

        }

		private void rjSmt010110_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Smt.Input.frmNewIPQCCheck());
		}

		private void rjAssy010109_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.frmRepairIssueByLine());
		}

		private void rjAssy01010307_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.Setup.frmEditUnitByBarcode());
		}

		private void rjPe01010206_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Jig.JIG.frmJIGRepairHistory());
		}

		private void rjAssy01011001_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.Report.frmDownloadDDR());
		}

		private void rjAssy01011003_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Assy.Report.frmFromQRToHistory());
		}

		private void rjPe01010207_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Jig.JIG.frmJigReport());
		}

		private void rjSmt010111_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new Smt.Input.frmCutLot());
		}

		private void rjAssy01011101_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.frmMODELLOT_SETUP());
		}

		private void rjAssy01011102_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.frmLotControlSetup());
		}

		private void rjAssy0101110401_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.ETASSY.frmGeneralSerial());
		}

		private void rjAssy0101110402_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.ETASSY.frmPCBCodeSetup());
		}

		private void rjAssy0101110403_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.ETASSY.frmWirelessQRImport());
		}

		private void rjAssy0101110701_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.REPAIR.frmRepairSetup());
		}

		private void rjAssy0101110101_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.frmMODELLOT_SETUP());
		}

		private void rjAssy0101110702_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.REPAIR.frmCreateRepairCode());
		}

		private void rjAssy0101110703_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.REPAIR.frmRepairModel());
		}

		private void rjAssy0101110601_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.frmLotControlSetup());
		}

		private void rjAssy0101110602_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
            OpenChildFormM(new AssyLine.UG.frmCOM1());
		}

		private void rjAssy0101110102_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.frmSetupCBModel());
		}

		private void rjAssy0101110103_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.MENU.frmCBCheckData());
		}

		private void rjAssy0101110603_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.UG.frmCOM2());
		}

		private void rjAssy0101110104_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.MENU.frmCOM21());
		}

		private void rjAssy0101110301_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.REPAIR.frmKeyinSamsungRepair());
		}

		private void rjAssy0101110105_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.REPAIR.frmRepairKeyIn());
		}

		private void rjAssy0101110501_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.MENU.frmUpdateBatch());
		}

		private void rjAssy0101110502_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.MENU.frmChangeBatch());
		}

		private void rjAssy0101110106_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.MENU.frmEastechSerialControl());
		}

		private void rjAssy0101110201_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.VIEW.frmViewCBData());
		}

		private void rjAssy0101110202_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.VIEW.frmViewUGCOM2());
		}

		private void rjAssy0101110203_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.VIEW.frmDailyOutputCOM2());
		}

		private void rjAssy0101110204_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.VIEW.frmViewRepairKeyIn());
		}

		private void rjAssy0101110205_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.VIEW.frmViewEastechHistoryInput());
		}

		private void rjAssy0101110206_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.VIEW.frmPrintQRCode());
		}

		private void rjAssy0101110207_Click(object sender, EventArgs e)
		{
			btnCloseChildForm.Visible = true;
			OpenChildFormM(new AssyLine.VIEW.frmViewSamsungRepair());
		}
	}
}
