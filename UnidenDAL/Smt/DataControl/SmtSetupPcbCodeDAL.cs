using Microsoft.Office.Interop.Excel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
    public class GetPCBCode
    {
        public string PCBCode { get; set; }      
    }
    public class getPCBType
    {
        public string PCBType { get; set; }
    }
    public class getModel
    {
        public string Model { get; set; }
    }
    public class GeneralSerialNumber
    {
        public string SerialNumber { get; set; }
    }
    public class SmtSetupPcbCodeDAL
    {
        UVEntities _entities = new UVEntities();
        private static SmtSetupPcbCodeDAL instance;
        public static SmtSetupPcbCodeDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtSetupPcbCodeDAL();
                return instance;
            }
        }
        public SmtSetupPcbCodeDAL() { }

        public List<ModelName> getModelList()
        {
            return _entities.ModelNames.ToList();
        }
        public ModelName getModelCode(string modelname)
        {
            return _entities.ModelNames.Where(x => x.ModelName1 == modelname).FirstOrDefault();
        }
        public List<PcbType> getPcbTypeList()
        {
            return _entities.PcbTypes.ToList();
        }
        public List<tbl_EastechPCBCode> getPcbCodeList()
        {
            return _entities.tbl_EastechPCBCode.Where(p=>p.Statuc== "Active").ToList();
        }
        public bool Add(tbl_EastechPCBCode pcbCode)
        {
            try
            {
                _entities.tbl_EastechPCBCode.Add(pcbCode);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        public bool Update(tbl_EastechPCBCode pcbCode)
        {

            var _pcbCode = _entities.tbl_EastechPCBCode.Where(p => p.Id == pcbCode.Id).FirstOrDefault();
            if (_pcbCode != null)
            {
                try
                {
                    _pcbCode.PcbKey = pcbCode.PcbKey;
                    _pcbCode.PCBCode = pcbCode.PCBCode;
                    _pcbCode.Model = pcbCode.Model;
                    _pcbCode.Statuc = pcbCode.Statuc;
                    _pcbCode.PcbType = pcbCode.PcbType;
                    _pcbCode.DateT = pcbCode.DateT;
                    _entities.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public bool Remove(long Id)
        {
            var pcb = new tbl_EastechPCBCode();
            pcb = _entities.tbl_EastechPCBCode.Where(p => p.Id == Id).FirstOrDefault();
            if (pcb != null)
            {
                _entities.tbl_EastechPCBCode.Remove(pcb);
                _entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public tbl_EastechPCBCode getPcbInfo(string pcbCode)
        {
            return _entities.tbl_EastechPCBCode.Where(p => p.PCBCode == pcbCode).FirstOrDefault();
        }
        public bool checkPCBCodeExist(string pcbCode)
        {
            var lstPCB=_entities.tbl_EastechPCBCode.Where(p=>p.PCBCode== pcbCode).ToList();
            if (lstPCB.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		public bool checkExistPcbKey(string pcbKey)
		{
			var lstPCB = _entities.tbl_EastechPCBCode.Where(p => p.PcbKey == pcbKey).ToList();
			if (lstPCB.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public List<tbl_EastechPCBCode> getSearchByString(string search)
        {
            return _entities.tbl_EastechPCBCode.Where(p=>p.PcbKey.Contains(search)
            || p.PCBCode.Contains(search)
            || p.PcbType.Contains(search)).ToList();
        }

        public List<GetPCBCode> getPCBCodeByModel(string model)
        {
            var query=(from a in _entities.tbl_EastechPCBCode.Where(m=>m.Model==model && m.Statuc== "Active").GroupBy(p=>p.PCBCode)
                       select new GetPCBCode
                       {
                           PCBCode = a.Key                         
                       }).ToList();

            return query;     
        }
        public tbl_EastechPCBCode getPCBTypeByModelAndPCBCode(string model, string pcbCode)
        {
            return _entities.tbl_EastechPCBCode.Where(
                p => p.Model == model && p.PCBCode == pcbCode && p.Statuc == "Active").FirstOrDefault();
        }
        public List<GetPCBCode> getPCBCodeAll()
        {
            var query = (from a in _entities.tbl_EastechPCBCode.Where(m=>m.Statuc == "Active").GroupBy(p => p.PCBCode)
                         select new GetPCBCode
                         {
                             PCBCode = a.Key
                         }).ToList();

            return query;
        }

        public List<getModel> getUvModel()
        {
            var query = (from a in _entities.tbl_EastechPCBCode.Where(m => m.Statuc == "Active"&& m.Model.StartsWith("U")).GroupBy(p => p.Model)
                         select new getModel
                         {
                             Model= a.Key
                         }).ToList();

            return query;
        }
        
        public System.Data.DataTable getModelForRegistorPCBCode()
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_getModelForRegistorPCBCode";
                command.CommandType = CommandType.StoredProcedure;                
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

        public System.Data.DataTable getModelForUVorOtherPCBTYPE(int option)
        {
            var dt = new System.Data.DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_getModelForUVorOther";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Option", option));
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

    }
}
