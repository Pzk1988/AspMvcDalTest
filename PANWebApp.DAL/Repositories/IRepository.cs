using System.Collections.Generic;
using PANWebApp.DAL.DbModels;

namespace PANWebApp.DAL.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey id);
    }
}