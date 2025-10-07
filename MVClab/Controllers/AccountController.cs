using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVClab.Models;
using MVClab.ViewModels;

namespace MVClab.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> UserManager,SignInManager<ApplicationUser> SignInManager)
        {
            this.userManager = UserManager;
            this.signInManager = SignInManager;
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterVM UserViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser();
                appUser.Adress = UserViewModel.Address;
                appUser.UserName = UserViewModel.UserName;
                appUser.PasswordHash = UserViewModel.Password;
                IdentityResult result =  await userManager.CreateAsync(appUser);
                if (result.Succeeded) 
                {
                    //cookie
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "Department");                
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                
            }
            return View("Register",UserViewModel);
        }
    }
}
