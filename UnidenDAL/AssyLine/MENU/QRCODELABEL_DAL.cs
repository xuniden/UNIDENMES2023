using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.AssyLine.MENU
{
	public class QRCODELABEL_DAL
	{
		UVEntities _entities = new UVEntities();
		private static QRCODELABEL_DAL instance;
		public static QRCODELABEL_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new QRCODELABEL_DAL();
				return instance;
			}
		}
		public QRCODELABEL_DAL() { }
	}
}
