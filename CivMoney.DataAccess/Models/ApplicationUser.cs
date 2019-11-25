using Microsoft.AspNetCore.Identity;

namespace CivMoney.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Currency { get; set; }
        public string Name { get; set; }
    }
}
