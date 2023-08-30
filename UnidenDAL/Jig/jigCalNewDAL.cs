using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Jig
{
    public class jigCalNewDAL
    {
        UVEntities _entities = new UVEntities();
        private static jigCalNewDAL instance;
        public static jigCalNewDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new jigCalNewDAL();
                return instance;
            }
        }
        public jigCalNewDAL() { }

        public string  Add(JIG_CALDEVICES_NEW jigDevices)
        {
            string message = "";
            try
            {
                _entities.JIG_CALDEVICES_NEW.Add(jigDevices);
                _entities.SaveChanges();
                message = "";

			}
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public string Update(JIG_CALDEVICES_NEW jigDevices)
        {
            string message = "";
            var jig = _entities.JIG_CALDEVICES_NEW.Where(p => p.ControlNo == jigDevices.ControlNo).FirstOrDefault();
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
                    jig.BookValue = jigDevices.BookValue;
                    jig.InvoiceNo = jigDevices.InvoiceNo;
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
                    message=ex.Message;
                }
            }
            else
            {
                message = "Không tìm thấy thiết bị theo mã";
            }
            return message;
        }
        public DataTable getNewDeviceControNo()
        {
            //sp_Jig_GetNewControlNo
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_Jig_GetNewControlNo";
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
		#region Lấy 4 số đầu mã công ty để tạo số tem mới tự động tăng
		public DataTable getNewDeviceControNo_New(string Congty)
		{
			//sp_Jig_GetNewControlNo
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Jig_GetNewControlNo_New";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Congty", Congty));
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
		#endregion
		public DataTable getNewDevices(DateTime currentdate)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_Jig_GetNewDevicesByDate";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Date", currentdate));                
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
        public bool UpdateReal(string controlNo, bool real)
        {
            var jig = _entities.JIG_CALDEVICES_NEW.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (jig != null)
            {
                try
                {
                    jig.Real = real;
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
        public bool UpdateHC(JIG_CALDEVICES_NEW jigCal)
        {
            var jig = _entities.JIG_CALDEVICES_NEW.Where(p => p.ControlNo == jigCal.ControlNo).FirstOrDefault();
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
        public JIG_CALDEVICES_NEW checkCalDevicesExist(string controlNo)
        {
            return _entities.JIG_CALDEVICES_NEW.Where(p => p.ControlNo == controlNo).FirstOrDefault();
        }
        public JIG_CALDEVICES_NEW checkCalDevicesExistBySerial(string Serial)
        {
            return _entities.JIG_CALDEVICES_NEW.Where(p => p.SerialNumber == Serial).FirstOrDefault();
        }
        public bool Remove(string controlNo)
        {
            var calDevices = new JIG_CALDEVICES_NEW();
            calDevices = _entities.JIG_CALDEVICES_NEW.Where(p => p.ControlNo == controlNo).FirstOrDefault();
            if (calDevices != null)
            {
                _entities.JIG_CALDEVICES_NEW.Remove(calDevices);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable ThietBiCanHieuChinhTheoNgayThang(string CalType, DateTime sdate, DateTime edate)
        {
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_Jig_NeedCalibrationNew";
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
    }
}
