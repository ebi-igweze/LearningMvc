using LearningMVC.Core.DataAccess;
using LearningMVC.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMVC.Core.Managers
{
    public class UserManager
    {
        private DataRepository _db;
        public UserManager(DataRepository db)
        {
            _db = db;
        }

        public UserModel[] GetUsers()
        {
            var records = _db.Query<User>().ToList();
            return records.Select(r => new UserModel(r)).ToArray();
        }

        public string[] GetRoles()
        {
            return _db.Query<Role>().Select(r => r.Name).ToArray();
        }

        public void AddToRole(UserModel model, string roleName)
        {
            //Get the Role Based on the RoleName
            var role = _db.Query<Role>().Where(r => r.Name == roleName).FirstOrDefault();
            if (role == null) throw new Exception("Role Does Not Exist");

            //Get User
            var user = _db.Query<User>().Where(u => u.Email == model.Email).FirstOrDefault();
            if (user == null) throw new Exception("Invalid User");

            //Check to see if user already has this role
            var userRole = user.UserRoles.Where(ur => ur.RoleID == role.RoleID).FirstOrDefault();
            if(userRole == null)
            {
                userRole = new UserRole
                {
                    UserID = user.UserID,
                    RoleID = role.RoleID
                };

                _db.Add(userRole);
                _db.SaveChanges();
            }
        }

        public UserModel FindByID(string userId)
        {
            var user = _db.Query<User>().Where(u => u.UserID == int.Parse(userId)).FirstOrDefault();
            if (user == null) throw new Exception("Invalid UserID");
            return new UserModel(user);
        }

        public string[] GetUserRoles(string email)
        {
            return _db.Query<User>().Where(u => u.Email == email).SelectMany(u => u.UserRoles.Select(ur => ur.Role.Name)).ToArray();
        }
    }
}
