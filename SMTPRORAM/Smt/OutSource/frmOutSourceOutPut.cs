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
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.Smt.DataControl;
using UnidenDAL.Smt.OutSource;
using System.Windows.Controls;
using Excel=Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Web.Services.Description;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace SMTPRORAM.Smt.OutSource
{
    public partial class frmOutSourceOutPut : Form
    {
        bool AddFlag = false;
        private List<SYS_UserButtonFunction> lstUBFunction;
        long Id = 0;
        public frmOutSourceOutPut()
        {
            InitializeComponent();
        }
        private void HienThiTatCa()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_OUTPUTDAL.Instance.HienThiTatCa());
        }
        private void frmOutSourceOutPut_Load(object sender, EventArgs e)
        {
            HienThiTatCa();
            //showHideControll(true);
            //_enable(false);         

            // Kiểm tra xem button có được enable hay không?
            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        //void _enable(bool t)
        //{
        //    txtOrderNo.Enabled = t;
        //    txtOutputQty.Enabled = t;
        //    txtRemark.Enabled = t;
        //    chkStatus.Enabled = t;
        //}

        //void ResetControll()
        //{

        //    txtOrderNo.Text = "";
        //    txtOutputQty.Text = "";
        //    chkStatus.Checked = false;
        //    txtRemark.Text = "";            
        //}
        //void showHideControll(bool t)
        //{
        //    iconbtnAdd.Visible = t;
        //    iconbtnEdit.Visible = t;
        //    iconbtnDelete.Visible = t;
        //    iconbtnCancel.Visible = !t;
        //    iconbtnSave.Visible = !t;
        //}

        //private void iconbtnAdd_Click(object sender, EventArgs e)
        //{
        //    AddFlag = true;
        //    showHideControll(false);
        //    _enable(true);
        //    ResetControll();
        //    txtOrderNo.Focus();
        //}

        //private void iconbtnEdit_Click(object sender, EventArgs e)
        //{
        //    if (Id > 0)
        //    {
        //        AddFlag = false;
        //        _enable(true);
        //        showHideControll(false);
        //        txtOrderNo.Focus();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Phải chọn dữ liệu để sửa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        //private void iconbtnDelete_Click(object sender, EventArgs e)
        //{
        //    if (Id > 0)
        //    {
        //        if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //        {
        //            bool flag = false;
        //           // bool flag = SmtSetupPcbCodeDAL.Instance.Remove(Id);
        //            if (flag == true)
        //            {
        //                MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                SMT_OUTSOURCE_OUTPUTDAL.Instance.HienThiDuLieuTheoUserVaNgayThang(Program.UserId);
        //                return;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Xóa không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //        }
        //    }
        //}
        //private bool IsDataOK()
        //{
        //    if (txtOrderNo.Text.Trim().Equals("") )
        //    {
        //        MessageBox.Show("Order No không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtOrderNo.Focus();
        //        return false;
        //    }
        //    if (txtOutputQty.Text.Trim().Equals("") )
        //    {
        //        MessageBox.Show("Số lượng xuát không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtOutputQty.Focus();
        //        return false;
        //    }            
        //    return true;
        //}

        //private void iconbtnSave_Click(object sender, EventArgs e)
        //{
        //    if (IsDataOK() == true)
        //    {
        //        var orderNo = new SMT_OUTSOURCE_OUTPUT();
        //        orderNo.OrderNo = txtOrderNo.Text.Trim();
        //        orderNo.OuputQty = long.Parse(txtOutputQty.Text.Trim());
        //        if (chkStatus.Checked==true)
        //        {
        //            orderNo.OrderStatus =true;
        //        }
        //        else
        //        {
        //            orderNo.OrderStatus = false;
        //        }                
        //        orderNo.Remark = txtRemark.Text;
        //        orderNo.CreatedBy = Program.UserId;                
                
        //        if (AddFlag)
        //        {
        //            orderNo.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
        //            orderNo.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
        //            // Xử lý trừ dữ liệu tồn kho
        //            // 2) Kiểm tra xem OrderNo này đã được đóng trên OUTPUT chưa?
        //            var outputRecod = new SMT_OUTSOURCE_OUTPUT();
        //            bool checkOrderClosed=SMT_OUTSOURCE_OUTPUTDAL.Instance.KiemtraOrderClosed(txtOrderNo.Text.Trim());
        //            if (checkOrderClosed)
        //            {
        //                MessageBox.Show("Số OrderNo: " + txtOrderNo.Text.Trim() + " đã được đóng trên hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }

        //            // 1) Kiểm tra xem OutputQty<=Input Qty không?
        //            // 3) Kiểm tra xem OrderNO này đã ouput lần nào chưa?
        //            //    Nếu đã output rồi thì tổng output có nhỏ hơn Input không?
        //            // 
        //            var sumQtyOutput = new List<SumOutPut>();
        //            var inputQty = new SMT_OUTSOURCE_ORDER_IMPORT();
        //            inputQty=SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.LayQtyTheoOrderNo(txtOrderNo.Text.Trim());
        //            sumQtyOutput=SMT_OUTSOURCE_OUTPUTDAL.Instance.TinhQtyOutputTheoOrderNo(txtOrderNo.Text.Trim());
        //            if (sumQtyOutput.Count>0)
        //            {
        //                long totalOutput = 0;
        //                foreach (var item in sumQtyOutput)
        //                {
        //                    totalOutput = totalOutput+ item.OutQty;
        //                }
        //                totalOutput = totalOutput + long.Parse(txtOutputQty.Text.Trim());
        //                if (totalOutput>inputQty.LotSize)
        //                {
        //                    MessageBox.Show("Số lượng nhập vào đã vượt quá Lotsize", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return;
        //                }
        //                if (totalOutput==inputQty.LotSize)
        //                {
        //                    MessageBox.Show("Số xuất đi bằng với Lotsize bạn có muốn đóng Order này không? \n Nếu muốn đóng thì tích vào Close !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return;
        //                }
        //            }
        //            // 4) Lấy thông tin từng linh kiện output của Order 
        //            //    lấy partcode đó xem có còn dữ liệu trong hệ thống để trừ không?

        //            var linhkientonkhoList = SMT_OUTSOURCE_IN_QTYDAL.Instance.getTonKhoList();
        //            var linhkientheoOrderList = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrder(txtOrderNo.Text.Trim());

        //            var NotInRecord = linhkientheoOrderList.Where(p => !linhkientonkhoList.Any(p2 => p2.Partcode == p.Parts)).ToList();

        //            if (NotInRecord.Count>0)
        //            {
        //                MessageBox.Show("Không thể xuất được Order này. Vì không đủ linh kiện để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //            // Nếu đủ linh kiện thì kiểm tra xem có đủ số lượng không?
        //            string lstQty = "";
        //            int output=int.Parse(txtOutputQty.Text.Trim());
        //            bool check = false;
        //            foreach (var item1 in linhkientheoOrderList)
        //            {
        //                var result = linhkientonkhoList.Where(p => p.Partcode == item1.Parts).FirstOrDefault();
        //                if (result==null)
        //                {
        //                    lstQty = lstQty + item1.Parts + ";" + item1.Qty + ";" + item1.LotSize + ";" + item1.MaterialPerPcb + "\n";
        //                    check =true;
        //                }
                         
        //                //foreach (var item2 in linhkientonkhoList)
        //                //{
        //                //    // Tính toán số linh kiện cần dùng
        //                //    if (item1.Parts==item2.Partcode)
        //                //    {
        //                //        double solinhKien = item1.MaterialPerPcb * output;
        //                //        if (solinhKien > item2.Qty)
        //                //        {
        //                //            lstQty = lstQty + item1.Parts + ";" + item1.Qty + ";" + item1.LotSize + ";" + item1.MaterialPerPcb + "\n";
        //                //            check = true;
        //                //            break;
        //                //        }
        //                //    }                            
        //                //}
        //            }
        //            if (check==true)
        //            {
        //                MessageBox.Show("Qty tồn kho không đủ để xuất hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //            // Nếu đủ linh kiện và số lượng rồi thì tiến hành trừ linh kiện ở kho khi xuất hàng
        //            foreach (var item in linhkientheoOrderList)
        //            {
        //                var TonkhoPart = SMT_OUTSOURCE_IN_QTYDAL.Instance.danhsachMacoQty(item.Parts);
        //                var solinhkiencandung=item.MaterialPerPcb * output;
                        
        //                foreach (var item2 in TonkhoPart)
        //                {
        //                    double soconlai = item2.Qty - solinhkiencandung;
        //                    item2.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
        //                    item2.CreatedBy = Program.UserId;
        //                    if (soconlai>=0)
        //                    {
        //                        item2.Qty=soconlai;                                                             
        //                        SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(item2);

        //                        break;
        //                    }
        //                    else
        //                    {
        //                        solinhkiencandung = soconlai*-1;
        //                        item2.Qty = 0;
        //                        SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(item2);
        //                    }

        //                }
        //            }


        //            if (SMT_OUTSOURCE_OUTPUTDAL.Instance.Add(orderNo))
        //            {                        
        //                MessageBox.Show("Thêm mới thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_OUTPUTDAL.Instance.HienThiDuLieuTheoUserVaNgayThang(Program.UserId));
        //                txtOrderNo.Text = "";
        //                txtOutputQty.Text = "";
        //                chkStatus.Checked = false;
        //                txtRemark.Text = "";
        //                return;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Thêm mới không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //        }
        //        //else
        //        //{
        //        //    orderNo.ID = Id;
        //        //    if (orderNo.ID>0)
        //        //    {
        //        //        orderNo.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
        //        //        if (SMT_OUTSOURCE_OUTPUTDAL.Instance.Update(orderNo))
        //        //        {
        //        //            MessageBox.Show("Update thành công vào csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //            return;
        //        //        }
        //        //        else
        //        //        {
        //        //            MessageBox.Show("Update không thành công vào csdl :D", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //            return;
        //        //        }
        //        //    }
                                    
        //        //}
                
        //        CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_OUTPUTDAL.Instance.HienThiDuLieuTheoUserVaNgayThang(Program.username));
        //        showHideControll(true);
        //        ResetControll();
        //        _enable(false);
        //    }
        //}

        //private void iconbtnCancel_Click(object sender, EventArgs e)
        //{
        //    AddFlag = false;
        //    showHideControll(true);
        //    _enable(false);
        //}

        //private void dgView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (dgView.RowCount > 0)
        //    {
        //        DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
        //        Id = int.Parse(row.Cells["Id"].Value.ToString());
        //        txtOrderNo.Text = row.Cells["OrderNo"].Value.ToString();
        //        txtOutputQty.Text = row.Cells["OuputQty"].Value.ToString();
        //        if (bool.Parse(row.Cells["OrderStatus"].Value.ToString()))
        //        {
        //            chkStatus.Checked = true;
        //        }
        //        else
        //        {
        //            chkStatus.Checked = false;
        //        }                
        //        txtRemark.Text = row.Cells["Remark"].Value.ToString();                
        //    }
        //}
        private void SearchData()
        {
            CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_OUTPUTDAL.Instance.TimKiemDuLieu(txtSearch.Text.Trim()));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchData();
            }
            
        }

        private void icobtnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void txtOutputQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
        }

        //private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode==Keys.Enter)
        //    {
        //        bool checkExistOrder = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.KiemtraOrderDaTonTaiChua(txtOrderNo.Text.Trim());
        //        if (!checkExistOrder)
        //        {
        //            MessageBox.Show("Order này không tồn tại, ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        else
        //        {
        //            txtOutputQty.Focus();
        //        }
        //    }
        //}

        //private void txtOutputQty_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode==Keys.Enter)
        //    {
        //        var output = new SMT_OUTSOURCE_OUTPUT();
        //        var input = new SMT_OUTSOURCE_ORDER_IMPORT();
        //        output = SMT_OUTSOURCE_OUTPUTDAL.Instance.LaydulieutheoOrder(txtOrderNo.Text.Trim());
        //        input = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.LayQtyTheoOrderNo(txtOrderNo.Text.Trim());
        //        if (output!=null && input!=null)
        //        {
        //            if (output.OuputQty>input.Qty)
        //            {
        //                MessageBox.Show("Hãy nhập output nhỏ hơn Input", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                txtOutputQty.Focus();
        //                txtOutputQty.SelectAll();
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Dữ liệu nhập vào không đúng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
        //            return ;
        //        }
        //    }
        //}
        private string pathFile = "";
        private void iconbtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Please Select Excel File to Import |*.xlsx;*.xls";
            op.Title = "Select Excel";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = op.FileName;
                pathFile = System.IO.Path.GetDirectoryName(op.FileName);
            }
        }

        private void iconbtnUpload_Click(object sender, EventArgs e)
        {           
            if (!txtFile.Text.Trim().Equals(""))
            {
                string fileError = "Import_Error_" + CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
                string fileFullPath = pathFile + "\\" + fileError;
                progressBar.Visible = true;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                int j = 0;
                int rCnt = 0;
                int cCnt = 0;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(txtFile.Text.Trim(), 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;
                progressBar.Minimum = 0;
                progressBar.Maximum = range.Rows.Count;
                string keyImport = "Import_Data_" + CommonDAL.Instance.getSqlServerDatetime().ToString("yyyy-MM-dd-H-mm-ss");
              
                var outputOrderList = new List<SMT_OUTSOURCE_OUTPUT>();
                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    var outputOrder = new SMT_OUTSOURCE_OUTPUT();
                    string[] str = new string[8];
                    for (cCnt = 1; cCnt <= 8; cCnt++)
                    {
                        if (!string.IsNullOrEmpty((range.Cells[rCnt, cCnt] as Excel.Range).Text) || (range.Cells[rCnt, cCnt] as Excel.Range).Text == "")
                        {
                            str[j] = (range.Cells[rCnt, cCnt] as Excel.Range).Text;
                            j = j + 1;
                        }
                        else
                        {
                            str[j] = "";
                            j = j + 1;
                        }
                    }
                    System.DateTime date = new System.DateTime();
                    date= CommonDAL.Instance.getSqlServerDatetime();
                    if (checkOKData(str) == true)
                    {
                        outputOrder.OrderNo = str[0];
                        outputOrder.OuputQty = int.Parse(str[1]);
                        outputOrder.WorkOrder = str[2];
                        outputOrder.PoNo = str[3];
                        outputOrder.MaterialCode = str[4];
                        outputOrder.PcbType = str[5];
                        outputOrder.DeliveryDate = System.DateTime.Parse( str[6]);
                        outputOrder.Remark = str[7];
                        outputOrder.OrderStatus = false;
                        outputOrder.CreatedBy = Program.UserId;
                        outputOrder.CreatedDate = date;
                        outputOrder.UpdatedDate = date;
                        outputOrderList.Add(outputOrder);
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã có lỗi, hãy kiểm tra dữ liệu dòng:  " + rCnt + " trong file excel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    progressBar.Value = rCnt;
                    j = 0;
                }
                // Kiểm tra output vs lotsize

               // bool check = false;
                progressBar.Visible= false;
                progressBar.Visible = true;
                int processBar=0;
                progressBar.Minimum = 0;
                progressBar.Maximum = outputOrderList.Count;
                foreach (var item in outputOrderList)
                {
                    long TotalOutputQty = 0;
                    var sumOutputQty = new SumOutPut();
                    // Lấy tổng số lượng đã output trước đó
                    sumOutputQty = SMT_OUTSOURCE_OUTPUTDAL.Instance.QtyOutputTheoOrderNo(item.OrderNo);
                    var getLotSize = new SMT_OUTSOURCE_ORDER_IMPORT();
                    // Lấy lotzie theo order
                    getLotSize = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.LayLotsizeTheoOrderNo(item.OrderNo);
                    if (sumOutputQty==null)
                    {
                        TotalOutputQty= item.OuputQty;
                    }
                    else
                    {
                        TotalOutputQty = sumOutputQty.OutQty + item.OuputQty;
                    }
                    if (getLotSize==null)
                    {
                        string message = "Số order này không có trong danh sách order của khách hàng: " + "\n\n"
                       + "Số order: " + item.OrderNo + "\n"
                       + "LotSize: zero" +  "\n"                      
                       + "OutPut: " + item.OuputQty;
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    // Kiểm tra tổng số lần xuất hàng của 1 order + lần xuất hàng hiện tại có nhỏ hơn lotsize của order không

                    if (TotalOutputQty<=getLotSize.LotSize)
                    {
                        // Kiểm tra xem tồn kho có đủ các mã linh kiện so với Order xuất hàng không?
                        var checkMaterial = new List<PartsList>();
                        // Lấy toàn bộ linh kiện dùng cho order đem kiểm tra với tồn kho
                        // Nếu có đủ part thì thực hiện kiểm tra xem số lượng có đủ không?
                        checkMaterial= SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.KiemTraLinhKienTheoOrder(item.OrderNo);
                        if (checkMaterial.Count>0)
                        {
                            string message = "Những parts sau không có trong kho: "+"\n\n"
                                            + "Số order: " + item.OrderNo + "\n";
                            foreach (var m in checkMaterial)
                            {
                                message = message + m.Partcode + "\n";
                            }
                            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            message = null;
                            break;
                        }
                        else
                        {
                            // Kiểm tra xem có đủ linh kiện để trừ không?
                            Runagain:
                            var dt = new System.Data.DataTable();
                            // Kiểm tra xem có đủ số lượng để trừ không?
                            // Nếu đủ nghĩa là dt =0 
                            dt = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.CheckMatrialByOrderVsOutputQty(item.OrderNo, item.OuputQty);
                            if (dt.Rows.Count>0)
                            {
                                string misPart = "";
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    misPart=misPart + dt.Rows[i]["Partcode"].ToString() +" ---> "+ dt.Rows[i]["Stock"].ToString()+"\n";
                                }
                                int qty = 0;
                                if (sumOutputQty == null)
                                {
                                     qty = 0;
                                }
                                else
                                {
                                     qty = (int)sumOutputQty.OutQty;
                                }    
                                string message = " Tồn kho không đủ để thực hiện xuất hàng: " + "\n\n"
                                                  + "Số order: " + item.OrderNo + "\n"
                                                  + "LotSize: " + getLotSize.LotSize + "\n"
                                                  + "Output trước đó: " + qty + "\n"
                                                  + "OutPut: " + item.OuputQty + "\n"
                                                  + "Danh sách part thiếu:"+"\n"+  misPart + "\n"
                                                  + "Bạn có muốn tiếp tục xử lý tạm ứng part này không???";


                                DialogResult dialogResult = MessageBox.Show(message, "Thông báo", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    // thêm dữ liệu vào Kho 
                                    // Lưu dữ liệu này sang bảng khác

                                    var datetime = new System.DateTime();
                                    datetime = CommonDAL.Instance.getSqlServerDatetime();
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        var misParts = new SMT_OUTPUT_MIS_MATERIAL();
                                        var stockPart = new SMT_OUTSOURCE_IN_QTY();

                                        misParts.OrderNo= dt.Rows[i]["OrderNo"].ToString();
                                        misParts.Partcode= dt.Rows[i]["Partcode"].ToString();
                                        misParts.OrderQty=float.Parse(dt.Rows[i]["OrderQty"].ToString());
                                        misParts.LotSize= int.Parse(dt.Rows[i]["Lotsize"].ToString());
                                        misParts.MaterialPerPcb=float.Parse( dt.Rows[i]["MaterialPerPcb"].ToString());
                                        misParts.NeedQty= float.Parse(dt.Rows[i]["NeedQty"].ToString());
                                        misParts.Stock=float.Parse(dt.Rows[i]["Stock"].ToString());
                                        misParts.CreatedBy = Program.UserId;
                                        misParts.CreatedDate = datetime;

                                        stockPart.PartCode= dt.Rows[i]["Partcode"].ToString();
                                        stockPart.DateCode = CommonDAL.Instance.getSqlServerDatetime();
                                        stockPart.Qty= float.Parse(dt.Rows[i]["Stock"].ToString())*-1;
                                        stockPart.Remark1 = dt.Rows[i]["OrderNo"].ToString() + " Vật tư tạm ứng khi kho hết hàng";
                                        stockPart.Remark1 = dt.Rows[i]["OrderNo"].ToString() + " Vật tư tạm ứng khi kho hết hàng";
                                        stockPart.CreatedBy = Program.UserId;
                                        stockPart.CreatedDate = datetime;
                                        stockPart.UpdatedDate = datetime;

                                        SMT_OUTPUT_MIS_MATERIALDAL.Instance.Add(misParts);
                                        SMT_OUTSOURCE_IN_QTYDAL.Instance.Add(stockPart);
                                    }

                                    goto Runagain;
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    break;
                                }
                                //MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //break;
                            }
                            else
                            {
                                CommonDAL.Instance.BeginTransaction();
                                try
                                {
                                    // Nếu đã đủ linh kiện và số lượng tồn kho rồi thì tiến hành trừ và ghi lại vào csdl
                                    var partsLists = new List<PartsList>();
                                   // var outPartList= new List<OutPartsList>();
                                    partsLists = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrderNew(item.OrderNo);
                                    //outPartList = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrderAndOutput(item.OrderNo,item.OuputQty);
                                    var dateTime = new System.DateTime();
                                    dateTime = CommonDAL.Instance.getSqlServerDatetime();
                                    foreach (var part in partsLists)
                                    {
                                        var TonkhoParts = SMT_OUTSOURCE_IN_QTYDAL.Instance.danhsachMacoQty(part.Partcode);
                                        double  solinhkiencandung = 0;
                                        solinhkiencandung= part.MaterialPerPcb * item.OuputQty;

                                        //=====================                                       
                                        var orderHistory = new SMT_OUTSOURCE_OUTHISTORY();
                                        orderHistory.Partcode = part.Partcode;
                                        orderHistory.OuputQty = item.OuputQty;
                                        orderHistory.CreatedBy = Program.UserId;
                                        orderHistory.CreatedDate = dateTime;
                                        orderHistory.OrderNo = item.OrderNo;
                                        foreach (var tonKho in TonkhoParts)
                                        {
                                            double soconlai = tonKho.Qty - solinhkiencandung;
                                            tonKho.UpdatedDate = dateTime;
                                            tonKho.CreatedBy = Program.UserId;                                           
                                            if (soconlai >= 0)
                                            {
                                                tonKho.Qty = soconlai;
                                                orderHistory.QtyOfPartcode = solinhkiencandung;
                                                tonKho.Remark1 = tonKho.Remark1 + " Output for order: " + item.OrderNo + " Qty: " + solinhkiencandung;
                                                SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(tonKho);
                                                SMT_OUTSOURCE_OUTHISTORYDAL.Instance.Add(orderHistory);
                                                break;
                                            }
                                            else
                                            {
                                                solinhkiencandung = soconlai * -1;
                                                orderHistory.QtyOfPartcode = tonKho.Qty;
                                                tonKho.Qty = 0; // là vì nó trừ đi số lượng còn lại
                                                tonKho.Remark1 = tonKho.Remark1 + " Output for order: " + item.OrderNo + " Qty: " + tonKho.Qty;
                                                SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(tonKho);
                                                SMT_OUTSOURCE_OUTHISTORYDAL.Instance.Add(orderHistory);
                                            }
                                        }
                                    }
                                    var smtOuput = new SMT_OUTSOURCE_OUTPUT();
                                    smtOuput.OrderNo = item.OrderNo;
                                    smtOuput.OuputQty = item.OuputQty;
                                    smtOuput.WorkOrder = item.WorkOrder;
                                    smtOuput.PoNo = item.PoNo;
                                    smtOuput.MaterialCode = item.MaterialCode;
                                    smtOuput.PcbType = item.PcbType;
                                    smtOuput.DeliveryDate = item.DeliveryDate;
                                    smtOuput.Remark = item.Remark;
                                    smtOuput.OrderStatus = false;
                                    smtOuput.CreatedBy = Program.UserId;
                                    smtOuput.CreatedDate = dateTime;
                                    smtOuput.UpdatedDate = dateTime; 
                                    SMT_OUTSOURCE_OUTPUTDAL.Instance.Add(smtOuput);
                                    CommonDAL.Instance.CommitTransaction();
                                }
                                catch (Exception ex)
                                {
                                    CommonDAL.Instance.RollbackTransaction();
                                    MessageBox.Show("Đã có lỗi xảy ra: "+ ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                    break;
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        string message = "Số lượng nhập vào đã vượt quá Lotsize: " + "\n\n"
                        + "Số order: " + item.OrderNo + "\n"
                        + "LotSize: " + getLotSize.LotSize + "\n"
                        + "Output trước đó: " + (sumOutputQty.OutQty) + "\n"
                        + "OutPut: " + item.OuputQty;
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                    processBar++;
                    //string message = "";
                    //message = checkOrderQty(item.OrderNo, item.OuputQty);
                    //if (message != "")
                    //{
                    //    //check = false;
                    //    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    //else
                    //{
                    //    processOrderPart(item.OrderNo, item.OuputQty);
                    //    SMT_OUTSOURCE_OUTPUTDAL.Instance.Add(item);
                    //} //check = true;
                    progressBar.Value = processBar ;
                }
                //if (check==true)
                //{
                    
                //}


                MessageBox.Show("Upload dữ liệu kết thúc !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgView.ReadOnly = true;
                CommonDAL.Instance.ShowDataGridView(dgView, SMT_OUTSOURCE_OUTPUTDAL.Instance.lstOutputByUserDate(Program.UserId));
                txtFile.Text = "";
                progressBar.Visible = false;
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                CommonDAL.Instance.releaseObject(xlWorkSheet);
                CommonDAL.Instance.releaseObject(xlWorkBook);
                CommonDAL.Instance.releaseObject(xlApp);

            }
        }
        private void processOrderPart(string OrderNo, long OutputQty)
        {           
                //var linhkientheoOrderList = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrder(OrderNo);
            var linhkientheoOrderList = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrderNew(OrderNo);
            // Nếu đủ linh kiện và số lượng rồi thì tiến hành trừ linh kiện ở kho khi xuất hàng
            foreach (var item2 in linhkientheoOrderList)
            {
                var TonkhoPart = SMT_OUTSOURCE_IN_QTYDAL.Instance.danhsachMacoQty(item2.Partcode);
                var solinhkiencandung = item2.MaterialPerPcb * OutputQty;
                var date = new System.DateTime();
                date= CommonDAL.Instance.getSqlServerDatetime();
                foreach (var item3 in TonkhoPart)
                {
                    var orderHistory = new SMT_OUTSOURCE_OUTHISTORY();
                    orderHistory.Partcode = item3.PartCode;
                    orderHistory.OuputQty = OutputQty;
                    orderHistory.CreatedBy = Program.UserId;
                    orderHistory.CreatedDate = date;
                    orderHistory.OrderNo = OrderNo;
                    double soconlai = item3.Qty - solinhkiencandung;
                    item3.UpdatedDate = date;
                    item3.CreatedBy = Program.UserId;
                    if (soconlai >= 0)
                    {
                        item3.Qty = soconlai;
                        orderHistory.QtyOfPartcode = solinhkiencandung;
                        SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(item3);
                        SMT_OUTSOURCE_OUTHISTORYDAL.Instance.Add(orderHistory);
                        break;
                    }
                    else
                    {
                        solinhkiencandung = soconlai * -1;
                        orderHistory.QtyOfPartcode = item3.Qty;
                        item3.Qty = 0; // là vì nó trừ đi số lượng còn lại
                        SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(item3);
                        SMT_OUTSOURCE_OUTHISTORYDAL.Instance.Add(orderHistory);
                    }
                }
            }
        }
        private void processPart( List<SMT_OUTSOURCE_OUTPUT> outputOrderList)
        {
            foreach (var item in outputOrderList)
            {
                var linhkientheoOrderList = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrder(item.OrderNo);
                // Nếu đủ linh kiện và số lượng rồi thì tiến hành trừ linh kiện ở kho khi xuất hàng
                foreach (var item2 in linhkientheoOrderList)
                {
                    var TonkhoPart = SMT_OUTSOURCE_IN_QTYDAL.Instance.danhsachMacoQty(item2.Partcode);
                    var solinhkiencandung = item2.MaterialPerPcb * item.OuputQty;
                    
                    foreach (var item3 in TonkhoPart)
                    {
                        var orderHistory = new SMT_OUTSOURCE_OUTHISTORY();
                        orderHistory.Partcode = item3.PartCode;
                        orderHistory.OuputQty = item.OuputQty;
                        orderHistory.CreatedBy = Program.UserId;
                        orderHistory.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        orderHistory.OrderNo = item.OrderNo;
                        
                        double soconlai = item3.Qty - solinhkiencandung;
                        item3.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        item3.CreatedBy = Program.UserId;
                        if (soconlai >= 0)
                        {
                            item3.Qty = soconlai;
                            orderHistory.QtyOfPartcode= solinhkiencandung;
                            SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(item3);
                            SMT_OUTSOURCE_OUTHISTORYDAL.Instance.Add(orderHistory);
                            break;
                        }
                        else
                        {
                            solinhkiencandung = soconlai * -1;
                            orderHistory.QtyOfPartcode = item3.Qty;
                            item3.Qty = 0; // là vì nó trừ đi số lượng còn lại                            
                            SMT_OUTSOURCE_IN_QTYDAL.Instance.UpdateQty(item3);
                            SMT_OUTSOURCE_OUTHISTORYDAL.Instance.Add(orderHistory);
                        }                        
                    }
                }
                SMT_OUTSOURCE_OUTPUTDAL.Instance.Add(item);
            }
        }
        

        //private string checkOrderQty(string order, long outputQty)
        //{
        //    var sumQtyOutput = new List<SumOutPut>();
        //    var inputQty = new SMT_OUTSOURCE_ORDER_IMPORT();
        //    inputQty = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.LayQtyTheoOrderNo(order);
        //    sumQtyOutput = SMT_OUTSOURCE_OUTPUTDAL.Instance.TinhQtyOutputTheoOrderNo(order);
        //    string message = "";
        //    if (sumQtyOutput.Count > 0) // Kiểm tra xem đã output chưa? Nếu output rồi thì xem số lượng có vượt quá lotsize không?
        //    {
        //        long totalOutput = 0;
        //        foreach (var item in sumQtyOutput)
        //        {
        //            totalOutput = totalOutput + item.OutQty;
        //        }
        //        totalOutput = totalOutput + outputQty;
        //        if (totalOutput > inputQty.LotSize)
        //        {
        //            //MessageBox.Show("Số lượng nhập vào đã vượt quá Lotsize", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //           return message = message = "Số lượng nhập vào đã vượt quá Lotsize: " + "\n\n"
        //                + "Số order: " + order + "\n"
        //                + "LotSize: " + inputQty.LotSize + "\n"
        //                + "Output trước đó: " + (totalOutput - outputQty)+"\n"
        //                + "OutPut: " + outputQty;
        //        }
        //        else
        //        {
        //            message = checkMaterial(order, outputQty);
        //            if (message!="")
        //            {                        
        //                return message;
        //            }    
        //        }
        //    }
        //    else
        //    {
        //        // Nếu là xuất hàng lần đầu thì cũng kiểm tra số lượng xuất với lotsize
        //        if (outputQty>inputQty.LotSize)
        //        {
        //            return message = "Số lượng nhập vào đã vượt quá Lotsize: " +"\n\n"
        //                + "Số order: " + order +"\n"
        //                + "LotSize: " + inputQty.LotSize  + "\n"
        //                + "OutPut: "+ outputQty;
        //        }
        //        else
        //        {
        //            message = checkMaterial(order, outputQty);
        //            if (message != "")
        //            {
        //                return message;
        //            }
        //        }
               
        //    }
        //    return message;
        //}
        //private string checkMaterial(string order, long outputQty)
        //{
        //    var linhkientonkhoList = SMT_OUTSOURCE_IN_QTYDAL.Instance.getTonKhoList();
        //    //var linhkientheoOrderList = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrder(order);
        //    var linhkientheoOrderList = SMT_OUTSOURCE_ORDER_IMPORTDAL.Instance.getListLinhKienTheoOrderNew(order);
        //    string message = "";
        //    // Kiểm tra xem có đủ linh kiện không
        //    var NotInRecord = linhkientheoOrderList.Where(p => !linhkientonkhoList.Any(p2 => p2.Partcode == p.Partcode)).ToList();
        //    bool check = false;
        //    if (NotInRecord.Count > 0)
        //    {
        //        string listpart = "";
        //        foreach (var part in NotInRecord)
        //        {
        //          listpart=listpart+  part.Partcode + "\n";
        //        }
        //        return message = "Những Partcode dưới đây không có trong tồn kho của Order: "+ order + "\n\n" + listpart;
        //    }
        //    else
        //    {
        //        // Nếu đủ linh kiện thì kiểm tra xem có đủ số lượng không?   
        //        foreach (var item1 in linhkientheoOrderList)
        //        {
        //            var result = linhkientonkhoList.Where(p => p.Partcode == item1.Partcode).FirstOrDefault();
        //            if (result.Qty < item1.MaterialPerPcb * outputQty)
        //            {
        //                message = "Tồn kho không đủ để xuất hàng: "+"\n\n"
        //                    +"Số order: " + order + "\n"
        //                    +"Partcode: " + item1.Partcode + "\n"
        //                    +"Số lượng tồn kho: " + result.Qty+ "\n"
        //                    +"Số lượng cần: "+ item1.MaterialPerPcb * outputQty;

        //                break;
        //            }
        //            else
        //            {
        //                message = "";
        //            }
        //        }
        //    }
        //    return message;
        //}
        private bool checkOKData(string[]checkdata)
        {
            if (checkdata[0].Equals("") ||checkdata[0].Length != 10  )
            {
                return false;
            }
            if (checkdata[1].Equals("")|| int.Parse(checkdata[1])<=0)
            {
                return false;
            }
            if (checkdata[2].Equals(""))
            {
                return false;
            }
            if (checkdata[3].Equals(""))
            {
                return false;
            }
            if (checkdata[4].Equals(""))
            {
                return false;
            }
            if (checkdata[5].Equals("") )
            {
                return false;
            }
            if (System.DateTime.TryParse(checkdata[6], out System.DateTime Temp) == false)
            {
                return false;
            }
            return true;
        }

        private void iconbtnTimKiem_Click(object sender, EventArgs e)
        {
            System.DateTime start = dateTimePicker1.Value;
            System.DateTime endd = dateTimePicker2.Value;
            TimeSpan diff = endd.Subtract(start);
            if (diff.TotalDays< 0)
            {
                MessageBox.Show("Nhập ngày tháng tìm kiếm không chính sác !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {                
                dgView.DataSource= SMT_OUTSOURCE_OUTPUTDAL.Instance.getSearchData(start, endd);
                dgView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void iconbtnDownload_Click(object sender, EventArgs e)
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
                    CommonDAL.Instance.writeCSV(dgView, filename);
                    MessageBox.Show("Đã Export Thành Công !!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
                throw;
            }
        }
    }
}
