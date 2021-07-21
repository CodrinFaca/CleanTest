using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanTest.Application.Interfaces;
using CleanTest.Web.Areas.Account.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTest.Web.Controllers
{
    [Area("Account")]
    public class AccountsController : Controller
    {
        private readonly IIdentityService _identityService;
        public AccountsController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.PasswordSignInAsync(vm.UserName, vm.Password);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Dashboard", new { area = "Dashboard" });

                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(vm);
        }
    }
}