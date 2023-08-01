using Azure.Core;
using Domain.Entity;
using EmployeeManagment.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.seed;

namespace EmployeeManagment.Controllers
{
    public class AccountsController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountsController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,SeedData seedData)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            //seedData.SeedAdminUser();

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
     
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
          public async Task< IActionResult> Login(LoginViewModel loginViewModel)
          {
            if(ModelState.IsValid)
            {
                var result= await signInManager.PasswordSignInAsync(loginViewModel.Name,loginViewModel.Password,false,false);
                var user = await userManager.FindByNameAsync(loginViewModel.Name);

                if (result.Succeeded)
                {

                 return RedirectToAction("GetAllEmployee", "Employee");

                }
              
            }
            ViewBag.errormessage = false;
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");
            return RedirectToAction("Login", "Accounts");
        }

    }
}
