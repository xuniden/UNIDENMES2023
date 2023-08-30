using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{
	public class groupDeptCode
	{
		public string DeptCode { get; set; }
		public string DeptDesc { get; set; }
	}
	public class DEPTCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static DEPTCODE_DAL instance;
		public static DEPTCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new DEPTCODE_DAL();
				return instance;
			}
		}
		public DEPTCODE_DAL() { }

		public string Add(UVASSY_DEPTCODE dEPTCODE)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_DEPTCODE.Add(dEPTCODE);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Update(UVASSY_DEPTCODE deptCode)
		{
			string message = string.Empty;
			try
			{
				var update = _entities.UVASSY_DEPTCODE.Where(p => p.ID == deptCode.ID).FirstOrDefault();
				if (update != null)
				{
					update.UpdatedDate = deptCode.UpdatedDate;
					update.UpdatedBy = deptCode.UpdatedBy;
					update.DeptDesc = deptCode.DeptDesc;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message += ex.Message;
			}
			return message;
		}

		public string AddUpdateRange(List<UVASSY_DEPTCODE> lstAdd, List<UVASSY_DEPTCODE> lstUpdate)
		{
			string message = string.Empty;
			using (var dbContextTransaction = _entities.Database.BeginTransaction())
			{
				try
				{
					_entities.UVASSY_DEPTCODE.AddRange(lstAdd);
					_entities.SaveChanges();

					foreach (var item in lstUpdate)
					{
						var upRecord = _entities.UVASSY_DEPTCODE.Where(p => p.ID == item.ID).FirstOrDefault();
						if (upRecord != null)
						{
							upRecord.UpdatedDate = item.UpdatedDate;
							upRecord.UpdatedBy = item.UpdatedBy;
							upRecord.DeptDesc = item.DeptDesc;
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

		public string AddRange(List<UVASSY_DEPTCODE> dEPTCODEs)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_DEPTCODE.AddRange(dEPTCODEs);
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
				var remove = _entities.UVASSY_DEPTCODE.Where(p => p.ID == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_DEPTCODE.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}

		public List<UVASSY_DEPTCODE> getAllInfo()
		{
			return _entities.UVASSY_DEPTCODE.ToList();
		}
		public UVASSY_DEPTCODE checkExistEfectCode(string deptCode)
		{
			return _entities.UVASSY_DEPTCODE.Where(p => p.DeptCode == deptCode).FirstOrDefault();
		}

		public List<UVASSY_DEPTCODE> searchAllInfo(string search)
		{
			return _entities.UVASSY_DEPTCODE.Where(p => p.DeptCode.Contains(search) || p.DeptDesc.Contains(search)).ToList();
		}

		public List<groupDeptCode> getDeptCodeForCombobox()
		{
			try
			{
				var selectionDeptCode = new groupDeptCode { DeptCode = "--Select--", DeptDesc = "-Select--" };
				var result = _entities.UVASSY_DEPTCODE
					.GroupBy(e => new { e.DeptCode, e.DeptDesc })
					.Select(g => new groupDeptCode
					{
						DeptCode = g.Key.DeptCode,
						DeptDesc = g.Key.DeptDesc
					})
					.ToList();
				result.Insert(0, selectionDeptCode);
				var sortedResult = result.OrderBy(e => e.DeptCode).ToList();
				return sortedResult;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
				return new List<groupDeptCode>();
			}

		}
	}
}
