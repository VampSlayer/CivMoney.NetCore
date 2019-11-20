using Microsoft.EntityFrameworkCore;

namespace CivMoney.DataAccess.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        bool IsDetached(object entity);
        void SetModified(object entity);
    }
}
