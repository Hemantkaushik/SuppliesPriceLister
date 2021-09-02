using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliesPriceLister.Utility
{
    public static class JsonReadHelper
    {
        public static T GetJsonContent<T>(string fileData)
        {
            return JsonConvert.DeserializeObject<T>(fileData);
        }
    }
}
