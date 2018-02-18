using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ILogicProviders
    {
        Task<int> SendEmail();
    }
}