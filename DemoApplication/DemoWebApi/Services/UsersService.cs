using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoWebApi.Models;

namespace DemoWebApi.Services
{
    public interface IUsersService : IGenerricService<Users>
    {
    }

    public class UsersService : GenericService<Users>, IUsersService
    {
        public override IEnumerable<Users> Get()
        {
            return UnitOfWork.UsersRepository.Get();
        }
    }
}