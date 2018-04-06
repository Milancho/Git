using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoWebApi.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DemoWebApi.Services
{
    public interface IGenerricService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
    }

    public class GenericService<TEntity> : IGenerricService<TEntity>, IDisposable where TEntity : class
    {
        public IUnitOfWork UnitOfWork;

        public GenericService()
        {
            UnitOfWork = new MyUnitOfWork();
        }
        
        public void Dispose()
        {
        }

        public virtual IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }
    }
}