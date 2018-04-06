using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DemoWebApi.Repository
{
    public interface IGenericInterface<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        void Update(int id, TEntity entity);
        Task<int> SaveAsync();
        int Save();
    }

    public class GenericRepository<TEntity> : IGenericInterface<TEntity>, IDisposable where TEntity : class
    {
        public DbContext Context;
        public DbSet<TEntity> DbSet;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get()
        {
            return DbSet;
        }

        public virtual TEntity Get(int id)
        {
            return DbSet.Find(id);
        }
        
        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(int id, TEntity entity)
        {
            //_dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        
        public string GetPrimaryKey()
        {
            var keyName = Context.Model
                .FindEntityType(typeof(TEntity))
                .FindPrimaryKey()
                .Properties
                .Select(x => x.Name).Single();

            return keyName;
        }

        public int GetPrimaryKeyValue(TEntity entity)
        {
            var keyName = GetPrimaryKey();
            var propertyInfo = entity.GetType().GetProperty(keyName);
            if (propertyInfo == null) return 0;
            return (int)propertyInfo.GetValue(entity, null);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

    }
}