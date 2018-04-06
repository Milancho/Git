using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Repository
{
    public interface IUsersRepository : IGenericInterface<Users>
    {
    }

    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}