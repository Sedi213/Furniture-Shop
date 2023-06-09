﻿using AutoMapper;
using FurnitureShop.WebUI.MappingProfile;
using FurnitureShop.Core.Models;

namespace FurnitureShop.WebUI.Models.VM
{
    public class FurnitureVM : IMapWith<Furniture>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumCategory Category { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Furniture, FurnitureVM>()
                .ForMember(frVm => frVm.Id,
                    opt => opt.MapFrom(fr => fr.Id))
                .ForMember(frVm => frVm.Name,
                    opt => opt.MapFrom(fr => fr.Name))
                .ForMember(frVm => frVm.Category,
                    opt => opt.MapFrom(fr => fr.Category))
                .ForMember(frVm => frVm.Price,
                    opt => opt.MapFrom(fr => fr.Price))
                .ForMember(frVm => frVm.ImgUrl,
                    opt => opt.MapFrom(fr => fr.ImgUrl));

        }
    }
}
