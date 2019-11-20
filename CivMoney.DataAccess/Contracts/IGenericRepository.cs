using CivMoney.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace CivMoney.DataAccess.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        void Delete(IEnumerable<TEntity> entitiesToDelete);
        void Update(TEntity entityToUpdate);
        void Update(IEnumerable<TEntity> entitiesToUpdate);
    }
}