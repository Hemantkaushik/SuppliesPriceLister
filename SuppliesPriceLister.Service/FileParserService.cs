using AutoMapper;
using SuppliesPriceLister.DataManager.Interface;
using SuppliesPriceLister.Model;
using SuppliesPriceLister.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppliesPriceLister.Service
{
    public class FileParserService : IFileParserService
    {
        private readonly IFileParserDataManager _fileParserDataManager;
        private readonly IMapper _iMapper;
        public FileParserService(IFileParserDataManager fileParserDataManager, IMapper iMapper)
        {
            _fileParserDataManager = fileParserDataManager;
            _iMapper = iMapper;
        }
        public async  Task<IList<BuildingSupplyItem>> ProcessParsedFiles(string filePath)
        {
            var humphriesFileData = await _fileParserDataManager.GetParsedHumphriesFile(filePath);
            return _iMapper.Map<List<BuildingSupplyItem>>(humphriesFileData).ToList();
        }
    }
}
