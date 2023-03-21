using FurnitureShop.Core.Services;
using FurnitureShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FurnitureShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly SharedService _sharedService;

        public HomeController(SharedService sharedService)
        {
            _sharedService = sharedService;
        }

        public IActionResult Index()
        {
            _sharedService.GetFurnitureByFilter();
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
    }
}