using System;

namespace CivMoney.Services.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
