using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningMVC.Models
{
    public class UserModel: IUser<string>
    {
        public int UserID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
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