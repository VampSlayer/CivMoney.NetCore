using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CivMoney.DataAccess.Models;
using CivMoney.Services.Contracts;
using CivMoney.Services.Dtos;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CivMoney.Services
{
    public class UserHelper : IUserHelper
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserHelper(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public int GetCountOfUsers()
        {
            return _userManager.Users.Count();
        }

        public async Task<UserDto> GetCurrentUserExternal()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task ChangeUserCurrency(string currency)
        {
            var user = await GetCurrentUser();

            user.Currency = currency;

            await _userManager.UpdateAsync(user);
        }

        public async Task LogoutCurrentUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task CreateOrFindAndLoginUser(string idToken)
        {
            var validPayload = await GoogleJsonWebSignature.ValidateAsync(idToken);

            var user = await _userManager.FindByEmailAsync(validPayload.Email);

            if (user != null)
            {
                await _signInManager.SignInAsync(user, true);
            }

            var newUser = new ApplicationUser
            {
                EmailConfirmed = true,
                Email = validPayload.Email,
                UserName = validPayload.Name.Replace(' ', '_'),
                Name = validPayload.Name,
                Currency = "$"
            };

            var userCreated = await _userManager.CreateAsync(newUser);

            if (userCreated.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, true);
            }
            else
            {
                throw new UserCreationException();
            }
        }
    }

    public class UserCreationException : Exception
    {
        public UserCreationException()
        {
        }
    }
}
