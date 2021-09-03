using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Model
{
    public class Supply
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public decimal PriceInCents { get; set; }
        public string ProviderId { get; set; }
        public string MaterialType { get; set; }
    }
}
