using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MSPCloudSite.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MSPCloudSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public async Task SendEmail(MailModel model)
        {
            const string body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("braamneethling1991@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("mcpcloud@support.co.za");  // replace with valid value
            message.Subject = "Client Interest";
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "braamneethling1991@gmail.com",  // replace with valid value
                    Password = "pangyman1234"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        public ActionResult MSPCloudServices()
        {
            return View();
        }
        public ActionResult PartnerServices()
        {
            return View();
        }
        public ActionResult Careers()
        {
            return View();
        }
        public ActionResult SupportContracts()
        {
            return View();
        }
        public ActionResult AdHocSupport()
        {
            return View();
        }
       
    }
}