using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechTherapist.Web.Controllers
{
    [AllowAnonymous]
    public class UserPanelController : Controller
    {       
        public IActionResult Index()
        {
            ViewBag.IsUserPanelClicked = true;
            return View();
        }
    }
}
