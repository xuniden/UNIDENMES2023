using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMTPROGRAM_Da.BoxET;
using SMTPROGRAM_Bu.BoxET;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using Microsoft.Reporting.WinForms;
using SMTPRORAM.Whs;
using UnidenDTO;
using UnidenDAL;

namespace SMTPRORAM.BoxET
{
    public partial class FBoxETManage : Form
    {
        public FBoxETManage()
        {
            InitializeComponent();
        }
        private string checkBoxValue = "";
        private void getDatabaseLabelInfo(string boxType)
        {
            if (boxETManage_Service.boxETManage_getNumberOfSerial(boxType).Rows.Count > 0)
            {
                lbltongsotem.Text = boxETManage_Service.boxETManage_getNumberOfSerial(boxType).Rows.Count.ToString();
            }
            else
            {
                lbltongsotem.Text = "";
            }
            if (boxETManage_Service.boxETManage_getLastOfSerial(boxType).Rows.Count > 0)
            {
                lbltemdatao.Text = boxETManage_Service.boxETManage_getLastOfSerial(boxType).Rows[0]["Serial"].ToString();
            }
            else
            {
                lbltemdatao.Text = "";
            }
        }
        private void FBoxETManage_Load(object sender, EventArgs e)
        {           
           
            this.reportViewerBoxET.RefreshReport();
        }

