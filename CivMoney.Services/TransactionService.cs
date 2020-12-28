using AutoMapper;
using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivMoney.Services.Contracts;
using CivMoney.Services.Dtos;

namespace CivMoney.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUserHelper _userHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUserHelper userHelper, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userHelper = userHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsForDate(DateTime date)
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id && x.Date.Date == date.Date)
                .Select(x => _mapper.Map<TransactionDto>(x));
        }

        public async Task<IEnumerable<TransactionRangeDto>> GetTransactionsForRange(DateTime start, DateTime end)
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id && x.Date.Date >= start.Date && x.Date.Date <= end.Date)
                .OrderBy(x => x.Date)
                .Select(x => _mapper.Map<TransactionRangeDto>(x));
        }

        public async Task AddMonthlyFixedTransaction(TransactionDto monthlyTransaction)
        {
            var user = await _userHelper.GetCurrentUser();

            var transactions = new List<Transaction>();

            var numberOfDaysInMonth = DateTime.DaysInMonth(monthlyTransaction.Date.Year, monthlyTransaction.Date.Month);

            for (var i = 1; i <= numberOfDaysInMonth; i++)
            {
                transactions.Add(new Transaction
                {
                    Amount = monthlyTransaction.Amount / numberOfDaysInMonth,
                    Description = monthlyTransaction.Description,
                    Date = new DateTime(monthlyTransaction.Date.Year, monthlyTransaction.Date.Month, i),
                    User = user,
                    UserId = user.Id
                });
            }

            _unitOfWork.TransactionsRepository.Add(transactions);

            await _unitOfWork.SaveAsync();
        }

        public async Task AddTransaction(TransactionDto transactionDto)
        {
            var user = await _userHelper.GetCurrentUser();

            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.User = user;
            transaction.UserId = user.Id;

            _unitOfWork.TransactionsRepository.Add(transaction);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTransaction(int id)
        {
            var user = await _userHelper.GetCurrentUser();

            var transaction = _unitOfWork.TransactionsRepository.GetAll()
                .FirstOrDefault(x => x.UserId == user.Id && x.Id == id);

            _unitOfWork.TransactionsRepository.Delete(transaction);

            await _unitOfWork.SaveAsync();
        }
    }
}
