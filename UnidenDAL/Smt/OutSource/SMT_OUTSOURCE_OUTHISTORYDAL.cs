using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Smt.OutSource
{
    public class SMT_OUTSOURCE_OUTHISTORYDAL
    {
        UVEntities _entities = new UVEntities();
        private static SMT_OUTSOURCE_OUTHISTORYDAL instance;
        public static SMT_OUTSOURCE_OUTHISTORYDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SMT_OUTSOURCE_OUTHISTORYDAL();
                return instance;
            }
        }
        public SMT_OUTSOURCE_OUTHISTORYDAL() { }

        public void Add(SMT_OUTSOURCE_OUTHISTORY history)
        {
            try
            {
                _entities.SMT_OUTSOURCE_OUTHISTORY.Add(history);
                _entities.SaveChanges();
            }
            catch 
            {

                throw;
            }
        }
    }
}
