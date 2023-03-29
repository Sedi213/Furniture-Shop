using AutoMapper;
using FurnitureShop.Core.Models;
using FurnitureShop.Core.Services;
using FurnitureShop.WebUI.Models;
using FurnitureShop.WebUI.Models.DTO;
using FurnitureShop.WebUI.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
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

        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
            );
            return LocalRedirect(returnUrl);
        }


        [HttpPost]
        //[Authorize]//feature for future identityserver4
        public IActionResult AddToBasket([FromBody] Guid Id)
        {
            _sharedService.AddToBasket(Id, Guid.Empty);//With authorize will be changes second param 
            return Ok();
        }
        [HttpPost]
        //[Authorize]//feature for future identityserver4
        public IActionResult DeleteFromBasket([FromBody] Guid Id)
        {
            _sharedService.DeleteFromBasket(Id, Guid.Empty);//With authorize will be changes second param 
            return Ok();
        }

    }
}