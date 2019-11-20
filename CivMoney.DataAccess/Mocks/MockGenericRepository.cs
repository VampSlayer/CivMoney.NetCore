using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace CivMoney.DataAccess.Mocks
{
    public class MockGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly List<TEntity> _entities;

        public MockGenericRepository(List<TEntity> entities)
        {
            _entities = entities;
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Delete(int id)
        {
            var entity = Find(id);

            Delete(entity);
        }

        public void Delete(TEntity entityToDelete)
        {
            _entities.Remove(entityToDelete);
        }

        public void Delete(IEnumerable<TEntity> entitiesToDelete)
        {
            foreach (var entityToDelete in entitiesToDelete)
            {
                Delete(entityToDelete);
            }
        }

        public TEntity Find(int id)
        {
            return _entities.First(x => x.Id == id); 
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public void Update(TEntity entityToUpdate)
        {
            var entity = Find(entityToUpdate.Id);

            Delete(entity);

            Add(entityToUpdate);
        }

        public void Update(IEnumerable<TEntity> entitiesToUpdate)
        {
            foreach (var entityToUpdate in entitiesToUpdate)
            {
                Update(entityToUpdate);
            }
        }
    }
}
