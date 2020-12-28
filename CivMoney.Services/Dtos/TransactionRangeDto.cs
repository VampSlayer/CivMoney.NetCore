using System;

namespace CivMoney.Services.Dtos
{
    public class TransactionRangeDto
    {
        public int Delete { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
