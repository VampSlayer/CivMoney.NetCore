using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using CivMoney.Services;
using CivMoney.Services.Contracts;

namespace CivMoney.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserHelper _userHelper;

        public AuthenticationController( IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromQuery(Name = "id_token")] string idToken)
        {
            try
            {
                await _userHelper.CreateOrFindAndLoginUser(idToken);

                return NoContent();
            }
            catch (InvalidJwtException)
            {
                return Unauthorized();
            }
            catch(UserCreationException)
            {
                return BadRequest("User failed to be created");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutCurrentUser();

            return NoContent();
        }
    }
}