using Entities;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ILogicCustomers
    {
        Task<int> RegisterCustomer(Customer user);
        Task<Customer> GetCustomer(string userId);
    }
}