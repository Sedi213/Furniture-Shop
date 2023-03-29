using AutoMapper;
using FurnitureShop.Core.Models;
using FurnitureShop.WebUI.MappingProfile;
using FurnitureShop.WebUI.Models.VM;
using System.ComponentModel.DataAnnotations;

namespace FurnitureShop.WebUI.Models.DTO
{
    public class NewFurnitureDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string ImgUrl { get; set; }
    }


}
