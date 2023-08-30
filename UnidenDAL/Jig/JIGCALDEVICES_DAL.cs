using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using System.Security.AccessControl;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UnidenDAL.Jig
{
    public class ShowCalDevices
    {        
        public string ControlNo { get; set; }
        public string EqName { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }        
        public string CalType { get; set; }     
 
        public string Maker { get; set; }
        public DateTime CalDate { get; set; }
        public string JigSecCode { get; set; }
        public string LocName { get; set; }
        public string SStatus { get; set; }
        public string NGDetail { get; set; }
        public string DevicesDesc { get; set; }
        public string Remark { get; set; }
        public string UseStatus { get; set; }
        public DateTime PurDate { get; set; }
        public string ImportCond { get; set; }
        public string Origin { get; set; }
        public string OldControlNo { get; set; }
        public string BookValue { get; set; }
        public string InvoiceNo { get; set; }
        public string FACode1 { get; set; }
        public string FACode2 { get; set; }
        public bool Real { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate {get;set;}
        public DateTime UpdatedDate { get;set;}
        public long Id { get; set; }
    }
    public class JIGCALDEVICES_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGCALDEVICES_DAL instance;
        public static JIGCALDEVICES_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGCALDEVICES_DAL();
                return instance;
            }
        }
        public JIGCALDEVICES_DAL() { }
        public DataTable ThietBiCanHieuChinhTheoNgayThang(string CalType, DateTime sdate, DateTime edate)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_Jig_NeedCalibration";
                command.CommandType = CommandType.StoredProcedure;                
                command.Parameters.Add(new SqlParameter("@CalType", CalType));
                command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                command.Parameters.Add(new SqlParameter("@ToDate", edate));
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
        public List<ShowCalDevices> getListCalDevices()
        {
            return (from a in _entities.JIG_CALDEVICES
                    select new ShowCalDevices
                    {
                        Id = a.Id, 
                        ControlNo = a.ControlNo,
                        EqName = a.EqName,
                        CalType = a.CalType,
                        SerialNumber = a.SerialNumber,
                        Model = a.Model,
                        Maker=a.Maker,
                        CalDate = a.CalDate,
                        JigSecCode = a.JigSecCode,
                        LocName = a.LocName,
                        SStatus = a.SStatus,
                        NGDetail = a.NGDetail,
                        DevicesDesc = a.DevicesDesc,
                        Remark = a.Remark,
                        UseStatus = a.UseStatus,
                        PurDate = a.PurDate,
                        ImportCond = a.ImportCond,
                        Origin = a.Origin,  
                        OldControlNo = a.OldControlNo,
                        BookValue= a.BookValue,
                        InvoiceNo= a.InvoiceNo,
                        FACode1 = a.FACode1,
                        FACode2 = a.FACode2,
                        Real = a.Real,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        UpdatedDate = a.UpdatedDate
                    }).ToList();
        }
		public List<ShowCalDevices> getListCalDevicesByEdit(string controlNo)
		{
			return (from a in _entities.JIG_CALDEVICES.Where(p=>p.ControlNo == controlNo)
					select new ShowCalDevices
					{
						Id = a.Id,
						ControlNo = a.ControlNo,
						EqName = a.EqName,
						CalType = a.CalType,
						SerialNumber = a.SerialNumber,
						Model = a.Model,
						Maker = a.Maker,
						CalDate = a.CalDate,
						JigSecCode = a.JigSecCode,
						LocName = a.LocName,
						SStatus = a.SStatus,
						NGDetail = a.NGDetail,
						DevicesDesc = a.DevicesDesc,
						Remark = a.Remark,
						UseStatus = a.UseStatus,
						PurDate = a.PurDate,
						ImportCond = a.ImportCond,
						Origin = a.Origin,
						OldControlNo = a.OldControlNo,
						BookValue = a.BookValue,
						InvoiceNo = a.InvoiceNo,
						FACode1 = a.FACode1,
						FACode2 = a.FACode2,
						Real = a.Real,
						CreatedBy = a.CreatedBy,
						CreatedDate = a.CreatedDate,
						UpdatedDate = a.UpdatedDate
					}).ToList();
		}

		#region Download Data
		public List<ShowCalDevices> DownloadData(string search)
		{
			return _entities.JIG_CALDEVICES.Where(p => p.ControlNo.Contains(search)
					 || p.EqName.Contains(search)
					 || p.SerialNumber.Contains(search)
					 || p.Maker.Contains(search)
					 || p.Model.Contains(search)
					 || p.LocName.Contains(search)
					 || p.JigSecCode.Contains(search)
					 || p.FACode1.Contains(search)
					 || p.FACode2.Contains(search)
					 ).Select(a => new ShowCalDevices
					 {
						 Id = a.Id,
						 ControlNo = a.ControlNo,
						 EqName = a.EqName,
						 Model = a.Model,
						 SerialNumber = a.SerialNumber,
						 CalType = a.CalType,
						 Maker = a.Maker,
						 CalDate = a.CalDate,
						 JigSecCode = a.JigSecCode,
						 LocName = a.LocName,
						 SStatus = a.SStatus,
						 NGDetail = a.NGDetail,
						 DevicesDesc = a.DevicesDesc,
						 Remark = a.Remark,
						 UseStatus = a.UseStatus,
						 PurDate = a.PurDate,
						 ImportCond = a.ImportCond,
						 Origin = a.Origin,
						 OldControlNo = a.OldControlNo,
						 BookValue = a.BookValue,
						 InvoiceNo = a.InvoiceNo,
						 FACode1 = a.FACode1,
						 FACode2 = a.FACode2,
						 Real = a.Real,
						 CreatedBy = a.CreatedBy,
						 CreatedDate = a.CreatedDate,
						 UpdatedDate = a.UpdatedDate
					 })
                     .ToList();
		}
		#endregion

		public long CountSearch( string search)
		{			
			return  _entities.JIG_CALDEVICES.Where(p => p.ControlNo.Contains(search)
					|| p.EqName.Contains(search)
					|| p.SerialNumber.Contains(search)
					|| p.Maker.Contains(search)
					|| p.Model.Contains(search)
					|| p.LocName.Contains(search)
					|| p.JigSecCode.Contains(search)
					|| p.FACode1.Contains(search)
					|| p.FACode2.Contains(search)
					).Count();			
		}


		#region Tìm kiếm và phân trang theo part
		public List<ShowCalDevices> searchByQRModelPartPagesEntity(int pageNumber, int RecordPerPage, string search)
		{
			var lstResult = new List<ShowCalDevices>();
			int startIndex = (pageNumber - 1) * RecordPerPage;
			
				lstResult = _entities.JIG_CALDEVICES.Where(a => a.ControlNo.Contains(search)
					                                            || a.EqName.Contains(search)
					                                            || a.SerialNumber.Contains(search)
					                                            || a.Maker.Contains(search)
					                                            || a.Model.Contains(search)
					                                            || a.LocName.Contains(search)
					                                            || a.JigSecCode.Contains(search)
					                                            || a.FACode1.Contains(search)
					                                            || a.FACode2.Contains(search)
					                                            )
						 .OrderBy(a => a.ControlNo) // Replace with the actual property to order by
						 .Skip(startIndex)
						 .Take(RecordPerPage)
						 .Select(a => new ShowCalDevices
						 {
							 Id = a.Id,
							 ControlNo = a.ControlNo,
							 EqName = a.EqName,
							 Model = a.Model,
							 SerialNumber = a.SerialNumber,
							 CalType = a.CalType,
							 Maker = a.Maker,
							 CalDate = a.CalDate,
							 JigSecCode = a.JigSecCode,
							 LocName = a.LocName,
							 SStatus = a.SStatus,
							 NGDetail = a.NGDetail,
							 DevicesDesc = a.DevicesDesc,
							 Remark = a.Remark,
							 UseStatus = a.UseStatus,
							 PurDate = a.PurDate,
							 ImportCond = a.ImportCond,
							 Origin = a.Origin,
							 OldControlNo = a.OldControlNo,
							 BookValue = a.BookValue,
							 InvoiceNo = a.InvoiceNo,
							 FACode1 = a.FACode1,
							 FACode2 = a.FACode2,
							 Real = a.Real,
							 CreatedBy = a.CreatedBy,
							 CreatedDate = a.CreatedDate,
							 UpdatedDate = a.UpdatedDate
						 })
						.ToList();
			
			return lstResult;
		}
		#endregion

		public List<ShowCalDevices> getListCalDevices(string search)
        {
            return (from a in _entities.JIG_CALDEVICES.Where(p => p.ControlNo.Contains(search) 
                    || p.EqName.Contains(search)
                    || p.SerialNumber.Contains(search)
                    || p.Maker.Contains(search)
                    || p.Model.Contains(search)
                    || p.LocName.Contains(search)
                    || p.JigSecCode.Contains(search)
                    ||p.FACode1.Contains(search)
                    || p.FACode2.Contains(search)
                    )
                    select new ShowCalDevices
                    {
                        Id = a.Id,
                        ControlNo = a.ControlNo,
                        EqName = a.EqName,
                        Model = a.Model,
                        SerialNumber = a.SerialNumber,
                        CalType = a.CalType,                      
                        Maker = a.Maker,
                        CalDate = a.CalDate,
                        JigSecCode = a.JigSecCode,
                        LocName = a.LocName,
                        SStatus = a.SStatus,
                        NGDetail = a.NGDetail,
                        DevicesDesc = a.DevicesDesc,
                        Remark = a.Remark,
                        UseStatus = a.UseStatus,
                        PurDate = a.PurDate,
                        ImportCond = a.ImportCond,
                        Origin = a.Origin,
                        OldControlNo = a.OldControlNo,
                        BookValue   = a.BookValue,
                        InvoiceNo= a.InvoiceNo,
                        FACode1 = a.FACode1,
                        FACode2 = a.FACode2,
                        Real = a.Real,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        UpdatedDate = a.UpdatedDate
                    }).ToList();
        }
        public List<ShowCalDevices> getListCalDevicesByControlOrSerial(string search)
        {
            return (from a in _entities.JIG_CALDEVICES.Where(p => p.ControlNo.Contains(search)                    
                    || p.SerialNumber.Contains(search)
                    || p.Model.Contains(search)
                    )
                    select new ShowCalDevices
                    {
                        Id = a.Id,
                        ControlNo = a.ControlNo,
                        EqName = a.EqName,
                        Model = a.Model,
                        SerialNumber = a.SerialNumber,
                        CalType = a.CalType,
                        Maker = a.Maker,
                        CalDate = a.CalDate,
                        JigSecCode = a.JigSecCode,
                        LocName = a.LocName,
                        SStatus = a.SStatus,
                        NGDetail = a.NGDetail,
                        DevicesDesc = a.DevicesDesc,
                        Remark = a.Remark,
                        UseStatus = a.UseStatus,
                        PurDate = a.PurDate,
                        ImportCond = a.ImportCond,
                        Origin = a.Origin,
                        OldControlNo = a.OldControlNo,
                        BookValue = a.BookValue,
                        InvoiceNo = a.InvoiceNo,
                        FACode1 = a.FACode1,
                        FACode2 = a.FACode2,
                        Real = a.Real,
                        CreatedBy = a.CreatedBy,
                        CreatedDate = a.CreatedDate,
                        UpdatedDate = a.UpdatedDate
                    }).ToList();
        }
        public bool Remove(string controlNo)
        {
            var calDevices = new JIG_CALDEVICES();
            calDevices = _entities.JIG_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (calDevices != null)
            {
                _entities.JIG_CALDEVICES.Remove(calDevices);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public JIG_CALDEVICES checkCalDevicesExist(string controlNo)
        {
            return _entities.JIG_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
        }
        public JIG_CALDEVICES checkCalDevicesExistBySerial(string Serial)
        {
            return _entities.JIG_CALDEVICES.Where(p => p.SerialNumber == Serial).FirstOrDefault();
        }
        public string Add(JIG_CALDEVICES jigDevices)
        {
            string message = "";
            try
            {
                _entities.JIG_CALDEVICES.Add(jigDevices);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public bool UpdateHC(JIG_CALDEVICES jigCal)
        {
            var jig = _entities.JIG_CALDEVICES.Where(p => p.ControlNo == jigCal.ControlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.CalDate = jigCal.CalDate;
                    jig.UpdatedDate = jigCal.UpdatedDate;
                    jig.CreatedBy = jigCal.CreatedBy;
                    _entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public string UpdateRealIN(string controlNo, bool real, string sstatus, 
            string ngdetail, string usestatus, string eqSection, string eqLocation)
        {
            string message = "";
            var jig = _entities.JIG_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.Real = real;
                    jig.SStatus = sstatus;
                    jig.NGDetail = ngdetail;
                    jig.UseStatus = usestatus;
                    jig.JigSecCode = eqSection;
                    jig.LocName = eqLocation;
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                message = "Không tìm thấy EQ Control này trong CSDL";
            }
            return message;
        }
        public string UpdateRealOUT(string controlNo, bool real, string sstatus, string ngdetail, string usestatus)
        {
            string message = "";
            var jig = _entities.JIG_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.Real = real;
                    jig.SStatus = sstatus;
                    jig.NGDetail = ngdetail;
                    jig.UseStatus = usestatus;
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                    message = ex.Message;   
                }   
            }
            else
            {
                message = "Không tìm thấy EQ Control này trong CSDL";
            }
            return message;
        }

        public string UpdateSStatus(string controlNo, string sstatus, DateTime updatedate)
        {
			string message = "";
			var jig = _entities.JIG_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
			if (jig != null)
			{
				try
				{
					
					jig.SStatus = sstatus;
                    jig.UpdatedDate = updatedate;
					_entities.SaveChanges();
					message = "";
				}
				catch (Exception ex)
				{
					message = ex.Message;
				}
			}
			else
			{
				message = "Không tìm thấy EQ Control này trong CSDL";
			}
			return message;
		}
        public string Update(JIG_CALDEVICES jigDevices)
        {
            string message = "";
            var jig = _entities.JIG_CALDEVICES.Where(p => p.ControlNo == jigDevices.ControlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.EqName = jigDevices.EqName;
                    jig.UpdatedDate = jigDevices.UpdatedDate;
                    jig.CalType = jigDevices.CalType;
                    jig.SerialNumber = jigDevices.SerialNumber;
                    jig.Model = jigDevices.Model;
                    jig.Maker = jigDevices.Maker;
                    jig.CalDate = jigDevices.CalDate;
                    jig.JigSecCode = jigDevices.JigSecCode;
                    jig.LocName = jigDevices.LocName;
                    jig.SStatus = jigDevices.SStatus;
                    jig.NGDetail = jigDevices.NGDetail;
                    jig.DevicesDesc = jigDevices.DevicesDesc;
                    jig.Remark = jigDevices.Remark;
                    jig.UseStatus = jigDevices.UseStatus;
                    jig.PurDate = jigDevices.PurDate;
                    jig.ImportCond = jigDevices.ImportCond;
                    jig.Origin = jigDevices.Origin;
                    jig.OldControlNo = jigDevices.OldControlNo;
                    jig.BookValue= jigDevices.BookValue;
                    jig.InvoiceNo= jigDevices.InvoiceNo;
                    jig.FACode1 = jigDevices.FACode1;
                    jig.FACode2 = jigDevices.FACode2;
                    jig.Real = jigDevices.Real;
                    jig.CreatedBy = jigDevices.CreatedBy;                   
                    jig.UpdatedDate = jigDevices.UpdatedDate;
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                message="Không tìm thấy dữ liệu theo mã thiết bị";
            }
            return message;
        }
        public DataTable getjig_eq_getListEQ(int Option, string Search)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_jig_eq_getListEQ";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Option", Option));
                command.Parameters.Add(new SqlParameter("@Search", Search));
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

		public DataTable getNewDeviceControNoAuto()
		{
			//sp_Jig_GetNewControlNo
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Jig_GetNewControlNoAuto";
				command.CommandType = CommandType.StoredProcedure;
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
	}
}
