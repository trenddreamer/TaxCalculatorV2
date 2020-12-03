﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using TaxCalculator.Models;
using TaxCalculator.Models.Entities;
using TaxCalculator.Models.Users;
using TaxCalculator.Repository.IRepository;

namespace TaxCalculator.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static string APIBaseUrl = "https://localhost:44349/";

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index()
        {
            var postalcode = await _unitOfWork.PostalCode.GetAllAsync(APIBaseUrl +"api/TaxData",HttpContext.Session.GetString("JWToken"));
            ViewData["PostalCode"] = new SelectList(postalcode, "Id", "Description");
            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TaxResult model)
        {
            if (ModelState.IsValid)
            {
                var success = await _unitOfWork.TaxResult.CreateAsync(APIBaseUrl + "api/taxdata/",model, HttpContext.Session.GetString("JWToken"));
                if (success)
                    TempData["Msg"] = "success";
                else
                    TempData["Msg"] = "error";
                return RedirectToAction("index","home");
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            User obj = new User();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User obj)
        {
            User objUser = await _unitOfWork.Account.LoginAsync(APIBaseUrl + "api/Users/authenticate/", obj);
            if (objUser.Token == null)
            {
                return View();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, objUser.Username));
            identity.AddClaim(new Claim(ClaimTypes.Role, objUser.Role));
            var principal = new ClaimsPrincipal(identity);
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            HttpContext.Session.SetString("JWToken", objUser.Token);
            TempData["alert"] = "Welcome " + objUser.Username;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User obj)
        {
            bool result = await _unitOfWork.Account.RegisterAsync(APIBaseUrl + "api/Users/register/", obj);
            if (result == false)
            {
                return View();
            }
            TempData["alert"] = "Registeration Successful";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
           // await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JWToken", "");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}