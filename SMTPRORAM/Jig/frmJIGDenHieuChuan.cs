using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDAL.Jig;
using UnidenDAL;
using UnidenDTO;

namespace SMTPRORAM.Jig
{
    public partial class frmJIGDenHieuChuan : Form
    {
        public frmJIGDenHieuChuan()
        {
            InitializeComponent();
        }        
        private string[] type = new string[5] { "HIEU CHUAN", "BAO DUONG", "HIEU CHUAN NGOAI", "KHONG HIEU CHUAN", "KHONG HC & BD" };
        private void Hienthithietbicanhieuchuan(string calType, DateTime start, DateTime end)
        {
            start = dateTimePickerFrom.Value.Date;
            end = dateTimePickerTo.Value.Date;
            TimeSpan diff = end.Subtract(start);
            if (diff.TotalDays >= 0)
            {
                var dt = new DataTable();
                dt=JIGCALDEVICES_DAL.Instance.ThietBiCanHieuChinhTheoNgayThang(calType,start,end);
                dgView.DataSource = null;
                dgView.Update();
                if (dt.Rows.Count>0)
                {
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
                }
            }
        }
        private void iconbtnLoad_Click(object sender, EventArgs e)
        {
            
            Hienthithietbicanhieuchuan(type[0],dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date);
            //DateTime date = dateTimePickerFrom.Value.Date;
            //var showCalDevices = new ShowCalDevices();
            //var lstShow= new List<ShowCalDevices>();

            //var lstCalDevices = JIGCALDEVICES_DAL.Instance.getListCalDevices();
           
            //foreach (var item in lstCalDevices)
            //{
            //    // row = dgView.Rows[e.RowIndex];
            //    var calDevices = new JIG_CALDEVICES();
            //    calDevices = JIGCALDEVICES_DAL.Instance.checkCalDevicesExist(item.ControlNo);
            //    if (calDevices != null)
            //    {
            //        DateTime calDate = calDevices.CalDate;    
            //        var calType = new JIG_CALTYPE();
            //        calType = JIGCALTYPE_DAL.Instance.checkCalTypeExist(calDevices.CalType);
            //        int cycle = calType.Cycle;
            //        if (calDate.AddMonths(cycle) <= date.AddMonths(1))
            //        {
            //            lstShow.Add(item);
            //        }
            //    }
            //}
            //dgView.DataSource = lstShow.ToList();
        }

        private void iconbtnList_Click(object sender, EventArgs e)
        {
            //dgView.DataSource = JIGINOUT_DAL.Instance.getListJigOnline();
            Hienthithietbicanhieuchuan(type[1], dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date);

        }

       
        private void iconbtnHieuChuanNgoai_Click(object sender, EventArgs e)
        {
            Hienthithietbicanhieuchuan(type[2], dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date);
        }

        private void iconbtnKhongHieuChuan_Click(object sender, EventArgs e)
        {
            Hienthithietbicanhieuchuan(type[3], dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date);
        }

        private void iconbtnKhonghieuchuanVabaoduong_Click(object sender, EventArgs e)
        {
            Hienthithietbicanhieuchuan(type[4], dateTimePickerFrom.Value.Date, dateTimePickerTo.Value.Date);
        }

		private void iconbtnExport_Click(object sender, EventArgs e)
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
