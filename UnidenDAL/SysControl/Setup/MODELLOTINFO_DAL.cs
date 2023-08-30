using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.AssyLine;
using UnidenDTO;
using System.Web;
using ExcelDataReader.Log;
using System.Data.Entity;

namespace UnidenDAL.SysControl.Setup
{
    public class MODELLOTINFO_DAL
    {
        UVEntities _entities = new UVEntities();
        private static MODELLOTINFO_DAL instance;
        public static MODELLOTINFO_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new MODELLOTINFO_DAL();
                return instance;
            }
        }

        public MODELLOTINFO_DAL() { }
        public UV_MODELLOTINFO checkExitsProgramKey(string programKey)
        {
            return _entities.UV_MODELLOTINFO.Where(p=>p.ProgramKey==programKey).FirstOrDefault();
        }    

        public UV_MODELLOTINFO getInfoByLot(string lot)
        {
            return _entities.UV_MODELLOTINFO.Where(p => p.Lot == lot &&p.IsCompleted==false).FirstOrDefault();
        }
        public string Add(UV_MODELLOTINFO modellot)
        {
            string message = "";
            try
            {
                _entities.UV_MODELLOTINFO.Add(modellot);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
               message=ex.Message;
            }
            return message;
        }
        public string Update(UV_MODELLOTINFO modellot)
        {
            string message = "";
            var loupdate = _entities.UV_MODELLOTINFO.Where(p => p.Lot == modellot.ProgramKey).FirstOrDefault();
            if (loupdate != null)
            {
                try
                {
                    loupdate.Model = modellot.Model;
                    loupdate.Lot = modellot.Lot;
                    loupdate.LotSize= modellot.LotSize;
                    loupdate.UpdatedDate = modellot.UpdatedDate;
                    loupdate.CreatedBy = modellot.CreatedBy;
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                   message = ex.Message;
                }
            }
            return message;

        }
        public bool Delete(UV_MODELLOTINFO Lot)
        {
            try
            {
                _entities.UV_MODELLOTINFO.Remove(Lot);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string DeleteByProgram(string program)
        {
            string message = "";
            var deleteModel= _entities.UV_MODELLOTINFO.Where(p=>p.ProgramKey == program).FirstOrDefault();
            if (deleteModel!=null)
            {
                try
                {
                    _entities.UV_MODELLOTINFO.Remove(deleteModel);
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                    message=ex.Message;
                }
            }
            return message;
        }

        public List<UV_MODELLOTINFO> getList()
        {
            DateTime dt = CommonDAL.Instance.getSqlServerDatetime();
            return _entities.UV_MODELLOTINFO.Where(p => p.UpdatedDate.Year == dt.Year && p.UpdatedDate.Month == dt.Month && p.UpdatedDate.Day == dt.Day).ToList();
        }
        public List<UV_MODELLOTINFO> getList(string search)
        {
            return _entities.UV_MODELLOTINFO.Where(p => p.Model.Contains(search) || p.Lot.Contains(search)).ToList();
        }
        public List<UV_MODELLOTINFO> getAllLotList()
        {
            return _entities.UV_MODELLOTINFO.Where(p=>p.IsCompleted==false).OrderBy(p=>p.Lot).ToList();
        }

        public System.Data.DataTable getModelForCreateUVQRCODE()
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_getModelForCreateUVQRCODE";
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@Option", option));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        public System.Data.DataTable getLotForSetupProcess()
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_getLotForSetupProcess";
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@Option", option));
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
		#region Lấy dữ liệu Model Lot từ QRCode theo tên chương trình trong output smt
		public UV_MODELLOTINFO getInfoByQRCode(string QRcode)
		{
			var result = _entities.UV_MODELLOTINFO
		    .Where(info => _entities.EASTECH_SMT_OUTPUT
						    .Where(et => et.QRCode == QRcode)
						    .Select(et => et.programkey)
						    .Distinct()
						    .Take(1)
						    .Contains(info.ProgramKey))
		    .FirstOrDefault();
            return result;
		}
		//public DataTable getInfoByQRCode(string QRcode)
		//{
		//	var dt = new System.Data.DataTable();
		//	using (var command = _entities.Database.Connection.CreateCommand())
		//	{
		//		command.CommandText = "sp_common_getInfoByQRCode";
		//		command.CommandType = CommandType.StoredProcedure;
		//		command.Parameters.Add(new SqlParameter("@QRCode", QRcode));
		//		if (command.Connection.State != ConnectionState.Open)
		//		{
		//			command.Connection.Open();
		//		}
		//		using (var reader = command.ExecuteReader())
		//		{
		//			dt.Load(reader);
		//		}
		//	}
		//	return dt;
		//}
		#endregion
	}
}
