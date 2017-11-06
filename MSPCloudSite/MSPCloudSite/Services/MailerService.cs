using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using MSPCloudSite.Models;

namespace MSPCloudSite.Services
{
    public class MailerService : IMailerService
    {
        public async Task SendEmail(MailViewModel viewModel)
        {
            var message = SetMailMessage(viewModel);
            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        private static MailMessage SetMailMessage(MailViewModel viewModel)
        {

            var message = new MailMessage();
            message.To.Add(new MailAddress("braamneethling1991@gmail.com"));
            message.From = new MailAddress("braamneethling1991@gmail.com");
            message.Subject = "Client Request" + " from " + viewModel.FromName;
            message.IsBodyHtml = true;
            var htmlView = SetEmailLogo(viewModel);
            message.AlternateViews.Add(htmlView);

            return message;
        }

        private static AlternateView SetEmailLogo(MailViewModel viewModel)
        {
            var linkedImage =
                new LinkedResource(
                    @"C:\Users\braam\Documents\MSPCloud\MSPCloudSite\MSPCloudSite\Resources\MSPCloud Logojpeg.jpg")
                {
                    ContentId = "Logo",
                    ContentType = new ContentType(MediaTypeNames.Image.Jpeg)
                };

            var htmlView = AlternateView.CreateAlternateViewFromString(
                "<div>" +
                "<img src=cid:Logo><br/> " +
                "From Name :" + viewModel.FromName + "<br/>" +
                "From Email :" + viewModel.FromEmail + "<br/>" +
                "Message :" + viewModel.Message + "<br/>" +
                "Contact Number :" + viewModel.ContactNumber + "<br/>" +
                "</div>",
                null, "text/html");

            htmlView.LinkedResources.Add(linkedImage);
            return htmlView;
        }
    }
}