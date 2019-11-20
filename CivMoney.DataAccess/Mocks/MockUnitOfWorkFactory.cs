using CivMoney.DataAccess.Models;
using System.Collections.Generic;

namespace CivMoney.DataAccess.Mocks
{
    public static class MockUnitOfWorkFactory
    {
        public static MockUnitOfWork CreateMockUnitOfWork()
        {
            var transactions = new List<Transaction>();

            return new MockUnitOfWork(transactions);
        }
    }
}
