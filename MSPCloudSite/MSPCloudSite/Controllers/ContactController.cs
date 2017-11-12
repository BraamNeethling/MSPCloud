using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MSPCloudSite.Models;
using MSPCloudSite.Services;

namespace MSPCloudSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMailerService _mailerService;

        public ContactController(IMailerService mailerService)
        {
            this._mailerService = mailerService;
        }
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        public async Task SendEmail(MailViewModel viewModel)
        {
            await _mailerService.SendEmail(viewModel);
        }
    }
}