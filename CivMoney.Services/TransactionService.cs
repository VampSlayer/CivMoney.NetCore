using AutoMapper;
using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using CivMoney.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivMoney.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddTransaction(TransactionDto transactionDto)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.User = user;

            _unitOfWork.TransactionsRespository.Add(transaction);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactionsForDate(DateTime date)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            return _unitOfWork.TransactionsRespository.GetAll()
                .Where(x => x.UserId == user.Id && x.Date.Date == date.Date)
                .Select(x => _mapper.Map<TransactionDto>(x));
        }
    }
}
