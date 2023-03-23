using FurnitureShop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.WebUI.Models.DTO
{
    public class IndexFilterDTO
    {
        public int? skip { get; set; } = 0;
        public int? take { get; set; } = 10;
        public int? category { get; set; } = null;
        public int? minPrice { get; set; } = null;
        public int? maxPrice { get; set; } = null;
        public string? containPart { get; set; } = "";
    }
}