        private void LoadData(string fromSerial, string toSerial)
        {
            var dt = boxETManage_Service.boxETManage_PrintBarcode(fromSerial, toSerial);
            if (dt.Rows.Count>0)
            {
                dataGridView.DataSource = dt;
                dataGridView.AutoResizeColumns();
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {

            }
        }
        public static void ApplyFontAllText(ReportDocument rapport, Font style)
        {

            foreach (ReportObject obj in rapport.ReportDefinition.ReportObjects)
            {
                if (obj.GetType().Name.Equals("FieldObject"))
                {

                    ((FieldObject)obj).ApplyFont(style);

                }
                //else if (obj.GetType().Name.Equals("FieldObject"))
                //{
                //    ((FieldObject)obj).ApplyFont(style);
                //}
            }
        }
        //public void ExtractResource(this Assembly assembly, string filename, string path = null)
        //{
        //    //Construct the full path name for the output file
        //    var outputFile = path ?? $@"{Directory.GetCurrentDirectory()}\{filename}";

        //    // If the project name contains dashes replace with underscores since 
        //    // namespaces do not permit dashes (underscores will be default to).
        //    var resourceName = $"{assembly.GetName().Name.Replace("-", "_")}.{filename}";

        //    // Pull the fully qualified resource name from the provided assembly
        //    using (var resource = assembly.GetManifestResourceStream(resourceName))
        //    {
        //        if (resource == null)
        //            throw new FileNotFoundException($"Could not find [{resourceName}] in {assembly.FullName}!");

        //        using (var file = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
        //        {
        //            resource.CopyTo(file);
        //        }
        //    }
        //}

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            if (checkRadio()==false)
            {
                MessageBox.Show("Phải chọn một trong các lựa chọn trước khi in tem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadData(checkBoxValue + numericUpDown1.Value.ToString("0000000000"), checkBoxValue + numericUpDown2.Value.ToString("0000000000"));
            DataTable ds = new DataTable();
            ds = boxETManage_Service.boxETManage_PrintBarcode(checkBoxValue+ numericUpDown1.Value.ToString("0000000000"), checkBoxValue + numericUpDown2.Value.ToString("0000000000"));
            PrintReport cp = new PrintReport();

            //Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SMTPRORAM.IDAUTOMATIONHC39M.OTF");
            //FileStream fileStream = new FileStream("IDAUTOMATIONHC39M.OTF", FileMode.CreateNew);
            //for (int i = 0; i < stream.Length; i++)
            //    fileStream.WriteByte((byte)stream.ReadByte());
            //fileStream.Close();

            ResourceManager.GetResourceInfo("IDAUTOMATIONHC39M.OTF", "SMTPRORAM.Resources");
            if (ResourceManager.resourceExists == false)
                return;

            //Loads packages.config in Bin/Debug
            ResourceManager.LoadResource("IDAUTOMATIONHC39M.OTF");



            var filePath = AppDomain.CurrentDomain.BaseDirectory+ "IDAUTOMATIONHC39M.OTF";
            //MessageBox.Show(filePath+ "IDAUTOMATIONHC39M.OTF");
            //Assembly assembly = Assembly.GetCallingAssembly();

            //ExtractResource(assembly, "IDAUTOMATIONHC39M", filePath);
            //var filePath = AppDomain.CurrentDomain.BaseDirectory;
            //Font fontFamily = new SMTPRORAM.Properties.Resources.IDAUTOMATIONHC39M
            PrintBarcode();
			#region Không in bằng crystalReport
			/*
            try
            {
                //var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                //string filePath = Path.Combine(projectPath, "Resources\\IDAUTOMATIONHC39M.OTF");              

                //string filePath1 = Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), "Resources");
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(filePath);
                int i = ds.Rows.Count;
                cp.SetDataSource(ds);
                ApplyFontAllText(cp, new Font(pfc.Families[0].Name, 9, FontStyle.Regular, GraphicsUnit.Point));
                crystalReportViewer.ReportSource = cp;
                crystalReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                throw;
            }
           */
			#endregion
		}

		private bool checkRadio()
        {
            bool check = false;
            if (radioBtnBox.Checked==false && radioBtnPalletShipment.Checked==false&&radioBtnPalletKeep.Checked==true)
            {
               check=true;
            }
            if (radioBtnBox.Checked == true && radioBtnPalletShipment.Checked == false && radioBtnPalletKeep.Checked == false)
            {
                check = true;
            }
            if (radioBtnBox.Checked == false && radioBtnPalletShipment.Checked == true && radioBtnPalletKeep.Checked == false)
            {
                check = true;
            }
            return check;
        }
        private void btnCreate_Click_1(object sender, EventArgs e)
        {            
            if (checkRadio()==false)
            {
                MessageBox.Show("Phải chọn một trong các lựa chọn trước khi tạo tem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (numericUpDown1.Value >= numericUpDown2.Value)
            {
                MessageBox.Show("Không tạo được số tem, nhập sai dữ liệu");
                numericUpDown1.Focus();
                return;
            }
            else
            {
                CreateBarcodeLabel(checkBoxValue, (int)numericUpDown1.Value, (int)numericUpDown2.Value);

                //// Kiểm tra xem số tem đã tạo có trong csdl chưa? Nếu chưa có thì tạo mới. Nếu có rồi thì không tạo báo lỗi
                //for (int i = (int)numericUpDown1.Value; i < (int)numericUpDown2.Value; i++)
                //{

                //    string Serial = "UV" + i.ToString("000000000000");
                //    if (boxETManage_Service.boxETManage_CheckExists(Serial).Rows.Count > 0)
                //    {
                //        MessageBox.Show("Số tem này đã có trong csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        checkFlag = true;
                //        break;
                //    }
                //}
                //// Khi đã kiểm tra xong số tem này không có trong csdl thì lưu vào csdl

                //if (checkFlag == false)
                //{
                //    try
                //    {
                //        for (int i = (int)numericUpDown1.Value; i <= (int)numericUpDown2.Value; i++)
                //        {
                //            var boxManage = new boxETManage();
                //            string Serial = "UV" + i.ToString("000000000000");
                //            string BarCode = "*" + Serial + "*";
                //            boxManage.Serial = Serial;
                //            boxManage.CreatedBy =  Program.username;
                //            boxManage.Status = false;
                //            boxManage.BarCode = BarCode;
                //            boxETManage_Service.boxETManage_Insert(boxManage);
                //        }
                //        MessageBox.Show("Đã tạo xong tem cần in, Bạn có thể in tem theo số vừa tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        LoadData("UV" + numericUpDown1.Value.ToString("000000000000"), "UV" + numericUpDown2.Value.ToString("000000000000"));
                //        return;
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //        throw;
                //    }
                //}
            }
        }

        private void CreateBarcodeLabel(string barcodeType,int fromNum, int toNum)
        {
            bool checkFlag = false;
            // Kiểm tra xem số tem đã tạo có trong csdl chưa? Nếu chưa có thì tạo mới. Nếu có rồi thì không tạo báo lỗi
            for (int i = fromNum; i <= toNum; i++)
            {
                string Serial = barcodeType + i.ToString("0000000000");
                if (boxETManage_Service.boxETManage_CheckExists(Serial).Rows.Count > 0)
                {
                    MessageBox.Show("Số tem này đã có trong csdl !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkFlag = true;
                    break;
                }
            }
            // Khi đã kiểm tra xong số tem này không có trong csdl thì lưu vào csdl

            if (checkFlag == false)
            {
                try
                {
                    for (int i =fromNum; i <= toNum; i++)
                    {
                        var boxManage = new boxETManage();
                        string Serial = barcodeType + i.ToString("0000000000");
                        string BarCode = "*" + Serial + "*";
                        boxManage.Serial = Serial;
                        boxManage.CreatedBy = Program.username;
                        boxManage.Status = false;
                        boxManage.BarCode = BarCode;
                        boxETManage_Service.boxETManage_Insert(boxManage);
                    }
                    MessageBox.Show("Đã tạo xong tem cần in, Bạn có thể in tem theo số vừa tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(barcodeType +fromNum.ToString("0000000000"), barcodeType+toNum.ToString("0000000000"));
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw;
                }
            }
        }
        private void btnBaocao_Click(object sender, EventArgs e)
        {
            var fm = new SMTPRORAM.BoxET.FBoxReport();
            fm.Show();
        }

        private void PrintBarcode()
        {
            this.reportViewerBoxET.RefreshReport();

            // reportViewer1.LocalReport.ReportEmbeddedResource= filePath;

            ResourceManager.GetResourceInfo("BoxET.rdlc", "SMTPRORAM.Resources");
            if (ResourceManager.resourceExists == false)
                return;

            //Loads packages.config in Bin/Debug
            ResourceManager.LoadResource("BoxET.rdlc");
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "BoxET.rdlc";
            reportViewerBoxET.LocalReport.ReportEmbeddedResource = filePath;

            //LoadData("UV" + numericUpDown1.Value.ToString("000000000000"), "UV" + numericUpDown2.Value.ToString("000000000000"));
            DataTable dt = new DataTable();
            dt = boxETManage_Service.boxETManage_PrintBarcode(checkBoxValue + numericUpDown1.Value.ToString("0000000000"), checkBoxValue + numericUpDown2.Value.ToString("0000000000"));
            var lst = new List<Box_ETManager>();
            
            DataTable redt = new DataTable();
            int k = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var etbox = new Box_ETManager();
                etbox.Id = long.Parse(dt.Rows[i]["Id"].ToString());
                etbox.Serial = dt.Rows[i]["Serial"].ToString();
                etbox.BarCode = dt.Rows[i]["BarCode"].ToString();
                etbox.CreatedDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());
                etbox.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                etbox.Status = bool.Parse(dt.Rows[i]["Status"].ToString());
                lst.Add(etbox);
                i = i + 2;
            }
            //List<Student> studentDetails = new List<Student>();
            //studentDetails = ConvertDataTable<Student>(dt); 

           // List<Box_ETManager> lst = new List<Box_ETManager>();
           // lst=CommonDAL.Instance.ConvertDataTable<Box_ETManager>(dt);           
            this.reportViewerBoxET.LocalReport.ReportPath = filePath;

            ReportDataSource reportDataSource = new ReportDataSource("BoxET", lst);

            reportViewerBoxET.LocalReport.DataSources.Clear();
            reportViewerBoxET.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewerBoxET.RefreshReport();
        }

        private void radioBtnBox_CheckedChanged(object sender, EventArgs e)
        {
            //string result1 = null;
            //foreach (Control control in this.groupBox1.Controls)
            //{
            //    if (control is RadioButton)
            //    {
            //        RadioButton radio = control as RadioButton;
            //        if (radio.Checked)
            //        {
            //            result1 = radio.Text;
            //            checkBoxValue = radio.Tag.ToString();
            //            getDatabaseLabelInfo(checkBoxValue);
            //        }
            //        //else
            //        //{
            //        //    MessageBox.Show("Chưa chon");
            //        //}
            //    }
            //}
            if (radioBtnBox.Checked)
            {

                radioBtnPalletShipment.Checked = false;
                radioBtnPalletKeep.Checked = false;
                checkBoxValue = radioBtnBox.Tag.ToString();
                getDatabaseLabelInfo(checkBoxValue);
            }
            else
            {
                radioBtnPalletShipment.Checked = false;
                radioBtnPalletKeep.Checked = false;
            }
        }
  
        private void radioBtnPalletShipment_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnPalletShipment.Checked)
            {
                radioBtnPalletKeep.Checked = false;
                radioBtnBox.Checked = false;
                checkBoxValue = radioBtnPalletShipment.Tag.ToString();
                getDatabaseLabelInfo(checkBoxValue);
            }    
            else
            {
				radioBtnPalletKeep.Checked = false;
				radioBtnBox.Checked = false;
			}        

        }

        private void radioBtnPalletKeep_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnPalletKeep.Checked)
            {
                radioBtnBox.Checked = false;
                radioBtnPalletShipment.Checked = false;
                checkBoxValue = radioBtnPalletKeep.Tag.ToString();
                getDatabaseLabelInfo(checkBoxValue);
            }   
            else
            {
				radioBtnBox.Checked = false;
				radioBtnPalletShipment.Checked = false;
			}
        }
    }
}
