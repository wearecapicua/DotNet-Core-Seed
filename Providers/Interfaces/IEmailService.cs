using System.Threading.Tasks;

namespace Providers.Services
{
    public interface IEmailService
    {
        Task<int> SendEmail();
    }
}