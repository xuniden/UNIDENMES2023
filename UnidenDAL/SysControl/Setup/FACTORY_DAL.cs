using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl.Setup
{
    public class FACTORY_DAL
    {
        UVEntities _entities = new UVEntities();
        private static FACTORY_DAL instance;

        public static FACTORY_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new FACTORY_DAL();
                return instance;
            }
            //set => instance = value; 
        }
        public FACTORY_DAL() { }
        public bool AddList(List<UV_FACTORY> uvfactory)
        {
            try
            {
                _entities.UV_FACTORY.AddRange(uvfactory);
                _entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Add(UV_FACTORY uvfactory)
        {
            try
            {
                _entities.UV_FACTORY.Add(uvfactory);
                _entities.SaveChanges();
                return true;
            }
            catch 
            {
                return false;                
            }
        }
        public bool Update(UV_FACTORY uvfactory)
        {
            bool check=false;
            var ufactory= _entities.UV_FACTORY.Where(p=>p.FACTORYCODE==uvfactory.FACTORYCODE).FirstOrDefault();
            if (ufactory != null)
            {
                try
                {
                    ufactory.FACTORYNAME= uvfactory.FACTORYNAME;
                    ufactory.UPDATEDDATE= uvfactory.UPDATEDDATE;
                    ufactory.UPDATEDBY= uvfactory.UPDATEDBY;
                    ufactory.FSTATUS= uvfactory.FSTATUS;
                    _entities.SaveChanges();
                    check= true;
                }
                catch
                {
                    check=false;
                }
            } 
            return check;
        }
        public DataTable getFactoryList()
        {
            DataTable result = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "sp_uv_getFactoryList";
                command.CommandType = CommandType.StoredProcedure;               
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (var reader = command.ExecuteReader())
                {
                    result.Load(reader);
                }
            }
            return result;
        }
    }
}
