using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnidenDTO;

namespace UnidenDAL.SysControl
{
    public class SessionLoginDAL
    {
        UVEntities _entities = new UVEntities();
        private static SessionLoginDAL instance;

        public static SessionLoginDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SessionLoginDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public SessionLoginDAL() { }

        public tbl_SessionLogin GetLogin(string userId)
        {
            return _entities.tbl_SessionLogin.Where(p => p.UserId == userId).FirstOrDefault();
        }
        public bool Add(tbl_SessionLogin secLogin)
        {
            try
            {
                _entities.tbl_SessionLogin.Add(secLogin);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }            
        }
        public bool Update(tbl_SessionLogin secLogin)
        {
            var login = _entities.tbl_SessionLogin.Where(p => p.UserId == secLogin.UserId).FirstOrDefault();
            try
            {
                login.Dept = secLogin.Dept;
                login.IpAddress = secLogin.IpAddress;
                login.LoginTime = secLogin.LoginTime;
                login.HostName = secLogin.HostName;
                _entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
              
            }

        }
        public List<tbl_SessionLogin> getListSection()
        {
            return _entities.tbl_SessionLogin.OrderByDescending(p=>p.LoginTime).ToList();
        }
        public bool Remove(string UserId)
        {
            try
            {
                var lgoin = new tbl_SessionLogin();                
                lgoin = _entities.tbl_SessionLogin.Where(p => p.UserId == UserId).FirstOrDefault();
                if (lgoin != null)
                {
                    _entities.tbl_SessionLogin.Remove(lgoin);
                    _entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<tbl_SessionLogin> getListSesstion(string search)
        {
            if (search!="")
            {
                return _entities.tbl_SessionLogin.Where(x => x.UserId.Contains(search)).ToList();
            }
            else
            {
                return _entities.tbl_SessionLogin.ToList();
            }
           
        }

        public string  KillAllSession()
        {
            string message = "";
            var lst= new List<tbl_SessionLogin>();
            lst = _entities.tbl_SessionLogin.ToList();
            try
            {
                _entities.tbl_SessionLogin.RemoveRange(lst);
                _entities.SaveChanges();
                message = "";
            }
            catch (Exception ex)
            {
                message=ex.Message;
            }
            return message;
        }
    }
}
