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
        private readonly IMspCloudService _mspCloudService;

        public HomeController(IMspCloudService mspCloudService)
        {
            this._mspCloudService = mspCloudService;
        }
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
            await _mspCloudService.SendEmail(model);
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