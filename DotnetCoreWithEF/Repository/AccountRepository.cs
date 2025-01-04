using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreWithEF.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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

        
    }
}
