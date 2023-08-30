using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl
{
    public class UserRight
    {
        public string MenuId { get; set; }
        public string MenuDesc { get; set; }
        public string Parent { get; set; }
        public bool? AccessMenu { get; set; }
    }
    public class UserFunMenu
    {
        public string MenuDesc { get; set; }
        public bool? AccessMenu { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class SYSUserMenuFuctionDAL
    {
        UVEntities _entities = new UVEntities();
        private static SYSUserMenuFuctionDAL instance;

        public static SYSUserMenuFuctionDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SYSUserMenuFuctionDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public SYSUserMenuFuctionDAL() { }
        public bool AddorUpdateFunction(SYS_UserMenuFuction sysUserFunction)
        {
            try
            {
                _entities.SYS_UserMenuFuction.AddOrUpdate(sysUserFunction);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        public List<SYS_UserMenuFuction> getUserFunction(string UserId)
        {
            return _entities.SYS_UserMenuFuction.Where(x => x.UserId == UserId).ToList();
        }
        public List<SYS_UserMenuFuction> getUserFunctionNew(string UserId)
        {
            return _entities.SYS_UserMenuFuction.Where(x => x.UserId == UserId&&x.AccessMenu==true).ToList();
        }
        public List<UserFunMenu> getByUserId(string UserId)
        {
            var listFunction = (from a in _entities.SYS_UserMenuFuction
                                where a.UserId == UserId && a.AccessMenu == true
                                select new UserFunMenu
                                {
                                    MenuDesc = a.MenuDesc,
                                    AccessMenu = a.AccessMenu,
                                    CreatedDate = a.CreatedDate
                                }).ToList();
            return listFunction;
        }

        public List<UserRight> getUserRight(string UserId)
        {
            var curList = (from a in _entities.SYS_MenuFunction
                           join b in _entities.SYS_UserMenuFuction.Where(x => x.UserId == UserId)
                           on a.MenuId equals b.MenuId
                           into ab
                           from bc in ab.DefaultIfEmpty()
                           select new UserRight
                           {
                               MenuId = a.MenuId,
                               MenuDesc = a.MenuDesc,
                               Parent = a.Parent,
                               AccessMenu = bc.AccessMenu
                           }).ToList();
            return curList;
        }
    }
}
