using SuppliesPriceLister.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuppliesPriceLister.FileParserRepository.Interface
{
    public interface IFileParserHumphries
    {
        Task<IList<HumphriesModel>> ParseFile(string filePath);
    }
}
