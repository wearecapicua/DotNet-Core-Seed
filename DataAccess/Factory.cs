using DataAccess.Classes;
using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class Factory
    {
        public IDBUsers getUsersRepository(UserManager<AppUser> manager)
        {
            return (DBUsers.GetInstance(manager));
        }

        public IDBCustomers getCustomersRepository()
        {
            return (DBCustomers.GetInstance());
        }

    }
}
