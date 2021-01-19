using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult ShowPricing() => ViewComponent("PricingComponent", new { pricing = new PricingViewModel() });

        [HttpPost]
        public IActionResult ShowPricing(PricingViewModel pricing)
        {
            if (ModelState.IsValid)
            {
                int temp;
                if (!int.TryParse(pricing.colCode, out temp))
                {
                    ViewBag.isValid = 0;
                    ModelState.AddModelError("colCode", "Invalid Data");
                    return ViewComponent("PricingComponent", new { pricing = pricing }); // 1
                }
                else if (!int.TryParse(pricing.colName, out temp))
                {
                    ViewBag.isValid = 0;
                    ModelState.AddModelError("colName", "Invalid Data");
                    return ViewComponent("UpdatePricingComponent", new { pricing = pricing }); //2
                }
                else
                {
                    ViewBag.isValid = 1;

                    // do something ...

                    return ViewComponent("ShowPricingExcelComponent"); //Call another view component
                }
            }
            else
            {
                ViewBag.isValid = 0;
                return ViewComponent("UpdatePricingComponent", new { pricing = pricing }); //3
            }
        }
    }
}
