using DotnetCoreWithEF.Data;
using Microsoft.AspNetCore.Identity;

namespace DotnetCoreWithEF.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel model);
    }
}