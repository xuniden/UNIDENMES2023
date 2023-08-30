using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Assy
{
	public class DELETEBARCODE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static DELETEBARCODE_DAL instance;
		public static DELETEBARCODE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new DELETEBARCODE_DAL();
				return instance;
			}
		}
		public DELETEBARCODE_DAL() { }

		public string Add(UV_DELETEBARCODE dELETEBARCODE)
		{
			string message = "";
			try
			{
				_entities.UV_DELETEBARCODE.Add(dELETEBARCODE);
				_entities.SaveChanges();
				message = "";
				return message;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				return message;
			}
		}

		public string checkBeforeClose(string barcode, string Lot, long processId)
		{
			string message = "";
			var check = new UV_DELETEBARCODE();
				check=_entities.UV_DELETEBARCODE.Where(p=>p.ProcessID == processId&&p.DeleteBar==barcode&& p.Lot==Lot).FirstOrDefault();
			if (check!=null)
			{
				message = "";
				return message;

			}
			else
			{
				message = "Chưa được ghi vào csdl";
				return message;
			}
		}
	}
}
