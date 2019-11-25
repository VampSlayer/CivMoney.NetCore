using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CivMoney.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity 
    {
        internal IApplicationDbContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(IApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity Find(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Delete(int id)
        {
            var entityToDelete = Find(id);

            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.IsDetached(entityToDelete))
            {
                DbSet.Attach(entityToDelete);
            }

            DbSet.Remove(entityToDelete);
        }

        public virtual void Delete(IEnumerable<TEntity> entitiesToDelete)
        {
            if (Context.IsDetached(entitiesToDelete))
            {
                DbSet.AttachRange(entitiesToDelete);
            }

            DbSet.RemoveRange(entitiesToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);

            Context.SetModified(entityToUpdate);
        }

        public virtual void Update(IEnumerable<TEntity> entitiesToUpdate)
        {
            DbSet.AttachRange(entitiesToUpdate);

            Context.SetModified(entitiesToUpdate);
        }
    }
}
