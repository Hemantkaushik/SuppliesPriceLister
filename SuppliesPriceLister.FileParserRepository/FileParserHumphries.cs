using SuppliesPriceLister.FileParserRepository.Interface;
using SuppliesPriceLister.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliesPriceLister.FileParserRepository
{
    public class FileParserHumphries : IFileParserHumphries
    {
        public Task<IList<HumphriesModel>> ParseFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
