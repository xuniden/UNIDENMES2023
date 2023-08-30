using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UnidenDTO;

namespace UnidenDAL.SysControl
{
    public class UserShort
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string ePassword { get; set; }
        public Nullable<long> DeptID { get; set; }
        public string DeptCode { get; set; }
        public Nullable<bool> IsDisable { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }

    }


    public class SYSUserDAL
    {
        UVEntities _entities = new UVEntities();
        private static SYSUserDAL instance;

        public static SYSUserDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SYSUserDAL();
                return instance;
            }
            //set => instance = value; 
        }
        public SYSUserDAL() { }

        public List<UserShort> getUserShort()
        {
            var query = (from a in _entities.SYS_Users
                         select new UserShort
                         {
                             UserId = a.UserID,
                             FullName = a.FullName,
                             ePassword = a.ePassword,
                             DeptID = long.Parse(a.DeptID.ToString()),
                             DeptCode = a.UV_DEPT.DeptCode,
                             IsDisable = a.IsDisable,
                             CreatedDate = a.CreatedDate,
                             UpdatedDate = a.UpdatedDate

                         }).ToList();
            return query;
        }
        public List<UserShort> getListUsers()
        {
            return (from a in _entities.SYS_Users
                    select new UserShort
                    {
                        UserId = a.UserID,
                        FullName = a.FullName,
                        ePassword = a.ePassword,
                        DeptID = a.DeptID,
                        DeptCode = a.UV_DEPT.DeptCode,
                        IsDisable = a.IsDisable,
                        CreatedDate = a.CreatedDate,
                        UpdatedDate = a.UpdatedDate

                    }).ToList();
        }
        public SYS_Users getOldPassword(string user)
        {
            return _entities.SYS_Users.Where(x => x.UserID == user).FirstOrDefault();
        }
        public SYS_Users checkLogin(string user, string password)
        {
            return _entities.SYS_Users.Where(x => x.UserID == user && x.ePassword == password).FirstOrDefault();
        }
        public bool checkExistUser(String UserId)
        {
            var lst = _entities.SYS_Users.Where(x => x.UserID == UserId).ToList();
            if (lst.Count > 0)
                return true;
            return false;
        }
        public bool Add(SYS_Users user)
        {
            try
            {
                _entities.SYS_Users.Add(user);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EditUser(SYS_Users user)
        {
            SYS_Users _user;
            _user = _entities.SYS_Users.Where(x => x.UserID == user.UserID).SingleOrDefault();
            _user.UserID = user.UserID;
            _user.FullName = user.FullName;
            _user.ePassword = user.ePassword;
            _user.DeptID = user.DeptID;
            _user.IsDisable = user.IsDisable;
            _user.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
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
        public List<SYS_Users> findUser(string user)
        {
            if (user == "")
            {
                return _entities.SYS_Users.ToList();
            }
            else
            {
                return _entities.SYS_Users.Where(x => x.UserID.Contains(user) || x.FullName.Contains(user)).ToList();
            }
        }
        public List<UserShort> findUserShort(string user)
        {
            if (user == "")
            {
                return (
                    from a in _entities.SYS_Users
                    select new UserShort
                    {
                        UserId = a.UserID,
                        FullName = a.FullName
                    }).ToList();

            }
            else
            {
                return (from a in _entities.SYS_Users.Where(x => x.UserID.Contains(user) || x.FullName.Contains(user))
                        select new UserShort
                        {
                            UserId = a.UserID,
                            FullName = a.FullName
                        }).ToList();

            }
        }
        public bool Delete(string UserId)
        {
            var user = _entities.SYS_Users.FirstOrDefault(x => x.UserID == UserId && x.IsDisable == false);
            user.IsDisable = true;
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
    }
}
