using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoWebApi.Infrastructure;
using DemoWebApi.Services;

namespace DemoWebApi.Controllers
{
    public class UsersController : GenericController
    {
        private readonly UsersService _usersService;
        public UsersController()
        {
            _usersService = new UsersService();
        }

        /// <summary>
        /// List of Users
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            return Ok(_usersService.Get());
        }
    }
}
