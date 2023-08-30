using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Assy.ET
{
	public class A_OperatorProcessDataDAL
	{
		UVEntities _entities = new UVEntities();
		private static A_OperatorProcessDataDAL instance;
		public static A_OperatorProcessDataDAL Instance
		{
			get
			{
				if (instance == null)
					instance = new A_OperatorProcessDataDAL();
				return instance;
			}
		}
		public A_OperatorProcessDataDAL() { }

		public string Add(A_OperatorProcessData processData)
		{
			string message = "";
			try
			{
				_entities.A_OperatorProcessData.Add(processData);
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
		public string Update(A_OperatorProcessData processData)
		{
			string message = "";
			var _processData = new A_OperatorProcessData();
			_processData=_entities.A_OperatorProcessData.Where(p=>p.QrCode==processData.QrCode).FirstOrDefault();
            if (true)
            {
				try
				{
					_processData.Model=processData.Model;
					_processData.Market=processData.Market;
					_processData.TypePcb=processData.TypePcb;
					_processData.Process=processData.Process;
					_processData.QrCode=processData.QrCode;
					_processData.Checkert=processData.Checkert;
					_processData.DateT=processData.DateT;
					_processData.Remark1 =processData.Remark1;
					_processData.Remark2 =processData.Remark2;
					_processData.Remark3 =processData.Remark3;
					_processData.LineName =processData.LineName;					
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
            
		}
	}
}
