using AutoMapper;
using FurnitureShop.Core.Models;
using FurnitureShop.Core.Services;
using FurnitureShop.WebUI.Models;
using FurnitureShop.WebUI.Models.DTO;
using FurnitureShop.WebUI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FurnitureShop.WebUI.Controllers
{
    public class ViewsController : Controller
    {

        private readonly SharedService _sharedService;
        private readonly IMapper _mapper;
        public ViewsController(SharedService sharedService, IMapper mapper)
        {
            _sharedService = sharedService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var rawlist = _sharedService.GetFurnitureByFilter();
            var mapedlist = _mapper.Map<IEnumerable<Furniture>, IEnumerable<FurnitureIndexVM>>(rawlist);
            return View(mapedlist);
        }

        public IActionResult FurniturePage(FurniturePageDTO dto)
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
