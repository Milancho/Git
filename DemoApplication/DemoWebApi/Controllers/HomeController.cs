﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class HomeController : ApiController
    {
        /// <summary>
        ///  Home
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            return Ok("Home");
        }
    }
}
