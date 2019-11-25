using CivMoney.DataAccess.Models;
using System.Threading.Tasks;

namespace CivMoney.DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<Transaction> TransactionsRepository { get; }
        public void Save();
        public Task SaveAsync();
    }
}
