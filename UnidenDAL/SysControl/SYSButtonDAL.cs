using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl
{
    public class SYSButtonDAL
    {
        UVEntities _entities = new UVEntities();
        private static SYSButtonDAL instance;

        public static SYSButtonDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SYSButtonDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public SYSButtonDAL() { }
        public SYS_ButtonFunction findButton(string buttonId)
        {
            return _entities.SYS_ButtonFunction.Where(x => x.ButtonId == buttonId).FirstOrDefault();
        }
        public List<SYS_ButtonFunction> getListButton()
        {
            return _entities.SYS_ButtonFunction.ToList();
        }
        public bool checkExistButton(string buttonid)
        {
            var lst = _entities.SYS_ButtonFunction.Where(x => x.ButtonId == buttonid).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(SYS_ButtonFunction button)
        {
            try
            {
                _entities.SYS_ButtonFunction.Add(button);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(SYS_ButtonFunction button)
        {
            try
            {
                _entities.SYS_ButtonFunction.Remove(button);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool EditButton(SYS_ButtonFunction button)
        {
            SYS_ButtonFunction _button;
            _button = _entities.SYS_ButtonFunction.Where(x => x.ButtonId == button.ButtonId).SingleOrDefault();
            _button.ButtonId = button.ButtonId;
            _button.ButtonDesc = button.ButtonDesc;
            _button.UpdatedDate = button.UpdatedDate;
            try
            {
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<SYS_ButtonFunction> findButtonById(string button)
        {
            if (button == "")
            {
                return _entities.SYS_ButtonFunction.ToList();
            }
            else
            {
                return _entities.SYS_ButtonFunction.Where(x => x.ButtonDesc.Contains(button) || x.ButtonId.Contains(button)).ToList();
            }

        }
    }
}
