using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using System.Web;
using System.Drawing.Printing;
using System.Diagnostics;

namespace UnidenDAL.Assy
{
    
    public class LINEPROCESSHISTORY_DAL
    {
        UVEntities _entities = new UVEntities();
        private static LINEPROCESSHISTORY_DAL instance;
        public static LINEPROCESSHISTORY_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LINEPROCESSHISTORY_DAL();
                return instance;
            }
        }
        public LINEPROCESSHISTORY_DAL() { }

        public bool checkSMTvsINSERTQRCodeScanned(string qrcode, string deptText)
        {            
            // Remark3 = Dept
            var result=new EASTECH_SMT_OUTPUT();
            result=_entities.EASTECH_SMT_OUTPUT.Where(p => p.QRCode == qrcode && p.Remark3==deptText).FirstOrDefault();
            if (result != null)
                return true;
            return false;                    
        }
        public bool checkUnitSerial(string Unidecode)
        {
            var result = new UV_LINEPROCESS_HISTORY();
            result=_entities.UV_LINEPROCESS_HISTORY.Where(p=>p.Other01== Unidecode).FirstOrDefault();
            if (result != null) return true;
            return false;
        }


        //spInsertAutoNumbers
        public System.Data.DataTable getNewAutoID()
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "spInsertAutoNumbers";
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
        // Kiểm tra xem QR này đã được combine lần nào chưa
        // Vì QR không thể giống nhau lên chỉ cần check Qr không cần check lot hay process
		public System.Data.DataTable checkQRUniqueCombine(string qrcode)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uv_checkQRCombine";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@QRcode", qrcode));
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
		public System.Data.DataTable getListProcessByUser(string user)
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_uv_getListProcessByUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@user", user));
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
        //public List<ListBoxView> getAllProcessByLot(string lot)
        //{
        //    return (from a in _entities.UV_LINEPROCESS.Where(p => p.Lot == lot)
        //            select new ListBoxView
        //            {
        //                processID=a.ProcessId,
        //                processName = a.ProcessName,
        //                orderProcess = a.OrderNumber
        //            }).ToList(); 
        //}
        public UV_LINEPROCESS_HISTORY checkSannedQRCode(string qrcode, string lot, long processId)
        {
            return _entities.UV_LINEPROCESS_HISTORY.Where(p=>p.QrCode00==qrcode&& p.Lot==lot&& p.ProcessId==processId).FirstOrDefault();
        }
		public UV_LINEPROCESS_HISTORY checkSannedBarcode(string qrcode, long processId)
		{
			return _entities.UV_LINEPROCESS_HISTORY.Where(p => p.QrCode00 == qrcode && p.ProcessId == processId).FirstOrDefault();
		}

		#region Lấy Tên Lot theo QR vs barcode
		public UV_LINEPROCESS_HISTORY checkSannedQRCode(string qrcode)
		{
			return _entities.UV_LINEPROCESS_HISTORY.Where(p => p.QrCode00 == qrcode ||
			    p.QrCode01 == qrcode ||
				p.QrCode02 == qrcode ||
				p.QrCode03 == qrcode ||
				p.QrCode04 == qrcode ||
				p.QrCode05 == qrcode ||
				p.QrCode06 == qrcode ||
				p.QrCode07 == qrcode ||
				p.QrCode08 == qrcode ||
				p.QrCode09 == qrcode ||
				p.QrCode10 == qrcode).FirstOrDefault();
		}
		#endregion
		public UV_LINEPROCESS_HISTORY checkSannedQRCode01(string qrcode, string lot, long processId)
		{
			return _entities.UV_LINEPROCESS_HISTORY.Where(p => p.Lot ==lot && 
            (
                p.QrCode01== qrcode  ||
			    p.QrCode02 == qrcode ||
			    p.QrCode03 == qrcode ||
			    p.QrCode04 == qrcode ||
			    p.QrCode05 == qrcode ||
			    p.QrCode06 == qrcode ||
			    p.QrCode07 == qrcode ||
			    p.QrCode08 == qrcode ||
			    p.QrCode09 == qrcode ||
			    p.QrCode10 == qrcode 			
            ) && p.ProcessId == processId).FirstOrDefault();
		}


		public List<UV_LINEPROCESS_HISTORY> checkProcessScannedQRCode(string qrcode, long processId)
        {
            return _entities.UV_LINEPROCESS_HISTORY.Where(p => p.QrCode00 == qrcode && p.ProcessId == processId).ToList();
        }
        public UV_LINEPROCESS_HISTORY checkLotVsProcessIDScanned(string Lot, long processId)
        {
            return _entities.UV_LINEPROCESS_HISTORY.Where(x=>x.ProcessId == processId&&x.Lot==Lot).FirstOrDefault();            
        }
        public bool checkDataAsTable(string table, string column, string condition)
        {
            bool result = false;
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_uv_CheckDataAsTable";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@table", table));
                command.Parameters.Add(new SqlParameter("@column", column));
                command.Parameters.Add(new SqlParameter("@condition", condition));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            if (dt.Rows.Count > 0) { result = true; }
            return result;
        }
        public string Add(UV_LINEPROCESS_HISTORY lineProcessHistory)
        {
            string message = "";
            try
            {
                _entities.UV_LINEPROCESS_HISTORY.Add(lineProcessHistory);
                _entities.SaveChanges();
                message="";
            }
            catch (Exception ex)
            {
                message=ex.Message;
            }
            return message;
        }
        public List<UV_LINEPROCESS_HISTORY>getHistoryByLotVsCreatedBy(string Lot, string createdBy)
        {
            return _entities.UV_LINEPROCESS_HISTORY.Where(p=>p.Lot == Lot&&(p.CreatedBy==createdBy||p.UpdatedBy==createdBy)).ToList();
        }
        public string UpdateByLotVsProcessId(UV_LINEPROCESS_HISTORY lineProcessHistory)
        {
            string message = "";
            var history= new UV_LINEPROCESS_HISTORY();
            history = _entities.UV_LINEPROCESS_HISTORY.Where(x => x.ProcessId == lineProcessHistory.ProcessId && x.Lot == lineProcessHistory.Lot).FirstOrDefault();
            if (history != null)
            {
                try
                {
                    history.Lot = lineProcessHistory.Lot;
                    history.ProcessId = lineProcessHistory.ProcessId;
                    history.ProcessName = lineProcessHistory.ProcessName;
                    history.LineName = lineProcessHistory.LineName;
                    history.UpdatedBy = lineProcessHistory.UpdatedBy;
                    history.UpdatedDate= lineProcessHistory.UpdatedDate;
                    history.EqControl01 = lineProcessHistory.EqControl01;
                    history.EqControl02 = lineProcessHistory.EqControl02;
                    history.EqControl03 = lineProcessHistory.EqControl03;
                    history.EqControl04 = lineProcessHistory.EqControl04;
                    history.EqControl05 = lineProcessHistory.EqControl05;
                    history.EqControl06 = lineProcessHistory.EqControl06;
                    history.EqControl07 = lineProcessHistory.EqControl07;
                    history.EqControl08 = lineProcessHistory.EqControl08;
                    history.EqControl09 = lineProcessHistory.EqControl09;
                    history.EqControl10 = lineProcessHistory.EqControl10;
                    history.EqControlName01 = lineProcessHistory.EqControlName01;
                    history.EqControlName02 = lineProcessHistory.EqControlName02;
                    history.EqControlName03 = lineProcessHistory.EqControlName03;
                    history.EqControlName04 = lineProcessHistory.EqControlName04;
                    history.EqControlName05 = lineProcessHistory.EqControlName05;
                    history.EqControlName06 = lineProcessHistory.EqControlName06;
                    history.EqControlName07 = lineProcessHistory.EqControlName07;
                    history.EqControlName08 = lineProcessHistory.EqControlName08;
                    history.EqControlName09 = lineProcessHistory.EqControlName09;
                    history.EqControlName10 = lineProcessHistory.EqControlName10;
                    history.EqCalDate01 = lineProcessHistory.EqCalDate01;
                    history.EqCalDate02 = lineProcessHistory.EqCalDate02;
                    history.EqCalDate03 = lineProcessHistory.EqCalDate03;
                    history.EqCalDate04 = lineProcessHistory.EqCalDate04;
                    history.EqCalDate05 = lineProcessHistory.EqCalDate05;
                    history.EqCalDate06 = lineProcessHistory.EqCalDate06;
                    history.EqCalDate07 = lineProcessHistory.EqCalDate07;
                    history.EqCalDate08 = lineProcessHistory.EqCalDate08;
                    history.EqCalDate09 = lineProcessHistory.EqCalDate09;
                    history.EqCalDate10 = lineProcessHistory.EqCalDate10;
                    history.JigControl01 = lineProcessHistory.JigControl01;
                    history.JigControl02 = lineProcessHistory.JigControl02;
                    history.JigControl03 = lineProcessHistory.JigControl03;
                    history.JigControl04 = lineProcessHistory.JigControl04;
                    history.JigControl05 = lineProcessHistory.JigControl05;
                    history.JigControl06 = lineProcessHistory.JigControl06;
                    history.JigControl07 = lineProcessHistory.JigControl07;
                    history.JigControl08 = lineProcessHistory.JigControl08;
                    history.JigControl09 = lineProcessHistory.JigControl09;
                    history.JigControl10 = lineProcessHistory.JigControl10;
                    history.JigName01 = lineProcessHistory.JigName01;
                    history.JigName02 = lineProcessHistory.JigName02;
                    history.JigName03   = lineProcessHistory.JigName03;
                    history.JigName04   = lineProcessHistory.JigName04;
                    history.JigName05   = lineProcessHistory.JigName05;
                    history.JigName06 = lineProcessHistory.JigName06;
                    history.JigName07 = lineProcessHistory.JigName07;
                    history.JigName08   = lineProcessHistory.JigName08;
                    history.JigName09   = lineProcessHistory.JigName09;
                    history.JigName10 = lineProcessHistory.JigName10;
                    history.JigCreate01 = lineProcessHistory.JigCreate01;
                    history.JigCreate02 = lineProcessHistory.JigCreate02;
                    history.JigCreate03 = lineProcessHistory.JigCreate03;
                    history.JigCreate04 = lineProcessHistory.JigCreate04;
                    history.JigCreate05 = lineProcessHistory.JigCreate05;
                    history.JigCreate06 = lineProcessHistory.JigCreate06;
                    history.JigCreate07 = lineProcessHistory.JigCreate07;
                    history.JigCreate08 = lineProcessHistory.JigCreate08;
                    history.JigCreate09 = lineProcessHistory.JigCreate09;
                    history.JigCreate10 = lineProcessHistory.JigCreate10;
                    history.OSG01 = lineProcessHistory.OSG01;
                    history.OSG02 = lineProcessHistory.OSG02;
                    history.OSG03 = lineProcessHistory.OSG03;
                    history.OSG04 = lineProcessHistory.OSG04;
                    history.OSG05 = lineProcessHistory.OSG05;
                    history.OSG06 = lineProcessHistory.OSG06;
                    history.OSG07 = lineProcessHistory.OSG07;
                    history.OSG08 = lineProcessHistory.OSG08;
                    history.OSG09 = lineProcessHistory.OSG09;
                    history.OSG10 = lineProcessHistory.OSG10;
                    history.Material01 = lineProcessHistory.Material01;
                    history.Material02 = lineProcessHistory.Material02;
                    history.Material03 = lineProcessHistory.Material03;
                    history.Material04 = lineProcessHistory.Material04;
                    history.Material05 = lineProcessHistory.Material05;
                    history.Material06 = lineProcessHistory.Material06;
                    history.Material07 = lineProcessHistory.Material07;
                    history.Material08 = lineProcessHistory.Material08;
                    history.Material09 = lineProcessHistory.Material09;
                    history.Material10 = lineProcessHistory.Material10;
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                    message=ex.Message;
                }
            }
            return message;
        }
        public string DeleteBarcode(string barcode, string lot, long processId)
        {
            string message = "";
            var lineDelete = new UV_LINEPROCESS_HISTORY();
            lineDelete=_entities.UV_LINEPROCESS_HISTORY.Where(p=>processId==processId&&p.Lot==lot&&p.QrCode00==barcode).FirstOrDefault();
            if (lineDelete != null)
            {
                try
                {
					_entities.UV_LINEPROCESS_HISTORY.Remove(lineDelete);
					_entities.SaveChanges();
					return message = "";
				}
                catch (Exception ex)
                {
                    return message = ex.Message;
                }
               
            }
            else
            {
                message = "Không tìm thấy dữ liệu nào";
                return message;
            }            
        }
		#region Lấy số tổng số lượng barcode đã được combine với QR code mà công nhân tại công nhân đã làm được
		public int getTotalByUsser(string lot, string userId)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uv_getTotalByUser";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Lot", lot));
				command.Parameters.Add(new SqlParameter("@OperatorID", userId));
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}
			return dt.Rows.Count;
		}
		#endregion
		#region Lấy số tổng số lượng barcode đã được combine với QR code theo Lot
		public int getTotalByLot(string lot)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uv_getTotalByLot";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Lot", lot));				
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}
			return dt.Rows.Count;
		}
		#endregion

		#region Sửa thông tin Unit Code theo Barcode
		public System.Data.DataTable editUnitCodeByBarcode(string barcode)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uv_editUnitCodeByBarcode";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@barcode", barcode));
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

		#region Hiển thị danh sách lỗi DDR theo User
		public System.Data.DataTable getDDRHistory(string user)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uv_getDDRHistory";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@CreatedBy", user));
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

		#region Hiển thị Unit code đã sửa theo barcode và Unitcode
		public System.Data.DataTable ShowEditedUnitcode(string barcode, string unitcode)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uv_getEditUnitCodeByBarcode";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@barcode", barcode));
				command.Parameters.Add(new SqlParameter("@unit", unitcode));
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

		#region Tìm kiếm dữ liệu để xóa hết đi làm lại theo Barcode
		public System.Data.DataTable searchBarcodeToDelete(string barcode)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uv_searchBarcodeToDelete";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@barcode", barcode));				
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

		#region Get thông tin qua ID
        public UV_LINEPROCESS_HISTORY getAllInfo(long ID)
        {
            return _entities.UV_LINEPROCESS_HISTORY.Where(p => p.ID == ID).FirstOrDefault();
        }
		#endregion

		#region Update khi thay đổi Unit Code theo Barcode
		public string EditUnitCode(long ID, string Unitcode,  string updateBy, DateTime updateDate)
        {
            string message = "";
            var processHistory= _entities.UV_LINEPROCESS_HISTORY.Where(p=>p.ID==ID).FirstOrDefault();
            if (processHistory!=null)
            {
                try
                {
					processHistory.Other01 = Unitcode;
					processHistory.UpdatedBy = updateBy;
					processHistory.UpdatedDate = updateDate;
					_entities.SaveChanges();
					message = "";
				}
                catch (Exception ex)
                {
                    message=ex.Message;                   
                }              
            }

            return message;
        }
		#endregion

	}
}
