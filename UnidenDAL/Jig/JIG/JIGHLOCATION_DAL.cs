using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.Jig.JIG
{
    public class JIGHLOCATION_DAL
    {
        UVEntities _entities = new UVEntities();
        private static JIGHLOCATION_DAL instance;
        public static JIGHLOCATION_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new JIGHLOCATION_DAL();
                return instance;
            }
        }
        public JIGHLOCATION_DAL() { }
       
        public List<JIGH_LOCATION> getListLocation(string search)
        {
            return _entities.JIGH_LOCATION.Where(p => p.JIsDisable == false &&
            (p.JLocName.Contains(search) || p.JLocDesc.Contains(search))).OrderBy(p => p.JLocName).ToList(); 
                   
        }
        public List<JIGH_LOCATION> getListLocation()
        {
            return _entities.JIGH_LOCATION.Where(p => p.JIsDisable == false).OrderBy(p => p.JLocName).ToList();

        }
        public string Remove(long Id)
        {
            string message = "";
            var jigLocation = new JIGH_LOCATION();
            jigLocation = _entities.JIGH_LOCATION.Where(p => p.Id == Id).FirstOrDefault();
            if (jigLocation != null)
            {
                jigLocation.JIsDisable = true;
                _entities.SaveChanges();
                message = "";
            }
            else
            {
                message = "Không thể xóa được location này";
            }
            return message;
        }
        public JIGH_LOCATION checkLocExist(string Loc)
        {
            return _entities.JIGH_LOCATION.Where(p => p.JLocName == Loc).FirstOrDefault();
        }
        public string Add(JIGH_LOCATION jigLoc)
        {
            string message = "";
            try
            {
                _entities.JIGH_LOCATION.Add(jigLoc);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message=ex.Message;
            }
            return message;
        }
        public string Update(JIGH_LOCATION jigLoc)
        {
            string message = "";
            var loc = _entities.JIGH_LOCATION.Where(p => p.Id == jigLoc.Id).FirstOrDefault();
            if (loc != null)
            {
                try
                {
                    loc.JLocDesc = jigLoc.JLocDesc;
                    loc.UpdatedDate = jigLoc.UpdatedDate;
                    loc.JIsDisable = jigLoc.JIsDisable;
                    loc.CreatedBy = jigLoc.CreatedBy;
                    _entities.SaveChanges();
                    message = "";
                }
                catch (Exception ex)
                {
                    message=ex.Message;
                }
            }
            else
            {
                message = "Không tìm thấy mã này trong csdl";
            }
            return message;

        }
    }
}
