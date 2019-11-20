using CivMoney.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CivMoney.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsForDate(DateTime date);
        Task AddTransaction(TransactionDto transactionDto);
    }
}
