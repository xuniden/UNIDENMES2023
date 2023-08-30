using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Assy.Setup
{
	public class LINECAUSEDEPT_DAL
	{
		UVEntities _entities = new UVEntities();
		private static LINECAUSEDEPT_DAL instance;
		public static LINECAUSEDEPT_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new LINECAUSEDEPT_DAL();
				return instance;
			}
		}
		public LINECAUSEDEPT_DAL() { }


		public string Update(UV_LINECAUSEDEPT causeDept)
		{
			string message = "";
			var causeDepts = _entities.UV_LINECAUSEDEPT.Where(p => p.DeptCode == causeDept.DeptCode).FirstOrDefault();
			try
			{
				causeDepts.DeptCode = causeDept.DeptCode;
				causeDepts.UpdatedBy = causeDept.UpdatedBy;
				causeDepts.UpdatedDate = causeDept.UpdatedDate;
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Add(UV_LINECAUSEDEPT causeDept)
		{
			string message = "";
			try
			{
				_entities.UV_LINECAUSEDEPT.Add(causeDept);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public UV_LINECAUSEDEPT checkExistsCauseDept(string causeDept)
		{
			return _entities.UV_LINECAUSEDEPT.Where(p => p.DeptCode == causeDept).FirstOrDefault();
		}


		public List<UV_LINECAUSEDEPT> getListCauseDept()
		{
			return _entities.UV_LINECAUSEDEPT.OrderByDescending(p=>p.CreatedDate).ToList();			
		}


		public List<UV_LINECAUSEDEPT> searchData(string search)
		{
			var lstResult = new List<UV_LINECAUSEDEPT>();
			lstResult = _entities.UV_LINECAUSEDEPT.Where(p => p.DeptCode.Contains(search) ).ToList();
			return lstResult;
		}

		public string Delete(string deptCode)
		{
			string message = "";
			try
			{
				var causeDept=_entities.UV_LINECAUSEDEPT.Where(p => p.DeptCode==deptCode).FirstOrDefault();
				_entities.UV_LINECAUSEDEPT.Remove(causeDept);
				_entities.SaveChanges();
				message = "";
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}
	}
}
