using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity;
using Providers.Services;

namespace BusinessLogic
{
    public class LogicFactory
    {
        public ILogicUsers getUsersLogic(UserManager<AppUser> manager)
        {
            return (LogicUsers.GetInstance(manager));
        }

        public ILogicCustomers getCustomersLogic()
        {
            return (LogicCustomers.GetInstance());
        }

        public ILogicProviders getProvidersLogic()
        {
            return (LogicProviders.GetInstance());
        }
    }
}
