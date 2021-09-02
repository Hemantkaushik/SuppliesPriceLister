using SuppliesPriceLister.FileParserRepository.Interface;
using SuppliesPriceLister.FileParserRepository.Model;
using SuppliesPriceLister.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliesPriceLister.FileParserRepository
{
    public class FileParserHumphries : IFileParserHumphries
    {
        public async  Task<IList<HumphriesModel>> ParseFile(string filePath)
        {
            var csvData = await Task.Run(() => CsvReadHelper.GetCsvContents<HumphriesModel>(filePath));
            return csvData;
        }
    }
}
