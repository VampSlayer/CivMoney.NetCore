using System.Threading.Tasks;
using CivMoney.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CivMoney.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserHelper _userHelper;

        public UserController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMe()
        {
            var user = await _userHelper.GetCurrentUserExternal();

            return Ok(user);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateMe([FromQuery] string currency)
        {
            await _userHelper.ChangeUserCurrency(currency);

            return NoContent();
        }
    }
} 