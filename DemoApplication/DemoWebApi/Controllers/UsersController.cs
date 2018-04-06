using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoWebApi.Infrastructure;

namespace DemoWebApi.Controllers
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// List of Users
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var db = new MyDbContext();
            var users = db.Users.ToList();
            return Ok(users);
        }
    }
}
