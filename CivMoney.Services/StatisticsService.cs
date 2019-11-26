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
    public class StatisticsService
    {
        private readonly IUserHelper _userHelper;
        private readonly IUnitOfWork _unitOfWork;

        public StatisticsService(IUserHelper userHelper, IUnitOfWork unitOfWork\)
        {
            _userHelper = userHelper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SpentSavedDto>> GetYearlySpentAndSaved()
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id)
                .GroupBy(x => x.Date.Year)
                .Select(g => new SpentSavedDto
                {
                    Spent = Math.Round(g.Where(x => x.Amount < 0).Sum(a => Math.Abs(a.Amount)), 2),
                    Saved = Math.Round(
                        g.Where(x => x.Amount > 0).Sum(a => a.Amount) -
                        g.Where(x => x.Amount < 0).Sum(a => Math.Abs(a.Amount)), 2),
                    Year = g.Key
                });
        }

        public async Task<IEnumerable<SpentSavedDto>> GetMonthlySpentAndSavedForYear(int year)
        {
            var user = await _userHelper.GetCurrentUser();

            return _unitOfWork.TransactionsRepository.GetAll()
                .Where(x => x.UserId == user.Id && x.Date.Date.Year == year)
                .GroupBy(x => x.Date.Month)
                .Select(g => new SpentSavedDto
                {
                    Spent = Math.Round(g.Where(a => a.Amount < 0).Sum(a => Math.Abs(a.Amount)), 2),
                    Saved = Math.Round(
                        g.Where(a => a.Amount > 0).Sum(a => a.Amount) -
                        g.Where(a => a.Amount < 0).Sum(a => Math.Abs(a.Amount)), 2),
                    Year = year,
                    Month = g.Key
                });
        }
    }
}
