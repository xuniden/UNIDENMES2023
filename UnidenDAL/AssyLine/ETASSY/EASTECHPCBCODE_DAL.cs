using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.ETASSY
{
	public class GroupModel
	{
		public string Model { get; set; }
	}
	public class GroupPCBCode
	{
		public string PcbCode { get; set; }
	}
	public class EASTECHPCBCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static EASTECHPCBCODE_DAL instance;
		public static EASTECHPCBCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new EASTECHPCBCODE_DAL();
				return instance;
			}
		}

		public EASTECHPCBCODE_DAL() { }
		public string Add(UVASSY_EASTECHPCBCODE pcbCode)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_EASTECHPCBCODE.Add(pcbCode);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string AddRange(List<UVASSY_EASTECHPCBCODE> pcbCodes)
		{
			string message = string.Empty;
			try
			{
				_entities.UVASSY_EASTECHPCBCODE.AddRange(pcbCodes);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Update(UVASSY_EASTECHPCBCODE pcbCode)
		{
			string message = string.Empty;
			try
			{
				var update=_entities.UVASSY_EASTECHPCBCODE.Where(p=>p.Id== pcbCode.Id).FirstOrDefault();
				if (update != null)
				{
					update	.PcbKey = pcbCode.PcbKey;
					update.PCBCode = pcbCode.PCBCode;
					update.UpdatedDate = pcbCode.UpdatedDate;
					update.UpdatedBy = pcbCode.UpdatedBy;
					update.Status = pcbCode.Status;
					_entities.SaveChanges();
				}
				else
				{
					message = "Không tìm thấy dữ liệu cần update";
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return message;
		}

		public string Delete(long Id)
		{
			string message=string.Empty;
			try
			{
				var rmove=_entities.UVASSY_EASTECHPCBCODE.Where(p=>Id==Id).FirstOrDefault();
				_entities.UVASSY_EASTECHPCBCODE.Remove(rmove);
				_entities.SaveChanges ();
			}
			catch (Exception ex)
			{
				message=ex.Message;
			}
			return message;
		}

		public List<UVASSY_EASTECHPCBCODE> searchData(string search)
		{
			return _entities.UVASSY_EASTECHPCBCODE.Where(p=>p.Model.Contains(search) || 
			p.PCBCode.Contains(search)
			||p.Status.Contains(search)).ToList();
		}

		public List<UVASSY_EASTECHPCBCODE> GetAll()
		{
			return _entities.UVASSY_EASTECHPCBCODE.OrderByDescending(p=>p.CreatedDate).ToList();
		}

		public List<GroupModel> getModel()
		{
			try
			{
				var selection = new GroupModel { Model = "--Select--" };
				var result = _entities.UVASSY_EASTECHPCBCODE
					.GroupBy(p => p.Model)
					.Select(p => new GroupModel
					{
						Model = p.Key
					}).ToList();
				result.Insert(0, selection);
				var g = result.OrderBy(p => p.Model).ToList();
				return g;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new List<GroupModel>();
			}
			
		}

		public List<GroupPCBCode> getPCBCodeByModel(string model)
		{
			try
			{
				var selection = new GroupPCBCode { PcbCode = "--Select--" };
				var result = _entities.UVASSY_EASTECHPCBCODE
				.Where(p=>p.Model==model)
				.GroupBy(p => p.PCBCode)
				.Select(p => new GroupPCBCode
				{
					PcbCode = p.Key
				}).ToList();
				result.Insert(0, selection);
				var gr=result.OrderBy(p => p.PcbCode).ToList();
				return gr;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new List<GroupPCBCode>();
			}
		}
	}
}
