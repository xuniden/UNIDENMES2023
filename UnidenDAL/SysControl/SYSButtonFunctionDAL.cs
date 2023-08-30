using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl
{
    public class ButtonFunction
    {
        public string ButtonId { get; set; }
        public string ButtonDesc { get; set; }
        public bool? AccessStatus { get; set; }

    }
    public class SYSButtonFunctionDAL
    {
        UVEntities _entities = new UVEntities();
        private static SYSButtonFunctionDAL instance;

        public static SYSButtonFunctionDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SYSButtonFunctionDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public SYSButtonFunctionDAL() { }
        public List<SYS_UserButtonFunction> getUBFuntion(string UserId)
        {
            return _entities.SYS_UserButtonFunction.Where(x => x.UserId == UserId).ToList();
        }
        public List<ButtonFunction> getButtonFunction(string UserId)
        {
            var curList = (from a in _entities.SYS_ButtonFunction
                           join b in _entities.SYS_UserButtonFunction.Where(x => x.UserId == UserId)
                           on a.ButtonId equals b.ButtonId
                           into ab
                           from bc in ab.DefaultIfEmpty()
                           select new ButtonFunction
                           {
                               ButtonId = a.ButtonId,
                               ButtonDesc = a.ButtonDesc,
                               AccessStatus = bc.AccessStatus
                           }).ToList();

            return curList;
        }
        public List<SYS_UserButtonFunction> getByUserId(string UserId)
        {
            var listFunction = _entities.SYS_UserButtonFunction.Where(x => x.UserId == UserId );
//            var listFunction = _entities.SYS_UserButtonFunction.Where(x => x.UserId == UserId && x.AccessStatus == true);
            return listFunction.ToList();
        }
        public bool AddorUpdateFunction(SYS_UserButtonFunction usb)
        {
            try
            {
                _entities.SYS_UserButtonFunction.AddOrUpdate(usb);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
