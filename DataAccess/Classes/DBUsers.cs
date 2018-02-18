using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    internal class DBUsers : IDBUsers
    {
        #region Singleton instance
        private static DBUsers _instance = null;
        private static UserManager<AppUser> _userManager;


        private DBUsers(UserManager<AppUser> manager)
        {
            _userManager = manager;
        }

        internal static IDBCustomers GetInstance()
        {
            throw new NotImplementedException();
        }

        public static DBUsers GetInstance(UserManager<AppUser> manager)
        {
            if (_instance == null)
            {
                _instance = new DBUsers(manager);
            }
            else
            {
                //_userManager is injected at the controller level and is brought here to work.
                //After the controller is disposed the object _userManager is disposed too. 
                //In subsequent api calls that re create the controller object we need to assign it here again.
                _userManager = manager;
            }

            return _instance;
        }
        #endregion

        public async Task<IdentityResult> RegisterUser(AppUser user, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password);
                return result;
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
                return await _userManager.FindByNameAsync(userName);
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
                return await _userManager.CheckPasswordAsync(userToVerify, password);
            }
            catch
            {
                throw;
            }
        }
    }
}
