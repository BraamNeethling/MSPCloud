﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MSPCloudSite.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
            var message = SetMailMessage(model);



            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        private static MailMessage SetMailMessage(MailModel model)
        {

            const string body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("braamneethling1991@gmail.com"));
            message.From = new MailAddress("braamneethling1991@gmail.com");
            message.Subject = "Client Interest";
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;

            var linkedImage =
                new LinkedResource(
                    @"C:\Users\braam\Documents\MSPCloud\MSPCloudSite\MSPCloudSite\Resources\MSPCloud Logojpeg.jpg")
                {
                    ContentId = "Logo",
                    ContentType = new ContentType(MediaTypeNames.Image.Jpeg)
                };
            //Added the patch for Thunderbird as suggested by Jorge

            var htmlView = AlternateView.CreateAlternateViewFromString(
                "<img src=cid:Logo><br/> " +
                "FromName :" + model.FromName + "<br/>" +
                "FromEmail :" + model.FromEmail + "<br/>" +
                "Message :" + model.Message + "<br/>",
                null, "text/html");

            htmlView.LinkedResources.Add(linkedImage);



            message.AlternateViews.Add(htmlView);

            return message;
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