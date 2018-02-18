using Providers.Interfaces;
using Providers.Services;

namespace Providers
{
    public class ProvidersFactory
    {
        public IEmailService getEmailService()
        {
            return (EmailService.GetInstance());
        }

        public ILogService getLogService()
        {
            return (LogService.GetInstance());
        }
    }
}
