using CivMoney.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CivMoney.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Currency { get; set; }
        public string Name { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
