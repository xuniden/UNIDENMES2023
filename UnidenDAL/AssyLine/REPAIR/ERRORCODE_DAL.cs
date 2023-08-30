using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{
	public class groupErrorCode
	{
		public string ErrorCode { get; set; }
		public string ErrorDesc { get; set; }
	}
	public class ERRORCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static ERRORCODE_DAL instance;
		public static ERRORCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new ERRORCODE_DAL();
				return instance;
			}
		}
		public ERRORCODE_DAL() { }


		public string Add(UVASSY_ERRORCODE errorCode)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_ERRORCODE.Add(errorCode);
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
				var remove = _entities.UVASSY_ERRORCODE.Where(p => p.ID == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_ERRORCODE.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}
		public string Update(UVASSY_ERRORCODE errorCode)
		{
			string message = string.Empty;
			try
			{
				var update = _entities.UVASSY_ERRORCODE.Where(p => p.ID == errorCode.ID).FirstOrDefault();
				if (update != null)
				{
					update.UpdatedDate = errorCode.UpdatedDate;
					update.UpdatedBy = errorCode.UpdatedBy;
					update.ErrorDesc = errorCode.ErrorDesc;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message += ex.Message;
			}
			return message;
		}
		public string AddUpdateRange(List<UVASSY_ERRORCODE> lstAdd, List<UVASSY_ERRORCODE> lstUpdate)
		{
			string message = string.Empty;
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					_entities.UVASSY_ERRORCODE.AddRange(lstAdd);
					_entities.SaveChanges();

					foreach (var item in lstUpdate)
					{
						var upRecord = _entities.UVASSY_ERRORCODE.Where(p => p.ID == item.ID).FirstOrDefault();
						if (upRecord != null)
						{
							upRecord.UpdatedDate = item.UpdatedDate;
							upRecord.UpdatedBy = item.UpdatedBy;
							upRecord.ErrorDesc = item.ErrorDesc;
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

		public string AddRange(List<UVASSY_ERRORCODE> errorCodes)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_ERRORCODE.AddRange(errorCodes);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}
		public List<UVASSY_ERRORCODE> getAllInfo()
		{
			return _entities.UVASSY_ERRORCODE.ToList();
		}
		public UVASSY_ERRORCODE checkExistEfectCode(string errorCode)
		{
			return _entities.UVASSY_ERRORCODE.Where(p => p.ErrorCode == errorCode).FirstOrDefault();
		}

		public List<UVASSY_ERRORCODE> searchAllInfo(string search)
		{
			return _entities.UVASSY_ERRORCODE.Where(p => p.ErrorCode.Contains(search) || p.ErrorDesc.Contains(search)).ToList();
		}

		public List<groupErrorCode> getErrorCodeForCombobox()
		{
			try
			{
				var selectionErrorCode = new groupErrorCode { ErrorCode = "--Select--", ErrorDesc = "-Select--" };
				var result = _entities.UVASSY_ERRORCODE
					.GroupBy(e => new { e.ErrorCode, e.ErrorDesc })
					.Select(g => new groupErrorCode
					{
						ErrorCode = g.Key.ErrorCode,
						ErrorDesc = g.Key.ErrorDesc
					})
					.ToList();
				result.Insert(0, selectionErrorCode);
				var sortedResult = result.OrderBy(e => e.ErrorCode).ToList();
				return sortedResult;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
				return new List<groupErrorCode>();
			}
			
		}
	}
}
