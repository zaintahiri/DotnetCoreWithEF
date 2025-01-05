using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreWithEF.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel model);
        Task<SignInResult> SignIn(SignInModel model);
        Task Logout();
    }
}