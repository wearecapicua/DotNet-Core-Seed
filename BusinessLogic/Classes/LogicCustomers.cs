using BusinessLogic.Interfaces;
using Entities;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    internal class LogicCustomers : ILogicCustomers
    {
        #region Singleton instance
        private static LogicCustomers _instance = null;


        private LogicCustomers()
        {
        }

        public static LogicCustomers GetInstance()
        {
            return _instance ?? (_instance = new LogicCustomers());
        }
        #endregion


        public async Task<int> RegisterCustomer(Customer user)
        {
            try
            {
                return await GetRepo.CustomersRepo().RegisterCustomer(user);
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
                return await GetRepo.CustomersRepo().GetCustomer(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}