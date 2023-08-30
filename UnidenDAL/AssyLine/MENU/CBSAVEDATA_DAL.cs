using Microsoft.Office.Interop.Excel;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.MENU
{
	public class CBSAVEDATA_DAL
	{
		UVEntities _entities = new UVEntities();
		private static CBSAVEDATA_DAL instance;
		public static CBSAVEDATA_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new CBSAVEDATA_DAL();
				return instance;
			}
		}
		public CBSAVEDATA_DAL() { }

		public UVASSY_CBSAVEDATA checkKey(string keys)
		{
			return _entities.UVASSY_CBSAVEDATA.Where(p=>p.Keys==keys).FirstOrDefault();
		}
		public UVASSY_CBSAVEDATA checkKey2(string keys2)
		{
			return _entities.UVASSY_CBSAVEDATA.Where(p => p.Keys2 == keys2).FirstOrDefault();
		}
		public string Update(UVASSY_CBSAVEDATA saveData)
		{
			string message=string.Empty;
			try
			{
				var update = _entities.UVASSY_CBSAVEDATA.Where(p => p.Lot == saveData.Lot && p.BatchNo == saveData.BatchNo).FirstOrDefault();
				if (update != null)
				{
					update.ErrorDetail = saveData.ErrorDetail;
					update.ErrorStatus= saveData.ErrorStatus;
					update.ChangeBatchTo= saveData.ChangeBatchTo;
					update.CreatedDate = saveData.CreatedDate;
					_entities.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}
		public string Add(UVASSY_CBSAVEDATA saveData)
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_CBSAVEDATA.Add(saveData);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;	
			}

			return message;
		}
		public string AddRange(List<UVASSY_CBSAVEDATA> saveDatas)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_CBSAVEDATA.AddRange(saveDatas);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public int getMaxCartonNumber(string lot, string line)
		{
			int result = 0;
			var checkCarton=_entities.UVASSY_CBSAVEDATA
									.Where(p=>p.Lot==lot && p.Line==line)
									.OrderByDescending(p=>p.Carton)
									.FirstOrDefault();
			if (checkCarton!=null)
			{
				result= checkCarton.Carton;
			}	
			return result;
		}

		public UVASSY_CBSAVEDATA checkBatch(string lot, string line,int carton)
		{
			return _entities.UVASSY_CBSAVEDATA
				.Where(p => p.Lot == lot && p.Line == line && p.Carton == carton)
				.FirstOrDefault();
		}

		public List<UVASSY_CBSAVEDATA> LoadDataByLotvsUser(string lot, string line, string user, string catonbarcode, string dboxbarcode)
		{
			return _entities.UVASSY_CBSAVEDATA.Where(p=>p.Lot== lot && p.Line==line && p.CreatedBy==user && p.Model_Serial==catonbarcode && p.Dbox_Serial==dboxbarcode)
											  .OrderByDescending(p=>p.CreatedDate)
											  .ToList();
		}

		public List<UVASSY_CBSAVEDATA> getDatabyLotvsUser(string lot,  string user)
		{
			return _entities.UVASSY_CBSAVEDATA.Where(p => p.Lot ==lot && p.CreatedBy==user)
				.OrderByDescending(p=>p.CreatedDate)
				.ToList();
		}

		public UVASSY_CBSAVEDATA checkExistLot(string lot)
		{
			return _entities.UVASSY_CBSAVEDATA
				.Where(p=>p.Lot== lot)	
				.FirstOrDefault();
		}

		public UVASSY_CBSAVEDATA checkLotvsBatch(string lot, string batch)
		{
			return _entities.UVASSY_CBSAVEDATA
				.Where(p => p.Lot == lot && p.BatchNo == batch)
				.FirstOrDefault();
		}
		public List<UVASSY_CBSAVEDATA> searchData(string search)
		{
			return _entities.UVASSY_CBSAVEDATA
				.Where (p => p.Lot == search)
				.ToList();
		}
		public int CountQty(string lot, string news)
		{
			return _entities.UVASSY_CBSAVEDATA
				.Where(p => p.Lot == lot && p.Remark==news)
				.Count();
		}
	}
}
