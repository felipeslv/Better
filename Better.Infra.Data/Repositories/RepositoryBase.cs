using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Better.Domain.Interfaces.Repositories;
using Better.Infra.Data.Contexto;

namespace Better.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable , IRepositoryBase<TEntity> where TEntity : class
    {
        protected BetterContext Db = new BetterContext();
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
           return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
