using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Assy.Setup
{
	public class LINECAUSECODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static LINECAUSECODE_DAL instance;
		public static LINECAUSECODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new LINECAUSECODE_DAL();
				return instance;
			}
		}
		public LINECAUSECODE_DAL() { }


		public List<UV_LINECAUSECODE> getListCauseCode()
		{
			return _entities.UV_LINECAUSECODE.OrderByDescending(p => p.CreatedDate).ToList();
		}

		public string Update(UV_LINECAUSECODE causeCode)
		{
			string message = "";
			var causeCodes = _entities.UV_LINECAUSECODE.Where(p => p.CauseCode == causeCode.CauseCode).FirstOrDefault();
			try
			{
				causeCodes.CauseCode = causeCode.CauseCode;
				causeCodes.UpdatedBy = causeCode.UpdatedBy;
				causeCodes.UpdatedDate = causeCode.UpdatedDate;
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Add(UV_LINECAUSECODE causeCode)
		{
			string message = "";
			try
			{
				_entities.UV_LINECAUSECODE.Add(causeCode);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public UV_LINECAUSECODE checkExistsCauseCode(string causeCode)
		{
			return _entities.UV_LINECAUSECODE.Where(p => p.CauseCode == causeCode).FirstOrDefault();
		}

		public string Delete(string Code)
		{
			string message = "";
			try
			{
				var causeCode = _entities.UV_LINECAUSECODE.Where(p => p.CauseCode == Code).FirstOrDefault();
				_entities.UV_LINECAUSECODE.Remove(causeCode);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
		public List<UV_LINECAUSECODE> searchData(string search)
		{
			var lstResult = new List<UV_LINECAUSECODE>();
			lstResult = _entities.UV_LINECAUSECODE.Where(p => p.CauseCode.Contains(search)).ToList();
			return lstResult;
		}
	}
}
