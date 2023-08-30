using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Assy.Setup
{
	public class LINEERRORCODE_DAL
	{

		UVEntities _entities = new UVEntities();
		private static LINEERRORCODE_DAL instance;
		public static LINEERRORCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new LINEERRORCODE_DAL();
				return instance;
			}
		}
		public LINEERRORCODE_DAL() { }
		public string AddRange(List<UV_LINEERRORCODE> lstErrorCode)
		{
			string message = "";
			try
			{
				_entities.UV_LINEERRORCODE.AddRange(lstErrorCode);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Update(UV_LINEERRORCODE lineERRORCODE)
		{
			string message = "";
			var errorCode=_entities.UV_LINEERRORCODE.Where(p=>p.ErrorCode==lineERRORCODE.ErrorCode).FirstOrDefault();
			try
			{
				errorCode.ErrorVNDescription= lineERRORCODE.ErrorVNDescription;
				errorCode.ErrorENDescription= lineERRORCODE.ErrorENDescription;
				errorCode.IsDelete= lineERRORCODE.IsDelete;
				errorCode.UpdatedBy= lineERRORCODE.UpdatedBy;
				errorCode.UpdatedDate = lineERRORCODE.UpdatedDate;
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Add(UV_LINEERRORCODE lineERRORCODE)
		{
			string message = "";
			try
			{
				_entities.UV_LINEERRORCODE.Add(lineERRORCODE);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public UV_LINEERRORCODE checkExistsErrorCode(string errorCode)
		{
			return _entities.UV_LINEERRORCODE.Where(p=>p.ErrorCode==errorCode).FirstOrDefault();
		}
		public List<UV_LINEERRORCODE> searchData(string search)
		{
			var lstResult= new List<UV_LINEERRORCODE>();
			lstResult=_entities.UV_LINEERRORCODE.Where(p=>p.ErrorCode.Contains(search) ||
			p.ErrorVNDescription.Contains(search)||
			p.ErrorENDescription.Contains(search)).ToList();
			return lstResult;
		}
		public List<UV_LINEERRORCODE> getListErrorCode()
		{
			return _entities.UV_LINEERRORCODE.OrderByDescending(p => p.CreatedDate).ToList();
		}

		public string Delete(UV_LINEERRORCODE errorCode)
		{
			string message = "";
			var lineErrorCode= new UV_LINEERRORCODE();
			lineErrorCode=_entities.UV_LINEERRORCODE.Where(p=>p.ErrorCode==errorCode.ErrorCode).FirstOrDefault();
			try
			{
				if (lineErrorCode != null)
				{
					lineErrorCode.IsDelete = errorCode.IsDelete;
					lineErrorCode.UpdatedDate = errorCode.UpdatedDate;
					lineErrorCode.UpdatedBy = errorCode.UpdatedBy;
					_entities.SaveChanges();
					message = "";
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			
			return message;
		}
	}
}
