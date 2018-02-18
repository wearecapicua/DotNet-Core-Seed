using BusinessLogic.Interfaces;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    internal class LogicProviders : ILogicProviders
    {
        #region Singleton instance
        private static LogicProviders _instance = null;


        private LogicProviders()
        {
        }

        public static LogicProviders GetInstance()
        {
            return _instance ?? (_instance = new LogicProviders());
        }
        #endregion

        public async Task<int> SendEmail()
        {
            try
            {
                return await GetRepo.EmailService().SendEmail();
            }
            catch
            {
                throw;
            }

        }
    }
}
