using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CivMoney.DataAccess.Mocks
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Transaction> TransactionsRepository { get; }
        public List<Transaction> Transaction { get; }

        public MockUnitOfWork(List<Transaction> transactions)
        {
            Transaction = transactions;

            TransactionsRepository = new MockGenericRepository<Transaction>(transactions);
        }

        public void Save()
        {
        }

        public Task SaveAsync()
        {
            return Task.CompletedTask;
        }
    }
}
