using DataAccess;
using DataAccess.Classes;
using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity;
using Providers;
using Providers.Services;

namespace BusinessLogic
{
    internal static class GetRepo
    {
        private static Factory _dataFactory = new Factory();
        private static ProvidersFactory _providersFactory = new ProvidersFactory();


        public static IDBUsers UsersRepo(UserManager<AppUser> manager)
        {
            return _dataFactory.getUsersRepository(manager);
        }

        public static IDBCustomers CustomersRepo()
        {
            return _dataFactory.getCustomersRepository();
        }

        public static IEmailService EmailService()
        {
            return _providersFactory.getEmailService();
        }
    }
}
