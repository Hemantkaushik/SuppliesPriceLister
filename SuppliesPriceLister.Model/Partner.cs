using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Model
{
    public class Partner
    {
        public string Name { get; set; }
        public string PartnerType { get; set; }
        public string PartnerAddress { get; set; }
        public List<Supply> Supplies { get; set; }
    }
}
