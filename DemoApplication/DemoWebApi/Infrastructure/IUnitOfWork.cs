using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DemoWebApi.Repository;

namespace DemoWebApi.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository UsersRepository { get; }

        void Save();
        Task<int> SaveAsync();
    }
}