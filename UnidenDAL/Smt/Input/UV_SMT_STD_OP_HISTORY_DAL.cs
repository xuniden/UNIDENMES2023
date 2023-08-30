using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Smt.Output;
using UnidenDTO;

namespace UnidenDAL.Smt.Input
{
	public class UV_SMT_STD_OP_HISTORY_DAL
	{
		UVEntities _entities = new UVEntities();
		private static UV_SMT_STD_OP_HISTORY_DAL instance;
		public static UV_SMT_STD_OP_HISTORY_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new UV_SMT_STD_OP_HISTORY_DAL();
				return instance;
			}
		}
		public UV_SMT_STD_OP_HISTORY_DAL() { }

		public string Add(UV_SMT_STD_OP_HISTORY uvSmtStdOpHistory)
		{
			string message = "";
			try
			{
				_entities.UV_SMT_STD_OP_HISTORY.Add(uvSmtStdOpHistory);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public string Update(UV_SMT_STD_OP_HISTORY uvSmtStdOpHistory)
		{
			string message = "";
			var uData = new UV_SMT_STD_OP_HISTORY();
			uData=_entities.UV_SMT_STD_OP_HISTORY.Where(p=>p.Id==uvSmtStdOpHistory.Id).FirstOrDefault();
			if (uData!=null)
			{
				try
				{
					uData.ipqcCheckedDesc = uvSmtStdOpHistory.ipqcCheckedDesc;
					uData.ipqcCheckedDate = uvSmtStdOpHistory.ipqcCheckedDate; 
					uData.ipqcCheckedQty = uvSmtStdOpHistory.ipqcCheckedQty;
					uData.ipqcCheckedBy = uvSmtStdOpHistory.ipqcCheckedBy;
					uData.ipqcCheckedDateCode = uvSmtStdOpHistory.ipqcCheckedDateCode;
					uData.ipqcCheckPartcode = uvSmtStdOpHistory.ipqcCheckPartcode;
					uData.resultFinal = uvSmtStdOpHistory.resultFinal;
					uData.ipqcCheckedStatus = uvSmtStdOpHistory.ipqcCheckedStatus;

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
				message = "Không tìm thấy dữ liệu để update";
			}
			
			

			return message;
		}
		public List<UV_SMT_STD_OP_HISTORY> getListByChangeUser(string program, string user)
		{
			return _entities.UV_SMT_STD_OP_HISTORY.Where(p=>p.programpartlist==program&& p.changedby==user).OrderByDescending(p=>p.changedtime).ToList();
		}

		public DataTable IPQCCheckResult(string line, string program, string feeder)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_smt_IPQCCheckResult";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@linename", line));
				command.Parameters.Add(new SqlParameter("@programpartlist", program));
				command.Parameters.Add(new SqlParameter("@fdrno", feeder));
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

		public DataTable IPQCCheckResultAfterChecked(string line, string program, string ipqcCheckBy)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_smt_IPQCCheckResultAfterChecked";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@linename", line));
				command.Parameters.Add(new SqlParameter("@programpartlist", program));
				command.Parameters.Add(new SqlParameter("@ipqcCheck", ipqcCheckBy));
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
		//sp_smt_OperatorCheck
		public DataTable OperatorCheck(string line, string program, string userid)
		{
			var dt = new DataTable();
			using (var command = _entities.Database.Connection.CreateCommand())
			{
				command.CommandText = "sp_smt_OperatorCheck";
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@linename", line));
				command.Parameters.Add(new SqlParameter("@programpartlist", program));
				command.Parameters.Add(new SqlParameter("@userid", userid));
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

		//public List<UV_SMT_STD_OP_HISTORY> getlistToCheckIPQC(string line,string program, string feeder)
		//{	
		//	return	_entities.UV_SMT_STD_OP_HISTORY.Where(p => p.linename==line&& p.programpartlist == program && p.fdrno==feeder).OrderBy(p => p.fdrno).ToList();			
		//}

		public UV_SMT_STD_OP_HISTORY getInfoById(long Id)
		{
			return _entities.UV_SMT_STD_OP_HISTORY.Where(p=>p.Id==Id).FirstOrDefault();
		}
	}
}
