using AutoMapper;
using FurnitureShop.Core.Services;
using FurnitureShop.WebUI.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.WebUI.Controllers
{
    public class SellerViewController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly IMapper _mapper;
        public SellerViewController(SellerService sellerService, IMapper mapper)
        {
            _sellerService = sellerService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]// TODO IS4
        public IActionResult SellerFurnitures()
        {
            var furnitures = _sellerService.GetSellerFurnitures(Guid.Empty);//TODO IS4
            var mappedFr = _mapper.Map<IEnumerable<SellerFurnitureVM>>(furnitures);
            return View(mappedFr);
        }
    }
}
