using DotnetCoreWithEF.Data;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreWithEF.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel model)
        {
            var identityUser = new IdentityUser 
            {
                Email=model.Email,
                UserName=model.Email
            };
            var result = await _userManager.CreateAsync(identityUser, model.Password);
            return result;
        }

        
    }
}
