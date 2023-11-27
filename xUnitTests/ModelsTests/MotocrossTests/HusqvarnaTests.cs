using VehEvalu8.Models.Interfaces;
using VehEvalu8.Models.Motocross;
using Xunit;
using xUnitTests.ModelsTests.Interfaces;

namespace xUnitTests.ModelsTests.MotocrossTests
{
    public class HusqvarnaTests : IModelsTests
    {
        [Fact]
        public void ModelsShouldInitializeCorrectly()
        {
            string model = "FC";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.husqvarna.com";
            int distance = 25;

            var testHusky = new Husqvarna(cc, year, priceForeign, link, distance);

            Assert.Equal("Husqvarna", testHusky.Make);
            Assert.Equal(model, testHusky.Model);
            Assert.Equal(cc, testHusky.CC);
            Assert.Equal(year, testHusky.Year);
            Assert.Equal(priceForeign, testHusky.PriceForeign);
            Assert.Equal(link, testHusky.Link);
            Assert.Equal(distance, testHusky.DistanceToPickUp);
        }

        [Fact]
        public void GetExpectedMarketPrice()
        {
            for (int year = 2007; year < 2024; year++)
            {
                var testHusky = new Husqvarna(250, year, 45000, "www.husqvarna.com", 15);
                Assert.Equal(MarketPricesByYear(testHusky.Year), testHusky.MarketPrice);
            }
        }

        [Fact]
        public void ModelsPropertiesMustHaveCorrectValues()
        {
            // Arrange
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.husqvarna.com";
            int distance = 25;

            // Act
            var testHusky = new Husqvarna(cc, year, priceForeign, link, distance);

            // Assert
            double expectedMarketPrice = MarketPricesByYear(year);
            Assert.Equal(expectedMarketPrice, testHusky.MarketPrice);
            double expectedPriceBGN = priceForeign * IMotorcycle.exchangeRateSEK;
            double expectedFuelCost = (double)(distance * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            double expectedTotalCost = expectedPriceBGN + expectedFuelCost + IMotorcycle.commission;
            Assert.Equal(expectedPriceBGN, testHusky.PriceBGN);
            Assert.Equal(expectedFuelCost, testHusky.FuelCost);
            Assert.Equal(expectedTotalCost, testHusky.TotalCost);
            double expectedProfit = expectedMarketPrice - expectedTotalCost;
            Assert.Equal(expectedProfit, testHusky.Profit);
            double expectedROI = expectedProfit / expectedTotalCost * 100.0;
            Assert.Equal(expectedROI, testHusky.ROI);
        }

        private static double MarketPricesByYear(int year)
        {
            switch (year)
            {
                case 2014: return 7200;
                case 2015: return 7500;
                case 2016: return 7900;
                case 2017: return 8100;
                case 2018: return 8500;
                case 2019: return 9200;
                case 2020: return 9800;
                case 2021: return 10500;
                case 2022: return 11000;
                case 2023: return 11500;
                default: return 0;
            }
        }
    }
}

