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

    //TODO ask about needed atributes
    public class ApiController : Controller
    {
        private readonly SharedService _sharedService;
        private readonly IMapper _mapper;
        public ApiController(SharedService sharedService, IMapper mapper)
        {
            _sharedService = sharedService;
            _mapper = mapper;
        }

        public IEnumerable<FurnitureIndexVM> Index(IndexFilterDTO dto)
        {
            var rawlist = _sharedService.GetFurnitureByFilter(dto.skip ?? 0,
                                                              dto.take ?? 10,
                                                              (EnumCategory)(dto.category ?? 0),
                                                              dto.minPrice,
                                                              dto.maxPrice,
                                                              dto.containPart);
            var mapedlist = _mapper.Map<IEnumerable<Furniture>, IEnumerable<FurnitureIndexVM>>(rawlist);
            return mapedlist ;
        }

        [HttpPost]
        public IActionResult AddToBasket()
        {
            //_sharedService.AddToBasket()
            return Ok();
        }
        
    }
}