using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Providers.Services
{
    public class EmailService : IEmailService
    {

        #region Singleton instance
        private static EmailService _instance = null;


        private EmailService()
        {
        }

        public static EmailService GetInstance()
        {
            return _instance ?? (_instance = new EmailService());
        }
        #endregion
        public async Task<int> SendEmail()
        {
            try
            {
                string apiKey = Configuration.GetSection("SendGrid:ApiKey");
                string idTemplate = Configuration.GetSection("SendGrid:DefaultTemplateId");

                ISendGridClient client = new SendGridClient(apiKey);
                SendGridMessage msg = new SendGridMessage();

                var from = Configuration.GetSection("SendGrid:FromEmail");
                var senderName = Configuration.GetSection("SendGrid:SenderName");
                msg.SetFrom(new EmailAddress(from, senderName));

                msg.SetSubject("" + ":");
                msg.AddTo(new EmailAddress("", ""));
                msg.SetTemplateId(idTemplate);

                //Substitute variables on your template if necessary.
                //msg.AddSubstitution("-CLIENT_NAME", "");
                Response response = await client.SendEmailAsync(msg);


                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}

