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

        [HttpGet]
        public IActionResult Index([FromQuery] IndexFilterDTO? dto)
        {
            var rawlist = _sharedService.GetFurnitureByFilter(dto.skip ?? 0,
                                                              dto.take ?? 10,
                                                              (EnumCategory?)(dto.category),
                                                              dto.minPrice,
                                                              dto.maxPrice,
                                                              dto.containPart ?? "");//TODO Add validator
            var mapedlist = _mapper.Map<IEnumerable<Furniture>, IEnumerable<FurnitureVM>>(rawlist);
            var count = _sharedService.GetCountOfElementByFilter((EnumCategory?)(dto.category),
                                                              dto.minPrice,
                                                              dto.maxPrice,
                                                              dto.containPart ?? "");//twice ask to db not good .
                                                                                     //Need to rework
                                                                                     //But i cant return from repository smt that is not Furniture?
            
            var VM = new IndexVM()
            {
                mapedlist = mapedlist,
                CountMappedItem = count,
                previousQuery = GetDictionaryQueryByDTO(dto)
            };
            return View(VM);
        }

        [NonAction]
        private Dictionary<string,string> GetDictionaryQueryByDTO(IndexFilterDTO dto)
        {
            var dictionary = new Dictionary<string, string>();
            if (dto.containPart != string.Empty)
                dictionary.Add("containPart", dto.containPart);
            if (dto.category != null)
                dictionary.Add("category", dto.category.ToString());
            if (dto.minPrice != null)
                dictionary.Add("minPrice", dto.minPrice.ToString());
            if (dto.maxPrice != null)
                dictionary.Add("maxPrice", dto.maxPrice.ToString());
            if (dto.skip != null)
                dictionary.Add("skip", dto.skip.ToString());
            if (dto.take != null)
                dictionary.Add("take", dto.take.ToString());
            return dictionary;
        }

        [HttpGet("Views/FurniturePage/{id?}")]
        public IActionResult FurniturePage(Guid id)
        {
            var rawEntity = _sharedService.GetFurnitureById(id);
            var mappedEntity = _mapper.Map<Furniture, FurnitureVM>(rawEntity);
            return View(mappedEntity);
        }

        [HttpGet]
        public IActionResult Basket()
        {
            var rawList = _sharedService.GetBasketByUserId(Guid.Empty);//will be changed with IS4
            var mapedlist = _mapper.Map<IEnumerable<Furniture>, IEnumerable<FurnitureVM>>(rawList);
            return View(mapedlist);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
