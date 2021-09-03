using AutoMapper;
using Microsoft.Extensions.Options;
using SuppliesPriceLister.DataManager.Interface;
using SuppliesPriceLister.Model;
using SuppliesPriceLister.Service.Interface;
using SuppliesPriceLister.Utility;
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
        private readonly ConfigurationSetting _options;
        public FileParserService(IFileParserDataManager fileParserDataManager, IMapper iMapper, IOptions<ConfigurationSetting> options)
        {
            _fileParserDataManager = fileParserDataManager;
            _iMapper = iMapper;
            _options = options.Value;
        }
        public async  Task ProcessParsedFiles(string csvFilePath,string jsonFilePath)
        {
            var humphriesFileData = await _fileParserDataManager.GetParsedHumphriesFile(csvFilePath);
            var megaCorpFileData = await _fileParserDataManager.GetParsedMegaCorpFile(jsonFilePath);
            var desiredData  = _iMapper.Map<List<BuildingSupplyItem>>(humphriesFileData).ToList();

            foreach (var item in megaCorpFileData)
            {
                var jsonSupplyData = _iMapper.Map<List<BuildingSupplyItem>>(item.Supplies).ToList();
                jsonSupplyData.ForEach(d => d.Price = d.Price.ConvertUSDCentsToAUD(_options.AudUsdExchangeRate));
                desiredData = desiredData.Concat(jsonSupplyData).ToList();
            }
            foreach (var item in desiredData.OrderByDescending(d => d.Price))
            {
                Console.WriteLine(item.Id + " , " + item.Name + " , $" + string.Format("{0:0.00}", item.Price));
            }
        }
    }
}
