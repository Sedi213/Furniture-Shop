using AutoMapper;

namespace FurnitureShop.WebUI.MappingProfile
{
    public interface IMapWith<T>
    {
        //TODO ask about how correct this default impl
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
