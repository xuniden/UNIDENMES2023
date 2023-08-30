using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
	public class EASTECH_ERROR_LOG_APPROVE_DAL
	{
		UVEntities _entities = new UVEntities();
		private static EASTECH_ERROR_LOG_APPROVE_DAL instance;
		public static EASTECH_ERROR_LOG_APPROVE_DAL Instance
		{
			get
			{
				if (instance == null)
					instance = new EASTECH_ERROR_LOG_APPROVE_DAL();
				return instance;
			}
		}
		public EASTECH_ERROR_LOG_APPROVE_DAL() { }

		public long AddReturnID(EASTECH_ERROR_LOG_APPROVE logApprove)
		{
			long identityKey = 0;
			try
			{
				_entities.EASTECH_ERROR_LOG_APPROVE.Add(logApprove);
				_entities.SaveChanges();
				identityKey = logApprove.ID;				
			}
			catch (Exception)
			{
				identityKey = 0;
			}
			return identityKey;
		}

		public string Update(EASTECH_ERROR_LOG_APPROVE logApprove)
		{
			string message = "";
			try
			{
				var update=_entities.EASTECH_ERROR_LOG_APPROVE.Where(p=>p.ID==logApprove.ID).FirstOrDefault();
				if (update!=null)
				{
					update.Aprroved = logApprove.Aprroved;
					update.Remark = logApprove.Remark;
					update.ApprovedDate= logApprove.ApprovedDate;
					_entities.SaveChanges();
					message = "";
				}
				else
				{
					message = "Không tìm thấy dữ liệu để update";
				}
			}
			catch (Exception ex)
			{
				message= ex.Message;	
			}
			return message;
		}

		public EASTECH_ERROR_LOG_APPROVE checkUpdateSuccess(long Id)
		{
			return _entities.EASTECH_ERROR_LOG_APPROVE.Where(p=>p.ID==Id).FirstOrDefault();	
		}
	}
}
