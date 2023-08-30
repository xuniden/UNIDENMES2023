using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{
	public class groupReasonCode
	{
		public string Reason_Code { get; set; }
		public string Reason_Desc { get; set; }
	}

	public class REASONCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static REASONCODE_DAL instance;
		public static REASONCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new REASONCODE_DAL();
				return instance;
			}
		}
		public REASONCODE_DAL() { }

		public string Add(UVASSY_REASONCODE rEASONCODE)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_REASONCODE.Add(rEASONCODE);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public string AddRange(List<UVASSY_REASONCODE> lstREASONCODE)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_REASONCODE.AddRange(lstREASONCODE);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}
		public string AddUpdateRange(List<UVASSY_REASONCODE> lstAdd, List<UVASSY_REASONCODE> lstUpdate)
		{
			string message = string.Empty;
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					_entities.UVASSY_REASONCODE.AddRange(lstAdd);
					_entities.SaveChanges();

					foreach (var item in lstUpdate)
					{
						var upRecord = _entities.UVASSY_REASONCODE.Where(p => p.ID == item.ID).FirstOrDefault();
						if (upRecord != null)
						{
							upRecord.UpdatedDate = item.UpdatedDate;
							upRecord.UpdatedBy = item.UpdatedBy;
							upRecord.Reason_Desc = item.Reason_Desc;
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

		public string Update(UVASSY_REASONCODE reasonCode)
		{
			string message = string.Empty;
			try
			{
				var update = _entities.UVASSY_REASONCODE.Where(p => p.ID == reasonCode.ID).FirstOrDefault();
				if (update != null)
				{
					update.UpdatedDate = reasonCode.UpdatedDate;
					update.UpdatedBy = reasonCode.UpdatedBy;
					update.Reason_Desc = reasonCode.Reason_Desc;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message += ex.Message;
			}
			return message;
		}

		public string Remove(int Id)
		{
			string messsage = string.Empty;
			try
			{
				var remove = _entities.UVASSY_REASONCODE.Where(p => p.ID == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_REASONCODE.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}


		public List<UVASSY_REASONCODE> getAllInfo()
		{
			return _entities.UVASSY_REASONCODE.ToList();
		}
		public UVASSY_REASONCODE checkExistEfectCode(string reasonCode)
		{
			return _entities.UVASSY_REASONCODE.Where(p => p.Reason_Code == reasonCode).FirstOrDefault();
		}

		public List<UVASSY_REASONCODE> searchAllInfo(string search)
		{
			return _entities.UVASSY_REASONCODE.Where(p => p.Reason_Code.Contains(search) || p.Reason_Desc.Contains(search)).ToList();
		}

		public List<groupReasonCode> getReasonCodeForCombobox()
		{
			try
			{
				var selectionReasonCode = new groupReasonCode { Reason_Code = "--Select--", Reason_Desc = "-Select--" };
				var result = _entities.UVASSY_REASONCODE
					.GroupBy(e => new { e.Reason_Code, e.Reason_Desc })
					.Select(g => new groupReasonCode
					{
						Reason_Code = g.Key.Reason_Code,
						Reason_Desc = g.Key.Reason_Desc
					})
					.ToList();
				result.Insert(0, selectionReasonCode);
				var sortedResult = result.OrderBy(e => e.Reason_Code).ToList();
				return sortedResult;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
				return new List<groupReasonCode>();
			}

		}
	}
}
