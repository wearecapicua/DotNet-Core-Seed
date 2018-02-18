using Entities;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public interface IDBCustomers
    {
        Task<int> RegisterCustomer(Customer user);
        Task<Customer> GetCustomer(string userId);

    }
}