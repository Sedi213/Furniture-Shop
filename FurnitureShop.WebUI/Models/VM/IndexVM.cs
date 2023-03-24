namespace FurnitureShop.WebUI.Models.VM
{
    public class IndexVM
    {
        public IEnumerable<FurnitureVM> mapedlist { get; set; }
        public Dictionary<string,string> previousQuery { get; set; }
        public int CountMappedItem { get; set; }
    }
}
