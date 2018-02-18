using BusinessLogic;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace NET_Core_Seed
{
    public static class Business
    {
        private static LogicFactory _bus = new LogicFactory();
        public static ILogicUsers UsersLogic(UserManager<AppUser> manager)
        {
            return  _bus.getUsersLogic(manager);
        }

        public static ILogicCustomers CustomersLogic()
        {
           return _bus.getCustomersLogic();
        }

        public static ILogicProviders ProvidersLogic()
        {
            return _bus.getProvidersLogic();
        }
    }
}
