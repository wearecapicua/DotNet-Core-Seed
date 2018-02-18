using BusinessLogic.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    internal class LogicUsers : ILogicUsers
    {
        #region Singleton instance
        private static LogicUsers _instance = null;
        private static UserManager<AppUser> _userManager;


        private LogicUsers(UserManager<AppUser> manager)
        {
            _userManager = manager;
        }

        public static LogicUsers GetInstance(UserManager<AppUser> manager)
        {
            if (_instance == null)
            {
                _instance = new LogicUsers(manager);
            }
            else
            {
                _userManager = manager;
            }

            return _instance;
        }
        #endregion

        public async Task<IdentityResult> RegisterUser(AppUser user, string password)
        {
            try
            {
                return await GetRepo.UsersRepo(_userManager).RegisterUser(user, password);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            try
            {
                return await GetRepo.UsersRepo(_userManager).FindByNameAsync(userName);
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> CheckPasswordAsync(AppUser userToVerify, string password)
        {
            try
            {
                return await GetRepo.UsersRepo(_userManager).CheckPasswordAsync(userToVerify, password);
            }
            catch
            {
                throw;
            }
        }
    }
}
