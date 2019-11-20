using System;

namespace CivMoney.Services
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
