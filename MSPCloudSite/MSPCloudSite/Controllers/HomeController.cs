using System.Net.Mail;
using System.Web.Mvc;
using MSPCloudSite.Models;
using System.Net.Mime;
using System.Threading.Tasks;
using MSPCloudSite.Services;

namespace MSPCloudSite.Controllers
{ 
   
    public class HomeController : Controller
    {
        private readonly IMailerService _mailerService;

        public HomeController(IMailerService mailerService)
        {
            this._mailerService = mailerService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public async Task SendEmail(MailViewModel viewModel)
        {
            await _mailerService.SendEmail(viewModel);
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