using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using LearningMVC.Models;

namespace LearningMVC.Security
{
    public class UserStore : IUserStore<UserModel>, IUserRoleStore<UserModel>
    {


        public Task AddToRoleAsync(UserModel user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(UserModel user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(UserModel user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}