using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{
	public class groupDefectCode
	{
		public string DefectCode { get; set; }
		
	}

	public class DEFECTCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static DEFECTCODE_DAL instance;
		public static DEFECTCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new DEFECTCODE_DAL();
				return instance;
			}
		}
		public DEFECTCODE_DAL() { }
		public List<groupDefectCode> listDefectCode()
		{
			try
			{
				var selectOption = new groupDefectCode { DefectCode = "[--Select--]"};
				var result = _entities.UVASSY_DEFECTCODE
					.GroupBy(e => new { e.Defect_Code })
					.Select(g => new groupDefectCode
					{
						DefectCode = g.Key.Defect_Code						
					})
					.ToList();
				result.Insert(0, selectOption);
				var re = result.OrderBy(e => e.DefectCode).ToList();
				return re;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
				return new List<groupDefectCode>();
			}

		}

		public string Add(UVASSY_DEFECTCODE dEFECTCODE)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_DEFECTCODE.Add(dEFECTCODE);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public string AddRange(List<UVASSY_DEFECTCODE> lstDEFECTCODE)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_DEFECTCODE.AddRange(lstDEFECTCODE);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public string AddUpdateRange(List<UVASSY_DEFECTCODE> lstAdd, List<UVASSY_DEFECTCODE> lstUpdate)
		{
			string message = string.Empty;
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					_entities.UVASSY_DEFECTCODE.AddRange(lstAdd);
					_entities.SaveChanges();

					foreach (var item in lstUpdate)
					{
						var upRecord = _entities.UVASSY_DEFECTCODE.Where(p => p.ID == item.ID).FirstOrDefault();
						if (upRecord != null)
						{
							upRecord.UpdatedDate = item.UpdatedDate;
							upRecord.UpdatedBy = item.UpdatedBy;
							upRecord.Defect_Desc = item.Defect_Desc;
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

		public string Update(UVASSY_DEFECTCODE uvEffect)
		{
			string message = string.Empty;
			try
			{
				var update = _entities.UVASSY_DEFECTCODE.Where(p => p.ID == uvEffect.ID).FirstOrDefault();
				if (update != null)
				{
					update.UpdatedDate = uvEffect.UpdatedDate;
					update.UpdatedBy = uvEffect.UpdatedBy;
					update.Defect_Desc = uvEffect.Defect_Desc;
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
			string messsage= string.Empty;
			try
			{
				var remove = _entities.UVASSY_DEFECTCODE.Where(p => p.ID == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_DEFECTCODE.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}

		public List<UVASSY_DEFECTCODE> getAllInfo()
		{
			return _entities.UVASSY_DEFECTCODE.ToList();
		}

		public UVASSY_DEFECTCODE checkExistEfectCode(string effectCode)
		{
			return _entities.UVASSY_DEFECTCODE.Where(p=>p.Defect_Code==effectCode).FirstOrDefault();
		}

		public List<UVASSY_DEFECTCODE> searchAllInfo(string search)
		{
			return _entities.UVASSY_DEFECTCODE.Where(p=>p.Defect_Code.Contains(search)||p.Defect_Desc.Contains(search)).ToList();
		}

	}
}
