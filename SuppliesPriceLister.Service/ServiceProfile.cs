using AutoMapper;
using SuppliesPriceLister.Model;

namespace SuppliesPriceLister.DataManager
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<BuildingSupplyItem, HumphriesModel>()
                    .ForMember(source => source.Identifier, d => d.MapFrom(dest => dest.Id))
                    .ForMember(source => source.Desc, d => d.MapFrom(dest => dest.Name))
                    .ForMember(source => source.CostAUD, d => d.MapFrom(dest => dest.Price)).ReverseMap();
        }
    }
}
