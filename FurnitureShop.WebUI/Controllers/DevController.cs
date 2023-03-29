using FurnitureShop.Core.Helper;
using FurnitureShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.WebUI.Controllers
{
    public class DevController : Controller
    {
        private readonly DataHelper _helper;

        public DevController(DataHelper helper)
        {   
            _helper=helper;
        }
        public IActionResult AddData()
        {
            _helper.FillTableTestData();
            return Ok();
        }
    }
}
