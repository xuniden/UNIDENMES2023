using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL
{
    public class GlobalTransaction
    {
        private static GlobalTransaction _instance;
        private static readonly object _lock = new object();
        private readonly UVEntities _entities;
        private DbContextTransaction _transaction;
        private GlobalTransaction()
        {
            _entities = new UVEntities();
        }
        public static GlobalTransaction Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GlobalTransaction();
                        }
                    }
                }
                return _instance;
            }
        }
        public void BeginTransaction()
        {
            _transaction = _entities.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _transaction.Commit();
            _transaction = null;
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }
    }   
}
