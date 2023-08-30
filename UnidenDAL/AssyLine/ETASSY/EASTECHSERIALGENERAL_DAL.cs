using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.ETASSY
{
	public class groupModel
	{
		public string Model { get; set; }
	}
	public class EASTECHSERIALGENERAL_DAL
	{
		UVEntities _entities = new UVEntities();
		private static EASTECHSERIALGENERAL_DAL instance;
		public static EASTECHSERIALGENERAL_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new EASTECHSERIALGENERAL_DAL();
				return instance;
			}
		}

		public EASTECHSERIALGENERAL_DAL() { }

		public List<groupModel> listModel()
		{
			var selectOption = new groupModel { Model = "--Select--" };
			var result = _entities.UVASSY_EASTECHSERIALGENERAL
				.GroupBy(e => new { e.Model })
				.Select(g => new groupModel
				{
					Model = g.Key.Model
				})
				.ToList();
			result.Insert(0, selectOption);
			result = result.OrderBy(e => e.Model).ToList();
			return result;
		}

		public string AddRange(List<UVASSY_EASTECHSERIALGENERAL> lstAddLists)
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_EASTECHSERIALGENERAL.AddRange(lstAddLists);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;			
		}
		public DataTable uvassyCheckExistsQRCode(StringBuilder sbQRcode)
		{
			var dt = new System.Data.DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_uvassy_CheckExistsQRCode";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@qrcodeList", sbQRcode.ToString()));
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

		public UVASSY_EASTECHSERIALGENERAL checkSerialvsModel(string serial, string model)
		{
			return _entities.UVASSY_EASTECHSERIALGENERAL
				.Where(p=>p.Serial_Number == serial && p.Model==model)
				.FirstOrDefault();
		}
	}
}
