using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{
	public class REPAIRGENERALCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static REPAIRGENERALCODE_DAL instance;
		public static REPAIRGENERALCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new REPAIRGENERALCODE_DAL();
				return instance;
			}
		}
		public REPAIRGENERALCODE_DAL() { }


		public string Add(UVASSY_REPAIRGENERALCODE repairCode)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_REPAIRGENERALCODE.Add(repairCode);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}
		public string Remove(int Id)
		{
			string messsage = string.Empty;
			try
			{
				var remove = _entities.UVASSY_REPAIRGENERALCODE.Where(p => p.ID == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_REPAIRGENERALCODE.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}
		
		public string AddRange(List<UVASSY_REPAIRGENERALCODE> lstAdd)
		{
			string message = string.Empty;			
			try
			{
				_entities.UVASSY_REPAIRGENERALCODE.AddRange(lstAdd);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{				
				message = ex.Message;
			}			
			return message;
		}

		
		public List<UVASSY_REPAIRGENERALCODE> getAllInfo()
		{
			return _entities.UVASSY_REPAIRGENERALCODE.ToList();
		}
		public UVASSY_REPAIRGENERALCODE checkExistRepairCode(string repairCode)
		{
			return _entities.UVASSY_REPAIRGENERALCODE.Where(p => p.RepairCode == repairCode).FirstOrDefault();
		}

		public DataTable CheckRepairCodeList(string repairCode)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = @"SELECT RepairCode FROM  UVASSY_REPAIRGENERALCODE WHERE RepairCode In(" + repairCode;
				command.CommandType = CommandType.Text;				

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

		public List<UVASSY_REPAIRGENERALCODE> searchAllInfo(string search)
		{
			return _entities.UVASSY_REPAIRGENERALCODE.Where(p => p.RepairCode.Contains(search) ).ToList();
		}
	}
}
