using System.Net;
using System.Net.Mail;
using WebApp.Observer.Models;

namespace WebApp.Observer.Observers
{
    public class UserObserverSendEmail : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendEmail(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();

            
            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("from@domain.com");

            mailMessage.To.Add(new MailAddress("to@domain.com"));

            mailMessage.Subject = "Hoşgeldiniz";

            mailMessage.Body = "<p>Sitemizin genel kuralları... böyle böyle... şöyle şöyle...</p>";

            mailMessage.IsBodyHtml = true;

            
            var smtpClient = new SmtpClient("smtp.domain.com");

            smtpClient.Port = 587;

            smtpClient.Credentials = new NetworkCredential("user@domain.com", "Password12*");

            smtpClient.Send(mailMessage);


            logger.LogInformation($"email send to user : {appUser.UserName}");
        }
    }
}
