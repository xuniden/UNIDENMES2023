using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{
	public class groupCauseCodeRepair
	{
		public string CauseCode { get; set; }
		public string CauseDesc { get; set; }
	}
	public class CAUSECODEREPAIR_DAL
	{
		UVEntities _entities = new UVEntities();
		private static CAUSECODEREPAIR_DAL instance;
		public static CAUSECODEREPAIR_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new CAUSECODEREPAIR_DAL();
				return instance;
			}
		}
		public CAUSECODEREPAIR_DAL() { }


		public string Add(UVASSY_CAUSECODEREPAIR cAUSECODE)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_CAUSECODEREPAIR.Add(cAUSECODE);
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
				var remove = _entities.UVASSY_CAUSECODEREPAIR.Where(p => p.ID == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_CAUSECODEREPAIR.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}
			

		public string AddRange(List<UVASSY_CAUSECODEREPAIR> cAUSECODEs)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_CAUSECODEREPAIR.AddRange(cAUSECODEs);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}
		public List<UVASSY_CAUSECODEREPAIR> getAllInfo()
		{
			return _entities.UVASSY_CAUSECODEREPAIR.ToList();
		}
		public UVASSY_CAUSECODEREPAIR checkExistEfectCode(string causeCode)
		{
			return _entities.UVASSY_CAUSECODEREPAIR.Where(p => p.Cause_Code == causeCode).FirstOrDefault();
		}

		public List<UVASSY_CAUSECODEREPAIR> searchAllInfo(string search)
		{
			return _entities.UVASSY_CAUSECODEREPAIR.Where(p => p.Cause_Code.Contains(search) || p.Cause_Desc.Contains(search)).ToList();
		}

		public List<groupCauseCodeRepair> getCauseCodeForCombobox()
		{
			try
			{
				var selectionCauseCode = new groupCauseCodeRepair { CauseCode = "--Select--", CauseDesc = "-Select--" };
				var result = _entities.UVASSY_CAUSECODEREPAIR
					.GroupBy(e => new { e.Cause_Code, e.Cause_Desc })
					.Select(g => new groupCauseCodeRepair
					{
						CauseCode = g.Key.Cause_Code,
						CauseDesc = g.Key.Cause_Desc
					})
					.ToList();
				result.Insert(0, selectionCauseCode);
				var sortedResult = result.OrderBy(e => e.CauseCode).ToList();
				return sortedResult;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
				return new List<groupCauseCodeRepair>();
			}

		}
	}
}
