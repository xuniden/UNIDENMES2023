using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.MENU
{
	public class PCBTYPE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static PCBTYPE_DAL instance;
		public static PCBTYPE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new PCBTYPE_DAL();
				return instance;
			}
		}
		public PCBTYPE_DAL() { }

		public List<UVASSY_PCBTYPE> getListPcbType()
		{
			var selectionPcbType = new UVASSY_PCBTYPE { PCBTYPE = "--Select--" };
			var result = _entities.UVASSY_PCBTYPE.ToList();			
			result.Insert(0, selectionPcbType);
			var resultShort = result.OrderBy(e => e.PCBTYPE).ToList();
			return resultShort;
		}
	}
}
