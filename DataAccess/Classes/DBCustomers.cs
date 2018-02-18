using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    internal class DBCustomers : IDBCustomers
    {
        #region Singleton instance
        private static DBCustomers _instance = null;

        private DBCustomers()
        {
        }

        public static DBCustomers GetInstance()
        {
            return _instance ?? (_instance = new DBCustomers());
        }
        #endregion

        public async Task<int> RegisterCustomer(Customer user)
        {
            try
            {
                AppContextFactory factory = new AppContextFactory();

                using (ApplicationDbContext context = factory.CreateDbContext(null))
                {
                    await context.Customers.AddAsync(user);
                    return await context.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }

        }


        public async Task<Customer> GetCustomer(string userId)
        {
            try
            {
                AppContextFactory factory = new AppContextFactory();
                    using (ApplicationDbContext context = factory.CreateDbContext(null))
                {
                    return await context.Customers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == Convert.ToString(userId));
                }
            }
            catch
            {
                throw;
            }

        }
    }
}
