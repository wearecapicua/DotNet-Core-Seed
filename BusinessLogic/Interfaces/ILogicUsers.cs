using Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ILogicUsers
    {
        Task<IdentityResult> RegisterUser( AppUser user, string password);
        Task<AppUser> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(AppUser userToVerify, string password);
    }
}
