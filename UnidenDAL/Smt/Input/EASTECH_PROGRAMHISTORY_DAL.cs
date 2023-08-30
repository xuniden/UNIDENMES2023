using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;
using UnidenDAL.Smt.DataControl;

namespace UnidenDAL.Smt.Input
{
	public class ProgramLineName
	{
		public string program { get; set; }
		public string LineName { get; set; }
	}
	public class EASTECH_PROGRAMHISTORY_DAL
	{
		UVEntities _entities = new UVEntities();
		private static EASTECH_PROGRAMHISTORY_DAL instance;
		public static EASTECH_PROGRAMHISTORY_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new EASTECH_PROGRAMHISTORY_DAL();
				return instance;
			}
		}
		public EASTECH_PROGRAMHISTORY_DAL() { }

		#region Xóa dữ liệu cắt lot không dùng
		public string DeleteCutLotDataNotUse(List<long> IdList)
		{			
			string message = "";
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					foreach (var item in IdList)
					{
						var removeRecord = _entities.EASTECH_PROGRAMHISTORY.Where(p => p.Id == item).FirstOrDefault();
						if (removeRecord != null)
						{
							_entities.EASTECH_PROGRAMHISTORY.Remove(removeRecord);
						}
					}
					_entities.SaveChanges();
					// If everything is successful, commit the transaction
					dbContextTransaction.Commit();
					message = "";
				}
				catch (Exception ex)
				{
					// If an exception occurs, roll back the transaction
					dbContextTransaction.Rollback();
					message = ex.Message;
				}
			}
			return message;
		}
		#endregion

		#region Lấy dữ liệu cắt lot
		public DataTable getCutLotData(string programName, string lineName)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechHistory_GetCutLotData";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@programkey", programName));
				command.Parameters.Add(new SqlParameter("@NewLine", lineName));

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


		#region Thực hiện thêm danh sách dữ liệu vào 2 bảng 
		public string InsertRangeETHistoryVsProgramHistory(List<PROGRAMHISTORY> lstpHistory, List<EASTECH_PROGRAMHISTORY> lstetHistory)
		{
			string message = "";
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					// Save ET History
					_entities.EASTECH_PROGRAMHISTORY.AddRange(lstetHistory);
					_entities.SaveChanges();


					// Save Program History
					_entities.PROGRAMHISTORies.AddRange(lstpHistory);
					_entities.SaveChanges(); // Save changes for the updates

					// If everything is successful, commit the transaction
					dbContextTransaction.Commit();
					message = "";
				}
				catch (Exception ex)
				{
					// If an exception occurs, roll back the transaction
					dbContextTransaction.Rollback();
					message = ex.Message;
				}
			}
			return message;
		}

		#endregion
		#region Thực hiện thêm dữ liệu vào 2 bảng 
		public string InsertETHistoryVsProgramHistory(PROGRAMHISTORY pHistory, EASTECH_PROGRAMHISTORY etHistory)
		{
			string message = "";
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					// Save ET History
					_entities.EASTECH_PROGRAMHISTORY.Add(etHistory);
					_entities.SaveChanges();


					// Save Program History
					_entities.PROGRAMHISTORies.Add(pHistory);
					_entities.SaveChanges(); // Save changes for the updates

					// If everything is successful, commit the transaction
					dbContextTransaction.Commit();
					message = "";
				}
				catch (Exception ex)
				{
					// If an exception occurs, roll back the transaction
					dbContextTransaction.Rollback();
					message = ex.Message;
				}
			}
			return message;
		}

		#endregion

		#region Thực hiện Thêm dữ liệu mới vào history và cập nhật lại dữ liệu theo ID với lot không scan QR code
		public string InsertUpdateRange(List<EASTECH_PROGRAMHISTORY> lists)
		{
			string message = "";
			var idKeep = new List<long>(); // List to store original Id values
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					foreach (var itemId in lists)
					{
						idKeep.Add(itemId.Id);
					}

					_entities.EASTECH_PROGRAMHISTORY.AddRange(lists);
					_entities.SaveChanges();

					// Update the second table based on Id values
					foreach (var orgId in idKeep)
					{
						var recordToUpdate = _entities.EASTECH_PROGRAMHISTORY.Where(e => e.Id == orgId).FirstOrDefault();
						if (recordToUpdate != null)
						{
							recordToUpdate.reqqty = 0;
							recordToUpdate.SoPCBCothedung = 0;
						}
					}
					_entities.SaveChanges(); // Save changes for the updates

					// If everything is successful, commit the transaction
					dbContextTransaction.Commit();
					message = "";
				}
				catch (Exception ex)
				{
					// If an exception occurs, roll back the transaction
					dbContextTransaction.Rollback();
					message = ex.Message;
				}
			}

			return message;
		}
		#endregion

		#region Thực hiện Thêm dữ liệu mới vào history và cập nhật lại dữ liệu theo ID với lot scan QR code
		public string InsertUpdateRangeQR(List<EASTECH_PROGRAMHISTORY> lists)
		{
			var idKeep = new List<long>(); // List to store original Id values
			string message = "";
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					foreach (var itemId in lists)
					{
						idKeep.Add(itemId.Id);
					}
					_entities.EASTECH_PROGRAMHISTORY.AddRange(lists);
					_entities.SaveChanges();

					// Update the second table based on Id values
					foreach (var item in idKeep)
					{
						var recordToUpdate = _entities.EASTECH_PROGRAMHISTORY.Where(e => e.Id == item).FirstOrDefault();
						if (recordToUpdate != null)
						{
							if (recordToUpdate.counts == null)
							{
								recordToUpdate.SoPCBCothedung = 0;
								recordToUpdate.reqqty = 0;
							}
							else
							{
								recordToUpdate.SoPCBCothedung = (int)recordToUpdate.counts;
								recordToUpdate.reqqty = (int)recordToUpdate.counts * (int)recordToUpdate.usage;
							}
						}
					}
					_entities.SaveChanges(); // Save changes for the updates

					// If everything is successful, commit the transaction
					dbContextTransaction.Commit();
					message = "";
				}
				catch (Exception ex)
				{
					// If an exception occurs, roll back the transaction
					dbContextTransaction.Rollback();
					message = ex.Message;
				}
			}
			return message;
		}
		#endregion

		public EASTECH_PROGRAMHISTORY getMaxSolanthaylinhkien(string program, string feeder, string lineName)
		{
			return _entities.EASTECH_PROGRAMHISTORY
					.Where(e => e.programpartlist == program && e.fdrno == feeder && e.remark1 == lineName)
					.OrderByDescending(e => e.Solanthaylinhkien)
					.FirstOrDefault();
		}
		public string Add(EASTECH_PROGRAMHISTORY eastechProgramHistory)
		{
			string message = "";
			try
			{
				_entities.EASTECH_PROGRAMHISTORY.Add(eastechProgramHistory);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message=ex.Message;
			}
			return message;
		}
		#region Lấy danh sách line đang dùng cho chương trình
		public List<ProgramLineName> GetProgramLineName(string programpartlist)
		{
			return _entities.EASTECH_PROGRAMHISTORY
				.Where(e => e.programpartlist == programpartlist)
				.GroupBy(e => new { e.programpartlist, e.remark1 })
				.Select(g => new ProgramLineName
				{
					program = g.Key.programpartlist,
					LineName = g.Key.remark1
				})
				.ToList();

		}
		#endregion

		public DataTable getMaxOfSolanthaylinhkien(string psubkey)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechHistory_CheckSubKeyNumber";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@psubkey", psubkey));
				
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
		#region Lấy số lần thay linh kiện cuối cùng
		public EASTECH_PROGRAMHISTORY getMaxSoLanThayLinhKien(string subkey)
		{
			return _entities.EASTECH_PROGRAMHISTORY.Where(p=>p.psubkey == subkey).OrderByDescending(p=>p.Solanthaylinhkien).FirstOrDefault();
		}
		#endregion

		#region Chuyển line của SMT. Kiểm tra: Chương trình + line có dữ liệu không?
		public List<EASTECH_PROGRAMHISTORY> checkMeterialByProgramAndLineName(string program, string lineName)
		{
			// Hàm này với hàm getListRecordByProgramAndLineName giống nhau nhưng chạy trên 2 môi trường khác nhau
			// 1 chạy qua entity framework 
			// 1 chạy bằng sql proceduce
			return _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == program &&
														   p.remark1 == lineName &&
														   (p.SoPCBCothedung - p.counts) > 0
														  ).ToList();
		}
		#endregion

		public int EastechHOutistory_CountQRCodeByUser(string pgkey1, string pgkey2, string Remark)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechOutputHistory_Count2";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@programkey1", pgkey1));
				command.Parameters.Add(new SqlParameter("@programkey2", pgkey2));
				command.Parameters.Add(new SqlParameter("@Remark", Remark));
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

		#region Chuyển line của SMT. Kiểm tra: Chương trình + line có dữ liệu không?
		public DataTable getListRecordByProgramAndLineName(string program, string lineName)
		{
			var dt = new DataTable();

			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechHistory_CheckProgKeyLineName";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@programpartlist", program));
				command.Parameters.Add(new SqlParameter("@remark1", lineName));
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

		#region Kiểm tra xem chương trình và Line đó có được bắn QR code hay không? Nếu bắn QR code thì count >0 và ngược lại
		public EASTECH_PROGRAMHISTORY checkLineScanQRorNotScanQRCode(string program, string lineName)
		{
			return _entities.EASTECH_PROGRAMHISTORY.Where(p => p.programpartlist == program && p.remark1 == lineName && p.counts > 0).FirstOrDefault();
		}
		#endregion

		#region Gộp hàm lấy linh kiện của chương trình cần chuyển sang line mới.
		public DataTable getListRecordNeedTransferToNewLine(int Option, string NewProgram, string OldProgram, string OldLineName)
		{
			var dt = new DataTable();
			if (Option == 1)
			{
				using (var command = _entities.Database.Connection.CreateCommand())
				{
					command.CommandText = "sp_EastechHistory_CombineProgramNonQRCode";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("@New_programpartlist", NewProgram));
					command.Parameters.Add(new SqlParameter("@Old_programpartlist", OldProgram));
					command.Parameters.Add(new SqlParameter("@Old_Line", OldLineName));

					if (command.Connection.State != ConnectionState.Open)
					{
						command.Connection.Open();
					}
					using (var reader = command.ExecuteReader())
					{
						dt.Load(reader);
					}
				}
			}
			else
			{

				using (var command = _entities.Database.Connection.CreateCommand())
				{
					command.CommandText = "sp_EastechHistory_CombineProgramQRCode";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("@New_programpartlist", NewProgram));
					command.Parameters.Add(new SqlParameter("@Old_programpartlist", OldProgram));
					command.Parameters.Add(new SqlParameter("@Old_Line", OldLineName));

					if (command.Connection.State != ConnectionState.Open)
					{
						command.Connection.Open();
					}
					using (var reader = command.ExecuteReader())
					{
						dt.Load(reader);
					}
				}
			}
			return dt;
		}

		#endregion


		#region Lấy danh sách linh kiện để trừ khi bắn QR code
		public DataTable getListMeterialAvailable(string program, string lineName)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechOutputHistory_SelectCheckByProkey";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@programpartlist", program));
				command.Parameters.Add(new SqlParameter("@Remark1", lineName));
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


		#region Lấy dữ liệu Còn thiếu khi công nhân bắn trên line
		public DataTable checkMissingListParts(string programName, string lineName)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechHistory_CheckProgKeyLineName_Checker_Mistake";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@programpartlist", programName));
				command.Parameters.Add(new SqlParameter("@remark1", lineName));

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

		#region Lấy dữ liệu hiện có của chương trình đã được thay linh kiện
		public DataTable getCurrentListParts(string programName, string lineName)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_EastechHistory_CheckProgKeyLineName_Checker";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@programpartlist", programName));
				command.Parameters.Add(new SqlParameter("@remark1", lineName));

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
