using SuppliesPriceLister.FileParserRepository.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliesPriceLister.FileParserRepository.Interface
{
    public interface IFileParserHumphries
    {
        Task<IList<HumphriesModel>> ParseFile(string filePath);
    }
}
