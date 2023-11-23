using VehEvalu8.Models.Motocross;
using VehEvalu8.Models.Interfaces;
using Xunit;
using xUnitTests.ModelsTests.Interfaces;

namespace xUnitTests.ModelsTests.MotocrossTests
{
    public class SuzukiTests : IModelsTests
    {
        [Fact]
        public void ModelsShouldInitializeCorrectly()
        {
            string model = "RM-Z";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.suzuki.com";
            int distance = 25;

            var testSuzuki = new Suzuki(cc, year, priceForeign, link, distance);

            Assert.Equal("Suzuki", testSuzuki.Make);
            Assert.Equal(model, testSuzuki.Model);
            Assert.Equal(cc, testSuzuki.CC);
            Assert.Equal(year, testSuzuki.Year);
            Assert.Equal(priceForeign, testSuzuki.PriceForeign);
            Assert.Equal(link, testSuzuki.Link);
            Assert.Equal(distance, testSuzuki.DistanceToPickUp);
        }

        [Fact]
        public void GetExpectedMarketPrice()
        {
            for (int year = 2007; year < 2024; year++)
            {
                var testSuzuki = new Suzuki(250, year, 45000, "www.suzuki.com", 15);
                Assert.Equal(MarketPricesByYear(testSuzuki.Year), testSuzuki.MarketPrice);
            }
        }

        [Fact]
        public void ModelsPropertiesMustHaveCorrectValues()
        {
            // Arrange
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.suzuki.com";
            int distance = 25;

            // Act
            var testSuzuki = new Suzuki(cc, year, priceForeign, link, distance);

            // Assert
            double expectedMarketPrice = MarketPricesByYear(year);
            Assert.Equal(expectedMarketPrice, testSuzuki.MarketPrice);
            double expectedPriceBGN = priceForeign * IMotorcycle.exchangeRateSEK;
            double expectedFuelCost = (double)(distance * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            double expectedTotalCost = expectedPriceBGN + expectedFuelCost + IMotorcycle.commission;
            Assert.Equal(expectedPriceBGN, testSuzuki.PriceBGN);
            Assert.Equal(expectedFuelCost, testSuzuki.FuelCost);
            Assert.Equal(expectedTotalCost, testSuzuki.TotalCost);
            double expectedProfit = expectedMarketPrice - expectedTotalCost;
            Assert.Equal(expectedProfit, testSuzuki.Profit);
            double expectedROI = expectedProfit / expectedTotalCost * 100.0;
            Assert.Equal(expectedROI, testSuzuki.ROI);
        }

        private static double MarketPricesByYear(int year)
        {
            switch (year)
            {
                case 2007: return 4400;
                case 2008: return 4600;
                case 2009: return 4800;
                case 2010: return 5200;
                case 2011: return 5600;
                case 2012: return 6000;
                case 2013: return 6300;
                case 2014: return 6500;
                case 2015: return 6700;
                case 2016: return 7300;
                case 2017: return 7700;
                case 2018: return 8300;
                case 2019: return 8900;
                case 2020: return 9400;
                case 2021: return 9800;
                case 2022: return 10000;
                case 2023: return 11000;
                default: return 0;
            }
        }
    }
}

