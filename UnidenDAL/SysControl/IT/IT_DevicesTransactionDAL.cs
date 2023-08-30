using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl.IT
{
    public class IT_DevicesTransactionDAL
    {

        UVEntities _entities = new UVEntities();
        private static IT_DevicesTransactionDAL instance;

        public static IT_DevicesTransactionDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new IT_DevicesTransactionDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public IT_DevicesTransactionDAL() { }

        public bool Add(IT_DevicesTransaction dt)
        {
            try
            {
                _entities.IT_DevicesTransaction.Add(dt);
                _entities.SaveChanges();
                return true;
            }
            catch 
            {
                return false;                
            }
        }
        public IT_DevicesTransaction getLastTrans(string MaTB)
        {
            return _entities.IT_DevicesTransaction.Where(p => p.MaTB == MaTB).OrderByDescending(q => q.ID).FirstOrDefault();
        }
        //IT_DevicesTransactionHistory_Display
        public DataTable getListLogTranBySearch(int option,string search)
        {
            //return _entities.IT_DevicesTransaction.Where(p => p.MaTB.Contains(search)
            //|| p.EmployeeName.Contains(search)).ToList();
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_DevicesTransactionHistory_Display";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@option", option));
                command.Parameters.Add(new SqlParameter("@Search", search));
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
        public DataTable getListTranBySearch(string search)
        {
            //return _entities.IT_DevicesTransaction.Where(p => p.MaTB.Contains(search)
            //|| p.EmployeeName.Contains(search)).ToList();
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_DevicesTransaction_GetBySearch";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Search", search));               
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
        public DataTable getListTranByUser(string User)
        {
            //return _entities.IT_DevicesTransaction.Where(p => p.MaTB.Contains(search)
            //|| p.EmployeeName.Contains(search)).ToList();
            var dt = new DataTable();
            using (var command = _entities.Database.Connection.CreateCommand())
            {
                command.CommandText = "IT_DevicesTransaction_GetDataByUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@User", User));
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
