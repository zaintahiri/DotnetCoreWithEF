using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreWithEF.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel model)
        {
            var identityUser = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email=model.Email,
                UserName=model.Email
            };
            var result = await _userManager.CreateAsync(identityUser, model.Password);
            return result;
        }

        public async Task<SignInResult> SignIn(SignInModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            return result;
        }

        public async Task Logout()
        { 
            await _signInManager.SignOutAsync();
        }


    }
}
