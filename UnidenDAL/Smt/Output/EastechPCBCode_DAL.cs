using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.Smt.DataControl;
using UnidenDTO;

namespace UnidenDAL.Smt.Output
{
	public class PcbCodeGroupBy
	{
		public string PCBCode { get; set; }
	}

	public class PCBCodeToModel
	{		
		public string PCBType { get; set; }
		public string Model { get; set; }
	}

	public class EastechPCBCode_DAL
	{
		UVEntities _entities = new UVEntities();
		private static EastechPCBCode_DAL instance;
		public static EastechPCBCode_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new EastechPCBCode_DAL();
				return instance;
			}
		}

		public EastechPCBCode_DAL() { }

		public List<PcbCodeGroupBy> getListPCBCode()
		{
			var selectOption = new PcbCodeGroupBy { PCBCode = "--Select--" };
			var result = _entities.tbl_EastechPCBCode
						.GroupBy(e => e.PCBCode)
						.Select(g => new PcbCodeGroupBy { PCBCode = g.Key })
						.ToList();

			 result.Insert(0,selectOption);
			 result.OrderBy(p=>p.PCBCode).ToList();
			return result;
		}
		public List<PCBCodeToModel> getModelPCBType(string PCBCode)
		{
			var selectOption = new PCBCodeToModel { Model = "--Select--" };
			var result = _entities.tbl_EastechPCBCode
				.Where(e => e.PCBCode == PCBCode && e.Statuc == "Active")
				.GroupBy(e => new { e.PcbType, e.Model })
				.Select(g => new PCBCodeToModel
				{					
					PCBType = g.Key.PcbType,
					Model = g.Key.Model
				})
				.ToList();
			result.Insert(0, selectOption);
			result.OrderBy(p => p.Model).ToList();
			return result;
		}

		public tbl_EastechPCBCode getPCBType(string PCBCode, string model)
		{
			return _entities.tbl_EastechPCBCode.Where(p=>p.PCBCode==PCBCode && p.Model==model).FirstOrDefault();
		}
	}
}
