using CivMoney.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace CivMoney.Controllers
{
    [Route("api/[Action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async System.Threading.Tasks.Task<IActionResult> LoginAsync([FromQuery]string id_token)
        {
            try
            {
                var validPayload = await GoogleJsonWebSignature.ValidateAsync(id_token);

                var user = await _userManager.FindByEmailAsync(validPayload.Email);

                if (user != null) {

                    await _signInManager.SignInAsync(user, true);
                    return NoContent();
                }

                var newUser = new ApplicationUser
                {
                    EmailConfirmed = true,
                    Email = validPayload.Email,
                    UserName = validPayload.Name.Replace(' ', '_'),
                    Name = validPayload.Name,
                    Currency = "$"
                };

                var userCreate = await _userManager.CreateAsync(newUser);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, newUser.Email),
                        new Claim(ClaimTypes.Name, newUser.Name),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    };

                //var claimsIdentity = new ClaimsIdentity(
                 //   claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsAdd = await _userManager.AddClaimsAsync(newUser,claims);

                //var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(newUser);

                await _signInManager.SignInAsync(newUser, true);

                ///_signInManager.

                //await HttpContext.SignInAsync(
                //   CookieAuthenticationDefaults.AuthenticationScheme,
                //  claimsPrincipal);
                return NoContent();
            }
            catch (InvalidJwtException)
            {
                return Unauthorized();
            }
        }

        public IActionResult Logout()
        {
            return Ok("logout");
        }
    }
}