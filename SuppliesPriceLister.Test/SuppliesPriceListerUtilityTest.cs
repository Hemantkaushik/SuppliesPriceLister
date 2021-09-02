using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuppliesPriceLister.Utility;

namespace SuppliesPriceLister.Test
{
    [TestClass]
    public class SuppliesPriceListerUtilityTest
    {
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
    }
}
