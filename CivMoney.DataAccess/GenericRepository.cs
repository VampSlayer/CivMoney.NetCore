using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CivMoney.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity 
    {
        internal IApplicationDbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(IApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Delete(int id)
        {
            var entityToDelete = Find(id);

            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.IsDetached(entityToDelete))
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Delete(IEnumerable<TEntity> entitiesToDelete)
        {
            if (_context.IsDetached(entitiesToDelete))
            {
                _dbSet.AttachRange(entitiesToDelete);
            }

            _dbSet.RemoveRange(entitiesToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);

            _context.SetModified(entityToUpdate);
        }

        public virtual void Update(IEnumerable<TEntity> entitiesToUpdate)
        {
            _dbSet.AttachRange(entitiesToUpdate);

            _context.SetModified(entitiesToUpdate);
        }
    }
}
