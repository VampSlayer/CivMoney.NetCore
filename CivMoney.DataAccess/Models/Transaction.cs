using System;

namespace CivMoney.DataAccess.Models
{
    public class Transaction : Entity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
