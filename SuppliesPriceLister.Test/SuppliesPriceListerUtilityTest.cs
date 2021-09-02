using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuppliesPriceLister.Utility;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SuppliesPriceLister.Test
{
    [TestClass]
    public class SuppliesPriceListerUtilityTest
    {
        #region CurrencyConverterHelper
        [TestMethod]
        public void should_convert_USD_cent_and_return_AUD()
        {
            //Arrange
            decimal rate = 0.7M;
            decimal usdValue = 8000M;
            //Act
            var audvalue = usdValue.ConvertUSDCentsToAUD(rate);
            //Assert
            Assert.AreEqual(56.0M, audvalue);
        }

        [TestMethod]
        public void should_convert_USD_and_return_AUD()
        {
            //Arrange
            decimal rate = 0.7M;
            decimal usdValue = 80M;
            //Act
            var audvalue = usdValue.ConvertUSDToAUD(rate);
            //Assert
            Assert.AreEqual(56.0M, audvalue);
        }
        #endregion
        #region  JsonReadHelper
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "")]
        public async Task should_return_Json_file_not_found_exception()
        {
            //Arrange
            var filePath = Directory.GetCurrentDirectory() + "\\userdata1.json";
            //Act
            var fileData = await File.ReadAllTextAsync(filePath);
            var jsonData = JsonReadHelper.GetJsonContent<Test>(fileData);
            //Assert
            Assert.IsNotNull(jsonData);
        }

        [TestMethod]
        public async Task should_return_data_from_json_file()
        {
            //Arrange
            var filePath = Directory.GetCurrentDirectory() + "\\userdata.json";
            //Act
            var fileData = await File.ReadAllTextAsync(filePath);
            var jsonData = JsonReadHelper.GetJsonContent<Test>(fileData);
            //Assert
            Assert.IsNotNull(jsonData);
        }

        #endregion
    }
    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Test
    {
        public List<UserData> Users { get; set; }
    }
}
