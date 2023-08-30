using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Jig
{
    public class JIGCALHISTORY_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGCALHISTORY_DAL instance;
        public static JIGCALHISTORY_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGCALHISTORY_DAL();
                return instance;
            }
        }
        public JIGCALHISTORY_DAL() { }

        public string Add(JIG_CALHISTORY calHistory)
        {
            string message = "";
            try
            {
                _entities.JIG_CALHISTORY.Add(calHistory);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message= ex.Message;
            }
            return message;
        }
        public JIG_CALHISTORY checkExistsEqControl(string eqControl)
        {
            return _entities.JIG_CALHISTORY.Where(p=>p.ControlNo== eqControl).FirstOrDefault();
        }
        public List<JIG_CALHISTORY> getListControlByControlNo(string controlNo)
        {
            return _entities.JIG_CALHISTORY.Where(p=>p.ControlNo==controlNo).OrderByDescending(p=>p.CreatedDate).ToList();
        }

        public List<JIG_CALHISTORY> getHistoryUpdateCalDate(string user)
        {
            return _entities.JIG_CALHISTORY.Where(p=>p.CreatedBy==user).OrderByDescending(p=>p.CreatedDate).ToList();
        }
    }
}
