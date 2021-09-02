using SuppliesPriceLister.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliesPriceLister.DataManager.Interface
{
    public interface IFileParserDataManager
    {
        Task<IList<HumphriesModel>> GetParsedFile(string filePath);
    }
}
