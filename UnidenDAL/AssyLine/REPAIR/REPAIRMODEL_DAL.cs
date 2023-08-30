using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.REPAIR
{

	public class groupRepairModel
	{
		public string ShortModel { get; set; }
	}
	public class REPAIRMODEL_DAL
	{
		UVEntities _entities = new UVEntities();
		private static REPAIRMODEL_DAL instance;
		public static REPAIRMODEL_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new REPAIRMODEL_DAL();
				return instance;
			}
		}
		public REPAIRMODEL_DAL() { }


		public string Add(UVASSY_REPAIRMODEL repairModel)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_REPAIRMODEL.Add(repairModel);
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
				var remove = _entities.UVASSY_REPAIRMODEL.Where(p => p.Id == Id).FirstOrDefault();
				if (remove != null)
				{
					_entities.UVASSY_REPAIRMODEL.Remove(remove);
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				messsage = ex.Message;
			}
			return messsage;
		}

		public string AddRange(List<UVASSY_REPAIRMODEL> lstAdd)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_REPAIRMODEL.AddRange(lstAdd);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}


		public List<UVASSY_REPAIRMODEL> getAllInfo()
		{
			return _entities.UVASSY_REPAIRMODEL.ToList();
		}
		public UVASSY_REPAIRMODEL checkExistShortModel(string ShortModel)
		{
			return _entities.UVASSY_REPAIRMODEL.Where(p => p.ShortModel == ShortModel).FirstOrDefault();
		}


		public List<UVASSY_REPAIRMODEL> searchAllInfo(string search)
		{
			return _entities.UVASSY_REPAIRMODEL.Where(p => p.ShortModel.Contains(search)).ToList();
		}

		public List<groupRepairModel> getRepairModelForCombobox()
		{
			try
			{
				var selectionRepairModel = new groupRepairModel { ShortModel = "--Select--" };
				var result = _entities.UVASSY_REPAIRMODEL
					.GroupBy(e => new { e.ShortModel })
					.Select(g => new groupRepairModel
					{
						ShortModel = g.Key.ShortModel
					})
					.ToList();
				result.Insert(0, selectionRepairModel);
				var sortedResult = result.OrderBy(e => e.ShortModel).ToList();
				return sortedResult;
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
				return new List<groupRepairModel>();
			}

		}
	}
}
