using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using Microsoft.ReportingServices.Diagnostics.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UnidenDAL;
using UnidenDAL.Assy;

namespace SMTPRORAM.Assy.Report
{
	public partial class frmDownloadDDR : Form
	{
		public frmDownloadDDR()
		{
			InitializeComponent();
		}
		private void CreatePieChart(DataTable datatable,string title,Control controlPie,Control controlDesc, string ChartName,string field1, string field2, string field3)
		{
			// Assuming 'datatable' is your DataTable

			// Create a Chart control
			Chart chart1 = new Chart();
			chart1.Size = new System.Drawing.Size(300, 200);
			chart1.ChartAreas.Add(ChartName);
			chart1.Titles.Add(title);

			// Create a Series for the pie chart
			Series series1 = new Series();
			series1.ChartType = SeriesChartType.Pie;

			// Bind the Series to the DataTable
			series1.Points.DataBind(datatable.DefaultView,field1, field2, "");

			// Add the Series to the Chart
			chart1.Series.Add(series1);

			// Add the Chart to your form
			controlPie.Controls.Add(chart1);
			
			int yPosition = 10;
			int number = 1;
			foreach (DataRow row in datatable.Rows)
			{
				string errorCode = row[field1].ToString();
				string errorDescription= row[field3].ToString();
				int numberOfErrors = Convert.ToInt32(row[field2]);
				
				// Create a label for each error detail
				Label label = new Label();
				label.AutoSize = true;
				label.Text = $"{number++.ToString("00")} --> {errorCode}:  {errorDescription}:     {numberOfErrors}\n";
				label.Location = new Point(10, yPosition); 
				controlDesc.Controls.Add(label);

				yPosition += label.Height + 5; // Adjust spacing between labels
			}

		}

		// Vẽ chart hình trong thể hiện % NG và % OK
		private void CreatePieChart2(string title, Control controlPie, string ChartName, double percentOK, double percentError)
		{
			// Assuming 'datatable' is your DataTable

			// Create a Chart control
			Chart chart1 = new Chart();
			chart1.Size = new System.Drawing.Size(300, 200);
			chart1.ChartAreas.Add(ChartName);
			chart1.Series.Clear();  // Clear any existing series

			
			// Add a new series
			chart1.Series.Add("ErrorStatus");
			chart1.Series["ErrorStatus"].Points.AddXY("OK", percentOK);
			chart1.Series["ErrorStatus"].Points.AddXY("Error", percentError);

			//chart1.Titles.Add("Tỷ lệ OK/NG");
			chart1.Titles.Add(title);
			chart1.Legends.Add("Legend");
			chart1.Legends["Legend"].Docking = Docking.Bottom;
			chart1.Series["ErrorStatus"].IsValueShownAsLabel = true;
			chart1.Series["ErrorStatus"].ChartType = SeriesChartType.Pie;
			controlPie.Controls.Add(chart1);

		}

		private void frmDownloadDDR_Load(object sender, EventArgs e)
		{
			lblError.Text = "";
			lblOutput.Text = "";
			//var dt = new DataTable();
			//dt = LINEERRORRECORD_DAL.Instance.TopErrorForAll();
			//CreatePieChart(dt,"Top 10 Error", panelTopError,panel1, "Chart1", "ErrorCode", "TopError", "ErrorENDescription");


			// Load danh sách lot
			var da = new DataTable();
			da = LINEERRORRECORD_DAL.Instance.LotList();
			cbLot.DataSource = da;
			cbLot.DisplayMember = "Lot";
			cbLot.ValueMember = "Lot";
		}

		private void CreateColumnChart(DataTable dataTable,string title,Control panel, string CauseCode, string TopCauseError, string ErrorENDesc
			, string ErrorPosition,string CauseDept)
		{
			// Create a Chart control
			Chart chart1 = new Chart();
			chart1.Size = new System.Drawing.Size(400, 300);
			chart1.ChartAreas.Add("ChartArea1");
			chart1.BorderlineWidth = 0;
			//chart1.BorderlineColor = System.Drawing.Color.Transparent;


			//chart1.ChartAreas[0].BorderDashStyle = ChartDashStyle.NotSet;
			//chart1.ChartAreas[0].BorderColor = Color.Transparent;
			chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
			chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
			// Create a Series for the column chart
			Series series1 = new Series();
			series1.ChartType = SeriesChartType.Column;

			// Bind the Series to the DataTable
			series1.Points.DataBind(dataTable.DefaultView, CauseCode, TopCauseError, "Label=" + CauseDept );
			
			// Add data labels to the chart
			series1.IsValueShownAsLabel = true;

			chart1.Titles.Add(title);
			// Add the Series to the Chart
			chart1.Series.Add(series1);

			// Set the x-axis label
			
			

			chart1.ChartAreas[0].AxisX.Title = "Error Code";

			// Set the y-axis label
			chart1.ChartAreas[0].AxisY.Title = "Number of Errors";

			// Add the Chart to your form
			panel.Controls.Add(chart1);
		}
		private void iconbtnSearch_Click(object sender, EventArgs e)
		{
			long numberOfError = 0;  // Replace with your actual data
			long totalOutput = 0;   // Replace with your actual data

			panel3.Controls.Clear();
			panel4.Controls.Clear();
			var dt = new DataTable();
			dt = LINEERRORRECORD_DAL.Instance.TopErrorForLot(cbLot.Text.Trim().ToUpper());
			CreatePieChart(dt, "Top 5 Error", panel3, panel4, "Chart2", "ErrorCode", "TopError", "ErrorENDescription");

			var da1 = new DataTable();
			da1 = LINEERRORRECORD_DAL.Instance.getTotalErrorByLot(cbLot.Text.Trim().ToUpper());
			dgView.DataSource = da1;

			numberOfError = LINEERRORRECORD_DAL.Instance.countTotalErrorByLot(cbLot.Text.Trim().ToUpper());
			totalOutput = LINEERRORRECORD_DAL.Instance.countTotalByLot(cbLot.Text.Trim().ToUpper());
			lblError.Text = numberOfError.ToString();
			lblOutput.Text = totalOutput.ToString();

			double percentOK = Math.Round(((double)(totalOutput - numberOfError) / totalOutput) * 100, 2);
			double percentError = Math.Round(((double)numberOfError / totalOutput) * 100, 2);

			var dta = new DataTable();
			dta = LINEREPAIRHISTORY_DAL.Instance.TopCauseErrorForLot(cbLot.Text.Trim().ToUpper());

			panel5.Controls.Clear();
			CreatePieChart2("Tỷ lệ OK /NG", panel5, "Persen", percentOK, percentError);
			panel1.Controls.Clear();
			CreateColumnChart(dta, "Nguyên nhân lỗi", panel1, "CauseCode", "TopCauseError","","","CauseDept");

		}

		private void iconbtnTim_Click(object sender, EventArgs e)
		{
			var dt= new DataTable();
			dt = LINEERRORRECORD_DAL.Instance.DDRDownloadDateRange(dateFrom.Value, dateTimePicker1.Value);
			dgView02.DataSource=dt;
		}

		private void iconButton1_Click(object sender, EventArgs e)
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
					CommonDAL.Instance.writeCSV(dgView02, filename);
					MessageBox.Show("Đã Export Thành Công !!!");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã có lỗi xảy ra khi Export dữ liệu:" + ex.Message);
				throw;
			}
		}

		private void iconButton2_Click(object sender, EventArgs e)
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
