using System.Collections.Generic;
using System.Threading.Tasks;
using CivMoney.Services.Dtos;

namespace CivMoney.Services.Contracts
{
    public interface ITotalsService
    {
        Task<IEnumerable<object>> GetYearlyTotals();
        Task<IEnumerable<TransactionDto>> GetDailyTotalsForMonth(int year, int month);
        Task<IEnumerable<object>> GetMonthlyTotalsForYear(int year);
        Task<IEnumerable<object>> GetMonthTotalsGroupedByDescription(int year, int month);
    }
}
