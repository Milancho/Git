using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Micro.Controllers;

namespace Micro.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MicroControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
