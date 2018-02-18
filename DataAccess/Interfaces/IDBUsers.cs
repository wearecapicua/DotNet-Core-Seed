using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDBUsers
    {
        Task<IdentityResult> RegisterUser(AppUser user, string password);
        Task<AppUser> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(AppUser userToVerify, string password);
    }
}
