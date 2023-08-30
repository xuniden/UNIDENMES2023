using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDTO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace UnidenDAL.Jig.JIG
{
    public class JIGHCALDEVICES_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGHCALDEVICES_DAL instance;
        public static JIGHCALDEVICES_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGHCALDEVICES_DAL();
                return instance;
            }
        }
        public JIGHCALDEVICES_DAL() { }
		//

		#region Download Data
		public List<JIGH_CALDEVICES> DownloadData(string search)
		{
			return _entities.JIGH_CALDEVICES.Where(a => a.ControlNo.Contains(search)
															|| a.EqName.Contains(search)
															|| a.Maker.Contains(search)
															|| a.Model.Contains(search)
															|| a.LocName.Contains(search)
															|| a.JigSecCode.Contains(search)
															)
					 .ToList();
		}
		#endregion

		#region Đếm số bản ghi
		public long CountSearch(string search)
		{
			return _entities.JIGH_CALDEVICES.Where(a => a.ControlNo.Contains(search)
															|| a.EqName.Contains(search)
															|| a.Maker.Contains(search)
															|| a.Model.Contains(search)
															|| a.LocName.Contains(search)
															|| a.JigSecCode.Contains(search)
															).Count();
		}
		#endregion

		#region Tìm kiếm và phân trang theo part
		public List<JIGH_CALDEVICES> searchByQRModelPartPagesEntity(int pageNumber, int RecordPerPage, string search)
		{
			var lstResult = new List<JIGH_CALDEVICES>();
			int startIndex = (pageNumber - 1) * RecordPerPage;

			lstResult = _entities.JIGH_CALDEVICES.Where(a => a.ControlNo.Contains(search)
															|| a.EqName.Contains(search)															
															|| a.Maker.Contains(search)
															|| a.Model.Contains(search)
															|| a.LocName.Contains(search)
															|| a.JigSecCode.Contains(search)															
															)
					 .OrderBy(a => a.ControlNo) // Replace with the actual property to order by
					 .Skip(startIndex)
					 .Take(RecordPerPage)					 
					 .ToList();

			return lstResult;
		}
		#endregion

		public DataTable getListJIG(string Search)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_jig_getListJIG";
                command.CommandType = CommandType.StoredProcedure;               
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
		public System.Data.DataTable getBySearchJIG(DateTime fromdate, DateTime todate)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_jig_getBySearchJIG";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@fromdate", fromdate));
				command.Parameters.Add(new SqlParameter("@todate", todate));

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
		

		public JIGH_CALDEVICES checkCalDevicesExist(string controlNo)
        {
            return _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
        }

        public JIGH_CALDEVICES checkCalDevicesStatus(string controlNo)
        {
			return _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo && p.SStatus.Contains("NG")).FirstOrDefault();
		}

		public List<JIGH_CALDEVICES> checkCalDevicesList(string controlNo)
		{
            return _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo).ToList();
		}
		public List<JIGH_CALDEVICES>getListJIGDevice() 
        { 
            return _entities.JIGH_CALDEVICES.OrderByDescending(x=>x.CreatedDate).Take(1000).ToList();
        }
        public List<JIGH_CALDEVICES> getListJIGDevice(string search)
        {
            return _entities.JIGH_CALDEVICES.Where(p=>p.ControlNo.Contains(search)||p.Model.Contains(search)).OrderBy(x=>x.Model).ToList();
        }
        public string Remove(string controlNo)
        {
            string message = "";
            var calDevices = new JIGH_CALDEVICES();
            calDevices = _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (calDevices != null)
            {
                _entities.JIGH_CALDEVICES.Remove(calDevices);
                _entities.SaveChanges();
                message = "";
            }
            else
            {
                message = "Không thể xóa được JIG control này";
            }
            return message;
        }
        public string AddRange(List<JIGH_CALDEVICES> jigDevices)
        {
            string message;
            try
            {
                _entities.JIGH_CALDEVICES.AddRange(jigDevices);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        public string Add(JIGH_CALDEVICES jigDevices)
        {
            string message;
            try
            {
                _entities.JIGH_CALDEVICES.Add(jigDevices);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
              message=ex.Message;
            }
            return message;
        }
        public string UpdateHC(JIGH_CALDEVICES jigCal)
        {
            string message;
            var jig = _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == jigCal.ControlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.MakeDate = jigCal.MakeDate;
                    jig.UpdatedDate = jigCal.UpdatedDate;
                    jig.UpdatedBy = jigCal.UpdatedBy;
                    _entities.SaveChanges();
                    message = "";
                }
                catch(Exception ex)
                {
                    message=ex.Message;
                }
            }
            else
            {
                message = "Không tìm thấy";
            }
            return message;
        }
        public string UpdateReal(string controlNo, bool real)
        {
            string message;
            var jig = _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.Real = real;
                    _entities.SaveChanges();
                    message = "";
                }
                catch(Exception ex)
                {
                    message=ex.Message;
                }
            }
            else
            {
                message = "Không tìm thấy JIG có mã: " +controlNo;
            }
            return message;
        }
		public string UpdateSStatus(string controlNo, string sstatus, DateTime dateTime)
		{
			string message;
			var jig = _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
			if (jig != null)
			{
				try
				{
					jig.SStatus = sstatus;
                    jig.UpdatedDate=dateTime;
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
				message = "Không tìm thấy JIG có mã: " + controlNo;
			}
			return message;
		}
		public string UpdateRealIN(string controlNo, bool real, string jigsec, string jigloc,string fixlocation, string userId, DateTime dt)
        {
            string message;
            var jig = _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.Real = real;
                    jig.JigSecCode = jigsec;
                    jig.LocName = jigloc;
                    jig.FixLocation = fixlocation;
                    jig.CurLocation = null;
                    jig.CurSection = null;
                    jig.UpdatedBy = userId;
                    jig.UpdatedDate = dt;
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
                message = "Không tìm thấy JIG có mã: " + controlNo;
            }
            return message;
        }
		public string UpdateRealOUT(string controlNo, bool real, string CurSection, string CurLocation,string userId, DateTime dt)
		{
			string message;
			var jig = _entities.JIGH_CALDEVICES.Where(p => p.ControlNo == controlNo).FirstOrDefault();
			if (jig != null)
			{
				try
				{
					jig.Real = real;					
					jig.UpdatedBy = userId;
					jig.UpdatedDate = dt;
                    jig.CurSection = CurSection;
                    jig.CurLocation = CurLocation;
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
				message = "Không tìm thấy JIG có mã: " + controlNo;
			}
			return message;
		}
		public string Update(JIGH_CALDEVICES jigDevices)
        {
            string message;
            var jig = _entities.JIGH_CALDEVICES.Where(p => p.Id == jigDevices.Id).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.ControlNo = jigDevices.ControlNo;
                    jig.EqName = jigDevices.EqName;                  
                    jig.Model = jigDevices.Model;
                    jig.Maker = jigDevices.Maker;
                    jig.MakeDate = jigDevices.MakeDate;
                    jig.RepairDate= jigDevices.RepairDate;
                    jig.JigSecCode = jigDevices.JigSecCode;
                    jig.LocName = jigDevices.LocName;
                    jig.FixLocation = jigDevices.FixLocation;
                    jig.SStatus = jigDevices.SStatus;
                    jig.NGDetail = jigDevices.NGDetail;                    
                    jig.Remark = jigDevices.Remark;
                    jig.SStatus = jigDevices.SStatus;
                    jig.PurDate = jigDevices.PurDate;
                    jig.ImportCond = jigDevices.ImportCond;                                       
                    jig.UpdatedBy = jigDevices.UpdatedBy;
                    jig.UpdatedDate = jigDevices.UpdatedDate;
                    jig.Remark=jigDevices.Remark;
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                    message= ex.Message;    
                }
            }
            else
            {
                message = "Không tìm thấy mã " + jigDevices.ControlNo;
            }
            return message;
        }
        public DataTable getjig_eq_getListJIG(int Option, string Search)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_jig_eq_getListJIG";
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
    }
}
