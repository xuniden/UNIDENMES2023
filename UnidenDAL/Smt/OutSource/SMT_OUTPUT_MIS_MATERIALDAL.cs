using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.OutSource
{
    public class SMT_OUTPUT_MIS_MATERIALDAL
    {
        UVEntities _entities = new UVEntities();
        private static SMT_OUTPUT_MIS_MATERIALDAL instance;
        public static SMT_OUTPUT_MIS_MATERIALDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SMT_OUTPUT_MIS_MATERIALDAL();
                return instance;
            }
        }
        public SMT_OUTPUT_MIS_MATERIALDAL() { }
        public List<SMT_OUTPUT_MIS_MATERIAL>getListMisMatrial()
        {
            return _entities.SMT_OUTPUT_MIS_MATERIAL.OrderBy(p => p.CreatedDate).ToList();
        }
        public bool Add(SMT_OUTPUT_MIS_MATERIAL addMisMaterial)
        {
            try
            {
                _entities.SMT_OUTPUT_MIS_MATERIAL.Add(addMisMaterial);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
