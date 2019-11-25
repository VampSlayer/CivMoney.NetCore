using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CivMoney.DataAccess.Contracts;
using CivMoney.Services.Contracts;
using CivMoney.Services.Dtos;

namespace CivMoney.Services
{
    public class TotalsService
    {
        private readonly IUserHelper _userHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TotalsService(IUserHelper userHelper, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userHelper = userHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<object>> GetYearlyTotals()
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id)
                .GroupBy(x => x.Date.Year)
                .Select(g => new
                {
                    Amount = g.Sum(a => a.Amount),
                    Year = g.Key
                });
        }

        public async Task<IEnumerable<TransactionDto>> GetDailyTotalsForMonth(int year, int month)
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id && x.Date.Year == year && x.Date.Month == month)
                .GroupBy(x => x.Date.Day)
                .Select(g => new TransactionDto
                {
                    Amount = g.Sum(a => a.Amount),
                    Date = new DateTime(year, month, g.Key)
                });
        }

        public async Task<IEnumerable<object>> GetMonthlyTotalsForYear(int year)
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id && x.Date.Year == year)
                .GroupBy(x => x.Date.Month)
                .Select(g => new
                {
                    Amount = g.Sum(a => a.Amount),
                    Month = g.Key,
                    Year = year
                });
        }

        public async Task<IEnumerable<object>> GetMonthTotalsGroupedByDescription(int year, int month)
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id && x.Date.Year == year && x.Date.Month == month)
                .GroupBy(x => x.Description)
                .Select(g => new
                {
                    Amount = Math.Round(g.Sum(a => a.Amount), 2),
                    Description = g.Key,
                    Year = year,
                    Month = month
                });
        }
    }
}
