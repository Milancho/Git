using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Micro.Controllers;

namespace Micro.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MicroControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
