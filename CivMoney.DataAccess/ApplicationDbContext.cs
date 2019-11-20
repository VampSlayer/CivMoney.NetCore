using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using CivMoney.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CivMoney.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public bool IsDetached(object entity)
        {
            return Entry(entity).State == EntityState.Detached;
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
