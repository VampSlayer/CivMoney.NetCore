﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CivMoney.Services.Dtos;

namespace CivMoney.Services.Contracts
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetTransactionsForDate(DateTime date);
        Task AddTransaction(TransactionDto transactionDto);
        Task<IEnumerable<TransactionDto>> GetTransactionsForRange(DateTime start, DateTime end);
        Task AddMonthlyFixedTransaction(TransactionDto monthlyTransaction);
        Task DeleteTransaction(int id);
    }
}
