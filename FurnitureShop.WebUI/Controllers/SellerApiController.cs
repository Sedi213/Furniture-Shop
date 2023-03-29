using FurnitureShop.Core.Services;
using FurnitureShop.WebUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.WebUI.Controllers
{
    public class SellerApiController : Controller
    {
        private readonly SellerService _sellerService;

        public SellerApiController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpPost]
        //[Authorize]//feature for future identityserver4
        public IActionResult NewFurniture(NewFurnitureDTO dto)
        {
            //if(User.Role==1) 
            //TODO Add check role with IS4
            _sellerService.AddNewFurniture(
                dto.Name,
                dto.Category,
                dto.Price,
                dto.ImgUrl,
                Guid.Empty);//TODO IS4
            return Ok();
        }
    }
}
