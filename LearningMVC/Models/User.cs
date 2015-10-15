using LearningMVC.Core.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningMVC.Models
{
    public class User: UserModel, IUser<string>
    {
        public User()
        {

        }
        public User(UserModel model)
        {
            UserID = model.UserID;
            Email = model.Email;
            Password = model.Password;
        }

        [EmailAddress]
        public override string Email { get; set; }
        public bool RememberMe { get; set; }

        public string Id => UserID.ToString();
        public string UserName
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }
    }
}