using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DemoWebApi.Repository;

namespace DemoWebApi.Infrastructure
{
    public class MyUnitOfWork : IUnitOfWork
    {
        public readonly MyDbContext Context;

        public MyUnitOfWork()
        {
            Context = new MyDbContext();
        }

        private IUsersRepository _usersRepository;
        public IUsersRepository UsersRepository => _usersRepository ?? (_usersRepository = new UsersRepository(Context));
        
        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}