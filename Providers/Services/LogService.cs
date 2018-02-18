using Newtonsoft.Json;
using Providers.Interfaces;
using Providers.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Services
{
    public class LogService : ILogService
    {
        #region Singleton instance
        private static LogService _instance = null;


        private LogService()
        {
        }

        public static LogService GetInstance()
        {
            return _instance ?? (_instance = new LogService());
        }
        #endregion

        private static readonly HttpClient client = new HttpClient();

        public async Task LogError(Exception ex)
        {
            try
            {
                string LogglyUrlToken = Configuration.GetSection("Loggly:ApiKey");

                ExceptionError e = new ExceptionError();
                e.Date = DateTime.Now;
                e.Message = ex.Message;
                e.StackTrace = ex.StackTrace;
                e.InnerException = (ex.InnerException != null) ? ex.InnerException.Message : "";
                e.Source = ex.Source;

                var jsonInString=  JsonConvert.SerializeObject(e);
                var response = await client.PostAsync(LogglyUrlToken, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

                var responseString = await response.Content.ReadAsStringAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
