using AutoMapper;
using SuppliesPriceLister.FileParserRepository.Model;


namespace SuppliesPriceLister.DataManager
{
    public class DataManagerProfile : Profile
    {
        public DataManagerProfile()
        {
            CreateMap<HumphriesModel, Model.HumphriesModel>().ReverseMap();
            CreateMap<Supply, Model.Supply>().ReverseMap();
            CreateMap<Partner, Model.Partner>().ReverseMap();
            CreateMap<MegaCorpModel, Model.MegaCorpModel>().ReverseMap();
        }
    }
}
