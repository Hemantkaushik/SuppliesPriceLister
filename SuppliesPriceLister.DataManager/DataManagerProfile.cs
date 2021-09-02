using AutoMapper;
using SuppliesPriceLister.FileParserRepository.Model;


namespace SuppliesPriceLister.DataManager
{
    public class DataManagerProfile : Profile
    {
        public DataManagerProfile()
        {
            CreateMap<HumphriesModel, Model.HumphriesModel>().ReverseMap();
        }
    }
}
