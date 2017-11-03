using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MSPCloudSite.Models;

namespace MSPCloudSite.Services
{
    public interface IMspCloudService
    {
        Task SendEmail(MailModel model);
    }
}