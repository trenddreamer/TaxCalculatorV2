using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxCalculator.Models.Entities;
using TaxCalculator.Repository.IRepository;

namespace TaxCalculator.Controllers.TaxWeb
{
    public class TaxWebController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaxWebController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var postalcode = await _unitOfWork.PostalCode.GetAllAsync(BaseUrl.APIBaseUrl + "api/TaxData", HttpContext.Session.GetString("JWToken"));
            ViewData["PostalCode"] = new SelectList(postalcode, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TaxResult model)
        {
            if (ModelState.IsValid)
            {
                var success = await _unitOfWork.TaxResult.CreateAsync(BaseUrl.APIBaseUrl + "api/taxdata/", model, HttpContext.Session.GetString("JWToken"));
                if (success)
                    TempData["Msg"] = "success";
                else
                    TempData["Msg"] = "error";
                return RedirectToAction("Index", "TaxWeb");
            }
            return View(model);
        }

    }
}
