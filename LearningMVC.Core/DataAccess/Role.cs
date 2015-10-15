using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMVC.Core.DataAccess
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }
}
