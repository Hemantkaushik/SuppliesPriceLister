using SuppliesPriceLister.FileParserRepository.Interface;
using SuppliesPriceLister.FileParserRepository.Model;
using SuppliesPriceLister.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SuppliesPriceLister.FileParserRepository
{
    public class FileParserMegaCorp : IFileParserMegaCorp
    {
        public async Task<IList<Partner>> ParseFile(string filePath)
        {
            var fileData = await Task.Run(() => File.ReadAllText(filePath));
            var partnerData = await Task.Run(() => JsonReadHelper.GetJsonContent<MegaCorpModel>(fileData));
            return partnerData.Partners;
        }
    }
}
