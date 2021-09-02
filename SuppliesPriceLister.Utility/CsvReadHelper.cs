using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace SuppliesPriceLister.Utility
{
    public static class CsvReadHelper
    {
        public static List<T> GetCsvContents<T>(string CsvFile)
        {
            List<T> ReturnContents = new List<T>();

            using (CsvReader ReadCsv = new CsvReader(new StreamReader(CsvFile), System.Globalization.CultureInfo.CurrentCulture))
            {
                ReturnContents.AddRange(ReadCsv.GetRecords<T>());
            }

            return ReturnContents;
        }
    }
}
