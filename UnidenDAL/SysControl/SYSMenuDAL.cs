using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl
{
    public class SYSMenuDAL
    {
        UVEntities _entities = new UVEntities();
        private static SYSMenuDAL instance;

        public static SYSMenuDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SYSMenuDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public SYSMenuDAL() { }
       
        public bool AddorUpdateMenu(SYS_MenuFunction sysMenu)
        {
            try
            {
                _entities.SYS_MenuFunction.AddOrUpdate(sysMenu);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckExistMenu(string MenuId)
        {
            var check = _entities.SYS_MenuFunction.Where(x => x.MenuId == MenuId).ToList();
            if (check.Count > 0)
                return true;
            return false;
        }
        public List<SYS_MenuFunction> getListMenu()
        {
            return _entities.SYS_MenuFunction.OrderBy(x => x.MenuId).ToList();
        }
    }
}
