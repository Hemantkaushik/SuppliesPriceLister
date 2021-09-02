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
        private readonly IMapper _mapper;

        public FileParserDataManager(IFileParserHumphries fileParserHumphries, IMapper mapper)
        {
            _fileParserHumphries = fileParserHumphries;
            _mapper = mapper;
        }
        public async Task<IList<HumphriesModel>> GetParsedHumphriesFile(string filePath)
        {
            var humphriesFileData = await _fileParserHumphries.ParseFile(filePath);
            return _mapper.Map<List<HumphriesModel>>(humphriesFileData);
        }
    }
}
