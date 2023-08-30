using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.AssyLine;
using UnidenDTO;

namespace UnidenDAL.Assy.Setup
{
    public class ListBoxView
    {
        public long processID { get; set; }
        public string processName { get; set; }
        public int? orderProcess { get; set; }
        public string groupProcess { get; set; }
    }
    public class LINEPROCESS_DAL
    {
        UVEntities _entities = new UVEntities();
        private static LINEPROCESS_DAL instance;
        public static LINEPROCESS_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LINEPROCESS_DAL();
                return instance;
            }
        }
        public LINEPROCESS_DAL() { }
        public UV_LINEPROCESS getProcessNameByProcessId(long processID)
        {
            return _entities.UV_LINEPROCESS.Where(p=>p.ProcessId==processID).FirstOrDefault();
        }

        public string Add(UV_LINEPROCESS lineProcess)
        {
            string message = "";
            try
            {
                _entities.UV_LINEPROCESS.Add(lineProcess);
                _entities.SaveChanges();
                message="";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }    
            return message;
        }
        public UV_LINEPROCESS checkExitsProcessName(string lot,string processName)
        { 
            return _entities.UV_LINEPROCESS.Where(p => p.ProcessName == processName && p.Lot==lot).FirstOrDefault();
        }
        public string AddList(List<UV_LINEPROCESS> lstLineProcess)
        {
            string message = "";
            try
            {
                _entities.UV_LINEPROCESS.AddRange(lstLineProcess);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public string  UpdateOrder(long processId, string groupProcess, int orderNumber, bool status, string updatedBy, DateTime updatedDate)
        {
            string message = "";
            var lineProcessU = _entities.UV_LINEPROCESS.Where(p => p.ProcessId == processId&&p.GroupProcess==groupProcess).FirstOrDefault();
            try
            {
                lineProcessU.OrderNumber = orderNumber;
                lineProcessU.Status = status;
                lineProcessU.UpdatedBy = updatedBy;
                lineProcessU.UpdatedDate = updatedDate;
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public string Update(UV_LINEPROCESS lineProcess)
        {
            string message = "";
            var lineProcessU = _entities.UV_LINEPROCESS.Where(p => p.ProcessId == lineProcess.ProcessId).FirstOrDefault();
            if (lineProcessU != null)
            {
                try
                {
                    lineProcessU.ProcessName= lineProcess.ProcessName;                    
                    lineProcessU.Status=lineProcess.Status;                    
                    lineProcessU.UpdatedBy=lineProcess.UpdatedBy;
                    lineProcessU.UpdatedDate = lineProcess.UpdatedDate;
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
                message = "Không tìm thấy ID để update";
            }
            return message;
        }
        public string Delete(UV_LINEPROCESS lineProcess)
        {
            string message = "";
            var lineProcessU = _entities.UV_LINEPROCESS.Where(p => p.ProcessId == lineProcess.ProcessId).FirstOrDefault();
            if (lineProcessU != null)
            {
                try
                {                   
                    lineProcessU.DeleteSatus = lineProcess.DeleteSatus;
                    lineProcessU.UpdatedBy = lineProcess.UpdatedBy;
                    lineProcessU.UpdatedDate = lineProcess.UpdatedDate;
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
                message = "Không tìm thấy ID để xóa";
            }
            return message;
        }

        public string UpdateIsComplete(long processId,string lot)
        {
            string message = "";
            var lineProcessU = _entities.UV_LINEPROCESS.Where(p => p.ProcessId == processId && p.Lot==lot).FirstOrDefault();
            if (lineProcessU != null)
            {
                try
                {
                    lineProcessU.Completed = true;  
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
                message = "Không cập nhật được trạng thái hoàn thành";
            }
            return message;
        }
        public string ResetIsComplete(long processId)
        {
            string message = "";
            var lineProcessU = _entities.UV_LINEPROCESS.Where(p=>p.ProcessId==processId).FirstOrDefault();
            if (lineProcessU != null)
            {
                try
                {
                    lineProcessU.Completed = false;
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
                message = "Không cập nhật được trạng thái hoàn thành";
            }
            return message;
        }
        public List<UV_LINEPROCESS> getListProcessOrderByProcessId(string lot)
        {
            return _entities.UV_LINEPROCESS.Where(p => p.Status == false && p.DeleteSatus == false && p.Lot == lot).OrderBy(p=>p.ProcessId).ToList();
        }
        public List<UV_LINEPROCESS> getNonProcessByLot(string lot)
        {
            return _entities.UV_LINEPROCESS.Where(p=>p.Status==true&&p.DeleteSatus==false&&p.Lot==lot&&p.Completed==false).ToList();
        }
        public UV_LINEPROCESS getProcessInfo(long processId)
        {
            return _entities.UV_LINEPROCESS.Where(p => p.Status == true && p.DeleteSatus == false && p.ProcessId == processId).FirstOrDefault();
        }
        public List<UV_LINEPROCESS>getProcessByLot(string lot)
        {
            return _entities.UV_LINEPROCESS.Where(p=>p.Status==false&&p.DeleteSatus==false&&p.Lot==lot&& p.Completed==false).ToList();
        }
		#region Lấy danh sách process theo Lot
		public List<UV_LINEPROCESS> getAllProcessByLot(string lot)
		{
			return _entities.UV_LINEPROCESS.Where(p=>p.DeleteSatus == false && p.Lot == lot && p.Completed == false).ToList();
		}
		#endregion
		#region Kiểm tra tên công đoạn có trong Lot hay không?
		public UV_LINEPROCESS checkProcessNameByLot(string lot, string processName)
		{
            return _entities.UV_LINEPROCESS.Where(p => p.DeleteSatus == false && p.Lot == lot && p.Completed == false && p.ProcessName == processName).FirstOrDefault();
		}
		#endregion
		// get list process to check step scan QRcode
		public List<UV_LINEPROCESS> getProcessList(string lot)
        {
            return _entities.UV_LINEPROCESS.Where(p=>p.Status==true && p.Lot==lot).OrderBy(x=>x.ProcessId).ToList();
        }
		public List<UV_LINEPROCESS> getProcessListByGroup(string lot, string group)
		{
			return _entities.UV_LINEPROCESS.Where(p => p.Status == true && p.Lot == lot && p.GroupProcess==group).OrderBy(x => x.ProcessId).ToList();
		}

		// Get List Process NONE Scan QR code
		public List<ListBoxView> getProcessNonScanQRByLot(string lot)
        {
            return (from a in  _entities.UV_LINEPROCESS.Where(p => p.Status == false && p.DeleteSatus == false && p.Lot == lot && p.Completed == false)
                    orderby a.ProcessName, a.OrderNumber
                    select new ListBoxView
                    {
                        processID=a.ProcessId,
                        processName=a.ProcessName,
                        orderProcess=a.OrderNumber,
                        groupProcess=a.GroupProcess
                        
                    }).OrderBy(x=>x.processName).ThenBy(p=>p.orderProcess).ToList();
        }
        // Get List Process Scan QR code
        public List<ListBoxView> getProcessScanQRByLot(string lot)
        {
            return (from a in  _entities.UV_LINEPROCESS.Where(p => p.Status == true && p.DeleteSatus == false && p.Lot == lot && p.Completed == false)
                    select new ListBoxView
                    {
                        processID=a.ProcessId,
                        processName=a.ProcessName,
                        orderProcess=a.OrderNumber,
                        groupProcess=a.GroupProcess
                    }).OrderBy(x => x.processName).ThenBy(p => p.orderProcess).ToList();
        }

        public List<UV_LINEPROCESS> getListResetCompleteByProcessId(string lot)
        {
            return _entities.UV_LINEPROCESS.Where(p => p.Status == false && p.DeleteSatus == false && p.Lot == lot&&p.Completed==true).ToList();
        }
        public System.Data.DataTable getListLineProcessByLot(string Lot)
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_uv_lineProcessGetByLot";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Lot", Lot));
                //command.Parameters.Add(new SqlParameter("@FromDate", sdate));
                //command.Parameters.Add(new SqlParameter("@ToDate", edate));
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

        public UV_LINEPROCESS getProcessDetail(long processId)
        {
            return _entities.UV_LINEPROCESS.Where(p=>p.ProcessId == processId).FirstOrDefault();
		}
	}
}
