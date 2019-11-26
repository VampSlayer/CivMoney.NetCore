using System.Threading.Tasks;
using CivMoney.DataAccess.Models;
using CivMoney.Services.Dtos;

namespace CivMoney.Services.Contracts
{
    public interface IUserHelper
    {
        int GetCountOfUsers();
        Task<UserDto> GetCurrentUserExternal();
        Task<ApplicationUser> GetCurrentUser();
        Task LogoutCurrentUser();
        Task CreateOrFindAndLoginUser(string idToken);
        Task ChangeUserCurrency(string currency);
    }
}
