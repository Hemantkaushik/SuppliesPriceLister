using System;

namespace SuppliesPriceLister.FileParserRepository.Model
{
    public class HumphriesModel
    {
        public string Identifier { get; set; }
        public string Desc { get; set; }
        public string Unit { get; set; }
        public decimal CostAUD { get; set; }
    }
}
