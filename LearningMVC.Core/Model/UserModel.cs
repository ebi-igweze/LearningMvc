using LearningMVC.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMVC.Core.Model
{
    public class UserModel
    {
        public int UserID { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public string[] Roles { get; set; }

        public UserModel()
        {

        }
        public UserModel(User user)
        {
            UserID = user.UserID;
            Email = user.Email;
            Password = user.Password;
        }
    }
}
