using SuppliesPriceLister.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuppliesPriceLister.Service.Interface
{
    public interface IFileParserService
    {
        Task ProcessParsedFiles(string csvFilePath,string jSonFilePath);
    }
}
