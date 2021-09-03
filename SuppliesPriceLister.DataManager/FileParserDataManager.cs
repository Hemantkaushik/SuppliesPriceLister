using AutoMapper;
using SuppliesPriceLister.DataManager.Interface;
using SuppliesPriceLister.FileParserRepository.Interface;
using SuppliesPriceLister.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliesPriceLister.DataManager
{
    public class FileParserDataManager : IFileParserDataManager
    {
        private readonly IFileParserHumphries _fileParserHumphries;
        private readonly IFileParserMegaCorp _fileParserMegacorp;
        private readonly IMapper _mapper;

        public FileParserDataManager(IFileParserHumphries fileParserHumphries, IMapper mapper, IFileParserMegaCorp fileParserMegacorp)
        {
            _fileParserHumphries = fileParserHumphries;
            _mapper = mapper;
            _fileParserMegacorp = fileParserMegacorp;
        }
        //
        public async Task<IList<HumphriesModel>> GetParsedHumphriesFile(string filePath)
        {
            var humphriesFileData = await _fileParserHumphries.ParseFile(filePath);
            return _mapper.Map<List<HumphriesModel>>(humphriesFileData);
        }
        public async Task<IList<Partner>> GetParsedMegaCorpFile(string filePath)
        {
            var megacorpFileData = await _fileParserMegacorp.ParseFile(filePath);
            return _mapper.Map<List<Partner>>(megacorpFileData);
        }
    }
}
