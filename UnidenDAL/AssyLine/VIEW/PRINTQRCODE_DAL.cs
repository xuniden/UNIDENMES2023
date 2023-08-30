using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UnidenDAL.AssyLine.UG;
using UnidenDTO;

namespace UnidenDAL.AssyLine.VIEW
{
	public class PRINTQRCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static PRINTQRCODE_DAL instance;
		public static PRINTQRCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new PRINTQRCODE_DAL();
				return instance;
			}
		}
		public PRINTQRCODE_DAL() { }

		public List<UVASSY_QRCODELABEL> getListPrint()
		{
			return _entities.UVASSY_QRCODELABEL.ToList();
		}

		public string AddRange (List<UVASSY_QRCODELABEL> lableQRCode) 
		{ 
			string message=string.Empty;
			try
			{
				_entities.UVASSY_QRCODELABEL.AddRange(lableQRCode);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return message;
		}

		public string DeleteRange(List<UVASSY_QRCODELABEL> lsrc)
		{
			string message=string.Empty;
			try
			{
				_entities.UVASSY_QRCODELABEL.RemoveRange(lsrc);
				_entities.SaveChanges();
			}
			catch (Exception ex)
			{
				message=ex.Message;	
			}
			return message;
		}
	}
}
