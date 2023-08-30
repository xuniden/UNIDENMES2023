using ExcelDataReader.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace UnidenDAL.Assy
{
	public class LINEERRORRECORD_DAL
	{
		UVEntities _entities = new UVEntities();
		private static LINEERRORRECORD_DAL instance;
		public static LINEERRORRECORD_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new LINEERRORRECORD_DAL();
				return instance;
			}
		}
		public LINEERRORRECORD_DAL() { }

		public UV_LINEERRORRECORD checkQRCode(string qrcode)
		{
			return _entities.UV_LINEERRORRECORD.Where(p=>p.BarVsQr==qrcode).FirstOrDefault();
		}
		#region tìm kiếm theo barcode/lot/processName/line/Createby
		public List<UV_LINEERRORRECORD> SearchData(string search)
		{
			return _entities.UV_LINEERRORRECORD.Where(
				p => p.BarVsQr.Contains( search			)
			|| p.Lot.Contains(search)
			|| p.ProcessName.Contains(search)
			|| p.LineName.Contains(search)
			|| p.CreatedBy.Contains(search)).ToList();
		}
		#endregion

		public string Add(UV_LINEERRORRECORD lineRecoder)
		{
			string message = "";
			try
			{
				_entities.UV_LINEERRORRECORD.Add(lineRecoder);
				_entities.SaveChanges();
				message = "";
				return message;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				return message;
			}
		}
		#region Lấy 10 lỗi nhiều nhất trong bảng lỗi
		public DataTable TopErrorForAll()
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_TopErrorForAll";
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
		#endregion

		#region Lấy 5 lỗi nhiều nhất cuả một LOT bất kỳ
		public DataTable TopErrorForLot(string lot)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_TopErrorForLot";
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
			return dt;
		}
		#endregion

		#region Lấy danh sách lot đã được làm tại assy
		public DataTable LotList()
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_LotList";
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
		#endregion

		#region Lấy dữ liệu lỗi theo Lot
		public DataTable getTotalErrorByLot(string lot)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getTotalErrorByLot";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@lot", lot));
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

		#region Đếm tổng số lượng output theo Lot
		public long countTotalByLot(string lot)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_countTotalByLot";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@lot", lot));
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}
			return long.Parse(dt.Rows[0][0].ToString());
		}
		#endregion

		#region Đếm tổng số lượng lỗi theo Lot
		public long countTotalErrorByLot(string lot)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_countTotalErrorByLot";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@lot", lot));
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}
			return long.Parse(dt.Rows[0][0].ToString());
		}
		#endregion

		#region Lấy danh sách các bản ghi từ ngày tháng năm tới ngày tháng năm
		public DataTable DDRDownloadDateRange(DateTime fromDate, DateTime toDate)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_DDRDownloadDateRange";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@fromDate", fromDate));
				command.Parameters.Add(new SqlParameter("@todate", toDate));
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

		#region Từ Unitcode trả lại Barcode tương ứng với Unitcode
		public string SearchByUnitCodeStep01(string UnitCode)
		{

			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getAllInfoByUnitCode01";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@UnitCode", UnitCode));				
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}
			string result = "";
			if (dt.Rows.Count>0)
			{
				result= dt.Rows[0]["QrCode00"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
			
		}
		#endregion

		#region Từ Từ Barcode lấy được thì lấy ra tất cả các Qrcode 
		public StringBuilder SearchByUnitCodeStep02(string Barcode)
		{

			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getAllInfoByUnitCode02";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Barcode", Barcode));
				if (command.Connection.State != ConnectionState.Open)
				{
					command.Connection.Open();
				}
				using (var reader = command.ExecuteReader())
				{
					dt.Load(reader);
				}
			}

			StringBuilder result = new StringBuilder(); // Create a new StringBuilder object

			if (dt.Rows.Count > 0)
			{
				result.Append("'");
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					string field = "QrCode0" + (i + 1);
					
					if (!string.IsNullOrEmpty(dt.Rows[0].Field<string>(field)) && dt.Rows[0].Field<string>(field).Length>0)
					{
						result.Append( dt.Rows[0].Field<string>(field) );
						result.Append("','");
					}
					
				}
				result.Length--;
				result.Length--;
			}			
			return result;

		}
		#endregion

		#region Từ danh sách qr code có được thì lấy toàn bộ dữ liệu smt
		public DataTable SearchByUnitCodeStep03(StringBuilder qrcode, int Option)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getAllInfoByUnitCode03";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@qrcode", qrcode.ToString()));
				command.Parameters.Add(new SqlParameter("@Option", Option));
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
		#region Từ danh sách qr code có được thì lấy toàn bộ dữ liệu ASSY
		public DataTable SearchByUnitCodeStep04(string qrcode ,StringBuilder qrcodeList)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getAllInfoByUnitCode04";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@qrcode", qrcode));
				command.Parameters.Add(new SqlParameter("@qrcodeList", qrcodeList.ToString()));
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

		#region Từ danh sách qr code có được thì lấy toàn bộ dữ liệu repair SMT theo QRcode
		public DataTable SearchByUnitCodeStep05( StringBuilder qrcodeList)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getAllInfoByUnitCode05";
				command.CommandType = CommandType.StoredProcedure;				
				command.Parameters.Add(new SqlParameter("@qrcodeList", qrcodeList.ToString()));
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

		#region Từ danh sách qr code có được thì lấy toàn bộ dữ liệu repair ASSY theo QRcode
		public DataTable SearchByUnitCodeStep06(StringBuilder qrcodeList)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getAllInfoByUnitCode06";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@qrcodeList", qrcodeList.ToString()));
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

		#region Lấy toàn bộ dữ liệu EQ/JIG/Material theo lot
		public DataTable SearchByUnitCodeStep07(string lot)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_Assy_getAllInfoByUnitCode07";
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
			return dt;

		}
		#endregion
	}
}
