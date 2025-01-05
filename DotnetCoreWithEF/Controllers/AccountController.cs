using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;
using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreWithEF.Controllers
{
    public class AccountController : Controller
    {

        public readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }



        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(model);
                if (!result.Succeeded)
                {
                    foreach (var errors in result.Errors)
                    {
                        ModelState.AddModelError("", errors.Description);

                    }
                    return View(model);
                }
                ModelState.Clear();

            }
            return View();
        }



        [Route("signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var result=await _accountRepository.SignIn(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");                
                }
                ModelState.AddModelError("","Invalid credentials");

            }
            return View(model);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.Logout();
            return RedirectToAction("index","home");
        }
    }
}

