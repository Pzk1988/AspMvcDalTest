using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PANWebApp.DAL.DbModels;

namespace PANWebApp.DAL.Repositories
{
    internal abstract class RepositoryBase<TEntity> 
        : IRepository<TEntity, Guid> 
        where TEntity : EntityBase
    {
        protected LibraryContext Context;

        protected RepositoryBase()
        {
            Context = new LibraryContext();
        }

        protected RepositoryBase(LibraryContext context)
        {
            Context = context;
        }

        public TEntity Get(Guid id)
        {
           return Context.Set<TEntity>().SingleOrDefault(_ => _.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().Select(_ => _);
        }

        public void Save(TEntity entity)
        {
            Context.Set<TEntity>().AddOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete(Guid id)
        {
            Context.Set<TEntity>().Remove(Get(id));
        }
    }
}
