using FurnitureShop.Core.Models;

namespace FurnitureShop.WebUI.Models.DTO
{
    public class IndexFilterDTO
    {
        public int? skip = 0;
        public int? take = 10;
        public int? category = null;
        public int? minPrice = null;
        public int? maxPrice = null;
        public string? containPart = "";
    }
}
