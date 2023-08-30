using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDAL.whs;
using UnidenDTO;

namespace UnidenDAL.Smt.DataControl
{
    public class SmtUploadBomDAL
    {
        UVEntities _entities = new UVEntities();
        private static SmtUploadBomDAL instance;
        public static SmtUploadBomDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SmtUploadBomDAL();
                return instance;
            }
        }
        public SmtUploadBomDAL() { }
        public List<PROGRAM> CheckProgramByKey(string programkey)
        {
            return _entities.PROGRAMs.Where(p => p.programpartlist == programkey).ToList();
        }
        public bool Add(PROGRAM program)
        {
            try
            {
                _entities.PROGRAMs.Add(program);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string AddList(List<PROGRAM> programs)
        {
            string message = "";
            try
            {
                _entities.PROGRAMs.AddRange(programs);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
