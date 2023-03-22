using AutoMapper;
using FurnitureShop.Core.Models;
using FurnitureShop.Core.Services;
using FurnitureShop.WebUI.Models;
using FurnitureShop.WebUI.Models.DTO;
using FurnitureShop.WebUI.Models.VM;
using Microsoft.AspNetCore.Authorization;
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

        public IEnumerable<FurnitureVM> Index(IndexFilterDTO dto)
        {
            var rawlist = _sharedService.GetFurnitureByFilter(dto.skip ?? 0,
                                                              dto.take ?? 10,
                                                              (EnumCategory)(dto.category ?? 0),
                                                              dto.minPrice,
                                                              dto.maxPrice,
                                                              dto.containPart);
            var mapedlist = _mapper.Map<IEnumerable<Furniture>, IEnumerable<FurnitureVM>>(rawlist);
            return mapedlist ;
        }

        [HttpPost]
        //[Authorize]//feature for future identityserver4
        public IActionResult AddToBasket(Guid Id)
        {
            _sharedService.AddToBasket(Id, Guid.Empty);//With authorize will be changes second param 
            return Ok();
        }
        
    }
}