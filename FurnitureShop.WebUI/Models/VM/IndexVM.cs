namespace FurnitureShop.WebUI.Models.VM
{
    public class IndexVM
    {
        public IEnumerable<FurnitureVM> Mapedlist { get; set; }
        public Dictionary<string,string> PreviousQuery { get; set; }
        public int CountMappedItem { get; set; }
    }
}
