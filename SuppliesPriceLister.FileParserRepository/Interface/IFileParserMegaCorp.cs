using SuppliesPriceLister.FileParserRepository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuppliesPriceLister.FileParserRepository.Interface
{
    public interface IFileParserMegaCorp
    {
        Task<IList<Partner>> ParseFile(string filePath);
    }
}
