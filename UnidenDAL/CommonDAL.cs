using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDTO;
using EzioDll;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using TextBox = System.Windows.Forms.TextBox;
using System.Media;

namespace UnidenDAL
{
    public class CommonDAL:IDisposable
    {
        private static readonly object _lock = new object();
        private readonly UVEntities _entities = new UVEntities();
        private DbContextTransaction _transaction;
        private static CommonDAL instance;
        

        public static CommonDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommonDAL();
                return instance;
            }
            // set => instance = value;
        }
        public CommonDAL() { }
		
		public void Dispose()
		{
			_entities.Dispose(); // Dispose of DbContext
			if (_transaction != null)
			{
				_transaction.Dispose(); // Dispose of transaction
			}
		}
		//public CommonDAL(UVEntities entities)
		//{
		//    _entities = entities;
		//}
		public void BeginTransaction()
        {
            _transaction = _entities.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
			_transaction.Commit();
			_transaction.Dispose();
			_transaction = null;
		}

        public void RollbackTransaction()
        {
			_transaction.Rollback();
			_transaction.Dispose();
			_transaction = null;
		}

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }
        public void LoadButtonFucntion()
        {

        }
        public DateTime getSqlServerDatetime()
        {
            var dateQuery = _entities.Database.SqlQuery<DateTime>("SELECT getdate()");
            DateTime serverDate = dateQuery.AsEnumerable().First();
            return serverDate;
        }
        //To call the preceding method, use the following syntax:
        //List<Student> studentDetails = new List<Student>();
        //studentDetails = ConvertDataTable<Student>(dt); 
        // chuyển từ datatable to list
        public  List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public  T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        // chuyển từ list to datatable
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public IEnumerable<Control> AllSubControls(Control control)
                => Enumerable.Repeat(control, 1)
                    .Union(control.Controls.OfType<Control>()
                              .SelectMany(AllSubControls)
             );

        public void CheckButtonEnable(IEnumerable<Control> lst, List<SYS_UserButtonFunction> list)
        {
            foreach (var button in lst)
            {
                foreach (var item in list)
                {
                    if (item.ButtonId == button.Name && item.AccessStatus != true)
                    {
                        button.Visible = false;
                    }
                }
            }
        }

        public void ShowDataGridView(DataGridView dgview, IEnumerable<Object> list)
        {
            dgview.DataSource = list;
            dgview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        public void ShowDataGridViewWithDataTable(DataGridView dgview, DataTable dt)
        {
            dgview.DataSource = dt;
            dgview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public void DropDownCombo(object sender, KeyPressEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.DroppedDown = true;
            string strFindStr = "";
            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }
            int intIdx = -1;
            // Search the string in the ComboBox list.
            intIdx = cb.FindString(strFindStr);
            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
                e.Handled = true;
        }
        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
                for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        if (dr.Cells[i].Value == null)
                        {
                            value = "";
                        }
                        else
                        {
                            value = dr.Cells[i].Value.ToString();
                        }

                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
                //MessageBox.Show("Đã Export Xong !!!");
            }
        }
        public void SelectDialog(TextBox txtFile)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Please Select Excel File to Import |*.xlsx;*.xls";
            op.Title = "Select Excel";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = op.FileName;
            }
        }
        public void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }
        public void ClearDataGridView(DataGridView dgView)
        {
            dgView.DataSource = null;
            dgView.DataBindings.Clear();
            dgView.Columns.Clear();
            dgView.Rows.Clear();
            dgView.Update();
            dgView.Refresh();
        }
        //var people = new List<Person> { new Person("Matt", "Abbott"), new Person("John Smith") };
        //WriteCSV(people, @"C:\people.csv");

        public void WriteTextError(string pathFile, string writeLine)
        {
            string path = pathFile;
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(writeLine);
                tw.Dispose();
            }
            else if (File.Exists(path))
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(writeLine);
                }
            }
        }
        public DataTableCollection BrowserExcelToCombobox(string filePath)
        {
            
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    return  result.Tables;
                    //cbSheet.Items.Clear();
                    //foreach (DataTable table in tableCollection)
                    //    cbSheet.Items.Add(table.TableName); //add sheet to combo
                }
            }
        }
        public void ExportToExcelFromDgView(DataGridView dgView)
        {
            if (dgView.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgView.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgView.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgView.Rows.Count; i++)
                {
                    for (int j = 0; j < dgView.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        public DataTable runStoreProceduceExecuteQuery(string sqlproceduce, object[] ParaValue=null) 
        {            
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText =sqlproceduce;
                command.CommandType = CommandType.StoredProcedure;
                if (ParaValue!=null)
                {
                    foreach (var item in ParaValue)
                    {
                        command.Parameters.Add(new SqlParameter("@" + item.ToString(), item.ToString()));
                    }
                }                            
                //command.Parameters.Add(new SqlParameter("@Search", search));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        public int runStoreProceduceExecuteNonQuery(string sqlproceduce, object[] ParaValue = null)
        {
            int data = 0;

            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = sqlproceduce;
                command.CommandType = CommandType.StoredProcedure;
                if (ParaValue != null)
                {
                    foreach (var item in ParaValue)
                    {
                        command.Parameters.Add(new SqlParameter("@" + item.ToString(), item.ToString()));
                    }
                }
                //command.Parameters.Add(new SqlParameter("@Search", search));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                data=command.ExecuteNonQuery();
            }
            return data;
        }
        public void FindPrinter_USB(ComboBox Cbo_USB)
        {
            Cbo_USB.Items.Clear();
            List<string> PrinterList = GodexPrinter.GetPrinter_USB();
            for (int i = 0; i < PrinterList.Count; i++)
                Cbo_USB.Items.Add(PrinterList[i]);
            if (Cbo_USB.Items.Count > 0)
                Cbo_USB.SelectedIndex = 0;
        }
        GodexPrinter Printer = new GodexPrinter();
        public void ConnectPrinter(RadioButton RBtn_USB, ComboBox Cbo_USB)
        {
            if (RBtn_USB.Checked == true)
            {
                if (Cbo_USB.SelectedIndex > -1)
                    Printer.OpenUSB(Cbo_USB.SelectedItem.ToString());
                else
                    Printer.Open(PortType.USB);
            }
        }

		#region Thiết lập màu và giá trị cho lable
		public void SetStatusLabels(System.Windows.Forms.Label lbl, string status)
		{
			lbl.Text = status;
			lbl.ForeColor = status == "OK" ? System.Drawing.Color.Green : System.Drawing.Color.Red;
		}
		#endregion

		#region Phát nhạc NG OK
		public void PlaySound(System.IO.Stream soundStream)
		{
			try
			{
				SoundPlayer sndPlay = new SoundPlayer(soundStream);
				sndPlay.Play();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Đã có lỗi xảy ra FUserCheck: {ex.Message}");
			}
		}
		#endregion
	}
}
