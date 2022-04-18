using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public class EmailProcessHandler : ProcessHandler
    {
        private readonly string _fileName;
        private readonly string _mailTo;

        public EmailProcessHandler(string fileName, string mailTo)
        {
            _fileName = fileName;
            _mailTo = mailTo;
        }

        public override object handle(object o)
        {
            var zipMemoryStream = o as MemoryStream;
            zipMemoryStream.Position = 0;


            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("from@domain.com");

            mailMessage.To.Add(new MailAddress(_mailTo));

            mailMessage.Subject = "Zip Dosyası";

            mailMessage.Body = "<p>Zip dosyası ektedir.</p>";

            mailMessage.IsBodyHtml = true;


            Attachment attachment = new Attachment(zipMemoryStream, _fileName, MediaTypeNames.Application.Zip);

            mailMessage.Attachments.Add(attachment);


            var smtpClient = new SmtpClient("smtp.domain.com");

            smtpClient.Port = 587;

            smtpClient.Credentials = new NetworkCredential("user@domain.com", "Password12*");

            smtpClient.Send(mailMessage);


            return base.handle(null);
        }
    }
}
