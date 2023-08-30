using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{
	public class groupCauseCode
	{
		public string CauseCode { get; set; }
		public string CauseDesc { get; set; }
	}
	public class CAUSECODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static CAUSECODE_DAL instance;
		public static CAUSECODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new CAUSECODE_DAL();
				return instance;
			}
		}
		public CAUSECODE_DAL() { }


		public string Add(UVASSY_CAUSECODE cAUSECODE)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_CAUSECODE.Add(cAUSECODE);
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
				var remove = _entities.UVASSY_CAUSECODE.Where(p => p.ID == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_CAUSECODE.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}
		public string Update(UVASSY_CAUSECODE causeCode)
		{
			string message = string.Empty;
			try
			{
				var update = _entities.UVASSY_CAUSECODE.Where(p => p.ID == causeCode.ID).FirstOrDefault();
				if (update != null)
				{
					update.UpdatedDate = causeCode.UpdatedDate;
					update.UpdatedBy = causeCode.UpdatedBy;
					update.Cause_Desc = causeCode.Cause_Desc;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message += ex.Message;
			}
			return message;
		}
		public string AddUpdateRange(List<UVASSY_CAUSECODE> lstAdd, List<UVASSY_CAUSECODE> lstUpdate)
		{
			string message = string.Empty;
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					_entities.UVASSY_CAUSECODE.AddRange(lstAdd);
					_entities.SaveChanges();

					foreach (var item in lstUpdate)
					{
						var upRecord = _entities.UVASSY_CAUSECODE.Where(p => p.ID == item.ID).FirstOrDefault();
						if (upRecord != null)
						{
							upRecord.UpdatedDate = item.UpdatedDate;
							upRecord.UpdatedBy = item.UpdatedBy;
							upRecord.Cause_Desc = item.Cause_Desc;
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

		public string AddRange(List<UVASSY_CAUSECODE> cAUSECODEs)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_CAUSECODE.AddRange(cAUSECODEs);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}
		public List<UVASSY_CAUSECODE> getAllInfo()
		{
			return _entities.UVASSY_CAUSECODE.ToList();
		}
		public UVASSY_CAUSECODE checkExistEfectCode(string causeCode)
		{
			return _entities.UVASSY_CAUSECODE.Where(p => p.Cause_Code == causeCode).FirstOrDefault();
		}

		public List<UVASSY_CAUSECODE> searchAllInfo(string search)
		{
			return _entities.UVASSY_CAUSECODE.Where(p => p.Cause_Code.Contains(search) || p.Cause_Desc.Contains(search)).ToList();
		}

		public List<groupCauseCode> getCauseCodeForCombobox()
		{
			try
			{
				var selectionCauseCode = new groupCauseCode { CauseCode = "--Select--", CauseDesc = "-Select--" };
				var result = _entities.UVASSY_CAUSECODE
					.GroupBy(e => new { e.Cause_Code, e.Cause_Desc })
					.Select(g => new groupCauseCode
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
				return new List<groupCauseCode>();
			}

		}
	}
}
